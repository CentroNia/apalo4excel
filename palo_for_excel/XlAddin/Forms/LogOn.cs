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

using System.Runtime.InteropServices;
using System.Windows.Forms;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
	/// <summary>
	/// Summary description for LogOn.
	/// </summary>
	[ComVisible(false)]
	public class LogOn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox inpUsername;
		private System.Windows.Forms.TextBox inpPassword;
		public string InputPassword
		{
			get
			{
				return this.inpPassword.Text;
			}
			set
			{
				this.inpPassword.Text = value;
			}
		}

		public string InputUserName
		{
			get
			{
				return this.inpUsername.Text;
			}
			set
			{
				this.inpUsername.Text = value;
			}
		}

		public string ConnectionName
		{
			get
			{
				return this.connName.Text;
			}
			set
			{
				this.connName.Text = value;
			}
		}

		public bool KeepLogOnData
		{
			get
			{
				return this.keepLoginData.Checked;
			}
			set
			{
				this.keepLoginData.Checked = value;
			}
		}

		private CheckBox keepLoginData;
        private System.Windows.Forms.Label connName;
        private Button xpOk;
        private Button xpCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LogOn()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.label2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.keepLoginData.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.connName.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.xpCancel.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.xpOk.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;

			this.label1.Text = ResourceInitializer.WIZARD_LABEL30;
			this.label2.Text = ResourceInitializer.WIZARD_LABEL31;
			this.keepLoginData.Text = ResourceInitializer.LABEL_LOGON_DATA;
			this.xpOk.Text = ResourceInitializer.BUTTON_OK;
			this.xpCancel.Text = ResourceInitializer.BUTTON_CANCEL;
			this.inpUsername.Focus();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogOn));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.keepLoginData = new System.Windows.Forms.CheckBox();
            this.xpOk = new System.Windows.Forms.Button();
            this.xpCancel = new System.Windows.Forms.Button();
            this.inpUsername = new System.Windows.Forms.TextBox();
            this.inpPassword = new System.Windows.Forms.TextBox();
            this.connName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 23);
            this.label2.TabIndex = 0;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // keepLoginData
            // 
            this.keepLoginData.BackColor = System.Drawing.SystemColors.Control;
            this.keepLoginData.ForeColor = System.Drawing.SystemColors.InfoText;
            this.keepLoginData.Location = new System.Drawing.Point(48, 66);
            this.keepLoginData.Name = "keepLoginData";
            this.keepLoginData.Size = new System.Drawing.Size(179, 24);
            this.keepLoginData.TabIndex = 3;
            this.keepLoginData.UseVisualStyleBackColor = false;
            // 
            // xpOk
            // 
            this.xpOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.xpOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.xpOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpOk.Location = new System.Drawing.Point(48, 89);
            this.xpOk.Name = "xpOk";
            this.xpOk.Size = new System.Drawing.Size(75, 23);
            this.xpOk.TabIndex = 10;
            // 
            // xpCancel
            // 
            this.xpCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.xpCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.xpCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpCancel.Location = new System.Drawing.Point(152, 89);
            this.xpCancel.Name = "xpCancel";
            this.xpCancel.Size = new System.Drawing.Size(75, 23);
            this.xpCancel.TabIndex = 11;
            // 
            // inpUsername
            // 
            this.inpUsername.AcceptsReturn = true;
            this.inpUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inpUsername.ForeColor = System.Drawing.SystemColors.InfoText;
            this.inpUsername.Location = new System.Drawing.Point(107, 10);
            this.inpUsername.Name = "inpUsername";
            this.inpUsername.Size = new System.Drawing.Size(149, 22);
            this.inpUsername.TabIndex = 1;
            this.inpUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inpUsername_KeyPress);
            // 
            // inpPassword
            // 
            this.inpPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inpPassword.ForeColor = System.Drawing.SystemColors.InfoText;
            this.inpPassword.Location = new System.Drawing.Point(107, 42);
            this.inpPassword.Name = "inpPassword";
            this.inpPassword.PasswordChar = '*';
            this.inpPassword.Size = new System.Drawing.Size(149, 22);
            this.inpPassword.TabIndex = 2;
            this.inpPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inpPassword_KeyPress);
            // 
            // connName
            // 
            this.connName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connName.Location = new System.Drawing.Point(12, 96);
            this.connName.Name = "connName";
            this.connName.Size = new System.Drawing.Size(176, 16);
            this.connName.TabIndex = 0;
            this.connName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connName.Visible = false;
            this.connName.TextChanged += new System.EventHandler(this.connName_TextChanged);
            // 
            // LogOn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.xpCancel;
            this.ClientSize = new System.Drawing.Size(270, 120);
            this.Controls.Add(this.connName);
            this.Controls.Add(this.xpCancel);
            this.Controls.Add(this.xpOk);
            this.Controls.Add(this.inpPassword);
            this.Controls.Add(this.inpUsername);
            this.Controls.Add(this.keepLoginData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogOn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void inpUsername_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13 && this.inpUsername.Text.Length != 0)
			{
				this.inpPassword.Focus();
			}
		}

		private void inpPassword_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13 && this.inpUsername.Text.Length != 0)
			{
				this.xpOk.PerformClick();
			}
		}

		private void connName_TextChanged(object sender, System.EventArgs e)
		{
			this.Text = this.connName.Text;
		}
	}
}
