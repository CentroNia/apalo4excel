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
    partial class CtrlPreview
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
            this.tcPreview = new JControls.JTreeView();
            this.cbAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btRefresh = new JControls.JButton();
            this.SuspendLayout();
            // 
            // tcPreview
            // 
            this.tcPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.tcPreview.AutoEdit = false;
            this.tcPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;                  //Crownwood.DotNetMagic.Controls.TreeBorderStyle.Solid;
            //this.tcPreview.FocusNode = null;
            //this.tcPreview.HotBackColor = System.Drawing.Color.Empty;
            //this.tcPreview.HotForeColor = System.Drawing.Color.Empty;
            this.tcPreview.LabelEdit = false;
            this.tcPreview.Location = new System.Drawing.Point(0, 0);
            this.tcPreview.Margin = new System.Windows.Forms.Padding(0);
            this.tcPreview.Name = "tcPreview";
            this.tcPreview.SelectedNode = null;
            //this.tcPreview.SelectedNoFocusBackColor = System.Drawing.SystemColors.Control;
            this.tcPreview.Size = new System.Drawing.Size(194, 208);
            this.tcPreview.TabIndex = 0;
            this.tcPreview.Text = "treeControl1";
            // 
            // cbAutoRefresh
            // 
            this.cbAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoRefresh.AutoSize = true;
            this.cbAutoRefresh.Checked = true;
            this.cbAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoRefresh.Location = new System.Drawing.Point(6, 216);
            this.cbAutoRefresh.Name = "cbAutoRefresh";
            this.cbAutoRefresh.Size = new System.Drawing.Size(88, 17);
            this.cbAutoRefresh.TabIndex = 1;
            this.cbAutoRefresh.Text = "Auto Refresh";
            this.cbAutoRefresh.Tag = "Auto Refresh";
            this.cbAutoRefresh.UseVisualStyleBackColor = true;
            this.cbAutoRefresh.CheckedChanged += new System.EventHandler(this.cbAutoRefresh_CheckedChanged);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(164, 212);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Tag = "Refresh";
            this.btRefresh.Size = new System.Drawing.Size(24, 21);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.btRefresh.ButtonImage = Utils.ResourceInitializer.IconRefresh;
            this.btRefresh.RolloverImage = Utils.ResourceInitializer.IconRefreshH;
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // CtrlPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.cbAutoRefresh);
            this.Controls.Add(this.tcPreview);
            this.Name = "CtrlPreview";
            this.Size = new System.Drawing.Size(194, 239);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JControls.JTreeView tcPreview;
        private System.Windows.Forms.CheckBox cbAutoRefresh;
        private JControls.JButton btRefresh;

    }
}
