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
    partial class RuleEditorAdvanced
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleEditorAdvanced));
            this.tbRule = new System.Windows.Forms.TextBox();
            this.lbRuleTitle = new System.Windows.Forms.Label();
            this.btParse = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btExpandAll = new System.Windows.Forms.Button();
            this.btCollapseAll = new System.Windows.Forms.Button();
            this.btShowComment = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lbComment = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbRule = new JControls.RBuilder();
            this.btRefreshList = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRule
            // 
            this.tbRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRule.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRule.Location = new System.Drawing.Point(0, 0);
            this.tbRule.Margin = new System.Windows.Forms.Padding(0);
            this.tbRule.Multiline = true;
            this.tbRule.Name = "tbRule";
            this.tbRule.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRule.Size = new System.Drawing.Size(560, 44);
            this.tbRule.TabIndex = 11;
            this.tbRule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRule_KeyDown);
            // 
            // lbRuleTitle
            // 
            this.lbRuleTitle.AutoSize = true;
            this.lbRuleTitle.Location = new System.Drawing.Point(11, 12);
            this.lbRuleTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lbRuleTitle.Name = "lbRuleTitle";
            this.lbRuleTitle.Size = new System.Drawing.Size(29, 13);
            this.lbRuleTitle.TabIndex = 0;
            this.lbRuleTitle.Text = "Rule";
            // 
            // btParse
            // 
            this.btParse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btParse.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btParse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btParse.Location = new System.Drawing.Point(578, 25);
            this.btParse.Name = "btParse";
            this.btParse.Size = new System.Drawing.Size(99, 23);
            this.btParse.TabIndex = 100;
            this.btParse.Text = "Parse";
            this.btParse.UseVisualStyleBackColor = true;
            this.btParse.Click += new System.EventHandler(this.btParse_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Location = new System.Drawing.Point(578, 54);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(99, 23);
            this.btOk.TabIndex = 101;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Location = new System.Drawing.Point(578, 83);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(99, 23);
            this.btCancel.TabIndex = 102;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btExpandAll
            // 
            this.btExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExpandAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExpandAll.Location = new System.Drawing.Point(578, 145);
            this.btExpandAll.Name = "btExpandAll";
            this.btExpandAll.Size = new System.Drawing.Size(99, 23);
            this.btExpandAll.TabIndex = 104;
            this.btExpandAll.Text = "Expand All";
            this.btExpandAll.UseVisualStyleBackColor = true;
            this.btExpandAll.Click += new System.EventHandler(this.btExpandAll_Click);
            // 
            // btCollapseAll
            // 
            this.btCollapseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCollapseAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCollapseAll.Location = new System.Drawing.Point(578, 174);
            this.btCollapseAll.Name = "btCollapseAll";
            this.btCollapseAll.Size = new System.Drawing.Size(99, 23);
            this.btCollapseAll.TabIndex = 105;
            this.btCollapseAll.Text = "Collapse All";
            this.btCollapseAll.UseVisualStyleBackColor = true;
            this.btCollapseAll.Click += new System.EventHandler(this.btCollapseAll_Click);
            // 
            // btShowComment
            // 
            this.btShowComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btShowComment.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btShowComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShowComment.Location = new System.Drawing.Point(578, 116);
            this.btShowComment.Name = "btShowComment";
            this.btShowComment.Size = new System.Drawing.Size(99, 23);
            this.btShowComment.TabIndex = 103;
            this.btShowComment.Text = "Hide Comment";
            this.btShowComment.UseVisualStyleBackColor = true;
            this.btShowComment.Click += new System.EventHandler(this.btMaximize_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbRule, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbComment, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbComment, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 91);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tbComment
            // 
            this.tbComment.BackColor = System.Drawing.SystemColors.Window;
            this.tbComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbComment.Location = new System.Drawing.Point(0, 57);
            this.tbComment.Margin = new System.Windows.Forms.Padding(0);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComment.Size = new System.Drawing.Size(560, 34);
            this.tbComment.TabIndex = 12;
            // 
            // lbComment
            // 
            this.lbComment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbComment.AutoSize = true;
            this.lbComment.Location = new System.Drawing.Point(0, 44);
            this.lbComment.Margin = new System.Windows.Forms.Padding(0);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(54, 13);
            this.lbComment.TabIndex = 0;
            this.lbComment.Text = "Comment:";
            // 
            // statusBar
            // 
            this.statusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 349);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(689, 22);
            this.statusBar.TabIndex = 200;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbRule);
            this.panel1.Location = new System.Drawing.Point(12, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 222);
            this.panel1.TabIndex = 20;
            // 
            // rbRule
            // 
            this.rbRule.AutoScroll = true;
            this.rbRule.AutoSize = true;
            this.rbRule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rbRule.CParent = null;
            this.rbRule.CPriority = JControls.CPriority.None;
            this.rbRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbRule.ExprValue = "[] =  ";
            this.rbRule.FQEN = false;
            this.rbRule.Location = new System.Drawing.Point(0, 0);
            this.rbRule.Name = "rbRule";
            this.rbRule.Size = new System.Drawing.Size(558, 220);
            this.rbRule.TabIndex = 21;
            this.rbRule.ExpressionUpdate += new JControls.EUEventHandler(this.tbUpdate);
            // 
            // btRefreshList
            // 
            this.btRefreshList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefreshList.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRefreshList.Location = new System.Drawing.Point(578, 203);
            this.btRefreshList.Name = "btRefreshList";
            this.btRefreshList.Size = new System.Drawing.Size(99, 23);
            this.btRefreshList.TabIndex = 201;
            this.btRefreshList.Text = "Refresh List";
            this.btRefreshList.UseVisualStyleBackColor = true;
            this.btRefreshList.Click +=new System.EventHandler(btRefreshList_Click);
            // 
            // RuleEditorAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(689, 371);
            this.Controls.Add(this.btRefreshList);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btShowComment);
            this.Controls.Add(this.btExpandAll);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btCollapseAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.lbRuleTitle);
            this.Controls.Add(this.btParse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RuleEditorAdvanced";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rule Builder (Advanced)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RuleEditorAdvanced_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRule;

        public string TbRule
        {
            get { return tbRule.Text; }
            set { tbRule.Text = value; }
        }
        private System.Windows.Forms.Label lbRuleTitle;
        private System.Windows.Forms.Button btParse;
        private System.Windows.Forms.Panel panel1;
        private JControls.RBuilder rbRule;
        private System.Windows.Forms.Button btExpandAll;
        private System.Windows.Forms.Button btCollapseAll;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btShowComment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lbComment;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btRefreshList;
    }
}