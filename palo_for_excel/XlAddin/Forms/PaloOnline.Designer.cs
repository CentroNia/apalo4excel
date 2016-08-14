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
using Apalo.XlAddin.Utils;

 namespace Apalo.XlAddin.Forms
{
    partial class PaloOnline
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
            // write form's size and position on close
            Apalo.XlAddin.Utils.RegUtils.SetFormProperties(PALOONLINE, new int[4] { this.Left, this.Top, this.Width, this.Height });

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaloOnline));
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblWhyRegister = new System.Windows.Forms.Label();
            this.txtWhyRegister = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.inpPassword = new System.Windows.Forms.TextBox();
            this.inpUsername = new System.Windows.Forms.TextBox();
            this.keepLoginData = new System.Windows.Forms.CheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lnkPaloOnline = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.ErrorImage")));
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.InitialImage")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(286, -11);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(153, 81);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblWhyRegister
            // 
            this.lblWhyRegister.AutoSize = true;
            this.lblWhyRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhyRegister.Location = new System.Drawing.Point(12, 142);
            this.lblWhyRegister.Name = "lblWhyRegister";
            this.lblWhyRegister.Size = new System.Drawing.Size(190, 13);
            this.lblWhyRegister.TabIndex = 0;
            this.lblWhyRegister.Text = "Why registering for Palo Online?";
            // 
            // txtWhyRegister
            // 
            this.txtWhyRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWhyRegister.Location = new System.Drawing.Point(15, 160);
            this.txtWhyRegister.Multiline = true;
            this.txtWhyRegister.Name = "txtWhyRegister";
            this.txtWhyRegister.Size = new System.Drawing.Size(454, 120);
            this.txtWhyRegister.TabIndex = 0;
            this.txtWhyRegister.TabStop = false;
            this.txtWhyRegister.Text = "Because";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(157, 75);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(53, 75);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // inpPassword
            // 
            this.inpPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inpPassword.ForeColor = System.Drawing.SystemColors.InfoText;
            this.inpPassword.Location = new System.Drawing.Point(112, 42);
            this.inpPassword.Name = "inpPassword";
            this.inpPassword.PasswordChar = '*';
            this.inpPassword.Size = new System.Drawing.Size(149, 22);
            this.inpPassword.TabIndex = 2;
            // 
            // inpUsername
            // 
            this.inpUsername.AcceptsReturn = true;
            this.inpUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inpUsername.ForeColor = System.Drawing.SystemColors.InfoText;
            this.inpUsername.Location = new System.Drawing.Point(112, 10);
            this.inpUsername.Name = "inpUsername";
            this.inpUsername.Size = new System.Drawing.Size(149, 22);
            this.inpUsername.TabIndex = 1;
            // 
            // keepLoginData
            // 
            this.keepLoginData.BackColor = System.Drawing.Color.Transparent;
            this.keepLoginData.Checked = true;
            this.keepLoginData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keepLoginData.ForeColor = System.Drawing.SystemColors.InfoText;
            this.keepLoginData.Location = new System.Drawing.Point(53, 66);
            this.keepLoginData.Name = "keepLoginData";
            this.keepLoginData.Size = new System.Drawing.Size(208, 24);
            this.keepLoginData.TabIndex = 3;
            this.keepLoginData.Text = "stay logged in";
            this.keepLoginData.UseVisualStyleBackColor = false;
            this.keepLoginData.Visible = false;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(12, 41);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(94, 23);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(12, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(94, 23);
            this.lblUsername.TabIndex = 17;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkPaloOnline
            // 
            this.lnkPaloOnline.AutoSize = true;
            this.lnkPaloOnline.Location = new System.Drawing.Point(12, 111);
            this.lnkPaloOnline.Name = "lnkPaloOnline";
            this.lnkPaloOnline.Size = new System.Drawing.Size(175, 13);
            this.lnkPaloOnline.TabIndex = 6;
            this.lnkPaloOnline.TabStop = true;
            this.lnkPaloOnline.Text = "Click here to register for Palo Online";
            this.lnkPaloOnline.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPaloOnline_LinkClicked);
            // 
            // PaloOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 287);
            this.Controls.Add(this.lnkPaloOnline);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.inpPassword);
            this.Controls.Add(this.inpUsername);
            this.Controls.Add(this.keepLoginData);
            this.Controls.Add(this.lblWhyRegister);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.txtWhyRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaloOnline";
            this.Text = "PaloOnline";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblWhyRegister;
        private System.Windows.Forms.TextBox txtWhyRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox inpPassword;
        private System.Windows.Forms.TextBox inpUsername;
        private System.Windows.Forms.CheckBox keepLoginData;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.LinkLabel lnkPaloOnline;
    }
}