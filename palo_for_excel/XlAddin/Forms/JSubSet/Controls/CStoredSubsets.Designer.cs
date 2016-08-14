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
namespace Apalo.XlAddin.JSubSet.Controls
{
    partial class CStoredSubsets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CStoredSubsets));
            this.tcSubsets = new System.Windows.Forms.TreeView();
            this.imlList = new System.Windows.Forms.ImageList(this.components);
            this.btEdit = new JControls.JButton();
            this.btAdd = new JControls.JButton();
            this.btRemove = new JControls.JButton();
            this.SuspendLayout();
            // 
            // tcSubsets
            // 
            this.tcSubsets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.tcSubsets.AutoEdit = false;
            this.tcSubsets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;          //Crownwood.DotNetMagic.Controls.TreeBorderStyle.Solid;
            //this.tcSubsets.FocusNode = null;
            //this.tcSubsets.GroupArrows = true;
            //this.tcSubsets.GroupAutoCollapse = true;
            //this.tcSubsets.GroupBorderStyle = Crownwood.DotNetMagic.Controls.GroupBorderStyle.VerticalEdges;
            //this.tcSubsets.GroupClickExpand = Crownwood.DotNetMagic.Controls.ClickExpandAction.Expand;
            //this.tcSubsets.GroupColoring = Crownwood.DotNetMagic.Controls.GroupColoring.Office2003Light;
            //this.tcSubsets.GroupForeColor = System.Drawing.Color.Black;
            //this.tcSubsets.GroupHotFontStyle = System.Drawing.FontStyle.Bold;
            //this.tcSubsets.GroupHotTrack = false;
            //this.tcSubsets.GroupSelectedFontStyle = System.Drawing.FontStyle.Bold;
            //this.tcSubsets.GroupSelectedForeColor = System.Drawing.Color.Black;
            //this.tcSubsets.GroupTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            //this.tcSubsets.HotBackColor = System.Drawing.Color.Empty;
            //this.tcSubsets.HotForeColor = System.Drawing.Color.Empty;
            this.tcSubsets.ImageList = this.imlList;
            this.tcSubsets.ItemHeight = tcSubsets.ItemHeight + 3;
            //this.tcSubsets.LineVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.Nowhere;
            this.tcSubsets.HideSelection = false;
            this.tcSubsets.ShowLines = false;
            this.tcSubsets.Location = new System.Drawing.Point(0, 0);
            this.tcSubsets.Name = "tcSubsets";
            this.tcSubsets.SelectedNode = null;            
            //this.tcSubsets.SelectedNoFocusBackColor = System.Drawing.SystemColors.Control;
            //this.tcSubsets.SelectMode = Crownwood.DotNetMagic.Controls.SelectMode.Single;
            //this.tcSubsets.SelectionMode = JControls.TreeViewSelectionMode.SingleSelect;
            this.tcSubsets.Size = new System.Drawing.Size(231, 192);
            this.tcSubsets.TabIndex = 0;
            this.tcSubsets.Text = "tcSubsets";
            //this.tcSubsets.VerticalGranularity = Crownwood.DotNetMagic.Controls.VerticalGranularity.Pixel;
            //this.tcSubsets.ViewControllers = Crownwood.DotNetMagic.Controls.ViewControllers.Group;
            this.tcSubsets.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tcSubsets_BeforeExpand);
            this.tcSubsets.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tcSubsets_BeforeSelect);
            this.tcSubsets.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tcSubsets_AfterSelect);
            this.tcSubsets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tcSubsets_KeyUp);
            // 
            // imlList
            // 
            this.imlList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlList.ImageStream")));
            this.imlList.TransparentColor = System.Drawing.Color.Transparent;
            this.imlList.Images.SetKeyName(0, "Subset.png");
            this.imlList.Images.SetKeyName(1, "Dimesion_new.png");
            this.imlList.Images.SetKeyName(2, "Dimesion_delete.png");
            this.imlList.Images.SetKeyName(3, "Dimesion_edit.png");
            this.imlList.Images.SetKeyName(4, "add2.png");
            this.imlList.Images.SetKeyName(5, "remove2.png");
            this.imlList.Images.SetKeyName(6, "rename2.png");
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEdit.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btEdit.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btEdit.ButtonImage")));
            this.btEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btEdit.FlatAppearance.BorderSize = 0;
            this.btEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.Image = ((System.Drawing.Image)(resources.GetObject("btEdit.Image")));
            this.btEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btEdit.Location = new System.Drawing.Point(66, 192);
            this.btEdit.Name = "btEdit";
            this.btEdit.RolloverImage = ((System.Drawing.Image)(resources.GetObject("btEdit.RolloverImage")));
            this.btEdit.Size = new System.Drawing.Size(32, 32);
            this.btEdit.TabIndex = 44;
            this.btEdit.Tag = "Edit";
            this.btEdit.UseVisualStyleBackColor = false;
            this.btEdit.Click += new System.EventHandler(this.renameSubset_Chosen);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAdd.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btAdd.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btAdd.ButtonImage")));
            this.btAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btAdd.FlatAppearance.BorderSize = 0;
            this.btAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Image = ((System.Drawing.Image)(resources.GetObject("btAdd.Image")));
            this.btAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btAdd.Location = new System.Drawing.Point(4, 192);
            this.btAdd.Name = "btAdd";
            this.btAdd.Tag = "Add";
            this.btAdd.RolloverImage = ((System.Drawing.Image)(resources.GetObject("btAdd.RolloverImage")));
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 42;
            this.btAdd.UseVisualStyleBackColor = false;
            this.btAdd.Click += new System.EventHandler(this.addSubset_Chosen);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRemove.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btRemove.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btRemove.ButtonImage")));
            this.btRemove.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btRemove.FlatAppearance.BorderSize = 0;
            this.btRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemove.Image = ((System.Drawing.Image)(resources.GetObject("btRemove.Image")));
            this.btRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btRemove.Location = new System.Drawing.Point(35, 192);
            this.btRemove.Name = "btRemove";
            this.btRemove.RolloverImage = ((System.Drawing.Image)(resources.GetObject("btRemove.RolloverImage")));
            this.btRemove.Size = new System.Drawing.Size(32, 32);
            this.btRemove.TabIndex = 43;
            this.btRemove.Tag = "Delete";
            this.btRemove.UseVisualStyleBackColor = false;
            this.btRemove.Click += new System.EventHandler(this.deleteSubset_Chosen);
            // 
            // CStoredSubsets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.tcSubsets);
            this.Name = "CStoredSubsets";
            this.Size = new System.Drawing.Size(231, 224);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tcSubsets;
        private JControls.JButton btEdit;
        private JControls.JButton btAdd;
        private JControls.JButton btRemove;
        private System.Windows.Forms.ImageList imlList;
    }
}
