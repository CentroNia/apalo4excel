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
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace Jedox.Windows.Forms.CustomControls
{
    public partial class DropDownTree : DropDownPanel
    {
        public DropDownTree()
        {
            InitializeComponent();
            DropDownTreePopup dd = new DropDownTreePopup();
            dd.FinishEditing += new DropDownValueChangedEventHandler(DropDown_FinishEditing);
            dd.ValueChanged += new DropDownValueChangedEventHandler(DropDown_ValueChanged);
            base.DropDownControl = dd;
			this.DropDownControl.BorderStyle = BorderStyle.None;
            this.DropDownControl.Width = this.Width;
        }        
	
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DropDownTreePopup DropDownControl				// new is on purpose to change the property's data type and to hide the setter.
		{
			get
			{ 
				if (base.DropDownControl != null)					
				{
                    return base.DropDownControl as DropDownTreePopup;
				}
				
				return null;
			}
		}

        [Localizable(true)]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeNodeCollection Nodes
        {
            get
            {
                return DropDownControl.Nodes;
            }
            set
            {
                DropDownControl.BeginUpdate();
                DropDownControl.Nodes.Clear();
                for (int i = 0; i < value.Count; i++)
                    DropDownControl.Nodes.Add(value[i]);
                DropDownControl.EndUpdate();                
            }

        }

        [DefaultValue(true)]
        public bool OneClickSelect
        {
            get { return DropDownControl.OneClickSelect;  }
            set { DropDownControl.OneClickSelect = value; }
        }
        // Summary:
        //     Disables any redrawing of the tree view.
        public void BeginUpdate() { DropDownControl.BeginUpdate(); }
        //
        // Summary:
        //     Collapses all the tree nodes.
        public void CollapseAll() { DropDownControl.CollapseAll(); }
        
        //
        // Summary:
        //     Enables the redrawing of the tree view.
        public void EndUpdate() { DropDownControl.EndUpdate(); }
        //
        // Summary:
        //     Expands all the tree nodes.
        public void ExpandAll() { DropDownControl.ExpandAll(); }

        //
        // Summary:
        //     Gets or sets the image-list index value of the default image that is displayed
        //     by the tree nodes.
        //
        // Returns:
        //     A zero-based index that represents the position of an System.Drawing.Image
        //     in an System.Windows.Forms.ImageList. The default is zero.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     The specified index is less than 0.
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(-1)]
        [RelatedImageList("ImageList")]
        [Localizable(true)]
        public int ImageIndex { get { return DropDownControl.ImageIndex;} set { DropDownControl.ImageIndex = value;} }
        //
        // Summary:
        //     Gets or sets the key of the default image for each node in the System.Windows.Forms.TreeView
        //     control when it is in an unselected state.
        //
        // Returns:
        //     The key of the default image shown for each node System.Windows.Forms.TreeView
        //     control when the node is in an unselected state.
        [Localizable(true)]
        [TypeConverter(typeof(ImageKeyConverter))]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [RelatedImageList("ImageList")]
        public string ImageKey { get { return DropDownControl.ImageKey; } set { DropDownControl.ImageKey = value; } }
        //
        // Summary:
        //     Gets or sets the System.Windows.Forms.ImageList that contains the System.Drawing.Image
        //     objects used by the tree nodes.
        //
        // Returns:
        //     The System.Windows.Forms.ImageList that contains the System.Drawing.Image
        //     objects used by the tree nodes. The default value is null.
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue("")]
        public ImageList ImageList { get { return DropDownControl.ImageList; } set { DropDownControl.ImageList = value; } }

        //
        // Summary:
        //     Gets or sets the image list used for indicating the state of the System.Windows.Forms.TreeView
        //     and its nodes.
        //
        // Returns:
        //     The System.Windows.Forms.ImageList used for indicating the state of the System.Windows.Forms.TreeView
        //     and its nodes.
        [DefaultValue("")]
        public ImageList StateImageList { get { return DropDownControl.StateImageList; } set { DropDownControl.StateImageList = value; } }

        public int PopupHeight
        {
            get { return DropDownControl.Height; }
            set { DropDownControl.Height = value; }
        }

        //
        // Summary:
        //     Gets or sets the image list index value of the image that is displayed when
        //     a tree node is selected.
        //
        // Returns:
        //     A zero-based index value that represents the position of an System.Drawing.Image
        //     in an System.Windows.Forms.ImageList.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The index assigned value is less than zero.
        [Localizable(true)]
        [DefaultValue(-1)]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [RelatedImageList("ImageList")]
        public int SelectedImageIndex { get { return DropDownControl.SelectedImageIndex; } set { DropDownControl.SelectedImageIndex = value; } }
        //
        // Summary:
        //     Gets or sets the key of the default image shown when a System.Windows.Forms.TreeNode
        //     is in a selected state.
        //
        // Returns:
        //     The key of the default image shown when a System.Windows.Forms.TreeNode is
        //     in a selected state.
        [RelatedImageList("ImageList")]
        [Localizable(true)]
        [TypeConverter(typeof(ImageKeyConverter))]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public string SelectedImageKey { get { return DropDownControl.SelectedImageKey; } set { DropDownControl.SelectedImageKey = value; } }
        //
        // Summary:
        //     Gets or sets the tree node that is currently selected in the tree view control.
        //
        // Returns:
        //     The System.Windows.Forms.TreeNode that is currently selected in the tree
        //     view control.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeNode SelectedNode { get { return DropDownControl.SelectedNode; } set { 
            DropDownControl.SelectedNode = value;
            if (value == null)
                SetValue(null, false);
        } }
        
    }
}
