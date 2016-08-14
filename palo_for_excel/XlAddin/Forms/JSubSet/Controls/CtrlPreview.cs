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

//  Additional Revisions to Palo (c) Junction BI LLC:
//  JMM 09-17-13 replaced Node with JNode to correct Tag/Key definition

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using Crownwood.DotNetMagic.Controls;
using JControls;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.JSubSet
{
    public partial class CtrlPreview : UserControl
    {
        public CtrlPreview()
        {
            InitializeComponent();
        }

        public JControls.JButton BTRefresh
        {
            get { return btRefresh; }
        }

        public CheckBox CBAutoRefresh
        {
            get { return cbAutoRefresh; }
        }

        public JTreeView TCPreview
        {
            get { return tcPreview; }
        }

        private List<uint> CreateIndentDef(SubsetResult[] results, int indent)
        {
            if (results == null || results.Length == 0) return null;

            List<uint> indents = new List<uint>();
            indents.Add(0); // Root

            for (int i = 1; i < results.Length; i++)
            {
                uint here = indents[i-1];
                int next = (int)here + 1; // Always 1!
                int prev = (int)here - ((int)results[i-1].Depth - (int)results[i].Depth);

                if (results[i].Depth != results[i - 1].Depth)
                {
                    if (results[i].Depth > results[i - 1].Depth) indents.Add(next >= 0 ? (uint)next : 0);
                    if (results[i].Depth < results[i - 1].Depth) indents.Add(prev >= 0 ? (uint)prev : 0);
                }
                else indents.Add(here);
            }
            return indents;
        }

        public void ClearPreviewData()
        {
            tcPreview.ClearNodes();
        }

        public void SetPreviewData(SubsetResult[] results, bool isHierarchy, int indent)
        {
            tcPreview.ClearNodes();
            if (results == null) return;

            if (!isHierarchy)
            {
                // Flat:
                foreach (SubsetResult res in results)
                    tcPreview.Nodes.Add(new JNode(res.Name));
            }
            else 
            {
                // Hierarchy:
                List<uint> indents = CreateIndentDef(results, indent);
                if (indents == null) return;

                JNode currentParent = null;
                JNode lastNode = new JNode(results[0].Name);
                tcPreview.Nodes.Add(lastNode);

                for (int i = 1; i < results.Length; i++) {
                    if (indents[i] < indents[i - 1])
                    {
                        for (int j = 0; j < indents[i - 1] - indents[i] && currentParent != null; j++)
                            currentParent = (JNode)currentParent.Parent;
                    }
                    else if (indents[i] > indents[i - 1]) currentParent = lastNode;
                    
                    lastNode = new JNode(results[i].Name);
                    if (currentParent == null)
                        tcPreview.Nodes.Add(lastNode);
                    else
                        currentParent.Nodes.Add(lastNode);
                }
            }

            tcPreview.ExpandAll();
        }

        private void cbAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            BTRefresh.Enabled = !cbAutoRefresh.Checked;
        }
    }
}
