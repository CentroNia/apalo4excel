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
    partial class ASubSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASubSet));
            this.imlList = new System.Windows.Forms.ImageList(this.components);
            this.tcFilters = new JTabControl();
            this.tpGeneral = new JTabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lbGeneral = new System.Windows.Forms.Label();
            this.fGeneral = new Apalo.XlAddin.JSubSet.Filter.FGeneral();
            this.tpHierarchy = new JTabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lbHierarchy = new System.Windows.Forms.Label();
            this.cbHierarchyActivate = new System.Windows.Forms.CheckBox();
            this.fHierarchy = new Apalo.XlAddin.JSubSet.FHierarchy();
            this.tpText = new JTabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lbText = new System.Windows.Forms.Label();
            this.cbTextActivate = new System.Windows.Forms.CheckBox();
            this.fText = new Apalo.XlAddin.JSubSet.Filter.FText();
            this.tpPicklist = new JTabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cbPicklistActivate = new System.Windows.Forms.CheckBox();
            this.lbPicklist = new System.Windows.Forms.Label();
            this.fPicklist = new Apalo.XlAddin.JSubSet.Filter.FPicklist();
            this.tpAttribute = new JTabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbAttribute = new System.Windows.Forms.Label();
            this.cbAttributeActivate = new System.Windows.Forms.CheckBox();
            this.fAttribute = new Apalo.XlAddin.JSubSet.Filter.FAttribute();
            this.tpData = new JTabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbData = new System.Windows.Forms.Label();
            this.cbDataActivate = new System.Windows.Forms.CheckBox();
            this.fData = new Apalo.XlAddin.JSubSet.Filter.FData();
            this.tpSort = new JTabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbSorting = new System.Windows.Forms.Label();
            this.fSort = new Apalo.XlAddin.JSubSet.Filter.FSort();
            this.label1 = new System.Windows.Forms.Label();
            this.tcFilters.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tpHierarchy.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tpText.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tpPicklist.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tpAttribute.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tpData.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tpSort.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imlList
            // 
            this.imlList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlList.ImageStream")));
            this.imlList.TransparentColor = System.Drawing.Color.Transparent;
            this.imlList.Images.SetKeyName(0, "drawing.png");
            this.imlList.Images.SetKeyName(1, "subsetIcon.png");
            this.imlList.Images.SetKeyName(2, "folfer_open_16.png");
            this.imlList.Images.SetKeyName(3, "save_16.png");
            this.imlList.Images.SetKeyName(4, "delete_x_16.png");
            // 
            // tcFilters
            // 
            //this.tcFilters.AllowDragReorder = false;
            this.tcFilters.AllowDrop = false;
            //this.tcFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tcFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.tcFilters.IDE2005HeaderBorder = true;
            //this.tcFilters.IDE2005PixelBorder = false;
            this.tcFilters.Location = new System.Drawing.Point(0, 0);
            this.tcFilters.Name = "tcFilters";
            //this.tcFilters.OfficeDockSides = false;
            //this.tcFilters.PositionTop = true;
            this.tcFilters.SelectedIndex = 6;
            //this.tcFilters.ShowDropSelect = false;
            this.tcFilters.Size = new System.Drawing.Size(516, 500);
            //this.tcFilters.Style = Crownwood.DotNetMagic.Common.VisualStyle.IDE2005;
            this.tcFilters.TabIndex = 1;
            this.tcFilters.TabPages.AddRange(new System.Windows.Forms.TabPage[] {
            this.tpGeneral,
            this.tpHierarchy,
            this.tpText,
            this.tpPicklist,
            this.tpAttribute,
            this.tpData,
            this.tpSort});
            this.tcFilters.Tag = "Filter General";
            //this.tcFilters.TextTips = true;
            // 
            // tpGeneral
            // 
            this.tpGeneral.AutoScroll = true;
            this.tpGeneral.Controls.Add(this.tableLayoutPanel7);
            this.tpGeneral.Controls.Add(this.fGeneral);
            //this.tpGeneral.InactiveBackColor = System.Drawing.Color.Empty;
            //this.tpGeneral.InactiveTextBackColor = System.Drawing.Color.Empty;
            //this.tpGeneral.InactiveTextColor = System.Drawing.Color.Empty;
            this.tpGeneral.Location = new System.Drawing.Point(0, 27);
            this.tpGeneral.Name = "tpGeneral";
            //this.tpGeneral.SelectBackColor = System.Drawing.Color.Empty;
            this.tpGeneral.Selected = false;
            //this.tpGeneral.SelectTextBackColor = System.Drawing.Color.Empty;
            //this.tpGeneral.SelectTextColor = System.Drawing.Color.Empty;
            this.tpGeneral.Size = new System.Drawing.Size(516, 473);
            this.tpGeneral.TabIndex = 10;
            this.tpGeneral.Tag = "Filter General";
            this.tpGeneral.Title = "General";
            //this.tpGeneral.ToolTip = "General";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.lbGeneral, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(507, 30);
            this.tableLayoutPanel7.TabIndex = 11;
            // 
            // lbGeneral
            // 
            this.lbGeneral.AutoSize = true;
            this.lbGeneral.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGeneral.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbGeneral.Location = new System.Drawing.Point(1, 1);
            this.lbGeneral.Margin = new System.Windows.Forms.Padding(1);
            this.lbGeneral.Name = "lbGeneral";
            this.lbGeneral.Size = new System.Drawing.Size(254, 24);
            this.lbGeneral.TabIndex = 0;
            this.lbGeneral.Tag = "Subset General Settings";
            this.lbGeneral.Text = "Subset General Settings";
            // 
            // fGeneral
            // 
            this.fGeneral.Alias1 = "";
            this.fGeneral.Alias2 = "";
            this.fGeneral.CBUse = null;
            this.fGeneral.Dimension = "";
            this.fGeneral.DimensionId = -1;
            this.fGeneral.EnableDBChange = true;
            this.fGeneral.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGeneral.Location = new System.Drawing.Point(0, 30);
            this.fGeneral.Name = "fGeneral";
            this.fGeneral.Size = new System.Drawing.Size(512, 299);
            this.fGeneral.TabIndex = 13;
            // 
            // tpHierarchy
            // 
            this.tpHierarchy.AutoScroll = true;
            this.tpHierarchy.Controls.Add(this.tableLayoutPanel6);
            this.tpHierarchy.Controls.Add(this.fHierarchy);
            //this.tpHierarchy.InactiveBackColor = System.Drawing.Color.Empty;
            //this.tpHierarchy.InactiveTextBackColor = System.Drawing.Color.Empty;
            //this.tpHierarchy.InactiveTextColor = System.Drawing.Color.Empty;
            this.tpHierarchy.Location = new System.Drawing.Point(0, 27);
            this.tpHierarchy.Name = "tpHierarchy";
            //this.tpHierarchy.SelectBackColor = System.Drawing.Color.Empty;
            this.tpHierarchy.Selected = false;
            //this.tpHierarchy.SelectTextBackColor = System.Drawing.Color.Empty;
            //this.tpHierarchy.SelectTextColor = System.Drawing.Color.Empty;
            this.tpHierarchy.Size = new System.Drawing.Size(516, 473);
            this.tpHierarchy.TabIndex = 20;
            this.tpHierarchy.Tag = "Filter Hierarchy";
            this.tpHierarchy.Title = "Hierarchy";
            //this.tpHierarchy.ToolTip = "Hierarchy";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.lbHierarchy, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbHierarchyActivate, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(507, 30);
            this.tableLayoutPanel6.TabIndex = 21;
            // 
            // lbHierarchy
            // 
            this.lbHierarchy.AutoSize = true;
            this.lbHierarchy.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHierarchy.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbHierarchy.Location = new System.Drawing.Point(1, 1);
            this.lbHierarchy.Margin = new System.Windows.Forms.Padding(1);
            this.lbHierarchy.Name = "lbHierarchy";
            this.lbHierarchy.Size = new System.Drawing.Size(238, 24);
            this.lbHierarchy.TabIndex = 0;
            this.lbHierarchy.Tag = "Subset Hierarchy Filter";
            this.lbHierarchy.Text = "Subset Hierarchy Filter";
            // 
            // cbHierarchyActivate
            // 
            this.cbHierarchyActivate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbHierarchyActivate.AutoSize = true;
            this.cbHierarchyActivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbHierarchyActivate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHierarchyActivate.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbHierarchyActivate.Location = new System.Drawing.Point(379, 6);
            this.cbHierarchyActivate.Margin = new System.Windows.Forms.Padding(0);
            this.cbHierarchyActivate.Name = "cbHierarchyActivate";
            this.cbHierarchyActivate.Size = new System.Drawing.Size(128, 17);
            this.cbHierarchyActivate.TabIndex = 22;
            this.cbHierarchyActivate.Tag = "Activate Filter";
            this.cbHierarchyActivate.Text = "Activate this filter";
            this.cbHierarchyActivate.UseVisualStyleBackColor = true;
            this.cbHierarchyActivate.CheckedChanged += new System.EventHandler(this.cbHierarchyActivate_CheckedChanged);
            // 
            // fHierarchy
            // 
            this.fHierarchy.AutoSize = true;
            this.fHierarchy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fHierarchy.CBUse = this.cbHierarchyActivate;
            this.fHierarchy.Enabled = false;
            this.fHierarchy.IsUsed = false;
            this.fHierarchy.Location = new System.Drawing.Point(0, 33);
            this.fHierarchy.Margin = new System.Windows.Forms.Padding(6);
            this.fHierarchy.MinimumSize = new System.Drawing.Size(472, 387);
            this.fHierarchy.Name = "fHierarchy";
            this.fHierarchy.Size = new System.Drawing.Size(684, 514);
            this.fHierarchy.TabIndex = 23;
            // 
            // tpText
            // 
            this.tpText.AutoScroll = true;
            this.tpText.Controls.Add(this.tableLayoutPanel5);
            this.tpText.Controls.Add(this.fText);
            //this.tpText.InactiveBackColor = System.Drawing.Color.Empty;
            //this.tpText.InactiveTextBackColor = System.Drawing.Color.Empty;
            //this.tpText.InactiveTextColor = System.Drawing.Color.Empty;
            this.tpText.Location = new System.Drawing.Point(0, 27);
            this.tpText.Name = "tpText";
            //this.tpText.SelectBackColor = System.Drawing.Color.Empty;
            this.tpText.Selected = false;
            //this.tpText.SelectTextBackColor = System.Drawing.Color.Empty;
            //this.tpText.SelectTextColor = System.Drawing.Color.Empty;
            this.tpText.Size = new System.Drawing.Size(516, 473);
            this.tpText.TabIndex = 30;
            this.tpText.Tag = "Filter Text";
            this.tpText.Title = "Text";
            //this.tpText.ToolTip = "Text";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.lbText, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.cbTextActivate, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(507, 30);
            this.tableLayoutPanel5.TabIndex = 31;
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbText.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbText.Location = new System.Drawing.Point(1, 1);
            this.lbText.Margin = new System.Windows.Forms.Padding(1);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(187, 24);
            this.lbText.TabIndex = 0;
            this.lbText.Tag = "Subset Text Filter";
            this.lbText.Text = "Subset Text Filter";
            // 
            // cbTextActivate
            // 
            this.cbTextActivate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbTextActivate.AutoSize = true;
            this.cbTextActivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbTextActivate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTextActivate.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbTextActivate.Location = new System.Drawing.Point(379, 6);
            this.cbTextActivate.Margin = new System.Windows.Forms.Padding(0);
            this.cbTextActivate.Name = "cbTextActivate";
            this.cbTextActivate.Size = new System.Drawing.Size(128, 17);
            this.cbTextActivate.TabIndex = 32;
            this.cbTextActivate.Tag = "Activate Filter";
            this.cbTextActivate.Text = "Activate this filter";
            this.cbTextActivate.UseVisualStyleBackColor = true;
            this.cbTextActivate.CheckedChanged += new System.EventHandler(this.cbTextActivate_CheckedChanged);
            // 
            // fText
            // 
            this.fText.CBUse = this.cbTextActivate;
            this.fText.Enabled = false;
            this.fText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fText.IsUsed = false;
            this.fText.Location = new System.Drawing.Point(0, 30);
            this.fText.Name = "fText";
            this.fText.Size = new System.Drawing.Size(512, 370);
            this.fText.TabIndex = 33;
            // 
            // tpPicklist
            // 
            this.tpPicklist.AutoScroll = true;
            this.tpPicklist.Controls.Add(this.tableLayoutPanel4);
            this.tpPicklist.Controls.Add(this.fPicklist);
            //this.tpPicklist.InactiveBackColor = System.Drawing.Color.Empty;
            //this.tpPicklist.InactiveTextBackColor = System.Drawing.Color.Empty;
            //this.tpPicklist.InactiveTextColor = System.Drawing.Color.Empty;
            this.tpPicklist.Location = new System.Drawing.Point(0, 27);
            this.tpPicklist.Name = "tpPicklist";
            //this.tpPicklist.SelectBackColor = System.Drawing.Color.Empty;
            this.tpPicklist.Selected = false;
            //this.tpPicklist.SelectTextBackColor = System.Drawing.Color.Empty;
            //this.tpPicklist.SelectTextColor = System.Drawing.Color.Empty;
            this.tpPicklist.Size = new System.Drawing.Size(516, 473);
            this.tpPicklist.TabIndex = 40;
            this.tpPicklist.Tag = "Filter Picklist";
            this.tpPicklist.Title = "Picklist";
            //this.tpPicklist.ToolTip = "Picklist";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.cbPicklistActivate, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbPicklist, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(507, 30);
            this.tableLayoutPanel4.TabIndex = 41;
            // 
            // cbPicklistActivate
            // 
            this.cbPicklistActivate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbPicklistActivate.AutoSize = true;
            this.cbPicklistActivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPicklistActivate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPicklistActivate.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbPicklistActivate.Location = new System.Drawing.Point(379, 6);
            this.cbPicklistActivate.Margin = new System.Windows.Forms.Padding(0);
            this.cbPicklistActivate.Name = "cbPicklistActivate";
            this.cbPicklistActivate.Size = new System.Drawing.Size(128, 17);
            this.cbPicklistActivate.TabIndex = 42;
            this.cbPicklistActivate.Tag = "Activate Filter";
            this.cbPicklistActivate.Text = "Activate this filter";
            this.cbPicklistActivate.UseVisualStyleBackColor = true;
            this.cbPicklistActivate.CheckedChanged += new System.EventHandler(this.cbPicklistActivate_CheckedChanged);
            // 
            // lbPicklist
            // 
            this.lbPicklist.AutoSize = true;
            this.lbPicklist.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPicklist.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbPicklist.Location = new System.Drawing.Point(1, 1);
            this.lbPicklist.Margin = new System.Windows.Forms.Padding(1);
            this.lbPicklist.Name = "lbPicklist";
            this.lbPicklist.Size = new System.Drawing.Size(215, 24);
            this.lbPicklist.TabIndex = 0;
            this.lbPicklist.Tag = "Subset Picklist Filter";
            this.lbPicklist.Text = "Subset Picklist Filter";
            // 
            // fPicklist
            // 
            this.fPicklist.CBUse = this.cbPicklistActivate;
            this.fPicklist.Enabled = false;
            this.fPicklist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fPicklist.IsUsed = false;
            this.fPicklist.Location = new System.Drawing.Point(0, 30);
            this.fPicklist.Name = "fPicklist";
            this.fPicklist.Size = new System.Drawing.Size(512, 378);
            this.fPicklist.TabIndex = 43;
            // 
            // tpAttribute
            // 
            this.tpAttribute.AutoScroll = true;
            this.tpAttribute.Controls.Add(this.tableLayoutPanel3);
            this.tpAttribute.Controls.Add(this.fAttribute);
            //this.tpAttribute.InactiveBackColor = System.Drawing.Color.Empty;
            //this.tpAttribute.InactiveTextBackColor = System.Drawing.Color.Empty;
            //this.tpAttribute.InactiveTextColor = System.Drawing.Color.Empty;
            this.tpAttribute.Location = new System.Drawing.Point(0, 27);
            this.tpAttribute.Name = "tpAttribute";
            //this.tpAttribute.SelectBackColor = System.Drawing.Color.Empty;
            this.tpAttribute.Selected = false;
            //this.tpAttribute.SelectTextBackColor = System.Drawing.Color.Empty;
            //this.tpAttribute.SelectTextColor = System.Drawing.Color.Empty;
            this.tpAttribute.Size = new System.Drawing.Size(516, 473);
            this.tpAttribute.TabIndex = 50;
            this.tpAttribute.Tag = "Filter Attribute";
            this.tpAttribute.Title = "Attribute";
            //this.tpAttribute.ToolTip = "Attribute";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.lbAttribute, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbAttributeActivate, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(507, 30);
            this.tableLayoutPanel3.TabIndex = 51;
            // 
            // lbAttribute
            // 
            this.lbAttribute.AutoSize = true;
            this.lbAttribute.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAttribute.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbAttribute.Location = new System.Drawing.Point(1, 1);
            this.lbAttribute.Margin = new System.Windows.Forms.Padding(1);
            this.lbAttribute.Name = "lbAttribute";
            this.lbAttribute.Size = new System.Drawing.Size(230, 24);
            this.lbAttribute.TabIndex = 0;
            this.lbAttribute.Tag = "Subset Attribute Filter";
            this.lbAttribute.Text = "Subset Attribute Filter";
            // 
            // cbAttributeActivate
            // 
            this.cbAttributeActivate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbAttributeActivate.AutoSize = true;
            this.cbAttributeActivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAttributeActivate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAttributeActivate.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbAttributeActivate.Location = new System.Drawing.Point(379, 6);
            this.cbAttributeActivate.Margin = new System.Windows.Forms.Padding(0);
            this.cbAttributeActivate.Name = "cbAttributeActivate";
            this.cbAttributeActivate.Size = new System.Drawing.Size(128, 17);
            this.cbAttributeActivate.TabIndex = 52;
            this.cbAttributeActivate.Tag = "Activate Filter";
            this.cbAttributeActivate.Text = "Activate this filter";
            this.cbAttributeActivate.UseVisualStyleBackColor = true;
            this.cbAttributeActivate.CheckedChanged += new System.EventHandler(this.cbAttributeActivate_CheckedChanged);
            // 
            // fAttribute
            // 
            this.fAttribute.CBUse = this.cbAttributeActivate;
            this.fAttribute.Enabled = false;
            this.fAttribute.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fAttribute.IsUsed = false;
            this.fAttribute.Location = new System.Drawing.Point(0, 30);
            this.fAttribute.Name = "fAttribute";
            this.fAttribute.Size = new System.Drawing.Size(512, 377);
            this.fAttribute.TabIndex = 53;
            // 
            // tpData
            // 
            this.tpData.AutoScroll = true;
            this.tpData.Controls.Add(this.tableLayoutPanel2);
            this.tpData.Controls.Add(this.fData);
            //this.tpData.InactiveBackColor = System.Drawing.Color.Empty;
            //this.tpData.InactiveTextBackColor = System.Drawing.Color.Empty;
            //this.tpData.InactiveTextColor = System.Drawing.Color.Empty;
            this.tpData.Location = new System.Drawing.Point(0, 27);
            this.tpData.Name = "tpData";
            //this.tpData.SelectBackColor = System.Drawing.Color.Empty;
            this.tpData.Selected = false;
            //this.tpData.SelectTextBackColor = System.Drawing.Color.Empty;
            //this.tpData.SelectTextColor = System.Drawing.Color.Empty;
            this.tpData.Size = new System.Drawing.Size(516, 473);
            this.tpData.TabIndex = 60;
            this.tpData.Tag = "Filter Data";
            this.tpData.Title = "Data";
            //this.tpData.ToolTip = "Data";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lbData, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbDataActivate, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(507, 30);
            this.tableLayoutPanel2.TabIndex = 61;
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbData.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbData.Location = new System.Drawing.Point(1, 1);
            this.lbData.Margin = new System.Windows.Forms.Padding(1);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(189, 24);
            this.lbData.TabIndex = 0;
            this.lbData.Tag = "Subset Data Filter";
            this.lbData.Text = "Subset Data Filter";
            // 
            // cbDataActivate
            // 
            this.cbDataActivate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbDataActivate.AutoSize = true;
            this.cbDataActivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDataActivate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDataActivate.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbDataActivate.Location = new System.Drawing.Point(379, 6);
            this.cbDataActivate.Margin = new System.Windows.Forms.Padding(0);
            this.cbDataActivate.Name = "cbDataActivate";
            this.cbDataActivate.Size = new System.Drawing.Size(128, 17);
            this.cbDataActivate.TabIndex = 62;
            this.cbDataActivate.Tag = "Activate Filter";
            this.cbDataActivate.Text = "Activate this filter";
            this.cbDataActivate.UseVisualStyleBackColor = true;
            this.cbDataActivate.CheckedChanged += new System.EventHandler(this.cbDataActivate_CheckedChanged);
            // 
            // fData
            // 
            this.fData.CBUse = this.cbDataActivate;
            this.fData.Enabled = false;
            this.fData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fData.IsUsed = false;
            this.fData.Location = new System.Drawing.Point(0, 30);
            this.fData.Name = "fData";
            this.fData.Size = new System.Drawing.Size(512, 442);
            this.fData.TabIndex = 63;
            // 
            // tpSort
            // 
            this.tpSort.AutoScroll = true;
            this.tpSort.Controls.Add(this.tableLayoutPanel1);
            this.tpSort.Controls.Add(this.fSort);
            //this.tpSort.InactiveBackColor = System.Drawing.Color.Empty;
            //this.tpSort.InactiveTextBackColor = System.Drawing.Color.Empty;
            //this.tpSort.InactiveTextColor = System.Drawing.Color.Empty;
            this.tpSort.Location = new System.Drawing.Point(0, 27);
            this.tpSort.Name = "tpSort";
            //this.tpSort.SelectBackColor = System.Drawing.Color.Empty;
            //this.tpSort.SelectTextBackColor = System.Drawing.Color.Empty;
            //this.tpSort.SelectTextColor = System.Drawing.Color.Empty;
            this.tpSort.Size = new System.Drawing.Size(516, 473);
            this.tpSort.TabIndex = 70;
            this.tpSort.Tag = "Filter Sort";
            this.tpSort.Title = "Sort";
            //this.tpSort.ToolTip = "Sort";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbSorting, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 30);
            this.tableLayoutPanel1.TabIndex = 71;
            // 
            // lbSorting
            // 
            this.lbSorting.AutoSize = true;
            this.lbSorting.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSorting.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbSorting.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbSorting.Location = new System.Drawing.Point(1, 1);
            this.lbSorting.Margin = new System.Windows.Forms.Padding(1);
            this.lbSorting.Name = "lbSorting";
            this.lbSorting.Size = new System.Drawing.Size(160, 24);
            this.lbSorting.TabIndex = 0;
            this.lbSorting.Tag = "Subset Sorting";
            this.lbSorting.Text = "Subset Sorting";
            // 
            // fSort
            // 
            this.fSort.CBUse = null;
            this.fSort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fSort.Location = new System.Drawing.Point(0, 30);
            this.fSort.Name = "fSort";
            this.fSort.Size = new System.Drawing.Size(512, 415);
            this.fSort.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Subset Sorting";
            this.label1.Text = "Subset Sorting";
            // 
            // ASubSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcFilters);
            this.Name = "ASubSet";
            this.Size = new System.Drawing.Size(516, 500);
            this.tcFilters.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tpHierarchy.ResumeLayout(false);
            this.tpHierarchy.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tpText.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tpPicklist.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tpAttribute.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tpData.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tpSort.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imlList;
        private JTabControl tcFilters;
        private JTabPage tpHierarchy;
        private FHierarchy fHierarchy;
        private JTabPage tpSort;
        private JTabPage tpPicklist;
        private Apalo.XlAddin.JSubSet.Filter.FSort fSort;
        private System.Windows.Forms.CheckBox cbHierarchyActivate;
        private System.Windows.Forms.Label lbHierarchy;
        private System.Windows.Forms.Label lbSorting;
        private System.Windows.Forms.Label lbPicklist;
        private System.Windows.Forms.CheckBox cbPicklistActivate;
        private Apalo.XlAddin.JSubSet.Filter.FPicklist fPicklist;
        private JTabPage tpData;
        private Apalo.XlAddin.JSubSet.Filter.FData fData;
        private System.Windows.Forms.CheckBox cbDataActivate;
        private System.Windows.Forms.Label lbData;
        private JTabPage tpAttribute;
        private System.Windows.Forms.CheckBox cbAttributeActivate;
        private System.Windows.Forms.Label lbAttribute;
        private Apalo.XlAddin.JSubSet.Filter.FAttribute fAttribute;
        private JTabPage tpGeneral;
        private System.Windows.Forms.Label lbGeneral;
        private Apalo.XlAddin.JSubSet.Filter.FGeneral fGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private JTabPage tpText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.CheckBox cbTextActivate;
        private Apalo.XlAddin.JSubSet.Filter.FText fText;
    }
}
