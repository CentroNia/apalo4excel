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
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Utils;

/*
<xs:element name="text_filter">
	<xs:complexType>
		<xs:sequence>
			<xs:element minOccurs="1" maxOccurs="1" ref="regexes" />
			<xs:element minOccurs="0" maxOccurs="1" ref="extended" />
		</xs:sequence>
	</xs:complexType>
</xs:element>

<!-- define individual regexes inside a regex tag -->
<xs:element name="regexes">
	<xs:complexType>
		<xs:sequence>
			<xs:element name="parameter" type="xs:string" minOccurs="0"/>
			<xs:element name="value">
				<xs:complexType>
					<xs:sequence>
						<xs:element name="expression" minOccurs="1" maxOccurs="unbounded" type="xs:string" />
					</xs:sequence>
				</xs:complexType>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
</xs:element>
<xs:element name="extended" type="boolParam"/>
*/

namespace Apalo.XlAddin.JSubSet.Filter
{
    public partial class FText : UserControl, IFilter
    {
        private string filterName = "Text";
        private string xmlName = "text_filter";
        private string filterSyntax = "PALO.TFILTER";

        public FText()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            Common.InternationalizeControl(gbSettings, true, false, tTip);
            Common.InternationalizeControl(lbDescription, true, false, tTip);
            Common.InternationalizeControl(lbExamples, true, false, tTip);
            Common.InternationalizeControl(pbRegex, true, false, tTip);
            Common.InternationalizeControl(pRegEx, false, false, tTip);
            this.tTip.ToolTipTitle = SubsetHelper.GetI18String("Description", "SB_");
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
                    case "regexes":
                        npRegex.SetCtrlFromXml(n);
                        break;
                    case "extended":
                        npbRegex.SetCtrlFromXml(n);
                        break;
                }
            }

            return true;
        }

        public bool FillXmlFromFilter(System.Xml.XmlWriter w)
        {
            if (!IsUsed) return false;

            w.WriteStartElement(this.xmlName);

            npRegex.FillXmlFromCtrl(w, "regexes");
            npbRegex.FillXmlFromCtrl(w, "extended");

            w.WriteEndElement();

            return true;
        }

        public void SetDefault()
        {
            this.IsUsed = false;

            cbDefinitionParam.Checked = false;
            cbRegexParam.Checked = false;

            pRegEx.SetDefault();
            pbRegex.SetDefault();
        }

        public string SValue
        {
            get
            {
                if (!IsUsed) return "";

                StringBuilder sb = new StringBuilder();
                sb.Append(this.filterSyntax + "(");
                sb.Append(npRegex.SValue);
                sb.Append(Common.Separator);
                sb.Append(npbRegex.SValue);
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
            get {
                return filterName;
            }
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

        public ArgTextFilterSettings ArgTextFilterSettings
        {
            get 
            {
                ArgTextFilterSettings settings = new ArgTextFilterSettings();
                if (!this.IsUsed)
                {
                    settings.Active = false;
                    return settings;
                }

                settings.Active = true;
                List<string> regexList = new List<string>();
                foreach (DataGridViewRow row in pRegEx.DGVRegexes.Rows)
                    if (row.Cells[0].Value != null) 
                        regexList.Add(row.Cells[0].Value.ToString());

                settings.RegularExpressions = regexList.ToArray();
                
                if (this.pbRegex.Checked) 
                    settings.Flags = TextFilterFlags.Extended;

                return settings;
            }
        }

        private void pRegEx_EnabledChanged(object sender, EventArgs e)
        {
            //pRegEx.Visible = pRegEx.Enabled;
        }
    }
}
