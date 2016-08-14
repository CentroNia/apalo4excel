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

/*
using System.Drawing.Design;
using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Text;
*/
using System.ComponentModel;
using System.Windows.Forms;

namespace JControls
{
    partial class TabControlWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabControlWizard));
            this.PanelContenerTabs = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tcMain = new TabControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTitle = new System.Windows.Forms.Label();
            this._imgPanel = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.PanelContenerTabs.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._imgPanel)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelContenerTabs
            // 
            this.PanelContenerTabs.BackColor = System.Drawing.Color.White;
            this.PanelContenerTabs.Controls.Add(this.pnlBottom);
            this.PanelContenerTabs.Controls.Add(this.tcMain);
            this.PanelContenerTabs.Controls.Add(this.tableLayoutPanel1);
            this.PanelContenerTabs.Location = new System.Drawing.Point(162, 3);
            this.PanelContenerTabs.Name = "PanelContenerTabs";
            this.PanelContenerTabs.Size = new System.Drawing.Size(463, 391);
            this.PanelContenerTabs.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlBottom.Controls.Add(this.btnFinish);
            this.pnlBottom.Controls.Add(this.btnBack);
            this.pnlBottom.Controls.Add(this.btnNext);
            this.pnlBottom.Location = new System.Drawing.Point(2, 325);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(457, 66);
            this.pnlBottom.TabIndex = 16;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Location = new System.Drawing.Point(348, 25);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(72, 21);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Tag = "0";
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.button_event);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBack.ImageIndex = 1;
            this.btnBack.Location = new System.Drawing.Point(161, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 21);
            this.btnBack.TabIndex = 3;
            this.btnBack.Tag = "-1";
            this.btnBack.Text = " < Previus";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button_event);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(242, 25);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 21);
            this.btnNext.TabIndex = 4;
            this.btnNext.Tag = "1";
            this.btnNext.Text = "Next > ";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button_event);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Location = new System.Drawing.Point(1, 59);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(461, 267);
            this.tcMain.TabIndex = 6;
            this.tcMain.Tag = "7";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.86957F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.13043F));
            this.tableLayoutPanel1.Controls.Add(this.lbTitle, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, -2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 49);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbTitle.Location = new System.Drawing.Point(53, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(404, 48);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Palo Wizard";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _imgPanel
            // 
            this._imgPanel.Image = ((System.Drawing.Image)(resources.GetObject("_imgPanel.Image")));
            this._imgPanel.Location = new System.Drawing.Point(3, 1);
            this._imgPanel.Name = "_imgPanel";
            this._imgPanel.Size = new System.Drawing.Size(160, 393);
            this._imgPanel.TabIndex = 4;
            this._imgPanel.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(453, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "1";
            this.tabPage1.Text = "Step1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 58);
            this.panel1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(348, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 21);
            this.button1.TabIndex = 5;
            this.button1.Tag = "0";
            this.button1.Text = "Finish";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.ImageIndex = 1;
            this.button2.Location = new System.Drawing.Point(161, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 3;
            this.button2.Tag = "-1";
            this.button2.Text = " < Previus";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(242, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 21);
            this.button3.TabIndex = 4;
            this.button3.Tag = "1";
            this.button3.Text = "Next > ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome.....";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(453, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "2";
            this.tabPage2.Text = "Step2";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Location = new System.Drawing.Point(0, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 58);
            this.panel2.TabIndex = 13;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(348, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(68, 21);
            this.button4.TabIndex = 5;
            this.button4.Tag = "0";
            this.button4.Text = "Finish";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button5.ImageIndex = 1;
            this.button5.Location = new System.Drawing.Point(161, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 21);
            this.button5.TabIndex = 3;
            this.button5.Tag = "-1";
            this.button5.Text = " < Previus";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(242, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 21);
            this.button6.TabIndex = 4;
            this.button6.Tag = "1";
            this.button6.Text = "Next > ";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(453, 315);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "3";
            this.tabPage3.Text = "Step3";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Location = new System.Drawing.Point(0, 261);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(453, 58);
            this.panel3.TabIndex = 14;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(348, 17);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(68, 21);
            this.button7.TabIndex = 5;
            this.button7.Tag = "0";
            this.button7.Text = "Finish";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button8.ImageIndex = 1;
            this.button8.Location = new System.Drawing.Point(161, 17);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 21);
            this.button8.TabIndex = 3;
            this.button8.Tag = "-1";
            this.button8.Text = " < Previus";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(242, 17);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 21);
            this.button9.TabIndex = 4;
            this.button9.Tag = "1";
            this.button9.Text = "Next > ";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Location = new System.Drawing.Point(0, 2618);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(453, 58);
            this.panel4.TabIndex = 13;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.panel5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(453, 315);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Tag = "4";
            this.tabPage4.Text = "Step4";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.Controls.Add(this.button10);
            this.panel5.Controls.Add(this.button11);
            this.panel5.Controls.Add(this.button12);
            this.panel5.Location = new System.Drawing.Point(0, 261);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(453, 58);
            this.panel5.TabIndex = 12;
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(348, 17);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(68, 21);
            this.button10.TabIndex = 5;
            this.button10.Tag = "0";
            this.button10.Text = "Finish";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button11.ImageIndex = 1;
            this.button11.Location = new System.Drawing.Point(161, 17);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 21);
            this.button11.TabIndex = 3;
            this.button11.Tag = "-1";
            this.button11.Text = " < Previus";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(242, 17);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 21);
            this.button12.TabIndex = 4;
            this.button12.Tag = "1";
            this.button12.Text = "Next > ";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.Controls.Add(this.panel6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(453, 315);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Tag = "5";
            this.tabPage5.Text = "Step5";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel6.Controls.Add(this.button13);
            this.panel6.Controls.Add(this.button14);
            this.panel6.Controls.Add(this.button15);
            this.panel6.Location = new System.Drawing.Point(0, 261);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(453, 58);
            this.panel6.TabIndex = 11;
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(348, 17);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(68, 21);
            this.button13.TabIndex = 5;
            this.button13.Tag = "0";
            this.button13.Text = "Finish";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button14.ImageIndex = 1;
            this.button14.Location = new System.Drawing.Point(161, 17);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 21);
            this.button14.TabIndex = 3;
            this.button14.Tag = "-1";
            this.button14.Text = " < Previus";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(242, 17);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 21);
            this.button15.TabIndex = 4;
            this.button15.Tag = "1";
            this.button15.Text = "Next > ";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.White;
            this.tabPage6.Controls.Add(this.panel7);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(453, 315);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Tag = "6";
            this.tabPage6.Text = "Step6";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel7.Controls.Add(this.button16);
            this.panel7.Controls.Add(this.button17);
            this.panel7.Controls.Add(this.button18);
            this.panel7.Location = new System.Drawing.Point(0, 261);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(453, 58);
            this.panel7.TabIndex = 10;
            // 
            // button16
            // 
            this.button16.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.button16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(348, 17);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(68, 21);
            this.button16.TabIndex = 5;
            this.button16.Tag = "0";
            this.button16.Text = "Finish";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button17.ImageIndex = 1;
            this.button17.Location = new System.Drawing.Point(161, 17);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 21);
            this.button17.TabIndex = 3;
            this.button17.Tag = "-1";
            this.button17.Text = " < Previus";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Location = new System.Drawing.Point(242, 17);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 21);
            this.button18.TabIndex = 4;
            this.button18.Tag = "1";
            this.button18.Text = "Next > ";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.White;
            this.tabPage7.Controls.Add(this.panel8);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(453, 315);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Tag = "7";
            this.tabPage7.Text = "Step7";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel8.Controls.Add(this.button19);
            this.panel8.Controls.Add(this.button20);
            this.panel8.Controls.Add(this.button21);
            this.panel8.Location = new System.Drawing.Point(0, 261);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(453, 58);
            this.panel8.TabIndex = 9;
            // 
            // button19
            // 
            this.button19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(348, 17);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(68, 21);
            this.button19.TabIndex = 5;
            this.button19.Tag = "0";
            this.button19.Text = "Finish";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button20.ImageIndex = 1;
            this.button20.Location = new System.Drawing.Point(161, 17);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(75, 21);
            this.button20.TabIndex = 3;
            this.button20.Tag = "-1";
            this.button20.Text = " < Previus";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.button21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(242, 17);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 21);
            this.button21.TabIndex = 4;
            this.button21.Tag = "1";
            this.button21.Text = "Next > ";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.White;
            this.tabPage8.Controls.Add(this.panel9);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(453, 315);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Tag = "8";
            this.tabPage8.Text = "Step8";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel9.Controls.Add(this.button22);
            this.panel9.Controls.Add(this.button23);
            this.panel9.Controls.Add(this.button24);
            this.panel9.Location = new System.Drawing.Point(0, 261);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(453, 58);
            this.panel9.TabIndex = 8;
            // 
            // button22
            // 
            this.button22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Location = new System.Drawing.Point(348, 17);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(68, 21);
            this.button22.TabIndex = 5;
            this.button22.Tag = "0";
            this.button22.Text = "Finish";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // button23
            // 
            this.button23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button23.ImageIndex = 1;
            this.button23.Location = new System.Drawing.Point(161, 17);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(75, 21);
            this.button23.TabIndex = 3;
            this.button23.Tag = "-1";
            this.button23.Text = " < Previus";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // button24
            // 
            this.button24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Location = new System.Drawing.Point(242, 17);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(75, 21);
            this.button24.TabIndex = 4;
            this.button24.Tag = "1";
            this.button24.Text = "Next > ";
            this.button24.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.Controls.Add(this.panel11);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(453, 315);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Tag = "9";
            this.tabPage9.Text = "Step9";
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel11.Controls.Add(this.button25);
            this.panel11.Controls.Add(this.button26);
            this.panel11.Controls.Add(this.button27);
            this.panel11.Location = new System.Drawing.Point(0, 261);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(453, 58);
            this.panel11.TabIndex = 7;
            // 
            // button25
            // 
            this.button25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Location = new System.Drawing.Point(348, 17);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(68, 21);
            this.button25.TabIndex = 5;
            this.button25.Tag = "0";
            this.button25.Text = "Finish";
            this.button25.UseVisualStyleBackColor = true;
            // 
            // button26
            // 
            this.button26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button26.ImageIndex = 1;
            this.button26.Location = new System.Drawing.Point(161, 17);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(75, 21);
            this.button26.TabIndex = 3;
            this.button26.Tag = "-1";
            this.button26.Text = " < Previus";
            this.button26.UseVisualStyleBackColor = true;
            // 
            // button27
            // 
            this.button27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.Location = new System.Drawing.Point(242, 17);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(75, 21);
            this.button27.TabIndex = 4;
            this.button27.Tag = "1";
            this.button27.Text = "Next > ";
            this.button27.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.White;
            this.tabPage10.Controls.Add(this.panel12);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(453, 315);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Tag = "10";
            this.tabPage10.Text = "Step10";
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel12.Controls.Add(this.button28);
            this.panel12.Controls.Add(this.button29);
            this.panel12.Controls.Add(this.button30);
            this.panel12.Location = new System.Drawing.Point(0, 261);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(453, 58);
            this.panel12.TabIndex = 6;
            // 
            // button28
            // 
            this.button28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button28.Location = new System.Drawing.Point(348, 17);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(68, 21);
            this.button28.TabIndex = 5;
            this.button28.Tag = "0";
            this.button28.Text = "Finish";
            this.button28.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            this.button29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button29.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button29.ImageIndex = 1;
            this.button29.Location = new System.Drawing.Point(161, 17);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(75, 21);
            this.button29.TabIndex = 3;
            this.button29.Tag = "-1";
            this.button29.Text = " < Previus";
            this.button29.UseVisualStyleBackColor = true;
            // 
            // button30
            // 
            this.button30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button30.Location = new System.Drawing.Point(242, 17);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(75, 21);
            this.button30.TabIndex = 4;
            this.button30.Tag = "1";
            this.button30.Text = "Next > ";
            this.button30.UseVisualStyleBackColor = true;
            // 
            // TabControlWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._imgPanel);
            this.Controls.Add(this.PanelContenerTabs);
            this.Name = "TabControlWizard";
            this.Size = new System.Drawing.Size(624, 395);
            this.PanelContenerTabs.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._imgPanel)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel PanelContenerTabs;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbTitle;

        [Description("The title associated with the control"), Category("TabControlWizard")]
        public string TitleLabel
        {
            get { return lbTitle.Text; }
            set { lbTitle.Text = value; }
        }
        //[Description("The title associated with the control"), Category("TabControlWizard")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //[Browsable(true)]
        //[EditorBrowsable(EditorBrowsableState.Always)]
        //public HideTongue.TabPageCollection TabControls
        //{
        //    get { return tcMain.TabPages; }

        //    set { 
        //        System.Collections.ArrayList al = new System.Collections.ArrayList();
        //        foreach (TabPage tb in value)
        //        {
        //            al.Add(tb);
                
                
        //        }



        //    }
  
        //}
        private System.Windows.Forms.PictureBox _imgPanel;
        [Description("The Image associated with the wizard control"), Category("TabControlWizard")]
        public System.Drawing.Image LeftPanelImage
        {
            get { return _imgPanel.Image; }
            set { _imgPanel.Image = value; }
        }

        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button button6;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button button8;
        public System.Windows.Forms.Button button9;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Button button10;
        public System.Windows.Forms.Button button11;
        public System.Windows.Forms.Button button12;
        public System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Button button13;
        public System.Windows.Forms.Button button14;
        public System.Windows.Forms.Button button15;
        public System.Windows.Forms.TabPage tabPage6;
        public System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.Button button16;
        public System.Windows.Forms.Button button17;
        public System.Windows.Forms.Button button18;
        public System.Windows.Forms.TabPage tabPage7;
        public System.Windows.Forms.Panel panel8;
        public System.Windows.Forms.Button button19;
        public System.Windows.Forms.Button button20;
        public System.Windows.Forms.Button button21;
        public System.Windows.Forms.TabPage tabPage8;
        public System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.Button button22;
        public System.Windows.Forms.Button button23;
        public System.Windows.Forms.Button button24;
        public System.Windows.Forms.TabPage tabPage9;
        public System.Windows.Forms.Panel panel11;
        public System.Windows.Forms.Button button25;
        public System.Windows.Forms.Button button26;
        public System.Windows.Forms.Button button27;
        public System.Windows.Forms.TabPage tabPage10;
        public System.Windows.Forms.Panel panel12;
        public System.Windows.Forms.Button button28;
        public System.Windows.Forms.Button button29;
        public System.Windows.Forms.Button button30;
        public TabControl tcMain;
        public System.Windows.Forms.Panel pnlBottom;
        public System.Windows.Forms.Button btnFinish;
        public System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.Button btnNext;

  

    }
}
