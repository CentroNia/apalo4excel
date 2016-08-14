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
    partial class DEControl
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
            if (disposing && (cbElement != null))
            {
                cbElement.Dispose();
            }

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
            this.cbElement = new System.Windows.Forms.ComboBox();
            this.cbDimension = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // tGrid
            // 
            this.tGrid.AutoSize = true;
            this.tGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tGrid.ColumnCount = 4;
            this.tGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tGrid.Controls.Add(this.cbElement, 2, 0);
            this.tGrid.Controls.Add(this.cbDimension, 0, 0);
            this.tGrid.Controls.Add(this.label1, 1, 0);
            this.tGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tGrid.Location = new System.Drawing.Point(0, 0);
            this.tGrid.Name = "tGrid";
            this.tGrid.RowCount = 1;
            this.tGrid.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tGrid.Size = new System.Drawing.Size(214, 21);
            this.tGrid.TabIndex = 0;
            // 
            // cbElement
            // 
            this.cbElement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbElement.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbElement.FormattingEnabled = true;
            this.cbElement.Location = new System.Drawing.Point(114, 0);
            this.cbElement.Margin = new System.Windows.Forms.Padding(0);
            this.cbElement.Name = "cbElement";
            this.cbElement.Size = new System.Drawing.Size(100, 21);
            this.cbElement.TabIndex = 2;
            this.cbElement.Leave += new System.EventHandler(this.cb_Leave);
            this.cbElement.TextChanged += new System.EventHandler(this.cb_TextChanged);
            // 
            // cbDimension
            // 
            this.cbDimension.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbDimension.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDimension.FormattingEnabled = true;
            this.cbDimension.Location = new System.Drawing.Point(0, 0);
            this.cbDimension.Margin = new System.Windows.Forms.Padding(0);
            this.cbDimension.Name = "cbDimension";
            this.cbDimension.Size = new System.Drawing.Size(100, 21);
            this.cbDimension.TabIndex = 0;
            this.cbDimension.Leave += new System.EventHandler(this.cb_Leave);
            this.cbDimension.TextChanged += new System.EventHandler(this.cb_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(8, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = ":";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DEControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tGrid);
            this.Name = "DEControl";
            this.Size = new System.Drawing.Size(214, 21);
            this.tGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tGrid;
        private System.Windows.Forms.ComboBox cbElement;
        private System.Windows.Forms.ComboBox cbDimension;
        private System.Windows.Forms.Label label1;
    }
}
