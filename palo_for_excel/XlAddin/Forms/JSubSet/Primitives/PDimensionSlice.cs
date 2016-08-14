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
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Apalo.XlAddin.Forms;
using System.Xml;

namespace Apalo.XlAddin.JSubSet.Primitives
{
    public partial class PDimensionSlice : LinkLabel, IPrimitive
    {
        public PDimensionSlice()
        {
            InitializeComponent();
            InitializeControls();
        }

        public PDimensionSlice(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeControls();
        }

        public String Dimension
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public String elementList;
        public String ElementList
        {
            get 
            {
                if (this.Dimension == Common.CurrentASubset.Dimension)
                    return "";

                if (elementList != null && elementList.Length > 0)
                    return elementList;
                else
                    return Common.allElements;
            }
            set 
            {
                elementList = value;
                SetSelectionAndLabelFromElementList(elementList);
            }
        }

        public ArrayList selection;
        public ArrayList Selection
        {
            get { return selection; }
            set 
            { 
                selection = value; 
                FillElementListAndLabelFromSelection(this.selection); 
            }
        }

        private Label lbElements;
        public Label LBElements
        {
            get { return lbElements; }
        }

        public void FillElementListAndLabelFromSelection(ArrayList selection)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbLabel = new StringBuilder();

            foreach (object[] o in selection)
            {
                sb.Append(Common.Enclose((string)o[0], '"', '"'));
                sb.Append(Common.Separator);

                sbLabel.Append((string)o[0]);
                sbLabel.Append(Common.Separator);
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
                sbLabel.Remove(sbLabel.Length - 1, 1);
            }

            this.elementList = sb.ToString();
            this.lbElements.Text = sbLabel.ToString();
        }

        public void SetSelectionAndLabelFromElementList(String elementList)
        {
            if (elementList == null || elementList == Common.allElements) 
            {
                this.selection = new ArrayList();
                this.lbElements.Text = "";
                return;
            }

            // Else:

            String elString = Common.Declose(elementList, '{', '}');
            List<String> eList = Common.Parse(elString, Common.Separator[0]);
            StringBuilder sbLabel = new StringBuilder();
            
            this.selection = new ArrayList();
            foreach (String s in eList)
            {
                string element = Common.Declose(s, '"', '"');
                this.selection.Add(new object[]
                {
                    element
                });

                sbLabel.Append(element);
                sbLabel.Append(Common.Separator);

            }
            if (sbLabel.Length > 0)
                sbLabel.Remove(sbLabel.Length - 1, 1);

            this.lbElements.Text = sbLabel.ToString();
        }

        public void SetAllFromElementIDList(List<int> elementIDList)
        {
            if (elementIDList == null || (elementIDList.Count == 1 && elementIDList[0] == -1))
            {
                this.ElementList = Common.allElements;
                this.selection = new ArrayList();
                this.lbElements.Text = "";
                return;
            }

            StringBuilder sb = new StringBuilder();
            StringBuilder sbLabel = new StringBuilder();
            this.selection = new ArrayList();

            foreach (int id in elementIDList)
            {
                string element = PaloInfo.Instance.GetForeignElementName(Common.CurrentASubset.Connection, Common.CurrentASubset.DatabaseName, this.Dimension, id);
                if (element != "") // Ignore non-existent elements
                {
                    this.selection.Add(new object[] {
                        element
                    });

                    sb.Append(Common.Enclose(element, '"', '"'));
                    sb.Append(Common.Separator);

                    sbLabel.Append(element);
                    sbLabel.Append(Common.Separator);
                }
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
                sbLabel.Remove(sbLabel.Length - 1, 1);
            }

            elementList = sb.ToString();
            lbElements.Text = sbLabel.ToString();
        }

        public void SetAllFromElementList(List<string> eList)
        {
            if (eList == null || (eList.Count == 1 && eList[0] == "-1"))
            {
                this.ElementList = Common.allElements;
                this.selection = new ArrayList();
                this.lbElements.Text = "";
                return;
            }

            StringBuilder sb = new StringBuilder();
            StringBuilder sbLabel = new StringBuilder();
            this.selection = new ArrayList();

            foreach (string element in eList)
            {
                if (element != "") // Ignore non-existent elements
                {
                    this.selection.Add(new object[] {
                        Common.Enclose(element, '"', '"') ==  Common.allElements ? "" : Common.Declose(element, '"', '"')
                    });

                    sb.Append(Common.Enclose(element, '"', '"'));
                    sb.Append(Common.Separator);

                    sbLabel.Append(element);
                    sbLabel.Append(Common.Separator);
                }
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
                sbLabel.Remove(sbLabel.Length - 1, 1);
            }

            elementList = sb.ToString();
            lbElements.Text = sbLabel.ToString();
        }

        public void InitializeControls()
        {
            this.AutoSize = true;
            this.Margin = new Padding(5, 0, 0, 1);
            this.Anchor = AnchorStyles.Left;

            lbElements = new Label();
            lbElements.Size = new Size(165, 15);
            lbElements.AutoEllipsis = true;
            lbElements.Margin = new Padding(0, 0, 0, 1);
            lbElements.Anchor = AnchorStyles.Left;
            lbElements.Tag = new ArrayList();

            selection = new ArrayList();

            if (this.Dimension == Common.CurrentASubset.SubsetEditor.Dimension)
                this.Enabled = false;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            ChooseElements frm = new ChooseElements(Common.CurrentASubset.DBConn, this.Dimension);
            frm.set_selection(ref this.selection, true, "");

            if (frm.ShowDialog() == DialogResult.Cancel) return;

            this.Selection = this.selection;

        }

        #region IPrimitive Members

        public string SValue
        {
            get
            {
                if (selection.Count > 1)
                    return Common.Enclose(ElementList, '{', '}');
                else
                    return ElementList;
            }
            set
            {
                this.ElementList = value;
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

        public void SetDefault()
        {
            this.ElementList = Common.allElements;
        }

        public void FillXmlFromCtrl(System.Xml.XmlWriter w)
        {
            if (this.selection.Count < 1)
            {
                w.WriteElementString("element", "-1");
                return;
            }

            foreach (object[] o in this.selection)
            {
                int id = PaloInfo.Instance.GetForeignElementId(Common.CurrentASubset.Connection, Common.CurrentASubset.DatabaseName, this.Dimension, (string)o[0]);
                w.WriteElementString("element", id.ToString());
            }
        }

        public bool SetCtrlFromXml(System.Xml.XmlNode root)
        {
            List<int> elemIDs = new List<int>();
            List<string> elements = new List<string>();
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "element")
                {
                    // Try to get elements by ID, otherwise just pass "as-is"
                    try
                    {
                        int elemID = Int32.Parse(node.ChildNodes[0].Value);
                        elemIDs.Add(elemID);
                    }
                    catch
                    {
                        string element = node.ChildNodes[0].Value;
                        string value = Common.Declose(element, '<', '>');
                        if (value != "*")
                            elements.Add(value);
                    }                  
                }
            }

            if (elemIDs.Count > 0)
                SetAllFromElementIDList(elemIDs);
            else
                try
                {
                    SetAllFromElementList(elements);
                }
                catch
                {
                }

            return true;
        }

        #endregion
    }
}
