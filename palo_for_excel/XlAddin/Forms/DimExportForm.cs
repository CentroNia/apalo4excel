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
//  JMM 09-17-13 replaced Node with JNode to correct Tag/Key definition
//  JMM 09-17-13 Various changes for 5.0 library compatability

using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Win32;
using JControls;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
    public partial class DimExportForm : WizardDialogForm
    {

        const int NORM_HEIGHT = 424;
        const int FINISH_HEIGHT = 210;

        #region Define vars

        private const string DIMEXPORTFORM = "DimExportForm";

        private string ActiveDB; // like dbN in CubeWizard
        private string ActiveDim;
        private string ActiveHostname;
        private ArrayList SelectedElements = new ArrayList();

        private Hashtable dimelems = new Hashtable(); // to identify children
        private int serialNumber; // serial number for parent-child-relation in one row.

        private string CsvFileToWrite;
        private ImportCore impcore = null;
        private bool finishing = false;
        private Font regularFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

        private Jedox.Palo.Comm.Connection currConn;

        private static string m_sFileName;
        private static string m_sOldDim;
        private static char m_cSeparator = '\t';
        private static bool m_bOneRow = true;

        public string CubeName
        {
            get
            {
                return this.comboBoxFile.Text;
            }
        }

        private System.Windows.Forms.ToolTip toolTip;
        private Label labelCaption;
        private Label labelSelect;
        private RadioButton radioTab;
        private RadioButton radioComma;
        private RadioButton radioSemicolon;
        private RadioButton radioBlank;
        private RadioButton radioUserdefined;
        private TextBox textBox1;
        private ComboBox comboBoxFile;
        private Button btnBrowse;
    
        private Label labelOutputFormat;
        private Label labelSeparator;
        private ComboBox comboBoxHierarchy;
        private System.ComponentModel.IContainer components;

        #endregion

        #region Construct / Destruct

        public DimExportForm(CultureInfo originalUICulture, string hostname, string dbN, string dimName)
        {
            #region Init

            InitializeComponent();
            this.wizardTabControl1.SelectTab(0);
            base.SetBtns((TabPageStep)this.wizardTabControl1.SelectedTab);
            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.pnlBottom.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PanelContenerTabs.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.labelCaption.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.labelSelect.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnBrowse.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.labelSeparator.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioTab.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioComma.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioSemicolon.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioBlank.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioUserdefined.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.labelOutputFormat.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnBack.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnNext.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnFinish.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;

            this.ActiveDim = dimName;
            this.ActiveDB = dbN;
            this.ActiveHostname = hostname;

            this.currConn = Apalo.XlAddin.Connections.GetConnection(hostname);
            this.impcore = new ImportCore(originalUICulture, null, this);
            this.impcore.Terminating += new PaloThread(make_exit);

            try
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\Jedox\Palo\XlAddin\MRU\CSV2");
                int valCnt = (int)regKey.ValueCount;
                this.comboBoxFile.Items.Clear();
                for (int i = 0; i <= valCnt; i++)
                {
                    string s = (string)regKey.GetValue("url" + i.ToString());
                    if (s != null)
                    {
                        this.comboBoxFile.Items.Add(s);
                    }
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error getting Registry Values.", exc);
            }

            this.LeftPanelImage = ResourceInitializer.WizardLogo;

            this.comboBoxHierarchy.Items.Add(ResourceInitializer.LabelDimExportNCFormat);
            this.comboBoxHierarchy.Items.Add(ResourceInitializer.LabelDimExportOneRow);
            this.comboBoxHierarchy.SelectedIndex = 0;
            this.labelCaption.Text = ResourceInitializer.LabelDimExportCaption;
            this.labelSelect.Text = ResourceInitializer.LABEL_EXPORT_PAGE2_2;
            this.labelSeparator.Text = ResourceInitializer.LabelDimExportSeparator;
            this.labelOutputFormat.Text = ResourceInitializer.LabelDimExportHierarchy;
            this.TitleLabel = ResourceInitializer.TITLE_EXPORT_DIMENSION;

            this.radioTab.Text = ResourceInitializer.LABEL_OPTION_TAB;
            this.radioComma.Text = ResourceInitializer.LABEL_OPTION_COMMA;
            this.radioSemicolon.Text = ResourceInitializer.LABEL_OPTION_SEMICOLON;
            this.radioBlank.Text = ResourceInitializer.LABEL_OPTION_BLANK;
            this.radioUserdefined.Text = ResourceInitializer.LABEL_OPTION_USERDEFINED;
            //this.toolTip.SetToolTip(this.comboBoxFile, ResourceInitializer.TIP_BUTTON_MOVE_UP_DIMENSION);
            this.btnBrowse.Text = ResourceInitializer.BUTTON_BROWSE;
            this.btnFinish.Text = ResourceInitializer.BUTTON_FINISH;
            //this.toolTip.SetToolTip(this.btnFinish, ResourceInitializer.TIP_BUTTON_OK_CUBE_WIZARD);
            this.btnNext.Text = ResourceInitializer.BUTTON_CANCEL;
            //this.toolTip.SetToolTip(this.btnCancel, ResourceInitializer.TIP_BUTTON_CLOSE_WIZARD);
            this.Text = ResourceInitializer.TITLE_EXPORT_DIMENSION;

            int[] tmpProps = RegUtils.GetFormProperties(DIMEXPORTFORM);
            if (tmpProps[0] != -1)
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                //this.Size = new System.Drawing.Size(tmpProps[2], tmpProps[3]);
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
            }
            else
            {
                //this.Size = new System.Drawing.Size(773, NORM_HEIGHT);
                this.StartPosition = FormStartPosition.CenterScreen;
            }

            if (!String.IsNullOrEmpty(m_sOldDim) && !String.IsNullOrEmpty(m_sFileName))
            {
                string sOldFileName = m_sFileName;
                string sEndung = ".txt";
                if (sOldFileName.EndsWith(".csv"))
                {
                    sEndung = ".csv";
                }

                int iN = sOldFileName.LastIndexOf('\\');
                if (iN != -1)
                {
                    m_sFileName = sOldFileName.Substring(0, iN + 1) + this.ActiveDim + sEndung;

                    if (!this.comboBoxFile.Items.Contains(m_sFileName))
                    {
                        this.comboBoxFile.Items.Add(m_sFileName);
                    }
                    this.comboBoxFile.SelectedItem = m_sFileName;
                }
            }
            else
            {
                m_sFileName = RegUtils.SavePath + this.ActiveDim + ".txt";

                if (!this.comboBoxFile.Items.Contains(m_sFileName))
                {
                    this.comboBoxFile.Items.Add(m_sFileName);
                }
                this.comboBoxFile.SelectedItem = m_sFileName;
            }

            switch (m_cSeparator)
            {
                case '\t':
                    radioTab.Checked = true;
                    break;
                case ',':
                    radioComma.Checked = true;
                    break;
                case ';':
                    radioSemicolon.Checked = true;
                    break;
                case ' ':
                    radioBlank.Checked = true;
                    break;
                default:
                    radioUserdefined.Checked = true;
                    textBox1.Text = m_cSeparator.ToString();
                    break;
            }

            if (m_bOneRow)
            {
                comboBoxHierarchy.SelectedIndex = 0;
            }
            else
            {
                comboBoxHierarchy.SelectedIndex = 1;
            }


            #endregion

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DimExportForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelCaption = new System.Windows.Forms.Label();
            this.labelSelect = new System.Windows.Forms.Label();
            this.radioTab = new System.Windows.Forms.RadioButton();
            this.radioComma = new System.Windows.Forms.RadioButton();
            this.radioSemicolon = new System.Windows.Forms.RadioButton();
            this.radioBlank = new System.Windows.Forms.RadioButton();
            this.radioUserdefined = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxFile = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.labelOutputFormat = new System.Windows.Forms.Label();
            this.labelSeparator = new System.Windows.Forms.Label();
            this.comboBoxHierarchy = new System.Windows.Forms.ComboBox();
            this.pnlBottom.SuspendLayout();
            this.PanelContenerTabs.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinish.Enabled = false;
            this.btnFinish.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnFinish.Location = new System.Drawing.Point(338, 3);
            this.btnFinish.Size = new System.Drawing.Size(97, 23);
            this.btnFinish.TabIndex = 101;
            this.btnFinish.Text = "btnFinish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBack.Location = new System.Drawing.Point(28, 7);
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNext.Location = new System.Drawing.Point(233, 3);
            this.btnNext.Size = new System.Drawing.Size(99, 23);
            this.btnNext.TabIndex = 100;
            this.btnNext.Text = "btnCancel";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PanelContenerTabs
            // 
            this.PanelContenerTabs.BackColor = System.Drawing.SystemColors.Control;
            // 
            // tabPageStep1
            // 
            this.tabPageStep1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep1.Controls.Add(this.comboBoxHierarchy);
            this.tabPageStep1.Controls.Add(this.labelSeparator);
            this.tabPageStep1.Controls.Add(this.labelOutputFormat);
            this.tabPageStep1.Controls.Add(this.btnBrowse);
            this.tabPageStep1.Controls.Add(this.comboBoxFile);
            this.tabPageStep1.Controls.Add(this.textBox1);
            this.tabPageStep1.Controls.Add(this.radioUserdefined);
            this.tabPageStep1.Controls.Add(this.radioBlank);
            this.tabPageStep1.Controls.Add(this.radioSemicolon);
            this.tabPageStep1.Controls.Add(this.radioComma);
            this.tabPageStep1.Controls.Add(this.radioTab);
            this.tabPageStep1.Controls.Add(this.labelSelect);
            this.tabPageStep1.Controls.Add(this.labelCaption);
            this.tabPageStep1.ShowBackButton = false;
            // 
            // labelCaption
            // 
            this.labelCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaption.Location = new System.Drawing.Point(15, 14);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(416, 32);
            this.labelCaption.TabIndex = 3;
            this.labelCaption.Text = "labelCaption";
            // 
            // labelSelect
            // 
            this.labelSelect.AutoSize = true;
            this.labelSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelect.Location = new System.Drawing.Point(24, 46);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(70, 13);
            this.labelSelect.TabIndex = 4;
            this.labelSelect.Text = "labelSelect";
            // 
            // radioTab
            // 
            this.radioTab.AutoSize = true;
            this.radioTab.Checked = true;
            this.radioTab.Enabled = false;
            this.radioTab.Location = new System.Drawing.Point(41, 145);
            this.radioTab.Name = "radioTab";
            this.radioTab.Size = new System.Drawing.Size(67, 17);
            this.radioTab.TabIndex = 12;
            this.radioTab.TabStop = true;
            this.radioTab.Text = "radioTab";
            this.radioTab.UseVisualStyleBackColor = true;
            // 
            // radioComma
            // 
            this.radioComma.AutoSize = true;
            this.radioComma.Enabled = false;
            this.radioComma.Location = new System.Drawing.Point(41, 168);
            this.radioComma.Name = "radioComma";
            this.radioComma.Size = new System.Drawing.Size(83, 17);
            this.radioComma.TabIndex = 13;
            this.radioComma.Text = "radioComma";
            this.radioComma.UseVisualStyleBackColor = true;
            // 
            // radioSemicolon
            // 
            this.radioSemicolon.AutoSize = true;
            this.radioSemicolon.Enabled = false;
            this.radioSemicolon.Location = new System.Drawing.Point(41, 191);
            this.radioSemicolon.Name = "radioSemicolon";
            this.radioSemicolon.Size = new System.Drawing.Size(97, 17);
            this.radioSemicolon.TabIndex = 14;
            this.radioSemicolon.Text = "radioSemicolon";
            this.radioSemicolon.UseVisualStyleBackColor = true;
            // 
            // radioBlank
            // 
            this.radioBlank.AutoSize = true;
            this.radioBlank.Enabled = false;
            this.radioBlank.Location = new System.Drawing.Point(174, 145);
            this.radioBlank.Name = "radioBlank";
            this.radioBlank.Size = new System.Drawing.Size(75, 17);
            this.radioBlank.TabIndex = 15;
            this.radioBlank.Text = "radioBlank";
            this.radioBlank.UseVisualStyleBackColor = true;
            // 
            // radioUserdefined
            // 
            this.radioUserdefined.AutoSize = true;
            this.radioUserdefined.Enabled = false;
            this.radioUserdefined.Location = new System.Drawing.Point(174, 168);
            this.radioUserdefined.Name = "radioUserdefined";
            this.radioUserdefined.Size = new System.Drawing.Size(105, 17);
            this.radioUserdefined.TabIndex = 16;
            this.radioUserdefined.Text = "radioUserdefined";
            this.radioUserdefined.UseVisualStyleBackColor = true;
            this.radioUserdefined.CheckedChanged += new System.EventHandler(this.radioUserdefined_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(194, 191);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBoxFile
            // 
            this.comboBoxFile.FormattingEnabled = true;
            this.comboBoxFile.Location = new System.Drawing.Point(41, 74);
            this.comboBoxFile.Name = "comboBoxFile";
            this.comboBoxFile.Size = new System.Drawing.Size(254, 21);
            this.comboBoxFile.TabIndex = 10;
            this.comboBoxFile.SelectedIndexChanged += new System.EventHandler(this.comboBoxFile_SelectedIndexChanged);
            this.comboBoxFile.TextChanged += new System.EventHandler(this.comboBoxFile_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Location = new System.Drawing.Point(332, 72);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(99, 23);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // labelOutputFormat
            // 
            this.labelOutputFormat.AutoSize = true;
            this.labelOutputFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutputFormat.Location = new System.Drawing.Point(38, 218);
            this.labelOutputFormat.Name = "labelOutputFormat";
            this.labelOutputFormat.Size = new System.Drawing.Size(110, 13);
            this.labelOutputFormat.TabIndex = 6;
            this.labelOutputFormat.Text = "labelOutputFormat";
            // 
            // labelSeparator
            // 
            this.labelSeparator.AutoSize = true;
            this.labelSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeparator.Location = new System.Drawing.Point(24, 117);
            this.labelSeparator.Name = "labelSeparator";
            this.labelSeparator.Size = new System.Drawing.Size(89, 13);
            this.labelSeparator.TabIndex = 5;
            this.labelSeparator.Text = "labelSeparator";
            // 
            // comboBoxHierarchy
            // 
            this.comboBoxHierarchy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHierarchy.Enabled = false;
            this.comboBoxHierarchy.FormattingEnabled = true;
            this.comboBoxHierarchy.Location = new System.Drawing.Point(41, 238);
            this.comboBoxHierarchy.Name = "comboBoxHierarchy";
            this.comboBoxHierarchy.Size = new System.Drawing.Size(254, 21);
            this.comboBoxHierarchy.TabIndex = 18;
            // 
            // DimExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnNext;
            this.ClientSize = new System.Drawing.Size(618, 395);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DimExportForm";
            this.Tag = "";
            this.Load += new System.EventHandler(this.frmDimExport_Load);
            this.VisibleChanged += new System.EventHandler(this.DimExportForm_VisibleChanged);
            this.pnlBottom.ResumeLayout(false);
            this.PanelContenerTabs.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.tabPageStep1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// get the tag of a dimension element type
        /// </summary>
        /// <param Name="dimElType">dimension element type</param>
        /// <returns>the tag</returns>
        public string TagOfDimElementType(Jedox.Palo.Comm.DimElementType dimElType)
        {
            switch (dimElType)
            {
                case Jedox.Palo.Comm.DimElementType.DimElementTypeNumeric:
                    return "N";
                case Jedox.Palo.Comm.DimElementType.DimElementTypeString:
                    return "S";
                case Jedox.Palo.Comm.DimElementType.DimElementTypeConsolidated:
                    return "C";
                case Jedox.Palo.Comm.DimElementType.DimElementTypeRule:
                    return "R";
                default:
                    return "N";
            }
        }

        #region Button Actions

        /// <summary>
        /// Finish dialog
        /// </summary>
        /// <param Name="sender">sender</param>
        /// <param Name="e">event arguments</param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                Jedox.Palo.Comm.Connection c = this.currConn;
                this.StartDsDim();
                this.dimelems.Clear(); // Clear Hashtable

                Jedox.Palo.Comm.ElementInfo dimDimElem;

                ExcelHelper.SetExcelStatusbar(ResourceInitializer.Replace(ResourceInitializer.STATUS_READING_ELEMENTS_SERVER, new object[] { this.ActiveHostname }));
                
                Jedox.Palo.Comm.ElementInfo[] dimDimElems = c.DimensionListElements(this.ActiveDB, this.ActiveDim);

                ExcelHelper.ResetExcelStatusbar();

                int i, dsize = dimDimElems.Length;
                bool bDataFound = (dsize > 0);

                if (this.comboBoxHierarchy.SelectedIndex == 0) // N-C-format (Alea, TM1)
                {
                    m_bOneRow = false;
                    uint level, maxlevel_1 = (uint)c.DimensionInformationSimple(this.ActiveDB, this.ActiveDim).MaximumLevel + 1 ;
                    ArrayList[] levels = new ArrayList[maxlevel_1];
                    ArrayList alevel;

                    for (level = 0; level < maxlevel_1; level++)
                    {
                        levels[level] = new ArrayList();
                    }

                    for (i = 0; i < dsize; i++)
                    {
                        dimDimElem = dimDimElems[i];
                        this.dimelems[dimDimElem.Identifier] = dimDimElem; // Fill Hashtable
                        level = (uint)dimDimElem.Level;
                        levels[level].Add(dimDimElem.Identifier);
                    }

                    dimDimElems = null;

                    int j, csize;

                    for (level = 0; level < maxlevel_1; level++) // consider all elements.
                    {
                        ExcelHelper.SetExcelStatusbar("level " + level.ToString());
                        alevel = levels[level];
                        dsize = alevel.Count;
                        for (i = 0; i < dsize; i++)
                        {
                            dimDimElem = (Jedox.Palo.Comm.ElementInfo)this.dimelems[alevel[i]];
                            if (!impcore.insertDimRowCsv(new string[] { TagOfDimElementType(dimDimElem.Type), dimDimElem.Name, "" }))
                            {
                                break;
                            }

                            csize = dimDimElem.Children.Length;

                            for (j = 0; j < csize; j++)
                            {
                                if (!impcore.insertDimRowCsv(new string[] { "", ((Jedox.Palo.Comm.ElementInfo)this.dimelems[dimDimElem.Children[j].Identifier]).Name, dimDimElem.Children[j].Factor.ToString() }))
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else // Parent-child-relation in one row
                {
                    m_bOneRow = true;
                    serialNumber = 0;
                    ArrayList tops = new ArrayList();

                    for (i = 0; i < dsize; i++)
                    {
                        dimDimElem = dimDimElems[i];
                        this.dimelems[dimDimElem.Identifier] = dimDimElem; // Fill Hashtable
                        if (dimDimElem.Parents.Length == 0)
                        {
                            tops.Add(dimDimElem.Identifier);
                        }
                    }

                    dimDimElems = null;

                    dsize = tops.Count;

                    for (i = 0; i < dsize; i++)
                    {
                        ExcelHelper.SetExcelStatusbar("Top " + i.ToString());
                        dimDimElem = (Jedox.Palo.Comm.ElementInfo)this.dimelems[tops[i]];
                        ++serialNumber;
                        if (!impcore.insertDimRowCsv(new string[] { serialNumber.ToString(), TagOfDimElementType(dimDimElem.Type), dimDimElem.Name, "", "" }))
                        {
                            break;
                        }
                        // Write his children
                        this.writeChildren(dimDimElem, serialNumber);
                    }
                }

                if (!bDataFound)
                {
                    MessageBox.Show(ResourceInitializer.ERROR_DATA_NOT_FOUND, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error finishing Export!", exc);
            }

            ExcelHelper.ResetExcelStatusbar();
            this.DialogResult = DialogResult.OK;
            this.impcore.clean_up();
            this.finishing = true;
            m_sOldDim = this.ActiveDim;
            m_sFileName = this.comboBoxFile.Text as string;
        }

        /// <summary>
        /// Write the children and their children and so on
        /// </summary>
        /// <param Name="dimDimElem">parent</param>
        private void writeChildren(Jedox.Palo.Comm.ElementInfo dimDimElem, int serialNum)
        {
            Jedox.Palo.Comm.ElementInfo childdimDimElem;

            try
            {
                int csize = dimDimElem.Children.Length;
                if (csize > 0)
                {
                    for (int i = 0; i < csize; i++)
                    {
                        childdimDimElem = (Jedox.Palo.Comm.ElementInfo)this.dimelems[dimDimElem.Children[i].Identifier];
                        ++serialNumber;
                        // Write child
                        if (!impcore.insertDimRowCsv(new string[] { serialNumber.ToString(), TagOfDimElementType(childdimDimElem.Type), childdimDimElem.Name, serialNum.ToString(), dimDimElem.Children[i].Factor.ToString() }))
                        {
                            break;
                        }
                        if (childdimDimElem.Children.Length > 0)
                        {
                            // Write children of child
                            this.writeChildren(childdimDimElem, serialNumber);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error writing children!", exc);
            }
        }

        #endregion

        #region Dims

        private void setDimensionList(Jedox.Palo.Comm.Connection c, string database)
        {
            c.Ping();

            string[] dbDims = c.DatabaseListDimensions(database, Jedox.Palo.Comm.DimensionType.NormalDimension);

            foreach (string Dim in dbDims)
            {
                JNode tN = new JNode(Dim);
                tN.NodeFont = this.regularFont;
            }
        }

        #endregion

        #region OnLoad
        /// <summary>
        /// Load form for dimension export
        /// </summary>
        /// <param Name="sender">sender</param>
        /// <param Name="e">event arguments</param>
        private void frmDimExport_Load(object sender, System.EventArgs e)
        {
            this.setDimensionList(this.currConn, this.ActiveDB);
        }


        #endregion

        #region Button events
        /// <summary>
        /// Click of cancel button
        /// </summary>
        /// <param Name="sender">sender</param>
        /// <param Name="e">event arguments</param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.impcore.Terminate();
            if (!this.finishing) this.do_exit();
        }

        /// <summary>
        /// reaction to change of "userdefined"-radiobutton
        /// </summary>
        /// <param Name="sender">sender</param>
        /// <param Name="e">event arguments</param>
        private void radioUserdefined_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox1.Enabled = this.radioUserdefined.Checked;
            this.checknext2();
        }

        /// <summary>
        /// Browse for file Name and directory
        /// </summary>
        /// <param Name="sender">sender</param>
        /// <param Name="e">event arguments</param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = RegUtils.SavePath;
            saveFileDialog1.Filter = ResourceInitializer.LABEL_CSV_FILTER;
            saveFileDialog1.RestoreDirectory = false;

            string sEndung = ".txt";
            saveFileDialog1.FilterIndex = 1;
            if (m_sFileName.EndsWith(".csv"))
            {
                sEndung = ".csv";
                saveFileDialog1.FilterIndex = 2;
            }
            saveFileDialog1.FileName = this.ActiveDim + sEndung;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                string fn = FileHelper.getdirname((string)saveFileDialog1.FileName);
                if (!String.IsNullOrEmpty(fn))
                {
                    RegUtils.SavePath = fn;
                }
                this.CsvFileToWrite = (string)saveFileDialog1.FileName;
                /*
                try
                {
                    if(System.IO.File.Exists(this.CsvFileToWrite))
                        System.IO.File.Delete(this.CsvFileToWrite);
                }
                catch(Exception exc)
                {
                    ErrorHandler.DisplayError("Error Deleting file.", exc);
                }
                */


                #region Combo/Registry

                /*
				 * If not found in combo add it to both combo and registry
				*/
                int i = 0;
                foreach (string itm in this.comboBoxFile.Items)
                {
                    if (itm == this.CsvFileToWrite)
                        i++;
                }

                if (i == 0)
                {
                    this.comboBoxFile.Items.Add(this.CsvFileToWrite);
                    RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\Jedox\Palo\XlAddin\MRU\CSV2");
                    int valCnt = (int)regKey.ValueCount;
                    valCnt++;
                    if (valCnt > 10) valCnt = 1;
                    regKey.SetValue("url" + valCnt, (string)saveFileDialog1.FileName);
                    regKey.Close();
                }

                #endregion

                this.comboBoxFile.Text = this.CsvFileToWrite;
                this.btnFinish.Enabled = true;
            }
            saveFileDialog1.Dispose();
            this.checknext_csv();

        }

        /// <summary>
        /// enable/disable dialog elements
        /// </summary>
        private void checknext_csv()
        {
            bool enabled = false;
            if (this.comboBoxFile.Text != "")
            {
                enabled = true;
            }

            this.radioTab.Enabled = enabled;
            this.radioComma.Enabled = enabled;
            this.radioSemicolon.Enabled = enabled;
            this.radioBlank.Enabled = enabled;
            this.radioUserdefined.Enabled = enabled;
            this.textBox1.Enabled = enabled && this.radioUserdefined.Checked;
            this.comboBoxHierarchy.Enabled = enabled;

            this.checknext2();
        }

        /// <summary>
        /// enable/disable finish button
        /// </summary>
        private void checknext2()
        {
            if ((this.comboBoxFile.Text.Length == 0) || (this.radioUserdefined.Checked && (this.textBox1.Text.Length == 0)))
            {
                this.btnFinish.Enabled = false;
            }
            else
            {
                this.btnFinish.Enabled = true;
            }
        }

        /// <summary>
        /// reaction to change of textBox1
        /// </summary>
        /// <param Name="sender">sender</param>
        /// <param Name="e">event arguments</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.checknext_csv();
        }

        /// <summary>
        /// reaction to change of comboBoxFile-selection
        /// </summary>
        /// <param Name="sender">sender</param>
        /// <param Name="e">event arguments</param>
        private void comboBoxFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.checknext_csv();
        }

        /// <summary>
        /// reaction to change of comboBoxFile-text
        /// </summary>
        /// <param Name="sender">sender</param>
        /// <param Name="e">event arguments</param>
        private void comboBoxFile_TextChanged(object sender, EventArgs e)
        {
            this.checknext_csv();
        }

        #endregion

        /// <summary>
        /// Set parameters for dimension export, as StartDsCube() in ExportWizard
        /// </summary>
        private void StartDsDim()
        {
            try
            {
                //char separator = ' ';
                if (this.radioTab.Checked == true)
                {
                    m_cSeparator = '\t';
                }
                else if (this.radioComma.Checked == true)
                {
                    m_cSeparator = ',';
                }
                else if (this.radioSemicolon.Checked == true)
                {
                    m_cSeparator = ';';
                }
                else if (this.radioBlank.Checked == true)
                {
                    m_cSeparator = ' ';
                }
                else if (this.radioUserdefined.Checked == true)
                {
                    char[] tmp = this.textBox1.Text.ToCharArray();
                    m_cSeparator = tmp[0];
                }

                string decpoint = ".";
                this.impcore.set_csv_params(this.comboBoxFile.Text, false, m_cSeparator, decpoint, false, 0, true);

                #region header
                // Insert header comment:
                this.impcore.insertDimRowCsv(new String[] { "################################################" });
                this.impcore.insertDimRowCsv(new String[] { "## Palo Dimension Export" });
                this.impcore.insertDimRowCsv(new String[] { "## v" + GeneralConst.VERSION });
                this.impcore.insertDimRowCsv(new String[] { "## Comment: " });
                this.impcore.insertDimRowCsv(new String[] { "################################################" });

                #endregion

            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
                ErrorHandler.DisplayError("Error filling dimension data!", exc);
            }
        }

        /// <summary>
        /// exit, as in ExportWizard
        /// </summary>
        /// <param Name="sender">sender</param>
        private void make_exit(object sender)
        {
            this.do_exit();
        }

        /// <summary>
        /// Do exit, as in ExportWizard
        /// </summary>
        public void do_exit()
        {
            this.finishing = false;
            //this.OldnewLineIndex = this.NewLineArt.SelectedIndex;

            ExcelHelper.ResetExcelStatusbar();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void DimExportForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == false)
            {
                RegUtils.SetFormProperties(DIMEXPORTFORM, new int[4] { this.Left, this.Top, this.Width, this.Height });
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            }
        }
    }
}
