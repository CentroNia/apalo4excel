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
//  JMM 09-01-15 Updates for 5.1 library compatability

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Jedox.Palo.Comm;
using Apalo.XlAddin.JSubSet.Primitives;
using Apalo.XlAddin.Utils;

/*
<xs:element name="attribute_filter">
	<xs:complexType>
		<xs:sequence>
			<xs:element minOccurs="1" maxOccurs="1" ref="attribute_filters" />
		</xs:sequence>
	</xs:complexType>
</xs:element>

<xs:element name="attribute_filters">
	<xs:complexType>
		<xs:sequence>
			<xs:element name="parameter" type="xs:string" minOccurs="0"/>
			<xs:element name="value">
				<xs:complexType>
					<xs:sequence>
						<xs:element name="filter_col" type="attribute_column" minOccurs="1" maxOccurs="unbounded" />
					</xs:sequence>
				</xs:complexType>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
</xs:element>
<xs:complexType name="attribute_column">
	<xs:sequence>
		<xs:element name="attribute" type="xs:int" minOccurs="1" maxOccurs="1" />
		<xs:element name="col_entry" type="xs:string" minOccurs="0" maxOccurs="unbounded" />
	</xs:sequence>
</xs:complexType>
*/
namespace Apalo.XlAddin.JSubSet.Filter
{
    public partial class FAttribute : UserControl, IFilter
    {
        private string filterName = "Attribute";
        private string xmlName = "attribute_filter";
        private string filterSyntax = "PALO.AFILTER";

        public FAttribute()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            Common.InternationalizeControl(gbSettings, true, false, tTip);
            Common.InternationalizeControl(lbAttributeConstraints, true, false, tTip);
            Common.InternationalizeControl(lbExamples, true, false, tTip);
            this.tTip.ToolTipTitle = SubsetHelper.GetI18String("Description", "SB_");
        }

        private List<PAttribute> pAttributes;
        public List<PAttribute> PAttributes
        {
            get
            {
                if (pAttributes == null)
                {
                    pAttributes = new List<PAttribute>();
                    pAttributes.Add(plConstraints);
                }
                return pAttributes;
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
                    case "attribute_filters":
                        nplConstraints.SetCtrlFromXml(n);
                        break;
                }
            }

            return true;
        }

        public bool FillXmlFromFilter(System.Xml.XmlWriter w)
        {
            if (!IsUsed) return false;

            w.WriteStartElement(this.xmlName);

            nplConstraints.FillXmlFromCtrl(w, "attribute_filters");

            w.WriteEndElement();

            return true;
        }

        public void SetDefault()
        {
            this.IsUsed = false;

            cbAttributeParam.Checked = false;

            plConstraints.SetDefault();
        }

        public string SValue
        {
            get 
            {
                if (!IsUsed) return "";

                StringBuilder sb = new StringBuilder();
                sb.Append(this.filterSyntax + "(");
                sb.Append(nplConstraints.SValue);
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
            get { return this.filterName; }
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

        public ArgFieldFilterSettings ArgFieldFilterSettings
        {
            get
            {
                ArgFieldFilterSettings settings = new ArgFieldFilterSettings();

                if (!this.IsUsed)
                {
                    settings.Active = false;
                    return settings;
                }

                // JMM 09-01-15 Modified for 5.1 library compatibility
                settings.Advanced = (string[][])plConstraints.Attributes;

                // Excel crash workaround:
                if (settings.Advanced.Length < 1 || settings.Advanced[0].Length < 2)
                    settings.Active = false;
                else
                {
                    settings.Active = true;
                    settings.Flags = AliasFilterFlags.UseFilterExp;
                }

                return settings;
            }
        }

        private void plConstraints_EnabledChanged(object sender, EventArgs e)
        {
            //plConstraints.Visible = plConstraints.Enabled;
            //btAdd.Enabled = plConstraints.Enabled;

            btEdit.Enabled = false;
            btRemove.Enabled = false;
        }
    }
}
