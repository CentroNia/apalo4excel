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
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using JControls;
using Apalo.XlAddin.Utils;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Globalization;
using System.Collections;
using Microsoft.Win32;

namespace Apalo.XlAddin.Forms
{
    [ComVisible(false)]
    public  class ExportWizard : WizardDialogForm
    {
        const int NORM_HEIGHT = 421;
        const int FINISH_HEIGHT = 210;

        private System.ComponentModel.IContainer components = null;

        private Panel panel1;
        private TabPageStep tabPageStep2;
        private TabPageStep tabPageStep3;
        private TabPageStep tabPageStep4;

        private string fileElements = RegUtils.SavePath + "\\elements.bin";

        private int entryTabIndex = 100;
        private int OldnewLineIndex;

        private Jedox.Palo.Comm.Connection currConn;

        private string ActiveDB;
        private string ActiveCube;
        private string ActiveHostname;

        private ArrayList SelectedElements = new ArrayList();

        private string CsvFileToWrite;
        private ImportCore impcore = null;
        private bool finishing = false;
        private bool show_no_data_mesg = true;
        private Thread t = null;
        private int nextpage = 0;
        private string decpointtext;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button xpBrowse;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;

        private System.Windows.Forms.ProgressBar ImportProgress;

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBoxEx1;

        private System.Windows.Forms.CheckBox Append2csv;
        private CheckBox BoxUseRule;
        private ComboBox NewLineArt;
        private Label LabelNewline;

        private CheckBox checkBoxHeader;

        public ExportWizard(string decpoint, CultureInfo originalUICulture, string hostname, string dbN, string cubeName)
		{
			InitializeComponent();
            this.wizardTabControl1.SelectTab(0);
            base.SetBtns((TabPageStep)this.wizardTabControl1.SelectedTab);
            this.panel1.BackColor = ResourceInitializer.FormStdBackgroundColor;
  
            this.PanelContenerTabs.BackColor = ResourceInitializer.FormStdBackgroundColor;
            //this.LowerPanel.BackColor = ResourceInitializer.FormStdBackgroundColor;
           // this.EtchedLine.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnBack.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnNext.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.pnlBottom.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnFinish.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.tabPageStep2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.LabelNewline.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.Append2csv.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.xpBrowse.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.radioButton11.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton10.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton9.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton8.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton7.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label4.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label11.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label12.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep4.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.ImportProgress.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label8.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep4.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.groupBox1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.BoxUseRule.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.checkBox2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.checkBox1.BackColor = ResourceInitializer.FormStdBackgroundColor;

            // to avoid the Exception with the message
            // Cross-thread operation not valid: Control 'ImportProgress' accessed from a thread other than the thread it was created on.

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false; 

			this.ActiveCube = cubeName;
			this.ActiveDB = dbN;
			this.ActiveHostname = hostname;

            this.currConn = Apalo.XlAddin.Connections.GetConnection(hostname);
			this.decpointtext = decpoint;
			this.impcore = new ImportCore(originalUICulture, null, ref this.ImportProgress, this);
			this.impcore.Terminating += new PaloThread(make_exit);

			string[] cubDims = this.currConn.CubeListDimensions(this.ActiveDB,this.ActiveCube);
			int currTmpBtn = 0;
            entryTabIndex = 100;
			
			try
			{
				RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\Jedox\Palo\XlAddin\MRU\CSV2");
				int valCnt = (int)regKey.ValueCount;
				this.comboBoxEx1.Items.Clear();
				for(int i=0;i<=valCnt;i++)
				{
					string s = (string)regKey.GetValue("url" + i.ToString());
					if(s != null)
						this.comboBoxEx1.Items.Add(s);
				}
			}
			catch(Exception exc)
			{
				ErrorHandler.DisplayError("Error getting Registry Values.", exc);
			}

			this.do_part_init();

			this.LeftPanelImage = ResourceInitializer.WizardLogo;
			//this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

			this.Text = ResourceInitializer.TITLE_EXPORT_WIZARD;
			this.TitleLabel = ResourceInitializer.TITLE_EXPORT_WIZARD;
			
			this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
			this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
			this.btnFinish.Text = ResourceInitializer.BUTTON_CANCEL;

			this.xpBrowse.Text = ResourceInitializer.BUTTON_BROWSE;

			this.label4.Text = ResourceInitializer.LABEL_EXPORT_PAGE_3_1;
			this.label3.Text = ResourceInitializer.LABEL_EXPORT_PAGE2_2;
			this.radioButton7.Text = ResourceInitializer.LABEL_OPTION_TAB;
			this.radioButton10.Text = ResourceInitializer.LABEL_OPTION_BLANK;
			this.radioButton8.Text = ResourceInitializer.LABEL_OPTION_COMMA;
			this.radioButton11.Text = ResourceInitializer.LABEL_OPTION_USERDEFINED;
			this.radioButton9.Text = ResourceInitializer.LABEL_OPTION_SEMICOLON;

			this.label8.Text = "";//ResourceInitializer.LABEL_IMPORT_PAGE4_1;

			this.groupBox1.Text = ResourceInitializer.LABEL_IMPORT_PAGE5_1;
			this.checkBox1.Text = ResourceInitializer.LABEL_IMPORT_PAGE5_2;
			this.checkBox2.Text = ResourceInitializer.LABEL_IMPORT_PAGE5_3;
			this.Append2csv.Text = ResourceInitializer.TEXT_APPEND2CSV;
            this.BoxUseRule.Text = ResourceInitializer.LABEL_EXPORT_USE_RULES;
            this.LabelNewline.Text = ResourceInitializer.LABEL_NEWLINE;
            this.checkBoxHeader.Text = ResourceInitializer.LABEL_CHECK_WITHHEADER;

			//this.WizardPages.SelectedIndex = 4;

			this.comboBoxEx1.TextChanged += new System.EventHandler(this.ComboBox1_TextChanged);

            // If last export was of same cube, offer old selections:
            if (String.Equals(hostname, RegUtils.ExportHostName)
                && String.Equals(dbN, RegUtils.ExportDB)
                && String.Equals(cubeName, RegUtils.ExportCube)
                && System.IO.File.Exists(fileElements))
            {
                // Read SelectedElements from file.
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(fileElements, FileMode.Open, FileAccess.Read, FileShare.Read);
                    this.SelectedElements = (ArrayList)formatter.Deserialize(stream);
                    stream.Close();
                }
                catch
                {}

                // Show old selections.
                foreach (string cubDim in cubDims)
                {
                    this.AddDimensionEntry(ref this.panel1, cubDim, currTmpBtn);
                    currTmpBtn++;
                    entryTabIndex += 10;
                }
                this.comboBox1.SelectedItem = RegUtils.ExportFirstComparator;
                this.textBox2.Text = RegUtils.ExportFirstNumber;
                this.comboBox4.SelectedItem = RegUtils.ExportCombination;
                this.comboBox3.SelectedItem = RegUtils.ExportSecondComparator;
                this.textBox3.Text = RegUtils.ExportSecondNumber;
                this.checkBox1.Checked = RegUtils.ExportSkipEmpty == 1;
                this.checkBox2.Checked = RegUtils.ExportBaseOnly == 1;
                this.BoxUseRule.Checked = RegUtils.ExportRules == 1;
                this.comboBoxEx1.SelectedItem = RegUtils.ExportFile;
                this.radioButton7.Checked = RegUtils.ExportSeparator == "	";
                this.radioButton8.Checked = RegUtils.ExportSeparator == ",";
                this.radioButton9.Checked = RegUtils.ExportSeparator == ";";
                this.radioButton10.Checked = RegUtils.ExportSeparator == " ";
                this.radioButton11.Checked = (RegUtils.ExportSeparator != "	")
                && (RegUtils.ExportSeparator != ",")
                && (RegUtils.ExportSeparator != ";")
                && (RegUtils.ExportSeparator != " ");
                this.textBox1.Text = RegUtils.ExportSeparator;
                this.Append2csv.Checked = RegUtils.ExportAppend == 1;
                this.NewLineArt.SelectedItem = RegUtils.ExportNewLine;
                this.checkBoxHeader.Checked = RegUtils.ExportHeader == 1;
                this.btnNext.Enabled = true;
            } 
            else
            {
                this.SelectedElements = new ArrayList();
                foreach (string cubDim in cubDims)
                {
                    this.SelectedElements.Add(new object[] { cubDim, new ArrayList() });
                    this.AddDimensionEntry(ref this.panel1, cubDim, currTmpBtn);
                    currTmpBtn++;
                    entryTabIndex += 10;
                }
            }

  
		}


		public void clean_up()
		{
			if (this.t != null)
			{
				try
				{
					t.Join();
					t.Abort();
					t.Join();
				}
				catch(Exception e)
				{
					ErrorHandler.DisplayError("Error cleaning_up ExportWizard", e);
				}
			}
			GC.Collect();
			t = null;
			GC.Collect();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
	
				GC.Collect();
				this.t = null;
				GC.Collect();
			}
			base.Dispose( disposing );
		}

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportWizard));
            this.tabPageStep2 = new JControls.TabPageStep();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BoxUseRule = new System.Windows.Forms.CheckBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPageStep3 = new JControls.TabPageStep();
            this.checkBoxHeader = new System.Windows.Forms.CheckBox();
            this.LabelNewline = new System.Windows.Forms.Label();
            this.NewLineArt = new System.Windows.Forms.ComboBox();
            this.Append2csv = new System.Windows.Forms.CheckBox();
            this.comboBoxEx1 = new System.Windows.Forms.ComboBox();
            this.xpBrowse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageStep4 = new JControls.TabPageStep();
            this.ImportProgress = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBottom.SuspendLayout();
            this.PanelContenerTabs.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.tabPageStep2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageStep3.SuspendLayout();
            this.tabPageStep4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(3, 358);
            this.pnlBottom.Size = new System.Drawing.Size(460, 41);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinish.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnFinish.Location = new System.Drawing.Point(367, 6);
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.xpCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBack.Location = new System.Drawing.Point(200, 6);
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.xpBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNext.Location = new System.Drawing.Point(280, 6);
            this.btnNext.Size = new System.Drawing.Size(80, 23);
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.xpNext_Click);
            // 
            // PanelContenerTabs
            // 
            this.PanelContenerTabs.BackColor = System.Drawing.SystemColors.Control;
            // 
            // wizardTabControl1
            // 
            this.wizardTabControl1.Controls.Add(this.tabPageStep2);
            this.wizardTabControl1.Controls.Add(this.tabPageStep3);
            this.wizardTabControl1.Controls.Add(this.tabPageStep4);
            this.wizardTabControl1.Location = new System.Drawing.Point(3, 61);
            this.wizardTabControl1.Size = new System.Drawing.Size(460, 302);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep4, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep3, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep2, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep1, 0);
            // 
            // tabPageStep1
            // 
            this.tabPageStep1.Controls.Add(this.panel1);
            this.tabPageStep1.Size = new System.Drawing.Size(452, 276);
            // 
            // tabPageStep2
            // 
            this.tabPageStep2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep2.Controls.Add(this.groupBox1);
            this.tabPageStep2.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep2.Name = "tabPageStep2";
            this.tabPageStep2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStep2.ShowBackButton = true;
            this.tabPageStep2.ShowFinishButton = true;
            this.tabPageStep2.ShowNextButton = true;
            this.tabPageStep2.Size = new System.Drawing.Size(452, 276);
            this.tabPageStep2.TabIndex = 1;
            this.tabPageStep2.Tag = 2;
            this.tabPageStep2.Text = "Step2";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.BoxUseRule);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 276);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BoxUseRule
            // 
            this.BoxUseRule.BackColor = System.Drawing.SystemColors.Control;
            this.BoxUseRule.Location = new System.Drawing.Point(16, 126);
            this.BoxUseRule.Name = "BoxUseRule";
            this.BoxUseRule.Size = new System.Drawing.Size(384, 24);
            this.BoxUseRule.TabIndex = 18;
            this.BoxUseRule.Text = "also export rule based cell values";
            this.BoxUseRule.UseVisualStyleBackColor = false;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Items.AddRange(new object[] {
            "AND",
            "OR",
            "XOR"});
            this.comboBox4.Location = new System.Drawing.Point(152, 24);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(56, 21);
            this.comboBox4.TabIndex = 13;
            // 
            // checkBox2
            // 
            this.checkBox2.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(16, 96);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(384, 24);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(16, 64);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(384, 24);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Items.AddRange(new object[] {
            "<none>",
            "=",
            ">=",
            ">",
            "<=",
            "<",
            "<>"});
            this.comboBox3.Location = new System.Drawing.Point(224, 24);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(64, 21);
            this.comboBox3.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "<none>",
            "=",
            ">=",
            ">",
            "<=",
            "<",
            "<>"});
            this.comboBox1.Location = new System.Drawing.Point(16, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(64, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(290, 24);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(56, 20);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(82, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "0";
            // 
            // tabPageStep3
            // 
            this.tabPageStep3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep3.Controls.Add(this.checkBoxHeader);
            this.tabPageStep3.Controls.Add(this.LabelNewline);
            this.tabPageStep3.Controls.Add(this.NewLineArt);
            this.tabPageStep3.Controls.Add(this.Append2csv);
            this.tabPageStep3.Controls.Add(this.comboBoxEx1);
            this.tabPageStep3.Controls.Add(this.xpBrowse);
            this.tabPageStep3.Controls.Add(this.textBox1);
            this.tabPageStep3.Controls.Add(this.radioButton11);
            this.tabPageStep3.Controls.Add(this.radioButton10);
            this.tabPageStep3.Controls.Add(this.radioButton9);
            this.tabPageStep3.Controls.Add(this.radioButton8);
            this.tabPageStep3.Controls.Add(this.radioButton7);
            this.tabPageStep3.Controls.Add(this.label3);
            this.tabPageStep3.Controls.Add(this.label4);
            this.tabPageStep3.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep3.Name = "tabPageStep3";
            this.tabPageStep3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStep3.ShowBackButton = true;
            this.tabPageStep3.ShowFinishButton = true;
            this.tabPageStep3.ShowNextButton = true;
            this.tabPageStep3.Size = new System.Drawing.Size(452, 276);
            this.tabPageStep3.TabIndex = 2;
            this.tabPageStep3.Tag = 3;
            this.tabPageStep3.Text = "Step3";
            // 
            // checkBoxHeader
            // 
            this.checkBoxHeader.AutoSize = true;
            this.checkBoxHeader.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxHeader.Enabled = false;
            this.checkBoxHeader.Location = new System.Drawing.Point(56, 257);
            this.checkBoxHeader.Name = "checkBoxHeader";
            this.checkBoxHeader.Size = new System.Drawing.Size(109, 17);
            this.checkBoxHeader.TabIndex = 31;
            this.checkBoxHeader.Text = "checkBoxHeader";
            this.checkBoxHeader.UseVisualStyleBackColor = false;
            // 
            // LabelNewline
            // 
            this.LabelNewline.Enabled = false;
            this.LabelNewline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNewline.Location = new System.Drawing.Point(206, 230);
            this.LabelNewline.Name = "LabelNewline";
            this.LabelNewline.Size = new System.Drawing.Size(226, 24);
            this.LabelNewline.TabIndex = 0;
            this.LabelNewline.Text = "Newline";
            this.LabelNewline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NewLineArt
            // 
            this.NewLineArt.Enabled = false;
            this.NewLineArt.Items.AddRange(new object[] {
            "Windows   ( \\r\\n )",
            "Linux     ( \\n   )",
            "Macintosh ( \\n\\r )"});
            this.NewLineArt.Location = new System.Drawing.Point(56, 230);
            this.NewLineArt.Name = "NewLineArt";
            this.NewLineArt.Size = new System.Drawing.Size(144, 21);
            this.NewLineArt.TabIndex = 30;
            // 
            // Append2csv
            // 
            this.Append2csv.BackColor = System.Drawing.SystemColors.Control;
            this.Append2csv.Enabled = false;
            this.Append2csv.Location = new System.Drawing.Point(56, 200);
            this.Append2csv.Name = "Append2csv";
            this.Append2csv.Size = new System.Drawing.Size(384, 24);
            this.Append2csv.TabIndex = 29;
            this.Append2csv.Text = "Append at the end of file";
            this.Append2csv.UseVisualStyleBackColor = false;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.Location = new System.Drawing.Point(56, 80);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(256, 21);
            this.comboBoxEx1.TabIndex = 21;
            this.comboBoxEx1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            // 
            // xpBrowse
            // 
            this.xpBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.xpBrowse.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.xpBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpBrowse.Location = new System.Drawing.Point(328, 80);
            this.xpBrowse.Name = "xpBrowse";
            this.xpBrowse.Size = new System.Drawing.Size(95, 23);
            this.xpBrowse.TabIndex = 22;
            this.xpBrowse.UseVisualStyleBackColor = false;
            this.xpBrowse.Click += new System.EventHandler(this.xpBrowse_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(208, 168);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 22);
            this.textBox1.TabIndex = 28;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioButton11
            // 
            this.radioButton11.Enabled = false;
            this.radioButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton11.Location = new System.Drawing.Point(192, 136);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(240, 24);
            this.radioButton11.TabIndex = 27;
            this.radioButton11.CheckedChanged += new System.EventHandler(this.radioButton11_CheckedChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.Enabled = false;
            this.radioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton10.Location = new System.Drawing.Point(192, 112);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(240, 24);
            this.radioButton10.TabIndex = 26;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.Enabled = false;
            this.radioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton9.Location = new System.Drawing.Point(56, 160);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(144, 24);
            this.radioButton9.TabIndex = 25;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.Enabled = false;
            this.radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton8.Location = new System.Drawing.Point(56, 136);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(136, 24);
            this.radioButton8.TabIndex = 24;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.Checked = true;
            this.radioButton7.Enabled = false;
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton7.Location = new System.Drawing.Point(56, 112);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(136, 24);
            this.radioButton7.TabIndex = 23;
            this.radioButton7.TabStop = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(392, 23);
            this.label3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(416, 32);
            this.label4.TabIndex = 0;
            // 
            // tabPageStep4
            // 
            this.tabPageStep4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep4.Controls.Add(this.ImportProgress);
            this.tabPageStep4.Controls.Add(this.label8);
            this.tabPageStep4.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep4.Name = "tabPageStep4";
            this.tabPageStep4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStep4.ShowBackButton = true;
            this.tabPageStep4.ShowFinishButton = true;
            this.tabPageStep4.ShowNextButton = true;
            this.tabPageStep4.Size = new System.Drawing.Size(452, 276);
            this.tabPageStep4.TabIndex = 3;
            this.tabPageStep4.Tag = 4;
            this.tabPageStep4.Text = "Step4";
            // 
            // ImportProgress
            // 
            this.ImportProgress.Location = new System.Drawing.Point(16, 50);
            this.ImportProgress.Name = "ImportProgress";
            this.ImportProgress.Size = new System.Drawing.Size(424, 23);
            this.ImportProgress.Step = 1;
            this.ImportProgress.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 278);
            this.panel1.TabIndex = 100;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 0;
            // 
            // ExportWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(618, 400);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportWizard";
            this.Text = "";
            this.TitleLabel = "";
            this.pnlBottom.ResumeLayout(false);
            this.PanelContenerTabs.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.tabPageStep2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageStep3.ResumeLayout(false);
            this.tabPageStep3.PerformLayout();
            this.tabPageStep4.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private void xpBack_Click(object sender, System.EventArgs e)
        {
            if (this.btnBack.Text != ResourceInitializer.BUTTON_NEXT)
            {
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;

                if (--this.wizardTabControl1.SelectedIndex == 0)
                {
                    this.btnBack.Enabled = false;
                    this.Height = NORM_HEIGHT;
                }
                this.nextpage = this.wizardTabControl1.SelectedIndex;
                this.btnNext.Enabled = true;
            }
            else
            {
                try
                {
                    this.impcore.insertRowCsv();
                }
                catch (Exception exc)
                {
                    ErrorHandler.DisplayError("Error stepping through export!", exc);
                }
            }
        }


        private void checknext2()
        {
            if ((this.comboBoxEx1.Text.Length == 0) || (this.radioButton11.Checked && (this.textBox1.Text.Length == 0)))
            {
                this.btnNext.Enabled = false;
            }
            else
            {
                this.btnNext.Enabled = true;
            }
        }

        private void manageStartPage()
        {
            if (++this.nextpage > 3)
                this.nextpage = 0;
        }

        private void xpNext_Click(object sender, System.EventArgs e)
        {
            if (this.btnNext.Text == ResourceInitializer.BUTTON_FINISH)
            {
                // insert selected filename into registry and comboBoxEx1.Items
                string fileName = this.comboBoxEx1.Text;
                int i = 0;
                foreach (string itm in this.comboBoxEx1.Items)
                {
                    if (itm == fileName) i++;
                }
                if (i == 0)
                {
                    this.comboBoxEx1.Items.Add(fileName);
                    RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\Jedox\Palo\XlAddin\MRU\CSV2");
                    int valCnt = (int)regKey.ValueCount;
                    valCnt++;
                    if (valCnt > 10)
                    {
                        valCnt = 1;
                    }
                    regKey.SetValue("url" + valCnt, fileName);
                    regKey.Close();
                }

                try
                {
                    ExcelHelper.ResetExcelStatusbar();

                    this.StartDsCube();
                    if (this.impcore.empty())
                    {
                        this.impcore.clean_up();
                        if (show_no_data_mesg) System.Windows.Forms.MessageBox.Show(ResourceInitializer.ERROR_DATA_NOT_FOUND, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show_no_data_mesg = true;
                    }
                    else
                    {
                        // Save selections in registry.
                        RegUtils.ExportHostName = this.ActiveHostname;
                        RegUtils.ExportDB = this.ActiveDB;
                        RegUtils.ExportCube = this.ActiveCube;

                        // Save SelectedElements in a file.

                        Stream stream = null;
                        try
                        {
                            IFormatter formatter = new BinaryFormatter();
                            stream = new FileStream(fileElements, FileMode.Create, FileAccess.Write, FileShare.None);
                            formatter.Serialize(stream, this.SelectedElements);
                        }
                        catch(Exception ex)
                        {
                            ErrorHandler.DisplayError("creating elements.bin failed !", ex);
                            if (stream != null)
                            {
                                stream.Close();
                            }
                        }

                        RegUtils.ExportFirstComparator = (string)this.comboBox1.SelectedItem;
                        RegUtils.ExportFirstNumber = this.textBox2.Text;
                        RegUtils.ExportCombination = (string)this.comboBox4.SelectedItem;
                        RegUtils.ExportSecondComparator = (string)this.comboBox3.SelectedItem;
                        RegUtils.ExportSecondNumber = this.textBox3.Text;
                        RegUtils.ExportSkipEmpty = this.checkBox1.Checked ? 1 : 0;
                        RegUtils.ExportBaseOnly = this.checkBox2.Checked ? 1 : 0;
                        RegUtils.ExportRules = this.BoxUseRule.Checked ? 1 : 0;
                        RegUtils.ExportFile = fileName;
                        string separator = " ";
                        if (this.radioButton7.Checked)
                        {
                            separator = "	";
                        } 
                        else if (this.radioButton8.Checked)
                        {
                            separator = ",";
                        }
                        else if (this.radioButton9.Checked)
                        {
                            separator = ";";
                        } 
                        else if (this.radioButton10.Checked)
                        {
                            separator = " ";
                        }
                        else if (this.radioButton11.Checked)
                        {
                            char[] tmp = this.textBox1.Text.ToCharArray();
                            separator = tmp[0].ToString();
                        }
                        RegUtils.ExportSeparator = separator;
                        RegUtils.ExportAppend = this.Append2csv.Checked ? 1 : 0;
                        RegUtils.ExportNewLine = this.NewLineArt.SelectedItem.ToString();
                        RegUtils.ExportHeader = this.checkBoxHeader.Checked ? 1 : 0;

                        this.SuspendLayout();
                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.wizardTabControl1.SelectedIndex = 3;
                        //this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
                        this.Height = FINISH_HEIGHT;
                        this.wizardTabControl1.Height = 90;
                        this.PanelContenerTabs.Height = FINISH_HEIGHT;
                        this.pnlBottom.Location = new System.Drawing.Point(0, 145);
                        this.btnBack.Text = ResourceInitializer.BUTTON_NEXT;
                        this.btnBack.Enabled = true;
                        this.btnBack.Visible = false;
                        this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                        this.btnNext.Enabled = false;
                        this.btnNext.Visible = false;
                        this.btnNext.Focus();
                        this.ResumeLayout();

                        this.t = new Thread(new ThreadStart(this.impcore.t_insertRowCsv));
                        this.finishing = true;
                        this.t.Start();
                    }
                }
                catch (Exception exc)
                {
                    ErrorHandler.DisplayError("Error finishing Export!", exc);
                }
            }
            else
            {
                this.manageStartPage();
                switch (this.nextpage)
                {
                    case 0:
                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.checknext2();
                        this.Height = NORM_HEIGHT;
                        this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
                        this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                        this.btnBack.Enabled = false;
                        this.btnNext.Enabled = true;
                        break;

                    case 1:
                        //if(this.radioButton3.Checked)
                        {
                            this.wizardTabControl1.SelectedIndex = this.nextpage;
                            this.btnBack.Enabled = true;
                            this.btnNext.Enabled = true;
                        }
                        break;

                    case 2:
                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.checknext2();
                        this.Height = NORM_HEIGHT;
                        this.btnBack.Enabled = true;
                        this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
                        this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                        break;

                }
            }
        }

        public void b_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
            int currItem = 0;
            foreach (object[] o in this.SelectedElements)
            {
                if ((string)o[0] == (string)b.Tag)
                {
                    break;
                }
                currItem++;
            }

            System.Object[] tmpSelection = (System.Object[])this.SelectedElements[currItem];
            ArrayList currElements = (ArrayList)tmpSelection[1];

            Apalo.XlAddin.Forms.ChooseElements frmename = new Apalo.XlAddin.Forms.ChooseElements(this.ActiveHostname + "/" + this.ActiveDB, (string)b.Tag);
            frmename.set_selection(ref currElements, true, "");
            if (frmename.ShowDialog() == DialogResult.OK)
            {
                string tmpToolTip = " ";
                int tmpCounter = 0;
                tmpSelection[1] = currElements;
                foreach (object[] s in currElements)
                {
                    if (tmpCounter > 10)
                    {
                        tmpToolTip += (string)s[0] + "...,";
                        break;
                    }

                    tmpToolTip += (string)s[0] + ",";

                    tmpCounter++;
                }

                tmpToolTip = tmpToolTip.Substring(0, tmpToolTip.Length - 1).Trim();

                if (tmpToolTip == "")
                {
                    tmpToolTip = "(" + ResourceInitializer.LABEL_SELECT_ALL_ELEMENTS + ")";
                }

                if (tmpToolTip.Length > 54)
                {
                    tmpToolTip = tmpToolTip.Substring(0, 54) + "...";
                }

                foreach (System.Windows.Forms.Control l in this.panel1.Controls)
                {
                    /// TODO reduce reduncancy
                    if (l.Tag != null && l.Name != null && l.Name == "label" && l.Tag == b.Tag)
                    {
                        if (tmpToolTip.Length < 55)
                            l.Text = tmpToolTip;
                        else
                            l.Text = tmpToolTip.Substring(0, 54) + "...";
                        break;
                    }
                }
            }
            frmename.Dispose();
            frmename = null;

        }

        public void AddDimensionEntry(ref System.Windows.Forms.Panel p1, string dim, int pos)
        {
            System.Windows.Forms.Button d = new System.Windows.Forms.Button();
            System.Windows.Forms.Button b = new System.Windows.Forms.Button();
            Label l = new Label();
            string dimLabel = "";

            if (dim.Length < 12)
                dimLabel = dim;
            else
                dimLabel = dim.Substring(0, 11);

            d.BackColor = ResourceInitializer.FormStdBackgroundColor;
            d.Text = dimLabel;
            d.FlatStyle = FlatStyle.Flat;
            d.Width = 85;
            d.Height = 23;
            d.Left = 6;
            d.Top = 8 + pos * 23;
            d.Tag = dim;
            d.TabIndex = entryTabIndex;
            this.toolTip1.SetToolTip(d, dim);

            b.BackColor = ResourceInitializer.FormStdBackgroundColor;
            b.Text = "...";
            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.01f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b.FlatStyle = FlatStyle.Flat;
            b.Margin = new System.Windows.Forms.Padding(0);
            b.Padding = new System.Windows.Forms.Padding(0);
            b.Width = 24;
            b.Height = d.Height;
            b.Left = d.Right - 1;
            b.Top = d.Top;
            b.Click += new EventHandler(b_Click);
            b.Tag = d.Tag;
            b.TabIndex = entryTabIndex + 1;
            this.toolTip1.SetToolTip(b, ResourceInitializer.TIP_CHOOSE_ELEMENTS);
            b.Name = "sibling";
            string tmpToolTip = " ";

            // TODO better implementation
            
            int currItem = 0;
            foreach (object[] o in this.SelectedElements)
            {
                if ((string)o[0] == dim) break;
                currItem++;
            }
            if (currItem < this.SelectedElements.Count)
            {
                Object[] tmpSelection = (Object[])this.SelectedElements[currItem];
                ArrayList currElements = (ArrayList)tmpSelection[1];
                int tmpCounter = 0;
                foreach (object[] s in currElements)
                {
                    if (tmpCounter > 10)
                    {
                        tmpToolTip += (string)s[0] + "...,";
                        break;
                    }
                    tmpToolTip += (string)s[0] + ",";
                    tmpCounter++;
                }
            }
            tmpToolTip = tmpToolTip.Substring(0, tmpToolTip.Length - 1).Trim();
            if (tmpToolTip == "")
            {
                tmpToolTip = "(" + ResourceInitializer.LABEL_SELECT_ALL_ELEMENTS + ")";
            }

            l.BackColor = ResourceInitializer.FormStdBackgroundColor;
            l.Text = "(" + ResourceInitializer.LABEL_SELECT_ALL_ELEMENTS + ")";
            if (tmpToolTip.Length < 55)
            {
                l.Text = tmpToolTip;
            } 
            else
            {
                l.Text = tmpToolTip.Substring(0, 54) + "...";
            }
            l.FlatStyle = FlatStyle.Flat;
            l.Width = 325;
            l.Height = d.Height - 1;
            l.Left = b.Right + 7;
            l.Top = d.Top + 1;
            l.Tag = d.Tag;
            l.Name = "label";
            l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            p1.Controls.Add(d);
            p1.Controls.Add(b);
            p1.Controls.Add(l);
        }
        private void xpCancel_Click(object sender, System.EventArgs e)
        {
            this.impcore.Terminate();
            if (!this.finishing) this.do_exit();
        }

        private void do_part_init()
        {
            this.impcore.clean_up();

            this.Height = NORM_HEIGHT;
            this.ImportProgress.Value = 0;
            this.wizardTabControl1.SelectedIndex = 0;
            this.btnBack.Enabled = false;
            this.NewLineArt.SelectedIndex = (this.OldnewLineIndex > -1) ? this.OldnewLineIndex : 0;

        }

        public void do_exit()
        {
            this.finishing = false;
            this.OldnewLineIndex = this.NewLineArt.SelectedIndex;

            ExcelHelper.ResetExcelStatusbar();
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void make_exit(object sender)
        {
            this.do_exit();
        }

        public void reinit()
        {
           // this.TitlePanel.SuspendLayout();
           // this.LowerPanel.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.tabPageStep2.SuspendLayout();
            this.tabPageStep3.SuspendLayout();
            this.tabPageStep4.SuspendLayout();
            this.SuspendLayout();
            this.tabPageStep1.Location = new System.Drawing.Point(4, 4);
            this.tabPageStep2.Location = new System.Drawing.Point(4, 4);
            this.tabPageStep3.Location = new System.Drawing.Point(4, 4);
            this.tabPageStep4.Location = new System.Drawing.Point(4, 4);
            //this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //this.TitlePanel.ResumeLayout(false);
           // this.LowerPanel.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.tabPageStep2.ResumeLayout(false);
            this.tabPageStep3.ResumeLayout(false);
            this.tabPageStep4.ResumeLayout(false);
            this.do_part_init();
            this.ResumeLayout(false);
        }

        private void StartDsCube()
        {
            try
            {
                char separator = ' ';
                if (this.radioButton7.Checked == true)
                {
                    separator = '	';
                }
                else if (this.radioButton8.Checked == true)
                {
                    separator = ',';
                }
                else if (this.radioButton9.Checked == true)
                {
                    separator = ';';
                }
                else if (this.radioButton10.Checked == true)
                {
                    separator = ' ';
                }
                else if (this.radioButton11.Checked == true)
                {
                    char[] tmp = this.textBox1.Text.ToCharArray();
                    separator = tmp[0];
                }

                string decpoint = ".";

                if (this.decpointtext.Length > 0)
                {
                    decpoint = this.decpointtext;
                }

                this.impcore.set_csv_params(this.comboBoxEx1.Text, false, separator, decpoint, this.Append2csv.Checked, this.NewLineArt.SelectedIndex, true);
                this.impcore.set_withHeader(this.checkBoxHeader.Checked);
                this.impcore.set_cube_params(this.currConn, this.ActiveDB, this.ActiveCube, this.SelectedElements, new ArrayList(new object[] { this.textBox2.Text, this.comboBox1.SelectedIndex, this.comboBox4.SelectedIndex, this.comboBox3.SelectedIndex, this.textBox3.Text, this.checkBox1.Checked, this.checkBox2.Checked, this.BoxUseRule.Checked }));
                this.impcore.start();
            }
            catch (Exception exc)
            {
                this.impcore.clean_up();
                System.Windows.Forms.MessageBox.Show(exc.Message);
                show_no_data_mesg = false;
                ErrorHandler.DisplayError("Error filling Cube data!", exc);
            }
        }

        private void checknext_csv()
        {
            bool enabled = false;
            if (this.comboBoxEx1.Text != "")
            {
                enabled = true;
            }

            if (this.NewLineArt.SelectedIndex < 0)
            {
                this.NewLineArt.SelectedIndex = 0;
            }

            this.radioButton7.Enabled = enabled;
            this.radioButton8.Enabled = enabled;
            this.radioButton9.Enabled = enabled;
            this.radioButton10.Enabled = enabled;
            this.radioButton11.Enabled = enabled;
            this.Append2csv.Enabled = enabled;
            this.NewLineArt.Enabled = enabled;
            this.LabelNewline.Enabled = enabled;
            this.checkBoxHeader.Enabled = enabled;

            this.checknext2();
        }

        private void ComboBox1_TextChanged(object sender, System.EventArgs e)
        {
            this.checknext_csv();
        }

        private void xpBrowse_Click(object sender, System.EventArgs e)
        {

            SaveFileDialog openFileDialog1 = new SaveFileDialog();

            openFileDialog1.InitialDirectory = RegUtils.SavePath;
            openFileDialog1.Filter = ResourceInitializer.LABEL_CSV_FILTER;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                string fn = FileHelper.getdirname((string)openFileDialog1.FileName);
                if (!String.IsNullOrEmpty(fn))
                {
                    RegUtils.SavePath = fn;
                }
                this.CsvFileToWrite = (string)openFileDialog1.FileName;

                /*
				 * If not found in combo add it to both combo and registry
				*/
                int i = 0;
                foreach (string itm in this.comboBoxEx1.Items)
                {
                    if (itm == this.CsvFileToWrite)
                        i++;
                }

                if (i == 0)
                {
                    this.comboBoxEx1.Items.Add(this.CsvFileToWrite);
                    RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\Jedox\Palo\XlAddin\MRU\CSV2");
                    int valCnt = (int)regKey.ValueCount;
                    valCnt++;
                    if (valCnt > 10) valCnt = 1;
                    regKey.SetValue("url" + valCnt, (string)openFileDialog1.FileName);
                    regKey.Close();
                }

                this.comboBoxEx1.Text = this.CsvFileToWrite;
                this.btnNext.Enabled = true;
            }
            openFileDialog1.Dispose();
            this.checknext_csv();

        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.checknext_csv();
        }

        private void radioButton11_CheckedChanged(object sender, System.EventArgs e)
        {
            this.textBox1.Enabled = this.radioButton11.Checked;
            this.checknext2();
        }

        private void radioButton7_CheckedChanged(object sender, System.EventArgs e)
        {
            this.btnNext.Enabled = true;
            this.textBox1.Enabled = false;
        }

        private void radioButton8_CheckedChanged(object sender, System.EventArgs e)
        {
            this.btnNext.Enabled = true;
            this.textBox1.Enabled = false;
        }

        private void radioButton9_CheckedChanged(object sender, System.EventArgs e)
        {
            this.btnNext.Enabled = true;
            this.textBox1.Enabled = false;
        }

        private void radioButton10_CheckedChanged(object sender, System.EventArgs e)
        {
            this.btnNext.Enabled = true;
            this.textBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            this.checknext2();
        }

    }
}