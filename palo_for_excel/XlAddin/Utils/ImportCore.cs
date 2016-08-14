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
using System.IO;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using Apalo.XlAddin.Forms;

namespace Apalo.XlAddin.Utils
{

	public delegate void PaloThread(Object Sender);

    [ComVisible(false)]
    class CsvWriter : IDisposable
    {
        private string m_filename = "";

        private StreamWriter m_sw = null;

        public CsvWriter(string csvFile, string newline, bool append2csv, int codepage)
        {
            m_filename = csvFile;
            if (!string.IsNullOrEmpty(m_filename))
            {
                m_sw = new StreamWriter(m_filename, append2csv, System.Text.Encoding.GetEncoding(codepage));
                m_sw.NewLine = newline;
            }
        }

        public bool WriteLine(string line)
        {
            try
            {
                m_sw.WriteLine(line);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error writing to file " + m_filename + ":", ex);
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            if (m_sw != null)
            {
                m_sw.Flush();
                m_sw.Close();
                m_sw.Dispose();
                m_sw = null;
            }
            m_filename = null;
        }
    }
    
	[ComVisible(false)]
	class ImportCore : IDisposable
	{

		public event PaloThread Terminating;

		public const byte IMPORT_CSV = 0;
        public const byte IMPORT_ODBC = 1;
        public const byte IMPORT_CUBE = 2;
        public const byte IMPORT_INTERNAL_LOOP = 3;
        public const byte EXPORT = 4;

		private const byte NR_OF_BARS = 30;
		private const int MAX_XLCELLS = 5460;
		private const int PAGESIZE = 10000;
		private const int CUBEPAGESIZE = 10000;

		private CsvReader CSVda = null;
        private CsvWriter cw = null;
        private PaloSqlReader SQLda = null;
		private PaloCubeReader CUBEda = null;
		private int realsize = PAGESIZE;

		private DataSet ds = null;
        private string fname = "";
		private int step = 0;
		private long maxrowcount = 0;
		private long actvalue = 0;
		private byte import_mode = IMPORT_CSV;
		private bool do_abort = false;
		private bool screenupdating;
        private bool has_finished;
        private ExcelHelper eH = null;
		private System.Windows.Forms.ProgressBar ImportProgress;
//		private int progresslimit = 0;

		private int rcount = 0;
		private int ccount = 0;
		private int codepage = -1;
		private CultureInfo originalCulture;

		private string dsn = "";
		private string user = "";
		private string password = "";
		private string sql_cmd= "";

		private bool has_header = false;
		private char separator = ' ';
		private string decpoint = "";
        private bool withHeader = true;

		private Jedox.Palo.Comm.Connection conn;
		private string db;
		private string cube;
		private ArrayList elements;
		private ArrayList restrictions;

		private ImportWizard iform = null;
		private ExportWizard eform = null;
        private System.Windows.Forms.Form fform = null;
        private bool doblank = false;

        Excel.Range A1;
        Excel.Range B1;

        /// <summary>
        /// Constructor for Wizard
        /// </summary>
        /// <param name="originalCulture">Culture</param>
        /// <param name="eH">ExcelHelper</param>
        /// <param name="ImportProgress">ProgressBar</param>
        /// <param name="form">Wizard</param>


        public ImportCore(CultureInfo originalCulture, ExcelHelper eH, ref System.Windows.Forms.ProgressBar ImportProgress, System.Windows.Forms.Form form)
        {
            this.originalCulture = originalCulture;
            this.codepage = originalCulture.TextInfo.ANSICodePage;
            this.eH = eH;
            this.ImportProgress = ImportProgress;
            if (form is ImportWizard)
            {
                this.iform = (ImportWizard)form;
            }
            else
            {
                if (form is ExportWizard)
                {
                    this.eform = (ExportWizard)form;
                }
            }
        }
        /// <summary>
        /// Constructor for Form
        /// </summary>
        /// <param name="originalCulture">Culture</param>
        /// <param name="eH">ExcelHelper</param>
        /// <param name="form">Form</param>
        public ImportCore(CultureInfo originalCulture, ExcelHelper eH, System.Windows.Forms.Form form)
        {
            this.originalCulture = originalCulture;
            this.codepage = originalCulture.TextInfo.ANSICodePage;
            this.eH = eH;

            this.fform = form;
        }

		public void clean_up()
		{
			this.step = 0;

            /*
            if (this.doblank)
            {
                if (this.import_mode == IMPORT_INTERNAL_LOOP)
                {
                    this.eH.ClearRange(1, 1, (Excel.Worksheet)Apalo.XlAddin.Utils.ExcelHelper.oExcelApp.ActiveSheet);
                }
                else
                {
                    if (ccount > 0)
                    {
                        this.eH.ClearRange(1, 1, 1, ccount, (Excel.Worksheet)Apalo.XlAddin.Utils.ExcelHelper.oExcelApp.ActiveSheet);
                    }
                }
            }
            */

			if (this.SQLda != null)
			{
				this.SQLda.Dispose();
				this.SQLda = null;
			}

			if (this.CSVda != null)
			{
				this.CSVda.cleanup();
				this.CSVda.Dispose();
				this.CSVda = null;
			}

            if (this.cw != null)
            {
                this.cw.Dispose();
                this.cw = null;
            }

			if (this.CUBEda != null)
			{
				this.CUBEda.Dispose();
				this.CUBEda = null;
			}
            this.doblank = false;
		}

		public void Dispose()
		{
			this.clean_up();
		}

		public void Terminate()
		{
			this.do_abort = true;
		}

		public bool empty()
		{
			return ((this.rcount * this.ccount) == 0 && (this.import_mode != IMPORT_INTERNAL_LOOP));  
		}

		public void set_screenupdating(bool do_upd)
		{
			this.screenupdating = do_upd;
		}

		public void set_odbc_params(string dsn, string user, string password, string sql_cmd)
		{
			this.import_mode = IMPORT_ODBC;
			this.dsn = dsn;
			this.user = user;
			this.password = password;
			this.sql_cmd= sql_cmd;
		}

        public void set_csv_params(string fname, bool has_header, char separator, string decpoint, bool append2csv, int newlineart, bool for_export)
        {
            if (for_export)
            {
                this.import_mode = EXPORT;
            }
            else
            {
                this.import_mode = IMPORT_CSV;
            }

            this.fname = fname;
            this.has_header = has_header;
            this.separator = separator;
            this.decpoint = decpoint;

            string newline = GeneralConst.WINDOWS_NEWLINE;

            switch (newlineart)
            {
                case 1:
                    newline = GeneralConst.UNIX_NEWLINE;
                    break;

                case 2:
                    newline = GeneralConst.MAC_NEWLINE;
                    break;
            }

            if (for_export)
            {
                cw = new CsvWriter(fname, newline, append2csv, this.codepage);
            }
        }

        public void set_withHeader(bool withHeader)
        {
            this.withHeader = withHeader;
        }

		public void set_cube_params(Jedox.Palo.Comm.Connection conn, string db, string cube, ArrayList elements, ArrayList restrictions)
		{
			this.import_mode = IMPORT_CUBE;
			this.conn = conn;
			this.db = db;
			this.cube = cube;
			this.elements = elements;
			this.restrictions = restrictions;
		}

        public void set_internal_mode_params()
        {
            this.import_mode = IMPORT_INTERNAL_LOOP;
            Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();
            this.A1 = this.eH.Create_Range(1, 1, ws);
            this.B1 = this.eH.Create_Range(1, 2, ws);
        }

        public void SetBlank(bool doblank)
        {
            this.doblank = doblank;
        }

        public void start()
        {
            this.ds = new DataSet();
            this.maxrowcount = 0;
            this.rcount = 0;
            this.ccount = 0;
            this.has_finished = false;
            this.do_abort = false;
            this.step = 0;

            switch (this.import_mode)
            {
                case IMPORT_CSV:
                    this.realsize = PAGESIZE;
                    this.CSVda = new CsvReader(this.fname, this.has_header, this.separator, this.decpoint, this.codepage, this.realsize);
                    this.maxrowcount = this.CSVda.Start(this.ds);
                    break;
                case IMPORT_ODBC:
                    this.realsize = PAGESIZE;
                    this.SQLda = new PaloSqlReader(this.dsn, this.user, this.password, this.sql_cmd, this.realsize);
                    this.maxrowcount = this.SQLda.Start(this.ds);
                    break;
                case IMPORT_CUBE:
                    this.realsize = CUBEPAGESIZE;
                    this.CUBEda = new PaloCubeReader(this.conn, this.db, this.cube, this.elements, this.restrictions, this.originalCulture, this.realsize);
                    this.maxrowcount = this.CUBEda.Start(this.ds);
                    break;

                case IMPORT_INTERNAL_LOOP:
                    this.step = 1;
                    break;
            }
            try
            {
                this.rcount = this.ds.Tables[0].Rows.Count;
                this.ccount = this.ds.Tables[0].Columns.Count;
            }
            catch
            {
                this.rcount = 0;
                this.ccount = 0;
            }

            if (this.ImportProgress != null)
            {
                this.ImportProgress.Maximum = 100;
            }
//            this.progresslimit = 95;
        }

		private void get_next()
		{
			this.ds.Clear();
			GC.Collect();

            if (do_abort)
            {
                this.rcount = 0;
            }
            else
            {
                if ((this.import_mode == IMPORT_ODBC) && (this.SQLda != null))
                {
                    this.maxrowcount = this.SQLda.Next(this.ds);
                }
                else if ((this.import_mode == IMPORT_CSV) && (this.CSVda != null))
                {
                    this.maxrowcount = this.CSVda.Next(this.ds);
                }
                else if ((this.import_mode == IMPORT_CUBE) && (this.CUBEda != null))
                {
                    this.maxrowcount = this.CUBEda.Next(this.ds);
                }

                try
                {
                    this.rcount = this.ds.Tables[0].Rows.Count;
                }
                catch
                {
                    this.rcount = 0;
                }
            }
		}

		private void go_out()
		{
			this.clean_up();
			this.step = 0;
			this.actvalue = 0;
			if (this.iform != null)
			{
				this.iform.do_exit();
			}
			else
			{
				if (this.eform != null)
				{
					this.eform.do_exit();
				}
				else
				{
                    if (Terminating != null)
                    {
                        Terminating(new object());
                    }
				}
			}
		}


		private bool isnumeric(object o)
		{
			bool ret;

			switch(o.GetType().FullName)
			{
				case "System.Byte" :
				case "System.Decimal" :
				case "System.Double" :
				case "System.Int16" :
				case "System.Int32" :
				case "System.Int64" :
				case "System.SByte" :
				case "System.Single" :
				case "System.UInt16" :
				case "System.UInt32" :
				case "System.UInt64" :
					ret = true;
					break;
				default:
					ret = false;
					break;
			}
			return ret;
		}

        private void upd_progress()
        {
            if (this.ImportProgress != null)
            {
                int val = 0;
                if (this.maxrowcount > 0)
                {
                    val = System.Convert.ToInt32(System.Math.Floor((double)(this.actvalue * 100 / this.maxrowcount)));
                    if (val < this.ImportProgress.Minimum)
                    {
                        val = this.ImportProgress.Minimum;
                    }
                    if (val > this.ImportProgress.Maximum)
                    {
                        val = this.ImportProgress.Maximum;
                    }
                    this.ImportProgress.Value = val;
                }
            }
        }


		private void inc_progress()
		{
            this.actvalue++;
            if (this.ImportProgress != null)
            {
//              if (this.ImportProgress.Value < this.progresslimit)
                {
                    this.upd_progress();
                }
            }
		}

		[STAThread]
		public void t_insertRow()
		{
			Thread thisThread = Thread.CurrentThread;
			
			thisThread.CurrentCulture = new CultureInfo("en-US");
			thisThread.CurrentUICulture = new CultureInfo("en-US");

			this.do_abort = false;
			ulong clines = 0;

			try
			{
				
				object o = System.Reflection.Missing.Value;
                Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();
				Connect.InPaste = false;
                // @@@				ExcelHelper..ScreenUpdating(this.screenupdating);

                if (this.import_mode == IMPORT_INTERNAL_LOOP)
                {
                    do
                    {
                        this.eH.AddItemToSpreadsheet(this.A1, step.ToString());
                        ExcelHelper.CalculateActivesheet();
                        ++step;
                    } while (!this.eH.IsError(this.B1) && (step <= 65536) && !this.do_abort);
                }
                else
                {
                    string swert;
                    double zahl;

                    long bcount = (this.maxrowcount + NR_OF_BARS - 1) / NR_OF_BARS;

                    if (bcount * this.ccount > MAX_XLCELLS)
                    {
                        bcount = MAX_XLCELLS / this.ccount;
                    }

                    int bcount2 = System.Convert.ToInt32(bcount);


                    object[,] data = new object[bcount, this.ccount];
                    string[] format = new string[this.ccount];


                    for (int j = 0; j < this.ccount; j++)
                    {
                        format[j] = this.eH.Create_Range(1, j + 1, ws).NumberFormat.ToString();
                    }

                    while (this.rcount > 0)
                    {
                        GC.Collect();

                        int k = 0;
                        for (int i = this.step; i < this.rcount; i++)
                        {
                            k = (i - step) % bcount2;

                            for (int j = 0; j < this.ccount; j++)
                            {
                                swert = this.ds.Tables[0].DefaultView[i][j].ToString();
                                if ((format[j] != "@") && System.Double.TryParse(swert, NumberStyles.Number, Thread.CurrentThread.CurrentUICulture, out zahl))
                                {
                                    data[k, j] = zahl;
                                }
                                else
                                {

                                    if (swert.Length > 255)
                                    {
                                        swert = swert.Substring(0, 255);
                                    }
                                    if ((swert == "") && (format[j] != "@"))
                                    {
                                        swert = null;
                                    }

                                    data[k, j] = swert;
                                }
                            }

                            if (this.do_abort) break;
                            if ((k == bcount2 - 1) || (i == this.rcount - 1))
                            {
                                ExcelHelper.oExcelApp.Run("PALO.WRITE_ARRAY", data, k + 1, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o);
                            }

                            this.inc_progress();
                            clines++;
                        }
                        if (this.do_abort || (this.rcount < this.realsize))
                        {
                            break;
                        }

                        this.get_next();
                        this.step = 0;
                    }
                }
                if (this.ImportProgress != null)
                {
                    this.ImportProgress.Value = this.ImportProgress.Maximum;
                }
			}
			catch(ThreadAbortException)
			{
			}
			catch(Exception e)
			{
                System.Windows.Forms.MessageBox.Show(e.Message);
                Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error actual finishing Import!", e);
			}
			finally
			{
				this.clean_up();
				Connect.InPaste = true;
				this.go_out();
			}
		}


		public void insertRow()
		{
			try
			{
                Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();

				Connect.InPaste = false;

                if (this.import_mode == IMPORT_INTERNAL_LOOP)
                {
                    this.eH.AddItemToSpreadsheet(this.A1, step.ToString());
                    ExcelHelper.CalculateActivesheet();
                    ++step;
                    if (this.eH.IsError(this.B1)|| (step >=65536))
                    {
                        this.has_finished = true;
                    }
                }
                else
                {
                    for (int i = 0; i < this.ccount; i++)
                    {
                        this.eH.AddItemToSpreadsheet(1, (i + 1), ws, this.ds.Tables[0].DefaultView[step][i].ToString());
                    }

                    ExcelHelper.CalculateActivesheet();
                    this.inc_progress();

                    if (step < this.rcount - 1)
                    {
                        ++step;
                    }
                    else
                    {
                        this.step = 0;
                        if (this.rcount == this.realsize)
                        {
                            this.get_next();
                        }
                        else
                        {
                            this.has_finished = true;
                        }
                    }
                }
			
			}
			catch(Exception e)
			{
                System.Windows.Forms.MessageBox.Show(e.Message);
				Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error actual stepping through Import!", e);
			}
			finally
			{
				if (this.has_finished)
				{
					this.clean_up();
                    if (this.ImportProgress != null)
                    {
                        this.ImportProgress.Value = this.ImportProgress.Maximum;
                    }
					this.go_out();
				}
			}
		}

		public void insertRowCsv()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			try
			{
				for(int i=0;i<this.ccount;i++) 
				{
					sb.Append(this.ds.Tables[0].DefaultView[step][i].ToString() + this.separator);
				}
				WriteLineToCsvFile(sb.ToString());
				this.inc_progress();
				if (step < this.rcount-1)
				{
					++step;
				}
				else
				{
					this.step = 0;
					if (this.rcount == this.realsize)
					{
						this.get_next();
					}
					else
					{
						this.rcount = 0;
					}
				}			
			
			}
			catch(Exception e)
			{
                System.Windows.Forms.MessageBox.Show(e.Message);
                Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error actual stepping through Export!", e);
			}
			finally
			{
				if (this.rcount == 0)
				{
                    if (this.ImportProgress != null)
                    {
                        this.ImportProgress.Value = this.ImportProgress.Maximum;
                    }
					this.go_out();
				}
			}
		}

        /// <summary>
        /// Insert dimension Row into Csv-File
        /// </summary>
        public bool insertDimRowCsv(string[] dimRow)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            bool ret = true;

            try
            {
                for (int i = 0; i < dimRow.Length; i++)
                {
                    sb.Append(dimRow[i] + this.separator);
                }
                ret = WriteLineToCsvFile(sb.ToString());
                
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error actual stepping through Export!", e);
            }
            finally
            {
                if (dimRow == null)
                {
                    this.go_out();
                }
            }
            return ret;
        }

		[STAThread]
		public void t_insertRowCsv()
		{
            Thread thisThread = Thread.CurrentThread;
//			CultureInfo originalCulture = thisThread.CurrentCulture;
//			CultureInfo originalUICulture = thisThread.CurrentUICulture;

			thisThread.CurrentCulture = new CultureInfo("en-US");
			thisThread.CurrentUICulture = new CultureInfo("en-US");

			this.do_abort = false;
            try
			{
                if (this.withHeader)
                {
                    System.Text.StringBuilder sbh = new System.Text.StringBuilder();
                    string[] dims = this.conn.CubeListDimensions(this.db, this.cube);
                    for (int j = 0; j < dims.Length; j++)
                    {
                        sbh.Append(dims[j] + this.separator);
                    }
                    sbh.Append("Value" + this.separator);
                    WriteLineToCsvFile(sbh.ToString());
                }

                bool my_do_abort = this.do_abort;

				while (this.rcount > 0)
				{
					for(int i=this.step;i<this.rcount;i++)
					{
						System.Text.StringBuilder sb = new System.Text.StringBuilder();
						for(int j=0;j<this.ccount;j++) 
						{
							sb.Append(this.ds.Tables[0].DefaultView[i][j].ToString() + this.separator);
						}

                        my_do_abort = this.do_abort || !WriteLineToCsvFile(sb.ToString());

                        if (my_do_abort) break;
						
						sb = null;
						this.inc_progress();
					}
                    if (my_do_abort || (this.rcount < this.realsize)) break;
					this.get_next();
					this.step = 0;
				}
			}
			catch(ThreadAbortException)
			{
			}
			catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
				Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error actual finishing Export!", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
//				thisThread.CurrentCulture = originalCulture;
//				thisThread.CurrentCulture = originalUICulture;

				this.go_out();
			}
		}

        private string preprocessline(string line)
        {
            string tmpstr = line;
            string rep = GeneralConst.UNIX_NEWLINE;
            if (tmpstr != null)
            {
                string[] tmpstrs = tmpstr.Split('\n');
                int slen = tmpstrs.Length;
                tmpstr = "";
                for (int i = 0; i < slen; i++)
                {
                    tmpstr += tmpstrs[i] + rep;
                }
                if (slen > 0)
                {
                    tmpstr = tmpstr.Substring(0, tmpstr.Length - rep.Length);
                }
            }
            if (tmpstr != null)
            {
                tmpstr = tmpstr.Substring(0, tmpstr.Length - 1);
            }

            return tmpstr;
        }

        private bool WriteLineToCsvFile(string line)
        {
            if (this.cw == null)
            {
                return false;
            }

            line = preprocessline(line);
            if (line == null)
            {
                return true;
            }

            return this.cw.WriteLine(line);

        }
        
	}
}
