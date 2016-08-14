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
/// @brief  Target (special case of [...]) control
///
/// @file   CTarget.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////

using System.Windows.Forms;

namespace JControls
{
    public partial class CTarget : CExpression
    {
        public CTarget()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.exprLabel.Text = "Target";
            this.TGrid.Padding = new Padding(0, 0, 0, 14);
            this.CFChooserAt(0).FNText = Constants.strBrack;
            this.CFChooserAt(0).CBOption.Enabled = false;
            OperatorSelectorAt(0).Visible = false;

            //Label lbBrack = new Label();

            //lbBrack.Text = "Target";
            //lbBrack.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            //lbBrack.AutoSize = true;
            //lbBrack.Anchor = AnchorStyles.Left;
            //TitleControl = lbBrack;
            //TitleControl.Margin = new Padding(0, 0, 0, 0);

            //AddAreaControl(new AreaControl());
        }

        public AreaControl AreaControl
        {
            get 
            {
                return CFChooserAt(0).AreaControl;
            }
        }

        public void ClearAreaControl()
        {
            while (AreaControl.DECount > 1)
            {
                AreaControl.RemoveDEAt(AreaControl.DECount - 1);
            }
            AreaControl.DEAt(0).ExprValue = "";
        }

        /*
        public override void BuildCacheExp(bool propagateDown)
        {
            base.BuildCacheExp(propagateDown);
            if (propagateDown)
            {
                AreaControl.BuildCacheExp(propagateDown);
            }
            cacheExpr = "[" + this.ExprValue xprValue + "]";
        }
         */
    }
}
