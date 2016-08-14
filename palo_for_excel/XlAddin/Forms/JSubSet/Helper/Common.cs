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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
//using Crownwood.DotNetMagic.Controls;
using Jedox.Palo.Comm;
using JControls;
using Apalo.XlAddin.Utils;
using Jedox.Windows.Forms.CustomControls;

namespace Apalo.XlAddin.JSubSet
{
    public class Common
    {
        public static bool showTimiWarnings = true;
        public static string strInvalid = "#VALUE?";
        public static string Separator = ",";
        public static string Separator2 = ";";
        public static char escChar = '\\';
        public static string allElements = "\"*\"";
        
        public static string Enclose(string value, char left, char right, bool stripBounds)
        {
            StringBuilder sb = new StringBuilder(value);
            if (String.IsNullOrEmpty(value))
            {
                return left.ToString() + right.ToString();
            }
            if (stripBounds)
            {
                if (sb[0] == left)
                {
                    sb.Remove(0, 1);
                }
                if (sb.Length > 0 && sb[sb.Length - 1] == right)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
            }

            sb.Replace("" + left, "" + escChar + left);
            if (left != right)
            {
                sb.Replace("" + right, "" + escChar + right);
            }

            sb.Insert(0, left);
            sb.Append(right);

            return sb.ToString();
        }

        public static string Enclose(string value, char left, char right)
        {
            return Enclose(value, left, right, true);
        }


        public static string EncloseIf(string value, char left, char right, bool doenclose)
        {
            return (doenclose) ? Enclose(value, left, right, true) : value;
        }

        public static string EnclosePossibleNumber(string value, char left, char right)
        {
            double dummy;
            if (double.TryParse(value, out dummy))
                return value;
            else
                return Enclose(value, left, right, true);
        }

        public static string Declose(string value, char left, char right)
        {
            StringBuilder sb = new StringBuilder(value);

            if (sb.Length == 0) return "";
            if (sb[0] == left) sb.Remove(0, 1);
            if (sb.Length == 0) return "";
            if (sb[sb.Length - 1] == right) sb.Remove(sb.Length - 1, 1);
            
            sb.Replace("" + escChar + left, "" + left);
            if (left != right) sb.Replace("" + escChar + right, "" + right);
            
            return sb.ToString();
        }

        public static List<string> Parse(string value, char separator)
        {
            List<string> list = new List<string>();
            if (value.Length == 0) return list;
            string[] values = value.Split(new char[] { separator }, StringSplitOptions.None);
            foreach (string v in values)
                list.Add(v.Trim());
            return list;
        }

        public static string ReadOptionalAttribute(XmlNode node, string attr)
        {
            try
            {
                return node.Attributes[attr].Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void InternationalizeControl(Control c, bool text, bool mouseOver, ToolTip tTip)
        {
            string controlName = (c.Tag as string);
            if (!String.IsNullOrEmpty(controlName))
            {
                if (text)
                {
                    c.Text = SubsetHelper.GetI18String(controlName, "SB_", c.Text);
                }

                if (mouseOver)
                {
                    tTip.SetToolTip(c, SubsetHelper.GetI18String((c.Tag as string) + " Desc Long", "SB_"));
                }
            }
        }

        public static void InternationalizeControlTitle(JTabPage c, bool text)
        {
            string controlName = (c.Tag as string);
            if (!String.IsNullOrEmpty(controlName))
            {
                if (text)
                    c.Title = SubsetHelper.GetI18String(controlName, "SB_", c.Title);
            }
        }

        private static ASubSet aSubSet;
        public static ASubSet CurrentASubset
        {
            get { return aSubSet; }
            set { aSubSet = value; }
        }

        private static List<String> namedParams;
        public static List<String> NamedParams
        {
            get
            {
                if (namedParams == null)
                    namedParams = new List<string>();
                return namedParams;
            }
            set
            {
                namedParams = value;
            }
        }

        public static List<List<String>> GetListFromMatrix(object[,] matrix)
        {
            List<List<String>> list = new List<List<string>>();
            for (int i = 1; i <= matrix.GetLength(0); i++)
            {
                List<String> rowList = new List<string>();
                for (int j = 1; j <= matrix.GetLength(1); j++)
                    if (matrix[i, j] != null)
                        rowList.Add(matrix[i, j].ToString());
                    else
                        rowList.Add("");

                list.Add(rowList);
            }

            return list;
        }
        
        // Returns matrix in form:
        //     a11, a12; a21, a22
        public static String GetStringFromRangeValue(object value2)
        {
            try // Try to return matrix
            {
                object[,] matrix = ((object[,])value2);
                List<List<String>> list = GetListFromMatrix(matrix);

                StringBuilder sb = new StringBuilder();

                foreach (List<String> rowList in list)
                {
                    foreach (String cell in rowList)
                    {
                        sb.Append(cell);
                        sb.Append(Common.Separator);
                    }
                    if (rowList.Count > 0)
                        sb.Remove(sb.Length - 1, 1);
                    
                    sb.Append(Common.Separator2);
                }
                if (list.Count > 0)
                    sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }
            catch // If this fails, return single value
            {
                return value2.ToString();
            }
        }
    }

    public class PaloInfo
    {
        public List<string> Elements;    
        public List<string> Cubes;
        public List<string> Dimensions;
        public List<string> Aliases;
        public List<string> Attributes;

        public List<int> CubesID;
        public List<int> DimensionsID;
        public List<int> ElementsID;
        public List<int> AliasesID;
        public List<int> AttributesID;

        public JTreeView ElementsTree;

        public class ForeignElements 
        {
            public string Dimension;
            public List<int> ElementsID;
            public List<string> Elements;

            public string GetElementName(int id)
            {
                string s = "";
                try
                {
                    int ind = ElementsID.IndexOf(id);
                    s = Elements[ind];
                }
                catch (Exception)
                {
                    // MessageBox.Show(entType + " with id: " + entId + " doesn't exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return s;
            }

            public int GetElementId(string name)
            {
                int id = -1;
                try
                {
                    int ind = Elements.IndexOf(name);
                    id = ElementsID[ind];
                }
                catch (Exception)
                {
                    // MessageBox.Show(entType + " with name: \"" + entName + "\" doesn't exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return id;
            }
        }
        
        public Hashtable HTFElements;

        private PaloInfo()
        {
            Elements = new List<string>();
            Cubes = new List<string>();
            Dimensions = new List<string>();
            Aliases = new List<string>();
            Attributes = new List<string>();

            ElementsID = new List<int>();
            CubesID = new List<int>();
            DimensionsID = new List<int>();
            AliasesID = new List<int>();
            AttributesID = new List<int>();

            ElementsTree = new JTreeView();

            HTFElements = new Hashtable();
        }

        private static PaloInfo instance;

        public void ClearDimensions()
        {
            Dimensions.Clear();
            DimensionsID.Clear();
        }

        public int GetEntityID(List<string> entities, List<int> entitiesID, string entType, string entName)
        {
            int id = -1;
            try
            {
                int ind = entities.IndexOf(entName);
                id = entitiesID[ind];
            }
            catch (Exception)
            {
                // MessageBox.Show(entType + " with name: \"" + entName + "\" doesn't exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return id;
        }

        public string GetEntityName(List<string> entities, List<int> entitiesID, string entType, int entId)
        {
            string s = "";
            try
            {
                int ind = entitiesID.IndexOf(entId);
                if (ind >= 0) s = entities[ind];
            }
            catch (Exception)
            {
                // MessageBox.Show(entType + " with id: " + entId + " doesn't exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return s;
        }

        public int GetDimensionId(string dimension)
        {
            return GetEntityID(Dimensions, DimensionsID, "Dimension", dimension);
        }

        public string GetDimensionName(int id)
        {
            return GetEntityName(Dimensions, DimensionsID, "Dimension", id);
        }

        public int GetCubeId(string cube)
        {
            return GetEntityID(Cubes, CubesID, "Cube", cube);
        }

        public string GetCubeName(int id)
        {
            return GetEntityName(Cubes, CubesID, "Cube", id);
        }

        public int GetElementId(string element)
        {
            return GetEntityID(Elements, ElementsID, "Element", element);
        }

        public string GetElementName(int id)
        {
            return GetEntityName(Elements, ElementsID, "Element", id);
        }

        public int GetAliasID(string alias)
        {
            return GetEntityID(Aliases, AliasesID, "Alias", alias);
        }

        public string GetAliasName(int id)
        {
            return GetEntityName(Aliases, AliasesID, "Alias", id);
        }

        public int GetAttributeID(string attribute)
        {
            return GetEntityID(Attributes, AttributesID, "Attribute", attribute);
        }

        public string GetAttributeName(int id)
        {
            return GetEntityName(Attributes, AttributesID, "Attribute", id);
        }

        // For elements outside current dimension
        public void CreateForeignElementsEntry(Connection conn, string dbname, string dimension)
        {
            // Make dictionary entry:
            ForeignElements de = new ForeignElements();
            de.Dimension = dimension;
            de.Elements = new List<string>();
            de.ElementsID = new List<int>();

            ElementInfo[] dei = conn.DimensionListElements(dbname, dimension);
            foreach (ElementInfo deinfo in dei)
            {
                de.Elements.Add(deinfo.Name);
                de.ElementsID.Add(deinfo.Identifier);
            }

            HTFElements.Add(dimension, de);
        }
        
        public string GetForeignElementName(Connection conn, string dbname, string dimension, int id)
        {
            if (!HTFElements.ContainsKey(dimension))
                CreateForeignElementsEntry(conn, dbname, dimension);

            ForeignElements fe = HTFElements[dimension] as ForeignElements;

            return fe.GetElementName(id);
        }

        public int GetForeignElementId(Connection conn, string dbname, string dimension, string name)
        {
            if (!HTFElements.ContainsKey(dimension))
            {
                CreateForeignElementsEntry(conn, dbname, dimension);
            }

            ForeignElements fe = HTFElements[dimension] as ForeignElements;

            return fe.GetElementId(name);
        }

        // Copy TreeView to DropDownTree
        public void CopyDNMTreeToDDTree(JTreeView source, DropDownTree target)
        {
            target.Nodes.Clear();
            if (source.Nodes.Count > 0)
            {
                CopyTreeNodeCollectionToNodeCollection(source.Nodes, target.Nodes);
            }

            try
            {
                target.Nodes[0].Expand();
            }
            catch
            {
            }
        }

        public void CopyTreeNodeCollectionToNodeCollection(TreeNodeCollection nc, TreeNodeCollection tnc)
        {
            foreach (TreeNode n in nc)
            {
                TreeNode tn = n is JNode ? new JNode(n.Text) : new TreeNode(n.Text);
                tn.Name = tn.Text;
                tnc.Add(tn);
                if (n.Nodes.Count > 0)
                {
                    CopyTreeNodeCollectionToNodeCollection(n.Nodes, tn.Nodes);
                }
            }
        }

        public static PaloInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaloInfo();
                }
                return instance;
            }
        }
    }
}