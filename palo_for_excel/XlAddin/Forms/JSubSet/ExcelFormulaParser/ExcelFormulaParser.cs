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
﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Apalo.XlAddin.JSubSet;
using Jedox.Palo.Comm;

namespace Subset.Parser
{
    class ParameterValue
    {
        public String Parameter;
        public String Value;

        public static ParameterValue NewParameter(String Parameter)
        {
            ParameterValue p = new ParameterValue();
            p.Parameter = Parameter; return p;
        }

        public static ParameterValue NewValue(String Value)
        { 
            ParameterValue p = new ParameterValue(); 
            p.Value = Value; 
            return p; 
        }

    }

    class ParameterValueList
    {
        public String Parameter;
        public String[] Values;
        public String ItemName;

        public static ParameterValueList NewParameter(String Parameter)
        {
            ParameterValueList p = new ParameterValueList(); 
            p.Parameter = Parameter; 
            return p; 
        }
        
        public static ParameterValueList NewValueList(String ItemName, String[] Values)
        {
            ParameterValueList p = new ParameterValueList();
            p.ItemName = ItemName;
            p.Values = Values; 
            return p; 
        }
    }

    public class ExcelFormulaParser : ParserBase
    {
        public static XmlDocument ConvertToSubsetXml(String ExcelFormula)
        {
            ExcelFormulaParser ef = new ExcelFormulaParser();
            return ef.ConvertToXml(ExcelFormula);
        }

        private ExcelFormulaParser() { }

        private XmlDocument ConvertToXml(String formula)
        {
            ProcessString(formula);

            if (!SkipString("="))
            {
                throw new Exception("Formula must start with '='!");
            }

            Range[] args;
            String fname;
            ReadFunction(3, 10, out fname, out args);
            if (fname != "PALO.SUBSET")
            {
                throw new Exception("Missing PALO.SUBSET!");
            }

            try
            {
                String connection = getStringValue(args[0]);
                String connectionName = connection.Substring(0, connection.LastIndexOf('/'));
                String databaseName = connection.Substring(connection.LastIndexOf('/') + 1);
                Common.CurrentASubset.SetDBConn(connectionName, databaseName);
            }
            catch
            {
                throw new Exception("Connection or database not set properly");
            }

            XmlDocument d = new XmlDocument();
            
            d.InsertBefore(d.CreateXmlDeclaration("1.0", "utf-8", null), d.DocumentElement);
            d.AppendChild(d.CreateProcessingInstruction("palosubset", "version=\"1.0\""));

            XmlElement sub = d.CreateElement("subset", @"http://www.jedox.com/palo/SubsetXML");

            XmlHelper subh = new XmlHelper(d, sub);
            subh.SetAttribute("id", "0");

            String dimension = getStringValue(args[1]);
            try
            {
                Common.CurrentASubset.Dimension = dimension;
            }
            catch
            {
                throw new Exception("Dimenson not set properly!");
            }
            subh.SetAttribute("sourceDimensionId", PaloInfo.Instance.GetDimensionId(dimension).ToString()).SetAttribute("xmlns", @"http://www.jedox.com/palo/SubsetXML");

            subh.InsertElementAndValueElement("indent", RangeString(args[2]));

            if (args.Length > 3)
            {
                ParseAliasFilter(subh, args[3]);
            }
            if (args.Length > 4)
            {
                ParseHierarchyFilter(subh, args[4]);
            }
            if (args.Length > 5)
            {
                ParseTextFilter(subh, args[5]);
            }
            if (args.Length > 6)
            {
                ParseAttributeFilter(subh, args[6]);
            }
            if (args.Length > 7)
            {
                ParseDataFilter(subh, args[7]);
            }
            if (args.Length > 8)
            {
                ParsePickListFilter(subh, args[8]);
            }
            if (args.Length > 9)
            {
                ParseSortingFilter(subh, args[9]);
            }

            d.AppendChild(sub);

            return d;
        }

        private void ParseAliasFilter(XmlHelper sub, Range r)
        {

            ParameterValueList af = ParseStringParameterList("i", r);
            if (af == null)
            {
                return;
            }

            XmlHelper hf = sub.InsertElement("alias_filter");

            if (af.Parameter != null)
            {
                String[] c = af.Parameter.Split(':');
                if (c.Length > 2)
                {
                    throw new Exception("Too many cells for alias filter");
                }
                hf.InsertElementAndParameterValue("alias1", ParameterValue.NewParameter(c[0]));
                if (c.Length > 1)
                {
                    hf.InsertElementAndParameterValue("alias2", ParameterValue.NewParameter(c[1]));
                }
                sub.AppendChild(hf);
            }
            else
            {
                if (af.Values.Length > 2)
                {
                    throw new Exception("Too many aliases for alias filter");
                }
                hf.InsertElementAndParameterValue("alias1", PaloAliasIdParameter(ParameterValue.NewValue( af.Values[0] )));
                if (af.Values.Length > 1)
                {
                    hf.InsertElementAndParameterValue("alias2", PaloAliasIdParameter(ParameterValue.NewValue(af.Values[1])));
                }
                sub.AppendChild(hf);
            }
        }

        private void ParseTextFilter(XmlHelper sub, Range r)
        {
            if (r.Empty)
            {
                return;
            }

            ProcessRange(r);

            Range[] args;
            String fname;
            ReadFunction(1, 2, out fname, out args);
            if (fname != "PALO.TFILTER")
            {
                throw new Exception("Missing PALO.TFILTER!");
            }

            XmlHelper tf = sub.InsertElement("text_filter");
            tf.InsertElementAndParameterValueList("regexes", ParseStringParameterList("expression", args[0]));
            tf.InsertElementAndParameterValue("extended", ParseBoolParameter(args[1]));

            sub.AppendChild(tf);
        }

        private void ParseHierarchyFilter(XmlHelper sub, Range r)
        {
            if (r.Empty)
            {
                return;
            }

            ProcessRange(r);

            Range[] args;
            String fname;
            ReadFunction(0, 9, out fname, out args);
            if (fname != "PALO.HFILTER")
            {
                throw new Exception("Missing PALO.HFILTER!");
            }

            XmlHelper hf = sub.InsertElement("hierarchical_filter");
            if (args.Length > 0)
            {
                hf.InsertElementAndParameterValue("element", PaloElementIdParameter(ParseStringParameter(args[0])));
            }
            if (args.Length > 1)
            {
                hf.InsertElementAndParameterValue("above", ParseBoolParameter(args[1]));
            }
            if (args.Length > 2)
            {
                hf.InsertElementAndParameterValue("exclusive", ParseBoolParameter(args[2]));
            }
            if (args.Length > 3)
            {
                hf.InsertElementAndParameterValue("hide", ParseIntParameter(args[3]));
            }
            if (args.Length > 4)
            {
                hf.InsertElementAndParameterValue("revolve_element", PaloElementIdParameter(ParseStringParameter(args[4])));
            }
            if (args.Length > 5)
            {
                hf.InsertElementAndParameterValue("revolve_count", ParseIntParameter(args[5]));
            }
            if (args.Length > 6)
            {
                hf.InsertElementAndParameterValue("revolve_add", ParseIntParameter(args[6]));
            }
            if (args.Length > 7)
            {
                hf.InsertElementAndParameterValue("level_start", ParseIntParameter(args[7]));
            }
            if (args.Length > 8)
            {
                hf.InsertElementAndParameterValue("level_end", ParseIntParameter(args[8]));
            }

            sub.AppendChild(hf);
        }

        private void ParsePickListFilter(XmlHelper sub, Range r)
        {
            if (r.Empty)
            {
                return;
            }

            ProcessRange(r);

            Range[] args;
            String fname;
            ReadFunction(1, 2, out fname, out args);
            if (fname != "PALO.PICKLIST")
            {
                throw new Exception("Missing PALO.PICKLIST!");
            }

            XmlHelper plf = sub.InsertElement("picklist_filter");
            plf.InsertElementAndParameterValueList("manual_definition", PaloElementIdListParameter(ParseStringParameterList("pick_elem", args[0])));
            if (args.Length > 1)
            {
                plf.InsertElementAndParameterValue("pick_type", ParseIntParameter(args[1]));
            }

            sub.AppendChild(plf);
        }

        private void ParseAttributeFilter(XmlHelper sub, Range r)
        {
            if (r.Empty)
            {
                return;
            }

            ProcessRange(r);

            Range[] args;
            String fname;
            ReadFunction(1, 1, out fname, out args);
            if (fname != "PALO.AFILTER")
            {
                throw new Exception("Missing PALO.AFILTER!");
            }

            XmlHelper af = sub.InsertElement("attribute_filter");

            if (ArrayBrackets(args[0]))
            {
                //parse matrix
                Range[] rowStrings = GetRangeList(args[0].Inflate(-1), false, ';');
                List<String[]> rows = new List<string[]>();
                foreach (Range rs in rowStrings)
                {
                    rows.Add(GetStringList(rs, true, ','));
                }
                if (rows.Count > 0)
                {
                    XmlHelper afsv = af.InsertElement("attribute_filters").InsertElement("value");
                    for (int i = 0; i < rows[0].Length; i++)
                    {
                        XmlHelper fc = afsv.InsertElement("filter_col");
                        fc.InsertElement("attribute").InnerText = PaloInfo.Instance.GetAttributeID(rows[0][i]).ToString();
                        for (int j = 1; j < rows.Count; j++)
                        {
                            if (rows[j].Length > i)
                            {
                                fc.InsertElement("col_entry").InnerText = rows[j][i];
                            }
                        }
                    }
                }
            }
            else //parameter
            {
                af.InsertElementAndParameterValue("attribute_filters", ParameterValue.NewParameter(RangeString(args[0])));
            }

            sub.AppendChild(af);
        }

        private void ParseSortingFilter(XmlHelper sub, Range r)
        {
            if (r.Empty)
            {
                return;
            }

            ProcessRange(r);

            Range[] args;
            String fname;
            ReadFunction(0, 7, out fname, out args);
            if (fname != "PALO.SORT")
            {
                throw new Exception("Missing PALO.SORT!");
            }

            XmlHelper sf = sub.InsertElement("sorting_filter");
            if (args.Length > 0)
            {
                sf.InsertElementAndParameterValue("whole", ParseIntParameter(args[0]));
            }
            if (args.Length > 1)
            {
                sf.InsertElementAndParameterValue("sorting_criteria", ParseIntParameter(args[1]));
            }
            if (args.Length > 2)
            {
                sf.InsertElementAndParameterValue("attribute", PaloAttributeIdParameter(ParseStringParameter(args[2])));
            }
            if (args.Length > 3)
            {
                sf.InsertElementAndParameterValue("type_limitation", ParseIntParameter(args[3]));
            }
            if (args.Length > 4)
            {
                sf.InsertElementAndParameterValue("level", ParseIntParameter(args[4]));
            }
            if (args.Length > 5)
            {
                sf.InsertElementAndParameterValue("reverse", ParseIntParameter(args[5]));
            }
            if (args.Length > 6)
            {
                sf.InsertElementAndParameterValue("show_duplicates", ParseIntParameter(args[6]));
            }

            sub.AppendChild(sf);
        }

        private void ParseDataFilter(XmlHelper sub, Range r)
        {
            if (r.Empty)
            {
                return;
            }

            ProcessRange(r);

            Range[] args;
            String fname;
            ReadFunction(1, 7, out fname, out args);
            if (fname != "PALO.DFILTER")
            {
                throw new Exception("Missing PALO.DFILTER!");
            }

            XmlHelper df = sub.InsertElement("data_filter");
            ParseSubcubeFn(df, args[0]);
            if (args.Length > 1 && !args[1].Empty)
            {
                Range rr = args[1];               
                String[] list;
                if (ArrayBrackets(rr))
                {
                    list = GetStringList(rr.Inflate(-1), false, ',', ';');
                }
                else
                {
                    throw new Exception("Criteria must be in {}");
                }

                XmlHelper ddf = df.InsertElement("criteria");
                if (list.Length > 1)
                {
                    if (!Quoted(list[1]))
                    {
                        ddf.InsertElementAndParameterValue("par1", ParseDoubleParameter(list[1]));
                    }
                    else
                    {
                        ddf.InsertElementAndParameterValue("par1", ParseStringParameter(list[1]));
                    }
                    ddf.InsertRawElement("op1", Common.Declose(list[0], '"', '"'));
                }
                if (list.Length > 3)
                {
                    // We have to support: { "<=", 1, ... } AND { "<>", A4:A5, ... } AND { "=", "String", ... } 
                    if (!Quoted(list[3]))
                    {
                        ddf.InsertElementAndParameterValue("par2", ParseDoubleParameter(list[3]));
                    }
                    else
                    {
                        ddf.InsertElementAndParameterValue("par2", ParseStringParameter(list[3]));
                    }
                    ddf.InsertRawElement("op2", Common.Declose(list[2], '"', '"'));
                }
                if (list.Length > 4)
                {
                    throw new Exception("Criteria has too many elements!");
                }
                
                df.AppendChild(ddf);
            }
            if (args.Length > 2)
            {
                df.InsertElementAndParameterValue("top", ParseIntParameter(args[2]));
            }
            if (args.Length > 3)
            {
                df.InsertElementAndParameterValue("upper_percentage", ParseDoubleParameter(args[3]));
            }
            if (args.Length > 4)
            {
                df.InsertElementAndParameterValue("lower_percentage", ParseDoubleParameter(args[4]));
            }
            if (args.Length > 5)
            {
                df.InsertElementAndParameterValue("cell_operator", ParseIntParameter(args[5]));
            }
            if (args.Length > 6)
            {
                df.InsertElementAndParameterValue("no_rules", ParseIntParameter(args[6]));
            }

            sub.AppendChild(df);
        }

        private void ParseSubcubeFn(XmlHelper df, Range r)
        {
            if (r.Empty)
            {
                return;
            }

            ProcessRange(r);

            Range[] args;
            String fname;
            ReadFunction(1, 50000, out fname, out args);
            if (fname != "PALO.SUBCUBE")
            {
                throw new Exception("Missing PALO.SUBCUBE!");
            }

            XmlHelper sc = df.InsertElement("subcube");

            sc.InsertElementAndParameterValue("source_cube", PaloCubeIdParameter(ParseStringParameter(args[0])));
            for (int i = 1; i < args.Length; i++)
            {
                ParameterValueList pvl = ParseStringParameterList("element", args[i]);
                if ((pvl == null) || ((pvl.Values == null) && String.IsNullOrEmpty(pvl.Parameter)))
                {
                    sc.InsertElementAndEmptyValueElement("dimension_coordinates");
                }
                else
                {
                    /**
                     * Hack: Strings in element lists for dimension_coordinates are not supported
                     * by XML Subset Definition Schema, but this is one way to eliminate the need for
                     * querying for foreign Elements (Elements outside selected database), since
                     * these elements are not cached.
                     * To ensure that element names can never be confused for integers, PaloElementStringListParameter
                     * method encloses each element under '<' '>'
                     * */
                    sc.InsertElementAndParameterValueList("dimension_coordinates", PaloElementStringListParameter(pvl));
                }
            }            

            df.AppendChild(sc);
        }

        private String ParseBool(Range r)
        {
            if (r.Empty)
            {
                return null;
            }
            String s = RangeString(r);
            bool b;
            if (bool.TryParse(s, out b))
            {
                return b ? "true" : "false";
            }
            throw new Exception("Could not parse bool!");
        }

        private ParameterValue ParseBoolParameter(Range r)
        {
            if (r.Empty)
            {
                return null;
            }
            String s = RangeString(r);
            bool b;
            if (bool.TryParse(s, out b))
            {
                return ParameterValue.NewValue((b ? "true" : "false"));
            }
            return ParameterValue.NewParameter( s );
        }

        private String ParseInt(Range r)
        {
            if (r.Empty)
            {
                return null;
            }
            String s = RangeString(r);
            int b;
            if (int.TryParse(s, out b))
            {
                return b.ToString();
            }
            throw new Exception("Could not parse int!");
        }

        private ParameterValue ParseIntParameter(Range r)
        {
            if (r.Empty)
            {
                return null;
            }
            String s = RangeString(r);
            return ParseIntParameter(s);
        }

        private ParameterValue ParseIntParameter(String s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return null;
            }
            int b;
            if (int.TryParse(s, out b))
            {
                return ParameterValue.NewValue(b.ToString());
            }
            return ParameterValue.NewParameter( s );
        }

        private ParameterValue ParseDoubleParameter(Range r)
        {
            if (r.Empty)
            {
                return null;
            }
            String s = RangeString(r);
            return ParseDoubleParameter(s);
        }

        private ParameterValue ParseDoubleParameter(String s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return null;
            }
            double b;
            if (double.TryParse(s, out b))
            {
                return ParameterValue.NewValue(s);
            }
            return ParameterValue.NewParameter(s);
        }

        private ParameterValue ParseStringParameter(Range r)
        {
            if (r.Empty)
            {
                return null;
            }
            String s = RangeString(r);
            if (Quoted(s))
            {
                return ParameterValue.NewValue(Unquote(s));
            }
            return ParameterValue.NewParameter( s );
        }

        private ParameterValue ParseStringParameter(String s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return null;
            }
            if (Quoted(s))
            {
                return ParameterValue.NewValue(Unquote(s));
            }
            return ParameterValue.NewParameter( s );
        }

        private ParameterValueList ParseStringParameterList(String item, Range r)
        {
            if (r.Empty)
            {
                return null;
            }
            if (ArrayBrackets(r))
            {
                return ParameterValueList.NewValueList(item, GetStringList(r.Inflate(-1), true, ';', ','));
            }
            if (Quoted(r))
            {
                return ParameterValueList.NewValueList(item, new String[] { RangeString(Unquote(r)) });
            }
            return ParameterValueList.NewParameter(RangeString(r));
        }


        private bool pvCheck(ParameterValue pv)
        {
            return (pv != null) && !String.IsNullOrEmpty(pv.Value);
        }

        private bool pvlCheck(ParameterValueList pvl)
        {
            return (pvl != null) && (pvl.Values != null);
        }

        private ParameterValue PaloDimensionIdParameter(ParameterValue pv)
        {
            if (pvCheck(pv))
            {
                pv.Value = PaloInfo.Instance.GetDimensionId(Common.Declose(pv.Value, '"', '"')).ToString();
            }
            return pv;
        }

        private ParameterValue PaloAliasIdParameter(ParameterValue pv)
        {
            if (pvCheck(pv))
            {
                pv.Value = PaloInfo.Instance.GetAliasID(Common.Declose(pv.Value, '"', '"')).ToString();
            }
            return pv;
        }

        private ParameterValue PaloElementIdParameter(ParameterValue pv)
        {
            if (pvCheck(pv))
            {
                pv.Value = PaloInfo.Instance.GetElementId(Common.Declose(pv.Value, '"', '"')).ToString();
            }
            return pv;
        }

        private ParameterValue PaloCubeIdParameter(ParameterValue pv)
        {
            if (pvCheck(pv))
            {
                pv.Value = PaloInfo.Instance.GetCubeId(Common.Declose(pv.Value, '"', '"')).ToString();
            }
            return pv;
        }

        private ParameterValue PaloAttributeIdParameter(ParameterValue pv)
        {
            if (pvCheck(pv))
            {
                pv.Value = PaloInfo.Instance.GetAttributeID(Common.Declose(pv.Value, '"', '"')).ToString();
            }
            return pv;
        }

        private ParameterValueList PaloElementIdListParameter(ParameterValueList pvl)
        {
            if (pvlCheck(pvl))
            {
                for (int i = 0; i < pvl.Values.Length; i++)
                {
                    pvl.Values[i] = PaloInfo.Instance.GetElementId(Common.Declose(pvl.Values[i], '"', '"')).ToString();
                }
            }
            return pvl;
        }

        private ParameterValueList PaloElementStringListParameter(ParameterValueList pvl)
        {
            if (pvlCheck(pvl))
            {
                for (int i = 0; i < pvl.Values.Length; i++)
                {
                    pvl.Values[i] = Common.Enclose(pvl.Values[i], '<', '>');
                }
            }
            return pvl;
        }

        private String getStringValue(Range r)
        {
            String retval, arg = RangeString(r);
            if (Quoted(arg))
            {
                retval = Unquote(arg);
            }
            else
            {
                QueryXCellEventArgs qe = new QueryXCellEventArgs();
                qe.CellRange = arg;

                Common.CurrentASubset.OnQueryXCell(qe);
                retval = qe.ExcelValue;
            }
            return retval;
        }
    }

}

