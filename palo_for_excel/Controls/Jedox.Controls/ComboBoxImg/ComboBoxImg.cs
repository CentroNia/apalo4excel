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
////////////////////////////////////////////////////////////////////////////////
/// @brief  Implements combo box control which supports Images and Indent
///
/// @file   ComboBoxImg.cs
///
/// Developed by Vladislav Malicevic on behalf of Jedox AG.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox AG, Freiburg.
///
/// @author Vladislav Malicevic
////////////////////////////////////////////////////////////////////////////////

using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Jedox.Controls
{
    /// <summary>
    /// Implements combo box control which supports Images and Indent
    /// </summary>
    public class ComboBoxImg : ComboBox 
    {
        private ImageList _imageList;
        /// <summary>
        /// Gets or sets ImageList used with ComboBox
        /// </summary>
        /// <remarks>If not set, control behaves like normal ComboBox control.</remarks>
        /// <value>ImageList</value>
        [Description("The ImageList associated with the control"), Category("Jedox.Controls")]
        public ImageList ImageList
        {
            get { return _imageList; }
            set { _imageList = value; }
        }

        [Description("The SelectedIndex associated with the control"), Category("Jedox.Controls")]
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
        /// Initializes new instance of the ComboBoxImg class
        /// </summary>
        public ComboBoxImg()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // some standard stuff (needed!)
            e.DrawBackground();
            e.DrawFocusRectangle();

            // make sure index is not out of bounds
            if (e.Index != -1)
            {
                // some cache
                ComboBoxImgItem item = (ComboBoxImgItem)Items[e.Index];

                // draw white text and no ident when item hover
                if ((e.State & DrawItemState.Focus) == 0)
                {
                    // draw only text if no image is present
                    if (item.ImageIndex != -1 && _imageList != null)
                    {
                        e.Graphics.DrawString(item.Text, Font, Brushes.Black, new Point(_imageList.Images[item.ImageIndex].Width * 2 + ((item.Indent > 0) ? item.Indent * 24 : 0), e.Bounds.Y));
                        e.Graphics.DrawImage(_imageList.Images[item.ImageIndex], new Point(e.Bounds.X + 4 + ((item.Indent > 0) ? item.Indent * 24 : 0), e.Bounds.Y));
                    }
                    else if (item.ImageIndex == -1 && _imageList == null && item.Indent > 0)
                        e.Graphics.DrawString(item.Text, Font, Brushes.Black, new Point(((item.Indent > 0) ? item.Indent * 24 : 0), e.Bounds.Y));
                    else
                        e.Graphics.DrawString(item.Text, Font, Brushes.Black, new Point(e.Bounds.X, e.Bounds.Y));
                }
                else
                {
                    // draw only text if no image is present
                    if (item.ImageIndex != -1 && _imageList != null)
                    {
                        e.Graphics.DrawString(item.Text, Font, Brushes.White, new Point(_imageList.Images[item.ImageIndex].Width * 2 + ((item.Indent > 0) ? item.Indent * 24 : 0), e.Bounds.Y));
                        e.Graphics.DrawImage(_imageList.Images[item.ImageIndex], new Point(e.Bounds.X + 4 + ((item.Indent > 0) ? item.Indent * 24 : 0), e.Bounds.Y));
                    }
                    else if (item.ImageIndex == -1 && _imageList == null && item.Indent > 0)
                        e.Graphics.DrawString(item.Text, Font, Brushes.White, new Point(((item.Indent > 0) ? item.Indent * 24 : 0), e.Bounds.Y));
                    else
                        e.Graphics.DrawString(item.Text, Font, Brushes.White, new Point(e.Bounds.X, e.Bounds.Y));
                }

                // clean
                item = null;
            }
     
            // do the base stuff
            base.OnDrawItem(e);
        }
    }

    /// <summary>
    /// Represents item for the ComboBoxImg. In addtion to text it also features,value, image and ident level.
    /// </summary>
    public class ComboBoxImgItem
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private object _value;
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private int _imageIndex;
        /// <summary>
        /// Index of the Image from the ImageList used with the item
        /// </summary>
        /// <value>-1 if not defined othervise 0 or greater if defined</value>
        public int ImageIndex
        {
            get { return _imageIndex; }
            set { _imageIndex = value; }
        }

        private int _indent;
        /// <summary>
        /// Alias for Level
        /// </summary>
        /// <value>0 if not defined or greater if defined</value>
        public int Indent
        {
            get { return _indent; }
            set { _indent = value; }
        }

        /// <summary>
        /// Indent level of the item
        /// </summary>
        /// <value>0 if not defined or greater if defined</value>
        public int Level
        {
            get { return _indent; }
            set { _indent = value; }
        }

        /// <summary>
        /// Initializes new instance of the ComboBoxImgItem class
        /// </summary>
        public ComboBoxImgItem() : this("", -1, 0)
        {
        }

        /// <summary>
        /// Initializes new instance of the ComboBoxImgItem class
        /// </summary>
        /// <param name="text">The label of the item</param>
        public ComboBoxImgItem(string text) : this(text, -1, 0)
        {
        }

        /// <summary>
        /// Initializes new instance of the ComboBoxImgItem class
        /// </summary>
        /// <param name="text">The label of the item</param>
        /// <param name="imageIndex">The index of the image used to be displayed with the item</param>
        public ComboBoxImgItem(string text, int imageIndex)
        {
            _text = text;
            _imageIndex = imageIndex;
        }

        /// <summary>
        /// Initializes new instance of the ComboBoxImgItem class
        /// </summary>
        /// <param name="text">The label of the item</param>
        /// <param name="imageIndex">The index of the image used to be displayed with the item</param>
        /// <param name="indent">The indent level of the item</param>
        public ComboBoxImgItem(string text, int imageIndex, int indent)
        {
            _text = text;
            _imageIndex = imageIndex;
            _indent = indent;
        }

        /// <summary>
        /// Initializes new instance of the ComboBoxImgItem class
        /// </summary>
        /// <param name="text">The label of the item</param>
        /// <param name="value">The value of the item</param>
        /// <param name="imageIndex">The index of the image used to be displayed with the item</param>
        public ComboBoxImgItem(string text, object value, int imageIndex)
        {
            _text = text;
            _imageIndex = imageIndex;
            _value = value;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}