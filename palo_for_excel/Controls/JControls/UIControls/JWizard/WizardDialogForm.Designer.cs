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
*	http://www.jedox.com/license_palo_bi_suite.txt
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

/*
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Drawing.Design;
*/
using System.ComponentModel;
using System.Windows.Forms;

namespace JControls
{

	partial class WizardDialogForm
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


		private TabPage GenerateTab(int i)
		{

			TabPage tb = new TabPage();
			tb.SuspendLayout();
			tb.BackColor = System.Drawing.Color.White;
			tb.Location = new System.Drawing.Point(4, 22);
			tb.Name = "tbStep" + i.ToString();
			tb.Padding = new System.Windows.Forms.Padding(3);
			tb.Size = new System.Drawing.Size(453, 257);
			tb.TabIndex = i-1;
			tb.Tag = i.ToString();
			tb.Text = "Step" + i.ToString();
			tb.ResumeLayout(false);
			tb.PerformLayout();

			return tb;

		}
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardDialogForm));
			this.PanelContenerTabs = new System.Windows.Forms.Panel();
			this.wizardTabControl1 = new JControls.WizardTabControl();
			this.tabPageStep1 = new JControls.TabPageStep();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.btnFinish = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this._imgPanel = new System.Windows.Forms.PictureBox();
			this.panel12 = new System.Windows.Forms.Panel();
			this.panel13 = new System.Windows.Forms.Panel();
			this.panel14 = new System.Windows.Forms.Panel();
			this.panel17 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.PanelContenerTabs.SuspendLayout();
			this.wizardTabControl1.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._imgPanel)).BeginInit();
			this.SuspendLayout();
			//
			// PanelContenerTabs
			//
			this.PanelContenerTabs.BackColor = System.Drawing.Color.White;
			this.PanelContenerTabs.Controls.Add(this.wizardTabControl1);
			this.PanelContenerTabs.Controls.Add(this.pnlBottom);
			this.PanelContenerTabs.Controls.Add(this.tableLayoutPanel1);
			this.PanelContenerTabs.Location = new System.Drawing.Point(156, 1);
			this.PanelContenerTabs.Name = "PanelContenerTabs";
			this.PanelContenerTabs.Size = new System.Drawing.Size(462, 402);
			this.PanelContenerTabs.TabIndex = 0;
			//
			// wizardTabControl1
			//
			this.wizardTabControl1.Controls.Add(this.tabPageStep1);
			this.wizardTabControl1.Location = new System.Drawing.Point(3, 50);
			this.wizardTabControl1.Name = "wizardTabControl1";
			this.wizardTabControl1.SelectedIndex = 0;
			this.wizardTabControl1.Size = new System.Drawing.Size(460, 297);
			this.wizardTabControl1.TabIndex = 16;
			this.wizardTabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.wizardTabControl1_Selected);
			//
			// tabPageStep1
			//
			this.tabPageStep1.BackColor = System.Drawing.Color.White;
			this.tabPageStep1.Location = new System.Drawing.Point(4, 22);
			this.tabPageStep1.Name = "tabPageStep1";
			this.tabPageStep1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStep1.ShowBackButton = true;
			this.tabPageStep1.ShowFinishButton = true;
			this.tabPageStep1.ShowNextButton = true;
			this.tabPageStep1.Size = new System.Drawing.Size(452, 271);
			this.tabPageStep1.TabIndex = 0;
			this.tabPageStep1.Tag = 1;
			this.tabPageStep1.Text = "Step1";
			//
			// pnlBottom
			//
			this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
			this.pnlBottom.Controls.Add(this.btnFinish);
			this.pnlBottom.Controls.Add(this.btnBack);
			this.pnlBottom.Controls.Add(this.btnNext);
			this.pnlBottom.Location = new System.Drawing.Point(3, 346);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(460, 61);
			this.pnlBottom.TabIndex = 15;
			//
			// btnFinish
			//
			this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFinish.Location = new System.Drawing.Point(348, 22);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(75, 21);
			this.btnFinish.TabIndex = 5;
			this.btnFinish.Tag = "0";
			this.btnFinish.Text = "Finish";
			this.btnFinish.UseVisualStyleBackColor = true;
			//
			// btnBack
			//
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnBack.ImageIndex = 1;
			this.btnBack.Location = new System.Drawing.Point(161, 22);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(75, 21);
			this.btnBack.TabIndex = 3;
			this.btnBack.Tag = "-1";
			this.btnBack.Text = " < Back";
			this.btnBack.UseVisualStyleBackColor = true;
			//
			// btnNext
			//
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNext.Location = new System.Drawing.Point(242, 22);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 21);
			this.btnNext.TabIndex = 4;
			this.btnNext.Tag = "1";
			this.btnNext.Text = "Next > ";
			this.btnNext.UseVisualStyleBackColor = true;
			//
			// tableLayoutPanel1
			//
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.86957F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.13043F));
			this.tableLayoutPanel1.Controls.Add(this.lbTitle, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, -2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 49);
			this.tableLayoutPanel1.TabIndex = 5;
			//
			// lbTitle
			//
			this.lbTitle.AutoSize = true;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbTitle.Location = new System.Drawing.Point(53, 1);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(404, 48);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Apalo Wizard";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// panel6
			//
			this.panel6.Location = new System.Drawing.Point(1, 233);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(450, 82);
			this.panel6.TabIndex = 0;
			//
			// panel8
			//
			this.panel8.Location = new System.Drawing.Point(1, 233);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(450, 82);
			this.panel8.TabIndex = 0;
			//
			// _imgPanel
			//
			this._imgPanel.Image = ((System.Drawing.Image)(resources.GetObject("_imgPanel.Image")));
			this._imgPanel.Location = new System.Drawing.Point(-2, -1);
			this._imgPanel.Name = "_imgPanel";
			this._imgPanel.Size = new System.Drawing.Size(160, 404);
			this._imgPanel.TabIndex = 3;
			this._imgPanel.TabStop = false;
			//
			// panel12
			//
			this.panel12.Location = new System.Drawing.Point(0, 0);
			this.panel12.Name = "panel12";
			this.panel12.Size = new System.Drawing.Size(200, 100);
			this.panel12.TabIndex = 0;
			//
			// panel13
			//
			this.panel13.Location = new System.Drawing.Point(0, 0);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(200, 100);
			this.panel13.TabIndex = 0;
			//
			// panel14
			//
			this.panel14.Location = new System.Drawing.Point(0, 0);
			this.panel14.Name = "panel14";
			this.panel14.Size = new System.Drawing.Size(200, 100);
			this.panel14.TabIndex = 0;
			//
			// panel17
			//
			this.panel17.Location = new System.Drawing.Point(0, 0);
			this.panel17.Name = "panel17";
			this.panel17.Size = new System.Drawing.Size(200, 100);
			this.panel17.TabIndex = 0;
			//
			// panel10
			//
			this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel10.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel10.Location = new System.Drawing.Point(0, 2560);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(453, 58);
			this.panel10.TabIndex = 13;
			//
			// WizardDialogForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(618, 401);
			this.Controls.Add(this._imgPanel);
			this.Controls.Add(this.PanelContenerTabs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WizardDialogForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WizardDialogForm";
			this.PanelContenerTabs.ResumeLayout(false);
			this.wizardTabControl1.ResumeLayout(false);
			this.pnlBottom.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._imgPanel)).EndInit();
			this.ResumeLayout(false);

		}



		#endregion



		private System.Windows.Forms.Panel panel6;



		private System.Windows.Forms.Panel panel8;

		private System.Windows.Forms.PictureBox _imgPanel;

		[ Category("JWizard") ,Description("The Image associated with the wizard control")]
		public System.Drawing.Image LeftPanelImage
		{
			get { return _imgPanel.Image; }
			set { _imgPanel.Image = value; }
		}

		[ Category("JWizard") ,Description("The title associated with the control")]
		public string TitleLabel
		{
			get { return lbTitle.Text; }
			set { lbTitle.Text = value; }
		}

		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Panel panel17;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel10;
		public Panel pnlBottom;
		public Button btnFinish;
		public Button btnBack;
		public Button btnNext;
		public Panel PanelContenerTabs;
		protected WizardTabControl wizardTabControl1;
		public TabPageStep tabPageStep1;
	}
}
