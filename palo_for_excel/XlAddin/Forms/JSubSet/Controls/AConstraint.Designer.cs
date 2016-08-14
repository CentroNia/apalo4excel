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
namespace Apalo.XlAddin.JSubSet.Controls
{
    partial class AConstraint
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbAttribute = new System.Windows.Forms.Label();
            this.lbConstraint = new System.Windows.Forms.Label();
            this.lbAName = new System.Windows.Forms.Label();
            this.cbConstraint = new System.Windows.Forms.ComboBox();
            this.tbConstraint = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpList
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbAttribute, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbConstraint, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbAName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbConstraint, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbConstraint, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tlpList";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(315, 46);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbAttribute
            // 
            this.lbAttribute.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAttribute.AutoSize = true;
            this.lbAttribute.Location = new System.Drawing.Point(3, 3);
            this.lbAttribute.Margin = new System.Windows.Forms.Padding(3);
            this.lbAttribute.Name = "lbAttribute";
            this.lbAttribute.Size = new System.Drawing.Size(50, 13);
            this.lbAttribute.TabIndex = 0;
            this.lbAttribute.Text = "Attribute";
            // 
            // lbConstraint
            // 
            this.lbConstraint.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbConstraint.AutoSize = true;
            this.lbConstraint.Location = new System.Drawing.Point(3, 26);
            this.lbConstraint.Name = "lbConstraint";
            this.lbConstraint.Size = new System.Drawing.Size(57, 13);
            this.lbConstraint.TabIndex = 1;
            this.lbConstraint.Text = "Constraint";
            // 
            // lbAName
            // 
            this.lbAName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAName.AutoSize = true;
            this.lbAName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAName.Location = new System.Drawing.Point(66, 3);
            this.lbAName.Name = "lbAName";
            this.lbAName.Size = new System.Drawing.Size(41, 13);
            this.lbAName.TabIndex = 2;
            this.lbAName.Text = "lbLevelType";
            // 
            // cbConstraint
            // 
            this.cbConstraint.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbConstraint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConstraint.FormattingEnabled = true;
            this.cbConstraint.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "<=",
            ">=",
            "<>"});
            this.cbConstraint.Location = new System.Drawing.Point(66, 22);
            this.cbConstraint.Name = "cbConstraint";
            this.cbConstraint.Size = new System.Drawing.Size(65, 21);
            this.cbConstraint.TabIndex = 3;
            // 
            // tbConstraint
            // 
            this.tbConstraint.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbConstraint.Location = new System.Drawing.Point(137, 22);
            this.tbConstraint.Name = "tbConstraint";
            this.tbConstraint.Size = new System.Drawing.Size(175, 21);
            this.tbConstraint.TabIndex = 4;
            // 
            // AConstraint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AConstraint";
            this.Size = new System.Drawing.Size(321, 52);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbAttribute;
        private System.Windows.Forms.Label lbConstraint;
        private System.Windows.Forms.Label lbAName;
        private System.Windows.Forms.ComboBox cbConstraint;
        private System.Windows.Forms.TextBox tbConstraint;
    }
}
