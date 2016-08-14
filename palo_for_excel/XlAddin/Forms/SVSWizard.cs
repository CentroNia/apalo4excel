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
using Jedox.Controls;
using Jedox.Palo.XlAddin.Utils;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Globalization;
using System.Collections;
using Microsoft.Win32;

using Fireball.Windows.Forms; // Where is located CodeEditorControl class
using Fireball.Syntax; // Where is located SyntaxDocument class
using Fireball.CodeEditor.SyntaxFiles; // Where is located commons SyntaxFiles

namespace Jedox.Palo.XlAddin.Forms
{
    [ComVisible(false)]
    public  class SVSWizard : WizardDialogForm
    {
        const int NORM_HEIGHT = 421;
        const int FINISH_HEIGHT = 210;

        private System.ComponentModel.IContainer components = null;

        private Panel panel1;
        private TabPageStep tabPageStep2;
        private TabPageStep tabPageStep3;
        private TabPageStep tabPageStep4;
        private TabPageStep tabPageStep5;

        private string fileElements = RegUtils.SavePath + "\\svs_elements.bin";

        private int entryTabIndex = 100;

        private Jedox.Palo.Comm.Connection currConn;

        private string ActiveDB;
        private string ActiveCube;
        private string ActiveHostname;

        private ArrayList SelectedElements = new ArrayList();

        private bool finishing = false;
        private Thread t = null;
        private int nextpage = 0;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Label label1;
        private Label label2;
        private CodeEditorControl codeWindow;
        private Label label3;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label4;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private Label label5;
        private RadioButton radioButton6;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label13;
        private Label label10;
        private Label label15;
        private Label label14;
        private System.Windows.Forms.ToolTip toolTip1;

        public SVSWizard(CultureInfo originalUICulture, string hostname, string dbN, string cubeName)
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
            this.label11.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label12.BackColor = ResourceInitializer.FormStdBackgroundColor;            
            this.tabPageStep1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep4.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep5.BackColor = ResourceInitializer.FormStdBackgroundColor;

			this.ActiveCube = cubeName;
			this.ActiveDB = dbN;
			this.ActiveHostname = hostname;

            this.currConn = Connections.GetConnection(hostname);

			string[] cubDims = this.currConn.CubeListDimensions(this.ActiveDB,this.ActiveCube);
			int currTmpBtn = 0;
            entryTabIndex = 100;

			this.LeftPanelImage = ResourceInitializer.WizardLogo;
			//this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

			this.Text = ResourceInitializer.TITLE_SVS_WIZARD;
			this.TitleLabel = ResourceInitializer.TITLE_SVS_WIZARD;
			
			this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
			this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
			this.btnFinish.Text = ResourceInitializer.BUTTON_CANCEL;

            this.btnBack.Enabled = false;
            
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

            // Add the Code Editor for Step 3
            CodeEditorSyntaxLoader.SetSyntax(codeWindow, SyntaxLanguage.PHP);

            // Zum Test hier, gehört in die Sprachdatei später
            this.label1.Text = ResourceInitializer.SVS_WIZARD_SETP3_TEXT;
            this.label2.Text = ResourceInitializer.SVS_WIZARD_SETP4_TEXT;
            this.label3.Text = ResourceInitializer.SVS_WIZARD_SETP3_TEXT;
            this.label4.Text = ResourceInitializer.SVS_WIZARD_SETP1_TEXT;
            this.label5.Text = ResourceInitializer.SVS_WIZARD_SETP2_TEXT;

            this.label14.Text = ResourceInitializer.SVS_WIZARD_SETP5_TEXT;
            this.label15.Text = ResourceInitializer.SVS_SAVE_TEXT;

            // captions for the radiobuttons on step 1
            this.radioButton1.Text = ResourceInitializer.SVS_RADIOBUTTON1_TEXT;
            this.radioButton2.Text = ResourceInitializer.SVS_RADIOBUTTON2_TEXT;
            this.radioButton3.Text = ResourceInitializer.SVS_RADIOBUTTON3_TEXT;
            this.radioButton6.Text = ResourceInitializer.SVS_RADIOBUTTON4_TEXT;

            // catpions for the radiobuttons on step 2
            this.radioButton4.Text = ResourceInitializer.SVS_RADIOBUTTON5_TEXT;
            this.radioButton5.Text = ResourceInitializer.SVS_RADIOBUTTON6_TEXT;

            this.label6.Text = ResourceInitializer.SVS_RADIOBUTTON1_DESCRIPTION;
            this.label7.Text = ResourceInitializer.SVS_RADIOBUTTON2_DESCRIPTION;
            this.label8.Text = ResourceInitializer.SVS_RADIOBUTTON3_DESCRIPTION;
            this.label9.Text = ResourceInitializer.SVS_RADIOBUTTON4_DESCRIPTION;
            this.label10.Text = ResourceInitializer.SVS_RADIOBUTTON5_DESCRIPTION;
            this.label13.Text = ResourceInitializer.SVS_RADIOBUTTON6_DESCRIPTION;
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
            Fireball.Windows.Forms.LineMarginRender lineMarginRender1 = new Fireball.Windows.Forms.LineMarginRender();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SVSWizard));
            this.tabPageStep2 = new Jedox.Controls.TabPageStep();
            this.tabPageStep3 = new Jedox.Controls.TabPageStep();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageStep4 = new Jedox.Controls.TabPageStep();
            this.codeWindow = new Fireball.Windows.Forms.CodeEditorControl();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageStep5 = new Jedox.Controls.TabPageStep();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.PanelContenerTabs.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.tabPageStep2.SuspendLayout();
            this.tabPageStep3.SuspendLayout();
            this.tabPageStep4.SuspendLayout();
            this.tabPageStep5.SuspendLayout();
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
            this.wizardTabControl1.Controls.Add(this.tabPageStep5);
            this.wizardTabControl1.Location = new System.Drawing.Point(3, 56);
            this.wizardTabControl1.Size = new System.Drawing.Size(460, 302);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep5, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep4, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep3, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep2, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep1, 0);
            // 
            // tabPageStep1
            // 
            this.tabPageStep1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep1.Controls.Add(this.label9);
            this.tabPageStep1.Controls.Add(this.label8);
            this.tabPageStep1.Controls.Add(this.label7);
            this.tabPageStep1.Controls.Add(this.label6);
            this.tabPageStep1.Controls.Add(this.radioButton6);
            this.tabPageStep1.Controls.Add(this.radioButton3);
            this.tabPageStep1.Controls.Add(this.radioButton2);
            this.tabPageStep1.Controls.Add(this.radioButton1);
            this.tabPageStep1.Controls.Add(this.label4);
            this.tabPageStep1.Controls.Add(this.label3);
            this.tabPageStep1.Size = new System.Drawing.Size(452, 276);
            this.tabPageStep1.TabIndex = 2;
            this.tabPageStep1.Tag = 3;
            // 
            // tabPageStep2
            // 
            this.tabPageStep2.Controls.Add(this.label13);
            this.tabPageStep2.Controls.Add(this.label10);
            this.tabPageStep2.Controls.Add(this.radioButton5);
            this.tabPageStep2.Controls.Add(this.radioButton4);
            this.tabPageStep2.Controls.Add(this.label5);
            this.tabPageStep2.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep2.Name = "tabPageStep2";
            this.tabPageStep2.ShowBackButton = true;
            this.tabPageStep2.ShowFinishButton = true;
            this.tabPageStep2.ShowNextButton = true;
            this.tabPageStep2.Size = new System.Drawing.Size(452, 276);
            this.tabPageStep2.TabIndex = 1;
            this.tabPageStep2.Text = "Step2";
            // 
            // tabPageStep3
            // 
            this.tabPageStep3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep3.Controls.Add(this.panel1);
            this.tabPageStep3.Controls.Add(this.label1);
            this.tabPageStep3.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep3.Name = "tabPageStep3";
            this.tabPageStep3.ShowBackButton = true;
            this.tabPageStep3.ShowFinishButton = true;
            this.tabPageStep3.ShowNextButton = true;
            this.tabPageStep3.Size = new System.Drawing.Size(452, 276);
            this.tabPageStep3.TabIndex = 1;
            this.tabPageStep3.Tag = 2;
            this.tabPageStep3.Text = "Step3";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(3, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 238);
            this.panel1.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 32);
            this.label1.TabIndex = 1;
            // 
            // tabPageStep4
            // 
            this.tabPageStep4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep4.Controls.Add(this.codeWindow);
            this.tabPageStep4.Controls.Add(this.label2);
            this.tabPageStep4.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep4.Name = "tabPageStep4";
            this.tabPageStep4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStep4.ShowBackButton = true;
            this.tabPageStep4.ShowFinishButton = true;
            this.tabPageStep4.ShowNextButton = true;
            this.tabPageStep4.Size = new System.Drawing.Size(452, 276);
            this.tabPageStep4.TabIndex = 2;
            this.tabPageStep4.Tag = 3;
            this.tabPageStep4.Text = "Step4";
            // 
            // codeWindow
            // 
            this.codeWindow.ActiveView = Fireball.Windows.Forms.CodeEditor.ActiveView.BottomRight;
            this.codeWindow.AllowBreakPoints = false;
            this.codeWindow.AutoListPosition = null;
            this.codeWindow.AutoListSelectedText = "a123";
            this.codeWindow.AutoListVisible = false;
            this.codeWindow.CopyAsRTF = false;
            this.codeWindow.InfoTipCount = 1;
            this.codeWindow.InfoTipPosition = null;
            this.codeWindow.InfoTipSelectedIndex = 1;
            this.codeWindow.InfoTipVisible = false;
            lineMarginRender1.Bounds = new System.Drawing.Rectangle(19, 0, 19, 16);
            this.codeWindow.LineMarginRender = lineMarginRender1;
            this.codeWindow.Location = new System.Drawing.Point(6, 35);
            this.codeWindow.LockCursorUpdate = false;
            this.codeWindow.Name = "codeWindow";
            this.codeWindow.Saved = false;
            this.codeWindow.Size = new System.Drawing.Size(440, 232);
            this.codeWindow.SmoothScroll = false;
            this.codeWindow.SplitView = false;
            this.codeWindow.SplitviewH = -4;
            this.codeWindow.SplitviewV = -4;
            this.codeWindow.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.codeWindow.TabIndex = 4;
            this.codeWindow.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 32);
            this.label2.TabIndex = 3;
            // 
            // tabPageStep5
            // 
            this.tabPageStep5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep5.Controls.Add(this.label15);
            this.tabPageStep5.Controls.Add(this.label14);
            this.tabPageStep5.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep5.Name = "tabPageStep5";
            this.tabPageStep5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStep5.ShowBackButton = true;
            this.tabPageStep5.ShowFinishButton = true;
            this.tabPageStep5.ShowNextButton = true;
            this.tabPageStep5.Size = new System.Drawing.Size(452, 276);
            this.tabPageStep5.TabIndex = 2;
            this.tabPageStep5.Tag = 3;
            this.tabPageStep5.Text = "Step5";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(448, 270);
            this.label3.TabIndex = 4;           
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
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 166);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 17);
            this.radioButton3.TabIndex = 8;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 102);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 38);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(416, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "caption";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 102);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(85, 17);
            this.radioButton5.TabIndex = 8;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 38);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(85, 17);
            this.radioButton4.TabIndex = 7;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(416, 32);
            this.label5.TabIndex = 6;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(6, 221);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(85, 17);
            this.radioButton6.TabIndex = 9;
            this.radioButton6.Text = "radioButton6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(416, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "desc1";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(416, 32);
            this.label7.TabIndex = 11;
            this.label7.Text = "desc2";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(416, 32);
            this.label8.TabIndex = 12;
            this.label8.Text = "desc3";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(416, 32);
            this.label9.TabIndex = 13;
            this.label9.Text = "desc4";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(416, 32);
            this.label10.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(416, 32);
            this.label13.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(416, 32);
            this.label14.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(416, 238);
            this.label15.TabIndex = 3;
            // 
            // SVSWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(618, 400);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SVSWizard";
            this.Text = "";
            this.TitleLabel = "";
            this.pnlBottom.ResumeLayout(false);
            this.PanelContenerTabs.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.tabPageStep1.PerformLayout();
            this.tabPageStep2.ResumeLayout(false);
            this.tabPageStep2.PerformLayout();
            this.tabPageStep3.ResumeLayout(false);
            this.tabPageStep4.ResumeLayout(false);
            this.tabPageStep5.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private void xpBack_Click(object sender, System.EventArgs e)
        {
            if (this.btnBack.Text != ResourceInitializer.BUTTON_NEXT)
            {
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                int currentPage = this.wizardTabControl1.SelectedIndex;

                --this.wizardTabControl1.SelectedIndex;                

                if(currentPage == 3 && !this.radioButton2.Checked) {
                    if(this.radioButton3.Checked) {
                        this.wizardTabControl1.SelectedIndex = 1;
                    } else {
                        this.wizardTabControl1.SelectedIndex = 0;
                    }
                }

                if (currentPage == 2 && !this.radioButton3.Checked)
                {
                    this.wizardTabControl1.SelectedIndex = 0;
                }

                if (this.wizardTabControl1.SelectedIndex == 0)
                {
                    this.btnBack.Enabled = false;
                    this.Height = NORM_HEIGHT;
                }

                this.nextpage = this.wizardTabControl1.SelectedIndex;
                this.btnNext.Enabled = true;
            }
            else
            {
            }
        }

        private void xpNext_Click(object sender, System.EventArgs e)
        {
            if (this.btnNext.Text == ResourceInitializer.BUTTON_FINISH)
            {
                saveCode();
                this.do_exit();
            }
            else
            {
                this.manageStartPage();                
                switch (this.nextpage)
                {
                    case 0:
                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.Height = NORM_HEIGHT;
                        this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
                        this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                        this.btnBack.Enabled = false;
                        this.btnNext.Enabled = true;
                        break;

                    case 1:
                        if (this.radioButton2.Checked)
                        {
                            this.nextpage = 2;
                        } 
                        else if(this.radioButton3.Checked) 
                        {
                            this.nextpage = 1;
                        } 
                        else
                        {
                            this.nextpage = 3;
                            setupCode();
                        }

                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.btnBack.Enabled = true;
                        this.btnNext.Enabled = true;                        
                        break;

                    case 2:
                        if (this.radioButton3.Checked) 
                        {
                            this.nextpage = 3;
                            setupCode();
                        }

                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.Height = NORM_HEIGHT;
                        this.btnBack.Enabled = true;
                        this.btnNext.Enabled = true;
                        break;

                    case 3:
                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.Height = NORM_HEIGHT;
                        setupCode(); 
                        break;
                    case 4:
                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.Height = NORM_HEIGHT;
                        this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;        
                        break;
                }
            }
        }

        private void manageStartPage()
        {
            if (++this.nextpage > 4)
                this.nextpage = 0;
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

            Jedox.Palo.XlAddin.Forms.ChooseElements frmename = new Jedox.Palo.XlAddin.Forms.ChooseElements(this.ActiveHostname + "/" + this.ActiveDB, (string)b.Tag);
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
            if (!this.finishing) this.do_exit();
        }

        public void do_exit()
        {
            this.finishing = false;
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
            this.ResumeLayout(false);

            this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
            this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            this.btnFinish.Text = ResourceInitializer.BUTTON_CANCEL;
            this.btnBack.Enabled = false;
            this.wizardTabControl1.SelectedIndex = this.nextpage = 0;
        }

        private void setupCode()
        {
            codeWindow.ResetText();

            string code;
            code = "<?php\n";
            code += "class SEPEventHandler extends SEPEventHandlerBase\n";
            code += "{\n";
            code += "\tpublic function OnUserLogin($username) {\n";
            code += "\t\tsep_log(\"<< User logged in: $username >>\");\n";
            code += "\t}\n\n";

            code += "\tpublic function OnUserLogout($username) {\n";
            code += "\t\tsep_log(\"<< User logged out: $username >>\");\n";
            code += "\t}\n\n";

            code += "\tpublic function OnUserAuthenticate($username, $password) {\n";
            code += "\t\tsep_log(\"<< User authenticate >>\");\n";
            code += "\t\treturn true;\n";
            code += "\t}\n\n";

            code += "\tpublic function OnUserAuthorize($username, $password, array& $groups) {\n";
            code += "\t\tsep_log(\"<< User authorize >>\");\n";
            code += "\t\treturn true;\n";
            code += "\t}\n\n";

            code += "\tpublic function OnServerShutdown() {\n";
            code += "\t\tsep_log(\"<< Server shutdown handler >>\")\n";
            code += "\t}\n\n";

            code += "\tpublic function OnDatabaseSaved($database) {\n";
            code += "\t\tsep_log(\"<< Databased saved : $database >>\");\n";
            code += "\t}\n\n";

            code += "\tpublic function OnTermination() {\n";
            code += "\t\tsep_log(\"<< Termination handler >>\");\n";
            code += "\t}\n\n";

            // data mode
            code += "\tpublic function OnCellChange($database,$cube) {\n";
            if (this.radioButton2.Checked)
            {
                code += "\t\tif($database == \"" + this.ActiveDB + "\")\n";
                code += "\t\t{\n";
                code += "\t\t\tif($cube == \"" + this.ActiveCube + "\")\n";
                code += "\t\t\t{\n";
                code += "\t\t\t\t$AreaA = array(";
                for (int i = 0; i < this.SelectedElements.Count; i++)
                {
                    object[] o = (object[])this.SelectedElements[i];
                    ArrayList objs = (ArrayList)o[1];

                    if (objs.Count > 0)
                    {
                        code += "array(";
                        foreach (object[] obj in objs)
                        {
                            code += "\"" + obj[0] + "\",";
                        }

                        // remove the last ,
                        code = code.Substring(0, code.Length - 1);
                        code += "),";
                    }
                    else
                    {
                        code += "DIMENSION_TOTAL,";
                    }
                }
                code = code.Substring(0, code.Length - 1); // remove the last ,
                code += ");\n";
                code += "\t\t\t\t$this->SensitizeArea($AreaA,'CallbackFunction');\n";
                code += "\t\t\t}\n";
                code += "\t\t}\n";
            }
            code += "\t\tsep_log(\"<< OnCellChange >>\");\n";
            code += "\t}\n\n";
            code += "\tpublic function OnDrillThrough( $database, $cube, $mode, $arg ) {\n";
            code += "\t\tsep_log(\"<< OnDrillThrough >>\");\n";
            code += "\t\treturn \"not implemented;\\r\\n\"\n";
            code += "\t}\n";
            code += "}\n\n";

            if (this.radioButton2.Checked)
            {
                code += "function CallbackFunction($database, $cube, $areaid, $sid2, $coordinates, $value) {\n";
                code += "\t// todo, insert your code here\n";
                code += "}\n";
            }
            code += "?>";

            SyntaxDocument sd = new SyntaxDocument();
            sd.InsertText(code, 0, 0, false);
            codeWindow.AttachDocument(sd);
            codeWindow.Refresh();

            CodeEditorSyntaxLoader.SetSyntax(codeWindow, SyntaxLanguage.PHP);
        }

        void saveCode()
        {
            SaveFileDialog DialogSave = new SaveFileDialog();
            DialogSave.DefaultExt = "php";
            DialogSave.Filter = "PHP file (*.php)|*.php";
            DialogSave.AddExtension = true;
            DialogSave.Title = "Please select your SVS script folder";
            DialogSave.InitialDirectory = @"C:/";

            if (DialogSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TextWriter tw = new StreamWriter(DialogSave.FileName);
                    tw.Write(codeWindow.Document.Text);
                    tw.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //saveCode();
            }
            DialogSave.Dispose();
            DialogSave = null;
        }
    }
}