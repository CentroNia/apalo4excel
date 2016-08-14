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
    partial class FSort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSort));
            this.pElement = new Apalo.XlAddin.JSubSet.PElement();
            this.gbBehaviour = new System.Windows.Forms.GroupBox();
            this.rbAttribute = new System.Windows.Forms.RadioButton();
            this.prbCriteria = new Apalo.XlAddin.JSubSet.Primitives.PRadioPanel();
            this.rbDefinition = new System.Windows.Forms.RadioButton();
            this.rbValue = new System.Windows.Forms.RadioButton();
            this.rbElement = new System.Windows.Forms.RadioButton();
            this.rbAlias = new System.Windows.Forms.RadioButton();
            this.cbAttributeParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbCriteriaParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.paAttribute = new Apalo.XlAddin.JSubSet.PAlias();
            this.gbReverse = new System.Windows.Forms.GroupBox();
            this.piReverse = new Apalo.XlAddin.JSubSet.PInt();
            this.cbReverseParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbReverse = new System.Windows.Forms.CheckBox();
            this.gbLimitation = new System.Windows.Forms.GroupBox();
            this.cbLimitationParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.prbLimitation = new Apalo.XlAddin.JSubSet.Primitives.PRadioPanel();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbBase = new System.Windows.Forms.RadioButton();
            this.rbConsolidated = new System.Windows.Forms.RadioButton();
            this.gbLevel = new System.Windows.Forms.GroupBox();
            this.lbLevelType = new System.Windows.Forms.Label();
            this.cbSortLevelParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.piSortLevel = new Apalo.XlAddin.JSubSet.PInt();
            this.cbSortLevel = new System.Windows.Forms.CheckBox();
            this.nprbCriteria = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npaAttribute = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.nprbLimitation = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npiSortLevel = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.npiReverse = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.gbBehaviour.SuspendLayout();
            this.prbCriteria.SuspendLayout();
            this.gbReverse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piReverse)).BeginInit();
            this.gbLimitation.SuspendLayout();
            this.prbLimitation.SuspendLayout();
            this.gbLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piSortLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // pElement
            // 
            this.pElement.ImageList = null;
            this.pElement.Location = new System.Drawing.Point(0, 0);
            this.pElement.Name = "pElement";
            this.pElement.PName = "Untitled";
            this.pElement.PopupHeight = 97;
            this.pElement.Size = new System.Drawing.Size(121, 21);
            this.pElement.StateImageList = null;
            this.pElement.SValue = "";
            this.pElement.TabIndex = 0;
            // 
            // gbBehaviour
            // 
            this.gbBehaviour.Controls.Add(this.rbAttribute);
            this.gbBehaviour.Controls.Add(this.prbCriteria);
            this.gbBehaviour.Controls.Add(this.cbAttributeParam);
            this.gbBehaviour.Controls.Add(this.cbCriteriaParam);
            this.gbBehaviour.Controls.Add(this.paAttribute);
            this.gbBehaviour.Location = new System.Drawing.Point(6, 3);
            this.gbBehaviour.Name = "gbBehaviour";
            this.gbBehaviour.Size = new System.Drawing.Size(504, 140);
            this.gbBehaviour.TabIndex = 4;
            this.gbBehaviour.TabStop = false;
            this.gbBehaviour.Tag = "Sorting Behaviour";
            this.gbBehaviour.Text = "Sorting behaviour";
            // 
            // rbAttribute
            // 
            this.rbAttribute.AutoSize = true;
            this.rbAttribute.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAttribute.Location = new System.Drawing.Point(9, 114);
            this.rbAttribute.Name = "rbAttribute";
            this.rbAttribute.Size = new System.Drawing.Size(94, 17);
            this.rbAttribute.TabIndex = 1;
            this.rbAttribute.TabStop = true;
            this.rbAttribute.Tag = "By Attribute";
            this.rbAttribute.Text = "By Attribute";
            this.rbAttribute.UseVisualStyleBackColor = true;
            this.rbAttribute.CheckedChanged += new System.EventHandler(this.rbAttribute_CheckedChanged);
            // 
            // prbCriteria
            // 
            this.prbCriteria.Controls.Add(this.rbDefinition);
            this.prbCriteria.Controls.Add(this.rbValue);
            this.prbCriteria.Controls.Add(this.rbElement);
            this.prbCriteria.Controls.Add(this.rbAlias);
            this.prbCriteria.Inverse = false;
            this.prbCriteria.Location = new System.Drawing.Point(6, 16);
            this.prbCriteria.Name = "prbCriteria";
            this.prbCriteria.PName = "Criteria";
            this.prbCriteria.PRadioPanelType = Apalo.XlAddin.JSubSet.Primitives.PRadioPanelType.Int;
            this.prbCriteria.Size = new System.Drawing.Size(370, 89);
            this.prbCriteria.StartCount = 0;
            this.prbCriteria.SValue = "0";
            this.prbCriteria.TabIndex = 0;
            // 
            // rbDefinition
            // 
            this.rbDefinition.AutoSize = true;
            this.rbDefinition.Checked = true;
            this.rbDefinition.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDefinition.Location = new System.Drawing.Point(3, 3);
            this.rbDefinition.Name = "rbDefinition";
            this.rbDefinition.Size = new System.Drawing.Size(96, 17);
            this.rbDefinition.TabIndex = 0;
            this.rbDefinition.TabStop = true;
            this.rbDefinition.Tag = "By Definition";
            this.rbDefinition.Text = "By Definition";
            this.rbDefinition.UseVisualStyleBackColor = true;
            this.rbDefinition.Click += new System.EventHandler(this.rbDefinition_Click);
            // 
            // rbValue
            // 
            this.rbValue.AutoSize = true;
            this.rbValue.Enabled = false;
            this.rbValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbValue.Location = new System.Drawing.Point(3, 72);
            this.rbValue.Name = "rbValue";
            this.rbValue.Size = new System.Drawing.Size(73, 17);
            this.rbValue.TabIndex = 3;
            this.rbValue.Tag = "By Value";
            this.rbValue.Text = "By Value";
            this.rbValue.UseVisualStyleBackColor = true;
            this.rbValue.Click += new System.EventHandler(this.rbDefinition_Click);
            // 
            // rbElement
            // 
            this.rbElement.AutoSize = true;
            this.rbElement.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbElement.Location = new System.Drawing.Point(3, 26);
            this.rbElement.Name = "rbElement";
            this.rbElement.Size = new System.Drawing.Size(123, 17);
            this.rbElement.TabIndex = 1;
            this.rbElement.Tag = "By Element Name";
            this.rbElement.Text = "By Element name";
            this.rbElement.UseVisualStyleBackColor = true;
            this.rbElement.Click += new System.EventHandler(this.rbDefinition_Click);
            // 
            // rbAlias
            // 
            this.rbAlias.AutoSize = true;
            this.rbAlias.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAlias.Location = new System.Drawing.Point(3, 49);
            this.rbAlias.Name = "rbAlias";
            this.rbAlias.Size = new System.Drawing.Size(69, 17);
            this.rbAlias.TabIndex = 2;
            this.rbAlias.Tag = "By Alias";
            this.rbAlias.Text = "By Alias";
            this.rbAlias.UseVisualStyleBackColor = true;
            this.rbAlias.Click += new System.EventHandler(this.rbDefinition_Click);
            // 
            // cbAttributeParam
            // 
            this.cbAttributeParam.AutoSize = true;
            this.cbAttributeParam.Enabled = false;
            this.cbAttributeParam.Location = new System.Drawing.Point(404, 115);
            this.cbAttributeParam.Name = "cbAttributeParam";
            this.cbAttributeParam.Size = new System.Drawing.Size(76, 17);
            this.cbAttributeParam.TabIndex = 5;
            this.cbAttributeParam.Text = "Parameter";
            this.cbAttributeParam.UseVisualStyleBackColor = true;
            // 
            // cbCriteriaParam
            // 
            this.cbCriteriaParam.AutoSize = true;
            this.cbCriteriaParam.Location = new System.Drawing.Point(404, 57);
            this.cbCriteriaParam.Name = "cbCriteriaParam";
            this.cbCriteriaParam.Size = new System.Drawing.Size(76, 17);
            this.cbCriteriaParam.TabIndex = 4;
            this.cbCriteriaParam.Text = "Parameter";
            this.cbCriteriaParam.UseVisualStyleBackColor = true;
            // 
            // paAttribute
            // 
            this.paAttribute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.paAttribute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.paAttribute.DataSource = ((object)(resources.GetObject("paAttribute.DataSource")));
            this.paAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paAttribute.Enabled = false;
            this.paAttribute.FormattingEnabled = true;
            this.paAttribute.Location = new System.Drawing.Point(171, 110);
            this.paAttribute.Name = "paAttribute";
            this.paAttribute.PName = "Sort Attribute";
            this.paAttribute.Size = new System.Drawing.Size(140, 21);
            this.paAttribute.SValue = "";
            this.paAttribute.TabIndex = 2;
            // 
            // gbReverse
            // 
            this.gbReverse.Controls.Add(this.piReverse);
            this.gbReverse.Controls.Add(this.cbReverseParam);
            this.gbReverse.Controls.Add(this.cbReverse);
            this.gbReverse.Location = new System.Drawing.Point(6, 144);
            this.gbReverse.Name = "gbReverse";
            this.gbReverse.Size = new System.Drawing.Size(504, 48);
            this.gbReverse.TabIndex = 5;
            this.gbReverse.TabStop = false;
            this.gbReverse.Tag = "Reverse Order";
            this.gbReverse.Text = "Reverse Order";
            // 
            // piReverse
            // 
            this.piReverse.Location = new System.Drawing.Point(171, 15);
            this.piReverse.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.piReverse.Name = "piReverse";
            this.piReverse.PName = "Reverse";
            this.piReverse.Size = new System.Drawing.Size(140, 21);
            this.piReverse.SValue = "0";
            this.piReverse.TabIndex = 3;
            this.piReverse.Visible = false;
            this.piReverse.ValueChanged += new System.EventHandler(this.piReverse_ValueChanged);
            // 
            // cbReverseParam
            // 
            this.cbReverseParam.AutoSize = true;
            this.cbReverseParam.Location = new System.Drawing.Point(404, 19);
            this.cbReverseParam.Name = "cbReverseParam";
            this.cbReverseParam.Size = new System.Drawing.Size(76, 17);
            this.cbReverseParam.TabIndex = 2;
            this.cbReverseParam.Text = "Parameter";
            this.cbReverseParam.UseVisualStyleBackColor = true;
            this.cbReverseParam.CheckedChanged += new System.EventHandler(this.cbReverseParam_CheckedChanged);
            // 
            // cbReverse
            // 
            this.cbReverse.AutoSize = true;
            this.cbReverse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReverse.Location = new System.Drawing.Point(9, 19);
            this.cbReverse.Name = "cbReverse";
            this.cbReverse.Size = new System.Drawing.Size(73, 17);
            this.cbReverse.TabIndex = 0;
            this.cbReverse.Tag = "Reverse";
            this.cbReverse.Text = "Reverse";
            this.cbReverse.UseVisualStyleBackColor = true;
            this.cbReverse.CheckedChanged += new System.EventHandler(this.cbReverse_CheckedChanged);
            // 
            // gbLimitation
            // 
            this.gbLimitation.Controls.Add(this.cbLimitationParam);
            this.gbLimitation.Controls.Add(this.prbLimitation);
            this.gbLimitation.Location = new System.Drawing.Point(6, 193);
            this.gbLimitation.Name = "gbLimitation";
            this.gbLimitation.Size = new System.Drawing.Size(504, 100);
            this.gbLimitation.TabIndex = 6;
            this.gbLimitation.TabStop = false;
            this.gbLimitation.Tag = "Type Limitation";
            this.gbLimitation.Text = "Type Limitation";
            // 
            // cbLimitationParam
            // 
            this.cbLimitationParam.AutoSize = true;
            this.cbLimitationParam.Location = new System.Drawing.Point(404, 46);
            this.cbLimitationParam.Name = "cbLimitationParam";
            this.cbLimitationParam.Size = new System.Drawing.Size(76, 17);
            this.cbLimitationParam.TabIndex = 3;
            this.cbLimitationParam.Text = "Parameter";
            this.cbLimitationParam.UseVisualStyleBackColor = true;
            // 
            // prbLimitation
            // 
            this.prbLimitation.Controls.Add(this.rbAll);
            this.prbLimitation.Controls.Add(this.rbBase);
            this.prbLimitation.Controls.Add(this.rbConsolidated);
            this.prbLimitation.Inverse = false;
            this.prbLimitation.Location = new System.Drawing.Point(11, 19);
            this.prbLimitation.Name = "prbLimitation";
            this.prbLimitation.PName = "Type Limitation";
            this.prbLimitation.PRadioPanelType = Apalo.XlAddin.JSubSet.Primitives.PRadioPanelType.Int;
            this.prbLimitation.Size = new System.Drawing.Size(390, 75);
            this.prbLimitation.StartCount = 0;
            this.prbLimitation.SValue = "0";
            this.prbLimitation.TabIndex = 0;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAll.Location = new System.Drawing.Point(3, 3);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(94, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Tag = "All Elements";
            this.rbAll.Text = "All Elements";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbBase
            // 
            this.rbBase.AutoSize = true;
            this.rbBase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBase.Location = new System.Drawing.Point(3, 26);
            this.rbBase.Name = "rbBase";
            this.rbBase.Size = new System.Drawing.Size(135, 17);
            this.rbBase.TabIndex = 1;
            this.rbBase.Tag = "Base Elements";
            this.rbBase.Text = "Base Elements Only";
            this.rbBase.UseVisualStyleBackColor = true;
            // 
            // rbConsolidated
            // 
            this.rbConsolidated.AutoSize = true;
            this.rbConsolidated.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConsolidated.Location = new System.Drawing.Point(3, 49);
            this.rbConsolidated.Name = "rbConsolidated";
            this.rbConsolidated.Size = new System.Drawing.Size(181, 17);
            this.rbConsolidated.TabIndex = 2;
            this.rbConsolidated.Tag = "Consolidated Elements";
            this.rbConsolidated.Text = "Consolidated Elements Only";
            this.rbConsolidated.UseVisualStyleBackColor = true;
            // 
            // gbLevel
            // 
            this.gbLevel.Controls.Add(this.lbLevelType);
            this.gbLevel.Controls.Add(this.cbSortLevelParam);
            this.gbLevel.Controls.Add(this.piSortLevel);
            this.gbLevel.Controls.Add(this.cbSortLevel);
            this.gbLevel.Location = new System.Drawing.Point(6, 294);
            this.gbLevel.Name = "gbLevel";
            this.gbLevel.Size = new System.Drawing.Size(504, 48);
            this.gbLevel.TabIndex = 7;
            this.gbLevel.TabStop = false;
            this.gbLevel.Tag = "Sort Level";
            this.gbLevel.Text = "Sort Level";
            // 
            // lbLevelType
            // 
            this.lbLevelType.AutoSize = true;
            this.lbLevelType.Enabled = false;
            this.lbLevelType.Location = new System.Drawing.Point(222, 19);
            this.lbLevelType.Name = "lbLevelType";
            this.lbLevelType.Size = new System.Drawing.Size(102, 13);
            this.lbLevelType.TabIndex = 5;
            this.lbLevelType.Tag = "LB Hierarchy Indent";
            this.lbLevelType.Text = "LB Hierarchy Indent";
            // 
            // cbSortLevelParam
            // 
            this.cbSortLevelParam.AutoSize = true;
            this.cbSortLevelParam.Enabled = false;
            this.cbSortLevelParam.Location = new System.Drawing.Point(404, 19);
            this.cbSortLevelParam.Name = "cbSortLevelParam";
            this.cbSortLevelParam.Size = new System.Drawing.Size(76, 17);
            this.cbSortLevelParam.TabIndex = 4;
            this.cbSortLevelParam.Text = "Parameter";
            this.cbSortLevelParam.UseVisualStyleBackColor = true;
            // 
            // piSortLevel
            // 
            this.piSortLevel.Enabled = false;
            this.piSortLevel.Location = new System.Drawing.Point(171, 15);
            this.piSortLevel.Name = "piSortLevel";
            this.piSortLevel.PName = "Sort Level";
            this.piSortLevel.Size = new System.Drawing.Size(32, 21);
            this.piSortLevel.SValue = "0";
            this.piSortLevel.TabIndex = 1;
            // 
            // cbSortLevel
            // 
            this.cbSortLevel.AutoSize = true;
            this.cbSortLevel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSortLevel.Location = new System.Drawing.Point(9, 19);
            this.cbSortLevel.Name = "cbSortLevel";
            this.cbSortLevel.Size = new System.Drawing.Size(98, 17);
            this.cbSortLevel.TabIndex = 0;
            this.cbSortLevel.Tag = "Sort Level";
            this.cbSortLevel.Text = "Sort at Level";
            this.cbSortLevel.UseVisualStyleBackColor = true;
            this.cbSortLevel.CheckedChanged += new System.EventHandler(this.cbSortLevel_CheckedChanged);
            // 
            // nprbCriteria
            // 
            this.nprbCriteria.CBParameter = this.cbCriteriaParam;
            this.nprbCriteria.IPrimitive = this.prbCriteria;
            this.nprbCriteria.SValue = "0";
            // 
            // npaAttribute
            // 
            this.npaAttribute.CBParameter = this.cbAttributeParam;
            this.npaAttribute.IPrimitive = this.paAttribute;
            this.npaAttribute.SValue = "";
            // 
            // nprbLimitation
            // 
            this.nprbLimitation.CBParameter = this.cbLimitationParam;
            this.nprbLimitation.IPrimitive = this.prbLimitation;
            this.nprbLimitation.SValue = "0";
            // 
            // npiSortLevel
            // 
            this.npiSortLevel.CBParameter = this.cbSortLevelParam;
            this.npiSortLevel.IPrimitive = this.piSortLevel;
            this.npiSortLevel.SValue = "0";
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
            // npiReverse
            // 
            this.npiReverse.CBParameter = this.cbReverseParam;
            this.npiReverse.IPrimitive = this.piReverse;
            this.npiReverse.SValue = "0";
            // 
            // FSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLevel);
            this.Controls.Add(this.gbLimitation);
            this.Controls.Add(this.gbReverse);
            this.Controls.Add(this.gbBehaviour);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FSort";
            this.Size = new System.Drawing.Size(514, 347);
            this.gbBehaviour.ResumeLayout(false);
            this.gbBehaviour.PerformLayout();
            this.prbCriteria.ResumeLayout(false);
            this.prbCriteria.PerformLayout();
            this.gbReverse.ResumeLayout(false);
            this.gbReverse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piReverse)).EndInit();
            this.gbLimitation.ResumeLayout(false);
            this.gbLimitation.PerformLayout();
            this.prbLimitation.ResumeLayout(false);
            this.prbLimitation.PerformLayout();
            this.gbLevel.ResumeLayout(false);
            this.gbLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piSortLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PElement pElement;
        private System.Windows.Forms.GroupBox gbBehaviour;
        private PRadioPanel prbCriteria;
        private System.Windows.Forms.RadioButton rbValue;
        private System.Windows.Forms.RadioButton rbAlias;
        private System.Windows.Forms.RadioButton rbElement;
        private System.Windows.Forms.RadioButton rbDefinition;
        private CBParameter cbAttributeParam;
        private CBParameter cbCriteriaParam;
        private PAlias paAttribute;
        private System.Windows.Forms.RadioButton rbAttribute;
        private System.Windows.Forms.GroupBox gbReverse;
        private System.Windows.Forms.GroupBox gbLimitation;
        private CBParameter cbLimitationParam;
        private PRadioPanel prbLimitation;
        private System.Windows.Forms.RadioButton rbConsolidated;
        private System.Windows.Forms.RadioButton rbBase;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.GroupBox gbLevel;
        private CBParameter cbSortLevelParam;
        private PInt piSortLevel;
        public System.Windows.Forms.CheckBox cbSortLevel;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive nprbCriteria;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npaAttribute;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive nprbLimitation;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npiSortLevel;
        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.Label lbLevelType;
        public System.Windows.Forms.CheckBox cbReverse;
        public CBParameter cbReverseParam;
        public Apalo.XlAddin.JSubSet.Controls.NPrimitive npiReverse;
        public PInt piReverse;

    }
}
