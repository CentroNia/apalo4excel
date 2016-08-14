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

using Apalo.XlAddin.Forms.Controls;

namespace Apalo.XlAddin.Forms
{
    partial class FrmPasteView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPasteView));
            this.lbChooseServer = new System.Windows.Forms.Label();
            this.lbChooseCube = new System.Windows.Forms.Label();
            this.cbCubes = new Apalo.XlAddin.Forms.Controls.CubeComboBox();
            this.btData = new System.Windows.Forms.Button();
            this.btAttr = new System.Windows.Forms.Button();
            this.btUser = new System.Windows.Forms.Button();
            this.gbPageSelect = new System.Windows.Forms.GroupBox();
            this.tcPageSelector = new JControls.JTreeView();
            this.gbRowSelect = new System.Windows.Forms.GroupBox();
            this.tcRows = new JControls.JTreeView();
            this.cbIndent = new System.Windows.Forms.CheckBox();
            this.gbColSelect = new System.Windows.Forms.GroupBox();
            this.tcColumns = new JControls.JTreeView();
            this.tbColWidth = new System.Windows.Forms.TextBox();
            this.cbFixedWidth = new System.Windows.Forms.CheckBox();
            this.cbWrap = new System.Windows.Forms.CheckBox();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.btDefault = new System.Windows.Forms.Button();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.lbChooseStyle = new System.Windows.Forms.Label();
            this.cbZeroSuppressionAlsoCalculatedNull = new System.Windows.Forms.CheckBox();
            this.cbZeroSuppression = new System.Windows.Forms.CheckBox();
            this.cbShowSelector = new System.Windows.Forms.CheckBox();
            this.cbDataMode = new System.Windows.Forms.ComboBox();
            this.btPaste = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.pPanel = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbPageSelect.SuspendLayout();
            this.gbRowSelect.SuspendLayout();
            this.gbColSelect.SuspendLayout();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbChooseServer
            // 
            this.lbChooseServer.AutoSize = true;
            this.lbChooseServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbChooseServer.Location = new System.Drawing.Point(12, 9);
            this.lbChooseServer.Name = "lbChooseServer";
            this.lbChooseServer.Size = new System.Drawing.Size(131, 13);
            this.lbChooseServer.TabIndex = 0;
            this.lbChooseServer.Text = "Choose Server/Database:";
            // 
            // lbChooseCube
            // 
            this.lbChooseCube.AutoSize = true;
            this.lbChooseCube.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbChooseCube.Location = new System.Drawing.Point(325, 9);
            this.lbChooseCube.Name = "lbChooseCube";
            this.lbChooseCube.Size = new System.Drawing.Size(74, 13);
            this.lbChooseCube.TabIndex = 0;
            this.lbChooseCube.Text = "Choose Cube:";
            // 
            // cbCubes
            // 
            this.cbCubes.DisplayMember = "Text";
            this.cbCubes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCubes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCubes.Enabled = false;
            this.cbCubes.FormattingEnabled = true;
            this.cbCubes.Location = new System.Drawing.Point(327, 25);
            this.cbCubes.MaxLength = 0;
            this.cbCubes.Name = "cbCubes";
            this.cbCubes.SelectedIndex = -1;
            this.cbCubes.Size = new System.Drawing.Size(219, 21);
            this.cbCubes.TabIndex = 3;
            this.cbCubes.SelectedIndexChanged += new System.EventHandler(this.cbCubes_SelectedIndexChanged);
            this.cbCubes.EnabledChanged += new System.EventHandler(this.cbCubes_EnabledChanged);
            // 
            // btData
            // 
            this.btData.Enabled = false;
            this.btData.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btData.Location = new System.Drawing.Point(552, 25);
            this.btData.Name = "btData";
            this.btData.Size = new System.Drawing.Size(21, 21);
            this.btData.TabIndex = 4;
            this.btData.UseVisualStyleBackColor = true;
            this.btData.Click += new System.EventHandler(this.btData_Click);
            // 
            // btAttr
            // 
            this.btAttr.Enabled = false;
            this.btAttr.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btAttr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAttr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btAttr.Location = new System.Drawing.Point(579, 25);
            this.btAttr.Name = "btAttr";
            this.btAttr.Size = new System.Drawing.Size(21, 21);
            this.btAttr.TabIndex = 5;
            this.btAttr.UseVisualStyleBackColor = false;
            this.btAttr.Click += new System.EventHandler(this.btAttr_Click);
            // 
            // btUser
            // 
            this.btUser.Enabled = false;
            this.btUser.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btUser.Location = new System.Drawing.Point(606, 25);
            this.btUser.Name = "btUser";
            this.btUser.Size = new System.Drawing.Size(21, 21);
            this.btUser.TabIndex = 6;
            this.btUser.UseVisualStyleBackColor = false;
            this.btUser.Click += new System.EventHandler(this.btUser_Click);
            // 
            // gbPageSelect
            // 
            this.gbPageSelect.Controls.Add(this.tcPageSelector);
            this.gbPageSelect.Location = new System.Drawing.Point(15, 52);
            this.gbPageSelect.Name = "gbPageSelect";
            this.gbPageSelect.Size = new System.Drawing.Size(300, 212);
            this.gbPageSelect.TabIndex = 10;
            this.gbPageSelect.TabStop = false;
            this.gbPageSelect.Text = "Page selector";
            // 
            // tcPageSelector
            // 
            this.tcPageSelector.AllowSingleSelectedNode = false;
            this.tcPageSelector.GroupAutoCollapse = false;
            this.tcPageSelector.GroupBackColor = System.Drawing.Color.Empty;
            this.tcPageSelector.GroupByRootNodes = false;
            this.tcPageSelector.GroupFont = null;
            this.tcPageSelector.GroupForeColor = System.Drawing.Color.Empty;
            this.tcPageSelector.GroupSelectedBackColor = System.Drawing.Color.Empty;
            this.tcPageSelector.GroupSelectedFont = null;
            this.tcPageSelector.GroupSelectedForeColor = System.Drawing.Color.Empty;
            this.tcPageSelector.Location = new System.Drawing.Point(12, 19);
            this.tcPageSelector.Name = "tcPageSelector";
            this.tcPageSelector.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.tcPageSelector.SelectionMode = JControls.TreeViewSelectionMode.SingleSelect;
            this.tcPageSelector.Size = new System.Drawing.Size(260, 160);
            this.tcPageSelector.TabIndex = 11;
            this.tcPageSelector.Text = "treeControl1";
            this.tcPageSelector.DoubleClick += new System.EventHandler(this.treeControl_DoubleClick);
            // 
            // gbRowSelect
            // 
            this.gbRowSelect.Controls.Add(this.tcRows);
            this.gbRowSelect.Controls.Add(this.cbIndent);
            this.gbRowSelect.Location = new System.Drawing.Point(15, 270);
            this.gbRowSelect.Name = "gbRowSelect";
            this.gbRowSelect.Size = new System.Drawing.Size(300, 212);
            this.gbRowSelect.TabIndex = 20;
            this.gbRowSelect.TabStop = false;
            this.gbRowSelect.Text = "Row Labels";
            // 
            // tcRows
            // 
            this.tcRows.AllowSingleSelectedNode = false;
            this.tcRows.GroupAutoCollapse = false;
            this.tcRows.GroupBackColor = System.Drawing.Color.Empty;
            this.tcRows.GroupByRootNodes = false;
            this.tcRows.GroupFont = null;
            this.tcRows.GroupForeColor = System.Drawing.Color.Empty;
            this.tcRows.GroupSelectedBackColor = System.Drawing.Color.Empty;
            this.tcRows.GroupSelectedFont = null;
            this.tcRows.GroupSelectedForeColor = System.Drawing.Color.Empty;
            this.tcRows.Location = new System.Drawing.Point(12, 19);
            this.tcRows.Name = "tcRows";
            this.tcRows.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.tcRows.SelectionMode = JControls.TreeViewSelectionMode.SingleSelect;
            this.tcRows.Size = new System.Drawing.Size(260, 164);
            this.tcRows.TabIndex = 21;
            this.tcRows.Text = "treeControl3";
            this.tcRows.DoubleClick += new System.EventHandler(this.treeControl_DoubleClick);
            // 
            // cbIndent
            // 
            this.cbIndent.AutoSize = true;
            this.cbIndent.Checked = true;
            this.cbIndent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIndent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbIndent.Location = new System.Drawing.Point(12, 189);
            this.cbIndent.Name = "cbIndent";
            this.cbIndent.Size = new System.Drawing.Size(56, 17);
            this.cbIndent.TabIndex = 22;
            this.cbIndent.Text = "Indent";
            this.cbIndent.UseVisualStyleBackColor = true;
            // 
            // gbColSelect
            // 
            this.gbColSelect.Controls.Add(this.tcColumns);
            this.gbColSelect.Controls.Add(this.tbColWidth);
            this.gbColSelect.Controls.Add(this.cbFixedWidth);
            this.gbColSelect.Controls.Add(this.cbWrap);
            this.gbColSelect.Location = new System.Drawing.Point(328, 52);
            this.gbColSelect.Name = "gbColSelect";
            this.gbColSelect.Size = new System.Drawing.Size(300, 212);
            this.gbColSelect.TabIndex = 30;
            this.gbColSelect.TabStop = false;
            this.gbColSelect.Text = "Column Labels";
            // 
            // tcColumns
            // 
            this.tcColumns.AllowSingleSelectedNode = false;
            this.tcColumns.GroupAutoCollapse = false;
            this.tcColumns.GroupBackColor = System.Drawing.Color.Empty;
            this.tcColumns.GroupByRootNodes = false;
            this.tcColumns.GroupFont = null;
            this.tcColumns.GroupForeColor = System.Drawing.Color.Empty;
            this.tcColumns.GroupSelectedBackColor = System.Drawing.Color.Empty;
            this.tcColumns.GroupSelectedFont = null;
            this.tcColumns.GroupSelectedForeColor = System.Drawing.Color.Empty;
            this.tcColumns.Location = new System.Drawing.Point(10, 19);
            this.tcColumns.Name = "tcColumns";
            this.tcColumns.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.tcColumns.SelectionMode = JControls.TreeViewSelectionMode.SingleSelect;
            this.tcColumns.Size = new System.Drawing.Size(260, 160);
            this.tcColumns.TabIndex = 31;
            this.tcColumns.Text = "treeControl2";
            this.tcColumns.DoubleClick += new System.EventHandler(this.treeControl_DoubleClick);
            // 
            // tbColWidth
            // 
            this.tbColWidth.Location = new System.Drawing.Point(236, 183);
            this.tbColWidth.MaxLength = 6;
            this.tbColWidth.Name = "tbColWidth";
            this.tbColWidth.Size = new System.Drawing.Size(34, 20);
            this.tbColWidth.TabIndex = 34;
            this.tbColWidth.Text = "14.00";
            this.tbColWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbColWidth.Leave += new System.EventHandler(this.tbColWidth_Leave);
            // 
            // cbFixedWidth
            // 
            this.cbFixedWidth.AutoSize = true;
            this.cbFixedWidth.Checked = true;
            this.cbFixedWidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFixedWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbFixedWidth.Location = new System.Drawing.Point(109, 185);
            this.cbFixedWidth.Name = "cbFixedWidth";
            this.cbFixedWidth.Size = new System.Drawing.Size(82, 17);
            this.cbFixedWidth.TabIndex = 33;
            this.cbFixedWidth.Text = "Fixed width:";
            this.cbFixedWidth.UseVisualStyleBackColor = true;
            this.cbFixedWidth.CheckedChanged += new System.EventHandler(this.cbFixedWidth_CheckedChanged);
            // 
            // cbWrap
            // 
            this.cbWrap.AutoSize = true;
            this.cbWrap.Checked = true;
            this.cbWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWrap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbWrap.Location = new System.Drawing.Point(10, 185);
            this.cbWrap.Name = "cbWrap";
            this.cbWrap.Size = new System.Drawing.Size(82, 17);
            this.cbWrap.TabIndex = 32;
            this.cbWrap.Text = "Wrap labels";
            this.cbWrap.UseVisualStyleBackColor = true;
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.btDefault);
            this.gbData.Controls.Add(this.cbStyle);
            this.gbData.Controls.Add(this.lbChooseStyle);
            this.gbData.Controls.Add(this.cbZeroSuppressionAlsoCalculatedNull);
            this.gbData.Controls.Add(this.cbZeroSuppression);
            this.gbData.Controls.Add(this.cbShowSelector);
            this.gbData.Controls.Add(this.cbDataMode);
            this.gbData.Location = new System.Drawing.Point(328, 270);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(300, 212);
            this.gbData.TabIndex = 40;
            this.gbData.TabStop = false;
            this.gbData.Text = "Data";
            // 
            // btDefault
            // 
            this.btDefault.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDefault.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btDefault.Location = new System.Drawing.Point(136, 61);
            this.btDefault.Name = "btDefault";
            this.btDefault.Size = new System.Drawing.Size(75, 21);
            this.btDefault.TabIndex = 101;
            this.btDefault.Text = "Default";
            this.btDefault.UseVisualStyleBackColor = true;
            // 
            // cbStyle
            // 
            this.cbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStyle.FormattingEnabled = true;
            this.cbStyle.Location = new System.Drawing.Point(10, 61);
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Size = new System.Drawing.Size(120, 21);
            this.cbStyle.TabIndex = 46;
            // 
            // lbChooseStyle
            // 
            this.lbChooseStyle.AutoSize = true;
            this.lbChooseStyle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbChooseStyle.Location = new System.Drawing.Point(7, 45);
            this.lbChooseStyle.Name = "lbChooseStyle";
            this.lbChooseStyle.Size = new System.Drawing.Size(72, 13);
            this.lbChooseStyle.TabIndex = 45;
            this.lbChooseStyle.Text = "Choose Style:";
            // 
            // cbZeroSuppressionAlsoCalculatedNull
            // 
            this.cbZeroSuppressionAlsoCalculatedNull.AutoSize = true;
            this.cbZeroSuppressionAlsoCalculatedNull.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbZeroSuppressionAlsoCalculatedNull.Location = new System.Drawing.Point(27, 167);
            this.cbZeroSuppressionAlsoCalculatedNull.Name = "cbZeroSuppressionAlsoCalculatedNull";
            this.cbZeroSuppressionAlsoCalculatedNull.Size = new System.Drawing.Size(142, 17);
            this.cbZeroSuppressionAlsoCalculatedNull.TabIndex = 44;
            this.cbZeroSuppressionAlsoCalculatedNull.Text = " suppress calculated null";
            this.cbZeroSuppressionAlsoCalculatedNull.UseVisualStyleBackColor = true;
            // 
            // cbZeroSuppression
            // 
            this.cbZeroSuppression.AutoSize = true;
            this.cbZeroSuppression.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbZeroSuppression.Location = new System.Drawing.Point(10, 145);
            this.cbZeroSuppression.Name = "cbZeroSuppression";
            this.cbZeroSuppression.Size = new System.Drawing.Size(102, 17);
            this.cbZeroSuppression.TabIndex = 42;
            this.cbZeroSuppression.Text = "Zero suppresion";
            this.cbZeroSuppression.UseVisualStyleBackColor = true;
            // 
            // cbShowSelector
            // 
            this.cbShowSelector.AutoSize = true;
            this.cbShowSelector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbShowSelector.Location = new System.Drawing.Point(10, 189);
            this.cbShowSelector.Name = "cbShowSelector";
            this.cbShowSelector.Size = new System.Drawing.Size(205, 17);
            this.cbShowSelector.TabIndex = 43;
            this.cbShowSelector.Text = "Show element selector on doubleclick";
            this.cbShowSelector.UseVisualStyleBackColor = true;
            // 
            // cbDataMode
            // 
            this.cbDataMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataMode.FormattingEnabled = true;
            this.cbDataMode.Items.AddRange(new object[] {
            "PALO.DATA",
            "PALO.DATAC",
            "PALO.DATAX",
            "PALO.DATAV"});
            this.cbDataMode.Location = new System.Drawing.Point(10, 19);
            this.cbDataMode.Name = "cbDataMode";
            this.cbDataMode.Size = new System.Drawing.Size(120, 21);
            this.cbDataMode.TabIndex = 41;
            // 
            // btPaste
            // 
            this.btPaste.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btPaste.Enabled = false;
            this.btPaste.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPaste.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btPaste.Location = new System.Drawing.Point(647, 25);
            this.btPaste.Name = "btPaste";
            this.btPaste.Size = new System.Drawing.Size(75, 23);
            this.btPaste.TabIndex = 100;
            this.btPaste.Text = "&Paste";
            this.btPaste.UseVisualStyleBackColor = true;
            this.btPaste.Click += new System.EventHandler(this.btPaste_Click);
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btClose.Location = new System.Drawing.Point(647, 54);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 101;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // pPanel
            // 
            this.pPanel.Location = new System.Drawing.Point(15, 25);
            this.pPanel.Name = "pPanel";
            this.pPanel.Size = new System.Drawing.Size(300, 21);
            this.pPanel.TabIndex = 1;
            // 
            // FrmPasteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(730, 524);
            this.ControlBox = false;
            this.Controls.Add(this.pPanel);
            this.Controls.Add(this.gbRowSelect);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btPaste);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.gbColSelect);
            this.Controls.Add(this.gbPageSelect);
            this.Controls.Add(this.btUser);
            this.Controls.Add(this.btAttr);
            this.Controls.Add(this.btData);
            this.Controls.Add(this.cbCubes);
            this.Controls.Add(this.lbChooseCube);
            this.Controls.Add(this.lbChooseServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(736, 546);
            this.Name = "FrmPasteView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Paste view";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPasteView_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FrmPasteView_VisibleChanged);
            this.gbPageSelect.ResumeLayout(false);
            this.gbRowSelect.ResumeLayout(false);
            this.gbRowSelect.PerformLayout();
            this.gbColSelect.ResumeLayout(false);
            this.gbColSelect.PerformLayout();
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbChooseServer;
        private System.Windows.Forms.Label lbChooseCube;
        private CubeComboBox  cbCubes;
        private System.Windows.Forms.Button btData;
        private System.Windows.Forms.Button btAttr;
        private System.Windows.Forms.Button btUser;
        private System.Windows.Forms.GroupBox gbPageSelect;
        private System.Windows.Forms.GroupBox gbRowSelect;
        private System.Windows.Forms.GroupBox gbColSelect;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.Button btPaste;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.CheckBox cbIndent;
        private System.Windows.Forms.TextBox tbColWidth;
        private System.Windows.Forms.CheckBox cbFixedWidth;
        private System.Windows.Forms.CheckBox cbWrap;
        private System.Windows.Forms.CheckBox cbShowSelector;
        private System.Windows.Forms.ComboBox cbDataMode;
        private JControls.JTreeView tcPageSelector;
        private JControls.JTreeView tcRows;
        private JControls.JTreeView tcColumns;
        private System.Windows.Forms.Panel pPanel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox cbZeroSuppression;
        private System.Windows.Forms.CheckBox cbZeroSuppressionAlsoCalculatedNull;
        private System.Windows.Forms.Label lbChooseStyle;
        private System.Windows.Forms.Button btDefault;
        private System.Windows.Forms.ComboBox cbStyle;

    }
}

