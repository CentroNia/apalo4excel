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
namespace Apalo.XlAddin.JSubSet.Filter
{
    partial class FGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGeneral));
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.pPanel = new System.Windows.Forms.Panel();
            this.cbDimension = new System.Windows.Forms.ComboBox();
            this.lbDimension = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.gbLayout = new System.Windows.Forms.GroupBox();
            this.cbReverseOrder = new System.Windows.Forms.CheckBox();
            this.rbHierarchy = new System.Windows.Forms.RadioButton();
            this.rbFlat = new System.Windows.Forms.RadioButton();
            this.cbShowDups = new System.Windows.Forms.CheckBox();
            this.cbShowHidden = new System.Windows.Forms.CheckBox();
            this.gbHierarchy = new System.Windows.Forms.GroupBox();
            this.cbHierarchyParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.prbHierarchy = new Apalo.XlAddin.JSubSet.Primitives.PRadioPanel();
            this.rbIndent = new System.Windows.Forms.RadioButton();
            this.rbLevel = new System.Windows.Forms.RadioButton();
            this.rbDepth = new System.Windows.Forms.RadioButton();
            this.gbAlias = new System.Windows.Forms.GroupBox();
            this.pcbAlias2 = new Apalo.XlAddin.JSubSet.PAlias();
            this.pcbAlias1 = new Apalo.XlAddin.JSubSet.PAlias();
            this.cbAlias2Param = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbAlias1Param = new Apalo.XlAddin.JSubSet.CBParameter();
            this.lbAlias2 = new System.Windows.Forms.Label();
            this.lbAlias1 = new System.Windows.Forms.Label();
            this.pElement1 = new Apalo.XlAddin.JSubSet.PElement();
            this.pElement2 = new Apalo.XlAddin.JSubSet.PElement();
            this.imgListServerIcons = new System.Windows.Forms.ImageList(this.components);
            this.npcbAlias1 = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npcbAlias2 = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.nprbHierarchy = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.gbConnection.SuspendLayout();
            this.gbLayout.SuspendLayout();
            this.gbHierarchy.SuspendLayout();
            this.prbHierarchy.SuspendLayout();
            this.gbAlias.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.pPanel);
            this.gbConnection.Controls.Add(this.cbDimension);
            this.gbConnection.Controls.Add(this.lbDimension);
            this.gbConnection.Controls.Add(this.lbServer);
            this.gbConnection.Location = new System.Drawing.Point(6, 3);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(230, 102);
            this.gbConnection.TabIndex = 10;
            this.gbConnection.TabStop = false;
            this.gbConnection.Tag = "Server";
            this.gbConnection.Text = "Server";
            // 
            // pPanel
            // 
            this.pPanel.Location = new System.Drawing.Point(9, 34);
            this.pPanel.Name = "pPanel";
            this.pPanel.Size = new System.Drawing.Size(215, 21);
            this.pPanel.TabIndex = 11;
            // 
            // cbDimension
            // 
            this.cbDimension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDimension.FormattingEnabled = true;
            this.cbDimension.Location = new System.Drawing.Point(9, 74);
            this.cbDimension.Name = "cbDimension";
            this.cbDimension.Size = new System.Drawing.Size(215, 21);
            this.cbDimension.TabIndex = 12;
            this.cbDimension.Tag = "Dimension";
            // 
            // lbDimension
            // 
            this.lbDimension.AutoSize = true;
            this.lbDimension.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDimension.Location = new System.Drawing.Point(6, 60);
            this.lbDimension.Name = "lbDimension";
            this.lbDimension.Size = new System.Drawing.Size(66, 13);
            this.lbDimension.TabIndex = 0;
            this.lbDimension.Tag = "Dimension";
            this.lbDimension.Text = "Dimension";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServer.Location = new System.Drawing.Point(6, 16);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(166, 13);
            this.lbServer.TabIndex = 0;
            this.lbServer.Tag = "Server Selection";
            this.lbServer.Text = "Server / Database Selection";
            // 
            // gbLayout
            // 
            this.gbLayout.Controls.Add(this.cbReverseOrder);
            this.gbLayout.Controls.Add(this.rbHierarchy);
            this.gbLayout.Controls.Add(this.rbFlat);
            this.gbLayout.Location = new System.Drawing.Point(6, 106);
            this.gbLayout.Name = "gbLayout";
            this.gbLayout.Size = new System.Drawing.Size(230, 82);
            this.gbLayout.TabIndex = 20;
            this.gbLayout.TabStop = false;
            this.gbLayout.Tag = "Layout";
            this.gbLayout.Text = "Layout";
            // 
            // cbReverseOrder
            // 
            this.cbReverseOrder.AutoSize = true;
            this.cbReverseOrder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReverseOrder.Location = new System.Drawing.Point(10, 58);
            this.cbReverseOrder.Name = "cbReverseOrder";
            this.cbReverseOrder.Size = new System.Drawing.Size(108, 17);
            this.cbReverseOrder.TabIndex = 23;
            this.cbReverseOrder.Tag = "Reverse Hierarchy";
            this.cbReverseOrder.Text = "Reverse Order";
            this.cbReverseOrder.UseVisualStyleBackColor = true;
            this.cbReverseOrder.CheckedChanged += new System.EventHandler(this.cbReverseOrder_CheckedChanged);
            // 
            // rbHierarchy
            // 
            this.rbHierarchy.AutoSize = true;
            this.rbHierarchy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHierarchy.Location = new System.Drawing.Point(10, 37);
            this.rbHierarchy.Name = "rbHierarchy";
            this.rbHierarchy.Size = new System.Drawing.Size(80, 17);
            this.rbHierarchy.TabIndex = 22;
            this.rbHierarchy.Tag = "Hierarchy";
            this.rbHierarchy.Text = "Hierarchy";
            this.rbHierarchy.UseVisualStyleBackColor = true;
            this.rbHierarchy.CheckedChanged += new System.EventHandler(this.rbHierarchy_CheckedChanged);
            // 
            // rbFlat
            // 
            this.rbFlat.AutoSize = true;
            this.rbFlat.Checked = true;
            this.rbFlat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFlat.Location = new System.Drawing.Point(10, 16);
            this.rbFlat.Name = "rbFlat";
            this.rbFlat.Size = new System.Drawing.Size(46, 17);
            this.rbFlat.TabIndex = 21;
            this.rbFlat.TabStop = true;
            this.rbFlat.Tag = "Flat";
            this.rbFlat.Text = "Flat";
            this.rbFlat.UseVisualStyleBackColor = true;
            this.rbFlat.CheckedChanged += new System.EventHandler(this.rbFlat_CheckedChanged);
            // 
            // cbShowDups
            // 
            this.cbShowDups.AutoSize = true;
            this.cbShowDups.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowDups.Location = new System.Drawing.Point(10, 43);
            this.cbShowDups.Name = "cbShowDups";
            this.cbShowDups.Size = new System.Drawing.Size(117, 17);
            this.cbShowDups.TabIndex = 32;
            this.cbShowDups.Tag = "Show Duplicates";
            this.cbShowDups.Text = "Show duplicates";
            this.cbShowDups.UseVisualStyleBackColor = true;
            // 
            // cbShowHidden
            // 
            this.cbShowHidden.Enabled = false;
            this.cbShowHidden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowHidden.Location = new System.Drawing.Point(10, 20);
            this.cbShowHidden.Name = "cbShowHidden";
            this.cbShowHidden.Size = new System.Drawing.Size(216, 17);
            this.cbShowHidden.TabIndex = 31;
            this.cbShowHidden.Tag = "Show Hidden Children";
            this.cbShowHidden.Text = "Show children of hidden elements";
            this.cbShowHidden.UseVisualStyleBackColor = true;
            // 
            // gbHierarchy
            // 
            this.gbHierarchy.Controls.Add(this.cbHierarchyParam);
            this.gbHierarchy.Controls.Add(this.prbHierarchy);
            this.gbHierarchy.Location = new System.Drawing.Point(242, 106);
            this.gbHierarchy.Name = "gbHierarchy";
            this.gbHierarchy.Size = new System.Drawing.Size(268, 151);
            this.gbHierarchy.TabIndex = 50;
            this.gbHierarchy.TabStop = false;
            this.gbHierarchy.Tag = "Hierarchy enumeration";
            this.gbHierarchy.Text = "Hierarchy enumeration";
            // 
            // cbHierarchyParam
            // 
            this.cbHierarchyParam.AutoSize = true;
            this.cbHierarchyParam.Location = new System.Drawing.Point(191, 16);
            this.cbHierarchyParam.Name = "cbHierarchyParam";
            this.cbHierarchyParam.Size = new System.Drawing.Size(106, 17);
            this.cbHierarchyParam.TabIndex = 55;
            this.cbHierarchyParam.Text = "@@@Parameter";
            this.cbHierarchyParam.UseVisualStyleBackColor = true;
            this.cbHierarchyParam.Visible = false;
            // 
            // prbHierarchy
            // 
            this.prbHierarchy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.prbHierarchy.Controls.Add(this.rbIndent);
            this.prbHierarchy.Controls.Add(this.rbLevel);
            this.prbHierarchy.Controls.Add(this.rbDepth);
            this.prbHierarchy.Inverse = false;
            this.prbHierarchy.Location = new System.Drawing.Point(4, 12);
            this.prbHierarchy.Name = "prbHierarchy";
            this.prbHierarchy.PName = "Indent";
            this.prbHierarchy.PRadioPanelType = Apalo.XlAddin.JSubSet.Primitives.PRadioPanelType.Int;
            this.prbHierarchy.Size = new System.Drawing.Size(155, 70);
            this.prbHierarchy.StartCount = 1;
            this.prbHierarchy.SValue = "1";
            this.prbHierarchy.TabIndex = 51;
            // 
            // rbIndent
            // 
            this.rbIndent.AutoSize = true;
            this.rbIndent.Checked = true;
            this.rbIndent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIndent.Location = new System.Drawing.Point(6, 3);
            this.rbIndent.Name = "rbIndent";
            this.rbIndent.Size = new System.Drawing.Size(63, 17);
            this.rbIndent.TabIndex = 52;
            this.rbIndent.TabStop = true;
            this.rbIndent.Tag = "Indent";
            this.rbIndent.Text = "Indent";
            this.rbIndent.UseVisualStyleBackColor = true;
            this.rbIndent.CheckedChanged += new System.EventHandler(this.rbIndent_CheckedChanged);
            // 
            // rbLevel
            // 
            this.rbLevel.AutoSize = true;
            this.rbLevel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLevel.Location = new System.Drawing.Point(6, 26);
            this.rbLevel.Name = "rbLevel";
            this.rbLevel.Size = new System.Drawing.Size(55, 17);
            this.rbLevel.TabIndex = 53;
            this.rbLevel.Tag = "Level";
            this.rbLevel.Text = "Level";
            this.rbLevel.UseVisualStyleBackColor = true;
            this.rbLevel.CheckedChanged += new System.EventHandler(this.rbLevel_CheckedChanged);
            // 
            // rbDepth
            // 
            this.rbDepth.AutoSize = true;
            this.rbDepth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDepth.Location = new System.Drawing.Point(6, 49);
            this.rbDepth.Name = "rbDepth";
            this.rbDepth.Size = new System.Drawing.Size(59, 17);
            this.rbDepth.TabIndex = 54;
            this.rbDepth.Tag = "Depth";
            this.rbDepth.Text = "Depth";
            this.rbDepth.UseVisualStyleBackColor = true;
            this.rbDepth.CheckedChanged += new System.EventHandler(this.rbDepth_CheckedChanged);
            // 
            // gbAlias
            // 
            this.gbAlias.Controls.Add(this.pcbAlias2);
            this.gbAlias.Controls.Add(this.pcbAlias1);
            this.gbAlias.Controls.Add(this.cbAlias2Param);
            this.gbAlias.Controls.Add(this.cbAlias1Param);
            this.gbAlias.Controls.Add(this.lbAlias2);
            this.gbAlias.Controls.Add(this.lbAlias1);
            this.gbAlias.Location = new System.Drawing.Point(242, 3);
            this.gbAlias.Name = "gbAlias";
            this.gbAlias.Size = new System.Drawing.Size(268, 102);
            this.gbAlias.TabIndex = 40;
            this.gbAlias.TabStop = false;
            this.gbAlias.Tag = "Alias";
            this.gbAlias.Text = "Alias";
            // 
            // pcbAlias2
            // 
            this.pcbAlias2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.pcbAlias2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pcbAlias2.DataSource = ((object)(resources.GetObject("pcbAlias2.DataSource")));
            this.pcbAlias2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pcbAlias2.FormattingEnabled = true;
            this.pcbAlias2.Location = new System.Drawing.Point(9, 74);
            this.pcbAlias2.Name = "pcbAlias2";
            this.pcbAlias2.PName = "Alias 2";
            this.pcbAlias2.Size = new System.Drawing.Size(176, 21);
            this.pcbAlias2.SValue = "";
            this.pcbAlias2.TabIndex = 43;
            this.pcbAlias2.Tag = "Alias2";
            this.pcbAlias2.SelectedIndexChanged += new System.EventHandler(this.cbAlias2_SelectedIndexChanged);
            // 
            // pcbAlias1
            // 
            this.pcbAlias1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.pcbAlias1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pcbAlias1.DataSource = ((object)(resources.GetObject("pcbAlias1.DataSource")));
            this.pcbAlias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pcbAlias1.FormattingEnabled = true;
            this.pcbAlias1.Location = new System.Drawing.Point(9, 33);
            this.pcbAlias1.Name = "pcbAlias1";
            this.pcbAlias1.PName = "Alias 1";
            this.pcbAlias1.Size = new System.Drawing.Size(176, 21);
            this.pcbAlias1.SValue = "";
            this.pcbAlias1.TabIndex = 41;
            this.pcbAlias1.Tag = "Alias1";
            this.pcbAlias1.SelectedIndexChanged += new System.EventHandler(this.cbAlias1_SelectedIndexChanged);
            // 
            // cbAlias2Param
            // 
            this.cbAlias2Param.AutoSize = true;
            this.cbAlias2Param.Location = new System.Drawing.Point(191, 74);
            this.cbAlias2Param.Name = "cbAlias2Param";
            this.cbAlias2Param.Size = new System.Drawing.Size(106, 17);
            this.cbAlias2Param.TabIndex = 44;
            this.cbAlias2Param.Text = "@@@Parameter";
            this.cbAlias2Param.UseVisualStyleBackColor = true;
            // 
            // cbAlias1Param
            // 
            this.cbAlias1Param.AutoSize = true;
            this.cbAlias1Param.Location = new System.Drawing.Point(191, 33);
            this.cbAlias1Param.Name = "cbAlias1Param";
            this.cbAlias1Param.Size = new System.Drawing.Size(106, 17);
            this.cbAlias1Param.TabIndex = 42;
            this.cbAlias1Param.Text = "@@@Parameter";
            this.cbAlias1Param.UseVisualStyleBackColor = true;
            // 
            // lbAlias2
            // 
            this.lbAlias2.AutoSize = true;
            this.lbAlias2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlias2.Location = new System.Drawing.Point(6, 60);
            this.lbAlias2.Name = "lbAlias2";
            this.lbAlias2.Size = new System.Drawing.Size(116, 13);
            this.lbAlias2.TabIndex = 0;
            this.lbAlias2.Tag = "Select Second Alias";
            this.lbAlias2.Text = "Select Second Alias";
            // 
            // lbAlias1
            // 
            this.lbAlias1.AutoSize = true;
            this.lbAlias1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlias1.Location = new System.Drawing.Point(6, 16);
            this.lbAlias1.Name = "lbAlias1";
            this.lbAlias1.Size = new System.Drawing.Size(100, 13);
            this.lbAlias1.TabIndex = 0;
            this.lbAlias1.Tag = "Select First Alias";
            this.lbAlias1.Text = "Select First Alias";
            // 
            // pElement1
            // 
            this.pElement1.ImageList = null;
            this.pElement1.Location = new System.Drawing.Point(0, 0);
            this.pElement1.Name = "pElement1";
            this.pElement1.PName = "Untitled";
            this.pElement1.PopupHeight = 97;
            this.pElement1.Size = new System.Drawing.Size(121, 21);
            this.pElement1.StateImageList = null;
            this.pElement1.SValue = "";
            this.pElement1.TabIndex = 0;
            // 
            // pElement2
            // 
            this.pElement2.ImageList = null;
            this.pElement2.Location = new System.Drawing.Point(0, 0);
            this.pElement2.Name = "pElement2";
            this.pElement2.PName = "Untitled";
            this.pElement2.PopupHeight = 97;
            this.pElement2.Size = new System.Drawing.Size(121, 21);
            this.pElement2.StateImageList = null;
            this.pElement2.SValue = "";
            this.pElement2.TabIndex = 0;
            // 
            // imgListServerIcons
            // 
            this.imgListServerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListServerIcons.ImageStream")));
            this.imgListServerIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListServerIcons.Images.SetKeyName(0, "disconnect16.png");
            this.imgListServerIcons.Images.SetKeyName(1, "connect16.png");
            this.imgListServerIcons.Images.SetKeyName(2, "3.ico");
            this.imgListServerIcons.Images.SetKeyName(3, "database16.png");
            // 
            // npcbAlias1
            // 
            this.npcbAlias1.CBParameter = this.cbAlias1Param;
            this.npcbAlias1.IPrimitive = this.pcbAlias1;
            this.npcbAlias1.SValue = "";
            // 
            // npcbAlias2
            // 
            this.npcbAlias2.CBParameter = this.cbAlias2Param;
            this.npcbAlias2.IPrimitive = this.pcbAlias2;
            this.npcbAlias2.SValue = "";
            // 
            // nprbHierarchy
            // 
            this.nprbHierarchy.CBParameter = this.cbHierarchyParam;
            this.nprbHierarchy.IPrimitive = this.prbHierarchy;
            this.nprbHierarchy.SValue = "1";
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
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.cbShowHidden);
            this.gbOptions.Controls.Add(this.cbShowDups);
            this.gbOptions.Location = new System.Drawing.Point(6, 189);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(230, 68);
            this.gbOptions.TabIndex = 30;
            this.gbOptions.TabStop = false;
            this.gbOptions.Tag = "OPTIONAL_SETTINGS";
            this.gbOptions.Text = "Options";
            // 
            // FGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.gbAlias);
            this.Controls.Add(this.gbHierarchy);
            this.Controls.Add(this.gbLayout);
            this.Controls.Add(this.gbConnection);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FGeneral";
            this.Size = new System.Drawing.Size(515, 262);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbLayout.ResumeLayout(false);
            this.gbLayout.PerformLayout();
            this.gbHierarchy.ResumeLayout(false);
            this.gbHierarchy.PerformLayout();
            this.prbHierarchy.ResumeLayout(false);
            this.prbHierarchy.PerformLayout();
            this.gbAlias.ResumeLayout(false);
            this.gbAlias.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.ComboBox cbDimension;
        private System.Windows.Forms.Label lbDimension;
        private System.Windows.Forms.GroupBox gbLayout;
        private System.Windows.Forms.GroupBox gbHierarchy;
        private PRadioPanel prbHierarchy;
        private System.Windows.Forms.RadioButton rbDepth;
        private System.Windows.Forms.RadioButton rbLevel;
        private System.Windows.Forms.RadioButton rbIndent;
        private System.Windows.Forms.GroupBox gbAlias;
        private System.Windows.Forms.Label lbAlias1;
        private System.Windows.Forms.Label lbAlias2;
        private CBParameter cbAlias2Param;
        private CBParameter cbAlias1Param;
        private PElement pElement1;
        private PElement pElement2;
        PAlias pcbAlias2;
        PAlias pcbAlias1;
        private System.Windows.Forms.Panel pPanel;
        private System.Windows.Forms.ImageList imgListServerIcons;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npcbAlias1;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npcbAlias2;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive nprbHierarchy;
        public System.Windows.Forms.CheckBox cbShowDups;
        public System.Windows.Forms.CheckBox cbShowHidden;
        public System.Windows.Forms.RadioButton rbHierarchy;
        public System.Windows.Forms.RadioButton rbFlat;
        private CBParameter cbHierarchyParam;
        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.GroupBox gbOptions;
        public System.Windows.Forms.CheckBox cbReverseOrder;
    }
}
