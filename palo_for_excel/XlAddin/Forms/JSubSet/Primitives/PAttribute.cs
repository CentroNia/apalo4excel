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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Apalo.XlAddin.JSubSet.Primitives
{
    public partial class PAttribute : UserControl, IPrimitive
    {
        public PAttribute()
        {
            InitializeComponent();
            InitializeControls();
        }

        public DataGridView DGVAttributes
        {
            get { return dgvAttributes; }
        }

        private void InitializeControls()
        {
            dgvAttributes.BackgroundColor = Utils.ResourceInitializer.FormStdBackgroundColor;
        }

        #region IPrimitive Members

        public string SValue
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                int i;
                for (i = 0; i < dgvAttributes.Columns.Count; i++)
                {
                    sb.Append(Common.Enclose(dgvAttributes.Columns[i].HeaderText, '"', '"'));
                    sb.Append(Common.Separator);
                }
                if (i > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(Common.Separator2);
                }
                i = 0;
                foreach (DataGridViewRow row in dgvAttributes.Rows)
                {
                    if (row.IsNewRow) continue;

                    int j;
                    for (j = 0; j < row.Cells.Count; j++)
                    {
                        if (row.Cells[j].Value != null)
                            sb.Append(Common.Enclose(row.Cells[j].Value.ToString(), '"', '"'));
                        else
                            sb.Append("\"\"");
                        sb.Append(Common.Separator);
                    }
                    if (j > 0) 
                        sb.Remove(sb.Length - 1, 1);

                    sb.Append(Common.Separator2);
                    i++;
                }
                if (i > 0)
                    sb.Remove(sb.Length - 1, 1); // Remove final Separator2
                else
                {
                    int j;
                    for (j = 0; j < dgvAttributes.Columns.Count; j++)
                    {
                        sb.Append(Common.Enclose("", '"', '"'));
                        sb.Append(Common.Separator);
                    }
                    if (j > 0)
                        sb.Remove(sb.Length - 1, 1);
                }

                if (sb.Length > 0)
                    return Common.Enclose(sb.ToString(), '{', '}');
                else
                    return "";
            }
            set
            {
                dgvAttributes.Rows.Clear();
                if (value == null) return;

                List<string> el = Common.Parse(value, Common.Separator2[0]);
                if (el.Count < 2) return;
                 
                // Headers:
                List<string> headers = Common.Parse(el[0], Common.Separator[0]);

                for (int i = 1; i < el.Count; i++)
                {
                    List<string> cells = Common.Parse(el[i], Common.Separator[0]);
                    dgvAttributes.Rows.Add();
                    for (int j = 0; j < cells.Count; j++)
                        try
                        {
                            string val = Common.Declose(cells[j], '"', '"');
                            if (dgvAttributes.Columns.Contains(headers[j]))                            
                                dgvAttributes.Rows[i-1].Cells[headers[j]].Value = val;
                        }
                        catch // Silently die
                        {
                            dgvAttributes.Rows.Clear();
                            return; 
                        }
                }
            }
        }

        public void SetDefault()
        {
            dgvAttributes.Rows.Clear();
        }

        public void FillXmlFromCtrl(System.Xml.XmlWriter w)
        {
            Array[] attr = this.Attributes;
            
            if (attr.Length < 1) return;

            for (int i = 0; i < attr.Length; i++)
            {
                w.WriteStartElement("filter_col");
                int aliasID = PaloInfo.Instance.GetAttributeID(attr[i].GetValue(0).ToString());
                w.WriteElementString("attribute", aliasID.ToString());

                for (int j = 1; j < attr[i].Length; j++)
                {
                    w.WriteElementString("col_entry", attr[i].GetValue(j).ToString());
                }

                w.WriteEndElement();            
            }

        }

        public bool SetCtrlFromXml(System.Xml.XmlNode root)
        {
            dgvAttributes.Rows.Clear();
            foreach (XmlNode n in root.ChildNodes)
            {
                if (n.Name == "filter_col")
                {
                    int attributeID = 0;
                    String attributeValue = null;
                    List<string> constraints = new List<string>();
                    
                    foreach (XmlNode cn in n.ChildNodes)
                    {
                        attributeValue = null;
                        if (cn.Name == "attribute")
                        {
                            try
                            {
                                attributeID = Int32.Parse(cn.ChildNodes[0].Value);
                            }
                            catch
                            {
                                attributeValue = cn.ChildNodes[0].Value;
                            }
                        }
                        else
                        {
                            if (cn.Name == "col_entry")
                            {
                                if (cn.ChildNodes.Count > 0)
                                {
                                    constraints.Add(cn.ChildNodes[0].Value);
                                }
                                else
                                {
                                    constraints.Add("");
                                }
                            }
                        }
                    }

                    if (dgvAttributes.Rows.Count <= constraints.Count)
                    {
                        dgvAttributes.Rows.Add(constraints.Count - dgvAttributes.Rows.Count + 1);
                    }

                    if (attributeValue == null)
                    {
                        attributeValue = PaloInfo.Instance.GetAttributeName(attributeID);
                    }

                    if (attributeValue == "") continue;

                    for (int i = 0; i < constraints.Count; i++)
                    {
                        try
                        {
                            dgvAttributes.Rows[i].Cells[attributeValue].Value = constraints[i];
                        }
                        catch
                        {
                            // Skip (ignore) non-existent attribute columns:
                            break;
                        }
                    }
                }
            }

            return true;
        }

        #endregion

        #region IPrimitive Members

        // Strange Attributes format...
        public Array[] Attributes
        {
            get
            {
                List<Array> aList = new List<Array>();

                for (int i = 0; i < dgvAttributes.ColumnCount; i++)
                {
                    List<String> arrayList = new List<string>();
                    arrayList.Add(dgvAttributes.Columns[i].HeaderText);

                    for (int j = 0; j < dgvAttributes.RowCount; j++)
                    {
                        if (dgvAttributes.Rows[j].IsNewRow) continue;

                        if (dgvAttributes.Rows[j].Cells[i].Value != null)
                            arrayList.Add(dgvAttributes.Rows[j].Cells[i].Value.ToString());
                        else
                            arrayList.Add("");
                    }

                    aList.Add(arrayList.ToArray());
                }

                return aList.ToArray();
            }
        }

        private string pName;
        public string PName
        {
            get
            {
                return (pName != null && pName != "") ? pName : "Untitled";
            }
            set
            {
                pName = value;
            }
        }

        #endregion
    }
}
