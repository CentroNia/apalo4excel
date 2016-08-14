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
using JControls;

namespace Apalo.XlAddin.Forms
{
    partial class RuleEditorKiss
    {
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleEditorKiss));
            this.lblRuleList = new System.Windows.Forms.Label();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.cmdDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRuleActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdNew = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdChangeStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chUpdated = new System.Windows.Forms.ColumnHeader();
            this.chRule = new System.Windows.Forms.ColumnHeader();
            this.lstRules = new System.Windows.Forms.ListView();
            this.chComment = new System.Windows.Forms.ColumnHeader();
            this.btnExport = new JControls.JButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnUp = new JControls.JButton();
            this.btnDown = new JControls.JButton();
            this.btnImport = new JControls.JButton();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblRule = new System.Windows.Forms.Label();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.chID = new System.Windows.Forms.ColumnHeader();
            this.mnuRuleActions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRuleList
            // 
            this.lblRuleList.BackColor = System.Drawing.SystemColors.Control;
            this.lblRuleList.Location = new System.Drawing.Point(9, 10);
            this.lblRuleList.Name = "lblRuleList";
            this.lblRuleList.Size = new System.Drawing.Size(563, 15);
            this.lblRuleList.TabIndex = 0;
            this.lblRuleList.Text = "List of defined rules";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtComment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtComment.BackColor = System.Drawing.SystemColors.Window;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(12, 335);
            this.txtComment.MaxLength = 65535;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(663, 45);
            this.txtComment.TabIndex = 7;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // cmdDown
            // 
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(130, 22);
            this.cmdDown.Text = "Move Down";
            // 
            // mnuRuleActions
            // 
            this.mnuRuleActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNew,
            this.cmdDelete,
            this.cmdEdit,
            this.toolStripSeparator1,
            this.cmdUp,
            this.cmdDown,
            this.toolStripSeparator2,
            this.cmdChangeStatus,
            this.toolStripSeparator3,
            this.cmdInfo});
            this.mnuRuleActions.Name = "contextMenuStrip1";
            this.mnuRuleActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuRuleActions.Size = new System.Drawing.Size(131, 176);
            this.mnuRuleActions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuRuleActions_ItemClicked);
            // 
            // cmdNew
            // 
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(130, 22);
            this.cmdNew.Text = "Add";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(130, 22);
            this.cmdDelete.Text = "Delete...";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(130, 22);
            this.cmdEdit.Text = "Edit...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // cmdUp
            // 
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(130, 22);
            this.cmdUp.Text = "Move Up";
            // 
            // cmdChangeStatus
            // 
            this.cmdChangeStatus.Name = "cmdChangeStatus";
            this.cmdChangeStatus.Size = new System.Drawing.Size(130, 22);
            this.cmdChangeStatus.Text = "Activ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(127, 6);
            // 
            // cmdInfo
            // 
            this.cmdInfo.Name = "cmdInfo";
            this.cmdInfo.Size = new System.Drawing.Size(130, 22);
            this.cmdInfo.Text = "Info";
            // 
            // chUpdated
            // 
            this.chUpdated.Text = "Updated";
            this.chUpdated.Width = 148;
            // 
            // chRule
            // 
            this.chRule.Text = "Rule";
            this.chRule.Width = 314;
            // 
            // lstRules
            // 
            this.lstRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRules.BackColor = System.Drawing.SystemColors.Window;
            this.lstRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chRule,
            this.chComment,
            this.chUpdated});
            this.lstRules.FullRowSelect = true;
            this.lstRules.GridLines = true;
            this.lstRules.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstRules.HideSelection = false;
            this.lstRules.LabelWrap = false;
            this.lstRules.Location = new System.Drawing.Point(12, 26);
            this.lstRules.Name = "lstRules";
            this.lstRules.ShowGroups = false;
            this.lstRules.ShowItemToolTips = true;
            this.lstRules.Size = new System.Drawing.Size(625, 230);
            this.lstRules.TabIndex = 1;
            this.lstRules.TabStop = false;
            this.lstRules.UseCompatibleStateImageBehavior = false;
            this.lstRules.View = System.Windows.Forms.View.Details;
            this.lstRules.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lstRules_ColumnWidthChanged);
            this.lstRules.SizeChanged += new System.EventHandler(this.lstRules_SizeChanged);
            this.lstRules.DoubleClick += new System.EventHandler(this.lstRules_DoubleClick);
            this.lstRules.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstRules_MouseUp);
            // 
            // chComment
            // 
            this.chComment.Text = "Comment";
            this.chComment.Width = 140;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExport.ButtonImage = null;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(643, 116);
            this.btnExport.Name = "btnExport";
            this.btnExport.RolloverImage = null;
            this.btnExport.Size = new System.Drawing.Size(23, 26);
            this.btnExport.TabIndex = 4;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(585, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 24);
            this.btnClose.TabIndex = 100;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(106, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 24);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete...";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(200, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 24);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(12, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(88, 24);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "New...";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnNew);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.statusBar);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 383);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(687, 60);
            this.pnlButtons.TabIndex = 10;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(306, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 24);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // statusBar
            // 
            this.statusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 38);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(687, 22);
            this.statusBar.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnUp.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnUp.ButtonImage = null;
            this.btnUp.Enabled = false;
            this.btnUp.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnUp.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(643, 26);
            this.btnUp.Name = "btnUp";
            this.btnUp.RolloverImage = null;
            this.btnUp.Size = new System.Drawing.Size(32, 32);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnDown.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnDown.ButtonImage = null;
            this.btnDown.Enabled = false;
            this.btnDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnDown.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(643, 64);
            this.btnDown.Name = "btnDown";
            this.btnDown.RolloverImage = null;
            this.btnDown.Size = new System.Drawing.Size(32, 32);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnImport.ButtonImage = null;
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(643, 154);
            this.btnImport.Name = "btnImport";
            this.btnImport.RolloverImage = null;
            this.btnImport.Size = new System.Drawing.Size(23, 26);
            this.btnImport.TabIndex = 5;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblComment
            // 
            this.lblComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(9, 321);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            // 
            // lblRule
            // 
            this.lblRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRule.AutoSize = true;
            this.lblRule.Location = new System.Drawing.Point(9, 262);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new System.Drawing.Size(29, 13);
            this.lblRule.TabIndex = 0;
            this.lblRule.Text = "Rule";
            // 
            // txtRule
            // 
            this.txtRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRule.Location = new System.Drawing.Point(12, 275);
            this.txtRule.Multiline = true;
            this.txtRule.Name = "txtRule";
            this.txtRule.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRule.Size = new System.Drawing.Size(663, 45);
            this.txtRule.TabIndex = 6;
            this.txtRule.TextChanged += new System.EventHandler(this.txtRule_TextChanged);
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 25;
            // 
            // RuleEditorKiss
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(687, 443);
            this.Controls.Add(this.txtRule);
            this.Controls.Add(this.lblRule);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblRuleList);
            this.Controls.Add(this.lstRules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(695, 467);
            this.Name = "RuleEditorKiss";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rule Editor";
            this.VisibleChanged += new System.EventHandler(this.RuleEditorKiss_VisibleChanged);
            this.mnuRuleActions.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRuleList;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ColumnHeader chRule;
        private System.Windows.Forms.ColumnHeader chComment;
        private System.Windows.Forms.ColumnHeader chUpdated;
        private System.Windows.Forms.ListView lstRules;
        private JButton btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        private JButton btnUp;
        private JButton btnDown;

        private JButton btnImport;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblRule;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.ContextMenuStrip mnuRuleActions;

        private System.Windows.Forms.ToolStripMenuItem cmdNew;
        private System.Windows.Forms.ToolStripMenuItem cmdDelete;
        private System.Windows.Forms.ToolStripMenuItem cmdEdit;
        private System.Windows.Forms.ToolStripMenuItem cmdUp;
        private System.Windows.Forms.ToolStripMenuItem cmdDown;
        private System.Windows.Forms.ToolStripMenuItem cmdInfo;
        private System.Windows.Forms.ToolStripMenuItem cmdChangeStatus;
        
        
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ColumnHeader chID;
        
        
    }
}
