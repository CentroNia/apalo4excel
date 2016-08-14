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

namespace JControls
{
    partial class AnnoylessBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbDontShow = new System.Windows.Forms.CheckBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDontShow
            // 
            this.cbDontShow.AutoSize = true;
            this.cbDontShow.Location = new System.Drawing.Point(3, 51);
            this.cbDontShow.Name = "cbDontShow";
            this.cbDontShow.Size = new System.Drawing.Size(127, 17);
            this.cbDontShow.TabIndex = 2;
            this.cbDontShow.Tag = "Autorefresh Dont Show";
            this.cbDontShow.Text = "Don\'t show this again";
            this.cbDontShow.UseVisualStyleBackColor = true;
            this.cbDontShow.CheckedChanged += new System.EventHandler(this.cbDontShow_CheckedChanged);
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMessage.Location = new System.Drawing.Point(3, 0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(423, 48);
            this.lbMessage.TabIndex = 1;
            this.lbMessage.Tag = "Autorefresh Warning";
            this.lbMessage.Text = "Annoying message";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btOk
            // 
            this.btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btOk, 2);
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(177, 74);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cbDontShow, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbMessage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btOk, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 101);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // AnnoylessBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 107);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AnnoylessBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// Sets/Gets the dialog title.
        /// </summary>
        public string Title
        {
            set { this.Text = value; }
            get { return this.Text; }
        }

        private bool hide;
        /// <summary>
        /// Gets the value representing visibility.
        /// </summary>
        public bool HideDialog
        {
            get { return hide; }
        }

        private System.Windows.Forms.CheckBox cbDontShow;

        /// <summary>
        /// Sets the string value representing the text behind checkbox.
        /// </summary>
        public string LabelDontShow
        {
            set { cbDontShow.Text = value; }
            get { return cbDontShow.Text; }
        }
        private System.Windows.Forms.Label lbMessage;

        /// <summary>
        /// Sets the string value representing the text of the message box.
        /// </summary>
        public string LabelMessage
        {
            set { lbMessage.Text = value; }
            get { return lbMessage.Text; }
        }
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
