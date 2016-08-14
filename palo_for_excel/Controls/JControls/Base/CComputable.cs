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
/// @brief  Collapsible Computable Control (Base Class)
///
/// @file
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

    public partial class CComputable : Collapsible, IComputable
    {
        public event EUEventHandler ExpressionUpdate;
        private IComputable cParent = null;
        protected ToolTip cTTip;
        protected string cacheExpr;
        private bool dirty = true;
        protected bool suspended = false;

        public IComputable CParent
        {
            get { return cParent; }
            set { cParent = value; }
        }

        public bool Suspended
        {
            get { return suspended; }
        }

        public virtual string ExprValue
        {
            get
            {
                if (dirty)
                {
                    dirty = false;
                    BuildCacheExp(false);
                }
                return cacheExpr;
            }
        }

        public virtual void BuildCacheExp(bool propagateDown)
        {
        }

        public override bool Collapsed
        {
            get
            {
                return base.Collapsed;
            }
            set
            {
                CaptionLabel.Text = ExprValue;
                base.Collapsed = value;
            }
        }

        // After invoking SuspendUpdate() it is sufficient to call PerformUpdateAll()
        // for the topmost CComputable, and it will resume update for all its children
        // controls, all the way down to the leafs

        public void SuspendUpdate()
        {
            suspended = true;
        }

        public void PerformUpdateAll()
        {
            for (int i = 2; i < TControls.Count; i++)
            {
                if (TControls[i] is CComputable)
                {
                    ((CComputable)TControls[i]).PerformUpdateAll();
                }
            }

            PerformUpdate();
        }
        
        public void PerformUpdate()
        {
            dirty = true;
            if (Collapsed)
            {
                CaptionLabel.Text = ExprValue;
            }
            // WARNING: ToolTip memory leak
            cTTip.SetToolTip(CaptionLabel, ExprValue);
            suspended = false;
        }

        public virtual void OnExpressionUpdate(object sender, EventArgs e)
        {
            if (!suspended)
            {
                PerformUpdate();

                if (cParent != null)
                {
                    cParent.OnExpressionUpdate(sender, e);
                }

                if (ExpressionUpdate != null)
                {
                    ExpressionUpdate(sender, e);
                }
            }
        }

        public CComputable()
        {
            cTTip = new ToolTip();
            cTTip.AutoPopDelay = 20000;
            cTTip.ShowAlways = true;
        }
    }
}
