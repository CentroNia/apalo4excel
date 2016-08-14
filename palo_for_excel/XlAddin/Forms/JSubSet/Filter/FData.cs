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
<xs:element name="data_filter">
	<xs:complexType>
		<xs:sequence>
			<xs:element minOccurs="1" maxOccurs="1" ref="subcube" />
			<!-- when no op/par is passed, all elements are extracted (we could use values for sorting / TOP / etc) -->
			<xs:element minOccurs="0" maxOccurs="1" ref="criteria" />
			<xs:element minOccurs="0" maxOccurs="1" ref="top" />
			<xs:element minOccurs="0" maxOccurs="1" ref="upper_percentage" />
			<xs:element minOccurs="0" maxOccurs="1" ref="lower_percentage" />
			<xs:element minOccurs="0" maxOccurs="1" ref="cell_operator" />
			<xs:element minOccurs="0" maxOccurs="1" ref="no_rules" />
		</xs:sequence>
	</xs:complexType>
</xs:element>

<!-- Set the cube that serves as our data source -->
<xs:element name="subcube">
	<xs:complexType>
		<xs:sequence>
			<xs:element name="source_cube" type="intParam" />
			<xs:sequence>
				<xs:element name="dimension_coordinates" type="element_list" minOccurs="0" maxOccurs="unbounded" />
			</xs:sequence>
		</xs:sequence>
	</xs:complexType>
</xs:element>
<!-- string array of coordinates that specify the cells we use as source for values-->
<xs:complexType name="element_list">
	<xs:sequence>
		<xs:element name="parameter" type="xs:string" minOccurs="0"/>
		<xs:element name="value">
			<xs:complexType>
				<xs:sequence>
					<!-- use sigle value -1 to denote "all elements": -->
					<xs:element name="element" type="xs:int" minOccurs="0" maxOccurs="unbounded" />
				</xs:sequence>
			</xs:complexType>
		</xs:element>
	</xs:sequence>
</xs:complexType>

<xs:element name="criteria">
	<xs:complexType>
		<xs:sequence>
			<xs:element minOccurs="0" maxOccurs="1" ref="par1" />
			<xs:element minOccurs="0" maxOccurs="1" ref="op1" />
			<xs:element minOccurs="0" maxOccurs="1" ref="par2" />
			<xs:element minOccurs="0" maxOccurs="1" ref="op2" />
		</xs:sequence>
	</xs:complexType>
</xs:element>
<!-- first value to compare cell results with - uses operator1-->
<xs:element name="par1" type="stringParam" />
<!--second value to compare cell results with - uses operator2-->
<xs:element name="par2" type="stringParam" />
<!-- first operator  used to compare with par1 -->
<xs:element name="op1" type="xs:string" />
<!-- second operator  used to compare with par2 -->
<xs:element name="op2" type="xs:string" />

<xs:element name="top" type="intParam" />
<xs:element name="upper_percentage" type="decimalParam" />
<xs:element name="lower_percentage" type="decimalParam" />
<xs:element name="cell_operator" type="intParam" />
<!--Flag for not using rules-->
<xs:element name="no_rules" type="intParam"/>
 */

namespace Apalo.XlAddin.JSubSet.Filter
{
    public partial class FData : UserControl, IFilter
    {
        private string filterName = "Data";
        private string xmlName = "data_filter";
        private string filterSyntax = "PALO.DFILTER";

        public class DEView
        {
            private LinkLabel dimension;

            public LinkLabel Dimension
            {
                get { return dimension; }
                set { dimension = value; }
            }
            private string elements;

            public string Elements
            {
                get { return elements; }
                set { elements = value; }
            }
            private bool parameter;

            public bool Parameter
            {
                get { return parameter; }
                set { parameter = value; }
            }

            public DEView(LinkLabel dimension, string elements, bool parameter)
            {
                Dimension = dimension;
                Elements = elements;
                Parameter = parameter;
            }
        }

        public FData()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            Common.InternationalizeControl(gbSettings, true, false, tTip);
            Common.InternationalizeControl(gbOptional, true, false, tTip);
            Common.InternationalizeControl(gbOperators, true, false, tTip);

            Common.InternationalizeControl(lbSelectCube, true, false, tTip);
            Common.InternationalizeControl(lbOperatorMode, true, true, tTip);

            Common.InternationalizeControl(cbTopmost, true, true, tTip);
            Common.InternationalizeControl(cbUpperElements, true, true, tTip);
            Common.InternationalizeControl(cbLowerElements, true, true, tTip);

            pcCellOperator.Items[0] = SubsetHelper.GetI18String("Sum", "SB_");
            pcCellOperator.Items[1] = SubsetHelper.GetI18String("All", "SB_");
            pcCellOperator.Items[2] = SubsetHelper.GetI18String("Average", "SB_");
            pcCellOperator.Items[3] = SubsetHelper.GetI18String("Max", "SB_");
            pcCellOperator.Items[4] = SubsetHelper.GetI18String("Any", "SB_");
            pcCellOperator.Items[5] = SubsetHelper.GetI18String("Min", "SB_");
            pcCellOperator.Items[6] = SubsetHelper.GetI18String("String", "SB_");

            pCube.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.tTip.ToolTipTitle = SubsetHelper.GetI18String("Description", "SB_");
            piTopmost.Minimum = -1;
        }

        private void cbTopmost_CheckedChanged(object sender, EventArgs e)
        {
            piTopmost.Enabled = cbTopmost.Checked;
            cbTopmostNamedParam.Enabled = cbTopmost.Checked;
        }

        private void cbUpperElements_CheckedChanged(object sender, EventArgs e)
        {
            piUpper.Enabled = cbUpperElements.Checked;
            cbUpperNamedParam.Enabled = cbUpperElements.Checked;
        }

        private void cbLowerElements_CheckedChanged(object sender, EventArgs e)
        {
            piLower.Enabled = cbLowerElements.Checked;
            cbLowerNamedParam.Enabled = cbLowerElements.Checked;
        }

        private List<PCube> pCubes;
        public List<PCube> PCubes
        {
            get
            {
                if (pCubes == null)
                {
                    pCubes = new List<PCube>();
                    pCubes.Add(pCube);
                }
                return pCubes;
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
                    case "subcube":
                        SetSubcubeFromXml(n);
                        break;
                    case "criteria":
                        pOperator.SetCtrlFromXml(n);
                        break;
                    case "top":
                        cbTopmost.Checked = true;
                        npiTopmost.SetCtrlFromXml(n);
                        break;
                    case "upper_percentage":
                        cbUpperElements.Checked = true;
                        npiUpperElements.SetCtrlFromXml(n);
                        break;
                    case "lower_percentage":
                        cbLowerElements.Checked = true;
                        npiLowerElements.SetCtrlFromXml(n);
                        break;
                    case "cell_operator":
                        npcCellOperator.SetCtrlFromXml(n);
                        break;
                }
            }

            return true;
        }

        public void SetSubcubeFromXml(XmlNode root)
        {
            bool leave = false;
            // Consume source_cube:
            foreach (XmlNode n in root.ChildNodes)
            {
                switch (n.Name)
                {
                    case "source_cube":
                        npCube.SetCtrlFromXml(n);
                        leave = true;
                        break;
                }
                if (leave) break;
            }

            pDataPicker.SetCtrlFromXml(root);
        }

        public bool FillXmlFromFilter(System.Xml.XmlWriter w)
        {
            if (!IsUsed) return false;

            w.WriteStartElement(this.xmlName);

            w.WriteStartElement("subcube");
            
            npCube.FillXmlFromCtrl(w, "source_cube");
            pDataPicker.FillXmlFromCtrl(w);

            w.WriteEndElement(); //subcube

            pOperator.FillXmlFromCtrl(w);

            if (cbTopmost.Checked)
                npiTopmost.FillXmlFromCtrl(w, "top");
            if (cbUpperElements.Checked)
                npiUpperElements.FillXmlFromCtrl(w, "upper_percentage");
            if (cbLowerElements.Checked)
                npiLowerElements.FillXmlFromCtrl(w, "lower_percentage");

            npcCellOperator.FillXmlFromCtrl(w, "cell_operator");
            
            // IMPLEMENT ME: No rules?

            w.WriteEndElement(); // xmlName

            return true;
        }

        public void SetDefault()
        {
            this.IsUsed = false;

            cbCubeParam.Checked = false;
            cbOperatorParam.Checked = false;
            cbPar1Param.Checked = false;
            cbPar2Param.Checked = false;
            cbTopmostNamedParam.Checked = false;
            cbUpperNamedParam.Checked = false;
            cbLowerNamedParam.Checked = false;

            pCube.SetDefault();
            pDataPicker.SetDefault();
            pcCellOperator.SetDefault();
            pOperator.SetDefault();

            cbTopmost.Checked = false;
            cbUpperElements.Checked = false;
            cbLowerElements.Checked = false;

            piTopmost.SetDefault();
            piLower.SetDefault();
            piUpper.SetDefault();
        }

        public string SValue
        {
            get {
                if (!IsUsed) return "";

                StringBuilder sb = new StringBuilder();
                sb.Append(this.filterSyntax + "(");
                sb.Append("PALO.SUBCUBE(" + npCube.SValue);
                sb.Append(Common.Separator);
                sb.Append(pDataPicker.SValue);
                sb.Append(")");
                sb.Append(Common.Separator);

                sb.Append(pOperator.SValue);
                sb.Append(Common.Separator);
                if (cbTopmost.Checked)
                    sb.Append(npiTopmost.SValue);
                sb.Append(Common.Separator);
                if (cbUpperElements.Checked)
                    sb.Append(npiUpperElements.SValue);
                sb.Append(Common.Separator);
                if (cbLowerElements.Checked)
                    sb.Append(npiLowerElements.SValue);
                sb.Append(Common.Separator);
                
                sb.Append(npcCellOperator.SValue);
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

        public ArgDataFilterSettings ArgDataFilterSettings
        {
            get
            {
                ArgDataFilterSettings settings = new ArgDataFilterSettings();
                if (!this.IsUsed)
                {
                    settings.Active = false;
                    return settings;
                }

                settings.Active = true;
                
                settings.Cube = Common.Declose(pCube.SValue, '"', '"');
                pDataPicker.SetCoords(ref settings.Coords, ref settings.CoordsSet);


                settings.Cmp = new DataComparison();
                pOperator.SetParams(
                    ref settings.Cmp.Op1,
                    ref settings.Cmp.Op2,

                    ref settings.Cmp.Par1d,
                    ref settings.Cmp.Par1s,
                    ref settings.Cmp.Par2d,
                    ref settings.Cmp.Par2s,
                    ref settings.Cmp.UseStrings
                );
            
                switch (pcCellOperator.SelectedIndex)
                {
                    case 0:
                        settings.Flags = DataFilterFlags.DataSum;
                        break;
                    case 1:
                        settings.Flags = DataFilterFlags.DataAll;
                        break;
                    case 2:
                        settings.Flags = DataFilterFlags.DataAverage;
                        break;
                    case 3:
                        settings.Flags = DataFilterFlags.DataMax;
                        break;
                    case 4:
                        settings.Flags = DataFilterFlags.DataAny;
                        break;
                    case 5:
                        settings.Flags = DataFilterFlags.DataMin;
                        break;
                    case 6:
                        settings.Flags = DataFilterFlags.DataString;
                        break;
                }

                if (cbLowerElements.Checked)
                {
                    settings.LowerPercentageSet = true;
                    settings.Flags = settings.Flags | DataFilterFlags.LowerPercentage;
                    settings.LowerPercentage = (double)piLower.Value;
                }

                if (cbUpperElements.Checked)
                {
                    settings.UpperPercentageSet = true;
                    settings.Flags = settings.Flags | DataFilterFlags.UpperPercentage;
                    settings.UpperPercentage = (double)piUpper.Value;
                }

                if (cbTopmost.Checked && (piTopmost.Value > -1))
                {
                    settings.Top = (int)piTopmost.Value;
                    settings.Flags = settings.Flags | DataFilterFlags.Top;
                }

                return settings;
            }
        }

        private void pCube_SelectedIndexChanged(object sender, EventArgs e)
        {
            pDataPicker.ClearList();
            Connection c = Common.CurrentASubset.Connection;
            try
            {
                if ((pCube != null) && !String.IsNullOrEmpty(pCube.Text))
                {
                    string[] dimsA = c.CubeListDimensions(Common.CurrentASubset.DatabaseName, pCube.Text);
                    pDataPicker.SetDimensions(dimsA);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
