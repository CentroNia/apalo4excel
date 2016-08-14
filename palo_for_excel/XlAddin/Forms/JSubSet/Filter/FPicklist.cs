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
using Jedox.Palo.Comm;
using Apalo.XlAddin.Forms;
using Apalo.XlAddin.Utils;

/*
<xs:element name="picklist_filter">
	<xs:complexType>
		<xs:sequence>
			<xs:element minOccurs="1" maxOccurs="1" ref="manual_definition" />
			<xs:element minOccurs="0" maxOccurs="1" ref="pick_type" />
		</xs:sequence>
	</xs:complexType>
</xs:element>

<xs:element name="manual_definition">
	<xs:complexType>
		<xs:sequence>
			<xs:element name="parameter" type="xs:string" minOccurs="0"/>
			<xs:element name="value">
				<xs:complexType>
					<xs:sequence>
						<xs:element name="pick_elem" type="xs:integer" minOccurs="0" maxOccurs="unbounded" />
					</xs:sequence>
				</xs:complexType>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
</xs:element>
*/

namespace Apalo.XlAddin.JSubSet.Filter
{
    public partial class FPicklist : UserControl, IFilter
    {
        private string filterName = "Picklist";
        private string xmlName = "picklist_filter";
        private string filterSyntax = "PALO.PICKLIST";

        public FPicklist()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            Common.InternationalizeControl(lbChosenElements, true, false, tTip);
            Common.InternationalizeControl(btEdit, true, false, tTip);
            Common.InternationalizeControl(lbSelect, true, false, tTip);
            Common.InternationalizeControl(rbFront, true, true, tTip);
            Common.InternationalizeControl(rbBack, true, true, tTip);
            Common.InternationalizeControl(rbMerge, true, true, tTip);
            Common.InternationalizeControl(rbSubtract, true, true, tTip);

            Common.InternationalizeControl(gbDimension, true, false, tTip);
            Common.InternationalizeControl(gbBehaviour, true, false, tTip);

            //plElements.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.tTip.ToolTipTitle = SubsetHelper.GetI18String("Description", "SB_");
        }

        private void plElements_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            ChooseElements frm = new ChooseElements(Common.CurrentASubset.DBConn, Common.CurrentASubset.SubsetEditor.Dimension);
            ArrayList sel = new ArrayList();
            foreach (ListViewItem lvi in plElements.Items)
                //sel.Add(new object[] { lvi.Text, Boolean.Parse(lvi.SubItems[1].Text), lvi.SubItems[2].Text, lvi.SubItems[3].Text });
                sel.Add(new object[] { lvi.Text });

            if (plElements.Tag == null)
                plElements.Tag = "";
            frm.set_selection(ref sel, true, (string)plElements.Tag, true);

            if (frm.ShowDialog() == DialogResult.Cancel) return;
            
            plElements.BeginUpdate();
            plElements.Items.Clear();
            foreach (object[] o in sel)
            {
                ListViewItem lvi = new ListViewItem((string)o[0]);
                //lvi.SubItems.Add(((bool)o[1]).ToString());
                //lvi.SubItems.Add((string)o[2]);
                //lvi.SubItems.Add((string)o[3]);
                plElements.Items.Add(lvi);
            }

            plElements.EndUpdate();

            if (sel.Count > 0)
            {
                object[] element = (object[])sel[0];
                if (element.Length > 4)
                {
                    plElements.Tag = (string)element[4];
                }
            }
        }

        #region IFilter Members

        private XmlNode GetMyXmlNode(XmlNode root)
        {
            XmlNode node = null;

            if (root == null)
                return node;

            foreach (XmlNode n in root.ChildNodes)
                if (n.Name == this.xmlName)
                {
                    node = n;
                    break;
                }

            return node;
        }

        public bool SetFilterFromXml(XmlNode root)
        {
            this.SetDefault();

            XmlNode node = GetMyXmlNode(root);
            if (node == null)
            {
                this.IsUsed = false;
                return false;
            }

            this.IsUsed = true;

            foreach (XmlNode n in node.ChildNodes)
            {
                switch (n.Name)
                {
                    case "manual_definition":
                        nplElements.SetCtrlFromXml(n);
                        break;
                    case "pick_type":
                        nprbPickType.SetCtrlFromXml(n);
                        break;
                }
            }

            return true;
        }

        public bool FillXmlFromFilter(System.Xml.XmlWriter w)
        {
            if (!IsUsed) return false;

            w.WriteStartElement(this.xmlName);

            nplElements.FillXmlFromCtrl(w, "manual_definition");
            nprbPickType.FillXmlFromCtrl(w, "pick_type");

            w.WriteEndElement();

            return true;
        }

        public void SetDefault()
        {
            this.IsUsed = false;

            cbElementsParam.Checked = false;
            cbTypeParam.Checked = false;

            prbPickType.SetDefault();
            plElements.SetDefault();
        }

        public string SValue
        {
            get 
            {
                if (!IsUsed) return "";

                StringBuilder sb = new StringBuilder();
                sb.Append(filterSyntax + "(");
                sb.Append(nplElements.SValue);
                sb.Append(Common.Separator);
                sb.Append(nprbPickType.SValue);
                sb.Append(")");

                return sb.ToString();
            }
        }

        public bool IsUsed
        {
            get { return (CBUse != null) && CBUse.Checked && CBUse.Enabled; }
            set { if (CBUse != null) CBUse.Checked = value; if (value) CBUse.Enabled = true; }
        }


        public string FilterName
        {
            get { return filterName; }
        }

        private CheckBox _cbUse;
        public CheckBox CBUse
        {
            get
            {
                return _cbUse;
            }
            set
            {
                _cbUse = value;
            }
        }

        #endregion

        public ArgBasicFilterSettings ArgBasicFilterSettings
        {
            get
            {
                ArgBasicFilterSettings settings = new ArgBasicFilterSettings();

                if (!this.IsUsed)
                {
                    settings.Active = false;
                    return settings;
                }

                settings.Active = true;

                List<string> pList = new List<string>();
                foreach (ListViewItem lvi in plElements.Items)
                {
                    pList.Add(lvi.Text);
                }
                
                settings.ManualSubset = pList.ToArray();
                settings.ManualSubsetSet = true;
                
                int pT = Int32.Parse(prbPickType.SValue);
                switch (pT) 
                {
                    case 0: 
                        settings.Flags = PickListFlags.InsertFront;
                        break;
                    case 1:
                        settings.Flags = PickListFlags.InsertBack;
                        break;
                    case 2:
                        settings.Flags = PickListFlags.MergeElements;
                        break;
                    case 3:
                        settings.Flags = PickListFlags.Sub;
                        break;
                }

                return settings;
            }
        }

        private void plElements_EnabledChanged(object sender, EventArgs e)
        {
            btEdit.Enabled = plElements.Enabled;

            //plElements.Visible = plElements.Enabled;
            //btEdit.Visible = plElements.Enabled;
            //tlpContainer.CellBorderStyle = plElements.Visible ? TableLayoutPanelCellBorderStyle.None : TableLayoutPanelCellBorderStyle.Single;

            plElements.Visible = true;
            tlpContainer.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            btEdit.Visible = true;
        }
    }
}
    