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
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.Utils
{
	[ComVisible(false)]
	public class PaloCubeReader : System.IDisposable
	{
		private const byte WERT1 = 0;
		private const byte OP1 = 1;
		private const byte BOOLOP = 2;
		private const byte OP2 = 3;
		private const byte WERT2 = 4;
		private const byte NOEMPTY = 5;
		private const byte BASEELEM = 6;
        private const byte USERULES = 7;

		private Connection conn;
		private string db;
		private string cube;
		private ArrayList elements;
		private ArrayList restrictions;

		private GetDataExportOptions opts;
		private String[][] dimelements;
		
		private int pageSize;
		private CultureInfo originalUICulture;
        private long countsofar;
        private bool useRules;

		public PaloCubeReader(Connection connection, string db, string cube, ArrayList elements, ArrayList restrictions, CultureInfo originalUICulture, int pageSize)
		{
			this.conn = connection;
			this.db = db;
			this.cube = cube;
			this.elements = elements;
			this.restrictions = restrictions;

			this.originalUICulture = originalUICulture;
			this.pageSize = pageSize;
		}
	
		private static CompareOp set_op(object op)
		{
			CompareOp ret = CompareOp.CompareOpTRUE;

			switch ((int)op)
			{
				case 1:
					ret = CompareOp.CompareOpEQ;
					break;
				case 2:
					ret = CompareOp.CompareOpGTE;
					break;
				case 3:
					ret = CompareOp.CompareOpGT;
					break;
				case 4:
					ret = CompareOp.CompareOpLTE;
					break;
				case 5:
					ret = CompareOp.CompareOpLT;
					break;
				case 6:
					ret = CompareOp.CompareOpNEQ;
					break;
				default:
					ret = CompareOp.CompareOpTRUE;
					break;
			}
			return ret;
		}

		private CellValue set_value(object val)
		{
			CellValue ret = new CellValue();
			string swert = (string)val;
			double zahl;

			if (System.Double.TryParse(swert, System.Globalization.NumberStyles.Number, this.originalUICulture, out zahl))
			{
				ret.Type = CellValueType.CellValueTypeDouble;
				ret.Value.DblValue = zahl;
			}
			else
			{
				ret.Type = CellValueType.CellValueTypeString;
				ret.Value.StrValue = swert;
			}

			return ret;
		}

		private static object[] getdata2array(Dataset ds, long anzahl)
		{
			object[] buffer = new object[anzahl];
			for (long i = 0; i < anzahl-1; i++)
			{
				buffer[i] = ds.Coordinates[i];
			}

			if (ds.Value.Type == CellValueType.CellValueTypeDouble)
			{
				buffer[anzahl-1] = ds.Value.Value.DblValue;
			}
			else
			{
				buffer[anzahl-1] = ds.Value.Value.StrValue;
			}

			return buffer;
		}

        private long EstimateNumberRecords(double progress, long lastcount)
        {
            long count = this.countsofar;
            if ((progress > 0) && (lastcount == this.pageSize) && (progress < 1))
            {
                count = System.Convert.ToInt64(System.Math.Ceiling(this.countsofar / progress));
            }
            return count;
        }

		public long Start(System.Data.DataSet dataSet)
		{
            countsofar = 0;
            if (dataSet == null)
            {
                return -1;
            }

			long anzahl = this.elements.Count;
			long anzahl2;
			
			DataColumn dc;

	  		double progress=0;

			DataTable dt = dataSet.Tables.Add(this.cube);
			object[] werte;
			ArrayList tmpL;

            Apalo.XlAddin.Utils.ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.STATUS_READ_CUBE_WAIT);

            this.dimelements = new String[anzahl][];
            ArrayList al = new ArrayList();
            string element = "";
			for (int i=0; i<anzahl; i++)
			{
				werte = (object[])this.elements[i];
				tmpL = (ArrayList)werte[1];
				anzahl2 = tmpL.Count;
                al.Clear();

                for (int j = 0; j < anzahl2; j++)
                {
                    if (tmpL[j].GetType() == typeof(String) )
                    {
                        element = tmpL[j].ToString();
                    }
                    else
                    {
                        element = (((object[])tmpL[j])[0]).ToString();
                    }
                    if (!al.Contains(element))
                    {
                        al.Add(element);
                    }
                }

                this.dimelements[i] = new string[al.Count];
                al.CopyTo(this.dimelements[i]);


                /*
                                if (anzahl2 != 0)
                                {
                                    this.dimelements[i] = new String[anzahl2];
                                    for(int j=0; j<anzahl2; j++)
                                    {
                                        this.dimelements[i][j] = (string)((object[])tmpL[j])[0];
                                    }
                                }
                                else
                                {
                                    DimElementInfo[] deis = this.conn.DimensionListDimElements(this.db, (string)werte[0]);
                                    if (deis.Length == 0)
                                    {
                                        return -1;
                                    }
                                    this.dimelements[i] = new String[deis.Length];
                                    for(long j=0; j<deis.Length; j++) 
                                        this.dimelements[i][j] = deis[j].Name;
                                }
                 */
            }

			this.opts.Filter.CmpOp1 = set_op(this.restrictions[OP1]);
			this.opts.Filter.Value1 = this.set_value(this.restrictions[WERT1]);
			this.opts.Filter.CmpOp2 = set_op(this.restrictions[OP2]);
			this.opts.Filter.Value2 = this.set_value(this.restrictions[WERT2]);

			switch ((int)this.restrictions[BOOLOP])
			{
				case 0:
					this.opts.Filter.AndOr12 = BoolOp.BoolOpAND;
					break;

                case 1:
					this.opts.Filter.AndOr12 = BoolOp.BoolOpOR;
					break;

                case 2:
                    this.opts.Filter.AndOr12 = BoolOp.BoolOpXOR;
                    break;

                default:
					this.opts.Filter.AndOr12 = BoolOp.BoolOpAND;
					this.opts.Filter.CmpOp2 = CompareOp.CompareOpTRUE;
					break;
			}

			this.opts.IngoreEmptyCells = (bool)this.restrictions[NOEMPTY];
			this.opts.BaseElementsOnly = (bool)this.restrictions[BASEELEM];

            if (this.restrictions.Count > USERULES)
            {
                this.useRules = (bool)this.restrictions[USERULES];
            }
            else
            {
                this.useRules = false;
            }

			this.opts.LastCoordinates = new String[0];
			this.opts.NumDatasets = (uint)this.pageSize;
			Dataset[] dsa = null;

            dsa = this.conn.GetDataExport(this.db, this.cube, this.dimelements, this.opts, this.useRules, ref progress);

            Apalo.XlAddin.Utils.ExcelHelper.ResetExcelStatusbar();

			if (dsa != null)
			{
				anzahl = dsa.Length;
			}
			else
			{
				anzahl = 0;
			}

            if (anzahl == 0)
			{
				return 0;
			}
			
			this.countsofar = anzahl;

			Dataset ds = dsa[0];

			anzahl2 = ds.Coordinates.Length;
            
            for(int iColumn = 0; iColumn < anzahl2; iColumn++)
			{
				//add to columns collection
				dc = dt.Columns.Add("Column " + iColumn.ToString());
//				dc.DataType = ds.Coordinates[iColumn].GetType();
				dc.DataType = typeof(System.String);
				dc.AllowDBNull = true;
			}

			dc = dt.Columns.Add("Column " + anzahl2.ToString());
			dc.AllowDBNull = true;

/*
 			if (ds.Value.Type == CellValueType.CellValueTypeDouble)
			{
				dc.DataType = ds.Value.Value.DblValue.GetType();
			}
			else
			{
				dc.DataType = ds.Value.Value.StrValue.GetType();
			}
*/
			dc.DataType = typeof(System.String);
			dt.Rows.Add(getdata2array(ds, ++anzahl2));
			this.opts.LastCoordinates = ds.Coordinates;

			for (int i=1; i < anzahl; i++)
			{
				ds = dsa[i];
				dt.Rows.Add(getdata2array(ds, anzahl2));
				this.opts.LastCoordinates = ds.Coordinates;
			}

			return EstimateNumberRecords(progress, anzahl);
		}

		public long Next(System.Data.DataSet dataSet)
		{
            double progress = 0;
            if (dataSet == null)
            {
                return -1;
            }

			Dataset[] dsa = null;
			DataTable dt = dataSet.Tables[0];

            Apalo.XlAddin.Utils.ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.STATUS_READ_CUBE_WAIT);

            dsa = this.conn.GetDataExport(this.db, this.cube, this.dimelements, this.opts, this.useRules, ref progress);

            Apalo.XlAddin.Utils.ExcelHelper.ResetExcelStatusbar();

            int anzahl = dsa.Length;
            this.countsofar += anzahl;

            for (int i = 0; i < anzahl; i++)
            {
                dt.Rows.Add(getdata2array(dsa[i], dt.Columns.Count));
            }

            if (anzahl > 0)
            {
                this.opts.LastCoordinates = dsa[anzahl - 1].Coordinates;
            }

            return this.EstimateNumberRecords(progress, anzahl);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if(disposing == true)
			{
			}
		}
	}
}