 /* 
 *
 * Copyright (C) 2006-2009 Jedox AG
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

// Additional Revisions to Palo (c) Junction BI LLC:
// JMM 09-17-13 DimensionListDimElements is now DimensionListElements

using System;
using System.Collections;
using System.Collections.Generic;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.Utils
{
    public enum SubsetType { Local, Global, Formula };

    public class SubsetHelper
    {

        private const string xmlName = "subset";

        private static Hashtable htStrings = null;

        public SubsetHelper()
        {
        }
   
        private static List<string> GetSubsetListHelper(Connection c, string ServerName, string dbName, string dimensionName)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();

            try
            {
                // JMM 09-17-13
                // DimElementInfo[] sde = c.DimensionListDimElements(dbName, GeneralConst.SUBSET_DIM);
                ElementInfo[] sde = c.DimensionListElements(dbName, GeneralConst.SUBSET_DIM);
                int tmpLenght = sde.Length;
                if (tmpLenght != 0)
                {
                    // JMM 09-17-13
                    //DimElementInfo sd;
                    ElementInfo sd;
                    string user = (string.IsNullOrEmpty(ServerName)) ? null : Connections.GetCredentials(ServerName).user;
                    for (int i = 0; i < tmpLenght; i++)
                    {
                        sd = sde[i];
                        string tmpStrVal = "";
                        double tmpDblVal = 0.0;
                        try
                        {
                            if (user == null)
                            {
                                c.GetData(ref tmpStrVal, ref tmpDblVal, dbName, GeneralConst.GLOBAL_SUBSET_CUBE, new string[] { dimensionName, sd.Name });
                            }
                            else
                            {
                                c.GetData(ref tmpStrVal, ref tmpDblVal, dbName, GeneralConst.LOCAL_SUBSET_CUBE, new string[] { dimensionName, user, sd.Name });
                            }

                            if (tmpStrVal.Length != 0)
                            {
                                result.Add(sd.Name);
                            }
                        }
                        catch (Exception pe)
                        {
                            ErrorHandler.DisplayError("Error reading " + ((user == null) ? "global" : "local") + " subset value", pe);
                        }
                    }
                }
            }
            catch (Exception pe)
            {
                ErrorHandler.DisplayError("Error reading dimension elements in GetSubsetListHelper", pe);
            }

            return result;
        }

        public static List<string> GetGlobalSubsetList(Connection c, string dbName, string dimensionName)
        {
            return GetSubsetListHelper(c, null, dbName, dimensionName);
        }

        public static List<string> GetLocalSubsetList(Connection c, string ServerName, string dbName, string dimensionName)
        {
            return GetSubsetListHelper(c, ServerName, dbName, dimensionName);
        }

        public static string CubeFromType(SubsetType type)
        {
            if (type == SubsetType.Global) return GeneralConst.GLOBAL_SUBSET_CUBE;
            if (type == SubsetType.Local) return GeneralConst.LOCAL_SUBSET_CUBE;

            return "";
        }

        public static string GetI18String(string name, string prefix, String defaultValue)
        {
            if (htStrings == null)
            {
                htStrings = ResourceInitializer.HT_SB_RES;
            }
            string start = (name.StartsWith(prefix) ? "" : prefix);
            string key = start + name.ToUpper().Replace(" ", "_");

#if (DEBUG)
            // "@@@" prefix serves as a reminder to developer that the i18n string is not set:
            if (defaultValue == null || defaultValue == "") defaultValue = "@@@" + name;
#else
            // In release version, lose the "@@@":
            if (defaultValue == null || defaultValue == "") defaultValue = name;
#endif

            if ((htStrings != null) && (htStrings.ContainsKey(key)) && (htStrings[key] != null  ))
            {
                string tempstring = htStrings[key].ToString().Trim();
                return (tempstring == "" ) ? defaultValue : tempstring;
            }
            else
            {
                return defaultValue;
            }
        }


        public static string GetI18String(string name, string prefix)
        {
            return GetI18String(name, prefix, null);
        }

        public static bool DeleteSubset(Connection c, string connectionname, string database, string dimension, string subsetName, SubsetType type)
        {
            List<String> s;
            if (type == SubsetType.Global)
            {
                s = GetGlobalSubsetList(c, database, dimension);
            }
            else
            {
                s = GetLocalSubsetList(c, connectionname, database, dimension);
            }

            // IMPORTANT: After deletion, return true (if deletion succeeded)
            // or false (if deletion failed)


            try
            {
                if (s.Count > 1)
                {
                    if (type == SubsetType.Global)
                    {
                       c.SetData(database, CubeFromType(type), new string[] { dimension, subsetName }, "");
                    }
                    else
                    {
                        c.SetData(database, CubeFromType(type), new string[] { dimension, Apalo.XlAddin.Connections.GetCredentials(connectionname).user, subsetName }, "");
                    }
                }
                else
                {
                    c.DimElementDelete(database, GeneralConst.SUBSET_DIM, subsetName);
                    c.Ping();
                }

                return true;
            }
            catch (PaloException ex)
            {
                Utils.ErrorHandler.DisplayError("Error removing Subset", ex);
                return false;
            }
        }
    }
}
