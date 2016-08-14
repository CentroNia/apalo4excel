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
<xs:element name="sorting_filter">
	<xs:complexType>
		<xs:sequence>
			<xs:element minOccurs="0" maxOccurs="1" ref="whole" />
			<xs:element minOccurs="0" maxOccurs="1" ref="sorting_criteria" />
			<xs:element minOccurs="0" maxOccurs="1" ref="attribute" />
			<xs:element minOccurs="0" maxOccurs="1" ref="type_limitation" />
<!-- COMPAT BEGIN -->
 * 1.0, 1.0rc3:
			<xs:element minOccurs="0" maxOccurs="1" ref="level" />
 * 1.0rc2:
            <xs:element minOccurs="0" maxOccurs="1" ref="level_element" />
<!-- COMPAT END -->
			<xs:element minOccurs="0" maxOccurs="1" ref="reverse" />
			<xs:element minOccurs="0" maxOccurs="1" ref="show_duplicates" />
		</xs:sequence>
	</xs:complexType>
</xs:element>
<xs:element name="whole" type="intParam" />
<xs:element name="sorting_criteria" type="intParam" />
<!-- Set the attribute/alias according to which we want to sort -->
<xs:element name="attribute" type="intParam" />
<xs:element name="type_limitation" type="intParam" />
<!-- Set the element that defines the level we use for sorting-->
<xs:element name="level_element" type="intParam" />
<xs:element name="reverse" type="intParam" />
*/
namespace Apalo.XlAddin.JSubSet.Filter
{
    public partial class FSort : UserControl, IFilter
    {
        private string filterName = "Sorting";
        private string xmlName = "sorting_filter";
        private string filterSyntax = "PALO.SORT";

        public FSort()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            Common.InternationalizeControl(gbBehaviour, true, false, tTip);
            Common.InternationalizeControl(gbLevel, true, false, tTip);
            Common.InternationalizeControl(gbReverse, true, false, tTip);
            Common.InternationalizeControl(gbLimitation, true, false, tTip);

            Common.InternationalizeControl(rbDefinition, true, true, tTip);
            Common.InternationalizeControl(rbElement, true, true, tTip);
            Common.InternationalizeControl(rbAlias, true, true, tTip);
            Common.InternationalizeControl(rbValue, true, true, tTip);
            Common.InternationalizeControl(rbAttribute, true, true, tTip);

            Common.InternationalizeControl(cbReverse, true, true, tTip);
            //Common.InternationalizeControl(rbPerLevel, true, true, tTip);
            //Common.InternationalizeControl(rbTotal, true, true, tTip);

            Common.InternationalizeControl(rbAll, true, true, tTip);
            Common.InternationalizeControl(rbBase, true, true, tTip);
            Common.InternationalizeControl(rbConsolidated, true, true, tTip);
            Common.InternationalizeControl(cbSortLevel, true, true, tTip);

            Common.InternationalizeControl(lbLevelType, true, false, tTip);

            paAttribute.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.tTip.ToolTipTitle = SubsetHelper.GetI18String("Description", "SB_");
        }

        public void SetLevelType(string level)
        {
            lbLevelType.Tag = "LB Hierarchy " + level;
            Common.InternationalizeControl(lbLevelType, true, false, tTip);

            try
            {
                DimensionInfoSimple di = Common.CurrentASubset.Connection.DimensionInformationSimple(Common.CurrentASubset.DatabaseName, Common.CurrentASubset.Dimension);

                switch (level)
                {
                    case "Indent":
                        piSortLevel.Maximum = di.MaximumIndent;
                        piSortLevel.Minimum = 1;
                        break;
                    case "Level":
                        piSortLevel.Maximum = di.MaximumLevel;
                        piSortLevel.Minimum = 0;
                        break;
                    case "Depth":
                        piSortLevel.Maximum = di.MaximumDepth;
                        piSortLevel.Minimum = 0;
                        break;
                }

                piSortLevel.SetDefault();
            }
            catch
            {
            }
        }

        public void CheckValuepiReverse()
        {
            int add = Common.CurrentASubset.FGeneral.cbReverseOrder.Checked ? 1 : 0;
            piReverse.Value = add + (cbReverse.Checked ? 2 : 0); 
        }

        private void cbReverse_CheckedChanged(object sender, EventArgs e)
        {
            CheckValuepiReverse();
        }

        private void cbSortLevel_CheckedChanged(object sender, EventArgs e)
        {
            piSortLevel.Enabled = cbSortLevel.Checked;
            lbLevelType.Enabled = cbSortLevel.Checked;
            cbSortLevelParam.Enabled = cbSortLevel.Checked;
        }

        private void rbAttribute_CheckedChanged(object sender, EventArgs e)
        {
            paAttribute.Enabled = rbAttribute.Checked;
            cbAttributeParam.Enabled = rbAttribute.Checked;
            if (paAttribute.Enabled)
            {
                prbCriteria.SValue = "-1";
            }
        }

        private void rbDefinition_Click(object sender, EventArgs e)
        {
            rbAttribute.Checked = false;
        }

        private List<PAlias> pAliases;
        public List<PAlias> PAliases
        {
            get
            {
                if (pAliases == null)
                {
                    pAliases = new List<PAlias>();
                    pAliases.Add(paAttribute);
                }
                return pAliases;
            }
        }


        #region IFilter Members

        private XmlNode GetMyXmlNode(XmlNode root)
        {
            XmlNode node = null;

            if (root == null)
            {
                return node;
            }

            foreach (XmlNode n in root.ChildNodes)
            {
                if (n.Name == this.xmlName)
                {
                    node = n;
                    break;
                }
            }

            return node;
        }

        public bool SetFilterFromXml(XmlNode root)
        {
            this.SetDefault();

            XmlNode node = GetMyXmlNode(root);
            if (node == null)
            {
                return false;
            }

            // Defaults:
            Common.CurrentASubset.FGeneral.rbFlat.Checked = true;
            Common.CurrentASubset.FGeneral.cbShowHidden.Checked = false;

            foreach (XmlNode n in node.ChildNodes)
            {
                switch (n.Name)
                {
                    case "whole":
                        if (n.ChildNodes[0].ChildNodes[0].Value == "1")
                        {
                            Common.CurrentASubset.FGeneral.rbHierarchy.Checked = true;
                            Common.CurrentASubset.FGeneral.cbShowHidden.Checked = true;
                        }
                        else if (n.ChildNodes[0].ChildNodes[0].Value == "2")
                        {
                            Common.CurrentASubset.FGeneral.rbHierarchy.Checked = true;
                            Common.CurrentASubset.FGeneral.cbShowHidden.Checked = false;
                        }
                        break;
                    case "sorting_criteria":
                        nprbCriteria.SetCtrlFromXml(n);
                        break;
                    case "attribute":
                        rbAttribute.Checked = true;
                        npaAttribute.SetCtrlFromXml(n);
                        break;
                    case "type_limitation":
                        nprbLimitation.SetCtrlFromXml(n);
                        break;
                    // 1.0rc3:
                    case "level":
                    // 1.0rc2:
                    case "level_element":
                        cbSortLevel.Checked = true;
                        npiSortLevel.SetCtrlFromXml(n);
                        break;
                    case "reverse":
                        npiReverse.SetCtrlFromXml(n);
                        break;
                    case "show_duplicates":
                        Common.CurrentASubset.FGeneral.cbShowDups.Checked =
                            n.ChildNodes[0].ChildNodes[0].Value == "1";
                        break;
                }
            }

            return true;
        }

        public bool FillXmlFromFilter(System.Xml.XmlWriter w)
        {
            if (!IsUsed) return false;

            w.WriteStartElement(this.xmlName);

            if (Common.CurrentASubset.FGeneral.rbHierarchy.Checked)
            {
                w.WriteStartElement("whole");
                if (Common.CurrentASubset.FGeneral.cbShowHidden.Checked)
                {
                    w.WriteElementString("value", "1");
                }
                else
                {
                    w.WriteElementString("value", "2");
                }
                w.WriteEndElement();
            }
            else 
            {
                w.WriteStartElement("whole");
                w.WriteElementString("value", "0");
                w.WriteEndElement();
            }

            if (!rbAttribute.Checked)
            {
                nprbCriteria.FillXmlFromCtrl(w, "sorting_criteria");
            }
            else
            {
                npaAttribute.FillXmlFromCtrl(w, "attribute");
            }

            nprbLimitation.FillXmlFromCtrl(w, "type_limitation");

            if (cbSortLevel.Checked)
            {
                npiSortLevel.FillXmlFromCtrl(w, "level");
            }

            npiReverse.FillXmlFromCtrl(w, "reverse");

            if (Common.CurrentASubset.FGeneral.cbShowDups.Checked)
            {
                w.WriteStartElement("show_duplicates");
                w.WriteElementString("value", "1");
                w.WriteEndElement();
            }
            else
            {
                w.WriteStartElement("show_duplicates");
                w.WriteElementString("value", "0");
                w.WriteEndElement();
            }

            w.WriteEndElement();

            return true;
        }

        public void SetDefault()
        {
            cbCriteriaParam.Checked = false;
            cbAttributeParam.Checked = false;
            cbReverseParam.Checked = false;
            cbLimitationParam.Checked = false;
            cbSortLevelParam.Checked = false;

            rbAttribute.Checked = false;
            prbCriteria.SetDefault();
            paAttribute.SetDefault();
            cbReverse.Checked = false;
            piReverse.SetDefault();

            prbLimitation.SetDefault();
            cbSortLevel.Checked = false;
            piSortLevel.SetDefault();
        }

        public string SValue
        {
            get 
            {
                if (!IsUsed) return "";

                StringBuilder sb = new StringBuilder();

                sb.Append(this.filterSyntax + "(");
                if (Common.CurrentASubset.FGeneral.rbHierarchy.Checked)
                {
                    if (Common.CurrentASubset.FGeneral.cbShowHidden.Checked)
                    {
                        sb.Append("1"); // Whole
                    }
                    else
                    {
                        sb.Append("2");
                    }
                }
                else
                {
                    sb.Append("0");
                }
                sb.Append(Common.Separator);
                if (!rbAttribute.Checked)
                {
                    sb.Append(nprbCriteria.SValue);
                }
                sb.Append(Common.Separator);
                if (rbAttribute.Checked)
                {
                    sb.Append(Common.EncloseIf(npaAttribute.SValue, '"', '"', !npaAttribute.CBParameter.Checked));
                }
                sb.Append(Common.Separator);
                sb.Append(nprbLimitation.SValue);
                sb.Append(Common.Separator);
                if (cbSortLevel.Checked)
                {
                    sb.Append(npiSortLevel.SValue);
                }
                sb.Append(Common.Separator);

                sb.Append(npiReverse.SValue);

                sb.Append(Common.Separator);
                if (Common.CurrentASubset.FGeneral.cbShowDups.Checked)
                {
                    sb.Append('1');
                }
                else
                {
                    sb.Append('0');
                }

                sb.Append(")");

                return sb.ToString();

            }
        }

        public void EnableAliasSort(bool enable)
        {
            if (!enable)
                prbCriteria.SetDefault();
            rbAlias.Enabled = enable;
        }
   
        public void EnableAttributeSort(bool enable)
        {
            if (!enable)
            {
                prbCriteria.SetDefault();
                rbAttribute.Checked = false;
            }
            rbAttribute.Enabled = enable;
        }

        public void EnableValueSort(bool enable)
        {
            if (!enable)
            {
                prbCriteria.SetDefault();
                rbValue.Checked = false;
            }
            rbValue.Enabled = enable;
        }

        public bool IsUsed
        {
            get { return true; }
        }

        public string FilterName
        {
            get { return this.filterName; }
        }

        public CheckBox CBUse
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
        
        #endregion

        public ArgSortingFilterSettings ArgSortingFilterSettings
        {
            get
            {
                ArgSortingFilterSettings settings = new ArgSortingFilterSettings();
                settings.Active = true;

                if (this.rbAttribute.Checked)
                {
                    //settings.Flags = SortingFilterFlags.UseAttribute;
                    settings.Attribute = paAttribute.SValue;
                }
                else if (this.rbAlias.Checked)
                {
                    settings.Flags = SortingFilterFlags.UseAlias;
                }
                else if (this.rbDefinition.Checked)
                {
                    settings.Flags = SortingFilterFlags.Position;
                }
                else if (this.rbElement.Checked)
                {
                    settings.Flags = SortingFilterFlags.Text;
                }
                else if (this.rbValue.Checked)
                {
                    settings.Flags = SortingFilterFlags.Numeric;
                }

                switch ((int)piReverse.Value)
                {
                    case 0:
                        break;
                    case 1:
                        settings.Flags |= SortingFilterFlags.ReverseOrder;
                        break;
                    case 2:
                        settings.Flags |= SortingFilterFlags.ReverseTotal;
                        break;
                    case 3:
                        settings.Flags |= SortingFilterFlags.ReverseTotal | SortingFilterFlags.ReverseOrder;
                        break;
                }

                if (this.rbBase.Checked)
                {
                    settings.Flags = settings.Flags | SortingFilterFlags.LeavesOnly;
                }

                if (this.rbConsolidated.Checked)
                {
                    settings.Flags = settings.Flags | SortingFilterFlags.ConsolidatedOnly;
                }

                if (this.cbSortLevel.Checked)
                {
                    settings.Flags = settings.Flags | SortingFilterFlags.SortOneLevel;
                    settings.Level = (int)this.piSortLevel.Value;
                }

                if (Common.CurrentASubset.FGeneral.rbHierarchy.Checked)
                {
                    settings.Flags = settings.Flags | SortingFilterFlags.Whole;
                    if (!Common.CurrentASubset.FGeneral.cbShowHidden.Checked)
                    {
                        settings.Flags = settings.Flags | SortingFilterFlags.NoChildren;
                    }
                }

                if (Common.CurrentASubset.FGeneral.cbShowDups.Checked)
                {
                    settings.Flags = settings.Flags | SortingFilterFlags.ShowDuplicates;
                }

                return settings;
            }
        }

        private void piReverse_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)piReverse.Value)
            {
                case 0:
                    cbReverse.Checked = false;
                    Common.CurrentASubset.FGeneral.cbReverseOrder.Checked = false;
                    break;
                case 1:
                    cbReverse.Checked = false;
                    Common.CurrentASubset.FGeneral.cbReverseOrder.Checked = true;
                    break;
                case 2:
                    cbReverse.Checked = true;
                    Common.CurrentASubset.FGeneral.cbReverseOrder.Checked = false;
                    break;
                case 3:
                    cbReverse.Checked = true;
                    Common.CurrentASubset.FGeneral.cbReverseOrder.Checked = true;
                    break;
            }
        }

        private void cbReverseParam_CheckedChanged(object sender, EventArgs e)
        {
            cbReverse.Enabled = !cbReverseParam.Checked;
        }
    }
}
