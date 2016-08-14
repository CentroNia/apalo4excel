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
/// @brief  Collapsible Expression Control
///
/// @file   CExpression.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;

namespace JControls
{
    public partial class CExpression : CComputable
    {
        protected Label exprLabel;    // Holds the string for TitleControl (next to the (-) button)

        public override bool Collapsed
        {
            get { return base.Collapsed; }
            set 
            { 
                base.Collapsed = value;
                if (!value)
                {
                    for (int i = 2; i < TControls.Count; i++)
                    {
                        if (TControls[i] is Collapsible)
                        {
                            ((Collapsible)TControls[i]).Expand();
                        }
                    }
                }
            }
        }

        public override void BuildCacheExp(bool propagateDown)
        {
            base.BuildCacheExp(propagateDown);
            cacheExpr = "";
            for (int i = 2; i < TControls.Count; i += 2)
            {
                CFChooser cfc = TControls[i] as CFChooser;
                if (propagateDown)
                {
                    cfc.BuildCacheExp(propagateDown);
                }
                cacheExpr += cfc.ExprValue;

                OperatorSelector os = TControls[i + 1] as OperatorSelector;
                if (os.Operator != "")
                {
                    cacheExpr += (" " + os.Operator + " ");
                }
            }
        }

        public CExpression()
        {
            InitializeComponent();
            InitializeControls(new CFChooser());
        }

        public CExpression(CFChooser cfc)
        {
            InitializeComponent();
            InitializeControls(cfc);
        }

        private void EnableDBuffering()
        {
            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.UpdateStyles();
        }

        private void InitializeControls(CFChooser cfc)
        {
            SuspendLayout();
            exprLabel = new Label();
            exprLabel.Text = "Expression";
            exprLabel.Anchor = AnchorStyles.Left;
            exprLabel.AutoSize = true;
            exprLabel.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            exprLabel.Margin = new Padding(3, 0, 3, 0);
            TitleControl = exprLabel;
            TGrid.ControlAdded += new ControlEventHandler(TGrid_ControlAdded);

            if (cfc != null)
                AddCFChooser(cfc);
            
            EnableDBuffering();
            ResumeLayout();
        }

        /// <summary>
        /// Sets the last operator to value different than ""
        /// </summary>
        /// <param name="op">
        /// Operator value (e.g. "+", "-", etc.)
        /// </param>
        public void AddOperator(string op)
        {
            OperatorSelector os = (OperatorSelector)TControls[TControls.Count - 1];
            os.Operator = op;
            OnExpressionUpdate(this, new EventArgs());
        }

        /// <summary>
        /// Adds CFunction and dummy operator selector ("...")
        /// </summary>
        /// <param name="c">
        /// CFunction to be added
        /// </param>
        public void AddCFChooser(CFChooser c)
        {
            if (this.suspended) c.SuspendUpdate();
            c.CParent = this;
            c.Dock = DockStyle.Fill;
            c.Visible = !this.Collapsed;
            AddControl(c);
            OperatorSelector os = new OperatorSelector();
            os.TabStop = false;
            os.Dock = DockStyle.Fill;
            // WARNING: (ContextMenuStrip memory leak): 
            os.CMSOperator.ItemClicked += new ToolStripItemClickedEventHandler(OSelector_ItemClicked);
            os.Visible = !this.Collapsed;
            AddControl(os); 
            os.Focus();
            OnExpressionUpdate(this, new EventArgs());
            if ((c.CBOption.SelectedIndex < 0) && (c.CBOption.Items.Count > 0))
            {
                c.CBOption.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// Returns desired CollapsibleFunction
        /// </summary>
        /// <param name="index">
        /// Index of CollapsibleFunction
        /// </param>
        /// <returns></returns>
        public CFChooser CFChooserAt(int index)
        {
            return (CFChooser)TControls[index * 2 + 2];
        }

        public OperatorSelector OperatorSelectorAt(int index)
        {
            return (OperatorSelector)TControls[index * 2 + 3];
        }

        public void RemoveAll()
        {
            while (TControls.Count > 4)
            {
                TCDisposeAt(TControls.Count - 1);
            }
            AddOperator("");
            CFChooserAt(0).FNText = "";
        }

        public void ClearAll()
        {
            while (TControls.Count > 4)
            {
                TCDisposeAt(TControls.Count - 1);
            }
            AddOperator("");
            CFChooserAt(0).FNText = "";
        }

        private void OSelector_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)sender;          
            Button bt = (Button)cms.SourceControl;
            if (bt == null) { cms.Dispose(); cms = null; return; }
            TableLayoutPanel tlp = (TableLayoutPanel)bt.Parent;
            OperatorSelector os = (OperatorSelector)tlp.Parent;
            int index = TControls.IndexOf(os);

            if (e.ClickedItem.Text == "Remove")
            {
                if (index != TControls.Count - 1)
                {
                    SuspendLayout();
                    TCDisposeAt(index + 1);
                    TCDisposeAt(index);
                    ((OperatorSelector)TControls[TControls.Count - 1]).Operator = "";
                    ((OperatorSelector)TControls[TControls.Count - 1]).DisableRemove();
                    ResumeLayout();
                    Focus(); 
                    OnExpressionUpdate(this, new EventArgs());
                }
                else { /* Do nothing */ }
            }
            else
            {
                os.EnableRemove();
                SuspendLayout();
                os.Operator = e.ClickedItem.Text;
                if (index == TControls.Count - 1)
                {
                    AddCFChooser(new CFChooser());
                }
                else
                {
                    OnExpressionUpdate(this, new EventArgs());
                }

                if (os.Operator == Constants.strAt)
                {
                    CFChooser cfc = (CFChooser)TControls[TControls.IndexOf(os) + 1];
                    cfc.FNText = "PALO.MARKER";
                }
                ResumeLayout();
                Focus();
            }
        }

        private void TGrid_ControlAdded(object sender, EventArgs e)
        {
            if (TControls.Count > 2)
            {
                TControls[TControls.Count - 2].Focus();
            }
        }
    }
}