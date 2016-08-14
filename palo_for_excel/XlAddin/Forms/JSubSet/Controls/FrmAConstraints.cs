 /* 
 *
 * Copyright (C) 2006-2009 Jedox AG
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jedox.Palo.XlAddin.JSubSet.Controls
{
    public partial class FrmAConstraints : Form
    {
        private ListViewItem definition;

        public FrmAConstraints()
        {
            InitializeComponent();
        }

        public FrmAConstraints(ListViewItem def)
        {
            this.definition = def;

            InitializeComponent();
            InitializeControls();
        }

        public string GetConstraint(int index)
        {
            try
            {
                AConstraint ac = tlpDefinition.Controls[index] as AConstraint;
                return ac.CRelation + ac.Constraint;
            }
            catch (Exception)
            {
                throw new FormatException("Internal error");
            }
        }

        public bool DivideConstraint(String constraint, out String left, out String right)
        {
            if (constraint.StartsWith("<>") || constraint.StartsWith("<=") || constraint.StartsWith(">="))
            {
                left = constraint.Substring(0, 2);
                right = constraint.Substring(2, constraint.Length-2);
                return true;
            }
            else if (constraint.StartsWith("<") || constraint.StartsWith(">") || constraint.StartsWith("="))
            {
                left = constraint.Substring(0, 1);
                right = constraint.Substring(1, constraint.Length - 1);
                return true;
            }
            else
            {
                left = right = "";
                return false;
            }
        }

        private void InitializeControls()
        {
            tlpDefinition.SuspendLayout();
            for (int i = 1; i < PaloInfo.Instance.Aliases.Count; i++)
            {
                //if (i > 1)
                //{
                //    CAnd cand = new CAnd();
                //    cand.Anchor = AnchorStyles.None;
                //    tlpDefinition.Controls.Add(cand);
                //}

                AConstraint ac = new AConstraint();
                ac.AName = PaloInfo.Instance.Aliases[i];
                if (this.definition != null)
                {
                    string constraint = definition.SubItems[i].Text;
                    try
                    {
                        string left, right;
                        DivideConstraint(constraint, out left, out right);
                        ac.CRelation = left;
                        ac.Constraint = right;
                    }
                    catch (Exception)
                    {
                    }
                }
                tlpDefinition.Controls.Add(ac);
            }
            tlpDefinition.ResumeLayout();
        }
    }
}