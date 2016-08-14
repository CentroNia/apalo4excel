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
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using JControls;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Utils;


namespace Apalo.XlAddin.Forms
{
    [ComVisible(false)]
    public  class PaloWizard : WizardDialogForm
    {

        private const int START_PAGE = 0;
        private const int CREATE_DATABASE = 1;
        private const int DELETE_DATABASE = 2;
        private const int REGISTER_SERVER = 3;
        private const int CREATE_DATABASE_FROM_TEMPLATE = 4;
        private const int UNREGISTER_SERVER = 5;
        private const int EDIT_SERVER = 6;
        private const string PALOWIZRAD = "PaloWizard";

        # region Variable Define

        public bool changesMade;
        public string changesAction = "";
        public string changesServerName = "";

        private System.Windows.Forms.Button xpConnect;
        private bool inTab;
        private bool doedit;

        private string oldconnection = "";
        private string oldhostname = "";
        private string oldservice = "";
        private string oldusername = "";
        private string oldpasswd = "";

       
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.TabPage tabStart;
        private System.Windows.Forms.ComboBox comboServers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label29;
      
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button xpButton1;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ListBox tplList;
        private System.Windows.Forms.ToolTip toolTip;
        private TabPageStep tabCreateDatabase;
        private TabPageStep tabRegisterServer;
        private TabPageStep tabDeleteDatabase;
        private TabPageStep tabCreateDatabaseTpl;
        private TabPageStep tabDummyUnregister;
       
        private Label label20;
        private Label label10;
        private Label label15;
        private Label label6;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private RadioButton radioButtonWindowsAuth;
        private RadioButton radioButtonPaloAuth;
        private Label label31;
        private Label label30;
        private TextBox textBox5;
        private TextBox textBox6;
        private CheckBox xpCheckBox1;
        private System.Windows.Forms.TextBox textBox7;

        # endregion

        #region Construct/Dispose
        public PaloWizard()
        {
            #region Init

            InitializeComponent();
            this.wizardTabControl1.SelectTab(0);
            base.SetBtns((TabPageStep)this.wizardTabControl1.SelectedTab);
            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.pnlBottom.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PanelContenerTabs.BackColor = ResourceInitializer.FormStdBackgroundColor;
      
            //this.EtchedLine.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnBack.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnFinish.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnNext.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;

            this.xpConnect.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.xpButton1.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.tabPageStep1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabRegisterServer.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabCreateDatabase.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabDeleteDatabase.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabCreateDatabaseTpl.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabDummyUnregister.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.panel1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.panel2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.panel3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label4.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label5.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label6.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label7.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label8.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label9.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label10.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label11.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label12.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label13.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label14.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label15.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label16.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label18.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label19.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label20.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label23.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label24.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label25.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label26.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label27.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label28.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label29.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label30.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label31.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label32.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton4.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton5.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton6.BackColor = ResourceInitializer.FormStdBackgroundColor;

            this.setCombo();

            this.LeftPanelImage = ResourceInitializer.WizardLogo;

            this.label1.Text = ResourceInitializer.WIZARD_LABEL1;
            this.label2.Text = ResourceInitializer.WIZARD_LABEL2;
            this.label3.Text = ResourceInitializer.WIZARD_LABEL3;
            this.label4.Text = ResourceInitializer.WIZARD_LABEL4;
            this.label5.Text = ResourceInitializer.WIZARD_LABEL5;
            this.label7.Text = ResourceInitializer.WIZARD_LABEL7;
            this.label8.Text = ResourceInitializer.WIZARD_LABEL8;
            this.label9.Text = ResourceInitializer.ServerDNSNameOrIP;
            this.label29.Text = ResourceInitializer.WIZARD_LABEL29;
            this.label32.Text = ResourceInitializer.WIZARD_LABEL32;
            this.label30.Text = ResourceInitializer.WIZARD_LABEL30;
            this.label31.Text = ResourceInitializer.WIZARD_LABEL31;
            this.label16.Text = ResourceInitializer.WIZARD_LABEL16;
            this.label18.Text = ResourceInitializer.WIZARD_LABEL18;
            this.label19.Text = ResourceInitializer.WIZARD_LABEL19;
            this.label13.Text = ResourceInitializer.WIZARD_LABEL13;
            this.label12.Text = ResourceInitializer.WIZARD_LABEL12;
            this.label11.Text = ResourceInitializer.WIZARD_LABEL19;

            this.xpButton1.Text = ResourceInitializer.BUTTON_TEST_CONNECTION;
            this.xpCheckBox1.Text = ResourceInitializer.LABEL_LOGON_DATA;

            this.Text =  ResourceInitializer.WIZARD_TITLE;
            this.TitleLabel = ResourceInitializer.WIZARD_PAGE_TITLE;

            this.xpConnect.Text = ResourceInitializer.BUTTON_CONNECT;
            this.toolTip.SetToolTip(this.xpConnect, ResourceInitializer.TIP_BUTTON_TOGGLE_CONNECTION);

            this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            this.toolTip.SetToolTip(this.btnNext, ResourceInitializer.TIP_STEP_NEXT);

            this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
            this.toolTip.SetToolTip(this.btnBack, ResourceInitializer.TIP_STEP_BACK);

            this.btnFinish.Text = ResourceInitializer.BUTTON_CLOSE;
            this.toolTip.SetToolTip(this.btnFinish, ResourceInitializer.TIP_BUTTON_CLOSE_WIZARD);

            this.toolTip.SetToolTip(this.comboServers, ResourceInitializer.TIP_CHOOSE_SERVER);
            this.toolTip.SetToolTip(this.comboBox1, ResourceInitializer.TIP_CHOOSE_DATABASE);

            this.radioButton1.Text = ResourceInitializer.WIZARD_OPTION1;
            this.radioButton2.Text = ResourceInitializer.WIZARD_OPTION2;
            this.radioButton3.Text = ResourceInitializer.WIZARD_OPTION3;
            this.radioButton4.Text = ResourceInitializer.WIZARD_OPTION4;
            this.radioButton5.Text = ResourceInitializer.WIZARD_OPTION5;
            this.radioButton6.Text = ResourceInitializer.WIZARD_OPTION6;
            this.radioButtonPaloAuth.Text = ResourceInitializer.WizardPaloAuthentication;
            this.radioButtonWindowsAuth.Text = ResourceInitializer.WizardWindowsAuthentication;
            this.toolTip.SetToolTip(this.radioButtonWindowsAuth, ResourceInitializer.TipSVS);

            this.label20.Text = this.label3.Text;
            this.label10.Text = this.comboServers.Text;

            this.label6.Text = this.label3.Text;
            this.label15.Text = this.comboServers.Text;


            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);

            this.checkxpButton1();

            #region Handling restore form's size/position
            this.MinimumSize = new System.Drawing.Size(680, 425);
            int[] tmpProps = RegUtils.GetFormProperties(PALOWIZRAD);
            if (tmpProps[0] != -1)
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Size = new System.Drawing.Size(tmpProps[2], tmpProps[3]);
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
                this.StartPosition = FormStartPosition.Manual;
            }
            else
            {
                this.Size = new System.Drawing.Size(680, 425);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            #endregion

            #endregion

        }
       

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaloWizard));
            this.tabCreateDatabase = new JControls.TabPageStep();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabRegisterServer = new JControls.TabPageStep();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.radioButtonWindowsAuth = new System.Windows.Forms.RadioButton();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.radioButtonPaloAuth = new System.Windows.Forms.RadioButton();
            this.label32 = new System.Windows.Forms.Label();
            this.xpCheckBox1 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.xpButton1 = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabDeleteDatabase = new JControls.TabPageStep();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabCreateDatabaseTpl = new JControls.TabPageStep();
            this.label28 = new System.Windows.Forms.Label();
            this.tplList = new System.Windows.Forms.ListBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tabDummyUnregister = new JControls.TabPageStep();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.xpConnect = new System.Windows.Forms.Button();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.comboServers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlBottom.SuspendLayout();
            this.PanelContenerTabs.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.tabCreateDatabase.SuspendLayout();
            this.tabRegisterServer.SuspendLayout();
            this.tabDeleteDatabase.SuspendLayout();
            this.tabCreateDatabaseTpl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(3, 364);
            this.pnlBottom.Size = new System.Drawing.Size(518, 35);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFinish.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnFinish.Location = new System.Drawing.Point(429, 4);
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 102;
            this.btnFinish.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.Enabled = false;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBack.Location = new System.Drawing.Point(235, 4);
            this.btnBack.Size = new System.Drawing.Size(80, 24);
            this.btnBack.TabIndex = 100;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.xpBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.Enabled = false;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNext.Location = new System.Drawing.Point(323, 4);
            this.btnNext.Size = new System.Drawing.Size(80, 23);
            this.btnNext.TabIndex = 101;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.xpNext_Click);
            // 
            // PanelContenerTabs
            // 
            this.PanelContenerTabs.BackColor = System.Drawing.SystemColors.Control;
            this.PanelContenerTabs.Size = new System.Drawing.Size(520, 402);
            // 
            // wizardTabControl1
            // 
            this.wizardTabControl1.Controls.Add(this.tabCreateDatabase);
            this.wizardTabControl1.Controls.Add(this.tabDeleteDatabase);
            this.wizardTabControl1.Controls.Add(this.tabRegisterServer);
            this.wizardTabControl1.Controls.Add(this.tabCreateDatabaseTpl);
            this.wizardTabControl1.Controls.Add(this.tabDummyUnregister);
            this.wizardTabControl1.Size = new System.Drawing.Size(515, 318);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabDummyUnregister, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabCreateDatabaseTpl, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabRegisterServer, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabDeleteDatabase, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabCreateDatabase, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep1, 0);
            // 
            // tabPageStep1
            // 
            this.tabPageStep1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep1.Controls.Add(this.xpConnect);
            this.tabPageStep1.Controls.Add(this.radioButton6);
            this.tabPageStep1.Controls.Add(this.radioButton5);
            this.tabPageStep1.Controls.Add(this.radioButton4);
            this.tabPageStep1.Controls.Add(this.label5);
            this.tabPageStep1.Controls.Add(this.radioButton3);
            this.tabPageStep1.Controls.Add(this.radioButton2);
            this.tabPageStep1.Controls.Add(this.radioButton1);
            this.tabPageStep1.Controls.Add(this.label4);
            this.tabPageStep1.Controls.Add(this.comboServers);
            this.tabPageStep1.Controls.Add(this.label3);
            this.tabPageStep1.Controls.Add(this.label2);
            this.tabPageStep1.Controls.Add(this.label1);
            this.tabPageStep1.Size = new System.Drawing.Size(507, 292);
            this.tabPageStep1.Text = "step1";
            // 
            // tabCreateDatabase
            // 
            this.tabCreateDatabase.BackColor = System.Drawing.SystemColors.Control;
            this.tabCreateDatabase.Controls.Add(this.label10);
            this.tabCreateDatabase.Controls.Add(this.label20);
            this.tabCreateDatabase.Controls.Add(this.textBox2);
            this.tabCreateDatabase.Controls.Add(this.label11);
            this.tabCreateDatabase.Controls.Add(this.label12);
            this.tabCreateDatabase.Controls.Add(this.label13);
            this.tabCreateDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabCreateDatabase.Name = "tabCreateDatabase";
            this.tabCreateDatabase.ShowBackButton = true;
            this.tabCreateDatabase.ShowFinishButton = true;
            this.tabCreateDatabase.ShowNextButton = true;
            this.tabCreateDatabase.Size = new System.Drawing.Size(507, 292);
            this.tabCreateDatabase.TabIndex = 10;
            this.tabCreateDatabase.Text = "step2";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(146, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(202, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "localhost";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(40, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 23);
            this.label20.TabIndex = 1;
            this.label20.Text = "server";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(148, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 11;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(40, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 12;
            this.label11.Text = "database:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(472, 24);
            this.label12.TabIndex = 13;
            this.label12.Text = "Enter an unique name for the new database.";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(496, 32);
            this.label13.TabIndex = 14;
            // 
            // tabRegisterServer
            // 
            this.tabRegisterServer.BackColor = System.Drawing.SystemColors.Control;
            this.tabRegisterServer.Controls.Add(this.label31);
            this.tabRegisterServer.Controls.Add(this.label30);
            this.tabRegisterServer.Controls.Add(this.textBox5);
            this.tabRegisterServer.Controls.Add(this.radioButtonWindowsAuth);
            this.tabRegisterServer.Controls.Add(this.textBox6);
            this.tabRegisterServer.Controls.Add(this.radioButtonPaloAuth);
            this.tabRegisterServer.Controls.Add(this.label32);
            this.tabRegisterServer.Controls.Add(this.xpCheckBox1);
            this.tabRegisterServer.Controls.Add(this.textBox7);
            this.tabRegisterServer.Controls.Add(this.xpButton1);
            this.tabRegisterServer.Controls.Add(this.label29);
            this.tabRegisterServer.Controls.Add(this.textBox4);
            this.tabRegisterServer.Controls.Add(this.label9);
            this.tabRegisterServer.Controls.Add(this.textBox1);
            this.tabRegisterServer.Controls.Add(this.label8);
            this.tabRegisterServer.Controls.Add(this.label7);
            this.tabRegisterServer.Location = new System.Drawing.Point(4, 22);
            this.tabRegisterServer.Name = "tabRegisterServer";
            this.tabRegisterServer.ShowBackButton = true;
            this.tabRegisterServer.ShowFinishButton = true;
            this.tabRegisterServer.ShowNextButton = true;
            this.tabRegisterServer.Size = new System.Drawing.Size(507, 292);
            this.tabRegisterServer.TabIndex = 40;
            this.tabRegisterServer.Text = "step3";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(42, 218);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(126, 23);
            this.label31.TabIndex = 48;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(42, 192);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(126, 23);
            this.label30.TabIndex = 49;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(168, 189);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(200, 20);
            this.textBox5.TabIndex = 44;
            // 
            // radioButtonWindowsAuth
            // 
            this.radioButtonWindowsAuth.AutoSize = true;
            this.radioButtonWindowsAuth.Location = new System.Drawing.Point(27, 269);
            this.radioButtonWindowsAuth.Name = "radioButtonWindowsAuth";
            this.radioButtonWindowsAuth.Size = new System.Drawing.Size(145, 17);
            this.radioButtonWindowsAuth.TabIndex = 56;
            this.radioButtonWindowsAuth.TabStop = true;
            this.radioButtonWindowsAuth.Text = "radioButtonWindowsAuth";
            this.radioButtonWindowsAuth.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(168, 215);
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '*';
            this.textBox6.Size = new System.Drawing.Size(200, 20);
            this.textBox6.TabIndex = 45;
            // 
            // radioButtonPaloAuth
            // 
            this.radioButtonPaloAuth.AutoSize = true;
            this.radioButtonPaloAuth.Location = new System.Drawing.Point(27, 162);
            this.radioButtonPaloAuth.Name = "radioButtonPaloAuth";
            this.radioButtonPaloAuth.Size = new System.Drawing.Size(122, 17);
            this.radioButtonPaloAuth.TabIndex = 55;
            this.radioButtonPaloAuth.TabStop = true;
            this.radioButtonPaloAuth.Text = "radioButtonPaloAuth";
            this.radioButtonPaloAuth.UseVisualStyleBackColor = true;
            this.radioButtonPaloAuth.CheckedChanged += new System.EventHandler(this.radioButtonPaloAuth_CheckedChanged);
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(27, 75);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(141, 23);
            this.label32.TabIndex = 0;
            // 
            // xpCheckBox1
            // 
            this.xpCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.xpCheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpCheckBox1.Location = new System.Drawing.Point(168, 241);
            this.xpCheckBox1.Name = "xpCheckBox1";
            this.xpCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xpCheckBox1.Size = new System.Drawing.Size(328, 24);
            this.xpCheckBox1.TabIndex = 46;
            this.xpCheckBox1.UseVisualStyleBackColor = false;
            this.xpCheckBox1.CheckedChanged += new System.EventHandler(this.xpCheckBox1_CheckedChanged);
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(168, 72);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(200, 20);
            this.textBox7.TabIndex = 41;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // xpButton1
            // 
            this.xpButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.xpButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpButton1.Location = new System.Drawing.Point(369, 269);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(126, 23);
            this.xpButton1.TabIndex = 47;
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(27, 139);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(141, 23);
            this.label29.TabIndex = 50;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(168, 136);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(200, 20);
            this.textBox4.TabIndex = 43;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 16);
            this.label9.TabIndex = 51;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(168, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 42;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(472, 24);
            this.label8.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(496, 32);
            this.label7.TabIndex = 53;
            // 
            // tabDeleteDatabase
            // 
            this.tabDeleteDatabase.BackColor = System.Drawing.SystemColors.Control;
            this.tabDeleteDatabase.Controls.Add(this.label15);
            this.tabDeleteDatabase.Controls.Add(this.label6);
            this.tabDeleteDatabase.Controls.Add(this.label19);
            this.tabDeleteDatabase.Controls.Add(this.comboBox1);
            this.tabDeleteDatabase.Controls.Add(this.label18);
            this.tabDeleteDatabase.Controls.Add(this.label16);
            this.tabDeleteDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDeleteDatabase.Name = "tabDeleteDatabase";
            this.tabDeleteDatabase.ShowBackButton = true;
            this.tabDeleteDatabase.ShowFinishButton = true;
            this.tabDeleteDatabase.ShowNextButton = true;
            this.tabDeleteDatabase.Size = new System.Drawing.Size(507, 292);
            this.tabDeleteDatabase.TabIndex = 30;
            this.tabDeleteDatabase.Text = "step4";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(145, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(203, 23);
            this.label15.TabIndex = 0;
            this.label15.Text = "localhost";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Server:";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(40, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 23);
            this.label19.TabIndex = 2;
            this.label19.Text = "database:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.Location = new System.Drawing.Point(148, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 31;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(24, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(472, 23);
            this.label18.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(504, 23);
            this.label16.TabIndex = 33;
            // 
            // tabCreateDatabaseTpl
            // 
            this.tabCreateDatabaseTpl.BackColor = System.Drawing.SystemColors.Control;
            this.tabCreateDatabaseTpl.Controls.Add(this.label28);
            this.tabCreateDatabaseTpl.Controls.Add(this.tplList);
            this.tabCreateDatabaseTpl.Controls.Add(this.label27);
            this.tabCreateDatabaseTpl.Controls.Add(this.label26);
            this.tabCreateDatabaseTpl.Controls.Add(this.label25);
            this.tabCreateDatabaseTpl.Controls.Add(this.textBox3);
            this.tabCreateDatabaseTpl.Controls.Add(this.label14);
            this.tabCreateDatabaseTpl.Controls.Add(this.label24);
            this.tabCreateDatabaseTpl.Controls.Add(this.label23);
            this.tabCreateDatabaseTpl.Location = new System.Drawing.Point(4, 22);
            this.tabCreateDatabaseTpl.Name = "tabCreateDatabaseTpl";
            this.tabCreateDatabaseTpl.ShowBackButton = true;
            this.tabCreateDatabaseTpl.ShowFinishButton = true;
            this.tabCreateDatabaseTpl.ShowNextButton = true;
            this.tabCreateDatabaseTpl.Size = new System.Drawing.Size(507, 292);
            this.tabCreateDatabaseTpl.TabIndex = 20;
            this.tabCreateDatabaseTpl.Text = "step5";
            // 
            // label28
            // 
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Location = new System.Drawing.Point(280, 176);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(216, 112);
            this.label28.TabIndex = 0;
            // 
            // tplList
            // 
            this.tplList.Location = new System.Drawing.Point(48, 176);
            this.tplList.Name = "tplList";
            this.tplList.Size = new System.Drawing.Size(216, 108);
            this.tplList.TabIndex = 22;
            this.tplList.SelectedIndexChanged += new System.EventHandler(this.tplList_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(280, 160);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(72, 16);
            this.label27.TabIndex = 23;
            this.label27.Text = "Description:";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(48, 160);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 16);
            this.label26.TabIndex = 24;
            this.label26.Text = "Template:";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(24, 128);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(224, 16);
            this.label25.TabIndex = 25;
            this.label25.Text = "2. Chose a database template";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(128, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 20);
            this.textBox3.TabIndex = 21;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(48, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 23);
            this.label14.TabIndex = 26;
            this.label14.Text = "database:";
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(24, 40);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(312, 32);
            this.label24.TabIndex = 27;
            this.label24.Text = "1. Enter an unique name for the new database.";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 8);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(408, 32);
            this.label23.TabIndex = 28;
            this.label23.Text = "In this step you will create new database on the selected server.";
            // 
            // tabDummyUnregister
            // 
            this.tabDummyUnregister.BackColor = System.Drawing.SystemColors.Control;
            this.tabDummyUnregister.Location = new System.Drawing.Point(4, 22);
            this.tabDummyUnregister.Name = "tabDummyUnregister";
            this.tabDummyUnregister.ShowBackButton = true;
            this.tabDummyUnregister.ShowFinishButton = true;
            this.tabDummyUnregister.ShowNextButton = true;
            this.tabDummyUnregister.Size = new System.Drawing.Size(507, 292);
            this.tabDummyUnregister.TabIndex = 50;
            this.tabDummyUnregister.Text = "step6";
            // 
            // xpConnect
            // 
            this.xpConnect.BackColor = System.Drawing.SystemColors.Control;
            this.xpConnect.Enabled = false;
            this.xpConnect.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.xpConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpConnect.Location = new System.Drawing.Point(352, 72);
            this.xpConnect.Name = "xpConnect";
            this.xpConnect.Size = new System.Drawing.Size(80, 24);
            this.xpConnect.TabIndex = 2;
            this.xpConnect.UseVisualStyleBackColor = false;
            this.xpConnect.Click += new System.EventHandler(this.xpConnect_Click);
            // 
            // radioButton6
            // 
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6.Location = new System.Drawing.Point(48, 270);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(384, 24);
            this.radioButton6.TabIndex = 8;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.Enabled = false;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton5.Location = new System.Drawing.Point(48, 249);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(384, 24);
            this.radioButton5.TabIndex = 7;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(48, 228);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(384, 24);
            this.radioButton4.TabIndex = 6;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(400, 23);
            this.label5.TabIndex = 9;
            // 
            // radioButton3
            // 
            this.radioButton3.Enabled = false;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(48, 166);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(376, 24);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Enabled = false;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(48, 145);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(376, 24);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Enabled = false;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(48, 125);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(376, 24);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(400, 23);
            this.label4.TabIndex = 10;
            // 
            // comboServers
            // 
            this.comboServers.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.comboServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboServers.Location = new System.Drawing.Point(128, 72);
            this.comboServers.Name = "comboServers";
            this.comboServers.Size = new System.Drawing.Size(200, 21);
            this.comboServers.TabIndex = 1;
            this.comboServers.SelectedIndexChanged += new System.EventHandler(this.comboServers_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 23);
            this.label2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 32);
            this.label1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.panel1.Location = new System.Drawing.Point(160, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 8);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.panel2.Location = new System.Drawing.Point(160, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 322);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.panel3.Location = new System.Drawing.Point(664, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 325);
            this.panel3.TabIndex = 7;
            // 
            // PaloWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnFinish;
            this.ClientSize = new System.Drawing.Size(674, 400);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaloWizard";
            this.Load += new System.EventHandler(this.frmWiz_Load);
            this.VisibleChanged += new System.EventHandler(this.frmWiz_VisibleChanged);
            this.pnlBottom.ResumeLayout(false);
            this.PanelContenerTabs.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.tabCreateDatabase.ResumeLayout(false);
            this.tabCreateDatabase.PerformLayout();
            this.tabRegisterServer.ResumeLayout(false);
            this.tabRegisterServer.PerformLayout();
            this.tabDeleteDatabase.ResumeLayout(false);
            this.tabCreateDatabaseTpl.ResumeLayout(false);
            this.tabCreateDatabaseTpl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region Set Combo Boxes

        private void setCombo(string SelectedValue)
        {
            try
            {
                XmlUtils.ReadXmlInitial();
                DataTable myDt = XmlUtils.dsConnectionsTable;
                this.comboServers.DisplayMember = "name";
                this.comboServers.ValueMember = "name";
                this.comboServers.DataSource = myDt;
                if (!string.IsNullOrEmpty(SelectedValue))
                {
                    this.comboServers.SelectedValue = SelectedValue;
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error Reading List Items.", exc);
            }
        }

        private void setCombo()
        {
            setCombo("");
        }


        private void setComboDb(String ConnName)
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Text = "Click here to select the database...";

            try
            {
                Connection c = Connections.GetConnection(ConnName);
                string[] dbL = c.RootListDatabases(DatabaseType.NormalDatabase);

                foreach (string dbN in dbL)
                {
                    this.comboBox1.Items.Add(dbN);
                }

                if (this.comboBox1.Items.Count > 0)
                {
                    this.comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error Reading List Items.", exc);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.btnNext.Enabled = true;
        }

        #endregion

        # region Add/Delete helper functions

        private void ChangeDataRow(ref DataRow r, int id, string name, string hostname, string service, bool connected, string username, string password, bool usewinauth)
        {
            if (id > -1)
            {
                r["id"] = id;
            }
            r["name"] = name;
            r["hostname"] = hostname;
            r["service"] = service;
            r["connected"] = (connected) ? Boolean.TrueString : Boolean.FalseString;
            r["username"] = username;
            r["password"] = password;
            r["offline"] = Boolean.FalseString;
            r["usewinauth"] = (usewinauth) ? Boolean.TrueString : Boolean.FalseString;

        }

        private bool IsConnected(string name, string hostname, string service, ref string username, ref string password, bool keepLoginData, bool create)
        {
            bool connected = false;

            if (username.Length != 0 && password.Length != 0)
            {
                Connection con = Connections.GetConnection(hostname, service, username, password, name);

                if (con != null)
                {
                    this.changesMade = true;
                    Connect.changesMade = true;
                    this.changesAction = (create) ? "create" : "edit";
                    this.changesServerName = name;
                    if (create)
                    {
                        List<string> dbs = ConnectionsHelper.getListDB(con, ConnectionsHelper.HandleDatabase.WithoutSystem);
                        RegUtils.ActiveConnection = name;
                        RegUtils.ActiveDB = (dbs.Count == 0) ? "" : dbs[0];
                        RegUtils.ActiveCube = "";
                    }
                    connected = true;
                }
            }

            if (keepLoginData == false)
            {
                username = "";
                password = "";
            }

            return connected;
        }
        

        private bool addServer(string hostname, string service, string name, string username, string password, bool keepLoginData, bool usewinauth)
        {
            try
            {
                bool connected = IsConnected(name, hostname, service, ref username, ref password, keepLoginData, true);
                DataTable conntab = XmlUtils.dsConnectionsTable;

                int tmpRowCount = conntab.Rows.Count;

                int i, maxid = 0, currid;

                for (i = 0; i < tmpRowCount; i++)
                {
                    currid = ((int)(conntab.Rows[i]["id"]));
                    if (currid > maxid)
                    {
                        maxid = currid;
                    }

                }


                DataRow newRow = conntab.NewRow();

                ChangeDataRow(ref newRow, maxid + 1, name, hostname, service, connected, username, password, usewinauth);

                conntab.Rows.Add(newRow);
                XmlUtils.WriteConnections();

                return true;
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error registering server!", e);
                return false;
            }
        }

        private bool editServer(string hostname, string service, string name, string username, string password, bool keepLoginData, bool usewinauth)
        {
            try
            {

                bool ConnectionNameHasChanged = (this.oldconnection != name);

                if (ConnectionNameHasChanged || (this.oldhostname != hostname) || (this.oldservice != service) || (this.oldusername != username) || (this.oldpasswd != password))
                {
                    Connections.CloseConnection(oldconnection);
                    if (ConnectionNameHasChanged)
                    {
                        Connections.CloseConnection(name);
                    }
                }

                bool connected = IsConnected(name, hostname, service, ref username, ref password, keepLoginData, false);

                if (username.Length != 0 && password.Length != 0)
                {
                    if (Connections.GetConnection(hostname, service, username, password, name) != null)
                    {
                        this.changesMade = true;
                        Connect.changesMade = true;
                        this.changesAction = "edit";
                        this.changesServerName = name;
                        connected = true;
                    }
                }

                if (keepLoginData == false)
                {
                    username = "";
                    password = "";
                }

                DataRow foundRow = XmlUtils.dsConnectionsTable.Rows.Find(oldconnection);

                ChangeDataRow(ref foundRow, -1, name, hostname, service, connected, username, password, usewinauth);

                XmlUtils.WriteConnections();

                return true;
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error registering server!", e);
                return false;
            }
        }

        private static bool addDatabase(string ConnName, string dbName)
        {
            try
            {
                Connection c = Connections.GetConnection(ConnName);
                c.AddDatabase(dbName);
                c.DatabaseSave(dbName);
                c.Ping();
                RegUtils.ActiveDB = dbName;
                return true;
            }
            catch (PaloException e)
            {
                if ((e.ErrorCode == -20) || (e.ErrorCode == 2004))
                {
                    MessageBox.Show(ResourceInitializer.ERROR_DATABASE_EXISTS, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if ((e.ErrorCode == -68) || (e.ErrorCode == 2000))
                    {
                        MessageBox.Show(ResourceInitializer.ERROR_DATABASE_INVALID_NAME, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show(e.Message, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                        ErrorHandler.DisplayError("Error adding database!", e);
                    }
                }
                return false;
            }
        }

        // delete specific database
        private static bool delDatabase(String ConnName, string dbName)
        {
            try
            {
                Connection c = Connections.GetConnection(ConnName);
                c.DeleteDatabase(dbName);
                c.Ping();
                return true;
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error deleting database!", e);
                return false;
            }
        }

        private bool unregisterServer(string connName)
        {
            try
            {
                string newconn = RegUtils.ActiveConnection;
                if (string.Equals(RegUtils.ActiveConnection, connName, StringComparison.InvariantCultureIgnoreCase))
                {
                    int newindex = -1, currindex = this.comboServers.SelectedIndex, count = this.comboServers.Items.Count;

                    if ((currindex + 1) < count)
                    {
                        newindex = currindex + 1;
                    }
                    else
                    {
                        if ((currindex - 1) > -1)
                        {
                            newindex = currindex - 1;
                        }
                    }

                    if (newindex > -1)
                    {
                        newconn = this.comboServers.GetItemText(this.comboServers.Items[newindex]);
                    }
                }


                DataTable delTable = XmlUtils.dsConnectionsTable;
                DataRow foundRow = delTable.Rows.Find(connName);
                delTable.Rows.Remove(foundRow);
                XmlUtils.WriteConnections();
                RegUtils.ActiveConnection = newconn;
                Connections.CloseConnection(connName);
                return true;
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error unregistering server " + connName + "!", e);
                return false;
            }
        }

        #endregion

        # region Manage switching between tabs

        private void manageStartPage()
        {
            if (this.radioButton1.Checked == true)
            {
                this.wizardTabControl1.SelectedIndex = CREATE_DATABASE;
            }
            /*else if( this.radioButton2.Checked == true )
            {
                this.WizardPages.SelectedIndex = CREATE_DATABASE_FROM_TEMPLATE ;
            }*/
            else if (this.radioButton3.Checked == true)
            {
                this.wizardTabControl1.SelectedIndex = DELETE_DATABASE;
            }
            else if (this.radioButton4.Checked == true)
            {
                this.label7.Text = ResourceInitializer.WIZARD_LABEL7;
                this.doedit = false;
                this.wizardTabControl1.SelectedIndex = REGISTER_SERVER;
            }
            else if (this.radioButton5.Checked == true)
            {
                this.wizardTabControl1.SelectedIndex = UNREGISTER_SERVER;
            }
            else if (this.radioButton6.Checked == true)
            {
                this.label7.Text = ResourceInitializer.WIZARD_LABEL7E;
                this.doedit = true;
                this.wizardTabControl1.SelectedIndex = REGISTER_SERVER;
            }
            else
            {
                // go to start page
                this.wizardTabControl1.SelectedIndex = START_PAGE;
                this.btnNext.Enabled = false;
            }
        }

        private void xpNext_Click(object sender, System.EventArgs e)
        {
            this.manageStartPage();
            this.btnBack.Enabled = true;
            this.btnNext.Enabled = false;
            this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;

            int action = (int)this.wizardTabControl1.SelectedIndex;

            if (this.doedit && (action == REGISTER_SERVER))
            {
                action = EDIT_SERVER;
            }

            switch (action)
            {
                case START_PAGE:
                    this.btnBack.Enabled = false;
                    break;

                case DELETE_DATABASE:
                    if (this.inTab == true)
                    {
                        this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;

                        if (MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.QUESTION_DELETE_DATABASE, new object[] { (string)this.comboBox1.SelectedItem }), ResourceInitializer.QUESTION_DELETE_DATABASE_TITLE, System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            if (delDatabase((string)this.comboServers.SelectedValue, (string)this.comboBox1.SelectedItem) == true)
                            {
                                MessageBox.Show(ResourceInitializer.INFO_DATABASE_DELETED, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                                //								this.Visible = false;
                                this.DialogResult = DialogResult.Cancel;
                                this.inTab = false;
                                this.btnNext.Enabled = true;
                                this.changesMade = true;
                                Connect.changesMade = true;
                                this.wizardTabControl1.SelectedIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                        this.setComboDb((string)this.comboServers.SelectedValue);
                        this.inTab = true;
                    }
                    break;

                case CREATE_DATABASE:
                    if (this.inTab == true)
                    {
                        this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                        if (addDatabase((string)this.comboServers.SelectedValue, (string)this.textBox2.Text) == true)
                        {
                            MessageBox.Show(ResourceInitializer.INFO_DATABASE_CREATED, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                            this.DialogResult = DialogResult.Cancel;
                            this.wizardTabControl1.SelectedIndex = 0;
                            this.inTab = false;
                            this.textBox2.Text = "";
                            this.btnNext.Enabled = true;
                            this.changesMade = true;
                            Connect.changesMade = true;
                            this.btnBack.Enabled = false;
                        }
                        else
                        {
                            this.textBox2.Text = "";
                            this.btnNext.Enabled = false;
                            break;
                        }
                    }
                    else
                    {
                        this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                        if (this.textBox2.Text.Length != 0)
                        {
                            this.btnNext.Enabled = true;
                        }
                        this.inTab = true;
                    }
                    break;

                case CREATE_DATABASE_FROM_TEMPLATE:
                    #region template
                    /*this.initTemplateList();
					if( this.inTab == true )
					{
						this.xpNext.Text = "Next >";
						if( this.addDatabase((int)this.comboServers.SelectedValue, (string)this.textBox3.Text, (string)this.tplList.SelectedItem) == true )
						{
							MessageBox.Show("database successfully created.");
							this.Visible = false;
							this.DialogResult = DialogResult.Cancel;
							this.WizardPages.SelectedIndex = 0;
							this.inTab = false;
							this.textBox3.Text = "";
							this.xpNext.Enabled = true;
							this.changesMade = true;
							this.xpBack.Enabled = false;
						}
						else
						{
							this.textBox3.Text = "";
							this.tplList.SelectedIndex = -1;
							this.xpNext.Enabled = false;
							break;
						}
					}
					else
					{
						this.xpNext.Text = "Finish >>";
						if(this.textBox3.Text != "")
						{
							this.xpNext.Enabled = true;
						}
						this.inTab = true;
					}*/
                    #endregion
                    break;

                case REGISTER_SERVER:
                    if (this.inTab == true)
                    {
                        this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                        string userName = "";
                        string password = "";
                        if (this.radioButtonWindowsAuth.Checked)
                        {
                            ConnectionsHelper.GetWindowsUser(ref userName, ref password);
                        }
                        else
                        {
                            userName = this.textBox5.Text.ToString();
                            password = this.textBox6.Text.ToString();
                            if (userName.Contains("@"))
                            {
                                MessageBox.Show(ResourceInitializer.ErrorUsername, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                                break;
                            }
                        }

                        if (this.addServer(this.textBox1.Text.ToString(), this.textBox4.Text.ToString(), this.textBox7.Text.ToString(), userName, password, this.xpCheckBox1.Checked, this.radioButtonWindowsAuth.Checked) == true)
                        {
                            MessageBox.Show(ResourceInitializer.INFO_SERVER_REGISTERED, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                            Connect.changesMade = true;
                            this.changesAction = "NEWCONN";
                            this.DialogResult = DialogResult.Cancel;
                            this.wizardTabControl1.SelectedIndex = 0;
                            this.inTab = false;
                            this.textBox1.Text = "";
                            this.textBox4.Text = "";
                            this.textBox7.Text = "";
                            this.textBox5.Text = "";
                            this.textBox6.Text = "";
                            this.xpCheckBox1.Checked = false;
                            this.radioButton4.Checked = false;
                            this.btnNext.Enabled = false;
                            this.btnBack.Enabled = false;
                            this.setCombo();
                            this.changesMade = true;
                            this.changesAction = "create";
                        }
                        else
                        {
                            MessageBox.Show(ResourceInitializer.ERROR_REGISTER_SERVER, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                            this.btnNext.Enabled = true;
                            this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                            this.textBox4.Focus();
                        }
                    }
                    else
                    {
                        this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                        this.inTab = true;
                        bool bwa = false;
                        try
                        {
                            bwa = Convert.ToBoolean(RegUtils.GetConnRegData((string)this.comboServers.SelectedValue, "usewinauth"));
                        }
                        catch
                        { }
                        this.radioButtonWindowsAuth.Checked = bwa;
                        this.radioButtonPaloAuth.Checked = !bwa;
                        this.textBox5.Enabled = !bwa;
                        this.textBox6.Enabled = !bwa;
                        this.xpCheckBox1.Enabled = !bwa;
                    }
                    break;

                case UNREGISTER_SERVER:
                    this.btnNext.Enabled = true;
                    this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                    if (MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.QUESTION_UNREGISTER_SERVER, new object[] { (string)this.comboServers.Text }), ResourceInitializer.QUESTION_UNREGISTER_TITLE, System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        if (this.unregisterServer((string)this.comboServers.SelectedValue) == true)
                        {
                            MessageBox.Show(ResourceInitializer.INFO_SERVER_UNREGISTERED, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                            //							this.Visible = false;
                            this.DialogResult = DialogResult.Cancel;
                            this.wizardTabControl1.SelectedIndex = 0;
                            this.inTab = false;
                            this.btnNext.Enabled = false;
                            this.btnBack.Enabled = false;
                            this.setCombo();
                            this.changesMade = true;
                            Connect.changesMade = true;
                            this.changesAction = "delete";
                            this.radioButton5.Checked = false;
                        }
                    }
                    else
                    {
                        this.wizardTabControl1.SelectedIndex = 0;
                        this.btnBack.Enabled = false;
                    }
                    break;

                case EDIT_SERVER:
                    if (this.inTab == true)
                    {
                        this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                        string userName = "";
                        string password = "";
                        if (this.radioButtonWindowsAuth.Checked)
                        {
                            ConnectionsHelper.GetWindowsUser(ref userName, ref password);
                        }
                        else
                        {
                            userName = this.textBox5.Text.ToString();
                            password = this.textBox6.Text.ToString();
                            if (userName.Contains("@"))
                            {
                                MessageBox.Show(ResourceInitializer.ErrorUsername, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                                break;
                            }
                        }

                        if (this.editServer(this.textBox1.Text.ToString(), this.textBox4.Text.ToString(), this.textBox7.Text.ToString(), userName, password, this.xpCheckBox1.Checked, this.radioButtonWindowsAuth.Checked) == true)
                        {
                            MessageBox.Show(ResourceInitializer.INFO_SERVER_REGISTERED, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                            Connect.changesMade = true;
                            this.changesAction = "NEWCONN";
                            this.DialogResult = DialogResult.Cancel;
                            this.wizardTabControl1.SelectedIndex = 0;
                            this.inTab = false;
                            this.radioButton6.Checked = false;
                            this.btnNext.Enabled = false;
                            this.btnBack.Enabled = false;
                            this.setCombo();
                            this.changesMade = true;
                            this.changesAction = "create";
                        }
                        else
                        {
                            MessageBox.Show(ResourceInitializer.ERROR_REGISTER_SERVER, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                            this.btnNext.Enabled = true;
                            this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                            this.textBox4.Focus();
                        }
                    }
                    else
                    {
                        DataRow foundRow = XmlUtils.dsConnectionsTable.Rows.Find(comboServers.SelectedValue.ToString());

                        this.oldconnection = foundRow["name"].ToString();
                        this.oldhostname = foundRow["hostname"].ToString();
                        this.oldservice = foundRow["service"].ToString();
                        this.oldusername = foundRow["username"].ToString();
                        this.oldpasswd = foundRow["password"].ToString();

                        this.textBox1.Text = this.oldhostname.ToString();
                        this.textBox4.Text = this.oldservice;
                        this.textBox7.Text = this.oldconnection;

                        if (String.IsNullOrEmpty(this.oldusername) && String.IsNullOrEmpty(this.oldpasswd))
                        {
                            this.xpCheckBox1.Checked = false;
                        }
                        else
                        {
                            this.xpCheckBox1.Checked = true;
                        }
                        this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                        this.inTab = true;
                        bool bwa = false;
                        try
                        {
                            bwa = Convert.ToBoolean(RegUtils.GetConnRegData(this.comboServers.SelectedValue.ToString(), "usewinauth"));
                        }
                        catch
                        { }
                        this.radioButtonWindowsAuth.Checked = bwa;
                        this.radioButtonPaloAuth.Checked = !bwa;
                        if (bwa)
                        {
                            this.textBox5.Text = "";
                            this.textBox6.Text = "";
                        }
                        else
                        {
                            this.textBox5.Text = this.oldusername;
                            this.textBox6.Text = this.oldpasswd;
                        }
                        this.textBox5.Enabled = !bwa;
                        this.textBox6.Enabled = !bwa;
                        this.xpCheckBox1.Enabled = !bwa;
                    }
                    break;
            }
        }

        #region Manage combo change Enable/Disable Toggle Connect Button
        private void comboServers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // first we enable and uncheck all the buttons
            this.radioButton1.Enabled = true;
            this.radioButton2.Enabled = false;
            this.radioButton3.Enabled = true;
            this.radioButton4.Enabled = true;
            this.radioButton5.Enabled = true;
            this.radioButton6.Enabled = true;

            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;
            this.radioButton4.Checked = false;
            if (this.radioButton5.Checked == false)
            {
                this.radioButton5.Checked = false;
            }

            if (this.radioButton6.Checked == false)
            {
                this.radioButton6.Checked = false;
            }


            if (this.comboServers.SelectedIndex > -1)
            {
                this.label10.Text = this.comboServers.Text;
                this.label15.Text = this.comboServers.Text;

                if (Connections.ConnectionExists(this.comboServers.Text) == true)
                {
                    this.radioButton1.Enabled = true;
                    this.radioButton2.Enabled = false;
                    this.radioButton3.Enabled = true;
                    this.xpConnect.Enabled = true;
                    this.xpConnect.Text = ResourceInitializer.BUTTON_DISCONNECT;
                    //this.changesMade = true;
                }
                else
                {
                    this.radioButton1.Enabled = false;
                    this.radioButton2.Enabled = false;
                    this.radioButton3.Enabled = false;
                    this.xpConnect.Enabled = true;
                    this.xpConnect.Text = ResourceInitializer.BUTTON_CONNECT;
                    //this.changesMade = true;
                }
            }

        }
        #endregion

        #endregion

        # region Checkbox clicks(enable xpNext and change Tip label)

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.comboServers.SelectedIndex != -1 && this.radioButton1.Checked == true)
            {
                this.btnNext.Enabled = true;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            }
            else
            {
                this.btnNext.Enabled = false;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            }
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.comboServers.SelectedIndex != -1 && this.radioButton2.Checked == true)
            {
                this.btnNext.Enabled = true;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            }
            else
            {
                this.btnNext.Enabled = false;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            }
        }

        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.comboServers.SelectedIndex != -1 && this.radioButton3.Checked == true)
            {
                this.btnNext.Enabled = true;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            }
            else
            {
                this.btnNext.Enabled = false;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            }
        }

        private void radioButton4_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.radioButton4.Checked == true)
            {
                this.btnNext.Enabled = true;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            }
            else
            {
                this.btnNext.Enabled = false;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            }
        }

        private void radioButton5_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.comboServers.SelectedIndex != -1)
            {
                if (this.radioButton5.Checked == true)
                {
                    this.btnNext.Enabled = true;
                    this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                }
            }
            else
            {
                this.btnNext.Enabled = false;
                this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
            }
        }

        private void radioButton6_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.comboServers.SelectedIndex != -1)
            {
                if (this.radioButton6.Checked == true)
                {
                    this.btnNext.Enabled = true;
                    this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                }
                else
                {
                    this.btnNext.Enabled = false;
                    this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                }
            }
            else
            {
                this.btnNext.Enabled = false;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            }
        }

        private void xpCheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            /*
            if( this.xpCheckBox1.Checked == true )
            {
                this.textBox5.Enabled = true;
                this.textBox6.Enabled = true;
            }
            else
            {
                this.textBox5.Enabled = false;
                this.textBox6.Enabled = false;
            }
            */
        }

        # endregion

        # region Handle xpNext

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            this.checkxpButton1();
        }

        private void textBox4_TextChanged(object sender, System.EventArgs e)
        {
            this.checkxpButton1();
        }

        private void textBox5_TextChanged(object sender, System.EventArgs e)
        {
            this.checkxpButton1();
        }

        private void textBox6_TextChanged(object sender, System.EventArgs e)
        {
            this.checkxpButton1();
        }

        private void textBox7_TextChanged(object sender, System.EventArgs e)
        {
            this.checkxpButton1();
        }

        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            if (this.textBox2.Text.Length != 0)
            {
                this.btnNext.Enabled = true;
            }
            else
            {
                this.btnNext.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, System.EventArgs e)
        {
            if (this.textBox3.Text.Length != 0 && this.tplList.SelectedIndex != -1)
            {
                this.btnNext.Enabled = true;
            }
            else
            {
                this.btnNext.Enabled = false;
            }
        }

        #endregion

        #region Handle xpBack
        private void xpBack_Click(object sender, System.EventArgs e)
        {
            this.wizardTabControl1.SelectedIndex = 0;
            this.btnBack.Enabled = false;
            this.btnNext.Enabled = true;
            this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            this.xpConnect.Text = ResourceInitializer.BUTTON_DISCONNECT;
            this.xpConnect.Enabled = false;
            this.comboServers.SelectedIndex = -1;
            if (this.comboServers.Items.Count > 0)
            {
                this.comboServers.SelectedIndex = 0;
            }
            //this.comboServers.Text = "Click here to select the server...";
            this.inTab = false;
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;
            this.radioButton4.Checked = false;
            this.radioButton5.Checked = false;
            this.radioButton6.Checked = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.xpCheckBox1.Checked = false;
        }
        #endregion

        # region Test Connection

        private void checkxpButton1()
        {
            this.btnNext.Enabled = !String.IsNullOrEmpty(this.textBox1.Text)
                && !String.IsNullOrEmpty(this.textBox4.Text)
                && !String.IsNullOrEmpty(this.textBox7.Text)
                && ((textBox7.Text.Trim()).Length == textBox7.Text.Length);

            this.xpButton1.Enabled = this.btnNext.Enabled && ((!String.IsNullOrEmpty(this.textBox5.Text) && !String.IsNullOrEmpty(this.textBox6.Text)) || this.radioButtonWindowsAuth.Checked);
        }

        private void xpButton1_Click(object sender, System.EventArgs e)
        {
            string userName = "";
            string password = "";
            if (this.radioButtonWindowsAuth.Checked)
            {
                ConnectionsHelper.GetWindowsUser(ref userName, ref password);
            }
            else
            {
                userName = this.textBox5.Text.ToString();
                password = this.textBox6.Text.ToString();
                if (userName.Contains("@"))
                {
                    MessageBox.Show(ResourceInitializer.ErrorUsername, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                    this.textBox5.Focus();
                    return;
                }
            }

            if (Connections.TestConnection(this.textBox1.Text.ToString().ToLower(), this.textBox4.Text.ToString().ToLower(), userName, password) == true)
            {
                MessageBox.Show(ResourceInitializer.INFO_TEST_OK, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                this.btnNext.Enabled = true;
            }
            else
            {
                MessageBox.Show(ResourceInitializer.ERROR_CONNECTING, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                this.textBox7.Focus();
            }
        }

        #endregion

        #region Template handling
   
        private void tplList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.tplList.SelectedIndex != -1)
            {
                this.btnNext.Enabled = true;
            }
            else
            {
                this.btnNext.Enabled = false;
            }
        }
        #endregion

        #region Manage Connect/Disconnect Toggle Button

        private void frmWiz_Load(object sender, System.EventArgs e)
        {
            if (this.xpConnect.Text == ResourceInitializer.BUTTON_CONNECT)
            {
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;
                this.radioButton3.Enabled = false;
            }
        }

        private void xpConnect_Click(object sender, System.EventArgs e)
        {
            if (this.comboServers.SelectedValue != null)
            {
                string selectedItem = (string)this.comboServers.SelectedValue;
                this.changesMade = true;
                Connect.changesMade = true;

                if (!string.IsNullOrEmpty(selectedItem))
                {
                    if (ListBoxHelper.ConnToggle(selectedItem))
                    {
                        this.xpConnect.Text = ResourceInitializer.BUTTON_DISCONNECT;
                    }
                    else
                    {
                        this.xpConnect.Text = ResourceInitializer.BUTTON_CONNECT;
                        this.radioButton1.Enabled = false;
                        this.radioButton2.Enabled = false;
                        this.radioButton3.Enabled = false;
                    }
                    this.comboServers.SelectedValue = selectedItem;
                }
            }
        }
        #endregion

        #region Handle VisibleChange event
        private void frmWiz_VisibleChanged(object sender, System.EventArgs e)
        {
            if (this.Visible == true)
            {
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;
                this.radioButton3.Enabled = false;
                this.radioButton4.Enabled = true;
                this.radioButton5.Enabled = false;
                this.radioButton1.Checked = false;
                this.radioButton2.Checked = false;
                this.radioButton3.Checked = false;
                this.radioButton4.Checked = false;
                this.radioButton5.Checked = false;
                this.radioButton6.Checked = false;

                this.btnBack.Enabled = false;
                this.btnNext.Enabled = false;
                this.xpConnect.Enabled = false;

                this.changesMade = false;
                this.inTab = false;

                this.wizardTabControl1.SelectedIndex = (int)0;
                this.setCombo();
                this.comboServers.SelectedIndex = -1;
                if (this.comboServers.Items.Count > 0)
                {
                    this.comboServers.SelectedIndex = 0;
                }
            }
            else
            {
                RegUtils.SetFormProperties(PALOWIZRAD, new int[4] { this.Left, this.Top, this.Width, this.Height });
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            }
        }
        #endregion

        private void radioButtonPaloAuth_CheckedChanged(object sender, EventArgs e)
        {
            this.checkxpButton1();
            this.textBox5.Enabled = this.radioButtonPaloAuth.Checked;
            this.textBox6.Enabled = this.radioButtonPaloAuth.Checked;
            this.xpCheckBox1.Enabled = this.radioButtonPaloAuth.Checked;
            /*if (this.radioButtonPaloAuth.Checked)
            {
                groupBoxPaloAuth.Enabled = true;
            } 
            else
            {
                groupBoxPaloAuth.Enabled = false;
            }*/
        }








    }
}