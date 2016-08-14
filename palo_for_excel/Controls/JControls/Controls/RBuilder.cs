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
/// @brief  Rule Builder Control (Target = Source)
///
/// @file   RBuilder.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;

namespace JControls
{
    public partial class RBuilder : UComputable
    {
        private CPriority cP = CPriority.None;
        public RBuilder()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            cfcBrack.CParent = this;
            ceExpression.CParent = this;

            ceExpression.BorderColor = SystemColors.ControlDark;
            ceExpression.TitleControl.Text = "Source";

            cbPriority.Items.Add(Constants.strNone);
            cbPriority.Items.Add(Constants.strNColon);
            cbPriority.Items.Add(Constants.strCColon);

            cbPriority.Text = Constants.strNone;
        }

        public override void BuildCacheExp(bool propagateDown)
        {
            base.BuildCacheExp(propagateDown);
            if (propagateDown)
            {
                cfcBrack.BuildCacheExp(propagateDown);
                ceExpression.BuildCacheExp(propagateDown);
            }
            cacheExpr = cfcBrack.ExprValue + " = " + Constants.StringFromPriority(CPriority) + " " + ceExpression.ExprValue;
        }

        public CTarget CTarget
        {
            get { return cfcBrack; }
            set { cfcBrack = value; }
        }

        public CExpression CExpression
        {
            get { return ceExpression; }
            set { ceExpression = value; }
        }

        public void ExpandAll()
        {
            CTarget.ExpandAll();
            CExpression.ExpandAll();
        }

        public void CollapseAll()
        {
            CTarget.CollapseUnder();
            CExpression.CollapseUnder();
        }

        public CPriority CPriority
        {
            get
            {
                return cP;
            }
            set
            {
                cP = value;
                cbPriority.SelectedIndex = (int)value;
            }
        }

        public bool FQEN
        {   
            get { return false; }        // Should have been something smarter
            set {  }
        }

        private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update only if not called from CPriority._set
            if ((int)CPriority != cbPriority.SelectedIndex)
            {
                CPriority = (CPriority)cbPriority.SelectedIndex;
                OnExpressionUpdate(this, new EventArgs());
            }
        }

        private void cbFQE_CheckedChanged(object sender, EventArgs e)
        {
            OnExpressionUpdate(sender, e);
        }
    }
}
