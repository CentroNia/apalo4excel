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
namespace Apalo.XlAddin.JSubSet.Filter
{
    partial class FText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FText));
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.tplContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbExamples = new System.Windows.Forms.Label();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.pRegEx = new Apalo.XlAddin.JSubSet.Primitives.PRegEx();
            this.cbRegexParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.cbDefinitionParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.pbRegex = new Apalo.XlAddin.JSubSet.PBool();
            this.npRegex = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.npbRegex = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.gbSettings.SuspendLayout();
            this.tplContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.tplContainer);
            this.gbSettings.Controls.Add(this.cbRegexParam);
            this.gbSettings.Controls.Add(this.cbDefinitionParam);
            this.gbSettings.Controls.Add(this.pbRegex);
            this.gbSettings.Controls.Add(this.lbDescription);
            this.gbSettings.Controls.Add(this.lbExamples);
            this.gbSettings.Location = new System.Drawing.Point(6, 3);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(504, 368);
            this.gbSettings.TabIndex = 10;
            this.gbSettings.TabStop = false;
            this.gbSettings.Tag = "Settings";
            this.gbSettings.Text = "Settings";
            // 
            // tplContainer
            // 
            this.tplContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tplContainer.ColumnCount = 1;
            this.tplContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplContainer.Controls.Add(this.pRegEx, 0, 0);
            this.tplContainer.Location = new System.Drawing.Point(6, 50);
            this.tplContainer.Name = "tplContainer";
            this.tplContainer.RowCount = 1;
            this.tplContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplContainer.Size = new System.Drawing.Size(410, 171);
            this.tplContainer.TabIndex = 11;
            // 
            // lbDescription
            // 
            this.lbDescription.Location = new System.Drawing.Point(6, 16);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(494, 34);
            this.lbDescription.TabIndex = 0;
            this.lbDescription.Tag = "RegexTitle";
            this.lbDescription.Text = resources.GetString("lbDescription.Text");
            // 
            // lbExamples
            // 
            this.lbExamples.Location = new System.Drawing.Point(6, 250);
            this.lbExamples.Name = "lbExamples";
            this.lbExamples.Size = new System.Drawing.Size(494, 110);
            this.lbExamples.TabIndex = 0;
            this.lbExamples.Tag = "RegexExamples";
            this.lbExamples.Text = "Examples:\r\n\r\n    -  \"Jan|Feb\", to match \"Jan\" and \"Feb\"\r\n    -  \"J.*\", to match a" +
                "ll elements starting with a \"J\"\r\n    -  \"J.*|Mar\", to match all elements startin" +
                "g with a \"J\" and \"Mar\"\r\n";
            this.lbExamples.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            // pRegEx
            // 
            this.pRegEx.Location = new System.Drawing.Point(1, 1);
            this.pRegEx.Margin = new System.Windows.Forms.Padding(0);
            this.pRegEx.Name = "pRegEx";
            this.pRegEx.PName = "RegExes";
            this.pRegEx.Size = new System.Drawing.Size(408, 166);
            this.pRegEx.SValue = "";
            this.pRegEx.TabIndex = 12;
            this.pRegEx.Tag = "RegEx";
            this.pRegEx.EnabledChanged += new System.EventHandler(this.pRegEx_EnabledChanged);
            // 
            // cbRegexParam
            // 
            this.cbRegexParam.AutoSize = true;
            this.cbRegexParam.Location = new System.Drawing.Point(424, 230);
            this.cbRegexParam.Name = "cbRegexParam";
            this.cbRegexParam.Size = new System.Drawing.Size(76, 17);
            this.cbRegexParam.TabIndex = 15;
            this.cbRegexParam.Text = "Parameter";
            this.cbRegexParam.UseVisualStyleBackColor = true;
            // 
            // cbDefinitionParam
            // 
            this.cbDefinitionParam.AutoSize = true;
            this.cbDefinitionParam.Location = new System.Drawing.Point(424, 50);
            this.cbDefinitionParam.Name = "cbDefinitionParam";
            this.cbDefinitionParam.Size = new System.Drawing.Size(76, 17);
            this.cbDefinitionParam.TabIndex = 13;
            this.cbDefinitionParam.Text = "Parameter";
            this.cbDefinitionParam.UseVisualStyleBackColor = true;
            // 
            // pbRegex
            // 
            this.pbRegex.AutoSize = true;
            this.pbRegex.Checked = true;
            this.pbRegex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pbRegex.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbRegex.Location = new System.Drawing.Point(9, 230);
            this.pbRegex.Name = "pbRegex";
            this.pbRegex.PName = "RegEx";
            this.pbRegex.Size = new System.Drawing.Size(141, 17);
            this.pbRegex.SValue = "True";
            this.pbRegex.TabIndex = 14;
            this.pbRegex.Tag = "Regular Expressions";
            this.pbRegex.Text = "Regular expressions";
            this.pbRegex.UseVisualStyleBackColor = true;
            // 
            // npRegex
            // 
            this.npRegex.CBParameter = this.cbDefinitionParam;
            this.npRegex.IPrimitive = this.pRegEx;
            this.npRegex.SValue = "";
            // 
            // npbRegex
            // 
            this.npbRegex.CBParameter = this.cbRegexParam;
            this.npbRegex.IPrimitive = this.pbRegex;
            this.npbRegex.SValue = "True";
            // 
            // FText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSettings);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FText";
            this.Size = new System.Drawing.Size(515, 374);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.tplContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lbDescription;
        private PBool pbRegex;
        private System.Windows.Forms.Label lbExamples;
        private CBParameter cbRegexParam;
        private CBParameter cbDefinitionParam;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npRegex;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive npbRegex;
        private System.Windows.Forms.TableLayoutPanel tplContainer;
        private Apalo.XlAddin.JSubSet.Primitives.PRegEx pRegEx;
        private System.Windows.Forms.ToolTip tTip;
    }
}
