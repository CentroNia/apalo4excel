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

// Additional Revisions to Palo (c) Junction BI LLC:
// JMM 09-17-13 replaced Node with JNode to correct Tag/Key definition

using System;
using System.Windows.Forms;
//using Crownwood.DotNetMagic.Controls;
using JControls;
//using JNode = System.Windows.Forms.TreeNode;

namespace Apalo.XlAddin.Utils
{

    /// <summary>
    /// Helper class for handling Subsets
    /// </summary>
    class SubsetUtils
    {

        /// <summary>
        /// Singleton holder
        /// </summary>
        private static SubsetUtils _sUtils = null;

        /// <summary>
        /// Instantiets SubsetUtils singleton
        /// </summary>
        public static SubsetUtils Instance()
        {
            if (null == _sUtils)
            {
                _sUtils = new SubsetUtils();
            }

            return _sUtils;
        }

        /// <summary>
        /// </summary>
        private SubsetUtils()
        {
        }

        /// <summary>
        /// Generates dimension tree
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="dbname"></param>
        /// <param name="dimension"></param>
        /// <param name="pi"></param>
        /// 
        public static void GenerateTree(Jedox.Palo.Comm.Connection connection, string dbname, string dimension, ref JTreeView tc)
        {
            tc.ClearNodes();
            TreeHelper.showElements(connection, dbname, dimension, true, ref tc);

            JNode allElements = new JNode(SubsetHelper.GetI18String("All Elements", "SB_CB_"));
            foreach (JNode n in tc.Nodes)
                {
                //  JMM 09-17-13
                allElements.Nodes.Add((TreeNode)n.Clone());
                }

            tc.ClearNodes();
            tc.Nodes.Add(allElements);

        }

        public static bool ConfirmSubsetDelete(String SubsetName)
        {
            DialogResult dlgres = MessageBox.Show(
                    String.Format(SubsetHelper.GetI18String("Confirm Delete", "SB_MB_"), SubsetName),
                    SubsetHelper.GetI18String("Subset Editor", "SB_"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return dlgres == DialogResult.Yes;
        }

    }
}
