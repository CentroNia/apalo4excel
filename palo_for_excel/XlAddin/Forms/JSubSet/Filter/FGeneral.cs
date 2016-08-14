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
using Apalo.XlAddin.Forms.Controls;
using Apalo.XlAddin.Utils;

/*
<xs:element name="subset">
	<xs:complexType>
		<xs:sequence>
			<xs:element minOccurs="0" maxOccurs="1" ref="indent"/>
			<xs:element minOccurs="0" maxOccurs="1" ref="alias_filter" />
			<xs:element minOccurs="0" maxOccurs="1" ref="hierarchical_filter" />
			<xs:element minOccurs="0" maxOccurs="1" ref="text_filter" />
			<xs:element minOccurs="0" maxOccurs="1" ref="attribute_filter" />
			<xs:element minOccurs="0" maxOccurs="1" ref="data_filter" />
			<xs:element minOccurs="0" maxOccurs="1" ref="picklist_filter" />
			<xs:element minOccurs="0" maxOccurs="1" ref="sorting_filter" />
		</xs:sequence>
		
		<xs:attribute name="name" type="xs:string" />
		<xs:attribute name="id" type="xs:integer" use="required" />
		<xs:attribute name="sourceDimensionId" type="xs:integer" use="required" />
	</xs:complexType>
</xs:element>

<xs:element name="indent" type="intParam"/>

<!-- ***************************************************************************
************************* Alias Filter Begin ************************************
******************************************************************************* -->
<xs:element name="alias_filter">
	<xs:complexType>
		<xs:sequence>
			<xs:element minOccurs="0" maxOccurs="1" ref="alias1" />
			<xs:element minOccurs="0" maxOccurs="1" ref="alias2" />
		</xs:sequence>
	</xs:complexType>
</xs:element>

<xs:element name="alias1" type="intParam"/>
<xs:element name="alias2" type="intParam"/>
<!-- ***************************************************************************
************************* Alias Filter End **************************************
******************************************************************************* -->
*/
namespace Apalo.XlAddin.JSubSet.Filter
{
    public partial class FGeneral : UserControl, IFilter
    {
        #region ComboConn Related

        private ConnComboBox comboConnList;

        public int OldSelectedDatabaseIndex = -1;
        public int OldSelectedDimensionIndex = -1;

        #endregion


        public FGeneral()
        {
            InitializeComponent();
            InitializeControls();
        }

        public bool EnableDBChange
        {
            get { return gbConnection.Enabled; }
            set { gbConnection.Enabled = value; }
        }

        public string DBConn
        {
            get { return serverName + "/" + databaseName; }
        }

        private string serverName;
        public string ServerName
        {
            get { return serverName; }
        }

        private string databaseName;
        public string DatabaseName
        {
            get { return databaseName; }
        }

        public string Dimension
        {
            get { return cbDimension.Text; }
            set { cbDimension.Text = value; }
        }

        public int DimensionId
        {
            get { return PaloInfo.Instance.GetDimensionId(Dimension); }
            set { Dimension = PaloInfo.Instance.GetDimensionName(value); }
        }

        private Connection currConn;
        public Connection Connection
        {
            get { return currConn; }
        }

        public ComboBox CBDimension
        {
            get { return cbDimension; }
        }

        public ConnComboBox CBDatabase
        {
            get { return comboConnList; }
        }

        public void SetDBConn(string connName, string dbname)
        {
            this.initCombo();
            this.setCombo();

            this.comboConnList.SetItem(connName, dbname);
            Common.CurrentASubset.SubsetEditor.SetEditorEnabled(true);

            return;
        }


        private void rbFlat_CheckedChanged(object sender, EventArgs e)
        {
            i18nReverseOrder();
            cbShowHidden.Enabled = rbHierarchy.Checked;
            // This was regarded as a bug (1647), but to some this may seem like a normal behavior
            // if (!cbShowHidden.Enabled) cbShowHidden.Checked = false;
            // Here's the "correction":
            cbShowHidden.Checked = !rbFlat.Checked;

            Common.CurrentASubset.FSort.cbSortLevel.Enabled = rbHierarchy.Checked;
            if (!Common.CurrentASubset.FSort.cbSortLevel.Enabled)
            {
                Common.CurrentASubset.FSort.cbSortLevel.Checked = false;
            }

            Common.CurrentASubset.FSort.CheckValuepiReverse();
        }

        private void rbHierarchy_CheckedChanged(object sender, EventArgs e)
        {
            i18nReverseOrder();
            cbShowHidden.Enabled = rbHierarchy.Checked;
            if (!cbShowHidden.Enabled) cbShowHidden.Checked = false;

            Common.CurrentASubset.FSort.cbSortLevel.Enabled = rbHierarchy.Checked;
            if (!Common.CurrentASubset.FSort.cbSortLevel.Enabled)
            {
                Common.CurrentASubset.FSort.cbSortLevel.Checked = false;
            }

            Common.CurrentASubset.FSort.CheckValuepiReverse();

        }

        private void cbReverseOrder_CheckedChanged(object sender, EventArgs e)
        {
            cbShowHidden.Enabled = rbHierarchy.Checked;
            if (!cbShowHidden.Enabled) cbShowHidden.Checked = false;

            Common.CurrentASubset.FSort.cbSortLevel.Enabled = rbHierarchy.Checked;
            if (!Common.CurrentASubset.FSort.cbSortLevel.Enabled)
            {
                Common.CurrentASubset.FSort.cbSortLevel.Checked = false;
            }

            Common.CurrentASubset.FSort.CheckValuepiReverse();
        }

        public String Alias1
        {
            get
            {
                return npcbAlias1.SValue;
            }
            set { npcbAlias1.SValue = value; }
        }

        public String Alias2
        {
            get 
            {
                return npcbAlias2.SValue;
            }
            set { npcbAlias2.SValue = value; }
        }


        private List<PAlias> pAliases;
        public List<PAlias> PAliases
        {
            get
            {
                if (pAliases == null)
                {
                    pAliases = new List<PAlias>();
                    pAliases.Add(pcbAlias1);
                    pAliases.Add(pcbAlias2);
                }
                return pAliases;
            }
        }

        private void i18nReverseOrder(string tag)
        {
            cbReverseOrder.Tag = tag;
            Common.InternationalizeControl(cbReverseOrder, true, true, tTip);
        }

        private void i18nReverseOrder()
        {
            i18nReverseOrder((rbFlat.Checked) ? "REVERSE" : "REVERSE_HIERARCHY");
        }

        private void InitializeControls()
        {
            initFirst();
            
            comboConnList.Tag = "Connection";

            Common.InternationalizeControl(comboConnList, false, true, tTip);
            Common.InternationalizeControl(lbServer, true, false, tTip);
            Common.InternationalizeControl(cbDimension, false, true, tTip);
            Common.InternationalizeControl(lbDimension, true, false, tTip);
            Common.InternationalizeControl(pcbAlias1, false, true, tTip);
            Common.InternationalizeControl(lbAlias1, true, false, tTip);
            Common.InternationalizeControl(pcbAlias2, false, true, tTip);
            Common.InternationalizeControl(lbAlias2, true, false, tTip);
            Common.InternationalizeControl(rbFlat, true, true, tTip);
            Common.InternationalizeControl(rbHierarchy, true, true, tTip);
            Common.InternationalizeControl(cbShowHidden, true, true, tTip);
            Common.InternationalizeControl(cbShowDups, true, true, tTip);
            Common.InternationalizeControl(rbIndent, true, true, tTip);
            Common.InternationalizeControl(rbLevel, true, true, tTip);
            Common.InternationalizeControl(rbDepth, true, true, tTip);
            Common.InternationalizeControl(gbConnection, true, false, tTip);
            Common.InternationalizeControl(gbAlias, true, false, tTip);
            Common.InternationalizeControl(gbLayout, true, false, tTip);
            Common.InternationalizeControl(gbHierarchy, true, false, tTip);
            Common.InternationalizeControl(gbOptions, true, false, tTip);

            i18nReverseOrder();
            
            cbDimension.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            pcbAlias1.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            pcbAlias2.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.tTip.ToolTipTitle = SubsetHelper.GetI18String("Description", "SB_");
        }

        private void initFirst()
        {
            this.comboConnList = new ConnComboBox();
            pPanel.Controls.Add(comboConnList);
        }

        #region Code From Hell
        private void setCombo()
        {
            this.comboConnList.FillList(-1, ConnectionsHelper.HandleDatabase.WithoutSystem);
        }

        private void initCombo()
        {
            // 
            // comboConnList
            // 
            this.comboConnList.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.comboConnList.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.comboConnList.CausesValidation = false;
            this.comboConnList.DisplayMember = "Text";
            this.comboConnList.Dock = DockStyle.Fill;
            this.comboConnList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboConnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.comboConnList.ImageList = this.imgListServerIcons;
            this.comboConnList.MaxLength = 1;
            this.comboConnList.Name = "comboConnList";
            this.comboConnList.TabIndex = 36;
            this.comboConnList.SelectedIndexChanged += new System.EventHandler(this.comboConnList_SelectedIndexChanged);
            this.comboConnList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        }

        private void comboConnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboConnList.SelectedIndex == this.OldSelectedDatabaseIndex)
            {
                return;
            }

            Common.CurrentASubset.SubsetEditor.Dimension = "";

            if ((Common.CurrentASubset != null) && (Common.CurrentASubset.SubsetEditor.AskAndSaveChangesIfNeeded() == DialogResult.Cancel))
            {
                if (this.OldSelectedDatabaseIndex != -1)
                {
                    comboConnList.SelectedIndex = this.OldSelectedDatabaseIndex;
                }

                return;
            }

            this.OldSelectedDatabaseIndex = comboConnList.SelectedIndex;

            this.serverName = this.comboConnList.GetConnectionName();
            this.databaseName = this.comboConnList.GetDatabase();

            if (String.IsNullOrEmpty(this.databaseName))
            {
                cbDimension.Items.Clear();
                cbDimension.Enabled = false;

                Common.CurrentASubset.SubsetEditor.SetDefault();
                Common.CurrentASubset.SubsetEditor.SetEditorEnabled(false);
            }
            else
            {
                this.pumpDbData(this.serverName, this.databaseName);
                cbDimension.Enabled = true;

                Common.CurrentASubset.SubsetEditor.SetDefault();
                if (cbDimension.Items.Count > 0)
                {
                    cbDimension.SelectedIndex = 0;
                }

                Common.CurrentASubset.SubsetEditor.SetEditorEnabled(true);
            }
        }

        /// <summary>
        /// Pumps data into list boxes(dimensions and cubes)
        /// </summary>
        private void pumpDbData(string connName, string dbN)
        {
            try
            {
                Connection c = Apalo.XlAddin.Connections.GetConnection(connName);
                this.currConn = c;
                string[] tmpDbDims = new string[] { };
                try
                {
                    tmpDbDims = c.DatabaseListDimensions(dbN, DimensionType.NormalDimension);
                }
                catch (PaloException)
                { }

                int tmpCnt = tmpDbDims.Length;
                string[] dbDims = new string[tmpCnt + 1];
                dbDims = tmpDbDims;

                cbDimension.BeginUpdate();
                cbDimension.Items.Clear();

                for (int i = 0; i < dbDims.Length; i++)
                {
                    string Dim = (string)dbDims[i];
                    if (!ListBoxHelper.IsJPaloDim(Dim))
                    {
                        this.cbDimension.Items.Add(Dim);
                    }
                }

                cbDimension.EndUpdate();

            }
            catch (PaloException e)
            {
                Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error regenerating ServerName/DB list!", e);
            }
        }

        #endregion

        #region IFilter Members
        private XmlNode GetXmlNodeForSubFilter(XmlNode root, string subFilterXmlName)
        {
            XmlNode node = null;

            if (root == null)
            {
                return node;
            }

            foreach (XmlNode n in root.ChildNodes)
            {
                if (n.Name == subFilterXmlName)
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

            // Alias filter:
            XmlNode aliasNode = GetXmlNodeForSubFilter(root, "alias_filter");            
            if (aliasNode != null)
            {
                foreach (XmlNode n in aliasNode.ChildNodes)
                {
                    switch (n.Name)
                    {
                        case "alias1":
                            npcbAlias1.SetCtrlFromXml(n);
                            break;
                        case "alias2":
                            npcbAlias2.SetCtrlFromXml(n);
                            break;
                    }
                }
            }

            // Indent:
            XmlNode indentNode = GetXmlNodeForSubFilter(root, "indent");
            if (indentNode != null)
            {
                nprbHierarchy.SetCtrlFromXml(indentNode);
            }

            return true;
        }

        public bool FillXmlFromFilter(System.Xml.XmlWriter w)
        {
            if (!IsUsed)
            {
                return false;
            }

            nprbHierarchy.FillXmlFromCtrl(w, "indent");

            if ((pcbAlias1.SelectedIndex != 0) || (pcbAlias2.SelectedIndex != 0))
            {
                w.WriteStartElement("alias_filter");

                if (pcbAlias1.SelectedIndex != 0)
                {
                    npcbAlias1.FillXmlFromCtrl(w, "alias1");
                }

                if (pcbAlias2.SelectedIndex != 0)
                {
                    npcbAlias2.FillXmlFromCtrl(w, "alias2");
                }

                w.WriteEndElement();
            }

            return true;
        }

        public void SetDefault()
        {
            cbAlias1Param.Checked = false;
            cbAlias2Param.Checked = false;
            cbHierarchyParam.Checked = false;

            pcbAlias1.SetDefault();
            pcbAlias2.SetDefault();
            prbHierarchy.SetDefault();

            rbHierarchy.Checked = true;
            cbShowHidden.Checked = true;
            cbShowDups.Checked = true;
        }

        public string SValue
        {
            get
            {
                if (!this.IsUsed) return "";
                StringBuilder sb = new StringBuilder();

                sb.Append(Common.Enclose(this.DBConn, '"', '"'));
                sb.Append(Common.Separator);
                sb.Append(Common.Enclose(Common.CurrentASubset.SubsetEditor.Dimension, '"', '"'));
                sb.Append(Common.Separator);
                sb.Append(nprbHierarchy.SValue);
                sb.Append(Common.Separator);
                
                int numAliases = 0;
                StringBuilder sbAlias = new StringBuilder();
                
                if (!String.IsNullOrEmpty(Alias1))
                {
                    sbAlias.Append(Common.EncloseIf(Alias1, '"', '"', !npcbAlias1.CBParameter.Checked));
                    numAliases++;
                }

                if (!String.IsNullOrEmpty(Alias2))
                {
                    if (numAliases > 0)
                    {
                        sbAlias.Append(Common.Separator);
                    }
                    sbAlias.Append(Common.EncloseIf(Alias2, '"', '"', !npcbAlias1.CBParameter.Checked));
                    numAliases++;
                }

                if (numAliases > 1)
                {
                    sb.Append(Common.Enclose(sbAlias.ToString(), '{', '}'));
                }
                else
                {
                    sb.Append(sbAlias.ToString());
                }

                return sb.ToString();
            }
        }

        public int Indent
        {
            get
            {
                try
                {
                    return Int32.Parse(this.prbHierarchy.SValue);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public void EnableGeneral(bool enable)
        {
            this.SetDefault();

            gbAlias.Enabled = enable;
            gbHierarchy.Enabled = enable;
            gbLayout.Enabled = enable;
        }

        public bool IsUsed
        {
            get { return true; }
        }

        public string FilterName
        {
            get { return "[[General]]"; }
        }

        public CheckBox CBUse
        {
            get { return null; }
            set {}
        }

        #endregion

        public ArgAliasFilterSettings ArgAliasFilterSettings
        {
            get
            {
                ArgAliasFilterSettings settings = new ArgAliasFilterSettings();

                int numAliases = 0;
                if (pcbAlias1.SValue != "" && pcbAlias1.SValue != "\"\"")
                {
                    settings.Attribute1 = pcbAlias1.SValue;
                    settings.Active = true;
                    settings.Flags = AliasFilterFlags.SearchOne;
                    numAliases++;
                }

                if (pcbAlias2.SValue != "" && pcbAlias2.SValue != "\"\"")
                {
                    if (numAliases == 0)
                    {
                        settings.Attribute1 = pcbAlias2.SValue;
                        settings.Flags = AliasFilterFlags.SearchOne;
                    }
                    else
                    {
                        settings.Attribute2 = pcbAlias2.SValue;
                        settings.Flags = AliasFilterFlags.SearchTwo;
                    }
                    settings.Active = true;
                    numAliases++;
                }

                return settings;
            }
        }

        private void cbAlias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.CurrentASubset.FSort.EnableAliasSort(pcbAlias1.SelectedIndex != 0 || pcbAlias2.SelectedIndex != 0);
        }

        private void cbAlias2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.CurrentASubset.FSort.EnableAliasSort(pcbAlias1.SelectedIndex != 0 || pcbAlias2.SelectedIndex != 0);
        }

        public void SetLevelType(string level)
        {
            Common.CurrentASubset.FSort.SetLevelType(level);
            Common.CurrentASubset.FHierarchy.SetLevelType(level);
        }
        
        private void rbIndent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIndent.Checked) SetLevelType("Indent");
        }

        private void rbLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLevel.Checked) SetLevelType("Level");
        }

        private void rbDepth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDepth.Checked) SetLevelType("Depth");
        }

    }
}
