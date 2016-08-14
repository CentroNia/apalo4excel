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
using System.Diagnostics;
using System.Text;
using Jedox.Windows.Forms.CustomControls;
using System.Windows.Forms;

namespace Jedox.Windows.Forms.CustomControls
{
    public partial class DropDownTreePopup : TreeView, IDropDownAware
    {
        private bool _oneClickSelect = true;

        public DropDownTreePopup()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
        }

        public DropDownTreePopup(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //OneClickSelect
        public bool OneClickSelect { get { return _oneClickSelect; } set { _oneClickSelect = value; } }

        #region TreeView Events
        /// <summary>
        /// Allow keeping track of the editing process.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            
            base.OnAfterSelect(e);

            if (ValueChanged != null)
            {
                ValueChanged(this, new DropDownValueChangedEventArgs(e.Node));
            }


            if (OneClickSelect && e.Action == TreeViewAction.ByMouse)
                SendKeys.Send("{ENTER}");
        }

        /// <summary>
        /// A double click on a node counts as finish editing.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            TreeNode node = HitTest(PointToClient(Cursor.Position)).Node;

            if ((FinishEditing != null) && (node != null))
            {
                FinishEditing(this, new DropDownValueChangedEventArgs(node));
            }
        }

        /// <summary>
        /// ENNTER counts as finish editing, ESC as cancel (null is returned).
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (FinishEditing != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                    case Keys.Space:
                        FinishEditing(this, new DropDownValueChangedEventArgs(Value));
                        break;
                    case Keys.Escape:
                        FinishEditing(this, new DropDownValueChangedEventArgs(null));
                        break;
                }
            }            
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
           
        }
        #endregion
        #region IDropDownAware Implementation
        public event DropDownValueChangedEventHandler FinishEditing;
        public event DropDownValueChangedEventHandler ValueChanged;

        public object Value
        {            
            get { return base.SelectedNode; }
            set
            {
                base.SelectedNode = value as TreeNode;                
            }
        }



        #endregion
    }
}
