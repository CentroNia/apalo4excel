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
//  JMM 09-03-14 Insert multiple dimensions in proper order
//  JMM 09-17-13 DimensionListDimElements is now DimensionListElements

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.Utils
{

    [ComVisible(false)]
    public class PasteUtils : System.IDisposable
    {
        public const string STYLEFILESTART = "palostyles_";

        private class DummyDim : object
        {
            public string dim;
            public string refer;

            public DummyDim(string dim)
            {
                this.dim = dim;
                this.refer = "";
            }
        }

        public class ElementHelper
        {
            public string name;
            public string alias;
            public string path;
            public bool HasChildren;

            public ElementHelper(string element, string asname, string withpath, bool children_yn)
            {
                this.name = element;
                this.alias = asname;
                this.path = withpath;
                this.HasChildren = children_yn;
            }
        }

        public class DimensionHelper
        {
            public string name;
            public string attribute;
            public ArrayList elements;

            public DimensionHelper(string dimension, string attrib)
            {
                this.name = dimension;
                this.attribute = attrib;
                this.elements = new ArrayList();
            }
        }

        public class StyleItem
        {
            private string shortname;
            private string longname;
            private string path;

            public StyleItem(string path)
            {
                


                this.path = path;
                this.longname = FileHelper.getfilename(path);
                this.shortname = FileHelper.getbasename(path);

                int pos = this.shortname.LastIndexOf(STYLEFILESTART, StringComparison.InvariantCultureIgnoreCase);

                if (pos > -1)
                {
                    this.shortname = this.shortname.Substring(pos + STYLEFILESTART.Length);
                }
            }

            public string getshortname()
            {
                return shortname;
            }

            override public string ToString() 
            {
                return getshortname();
            }
        }

        private const int MAX_NUMBER_OF_CELLS = 20000;
        private const string STYLE_FILE_NAME_FALLBACK = "palostyles.xls";

        private static Connection currConn;
        private static int MaxPastCol, MaxPasteRow, AttribStartX, AttribStartY;
        private static bool UseAttributesX, UseAttributesY;

        public void Dispose()
        {
        }

        public static void getAttributesvalues(ref System.Collections.Specialized.StringDictionary anames, Connection currConn, string db, string dimension, string Attribute, string[] elems, string attrib_cube, uint blocksize)
        {
            string ename, avalue;
            GetDataExportOptions opts = new GetDataExportOptions();

            string[][] dimelements = new String[2][];
            dimelements[0] = new string[1];
            dimelements[0][0] = Attribute;
            dimelements[1] = elems;

            opts.Filter.CmpOp1 = CompareOp.CompareOpTRUE;
            opts.Filter.Value1.Type = CellValueType.CellValueTypeDouble;
            opts.Filter.Value1.Value.DblValue = 0;
            opts.Filter.AndOr12 = BoolOp.BoolOpAND;
            opts.Filter.CmpOp2 = CompareOp.CompareOpTRUE;
            opts.Filter.Value2.Type = CellValueType.CellValueTypeDouble;
            opts.Filter.Value2.Value.DblValue = 0;

            opts.IngoreEmptyCells = false;
            opts.BaseElementsOnly = false;

            opts.LastCoordinates = new String[0];
            opts.NumDatasets = blocksize +1 ; // + 1 for server bug
            Dataset[] dsa = null;
            Dataset ds;

            dsa = currConn.GetDataExport(db, attrib_cube, dimelements, opts);

            int i, dsasize = dsa.Length;

            for (i = 0; i < dsasize; i++)
            {
                ds = dsa[i];
                ename = ds.Coordinates[1];
                if (ds.Value.Type == CellValueType.CellValueTypeDouble)
                {
                    avalue = ds.Value.Value.DblValue.ToString();
                }
                else
                {
                    avalue = ds.Value.Value.StrValue;
                }

                anames[ename] = avalue;
            }

        }

        public static void getAttributesvalues(ref System.Collections.Specialized.StringDictionary anames, Connection currConn, string db, string dimension, string Attribute, string[] elems, string attrib_cube)
        {
            getAttributesvalues(ref anames, currConn, db, dimension, Attribute, elems, attrib_cube, (uint)elems.Length);
        }

        private static void AdJustDimensionHelper0(string db, ref DimensionHelper dh, string oldelem, int index, ref Hashtable delems, ref Hashtable delems2)
        {
            if (index >= dh.elements.Count)
            {
                return;
            }

            ElementHelper eh = (ElementHelper)dh.elements[index];
            int i, count, len = dh.elements.Count, id;

            ChildInfoRaw[] cira = ((ElementInfo)delems2[(int)delems[oldelem]]).Children;

            count = cira.Length;

            ArrayList al = new ArrayList(count);

            for (i = 0; i < count; i++)
            {
                id = (int)cira[i].Identifier;

                if (delems2.ContainsKey(id))
                {
                    al.Add(((ElementInfo)delems2[id]).Name);
                }
            }

            while ((index < len) && al.Contains(eh.name))
            {
                dh.elements.RemoveAt(index);
                if (eh.HasChildren)
                {
                    AdJustDimensionHelper0(db, ref dh, eh.name, index, ref delems, ref delems2);
                }

                len = dh.elements.Count;
                if (index < len)
                {
                    eh = (ElementHelper)dh.elements[index];
                }
            }
        }

        private static void AdJustDimensionHelper(string hostname, string db, ref DimensionHelper dh, int index)
        {
            System.Collections.Specialized.StringDictionary anames = new System.Collections.Specialized.StringDictionary();
            ElementHelper eh = (ElementHelper)dh.elements[index];
            int i, count, len;
            string attribute = dh.attribute, dimension = dh.name, path = eh.path, name, asname, nextpath;
            currConn = Connections.GetConnection(hostname);
            ConsolidationInfo[] cia = currConn.DimElementListConsolidated(db, dimension, eh.name);
            ConsolidationInfo ci;
            count = cia.Length;

            string[] elems = new string[count];
            ArrayList al = new ArrayList(count);

            for (i=0; i < count; i++)
            {
                name = cia[i].Name;
                elems[i] = name;
                al.Add(name);
            }

            if (!string.IsNullOrEmpty(attribute))
            {
                getAttributesvalues(ref anames, currConn, db, dimension, attribute, elems, currConn.GetAttributeCube(db, dimension));
            }

            if (dh.elements.Count - 1 == index)
            {
                for (i = 0; i < count; i++)
                {
                    ci = cia[i];
                    name = ci.Name;
                    asname = (!string.IsNullOrEmpty(attribute)) ? anames[name] : name;
                    dh.elements.Add(new ElementHelper(name, asname, path + GeneralConst.PATH_DELIMTER + name, ci.Type == DimElementType.DimElementTypeConsolidated));
                }
            }
            else
            {
                index++;
                eh = (ElementHelper)dh.elements[index];
                nextpath = eh.path;
                name = eh.name;
                if (al.Contains(name) && (String.IsNullOrEmpty(nextpath) || ((path + GeneralConst.PATH_DELIMTER + name) == nextpath)))
                {
                    ElementInfo[] elemente = currConn.DimensionListElements(db, dimension);
                    ElementInfo ei;
                    long id;
                    int id2;

                    count = elemente.Length;

                    Hashtable delems = new Hashtable(count), delems2 = new Hashtable(count);

                    for (i = 0; i < count; i++)
                    {
                        ei = elemente[i];
                        id = ei.Identifier;

                        if (id > -1)
                        {
                            id2 = (int)id;
                            delems[ei.Name] = id2;
                            delems2[id2] = ei;
                        }
                    }

                    elemente = null;

                    do
                    {
                        dh.elements.RemoveAt(index);
                        if (eh.HasChildren && (index < dh.elements.Count))
                        {
                            AdJustDimensionHelper0(db, ref dh, eh.name, index, ref delems, ref delems2);
                        }
                        len = dh.elements.Count;

                        if (index < len)
                        {
                            eh = (ElementHelper)dh.elements[index];
                        }
                        name = eh.name;
                        nextpath = eh.path;
                    }
                    while ((index < len) && al.Contains(eh.name) && (String.IsNullOrEmpty(nextpath) || ((path + GeneralConst.PATH_DELIMTER + name) == nextpath)));
                    delems.Clear();
                    delems2.Clear();
                    delems = null;
                    delems2 = null;
                    GC.Collect();
                }
                else
                {
                    for (i = 0; i < count; i++)
                    {
                        ci = cia[i];
                        name = ci.Name;
                        asname = (!string.IsNullOrEmpty(attribute)) ? anames[name] : name;
                        dh.elements.Insert(index, new ElementHelper(name, asname, path + GeneralConst.PATH_DELIMTER + name, ci.Type == DimElementType.DimElementTypeConsolidated));
                        index++;
                    }
                }
            }
        }

        private static void FillDimensionHelperArrayFromDoubleClick(ref DimensionHelper[] dha, ArrayList al, int len)
        {
            int i, j, len2;
            object[] o1, o2;
            ArrayList al2;

            for (i = 0; i < len; i++)
            {
                o1 = (object[])al[i];
                /*  0 = int : row Anzeige
                 *  1 = int : col Anzeige
                 *  2 = string : Name der Dimension
                 *  3 = ArrayList : Elemente 
                 *  4 = string
                 *  5 = string
                 *  6 = string : Attribute
                 *  7 = int : row Index
                 *  8 = int : col Index
                 */
                dha[i] = new DimensionHelper(o1[2].ToString(), o1[6].ToString());
                al2 = (ArrayList)o1[3];
                len2 = al2.Count;
                dha[i].elements = new ArrayList();
                /*  0 = string : Namen 
                 *  1 = bool: Hat Kinder
                 *  2 = string : Pfad
                 *  3 = string : Attributenamen
                 */
                for (j = 0; j < len2; j++)
                {
                    o2 = (object[])al2[j];
                    dha[i].elements.Add(new ElementHelper(o2[0].ToString(), o2[3].ToString(), o2[2].ToString(), (bool)o2[1]));
                }
             }
        }

        public static bool do_doubleclick(int col, int row, Excel.XlCalculation oldcalculation)
        {
            ExcelHelper eH = new ExcelHelper();
            ArrayList GlobalDb = new ArrayList();
            ArrayList GlobalCube = new ArrayList();
            ArrayList GlobalPages = new ArrayList();
            ArrayList GlobalRows = new ArrayList();
            ArrayList GlobalCols = new ArrayList();
            ArrayList GlobalPageCoordinates = new ArrayList();
            ArrayList GlobalTableCoordinates = new ArrayList();
            ArrayList GlobalOptions = new ArrayList();
            string GlobalDataMode = "";
            string GlobalPrefix = "";
            string GlobalPostfix = "";
            bool view_exists = eH.get_ws_params2(ref GlobalDataMode, ref GlobalDb, ref GlobalCube, ref GlobalPages, ref GlobalRows, ref GlobalCols, ref GlobalPrefix, ref GlobalPostfix, ref GlobalPageCoordinates, ref GlobalTableCoordinates, ref GlobalOptions);

            if (view_exists)
            {
                string host = "";
                string db = "";
                string cube = "";
                DimensionHelper[] Pages, Rows, Cols;
                bool isIdent = false, useZeroSupression = false;
                bool ZeroSupressionAlsoCalculatedNull = false;
                bool showselector = GeneralConst.PASTE_VIEW_DEFAULT_SHOWSELECTOR_CHECKED;
                int len = 0;
                double usewidth = -1;
                
                if (GlobalDb != null && GlobalDb.Count > 0)
                {
                    host = GlobalDb[2].ToString();
                    db = (string)GlobalDb[3];
                }

                if (GlobalCube != null && GlobalCube.Count > 2)
                {
                    cube = (string)GlobalCube[2];
                }

                len = GlobalPages.Count;
                Pages = new DimensionHelper[len];
                FillDimensionHelperArrayFromDoubleClick(ref Pages, GlobalPages, len);
                len = GlobalRows.Count;
                Rows = new DimensionHelper[len];
                FillDimensionHelperArrayFromDoubleClick(ref Rows, GlobalRows, len);
                len = GlobalCols.Count;
                Cols = new DimensionHelper[len];
                FillDimensionHelperArrayFromDoubleClick(ref Cols, GlobalCols, len);

                // Bestimmen welche Row bzw Col ausgewält worden ist.
                int min_row = (int)GlobalTableCoordinates[0];
                int min_col = (int)GlobalTableCoordinates[1];
                int i, index = 0, index2 = 0, divisor = 1;

                string stylename = "";
                bool is_row = (col < min_col + Rows.Length);

                if (is_row)
                {
                    index = Rows.Length - 1 - col + min_col;
                    index2 = row - min_row - Cols.Length ;

                    for (i = 0; i < index; i++)
                    {
                        divisor *= Rows[i].elements.Count;
                    }
                    index2 /= divisor;
                    index2 %= Rows[index].elements.Count;

                    AdJustDimensionHelper(host, db, ref Rows[index], index2);

                }
                else
                {
                    index = Cols.Length - 1 - row + min_row;
                    index2 = col - min_col - Rows.Length;

                    for (i = 0; i < index; i++)
                    {
                        divisor *= Cols[i].elements.Count;
                    }
                    index2 /= divisor;
                    index2 %= Cols[index].elements.Count;

                    AdJustDimensionHelper(host, db, ref Cols[index], index2);
                }

                if (GlobalOptions.Count > 1)
                {
                    isIdent = (bool)GlobalOptions[1];
                }

                if (GlobalOptions.Count > 2)
                {
                    useZeroSupression = (bool)GlobalOptions[2];
                }

                if (GlobalOptions.Count > 3)
                {
                    usewidth = (double)GlobalOptions[3];
                }

                if (GlobalOptions.Count > 4)
                {
                    ZeroSupressionAlsoCalculatedNull = (bool)GlobalOptions[4];
                }

                if (GlobalOptions.Count > 5)
                {
                    showselector = (bool)GlobalOptions[5];
                }

                bool fixedwidth_checked = (usewidth == -1) ? false : true;

                if (GlobalOptions.Count > 6)
                {
                    stylename = GlobalOptions[6].ToString();
                }

                return do_paste_view(host, db, cube, GlobalDataMode, Pages, Rows, Cols, true, GlobalDb, GlobalCube, GlobalPageCoordinates, GlobalTableCoordinates, GlobalPages, (GlobalRows != null) ? GlobalRows.Count : 0, useZeroSupression, ZeroSupressionAlsoCalculatedNull, showselector, GeneralConst.PASTE_VIEW_DEFAULT_WRAP_CHECKED, fixedwidth_checked, (fixedwidth_checked) ? usewidth : GeneralConst.PASTE_VIEW_DEFAULT_FIXEDWIDTH, isIdent, oldcalculation, stylename, true);
            }

            return false;

        }

        private static void SetDefaultElements(ref ArrayList elements, string dbN, string dim, bool ispage)
        {
            string element;
            ElementInfo[] dimDimElems = currConn.DimensionListElements(dbN, dim);
            ElementInfo dimDimElem;

            Hashtable dimelems = new Hashtable();

            for (int j = 0; j < dimDimElems.Length; j++)
            {
                dimelems[dimDimElems[j].Identifier] = 0; // value is in this case unimportant
            }

            for (int j = 0; j < dimDimElems.Length; j++)
            {
                dimDimElem = dimDimElems[j];
                element = (string)dimDimElem.Name;
                if (!string.IsNullOrEmpty(element))
                {
                    if (TreeHelper.has_no_valid_parents(dimDimElem, dimelems))
                    {
                        elements.Add(new ElementHelper(element, element, element, dimDimElem.Type == Jedox.Palo.Comm.DimElementType.DimElementTypeConsolidated));
                        if (ispage)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static void ZeroSuppressionHelper(string db, ref DimensionHelper[] dha, Hashtable arrName2ID, ArrayList[] elements)
        {
            int i, j, len = dha.Length, len2, index;
            DimensionHelper dh;
            ElementHelper DefaultElement;
            ArrayList dimelems;
            string dim;

            for (i = 0; i < len; i++)
            {
                dh = dha[i];
                dim = dh.name;
                index = (int)arrName2ID[dim];
                dimelems = elements[index];
                len2 = dh.elements.Count;
                if (len2 > 0)
                {
                    DefaultElement = (ElementHelper)dh.elements[0];
                }
                else
                {
                    DefaultElement = new ElementHelper("", "", "", false);
                }

                for (j = len2 - 1; j > -1; j--)
                {
                    if (!dimelems.Contains(((ElementHelper)dh.elements[j]).name))
                    {
                        dh.elements.RemoveAt(j);
                    }
                }
                if (dh.elements.Count == 0)
                {
                    if (len2 > 0)
                    {
                        dh.elements.Add(DefaultElement);
                    }
                    else
                    {
                        SetDefaultElements(ref dh.elements, db, dim, false);
                    }
                }
            }
        }


        private static void ZeroSuppression(string db, string cube, DimensionHelper[] pages, ref DimensionHelper[] rows, ref DimensionHelper[] cols, Hashtable arrName2ID, bool ZeroSupressionAlsoCalculatedNull)
        {
            int i, j, k, count = pages.Length + rows.Length + cols.Length, len, len2, len3, index;
            uint count2 = 1, blocksize = 1000;
            string[][] dimelements = new String[count][];
            DimensionHelper dh;
            DimensionHelper[] dha;
            ArrayList helper = new ArrayList(new object[] { pages, rows, cols }), helper2 = new ArrayList(), helper3 = new ArrayList();
            string element;

            len = helper.Count;
            for (i = 0; i < len; i++)
            {
                dha = (DimensionHelper[])helper[i];
                len2 = dha.Length;

                for (j = 0; j < len2; j++)
                {
                    dh = dha[j];
                    index = (int)arrName2ID[dh.name];

                    len3 = dh.elements.Count;

                    helper2.Clear();
                    for (k = 0; k < len3; k++)
                    {
                        element = ((ElementHelper)dh.elements[k]).name;
                        if (!helper2.Contains(element))
                        {
                            helper2.Add(element);
                        };
                    }

                    len3 = helper2.Count;

                    dimelements[index] = new string[len3];
                    helper3.Clear();
                    for (k = 0; k < len3; k++)
                    {
                        element = (string)helper2[k];
                        if (!helper3.Contains(element))
                        {
                            dimelements[index][k] = element;
                            helper3.Add(element);
                        };
                    }
                    count2 *= (uint)len3;
                }
            }

            helper.Clear();
            helper2.Clear();
            helper3.Clear();
            GetDataExportOptions opts = new GetDataExportOptions();

            opts.Filter.CmpOp1 = (ZeroSupressionAlsoCalculatedNull) ? CompareOp.CompareOpNEQ : CompareOp.CompareOpTRUE;
            opts.Filter.Value1.Type = CellValueType.CellValueTypeDouble;
            opts.Filter.Value1.Value.DblValue = 0;
            opts.Filter.AndOr12 = BoolOp.BoolOpOR;
            opts.Filter.CmpOp2 = CompareOp.CompareOpTRUE;
            opts.Filter.Value2.Type = CellValueType.CellValueTypeDouble;
            opts.Filter.Value2.Value.DblValue = 0;

            opts.IngoreEmptyCells = true;
            opts.BaseElementsOnly = false;

            opts.LastCoordinates = new String[0];
            opts.NumDatasets = blocksize;
            double progress = 0;

            int dsasize;
            Dataset[] dsa;
            Dataset ds;
            ArrayList[] helper4 = new ArrayList[count];
            for (j = 0; j < count; j++)
            {
                helper4[j] = new ArrayList();
            }

            string coord;

            ExcelHelper.SetExcelStatusbar(ResourceInitializer.PASTE_VIEW_WAIT);

            do
            {
                dsa = currConn.GetDataExport(db, cube, dimelements, opts, true, ref progress);
                ExcelHelper.SetExcelStatusbar(ResourceInitializer.PASTE_VIEW_WAIT + " (" + ((uint)(progress * 100)) + "%)");

                dsasize = dsa.Length;

                for (i = 0; i < dsasize; i++)
                {
                    ds = dsa[i];
                    len = ds.Coordinates.Length;
                    for (j = 0; j < len; j++)
                    {
                        coord = ds.Coordinates[j];
                        if (!helper4[j].Contains(coord))
                        {
                            helper4[j].Add(ds.Coordinates[j]);
                        }
                    }
                }

                if (dsasize > 0)
                {
                    opts.LastCoordinates = dsa[dsasize-1].Coordinates;
                }

            } while (dsasize == blocksize);

            ZeroSuppressionHelper(db, ref rows, arrName2ID, helper4);
            ZeroSuppressionHelper(db, ref cols, arrName2ID, helper4);

            for (j = 0; j < count; j++)
            {
                helper4[j].Clear();
            }

        }

        private static void UpdateMaxima(int row, int col, Excel._Worksheet ws, Excel._Worksheet InitialWorksheet, ref int newmaxrow, ref int newmaxcol)
        {
            if (InitialWorksheet.Name == ws.Name)
            {
                if (row > newmaxrow)
                {
                    newmaxrow = row;
                }
                if (col > newmaxcol)
                {
                    newmaxcol = col;
                }
            }
        }

        private static void CheckAndAdd(int row, int col, ExcelHelper eH, Excel._Worksheet ws, string item, string style, Excel._Worksheet InitialWorksheet, int oldmaxrow, int oldmaxcol, ref int newmaxrow, ref int newmaxcol)
        {
            eH.AddItemToSpreadsheet(row, col, ws, item, style);

            UpdateMaxima(row, col, ws, InitialWorksheet, ref newmaxrow, ref newmaxcol);
        }

        private static void prepare_paste(ExcelHelper eH, string dim, int row1, int col1, int row2, int col2, bool row_abs, bool col_abs, ref DummyDim[] DDim, string tmpPageSheet)
        {
            string refer = eH.make_ref(row1, col1, row_abs, col_abs);
            string sheet = tmpPageSheet;

            if (!string.IsNullOrEmpty(tmpPageSheet))
            {
                if ((sheet.IndexOf(' ') > -1) || (sheet.IndexOf('"') > -1) || (sheet.IndexOf('\'') > -1))
                {
                    sheet = sheet.Replace("'", "''");
                    sheet = "'" + sheet + "'";
                }
                sheet += "!";
            }

            if ((row1 != row2) || (col1 != col2))
            {
                refer += ":" + eH.make_ref(row2, col2, row_abs, col_abs);
            }

            int i, k = DDim.Length;
            for (i = 0; i < k; i++)
            {
                if ((DDim[i].dim == dim) && (DDim[i].refer.Length == 0))
                {
                    DDim[i].refer = sheet + refer;
                    break;
                }
            }
        }

        private static void prepare_paste(ExcelHelper eH, string dim, int row, int col, bool row_abs, bool col_abs, ref DummyDim[] DDim, string tmpPageSheet)
        {
            prepare_paste(eH, dim, row, col, row, col, row_abs, col_abs, ref DDim, tmpPageSheet);
        }

        private static void prepare_paste2(string dbN, ref DummyDim[] DDim)
        {
            int i, k = DDim.Length;
            string dim = "";

            for (i = 0; i < k; i++)
            {
                if (DDim[i].refer.ToString().Length == 0)
                {
                    dim = DDim[i].dim;
                    DDim[i].refer = dim;
                    try
                    {
                        ElementInfo[] dimDimElems = currConn.DimensionListElements(dbN, DDim[i].dim);
                        for (int j = 0; j < dimDimElems.Length; j++)
                        {
                            ElementInfo dimDimElem = dimDimElems[j];
                            string element = (string)dimDimElem.Name;
                            if (currConn.ElementParentCount(dbN, dim, element) == 0)
                            {
                                DDim[i].refer = '"' + element + '"';
                                break;
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        ErrorHandler.DisplayError("Error getting dimensions elements!", exc);
                    }
                }
            }
        }

        private static void do_paste(ExcelHelper eH, string datamode, DummyDim[] DDim, string tmpConnCoordinates, string tmpCubeCoordinates)
        {
            Excel.Range eS = ExcelHelper.GetSelection();
            System.Text.StringBuilder formula = new System.Text.StringBuilder();
            formula.Append("=" + datamode + "(" + tmpConnCoordinates + "," + tmpCubeCoordinates + ",");

            int i, k = DDim.Length;
            for (i = 0; i < k; i++)
            {
                formula.Append(DDim[i].refer + ",");
            }

            string formulaS = formula.ToString().Substring(0, formula.Length - 1) + ")";

            if (datamode != GeneralConst.PALO_DATAV)
            {
                eH.AddFormulaToSpreadsheet(eS, formulaS);
            }
            else
            {
                eH.AddFormulaArrayToSpreadsheet(eS, formulaS);
            }
        }

        private static string SplitPath(string inpString, int currentLenght, ExcelHelper eH)
        {
            int chunkSize = 255;
            int maxLenght = 900;// we need some extra chars
            inpString = eH.EscapeQuote(inpString);
            int strLen = inpString.Length;
            string retString;

            if (strLen < chunkSize)
            {
                retString = inpString;
            }
            else
            {
                if (strLen < chunkSize * 2)
                {
                    retString = inpString.Substring(0, chunkSize) + '"' + '&' + '"' + inpString.Substring(chunkSize);
                }
                else
                {
                    if (strLen < chunkSize * 3)
                    {
                        retString = inpString.Substring(0, chunkSize) + '"' + '&' + '"' + inpString.Substring(chunkSize, chunkSize) + '"' + '&' + '"' + inpString.Substring(chunkSize * 2);
                    }
                    else
                    {
                        if (strLen < chunkSize * 4)
                        {
                            retString = inpString.Substring(0, chunkSize) + '"' + '&' + '"' + inpString.Substring(chunkSize, chunkSize) + '"' + '&' + '"' + inpString.Substring(chunkSize * 2, chunkSize) + '"' + '&' + '"' + inpString.Substring(chunkSize * 3, strLen - chunkSize * 3);
                        }
                        else
                        {
                            retString = inpString.Substring(0, chunkSize) + '"' + '&' + '"' + inpString.Substring(chunkSize, chunkSize) + '"' + '&' + '"' + inpString.Substring(chunkSize * 2, chunkSize) + '"' + '&' + '"' + inpString.Substring(chunkSize * 3, strLen - chunkSize * 3);
                        }
                    }
                }
            }

            // first we escape double quotes
            retString = eH.EscapeDoubleQuote(retString);

            // then we make sure we didn't screw the concat
            retString = retString.Replace("\"\"&\"\"", "\"&\"");

            if (retString.Length + currentLenght < maxLenght)
            {
                return retString;
            }
            else
            {
                return retString.Substring(0, maxLenght - currentLenght - 1);
            }
        }

        private static string[] BuildFormula(string sCube, DimensionHelper dh, ElementHelper elh, int startX, int InitStartX, int startY, int InitStartY, bool ShowFormula, bool bold, ExcelHelper eH, string tmpConnCoordinates, bool ShowSelector)
        {
            int maxExcelLength = 255;
            string name = elh.name;
            string path = elh.path;
            string attribute = dh.attribute;

            if (name.Length > maxExcelLength)
            {
                name = name.Substring(0, maxExcelLength);
            }

            string sFormula = "=PALO.ENAME(" + tmpConnCoordinates + ',' + '"' + eH.EscapeDoubleQuote(sCube) + '"' + "," + '"' + eH.EscapeDoubleQuote(name) + '"' + ",";
            string sFormulaAttrib = sFormula;

            if ((startX == InitStartX) && (startY == InitStartY) && ShowFormula && ShowSelector)
            {
                sFormulaAttrib += "2";
            }
            else if ((startX == InitStartX) && (startY == InitStartY) && ShowFormula && ShowSelector)
            {
                sFormulaAttrib += ((bold == true) ? "3" : "2");
            }
            else if (bold == true)
            {
                sFormulaAttrib += "3";
            }
            else
            {
                sFormulaAttrib += "0";
            }

            sFormulaAttrib += "," + '"' + SplitPath(path, sFormula.Length, eH) + '"';


            if (!string.IsNullOrEmpty(attribute))
            {
                sFormulaAttrib += "," + '"' + eH.EscapeDoubleQuote(attribute) + '"';
            }

            sFormulaAttrib += ')';

            return new string[2] { sFormula, sFormulaAttrib };
        }

        private static void Display1stRow(ref DummyDim[] DDim, DimensionHelper dh, int rowcount, string DataMode, ExcelHelper eH, Excel._Worksheet ws, ref int startY, int startX, bool ShowFormula, string tmpConnCoordinates, string tmpPageSheet, bool ShowSelector, bool isIndent)
        {
            string dim = dh.name;
            string attribute = dh.attribute;
            string path;
            int InitStartX = startX;
            int InitStartY = startY;
            string formula = "";
            string formulaAttrib = "";
            bool bold = false;
            int col = startX + rowcount - 1;
            int i, len = dh.elements.Count, tmpCountLevels;
            string[] tmpStrRes;
            ElementHelper elh;

            // A
            try
            {
                for (i = 0; i < len; i++)
                {
                    if (startY > MaxPasteRow)
                    {
                        break;
                    }

                    elh = (ElementHelper)dh.elements[i];

                    bold = elh.HasChildren;
                    path = elh.path;

                    tmpStrRes = BuildFormula(dim, dh, elh, startX, InitStartX, startY, InitStartY, ShowFormula, bold, eH, tmpConnCoordinates, ShowSelector);
                    formulaAttrib = tmpStrRes[1];

                    if (UseAttributesX)
                    {
                        formula = tmpStrRes[0];
                        formula += "4" + "," + '"' + SplitPath(path, formula.Length, eH) + '"' + "," + eH.GetColumnStrVal(col) + startY.ToString() + ')';
                        eH.AddFormulaToSpreadsheet(startY, AttribStartX, ws, formula, "___row1", bold, true);
                        eH.HideColumn(AttribStartX, ws, true);
                    }

                    eH.AddFormulaToSpreadsheet(startY, col, ws, formulaAttrib, "___row1", bold, true);

                    if (isIndent)
                    {
                        tmpCountLevels = (path).Split('\\').Length - 1;
                        if (tmpCountLevels > 0)
                        {
                            eH.SetIndentCell(startY, col, ws, tmpCountLevels);
                        }
                    }

                    startY++;
                }

                if (UseAttributesX == false)
                {
                    if ((GeneralConst.PALO_DATAV == DataMode))
                    {
                        prepare_paste(eH, dim, InitStartY, col, startY - 1, col, false, true, ref DDim, "");
                    }
                    else
                    {
                        prepare_paste(eH, dim, InitStartY, col, false, true, ref DDim, "");
                    }
                }
                else
                {
                    if (GeneralConst.PALO_DATAV == DataMode)
                    {
                        prepare_paste(eH, dim, InitStartY, AttribStartX, startY - 1, AttribStartX, false, true, ref DDim, "");
                    }
                    else
                    {
                        prepare_paste(eH, dim, InitStartY, AttribStartX, false, true, ref DDim, "");
                    }
                }
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error in Display1stRow", e);
            }
        }

        private static void Display2ndRow(ref DummyDim[] DDim, DimensionHelper dh, int rowcount, int cntA, string DataMode, ExcelHelper eH, Excel._Worksheet ws, ref int startY, int startX, string styleA, string styleB, bool ShowFormula, string tmpConnCoordinates, string tmpPageSheet, bool ShowSelector, bool isIndent)
        {
            string dim = dh.name;
            string attribute = dh.attribute;
            string path;
            int InitStartX = startX;
            int InitStartY = startY;
            string formula = "";
            string formulaAttrib = "";
            bool bold = false;
            ElementHelper elh;
            string[] tmpStrRes;

            // B
            try
            {
                int i, j, col = startX + rowcount - 2, len = dh.elements.Count, tmpCountLevels, tmpPrevX, tmpPrevRow;
                string to_paste;

                for (i = 0; i < len; i++)
                {
                    elh = (ElementHelper)dh.elements[i];

                    bold = elh.HasChildren;

                    for (j = 0; j < cntA; j++)
                    {
                        if (startY > MaxPasteRow)
                        {
                            break;
                        }

                        if (j == 0)
                        {
                            path = elh.path;
                            tmpStrRes = BuildFormula(dim, dh, elh, startX, InitStartX, startY, InitStartY, ShowFormula, bold, eH, tmpConnCoordinates, ShowSelector);

                            formulaAttrib = tmpStrRes[1];

                            if (UseAttributesX)
                            {
                                formula = tmpStrRes[0];
                                formula += "4" + "," + '"' + SplitPath(path, formula.Length, eH) + '"' + "," + eH.GetColumnStrVal(col) + startY.ToString() + ')';
                                eH.AddFormulaToSpreadsheet(startY, AttribStartX + 1, ws, formula, "__" + styleA, bold, true);
                                eH.HideColumn(AttribStartX + 1, ws, true);
                            }

                            eH.AddFormulaToSpreadsheet(startY, col, ws, formulaAttrib, "__" + styleA, bold, true);

                            if (isIndent)
                            {
                                tmpCountLevels = path.Split('\\').Length - 1;
                                if (tmpCountLevels > 0)
                                {
                                    eH.SetIndentCell(startY, col, ws, tmpCountLevels);
                                }
                            }

                            if (GeneralConst.PALO_DATAV != DataMode)
                            {   // Hendrik
                                if (UseAttributesX == false)
                                {
                                    prepare_paste(eH, dim, startY, col, false, true, ref DDim, "");
                                }
                                else
                                {
                                    prepare_paste(eH, dim, startY, AttribStartX + 1, false, true, ref DDim, "");
                                }
                            }
                        }
                        else
                        {
                            tmpPrevX = AttribStartX + 1;

                            if (UseAttributesX == false)
                            {
                                tmpPrevX = col;
                            }

                            tmpPrevRow = startY - 1;
                            to_paste = "=" + eH.GetColumnStrVal(tmpPrevX) + tmpPrevRow.ToString((System.IFormatProvider)System.Globalization.CultureInfo.InvariantCulture);
                            if (GeneralConst.PALO_DATAV == DataMode)
                            {   // Hendrik
                                to_paste = "=\"\"";
                            }

                            if (UseAttributesX == false)
                            {
                                eH.AddFormulaToSpreadsheet(startY, col, ws, to_paste, styleB, bold, true);
                            }
                            else
                            {
                                eH.AddFormulaToSpreadsheet(startY, AttribStartX + 1, ws, to_paste, styleB, bold, true);
                            }
                        }
                        startY++;
                    }
                }
                // Hendrik
                if (GeneralConst.PALO_DATAV == DataMode)
                {
                    if (UseAttributesX == false)
                    {
                        prepare_paste(eH, dim, InitStartY, col, startY - 1, col, false, true, ref DDim, "");
                    }
                    else
                    {
                        prepare_paste(eH, dim, InitStartY, AttribStartX + 1, startY - 1, AttribStartX + 1, false, true, ref DDim, "");
                    }
                }
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error in Display2ndRow", e);
            }
        }

        private static void Display1stColumn(ref DummyDim[] DDim, DimensionHelper dh, int colcount, string DataMode, ExcelHelper eH, Excel._Worksheet ws, int startY, ref int startX, string styleA, bool ShowFormula, string tmpConnCoordinates, string tmpPageSheet, bool ShowSelector)
        {
            string dim = dh.name;
            string attribute = dh.attribute;
            string path;
            int InitStartX = startX;
            int InitStartY = startY;
            int i, len = dh.elements.Count;
            string formula = "";
            string formulaAttrib = "";
            bool bold = false;
            int row = startY + colcount - 1; ;
            ElementHelper elh;
            string[] tmpStrRes;

            try
            {
                for (i = 0; i < len; i++)
                {
                    if (startX > MaxPastCol)
                    {
                        break;
                    }
                    elh = (ElementHelper)dh.elements[i];

                    bold = elh.HasChildren;
                    path = elh.path;

                    tmpStrRes = BuildFormula(dim, dh, elh, startX, InitStartX, startY, InitStartY, ShowFormula, bold, eH, tmpConnCoordinates, ShowSelector);
                    formulaAttrib = tmpStrRes[1];

                    if (UseAttributesY)
                    {
                        formula = tmpStrRes[0];
                        formula += "4" + "," + '"' + SplitPath(path, formula.Length, eH) + '"' + "," + eH.GetColumnStrVal(startX) + row.ToString() + ')';
                        eH.AddFormulaToSpreadsheet(AttribStartY, startX, ws, formula, "__" + styleA, bold, true);
                        eH.HideRow(AttribStartY, ws, true);
                    }

                    eH.AddFormulaToSpreadsheet(row, startX, ws, formulaAttrib, "__" + styleA, bold, true);
                    startX++;
                }

                if (UseAttributesY == false)
                {
                    if (GeneralConst.PALO_DATAV == DataMode)
                    {
                        prepare_paste(eH, dim, row, InitStartX, row, startX - 1, true, false, ref DDim, "");
                    }
                    else
                    {
                        prepare_paste(eH, dim, row, InitStartX, true, false, ref DDim, "");
                    }
                }
                else
                {
                    if (GeneralConst.PALO_DATAV == DataMode)
                    {
                        prepare_paste(eH, dim, AttribStartY, InitStartX, AttribStartY, startX - 1, true, false, ref DDim, "");
                    }
                    else
                    {
                        prepare_paste(eH, dim, AttribStartY, InitStartX, true, false, ref DDim, "");
                    }
                }
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error in Display1stColumn", e);
            }
        }

        private static void Display2ndColumn(ref DummyDim[] DDim, DimensionHelper dh, int colcount, int cntA, string Datamode, ExcelHelper eH, Excel._Worksheet ws, int startY, ref int startX, string styleA, string styleB, bool ThirdLevel, bool ShowFormula, string tmpConnCoordinates, string tmpPageSheet, bool ShowSelector)
        {
            string dim = dh.name;
            string attribute = dh.attribute;
            int InitStartX = startX;
            int InitStartY = startY;
            string formula = "";
            string formulaAttrib = "";
            bool bold = false;
            ElementHelper elh;
            string[] tmpStrRes;

            try
            {
                int i, j, row = startY + colcount - 2, len = dh.elements.Count;
                int tmpPrevX, tmpPrevY;
                string to_paste;

                for (i = 0; i < len; i++)
                {
                    elh = (ElementHelper)dh.elements[i];
                    bold = elh.HasChildren;

                    for (j = 0; j < cntA; j++)
                    {
                        if (startX > MaxPastCol)
                        {
                            break;
                        }

                        if (j == 0)
                        {
                            tmpStrRes = BuildFormula(dim, dh, elh, startX, InitStartX, startY, InitStartY, ShowFormula, bold, eH, tmpConnCoordinates, ShowSelector);
                            formulaAttrib = tmpStrRes[1];

                            if (UseAttributesY)
                            {
                                formula = tmpStrRes[0];
                                formula += "4" + "," + '"' + SplitPath(elh.path, formula.Length, eH) + '"' + "," + eH.GetColumnStrVal(startX) + row.ToString() + ')';
                                eH.AddFormulaToSpreadsheet(AttribStartY + 1, startX, ws, formula, "__" + styleA, bold, true);
                                eH.HideRow(AttribStartY + 1, ws, true);
                            }

                            eH.AddFormulaToSpreadsheet(row, startX, ws, formulaAttrib, "__" + styleA, bold, true);

                            if (GeneralConst.PALO_DATAV != Datamode)
                            {   // Hendrik
                                if (UseAttributesY == false)
                                {
                                    prepare_paste(eH, dim, row, startX, true, false, ref DDim, "");
                                }
                                else
                                {
                                    prepare_paste(eH, dim, AttribStartY + 1, startX, true, false, ref DDim, "");
                                }
                            }
                        }
                        else
                        {
                            tmpPrevX = startX + colcount - 3;
                            tmpPrevY = startY;

                            if (ThirdLevel == true)
                            {
                                tmpPrevX = startX + colcount - 4;
                                tmpPrevY = startY + 1;
                            }

                            to_paste = "";
                            if (UseAttributesY == false)
                            {
                                to_paste = "=" + eH.GetColumnStrVal(tmpPrevX) + (row).ToString((System.IFormatProvider)System.Globalization.CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                to_paste = "=" + eH.GetColumnStrVal(tmpPrevX) + (AttribStartY + 1).ToString((System.IFormatProvider)System.Globalization.CultureInfo.InvariantCulture);
                            }

                            if (GeneralConst.PALO_DATAV == Datamode)
                            {   // Hendrik
                                to_paste = "=\"\"";
                            }

                            if (UseAttributesY == false)
                            {
                                eH.AddFormulaToSpreadsheet(row, startX, ws, to_paste, styleB, bold, true);
                            }
                            else
                            {
                                eH.AddFormulaToSpreadsheet(AttribStartY + 1, startX, ws, to_paste, styleB, bold, true);
                            }
                        }
                        startX++;
                    }
                }
                // Hendrik
                if (GeneralConst.PALO_DATAV == Datamode)
                {
                    if (UseAttributesY == false)
                    {
                        prepare_paste(eH, dim, row, InitStartX, row, startX - 1, true, false, ref DDim, "");
                    }
                    else
                    {
                        prepare_paste(eH, dim, AttribStartY + 1, InitStartX, AttribStartY + 1, startX - 1, true, false, ref DDim, "");
                    }
                }
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error in Display2ndColumn", e);
            }
        }

        private static void CheckDH(ref DimensionHelper[] dha, string dbN, bool ispage)
        {
            int i, lenght = dha.Length;

            for (i = 0; i < lenght; i++)
            {
                if (dha[i].elements.Count == 0)
                {
                    SetDefaultElements(ref dha[i].elements, dbN, dha[i].name, ispage);
                }
            }
        }

        public static string GetStylesDirectory(bool nofallback)
        {
            string stylepath = GeneralConst.ExecutePath;
            if (nofallback)
            {
                stylepath += @"styles\";
            }

            return stylepath;
        }

        private static bool LoadStyleFile(string fname, Excel._Workbook awb, bool nofallback)
        {
            object om = Type.Missing;
            bool retval = true;

            string stylefile = GetStylesDirectory(nofallback) + fname;

            bool Yield = ExcelHelper.oExcelApp.Application.DisplayAlerts;

            string tmpfile = null;

            try
            {

                ExcelHelper.oExcelApp.Application.DisplayAlerts = false;

                int i, cntStyles;

                Excel.Workbook tmpBOOK = null;
                try
                {
                    tmpfile = System.IO.Path.GetTempFileName();

                    ExcelHelper.oExcelApp.ActiveWorkbook.SaveCopyAs(tmpfile);
                    ExcelHelper.OpenFile(tmpfile);
                    tmpBOOK = ExcelHelper.GetWorkbookFromFullName(tmpfile);

                    cntStyles = tmpBOOK.Styles.Count;
                    Excel.Style style;

                    for (i = cntStyles; i > 0; i--)
                    {
                        style = tmpBOOK.Styles.get_Item(i);
                        if (!style.BuiltIn)
                        {
                            style.Delete();
                        }
                    }
                }
                catch (Exception e)
                {
                    ErrorHandler.DisplayError("Unable to load copy of active book !", e);
                }

                ExcelHelper.OpenFile(stylefile);
                Excel.Workbook StyleBOOK = ExcelHelper.GetWorkbookFromFullName(stylefile);

                if ((tmpBOOK != null) && (StyleBOOK != null))
                {
                    try
                    {
                        StyleBOOK.Styles.Merge(tmpBOOK);
                    }
                    catch (Exception e)
                    {
                        ErrorHandler.DisplayError("Unable to merge builtin styles to stylefile !", e);
                    }

                    tmpBOOK.Close();
                }
                if (StyleBOOK != null)
                {
                    awb.Styles.Merge(StyleBOOK);
                    for (i = 1; i < 56; i++)
                    {
                        try
                        {
                        object c = StyleBOOK.get_Colors(i);
                        awb.set_Colors(i, c);
                        }
                        catch
                        { }
                    }
                    StyleBOOK.Close();
                }

            }
            catch (Exception exc) //COMexception
            {
                ErrorHandler.DisplayError("Unable to load template file " + stylefile + " !", exc);
                retval = false;
            }
            finally
            {
                try
                {
                    if (!string.IsNullOrEmpty(tmpfile))
                    {
                        System.IO.File.Delete(tmpfile);
                    }
                }
                catch 
                {
                }

                ExcelHelper.oExcelApp.Application.DisplayAlerts = Yield;

            }

            return retval;
        }

        public static bool do_paste_view(string hostname, string dbN, string cube, string datamode, DimensionHelper[] pages, DimensionHelper[] rows, DimensionHelper[] cols, bool ChangeTableOnly, ArrayList GlobalDb, ArrayList GlobalCube, ArrayList GlobalPageCoordinates, ArrayList GlobalTableCoordinates, ArrayList GlobalPages, int GlobalRowsCount, bool useZeroSuppression, bool ZeroSuppressionAlsoCalulatedNull, bool ShowSelector, bool wrap, bool FixedWidth, double ColWidth, bool isIndent, string stylename)
        {
            Excel.XlCalculation currCalcMethod = Excel.XlCalculation.xlCalculationAutomatic;

            try
            {
                currCalcMethod = ExcelHelper.DisableAutomaticRecalc();
            }
            catch
            { }

            return do_paste_view(hostname, dbN, cube, datamode, pages, rows, cols, ChangeTableOnly, GlobalDb, GlobalCube, GlobalPageCoordinates, GlobalTableCoordinates, GlobalPages, GlobalRowsCount, useZeroSuppression, ZeroSuppressionAlsoCalulatedNull, ShowSelector, wrap, FixedWidth, ColWidth, isIndent, currCalcMethod, stylename, false);
        }

        public static bool do_paste_view(string hostname, string dbN, string cube, string datamode, DimensionHelper[] pages, DimensionHelper[] rows, DimensionHelper[] cols, bool ChangeTableOnly, ArrayList GlobalDb, ArrayList GlobalCube, ArrayList GlobalPageCoordinates, ArrayList GlobalTableCoordinates, ArrayList GlobalPages, int GlobalRowsCount, bool useZeroSuppression, bool ZeroSuppressionAlsoCalulatedNull, bool ShowSelector, bool wrap, bool FixedWidth, double ColWidth, bool isIndent, Excel.XlCalculation oldcalculation, string stylename, bool doubleclick)
        {
            ExcelHelper eH = new ExcelHelper();
            Excel._Worksheet ws;
            Excel._Worksheet InitialWorksheet;
            string InitialWorksheetName;
            UseAttributesX = false;
            UseAttributesY = false;

            Connect.InPaste = false;
            string cns = hostname + "/" + dbN;
            object om = Type.Missing;      
            int oldmaxrow = 0, oldmaxcol = 0, newmaxrow = 0, newmaxcol = 0, i, k, l;

            string tmpConnCoordinates = '$' + "A" + '$' + "1", tmpCubeCoordinates = '$' + "A" + '$' + "2";
            bool MergeWarning = false;
            bool? EnableEvents = true;

            Excel.Range activecell = null;

            try
            {
                ExcelHelper.SetExcelStatusbar(ResourceInitializer.STATUS_GENERATE_VIEW);
                ws = ExcelHelper.GetActiveWorkSheet();
                EnableEvents = ExcelHelper.EnableEvents(false);
                if (EnableEvents == null)
                    return false;
                ExcelHelper.PaloEnableXLL(false);

                try
                {
                    activecell = ExcelHelper.GetActiveCell();
                    Excel.Range roo = activecell;
                    if (GlobalPageCoordinates != null && GlobalPageCoordinates.Count > 0 && GlobalPageCoordinates[0] != null)
                    {
                        roo = ws.get_Range((Excel.Range)ws.Cells[(int)GlobalPageCoordinates[0], (int)GlobalPageCoordinates[1]], (Excel.Range)ws.Cells[(int)GlobalPageCoordinates[2], (int)GlobalPageCoordinates[3]]);
                    }
                    else if (GlobalTableCoordinates != null && GlobalTableCoordinates.Count > 0 && GlobalTableCoordinates[0] != null)
                    {
                        roo = ws.get_Range((Excel.Range)ws.Cells[(int)GlobalTableCoordinates[0], (int)GlobalTableCoordinates[1]], (Excel.Range)ws.Cells[(int)GlobalTableCoordinates[2], (int)GlobalTableCoordinates[3]]);
                    }
                    else
                    {
                        roo = (Excel.Range)ws.get_Range((Excel.Range)ws.Cells[1, 1], (Excel.Range)ws.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing));
                    }

                    MergeWarning = (bool)roo.MergeCells;
                }
                catch
                {
                    MergeWarning = true;
                }

                if (MergeWarning == true)
                {
                    ErrorHandler.ErrorPopup(ResourceInitializer.MESSAGE_MERGED_CELLS, MessageBoxIcon.Warning);
                    return false;
                }

                ExcelHelper.SetScreenUpdating(false);

                // try to find style in current document if it fails load it from template
                Excel._Workbook awb = ExcelHelper.oExcelApp.ActiveWorkbook;

                if (!doubleclick)
                {

                    bool fallback = string.IsNullOrEmpty(stylename);

                    LoadStyleFile((fallback) ? STYLE_FILE_NAME_FALLBACK : STYLEFILESTART + stylename + ".xls", awb, !fallback);

                    try
                    {
                        Excel.Style style = null;
                        style = awb.Styles["__page"];
                        style = awb.Styles["_page"];
                        style = awb.Styles["_data"];

                        style = awb.Styles["_row1"]; // unused 
                        style = awb.Styles["___row1"];

                        style = awb.Styles["_row2"];
                        style = awb.Styles["__row2"];
                        style = awb.Styles["___row2"]; // unused

                        style = awb.Styles["_row3"]; // unused 
                        style = awb.Styles["__row3"];
                        style = awb.Styles["___row3"];

                        style = awb.Styles["_col1"];
                        style = awb.Styles["___col1"]; //unused

                        style = awb.Styles["_col2"];
                        style = awb.Styles["__col2"];
                        style = awb.Styles["___col2"]; // unused

                        style = awb.Styles["_col3"];  // unused
                        style = awb.Styles["__col3"];
                        style = awb.Styles["___col3"];

                    }
                    catch (Exception)
                    {
                        if (!LoadStyleFile(STYLE_FILE_NAME_FALLBACK, awb, false))
                        {
                            return false;
                        }
                    }
                }

                // prepare view
                string dim = "", element = "";
                string[] dbCubesDim = null;
                DummyDim[] DDim = null;
                Hashtable arrName2ID = null;

                currConn = Connections.GetConnection(hostname, false);

                CheckDH(ref pages, dbN, true);
                CheckDH(ref rows, dbN, false);
                CheckDH(ref cols, dbN, false);

                try
                {
                    dbCubesDim = currConn.CubeListDimensions(dbN, cube);
                    int i1, k1 = dbCubesDim.Length;
                    DDim = new DummyDim[k1];
                    arrName2ID = new Hashtable(k1);
                    string dimcube;
                    for (i1 = 0; i1 < k1; i1++)
                    {
                        dimcube = dbCubesDim[i1];
                        DDim[i1] = new DummyDim(dimcube);
                        arrName2ID[dimcube] = i1;
                    }
                }
                catch (Exception exp)
                {
                    ExcelHelper.SetScreenUpdating(true);
                    ErrorHandler.DisplayError("Error getting list of dimensions", exp);
                    return false;
                }

                int len, len2, len3;
                string attrib;

                MaxPastCol = GeneralConst.getMaxColumn();
                MaxPasteRow = GeneralConst.getMaxRow();

                len = rows.Length;
                for (i = 0; (i < len) && !UseAttributesX; i++)
                {
                    UseAttributesX = !String.IsNullOrEmpty(rows[i].attribute);
                }

                if (UseAttributesX)
                {
                    MaxPastCol -= len;
                }

                len = cols.Length;
                for (i = 0; (i < len) && !UseAttributesY; i++)
                {
                    UseAttributesY = !String.IsNullOrEmpty(cols[i].attribute);
                }

                if (UseAttributesY)
                {
                    MaxPasteRow -= len;
                }

                if (useZeroSuppression /*&& (rows.Length * cols.Length < 2) */)
                {
                    ZeroSuppression(dbN, cube, pages, ref rows, ref cols, arrName2ID, ZeroSuppressionAlsoCalulatedNull);
                    ExcelHelper.SetExcelStatusbar(ResourceInitializer.STATUS_GENERATE_VIEW);
                }

                eH.HideUsedRange(ws, false);
                InitialWorksheet = ExcelHelper.GetActiveWorkSheet();
                InitialWorksheetName = (string)InitialWorksheet.Name;

                if (!ChangeTableOnly)
                {
                    // clear header cells before pasting
                    if (GlobalPageCoordinates != null && GlobalPageCoordinates.Count > 0 && GlobalPageCoordinates[0] != null)
                    {
                        eH.ClearRange((int)GlobalPageCoordinates[0], (int)GlobalPageCoordinates[1], (int)GlobalPageCoordinates[2], (int)GlobalPageCoordinates[3], ws);
                    }

                }

                if (GlobalTableCoordinates != null && GlobalTableCoordinates.Count > 0 && GlobalTableCoordinates[0] != null)
                {
                    eH.ClearRange((int)GlobalTableCoordinates[0], (int)GlobalTableCoordinates[1], (int)GlobalTableCoordinates[2], (int)GlobalTableCoordinates[3], ws);
                }

                if ((GlobalPages == null) || (GlobalPages.Count != pages.Length))
                {
                    GlobalCube = null;
                    GlobalDb = null;
                    GlobalPageCoordinates = null;
                    GlobalPages = null;
                    GlobalRowsCount = 0;
                    GlobalTableCoordinates = null;
                }

                int row = 1, col = 1;
                string item, itemstyle;
                Excel._Worksheet itemws = null;

                item = cns;
                itemstyle = "__page";

                // add connection string
                if (GlobalDb == null || GlobalDb.Count == 0)
                {
                    row = 1;
                    col = 1;
                    itemws = ws;
                }
                else if (GlobalDb[4].ToString().Length == 0)
                {
                    row = (int)GlobalDb[0];
                    col = (int)GlobalDb[1];
                    itemws = ws;

                    if (GlobalDb[5].ToString().Length != 0)
                    {
                        tmpConnCoordinates = (string)GlobalDb[5];
                    }
                    else
                    {
                        tmpConnCoordinates = '$' + eH.GetColumnStrVal((int)GlobalDb[1]) + '$' + GlobalDb[0].ToString();
                    }
                }
                else
                {
                    try
                    {
                        row = (int)GlobalDb[0];
                        col = (int)GlobalDb[1];

                        itemws = eH.get_ws((string)GlobalDb[4]);
                        ws = (Excel._Worksheet)eH.get_ws(InitialWorksheetName);
                        ws.Activate();

                        if (GlobalDb[5].ToString().Length != 0)
                        {
                            tmpConnCoordinates = (string)GlobalDb[5];
                        }
                        else
                        {
                            tmpConnCoordinates = (string)GlobalDb[4] + '!' + '$' + eH.GetColumnStrVal((int)GlobalDb[1]) + '$' + GlobalDb[0].ToString();
                        }
                    }
                    catch (Exception pita)
                    {
                        ErrorHandler.DisplayError("Major Error!", pita);
                    }

                }

                if (!ChangeTableOnly)
                {
                    CheckAndAdd(row, col, eH, itemws, item, itemstyle, InitialWorksheet, oldmaxrow, oldmaxcol, ref newmaxrow, ref newmaxcol);
                }

                // add cube
                if (GlobalCube == null || GlobalCube.Count == 0)
                {
                    if (!ChangeTableOnly)
                    {
                        eH.AddItemToSpreadsheet(2, 1, ws, cube, "__page");
                        UpdateMaxima(2, 1, ws, InitialWorksheet, ref newmaxrow, ref newmaxcol);
                    }
                }
                else if (GlobalCube[3].ToString().Length == 0)
                {
                    if (!ChangeTableOnly)
                    {
                        eH.AddItemToSpreadsheet((int)GlobalCube[0], (int)GlobalCube[1], ws, cube, "__page");
                        UpdateMaxima((int)GlobalCube[0], (int)GlobalCube[1], ws, InitialWorksheet, ref newmaxrow, ref newmaxcol);
                    }
                    if (GlobalCube[4].ToString().Length != 0)
                    {
                        tmpCubeCoordinates = (string)GlobalCube[4];
                    }
                    else
                    {
                        tmpCubeCoordinates = '$' + eH.GetColumnStrVal((int)GlobalCube[1]) + '$' + GlobalCube[0].ToString();
                    }
                }
                else
                {
                    ws = eH.get_ws((string)GlobalCube[3]);
                    if (!ChangeTableOnly)
                    {
                        eH.AddItemToSpreadsheet((int)GlobalCube[0], (int)GlobalCube[1], ws, cube, "__page");
                        UpdateMaxima((int)GlobalCube[0], (int)GlobalCube[1], ws, InitialWorksheet, ref newmaxrow, ref newmaxcol);
                    }
                    if (GlobalCube[4].ToString().Length != 0)
                    {
                        tmpCubeCoordinates = (string)GlobalCube[4];
                    }
                    else
                    {
                        tmpCubeCoordinates = (string)GlobalCube[3] + '!' + '$' + eH.GetColumnStrVal((int)GlobalCube[1]) + '$' + GlobalCube[0].ToString();
                    }
                    ws = eH.get_ws(InitialWorksheetName);
                    ws.Activate();
                }

                int colY = 3;
                string formula = "";

                // Todo : use an try block, if a loading Palostyles.xls failed above
                int tmpCounter = 0;
                object[] tmpObject = null, tmpPage = null;
                bool bold = false;
                string tmpSheetName, tmpPageSheet = "", tmpName, sAttributeFormat, PageElementsSheet;

                len = pages.Length;
                DimensionHelper dh;
                ElementHelper elh;
                for (i = 0; i < len; i++)
                {
                    dh = pages[i];
                    dim = dh.name;
                    attrib = dh.attribute;
                    elh = (ElementHelper)dh.elements[0];
                    element = elh.name;
                    bold = elh.HasChildren;

                    tmpSheetName = "";
                    tmpName = "";
                    sAttributeFormat = "";

                    if (!String.IsNullOrEmpty(attrib))
                    {
                        if (String.IsNullOrEmpty(ws.CodeName))
                        {
                            tmpSheetName = ws.Name;
                        }
                        else
                        {
                            tmpSheetName = ws.CodeName;
                        }

                        tmpName = "__palo_page" + colY.ToString();
                        ExcelHelper.AddNameValue(ws, tmpName, element);
                        formula = "=PALO.ENAME(" + tmpConnCoordinates + ',' + '"' + eH.EscapeDoubleQuote(dim) + '"' + "," + '"' + eH.EscapeDoubleQuote(element) + '"' + ',' + 1 + ',' + '"' + '"' + ',' + '"' + eH.EscapeDoubleQuote(attrib) + '"' + ',' + '"' + tmpSheetName + '!' + tmpName + '"' + ')';
                        sAttributeFormat = '"' + tmpSheetName + '!' + tmpName + '"' + ";;;" + '"' + eH.EscapeDoubleQuote(elh.alias) + '"';
                    }
                    else
                    {
                        formula = "=PALO.ENAME(" + tmpConnCoordinates + ',' + '"' + eH.EscapeDoubleQuote(dim) + '"' + "," + '"' + eH.EscapeDoubleQuote(element) + '"' + ',' + 1 + ',' + '"' + '"' + ')';
                    }

                    if ((GlobalPages != null) && (tmpCounter < GlobalPages.Count))
                    {
                        tmpObject = (object[])GlobalPages[tmpCounter];
                    }
                    else
                    {
                        tmpObject = null;
                    }

                    // compare user selected content with the scanned content
                    // and if no changes were made than paste in the same place
                    // otherwise paste on the first sheet starting with 3rd row
                    if ((tmpObject != null) && ((int)tmpObject[0] != 0) && ((int)tmpObject[1] != 0) && (tmpObject[2] != null) && string.Equals(tmpObject[2].ToString(), dim, StringComparison.InvariantCultureIgnoreCase))
                    {
                        PageElementsSheet = "";

                        if ((tmpObject[4] != null) && (tmpObject[4].ToString().Length == 0))
                        {
                            eH.AddFormulaToSpreadsheet((int)tmpObject[0], (int)tmpObject[1], ws, formula, "_page", bold, true, sAttributeFormat);
                            UpdateMaxima((int)tmpObject[0], (int)tmpObject[1], ws, InitialWorksheet, ref newmaxrow, ref newmaxcol);
                        }
                        else
                        {
                            InitialWorksheet = ExcelHelper.GetActiveWorkSheet();
                            InitialWorksheetName = (string)InitialWorksheet.Name;
                            PageElementsSheet = InitialWorksheetName;
                            tmpPage = null;
                            if (GlobalPages[tmpCounter] != null)
                            {
                                tmpPage = (object[])GlobalPages[tmpCounter];
                            }

                            if (tmpPage.Length > 0 && tmpPage[4] != null)
                            {
                                PageElementsSheet = (string)tmpPage[4];
                            }
                            ws = eH.get_ws(PageElementsSheet);
                            if (!ChangeTableOnly)
                            {
                                eH.AddFormulaToSpreadsheet((int)tmpObject[0], (int)tmpObject[1], ws, formula, "_page", bold, true, sAttributeFormat);
                            }
                            ws = eH.get_ws(InitialWorksheetName);
                            ws.Activate();
                            if (PageElementsSheet.CompareTo(InitialWorksheetName) == 0)
                            {
                                UpdateMaxima((int)tmpObject[0], (int)tmpObject[1], ws, InitialWorksheet, ref newmaxrow, ref newmaxcol);
                            }
                        }

                        prepare_paste(eH, dim, (int)tmpObject[0], (int)tmpObject[1], true, true, ref DDim, PageElementsSheet);
                    }
                    else
                    {
                        if (!ChangeTableOnly)
                        {
                            eH.AddFormulaToSpreadsheet(colY, 1, ws, formula, "_page", bold, true, sAttributeFormat);
                            UpdateMaxima(colY, 1, ws, InitialWorksheet, ref newmaxrow, ref newmaxcol);
                        }

                        prepare_paste(eH, dim, colY, 1, true, true, ref DDim, tmpPageSheet);
                    }

                    tmpCounter++;
                    colY++;
                }

                // init some coordinates in case we need word wrap
                int[] tmpWrapCoords = new int[4];
                int tmpCountLevels;

                // end coordinates
                int endX = 0, endY = 0;

                // start coordinates
                int startX = rows.Length + 1;
                int startY = pages.Length + 4;
                if (GlobalTableCoordinates != null && GlobalTableCoordinates.Count > 0 && GlobalTableCoordinates[0] != null)
                {
                    int startrow = (int)GlobalTableCoordinates[0];
                    if (newmaxrow > startrow)
                    {
                        startrow = newmaxrow;
                        GlobalTableCoordinates[0] = startrow;
                    }

                    startX = (int)GlobalTableCoordinates[1] + rows.Length;
                    startY = startrow;
                }

                int tmpStartAttrib = 1;

                len = rows.Length;

                for (i = 0; i < len; i++)
                {
                    tmpStartAttrib *= rows[i].elements.Count;
                }

                AttribStartY = pages.Length + cols.Length + 4 + tmpStartAttrib;

                // assign start cell for word wrap
                tmpWrapCoords[0] = startX;
                tmpWrapCoords[1] = startY;

                int cntA = 0, cntB = 0, cntC = 0;
                int InitStartX;
                int InitStartY;
                bool ShowFormula;
                string formulaAttrib;
                string[] tmpStrRes;
                int tmpPrevX;
                int tmpPrevY;
                string to_paste;

                len = cols.Length;

                if (len == 3)
                {
                    cntC = cols[2].elements.Count;
                    cntB = cols[1].elements.Count;
                    cntA = cols[0].elements.Count;

                    len2 = cntB * cntC;

                    // A
                    for (i = 0; i < cntB * cntC; i++)
                    {
                        Display1stColumn(ref DDim, cols[0], len, datamode, eH, ws, startY, ref startX, "_col1", i == 0, tmpConnCoordinates, "", ShowSelector);
                    }

                    startX = rows.Length + 1;
                    startY = pages.Length + 4;
                    if (GlobalTableCoordinates != null && GlobalTableCoordinates.Count > 0 && GlobalTableCoordinates[0] != null)
                    {
                        startX = (int)GlobalTableCoordinates[1] + rows.Length;
                        startY = (int)GlobalTableCoordinates[0];
                    }

                    // B
                    for (i = 0; i < cntC; i++)
                    {
                        Display2ndColumn(ref DDim, cols[1], len, cntA, datamode, eH, ws, startY, ref startX, "_col2", "__col2", true, i == 0, tmpConnCoordinates, "", ShowSelector);
                    }

                    startX = rows.Length + 1;
                    startY = pages.Length + 4;
                    if (GlobalTableCoordinates != null && GlobalTableCoordinates.Count > 0 && GlobalTableCoordinates[0] != null)
                    {
                        startX = (int)GlobalTableCoordinates[1] + rows.Length;
                        startY = (int)GlobalTableCoordinates[0];
                    }

                    InitStartX = startX;
                    InitStartY = startY;
                    formula = "";
                    ShowFormula = true;
                    formulaAttrib = "";
                    bold = false;
                    row = 0;

                    dh = cols[2];
                    dim = dh.name;
                    attrib = dh.attribute;

                    len2 = dh.elements.Count;
                    len3 = cntB * cntA;

                    for (l = 0; l < len2; l++)
                    {
                        elh = (ElementHelper)dh.elements[l];
                        bold = elh.HasChildren;

                        for (k = 0; k < len3; k++)
                        {
                            if (startX > MaxPastCol)
                            {
                                break;
                            }

                            row = startY + len - 3;

                            if (k == 0)
                            {
                                tmpStrRes = BuildFormula(dim, dh, elh, startX, InitStartX, startY, InitStartY, ShowFormula, bold, eH, tmpConnCoordinates, ShowSelector);
                                formulaAttrib = tmpStrRes[1];

                                if (UseAttributesY)
                                {
                                    formula = tmpStrRes[0];
                                    formula += "4" + "," + '"' + SplitPath(elh.path, formula.Length, eH) + '"' + "," + eH.GetColumnStrVal(startX) + row.ToString() + ')';
                                    eH.AddFormulaToSpreadsheet(AttribStartY + 2, startX, ws, formula, "___col3", bold, true);
                                    eH.HideRow(AttribStartY + 2, ws, true);
                                }

                                eH.AddFormulaToSpreadsheet(row, startX, ws, formulaAttrib, "___col3", bold, true);

                                // Hendrik
                                if (GeneralConst.PALO_DATAV != datamode)
                                {
                                    if (UseAttributesY == false)
                                    {
                                        prepare_paste(eH, dim, row, startX, true, false, ref DDim, "");
                                    }
                                    else
                                    {
                                        prepare_paste(eH, dim, AttribStartY + 2, startX, true, false, ref DDim, "");
                                    }
                                }
                            }
                            else
                            {
                                tmpPrevX = startX + len - 4;
                                tmpPrevY = AttribStartY + 2;
                                to_paste = "";

                                if (UseAttributesY == false)
                                {
                                    eH.AddFormulaToSpreadsheet(row, startX, ws, "=" + eH.GetColumnStrVal(tmpPrevX) + tmpPrevY.ToString((System.IFormatProvider)System.Globalization.CultureInfo.InvariantCulture), "__col3", bold, true);
                                    to_paste = "=" + eH.GetColumnStrVal(tmpPrevX) + row.ToString((System.IFormatProvider)System.Globalization.CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    eH.AddFormulaToSpreadsheet(AttribStartY + 2, startX, ws, "=" + eH.GetColumnStrVal(tmpPrevX) + tmpPrevY.ToString((System.IFormatProvider)System.Globalization.CultureInfo.InvariantCulture), "__col3", bold, true);
                                    to_paste = "=" + eH.GetColumnStrVal(tmpPrevX) + tmpPrevY.ToString((System.IFormatProvider)System.Globalization.CultureInfo.InvariantCulture);
                                }

                                if (GeneralConst.PALO_DATAV == datamode)
                                {   // Hendrik
                                    to_paste = "=\"\"";
                                }

                                if (UseAttributesY == false)
                                {
                                    eH.AddFormulaToSpreadsheet(row, startX, ws, to_paste, "__col3", bold, true);
                                }
                                else
                                {
                                    eH.AddFormulaToSpreadsheet(AttribStartY + 2, startX, ws, to_paste, "__col3", bold, true);
                                }
                            }
                            startX++;
                        }
                    }
                    // Hendrik
                    if (GeneralConst.PALO_DATAV == datamode)
                    {
                        if (UseAttributesY == false)
                        {
                            prepare_paste(eH, dim, row, InitStartX, row, startX - 1, true, false, ref DDim, "");
                        }
                        else
                        {
                            prepare_paste(eH, dim, AttribStartY + 2, InitStartX, AttribStartY + 2, startX - 1, true, false, ref DDim, "");
                        }
                    }
                }
                else if (len == 2)
                {
                    cntB = cols[1].elements.Count;
                    cntA = cols[0].elements.Count;

                    // A
                    for (i = 0; i < cntB; i++)
                    {
                        Display1stColumn(ref DDim, cols[0], len, datamode, eH, ws, startY, ref startX, "_col1", i == 0, tmpConnCoordinates, "", ShowSelector);
                    }

                    startX = rows.Length + 1;
                    startY = pages.Length + 4;
                    if (GlobalTableCoordinates != null && GlobalTableCoordinates.Count > 0 && GlobalTableCoordinates[0] != null)
                    {
                        startX = (int)GlobalTableCoordinates[1] + rows.Length;
                        startY = (int)GlobalTableCoordinates[0];
                    }

                    // B
                    Display2ndColumn(ref DDim, cols[1], len, cntA, datamode, eH, ws, startY, ref startX, "_col2", "__col2", false, true, tmpConnCoordinates, "", ShowSelector);
                }
                else if (len == 1)
                {
                    Display1stColumn(ref DDim, cols[0], len, datamode, eH, ws, startY, ref startX, "_col1", true, tmpConnCoordinates, "", ShowSelector);
                }

                // assign end cell for word wrap
                tmpWrapCoords[2] = startX - 1;
                tmpWrapCoords[3] = startY + len - 1;

                // @@@ anpassen für Excel 2007
                if (tmpWrapCoords[0] > 0 && tmpWrapCoords[0] < 257
                    && tmpWrapCoords[1] > 0 && tmpWrapCoords[1] < 65536
                    && tmpWrapCoords[2] > 0 && tmpWrapCoords[2] < 257
                    && tmpWrapCoords[3] > 0 && tmpWrapCoords[3] < 65536
                    )
                {

                    Excel.Range tmpWrapRange = (Excel.Range)ExcelHelper.oExcelApp.get_Range((Excel.Range)ExcelHelper.oExcelApp.Cells[tmpWrapCoords[1], tmpWrapCoords[0]], (Excel.Range)ExcelHelper.oExcelApp.Cells[tmpWrapCoords[3], tmpWrapCoords[2]]);
                    tmpWrapRange.Select();
                    if (FixedWidth)
                    {
                        tmpWrapRange.ColumnWidth = ColWidth;
                    }

                    // text wrap 
                    if (wrap)
                    {
                        tmpWrapRange = (Excel.Range)ExcelHelper.oExcelApp.get_Range((Excel.Range)ExcelHelper.oExcelApp.Cells[tmpWrapCoords[1], tmpWrapCoords[0]], (Excel.Range)ExcelHelper.oExcelApp.Cells[tmpWrapCoords[3], tmpWrapCoords[2]]);
                        tmpWrapRange.Select();
                        tmpWrapRange.WrapText = true;
                        tmpWrapRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignGeneral;
                        tmpWrapRange.VerticalAlignment = Excel.XlVAlign.xlVAlignBottom;
                        tmpWrapRange.WrapText = true;
                        tmpWrapRange.Orientation = 0;
                        tmpWrapRange.AddIndent = false;
                        tmpWrapRange.ShrinkToFit = false;
                        tmpWrapRange.MergeCells = false;
                    }
                }

                endX = startX;

                // start coordinates
                tmpStartAttrib = 1;

                len = cols.Length;

                for (i = 0; i < len; i++)
                {
                    tmpStartAttrib *= cols[i].elements.Count;
                }

                AttribStartX = rows.Length + tmpStartAttrib + 1;

                startX = 1;
                startY = pages.Length + 4 + cols.Length;

                if (GlobalTableCoordinates != null
                    && GlobalTableCoordinates.Count > 0
                    && GlobalTableCoordinates[0] != null
                    && GlobalRowsCount > 0)
                {
                    startX = (int)GlobalTableCoordinates[1];
                    startY = (int)GlobalTableCoordinates[0] + cols.Length;
                }

                len = rows.Length;
                cntA = 0;
                cntB = 0;
                cntC = 0;

                if (len == 3)
                {
                    string path;
                    cntC = rows[2].elements.Count;
                    cntB = rows[1].elements.Count;
                    cntA = rows[0].elements.Count;

                    // A
                    for (i = 0; i < cntB * cntC; i++)
                    {
                        Display1stRow(ref DDim, rows[0], len, datamode, eH, ws, ref startY, startX, i == 0, tmpConnCoordinates, "", ShowSelector, isIndent);
                    }

                    startX = 1;
                    startY = pages.Length + 4 + cols.Length;
                    if (GlobalTableCoordinates != null
                        && GlobalTableCoordinates.Count > 0
                        && GlobalTableCoordinates[0] != null
                        && GlobalRowsCount > 0)
                    {
                        startX = (int)GlobalTableCoordinates[1];
                        startY = (int)GlobalTableCoordinates[0] + cols.Length;
                    }

                    // B
                    for (i = 0; i < cntC; i++)
                    {
                        Display2ndRow(ref DDim, rows[1], len, cntA, datamode, eH, ws, ref startY, startX, "_row2", "__row2", i == 0, tmpConnCoordinates, "", ShowSelector, isIndent);
                    }

                    startX = 1;
                    startY = pages.Length + 4 + cols.Length;
                    if (GlobalTableCoordinates != null
                        && GlobalTableCoordinates.Count > 0
                        && GlobalTableCoordinates[0] != null
                        && GlobalRowsCount > 0)
                    {
                        startX = (int)GlobalTableCoordinates[1];
                        startY = (int)GlobalTableCoordinates[0] + cols.Length;
                    }

                    InitStartX = startX;
                    InitStartY = startY;
                    formula = "";
                    ShowFormula = true;
                    formulaAttrib = "";
                    bold = false;
                    col = 0;

                    dh = rows[2];
                    dim = dh.name;
                    attrib = dh.attribute;

                    len2 = dh.elements.Count;
                    len3 = cntB * cntA;

                    // C
                    for (l = 0; l < len2; l++)
                    {
                        elh = (ElementHelper)dh.elements[l];

                        bold = elh.HasChildren;
                        path = elh.path;

                        for (k = 0; k < len3; k++)
                        {
                            if (startY > MaxPasteRow)
                            {
                                break;
                            }

                            col = startX + len - 3;

                            if (k == 0)
                            {
                                tmpStrRes = BuildFormula(dim, dh, elh, startX, InitStartX, startY, InitStartY, ShowFormula, bold, eH, tmpConnCoordinates, ShowSelector);
                                formulaAttrib = tmpStrRes[1];

                                if (UseAttributesX)
                                {
                                    formula = tmpStrRes[0];
                                    formula += "4" + "," + '"' + SplitPath(path, formula.Length, eH) + '"' + "," + eH.GetColumnStrVal(col) + startY.ToString() + ')';
                                    eH.AddFormulaToSpreadsheet(startY, AttribStartX + 2, ws, formula, "___row3", bold, true);
                                    eH.HideColumn(AttribStartX + 2, ws, true);
                                }

                                eH.AddFormulaToSpreadsheet(startY, col, ws, formulaAttrib, "___row3", bold, true);

                                if (isIndent)
                                {
                                    tmpCountLevels = path.Split('\\').Length - 1;
                                    if (tmpCountLevels > 0)
                                    {
                                        eH.SetIndentCell(startY, col, ws, tmpCountLevels);
                                    }
                                }

                                // Hendrik
                                if (GeneralConst.PALO_DATAV != datamode)
                                {
                                    if (UseAttributesX == false)
                                    {
                                        prepare_paste(eH, dim, startY, col, false, true, ref DDim, "");
                                    }
                                    else
                                    {
                                        prepare_paste(eH, dim, startY, AttribStartX + 2, false, true, ref DDim, "");
                                    }
                                }
                            }
                            else
                            {
                                tmpPrevX = AttribStartX + 2;// startX + len - 4;
                                tmpPrevY = startY - 1;
                                to_paste = "";

                                if (UseAttributesX == false)
                                {
                                    to_paste = "=" + eH.GetColumnStrVal(startX + len - 4) + tmpPrevY.ToString((System.IFormatProvider)System.Globalization.CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    to_paste = "=" + eH.GetColumnStrVal(tmpPrevX) + tmpPrevY.ToString((System.IFormatProvider)System.Globalization.CultureInfo.InvariantCulture);
                                }

                                if (GeneralConst.PALO_DATAV == datamode)
                                {   // Hendrik
                                    to_paste = "=\"\"";
                                }

                                if (UseAttributesX == false)
                                {
                                    eH.AddFormulaToSpreadsheet(startY, col, ws, to_paste, "__row3", bold, true);
                                }
                                else
                                {
                                    eH.AddFormulaToSpreadsheet(startY, AttribStartX + 2, ws, to_paste, "__row3", bold, true);
                                }
                            }
                            startY++;
                        }
                    }

                    // Hendrik
                    if (GeneralConst.PALO_DATAV == datamode)
                    {
                        if (UseAttributesX == false)
                        {
                            prepare_paste(eH, dim, InitStartY, col, startY - 1, col, false, true, ref DDim, "");
                        }
                        else
                        {
                            prepare_paste(eH, dim, InitStartY, AttribStartX + 2, startY - 1, AttribStartX + 2, false, true, ref DDim, "");
                        }
                    }
                }
                else if (len == 2)
                {
                    // JMM 09-03-14 Swap to insert in proper order:
                    DimensionHelper temp = rows[0];
                    rows[0] = rows[1];
                    rows[1] = temp;

                    cntB = rows[1].elements.Count;
                    cntA = rows[0].elements.Count;

                    // A
                    for (i = 0; i < cntB; i++)
                    {
                        Display1stRow(ref DDim, rows[0], len, datamode, eH, ws, ref startY, startX, i == 0, tmpConnCoordinates, "", ShowSelector, isIndent);
                    }

                    startX = 1;
                    startY = pages.Length + 4 + cols.Length;
                    if (GlobalTableCoordinates != null
                        && GlobalTableCoordinates.Count > 0
                        && GlobalTableCoordinates[0] != null
                        && GlobalRowsCount > 0)
                    {
                        startX = (int)GlobalTableCoordinates[1];
                        startY = (int)GlobalTableCoordinates[0] + cols.Length;
                    }

                    // B
                    Display2ndRow(ref DDim, rows[1], len, cntA, datamode, eH, ws, ref startY, startX, "_row2", "__row2", true, tmpConnCoordinates, "", ShowSelector, isIndent);
                }
                else if (len == 1)
                {
                    Display1stRow(ref DDim, rows[0], len, datamode, eH, ws, ref startY, startX, true, tmpConnCoordinates, "", ShowSelector, isIndent);
                }

                prepare_paste2(dbN, ref DDim);

                endY = startY;
                startX = rows.Length + 1;
                startY = pages.Length + cols.Length + 4;
                if ((GlobalTableCoordinates != null) && (GlobalTableCoordinates.Count > 0) && (GlobalTableCoordinates[0] != null))
                {
                    startX = (int)GlobalTableCoordinates[1] + rows.Length;
                    startY = (int)GlobalTableCoordinates[0] + cols.Length;
                }

                try
                {
                    eH.AddItemToSpreadsheet(startY, startX, ws, "");
                }
                catch (Exception err1)//(COMException)
                {
                    ErrorHandler.DisplayError("Major error", err1);
                    ExcelHelper.SetScreenUpdating(true);
                    return false;
                }

                if (endY - 1 < startY)
                {
                    endY = startY + 1;
                }

                if (endX - 1 < startX)
                {
                    endX = startX + 1;
                }

                Excel.Range r = ws.get_Range((Excel.Range)ws.Cells[startY, startX], (Excel.Range)ws.Cells[endY - 1, endX - 1]);

                int cellcount = r.Count;
                if (cellcount >= MAX_NUMBER_OF_CELLS)
                {
                    int tmpLimitToNoRows = Convert.ToInt32(Math.Floor((double)(MAX_NUMBER_OF_CELLS / (((endX - startX != 0) ? endX - startX : 1)))));
                    if (MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.MESSAGE_LIMIT_VIEW_SIZE, new object[] { MAX_NUMBER_OF_CELLS, tmpLimitToNoRows, cellcount }), ResourceInitializer.PASTE_VIEW_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        r = ws.get_Range((Excel.Range)ws.Cells[startY, startX], (Excel.Range)ws.Cells[startY + tmpLimitToNoRows - 1, endX - 1]);
                    }
                }
                r.Style = "_data";
                r.Select();

                if (FixedWidth)
                {
                    r.ColumnWidth = ColWidth;
                }

                do_paste(eH, datamode, DDim, tmpConnCoordinates, tmpCubeCoordinates);

                ExcelHelper.AddNameValue(InitialWorksheet, GeneralConst.PASTE_VIEW_IDENT, isIndent);
                ExcelHelper.AddNameValue(InitialWorksheet, GeneralConst.PASTE_VIEW_ZEROSUPPRESSION, useZeroSuppression);
                ExcelHelper.AddNameValue(InitialWorksheet, GeneralConst.PASTE_VIEW_ZEROSUPPRESSIONALSOCALCULATEDNULL, ZeroSuppressionAlsoCalulatedNull);

                double usewidth = ((FixedWidth) ? ColWidth : -1);

                ExcelHelper.AddNameValue(InitialWorksheet, GeneralConst.PASTE_VIEW_COLWIDTH, usewidth);
                if (!string.IsNullOrEmpty(stylename))
                {
                    ExcelHelper.AddNameValue(InitialWorksheet, GeneralConst.PASTE_VIEW_STYLE, stylename);
                }

                if (datamode == GeneralConst.PALO_DATAX)
                {
                    ExcelHelper.AddNameValue(InitialWorksheet, GeneralConst.PASTE_VIEW_X_CALC, true);
                }

                if (FixedWidth)
                {
                    r.ColumnWidth = ColWidth;
                }

                if (activecell != null)
                {
                    activecell.Select();
                }

                Connect.SetCurrFormulaFromActiveCell();

                try
                {
                    ExcelHelper.PaloEnableXLL(true);
                    ExcelHelper.SetCalculation(oldcalculation);

                    if (oldcalculation != Excel.XlCalculation.xlCalculationAutomatic)
                    {
                        ExcelHelper.CalculateSpreadsheet();
                    }

                    // because of some strange behaviour od Datax
                    if (datamode == GeneralConst.PALO_DATAX)
                    {
                        ExcelHelper.DataxCalc();
                    }

                }
                catch (Exception err1)
                {
                    ErrorHandler.DisplayError("Major error", err1);
                }

                for (i = 1; i <= rows.Length; i++)
                {
                    eH.AutofitColumn(i, ws);
                }
            }
            catch (PaloException exc)
            {
                MessageBox.Show(exc.PaloMessage);
                // ExcelHelper.oExcelApp.Undo(); Unfortunatly this will throw an execption.

            }
            finally
            {
                ws = null;
                eH = null;
                ExcelHelper.ResetExcelStatusbar();
                ExcelHelper.SetScreenUpdating(true);
                ExcelHelper.PaloEnableXLL(true);
                ExcelHelper.EnableEvents(EnableEvents);
            }
            Connect.InPaste = true;
            return true;
        }

    }
}
