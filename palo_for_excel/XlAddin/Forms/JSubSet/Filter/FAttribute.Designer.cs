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
    partial class FAttribute
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
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lbExamples = new System.Windows.Forms.Label();
            this.btEdit = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.lbAttributeConstraints = new System.Windows.Forms.Label();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.plConstraints = new Apalo.XlAddin.JSubSet.Primitives.PAttribute();
            this.cbAttributeParam = new Apalo.XlAddin.JSubSet.CBParameter();
            this.nplConstraints = new Apalo.XlAddin.JSubSet.Controls.NPrimitive(this.components);
            this.gbSettings.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.tlpContainer);
            this.gbSettings.Controls.Add(this.lbExamples);
            this.gbSettings.Controls.Add(this.btEdit);
            this.gbSettings.Controls.Add(this.btRemove);
            this.gbSettings.Controls.Add(this.cbAttributeParam);
            this.gbSettings.Controls.Add(this.btAdd);
            this.gbSettings.Controls.Add(this.lbAttributeConstraints);
            this.gbSettings.Location = new System.Drawing.Point(6, 3);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(504, 368);
            this.gbSettings.TabIndex = 10;
            this.gbSettings.TabStop = false;
            this.gbSettings.Tag = "Settings";
            this.gbSettings.Text = "Settings";
            // 
            // tlpContainer
            // 
            this.tlpContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.52427F));
            this.tlpContainer.Controls.Add(this.plConstraints, 0, 0);
            this.tlpContainer.Location = new System.Drawing.Point(6, 50);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 1;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.62791F));
            this.tlpContainer.Size = new System.Drawing.Size(410, 171);
            this.tlpContainer.TabIndex = 20;
            // 
            // lbExamples
            // 
            this.lbExamples.Location = new System.Drawing.Point(6, 255);
            this.lbExamples.Name = "lbExamples";
            this.lbExamples.Size = new System.Drawing.Size(494, 110);
            this.lbExamples.TabIndex = 0;
            this.lbExamples.Tag = "Attribute Examples";
            this.lbExamples.Text = "Examples:\r\n\r\n    -  \">0\", to match ...\r\n    -  \"<=1000\", to match ...\r\n    -  \"<>" +
                "10\", to match...\r\n    -  \"=10\", to match...\r\n\r\n\r\n";
            this.lbExamples.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btEdit
            // 
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.Location = new System.Drawing.Point(424, 198);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(75, 23);
            this.btEdit.TabIndex = 103;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Visible = false;
            // 
            // btRemove
            // 
            this.btRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemove.Location = new System.Drawing.Point(424, 138);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(75, 23);
            this.btRemove.TabIndex = 101;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Visible = false;
            // 
            // btAdd
            // 
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Location = new System.Drawing.Point(424, 169);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 102;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Visible = false;
            // 
            // lbAttributeConstraints
            // 
            this.lbAttributeConstraints.Location = new System.Drawing.Point(6, 16);
            this.lbAttributeConstraints.Name = "lbAttributeConstraints";
            this.lbAttributeConstraints.Size = new System.Drawing.Size(494, 34);
            this.lbAttributeConstraints.TabIndex = 0;
            this.lbAttributeConstraints.Tag = "Select Attribute Fields";
            this.lbAttributeConstraints.Text = "Please select and set attribute fields.\r\n";
            this.lbAttributeConstraints.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            // plConstraints
            // 
            this.plConstraints.Location = new System.Drawing.Point(1, 1);
            this.plConstraints.Margin = new System.Windows.Forms.Padding(0);
            this.plConstraints.Name = "plConstraints";
            this.plConstraints.PName = "Attributes";
            this.plConstraints.Size = new System.Drawing.Size(408, 169);
            this.plConstraints.SValue = "{\"Column1\";\"\"}";
            this.plConstraints.TabIndex = 21;
            this.plConstraints.EnabledChanged += new System.EventHandler(this.plConstraints_EnabledChanged);
            // 
            // cbAttributeParam
            // 
            this.cbAttributeParam.AutoSize = true;
            this.cbAttributeParam.Location = new System.Drawing.Point(424, 50);
            this.cbAttributeParam.Name = "cbAttributeParam";
            this.cbAttributeParam.Size = new System.Drawing.Size(76, 17);
            this.cbAttributeParam.TabIndex = 100;
            this.cbAttributeParam.Text = "Parameter";
            this.cbAttributeParam.UseVisualStyleBackColor = true;
            // 
            // nplConstraints
            // 
            this.nplConstraints.CBParameter = this.cbAttributeParam;
            this.nplConstraints.IPrimitive = this.plConstraints;
            this.nplConstraints.SValue = "{\"Column1\";\"\"}";
            // 
            // FAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSettings);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FAttribute";
            this.Size = new System.Drawing.Size(516, 374);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.tlpContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lbAttributeConstraints;
        private CBParameter cbAttributeParam;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btEdit;
        private Apalo.XlAddin.JSubSet.Controls.NPrimitive nplConstraints;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label lbExamples;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private PAttribute plConstraints;
        private System.Windows.Forms.ToolTip tTip;
    }
}
