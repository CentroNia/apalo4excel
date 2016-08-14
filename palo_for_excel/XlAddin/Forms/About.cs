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
// JMM 10-31-13 Update revision #

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
	[ComVisible(false)]
	public class About : Form
	{
		private Panel pnlMain;
        private Button btnOk;
		private System.Timers.Timer timerAbout;
		private Label lblCopyright;
        private Label lblVersion;
        private Label lblStatus;
        private LinkLabel lblUpdate;
        private CheckBox chkUpdateSearch;
        private Label label1;
        private Label label2;
        private Label labelVersion1;
        private Button button1;
        private JTabControl tabctl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private PictureBox pictureBox1;
        private Button button2;
		private System.ComponentModel.Container components = null;

        public static string revision
        {
            get
            {
            // JMM 10-31-13            
            return "3.2." + Properties.Resources.WCREV;
            }

        }

		public About(bool timer, string msg)
		{
			InitializeComponent();
            this.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.pnlMain.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
			this.timerAbout.Enabled = false;
            
            #if NOTUSED
            if (timer == true)
            {
                this.timerAbout.Enabled = true;
                this.timerAbout.Interval = 3000;
            }
            else
            {

                chkUpdateSearch.Text = Utils.ResourceInitializer.ACTIVATE_UPDATE_SEARCH;
                chkUpdateSearch.Checked = (RegUtils.HeartBeat != 0) ;
                chkUpdateSearch.CheckedChanged += new EventHandler(chkUpdateSearch_CheckedChanged);
                chkUpdateSearch.Visible = true;

                lblUpdate.Text = Utils.ResourceInitializer.LabelCheckForUpdates;
                lblUpdate.LinkClicked += new LinkLabelLinkClickedEventHandler(lblUpdate_LinkClicked);

                handle_lbupdate_visible();
            }
            #endif
	
			pnlMain.Width = this.Width;
			pnlMain.Height = this.Height;
			this.lblStatus.Text = msg;
            // JMM 10-31-13
            this.lblVersion.Text = string.Format("(Build {0})", Properties.Resources.WCREV);
			this.btnOk.Text = Apalo.XlAddin.Utils.ResourceInitializer.BUTTON_OK;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.labelVersion1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUpdateSearch = new System.Windows.Forms.CheckBox();
            this.lblUpdate = new System.Windows.Forms.LinkLabel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timerAbout = new System.Timers.Timer();
            this.tabctl1 = new Apalo.XlAddin.JTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerAbout)).BeginInit();
            this.tabctl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSize = true;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.button1);
            this.pnlMain.Controls.Add(this.labelVersion1);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.chkUpdateSearch);
            this.pnlMain.Controls.Add(this.lblUpdate);
            this.pnlMain.Controls.Add(this.lblVersion);
            this.pnlMain.Controls.Add(this.lblCopyright);
            this.pnlMain.Controls.Add(this.btnOk);
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(310, 285);
            this.pnlMain.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(192, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 25);
            this.button1.TabIndex = 34;
            this.button1.Text = "Team Members";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelVersion1
            // 
            this.labelVersion1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelVersion1.AutoSize = true;
            this.labelVersion1.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion1.ForeColor = System.Drawing.Color.Navy;
            this.labelVersion1.Location = new System.Drawing.Point(41, 54);
            this.labelVersion1.Name = "labelVersion1";
            this.labelVersion1.Size = new System.Drawing.Size(227, 19);
            this.labelVersion1.TabIndex = 33;
            this.labelVersion1.Text = "Version 3.2 Open Source Edition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(28, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 33);
            this.label1.TabIndex = 31;
            this.label1.Text = "Apalo: Open Source BI";
            // 
            // chkUpdateSearch
            // 
            this.chkUpdateSearch.AutoSize = true;
            this.chkUpdateSearch.BackColor = System.Drawing.Color.Transparent;
            this.chkUpdateSearch.Enabled = false;
            this.chkUpdateSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.chkUpdateSearch.ForeColor = System.Drawing.Color.Navy;
            this.chkUpdateSearch.Location = new System.Drawing.Point(49, 227);
            this.chkUpdateSearch.Name = "chkUpdateSearch";
            this.chkUpdateSearch.Size = new System.Drawing.Size(167, 17);
            this.chkUpdateSearch.TabIndex = 30;
            this.chkUpdateSearch.Text = "Akitviere Akutalisierungssuche";
            this.chkUpdateSearch.UseVisualStyleBackColor = false;
            this.chkUpdateSearch.Visible = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.ActiveLinkColor = System.Drawing.Color.Navy;
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdate.DisabledLinkColor = System.Drawing.Color.Transparent;
            this.lblUpdate.Enabled = false;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.ForeColor = System.Drawing.Color.Navy;
            this.lblUpdate.LinkColor = System.Drawing.Color.Navy;
            this.lblUpdate.Location = new System.Drawing.Point(46, 199);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(110, 13);
            this.lblUpdate.TabIndex = 8;
            this.lblUpdate.TabStop = true;
            this.lblUpdate.Text = "check for updates";
            this.lblUpdate.Visible = false;
            this.lblUpdate.VisitedLinkColor = System.Drawing.Color.Navy;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Navy;
            this.lblVersion.Location = new System.Drawing.Point(109, 82);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(90, 19);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "(Build 0000)";
            // 
            // lblCopyright
            // 
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.Color.Navy;
            this.lblCopyright.Location = new System.Drawing.Point(46, 115);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(219, 35);
            this.lblCopyright.TabIndex = 5;
            this.lblCopyright.Text = "Palo Community Edition Copyright © 2004-2011 Jedox AG";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(46, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 35);
            this.label2.TabIndex = 32;
            this.label2.Text = "Apalo Updates Copyright © 2013-2016 Junction BI LLC";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.Navy;
            this.btnOk.Location = new System.Drawing.Point(49, 269);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Navy;
            this.lblStatus.Location = new System.Drawing.Point(47, 185);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(234, 68);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerAbout
            // 
            this.timerAbout.Enabled = true;
            this.timerAbout.SynchronizingObject = this;
            this.timerAbout.Elapsed += new System.Timers.ElapsedEventHandler(this.Close);
            // 
            // tabctl1
            // 
            this.tabctl1.Controls.Add(this.tabPage1);
            this.tabctl1.Controls.Add(this.tabPage2);
            this.tabctl1.HideTabs = true;
            this.tabctl1.Location = new System.Drawing.Point(0, 0);
            this.tabctl1.Name = "tabctl1";
            this.tabctl1.SelectedIndex = 0;
            this.tabctl1.Size = new System.Drawing.Size(324, 317);
            this.tabctl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.pnlMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(316, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(316, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(40, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "<<< Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 285);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(324, 317);
            this.Controls.Add(this.tabctl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.TopMost = true;
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerAbout)).EndInit();
            this.tabctl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

        private void handle_lbupdate_visible()
        {
            lblUpdate.Visible = !chkUpdateSearch.Checked;
        }

        private void chkUpdateSearch_CheckedChanged(object sender, System.EventArgs e)
        {
                RegUtils.HeartBeat = (chkUpdateSearch.Checked) ? 1 : 0;
                handle_lbupdate_visible();
        }

		private void Close(object sender, System.Timers.ElapsedEventArgs e)
		{
			if(this.lblStatus.Text == "Starting PALO Designer Add-in ...")
			{
				this.DialogResult = DialogResult.OK;
			}
		}

        private void lblUpdate_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
        #if NOTUSED
            string url = "http://www.jedox.com/palo/version/?build=$WCREV$&lang=";
            string lang = Connect.PaloOnlineLanguage;

            this.TopMost = false;
            System.Diagnostics.Process.Start(url + lang);
        #endif
        }

        private void button1_Click(object sender, EventArgs e)
            {
            tabctl1.SelectedIndex = 1;
            }

        private void button2_Click(object sender, EventArgs e)
            {
            tabctl1.SelectedIndex = 0;
            }

	}
}
