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

using Apalo.XlAddin.Utils;

 namespace Apalo.XlAddin.JSubSet.Filter
{
    partial class FData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FData));
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.pcCellOperator = new Apalo.XlAddin.JSubSet.Primitives.PCombo();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pDataPicker = new Apalo.XlAddin.JSubSet.Primitives.PDataPicker();
            this.pCube = new Apalo.XlAddin.JSubSet.PCube();
            this.cbOperatorParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.lbOperatorMode = new System.Windows.Forms.Label();
            this.cbCubeParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.lbSelectCube = new System.Windows.Forms.Label();
            this.piUpper = new Apalo.XlAddin.JSubSet.PInt();
            this.gbOperators = new System.Windows.Forms.GroupBox();
            this.cbPar2Param = new Apalo.XlAddin.JSubSet.CBParameter();
            this.pOperator = new Apalo.XlAddin.JSubSet.POpPar();
            this.cbPar1Param = new Apalo.XlAddin.JSubSet.CBParameter();
            this.gbOptional = new System.Windows.Forms.GroupBox();
            this.cbLowerNamedParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbUpperNamedParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbTopmostNamedParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.piLower = new Apalo.XlAddin.JSubSet.PInt();
            this.piTopmost = new Apalo.XlAddin.JSubSet.PInt();
            this.cbLowerElements = new System.Windows.Forms.CheckBox();
            this.cbUpperElements = new System.Windows.Forms.CheckBox();
            this.cbTopmost = new System.Windows.Forms.CheckBox();
            this.npCube = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npcCellOperator = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npiTopmost = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npiUpperElements = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npiLowerElements = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbSettings.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piUpper)).BeginInit();
            this.gbOperators.SuspendLayout();
            this.gbOptional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piLower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piTopmost)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.pcCellOperator);
            this.gbSettings.Controls.Add(this.tlpContainer);
            this.gbSettings.Controls.Add(this.pCube);
            this.gbSettings.Controls.Add(this.cbOperatorParam);
            this.gbSettings.Controls.Add(this.lbOperatorMode);
            this.gbSettings.Controls.Add(this.cbCubeParam);
            this.gbSettings.Controls.Add(this.lbSelectCube);
            this.gbSettings.Location = new System.Drawing.Point(6, 3);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(504, 240);
            this.gbSettings.TabIndex = 10;
            this.gbSettings.TabStop = false;
            this.gbSettings.Tag = "Settings";
            this.gbSettings.Text = "Settings";
            // 
            // pcCellOperator
            // 
            this.pcCellOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pcCellOperator.FormattingEnabled = true;
            this.pcCellOperator.Items.AddRange(new object[] {
            "Sum",
            "All",
            "Average",
            "Max",
            "Any",
            "Min",
            "String"});
            this.pcCellOperator.Location = new System.Drawing.Point(10, 206);
            this.pcCellOperator.Name = "pcCellOperator";
            this.pcCellOperator.PName = SubsetHelper.GetI18String("CELL_OPERATOR", "SB_", "Criteria");// "Untitled";
            this.pcCellOperator.Size = new System.Drawing.Size(223, 21);
            this.pcCellOperator.StartCount = 0;
            this.pcCellOperator.SValue = "-1";
            this.pcCellOperator.TabIndex = 15;
            // 
            // tlpContainer
            // 
            this.tlpContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Controls.Add(this.pDataPicker, 0, 0);
            this.tlpContainer.Location = new System.Drawing.Point(9, 56);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 1;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Size = new System.Drawing.Size(490, 131);
            this.tlpContainer.TabIndex = 13;
            // 
            // pDataPicker
            // 
            this.pDataPicker.AutoScroll = true;
            this.pDataPicker.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pDataPicker.Location = new System.Drawing.Point(1, 1);
            this.pDataPicker.Margin = new System.Windows.Forms.Padding(0);
            this.pDataPicker.Name = "pDataPicker";
            this.pDataPicker.PName = "Untitled";
            this.pDataPicker.Size = new System.Drawing.Size(488, 129);
            this.pDataPicker.SValue = "";
            this.pDataPicker.TabIndex = 14;
            // 
            // pCube
            // 
            this.pCube.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.pCube.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pCube.DataSource = ((object)(resources.GetObject("pCube.DataSource")));
            this.pCube.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pCube.FormattingEnabled = true;
            this.pCube.Location = new System.Drawing.Point(9, 32);
            this.pCube.Name = "pCube";
            this.pCube.PName = "Cube";
            this.pCube.Size = new System.Drawing.Size(224, 21);
            this.pCube.SValue = "\"\"";
            this.pCube.TabIndex = 11;
            this.pCube.SelectedIndexChanged += new System.EventHandler(this.pCube_SelectedIndexChanged);
            // 
            // cbOperatorParam
            // 
            this.cbOperatorParam.AutoSize = true;
            this.cbOperatorParam.Location = new System.Drawing.Point(427, 206);
            this.cbOperatorParam.Name = "cbOperatorParam";
            this.cbOperatorParam.Size = new System.Drawing.Size(76, 17);
            this.cbOperatorParam.TabIndex = 16;
            this.cbOperatorParam.Text = "Parameter";
            this.cbOperatorParam.UseVisualStyleBackColor = true;
            // 
            // lbOperatorMode
            // 
            this.lbOperatorMode.AutoSize = true;
            this.lbOperatorMode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOperatorMode.Location = new System.Drawing.Point(6, 190);
            this.lbOperatorMode.Name = "lbOperatorMode";
            this.lbOperatorMode.Size = new System.Drawing.Size(118, 13);
            this.lbOperatorMode.TabIndex = 0;
            this.lbOperatorMode.Tag = "Cell Operator";
            this.lbOperatorMode.Text = "Cell operator mode:";
            // 
            // cbCubeParam
            // 
            this.cbCubeParam.AutoSize = true;
            this.cbCubeParam.Location = new System.Drawing.Point(430, 30);
            this.cbCubeParam.Name = "cbCubeParam";
            this.cbCubeParam.Size = new System.Drawing.Size(76, 17);
            this.cbCubeParam.TabIndex = 12;
            this.cbCubeParam.Text = "Parameter";
            this.cbCubeParam.UseVisualStyleBackColor = true;
            // 
            // lbSelectCube
            // 
            this.lbSelectCube.AutoSize = true;
            this.lbSelectCube.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectCube.Location = new System.Drawing.Point(6, 16);
            this.lbSelectCube.Name = "lbSelectCube";
            this.lbSelectCube.Size = new System.Drawing.Size(76, 13);
            this.lbSelectCube.TabIndex = 0;
            this.lbSelectCube.Tag = "Cube";
            this.lbSelectCube.Text = "Select Cube:";
            // 
            // piUpper
            // 
            this.piUpper.Enabled = false;
            this.piUpper.Location = new System.Drawing.Point(275, 38);
            this.piUpper.Name = "piUpper";
            this.piUpper.PName = "Upper";
            this.piUpper.Size = new System.Drawing.Size(43, 21);
            this.piUpper.SValue = "0";
            this.piUpper.TabIndex = 35;
            // 
            // gbOperators
            // 
            this.gbOperators.Controls.Add(this.cbPar2Param);
            this.gbOperators.Controls.Add(this.pOperator);
            this.gbOperators.Controls.Add(this.cbPar1Param);
            this.gbOperators.Location = new System.Drawing.Point(6, 244);
            this.gbOperators.Name = "gbOperators";
            this.gbOperators.Size = new System.Drawing.Size(504, 96);
            this.gbOperators.TabIndex = 20;
            this.gbOperators.TabStop = false;
            this.gbOperators.Tag = "Slice operators";
            this.gbOperators.Text = "Slice operators";
            // 
            // cbPar2Param
            // 
            this.cbPar2Param.AutoSize = true;
            this.cbPar2Param.Location = new System.Drawing.Point(427, 66);
            this.cbPar2Param.Name = "cbPar2Param";
            this.cbPar2Param.Size = new System.Drawing.Size(76, 17);
            this.cbPar2Param.TabIndex = 23;
            this.cbPar2Param.Text = "Parameter";
            this.cbPar2Param.UseVisualStyleBackColor = true;
            // 
            // pOperator
            // 
            this.pOperator.CBPPar1 = this.cbPar1Param;
            this.pOperator.CBPPar2 = this.cbPar2Param;
            this.pOperator.Location = new System.Drawing.Point(9, 16);
            this.pOperator.Name = "pOperator";
            this.pOperator.Op1Selected = false;
            this.pOperator.Op2Selected = false;
            this.pOperator.PName = "Criteria";
            this.pOperator.Size = new System.Drawing.Size(386, 74);
            this.pOperator.SValue = "";
            this.pOperator.TabIndex = 21;
            // 
            // cbPar1Param
            // 
            this.cbPar1Param.AutoSize = true;
            this.cbPar1Param.Location = new System.Drawing.Point(427, 18);
            this.cbPar1Param.Name = "cbPar1Param";
            this.cbPar1Param.Size = new System.Drawing.Size(76, 17);
            this.cbPar1Param.TabIndex = 22;
            this.cbPar1Param.Text = "Parameter";
            this.cbPar1Param.UseVisualStyleBackColor = true;
            // 
            // gbOptional
            // 
            this.gbOptional.Controls.Add(this.cbLowerNamedParam);
            this.gbOptional.Controls.Add(this.cbUpperNamedParam);
            this.gbOptional.Controls.Add(this.cbTopmostNamedParam);
            this.gbOptional.Controls.Add(this.piLower);
            this.gbOptional.Controls.Add(this.piUpper);
            this.gbOptional.Controls.Add(this.piTopmost);
            this.gbOptional.Controls.Add(this.cbLowerElements);
            this.gbOptional.Controls.Add(this.cbUpperElements);
            this.gbOptional.Controls.Add(this.cbTopmost);
            this.gbOptional.Location = new System.Drawing.Point(6, 341);
            this.gbOptional.Name = "gbOptional";
            this.gbOptional.Size = new System.Drawing.Size(504, 86);
            this.gbOptional.TabIndex = 30;
            this.gbOptional.TabStop = false;
            this.gbOptional.Tag = "Optional Settings";
            this.gbOptional.Text = "Optional Settings";
            // 
            // cbLowerNamedParam
            // 
            this.cbLowerNamedParam.AutoSize = true;
            this.cbLowerNamedParam.Enabled = false;
            this.cbLowerNamedParam.Location = new System.Drawing.Point(427, 60);
            this.cbLowerNamedParam.Name = "cbLowerNamedParam";
            this.cbLowerNamedParam.Size = new System.Drawing.Size(76, 17);
            this.cbLowerNamedParam.TabIndex = 39;
            this.cbLowerNamedParam.Text = "Parameter";
            this.cbLowerNamedParam.UseVisualStyleBackColor = true;
            // 
            // cbUpperNamedParam
            // 
            this.cbUpperNamedParam.AutoSize = true;
            this.cbUpperNamedParam.Enabled = false;
            this.cbUpperNamedParam.Location = new System.Drawing.Point(427, 38);
            this.cbUpperNamedParam.Name = "cbUpperNamedParam";
            this.cbUpperNamedParam.Size = new System.Drawing.Size(76, 17);
            this.cbUpperNamedParam.TabIndex = 36;
            this.cbUpperNamedParam.Text = "Parameter";
            this.cbUpperNamedParam.UseVisualStyleBackColor = true;
            // 
            // cbTopmostNamedParam
            // 
            this.cbTopmostNamedParam.AutoSize = true;
            this.cbTopmostNamedParam.Enabled = false;
            this.cbTopmostNamedParam.Location = new System.Drawing.Point(427, 16);
            this.cbTopmostNamedParam.Name = "cbTopmostNamedParam";
            this.cbTopmostNamedParam.Size = new System.Drawing.Size(76, 17);
            this.cbTopmostNamedParam.TabIndex = 33;
            this.cbTopmostNamedParam.Text = "Parameter";
            this.cbTopmostNamedParam.UseVisualStyleBackColor = true;
            // 
            // piLower
            // 
            this.piLower.Enabled = false;
            this.piLower.Location = new System.Drawing.Point(275, 60);
            this.piLower.Name = "piLower";
            this.piLower.PName = "Lower";
            this.piLower.Size = new System.Drawing.Size(43, 21);
            this.piLower.SValue = "0";
            this.piLower.TabIndex = 38;
            // 
            // piTopmost
            // 
            this.piTopmost.Enabled = false;
            this.piTopmost.Location = new System.Drawing.Point(275, 16);
            this.piTopmost.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.piTopmost.Name = "piTopmost";
            this.piTopmost.PName = "Topmost";
            this.piTopmost.Size = new System.Drawing.Size(43, 21);
            this.piTopmost.SValue = "1";
            this.piTopmost.TabIndex = 32;
            this.piTopmost.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbLowerElements
            // 
            this.cbLowerElements.AutoSize = true;
            this.cbLowerElements.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLowerElements.Location = new System.Drawing.Point(10, 60);
            this.cbLowerElements.Name = "cbLowerElements";
            this.cbLowerElements.Size = new System.Drawing.Size(214, 17);
            this.cbLowerElements.TabIndex = 37;
            this.cbLowerElements.Tag = "Take Lower";
            this.cbLowerElements.Text = "Take all lower elements up to  %:";
            this.cbLowerElements.UseVisualStyleBackColor = true;
            this.cbLowerElements.CheckedChanged += new System.EventHandler(this.cbLowerElements_CheckedChanged);
            // 
            // cbUpperElements
            // 
            this.cbUpperElements.AutoSize = true;
            this.cbUpperElements.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUpperElements.Location = new System.Drawing.Point(10, 38);
            this.cbUpperElements.Name = "cbUpperElements";
            this.cbUpperElements.Size = new System.Drawing.Size(213, 17);
            this.cbUpperElements.TabIndex = 34;
            this.cbUpperElements.Tag = "Take Upper";
            this.cbUpperElements.Text = "Take all upper elements up to %:";
            this.cbUpperElements.UseVisualStyleBackColor = true;
            this.cbUpperElements.CheckedChanged += new System.EventHandler(this.cbUpperElements_CheckedChanged);
            // 
            // cbTopmost
            // 
            this.cbTopmost.AutoSize = true;
            this.cbTopmost.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTopmost.Location = new System.Drawing.Point(10, 16);
            this.cbTopmost.Name = "cbTopmost";
            this.cbTopmost.Size = new System.Drawing.Size(164, 17);
            this.cbTopmost.TabIndex = 31;
            this.cbTopmost.Tag = "Take Topmost";
            this.cbTopmost.Text = "Take topmost elements:";
            this.cbTopmost.UseVisualStyleBackColor = true;
            this.cbTopmost.CheckedChanged += new System.EventHandler(this.cbTopmost_CheckedChanged);
            // 
            // npCube
            // 
            this.npCube.CBParameter = this.cbCubeParam;
            this.npCube.IPrimitive = this.pCube;
            this.npCube.SValue = "\"\"";
            // 
            // npcCellOperator
            // 
            this.npcCellOperator.CBParameter = this.cbOperatorParam;
            this.npcCellOperator.IPrimitive = this.pcCellOperator;
            this.npcCellOperator.SValue = "-1";
            // 
            // npiTopmost
            // 
            this.npiTopmost.CBParameter = this.cbTopmostNamedParam;
            this.npiTopmost.IPrimitive = this.piTopmost;
            this.npiTopmost.SValue = "1";
            // 
            // npiUpperElements
            // 
            this.npiUpperElements.CBParameter = this.cbUpperNamedParam;
            this.npiUpperElements.IPrimitive = this.piUpper;
            this.npiUpperElements.SValue = "0";
            // 
            // npiLowerElements
            // 
            this.npiLowerElements.CBParameter = this.cbLowerNamedParam;
            this.npiLowerElements.IPrimitive = this.piLower;
            this.npiLowerElements.SValue = "0";
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
            // FData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOptional);
            this.Controls.Add(this.gbOperators);
            this.Controls.Add(this.gbSettings);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FData";
            this.Size = new System.Drawing.Size(517, 430);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.tlpContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piUpper)).EndInit();
            this.gbOperators.ResumeLayout(false);
            this.gbOperators.PerformLayout();
            this.gbOptional.ResumeLayout(false);
            this.gbOptional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piLower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piTopmost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lbSelectCube;
        private CBParameter cbCubeParam;
        private System.Windows.Forms.Label lbOperatorMode;
        private CBParameter cbOperatorParam;
        private System.Windows.Forms.GroupBox gbOperators;
        private CBParameter cbTopmostNamedParam;
        private CBParameter cbPar1Param;
        private System.Windows.Forms.GroupBox gbOptional;
        private CBParameter cbLowerNamedParam;
        private CBParameter cbUpperNamedParam;
        private PInt piLower;
        private PInt piUpper;
        private PInt piTopmost;
        private System.Windows.Forms.CheckBox cbLowerElements;
        private System.Windows.Forms.CheckBox cbUpperElements;
        private System.Windows.Forms.CheckBox cbTopmost;
        private POpPar pOperator;
        private Apalo.XlAddin.JSubSet.Primitives.PDataPicker pDataPicker;
        private PCube pCube;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npCube;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npcCellOperator;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npiTopmost;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npiUpperElements;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npiLowerElements;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.ToolTip tTip;
        private CBParameter cbPar2Param;
        private Apalo.XlAddin.JSubSet.Primitives.PCombo pcCellOperator;
    }
}
