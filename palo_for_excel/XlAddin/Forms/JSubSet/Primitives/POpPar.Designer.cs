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
namespace Apalo.XlAddin.JSubSet
{
    partial class POpPar
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbOper1 = new System.Windows.Forms.ComboBox();
            this.tbPar2 = new Apalo.XlAddin.JSubSet.PString();
            this.tbPar1 = new Apalo.XlAddin.JSubSet.PString();
            this.cbOper2 = new System.Windows.Forms.ComboBox();
            this.lbAND = new System.Windows.Forms.Label();
            this.npPar1 = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npPar2 = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.cbOper1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbPar2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbPar1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbOper2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbAND, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(379, 74);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cbOper1
            // 
            this.cbOper1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOper1.FormattingEnabled = true;
            this.cbOper1.Location = new System.Drawing.Point(3, 3);
            this.cbOper1.Name = "cbOper1";
            this.cbOper1.Size = new System.Drawing.Size(74, 21);
            this.cbOper1.TabIndex = 11;
            this.cbOper1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tbPar2
            // 
            this.tbPar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPar2.Enabled = false;
            this.tbPar2.Location = new System.Drawing.Point(83, 50);
            this.tbPar2.Name = "tbPar2";
            this.tbPar2.PName = "Par2";
            this.tbPar2.Size = new System.Drawing.Size(293, 20);
            this.tbPar2.SValue = "";
            this.tbPar2.TabIndex = 14;
            // 
            // tbPar1
            // 
            this.tbPar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPar1.Location = new System.Drawing.Point(83, 3);
            this.tbPar1.Name = "tbPar1";
            this.tbPar1.PName = "Par1";
            this.tbPar1.Size = new System.Drawing.Size(293, 20);
            this.tbPar1.SValue = "";
            this.tbPar1.TabIndex = 12;
            // 
            // cbOper2
            // 
            this.cbOper2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOper2.Enabled = false;
            this.cbOper2.FormattingEnabled = true;
            this.cbOper2.Location = new System.Drawing.Point(3, 50);
            this.cbOper2.Name = "cbOper2";
            this.cbOper2.Size = new System.Drawing.Size(74, 21);
            this.cbOper2.TabIndex = 13;
            this.cbOper2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lbAND
            // 
            this.lbAND.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAND.AutoSize = true;
            this.lbAND.Location = new System.Drawing.Point(3, 30);
            this.lbAND.Name = "lbAND";
            this.lbAND.Size = new System.Drawing.Size(30, 13);
            this.lbAND.TabIndex = 0;
            this.lbAND.Tag = "AND";
            this.lbAND.Text = "AND";
            // 
            // npPar1
            // 
            this.npPar1.CBParameter = null;
            this.npPar1.IPrimitive = this.tbPar1;
            this.npPar1.SValue = "";
            // 
            // npPar2
            // 
            this.npPar2.CBParameter = null;
            this.npPar2.IPrimitive = this.tbPar2;
            this.npPar2.SValue = "";
            // 
            // POpPar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "POpPar";
            this.Size = new System.Drawing.Size(379, 74);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private PString tbPar2;
        private PString tbPar1;
        private System.Windows.Forms.Label lbAND;
        private System.Windows.Forms.ComboBox cbOper1;
        private System.Windows.Forms.ComboBox cbOper2;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npPar1;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npPar2;


    }
}
