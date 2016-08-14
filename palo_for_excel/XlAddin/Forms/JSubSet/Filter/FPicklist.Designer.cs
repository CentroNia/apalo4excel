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
    partial class FPicklist
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
            this.gbDimension = new System.Windows.Forms.GroupBox();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.plElements = new Apalo.XlAddin.JSubSet.Primitives.PPickList();
            this.chElement = new System.Windows.Forms.ColumnHeader();
            this.lbChosenElements = new System.Windows.Forms.Label();
            this.cbElementsParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.btEdit = new System.Windows.Forms.Button();
            this.gbBehaviour = new System.Windows.Forms.GroupBox();
            this.lbSelect = new System.Windows.Forms.Label();
            this.cbTypeParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.prbPickType = new Apalo.XlAddin.JSubSet.Primitives.PRadioPanel();
            this.rbFront = new System.Windows.Forms.RadioButton();
            this.rbBack = new System.Windows.Forms.RadioButton();
            this.rbMerge = new System.Windows.Forms.RadioButton();
            this.rbSubtract = new System.Windows.Forms.RadioButton();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.nplElements = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.nprbPickType = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.gbDimension.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            this.gbBehaviour.SuspendLayout();
            this.prbPickType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDimension
            // 
            this.gbDimension.Controls.Add(this.tlpContainer);
            this.gbDimension.Controls.Add(this.lbChosenElements);
            this.gbDimension.Controls.Add(this.cbElementsParam);
            this.gbDimension.Controls.Add(this.btEdit);
            this.gbDimension.Location = new System.Drawing.Point(6, 3);
            this.gbDimension.Name = "gbDimension";
            this.gbDimension.Size = new System.Drawing.Size(504, 226);
            this.gbDimension.TabIndex = 10;
            this.gbDimension.TabStop = false;
            this.gbDimension.Tag = "Dimension Contents";
            this.gbDimension.Text = "Dimension Contents";
            // 
            // tlpContainer
            // 
            this.tlpContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Controls.Add(this.plElements, 0, 0);
            this.tlpContainer.Location = new System.Drawing.Point(6, 50);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 1;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Size = new System.Drawing.Size(412, 173);
            this.tlpContainer.TabIndex = 11;
            // 
            // plElements
            // 
            this.plElements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.plElements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chElement});
            this.plElements.FullRowSelect = true;
            this.plElements.GridLines = true;
            this.plElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.plElements.Location = new System.Drawing.Point(1, 1);
            this.plElements.Margin = new System.Windows.Forms.Padding(0);
            this.plElements.Name = "plElements";
            this.plElements.PName = "Picklist";
            this.plElements.Size = new System.Drawing.Size(410, 167);
            this.plElements.SValue = "";
            this.plElements.TabIndex = 12;
            this.plElements.UseCompatibleStateImageBehavior = false;
            this.plElements.View = System.Windows.Forms.View.Details;
            this.plElements.EnabledChanged += new System.EventHandler(this.plElements_EnabledChanged);
            this.plElements.SelectedIndexChanged += new System.EventHandler(this.plElements_SelectedIndexChanged);
            // 
            // chElement
            // 
            this.chElement.Text = "Element";
            this.chElement.Width = 409;
            // 
            // lbChosenElements
            // 
            this.lbChosenElements.Location = new System.Drawing.Point(6, 16);
            this.lbChosenElements.Name = "lbChosenElements";
            this.lbChosenElements.Size = new System.Drawing.Size(494, 34);
            this.lbChosenElements.TabIndex = 0;
            this.lbChosenElements.Tag = "Chosen elements";
            this.lbChosenElements.Text = "Chosen elements:";
            this.lbChosenElements.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbElementsParam
            // 
            this.cbElementsParam.AutoSize = true;
            this.cbElementsParam.Location = new System.Drawing.Point(424, 50);
            this.cbElementsParam.Name = "cbElementsParam";
            this.cbElementsParam.Size = new System.Drawing.Size(76, 17);
            this.cbElementsParam.TabIndex = 13;
            this.cbElementsParam.Text = "Parameter";
            this.cbElementsParam.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.Location = new System.Drawing.Point(424, 198);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(75, 23);
            this.btEdit.TabIndex = 14;
            this.btEdit.Tag = "Edit";
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Visible = false;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // gbBehaviour
            // 
            this.gbBehaviour.Controls.Add(this.lbSelect);
            this.gbBehaviour.Controls.Add(this.cbTypeParam);
            this.gbBehaviour.Controls.Add(this.prbPickType);
            this.gbBehaviour.Location = new System.Drawing.Point(6, 228);
            this.gbBehaviour.Name = "gbBehaviour";
            this.gbBehaviour.Size = new System.Drawing.Size(504, 143);
            this.gbBehaviour.TabIndex = 20;
            this.gbBehaviour.TabStop = false;
            this.gbBehaviour.Tag = "Behaviour";
            this.gbBehaviour.Text = "Behaviour";
            // 
            // lbSelect
            // 
            this.lbSelect.AutoSize = true;
            this.lbSelect.Location = new System.Drawing.Point(6, 16);
            this.lbSelect.Name = "lbSelect";
            this.lbSelect.Size = new System.Drawing.Size(222, 13);
            this.lbSelect.TabIndex = 0;
            this.lbSelect.Tag = "Select Insertion";
            this.lbSelect.Text = "Please select how to insert chosen elements:";
            // 
            // cbTypeParam
            // 
            this.cbTypeParam.AutoSize = true;
            this.cbTypeParam.Location = new System.Drawing.Point(424, 107);
            this.cbTypeParam.Name = "cbTypeParam";
            this.cbTypeParam.Size = new System.Drawing.Size(76, 17);
            this.cbTypeParam.TabIndex = 26;
            this.cbTypeParam.Text = "Parameter";
            this.cbTypeParam.UseVisualStyleBackColor = true;
            // 
            // prbPickType
            // 
            this.prbPickType.Controls.Add(this.rbFront);
            this.prbPickType.Controls.Add(this.rbBack);
            this.prbPickType.Controls.Add(this.rbMerge);
            this.prbPickType.Controls.Add(this.rbSubtract);
            this.prbPickType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prbPickType.Inverse = false;
            this.prbPickType.Location = new System.Drawing.Point(18, 32);
            this.prbPickType.Name = "prbPickType";
            this.prbPickType.PName = "Picklist Type";
            this.prbPickType.PRadioPanelType = Apalo.XlAddin.JSubSet.Primitives.PRadioPanelType.Int;
            this.prbPickType.Size = new System.Drawing.Size(392, 90);
            this.prbPickType.StartCount = 0;
            this.prbPickType.SValue = "0";
            this.prbPickType.TabIndex = 21;
            // 
            // rbFront
            // 
            this.rbFront.AutoSize = true;
            this.rbFront.Checked = true;
            this.rbFront.Location = new System.Drawing.Point(3, 3);
            this.rbFront.Name = "rbFront";
            this.rbFront.Size = new System.Drawing.Size(55, 17);
            this.rbFront.TabIndex = 22;
            this.rbFront.TabStop = true;
            this.rbFront.Tag = "Front";
            this.rbFront.Text = "Front";
            this.rbFront.UseVisualStyleBackColor = true;
            // 
            // rbBack
            // 
            this.rbBack.AutoSize = true;
            this.rbBack.Location = new System.Drawing.Point(3, 26);
            this.rbBack.Name = "rbBack";
            this.rbBack.Size = new System.Drawing.Size(52, 17);
            this.rbBack.TabIndex = 23;
            this.rbBack.Tag = "Back";
            this.rbBack.Text = "Back";
            this.rbBack.UseVisualStyleBackColor = true;
            // 
            // rbMerge
            // 
            this.rbMerge.AutoSize = true;
            this.rbMerge.Location = new System.Drawing.Point(3, 49);
            this.rbMerge.Name = "rbMerge";
            this.rbMerge.Size = new System.Drawing.Size(61, 17);
            this.rbMerge.TabIndex = 24;
            this.rbMerge.Tag = "Merge";
            this.rbMerge.Text = "Merge";
            this.rbMerge.UseVisualStyleBackColor = true;
            // 
            // rbSubtract
            // 
            this.rbSubtract.AutoSize = true;
            this.rbSubtract.Location = new System.Drawing.Point(3, 72);
            this.rbSubtract.Name = "rbSubtract";
            this.rbSubtract.Size = new System.Drawing.Size(74, 17);
            this.rbSubtract.TabIndex = 25;
            this.rbSubtract.Tag = "Subtract";
            this.rbSubtract.Text = "Subtract";
            this.rbSubtract.UseVisualStyleBackColor = true;
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
            // nplElements
            // 
            this.nplElements.CBParameter = this.cbElementsParam;
            this.nplElements.IPrimitive = this.plElements;
            this.nplElements.SValue = "";
            // 
            // nprbPickType
            // 
            this.nprbPickType.CBParameter = this.cbTypeParam;
            this.nprbPickType.IPrimitive = this.prbPickType;
            this.nprbPickType.SValue = "0";
            // 
            // FPicklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBehaviour);
            this.Controls.Add(this.gbDimension);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FPicklist";
            this.Size = new System.Drawing.Size(515, 374);
            this.gbDimension.ResumeLayout(false);
            this.gbDimension.PerformLayout();
            this.tlpContainer.ResumeLayout(false);
            this.gbBehaviour.ResumeLayout(false);
            this.gbBehaviour.PerformLayout();
            this.prbPickType.ResumeLayout(false);
            this.prbPickType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDimension;
        private System.Windows.Forms.Button btEdit;
        private CBParameter cbElementsParam;
        private System.Windows.Forms.GroupBox gbBehaviour;
        private CBParameter cbTypeParam;
        private PRadioPanel prbPickType;
        private System.Windows.Forms.RadioButton rbSubtract;
        private System.Windows.Forms.RadioButton rbMerge;
        private System.Windows.Forms.RadioButton rbBack;
        private System.Windows.Forms.RadioButton rbFront;
        private System.Windows.Forms.Label lbSelect;
        private System.Windows.Forms.Label lbChosenElements;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive nplElements;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive nprbPickType;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private PPickList plElements;
        private System.Windows.Forms.ColumnHeader chElement;
        private System.Windows.Forms.ToolTip tTip;
    }
}
