 /* 
 *
 * Copyright (C) 2006-2009 Jedox AG
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
namespace Jedox.Palo.XlAddin.Forms
{
	using Microsoft.Win32;
	using System;
	using System.Collections;
	using System.Data;
	using System.Globalization;
	using System.Runtime.InteropServices;
	using System.Threading;
	using System.Windows.Forms;
	using Jedox.Palo.Comm;
	using Jedox.Palo.XlAddin.Utils;

	[ComVisible(false)]
	public class ClearCubeWizard : System.Windows.Forms.Form//NETXP.Forms.Wizard
	{
		const int NORM_HEIGHT = 424;
		const int FINISH_HEIGHT = 210;

		#region Define Vars


		private Jedox.Palo.Comm.Connection currConn;

		private string ActiveDB;
		private string ActiveCube;
		private string ActiveHostname;

		private ArrayList SelectedElements;

		private string CsvFileToWrite;
		//private ImportCore impcore = null;
		private bool finishing;// = false;
		//private bool show_no_data_mesg = true;
		private Thread t;// = null;
		private int nextpage;// = 0;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private NETXP.Controls.XPButton xpBack;
		private NETXP.Controls.XPButton xpNext;
        private NETXP.Controls.XPButton xpCancel;
		private System.Windows.Forms.ProgressBar ImportProgress;
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.ImageList imgListServerIcons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage0;

		#endregion

		#region Construct / Destruct 
		public ClearCubeWizard(string decpoint, CultureInfo originalUICulture,int serverid, string hostname, string dbN, string cubeName)
		{
			InitializeComponent();

            // to avoid the Exception with the message
            // Cross-thread operation not valid: Control 'ImportProgress' accessed from a thread other than the thread it was created on.

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false; 

			this.ActiveCube = cubeName;
			this.ActiveDB = dbN;
			this.ActiveHostname = hostname;

            this.SelectedElements = new ArrayList();
			this.currConn = Jedox.Palo.XlAddin.Connections.GetConnection(serverid);
			//this.decpoint.Text = decpoint;
			//this.impcore = new ImportCore(originalUICulture, null, ref this.ImportProgress, this);
			//this.impcore.Terminating += new PaloThread(make_exit);

			string[] cubDims = this.currConn.CubeListDimensions(this.ActiveDB,this.ActiveCube);
			int currTmpBtn = 0;
			foreach(string cubDim in cubDims)
			{
				this.AddDimensionEntry(ref this.panel1, cubDim, currTmpBtn);
				this.SelectedElements.Add(new object[]{cubDim,new ArrayList()});
				currTmpBtn++;
			}


			try
			{
				RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\Jedox\PaloXlAddin\MRU\CSV2");
				int valCnt = (int)regKey.ValueCount;
				/*this.comboBoxEx1.Items.Clear();
				for(int i=0;i<=valCnt;i++)
				{
					string s = (string)regKey.GetValue("url" + i.ToString());
					if(s != null)
						this.comboBoxEx1.Items.Add(s);
				}*/
			}
			catch(Exception exc)
			{
				Jedox.Palo.XlAddin.Utils.ErrorHandler.DisplayError("Error getting Registry Values.", exc);
			}

			this.do_part_init();

			this.pictureBox1.Image = ResourceInitializer.WizardLogo;
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

			this.Text = ResourceInitializer.TITLE_EXPORT_WIZARD;
	//		this.PageTitle.Text = ResourceInitializer.TITLE_EXPORT_WIZARD;
			
			this.xpBack.Text = ResourceInitializer.BUTTON_BACK;
			this.xpNext.Text = ResourceInitializer.BUTTON_NEXT;
			this.xpCancel.Text = ResourceInitializer.BUTTON_CLOSE;
/*
			this.xpBrowse.Text = ResourceInitializer.BUTTON_BROWSE;
			this.label4.Text = ResourceInitializer.LABEL_EXPORT_PAGE_3_1;
			this.label3.Text = ResourceInitializer.LABEL_EXPORT_PAGE2_2;
			this.radioButton7.Text = ResourceInitializer.LABEL_OPTION_TAB;
			this.radioButton10.Text = ResourceInitializer.LABEL_OPTION_BLANK;
			this.radioButton8.Text = ResourceInitializer.LABEL_OPTION_COMMA;
			this.radioButton11.Text = ResourceInitializer.LABEL_OPTION_USERDEFINED;
			this.radioButton9.Text = ResourceInitializer.LABEL_OPTION_SEMICOLON;
			this.label7.Text = ResourceInitializer.LABEL_OPTION_DECIMALPOINT;
            this.groupBox1.Text = ResourceInitializer.LABEL_IMPORT_PAGE5_1;
            this.checkBox1.Text = ResourceInitializer.LABEL_IMPORT_PAGE5_2;
            this.checkBox2.Text = ResourceInitializer.LABEL_IMPORT_PAGE5_3;
            this.Append2csv.Text = ResourceInitializer.TEXT_APPEND2CSV;
            this.comboBoxEx1.TextChanged += new System.EventHandler(this.ComboBox1_TextChanged);
            */
			this.label8.Text = "";//ResourceInitializer.LABEL_IMPORT_PAGE4_1;

			
	//		this.WizardPages.SelectedIndex = 4;

			

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
					Jedox.Palo.XlAddin.Utils.ErrorHandler.DisplayError("Error cleaning_up ClearCubeWizard", e);
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

		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClearCubeWizard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ImportProgress = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.xpBack = new NETXP.Controls.XPButton();
            this.xpNext = new NETXP.Controls.XPButton();
            this.xpCancel = new NETXP.Controls.XPButton();
            this.tabPage0 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgListServerIcons = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
    //        this.TitlePanel.SuspendLayout();
      //      this.LowerPanel.SuspendLayout();
        //    this.WizardPages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage0.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
   //         this.TitlePanel.Location = new System.Drawing.Point(160, 2);
     //       this.TitlePanel.Padding = new System.Windows.Forms.Padding(6);
       //     this.TitlePanel.Size = new System.Drawing.Size(458, 48);
            // 
            // ProductLogo
            // 
    //        this.ProductLogo.Location = new System.Drawing.Point(420, 6);
      //      this.ProductLogo.Size = new System.Drawing.Size(32, 36);
            // 
            // PageTitle
            // 
    //        this.PageTitle.Location = new System.Drawing.Point(52, 6);
      //      this.PageTitle.Size = new System.Drawing.Size(400, 36);
        //    this.PageTitle.Text = "";
            // 
            // Separator
            // 
    //        this.Separator.Location = new System.Drawing.Point(37, 6);
      //      this.Separator.Size = new System.Drawing.Size(15, 36);
            // 
            // WizardLogo
            // 
    //        this.WizardLogo.Location = new System.Drawing.Point(6, 6);
      //      this.WizardLogo.Size = new System.Drawing.Size(31, 36);
            // 
            // LowerPanel
            // 
     /*       this.LowerPanel.Controls.Add(this.xpBack);
            this.LowerPanel.Controls.Add(this.xpCancel);
            this.LowerPanel.Controls.Add(this.xpNext);
            this.LowerPanel.Location = new System.Drawing.Point(160, 351);
            this.LowerPanel.Size = new System.Drawing.Size(458, 42);
            this.LowerPanel.Controls.SetChildIndex(this.xpNext, 0);
            this.LowerPanel.Controls.SetChildIndex(this.xpCancel, 0);
            this.LowerPanel.Controls.SetChildIndex(this.BackButton, 0);
            this.LowerPanel.Controls.SetChildIndex(this.NextButton, 0);
            this.LowerPanel.Controls.SetChildIndex(this.OKBtn, 0);
            this.LowerPanel.Controls.SetChildIndex(this.CancelBtn, 0);
            this.LowerPanel.Controls.SetChildIndex(this.xpBack, 0);*/
            // 
            // CancelBtn
            // 
    //        this.CancelBtn.Location = new System.Drawing.Point(284, 48);
            // 
            // NextButton
            // 
      //      this.NextButton.Location = new System.Drawing.Point(180, 48);
            // 
            // BackButton
            // 
        //    this.BackButton.Location = new System.Drawing.Point(84, 48);
            // 
            // WizardPages
            // 
          /*  this.WizardPages.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.WizardPages.Controls.Add(this.tabPage0);
            this.WizardPages.Controls.Add(this.tabPage3);
            this.WizardPages.Dock = System.Windows.Forms.DockStyle.None;
            this.WizardPages.Location = new System.Drawing.Point(160, 50);
            this.WizardPages.Size = new System.Drawing.Size(576, 326);
            // 
            // EtchedLine
            // 
            this.EtchedLine.Location = new System.Drawing.Point(160, 393);
            this.EtchedLine.Size = new System.Drawing.Size(458, 8);
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(292, 48);*/
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Navy;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 399);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ImportProgress);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(568, 300);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Data Import";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(434, 34);
            this.label8.TabIndex = 3;
            // 
            // xpBack
            // 
            this.xpBack.Enabled = false;
            this.xpBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpBack.Location = new System.Drawing.Point(200, 8);
            this.xpBack.Name = "xpBack";
            this.xpBack.Size = new System.Drawing.Size(75, 23);
            this.xpBack.TabIndex = 9;
            this.xpBack.Click += new System.EventHandler(this.xpBack_Click);
            // 
            // xpNext
            // 
            this.xpNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpNext.Location = new System.Drawing.Point(280, 8);
            this.xpNext.Name = "xpNext";
            this.xpNext.Size = new System.Drawing.Size(80, 23);
            this.xpNext.TabIndex = 10;
            this.xpNext.Click += new System.EventHandler(this.xpNext_Click);
            // 
            // xpCancel
            // 
            this.xpCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.xpCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpCancel.Location = new System.Drawing.Point(376, 8);
            this.xpCancel.Name = "xpCancel";
            this.xpCancel.Size = new System.Drawing.Size(75, 23);
            this.xpCancel.TabIndex = 11;
            this.xpCancel.Click += new System.EventHandler(this.xpCancel_Click);
            // 
            // tabPage0
            // 
            this.tabPage0.Controls.Add(this.panel1);
            this.tabPage0.Location = new System.Drawing.Point(4, 4);
            this.tabPage0.Name = "tabPage0";
            this.tabPage0.Size = new System.Drawing.Size(568, 300);
            this.tabPage0.TabIndex = 4;
            this.tabPage0.Text = "Cube Import Step 1";
            this.tabPage0.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 296);
            this.panel1.TabIndex = 8;
            // 
            // imgListServerIcons
            // 
            this.imgListServerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListServerIcons.ImageStream")));
            this.imgListServerIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListServerIcons.Images.SetKeyName(0, "");
            this.imgListServerIcons.Images.SetKeyName(1, "");
            this.imgListServerIcons.Images.SetKeyName(2, "");
            this.imgListServerIcons.Images.SetKeyName(3, "");
            // 
            // ClearCubeWizard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(618, 401);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(624, 425);
            this.MinimumSize = new System.Drawing.Size(624, 200);
            this.Name = "ClearCubeWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
  //          this.Controls.SetChildIndex(this.TitlePanel, 0);
    //        this.Controls.SetChildIndex(this.EtchedLine, 0);
      //      this.Controls.SetChildIndex(this.WizardPages, 0);
        //    this.Controls.SetChildIndex(this.LowerPanel, 0);
          //  this.TitlePanel.ResumeLayout(false);
         //   this.LowerPanel.ResumeLayout(false);
           // this.WizardPages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage0.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Switching tab pages

		#region Back button

		private void xpBack_Click(object sender, System.EventArgs e)
		{
			/*if(this.xpBack.Text != ResourceInitializer.BUTTON_NEXT)
			{
				if(--this.WizardPages.SelectedIndex == 0)
				{
					this.xpBack.Enabled = false;
					this.Height = NORM_HEIGHT;
				}
				this.nextpage = this.WizardPages.SelectedIndex;
				this.xpNext.Enabled = true;
			}
			/*else
			{
				try
				{
					this.impcore.insertRowCsv();
				}			
				catch(Exception exc)
				{
					Jedox.Palo.XlAddin.Utils.ErrorHandler.DisplayError("Error stepping through export!", exc);
				}
			}*/
		}


		#endregion

		#region Next button

		private void checknext2()
		{
			/*if ((this.comboBoxEx1.Text.Length == 0) || (this.radioButton11.Checked && (this.textBox1.Text.Length == 0)))
			{
				this.xpNext.Enabled = false;
			}
			else
			{
				this.xpNext.Enabled = true;
			}*/
		}

		private void manageStartPage()
		{
			if (++this.nextpage > 3)
					this.nextpage = 0;
		}	

		private void xpNext_Click(object sender, System.EventArgs e)
		{
			if (this.xpNext.Text == ResourceInitializer.BUTTON_FINISH)
			{
				try
				{
					Jedox.Palo.XlAddin.Utils.ExcelHelper.oExcelApp.StatusBar = false;
					this.StartDsCube();
					/*if (this.impcore.empty())
					{
						if (show_no_data_mesg) System.Windows.Forms.MessageBox.Show(ResourceInitializer.ERROR_DATA_NOT_FOUND, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
						show_no_data_mesg = true;
					}
					else
					{*/
						this.SuspendLayout();
						//this.WizardPages.SelectedIndex = this.nextpage;
		//				this.WizardPages.SelectedIndex = 3;
						this.pictureBox1.SizeMode =System.Windows.Forms.PictureBoxSizeMode.Normal;
						this.Height = FINISH_HEIGHT;
						this.xpBack.Text = ResourceInitializer.BUTTON_NEXT;
						this.xpBack.Enabled = true;
						this.xpBack.Visible = false;
						this.xpNext.Text = ResourceInitializer.BUTTON_FINISH;
						this.xpNext.Enabled= false;
						this.xpBack.Focus();
						this.ResumeLayout();
					//}
                    
					//this.t = new Thread(new ThreadStart(this.impcore.t_insertRowCsv));
					this.finishing = true;
					this.t.Start();
				}			
				catch(Exception exc)
				{
					Jedox.Palo.XlAddin.Utils.ErrorHandler.DisplayError("Error finishing Export!", exc);
				}
			}
			else
			{
				this.manageStartPage();
				switch(this.nextpage)
				{
					#region case 0 - Cube step 1
					case 0:
			//			this.WizardPages.SelectedIndex = this.nextpage;
						this.checknext2();
						this.Height = NORM_HEIGHT;
						this.xpBack.Text = ResourceInitializer.BUTTON_BACK;
						this.xpNext.Text = ResourceInitializer.BUTTON_NEXT;
						this.xpBack.Enabled = false;
						this.xpNext.Enabled = true;
						break;
					#endregion
					#region case 1 - Cube step 2
					case 1:
						//if(this.radioButton3.Checked)
						{
			//				this.WizardPages.SelectedIndex = this.nextpage;
							this.xpBack.Enabled = true;
							this.xpNext.Enabled = true;
						}
						break;
					#endregion
					#region case 2 - CSV
					case 2:
			//			this.WizardPages.SelectedIndex = this.nextpage;
						this.checknext2();
						this.Height = NORM_HEIGHT;
						this.xpBack.Enabled = true;
						this.xpBack.Text = ResourceInitializer.BUTTON_BACK;
						this.xpNext.Text = ResourceInitializer.BUTTON_FINISH;
						break;
					#endregion
					#region case 3 - Finish
					case 3:
						/*this.StartDsCube();
						Jedox.Palo.XlAddin.Utils.ExcelHelper.oExcelApp.StatusBar = false;

						if (this.impcore.empty())
						{
							System.Windows.Forms.MessageBox.Show("No data found!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							this.SuspendLayout();
							this.WizardPages.SelectedIndex = this.nextpage;
							this.pictureBox1.SizeMode =System.Windows.Forms.PictureBoxSizeMode.Normal;
							this.Height = FINISH_HEIGHT;
							this.xpBack.Text = ResourceInitializer.BUTTON_NEXT;
							this.xpBack.Enabled = true;
							this.xpNext.Text = ResourceInitializer.BUTTON_FINISH;
							this.xpNext.Enabled = true;
							this.xpBack.Focus();
							this.ResumeLayout();
						}*/
						break;
						#endregion
				}
			}
		}

		#endregion

		#endregion

		#region Add dimension entry in the list

		public void b_Click(object sender, System.EventArgs e)
		{
			NETXP.Controls.XPButton b = (NETXP.Controls.XPButton)sender;
			int currItem = 0;
			foreach(object[] o in this.SelectedElements)
			{
				if((string)o[0] == (string)b.Tag)
					break;
				currItem++;
			}

			System.Object[] tmpSelection = (System.Object[])this.SelectedElements[currItem];
			ArrayList currElements = (ArrayList)tmpSelection[1];

			Jedox.Palo.XlAddin.Forms.ChooseElements frmename = new Jedox.Palo.XlAddin.Forms.ChooseElements(this.ActiveHostname + "/" + this.ActiveDB, (string)b.Tag);
			frmename.set_selection(ref currElements, true);
			if(frmename.ShowDialog() == DialogResult.OK)
			{
				string tmpToolTip = " ";
				int tmpCounter = 0;
				tmpSelection[1] = currElements;
				foreach(object[] s in currElements)
				{
					if(tmpCounter > 10)
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

				/*foreach(System.Windows.Forms.Control l in this.panel1.Controls)
				{
					if(l.Tag != null && l.Name != "sibling" && l.Tag == b.Tag)
					{
						this.toolTip1.SetToolTip(l, tmpToolTip);
						break;
					}
				}*/

				foreach(System.Windows.Forms.Control l in this.panel1.Controls)
				{
					if(l.Tag != null && l.Name != null && l.Name == "label" && l.Tag == b.Tag)
					{
						if(tmpToolTip.Length < 55)
							l.Text = tmpToolTip;
						else
							l.Text = tmpToolTip.Substring(0,54) + "...";
						break;
					}
				}
			}
			frmename.Dispose();
			frmename = null;

		}

		public void AddDimensionEntry(ref System.Windows.Forms.Panel p1, string dim, int pos)
		{
			NETXP.Controls.XPButton d = new NETXP.Controls.XPButton();
			NETXP.Controls.XPButton b = new NETXP.Controls.XPButton();
			Label l = new Label();
			string dimLabel = "";

			if(dim.Length < 12)
				dimLabel = dim;
			else
				dimLabel = dim.Substring(0,11);

			d.Text = dimLabel;
			d.Width = 85;
			d.Height = 23;
			d.Left = 6;
			d.Top = 8 + pos * 23;
			d.Tag = dim;
			this.toolTip1.SetToolTip(d, dim);

			b.Text = "...";
			b.Width = 16;
			b.Height = d.Height;
			b.Left = d.Right - 1;
			b.Top = d.Top;
			b.Click += new EventHandler(b_Click);
			b.Tag = d.Tag;
			this.toolTip1.SetToolTip(b, ResourceInitializer.TIP_CHOOSE_ELEMENTS);
			b.Name = "sibling";

			l.Text = "(" + ResourceInitializer.LABEL_SELECT_ALL_ELEMENTS + ")";
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

		private void xpCancel_Click(object sender, System.EventArgs e)
		{
			//this.impcore.Terminate();
			if (!this.finishing) this.do_exit();
		}
				
		private void do_part_init()
		{
			//this.impcore.clean_up();

			this.Height = NORM_HEIGHT;
			this.ImportProgress.Value = 0;
	//		this.WizardPages.SelectedIndex = 0;
		}

		public void do_exit()
		{
			this.finishing = false;
			try
			{
				Jedox.Palo.XlAddin.Utils.ExcelHelper.oExcelApp.StatusBar = false;
			}
			catch(Exception exc)
			{
				Jedox.Palo.XlAddin.Utils.ErrorHandler.DisplayError("Error Setting Excel Statusbar.", exc);
			}

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void make_exit(object sender)
		{
			this.do_exit();
		}

		public void reinit()
		{
			this.TitlePanel.SuspendLayout();
			this.LowerPanel.SuspendLayout();
			this.WizardPages.SuspendLayout();
			this.tabPage0.SuspendLayout();
		//	this.tabPage1.SuspendLayout();
		//	this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			this.tabPage0.Location = new System.Drawing.Point(4, 4);
		//	this.tabPage1.Location = new System.Drawing.Point(4, 4);
		//	this.tabPage2.Location = new System.Drawing.Point(4, 4);
			this.tabPage3.Location = new System.Drawing.Point(4, 4);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.TitlePanel.ResumeLayout(false);
			this.LowerPanel.ResumeLayout(false);
			this.WizardPages.ResumeLayout(false);
			this.tabPage0.ResumeLayout(false);
		//	this.tabPage1.ResumeLayout(false);
		//	this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.do_part_init();
			this.ResumeLayout(false);
		}

		private void StartDsCube() 
		{	
			/*try
			{
				char separator = ' ';
				if(this.radioButton7.Checked == true)
				{
					separator = '	';							
				}
				else if(this.radioButton8.Checked == true)
				{
					separator = ',';
				}
				else if(this.radioButton9.Checked == true)
				{
					separator = ';';
				}
				else if(this.radioButton10.Checked == true)
				{
					separator = ' ';
				}
				else if(this.radioButton11.Checked == true)
				{
					char[] tmp = this.textBox1.Text.ToCharArray();
					separator = tmp[0];
				}

				string decpoint = ".";

				if (this.decpoint.Text.Length > 0)
				{	
					decpoint = this.decpoint.Text;
				}

				//this.impcore.set_csv_params(this.comboBoxEx1.Text, false, separator, decpoint, this.Append2csv.Checked);
				//this.impcore.set_cube_params(this.currConn, this.ActiveDB, this.ActiveCube, this.SelectedElements, new ArrayList(new object[]{this.textBox2.Text, this.comboBox1.SelectedIndex, this.comboBox4.SelectedIndex, this.comboBox3.SelectedIndex, this.textBox3.Text, this.checkBox1.Checked, this.checkBox2.Checked}));
				//this.impcore.start();
			}
			catch(Exception exc)
			{
				System.Windows.Forms.MessageBox.Show(exc.Message);
				show_no_data_mesg = false;
				Jedox.Palo.XlAddin.Utils.ErrorHandler.DisplayError("Error filling Cube data!", exc);
			}*/
		}

		private void checknext_csv()
		{
			bool enabled = false;
			/*if 	(this.comboBoxEx1.Text != "")
			{
				enabled = true;
			}
			this.radioButton7.Enabled = enabled;
			this.radioButton8.Enabled = enabled;
			this.radioButton9.Enabled = enabled;
			this.radioButton10.Enabled = enabled;
			this.radioButton11.Enabled = enabled;
			this.decpoint.Enabled = enabled;
			this.Append2csv.Enabled = enabled;
			this.label7.Enabled = enabled;
            */
			this.checknext2();
		}

		private void ComboBox1_TextChanged(object sender, System.EventArgs e)
		{
			this.checknext_csv();
		}

		private void xpBrowse_Click(object sender, System.EventArgs e)
		{
			
			SaveFileDialog openFileDialog1 = new SaveFileDialog();

			openFileDialog1.InitialDirectory = System.Environment.GetFolderPath((System.Environment.SpecialFolder)0x0005) + "\\Jedox\\";
			openFileDialog1.Filter = ResourceInitializer.LABEL_CSV_FILTER;
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = false;

			if(openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
			{
				this.CsvFileToWrite = (string)openFileDialog1.FileName;
/*
				try
				{
					if(System.IO.File.Exists(this.CsvFileToWrite))
						System.IO.File.Delete(this.CsvFileToWrite);
				}
				catch(Exception exc)
				{
					Jedox.Palo.XlAddin.Utils.ErrorHandler.DisplayError("Error Deleting file.", exc);
				}
*/
		

				#region Combo/Registry

				/*
				 * If not found in combo add it to both combo and registry
				*/
				int i = 0;
				/*foreach(string itm in this.comboBoxEx1.Items)
				{
					if(itm == this.CsvFileToWrite)
						i++;
				}*/

				if (i == 0)
				{
				//	this.comboBoxEx1.Items.Add(this.CsvFileToWrite);
					RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\Jedox\PaloXlAddin\MRU\CSV2");
					int valCnt = (int)regKey.ValueCount;
					valCnt++;
					if( valCnt > 10 ) valCnt = 1;
					regKey.SetValue("url" + valCnt,(string)openFileDialog1.FileName);
					regKey.Close();
				}

				#endregion

			//	this.comboBoxEx1.Text= this.CsvFileToWrite;
				this.xpNext.Enabled = true;
			}
			openFileDialog1.Dispose();
			this.checknext_csv();

		}

		private void comboBoxEx1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.checknext_csv();
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.xpNext.Enabled == false)
			{
				this.xpNext.Enabled = true;
			}
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.xpNext.Enabled == false)
			{
				this.xpNext.Enabled = true;
			}
		}

		private void radioButton11_CheckedChanged(object sender, System.EventArgs e)
		{
		//	this.textBox1.Enabled = this.radioButton11.Checked;
			this.checknext2();
		}

		private void radioButton7_CheckedChanged(object sender, System.EventArgs e)
		{
			this.xpNext.Enabled = true;
		//	this.textBox1.Enabled = false;
		}

		private void radioButton8_CheckedChanged(object sender, System.EventArgs e)
		{
			this.xpNext.Enabled = true;
		//	this.textBox1.Enabled = false;
		}

		private void radioButton9_CheckedChanged(object sender, System.EventArgs e)
		{
			this.xpNext.Enabled = true;
		//	this.textBox1.Enabled = false;
		}

		private void radioButton10_CheckedChanged(object sender, System.EventArgs e)
		{
			this.xpNext.Enabled = true;
		//	this.textBox1.Enabled = false;
		}

		
		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			this.checknext2();
		}

		#endregion	
	}
}

