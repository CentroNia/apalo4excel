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
namespace Apalo.XlAddin.Forms
{
    partial class InfoBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoBox));
            this.adTitleLogo = new System.Windows.Forms.TextBox();
            this.pctAdLogo = new System.Windows.Forms.PictureBox();
            this.tabControl = new Apalo.XlAddin.JTabControl();
            this.tabPageInfo = new Apalo.XlAddin.JTabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.chkAnnoyBox = new System.Windows.Forms.CheckBox();
            this.lblPaloMenu2 = new System.Windows.Forms.TextBox();
            this.lblPaloMenu1 = new System.Windows.Forms.TextBox();
            this.adTitle = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.bntAbout = new System.Windows.Forms.Button();
            this.tabPageLicense = new Apalo.XlAddin.JTabPage();
            this.lblComparison = new System.Windows.Forms.TextBox();
            this.lblCommunity = new System.Windows.Forms.TextBox();
            this.lblQuote = new System.Windows.Forms.TextBox();
            this.lblLicense = new System.Windows.Forms.TextBox();
            this.btnQuote = new System.Windows.Forms.Button();
            this.btnCEDownload = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctAdLogo)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.tabPageLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // adTitleLogo
            // 
            this.adTitleLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(77)))), ((int)(((byte)(160)))));
            this.adTitleLogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adTitleLogo.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adTitleLogo.ForeColor = System.Drawing.Color.White;
            this.adTitleLogo.Location = new System.Drawing.Point(528, 0);
            this.adTitleLogo.Multiline = true;
            this.adTitleLogo.Name = "adTitleLogo";
            this.adTitleLogo.ReadOnly = true;
            this.adTitleLogo.Size = new System.Drawing.Size(115, 178);
            this.adTitleLogo.TabIndex = 9;
            this.adTitleLogo.TabStop = false;
            this.adTitleLogo.Text = "Apalo:\r\nOpen\r\nSource";
            // 
            // pctAdLogo
            // 
            this.pctAdLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pctAdLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pctAdLogo.ErrorImage")));
            this.pctAdLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctAdLogo.Image")));
            this.pctAdLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pctAdLogo.InitialImage")));
            this.pctAdLogo.Location = new System.Drawing.Point(0, 0);
            this.pctAdLogo.Name = "pctAdLogo";
            this.pctAdLogo.Size = new System.Drawing.Size(643, 178);
            this.pctAdLogo.TabIndex = 0;
            this.pctAdLogo.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInfo);
            this.tabControl.Controls.Add(this.tabPageLicense);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.ForeColor = System.Drawing.SystemColors.Control;
            this.tabControl.HideTabs = true;
            this.tabControl.Location = new System.Drawing.Point(0, 184);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(643, 325);
            this.tabControl.TabIndex = 17;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.label2);
            this.tabPageInfo.Controls.Add(this.lblCopyright);
            this.tabPageInfo.Controls.Add(this.chkAnnoyBox);
            this.tabPageInfo.Controls.Add(this.lblPaloMenu2);
            this.tabPageInfo.Controls.Add(this.lblPaloMenu1);
            this.tabPageInfo.Controls.Add(this.adTitle);
            this.tabPageInfo.Controls.Add(this.btnClose);
            this.tabPageInfo.Controls.Add(this.bntAbout);
            this.tabPageInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Selected = true;
            this.tabPageInfo.Size = new System.Drawing.Size(635, 299);
            this.tabPageInfo.TabIndex = 4;
            this.tabPageInfo.Title = "";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(11, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 22);
            this.label2.TabIndex = 33;
            this.label2.Text = "Apalo Updates Copyright © 2013-2016 Junction BI LLC";
            // 
            // lblCopyright
            // 
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.Color.Navy;
            this.lblCopyright.Location = new System.Drawing.Point(11, 170);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(402, 22);
            this.lblCopyright.TabIndex = 30;
            this.lblCopyright.Text = "Palo Community Edition Copyright © 2004-2011 Jedox AG";
            // 
            // chkAnnoyBox
            // 
            this.chkAnnoyBox.AutoSize = true;
            this.chkAnnoyBox.Checked = true;
            this.chkAnnoyBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnnoyBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAnnoyBox.Location = new System.Drawing.Point(11, 266);
            this.chkAnnoyBox.Name = "chkAnnoyBox";
            this.chkAnnoyBox.Size = new System.Drawing.Size(307, 18);
            this.chkAnnoyBox.TabIndex = 29;
            this.chkAnnoyBox.Text = "Diesen Dialogbox beim ÷fnen von Palo  for Excel anzeigen";
            this.chkAnnoyBox.UseVisualStyleBackColor = true;
            this.chkAnnoyBox.CheckedChanged += new System.EventHandler(this.chkAnnoyBox_CheckedChanged);
            // 
            // lblPaloMenu2
            // 
            this.lblPaloMenu2.BackColor = System.Drawing.SystemColors.Control;
            this.lblPaloMenu2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblPaloMenu2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaloMenu2.Location = new System.Drawing.Point(14, 87);
            this.lblPaloMenu2.Multiline = true;
            this.lblPaloMenu2.Name = "lblPaloMenu2";
            this.lblPaloMenu2.ReadOnly = true;
            this.lblPaloMenu2.Size = new System.Drawing.Size(521, 80);
            this.lblPaloMenu2.TabIndex = 28;
            this.lblPaloMenu2.TabStop = false;
            this.lblPaloMenu2.Text = "label6";
            // 
            // lblPaloMenu1
            // 
            this.lblPaloMenu1.BackColor = System.Drawing.SystemColors.Control;
            this.lblPaloMenu1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblPaloMenu1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaloMenu1.Location = new System.Drawing.Point(11, 41);
            this.lblPaloMenu1.Multiline = true;
            this.lblPaloMenu1.Name = "lblPaloMenu1";
            this.lblPaloMenu1.ReadOnly = true;
            this.lblPaloMenu1.Size = new System.Drawing.Size(524, 38);
            this.lblPaloMenu1.TabIndex = 26;
            this.lblPaloMenu1.TabStop = false;
            this.lblPaloMenu1.Text = "label4";
            // 
            // adTitle
            // 
            this.adTitle.BackColor = System.Drawing.SystemColors.Control;
            this.adTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.adTitle.Location = new System.Drawing.Point(6, 6);
            this.adTitle.Multiline = true;
            this.adTitle.Name = "adTitle";
            this.adTitle.ReadOnly = true;
            this.adTitle.Size = new System.Drawing.Size(618, 19);
            this.adTitle.TabIndex = 23;
            this.adTitle.TabStop = false;
            this.adTitle.Text = "Title Text";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(489, 266);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 29);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Schlieﬂen";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // bntAbout
            // 
            this.bntAbout.Location = new System.Drawing.Point(338, 266);
            this.bntAbout.Name = "bntAbout";
            this.bntAbout.Size = new System.Drawing.Size(138, 29);
            this.bntAbout.TabIndex = 21;
            this.bntAbout.Text = "About Apalo for Excel";
            this.bntAbout.UseVisualStyleBackColor = true;
            this.bntAbout.Click += new System.EventHandler(this.bntAbout_Click);
            // 
            // tabPageLicense
            // 
            this.tabPageLicense.Controls.Add(this.lblComparison);
            this.tabPageLicense.Controls.Add(this.lblCommunity);
            this.tabPageLicense.Controls.Add(this.lblQuote);
            this.tabPageLicense.Controls.Add(this.lblLicense);
            this.tabPageLicense.Controls.Add(this.btnQuote);
            this.tabPageLicense.Controls.Add(this.btnCEDownload);
            this.tabPageLicense.Controls.Add(this.btnCompare);
            this.tabPageLicense.Controls.Add(this.btnContinue);
            this.tabPageLicense.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPageLicense.Location = new System.Drawing.Point(4, 22);
            this.tabPageLicense.Name = "tabPageLicense";
            this.tabPageLicense.Selected = false;
            this.tabPageLicense.Size = new System.Drawing.Size(635, 299);
            this.tabPageLicense.TabIndex = 5;
            this.tabPageLicense.Title = "";
            // 
            // lblComparison
            // 
            this.lblComparison.BackColor = System.Drawing.SystemColors.Control;
            this.lblComparison.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblComparison.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComparison.Location = new System.Drawing.Point(13, 169);
            this.lblComparison.Multiline = true;
            this.lblComparison.Name = "lblComparison";
            this.lblComparison.Size = new System.Drawing.Size(323, 116);
            this.lblComparison.TabIndex = 36;
            this.lblComparison.TabStop = false;
            this.lblComparison.Text = "Quote";
            // 
            // lblCommunity
            // 
            this.lblCommunity.BackColor = System.Drawing.SystemColors.Control;
            this.lblCommunity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblCommunity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommunity.Location = new System.Drawing.Point(13, 92);
            this.lblCommunity.Multiline = true;
            this.lblCommunity.Name = "lblCommunity";
            this.lblCommunity.Size = new System.Drawing.Size(323, 71);
            this.lblCommunity.TabIndex = 35;
            this.lblCommunity.TabStop = false;
            this.lblCommunity.Text = "Quote";
            // 
            // lblQuote
            // 
            this.lblQuote.BackColor = System.Drawing.SystemColors.Control;
            this.lblQuote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblQuote.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuote.Location = new System.Drawing.Point(12, 30);
            this.lblQuote.Multiline = true;
            this.lblQuote.Name = "lblQuote";
            this.lblQuote.Size = new System.Drawing.Size(323, 56);
            this.lblQuote.TabIndex = 34;
            this.lblQuote.TabStop = false;
            this.lblQuote.Text = "Quote";
            // 
            // lblLicense
            // 
            this.lblLicense.BackColor = System.Drawing.SystemColors.Control;
            this.lblLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblLicense.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLicense.Location = new System.Drawing.Point(6, 5);
            this.lblLicense.Multiline = true;
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.ReadOnly = true;
            this.lblLicense.Size = new System.Drawing.Size(618, 19);
            this.lblLicense.TabIndex = 33;
            this.lblLicense.TabStop = false;
            this.lblLicense.Text = "License";
            // 
            // btnQuote
            // 
            this.btnQuote.Location = new System.Drawing.Point(341, 43);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Size = new System.Drawing.Size(289, 29);
            this.btnQuote.TabIndex = 29;
            this.btnQuote.Text = "Angebot";
            this.btnQuote.UseVisualStyleBackColor = true;
            this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
            // 
            // btnCEDownload
            // 
            this.btnCEDownload.Location = new System.Drawing.Point(342, 102);
            this.btnCEDownload.Name = "btnCEDownload";
            this.btnCEDownload.Size = new System.Drawing.Size(289, 29);
            this.btnCEDownload.TabIndex = 30;
            this.btnCEDownload.Text = "Community";
            this.btnCEDownload.UseVisualStyleBackColor = true;
            this.btnCEDownload.Click += new System.EventHandler(this.btnCEDownload_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(341, 181);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(289, 29);
            this.btnCompare.TabIndex = 31;
            this.btnCompare.Text = "CE vs Premium";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContinue.Location = new System.Drawing.Point(492, 280);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(138, 29);
            this.btnContinue.TabIndex = 32;
            this.btnContinue.Text = "Weiter";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // InfoBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(643, 509);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.adTitleLogo);
            this.Controls.Add(this.pctAdLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apalo for Excel (Version: $WCREV$)";
            this.VisibleChanged += new System.EventHandler(this.InfoBox_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pctAdLogo)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.tabPageLicense.ResumeLayout(false);
            this.tabPageLicense.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctAdLogo;
        private System.Windows.Forms.TextBox adTitleLogo;
        private JTabControl tabControl;
        private JTabPage tabPageInfo;
        private System.Windows.Forms.CheckBox chkAnnoyBox;
        private System.Windows.Forms.TextBox lblPaloMenu2;
        private System.Windows.Forms.TextBox lblPaloMenu1;
        private System.Windows.Forms.TextBox adTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button bntAbout;
        private JTabPage tabPageLicense;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnCEDownload;
        private System.Windows.Forms.Button btnQuote;
        private System.Windows.Forms.TextBox lblLicense;
        private System.Windows.Forms.TextBox lblQuote;
        private System.Windows.Forms.TextBox lblComparison;
        private System.Windows.Forms.TextBox lblCommunity;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label label2;
        
    }
}