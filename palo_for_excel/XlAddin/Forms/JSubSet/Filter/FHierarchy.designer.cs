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
using Apalo.XlAddin.JSubSet.Primitives;
namespace Apalo.XlAddin.JSubSet
{
    partial class FHierarchy
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
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbRevolve = new System.Windows.Forms.RadioButton();
            this.rbElement = new System.Windows.Forms.RadioButton();
            this.tlpCount = new System.Windows.Forms.TableLayoutPanel();
            this.lbRevCount = new System.Windows.Forms.Label();
            this.piRevolveCount = new Apalo.XlAddin.JSubSet.PInt();
            this.cbLevel = new System.Windows.Forms.CheckBox();
            this.cbCountParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbHideParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbFromLevelParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbToLevelParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbShowOnly = new System.Windows.Forms.CheckBox();
            this.pElement = new Apalo.XlAddin.JSubSet.PElement();
            this.prbAboveBelow = new Apalo.XlAddin.JSubSet.Primitives.PRadioPanel();
            this.rbBelow = new System.Windows.Forms.RadioButton();
            this.rbAbove = new System.Windows.Forms.RadioButton();
            this.prbHide = new Apalo.XlAddin.JSubSet.Primitives.PRadioPanel();
            this.rbConsolidated = new System.Windows.Forms.RadioButton();
            this.rbLeaves = new System.Windows.Forms.RadioButton();
            this.pcbExclusive = new Apalo.XlAddin.JSubSet.PBool();
            this.cbElementParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbAboveBelowParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbExclusiveParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.tlpFromLevel = new System.Windows.Forms.TableLayoutPanel();
            this.lbLevel_Start = new System.Windows.Forms.Label();
            this.piFromLevel = new Apalo.XlAddin.JSubSet.PInt();
            this.lbLevelType2 = new System.Windows.Forms.Label();
            this.tlpToLevel = new System.Windows.Forms.TableLayoutPanel();
            this.lbLevel_End = new System.Windows.Forms.Label();
            this.piToLevel = new Apalo.XlAddin.JSubSet.PInt();
            this.lbLevelType1 = new System.Windows.Forms.Label();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.npElement = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.nprbAboveBelow = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npcbExclusive = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.nprbHide = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npiFromLevel = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npiToLevel = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npiRevolveCount = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.gbMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piRevolveCount)).BeginInit();
            this.prbAboveBelow.SuspendLayout();
            this.prbHide.SuspendLayout();
            this.tlpFromLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piFromLevel)).BeginInit();
            this.tlpToLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piToLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.tlpMain);
            this.gbMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMain.Location = new System.Drawing.Point(6, 0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Padding = new System.Windows.Forms.Padding(0);
            this.gbMain.Size = new System.Drawing.Size(504, 368);
            this.gbMain.TabIndex = 10;
            this.gbMain.TabStop = false;
            this.gbMain.Tag = "Hierarchy";
            this.gbMain.Text = "Hierarchy";
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Controls.Add(this.tlpCount, 0, 4);
            this.tlpMain.Controls.Add(this.cbLevel, 0, 7);
            this.tlpMain.Controls.Add(this.cbCountParam, 1, 4);
            this.tlpMain.Controls.Add(this.cbHideParam, 1, 6);
            this.tlpMain.Controls.Add(this.cbFromLevelParam, 1, 8);
            this.tlpMain.Controls.Add(this.cbToLevelParam, 1, 9);
            this.tlpMain.Controls.Add(this.cbShowOnly, 0, 5);
            this.tlpMain.Controls.Add(this.pElement, 0, 1);
            this.tlpMain.Controls.Add(this.prbAboveBelow, 0, 2);
            this.tlpMain.Controls.Add(this.prbHide, 0, 6);
            this.tlpMain.Controls.Add(this.pcbExclusive, 0, 3);
            this.tlpMain.Controls.Add(this.cbElementParam, 1, 1);
            this.tlpMain.Controls.Add(this.cbAboveBelowParam, 1, 2);
            this.tlpMain.Controls.Add(this.cbExclusiveParam, 1, 3);
            this.tlpMain.Controls.Add(this.tlpFromLevel, 0, 8);
            this.tlpMain.Controls.Add(this.tlpToLevel, 0, 9);
            this.tlpMain.Location = new System.Drawing.Point(3, 12);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.MinimumSize = new System.Drawing.Size(456, 300);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 10;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(496, 325);
            this.tlpMain.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 29);
            this.panel1.TabIndex = 30;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.rbRevolve, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbElement, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(184, 23);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // rbRevolve
            // 
            this.rbRevolve.AutoSize = true;
            this.rbRevolve.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRevolve.Location = new System.Drawing.Point(110, 3);
            this.rbRevolve.Margin = new System.Windows.Forms.Padding(24, 3, 3, 3);
            this.rbRevolve.Name = "rbRevolve";
            this.rbRevolve.Size = new System.Drawing.Size(71, 17);
            this.rbRevolve.TabIndex = 33;
            this.rbRevolve.Tag = "Revolve Element";
            this.rbRevolve.Text = "Revolve";
            this.rbRevolve.UseVisualStyleBackColor = true;
            // 
            // rbElement
            // 
            this.rbElement.AutoSize = true;
            this.rbElement.Checked = true;
            this.rbElement.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbElement.Location = new System.Drawing.Point(3, 3);
            this.rbElement.Name = "rbElement";
            this.rbElement.Size = new System.Drawing.Size(80, 17);
            this.rbElement.TabIndex = 32;
            this.rbElement.TabStop = true;
            this.rbElement.Tag = "Element";
            this.rbElement.Text = "Hierarchy";
            this.rbElement.UseVisualStyleBackColor = true;
            this.rbElement.CheckedChanged += new System.EventHandler(this.rbElement_CheckedChanged);
            // 
            // tlpCount
            // 
            this.tlpCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpCount.AutoSize = true;
            this.tlpCount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpCount.ColumnCount = 2;
            this.tlpCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCount.Controls.Add(this.lbRevCount, 0, 0);
            this.tlpCount.Controls.Add(this.piRevolveCount, 1, 0);
            this.tlpCount.Location = new System.Drawing.Point(45, 140);
            this.tlpCount.Margin = new System.Windows.Forms.Padding(45, 0, 3, 0);
            this.tlpCount.Name = "tlpCount";
            this.tlpCount.RowCount = 1;
            this.tlpCount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCount.Size = new System.Drawing.Size(127, 27);
            this.tlpCount.TabIndex = 50;
            this.tlpCount.Visible = false;
            // 
            // lbRevCount
            // 
            this.lbRevCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbRevCount.AutoSize = true;
            this.lbRevCount.Location = new System.Drawing.Point(0, 7);
            this.lbRevCount.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbRevCount.Name = "lbRevCount";
            this.lbRevCount.Size = new System.Drawing.Size(78, 13);
            this.lbRevCount.TabIndex = 0;
            this.lbRevCount.Tag = "Revolve Count";
            this.lbRevCount.Text = "Revolve Count";
            // 
            // piRevolveCount
            // 
            this.piRevolveCount.Location = new System.Drawing.Point(84, 3);
            this.piRevolveCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.piRevolveCount.Name = "piRevolveCount";
            this.piRevolveCount.PName = "List Length";
            this.piRevolveCount.Size = new System.Drawing.Size(40, 21);
            this.piRevolveCount.SValue = "1";
            this.piRevolveCount.TabIndex = 51;
            this.piRevolveCount.Tag = "Revolve Count";
            this.piRevolveCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbLevel
            // 
            this.cbLevel.AutoSize = true;
            this.cbLevel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLevel.Location = new System.Drawing.Point(11, 245);
            this.cbLevel.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Size = new System.Drawing.Size(56, 17);
            this.cbLevel.TabIndex = 65;
            this.cbLevel.Tag = "Level Element";
            this.cbLevel.Text = "Level";
            this.cbLevel.UseVisualStyleBackColor = true;
            this.cbLevel.CheckedChanged += new System.EventHandler(this.cbLevel_CheckedChanged);
            // 
            // cbCountParam
            // 
            this.cbCountParam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCountParam.AutoSize = true;
            this.cbCountParam.Location = new System.Drawing.Point(415, 145);
            this.cbCountParam.Name = "cbCountParam";
            this.cbCountParam.Size = new System.Drawing.Size(76, 17);
            this.cbCountParam.TabIndex = 52;
            this.cbCountParam.Text = "Parameter";
            this.cbCountParam.UseVisualStyleBackColor = true;
            this.cbCountParam.Visible = false;
            // 
            // cbHideParam
            // 
            this.cbHideParam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbHideParam.AutoSize = true;
            this.cbHideParam.Enabled = false;
            this.cbHideParam.Location = new System.Drawing.Point(415, 207);
            this.cbHideParam.Name = "cbHideParam";
            this.cbHideParam.Size = new System.Drawing.Size(76, 17);
            this.cbHideParam.TabIndex = 63;
            this.cbHideParam.Text = "Parameter";
            this.cbHideParam.UseVisualStyleBackColor = true;
            // 
            // cbFromLevelParam
            // 
            this.cbFromLevelParam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbFromLevelParam.AutoSize = true;
            this.cbFromLevelParam.Enabled = false;
            this.cbFromLevelParam.Location = new System.Drawing.Point(415, 273);
            this.cbFromLevelParam.Name = "cbFromLevelParam";
            this.cbFromLevelParam.Size = new System.Drawing.Size(76, 17);
            this.cbFromLevelParam.TabIndex = 72;
            this.cbFromLevelParam.Text = "Parameter";
            this.cbFromLevelParam.UseVisualStyleBackColor = true;
            // 
            // cbToLevelParam
            // 
            this.cbToLevelParam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbToLevelParam.AutoSize = true;
            this.cbToLevelParam.Enabled = false;
            this.cbToLevelParam.Location = new System.Drawing.Point(415, 306);
            this.cbToLevelParam.Name = "cbToLevelParam";
            this.cbToLevelParam.Size = new System.Drawing.Size(76, 17);
            this.cbToLevelParam.TabIndex = 82;
            this.cbToLevelParam.Text = "Parameter";
            this.cbToLevelParam.UseVisualStyleBackColor = true;
            // 
            // cbShowOnly
            // 
            this.cbShowOnly.AutoSize = true;
            this.cbShowOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowOnly.Location = new System.Drawing.Point(11, 170);
            this.cbShowOnly.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.cbShowOnly.Name = "cbShowOnly";
            this.cbShowOnly.Size = new System.Drawing.Size(84, 17);
            this.cbShowOnly.TabIndex = 55;
            this.cbShowOnly.Tag = "Hide";
            this.cbShowOnly.Text = "Show Only";
            this.cbShowOnly.UseVisualStyleBackColor = true;
            this.cbShowOnly.CheckedChanged += new System.EventHandler(this.cbHide_CheckedChanged);
            // 
            // pElement
            // 
            this.pElement.ImageList = null;
            this.pElement.Location = new System.Drawing.Point(48, 38);
            this.pElement.Margin = new System.Windows.Forms.Padding(48, 3, 3, 3);
            this.pElement.Name = "pElement";
            this.pElement.PName = "Element";
            this.pElement.PopupHeight = 400;
            this.pElement.Size = new System.Drawing.Size(317, 21);
            this.pElement.StateImageList = null;
            this.pElement.SValue = "";
            this.pElement.TabIndex = 35;
            this.pElement.Tag = "Element Name";
            // 
            // prbAboveBelow
            // 
            this.prbAboveBelow.AutoSize = true;
            this.prbAboveBelow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.prbAboveBelow.Controls.Add(this.rbBelow);
            this.prbAboveBelow.Controls.Add(this.rbAbove);
            this.prbAboveBelow.Inverse = false;
            this.prbAboveBelow.Location = new System.Drawing.Point(48, 65);
            this.prbAboveBelow.Margin = new System.Windows.Forms.Padding(48, 3, 3, 3);
            this.prbAboveBelow.Name = "prbAboveBelow";
            this.prbAboveBelow.PName = "Above";
            this.prbAboveBelow.PRadioPanelType = Apalo.XlAddin.JSubSet.Primitives.PRadioPanelType.Bool;
            this.prbAboveBelow.Size = new System.Drawing.Size(59, 46);
            this.prbAboveBelow.StartCount = 1;
            this.prbAboveBelow.SValue = "False";
            this.prbAboveBelow.TabIndex = 40;
            // 
            // rbBelow
            // 
            this.rbBelow.AutoSize = true;
            this.rbBelow.Checked = true;
            this.rbBelow.Location = new System.Drawing.Point(0, 3);
            this.rbBelow.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.rbBelow.Name = "rbBelow";
            this.rbBelow.Size = new System.Drawing.Size(53, 17);
            this.rbBelow.TabIndex = 41;
            this.rbBelow.TabStop = true;
            this.rbBelow.Tag = "Below";
            this.rbBelow.Text = "Below";
            this.rbBelow.UseVisualStyleBackColor = true;
            // 
            // rbAbove
            // 
            this.rbAbove.AutoSize = true;
            this.rbAbove.Location = new System.Drawing.Point(0, 26);
            this.rbAbove.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.rbAbove.Name = "rbAbove";
            this.rbAbove.Size = new System.Drawing.Size(56, 17);
            this.rbAbove.TabIndex = 42;
            this.rbAbove.Tag = "Above";
            this.rbAbove.Text = "Above";
            this.rbAbove.UseVisualStyleBackColor = true;
            // 
            // prbHide
            // 
            this.prbHide.AutoSize = true;
            this.prbHide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.prbHide.Controls.Add(this.rbConsolidated);
            this.prbHide.Controls.Add(this.rbLeaves);
            this.prbHide.Enabled = false;
            this.prbHide.Inverse = false;
            this.prbHide.Location = new System.Drawing.Point(48, 193);
            this.prbHide.Margin = new System.Windows.Forms.Padding(48, 3, 3, 3);
            this.prbHide.Name = "prbHide";
            this.prbHide.PName = "Hide";
            this.prbHide.PRadioPanelType = Apalo.XlAddin.JSubSet.Primitives.PRadioPanelType.Int;
            this.prbHide.Size = new System.Drawing.Size(90, 46);
            this.prbHide.StartCount = 1;
            this.prbHide.SValue = "1";
            this.prbHide.TabIndex = 60;
            // 
            // rbConsolidated
            // 
            this.rbConsolidated.AutoSize = true;
            this.rbConsolidated.Checked = true;
            this.rbConsolidated.Location = new System.Drawing.Point(0, 3);
            this.rbConsolidated.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.rbConsolidated.Name = "rbConsolidated";
            this.rbConsolidated.Size = new System.Drawing.Size(87, 17);
            this.rbConsolidated.TabIndex = 61;
            this.rbConsolidated.TabStop = true;
            this.rbConsolidated.Tag = "Consolidated";
            this.rbConsolidated.Text = "Consolidated";
            this.rbConsolidated.UseVisualStyleBackColor = true;
            // 
            // rbLeaves
            // 
            this.rbLeaves.AutoSize = true;
            this.rbLeaves.Location = new System.Drawing.Point(0, 26);
            this.rbLeaves.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.rbLeaves.Name = "rbLeaves";
            this.rbLeaves.Size = new System.Drawing.Size(59, 17);
            this.rbLeaves.TabIndex = 62;
            this.rbLeaves.Tag = "Leaves";
            this.rbLeaves.Text = "Leaves";
            this.rbLeaves.UseVisualStyleBackColor = true;
            // 
            // pcbExclusive
            // 
            this.pcbExclusive.AutoSize = true;
            this.pcbExclusive.Location = new System.Drawing.Point(48, 120);
            this.pcbExclusive.Margin = new System.Windows.Forms.Padding(48, 6, 3, 3);
            this.pcbExclusive.Name = "pcbExclusive";
            this.pcbExclusive.PName = "Exclusive";
            this.pcbExclusive.Size = new System.Drawing.Size(70, 17);
            this.pcbExclusive.SValue = "False";
            this.pcbExclusive.TabIndex = 45;
            this.pcbExclusive.Tag = "Exclusive";
            this.pcbExclusive.Text = "Exclusive";
            this.pcbExclusive.UseVisualStyleBackColor = true;
            // 
            // cbElementParam
            // 
            this.cbElementParam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbElementParam.AutoSize = true;
            this.cbElementParam.Location = new System.Drawing.Point(415, 40);
            this.cbElementParam.Name = "cbElementParam";
            this.cbElementParam.Size = new System.Drawing.Size(76, 17);
            this.cbElementParam.TabIndex = 36;
            this.cbElementParam.Text = "Parameter";
            this.cbElementParam.UseVisualStyleBackColor = true;
            // 
            // cbAboveBelowParam
            // 
            this.cbAboveBelowParam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbAboveBelowParam.AutoSize = true;
            this.cbAboveBelowParam.Location = new System.Drawing.Point(415, 79);
            this.cbAboveBelowParam.Name = "cbAboveBelowParam";
            this.cbAboveBelowParam.Size = new System.Drawing.Size(76, 17);
            this.cbAboveBelowParam.TabIndex = 43;
            this.cbAboveBelowParam.Text = "Parameter";
            this.cbAboveBelowParam.UseVisualStyleBackColor = true;
            // 
            // cbExclusiveParam
            // 
            this.cbExclusiveParam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbExclusiveParam.AutoSize = true;
            this.cbExclusiveParam.Location = new System.Drawing.Point(415, 118);
            this.cbExclusiveParam.Name = "cbExclusiveParam";
            this.cbExclusiveParam.Size = new System.Drawing.Size(76, 17);
            this.cbExclusiveParam.TabIndex = 46;
            this.cbExclusiveParam.Text = "Parameter";
            this.cbExclusiveParam.UseVisualStyleBackColor = true;
            // 
            // tlpFromLevel
            // 
            this.tlpFromLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpFromLevel.AutoSize = true;
            this.tlpFromLevel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpFromLevel.ColumnCount = 3;
            this.tlpFromLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFromLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFromLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFromLevel.Controls.Add(this.lbLevel_Start, 0, 0);
            this.tlpFromLevel.Controls.Add(this.piFromLevel, 1, 0);
            this.tlpFromLevel.Controls.Add(this.lbLevelType2, 2, 0);
            this.tlpFromLevel.Enabled = false;
            this.tlpFromLevel.Location = new System.Drawing.Point(45, 268);
            this.tlpFromLevel.Margin = new System.Windows.Forms.Padding(45, 3, 3, 3);
            this.tlpFromLevel.Name = "tlpFromLevel";
            this.tlpFromLevel.RowCount = 1;
            this.tlpFromLevel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFromLevel.Size = new System.Drawing.Size(244, 27);
            this.tlpFromLevel.TabIndex = 70;
            // 
            // lbLevel_Start
            // 
            this.lbLevel_Start.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbLevel_Start.Location = new System.Drawing.Point(0, 5);
            this.lbLevel_Start.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbLevel_Start.Name = "lbLevel_Start";
            this.lbLevel_Start.Size = new System.Drawing.Size(80, 16);
            this.lbLevel_Start.TabIndex = 0;
            this.lbLevel_Start.Tag = "Level Start";
            this.lbLevel_Start.Text = "From Level";
            // 
            // piFromLevel
            // 
            this.piFromLevel.Location = new System.Drawing.Point(86, 3);
            this.piFromLevel.Name = "piFromLevel";
            this.piFromLevel.PName = "Level Start";
            this.piFromLevel.Size = new System.Drawing.Size(40, 21);
            this.piFromLevel.SValue = "0";
            this.piFromLevel.TabIndex = 71;
            this.piFromLevel.Tag = "Level Start";
            // 
            // lbLevelType2
            // 
            this.lbLevelType2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbLevelType2.AutoSize = true;
            this.lbLevelType2.Location = new System.Drawing.Point(139, 7);
            this.lbLevelType2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lbLevelType2.Name = "lbLevelType2";
            this.lbLevelType2.Size = new System.Drawing.Size(102, 13);
            this.lbLevelType2.TabIndex = 0;
            this.lbLevelType2.Tag = "LB Hierarchy Indent";
            this.lbLevelType2.Text = "LB Hierarchy Indent";
            // 
            // tlpToLevel
            // 
            this.tlpToLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpToLevel.AutoSize = true;
            this.tlpToLevel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpToLevel.ColumnCount = 3;
            this.tlpToLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpToLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpToLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpToLevel.Controls.Add(this.lbLevel_End, 0, 0);
            this.tlpToLevel.Controls.Add(this.piToLevel, 1, 0);
            this.tlpToLevel.Controls.Add(this.lbLevelType1, 2, 0);
            this.tlpToLevel.Enabled = false;
            this.tlpToLevel.Location = new System.Drawing.Point(45, 301);
            this.tlpToLevel.Margin = new System.Windows.Forms.Padding(45, 3, 3, 3);
            this.tlpToLevel.Name = "tlpToLevel";
            this.tlpToLevel.RowCount = 1;
            this.tlpToLevel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpToLevel.Size = new System.Drawing.Size(241, 27);
            this.tlpToLevel.TabIndex = 80;
            // 
            // lbLevel_End
            // 
            this.lbLevel_End.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbLevel_End.Location = new System.Drawing.Point(0, 5);
            this.lbLevel_End.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbLevel_End.Name = "lbLevel_End";
            this.lbLevel_End.Size = new System.Drawing.Size(80, 16);
            this.lbLevel_End.TabIndex = 0;
            this.lbLevel_End.Tag = "Level End";
            this.lbLevel_End.Text = "To Level";
            // 
            // piToLevel
            // 
            this.piToLevel.Location = new System.Drawing.Point(86, 3);
            this.piToLevel.Name = "piToLevel";
            this.piToLevel.PName = "Level End";
            this.piToLevel.Size = new System.Drawing.Size(40, 21);
            this.piToLevel.SValue = "0";
            this.piToLevel.TabIndex = 81;
            this.piToLevel.Tag = "Level End";
            // 
            // lbLevelType1
            // 
            this.lbLevelType1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbLevelType1.AutoSize = true;
            this.lbLevelType1.Location = new System.Drawing.Point(139, 7);
            this.lbLevelType1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbLevelType1.Name = "lbLevelType1";
            this.lbLevelType1.Size = new System.Drawing.Size(102, 13);
            this.lbLevelType1.TabIndex = 0;
            this.lbLevelType1.Tag = "LB Hierarchy Indent";
            this.lbLevelType1.Text = "LB Hierarchy Indent";
            // 
            // tTip
            // 
            this.tTip.AutomaticDelay = 1000;
            this.tTip.AutoPopDelay = 20000;
            this.tTip.InitialDelay = 1000;
            this.tTip.IsBalloon = true;
            this.tTip.ReshowDelay = 200;
            this.tTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tTip.ToolTipTitle = "Description";
            // 
            // npElement
            // 
            this.npElement.CBParameter = this.cbElementParam;
            this.npElement.IPrimitive = this.pElement;
            this.npElement.SValue = "";
            // 
            // nprbAboveBelow
            // 
            this.nprbAboveBelow.CBParameter = this.cbAboveBelowParam;
            this.nprbAboveBelow.IPrimitive = this.prbAboveBelow;
            this.nprbAboveBelow.SValue = "False";
            // 
            // npcbExclusive
            // 
            this.npcbExclusive.CBParameter = this.cbExclusiveParam;
            this.npcbExclusive.IPrimitive = this.pcbExclusive;
            this.npcbExclusive.SValue = "False";
            // 
            // nprbHide
            // 
            this.nprbHide.CBParameter = this.cbHideParam;
            this.nprbHide.IPrimitive = this.prbHide;
            this.nprbHide.SValue = "1";
            // 
            // npiFromLevel
            // 
            this.npiFromLevel.CBParameter = this.cbFromLevelParam;
            this.npiFromLevel.IPrimitive = this.piFromLevel;
            this.npiFromLevel.SValue = "0";
            // 
            // npiToLevel
            // 
            this.npiToLevel.CBParameter = this.cbToLevelParam;
            this.npiToLevel.IPrimitive = this.piToLevel;
            this.npiToLevel.SValue = "0";
            // 
            // npiRevolveCount
            // 
            this.npiRevolveCount.CBParameter = this.cbCountParam;
            this.npiRevolveCount.IPrimitive = this.piRevolveCount;
            this.npiRevolveCount.SValue = "1";
            // 
            // FHierarchy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMain);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(472, 356);
            this.Name = "FHierarchy";
            this.Size = new System.Drawing.Size(516, 376);
            this.gbMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tlpCount.ResumeLayout(false);
            this.tlpCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piRevolveCount)).EndInit();
            this.prbAboveBelow.ResumeLayout(false);
            this.prbAboveBelow.PerformLayout();
            this.prbHide.ResumeLayout(false);
            this.prbHide.PerformLayout();
            this.tlpFromLevel.ResumeLayout(false);
            this.tlpFromLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piFromLevel)).EndInit();
            this.tlpToLevel.ResumeLayout(false);
            this.tlpToLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piToLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rbElement;
        private System.Windows.Forms.RadioButton rbRevolve;
        private System.Windows.Forms.TableLayoutPanel tlpCount;
        private System.Windows.Forms.Label lbRevCount;
        private System.Windows.Forms.CheckBox cbLevel;
        private CBParameter cbCountParam;
        private CBParameter cbHideParam;
        private CBParameter cbFromLevelParam;
        private CBParameter cbToLevelParam;
        private System.Windows.Forms.TableLayoutPanel tlpFromLevel;
        private System.Windows.Forms.Label lbLevel_Start;
        private System.Windows.Forms.TableLayoutPanel tlpToLevel;
        private System.Windows.Forms.Label lbLevel_End;
        private System.Windows.Forms.CheckBox cbShowOnly;
        private JSubSet.PElement pElement;
        private JSubSet.PInt piRevolveCount;
        private CBParameter cbElementParam;
        private PRadioPanel prbAboveBelow;
        private System.Windows.Forms.RadioButton rbAbove;
        private System.Windows.Forms.RadioButton rbBelow;
        private PRadioPanel prbHide;
        private PBool pcbExclusive;
        private PInt piFromLevel;
        private System.Windows.Forms.ToolTip tTip;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npElement;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive nprbAboveBelow;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npcbExclusive;
        private CBParameter cbAboveBelowParam;
        private CBParameter cbExclusiveParam;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive nprbHide;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npiFromLevel;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npiToLevel;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npiRevolveCount;
        private System.Windows.Forms.Label lbLevelType1;
        private System.Windows.Forms.Label lbLevelType2;
        private PInt piToLevel;
        public System.Windows.Forms.RadioButton rbLeaves;
        public System.Windows.Forms.RadioButton rbConsolidated;
    }
}
