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

using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace JControls
{
    /// <summary>
    /// Implements combo box control with check 
    /// </summary>
    public class JComboBox : ComboBox 
    {
        [Description("The SelectedIndex associated with the control"), Category("JControls")]
        override  public int SelectedIndex
        {
            get { return base.SelectedIndex; }
            set
            {
                if ((value > -1 && this.Items.Count > 0) || (value == -1))
                {
                    base.SelectedIndex = value;
                }
            }
        }
        
        /// <summary>
        /// Initializes new instance of the JComboBox class
        /// </summary>
        public JComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
        #if NOTUSED
        //  For test only ...
        Font f = e.Font;
        Rectangle r = e.Bounds;
        int i = e.Index;
        DrawItemState s = e.State;
        RectangleF rf = e.Graphics.ClipBounds;
        #endif

            // some standard stuff (needed!)            
            e.DrawBackground();
            e.DrawFocusRectangle();

            // make sure index is not out of bounds
            if (e.Index != -1)
            {
                // some cache
                string item = Items[e.Index].ToString();

                // draw white text and no ident when item hover
                if ((e.State & DrawItemState.Focus) == 0)
                {
                    // draw only text if no image is present
                    e.Graphics.DrawString(item, Font, Brushes.Black, new Point(e.Bounds.X, e.Bounds.Y));
                }
                else
                {
                    // draw only text if no image is present
                    e.Graphics.DrawString(item, Font, Brushes.White, new Point(e.Bounds.X, e.Bounds.Y));
                }

                // clean
                item = null;
            }
     
            // do the base stuff
            base.OnDrawItem(e);
        }
    }
}
