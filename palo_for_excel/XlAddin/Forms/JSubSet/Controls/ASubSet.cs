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

 // Additional Revisions to Palo (c) Junction BI LLC:
 // JMM 10-20-15 Fix SetSubsetFromXml

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Forms;
using Apalo.XlAddin.Forms.Controls;
using Apalo.XlAddin.JSubSet.Primitives;
using Apalo.XlAddin.JSubSet.Filter;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.JSubSet
{
    public partial class ASubSet : UserControl
    {
        private const string xmlName = "subset";
        private const string subsetSyntax = "PALO.SUBSET";
        private const string regpath = "SB_AUTOREFRESH_WARNING";
        private const string form = "ASubset";

        private int id;

        private TableLayoutPanel tlpNamedParams;
        public TableLayoutPanel TlpNamedParams
        {
            get { return tlpNamedParams; }
        }

        public ASubSet()
        {
            InitializeComponent();
            InitializeControls();
        }

        private SubSetEditor subsetEditor;
        public SubSetEditor SubsetEditor
        {
            get { return subsetEditor; }
            set { subsetEditor = value; }
        }

        public string SValue
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("=");
                sb.Append(subsetSyntax);
                sb.Append("(");
                sb.Append(fGeneral.SValue);
                sb.Append(Common.Separator);
                sb.Append(fHierarchy.SValue);
                sb.Append(Common.Separator);
                sb.Append(fText.SValue);
                sb.Append(Common.Separator);
                sb.Append(fAttribute.SValue);
                sb.Append(Common.Separator);
                sb.Append(fData.SValue);
                sb.Append(Common.Separator);
                sb.Append(fPicklist.SValue);
                sb.Append(Common.Separator);
                sb.Append(fSort.SValue);
                sb.Append(")");

                return sb.ToString();
            }
        }

        private string version = "1.0";
        public string Version
        {
            get { return version; }
        }

        public string[] supportedVersions = new string[] { "1.0rc2", "1.0rc3", "1.0" };
        public string[] SupportedVersions
        {
            get { return supportedVersions; }
        }

        /// <summary>
        /// Use SetDBConn to explicitly set ServerName, DatabaseName, Connection and DBConn
        /// </summary>
        public String DBConn
        {
            get { return fGeneral.DBConn;  }
        }

        /// <summary>
        /// Use SetDBConn to explicitly set ServerName, DatabaseName, Connection and DBConn
        /// </summary>
        public String DatabaseName
        {
            get { return fGeneral.DatabaseName; }
        }

        /// <summary>
        /// Use SetDBConn to explicitly set ServerName, DatabaseName, Connection and DBConn
        /// </summary>
        public String ServerName
        {
            get { return fGeneral.ServerName; }
        }

        /// <summary>
        /// Use SetDBConn to explicitly set ServerName, DatabaseName, Connection and DBConn
        /// </summary>
        public Connection Connection
        {
            get { return fGeneral.Connection; }
        }

        /// <summary>
        /// Use SetDBConn to explicitly set ServerName, DatabaseName, Connection and DBConn
        /// </summary>
        public void SetDBConn(string connName, string dbName)
        {
            fGeneral.SetDBConn(connName, dbName);
        }

        /// <summary>
        /// Defines the dimension on which this subset is defined
        /// Make sure that the definition of Dimension comes 
        /// AFTER the definition for PaloInfo.Instance.* values 
        /// (such as Elements, Cubes and Dimensions)
        /// </summary>
        public String Dimension
        {
            get { return fGeneral.Dimension; }          
            set { fGeneral.Dimension = value; }
        }

        private int DimensionId
        {
            get { return fGeneral.DimensionId; }
            set { fGeneral.DimensionId = value; }
        }

        public ComboBox CBDimension
        {
            get { return fGeneral.CBDimension; }
        }

        public ConnComboBox CBDatabase
        {
            get { return fGeneral.CBDatabase; }
        }

        public FGeneral FGeneral
        {
            get { return fGeneral; }
        }

        public FHierarchy FHierarchy
        {
            get { return fHierarchy; }
        }

        public FText FText
        {
            get { return fText; }
        }

        public FPicklist FPicklist
        {
            get { return fPicklist; }
        }

        public FAttribute FAttribute
        {
            get { return fAttribute; }
        }

        public FData FData
        {
            get { return fData; }
        }

        public FSort FSort
        {
            get { return fSort; }
        }

        public SubsetResult[] GetSubSetResults(Connection connection, string dbName, int limit)
        {
            ArgAliasFilterSettings aliasFS = FGeneral.ArgAliasFilterSettings;
            ArgStructuralFilterSettings structFS = FHierarchy.ArgStructuralFilterSettings;
            ArgTextFilterSettings textFS = FText.ArgTextFilterSettings;
            ArgBasicFilterSettings basicFS = FPicklist.ArgBasicFilterSettings;
            ArgFieldFilterSettings fieldFS = FAttribute.ArgFieldFilterSettings;
            ArgDataFilterSettings dataFS = FData.ArgDataFilterSettings;
            ArgSortingFilterSettings sortFS = FSort.ArgSortingFilterSettings;

            if (limit > -1 )
            {
                sortFS.Limit_count = (uint)limit;
                sortFS.Limit_start = 0;
                sortFS.Flags |= SortingFilterFlags.Limit;
            }
            
            SubsetResult[] result = null;
            try
            {
                if (connection != null)
                {
                    result = connection.DimensionSubset(dbName, SubsetEditor.Dimension, FGeneral.Indent,
                        aliasFS, fieldFS, basicFS, dataFS, sortFS, structFS, textFS);
                }
            }
            catch (Exception exp )
            {
               ErrorHandler.DisplayError("Error getting subset !", exp);
            }

            return result;
        }

        public string GetXmlFromSubset()
        {
            MemoryStream mstream = new MemoryStream();
            
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            ws.IndentChars = "    ";
            ws.NewLineChars = "\n";
            ws.Encoding = Encoding.UTF8;

            XmlWriter w = XmlWriter.Create(mstream, ws);
            w.Flush();

            w.WriteProcessingInstruction("palosubset", "version=\"" + Version + "\"");
            w.WriteStartElement(xmlName, "http://www.jedox.com/palo/SubsetXML");

            /**
             * 1.0rc2, 1.0rc3:
             * w.WriteAttributeString("name", Common.CurrentASubset.SubsetEditor.CurrentSubsetName);
             * */
            w.WriteAttributeString("id", this.id.ToString());
            w.WriteAttributeString("sourceDimensionId", PaloInfo.Instance.GetDimensionId(SubsetEditor.Dimension).ToString());

            fGeneral.FillXmlFromFilter(w);
            fHierarchy.FillXmlFromFilter(w);
            fText.FillXmlFromFilter(w);
            fAttribute.FillXmlFromFilter(w);
            fData.FillXmlFromFilter(w);
            fPicklist.FillXmlFromFilter(w);
            fSort.FillXmlFromFilter(w);

            w.WriteEndElement();
            w.Flush();

            UTF8Encoding enc = new UTF8Encoding();
            return enc.GetString(mstream.ToArray()).Substring(1); // HACK: Strange alien charachter at the beginning of the string
        }

        private bool ReadVersion(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
                if (node.NodeType == XmlNodeType.ProcessingInstruction && node.Name == "palosubset")
                {
                    foreach (string v in this.SupportedVersions)
                        if (node.Value == "version=\"" + v + "\"")
                    return true;
                }

            return false;
        }

        private void SetSubsetFromXml(string xmlData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);

            if (!ReadVersion(doc.ChildNodes))
            {
                throw new FormatException();
            }

            XmlNode root = doc.DocumentElement;

            if (root.Name != xmlName)
            {
                throw new FormatException();
            }

            // Required Fields:
            this.id = Int32.Parse(root.Attributes["id"].Value);


            /* 
            //ignore item sourceDimension entry in XML
            //dimension is one coordinate of the cube cell 
            try
            {
                this.DimensionId = Int32.Parse(root.Attributes["sourceDimensionId"].Value);
            }
            catch
            {
                this.DimensionId = PaloInfo.Instance.GetDimensionId(root.Attributes["sourceDimension"].Value);
            }
            */

            // JMM 2015-10-20
            var Attr = root.Attributes["name"];
            Common.CurrentASubset.SubsetEditor.CurrentSubsetName = (Attr != null) ? Attr.Value : this.SubsetEditor.LoadedSubsetNodeText;

            fGeneral.SetFilterFromXml(root);
            fHierarchy.SetFilterFromXml(root);
            fText.SetFilterFromXml(root);
            fAttribute.SetFilterFromXml(root);
            fData.SetFilterFromXml(root);
            fPicklist.SetFilterFromXml(root);
            fSort.SetFilterFromXml(root);
        }

        public string GetXmlFromSubset_Safe(string subsetName, int id)
        {
            Common.CurrentASubset.SubsetEditor.CurrentSubsetName = subsetName;
            this.id = id;
            StringBuilder sb = new StringBuilder();
            return GetXmlFromSubset();
        }

        public void SetSubsetFromXml_Safe(string xmlData)
        {
            try
            {
                SetSubsetFromXml(xmlData);
            }
            catch (Exception)
            {
                throw new FormatException();
            }
            finally
            {
                ResumeLayout();
            }
        }

        public void UpdateElements()
        {
            FGeneral.SetLevelType("Indent");

            if (RequestingElements != null)
            {
                RequestingElements(this, new EventArgs());
            }
            
            foreach (PElement pe in fHierarchy.PElements)
            {
                PaloInfo.Instance.CopyDNMTreeToDDTree(PaloInfo.Instance.ElementsTree, pe);
                pe.SetDefault();
            }

            foreach (PAlias pa in fGeneral.PAliases)
            {
                pa.DataSource = null;
                pa.DataSource = new List<String>(PaloInfo.Instance.Aliases);
                pa.FirstValidIndex = 1;
            }

            foreach (PAlias pa in fSort.PAliases)
            {
                pa.DataSource = null;
                pa.DataSource = new List<String>(PaloInfo.Instance.Attributes);
                pa.FirstValidIndex = 0;
            }

            foreach (PCube pc in fData.PCubes)
            {
                pc.DataSource = null;
                pc.DataSource = new List<String>(PaloInfo.Instance.Cubes);
            }

            foreach (PAttribute pa in fAttribute.PAttributes)
            {
                pa.DGVAttributes.Rows.Clear();
                pa.DGVAttributes.Columns.Clear();

                for (int i = 0; i < PaloInfo.Instance.Attributes.Count; i++)
                {
                    DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
                    tbc.HeaderText = PaloInfo.Instance.Attributes[i];
                    tbc.Name = tbc.HeaderText;
                    tbc.SortMode = DataGridViewColumnSortMode.NotSortable;
                    tbc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                    pa.DGVAttributes.Columns.Add(tbc);
                }
            }

            if (PaloInfo.Instance.Aliases.Count == 1)
            {
                cbAttributeActivate.Checked = false;
                cbAttributeActivate.Enabled = false;
                fSort.EnableAttributeSort(false);
            }
            else
            {
                cbAttributeActivate.Enabled = true;
                fSort.EnableAttributeSort(true);
            }
        }

        private void InitializeControls()
        {
            tlpNamedParams = new TableLayoutPanel();
            tlpNamedParams.AutoScroll = true;
            tlpNamedParams.Dock = DockStyle.Fill;
            tlpNamedParams.BackColor = ResourceInitializer.FormStdBackgroundColor;

            Common.CurrentASubset = this;

            Common.InternationalizeControl(cbHierarchyActivate, true, false, null);
            Common.InternationalizeControl(cbTextActivate, true, false, null);
            Common.InternationalizeControl(cbPicklistActivate, true, false, null);
            Common.InternationalizeControl(cbAttributeActivate, true, false, null);
            Common.InternationalizeControl(cbDataActivate, true, false, null);

            Common.InternationalizeControl(lbGeneral, true, false, null);
            Common.InternationalizeControl(lbHierarchy, true, false, null);
            Common.InternationalizeControl(lbText, true, false, null);
            Common.InternationalizeControl(lbPicklist, true, false, null);
            Common.InternationalizeControl(lbAttribute, true, false, null);
            Common.InternationalizeControl(lbData, true, false, null);
            Common.InternationalizeControl(lbSorting, true, false, null);

            Common.InternationalizeControlTitle(tpGeneral, true);
            Common.InternationalizeControlTitle(tpHierarchy, true);
            Common.InternationalizeControlTitle(tpText, true);
            Common.InternationalizeControlTitle(tpPicklist, true);
            Common.InternationalizeControlTitle(tpAttribute, true);
            Common.InternationalizeControlTitle(tpData, true);
            Common.InternationalizeControlTitle(tpSort, true);

            tcFilters.ImageList = new ImageList();
            tcFilters.ImageList.Images.Add(ResourceInitializer.IconCheckmark);
            //this.tcFilters.IDE2005Style = Crownwood.DotNetMagic.Controls.IDE2005Style.StandardDark;
            //this.tcFilters.OfficeStyle = Crownwood.DotNetMagic.Controls.OfficeStyle.Light;

            tpGeneral.BackColor = ResourceInitializer.FormStdBackgroundColor;
            tpHierarchy.BackColor = ResourceInitializer.FormStdBackgroundColor;
            tpText.BackColor = ResourceInitializer.FormStdBackgroundColor;
            tpPicklist.BackColor = ResourceInitializer.FormStdBackgroundColor;
            tpAttribute.BackColor = ResourceInitializer.FormStdBackgroundColor;
            tpData.BackColor = ResourceInitializer.FormStdBackgroundColor;
            tpSort.BackColor = ResourceInitializer.FormStdBackgroundColor;

            tpSort.Selected = false;
            tpData.Selected = false;
            tpAttribute.Selected = false;
            tpPicklist.Selected = false;
            tpText.Selected = false;
            tpHierarchy.Selected = false;
            tpGeneral.Selected = false;

            tcFilters.SelectedTab = tpGeneral;

            try
            {
                autoRefreshWarningEnabled = Convert.ToBoolean(RegUtils.GetIntValue4Form(form, regpath));
            }
            catch
            {
            }
        }

        private void cbHierarchyActivate_CheckedChanged(object sender, EventArgs e)
        {
            fHierarchy.Enabled = cbHierarchyActivate.Checked;
            if (fHierarchy.Enabled)
            {
                Common.CurrentASubset.FGeneral.cbShowHidden.Checked = true;
                //tpHierarchy.Image = ResourceInitializer.IconCheckmark;
                tpHierarchy.ImageIndex = 0;
            }
            else
            {
                tpHierarchy.ImageIndex = -1;
            }
        }

        private void cbTextActivate_CheckedChanged(object sender, EventArgs e)
        {
            fText.Enabled = cbTextActivate.Checked;
            tpText.ImageIndex = fText.Enabled ? 0 : -1;
        }

        private void cbPicklistActivate_CheckedChanged(object sender, EventArgs e)
        {
            fPicklist.Enabled = cbPicklistActivate.Checked;
            tpPicklist.ImageIndex = fPicklist.Enabled ? 0 : -1;
        }

        private void cbAttributeActivate_CheckedChanged(object sender, EventArgs e)
        {
            fAttribute.Enabled = cbAttributeActivate.Checked;
            tpAttribute.ImageIndex = fAttribute.Enabled ? 0 : -1;
        }

        private void cbDataActivate_CheckedChanged(object sender, EventArgs e)
        {
            fData.Enabled = cbDataActivate.Checked;
            tpData.ImageIndex = fData.Enabled ? 0 : -1;
            if (Common.CurrentASubset.SubsetEditor.CtrlPreview.CBAutoRefresh.Checked && cbDataActivate.Checked)
            {
                Common.CurrentASubset.SubsetEditor.CtrlPreview.CBAutoRefresh.Checked = false;
                Common.CurrentASubset.SubsetEditor.CtrlPreview.ClearPreviewData();

                if (this.Visible && this.autoRefreshWarningEnabled)
                {
                    JControls.AnnoylessBox frm = new JControls.AnnoylessBox();
                    frm.LabelMessage = SubsetHelper.GetI18String("AUTOREFRESH_WARNING", "SB_");
                    frm.LabelDontShow = SubsetHelper.GetI18String("AUTOREFRESH_DONT_SHOW", "SB_");
                    frm.ShowDialog();
                    Common.CurrentASubset.EnableAutoRefreshWarning(!frm.HideDialog);
                    frm.Dispose();
                    frm = null;
                }
            }

            Common.CurrentASubset.FSort.EnableValueSort(fData.Enabled);
        }

        private bool aSubsetEnabled = false;
        public void EnableASubset(bool enable)
        {
            cbHierarchyActivate.Enabled = enable;
            cbTextActivate.Enabled = enable;
            cbPicklistActivate.Enabled = enable;
            cbAttributeActivate.Enabled = enable;
            cbDataActivate.Enabled = enable;

            fHierarchy.Enabled = enable && cbHierarchyActivate.Checked;
            fText.Enabled = enable && cbTextActivate.Checked;
            fPicklist.Enabled = enable && cbPicklistActivate.Checked;
            fAttribute.Enabled = enable && cbAttributeActivate.Checked;
            fData.Enabled = enable && cbDataActivate.Checked;
            fGeneral.EnableGeneral(enable);

            aSubsetEnabled = enable;
        }

        bool autoRefreshWarningEnabled = true;
        public void EnableAutoRefreshWarning(bool enable)
        {
            autoRefreshWarningEnabled = enable;
            RegUtils.SetKeyValue4Form(form, regpath, (enable) ? 1 : 0);
        }

        public virtual void OnQueryXCell(QueryXCellEventArgs e)
        {
            if (QueryXCell != null)
            {
                QueryXCell(this, e);
            }
        }

        public virtual void OnPickXCell(QueryXCellEventArgs e)
        {
            if (PickXCell != null)
            {
                PickXCell(this, e);
            }
        }

        public delegate void QueryXCellEventHandler(object sender, QueryXCellEventArgs e);
        public delegate void PickXCellEventHandler(object sender, QueryXCellEventArgs e);

        public event QueryXCellEventHandler QueryXCell;
        public event PickXCellEventHandler PickXCell;
        public event EventHandler RequestingElements;

    }

    public class QueryXCellEventArgs : EventArgs
    {
        private string cellRange;

        public string CellRange
        {
            get { return cellRange; }
            set { cellRange = value; }
        }

        private string excelValue;

        public string ExcelValue
        {
            get { return excelValue; }
            set { excelValue = value; }
        }

        public QueryXCellEventArgs()
        {
        }
    }
}
