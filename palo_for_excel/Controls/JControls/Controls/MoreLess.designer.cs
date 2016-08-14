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
    partial class MoreLess
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
            this.lessButton = new System.Windows.Forms.Button();
            this.moreButton = new System.Windows.Forms.Button();
            this.tGrid = new System.Windows.Forms.TableLayoutPanel();
            this.tGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lessButton
            // 
            this.lessButton.FlatAppearance.BorderSize = 0;
            this.lessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lessButton.Image = global::JControls.Properties.Resources.minus;
            this.lessButton.Location = new System.Drawing.Point(0, 0);
            this.lessButton.Margin = new System.Windows.Forms.Padding(0);
            this.lessButton.Name = "lessButton";
            this.lessButton.Size = new System.Drawing.Size(12, 12);
            this.lessButton.TabIndex = 2;
            // 
            // moreButton
            // 
            this.moreButton.FlatAppearance.BorderSize = 0;
            this.moreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moreButton.Image = global::JControls.Properties.Resources.plus;
            this.moreButton.Location = new System.Drawing.Point(0, 12);
            this.moreButton.Margin = new System.Windows.Forms.Padding(0);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(12, 12);
            this.moreButton.TabIndex = 3;
            // 
            // tGrid
            // 
            this.tGrid.AutoSize = true;
            this.tGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tGrid.Controls.Add(this.lessButton, 0, 0);
            this.tGrid.Controls.Add(this.moreButton, 0, 1);
            this.tGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tGrid.Location = new System.Drawing.Point(0, 0);
            this.tGrid.Name = "tGrid";
            this.tGrid.RowCount = 2;
            this.tGrid.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tGrid.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tGrid.Size = new System.Drawing.Size(12, 24);
            this.tGrid.TabIndex = 2;
            // 
            // MoreLess
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tGrid);
            this.Name = "MoreLess";
            this.Size = new System.Drawing.Size(12, 24);
            this.tGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tGrid;
        private System.Windows.Forms.Button lessButton;
        private System.Windows.Forms.Button moreButton;
    }
}
