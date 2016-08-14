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
/// @brief  'Dimension':'element' Control
///
/// @file   DEControl.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;

namespace JControls
{
    /// <summary>
    /// Dimension/element control
    /// </summary>
    public partial class DEControl : UComputable
    {
        private MoreLess moreLess;

        public Filter FDimensions;
        public Filter FElements;
        public bool Filtered = false;

        private bool FQEN
        {
            get
            {
                IComputable cc = this.CParent as IComputable;
                while (!(cc is RBuilder) && (cc.CParent != null)) cc = cc.CParent;
                return (cc is RBuilder) ? ((RBuilder)cc).FQEN : true;
            }
        }

        private string AddApostrophe(string text)
        {
            string t = text;
            if ((t == "") || (t == "<Any element>") ) return t;
            if (!text.StartsWith("'"))
            {
                t = "'" + t;
            }
            if (!text.EndsWith("'"))
            {
                t = t + "'";
            }
            return t;
        }

        public override void BuildCacheExp(bool propagateDown)
        {
            // This is downmost control -- propagateDown is ignored
            base.BuildCacheExp(propagateDown);
            if (cbDimension.Text == "")
            {
                cacheExpr = AddApostrophe(cbElement.Text);
            }
            else
            {
                if (cbElement.Text == "<Any element>" || cbElement.Text == "")
                {
                    // cacheExpr = AddApostrophe(cbDimension.Text);
                    cacheExpr = "";
                    return;
                }
                if (FQEN || ((cbElement.SelectedItem != null) && !((CBEntity)cbElement.SelectedItem).Entity.Unique))
                {
                    cacheExpr = AddApostrophe(cbDimension.Text) + ":" + AddApostrophe(cbElement.Text);
                }
                else
                {
                    cacheExpr = AddApostrophe(cbElement.Text);
                }
            }  
        }

        private void CheckCombo(ComboBox combo)
        {
            if (String.IsNullOrEmpty(combo.Text))
            {
                combo.SelectedItem = null;
            }
        }

        public override string ExprValue
        {
            get
            {
                BuildCacheExp(false);
                return cacheExpr;
            }
            set
            {
                cacheExpr = value;
                int pos = value.IndexOf(":");
                if (pos != -1)
                {
                    cbDimension.Text = value.Substring(0, pos);
                    cbElement.Text = value.Substring(pos + 1, value.Length - pos - 1);
                }
                else
                {
                    if (value.StartsWith("'") && value.EndsWith("'") && value.Length >= 2)
                    {
                        string element = value.Substring(1, value.Length - 2).Replace("''", "'");
                        if (RBElements.Dictionary.ContainsKey(element))
                        {
                            cbDimension.Text = new CBEntity(RBElements.Dictionary[element].Dimension, "'").ToString();
                        }
                        else
                        {
                            cbDimension.Text = "";
                        }
                    }
                    else
                    {
                        cbDimension.Text = "";
                    }

                    cbElement.Text = value;

                    CheckCombo(cbDimension);
                    CheckCombo(cbElement);
                }
            }
        }

        public ComboBox CBElement
        {
            get { return cbElement; }
        }

        public Button MButton
        {
            get { return moreLess.MButton; }
        }

        public Button LButton
        {
            get { return moreLess.LButton; }
        }

        public DEControl()
        {
            InitializeComponent();

            cbElement.MaxLength = 64;
            moreLess = new MoreLess();
            moreLess.TabStop = false;
            moreLess.Orientation = MLOrientation.Horizontal;
            tGrid.Controls.Add(moreLess, 3, 0);

            FElements = new Filter();
            FDimensions = new Filter();

            FDimensions.AddChild(FElements);
            FDimensions.CBFilter = cbDimension;
            FElements.CBFilter = cbElement;
            FElements.ContainsBangDim = true;
            FElements.UsesAnyElement = true;
        }

        public DEControl(bool filtered)
        {
            this.Filtered = filtered;
            InitializeComponent();

            cbElement.MaxLength = 64;
            moreLess = new MoreLess();
            moreLess.TabStop = false;
            moreLess.Orientation = MLOrientation.Horizontal;
            tGrid.Controls.Add(moreLess, 3, 0);

            FElements = new Filter();
            FDimensions = new Filter();

            FDimensions.AddChild(FElements);
            FDimensions.Filtered = filtered;
            FDimensions.CBFilter = cbDimension;
            FElements.CBFilter = cbElement;
            FElements.ContainsBangDim = true;
            FElements.UsesAnyElement = true;
        }

        private void cb_TextChanged(object sender, EventArgs e)
        {
            OnExpressionUpdate(this, new EventArgs());
        }

        private void cb_Leave(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                cb.Text = AddApostrophe(cb.Text);
            }
        }
    }
}
