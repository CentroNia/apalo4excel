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
//  JMM 10-21-15 fixed err adding new subset

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Jedox.Palo.Comm;
using JControls;
using Apalo.XlAddin.JSubSet;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
    public enum EditorType { GlobalOnly, GlobalAndLocal };

    public partial class SubSetEditor : Form
    {
        private const string SUBSETEDITOR = "SubsetEditor";
        private const string SB_DISTANCE_SPLITTER_BASE = "SB_DISTANCE_SPLITTER";
        private const string SB_DISTANCE_SPLITTER1 = SB_DISTANCE_SPLITTER_BASE + "1";
        private const string SB_DISTANCE_SPLITTER2 = SB_DISTANCE_SPLITTER_BASE + "2";

        public CtrlPreview CtrlPreview
        {
            get { return ctrlPreview; }
        }
        
        private String savedSValue;
        private TableLayoutPanel tlpNamedParams;

        private SubsetType currentSubsetType;
        public SubsetType CurrentSubsetType
        {
            get { return currentSubsetType; }
            set { currentSubsetType = value; }
        }

        private String currentSubsetName;
        public String CurrentSubsetName
        {
            get { return currentSubsetName; }
            set { currentSubsetName = value; }
        }

        public String LoadedSubsetNodeText
        {
            get
            {
                if (
                    cSubsets.LoadedSubsetNode != null
                    && cSubsets.LoadedSubsetNode.Text != null
                    && cSubsets.LoadedSubsetNode.Text != "")
                {

                    return cSubsets.LoadedSubsetNode.Text;
                }
                else
                {
                    return "Untitled";
                }
            }
        }

        private string dimension = "";
        public string Dimension
        {
            get { return (dimension != null) ? dimension : ""; }
            set { dimension = value; }
        }

        public bool isflat = false;

        public SubSetEditor(EditorType type, string server, string dbname, string dim)
        {
            PreInit();
            InitializeComponent();
            InitializeControls(type);

            string _server = (String.IsNullOrEmpty(server) ? RegUtils.ActiveConnection : server);
            string _dbname = (String.IsNullOrEmpty(dbname) ? RegUtils.ActiveDB : dbname);


            PostInit(_server, _dbname, dim);
        }

        private void PreInit()
        {
            // This doesn't work, let's try to use "," always 
            // (since we disabled Copy to clipboard):
            //Common.Separator2 = (string)ExcelHelper.oExcelApp.get_International(Microsoft.Office.Interop.Excel.XlApplicationInternational.xlListSeparator);
            //Common.Separator = (Common.Separator2 == ";" ? "," : ";");

            Common.Separator = ",";
            Common.Separator2 = ";";

            FillNamedRanges();
        }

        private void PostInit(string server, string dbname, string dimension)
        {
            string errmesg = "Error in PostInit";
            try
            {
                aSubSet.SetDBConn(server, dbname);
                aSubSet.Dimension = dimension;

                if (aSubSet.Connection != null)
                {
                    try
                    {
                        foreach (string tmpDim in aSubSet.Connection.DatabaseListDimensions(aSubSet.DatabaseName))
                        {
                            if (!ListBoxHelper.IsJPaloDim(tmpDim))
                            {
                                try
                                {
                                    PaloInfo.Instance.DimensionsID.Add(aSubSet.Connection.DimensionInformationSimple(aSubSet.DatabaseName, tmpDim).id);
                                    PaloInfo.Instance.Dimensions.Add(tmpDim);
                                }
                                catch (Exception e2)
                                {
                                    ErrorHandler.DisplayError(errmesg, e2);
                                }
                            }
                        }
                    }
                    catch (Exception e1)
                    {
                        ErrorHandler.DisplayError(errmesg, e1);
                    }
                }
            }
            catch (Exception e0)
            {
                ErrorHandler.DisplayError(errmesg, e0);
            }
            

            savedSValue = aSubSet.SValue;
            modified = false;
            btSave.Enabled = false;

            scMain.Panel2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            scMain.Panel1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            aSubSet.BackColor = ResourceInitializer.FormStdBackgroundColor;
            tspMain.TopToolStripPanel.BackColor = ResourceInitializer.FormStdBackgroundColor;

            aSubSet.Controls[0].BackColor = ResourceInitializer.FormStdBackgroundColor;
            aSubSet.FAttribute.BackColor = ResourceInitializer.FormStdBackgroundColor;
            aSubSet.FData.BackColor = ResourceInitializer.FormStdBackgroundColor;
            aSubSet.FGeneral.BackColor = ResourceInitializer.FormStdBackgroundColor;
            aSubSet.FHierarchy.BackColor = ResourceInitializer.FormStdBackgroundColor;
            aSubSet.FSort.BackColor = ResourceInitializer.FormStdBackgroundColor;
            aSubSet.FText.BackColor = ResourceInitializer.FormStdBackgroundColor;
            //aSubSet.FPicklist.BackColor = ResourceInitializer.FormStdBackgroundColor;

            aSubSet.SubsetEditor.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tTip.ToolTipTitle = SubsetHelper.GetI18String("Description", "SB_");
        }

        private bool modified;
        public bool IsDirty 
        {
            get { return modified; }
        }

        private int GetUDRegData(string path)
        {
            return RegUtils.GetIntValue4Form(SUBSETEDITOR, path);
        }

        private void SetUDRegData(string path, object value)
        {
            RegUtils.SetKeyValue4Form(SUBSETEDITOR, path, value);
        }

        private void aSubSet_RequestingElements(object sender, EventArgs e)
        {
            PaloInfo.Instance.Cubes.Clear();
            PaloInfo.Instance.CubesID.Clear();

            PaloInfo.Instance.Elements.Clear();
            PaloInfo.Instance.ElementsID.Clear();

            PaloInfo.Instance.Elements.Add(SubsetHelper.GetI18String("All Elements", "SB_CB_"));
            PaloInfo.Instance.ElementsID.Add(-1);
            SubsetUtils.GenerateTree(Common.CurrentASubset.Connection, Common.CurrentASubset.DatabaseName, dimension, ref PaloInfo.Instance.ElementsTree);

            List<string> cubes = ListBoxHelper.GetCubeList(aSubSet.Connection, aSubSet.DatabaseName, GeneralConst.NORMAL_CUBE_VIEW, false);

            foreach (string tmpCube in cubes)
            {
                PaloInfo.Instance.Cubes.Add(tmpCube);
                PaloInfo.Instance.CubesID.Add(aSubSet.Connection.CubeInformation(aSubSet.DatabaseName, tmpCube).id);
            }

            ElementInfo[] dei = aSubSet.Connection.DimensionListElements(aSubSet.DatabaseName, this.Dimension);
            foreach (ElementInfo de in dei)
            {
                PaloInfo.Instance.Elements.Add(de.Name);
                PaloInfo.Instance.ElementsID.Add(de.Identifier);
            }

            FillAliasesAndAttributes();
        }

        private void FillNamedRanges()
        {
            try
            {                
                ExcelHelper eh = new ExcelHelper();
                Common.NamedParams = eh.GetNamedRangeList();
            }
            catch
            {
            }
        }

        #region Alias filling stuff here

        private void FillAliasesAndAttributes()
        {
            PaloInfo.Instance.Aliases.Clear();
            PaloInfo.Instance.AliasesID.Clear();
            PaloInfo.Instance.Attributes.Clear();
            PaloInfo.Instance.AttributesID.Clear();

            try
            {
                PaloInfo.Instance.Aliases.Add("<" + ResourceInitializer.TEXT_NONE + ">");
                PaloInfo.Instance.AliasesID.Add(-1);
                ArrayList attr = new ArrayList();
                ArrayList attrId = new ArrayList();


                ElementInfo[] attribs = AttributeHelper.checkattributes(aSubSet.Connection, aSubSet.DatabaseName, this.Dimension, ref attr, ref attrId);

                int i;

                for (i = 0; i < attribs.Length; i++)
                {
                    if (attribs[i].Name.ToUpper() != GeneralConst.ATTRIBUT_ALIAS)
                    {
                        PaloInfo.Instance.Attributes.Add(attribs[i].Name);
                        PaloInfo.Instance.AttributesID.Add(attribs[i].Identifier);
                    }
                }

                for (i = 0; i < attr.Count; i++)
                {
                    PaloInfo.Instance.Aliases.Add((string)attr[i]);
                    PaloInfo.Instance.AliasesID.Add((int)attrId[i]);
                }
            }
            catch (Jedox.Palo.Comm.PaloException)
            {
            }
        }

        #endregion

        private void OnDimensionChanged(object sender, EventArgs e)
        {
            if (aSubSet.Dimension == this.Dimension)
            {
                return;
            }

            if (AskAndSaveChangesIfNeeded() == DialogResult.Cancel)
            {
                aSubSet.Dimension = this.Dimension;
                return;
            }
            this.Dimension = aSubSet.Dimension;
            if (this.Dimension == "") return;

            FillStoredSubsets();

            aSubSet.UpdateElements();
            this.SetDefault();
            tlpNamedParams.Controls.Clear();
            pNamedParams.Visible = false;

            //savedSValue = aSubSet.SValue;
            //modified = false;
            //btSave.Enabled = false;
            cSubsets.SelectFormulaSubset();
        }

        private void FillStoredSubsets()
        {
            #region Here comes the code for loading stored subsets into list

            List<string> globalSub = SubsetHelper.GetGlobalSubsetList(aSubSet.Connection, aSubSet.DatabaseName, this.Dimension);
            cSubsets.ClearNodesOfType(SubsetType.Global);
            foreach (string s in globalSub)
            {
                cSubsets.AddStoredSubSet(s, SubsetType.Global);
            }

            if (this.EditorType == EditorType.GlobalAndLocal)
            {
                cSubsets.ClearNodesOfType(SubsetType.Local);
                List<string> localSub = SubsetHelper.GetLocalSubsetList(aSubSet.Connection, Common.CurrentASubset.FGeneral.ServerName, aSubSet.DatabaseName, this.Dimension);
                foreach (string s in localSub)
                {
                    cSubsets.AddStoredSubSet(s, SubsetType.Local);
                }
            }
            
            #endregion
        }

        private void InitializeControls(EditorType type)
        {
            statusStrip1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            tspMain.TopToolStripPanel.BackColor = ResourceInitializer.FormStdBackgroundColor;
            scMain.Panel1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            scMain.Panel2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            scMain.BackColor = ResourceInitializer.FormStdBackgroundColor;
            
            ctrlPreview.BTRefresh.Click += new EventHandler(RefreshPreview);
            ctrlPreview.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            ctrlPreview.CBAutoRefresh.CheckedChanged += new EventHandler(CBAutoRefresh_CheckedChanged);
            ctrlPreview.CBAutoRefresh.Text = SubsetHelper.GetI18String("Auto Refresh", "SB_");
            Common.InternationalizeControl(ctrlPreview.CBAutoRefresh, false, true, tTip);

            //ctrlPreview.BTRefresh.Text = SubsetHelper.GetI18String("Refresh", "SB_");
            ctrlPreview.BTRefresh.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            ctrlPreview.BTRefresh.ButtonImage = Utils.ResourceInitializer.IconRefresh;
            ctrlPreview.BTRefresh.RolloverImage = Utils.ResourceInitializer.IconRefreshH;
            Common.InternationalizeControl(ctrlPreview.BTRefresh, false, true, tTip);

            cSubsets.BTAdd.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            cSubsets.BTAdd.ButtonImage = Utils.ResourceInitializer.IconElementAdd;
            cSubsets.BTAdd.RolloverImage = Utils.ResourceInitializer.IconElementAddH;
            cSubsets.BTAdd.Location = new Point(4, 573);
            Common.InternationalizeControl(cSubsets.BTAdd, false, true, tTip);

            cSubsets.BTRename.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            cSubsets.BTRename.ButtonImage = Utils.ResourceInitializer.IconElementRename;
            cSubsets.BTRename.RolloverImage = Utils.ResourceInitializer.IconElementRenameH;
            cSubsets.BTRename.Location = new Point(66, 573);
            Common.InternationalizeControl(cSubsets.BTRename, false, true, tTip);

            cSubsets.BTRemove.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            cSubsets.BTRemove.ButtonImage = Utils.ResourceInitializer.IconElementDelete;
            cSubsets.BTRemove.RolloverImage = Utils.ResourceInitializer.IconElementDeleteH;
            cSubsets.BTRemove.Location = new Point(35, 573);
            Common.InternationalizeControl(cSubsets.BTRemove, false, true, tTip);

            ctrlPreview.BTRefresh.Location = new Point(206, 573);
            ctrlPreview.CBAutoRefresh.Location = new Point(6, 573);

            lbPreview.Text = SubsetHelper.GetI18String("Preview", "SB_");

            lbNamedParams.Text = SubsetHelper.GetI18String("Named Parameters", "SB_");
            pInnerNamedParams.Controls.Add(tlpNamedParams = aSubSet.TlpNamedParams);


            this.scVertical2.Panel1MinSize = 525;
            this.scVertical2.Panel2MinSize = 0;
            this.scVertical1.Panel2MinSize = 525;
            this.scVertical1.Panel1MinSize = 144;

            if ((aSubSet != null) && (aSubSet.CBDimension != null))
            {
                aSubSet.CBDimension.SelectedIndexChanged += new EventHandler(OnDimensionChanged);
            }

            aSubSet.SubsetEditor = this;
            this.EditorType = type;

            Common.InternationalizeControl(btSave, true, true, tTip);
            Common.InternationalizeControl(btClose, true, true, tTip);
            Common.InternationalizeControl(btPaste, true, true, tTip);
            Common.InternationalizeControl(btCopy, false, true, tTip);

            if (type == EditorType.GlobalOnly)
            {
                btPaste.Visible = false;
                btSave.Location = btPaste.Location;
            }

            #region Handling restore form's size/position
            int[] tmpProps = RegUtils.GetFormProperties(SUBSETEDITOR);
            if (tmpProps[0] != -1)
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Size = new System.Drawing.Size(tmpProps[2], tmpProps[3]);
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
            }
            else
            {
                this.Size = new System.Drawing.Size(773, 547);
                this.StartPosition = FormStartPosition.CenterScreen;
            }

            try
            {
                scVertical1.SplitterDistance = GetUDRegData(SB_DISTANCE_SPLITTER1);
                scVertical2.SplitterDistance = GetUDRegData(SB_DISTANCE_SPLITTER2);
            }
            catch
            {
            }

            #endregion			

            tmTimer.Enabled = true;
        }

        private EditorType eType = EditorType.GlobalAndLocal;
        public EditorType EditorType
        {
            get { return eType; }
            set
            {
                cSubsets.EditorType = value;
                eType = value;
                if (eType == EditorType.GlobalOnly)
                {
                    aSubSet.FGeneral.EnableDBChange = false;
                    lbStoredSubsets.Text = SubsetHelper.GetI18String("Stored Subsets", "SB_");
                }
                else
                {
                    aSubSet.FGeneral.EnableDBChange = true;
                    lbStoredSubsets.Text = SubsetHelper.GetI18String("Stored Subsets", "SB_");
                }
            }
        }

        public DialogResult AskAndSaveChangesIfNeeded()
        {
            if (!this.IsDirty)
            {
                return DialogResult.No;
            }

            if (this.CurrentSubsetType == SubsetType.Formula)
            {
                return DialogResult.No;
            }

            DialogResult dr = MessageBox.Show(
                SubsetHelper.GetI18String("Save Question", "SB_MB_") + CurrentSubsetName,
                SubsetHelper.GetI18String("Save subset", "SB_MB_"),
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (dr == DialogResult.Yes)
            {
                this.SaveSubset(CurrentSubsetName, CurrentSubsetType);
            }
           
            return dr;
        }

        public void SetDefault()
        {
            aSubSet.FGeneral.SetDefault();
            aSubSet.FHierarchy.SetDefault();
            aSubSet.FText.SetDefault();
            aSubSet.FPicklist.SetDefault();
            aSubSet.FAttribute.SetDefault();
            aSubSet.FData.SetDefault();
            aSubSet.FSort.SetDefault();
            this.savedSValue = aSubSet.SValue;
            this.modified = false;
            this.btSave.Enabled = false;
        }

        public bool RenameSubset(string originalSubsetName, string newSubsetName)
        {
            try
			{
                // Make sure that the new version is the latest:
                DeleteSubset(originalSubsetName, cSubsets.LoadedSubsetType);
                SaveSubset(newSubsetName, cSubsets.LoadedSubsetType);
                return true;
			}
			catch(Jedox.Palo.Comm.PaloException pe)
			{
                ErrorHandler.HandleErrorElementRename(pe);
                return false;
            }
        }

        public bool LoadSubset(string subsetName, SubsetType type, bool throwexecption)
        {
            cSubsets.SelectNode(subsetName, type);

            if (type == SubsetType.Formula)
            {
                CurrentSubsetType = SubsetType.Formula;
                CurrentSubsetName = subsetName;
                btSave.Visible = false;
                this.SetDefault();
                return true;
            }
           
            CurrentSubsetType = type;
            btSave.Visible = true;
            string errormsg = "Problem reading subset";

            string xmlData = "";
            #region Here comes the code for loading string that represents subset into string xmlData
            try
            {
                string tmpStrVal = "";
                double tmpDblVal = 0.0;

                if (type == SubsetType.Global)
                {
                    aSubSet.Connection.GetData(ref tmpStrVal, ref tmpDblVal, aSubSet.DatabaseName, SubsetHelper.CubeFromType(type), new string[] { this.Dimension, subsetName });
                }
                else
                {
                    aSubSet.Connection.GetData(ref tmpStrVal, ref tmpDblVal, aSubSet.DatabaseName, SubsetHelper.CubeFromType(type), new string[] { this.Dimension, Apalo.XlAddin.Connections.GetCredentials(Common.CurrentASubset.FGeneral.ServerName).user, subsetName });
                }
                
                xmlData = tmpStrVal;
            }            
            catch (PaloException ex)
            {
                //  JMM 2015-10-21
                if (!cSubsets.IsNewSubset)
                ErrorHandler.DisplayError(errormsg, ex);
                if (throwexecption) throw;
                // IMPORTANT: If loading was not successful, return false:
                return false;
            }
            
            #endregion



            try
            {
                aSubSet.SetSubsetFromXml_Safe(xmlData);
                savedSValue = aSubSet.SValue;
                modified = false;
                btSave.Enabled = false;
                
                return true;
            }
            catch (FormatException ex)
            {
                ErrorHandler.ProcessError(errormsg, ex);
                if (throwexecption) throw;
                MessageBox.Show(SubsetHelper.GetI18String("Invalid Subset", "SB_MB_"), SubsetHelper.GetI18String("Error", "SB_MB_"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ProcessError(errormsg, ex);
                if (throwexecption) throw;
                MessageBox.Show(SubsetHelper.GetI18String("Internal Error", "SB_MB_"), SubsetHelper.GetI18String("Error", "SB_MB_"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool LoadSubset(string subsetName, SubsetType type)
        {
            return LoadSubset(subsetName, type, false);
        }

        public bool SaveSubset(string subsetName, SubsetType type)
        {
            CurrentSubsetType = type;

            if (subsetName == null)
            {
                return false;
            }

            if (type == SubsetType.Formula)
            {
                return false;
            }

            #region Here comes the code for storing string xmlData into file
            try
            {
                int id = -1;

                try
                {
                    id = aSubSet.Connection.ElementInformationSimple(aSubSet.DatabaseName, GeneralConst.SUBSET_DIM, subsetName).Identifier;
                }
                catch
                {
                }

                /// if no element present then we add the new one
                /// and we get its ID
                if (id == -1)
                {
                    aSubSet.Connection.DimensionAddOrUpdateElement(aSubSet.DatabaseName, GeneralConst.SUBSET_DIM, subsetName);
                    aSubSet.Connection.Ping();

                    /// and here we do it again
                    id = aSubSet.Connection.ElementInformationSimple(aSubSet.DatabaseName, GeneralConst.SUBSET_DIM, subsetName).Identifier;
                }

                string xmlData = aSubSet.GetXmlFromSubset_Safe(subsetName, id);

                if (type == SubsetType.Global)
                {
                    aSubSet.Connection.SetData(aSubSet.DatabaseName, SubsetHelper.CubeFromType(type), new string[] { this.Dimension, subsetName }, xmlData);
                }
                else
                {
                    aSubSet.Connection.SetData(aSubSet.DatabaseName, SubsetHelper.CubeFromType(type), new string[] { this.Dimension, Apalo.XlAddin.Connections.GetCredentials(Common.CurrentASubset.FGeneral.ServerName).user, subsetName }, xmlData);
                }
                this.savedSValue = aSubSet.SValue;
                this.modified = false;
                btSave.Enabled = false;

                // IMPORTANT: After saving, return true (if saving succeeded)
                // or false (if saving failed)

                return true;
            }
            catch (PaloException ex)
            {
                Utils.ErrorHandler.DisplayError("Problem saving subset", ex);
                return false;
            }

            #endregion
        }

        public bool DeleteSubset(string subsetName, SubsetType type)
        {
            #region Here comes the code where you try to remove the stored subset
           
            if (SubsetHelper.DeleteSubset(aSubSet.Connection, Common.CurrentASubset.FGeneral.ServerName, aSubSet.DatabaseName, this.Dimension, subsetName, type))
            {
                this.CurrentSubsetName = "";
                this.savedSValue = aSubSet.SValue;
                this.modified = false;
                btSave.Enabled = false;
                return true;
            }
            else
            {
                return false;
            }
         
            #endregion
        }

        #region Event Handlers
        private void copySubset_Chosen(object sender, EventArgs e)
        {
            Clipboard.SetText(aSubSet.SValue, TextDataFormat.UnicodeText);
            MessageBox.Show(SubsetHelper.GetI18String("Clipboard", "SB_MB_") + ":\n\n" + aSubSet.SValue, SubsetHelper.GetI18String("Info", "SB_MB_"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pasteSubset_Chosen(object sender, EventArgs e)
        {
            System.Threading.Thread currentThread = System.Threading.Thread.CurrentThread;
            System.Globalization.CultureInfo originalCulture = currentThread.CurrentCulture;
            System.Globalization.CultureInfo originalUICulture = currentThread.CurrentUICulture;
            Microsoft.Office.Interop.Excel.XlCalculation oldCalculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationManual;
            ExcelHelper eH = new ExcelHelper();

            try
            {
                currentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                currentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

                Microsoft.Office.Interop.Excel.Range eR = ExcelHelper.GetSelection();

                if ((eR.Cells.Count == 1) && ((bool)eR.HasArray))
                {
                    eR = eR.CurrentArray;
                }

                ExcelHelper.GetFormulaArrayFromSelection().ClearContents();

                ExcelHelper.SetScreenUpdating(false);
                oldCalculation = ExcelHelper.DisableAutomaticRecalc();

                // no need for array formula if only 1 cell selected
                if (eR.Cells.Count == 1)
                {
                    eH.AddFormulaToSpreadsheet(eR, aSubSet.SValue);
                }
                // for the sake of not wasting time if no limit hitting
                else if (aSubSet.SValue.Length > 254)
                {
                    // Excel has limit of 255 chars for FormulaArray cell property, Formula doesn't
                    // so we enter formula, apply array trick to it(sending keys - which is kinda ugly)
                    eH.AddFormulaToSpreadsheet(eR, aSubSet.SValue);
                    ExcelHelper.oExcelApp.SendKeys("{F2}^+{ENTER}", false);
                }
                else
                {
                    eH.AddFormulaArrayToSpreadsheet(eR, aSubSet.SValue);
                }

                //  and then we close the dialog
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(SubsetHelper.GetI18String("Paste Error", "SB_MB_") + ex.Message, SubsetHelper.GetI18String("Error", "SB_MB_"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // return old calculation
                if ((oldCalculation != ExcelHelper.GetCalculation()))
                {
                    ExcelHelper.SetCalculation(oldCalculation);
                }

                // screen updating
                ExcelHelper.SetScreenUpdating(true);

                eH.Dispose();
                eH = null;
                // Restore the culture information for the thread after the
                // Excel calls have completed.
                currentThread.CurrentCulture = originalCulture;
                currentThread.CurrentUICulture = originalUICulture;
            }
        }

        private void closeSubset_Chosen(object sender, EventArgs e)
        {
            if (AskAndSaveChangesIfNeeded() == DialogResult.Cancel) return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            MessageBox.Show(SubsetHelper.GetI18String("Cancel Subset", "SB_MB_"), SubsetHelper.GetI18String("Info", "SB_MB_"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void tmTimer_Tick(object sender, EventArgs e)
        {
            if (statusBar.Text != aSubSet.SValue || !this.subsetEditorEnabled)
            {
                if (this.subsetEditorEnabled)
                {
                    statusBar.Text = aSubSet.SValue;

                    if (ctrlPreview.CBAutoRefresh.Checked)
                    {
                        RefreshPreview(this, e);
                    }
                }
                else
                {
                    statusBar.Text = "";
                }
            }

            if (tlpNamedParams.Controls.Count > 0)
            {
                pNamedParams.Visible = true;
            }

            if (savedSValue != aSubSet.SValue && !String.IsNullOrEmpty(this.CurrentSubsetName))
            {
                modified = true;
                btSave.Enabled = true;
            }

            string title = SubsetHelper.GetI18String("Subset Editor", "SB_");
            if (this.subsetEditorEnabled)
            {
                try
                {
                    title += " - " + aSubSet.ServerName.ToUpper() + " / " + aSubSet.DatabaseName + ": " + this.Dimension + " (" + CurrentSubsetName + ")";
                }
                catch
                {
                }
            }

            if (this.Text != title)
            {
                this.Text = title;
            }
        }

        private void aSubSet_QueryXCell(object sender, QueryXCellEventArgs e)
        {
            try
            {
                Utils.ExcelHelper eh = new Utils.ExcelHelper();
                object value2 = eh.GetNamedRangeValues(e.CellRange);
                e.ExcelValue = Common.GetStringFromRangeValue(value2);
            }
            catch { }
        }

        private void aSubSet_PickXCell(object sender, QueryXCellEventArgs e)
        {
            #region Here comes the code where you pick cell(s) in Excel and read its current value(s)
            //TestPickX q = new TestPickX();

            //// The cell subsetName(s) is (are) in CellRange property of EventArgs:
            //q.ShowDialog();
            #endregion

            // IMPORTANT:
            // We put back the return value into ExcelValue property of EventArgs
            //e.CellRange = q.CellNames;
            //e.ExcelValue = q.CellValues;
        }

        private void RefreshPreview(object sender, EventArgs e)
        {
            SubsetResult[] results = aSubSet.GetSubSetResults(aSubSet.Connection, aSubSet.DatabaseName, GeneralConst.SUBSET_LIMIT);

            // since tree view has issues with reversed order we make it flat every time it gets complicated:
            // when show base only
            // when hierarchy and reversed
            // when reverse hierarchy and not reversed
            bool isHierarchy = ( aSubSet.FGeneral.rbHierarchy.Checked && 
                                 !aSubSet.FSort.cbReverse.Checked &&
                                 !aSubSet.FGeneral.cbReverseOrder.Checked)
                               && !aSubSet.FHierarchy.rbLeaves.Checked;

            ctrlPreview.SetPreviewData(results, isHierarchy, aSubSet.FGeneral.Indent);
        }

        private void CBAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (ctrlPreview.CBAutoRefresh.Checked)
            {
                RefreshPreview(this, e);
            }
        }

        private void SubSetEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (pNamedParams.Visible)
                {
                    if (tlpNamedParams.Controls.Count > 0)
                    {
                        MessageBox.Show(SubsetHelper.GetI18String("NP Hide Disabled", "SB_MB_"), SubsetHelper.GetI18String("Info", "SB_MB_"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        pNamedParams.Visible = false;
                    }
                }
                else
                {
                    pNamedParams.Visible = true;
                }
                
                e.Handled = true;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (cSubsets.SelectedSubsetType != SubsetType.Formula)
            {
                SaveSubset(CurrentSubsetName, cSubsets.SelectedSubsetType);
            }
        }

        private void SubSetEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegUtils.SetFormProperties(SUBSETEDITOR, new int[4] { this.Left, this.Top, this.Width, this.Height });
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            SetUDRegData(SB_DISTANCE_SPLITTER1, scVertical1.SplitterDistance);
            SetUDRegData(SB_DISTANCE_SPLITTER2, scVertical2.SplitterDistance);
        }

        #endregion

        private bool subsetEditorEnabled = false;
        public void SetEditorEnabled(bool enable)
        {
            cSubsets.Enabled = enable;
            ctrlPreview.Enabled = enable;
            if (!enable)
            {
                ctrlPreview.ClearPreviewData();
            }

            aSubSet.EnableASubset(enable);
            this.subsetEditorEnabled = enable;
        }

        private void scVertical2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pNamedParams_VisibleChanged(object sender, EventArgs e)
        {
            if (!pNamedParams.Visible)
            {
                tableLayoutPanel1.RowStyles[0].Height = 100.0F;
                tableLayoutPanel1.RowStyles[1].Height = 0.0F;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 50.0F;
                tableLayoutPanel1.RowStyles[1].Height = 50.0F;
            }
        }
    }
}
