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
/// @brief  Implements Button control which supports mouse hover states
///
/// @file   JButton.cs
///
/// Developed by Vladislav Malicevic on behalf of Jedox AG.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox AG, Freiburg.
///
/// @author Vladislav Malicevic
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;

namespace JControls
{
    /// <summary>
    /// Implements Button with rollover effect
    /// </summary>
    /// <remarks>Intended to be used textless, i.e. image-only</remarks>
    public partial class JButton : Button
    {
        #region Variables
        private Image _buttonImage;
        private Image _rolloverImage;
        private Color _buttonColor;
        #endregion

        #region Construct
        public JButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            _buttonColor = Color.FromKnownColor(KnownColor.Control);
            this.FlatAppearance.BorderColor = _buttonColor;
            this.FlatAppearance.MouseDownBackColor = _buttonColor;
            this.FlatAppearance.MouseOverBackColor = _buttonColor;
            this.FlatAppearance.BorderSize = 0;
        }
        #endregion

        #region Color
        /// <summary>
        /// Color which will be set to all elements of a button
        /// </summary>
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                this.FlatAppearance.MouseDownBackColor = _buttonColor;
                this.FlatAppearance.MouseOverBackColor = _buttonColor;
            }
        }
        #endregion

        #region Rollover Images
        /// <summary>
        /// Default image for the button
        /// </summary>
        public Image ButtonImage
        {
            get { return _buttonImage; }
            set 
            {
                if (value != null)
                {
                    _buttonImage = value;
                    this.Image = _buttonImage;
                    this.Height = _buttonImage.Height + 2;
                    this.Width = _buttonImage.Width + 2;
                }
                else if (this.Image != null)
                {
                    _buttonImage = this.Image;
                    this.Height = _buttonImage.Height + 2;
                    this.Width = _buttonImage.Width + 2;
                }
                else
                {
                    this.Height = 26;
                    this.Width = 23;
                }
                this.ImageAlign = ContentAlignment.MiddleCenter;
            }
        }

        /// <summary>
        /// Image which will be displayed when pointer is over the button
        /// </summary>
        public Image RolloverImage
        {
            get { return _rolloverImage; }
            set { _rolloverImage = value; }
        }
        #endregion

        #region Events
        protected override void OnMouseHover(EventArgs e)
        {
            this.Image = _rolloverImage;
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_buttonImage != null)
                this.Image = _buttonImage;

            base.OnMouseLeave(e);
        }
        #endregion
    }
}