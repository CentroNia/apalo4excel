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
    partial class RBuilder
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cfcBrack = new JControls.CTarget();
            this.ceExpression = new JControls.CExpression();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.lbConsolidationPriority = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "=";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cfcBrack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ceExpression, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 95);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // cfcBrack
            // 
            this.cfcBrack.AutoCollapse = false;
            this.cfcBrack.AutoSize = true;
            this.cfcBrack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cfcBrack.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.cfcBrack.Collapsed = false;
            this.cfcBrack.CParent = null;
            this.cfcBrack.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfcBrack.HasBackColor = false;
            this.cfcBrack.Location = new System.Drawing.Point(3, 3);
            this.cfcBrack.Name = "cfcBrack";
            this.cfcBrack.Size = new System.Drawing.Size(321, 89);
            this.cfcBrack.TabIndex = 11;
            // 
            // ceExpression
            // 
            this.ceExpression.AutoCollapse = false;
            this.ceExpression.AutoSize = true;
            this.ceExpression.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ceExpression.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ceExpression.Collapsed = false;
            this.ceExpression.CParent = null;
            this.ceExpression.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceExpression.HasBackColor = false;
            this.ceExpression.Location = new System.Drawing.Point(350, 3);
            this.ceExpression.Name = "ceExpression";
            this.ceExpression.Size = new System.Drawing.Size(195, 58);
            this.ceExpression.TabIndex = 12;
            // 
            // cbPriority
            // 
            this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Location = new System.Drawing.Point(112, 3);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(160, 21);
            this.cbPriority.TabIndex = 1;
            this.cbPriority.SelectedIndexChanged += new System.EventHandler(this.cbPriority_SelectedIndexChanged);
            // 
            // lbConsolidationPriority
            // 
            this.lbConsolidationPriority.AutoSize = true;
            this.lbConsolidationPriority.Location = new System.Drawing.Point(3, 6);
            this.lbConsolidationPriority.Name = "lbConsolidationPriority";
            this.lbConsolidationPriority.Size = new System.Drawing.Size(103, 13);
            this.lbConsolidationPriority.TabIndex = 0;
            this.lbConsolidationPriority.Text = "Consolidation priority";
            // 
            // RBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.lbConsolidationPriority);
            this.Controls.Add(this.cbPriority);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RBuilder";
            this.Size = new System.Drawing.Size(551, 129);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CExpression ceExpression;
        private System.Windows.Forms.ComboBox cbPriority;
        public System.Windows.Forms.Label lbConsolidationPriority;
        private CTarget cfcBrack;
    }
}
