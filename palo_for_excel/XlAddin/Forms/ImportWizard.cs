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
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using JControls;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Forms.Controls;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
    public partial class ImportWizard : WizardDialogForm
    {

        private const int NORM_HEIGHT = 421;
        private const int FINISH_HEIGHT = 210;
        private const string IMPORTWIZARD = "ImportWizard";
        public const string CSVFILTERINDEX = "CSVFilterIndex";

        #region Define Vars

        private ExcelHelper eH = new ExcelHelper();

        private System.Drawing.Point normal;
        private System.Drawing.Point diff;

        private TabPageStep tabPageStep2;
        private TabPageStep tabPageStep3;
        private ToolTip toolTip1;
        private TabPageStep tabPageStep4;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private byte FilterType;
        private int entryTabIndex = 100;

        #region ComboConn Related

        private Connection currConn;
        private ConnComboBox comboConnList;
        private string ActiveDB;

        #endregion

        private ClearCube ccw = null;
        private string old_actCube;                      // selected cube.
        private ArrayList SelectedElements = new ArrayList();

        private ImportCore impcore;
        private CultureInfo origCulture;
        private bool inTab;
        private bool inTab2;
        private bool finishing;
        private bool show_no_data_mesg = true;
        private Thread t;
        private Excel.XlCalculation oldcalc;

        private int nextpage;
        private string ActiveHostname;

        string initdir;
        string initdir1;
        string initdir2;


        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button xpBrowse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btSQLDel;
        private System.Windows.Forms.Button btSQLLoad;

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox sql;
        private System.Windows.Forms.ComboBox dsn;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox decpoint;
        private System.Windows.Forms.ProgressBar ImportProgress;
        private System.Windows.Forms.CheckBox ScreenUpdating;
       
        private CubeComboBox comboCubes;
        private System.Windows.Forms.Button btData;
        private System.Windows.Forms.Button btAttr;
        private System.Windows.Forms.Button btUser;
     
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;

        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxEx1;

        private CheckBox BoxUseRule;

        private TabPageStep tabPageStep5;
        private TabPageStep tabPageStep6;
        private CheckBox IW_has_header;
        private Button btSQLBrowse;
        private Button btnClearCube;
        #endregion

        #region Construct / Destruct 
        public ImportWizard(string decpoint, CultureInfo originalCulture)
		{
            this.wizardTabControl1.SelectTab(0);
            base.SetBtns((TabPageStep)this.wizardTabControl1.SelectedTab);
			InitializeComponent();
            this.PanelContenerTabs.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep4.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep5.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep6.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.pnlBottom.BackColor = ResourceInitializer.FormStdBackgroundColor;
          
            this.btnClearCube.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnBack.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnNext.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnFinish.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.ScreenUpdating.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton4.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label1.BackColor = ResourceInitializer.FormStdBackgroundColor;
        
            this.IW_has_header.BackColor = ResourceInitializer.FormStdBackgroundColor;//Transparent
            this.label7.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.xpBrowse.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btSQLBrowse.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton11.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton10.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton9.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton8.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.radioButton7.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label4.BackColor = ResourceInitializer.FormStdBackgroundColor;

            this.btSQLBrowse.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btSQLLoad.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btSQLDel.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.label16.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label15.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label14.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label13.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label5.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label6.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label11.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label12.BackColor = ResourceInitializer.FormStdBackgroundColor;
          
            this.ImportProgress.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label8.BackColor = ResourceInitializer.FormStdBackgroundColor;
           
            this.label10.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label9.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.panel1.BackColor = ResourceInitializer.FormStdBackgroundColor;
   
            this.groupBox1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.BoxUseRule.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.checkBox2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.checkBox1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            
            // to avoid the Exception with the message
            // Cross-thread operation not valid: Control 'ImportProgress' accessed from a thread other than the thread it was created on.

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            this.initdir = RegUtils.SavePath;
            this.initdir1 = initdir;
            this.initdir2 = initdir + "\\SQL\\";

            this.origCulture = originalCulture;
			this.decpoint.Text = decpoint;
            normal = this.pnlBottom.Location;
            diff = this.ImportProgress.Location;
            diff.Y = diff.Y + 30;

			#region Cube import

			this.ActiveDB = "";
			this.ActiveHostname = "";
			this.initCombo();
			this.setCombo();

            this.preselectComboConnList();

            this.comboCubes.SetItem(RegUtils.ActiveCube);

			#endregion

			this.do_part_init();

			this.LeftPanelImage = ResourceInitializer.WizardLogo;
		

			this.Text = ResourceInitializer.TITLE_IMPORT_WIZARD;
			this.TitleLabel = ResourceInitializer.TITLE_IMPORT_WIZARD;
			
			this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
			this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
			this.btnFinish.Text = ResourceInitializer.BUTTON_CLOSE;

			this.xpBrowse.Text = ResourceInitializer.BUTTON_BROWSE;
            this.btSQLBrowse.Text = ResourceInitializer.BUTTON_BROWSE;
            this.btSQLDel.Text = ResourceInitializer.BUTTON_DELETE;
			this.btSQLLoad.Text = ResourceInitializer.BUTTON_SAVE;

			this.label1.Text = ResourceInitializer.LABEL_IMPORT_PAGE1_1;
			this.label2.Text = ResourceInitializer.LABEL_IMPORT_PAGE1_2;
			this.radioButton1.Text = ResourceInitializer.LABEL_IMPORT_PAGE1_3;
			this.radioButton2.Text = ResourceInitializer.LABEL_IMPORT_PAGE1_4;
			this.radioButton3.Text = ResourceInitializer.LABEL_IMPORT_PAGE1_5;
            this.radioButton4.Text = ResourceInitializer.LABEL_IMPORT_PAGE1_7;
            this.ScreenUpdating.Text = ResourceInitializer.LABEL_IMPORT_PAGE1_6;

			this.label4.Text = ResourceInitializer.LABEL_IMPORT_PAGE2_1;
			this.label3.Text = ResourceInitializer.LABEL_IMPORT_PAGE2_2;
			this.radioButton7.Text = ResourceInitializer.LABEL_OPTION_TAB;
			this.radioButton10.Text = ResourceInitializer.LABEL_OPTION_BLANK;
			this.radioButton8.Text = ResourceInitializer.LABEL_OPTION_COMMA;
			this.radioButton11.Text = ResourceInitializer.LABEL_OPTION_USERDEFINED;
			this.radioButton9.Text = ResourceInitializer.LABEL_OPTION_SEMICOLON;
			this.label7.Text = ResourceInitializer.LABEL_OPTION_DECIMALPOINT;

			this.label6.Text = ResourceInitializer.LABEL_IMPORT_PAGE3_1;
			this.label13.Text = ResourceInitializer.LABEL_IMPORT_PAGE3_2;
			this.label5.Text = ResourceInitializer.LABEL_IMPORT_PAGE3_3;
			this.label14.Text = ResourceInitializer.WIZARD_LABEL30;
			this.label15.Text = ResourceInitializer.WIZARD_LABEL31;
			this.label16.Text = ResourceInitializer.LABEL_IMPORT_PAGE3_4;

			this.label8.Text = ResourceInitializer.LABEL_IMPORT_PAGE4_1;

			this.label9.Text = ResourceInitializer.TEXT_CHOOSE_SERVER_DB;
			this.label10.Text = ResourceInitializer.TEXT_CHOOSE_CUBE;

			this.groupBox1.Text = ResourceInitializer.LABEL_IMPORT_PAGE5_1;
			this.checkBox1.Text = ResourceInitializer.LABEL_IMPORT_PAGE5_2;
			this.checkBox2.Text = ResourceInitializer.LABEL_IMPORT_PAGE5_3;

			this.IW_has_header.Text = ResourceInitializer.TEXT_HAS_HEADER;

            this.btnClearCube.Text = ResourceInitializer.CMD_CLEAR_CUBE;

            this.BoxUseRule.Text = ResourceInitializer.LABEL_EXPORT_USE_RULES;

			this.sql.TextChanged += new System.EventHandler(this.sql_TextChanged);
            this.sql.KeyDown +=new KeyEventHandler(this.sql_KeyDown);
			this.comboBoxEx1.TextChanged += new System.EventHandler(this.ComboBox1_TextChanged);
			this.ScreenUpdating.CheckedChanged += new System.EventHandler(this.ScreenUpdating_CheckedChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImportWizard_KeyDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportWizard_FormClosing);

            this.btSQLBrowse.Click += new System.EventHandler(this.btSQLBrowse_Click);

            this.btData.Visible = true;
            this.btAttr.Visible = true;
            this.btUser.Visible = true;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
                if (this.ccw != null)
                {
                    this.ccw.Dispose();
                }

                if (components != null) 
				{
					components.Dispose();
				}
	
				GC.Collect();
                this.ccw = null;
				this.t = null;
				GC.Collect();
			}
			base.Dispose( disposing );
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportWizard));
            this.tabPageStep2 = new JControls.TabPageStep();
            this.IW_has_header = new System.Windows.Forms.CheckBox();
            this.comboBoxEx1 = new System.Windows.Forms.ComboBox();
            this.decpoint = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.xpBrowse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageStep3 = new JControls.TabPageStep();
            this.btSQLBrowse = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.sql = new System.Windows.Forms.TextBox();
            this.dsn = new System.Windows.Forms.ComboBox();
            this.btSQLLoad = new System.Windows.Forms.Button();
            this.btSQLDel = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPageStep4 = new JControls.TabPageStep();
            this.ImportProgress = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPageStep5 = new JControls.TabPageStep();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPageStep6 = new JControls.TabPageStep();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BoxUseRule = new System.Windows.Forms.CheckBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ScreenUpdating = new System.Windows.Forms.CheckBox();
            this.btnClearCube = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.PanelContenerTabs.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.tabPageStep2.SuspendLayout();
            this.tabPageStep3.SuspendLayout();
            this.tabPageStep4.SuspendLayout();
            this.tabPageStep5.SuspendLayout();
            this.tabPageStep6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClearCube);
            this.pnlBottom.Controls.Add(this.ScreenUpdating);
            this.pnlBottom.Location = new System.Drawing.Point(3, 389);
            this.pnlBottom.Size = new System.Drawing.Size(460, 43);
            this.pnlBottom.Controls.SetChildIndex(this.ScreenUpdating, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnNext, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnBack, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnFinish, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClearCube, 0);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinish.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnFinish.Location = new System.Drawing.Point(374, 8);
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 1004;
            this.btnFinish.Text = "";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.xpCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBack.Location = new System.Drawing.Point(207, 8);
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 1003;
            this.btnBack.Text = "";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.xpBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNext.Location = new System.Drawing.Point(290, 8);
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1002;
            this.btnNext.Text = "";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.xpNext_Click);
            // 
            // PanelContenerTabs
            // 
            this.PanelContenerTabs.BackColor = System.Drawing.SystemColors.Control;
            this.PanelContenerTabs.Size = new System.Drawing.Size(462, 432);
            // 
            // wizardTabControl1
            // 
            this.wizardTabControl1.Controls.Add(this.tabPageStep2);
            this.wizardTabControl1.Controls.Add(this.tabPageStep3);
            this.wizardTabControl1.Controls.Add(this.tabPageStep4);
            this.wizardTabControl1.Controls.Add(this.tabPageStep5);
            this.wizardTabControl1.Controls.Add(this.tabPageStep6);
            this.wizardTabControl1.SelectedIndex = 2;
            this.wizardTabControl1.Size = new System.Drawing.Size(460, 338);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep6, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep5, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep4, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep3, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep2, 0);
            this.wizardTabControl1.Controls.SetChildIndex(this.tabPageStep1, 0);
            // 
            // tabPageStep1
            // 
            this.tabPageStep1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep1.Controls.Add(this.radioButton4);
            this.tabPageStep1.Controls.Add(this.radioButton3);
            this.tabPageStep1.Controls.Add(this.radioButton2);
            this.tabPageStep1.Controls.Add(this.radioButton1);
            this.tabPageStep1.Controls.Add(this.label2);
            this.tabPageStep1.Controls.Add(this.label1);
            this.tabPageStep1.Size = new System.Drawing.Size(452, 312);
            // 
            // tabPageStep2
            // 
            this.tabPageStep2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep2.Controls.Add(this.IW_has_header);
            this.tabPageStep2.Controls.Add(this.comboBoxEx1);
            this.tabPageStep2.Controls.Add(this.decpoint);
            this.tabPageStep2.Controls.Add(this.label7);
            this.tabPageStep2.Controls.Add(this.xpBrowse);
            this.tabPageStep2.Controls.Add(this.textBox1);
            this.tabPageStep2.Controls.Add(this.radioButton11);
            this.tabPageStep2.Controls.Add(this.radioButton10);
            this.tabPageStep2.Controls.Add(this.radioButton9);
            this.tabPageStep2.Controls.Add(this.radioButton8);
            this.tabPageStep2.Controls.Add(this.radioButton7);
            this.tabPageStep2.Controls.Add(this.label3);
            this.tabPageStep2.Controls.Add(this.label4);
            this.tabPageStep2.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep2.Name = "tabPageStep2";
            this.tabPageStep2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStep2.ShowBackButton = true;
            this.tabPageStep2.ShowFinishButton = true;
            this.tabPageStep2.ShowNextButton = true;
            this.tabPageStep2.Size = new System.Drawing.Size(452, 312);
            this.tabPageStep2.TabIndex = 1;
            this.tabPageStep2.Tag = 2;
            this.tabPageStep2.Text = "Step2";
            // 
            // IW_has_header
            // 
            this.IW_has_header.BackColor = System.Drawing.Color.Transparent;
            this.IW_has_header.Enabled = false;
            this.IW_has_header.Location = new System.Drawing.Point(56, 240);
            this.IW_has_header.Name = "IW_has_header";
            this.IW_has_header.Size = new System.Drawing.Size(384, 24);
            this.IW_has_header.TabIndex = 30;
            this.IW_has_header.Text = "header existing";
            this.IW_has_header.UseVisualStyleBackColor = false;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.Location = new System.Drawing.Point(56, 80);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(256, 21);
            this.comboBoxEx1.TabIndex = 21;
            this.comboBoxEx1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            // 
            // decpoint
            // 
            this.decpoint.Enabled = false;
            this.decpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decpoint.Location = new System.Drawing.Point(56, 200);
            this.decpoint.MaxLength = 1;
            this.decpoint.Name = "decpoint";
            this.decpoint.Size = new System.Drawing.Size(15, 22);
            this.decpoint.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Enabled = false;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(74, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(366, 24);
            this.label7.TabIndex = 0;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // tabPageStep3
            // 
            this.tabPageStep3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep3.Controls.Add(this.btSQLBrowse);
            this.tabPageStep3.Controls.Add(this.comboBox2);
            this.tabPageStep3.Controls.Add(this.sql);
            this.tabPageStep3.Controls.Add(this.dsn);
            this.tabPageStep3.Controls.Add(this.btSQLLoad);
            this.tabPageStep3.Controls.Add(this.btSQLDel);
            this.tabPageStep3.Controls.Add(this.label16);
            this.tabPageStep3.Controls.Add(this.password);
            this.tabPageStep3.Controls.Add(this.user);
            this.tabPageStep3.Controls.Add(this.label15);
            this.tabPageStep3.Controls.Add(this.label14);
            this.tabPageStep3.Controls.Add(this.label13);
            this.tabPageStep3.Controls.Add(this.label5);
            this.tabPageStep3.Controls.Add(this.label6);
            this.tabPageStep3.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep3.Name = "tabPageStep3";
            this.tabPageStep3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStep3.ShowBackButton = true;
            this.tabPageStep3.ShowFinishButton = true;
            this.tabPageStep3.ShowNextButton = true;
            this.tabPageStep3.Size = new System.Drawing.Size(452, 312);
            this.tabPageStep3.TabIndex = 2;
            this.tabPageStep3.Tag = 3;
            this.tabPageStep3.Text = "Step3";
            // 
            // btSQLBrowse
            // 
            this.btSQLBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.btSQLBrowse.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btSQLBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSQLBrowse.Location = new System.Drawing.Point(3, 283);
            this.btSQLBrowse.Name = "btSQLBrowse";
            this.btSQLBrowse.Size = new System.Drawing.Size(95, 23);
            this.btSQLBrowse.TabIndex = 48;
            this.btSQLBrowse.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.Location = new System.Drawing.Point(0, 256);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(449, 21);
            this.comboBox2.TabIndex = 45;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // sql
            // 
            this.sql.Location = new System.Drawing.Point(0, 160);
            this.sql.Multiline = true;
            this.sql.Name = "sql";
            this.sql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sql.Size = new System.Drawing.Size(449, 88);
            this.sql.TabIndex = 44;
            this.sql.WordWrap = false;
            // 
            // dsn
            // 
            this.dsn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsn.Location = new System.Drawing.Point(156, 64);
            this.dsn.Name = "dsn";
            this.dsn.Size = new System.Drawing.Size(268, 21);
            this.dsn.TabIndex = 41;
            this.dsn.SelectedIndexChanged += new System.EventHandler(this.dsn_SelectedIndexChanged);
            // 
            // btSQLLoad
            // 
            this.btSQLLoad.BackColor = System.Drawing.SystemColors.Control;
            this.btSQLLoad.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btSQLLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSQLLoad.Location = new System.Drawing.Point(156, 283);
            this.btSQLLoad.Name = "btSQLLoad";
            this.btSQLLoad.Size = new System.Drawing.Size(84, 23);
            this.btSQLLoad.TabIndex = 47;
            this.btSQLLoad.UseVisualStyleBackColor = false;
            this.btSQLLoad.Click += new System.EventHandler(this.btSQLLoad_Click);
            // 
            // btSQLDel
            // 
            this.btSQLDel.BackColor = System.Drawing.SystemColors.Control;
            this.btSQLDel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btSQLDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSQLDel.Location = new System.Drawing.Point(375, 283);
            this.btSQLDel.Name = "btSQLDel";
            this.btSQLDel.Size = new System.Drawing.Size(74, 23);
            this.btSQLDel.TabIndex = 46;
            this.btSQLDel.UseVisualStyleBackColor = false;
            this.btSQLDel.Click += new System.EventHandler(this.btSQLDel_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(446, 23);
            this.label16.TabIndex = 0;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(334, 104);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(90, 22);
            this.password.TabIndex = 43;
            // 
            // user
            // 
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(126, 104);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(110, 22);
            this.user.TabIndex = 42;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(248, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 23);
            this.label15.TabIndex = 0;
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 23);
            this.label14.TabIndex = 0;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(452, 23);
            this.label13.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 21);
            this.label5.TabIndex = 0;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(446, 24);
            this.label6.TabIndex = 0;
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
            this.tabPageStep4.Size = new System.Drawing.Size(452, 312);
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
            this.ImportProgress.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(452, 43);
            this.label8.TabIndex = 1;
            // 
            // radioButton4
            // 
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(64, 186);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(384, 24);
            this.radioButton4.TabIndex = 14;
            this.radioButton4.Text = "Internal Loop";
            // 
            // radioButton3
            // 
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(64, 154);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(384, 24);
            this.radioButton3.TabIndex = 13;
            // 
            // radioButton2
            // 
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(64, 122);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(392, 24);
            this.radioButton2.TabIndex = 12;
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(64, 90);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(384, 24);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 23);
            this.label2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 50);
            this.label1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 204);
            this.panel1.TabIndex = 99;
            // 
            // tabPageStep5
            // 
            this.tabPageStep5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep5.Controls.Add(this.label10);
            this.tabPageStep5.Controls.Add(this.label9);
            this.tabPageStep5.Controls.Add(this.panel1);
            this.tabPageStep5.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep5.Name = "tabPageStep5";
            this.tabPageStep5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStep5.ShowBackButton = true;
            this.tabPageStep5.ShowFinishButton = true;
            this.tabPageStep5.ShowNextButton = true;
            this.tabPageStep5.Size = new System.Drawing.Size(452, 312);
            this.tabPageStep5.TabIndex = 4;
            this.tabPageStep5.Tag = 5;
            this.tabPageStep5.Text = "Step5";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(2, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(440, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Choose Cube:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(440, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Choose Server/database:";
            // 
            // tabPageStep6
            // 
            this.tabPageStep6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep6.Controls.Add(this.groupBox1);
            this.tabPageStep6.Location = new System.Drawing.Point(4, 22);
            this.tabPageStep6.Name = "tabPageStep6";
            this.tabPageStep6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStep6.ShowBackButton = true;
            this.tabPageStep6.ShowFinishButton = true;
            this.tabPageStep6.ShowNextButton = true;
            this.tabPageStep6.Size = new System.Drawing.Size(452, 312);
            this.tabPageStep6.TabIndex = 5;
            this.tabPageStep6.Tag = 6;
            this.tabPageStep6.Text = "Step6";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.BoxUseRule);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 269);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // BoxUseRule
            // 
            this.BoxUseRule.BackColor = System.Drawing.SystemColors.Control;
            this.BoxUseRule.Location = new System.Drawing.Point(16, 126);
            this.BoxUseRule.Name = "BoxUseRule";
            this.BoxUseRule.Size = new System.Drawing.Size(384, 24);
            this.BoxUseRule.TabIndex = 78;
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
            this.comboBox4.TabIndex = 73;
            // 
            // checkBox2
            // 
            this.checkBox2.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(16, 96);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(384, 24);
            this.checkBox2.TabIndex = 77;
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
            this.checkBox1.TabIndex = 76;
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
            this.comboBox3.Location = new System.Drawing.Point(232, 24);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(64, 21);
            this.comboBox3.TabIndex = 74;
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
            this.comboBox1.TabIndex = 71;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(298, 24);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(56, 20);
            this.textBox3.TabIndex = 75;
            this.textBox3.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(82, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 72;
            this.textBox2.Text = "0";
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
            // ScreenUpdating
            // 
            this.ScreenUpdating.BackColor = System.Drawing.SystemColors.Control;
            this.ScreenUpdating.Checked = true;
            this.ScreenUpdating.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ScreenUpdating.Location = new System.Drawing.Point(8, 0);
            this.ScreenUpdating.Name = "ScreenUpdating";
            this.ScreenUpdating.Size = new System.Drawing.Size(192, 40);
            this.ScreenUpdating.TabIndex = 1000;
            this.ScreenUpdating.UseVisualStyleBackColor = false;
            this.ScreenUpdating.Visible = false;
            // 
            // btnClearCube
            // 
            this.btnClearCube.BackColor = System.Drawing.SystemColors.Control;
            this.btnClearCube.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnClearCube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCube.Location = new System.Drawing.Point(68, 8);
            this.btnClearCube.Name = "btnClearCube";
            this.btnClearCube.Size = new System.Drawing.Size(95, 23);
            this.btnClearCube.TabIndex = 1001;
            this.btnClearCube.UseVisualStyleBackColor = false;
            this.btnClearCube.Click += new System.EventHandler(this.btnClearCube_Click);
            // 
            // ImportWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(618, 429);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportWizard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImportWizard_FormClosed);
            this.pnlBottom.ResumeLayout(false);
            this.PanelContenerTabs.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.tabPageStep2.ResumeLayout(false);
            this.tabPageStep2.PerformLayout();
            this.tabPageStep3.ResumeLayout(false);
            this.tabPageStep3.PerformLayout();
            this.tabPageStep4.ResumeLayout(false);
            this.tabPageStep5.ResumeLayout(false);
            this.tabPageStep6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private int GetUDRegData(string path)
        {
            return RegUtils.GetIntValue4Form(IMPORTWIZARD, path, 0);
        }

        private void SetUDRegData(string path, object value)
        {
            RegUtils.SetKeyValue4Form(IMPORTWIZARD, path, value);
        }


        #region CleanUp
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
                catch (Exception e)
                {
                    ErrorHandler.DisplayError("Error cleaning_up ImportWizard", e);
                }
            }
            this.impcore = null;
            t = null;
        }
     #endregion

        #region Switching tab pages

        #region Back button

        private void xpBack_Click(object sender, System.EventArgs e)
        {
            if (this.btnBack.Text != ResourceInitializer.BUTTON_NEXT)
            {
                if (this.inTab2 == true)
                {
                    if (this.wizardTabControl1.SelectedIndex == 4)
                    {
                        this.inTab = false;
                        this.wizardTabControl1.SelectedIndex = 0;
                    }
                    else
                    {
                        if (this.wizardTabControl1.SelectedIndex > 4)
                        {
                            this.inTab2 = false;
                            this.wizardTabControl1.SelectedIndex--;
                        }
                    }
                }
                else
                {
                    this.inTab = false;
                    this.btnBack.Enabled = false;
                    this.btnNext.Enabled = true;
                    this.Height = NORM_HEIGHT;
                    this.wizardTabControl1.SelectedIndex = 0;
                    this.btnClearCube.Visible = true;
                }
            }
            else
            {
                try
                {
                    this.impcore.insertRow();
                    Connect.changesMade = true;
                }
                catch (Exception exc)
                {
                    ErrorHandler.DisplayError("Error stepping through import!", exc);
                }
            }
        }


        #endregion

        #region Next button

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

        private void checknextsql()
        {
            if ((this.dsn.Text.Length == 0) || (this.dsn.Text == ResourceInitializer.TEXT_SELECT_DSN) || (this.sql.Text.Length == 0))
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
            if (this.radioButton1.Checked == true && this.inTab == false)
            {
                this.nextpage = 1;
            }
            else if (this.radioButton2.Checked == true && this.inTab == false)
            {
                this.nextpage = 2;
            }
            else if (this.radioButton4.Checked == true)
            {
                this.nextpage = 3;
            }
            else if (this.radioButton1.Checked == true && this.inTab == true)
            {
                this.nextpage = 3;
            }
            else if (this.radioButton2.Checked == true && this.inTab == true)
            {
                this.nextpage = 3;
            }
            else if (this.radioButton3.Checked == true && this.inTab == true && this.inTab2 == true)
            {
                this.nextpage = 3;
            }
            else if (this.radioButton3.Checked == true && this.inTab == false)
            {
                this.nextpage = 4;
            }
            else if (this.radioButton3.Checked == true && this.inTab == true && this.inTab2 == false)
            {
                this.nextpage = 5;
            }
            else
            {
                // go to start page
                this.nextpage = 0;
            }
        }

        private void xpNext_Click(object sender, System.EventArgs e)
        {
            if (this.btnNext.Text == ResourceInitializer.BUTTON_FINISH)
            {
                try
                {
                    this.btnFinish.Text = ResourceInitializer.BUTTON_CANCEL;
                    this.btnBack.Enabled = false;
                    this.btnNext.Enabled = false;
                    if (this.radioButton3.Checked)
                    {
                        this.comboConnList.SaveItem();
                        this.comboCubes.SaveItem();
                    }
                    this.t = new Thread(new ThreadStart(this.impcore.t_insertRow));
                    this.impcore.set_screenupdating(this.ScreenUpdating.Checked);
                    this.impcore.SetBlank(true);
                    this.t.Start();
                    Connect.changesMade = true;
                }
                catch (Exception exc)
                {
                    ErrorHandler.DisplayError("Error finishing Import!", exc);
                }
            }
            else
            {
                this.manageStartPage();
                switch (this.nextpage)
                {
                    #region case 0 - Initial page
                    case 0:
                        this.btnClearCube.Visible = true;
                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.Height = NORM_HEIGHT;
                        this.btnBack.Enabled = false;
                        this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
                        this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                        this.inTab = false;
                        break;
                    #endregion
                    #region case 1 - CSV
                    case 1:
                        this.btnClearCube.Visible = false;
                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.checknext2();
                        this.Height = NORM_HEIGHT;
                        this.btnBack.Enabled = true;
                        this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
                        this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                        this.inTab = true;
                        break;
                    #endregion
                    #region case 2 - ODBC
                    case 2:
                        this.wizardTabControl1.SelectedIndex = this.nextpage;
                        this.checknextsql();
                        this.btnClearCube.Visible = false;

                        OdbcMngr[] DsnList = OdbcMngr.GetUserDSNList();

                        string dsnName = "";

                        foreach (OdbcMngr name in DsnList)
                        {
                            dsnName = name.GetDSNName().ToString();
                            if (!this.dsn.Items.Contains(dsnName))
                            {
                                this.dsn.Items.Add(dsnName);
                            }
                        }

                        DsnList = OdbcMngr.GetSystemDSNList();

                        foreach (OdbcMngr name in DsnList)
                        {
                            dsnName = name.GetDSNName().ToString();
                            if (!this.dsn.Items.Contains(dsnName))
                            {
                                this.dsn.Items.Add(dsnName);
                            }
                        }

                        this.initSqlCombo();

                        this.Height = NORM_HEIGHT;
                        this.btnBack.Enabled = true;
                        this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
                        this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                        this.inTab = true;
                        break;
                    #endregion
                    #region case 3 - Finish
                    case 3:
                        this.btnClearCube.Visible = false;
                        if (this.radioButton2.Checked)
                        {
                            this.check_sql_text();
                            this.StartDsDSN();
                        }
                        else if (this.radioButton1.Checked)
                        {
                            this.StartDsCSV();
                        }
                        else if (this.radioButton4.Checked)
                        {
                            this.impcore.set_internal_mode_params();
                            this.impcore.start();
                        }
                        else
                        {
                            this.StartDsCube();
                        }

                        ExcelHelper.ResetExcelStatusbar();

                        if (this.impcore.empty())
                        {
                            if (show_no_data_mesg) System.Windows.Forms.MessageBox.Show(ResourceInitializer.ERROR_DATA_NOT_FOUND);
                            show_no_data_mesg = true;
                        }
                        else
                        {
                            this.SuspendLayout();
                            this.wizardTabControl1.SelectedIndex = this.nextpage;
                           // this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;

                            setheight(false);
                                               
                            this.btnBack.Text = ResourceInitializer.BUTTON_NEXT;
                            this.btnBack.Enabled = true;
                            this.btnNext.Text = ResourceInitializer.BUTTON_FINISH;
                            this.btnNext.Enabled = true;
                            this.btnBack.Focus();
                            this.ScreenUpdating.Visible = true;
                            this.ResumeLayout();
                            this.oldcalc = ExcelHelper.DisableAutomaticRecalc();
                            ExcelHelper.AddNameValue(GeneralConst.IMPORT_ACTIVE, true);
                            ExcelHelper.PaloEnableLoop(true);
                        }
                        break;
                    #endregion
                    #region case 4 - Cube step 1
                    case 4:
                        this.btnClearCube.Visible = false;
                        this.inTab = true;
                        this.inTab2 = false;
                        if (this.radioButton3.Checked)
                        {
                            this.wizardTabControl1.SelectedIndex = this.nextpage;
                            this.btnBack.Enabled = true;
                            if (this.comboCubes.SelectedIndex != -1)
                                this.btnNext.Enabled = true;
                            else
                                this.btnNext.Enabled = false;
                        }
                        break;
                    #endregion
                    #region case 5 - Cube step 2
                    case 5:
                        this.btnClearCube.Visible = false;
                        if (this.radioButton3.Checked)
                        {
                            this.wizardTabControl1.SelectedIndex = this.nextpage;
                            this.btnBack.Enabled = true;
                            this.btnNext.Enabled = true;
                            this.inTab2 = true;
                        }
                        break;
                    #endregion
                }
            }
        }

        #endregion

        #endregion
        private void setheight(bool start)
        {
            if (start)
            {
                this.Height = NORM_HEIGHT;
                this.PanelContenerTabs.Height = 402;
                this.wizardTabControl1.Height = 308;
                this.pnlBottom.Location = new System.Drawing.Point(3, 359);
            }
            else 
            {

                this.Height = FINISH_HEIGHT;
                this.PanelContenerTabs.Height = FINISH_HEIGHT;
                this.wizardTabControl1.Height = 90;
                this.pnlBottom.Location = new System.Drawing.Point(0, 145);
            
            }

        }
        #region Combo related

        #region Helpers

        public void set_default()
        {
            this.setCombo();
            comboConnList.SetItem();
            this.get_cubes();
        }

        private void get_cubes()
        {
            this.comboCubes.RefreshList(this.comboConnList, this.currConn, this.FilterType, true);
        }

        #endregion

        #region Conn Combo

        private void initCombo()
        {
            this.comboConnList = null;
            this.comboCubes = null;
            this.comboConnList = new ConnComboBox();
            this.comboCubes = new CubeComboBox();
            this.btData = null;
            this.btAttr = null;
            this.btUser = null;
            this.btData = new System.Windows.Forms.Button();
            this.btAttr = new System.Windows.Forms.Button();
            this.btUser = new System.Windows.Forms.Button();
            this.btUser.Image = (System.Drawing.Image)ResourceInitializer.IconFilterUserOn;
            this.btData.Image = (System.Drawing.Image)ResourceInitializer.IconFilterDataOn;
            this.btAttr.Image = (System.Drawing.Image)ResourceInitializer.IconFilterAttributeOn;
            // 
            // comboCubes
            // 
            this.comboCubes.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.comboCubes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCubes.Enabled = false;
            this.comboCubes.Location = new System.Drawing.Point(8, 56);
            this.comboCubes.MaxLength = 1;
            this.comboCubes.Name = "comboCubes";
            this.comboCubes.Size = new System.Drawing.Size(262, 21);
            this.comboCubes.TabIndex = 62;
            this.toolTip1.SetToolTip(this.comboCubes, ResourceInitializer.TIP_CHOOSE_CUBE);
            this.comboCubes.EnabledChanged += new System.EventHandler(comboCubes_EnabledChanged);
            this.comboCubes.SelectedIndexChanged += new System.EventHandler(this.comboCubes_SelectedIndexChanged);
            this.tabPageStep5.Controls.Add(this.comboCubes);
            //
            // btData
            //
            this.btData.Enabled = false;
            this.btData.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btData.Location = new System.Drawing.Point(276, 56);
            this.btData.Name = "btData";
            this.btData.Size = new System.Drawing.Size(21, 21);
            this.btData.TabIndex = 63;
            this.btData.UseVisualStyleBackColor = true;
            this.btData.Click += new System.EventHandler(this.btData_Click);
            //
            // btAttr
            //
            this.btAttr.Enabled = false;
            this.btAttr.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btAttr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAttr.Location = new System.Drawing.Point(303, 56);
            this.btAttr.Name = "btAttr";
            this.btAttr.Size = new System.Drawing.Size(21, 21);
            this.btAttr.TabIndex = 64;
            this.btAttr.UseVisualStyleBackColor = true;
            this.btAttr.Click += new System.EventHandler(this.btAttr_Click);
            //
            // btUser
            //
            this.btUser.Enabled = false;
            this.btUser.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUser.Location = new System.Drawing.Point(330, 56);
            this.btUser.Name = "btUser";
            this.btUser.Size = new System.Drawing.Size(21, 21);
            this.btUser.TabIndex = 65;
            this.btUser.UseVisualStyleBackColor = true;
            this.btUser.Click += new System.EventHandler(this.btUser_Click);
            // 
            // comboConnList
            // 
            this.comboConnList.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.comboConnList.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.comboConnList.CausesValidation = false;
            this.comboConnList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboConnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.comboConnList.MaxLength = 1;
            this.comboConnList.Location = new System.Drawing.Point(8, 17);
            this.comboConnList.Name = "comboConnList";
            this.comboConnList.Size = new System.Drawing.Size(262, 21);
            this.comboConnList.TabIndex = 61;
            this.comboConnList.Tag = "myCustomCombo";
            this.comboConnList.Text = "Click here to change active server...";
            this.Controls.Add(this.comboConnList);
            this.comboConnList.SelectedIndexChanged += new System.EventHandler(this.comboConnList_SelectedIndexChanged);
            this.comboConnList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.tabPageStep5.Controls.Add(this.comboConnList);
            this.tabPageStep5.Controls.Add(this.btData);
            this.tabPageStep5.Controls.Add(this.btAttr);
            this.tabPageStep5.Controls.Add(this.btUser);
        }

        private void btData_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.FILTER_DATA);
        }

        private void btAttr_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.FILTER_ATTRIBUTE);
        }

        private void btUser_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.FILTER_USER);
        }

        private void do_btnFilter(byte filtertype)
        {
            this.FilterType = filtertype;
            this.btData.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btAttr.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btUser.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;

            if (filtertype == GeneralConst.FILTER_DATA)
            {
                this.btData.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            else if (filtertype == GeneralConst.FILTER_ATTRIBUTE)
            {
                this.btAttr.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            else if (filtertype == GeneralConst.FILTER_USER)
            {
                this.btUser.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            this.get_cubes();
        }

        private void setCombo()
        {
            this.toolTip1.SetToolTip(this.comboConnList, ResourceInitializer.TIP_COMBO_CONNECTIONS);
            this.comboConnList.FillList(-1, ConnectionsHelper.HandleDatabase.WithSystem);
        }

        private void comboConnList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string selectedHostname = this.comboConnList.GetConnectionName();
            string selectedDB = this.comboConnList.GetDatabase();

            this.currConn = this.comboConnList.GetConnection();

            if (string.IsNullOrEmpty(selectedDB)) // No database selected.
            {
                this.clearGroupBoxes();
                this.btnNext.Enabled = false;
                this.comboCubes.Enabled = false;
                this.comboCubes.Text = "Please select cube...";
                this.toolTip1.SetToolTip(this.comboCubes, "Please select cube...");
                this.btData.Enabled = false;
                this.btAttr.Enabled = false;
                this.btUser.Enabled = false;
            }
            else
            {
                if (!String.Equals(this.ActiveHostname, selectedHostname, StringComparison.InvariantCultureIgnoreCase) ||
                    !String.Equals(this.ActiveDB, selectedDB, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.clearGroupBoxes();
                    this.btnNext.Enabled = false;
                }
                // else keep selections.
                comboConnList.SaveItem();

                this.comboCubes.Enabled = true;

            }

            this.ActiveHostname = selectedHostname;
            this.ActiveDB = selectedDB;
            if (this.comboCubes.Enabled)
            {
                this.get_cubes();
                if (String.Equals(selectedDB, GeneralConst.SYSTEM_DB_NAME, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.do_btnFilter(GeneralConst.FILTER_USER);
                    this.btData.Enabled = false;
                    this.btAttr.Enabled = false;
                    this.btUser.Enabled = false;
                }
                else
                {
                    this.do_btnFilter(GeneralConst.FILTER_DATA);
                    this.btData.Enabled = true;
                    this.btAttr.Enabled = true;
                    this.btUser.Enabled = true;
                }
            }

            if (this.comboConnList.Text != null)
            {
                this.toolTip1.SetToolTip(this.comboConnList, this.comboConnList.Text);
            }
        }

        private void preselectComboConnList()
        {
            comboConnList.SetItem();
        }

        #endregion

        #region Cubes combo

        private void comboCubes_EnabledChanged(object sender, System.EventArgs e)
        {
            if (comboCubes.Enabled)
            {
                this.btData.Enabled = true;
                this.btAttr.Enabled = true;
                this.btUser.Enabled = true;
            }
            else
            {
                this.btData.Enabled = false;
                this.btAttr.Enabled = false;
                this.btUser.Enabled = false;
            }
        }

        private void clearGroupBoxes()
        {
            this.panel1.Controls.Clear();
            this.SelectedElements.Clear();
        }

        private void comboCubes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((this.comboCubes.SelectedIndex != -1) && (this.comboConnList.SelectedIndex != -1))
            {
                string actcube = this.comboCubes.SelectedItem.ToString();
                if ((String.Equals(actcube, old_actCube)) &&
                    (this.SelectedElements.Count > 0)) // Selected cube is the same as before.
                {
                    string[] cubDims = this.currConn.CubeListDimensions(this.ActiveDB, actcube);

                    int currTmpBtn = 0;
                    foreach (string cubDim in cubDims)
                    {
                        checkSelectedElements(ref this.panel1, this.ActiveDB, cubDim, currTmpBtn); // Check if elements have been deleted.
                        currTmpBtn++;
                    }
                }
                else
                {
                    old_actCube = actcube; // Save new selection.

                    this.btnNext.Enabled = true;
                    this.clearGroupBoxes();

                    string[] cubDims = this.currConn.CubeListDimensions(this.ActiveDB, actcube);

                    int currTmpBtn = 0;
                    entryTabIndex = 100;
                    foreach (string cubDim in cubDims)
                    {
                        this.AddDimensionEntry(ref this.panel1, cubDim, currTmpBtn);
                        this.SelectedElements.Add(new object[] { cubDim, new ArrayList() });

                        currTmpBtn++;
                        entryTabIndex += 10;
                    }
                }
            }
        }

        #endregion

        public void checkSelectedElements(ref System.Windows.Forms.Panel p1, string database, string dim, int pos)
        {
            if (p1 == null || String.IsNullOrEmpty(dim)) return;

            System.Object[] tmpSelection = (System.Object[])this.SelectedElements[pos];
            ArrayList currElements = (ArrayList)tmpSelection[1];

            ElementInfo[] dimDimElems = this.currConn.DimensionListElements(database, dim);
            List<string> elnames = new List<string>();
            ElementInfo dimDimElem;

            for (int i = 0; i < dimDimElems.Length; i++)
            {
                dimDimElem = dimDimElems[i];
                elnames.Add(dimDimElem.Name);
            }

            for (int i = 0; i < currElements.Count; i++)
            {
                object[] objArr = (object[])currElements[i];
                string sName = (string)objArr[0];

                if (!elnames.Contains(sName)) // sName has been deleted from this dimension.
                {
                    currElements.RemoveAt(i); // Remove sName from SelectedElements.
                    // Set label.Text:
                    foreach (System.Windows.Forms.Control lab in p1.Controls)
                    {
                        if ((lab.Tag != null) && (lab.Name != null) && (lab.Name == "label") && String.Equals(lab.Tag as string, tmpSelection[0] as string))
                        {
                            string tmpToolTip = " ";
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

                            tmpToolTip = tmpToolTip.Substring(0, tmpToolTip.Length - 1).Trim();

                            if (String.IsNullOrEmpty(tmpToolTip))
                            {
                                tmpToolTip = "(" + ResourceInitializer.LABEL_SELECT_ALL_ELEMENTS + ")";
                            }

                            if (tmpToolTip.Length < 55)
                            {
                                lab.Text = tmpToolTip;
                            }
                            else
                            {
                                lab.Text = tmpToolTip.Substring(0, 54) + "...";
                            }
                            break;
                        }
                    }
                }
            }
        }

        #endregion

        #region Add dimension entry in the list

        public void b_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
            int currItem = 0;
            foreach (object[] o in this.SelectedElements)
            {
                if ((string)o[0] == (string)b.Tag)
                    break;
                currItem++;
            }

            System.Object[] tmpSelection = (System.Object[])this.SelectedElements[currItem];
            ArrayList currElements = (ArrayList)tmpSelection[1];

            ChooseElements frmename = new ChooseElements(this.ActiveHostname + "/" + this.ActiveDB, (string)b.Tag);
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

                if (String.IsNullOrEmpty(tmpToolTip))
                {
                    tmpToolTip = "(" + ResourceInitializer.LABEL_SELECT_ALL_ELEMENTS + ")";
                }

                foreach (System.Windows.Forms.Control l in this.panel1.Controls)
                {
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
            if (p1 == null || String.IsNullOrEmpty(dim))
                return;

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
            b.FlatStyle = FlatStyle.Flat;
            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.01f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

            l.BackColor = ResourceInitializer.FormStdBackgroundColor;
            l.Text = "(" + ResourceInitializer.LABEL_SELECT_ALL_ELEMENTS + ")";
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

        #endregion

        #region Rest


        private void do_terminate()
        {
            this.impcore.Terminate();
            if (!this.finishing)
            {
                this.do_exit();
            }
        }


        private void ImportWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.comboCubes.SaveItem();
        }

        private void ImportWizard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == (int)System.Windows.Forms.Keys.Escape)
            {
                this.do_terminate();
            }
        }

        private void xpCancel_Click(object sender, System.EventArgs e)
        {
            this.do_terminate();
        }

        private void do_part_init()
        {
            this.impcore = new ImportCore(this.origCulture, this.eH, ref this.ImportProgress, this);
            this.impcore.Terminating += new PaloThread(make_exit);
            this.impcore.clean_up();

            this.btnFinish.Enabled = true;
            this.btnFinish.Text = ResourceInitializer.BUTTON_CLOSE;
            this.oldcalc = ExcelHelper.GetCalculation();
            this.Height = NORM_HEIGHT;
            this.ImportProgress.Value = 0;
            this.ScreenUpdating.Visible = false;
            this.wizardTabControl1.SelectedIndex = 0;
            this.finishing = false;
            this.nextpage = 0;
            this.btnClearCube.Visible = true;
            
            try
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\Jedox\Palo\XlAddin\MRU\CSV");
                int valCnt = (int)regKey.ValueCount;
                this.comboBoxEx1.Items.Clear();
                for (int i = 0; i <= valCnt; i++)
                {
                    string s = (string)regKey.GetValue("url" + i.ToString());
                    if (s != null)
                    {
                        this.comboBoxEx1.Items.Add(s);
                    }
                }
            }
            catch
            { }

            // Save old selections.
            this.ActiveHostname = this.comboConnList.GetConnectionName();
            this.ActiveDB = this.comboConnList.GetDatabase();

            this.setCombo();
            this.preselectComboConnList();

            this.comboCubes.SetItem(RegUtils.ActiveCube);

            // set active combo item end            

            //this.wizardTabControl1.Height = NORM_HEIGHT;
            this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
            this.btnBack.Enabled = false;
            if (this.radioButton1.Checked == true || this.radioButton2.Checked == true || this.radioButton3.Checked)
            {
                this.btnNext.Enabled = true;
            }
            else
            {
                if (this.radioButton4.Checked == true)
                {
                    this.check_internal_loop();
                }
                else
                {
                    this.btnNext.Enabled = false;
                }
            }
            this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
            this.inTab = false;
            this.inTab2 = false;
            setheight(true);
        }

        public void do_exit()
        {
            this.btnFinish.Enabled = false;
            this.impcore.clean_up();
            this.finishing = false;
            ExcelHelper.ResetExcelStatusbar();
            ExcelHelper.PaloEnableLoop(false);
            ExcelHelper.AddNameValue(GeneralConst.IMPORT_ACTIVE, false);
            ExcelHelper.SetCalculation(this.oldcalc);
            ExcelHelper.SetScreenUpdating(true);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void make_exit(object sender)
        {
            this.do_exit();
        }

        public void reinit()
        {
            //this.TitlePanel.SuspendLayout();
           // this.LowerPanel.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.tabPageStep2.SuspendLayout();
            this.tabPageStep3.SuspendLayout();
            this.tabPageStep4.SuspendLayout();
            this.tabPageStep5.SuspendLayout();
            this.tabPageStep6.SuspendLayout();
            this.SuspendLayout();
            this.tabPageStep1.Location = new System.Drawing.Point(4, 4);
            this.tabPageStep2.Location = new System.Drawing.Point(4, 4);
            this.tabPageStep3.Location = new System.Drawing.Point(4, 4);
            this.tabPageStep4.Location = new System.Drawing.Point(4, 4);
            this.tabPageStep5.Location = new System.Drawing.Point(4, 4);
            this.tabPageStep6.Location = new System.Drawing.Point(4, 4);
            setCombo();
            this.preselectComboConnList();
            this.comboCubes.SetItem(RegUtils.ActiveCube);

            //this.TitlePanel.ResumeLayout(false);
            //this.LowerPanel.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.tabPageStep2.ResumeLayout(false);
            this.tabPageStep3.ResumeLayout(false);
            this.tabPageStep4.ResumeLayout(false);
            this.tabPageStep5.ResumeLayout(false);
            this.tabPageStep6.ResumeLayout(false);
            this.do_part_init();
            this.ResumeLayout(false);
        }

        private void StartDsDSN()
        {
            try
            {
                this.impcore.set_odbc_params(this.dsn.Text, this.user.Text, this.password.Text, this.sql.Text);
                this.impcore.start();
            }
            catch (Exception ex)
            {
                ExcelHelper.ResetExcelStatusbar();

                show_no_data_mesg = false;
                System.Windows.Forms.MessageBox.Show(ResourceInitializer.ERROR_READING_FROM_DATABASE + GeneralConst.UNIX_NEWLINE + ex.Message);
                ErrorHandler.DisplayError("Error reading from database:", ex);
                this.Height = NORM_HEIGHT;
                this.btnBack.Enabled = true;
                this.btnBack.Text = ResourceInitializer.BUTTON_BACK;
                this.btnNext.Text = ResourceInitializer.BUTTON_NEXT;
                this.inTab = true;
                this.wizardTabControl1.SelectedIndex = 2;
            }
        }

        private void StartDsCube()
        {
            try
            {
                if (this.comboCubes.SelectedIndex != -1)
                {
                    this.impcore.set_cube_params(this.currConn, this.ActiveDB, this.comboCubes.SelectedItem.ToString(), this.SelectedElements, new ArrayList(new object[] { this.textBox2.Text, this.comboBox1.SelectedIndex, this.comboBox4.SelectedIndex, this.comboBox3.SelectedIndex, this.textBox3.Text, this.checkBox1.Checked, this.checkBox2.Checked, this.BoxUseRule.Checked }));
                    this.impcore.start();
                }
            }
            catch (Exception exc)
            {
                ExcelHelper.ResetExcelStatusbar();

                show_no_data_mesg = false;
                System.Windows.Forms.MessageBox.Show(exc.Message);
                ErrorHandler.DisplayError("Error filling Cube data!", exc);
            }
        }

        private void StartDsCSV()
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

            try
            {
                string decpoint = ".";

                if (this.decpoint.Text.Length > 0)
                {
                    decpoint = this.decpoint.Text;
                }

                this.impcore.set_csv_params(this.comboBoxEx1.Text, this.IW_has_header.Checked, separator, decpoint, false, 0, false);
                this.impcore.start();
            }
            catch (Exception exc)
            {
                ExcelHelper.ResetExcelStatusbar();

                show_no_data_mesg = false;
                System.Windows.Forms.MessageBox.Show(exc.Message);
                ErrorHandler.DisplayError("Error filling CSV data!", exc);
            }
        }

        private void ScreenUpdating_CheckedChanged(object sender, System.EventArgs e)
        {
            this.impcore.set_screenupdating(this.ScreenUpdating.Checked);
            ExcelHelper.SetScreenUpdating(this.ScreenUpdating.Checked);
        }

        private void checknext_csv()
        {
            bool enabled = false;
            if (!String.IsNullOrEmpty(this.comboBoxEx1.Text))
            {
                enabled = true;
            }
            this.radioButton7.Enabled = enabled;
            this.radioButton8.Enabled = enabled;
            this.radioButton9.Enabled = enabled;
            this.radioButton10.Enabled = enabled;
            this.radioButton11.Enabled = enabled;
            this.decpoint.Enabled = enabled;
            this.IW_has_header.Enabled = enabled;
            this.label7.Enabled = enabled;

            this.checknext2();
        }

        private void ComboBox1_TextChanged(object sender, System.EventArgs e)
        {
            this.checknext_csv();
        }

        private void btSQLBrowse_Click(object sender, System.EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = this.initdir2;
            openFileDialog1.Filter = ResourceInitializer.LABEL_SQL_FILTER;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                string fn = (string)openFileDialog1.FileName;
                this.initdir2 = FileHelper.getdirname(fn);

                if (!this.comboBox2.Items.Contains(fn))
                {
                    this.comboBox2.Items.Add(fn);
                }

                this.comboBox2.Text = fn;
            }
            openFileDialog1.Dispose();
        }



        private void xpBrowse_Click(object sender, System.EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = this.initdir1;
            openFileDialog1.Filter = ResourceInitializer.LABEL_CSV_FILTER;
            openFileDialog1.FilterIndex = GetUDRegData(CSVFILTERINDEX);
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                string fn = (string)openFileDialog1.FileName;
                this.initdir1 = FileHelper.getdirname(fn);
                if (!String.IsNullOrEmpty(this.initdir1))
                {
                    RegUtils.SavePath = this.initdir1;
                }

                #region Combo/Registry

                if (!this.comboBoxEx1.Items.Contains(fn))
                {
                    this.comboBoxEx1.Items.Add(fn);
                    RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\Jedox\Palo\XlAddin\MRU\CSV");
                    int valCnt = (int)regKey.ValueCount;
                    valCnt++;
                    if (valCnt > 10) valCnt = 1;
                    regKey.SetValue("url" + valCnt, (string)openFileDialog1.FileName);
                    regKey.Close();
                }

                #endregion

                this.comboBoxEx1.Text = fn;
            }
            SetUDRegData(CSVFILTERINDEX, openFileDialog1.FilterIndex);

            openFileDialog1.Dispose();
            this.checknext_csv();
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.checknext_csv();
        }

        private void radioButton_CheckedChanged(RadioButton radiobutton)
        {
            if (radiobutton.Checked && !this.btnNext.Enabled)
            {
                this.btnNext.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            this.radioButton_CheckedChanged(this.radioButton1);
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            this.radioButton_CheckedChanged(this.radioButton2);
        }

        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            this.radioButton_CheckedChanged(this.radioButton3);
        }

        private void check_internal_loop()
        {
            Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();

            string formula = this.eH.getFormulaFromSpreadsheet(1, 2, ws);

            if (formula.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show(ResourceInitializer.ERROR_NO_FORMULA_B1);
                this.btnNext.Enabled = false;
            }
            else
            {
                this.btnNext.Enabled = true;
            }
        }

        private void radioButton4_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.radioButton4.Checked)
            {
                check_internal_loop();
            }
        }

        private void radioButton11_CheckedChanged(object sender, System.EventArgs e)
        {
            this.textBox1.Enabled = this.radioButton11.Checked;
            this.checknext2();
        }

        private void initSqlCombo()
        {
            object oldselection = this.comboBox2.SelectedItem;
            this.comboBox2.Items.Clear();
            this.comboBox2.Text = ResourceInitializer.LABEL_SELECT_ACTION;
            this.comboBox2.Items.AddRange(new object[] { ResourceInitializer.LABEL_NEW });

            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(this.initdir2);

                foreach (System.IO.FileInfo f in dir.GetFiles("*.sql"))
                {
                    this.comboBox2.Items.Add(f.FullName);
                }
            }
            catch
            {
            }
            this.comboBox2.SelectedIndex = (oldselection == null) ? 0 : this.comboBox2.FindStringExact(oldselection.ToString());
            this.btSQLDel.Enabled = false;
        }

        private void btSQLLoad_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string name = null;

            saveFileDialog1.InitialDirectory = this.initdir2;
            saveFileDialog1.Filter = ResourceInitializer.LABEL_SQL_FILTER;
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                this.initdir2 = FileHelper.getdirname((string)saveFileDialog1.FileName) + "\\";
                try
                {
                    System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);

                    try
                    {
                        sw.Write(this.sql.Text);
                        sw.Flush();
                    }
                    catch (Exception exc)
                    {
                        ErrorHandler.DisplayError("Error writing SQL-Statement!", exc);
                    }
                    finally
                    {
                        sw.Close();
                        fs.Close();
                    }
                }
                catch (Exception exc)
                {
                    ErrorHandler.DisplayError("Error saving SQL-Statement!", exc);
                }
            }
            else
            {
                return;
            }
            name = saveFileDialog1.FileName;
            saveFileDialog1.Dispose();

            this.initSqlCombo();

            this.comboBox2.SelectedIndex = this.comboBox2.FindStringExact(name);
        }

        private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.sql.Text = "";
            if (this.comboBox2.SelectedItem.ToString() != ResourceInitializer.LABEL_NEW)
            {
                try
                {
                    System.IO.FileStream fs = new System.IO.FileStream(this.comboBox2.SelectedItem.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                    System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8);

                    try
                    {
                        while (sr.Peek() > -1)
                        {
                            string line = sr.ReadLine();
                            if (!String.IsNullOrEmpty(line))
                            {
                                this.sql.Text = this.sql.Text + line + Environment.NewLine;
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        ErrorHandler.DisplayError("Error reading SQL-Statement!", exc);
                    }
                    finally
                    {
                        sr.Close();
                        fs.Close();
                    }
                }
                catch (Exception exc)
                {
                    ErrorHandler.DisplayError("Error Opening SQL-Statement!", exc);
                }
                this.btSQLDel.Enabled = true;
            }
            this.checknextsql();
        }

        private void btSQLDel_Click(object sender, System.EventArgs e)
        {
            if (this.comboBox2.SelectedItem.ToString() != ResourceInitializer.LABEL_NEW)
            {
                if (MessageBox.Show(ResourceInitializer.WARNING_DELETE_SQL_FILE, ResourceInitializer.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.sql.Text = "";
                    File.Delete(this.initdir2 + this.comboBox2.SelectedItem.ToString());
                    this.initSqlCombo();
                }
            }
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

        private void dsn_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.checknextsql();
        }

        private void sql_TextChanged(object sender, System.EventArgs e)
        {
            this.checknextsql();
        }

        private void sql_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && (e.KeyValue == (int)Keys.A))
            {// handle CTRL + A
                e.Handled = true;
                this.sql.SelectAll();
            }
        }

        private void check_sql_text()
        {
            string tmpstr = this.sql.Text.Trim();
            int pos = tmpstr.IndexOf("SELECT", StringComparison.InvariantCultureIgnoreCase);

            if (pos < 0)
            {
                this.sql.Text = "";
            }
            else
            {
                tmpstr = tmpstr.Substring(pos);
                int count = tmpstr.Length;
                bool instring = false;

                for (int i = 0; i < count; i++)
                {
                    if (tmpstr[i] == System.Convert.ToChar("'")) instring = !instring;
                    if ((tmpstr[i] == ';') && !instring)
                    {
                        tmpstr = tmpstr.Substring(0, i + 1);
                        break;
                    }
                }
                this.sql.Text = tmpstr;
            }

            this.checknextsql();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            this.checknext2();
        }

        #endregion

        #region ClearCube
        private void btnClearCube_Click(object sender, EventArgs e)
        {
            try
            {
                this.ccw = new ClearCube(0, "", 0);
                this.ccw.ShowDialog();
                this.ccw.Dispose();
                this.ccw = null;
                this.comboCubes.SetItem(RegUtils.ActiveCube);
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error invoking Clear Cube", exc);
            }
        }
        #endregion

        private void ImportWizard_FormClosed(object sender, FormClosedEventArgs e)
        {
            setheight(true);
        }












    }
}