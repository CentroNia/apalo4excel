 /* 
 *
 * Copyright (C) 2006-2009 Jedox AG
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
namespace Jedox.Palo.XlAddin.Forms
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new Crownwood.DotNetMagic.Controls.TabControl();
            this.tabCacheSettings = new Crownwood.DotNetMagic.Controls.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabGeneral = new Crownwood.DotNetMagic.Controls.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.advCtrl = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lang = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numCacheSize = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabCacheSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCacheSize)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(343, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 46;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.OfficeDockSides = false;
            this.tabControl1.PositionTop = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowDropSelect = false;
            this.tabControl1.Size = new System.Drawing.Size(430, 261);
            this.tabControl1.TabIndex = 47;
            this.tabControl1.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
            this.tabGeneral,
            this.tabCacheSettings});
            this.tabControl1.TextTips = true;
            // 
            // tabCacheSettings
            // 
            this.tabCacheSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.tabCacheSettings.Controls.Add(this.groupBox5);
            this.tabCacheSettings.Controls.Add(this.groupBox1);
            this.tabCacheSettings.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabCacheSettings.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabCacheSettings.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabCacheSettings.Location = new System.Drawing.Point(1, 24);
            this.tabCacheSettings.Name = "tabCacheSettings";
            this.tabCacheSettings.SelectBackColor = System.Drawing.Color.Empty;
            this.tabCacheSettings.Selected = false;
            this.tabCacheSettings.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabCacheSettings.SelectTextColor = System.Drawing.Color.Empty;
            this.tabCacheSettings.Size = new System.Drawing.Size(428, 236);
            this.tabCacheSettings.TabIndex = 4;
            this.tabCacheSettings.Title = "Cache";
            this.tabCacheSettings.ToolTip = "Page";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 79);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(14, 13);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 49);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabGeneral.Controls.Add(this.groupBox3);
            this.tabGeneral.Controls.Add(this.groupBox2);
            this.tabGeneral.Controls.Add(this.groupBox4);
            this.tabGeneral.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabGeneral.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabGeneral.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabGeneral.Location = new System.Drawing.Point(1, 24);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectBackColor = System.Drawing.Color.Empty;
            this.tabGeneral.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabGeneral.SelectTextColor = System.Drawing.Color.Empty;
            this.tabGeneral.Size = new System.Drawing.Size(428, 236);
            this.tabGeneral.TabIndex = 5;
            this.tabGeneral.Title = "General";
            this.tabGeneral.ToolTip = "Page";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.advCtrl);
            this.groupBox3.Location = new System.Drawing.Point(11, 175);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 48);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // advCtrl
            // 
            this.advCtrl.Checked = true;
            this.advCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.advCtrl.Location = new System.Drawing.Point(24, 12);
            this.advCtrl.Name = "advCtrl";
            this.advCtrl.Size = new System.Drawing.Size(380, 30);
            this.advCtrl.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lang);
            this.groupBox2.Location = new System.Drawing.Point(11, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 64);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // lang
            // 
            this.lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lang.Location = new System.Drawing.Point(24, 24);
            this.lang.Name = "lang";
            this.lang.Size = new System.Drawing.Size(241, 21);
            this.lang.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(11, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(406, 88);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numCacheSize);
            this.groupBox5.Location = new System.Drawing.Point(13, 139);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(404, 94);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // numCacheSize
            // 
            this.numCacheSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numCacheSize.Location = new System.Drawing.Point(83, 39);
            this.numCacheSize.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numCacheSize.Name = "numCacheSize";
            this.numCacheSize.Size = new System.Drawing.Size(120, 21);
            this.numCacheSize.TabIndex = 0;
            this.numCacheSize.ValueChanged += new System.EventHandler(this.numCacheSize_ValueChanged);
            // 
            // CacheDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(430, 307);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CacheDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabControl1.ResumeLayout(false);
            this.tabCacheSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabGeneral.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCacheSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private Crownwood.DotNetMagic.Controls.TabControl tabControl1;
        private Crownwood.DotNetMagic.Controls.TabPage tabCacheSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private Crownwood.DotNetMagic.Controls.TabPage tabGeneral;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox advCtrl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox lang;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numCacheSize;
    }
}