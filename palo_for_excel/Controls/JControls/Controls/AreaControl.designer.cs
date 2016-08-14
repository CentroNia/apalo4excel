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
    partial class AreaControl
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
            this.tGrid = new System.Windows.Forms.TableLayoutPanel();
            this.deControl = new JControls.DEControl(this.Filtered);
            this.tGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // tGrid
            // 
            this.tGrid.AutoSize = true;
            this.tGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tGrid.ColumnCount = 1;
            this.tGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tGrid.Controls.Add(this.deControl, 0, 0);
            this.tGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tGrid.Location = new System.Drawing.Point(0, 0);
            this.tGrid.Name = "tGrid";
            this.tGrid.RowCount = 1;
            this.tGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tGrid.Size = new System.Drawing.Size(150, 25);
            this.tGrid.TabIndex = 0;
            // 
            // deControl
            // 
            this.deControl.AutoSize = true;
            this.deControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deControl.CParent = this;
            this.deControl.ExprValue = "";
            this.deControl.Location = new System.Drawing.Point(4, 2);
            this.deControl.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.deControl.Name = "deControl";
            this.deControl.Size = new System.Drawing.Size(142, 21);
            this.deControl.TabIndex = 0;
            this.deControl.ExprValue = "";
            // 
            // AreaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tGrid);
            this.Margin = new System.Windows.Forms.Padding(26, 3, 3, 3);
            this.Name = "AreaControl";
            this.Size = new System.Drawing.Size(150, 25);
            this.tGrid.ResumeLayout(false);
            this.tGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tGrid;
        private DEControl deControl;
    }
}
