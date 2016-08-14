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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.JSubSet.Controls
{
    public partial class FrmSelectFlags : Form
    {
        public ArgStructuralFilterSettings settings;
        public FrmSelectFlags(ArgStructuralFilterSettings settings)
        {
            this.settings = settings;

            InitializeComponent();

            if ((int)(settings.Flags & StructuralFilterFlags.AboveExclusive) != 0) 
                checkBox1.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.AboveInclusive) != 0)
                checkBox2.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.AggregatedLevel) != 0)
                checkBox3.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.BelowExclusive) != 0)
                checkBox4.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.BelowInclusive) != 0)
                checkBox5.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.Cyclic) != 0)
                checkBox6.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.HideConsolidated) != 0)
                checkBox7.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.HideLeaves) != 0)
                checkBox8.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.HierarchicalLevel) != 0)
                checkBox9.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.RevolveAddAbove) != 0)
                checkBox10.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.RevolveAddBelow) != 0)
                checkBox11.Checked = true;
            if ((int)(settings.Flags & StructuralFilterFlags.Revolving) != 0)
                checkBox12.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings.Flags = (StructuralFilterFlags)0;
            if (checkBox1.Checked) settings.Flags |= StructuralFilterFlags.AboveExclusive;
            if (checkBox2.Checked) settings.Flags |= StructuralFilterFlags.AboveInclusive;
            if (checkBox3.Checked) settings.Flags |= StructuralFilterFlags.AggregatedLevel;
            if (checkBox4.Checked) settings.Flags |= StructuralFilterFlags.BelowExclusive;
            if (checkBox5.Checked) settings.Flags |= StructuralFilterFlags.BelowInclusive;
            if (checkBox6.Checked) settings.Flags |= StructuralFilterFlags.Cyclic;
            if (checkBox7.Checked) settings.Flags |= StructuralFilterFlags.HideConsolidated;
            if (checkBox8.Checked) settings.Flags |= StructuralFilterFlags.HideLeaves;
            if (checkBox9.Checked) settings.Flags |= StructuralFilterFlags.HierarchicalLevel;
            if (checkBox10.Checked) settings.Flags |= StructuralFilterFlags.RevolveAddAbove;
            if (checkBox11.Checked) settings.Flags |= StructuralFilterFlags.RevolveAddBelow;
            if (checkBox12.Checked) settings.Flags |= StructuralFilterFlags.Revolving;

            this.Close();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            Common.showTimiWarnings = !this.checkBox13.Checked;
        }
    }
}