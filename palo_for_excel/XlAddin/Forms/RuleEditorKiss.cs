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
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
    public partial class RuleEditorKiss : Form
    {
        #region Defines

        private Color activatedColor = Color.FromArgb(0, 0, 0);
        private Color deactivatedColor = Color.FromArgb(255, 0, 0);

        private const string RULEEDITORKISS = "RuleEditorKiss";
        private const string REKCOLUMNRATIOBASE = "RekColumnRatio";
        public const string REKCOLUMNRATIO1 = REKCOLUMNRATIOBASE + "1";
        public const string REKCOLUMNRATIO2 = REKCOLUMNRATIOBASE + "2";
        public const string REKCOLUMNRATIO3 = REKCOLUMNRATIOBASE + "3";

        private byte currCubeType;
        private Connection currConn;
        private string currDb;
        private string currCube;
        private RuleInfo currRule;
        private RuleInfo[] currRuleInfoList;
        private double columnRatio1;
        private double columnRatio2;
        private double columnRatio3;
        private static CultureInfo origCulture;
        private static RuleEditorAdvanced rea;
        #endregion

        #region Construct
        private void RuleEditorKiss_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                RegUtils.SetFormProperties(RULEEDITORKISS, new int[4] { this.Left, this.Top, this.Width, this.Height });
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                txtComment.Text = "";
            }
        }

        public void ReInit(string connName, string db, string cube)
        {
            currConn = Connections.GetConnection(connName);
            currDb = db;
            currCube = cube;
            this.FillListBox();
        }

        public RuleEditorKiss(string connName, string db, string cube, byte cubeType, System.Globalization.CultureInfo origCulture)
        {
            double tmpColumnRatio1 = 0;
            double tmpColumnRatio2 = 0;
            double tmpColumnRatio3 = 0;
            currCubeType = cubeType;
            RuleEditorKiss.origCulture = origCulture;
            FixRegistry();

            try
            {
                tmpColumnRatio1 = System.Convert.ToDouble(GetUDRegData(REKCOLUMNRATIO1));
            }
            catch
            {}

            try
            {
                tmpColumnRatio2 = System.Convert.ToDouble(GetUDRegData(REKCOLUMNRATIO2));
            }
            catch
            {}

            try
            {
                tmpColumnRatio3 = System.Convert.ToDouble(GetUDRegData(REKCOLUMNRATIO3));
            }
            catch
            { }


            columnRatio1 = (tmpColumnRatio1 == 0.0 ? 1.8545 : tmpColumnRatio1);
            columnRatio2 = (tmpColumnRatio2 == 0.0 ? 3.7878 : tmpColumnRatio2);
            columnRatio3 = (tmpColumnRatio3 == 0.0 ? 5.2521 : tmpColumnRatio3);

            InitializeComponent();
            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnClose.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnDelete.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnEdit.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnNew.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnUpdate.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.lblComment.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.lblRule.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.lblRuleList.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.lblStatus.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.pnlButtons.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.statusBar.BackColor = ResourceInitializer.FormStdBackgroundColor;

            #region Position/Size handling
            int[] tmpProps = RegUtils.GetFormProperties(RULEEDITORKISS);
            if (tmpProps[0] != -1)
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Size = new System.Drawing.Size(tmpProps[2], tmpProps[3]);
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
            }
            else
            {
                tmpProps = RegUtils.GetFormProperties(GeneralConst.MODELLER);
                if (tmpProps[0] != -1)
                    this.Size = new System.Drawing.Size(tmpProps[2], tmpProps[3]);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            #endregion

            #region Manually assigned resources
            this.toolTip.SetToolTip(this.btnUp, Utils.ResourceInitializer.TipRuleBtnMoveUp);
            this.toolTip.SetToolTip(this.btnDown, Utils.ResourceInitializer.TipRuleBtnMoveDown);
            this.toolTip.SetToolTip(this.btnDelete, Utils.ResourceInitializer.TipRuleBtnDelete);
            this.toolTip.SetToolTip(this.btnClose, Utils.ResourceInitializer.TipRuleBtnClose);
            this.toolTip.SetToolTip(this.btnImport, Utils.ResourceInitializer.TipRuleBtnImport);
            this.toolTip.SetToolTip(this.btnExport, Utils.ResourceInitializer.TipRuleBtnExport);
            
            this.btnDelete.Text = Utils.ResourceInitializer.BUTTON_DELETE;
            this.btnClose.Text = Utils.ResourceInitializer.ButtonRuleExit;
            this.Text = Utils.ResourceInitializer.TitleRuleEditor;
            this.lblRuleList.Text = Utils.ResourceInitializer.LabelRuleEditor;
            
            this.lblComment.Text = Utils.ResourceInitializer.TEXT_COMMENT;
            this.chComment.Text = Utils.ResourceInitializer.TEXT_COMMENT;

            this.chRule.Text = Utils.ResourceInitializer.RuleInfoRule;
            this.lblRule.Text = Utils.ResourceInitializer.RuleInfoRule;
            this.btnEdit.Text = Utils.ResourceInitializer.LabelButtonEdit;
            this.btnNew.Text = Utils.ResourceInitializer.LabelButtonNewRule;
            this.chUpdated.Text = Utils.ResourceInitializer.RuleInfoUpdated;

            this.lstRules.SelectedIndexChanged += new System.EventHandler(this.lstRules_SelectedIndexChanged);
            this.btnUpdate.Text = Utils.ResourceInitializer.UpdateButton;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.ReInit(connName, db, cube);

            this.btnUp.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconUp;
            this.btnUp.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconUpH;
            this.btnUp.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            
            this.btnDown.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconDown;
            this.btnDown.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconDownH;
            this.btnDown.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExport.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExport;
            this.btnExport.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExportH;
            this.btnExport.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnImport.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconImport;
            this.btnImport.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconImportH;
            this.btnImport.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.Icon = ResourceInitializer.IconPalo;
            this.ShowInTaskbar = true;

            this.cmdNew.Text = ResourceInitializer.CmdRuleAdd;
            this.cmdDelete.Text = ResourceInitializer.CmdRuleDelete;
            this.cmdEdit.Text = ResourceInitializer.CmdRuleEdit;
            this.cmdUp.Text = ResourceInitializer.CmdRuleMoveUp;
            this.cmdDown.Text = ResourceInitializer.CmdRuleMoveDown;
            this.cmdChangeStatus.Text = ResourceInitializer.CmdRuleChangeStatus;
            this.cmdInfo.Text = ResourceInitializer.CmdRuleInfo;

            #endregion
        }

        private Color GetColor(int i)
        {
            return (currRuleInfoList[i].activated) ? activatedColor : deactivatedColor;
        }

        private void FillListBox()
        {
            try
            {
                currRuleInfoList = currConn.ListRules(currDb, currCube);
            }
            catch (Exception exc)
            {
                currRuleInfoList = new RuleInfo[0];
                Utils.ErrorHandler.DisplayError("Error Reading rules", exc);
            }

            int i, length = currRuleInfoList.Length;
            this.lstRules.Items.Clear();

            for (i = 0; i < length; i++)
            {
                double timestamp = currRuleInfoList[i].timestamp;
                string printDate = FormatTimestamp(timestamp);
                string[] items = new string[] { currRuleInfoList[i].id.ToString(), currRuleInfoList[i].definition, currRuleInfoList[i].comment.Replace(GeneralConst.UNIX_NEWLINE, " "), printDate };
                ListViewItem it = new ListViewItem(items);
                it.ForeColor = GetColor(i);

                this.lstRules.Items.Add(it);
            }

            //if ((index > -1) && (index < this.lstRules.Items.Count))
            if (length > 0)
            {
                this.lstRules.Items[0].Selected = true;
                this.lstRules.Items[0].Focused = true;
            }
        }

        private static string FormatTimestamp(double timestamp)
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            // added +1 hour since timestamp comming from server is apparently 1 hour back
            //(probably not the right way to do it)
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(timestamp);

            // culture
            CultureInfo oldCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = RuleEditorKiss.origCulture;
            dateTime = dateTime.ToLocalTime();
            string printDate = dateTime.ToString();
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCulture;
            return printDate;
        }
        #endregion

        #region Helper


        private string GetUDRegData(string path)
        {
            return RegUtils.GetStringValue4Form(RULEEDITORKISS, path);
        }

        private void SetUDRegData(string path, object value)
        {
            RegUtils.SetKeyValue4Form(RULEEDITORKISS, path, value);
        }

        private void FixRegistry()
        {
            string regvalue = "";
            string path;
            int i = 0;
            for (i=1; i < 4; i++)
            {
                path = REKCOLUMNRATIOBASE + i.ToString();
                regvalue = RegUtils.GetStringValue(path);
                if (!string.IsNullOrEmpty(regvalue))
                {
                    SetUDRegData(path, regvalue);
                }
                RegUtils.DeleteValue(path);
            }
        }


        private bool RuleCheck(string ruledef)
        {
            if (ruledef.Trim().Replace(" ","") == "[]=[]")
            {
                return false;
            }
            return true;
        }

        private bool RuleCreate(string db, string cube, string ruledef, string extern_id, string comment, bool active)
        {
            if (RuleCheck(ruledef))
            {
                this.currConn.RuleCreate(db, cube, ruledef, extern_id, comment, active);
                return true;
            }
            return false;
        }

        private bool RuleModify(string db, string cube, int id, string ruledef, string extern_id, string comment, bool active)
        {
            if (RuleCheck(ruledef))
            {
                this.currConn.RuleModify(db, cube, id, ruledef, extern_id, comment, active);
                return true;
            }
            return false;
        }
        #endregion


        #region Button clicks/Listbox changes
        protected void lstRules_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int index = (this.lstRules.SelectedIndices != null && this.lstRules.SelectedIndices.Count > 0) ? (int)this.lstRules.SelectedIndices[0] : -1;
            if (index > -1 && index < currRuleInfoList.Length)
            {
                currRule = currRuleInfoList[index];
            }

            btnUp.Enabled = false;
            btnDown.Enabled = false;
            cmdUp.Enabled = false;
            cmdDown.Enabled = false;
            btnDelete.Enabled = false;
            cmdDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnExport.Enabled = false;
            cmdEdit.Enabled = false;
            btnEdit.Enabled = false;
            cmdInfo.Enabled = false;
            btnUpdate.Enabled = false;

            this.txtComment.Text = "";
            this.lblStatus.Text = "";
            this.lblStatus.ToolTipText = "";

            if (lstRules.Items.Count == 0)
            {
                return;
            }
            else
            {
                btnDelete.Enabled = true;
                cmdDelete.Enabled = true;
                btnExport.Enabled = true;
            }


            if (lstRules.SelectedIndices.Count == 1)
            {
                cmdInfo.Enabled = true;
                cmdEdit.Enabled = true;
                btnEdit.Enabled = true;
                cmdChangeStatus.Text = ResourceInitializer.CmdRuleChangeStatus;// "Active";

                if (index > 0)
                {
                    btnUp.Enabled = true;
                    cmdUp.Enabled = true;
                }

                if (index < this.currRuleInfoList.Length - 1)
                {
                    btnDown.Enabled = true;
                    cmdDown.Enabled = true;
                }

                cmdChangeStatus.Checked = currRuleInfoList[index].activated;
                txtComment.Text = this.currRuleInfoList[index].comment.Replace(GeneralConst.UNIX_NEWLINE, System.Environment.NewLine.ToString());
                txtRule.Text = this.currRuleInfoList[index].definition;
                txtRule.ForeColor = GetColor(index);
            }
            else
            {
                cmdChangeStatus.Text = ResourceInitializer.CmdRuleToggleActivity;// "Toggle Activity";
            }
        }

        protected void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(ResourceInitializer.QuestionDeleteRules, ResourceInitializer.TITLE_DELETE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                if (lstRules.SelectedIndices != null && lstRules.SelectedIndices.Count > 0)
                {
                    foreach (int index in lstRules.SelectedIndices)
                    {
                        if (index > -1)
                        {
                            currConn.RuleDelete(currDb, currCube, currRuleInfoList[index].id);
                        }
                    }

                    FillListBox();
                    txtComment.Text = "";
                    txtRule.Text = "";
                    if (lstRules.Items.Count == 0)
                    {
                        btnEdit.Enabled = false;
                        cmdEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        cmdDelete.Enabled = false;
                        btnUpdate.Enabled = false;
                        
                        btnUp.Enabled = false;
                        cmdUp.Enabled = false;
                        btnDown.Enabled = false;
                        cmdDown.Enabled = false;
                        btnExport.Enabled = false;

                        cmdInfo.Enabled = false;
                    }
                    lblStatus.Text = Utils.ResourceInitializer.StatusRuleDeleted;
                }
            }
            catch (PaloException pcx)
            {
                lblStatus.Text = "Error:" + pcx.PaloMessage;
                toolTip.SetToolTip(statusBar, "Error:" + pcx.PaloMessage.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        #endregion

        #region Arrange order

        private void domove(int offset)
        {
            this.btnDown.Enabled = false;
            this.btnUp.Enabled = false;
            this.cmdDown.Enabled = false;
            this.cmdUp.Enabled = false;

            try
            {
                int lower_limit = (offset > 0) ? -1 : 0;
                if ((this.lstRules != null) &&
                    (this.lstRules.SelectedIndices != null) &&
                    (this.lstRules.SelectedIndices.Count > 0) &&
                    (this.lstRules.SelectedIndices[0] > lower_limit) &&
                    (this.lstRules.SelectedIndices[0] < this.currRuleInfoList.Length + lower_limit))
                {
                    int tmpSelectedItem = this.lstRules.SelectedIndices[0];
                    int targetSelectedItem = tmpSelectedItem + offset;
                    RuleInfo tmpRfTarget = this.currRuleInfoList[targetSelectedItem];
                    RuleInfo tmpRfSource = this.currRuleInfoList[tmpSelectedItem];
                    this.currConn.RuleModify(currDb, currCube, tmpRfTarget.id, tmpRfSource.definition, tmpRfSource.extern_id, tmpRfSource.comment, tmpRfSource.activated);
                    this.currConn.RuleModify(currDb, currCube, tmpRfSource.id, tmpRfTarget.definition, tmpRfTarget.extern_id, tmpRfTarget.comment, tmpRfTarget.activated);
                    this.FillListBox();
                    this.lstRules.SelectedItems.Clear();
                    this.lstRules.Items[targetSelectedItem].Selected = true;
                    this.lstRules.Items[targetSelectedItem].Focused = true;
                    this.lstRules.Items[targetSelectedItem].EnsureVisible();
                }
            }
            catch { }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            this.domove(-1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            this.domove(1);
        }
        #endregion

        #region Rest
        private string FilterRuleText(string filterText)
        {
            string ret = filterText;
            return ret.Replace(GeneralConst.UNIX_NEWLINE, "").Replace("\r", "").Replace("\t", "");
        }

        private string FilterCommentText(string filterText)
        {
            return filterText.Replace(System.Environment.NewLine.ToString(), GeneralConst.UNIX_NEWLINE);
        }
        #endregion

        #region Export/Import

        private string ExportImportFilename(bool isexport)
        {
            string filename = "";
            FileDialog openFileDialog1 = null;

            try
            {
                if (isexport)
                {
                    openFileDialog1 = new SaveFileDialog();
                    openFileDialog1.FileName = "RuleExport_" + currCube;
                }
                else
                {
                    openFileDialog1 = new OpenFileDialog();
                }

                openFileDialog1.InitialDirectory = Utils.RegUtils.SavePath;
                openFileDialog1.Filter = ResourceInitializer.LABEL_CSV_FILTER;
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = false;


                if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
                {
                    filename = openFileDialog1.FileName;
                    string fn = FileHelper.getdirname(filename);
                    if (!String.IsNullOrEmpty(fn))
                    {
                        Utils.RegUtils.SavePath = fn;
                    }
                }
            }
            catch { }

            if (openFileDialog1 != null)
            {
                openFileDialog1.Dispose();
                openFileDialog1 = null;
            }

            return filename;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filename = ExportImportFilename(true);

            if (filename.Length > 0)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.UTF8);

                    currRuleInfoList = currConn.ListRules(currDb, currCube);

                    int i, length = currRuleInfoList.Length;

                    sw.WriteLine("################################################");
                    sw.WriteLine("## Palo Rule Editor Export");
                    sw.WriteLine("## v" + GeneralConst.VERSION);
                    sw.WriteLine("## Active;Definition;Comment;Extern ID;Timestamp");
                    sw.WriteLine("################################################");

                    for (i = 0; i < length; i++)
                    {
                        sw.WriteLine((currRuleInfoList[i].activated == false ? "#" : "") + currRuleInfoList[i].definition + ";" + currRuleInfoList[i].comment.Replace(';', ',').Replace(GeneralConst.UNIX_NEWLINE, "<br>") + ";" + currRuleInfoList[i].extern_id.Replace(';', ',') + ";" + currRuleInfoList[i].timestamp);
                    }

                    sw.Flush();
                    sw.Close();
                }
                catch (Exception exc)
                {
                    Utils.ErrorHandler.DisplayError("Error exporting rules", exc);
                }
                finally
                {
                    this.lblStatus.Text = ResourceInitializer.StatusRuleExportSuccess;
                    this.toolTip.SetToolTip(this.statusBar, ResourceInitializer.StatusRuleExportSuccess);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string filename = ExportImportFilename(false);

            if (filename.Length > 0)
            {
                try
                {
                    bool err = false;

                    ArrayList ruleslist = new ArrayList();
                    try
                    {
                        #region Parse rules
                        StreamReader sw = new StreamReader(filename, System.Text.Encoding.UTF8);
                        string tmpLine = "";
                        int cntLines = 0;

                        do
                        {
                            tmpLine = sw.ReadLine();
                            if (tmpLine == null)
                            {
                                break;
                            }

                            ++cntLines;

                            // if the line is empty or contains comment, i.e. not inactive rule then skip
                            if ((tmpLine.StartsWith("#") && !tmpLine.Substring(1, 1).Equals("[", StringComparison.InvariantCulture)) || tmpLine.Length == 0)
                            {
                                continue;
                            }

                            try
                            {
                                this.currConn.RuleParse(currDb, currCube, tmpLine.Substring((tmpLine.StartsWith("#") ? 1 : 0), tmpLine.IndexOf(';')));
                                ruleslist.Add(tmpLine);
                            }
                            catch (PaloException pcx)
                            {
                                this.lblStatus.Text = ResourceInitializer.Replace(ResourceInitializer.StatusRuleImportError, new object[] { cntLines.ToString(), ((tmpLine.Length > 40) ? tmpLine.Substring(0, 40) : tmpLine), ((pcx.PaloMessage.Length > 50) ? pcx.PaloMessage.Substring(0, 50) : pcx.PaloMessage) });
                                this.toolTip.SetToolTip(this.statusBar, "Error in rule #" + cntLines.ToString() + ". Rule: " + tmpLine + ". Server Message: " + pcx.PaloMessage);
                                err = true;
                                System.Windows.Forms.MessageBox.Show(this.lblStatus.Text);
                                break;
                            }

                        } while (tmpLine != null);
                        sw.Close();

                        #endregion

                        #region Display error
                        if (err == true)
                            return;
                        #endregion

                        #region Delete existing?
                        if (this.currRuleInfoList.Length > 0 && (MessageBox.Show(ResourceInitializer.QuestionDeleteExistingRules, ResourceInitializer.TitleRuleEditor, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
                        {
                            foreach (RuleInfo rule in this.currRuleInfoList)
                            {
                                try
                                {
                                    this.currConn.RuleDelete(currDb, currCube, rule.id);
                                }
                                catch (PaloException pec)
                                {
                                    Utils.ErrorHandler.DisplayError("Error deleting rule", pec);
                                }
                            }
                        }
                        #endregion

                        #region Actual import
                        int i, lcount = ruleslist.Count;

                        err = false;
                        bool rActive = true;
                        int tmpCorrection = 0;
                        string rDef = null;
                        string rComment = null;
                        string rExtID = null;

                        for (i = 0; i < lcount; i++)
                        {
                            tmpLine = ruleslist[i].ToString();
                            try
                            {
                                // make sure inactive rules are also supported
                                //tmpLine = tmpLine.Replace(';', ',');
                                rActive = (tmpLine.Substring(0, 1).Equals("#", StringComparison.InvariantCulture) ? false : true);
                                tmpCorrection = (rActive ? 0 : 1);
                                rDef = tmpLine.Substring(tmpCorrection, tmpLine.IndexOf(';') - tmpCorrection);
                                tmpLine = tmpLine.Substring(tmpCorrection + 1 + rDef.Length);
                                rComment = tmpLine.Substring(0, tmpLine.IndexOf(';'));
                                tmpLine = tmpLine.Substring(rComment.Length + 1);
                                rExtID = tmpLine.Substring(0, tmpLine.IndexOf(';'));
                                this.RuleCreate(currDb, currCube, rDef, rExtID, rComment.Replace("<br>", GeneralConst.UNIX_NEWLINE), rActive);
                            }
                            catch (PaloException pcx)
                            {
                                this.lblStatus.Text = ResourceInitializer.Replace(ResourceInitializer.StatusRuleImportError, new object[] { cntLines.ToString(), ((tmpLine.Length > 40) ? tmpLine.Substring(0, 40) : tmpLine), ((pcx.PaloMessage.Length > 50) ? pcx.PaloMessage.Substring(0, 50) : pcx.PaloMessage) });
                                this.toolTip.SetToolTip(this.statusBar, "Error in rule #" + cntLines.ToString() + ". Rule: " + tmpLine + ". Server Message: " + pcx.PaloMessage);
                                err = true;
                                break;
                            }
                        }
                        #endregion
                    }
                    catch (System.Exception exp)
                    {   
                        Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error Importing rule", exp);
                        System.Windows.Forms.MessageBox.Show(exp.Message);
                    }
                    if (err == false)
                    {
                        this.lblStatus.Text = ResourceInitializer.StatusRuleImportSuccess;
                        this.toolTip.SetToolTip(this.statusBar, ResourceInitializer.StatusRuleImportSuccess);
                    }
                }
                catch (Exception ecx)
                {
                    Utils.ErrorHandler.DisplayError("Error importing rule", ecx);
                }
                this.FillListBox();
            }
        }
        #endregion

        #region Advanced Rule Editor

        private void callreahlper(int index, bool isactive)
        {
            this.lstRules.Items[index].Selected = isactive;
            this.lstRules.Items[index].Focused = isactive;
        }

        private void callrea(bool newrule)
        {
            this.Cursor = Cursors.WaitCursor;
            int index = ((this.lstRules.SelectedIndices != null) && (this.lstRules.SelectedIndices.Count > 0)) ? (int)this.lstRules.SelectedIndices[0] : -1;

            try
            {
                if ((rea == null) || (rea.conn != currConn) || (rea.currDb != currDb) || (rea.currCube != currCube))
                {
                    rea = new RuleEditorAdvanced(currConn, currCube, currCubeType, currDb);
                }

                if (newrule)
                {
                    rea.TbRule = "[] = []";
                }
                else
                {
                    rea.TbRule = currRuleInfoList[index].definition;
                    rea.Comment = currRuleInfoList[index].comment.Replace(GeneralConst.UNIX_NEWLINE, System.Environment.NewLine.ToString());
                }
                rea.InitRule();

                string errorMsg = "";
                DialogResult dr;

                do
                {
                    try
                    {
                        rea.SetError(errorMsg);
                        errorMsg = "";
                        dr = rea.ShowDialog();
                        this.Cursor = Cursors.Default;

                        if (dr == DialogResult.Cancel)
                        {
                            return;
                        }
                        else
                        {
                            if (newrule)
                            {
                                this.RuleCreate(currDb, currCube, rea.TbRule, "", rea.Comment, true);
                            }
                            else
                            {
                                this.RuleModify(currDb, currCube, this.currRuleInfoList[index].id, FilterRuleText(rea.TbRule), this.currRuleInfoList[index].extern_id, FilterCommentText(rea.Comment), this.currRuleInfoList[index].activated);
                            }
                        }
                    }
                    catch (PaloException pexc)
                    {
                        errorMsg = pexc.Message;
                        lblStatus.Text = pexc.Message;
                        MessageBox.Show(Utils.ResourceInitializer.LabelRuleError + pexc.Message, Utils.ResourceInitializer.TitleRuleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } while (!String.IsNullOrEmpty(errorMsg));
                this.FillListBox();
                if (this.lstRules.Items.Count > 0)
                {
                    index = (newrule) ? this.lstRules.Items.Count - 1 : index;
                    callreahlper(0, false);
                    callreahlper(index, true);
                    this.lstRules.Items[index].EnsureVisible();
                }
                lblStatus.Text = errorMsg;
            }
            catch (Exception exc)
            {
                Apalo.XlAddin.Utils.ErrorHandler.DisplayError("open advanced rule editor.", exc);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            callrea(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            callrea(true);
        }

        #endregion

        #region Header Size
        private void lstRules_SizeChanged(object sender, EventArgs e)
        {
            chRule.Width = (int)(lstRules.Width / columnRatio1);
            chComment.Width = (int)(lstRules.Width / columnRatio2);
            chUpdated.Width = (int)(lstRules.Width / columnRatio3);
        }

        private void lstRules_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            SetUDRegData(REKCOLUMNRATIO1, (lstRules.Width / (chRule.Width > 0 ? chRule.Width : 1.0)).ToString());
            SetUDRegData(REKCOLUMNRATIO2, (lstRules.Width / (chComment.Width > 0 ? chComment.Width : 1.0)).ToString());
            SetUDRegData(REKCOLUMNRATIO3, (lstRules.Width / (chUpdated.Width > 0 ? chUpdated.Width : 1.0)).ToString());
        }
        #endregion


        #region MouseUp/Click/DoubleClick
        private void lstRules_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                mnuRuleActions.Show(new Point(this.Left + e.X + 10, this.Top + e.Y + 50));
            }
        }

        private void mnuRuleActions_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                bool dofill = true;
                ToolStripItem tsi = e.ClickedItem;
                if (tsi == cmdInfo)
                {
                    if ((this.lstRules == null) || (this.lstRules.Items.Count == 0))
                    {
                        return;
                    }

                    InformationDialog iDlg = new InformationDialog();
                    iDlg.l1 = "ID";
                    iDlg.v1 = currRule.id.ToString();
                    iDlg.l2 = "Active";
                    iDlg.v2 = currRule.activated.ToString();
                    iDlg.l3 = lblRule.Text;
                    iDlg.v3 = currRule.definition;
                    iDlg.l4 = lblComment.Text;
                    iDlg.v4 = currRule.comment;
                    iDlg.l5 = "External ID";
                    iDlg.v5 = currRule.extern_id.ToString();
                    iDlg.l6 = "Timestamp";
                    iDlg.v6 = FormatTimestamp(currRule.timestamp);
                    iDlg.ShowDialog(true);
                    iDlg.Dispose();
                    iDlg = null;
                }
                else if (tsi == cmdUp)
                {
                    btnUp.PerformClick();
                }
                else if (tsi == cmdDown)
                {
                    btnDown.PerformClick();
                }
                else if (tsi == cmdEdit)
                {
                    btnEdit.PerformClick();
                }
                else if (tsi == cmdNew)
                {
                    btnNew.PerformClick();
                }
                else if (tsi == cmdDelete)
                {
                    if ((this.lstRules == null) || (this.lstRules.Items.Count == 0))
                    {
                        return;
                    }

                    btnDelete.PerformClick();
                }
                else if (tsi == cmdChangeStatus)
                {

                    if (lstRules.SelectedIndices != null && lstRules.SelectedIndices.Count > 0)
                    {
                        int i, index = -1, scount = lstRules.SelectedIndices.Count;

                        try
                        {
                            for(i=0; i < scount; i++)
                            {
                                index = lstRules.SelectedIndices[i];
                                if (index > -1)
                                {
                                    this.RuleModify(currDb, currCube, currRuleInfoList[index].id, currRuleInfoList[index].definition, currRuleInfoList[index].extern_id, currRuleInfoList[index].comment, !currRuleInfoList[index].activated);
                                    currRuleInfoList[index].activated = !currRuleInfoList[index].activated;
                                    lstRules.Items[index].ForeColor = GetColor(index);
                                }
                            }
                        }
                        catch (PaloException pe)
                        {
                            if (pe.ErrorCode == 8001)
                            {
                                if (index > -1)
                                {
                                    ArrayList sindeces = new ArrayList(lstRules.SelectedIndices);
                                    int index2, acount= sindeces.Count;
                                    for (i = 0; i < acount; i++)
                                    {
                                        index2 = (int)sindeces[i];
                                        if (index != index2)
                                        {
                                            lstRules.Items[index2].Selected = false;
                                        }
                                    }
                                    lstRules.Items[index].Focused = true;
                                    lstRules.Items[index].Selected = true;
                                    lstRules.Items[index].EnsureVisible();
                                }
                            }
                            else
                            {
                                ErrorHandler.DisplayError("Error modifying active state of rule", pe);
                            }
                            lblStatus.Text = pe.Message;
                            dofill = false;
                        }
                    }
                }

                mnuRuleActions.Close(ToolStripDropDownCloseReason.ItemClicked);
                if (dofill)
                {
                    FillListBox();
                }
            }
            catch { }
        }

        private void lstRules_DoubleClick(object sender, EventArgs e)
        {
            btnEdit.PerformClick();
        }
        #endregion

        #region Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string errorMsg = "";
                int tmpSelectedItem = -1;
                if (currDb != null
                    && currCube != null
                    && txtRule.Text != null
                    && txtRule.Text.Length != 0
                    && txtComment.Text != null
                    && lstRules.SelectedItems.Count == 1)
                    try
                    {
                        tmpSelectedItem = lstRules.SelectedIndices[0];
                        this.RuleModify(currDb, currCube, currRule.id, FilterRuleText(txtRule.Text), "", FilterCommentText(txtComment.Text), currRule.activated);
                    }
                    catch (PaloException pexc)
                    {
                        errorMsg = pexc.Message;
                    }
                this.FillListBox();
                this.lstRules.SelectedItems.Clear();
                this.lstRules.Items[tmpSelectedItem].Selected = true;
                this.lstRules.Items[tmpSelectedItem].Focused = true;
                this.lstRules.Items[tmpSelectedItem].EnsureVisible();

                lblStatus.Text = errorMsg;
            }
            catch { }
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = (currRule.definition != null && ((txtComment.Text.Length != 0 && currRule.comment != txtComment.Text) || (txtRule.Text.Length != 0 && currRule.definition != txtRule.Text)));
        }

        private void txtRule_TextChanged(object sender, EventArgs e)
        {
            if (lstRules.SelectedItems.Count == 1 && currRule.definition != null && ((txtRule.Text.Length != 0 && currRule.definition != txtRule.Text) || currRule.comment != txtComment.Text))
                btnUpdate.Enabled = true;
            else
                btnUpdate.Enabled = false;
        }
        #endregion
    }
}