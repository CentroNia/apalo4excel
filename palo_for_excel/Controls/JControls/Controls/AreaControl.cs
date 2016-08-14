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
/// @brief  Collapsible control representing the array of DEControls 
///         ('[...]' control)
///
/// @file   AreaControl.cs
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
    public partial class AreaControl : UComputable
    {
        private Filter fCube;
        public bool Filtered = false;

        public override void BuildCacheExp(bool propagateDown)
        {
            base.BuildCacheExp(propagateDown);
            cacheExpr = "";
            foreach (DEControl dec in tGrid.Controls)
            {
                if (propagateDown)
                {
                    dec.BuildCacheExp(propagateDown);
                }
                cacheExpr += (dec.ExprValue + ", ");
            }
            cacheExpr = cacheExpr.Remove(cacheExpr.Length - 2);
        }

        public DEControl DEAt(int index)
        {
            return (DEControl)tGrid.Controls[index];
        }

        public int DECount
        {
            get { return tGrid.Controls.Count; }
        }

        public void AddDE(string text)
        {
            DEControl dec = new DEControl(this.Filtered);
            dec.CParent = this;
            dec.MButton.Click += new EventHandler(MButton_Click);
            dec.LButton.Click += new EventHandler(LButton_Click);
            tGrid.Controls.Add(dec);
            dec.Focus();
            fCube.AddChild(dec.FDimensions);
            dec.FDimensions.UpdateCombo();
            dec.ExprValue = text;
            OnExpressionUpdate(this, new EventArgs());
        }

        public void AddDE()
        {
            AddDE("");
            OnExpressionUpdate(this, new EventArgs());
        }

        public void RemoveDE(DEControl dec)
        {
            tGrid.Controls.Remove(dec);
            fCube.RemoveChild(dec.FDimensions);
            OnExpressionUpdate(this, new EventArgs());
        }

        public void RemoveDEAt(int index)
        {
            tGrid.Controls.RemoveAt(index);
            fCube.RemoveChildAt(index);
            OnExpressionUpdate(this, new EventArgs());
        }

        public Entity Cube
        {
            get { return fCube.SelectedCBEntity.Entity; }
            set
            {
                if (fCube.SelectedCBEntity == null || fCube.SelectedCBEntity.Entity != value)
                {
                    fCube = new Filter();
                    fCube.AddEntity(value);
                    fCube.SelectedCBEntity = fCube.CBEList[0];
                    fCube.AddChild(deControl.FDimensions);
                }
            }
        }

        public AreaControl()
        {
            InitializeComponent();
            deControl.LButton.Visible = false;
            deControl.MButton.Click += new EventHandler(MButton_Click);
            fCube = new Filter();
            if (DBList.Instance.DefaultCube != null)
            {
                Cube = DBList.Instance.DefaultCube;
            }
        }

        public AreaControl( bool filtered )
        {
            this.Filtered = filtered;
            InitializeComponent();
            deControl.LButton.Visible = false;
            deControl.MButton.Click += new EventHandler(MButton_Click);
            fCube = new Filter();
            if (DBList.Instance.DefaultCube != null)
            {
                Cube = DBList.Instance.DefaultCube;
            }
        }
        private void MButton_Click(object sender, EventArgs e)
        {
            AddDE();
        }

        private void LButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            TableLayoutPanel tlp = (TableLayoutPanel)b.Parent;
            MoreLess ml = (MoreLess)tlp.Parent;
            TableLayoutPanel tlpp = (TableLayoutPanel)ml.Parent;
            DEControl dec = (DEControl)tlpp.Parent;
            RemoveDE(dec);
        }
    }
}
