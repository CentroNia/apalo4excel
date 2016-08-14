 /* 
 *
 * Copyright (C) 2006-2011 Jedox AG
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License (Version 2) as published
 * by the Free Software Foundation at http://www.gnu.org/copyleft/gpl.html.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 59 Temple
 * Place, Suite 330, Boston, MA 02111-1307 USA
 *
 * You may obtain a copy of the License at
 *
 * <a href="http://www.jedox.com/license_palo_bi_suite.txt">
 *   http://www.jedox.com/license_palo_bi_suite.txt
 * </a>
 *
 * If you are developing and distributing open source applications under the
 * GPL License, then you are free to use Palo under the GPL License.  For OEMs,
 * ISVs, and VARs who distribute Palo with their products, and do not license
 * and distribute their source code under the GPL, Jedox provides a flexible
 * OEM Commercial License.
 *
 * \author
 * 
 *
 */
using System;
using System.Collections;
using System.IO;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;


namespace Apalo.XlAddin.Utils
{
	[ComVisible(false)]
	public class CsvReader : System.IDisposable
	{
		private char separator;
		private string decpoint;
		private int codepage;
		private int pagesize = 0;
		private long wholecount = 0;
		private long ccount = 0;
        private long recordssofar;
        private string[] types;

		private ExcelHelper eH = new ExcelHelper();
		private Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();
		private string[] format = null;

		//name of CSV file
		private string m_filename;
		
		//tablename
		private string m_tablename;

		//stream reader
		private StreamReader m_reader;

		//file contains header row?
		private bool m_hasheader;

		private IFormatProvider culture1 = new CultureInfo("de-DE", false);
		private IFormatProvider culture2 = new CultureInfo("hu-HU", false);

        private int buffersize = 0;
        
		public CsvReader(string filename, bool hasHeader, char separator, string decpoint, int codepage, int pagesize )
		{
			this.separator = separator;
			//set filename
			m_filename = filename;

			System.IO.FileInfo fi = new FileInfo(m_filename);

			//tablename is filename without dim and extension
			m_tablename = fi.Name.Replace("." + fi.Extension ,"");
        
			//set whether file contains a header row with column names
			m_hasheader = hasHeader;

			this.decpoint = decpoint;
			this.codepage = codepage;
			this.pagesize = pagesize;

		}

		private void check4types(ref object[] rowbuffer)
		{
			double zahl = 0;
			string swert = "";
			int count = rowbuffer.Length;
			for (int i = 0; i < count; i++)
			{
				swert = rowbuffer[i].ToString();

                if ((this.types[i] != "System.String") && ((swert == "") || !System.Double.TryParse(swert, NumberStyles.Number, Thread.CurrentThread.CurrentUICulture, out zahl) ))
				{
					rowbuffer[i] = System.DBNull.Value;
				}
			}
		}

        private long ExtimateNumberRecords()
        {
            double bcount = this.ccount;
            if (bcount == 0) bcount = 1;

            return System.Convert.ToInt64(System.Math.Ceiling((double)(this.recordssofar * this.wholecount / bcount)));
        }   

		public long Start(System.Data.DataSet dataSet)
		{
            
			this.ccount = 0;
            this.recordssofar = 0;
            int i, records = 0;

            Apalo.XlAddin.Utils.ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.STATUS_READ_CSV);

			//table within the dataset
			DataTable dt = dataSet.Tables.Add(this.m_tablename);

			//raw row
			string rawrow;
			//store the current row
			object[] rowbuffer = new string[0];
			object[] tmprowbuffer = new string[0];

			//more records
			bool morerecords = true;

            if (!File.Exists(m_filename))
            {
                System.Windows.Forms.MessageBox.Show(Apalo.XlAddin.Utils.ResourceInitializer.Replace(Apalo.XlAddin.Utils.ResourceInitializer.ERROR_FILE_NOT_FOUND, new object[] { m_filename }));
                return 0;
            }
            //open stream to read from file
			m_reader = new StreamReader(m_filename, System.Text.Encoding.GetEncoding(this.codepage));

			this.wholecount = m_reader.BaseStream.Length;

            if (this.wholecount == 0) this.wholecount = 1;

			if(m_hasheader)
			{
				//read header row
				rawrow = m_reader.ReadLine();
				if (rawrow != null) 
				{
					this.ccount += rawrow.Length + 1;
				}
			}

			do
			{
				//read line
				rawrow = m_reader.ReadLine();

				if (rawrow==null)
				{
					morerecords = false;
				}
				else
				{
					this.ccount += rawrow.Length +1;

					if (rawrow.Length > 0)
					{
						//read the first row and get the length
						rowbuffer = SplitRow(rawrow, this.separator, this.decpoint);

						int rblength = rowbuffer.Length;
                
						this.types = new string[rblength];
						this.format = new string[rblength];

                        this.buffersize = rowbuffer.Length;

                        for (int iColumn = 0; iColumn < this.buffersize; iColumn++)
						{
							//add to columns collection
							DataColumn dc = dt.Columns.Add("Column " + iColumn.ToString());
							this.format[iColumn] = this.eH.Create_Range(1,iColumn+1,this.ws).NumberFormat.ToString();
							/*
											if (format[iColumn] != "@")
											{
												dc.DataType = rowbuffer[iColumn].GetType();
											}
											else
											{
												dc.DataType = System.String.Empty.GetType();
											}
							*/
							dc.DataType = typeof(System.String);
							this.types[iColumn] = dc.DataType.FullName;
							dc.AllowDBNull = true;
						}
					}
				}
			} while (morerecords && (rawrow.Length == 0));

			//processing of further rows goes here
			while(morerecords)
			{
				//add values to row and insert into table
//				this.check4types(ref rowbuffer);
                if (rowbuffer.Length > this.buffersize)
                {
                    tmprowbuffer = rowbuffer;
                    rowbuffer = new Object[this.buffersize];
                    for (i = 0; i < this.buffersize; i++)
                    {
                       rowbuffer[i] = tmprowbuffer[i];
                    }
                }

                dt.Rows.Add(rowbuffer);

				//increment rows affected
				records++;

				if (records >= this.pagesize) break;

				do
				{
					//read the next row
					rawrow = m_reader.ReadLine();

					if (rawrow==null)
					{
						morerecords = false;
					}
					else
					{
						this.ccount += rawrow.Length +1;
			
						if (rawrow.Length > 0)
						{
							//read the first row and get the length
							rowbuffer = SplitRow(rawrow,separator, this.decpoint);

                            if ((records % 1000) == 0)
                            {
                                Apalo.XlAddin.Utils.ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.STATUS_READ_CSV + (this.ccount * 100 / this.wholecount) + " %.");
                            }
						}
					}
				} while ( morerecords && (rawrow.Length == 0));
			}

            this.recordssofar = records;

			//mark dataset as up-to-date
			dataSet.AcceptChanges();

            Apalo.XlAddin.Utils.ExcelHelper.ResetExcelStatusbar();

            return ExtimateNumberRecords();
		}

		public long Next(System.Data.DataSet dataSet)
		{

            Apalo.XlAddin.Utils.ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.STATUS_READ_CSV);

            //table within the dataset
            DataTable dt = dataSet.Tables[0];

			//raw row
			string rawrow;

			//store records affected
			int i, records = 0;

			//store the current row
			object[] rowbuffer = new string[0];
            object[] tmprowbuffer = new string[0];

			//more records
			bool morerecords = true;

			//open stream to read from file
//			m_reader = new StreamReader(m_filename, System.Text.Encoding.GetEncoding(this.codepage));
//			m_reader.BaseStream.Position = this.ccount;

            if (m_reader != null)
            {
                do
                {
                    //read line
                    rawrow = m_reader.ReadLine();

                    if (rawrow == null)
                    {
                        morerecords = false;
                    }
                    else
                    {
                        this.ccount += rawrow.Length + 1;
                        if (rawrow.Length > 0)
                        {
                            //read the first row and get the length
                            rowbuffer = SplitRow(rawrow, this.separator, this.decpoint);
                        }
                    }
                } while (morerecords && (rawrow.Length == 0));

                //processing of further rows goes here
                while (morerecords)
                {

                    //add values to row and insert into table
                    //  				this.check4types(ref rowbuffer);
                    if (rowbuffer.Length > this.buffersize)
                    {
                        tmprowbuffer = rowbuffer;
                        rowbuffer = new Object[this.buffersize];
                        for (i = 0; i < this.buffersize; i++)
                        {
                            rowbuffer[i] = tmprowbuffer[i];
                        }
                    }
                    dt.Rows.Add(rowbuffer);

                    //increment rows affected
                    records++;

                    if (records >= this.pagesize) break;

                    do
                    {
                        //read the next row
                        rawrow = m_reader.ReadLine();

                        if (rawrow == null)
                        {
                            morerecords = false;
                        }
                        else
                        {
                            this.ccount += rawrow.Length + 1;

                            if (rawrow.Length > 0)
                            {
                                //read the first row and get the length
                                rowbuffer = SplitRow(rawrow, separator, this.decpoint);

                                if ((records % 1000) == 0)
                                {
                                    Apalo.XlAddin.Utils.ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.STATUS_READ_CSV + (this.ccount * 100 / this.wholecount) + " %.");
                                }
                            }
                        }
                    } while (morerecords && (rawrow.Length == 0));
                }
            }

            Apalo.XlAddin.Utils.ExcelHelper.ResetExcelStatusbar();

            this.recordssofar += records;

            //mark dataset as up-to-date
            dataSet.AcceptChanges();

            return ExtimateNumberRecords();

		}

		private static string QuoteString(object inString)
		{
			if(inString.ToString().IndexOf(' ') > -1 || inString.ToString().IndexOf(',') > -1)
			{
				return "\"" + inString.ToString() + "\"";
			}
			else
			{
				return inString.ToString();
			}
		}

		private static string BuildRow(object[] values)
		{
			//create string for a single output row
			string row = "";

			//loop for each item in the row
			foreach(object column in values)
			{
				if(column != null)
				{
					//add the item (with quotes as appropriate
					row += QuoteString(column);
				}

				//add the delimiting character
				row += ",";
			}
            
			//remove the extra delimiter at the end
			row = row.Remove(row.Length - 1, 1);

			return row;
		}

		private bool check4spezialdate(string orig)
		{
			bool ok = false;
			double laenge = orig.Length;

			if ((laenge >= 6) && (laenge <= 10) && (orig.IndexOf(",") == -1) && (orig.IndexOf(".") > -1))
			{
				try
				{
					DateTime.Parse(orig, culture1);
					ok = true;
				}
				catch
				{}
				
				if (!ok)
				{
					try
					{
						DateTime.Parse(orig, culture2);
						ok = true;
					}
					catch
					{}
				}
			}

			return ok;
		}

		private object check4number(string orig, string decpoint, int i)
		{
			double zahl = 0;
			bool ok = false;

			string numberformat = "";

			if (this.format == null)
			{
				numberformat = this.eH.Create_Range(1,i+1,this.ws).NumberFormat.ToString();
			}
			else
			{
				if (i< this.format.Length)
				{
					numberformat = this.format[i];
				}
				else
				{
					numberformat = this.eH.Create_Range(1,i+1,this.ws).NumberFormat.ToString();
				}
			}

		
			if ((numberformat != "@") && !this.check4spezialdate(orig))
			{

//				ok = System.Double.TryParse(orig.Replace(decpoint, "."), NumberStyles.Number, Thread.CurrentThread.CurrentUICulture, out zahl);
				

 				string tmpstr = orig.Replace(" ", "");
                /*
				CultureInfo ci = (CultureInfo)Thread.CurrentThread.CurrentUICulture.Clone();

 				ci.NumberFormat.CurrencyDecimalSeparator = decpoint;
				ci.NumberFormat.NumberDecimalSeparator = decpoint;
				ci.NumberFormat.PercentDecimalSeparator = decpoint;

				switch(decpoint)
				{
					case ".":
						ci.NumberFormat.CurrencyGroupSeparator = ",";
						ci.NumberFormat.NumberGroupSeparator = ",";
						ci.NumberFormat.PercentGroupSeparator = ",";
						break;
					case ",":
						ci.NumberFormat.CurrencyGroupSeparator = ".";
						ci.NumberFormat.NumberGroupSeparator = ".";
						ci.NumberFormat.PercentGroupSeparator = ".";
						break;
				}
                */

                tmpstr = tmpstr.Replace(decpoint, ".");

//				ok = System.Double.TryParse(tmpstr, NumberStyles.Number, ci, out zahl);
                ok = System.Double.TryParse(tmpstr, NumberStyles.Number | NumberStyles.AllowExponent, Thread.CurrentThread.CurrentUICulture, out zahl);

			}

			if (ok)
			{
				return zahl;
			}
			else
			{
				return orig;
			}
		}

		private object[] SplitRow(string row, char seperator, string decpoint)
		{
			int i = 0;
			//splitting with special cases
			string[] segments = row.Split(seperator);
			//store the fixedup segments
			ArrayList parsedsegments = new ArrayList();
			bool iscontinuation = false;
			string buffer = "";

			for(int iSegment = 0; iSegment < segments.Length; iSegment++)
			{
				//if value begins with a quote
				if(segments[iSegment].StartsWith("\""))
				{
					//if value also ends with a quote
					if(segments[iSegment].EndsWith("\""))
					{
						//string is unbroken quoted value
						parsedsegments.Add(segments[iSegment].Trim('"'));
						i++;
					}
					else
					{
						//string is beginning of quoted value (which contained a comma)
						buffer = segments[iSegment].TrimStart('"');
                        
						//flag that following section(s) are part of this quoted string
						iscontinuation = true;
					}
				}
				else
				{
					if(iscontinuation)
					{
						if(segments[iSegment].EndsWith("\""))
						{
							//add buffer, comma and this last section with quotes removed
							parsedsegments.Add(buffer + "," + segments[iSegment].TrimEnd('"'));
							i++;

							//this is the end of a continuation
							iscontinuation = false;
						}
						else
						{
							//add this section and continue
							buffer += "," + segments[iSegment];
						}
					}
					else
					{
						//item is an unquoted value - add straight in
						parsedsegments.Add(this.check4number(segments[iSegment],decpoint, i));
						i++;
					}
				}
			}

			return (object[])parsedsegments.ToArray(typeof(object));
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void cleanup()
		{
			if (this.m_reader != null)
			{
				this.m_reader.Close();
				this.m_reader = null;
			}

		}

		protected virtual void Dispose(bool disposing)
		{
			if(disposing == true)
			{
				this.cleanup();
			}
		}
	}
}