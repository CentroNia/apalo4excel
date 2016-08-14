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
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Jedox.Palo.Comm;
using Apalo.XlAddin.JSubSet.Primitives;
using Apalo.XlAddin.Utils;

/*
<xs:element name="hierarchical_filter">
    <xs:complexType>
        <xs:sequence>
            <xs:element minOccurs="0" maxOccurs="1" ref="element" />
            <xs:element minOccurs="0" maxOccurs="1" ref="above" />
            <xs:element minOccurs="0" maxOccurs="1" ref="exclusive" />
            <xs:element minOccurs="0" maxOccurs="1" ref="hide" />
            <xs:element minOccurs="0" maxOccurs="1" ref="revolve_element" />
            <xs:element minOccurs="0" maxOccurs="1" ref="revolve_count" />
            <xs:element minOccurs="0" maxOccurs="1" ref="revolve_add" />
            <xs:element minOccurs="0" maxOccurs="1" ref="level_start" />
            <xs:element minOccurs="0" maxOccurs="1" ref="level_end" />
        </xs:sequence>
    </xs:complexType>
</xs:element>
	
<xs:element name="element" type="intParam" />
<xs:element name="above" type="boolParam" />
<xs:element name="exclusive" type="boolParam" />
<xs:element name="hide" type="intParam" />
<xs:element name="revolve_element" type="intParam" />
<xs:element name="revolve_count" type="intParam" />
<xs:element name="revolve_add" type="intParam" />
<xs:element name="level_start" type="intParam" />
<xs:element name="level_end" type="intParam" />
 */

namespace Apalo.XlAddin.JSubSet
{
    public partial class FHierarchy : UserControl, IFilter
    {
        private string filterName = "Hierarchy";
        private string xmlName = "hierarchical_filter";
        private string filterSyntax = "PALO.HFILTER";

        public FHierarchy()
        {
            InitializeComponent();
            InitializeCotrols();
        }

        private List<PElement> elementPrimitives;
        public List<PElement> PElements
        {
            get
            {
                if (elementPrimitives == null)
                {
                    elementPrimitives = new List<PElement>();
                    elementPrimitives.Add(pElement);
                }
                return elementPrimitives;
            }
        }

        private void InitializeCotrols()
        {
            gbMain.Text = SubsetHelper.GetI18String(this.FilterName, "SB_FILTER_");

            Common.InternationalizeControl(rbElement, true, true, tTip);
            Common.InternationalizeControl(rbRevolve, true, true, tTip);
            Common.InternationalizeControl(rbBelow, true, true, tTip);
            Common.InternationalizeControl(rbAbove, true, true, tTip);
            Common.InternationalizeControl(pcbExclusive, true, true, tTip);
            Common.InternationalizeControl(lbRevCount, true, true, tTip);
            Common.InternationalizeControl(piRevolveCount, false, true, tTip);
            Common.InternationalizeControl(cbShowOnly, true, true, tTip);
            Common.InternationalizeControl(rbConsolidated, true, true, tTip);
            Common.InternationalizeControl(rbLeaves, true, true, tTip);
            Common.InternationalizeControl(cbLevel, true, true, tTip);
            Common.InternationalizeControl(lbLevel_Start, true, true, tTip);
            Common.InternationalizeControl(lbLevel_End, true, true, tTip);
            Common.InternationalizeControl(piFromLevel, false, true, tTip);
            Common.InternationalizeControl(piToLevel, false, true, tTip);

            Common.InternationalizeControl(lbLevelType1, true, false, tTip);
            Common.InternationalizeControl(lbLevelType2, true, false, tTip);

            pElement.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.tTip.ToolTipTitle = SubsetHelper.GetI18String("Description", "SB_");
        }

        public void SetLevelType(string level)
        {
            lbLevelType1.Tag = "LB Hierarchy " + level;
            Common.InternationalizeControl(lbLevelType1, true, false, tTip);

            lbLevelType2.Tag = "LB Hierarchy " + level;
            Common.InternationalizeControl(lbLevelType2, true, false, tTip);

            try
            {
                DimensionInfoSimple di = Common.CurrentASubset.Connection.DimensionInformationSimple(Common.CurrentASubset.DatabaseName, Common.CurrentASubset.Dimension);

                switch (level)
                {
                    case "Indent":
                        piFromLevel.Maximum = di.MaximumIndent;
                        piToLevel.Maximum = di.MaximumIndent;
                        piFromLevel.Minimum = 1;
                        piToLevel.Minimum = 1;
                        break;
                    case "Level":
                        piFromLevel.Maximum = di.MaximumLevel;
                        piToLevel.Maximum = di.MaximumLevel;
                        piFromLevel.Minimum = 0;
                        piToLevel.Minimum = 0;
                        break;
                    case "Depth":
                        piFromLevel.Maximum = di.MaximumDepth;
                        piToLevel.Maximum = di.MaximumDepth;
                        piFromLevel.Minimum = 0;
                        piToLevel.Minimum = 0;
                        break;
                }

                piFromLevel.SetDefault();
                if (!cbToLevelParam.Checked)
                {
                    piToLevel.Value = piToLevel.Maximum;
                }
            }
            catch
            {
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
                    case "element":
                        rbElement.Checked = true;
                        npElement.SetCtrlFromXml(n);
                        break;
                    case "above":
                        nprbAboveBelow.SetCtrlFromXml(n);
                        break;
                    case "exclusive":
                        npcbExclusive.SetCtrlFromXml(n);
                        break;
                    case "hide":
                        cbShowOnly.Checked = true;
                        nprbHide.SetCtrlFromXml(n);
                        break;
                    case "revolve_element":
                        rbRevolve.Checked = true;
                        npElement.SetCtrlFromXml(n);
                        break;
                    case "revolve_count":
                        rbRevolve.Checked = true;
                        npiRevolveCount.SetCtrlFromXml(n);
                        break;
                    case "revolve_add":
                        rbRevolve.Checked = true;
                        nprbAboveBelow.SetCtrlFromXml(n);
                        break;
                    case "level_start":
                        cbLevel.Checked = true;
                        npiFromLevel.SetCtrlFromXml(n);
                        break;
                    case "level_end":
                        npiToLevel.SetCtrlFromXml(n);
                        break;
                }
            }

            return true;
        }

        public bool FillXmlFromFilter(XmlWriter w)
        {
            if (!this.IsUsed) return false;

            w.WriteStartElement(xmlName);

            if (rbElement.Checked)
            {
                if (npElement.SValue != "") // This condition for jPalo compatibility? It doesn't support [All Elements]
                    npElement.FillXmlFromCtrl(w, "element");
                nprbAboveBelow.FillXmlFromCtrl(w, "above");
                npcbExclusive.FillXmlFromCtrl(w, "exclusive");
            }
            if (cbShowOnly.Enabled && cbShowOnly.Checked)
            {
                nprbHide.FillXmlFromCtrl(w, "hide");
            }
            if (rbRevolve.Checked)
            {
                if (npElement.SValue != "") // This condition for jPalo compatibility? It doesn't support [All Elements]
                    npElement.FillXmlFromCtrl(w, "revolve_element");
                npiRevolveCount.FillXmlFromCtrl(w, "revolve_count");
                nprbAboveBelow.FillXmlFromCtrl(w, "revolve_add");
            }
            if (cbLevel.Enabled && cbLevel.Checked)
            {
                npiFromLevel.FillXmlFromCtrl(w, "level_start");
                npiToLevel.FillXmlFromCtrl(w, "level_end");
            }

            w.WriteEndElement();

            return true;
        }

        public void SetDefault()
        {
            this.IsUsed = false;

            rbElement.Checked = true;
            cbShowOnly.Checked = false;
            cbLevel.Checked = false;

            cbElementParam.Checked = false;
            cbAboveBelowParam.Checked = false;
            cbExclusiveParam.Checked = false;
            cbCountParam.Checked = false;
            cbHideParam.Checked = false;
            cbFromLevelParam.Checked = false;
            cbToLevelParam.Checked = false;

            pElement.SetDefault();
            prbAboveBelow.SetDefault();
            pcbExclusive.SetDefault();
            piRevolveCount.SetDefault();
            prbHide.SetDefault();
            piFromLevel.SetDefault();
            piToLevel.SetDefault();
        }

        public string SValue
        {
            get
            {
                if (!IsUsed) return "";

                StringBuilder sb = new StringBuilder();
                sb.Append(this.filterSyntax + "(");

                if (rbElement.Checked)
                {
                    sb.Append(npElement.SValue);
                    sb.Append(Common.Separator);
                    sb.Append(nprbAboveBelow.SValue);
                    sb.Append(Common.Separator);
                    sb.Append(npcbExclusive.SValue);
                    sb.Append(Common.Separator);
                    if (cbShowOnly.Enabled && cbShowOnly.Checked)
                    {
                        sb.Append(nprbHide.SValue);
                    }
                    if (cbLevel.Enabled && cbLevel.Checked)
                    {
                        sb.Append(Common.Separator);

                        sb.Append(Common.Separator); // Revolve
                        sb.Append(Common.Separator); // Revolve count
                        sb.Append(Common.Separator); // Revolve Add

                        sb.Append(npiFromLevel.SValue);
                        sb.Append(Common.Separator);
                        sb.Append(npiToLevel.SValue);
                    }
                }
                else
                {
                    sb.Append(Common.Separator); // Element
                    sb.Append(Common.Separator); // Above
                    sb.Append(Common.Separator); // Exclusive

                    if (cbShowOnly.Enabled && cbShowOnly.Checked)
                    {
                        sb.Append(nprbHide.SValue);
                    }

                    sb.Append(Common.Separator);

                    sb.Append(npElement.SValue);
                    sb.Append(Common.Separator);
                    sb.Append(npiRevolveCount.SValue);
                    sb.Append(Common.Separator);
                    sb.Append(nprbAboveBelow.SValue);

                    if (cbLevel.Enabled && cbLevel.Checked)
                    {
                        sb.Append(Common.Separator);

                        sb.Append(npiFromLevel.SValue);
                        sb.Append(Common.Separator);
                        sb.Append(npiToLevel.SValue);
                    }
                }

                sb.Append(")");

                return sb.ToString();
            }
        }

        public ArgStructuralFilterSettings ArgStructuralFilterSettings
        {
            get
            {
                ArgStructuralFilterSettings settings = new ArgStructuralFilterSettings();
                if (!this.IsUsed)
                {
                    settings.Active = false;
                    return settings;
                }

                settings.Active = true;

                if (rbElement.Checked)
                {
                    if (pElement.SValue != "")
                    {
                        settings.Bound = Common.Declose(pElement.SValue, '"', '"');
                    }
                    
                    settings.Revolve = false;
                    if (cbLevel.Checked)
                    {
                        settings.Level = true;
                        settings.LevelStart = (int)piFromLevel.Value;
                        settings.LevelEnd = (int)piToLevel.Value;
                    }

                    if (!string.IsNullOrEmpty(settings.Bound))
                    {
                        if (rbBelow.Checked)
                        {
                            if (pcbExclusive.Checked)
                            {
                                settings.Flags = StructuralFilterFlags.BelowExclusive;
                            }
                            else
                            {
                                settings.Flags = StructuralFilterFlags.BelowInclusive;
                            }
                        }
                        else
                        {
                            if (pcbExclusive.Checked)
                            {
                                settings.Flags = StructuralFilterFlags.AboveExclusive;
                            }
                            else
                            {
                                settings.Flags = StructuralFilterFlags.AboveInclusive;
                            }
                        }
                    }

                    if (cbShowOnly.Checked)
                    {
                        if (rbConsolidated.Checked)
                        {
                            settings.Flags |= StructuralFilterFlags.HideLeaves;
                        }
                        else
                        {
                            settings.Flags |= StructuralFilterFlags.HideConsolidated;
                        }
                    }

                }
                else // rbRevolve.Checked
                {
                    settings.Revolve = true;
                    if (pElement.SValue != "")
                    {
                        settings.RevolveElement = Common.Declose(pElement.SValue, '"', '"');
                    }
                    settings.RevolveCount = (int)piRevolveCount.Value;

                    if (rbBelow.Checked)
                    {
                        settings.Flags = StructuralFilterFlags.RevolveAddBelow;
                    }
                    else
                    {
                        settings.Flags = StructuralFilterFlags.RevolveAddAbove;
                    }
                }

                return settings;
            }
        }

        private CheckBox _cbUse;
        public CheckBox CBUse
        {
            get { return _cbUse; }
            set { _cbUse = value; }
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

        #endregion

        private void rbElement_CheckedChanged(object sender, EventArgs e)
        {
            tlpMain.SuspendLayout();
            pcbExclusive.Visible = cbExclusiveParam.Visible = rbElement.Checked;
            tlpCount.Visible = cbCountParam.Visible = !rbElement.Checked;


            cbShowOnly.Enabled = rbElement.Checked;
            prbHide.Enabled = cbHideParam.Enabled = cbShowOnly.Checked && cbShowOnly.Enabled;

            cbLevel.Enabled = rbElement.Checked;
            tlpFromLevel.Enabled =
                tlpToLevel.Enabled =
                cbFromLevelParam.Enabled =
                cbToLevelParam.Enabled = cbLevel.Checked && cbLevel.Enabled;


            if (rbElement.Checked)
                prbAboveBelow.PRadioPanelType = PRadioPanelType.Bool;
            else
                prbAboveBelow.PRadioPanelType = PRadioPanelType.Int;

            tlpMain.ResumeLayout();
        }

        private void cbHide_CheckedChanged(object sender, EventArgs e)
        {
            prbHide.Enabled = cbHideParam.Enabled = cbShowOnly.Checked;
        }

        private void cbLevel_CheckedChanged(object sender, EventArgs e)
        {
            tlpFromLevel.Enabled =
                tlpToLevel.Enabled =
                cbToLevelParam.Enabled =
                cbFromLevelParam.Enabled =
                cbLevel.Checked;
        }
    }
}

