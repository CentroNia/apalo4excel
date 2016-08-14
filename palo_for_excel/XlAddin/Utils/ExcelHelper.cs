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

//  Additional Revisions to Palo (c) Junction BI LLC:
//  JMM 03-28-15 Corrected issues with not being enable to set EnableEvents:
//  JMM 09-17-13 DimensionListDimElements is now DimensionListElements

using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.Utils
{

	[ComVisible(false)]
	public class ExcelHelper : System.IDisposable
    {
        #region Defs

        const byte PAGE = 0;
		const byte COL = 1;
		const byte ROW = 2;
		const byte OTHER = 3;

        private static Excel.Application _oExcelApp = null;

        public static bool TestWithoutExcel = false;

        public static Excel.Application oExcelApp
        {
            get
            {
                if (_oExcelApp == null && !TestWithoutExcel)
                {
                    _oExcelApp = (Excel.Application )Marshal.GetActiveObject("Excel.Application"); 
                }
                return _oExcelApp;
            }
        }
        
        private static object om = System.Reflection.Missing.Value;


        #endregion

        #region Pagesorter/Rowsorter/Colsorter

        private class Pagesorter : IComparer
    	{
			public int Compare(object x, object y)  
			{
				int ret = 0;
				object[] x1 = (object[])x;
				object[] y1 = (object[])y;

				int ix = (int)x1[0];
				int iy = (int)y1[0];

				if (ix < iy)
				{
					ret = -1;
				}
				else
				{
					if (ix > iy)
					{
						ret = 1;
					}
					else
					{
						ix = (int)x1[1];
						iy = (int)y1[1];

						if (ix < iy)
						{
							ret = -1;
						}
						else
						{
							if (ix > iy)
							{
								ret = 1;
							}
							else
							{
								ret = 0;
							}
						}  
					}	 
				}		  
				return ret;
			}
		};

		private class Rowsorter : IComparer
		{
			public int Compare(object x, object y)  
			{
				int ret = 0;
				object[] x1 = (object[])x;
				object[] y1 = (object[])y;

				int ix = (int)x1[1];
				int iy = (int)y1[1];

				if (ix < iy)
				{
					ret = 1;
				}
				else
				{
					if (ix > iy)
					{
                        ret = -1;
					}
					else
					{
						ret = 0;
					}	 
				}		  
				return ret;
			}
		};

		private class Colsorter : IComparer
		{
 
            public int Compare(object x, object y)  
			{
				int ret = 0;
				object[] x1 = (object[])x;
				object[] y1 = (object[])y;

				int ix = (int)x1[0];
				int iy = (int)y1[0];

				if (ix < iy)
				{
					ret = 1;
				}
				else
				{
					if (ix > iy)
					{
						ret = -1;
					}
					else
					{
						ret = 0;
					}	 
				}		  
				return ret;
			}
		};

        #endregion

        #region Construct/Destruct

        public ExcelHelper()
		{
		}

		~ExcelHelper()
		{
			//			oExcelApp = null;
        }

        #endregion

        #region The Rest

		public string GetColumnStrVal(int index)
		{
            char first = 'A';
            int beginord = first; 
            if ((index < 1) || index > GeneralConst.getMaxColumn())
            {
                return first.ToString();
            }
            else
            {

                int tmpi = index -1, count = 26, div = tmpi / count, modulus = tmpi % count;

                string tmps = "";

                char toadd;

                do
                {
                    toadd = (char)(first + modulus);
                    tmps = toadd + tmps;
                    tmpi -= modulus;
                    tmpi /= count;
                    tmpi--;
                    modulus = tmpi % count;
                }
                while (tmpi > -1);

                return tmps;

            }
		}

        private static void SetExcelStatusbar(string message, string excmessage)
        {
            try
            {
            if (!TestWithoutExcel)
                oExcelApp.StatusBar = message;
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError(excmessage, exc);
            }
        }

        public static void SetExcelStatusbar(string message)
        {
            SetExcelStatusbar(message, "Error Setting Excel Statusbar.");
        }

        public static void ResetExcelStatusbar()
        {
            SetExcelStatusbar(null, "Error Resetting Excel Statusbar.");
        }

        public static void RegisterExcel(Excel.Application exApp)
		{
			_oExcelApp = exApp;
		}

        public static void UnRegisterExcel()
        {
            if (_oExcelApp != null)
            {
                while (Marshal.ReleaseComObject(ExcelHelper._oExcelApp) > 0) ;
                _oExcelApp = null;
            }

        }

        public static void AddNameValue(Excel._Worksheet ws, string name, object val)
        {
            Excel.Names wn = (Excel.Names)ws.Names;
            wn.Add(name, val, true, om, om, om, name, val, om, val, val);
        }

		public static void AddNameValue(string name, object val)
		{
			Excel.Workbook wb = (Excel.Workbook)oExcelApp.ActiveWorkbook;
			Excel.Names wn = (Excel.Names)wb.Names;
			wn.Add(name,val, true, om, om, om, name, val, om ,val, val);
		}

        public static void AddNameValueRef(Excel._Worksheet ws, string name, object val)
		{
			Excel.Names wn = (Excel.Names)ws.Names;
			wn.Add(name, om, true, om, om, om, om, om, om, val, om);
		}

        public bool IsError(Excel.Range er)
        {
            bool ret = false;

            try
            {
                ret = (bool)oExcelApp.WorksheetFunction.IsError(er);
            }
            catch (Exception cr)
            {
                ErrorHandler.DisplayError("Error calling ISERROR", cr);
            }

            return ret;
        }

        public bool RemoveFormat(string format)
        {
            object o = System.Reflection.Missing.Value;
            Excel.Workbook wb = (Excel.Workbook)oExcelApp.ActiveWorkbook;
            bool ret = true;
            try
            {
                wb.DeleteNumberFormat(format);
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        private static object Test4NameValue(string name, bool getValue, Excel._Worksheet ws, object defaultvalue)
        {
            object ret = defaultvalue;
            if (!name.StartsWith("\""))
            {
                object o = System.Reflection.Missing.Value;
                Excel.Names wn = null;
                if (ws == null)
                {
                    Excel.Workbook wb = (Excel.Workbook)oExcelApp.ActiveWorkbook;
                    wn = (Excel.Names)wb.Names;
                }
                else
                {
                    wn = (Excel.Names)ws.Names;
                }

                int anzahl = wn.Count;
                Excel.Name ename;

                string prefix = (ws == null) ? "" : ws.Name;

                if (prefix.Contains(" ") || prefix.Contains("!"))
                {
                    prefix = "'" + prefix + "'";
                }

                if (!String.IsNullOrEmpty(prefix))
                {
                    prefix += "!";
                }

                string cmpstr = prefix + name;

                for (int i = 1; i <= anzahl; i++)
                {
                    ename = wn.Item(i,o,o);

                    if (ename.Name == cmpstr)
                    {
                        if (getValue )
                        {
                            Thread thisThread = Thread.CurrentThread;
                            CultureInfo originalCulture = thisThread.CurrentCulture;
                            CultureInfo originalUICulture = thisThread.CurrentUICulture;

                            try
                            {
                                // set current thread's culture to en-US
                                thisThread.CurrentCulture = new CultureInfo("en-US");
                                thisThread.CurrentUICulture = new CultureInfo("en-US");

                                ret = ename.Value;
                            }
                            catch
                            { }
                            finally
                            {
                                thisThread.CurrentCulture = originalCulture;
                                thisThread.CurrentCulture = originalUICulture;
                            }

                        }
                        else
                        {
                            ret = true;
                        }
                        break;
                    }
                }
            }
            return ret;
        }

        public static bool Test4Name(string name, bool getValue, Excel._Worksheet ws)
        {
            bool ret = false;

            object o = Test4NameValue(name, getValue, ws, false);

            if (getValue)
            {
                ret = (o.ToString() == "=TRUE");
            }
            else
            {
                ret = (bool)o;
            }

            return ret;
        }

        public bool Test4Name(string name)
        {
            return Test4Name(name, false, null);
        }

        public void GetNamedRangeValue(string name, ref string retval, ref int col, ref int row, ref string wsName, ref bool iserror)
		{
			object o = System.Reflection.Missing.Value;
			try
			{
				Excel.Range tmpRng = (Excel.Range)oExcelApp.get_Range(name, o);
				col = tmpRng.Column;
				row = tmpRng.Row;
                iserror = IsError(tmpRng);
				wsName = tmpRng.Worksheet.Name;
                try 
                {
				    retval = tmpRng.Value2.ToString();
                }
                catch
                {
                    retval = tmpRng.Text.ToString();
                }
		    }
            catch
            {
                
            }
        }

        public object GetNamedRangeValues(string name)
        {
            object o = System.Reflection.Missing.Value;
            try
            {
                Excel.Range tmpRng = (Excel.Range)oExcelApp.get_Range(name, o);
                return tmpRng.Value2;
            }
            catch
            {
                return null;
            }
        }

		public Excel.Range Create_Range(int row, int column, Excel._Worksheet ws)
		{
			Excel.Range er = (Excel.Range)ws.Cells[row, column];
			return er;
		}

		public void HideRange(Excel.Range er, bool hide)
		{
            er.Hidden = hide;
		}

        public void AutofitRange(Excel.Range er)
        {
            er.AutoFit();
        }

        public void AutofitColumn(int column, Excel._Worksheet ws)
        {
            this.AutofitRange(this.Create_Range(1, column, ws).EntireColumn);
        }

        public void AutofitRow(int row, Excel._Worksheet ws)
        {
            this.AutofitRange(this.Create_Range(row, 1, ws).EntireRow);
        }

        public void HideColumn(int column, Excel._Worksheet ws, bool hide)
        {
            this.HideRange(this.Create_Range(1, column, ws).EntireColumn, hide);
        }

        public void HideRow(int row, Excel._Worksheet ws, bool hide)
        {
            this.HideRange(this.Create_Range(row, 1, ws).EntireRow, hide);
        }

        public void HideUsedRange(Excel._Worksheet ws, bool hide)
        {
            Excel.Range er = ws.UsedRange;
            this.HideRange(er.Columns, hide);
            this.HideRange(er.Rows, hide);
        }

        public void AddItemRawToSpreadsheet(Excel.Range er, string item)
        {
            if ((bool)er.HasArray)
            {
                er.CurrentArray.Clear();
            }

            er.Value2 = item;
        }

        public void AddItemToSpreadsheet(Excel.Range er, string item)
        {
            AddItemRawToSpreadsheet(er, this.EscapeQuote(item));
        }

		public void AddItemToSpreadsheet(Excel.Range er, string item, bool bold)
		{
            AddItemToSpreadsheet(er,item);
			er.Font.Bold = bold;
		}

        public void AddItemRawToSpreadsheet(Excel.Range er, string item, bool bold)
        {
            AddItemRawToSpreadsheet(er, item);
            er.Font.Bold = bold;
        }

		public void TestAddItemToSpreadsheet(int row, int column, Excel._Worksheet ws, string item, string style)
		{
			Excel.Range er = this.Create_Range(row, column, ws);
            AddItemToSpreadsheet(er, item);
            er.Style = style;
        }

		public void AddItemToSpreadsheet(Excel.Range er, string item, string style)
		{
            AddItemToSpreadsheet(er, item);
            try
			{
				er.Style = style;
			}
			catch
			{
			}
		}

		public void AddItemToSpreadsheet(Excel.Range er, string item, string style, bool bold)
		{
            AddItemToSpreadsheet(er, item);
            er.Style = style;
			er.Font.Bold = bold;
		}

		public void ClearRange(Excel.Range er)
		{
			er.Clear();
		}

		public void ClearRange(int row, int column, Excel._Worksheet ws)
		{
			Excel.Range er = this.Create_Range(row, column, ws);
			er.Clear();
		}

		public void ClearRange(int row, int column, int rowE, int columnE, Excel._Worksheet ws)
		{
			if(row <= 0 || column <= 0 || rowE <= 0 || columnE <=0)
				return;

			try
			{
				Excel.Range er = ws.get_Range((Excel.Range)ws.Cells[row,  column],(Excel.Range)ws.Cells[rowE,  columnE]);
				er.Clear();
			}
			catch(Exception cr)
			{
				ErrorHandler.DisplayError("Error selecting range", cr);
			}
		}

		#region Escape ' - Excel treats single quote as format setting for Text
		public string EscapeQuote(string inpString)
		{
			if(inpString.StartsWith("'"))
				return "'" + inpString;
			else
				return inpString;
		}

		public string EscapeDoubleQuote(string inpString)
		{
			return inpString.Replace("\"","\"\"");
		}

		public string DeEscapeDoubleQuote(string inpString)
		{
			return inpString.Replace("\"\"","\"");
		}

		#endregion

		public void AddItemToSpreadsheet(Excel.Range er, string item, string style, bool bold, bool force)
		{
            er.Value2 = this.EscapeQuote(item);
            er.Style = style;
			if( force && bold )
            {
				er.Font.Bold = true;
            }
		}

		public void AddItemToSpreadsheet(int row, int column, Excel._Worksheet ws, string item)
		{
			this.AddItemToSpreadsheet(this.Create_Range(row, column,ws), item);
		}

		public void AddItemToSpreadsheet(int row, int column, Excel._Worksheet ws, string item, bool bold)
		{
			this.AddItemToSpreadsheet(this.Create_Range(row, column,ws), item, bold);
		}

		public void AddItemToSpreadsheet(int row, int column, Excel._Worksheet ws, string item, string style)
		{
			this.AddItemToSpreadsheet(this.Create_Range(row, column,ws), item, style);
		}

		public void AddItemToSpreadsheet(int row, int column, Excel._Worksheet ws, string item, string style, bool bold)
		{
			this.AddItemToSpreadsheet(this.Create_Range(row, column,ws), item, style, bold);
		}

		public void AddItemToSpreadsheet(int row, int column, Excel._Worksheet ws, string item, string style, bool bold, bool force)
		{
			this.AddItemToSpreadsheet(this.Create_Range(row, column,ws), item, style, bold, force);
		}

		public string getItemFromSpreadsheet(Excel.Range er)
		{
			string item = "";
			try
			{
				object value2 = er.Value2;
				if (value2 != null)
				{
					item = value2.ToString();
				};
			}
			catch
			{}
			return item;
		}

		public string getItemFromSpreadsheet(int row, int column, Excel._Worksheet ws)
		{
			Excel.Range er = this.Create_Range(row, column,ws);
			return getItemFromSpreadsheet(er);
		}

		public void AddTextItemToSpreadsheet(Excel.Range er, string item)
		{
			er.NumberFormat = "@";
			er.Value2 = this.EscapeQuote(item);
		}

		public void AddTextItemToSpreadsheet(int row, int column, Excel._Worksheet ws, string item)
		{
			this.AddTextItemToSpreadsheet(this.Create_Range(row, column,ws), item);
		}

		public void AddFormulaToSpreadsheet(Excel.Range er, string formula)
		{
			er.Formula = formula;
		}

		public void AddFormulaToSpreadsheet(Excel.Range er, string formula, bool bold)
		{
			er.Formula = formula;
			er.Font.Bold = bold;
		}

		public void AddFormulaToSpreadsheet(Excel.Range er, string formula, string style)
		{
            er.Formula = formula;
            er.Style = style;
		}

		public void AddFormulaToSpreadsheet(Excel.Range er, string formula, string style, bool bold)
		{
            er.Formula = formula;
            er.Style = style;
			er.Font.Bold = bold;
		}

		public void AddFormulaToSpreadsheet(Excel.Range er, string formula, string style, bool bold, bool force)
		{
            er.Formula = formula;
            er.Style = style;
            if (force && bold)
            {
                er.Font.Bold = true;
            }
		}

        public void AddFormulaToSpreadsheet(Excel.Range er, string formula, string style, bool bold, bool force, string sAttrib)
        {
            er.Formula = formula;

            er.Style = style;

            if (!String.IsNullOrEmpty(sAttrib))
            {
                try
                {
                    er.NumberFormat = sAttrib;
                }
                catch (COMException)
                { }
            }

            if (force && bold)
            {
                er.Font.Bold = true;
            }
        }
		
		public void AddFormulaToSpreadsheet(int row, int column, Excel._Worksheet ws, string formula)
		{
			this.AddFormulaToSpreadsheet(this.Create_Range(row, column,ws), formula);
		}

		public void AddFormulaToSpreadsheet(int row, int column, Excel._Worksheet ws, string formula, bool bold)
		{
			this.AddFormulaToSpreadsheet(this.Create_Range(row, column,ws), formula, bold);
		}

		public void AddFormulaToSpreadsheet(int row, int column, Excel._Worksheet ws, string formula, string style)
		{
			this.AddFormulaToSpreadsheet(this.Create_Range(row, column,ws), formula, style);
		}

		public void AddFormulaToSpreadsheet(int row, int column, Excel._Worksheet ws, string formula, string style, bool bold)
		{
			this.AddFormulaToSpreadsheet(this.Create_Range(row, column,ws), formula, style, bold);
		}

		public void AddFormulaToSpreadsheet(int row, int column, Excel._Worksheet ws, string formula, string style, bool bold, bool force)
		{
			this.AddFormulaToSpreadsheet(this.Create_Range(row, column,ws), formula, style, bold, force);
		}

        public void AddFormulaToSpreadsheet(int row, int column, Excel._Worksheet ws, string formula, string style, bool bold, bool force, string sAttrib)
        {
            this.AddFormulaToSpreadsheet(this.Create_Range(row, column, ws), formula, style, bold, force, sAttrib);
        }

        public void SetIndentCell(int row, int column, Excel._Worksheet ws, int indentLevel)
        {
            try
            {
                Excel.Range er = this.Create_Range(row, column, ws);
                er.IndentLevel = (indentLevel > 15) ? 15 : indentLevel;
            }
            catch (COMException e)
            {
                ErrorHandler.DisplayError("Error indenting cell", e);
            }
        }

        public int GetIndentLevel(Excel._Worksheet ws, int row, int column)
        {
            int ret = 0;
            try
            {
                Excel.Range er = this.Create_Range(row, column, ws);
                ret = (int)er.IndentLevel;
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error getting indent level", e);
            }
            return ret;
        }
        
        public void AddFormulaArrayToSpreadsheet(Excel.Range er, string formula)
		{
			er.FormulaArray = formula;
		}

		public void AddFormulaArrayToSpreadsheet(int row, int column, Excel._Worksheet ws, string formula)
		{
			this.AddFormulaArrayToSpreadsheet(this.Create_Range(row, column,ws), formula);
		}

		static public string getFormulaFromSpreadsheet(Excel.Range er)
		{
			string item = "";
			object formula = er.Formula;
			if (formula != null)
			{
				item = formula.ToString();
			}
			return item;
		}

        static public string getFormulaLocalFromSpreadsheet(Excel.Range er)
        {
            string item = "";
            object formula = er.FormulaLocal;
            if (formula != null)
            {
                item = formula.ToString();
            }
            return item;
        }

		public string getFormulaFromSpreadsheet(int row, int column, Excel._Worksheet ws)
		{
			return getFormulaFromSpreadsheet(this.Create_Range(row, column,ws));
		}

		public string getFormulaArrayFromSpreadsheet(Excel.Range er)
		{
			string item = "";
			object formulaarray = er.FormulaArray;
            object formula = er.Formula;
            bool isarray = (bool)er.HasArray;
            if ((formulaarray != null) && isarray)
            {
                item = formulaarray.ToString();
            }
            else
            {
                if (formula != null)
                {
                    item = formula.ToString();
                }
            }
			return item;
		}

		public string getFormulaArrayFromSpreadsheet(int row, int column, Excel._Worksheet ws)
		{
			return getFormulaArrayFromSpreadsheet(this.Create_Range(row, column,ws));
		}

        public static void CalculateSpreadsheet()
		{
			oExcelApp.Calculate();
		}

        public static void CalculateActivesheet()
        {
            Excel._Worksheet ws = (Excel._Worksheet)oExcelApp.ActiveSheet;
            ws.Calculate();
        }

        public static bool GetScreenUpdating()
        {
            return oExcelApp.ScreenUpdating;
        }


        public static void SetScreenUpdating(bool activate)
		{
			oExcelApp.ScreenUpdating = activate;
		}

        public static Excel.XlCalculation DisableAutomaticRecalc()
		{
            Excel.XlCalculation calculation = oExcelApp.Calculation;
            oExcelApp.Calculation = Excel.XlCalculation.xlCalculationManual;
			return calculation;
		}

        public static Excel.XlCalculation GetCalculation()
        {
            return oExcelApp.Calculation;
        }

        public static void SetCalculation(Excel.XlCalculation calculation)
		{
            oExcelApp.Calculation = calculation;
		}

        private static void PaloEnableMacro(string name, bool activate)
        {
            oExcelApp.Run(name, activate, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om);
        }

		public static void PaloEnableLoop(bool activate)
		{
            PaloEnableMacro("PALO.ENABLE_LOOP", activate);
		}

        public static void PaloEnableXLL(bool activate)
        {
            PaloEnableMacro("PALO.ENABLE_XLL", activate);
        }

		public static void ClearSpreadsheet()
		{
            GetActiveWorkSheet().UsedRange.Clear();
		}
		
		public bool HasMergedCell(Excel.Range er)
		{
			bool ret = false;
			try
			{
				ret = (bool)er.MergeCells;
			}
			catch
			{
			}
			return ret; 
		}

		public bool HasMergedCell(int row, int column, Excel._Worksheet ws)
		{
			return HasMergedCell(this.Create_Range(row, column,ws));
        }

        #endregion 

        #region search Worksheet

        public Excel._Worksheet get_ws(string ws_name)
		{
            Microsoft.Office.Interop.Excel.Application eA = oExcelApp;
			foreach (Excel._Worksheet ws in eA.Worksheets)
			{
				if (ws.Name == ws_name)
				{
					return ws;
				}
			}

			return (Excel._Worksheet)eA.ActiveSheet;
		}

		private string get_real_value(string refer, Excel._Worksheet ws, ref string sheet, ref int col, ref int row, ref bool iserror)
		{
			col = 0;
			row = 0;
			sheet = "";
			char tmp;
			string ret = "";
			string tmprefer = refer;


			this.GetNamedRangeValue(tmprefer, ref ret, ref col, ref row, ref sheet, ref iserror);

            if (!iserror)
            {
			    if (sheet == ws.Name)
			    {
				    sheet = "";
			    }

			    if (ret == "")			
			    {
				    Excel._Worksheet ws1 = ws;

				    int pos = tmprefer.IndexOf("!");
				    if (pos > 0)
				    {
					    sheet = tmprefer.Substring(0,pos);
					    ws1 = this.get_ws(sheet);
				    	tmprefer = tmprefer.Substring(pos+1);
				    }

				    tmprefer = tmprefer.ToUpper();
    				int length = tmprefer.Length;

	    			for (int i=0; i < length; i++)
		    		{
			    		tmp = tmprefer[i];
				    	if ((tmp >= '0') && (tmp <= '9'))
					    {
						    row *= 10;
						    row += (tmp-'0');
					    }
					    else
					    {
						    if ((tmp >= 'A') && (tmp <= 'Z'))
						    {
							    col *= 26;
							    col += (tmp-'A') + 1;
						    }
						    else
						    {
							    if (tmp == ':')
							    {
								    break;
							    }
							    if (tmp != '$')
							    {
								    return "";
							    }
						    }
					    }
				    }

    				if (row > 0 && col >0)
	    			{
		    			ret = this.getItemFromSpreadsheet(row, col, ws1);
			    	}
				    else
				    {
					    ret = refer;
				    }

			    }
			}

			return ret;
		}

        private string processName(string ename, Excel._Worksheet ws, ref string sheet, ref int col, ref int row )
        {
            sheet = "";
            col = 0;
            row = 0;
            string sheetstr, basestr, retstr = "";
            bool iserror = false;
            int pos = ename.IndexOf("!");
            if (pos > 0)
            {
                sheetstr = ename.Substring(0, pos);
                basestr = ename.Substring(pos + 1);
                this.GetNamedRangeValue(sheetstr + "!_" + basestr, ref retstr, ref col, ref row, ref sheet, ref iserror);

                if (!iserror && (col == 0))
                {
                    try
                    {
                        object o = System.Reflection.Missing.Value;
                        Excel.Workbook wb = (Excel.Workbook)oExcelApp.ActiveWorkbook;
                        retstr = wb.Names.Item(ename, o, o).Value;
                    }
                    catch
                    {
                    }
                }

/*
 *              retstr = getNameValue(ename);

                int length = retstr.Length;
                if (length > 3)
                {
                    retstr = retstr.Remove(length - 1);
                    retstr = retstr.Remove(0, 2);
                }
                else
                {
                    retstr = "";
                }
 */
            }

            return retstr;        
        }

		private string get_value(string str, Excel._Worksheet ws, ref string sheet, ref int col, ref int row, string ename, ref bool iserror)
		{
			sheet = "";
			col = 0;
			row = 0;

			string tmpstr = "";
            iserror = false;
            if (ename != "")
            {
                tmpstr = processName(ename, ws, ref sheet, ref col, ref row);
            }
            else
            {
                // JMM 2015-12-04
                str = str.Trim();
                if (!str.StartsWith('"'.ToString()))
                {
                    tmpstr = this.get_real_value(str, ws, ref sheet, ref col, ref row, ref iserror);
                }
                else
                {
                    tmpstr = str.Remove(0, 1);
                    if (tmpstr.EndsWith('"'.ToString()))
                    {
                        tmpstr = tmpstr.Remove(tmpstr.Length - 1, 1);
                    }
                }
            }

			return tmpstr;
		}

        public string get_value(string str, Excel._Worksheet ws, string ename, ref bool iserror)
        {
            string sheet = "";
            int dummy_x = 0;
            int dummy_y = 0;
            return this.get_value(str, ws, ref sheet, ref dummy_x, ref dummy_y, ename, ref iserror);
        }

        public string get_value(string str, Excel._Worksheet ws)
        {
            bool iserror = false;
            return this.get_value(str, ws, "", ref iserror);
        }

        private string get_dimname(int row, int col, Excel._Worksheet ws)
		{
			string dim = "";
			string item = this.getFormulaFromSpreadsheet(row, col, ws);
			if (item.ToUpper().StartsWith("=PALO.ENAME("))
			{
				int pos = item.IndexOf(",");
				item = item.Substring(pos+1);
				pos = item.IndexOf(",");
				item = item.Substring(0,pos);
				dim = this.get_value(item.Substring(0,pos), ws);
			}
			return dim;
		}

		public string get_params(string formula, int index, bool withDoubleQuotes)
		{
			bool hasquotes = false;
			string arg = "";
			string tmpstr = formula;
			int pos,pos2, tmpindex = 0;
			pos = tmpstr.IndexOf("(");
			if (pos > -1) tmpstr = tmpstr.Substring(pos+1);
			pos = tmpstr.LastIndexOf(")");
			if (pos > -1) tmpstr = tmpstr.Substring(0,pos);
			while (tmpstr.Length > 0)
			{
				if (tmpstr[0] != '&')
				{
					arg = "";
					tmpindex++;
					hasquotes = (tmpstr[0] == '"');
				}
				else
				{
					tmpstr = tmpstr.Substring(1);
				}

				if (tmpstr[0] == '"')
				{
					tmpstr = tmpstr.Substring(1);
					pos = tmpstr.IndexOf("\"");
					if (pos < 0)
					{
						pos = tmpstr.Length;
					}
					else
					{
						while ((pos < tmpstr.Length-1) && (pos>=0))
						{
							if (tmpstr[pos+1] != '"')
							{
								break;
							}
							pos = tmpstr.IndexOf("\"",pos+2);
						}
						if (pos < 0)
						{
							pos = tmpstr.Length;
						}
					}
					pos2 = pos +1;
					if (pos2 < tmpstr.Length)
					{
						if (tmpstr[pos2] == '&')
						{
							pos2--;
						}
					}
				}
				else
				{
					pos = tmpstr.IndexOf(",");
					if (pos < 0)
					{
						pos = tmpstr.Length;
					}
					pos2 = pos;
				}

				arg += tmpstr.Substring(0,pos);
				if (pos2 < tmpstr.Length -1)
				{
					tmpstr = tmpstr.Substring(pos2 +1); 
				}
				else
				{
					tmpstr = "";
				}

				if ((tmpindex == index) && ((tmpstr == "") || (tmpstr[0] != '&')))
				{
					break;
				}
			}

			if (tmpindex != index)
			{
				arg = "";
			}

			if ((arg != "") && hasquotes && withDoubleQuotes)
			{
				arg = '"' + arg + '"';
			}

			return arg;
		}

		public string get_params(string formula, int index)
		{
			return this.get_params(formula, index, false);
		}
		
		private void min_max_page(ref int min_row, ref int max_row, ref int min_col, ref int max_col, string sheet, int row, int col, string actsheet)
		{
			if ((sheet == "") || (sheet == actsheet))
			{
				if ((min_col == 0) || (col < min_col)) 
				{
					min_col = col;
				}

				if ((min_row == 0) || (row < min_row)) 
				{
					min_row = row;
				}

				if (col > max_col) 
				{
					max_col = col;
				}

				if (row > max_row) 
				{
					max_row = row;
				}

			}
		}

		private void min_max_table(ref int min_row, ref int max_row, ref int min_col, ref int max_col, int row, int col)
		{
			if ((min_col == 0) || (col < min_col)) 
			{
				min_col = col;
			}

			if ((min_row == 0) || (row < min_row)) 
			{
				min_row = row;
			}

			if (col > max_col) 
			{
				max_col = col;
			}

			if (row > max_row) 
			{
				max_row = row;
			}
		}

		private void max_table(ref int max_row, ref int max_col, int row, int col)
		{
			if (col > max_col) 
			{
				max_col = col;
			}

			if (row > max_row) 
			{
				max_row = row;
			}
		}

		private byte get_type(string refer, string sheet, int row, int col, Excel._Worksheet ws, int srow, int scol, string ename, ref string param)
		{
			byte ret = OTHER;
            param = "";

  			if ((sheet != ""))
			{
				ret = PAGE;
			}
			else
			{
//				if (this.Test4Name(refer))
				if (ename != "")
				{
					ret = PAGE;
				}
				else
				{
					if (!refer.StartsWith('"'.ToString()))
					{
						string tmpstr = this.getFormulaFromSpreadsheet(row, col, ws).ToUpper();
						param = this.get_params(tmpstr,4);
                        if (tmpstr.StartsWith("=PALO.ENAME(") && (param != "2") && (param != "3") && (param != "0") && (param != "4"))
						{ 
								ret = PAGE;
						}
						else
						{

							if (refer == this.make_ref(row, col,true, true ))
							{
								ret = PAGE;
							}
							else
							{
								if (refer == this.make_ref(row, col, true, false))
								{
									ret = COL;
								}
								else
								{

									if (refer == this.make_ref(row, col, false, true))
									{
										ret = ROW;
									}
									else
									{
										if ((row >= srow) && (col < scol))
										{
											ret = ROW;
										}
										else
										{
											if ((row < srow) && (col >= scol))
											{
												ret = COL;
											}
										}

									}
								}
	
							}

						}
					}
				}
              }

			return ret;
		}

		private string get_path(Excel._Worksheet ws, int row, int col)
		{
			string pfad = "";

			string formula = this.getFormulaFromSpreadsheet(row, col, ws);
			if (formula.ToUpper().StartsWith("=PALO.ENAME("))
			{ 
				pfad = this.DeEscapeDoubleQuote(this.get_params(formula,5));

			}

			return pfad;
		}
		
		private bool get_picklist(Excel._Worksheet ws, string refer)
		{

			bool ret = false;
			int col=0, row=0;
			string formula="", tmpstr="";
            bool iserror = false;
			this.GetNamedRangeValue(refer, ref formula, ref col, ref row, ref tmpstr, ref iserror );

			if ((col > 0) && (row > 0))
			{
				formula = this.getFormulaFromSpreadsheet(row, col, ws);
            
				if (formula.ToUpper().StartsWith("=PALO.ENAME"))
				{
					ret = (this.get_params(formula, 4) == "3");
				}
			}

			return ret;
		}

        private string getOtherRef(Excel._Worksheet ws, string refer)
        {
            if (refer.StartsWith("\""))
            {
                return refer;
            }

            string retval = "", wsName = "";
            int col = 0, row = 0;
            bool iserror = false;

            GetNamedRangeValue(refer, ref retval, ref col, ref row, ref wsName, ref iserror);

            string formula = this.getFormulaFromSpreadsheet(row, col, ws);

            if (formula.ToUpper().StartsWith("=PALO.ENAME"))
            {
                retval = this.get_params(formula, 6);
            }

            return String.IsNullOrEmpty(retval) ? refer : retval;
        }
        
        private string get_ws_params2_helper0(Excel._Worksheet ws, int row, int col, bool row_absolute, bool col_absolute, ArrayList args2, Hashtable ht, ref int row2, ref int col2)
		{
			string ret = "";

            if ((row > 0) && (col > 0))
            {
                string refer = this.make_ref(row, col, false, false);

                if (args2.Contains(refer))
                {
                    string wsName = "";
                    bool iserror = false;

                    if (ht.ContainsKey(refer))
                    {
                        refer = (string)ht[refer];
                    }
                    GetNamedRangeValue(refer, ref ret, ref col2, ref row2, ref wsName, ref iserror);
                }

            }

			return ret;
		}

		private bool get_ws_params2_helper1(int row, int col, Excel._Worksheet ws, ref ArrayList list2, ref int max_row, ref int max_col, int row2, int col2, string checkitem, ArrayList dimelems, bool do_add, string displayedname)
		{
            string formula = this.getFormulaFromSpreadsheet(row, col, ws);

			string item = this.getItemFromSpreadsheet(row, col, ws);

            if (formula == "")
			{
				return false;
			}

            
            if (dimelems.Contains(item))
			{
				this.max_table(ref max_row, ref max_col, row, col);
			}

			if (checkitem != "")
			{
                formula = this.getFormulaFromSpreadsheet(row2, col2, ws);
                if (formula != "=\"\"")
                {
                    if (this.getItemFromSpreadsheet(row2, col2, ws) != checkitem)
                    {
                        return false;
                    }
                    if (!formula.StartsWith("=") || formula.ToUpper().StartsWith("=PALO.ENAME"))
                    {
                        return false;
                    }
                }
			}

			if (do_add)
			{
				formula = this.getFormulaFromSpreadsheet(row, col, ws);

				if (!formula.StartsWith("=") || formula.ToUpper().StartsWith("=PALO.ENAME")) 
				{
					if (dimelems.Contains(item))
					{
						string pfad = this.get_path(ws, row, col);
                        list2.Add(new object[] { item, pfad, displayedname  }); 
					}
				}
			}

			return do_add;
		}

        private void get_ws_params2_helper2(string db, string dim, Connection c, Excel._Worksheet ws, int trow, int tcol, string sheet, string ename, ArrayList list2, ref ArrayList result, int trow2, int tcol2)
		{
			if ((list2.Count > 0) && (dim != ""))
			{
				bool bold = false;
				string elem;
				ArrayList list = new ArrayList();
				foreach(object[] elems in list2)
				{
					elem = (string)elems[0];
					try
					{
						bold =c.ElementChildCount(db, dim, elem) > 0;
					}
					catch
					{
						bold = false;
					}
                    list.Add(new object[] { elem, bold, (string)elems[1], (string)elems[2]});
				}
				result.Add(new object[]{trow, tcol, dim, list, sheet, ename, getAttributeFromFormula(ws, trow, tcol), trow2, tcol2});
			}							
		}

        private string getAttributeFromFormula(Excel._Worksheet ws, int row, int col)
        {
            string formula = this.getFormulaFromSpreadsheet(row, col, ws);
            return DeEscapeDoubleQuote(get_params(formula, 6));

        }

        private bool getAttributeReferenz(Excel._Worksheet ws, int row, int col, ref int row2, ref int col2)
        {
            bool ret = false;
            row2 = row;
            col2 = col;

            string formula = this.getFormulaFromSpreadsheet(row, col, ws);
            string refer = DeEscapeDoubleQuote(get_params(formula, 6));
            string retval = "", sheet = "";

            if (refer != "")
            {
                bool iserror = false;
                this.GetNamedRangeValue(refer, ref retval, ref col2, ref row2, ref sheet, ref iserror);
                ret = true;
            }
            return ret;
        }

        private string getAttribute4Page(Excel._Worksheet ws, int row, int col, string value)
        {
            Excel.Range er = this.Create_Range(row, col, ws);
            string format = er.NumberFormat.ToString();
            string ret = value;

            int pos = format.IndexOf(";;;");
            
            if (pos > -1)
            {
                ret = format.Substring(pos + 4, format.Length - pos - 5);
            }
            return ret;

        }

        public bool get_ws_params2(ref string datamode, ref ArrayList DB, ref ArrayList Cube, ref ArrayList pages, ref ArrayList rows, ref ArrayList cols, ref string prefix, ref string postfix, ref ArrayList pagecoord, ref ArrayList tablecoord, ref ArrayList options)
		{

            SetExcelStatusbar(ResourceInitializer.STATUS_SCAN_SHEET);

			DB.Clear();
        	pages.Clear();
			rows.Clear();
			cols.Clear();
			Cube.Clear();
			pagecoord.Clear();
			tablecoord.Clear();
			options.Clear();

			datamode = "";
			prefix = "";
			postfix = "";

			int page_min_row = 0;
			int page_min_col = 0;
			int page_max_row = 0;
			int page_max_col = 0;

			int table_min_row = 0;
			int table_min_col = 0;
			int table_max_row = 0;
			int table_max_col = 0;

			string db = "";

			string cube = "";

			bool ret = false;

			ArrayList dimelems = new ArrayList();

			try
			{
                Microsoft.Office.Interop.Excel.Application eA = oExcelApp;
				Excel._Worksheet ws = (Excel._Worksheet) eA.ActiveSheet;
				Excel.Range eR = ws.UsedRange;
				int begincol = eR.Column;
				int beginrow = eR.Row;
				int maxcol = eR.Columns.Count + begincol - 1;
				int maxrow = eR.Rows.Count + beginrow - 1;

				bool found = false;

				int i, j;
				string ename;
				string item = "";
				string fn = "";
				string host = "";
				int col = 1;
				int row = 1;
                int col2 = 1;
                int row2 = 1;
                string sheet = "";
                string actsheet = "";
				int tcol = 0;
				int trow = 0;
				int pos = 0;
				string checkitem = "";
				bool do_add = true;

				for (i = beginrow; (i <= maxrow) && !found; i++)
				{
					for (j = begincol; (j <= maxcol) && !found; j++)
					{
						item = this.getFormulaArrayFromSpreadsheet(i, j, ws);
						
						if (item == "")
						{
							item = this.getFormulaFromSpreadsheet(i, j, ws);
						}

						item= item.Trim();

                        pos = item.ToUpper().IndexOf(GeneralConst.PALO_DATA);


						if (pos > 0)
						{
							row = i;
							col = j;

							prefix = item.Substring(1,pos-1);
							item = item.Substring(pos);
							pos = item.IndexOf(")");
							postfix = item.Substring(pos+1);
							item = item.Substring(0,pos+1);
							pos = item.IndexOf("(");
							datamode = item.Substring(0,pos);
							item = item.Remove(0,pos+1);
							pos = item.IndexOf(",");
							fn = item.Substring(0,pos);
							item = item.Remove(0,pos+1);
							pos = item.IndexOf(",");
							cube = item.Substring(0,pos);
							item = item.Remove(0,pos+1);
							found = true;
							table_min_row = row;
							table_min_col = col;
							table_max_row = table_min_row;
							table_max_col = table_min_col;
						}
					}
				}

				if (found)
				{
                    bool abbruch = false, nopicklist = false;
                    bool showselector = GeneralConst.PASTE_VIEW_DEFAULT_SHOWSELECTOR_CHECKED;
                    bool indent = Test4Name(GeneralConst.PASTE_VIEW_IDENT, true, ws);
                    bool zerosuppression = Test4Name(GeneralConst.PASTE_VIEW_ZEROSUPPRESSION, true, ws);
                    bool zerosuppressionalsocalculatednull = Test4Name(GeneralConst.PASTE_VIEW_ZEROSUPPRESSIONALSOCALCULATEDNULL, true, ws);
                    string usewidthstr =Test4NameValue(GeneralConst.PASTE_VIEW_COLWIDTH, true, ws, "").ToString();
                    string usestyle = Test4NameValue(GeneralConst.PASTE_VIEW_STYLE, true, ws, "").ToString();

                    double usewidth = -1;

                    if ((usewidthstr.Length > 0) && (usewidthstr[0] == '='))
                    {
                        usewidthstr = usewidthstr.Substring(1);
                    }

                    if (!System.Double.TryParse(usewidthstr, NumberStyles.Number, Thread.CurrentThread.CurrentUICulture, out usewidth))
                    {
                        usewidth = -1;
                    }

                    if ((usestyle.Length > 0) && (usestyle[0] == '='))
                    {
                        usestyle = usestyle.Substring(1);
                    }

                    if (usestyle.StartsWith("\""))
                    {
                        usestyle = usestyle.Substring(1);
                    }
                    
                    if (usestyle.EndsWith("\""))
                    {
                        usestyle = usestyle.Substring(0, usestyle.Length -1);
                    }

                    actsheet = ws.Name;
					item = item.Substring(0,item.Length-1);

					if (this.Test4Name(fn))
					{
						ename = fn;
					}
					else
					{
						ename = "";
					}
                    bool iserror = false;
					fn = this.get_value(fn, ws, ref sheet, ref tcol, ref trow, "", ref iserror);

					pos = fn.IndexOf("/");

                    abbruch = abbruch || iserror || (pos <= 0) || (tcol <= 0) || (trow <= 0);

					if (!abbruch) 
					{
                        this.min_max_page(ref page_min_row, ref page_max_row, ref page_min_col, ref page_max_col, sheet, trow, tcol, actsheet);
						host = fn.Substring(0,pos);
						db = fn.Substring(pos+1);
			
						Connection c = Apalo.XlAddin.Connections.GetConnection(host);

						if (c != null)
						{
                            DB.AddRange(new object[] { trow, tcol, host, db, sheet, ename, c.GetDatabaseType(db) });

							if (this.Test4Name(cube))
							{
								ename = cube;
							}
							else
							{
								ename = "";
							}

                            cube = this.get_value(cube, ws, ref sheet, ref tcol, ref trow, "", ref iserror);

                            abbruch = abbruch || iserror;

							if ((tcol>0) && (trow>0) && !abbruch)
							{

								this.min_max_page(ref page_min_row, ref page_max_row, ref page_min_col, ref page_max_col, sheet, trow, tcol, actsheet);

                                Cube.AddRange(new object[] { trow, tcol, cube, sheet, ename, c.GetCubeType(db, cube) });

								string[] dbCubesDim = c.CubeListDimensions(db, cube);
								string refer = "";

								int n = 0, indentlevel;
								int dimcount = dbCubesDim.Length;

								ArrayList args = new ArrayList();
								ArrayList args2 = new ArrayList();
                                Hashtable ht = new Hashtable();
                                string refer2 = "";

								while ((pos=item.IndexOf(","))>0)
								{
									refer = item.Substring(0,pos);
                                    item = item.Substring(pos + 1);

                                    pos = refer.IndexOf(":");
                                    if (pos > -1)
                                    {
                                        refer = refer.Substring(0, pos);
                                    }

									if (n<dimcount)
									{
										args.Add(new object[]{refer, dbCubesDim[n++]});
									}
									else
									{
										args.Add(new object[]{refer});
									}

                                    args2.Add(refer);

                                    refer = refer.Replace("$", "");
                                    args2.Add(refer);

                                    if (refer.StartsWith("\""))
                                    {
                                        abbruch = true;
                                        break;
                                    }
                                    refer2 = getOtherRef(ws, refer);
                                    ht[refer2]=refer;
                                    args2.Add(refer2);

								}
                                pos = item.IndexOf(":");
                                if (pos > -1)
                                {
                                    item = item.Substring(0, pos);
                                }

                                args2.Add(item);
                                refer = item.Replace("$", "");
                                args2.Add(refer);

                                refer2 = getOtherRef(ws, refer);
                                ht[refer2] = refer;
                                args2.Add(refer2);

                                if (n < dimcount)
								{
									args.Add(new object[]{item, dbCubesDim[n]});
								}
								else
								{
									args.Add(new object[]{item});
								}
		
								string dim = "", param = "";;
								byte typ;

								ArrayList list = new ArrayList();

                                bool hasattribs = false;
                                int trow2=0, tcol2=0, trow3=0, tcol3=0, offset = -1;

								foreach(object[] items in args)
								{
									if (items.Length < 2)
									{
										break;
									}

									refer = (string)items[0];
									dim = (string)items[1];

									if (this.Test4Name(refer))
									{
										ename = refer;
									}
									else
									{
										ename = "";
									}

                                    item = this.DeEscapeDoubleQuote(this.get_value(refer, ws, ref sheet, ref tcol, ref trow, ename, ref iserror));

                                    abbruch = abbruch || iserror;

                                    if (abbruch)
                                    {
                                        break;
                                    }
									typ = this.get_type(refer, sheet, trow, tcol, ws, row, col, ename, ref param);

									nopicklist = nopicklist || this.get_picklist(ws, refer);
				
									dimelems.Clear();

									ElementInfo[] dimDimElems = c.DimensionListElements(db, dim);

									foreach(ElementInfo dimDimElem in dimDimElems)
									{
										dimelems.Add(dimDimElem.Name);
									}

									switch(typ)
									{
										case PAGE:
											this.min_max_page(ref page_min_row, ref page_max_row, ref page_min_col, ref page_max_col, sheet, trow, tcol, actsheet);
											list.Clear();
											list.Add(new object[]{item,"", getAttribute4Page(ws, trow, tcol, item)});
											this.get_ws_params2_helper2(db, dim, c, ws, trow, tcol, sheet, ename, list, ref pages, trow, tcol);
											break;
										case ROW:
											this.min_max_table(ref table_min_row, ref table_max_row, ref table_min_col, ref table_max_col, trow, tcol);
											list.Clear();
                                            tcol2 = tcol;
                                            trow2 = trow;
                                            hasattribs = getAttributeReferenz(ws, trow, tcol, ref trow2, ref tcol2);
                                            this.min_max_table(ref table_min_row, ref table_max_row, ref table_min_col, ref table_max_col, trow2, tcol2);
                                            indentlevel = GetIndentLevel(ws, trow2, tcol2);
                                            indent = indent || (indentlevel > 0);
                                            showselector = showselector || (param == "2");
                                            offset = hasattribs ? 1 : -1;
                                            do_add = get_ws_params2_helper1(trow, tcol, ws, ref list, ref table_max_row, ref table_max_col, 1, 1, "", dimelems, true, getItemFromSpreadsheet(trow2, tcol2, ws));
											checkitem = get_ws_params2_helper0(ws, trow, tcol+offset, false, true, args2, ht, ref row2, ref col2);

											for (j = trow + 1; j <= maxrow; j++)
											{
                                                getAttributeReferenz(ws, j, tcol, ref trow3, ref tcol3);
                                                indentlevel = GetIndentLevel(ws, trow3, tcol3);
                                                indent = indent || (indentlevel > 0);
                                                do_add = get_ws_params2_helper1(j, tcol, ws, ref list, ref table_max_row, ref table_max_col, j, col2, checkitem, dimelems, do_add, getItemFromSpreadsheet(trow3, tcol3, ws));
/*
 * 												if (!get_ws_params2_helper1(j, tcol, ws, ref list, ref table_max_row, ref table_max_col, j, tcol-1, checkitem, dimelems))
												{
													break;
												}
*/
											}
											this.get_ws_params2_helper2(db, dim, c, ws, trow2, tcol2, sheet, ename, list, ref rows, trow, tcol);
											break;
										case COL:
											this.min_max_table(ref table_min_row, ref table_max_row, ref table_min_col, ref table_max_col, trow, tcol);
											list.Clear();
                                            tcol2 = tcol;
                                            trow2 = trow; ;
                                            hasattribs = getAttributeReferenz(ws, trow, tcol, ref trow2, ref tcol2);
                                            this.min_max_table(ref table_min_row, ref table_max_row, ref table_min_col, ref table_max_col, trow2, tcol2);
                                            offset = hasattribs ? 1 : -1;
                                            showselector = showselector || (param == "2");
                                            do_add = get_ws_params2_helper1(trow, tcol, ws, ref list, ref table_max_row, ref table_max_col, 1, 1, "", dimelems, true, getItemFromSpreadsheet(trow2, tcol2, ws));
											checkitem = get_ws_params2_helper0(ws, trow+offset, tcol, true, false, args2, ht, ref row2, ref col2);
											for (j = tcol + 1; j <= maxcol; j++)
											{
                                                getAttributeReferenz(ws, trow, j, ref trow3, ref tcol3);
                                                do_add = get_ws_params2_helper1(trow, j, ws, ref list, ref table_max_row, ref table_max_col, row2, j, checkitem, dimelems, do_add, getItemFromSpreadsheet(trow3, tcol3, ws));

/*												if (!get_ws_params2_helper1(trow, j, ws, ref list, ref table_max_row, ref table_max_col, trow-1, j, checkitem, dimelems))
												{
													break;
												}
*/
											}
                                            this.get_ws_params2_helper2(db, dim, c, ws, trow2, tcol2, sheet, ename, list, ref cols, trow, tcol);
											break;
										default:
											abbruch = true;
											break;
									}
									if (abbruch) break;
								}

                                iserror = (dbCubesDim.Length != (pages.Count + rows.Count + cols.Count));
                                abbruch = abbruch || iserror;

                                if (!abbruch)
                                {
                                    pages.Sort(new Pagesorter());
                                    rows.Sort(new Rowsorter());
                                    cols.Sort(new Colsorter());

                                    pagecoord.AddRange(new object[] { page_min_row, page_min_col, page_max_row, page_max_col });
                                    tablecoord.AddRange(new object[] { table_min_row, table_min_col, table_max_row, table_max_col });
                                    options.AddRange(new object[] { !nopicklist, indent, zerosuppression, usewidth, zerosuppressionalsocalculatednull, showselector, usestyle });
                                }
							}
						}
					}
                    ret = !abbruch;
                }
			}
			catch(Exception ex)
			{
				ErrorHandler.DisplayError("Error reading Worksheet", ex);
			}

            ResetExcelStatusbar();

			return ret;
		}

		#endregion

		#region paste function

		public string make_ref(int row, int col, bool row_abs, bool col_abs)
		{
			string srow = row.ToString();
			string scol = "";

            if (row_abs)
			{
				srow = "$" + srow;
			}

            scol = GetColumnStrVal(col);

			if (col_abs)
			{
				scol = "$" + scol;
			}

			return scol + srow;

		}
		
		private int get_index(StringDictionary dcdim, string dim)
		{
			int i = System.Convert.ToInt32(dcdim[dim]);
			return i;
		}

		private string[] get_item(int row, int col)
		{
			string[] elements = new string[1];

			Excel._Worksheet ws = (Excel._Worksheet)oExcelApp.ActiveSheet;

			elements[0] = this.getItemFromSpreadsheet(row, col, ws);

			return elements;
		}

		private string get_cubedim(Connection c, string dbN, string cube, string[] elements)
		{
			string dim = "";

			if (elements[0] != "")
			{
				try
				{
					dim = c.ElementCubeDimension(dbN, cube, elements, false);
				}
				catch
				{
					dim = "";
				}
			}

			return dim;
		}

		private void paste_func_help(Connection c, int row, int col, bool row_abs, bool col_abs, string dbN, string fn, string cube, ref string fn2, ref string cube2, ref StringDictionary dcdim, ref string[] dbCubesDim)
		{
			string[] elements = this.get_item(row, col);
			string dim = "";
			string item = "";
			string refer = "";

			if (row_abs && col_abs)
			{
				int pos = 0;
				if (elements[0] != "")
				{
					Excel._Worksheet ws = (Excel._Worksheet)oExcelApp.ActiveSheet;
					item = this.getFormulaFromSpreadsheet(row, col, ws);
					if (item.ToUpper().StartsWith("=PALO.ENAME("))
					{
						pos = item.IndexOf(",");
						item = item.Substring(pos+1);
						pos = item.IndexOf(",");
						item = item.Substring(0,pos);
						dim = this.get_value(item.Substring(0,pos), ws);
					}
				}
			}

			if (dim == "")
			{
				dim = this.get_cubedim(c, dbN, cube, elements);
			}

			if ((fn == elements[0]) && !item.ToUpper().StartsWith("=PALO.ENAME("))
			{
				fn2 = this.make_ref(row, col, true, true);
			}
			if ((cube == elements[0]) && !item.ToUpper().StartsWith("=PALO.ENAME("))
			{
				cube2 = this.make_ref(row, col, true, true);
			}

			refer = this.make_ref(row, col, row_abs, col_abs);
			if (dcdim.ContainsKey(dim) && (refer != cube2) && (refer != fn2))
			{
				dbCubesDim[this.get_index(dcdim, dim)] = refer;
				dcdim.Remove(dim);
			}


		}

		public string paste_func(Connection c, string host, string dbN, string cube, string datamode, bool guess)
		{
			Excel.Range eS = (Excel.Range) oExcelApp.Selection;
            

			int bCol = eS.Column;
			int bRow = eS.Row;

			string sbegin = "";
			string send = "";

			int rcount = eS.Rows.Count;
			int ccount = eS.Columns.Count;

			string fn = host + "/" + dbN;
			string cube2 = '"' + cube + '"';
			string fn2 = '"' + fn + '"';
			int i, j, k;
			string dim;
	
			string[] dbCubesDim = c.CubeListDimensions(dbN, cube);

			StringDictionary dcdim = new StringDictionary();
			k = dbCubesDim.Length;

			for (i = 0; i < k; i++)
			{
				dcdim.Add(dbCubesDim[i], i.ToString());
			}

			if (guess)
			{
				if (datamode != GeneralConst.PALO_DATAV)
				{
					for (i = bRow -1; i > 0; i--)
					{
						this.paste_func_help(c, i, bCol, true, false, dbN, fn, cube, ref fn2, ref cube2, ref dcdim, ref dbCubesDim);
					}
				}
				else
				{
					if (bRow > 1)
					{
						dim = this.get_cubedim(c, dbN, cube, this.get_item(bRow -1, bCol));

						if (dcdim.ContainsKey(dim))
						{
							sbegin = this.make_ref(bRow -1 , bCol, true, false);
							send = this.make_ref(bRow -1 , bCol + ccount -1, true, false);
							dbCubesDim[this.get_index(dcdim, dim)] = sbegin + ":" + send;
							dcdim.Remove(dim);
						}
					}
				}

				if (datamode != GeneralConst.PALO_DATAV)
				{
					for (i = bCol -1; i > 0; i--)
					{
						this.paste_func_help(c, bRow, i, false, true, dbN, fn, cube, ref fn2, ref cube2, ref dcdim, ref dbCubesDim);
					}
				}
				else
				{
					if (bCol > 1)
					{
						dim = this.get_cubedim(c, dbN, cube, this.get_item(bRow, bCol-1));

						if (dcdim.ContainsKey(dim))
						{
							sbegin = this.make_ref(bRow , bCol -1, false, true);
							send = this.make_ref(bRow + rcount -1 , bCol -1, false, true);
							dbCubesDim[this.get_index(dcdim, dim)] = sbegin + ":" + send;
							dcdim.Remove(dim);
						}
					}
				}

				for (i =1 ; i <= bRow -1; i++)
				{
					for (j = 1; j <= bCol -1; j++)
					{
						this.paste_func_help(c, i, j, true, true, dbN, fn, cube, ref fn2, ref cube2, ref dcdim, ref dbCubesDim);
					}
				}
			}
					
			for (i = 0; i < k; i++)
			{
				dim = dbCubesDim[i];
				if (dcdim.ContainsKey(dim))
				{
					try
					{
						ElementInfo[] dimDimElems = c.DimensionListElements(dbN, dim);
						
						foreach(ElementInfo dimDimElem in dimDimElems)
						{
								string element = (string)dimDimElem.Name;
								if (c.ElementParentCount(dbN, dim, element) == 0)
								{
									dbCubesDim[i] = '"' + this.EscapeDoubleQuote(element) + '"';
									break;
								}
						}
					}
					catch(Exception exc)
					{
						ErrorHandler.DisplayError("Error getting dimensions elements!", exc);
					}
				}
			}

			string formula = "";

			formula += "=" + datamode + "(";

			if (datamode == "PALO.SETDATA")
			{
				formula += "value,false,";
			}

			formula += fn2 + "," + cube2 + ",";

			foreach(string dimension in dbCubesDim)
			{
				formula += dimension + ",";
			}

			formula = formula.Substring(0,formula.Length-1) + ")";

			try
			{
				if (datamode != GeneralConst.PALO_DATAV)
				{
					this.AddFormulaToSpreadsheet(eS, formula);
                }
				else
				{
					this.AddFormulaArrayToSpreadsheet(eS, formula);
                }
			}
			catch
			{}

            if (datamode == GeneralConst.PALO_DATAX)
            {
                AddNameValue((Excel._Worksheet)oExcelApp.ActiveSheet, GeneralConst.PASTE_VIEW_X_CALC, true);
            }

            return formula;
		}
	
		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		#endregion

        #region Save As Snapshot

        public static void SaveAsSnapshot()
        {
            bool Excel2007 = GeneralConst.isNewExcel();
            string ext = ".xls";

            if (Excel2007)
            {
                ext += "x";
            }

            System.Windows.Forms.SaveFileDialog sf = new System.Windows.Forms.SaveFileDialog();
            sf.InitialDirectory = RegUtils.SavePath;
            sf.Filter = "Microsoft Office Excel Workbook (*" + ext + ")|*" + ext;
            sf.RestoreDirectory = true;
            bool su = false;
            
            #region Try to make it a bit more confortable for the end user

            int tmpFoundPos = -1;
            string tmpWbkName = oExcelApp.ActiveWorkbook.Name, addition = "_PaloSnapshot";
            tmpFoundPos = tmpWbkName.IndexOf(addition);
            if (tmpFoundPos != -1)
            {
                tmpWbkName = tmpWbkName.Substring(0, tmpFoundPos) + addition + ext;
            }
            else
            {
                if (tmpWbkName.ToLower().EndsWith(ext))
                {
                    tmpWbkName = tmpWbkName.Substring(0, tmpWbkName.Length - ext.Length) + addition + ext;
                }
                else
                {
                    tmpWbkName = tmpWbkName + addition + ext;
                }
            }

            sf.FileName = tmpWbkName;

            #endregion

            if (sf.ShowDialog() != System.Windows.Forms.DialogResult.OK || sf.FileName.Length == 0)
            {
                return;
            }
            else
            {
                string fn = FileHelper.getdirname((string)sf.FileName);
                if (!String.IsNullOrEmpty(fn))
                {
                    RegUtils.SavePath = fn;
                }

                Excel.XlCalculation tmpXlCalc = Excel.XlCalculation.xlCalculationManual;

                try
                {
                    // remember previous state and turn current off
                    su = GetScreenUpdating();
                    SetScreenUpdating(false);
                    Connect.InPaste = false;
                    EnableEvents(false);
                    PaloEnableLoop(true);

                    // make sure we have current values
                    if (oExcelApp.CalculateBeforeSave == false)
                    {
                       CalculateSpreadsheet();
                    }
                    string tmpfile = Path.GetTempFileName();
                    oExcelApp.Application.DisplayAlerts = false;

                    oExcelApp.ActiveWorkbook.SaveCopyAs(tmpfile);

                    tmpXlCalc = DisableAutomaticRecalc();

                    OpenFile(tmpfile);

                    WorkbookParser wbp = new WorkbookParser();
                    wbp.Start();
                    wbp = null;

                    SetCalculation(tmpXlCalc);
                    oExcelApp.ActiveWorkbook.Close(true, sf.FileName, om);

                    try
                    {
                        File.Delete(tmpfile);
                    }
                    catch (Exception)
                    {
                    }

                }
                catch (Exception e)
                {
                    ErrorHandler.DisplayError("Error saving snapshot!", e);
                }
                finally
                {
                    // turn everything back to normal
                    PaloEnableLoop(false);
                    Connect.InPaste = true;

                    SetCalculation(tmpXlCalc);
                    EnableEvents(true);
                    SetScreenUpdating(su);
                }

                sf.Dispose();
            } 
        }

        #endregion

        #region Reflection for COM Interop Calls
        static object SetPropertyInternational(object target, string name, params object[] args)
        {
            return target.GetType().InvokeMember(name,
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance,
                null, target, args, new System.Globalization.CultureInfo(1033));
        }

        static object GetPropertyInternational(object target, string name, params object[] args)
        {
            return target.GetType().InvokeMember(name, 
                System.Reflection.BindingFlags.GetProperty |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance,
                null, target, args, new System.Globalization.CultureInfo(1033));
        }

        static object InvokeMethodInternational(object target, string name, params object[] args)
        {
            return target.GetType().InvokeMember(name,
                System.Reflection.BindingFlags.InvokeMethod |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance,
                null, target, args, new System.Globalization.CultureInfo(1033));
        }

        #endregion

        #region Named Ranges

        public System.Collections.Generic.List<string> GetNamedRangeList(Microsoft.Office.Interop.Excel._Workbook wb)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            for (int i = 1; i <= wb.Names.Count; i++)
            {
                result.Add(wb.Names.Item(i, i, i).Name.ToString());
            }
            return result;
        }

        public System.Collections.Generic.List<string> GetNamedRangeList()
        {
        if (TestWithoutExcel) return new System.Collections.Generic.List<string>();
            return GetNamedRangeList(oExcelApp.ActiveWorkbook);
        }

        public string GetNamedRangeValue(string name)
        {
            string retval = "", wsName = "";
            int col = 0, row = 0;
            bool iserror = false;

            GetNamedRangeValue(name, ref retval, ref col, ref row, ref wsName, ref iserror);
            return retval;
        }

        // JMM 03-28-15 Corrected issues with not being enable to set EnableEvents:
        public static bool? EnableEvents(bool? enable, bool showError=true)
        {
            bool ret = true;
            try
            {
                ret = oExcelApp.EnableEvents;
            }
            catch (Exception exc)
            {
                if (showError)
                    ErrorHandler.DisplayError("Error getting EnableEventStatus !", exc);
                return null;
            }
            try
            {
            if (enable != null)
                oExcelApp.EnableEvents = (bool)enable;
            }
            catch (Exception exc)
            {
                if (showError)
                    ErrorHandler.DisplayError("Error setting EnableEventStatus !", exc);
                return null;
            }

            return ret;
        }

        public static Excel.Worksheet GetActiveWorkSheet()
        {
            return (Excel.Worksheet)ExcelHelper.oExcelApp.ActiveSheet;
        }

        public static Excel.Range GetActiveCell()
        {
            return (Excel.Range)ExcelHelper.oExcelApp.ActiveCell;
        }

        public static Excel.Range GetSelection()
        {
            return (Excel.Range)ExcelHelper.oExcelApp.Selection;
        }


        #endregion


        public static string ShortVersion()
        {
            string result = "Unknown";

            if (oExcelApp != null)
            {
                switch (oExcelApp.Version)
                {
                    case "9.0":
                        result = "2000";
                        break;

                    case "10.0":
                        result = "2002";
                        break;

                    case "11.0":
                        result = "2003";
                        break;

                    case "12.0":
                        result = "2007";
                        break;

                    case "14.0":
                        result = "2010";
                        break;
                        
                    case "15.0":
                        result = "2013";
                        break;
                }
            }

            return result;
        }

        public static Excel.Workbook GetWorkbookFromFullName(string fullname)
        {
            Excel.Workbook retval = null, act;
            int i = 1, cnt = oExcelApp.Workbooks.Count;
            while ((i <= cnt) && (retval == null))
            {
                act = oExcelApp.Workbooks[i];
                if (String.Equals(act.FullName, fullname, StringComparison.InvariantCultureIgnoreCase))
                {
                    retval = act;
                }
                i++;
            }
            return retval;
        }

        public static void OpenFile(string filename)
        {
            if (GeneralConst.isNewExcel())
            {
                // This crashes with Excel 2000
                oExcelApp.ActiveWindow.Application.Workbooks.Open(filename, om, om, om, om, om, om, om, om, om, om, om, om, false, om);
            }
            else
            {
                oExcelApp.Run("PALO.EXCEL.OPEN", filename, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om, om);
            }
        }

        public static void DataxCalc()
        {
            oExcelApp.Run("PALO.CALCSHEET");
        }

        public static Excel.Range GetFormulaArrayFromSelection()
        {
            Excel.Range eR = ExcelHelper.GetSelection();

            if (eR.Count > 1)
            {
                Excel.Range cells = eR.Cells;
                try
                {

                    cells = cells.SpecialCells(Excel.XlCellType.xlCellTypeFormulas);
                }
                catch
                {
                }

                IEnumerator it = cells.GetEnumerator();
                bool found = false;
                Excel.Range teR = null;
                while (!found && it.MoveNext())
                {
                    teR = (Excel.Range)it.Current;
                    if ((bool)teR.HasArray)
                    {
                        found = true;
                    }
                }

                if (found)
                {
                    eR = teR.CurrentArray;
                }
            }
            else
            {
                if ((bool)eR.HasArray)
                {
                   eR = eR.CurrentArray;
                }
            }

            return eR;
        }

    }

}
