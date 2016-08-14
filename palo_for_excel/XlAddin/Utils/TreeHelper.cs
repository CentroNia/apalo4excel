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
//  JMM 09-17-13 replaced Node with JNode to correct Tag/Key definition
//  JMM 09-17-13 DimensionListDimElements is now DimensionListElements

using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
//using CDNM = Crownwood.DotNetMagic;
using Jedox.Palo.Comm;
using JControls;
//using JNode = System.Windows.Forms.TreeNode;

namespace Apalo.XlAddin.Utils
{

    [ComVisible(false)]
    public class TreeHelper : System.IDisposable
    {

        private static Hashtable dimelements = new Hashtable();
        private static Font TreeFont = ResourceInitializer.RegularFont;

        public TreeHelper()
        {
        }

        ~TreeHelper()
        {
        }

        public void Dispose()
        {
        }

        private static void addSubNode(ref JNode tN, ElementInfo dimDimElem)
        {
            int i, length = dimDimElem.Children.Length;

            ElementInfo childelem;
            Jedox.Palo.Comm.ChildInfoRaw childinfo;
            string tmpName;
            JNode t;
            for (i = 0; i < length; i++)
            {
                childinfo = dimDimElem.Children[i];

                if (dimelements.ContainsKey(childinfo.Identifier))
                {
                    childelem = (ElementInfo)dimelements[childinfo.Identifier];

                    tmpName = childelem.Name;
                    t = new JNode();
                    t.Text = tmpName;
                    t.NodeFont = TreeFont;

                    if (childinfo.Factor < (double)0)
                    {
                        t.ForeColor = Color.Red;
                    }
                    else if (childinfo.Factor != (double)1)
                    {
                        t.ForeColor = Color.Blue;
                    }
                    else
                    {
                        t.ForeColor = Color.Black;
                    }

                    if (childelem.Children.LongLength > 0)
                    {
                        addSubNode(ref t, childelem);
                        t.Tag = "C";
                        t.ExpandAll();
                    }
                    else if (childelem.Type == DimElementType.DimElementTypeString)
                    {
                        t.Tag = "S";
                    }
                    else
                    {
                        t.Tag = "N";
                    }

                    tN.Nodes.Add(t);
                }
            }
        }


        public static void showElements(Jedox.Palo.Comm.Connection c, string db, string dim, bool tree, Font regFont, ref JTreeView treeCtrl)
        {
            treeCtrl.ClearNodes();

            if (tree == true)
            {
                treeCtrl.ImageList = null;
                //treeCtrl.LineVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.Everywhere;
                //treeCtrl.BoxVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.Everywhere;
            }
            else
            {
                //treeCtrl.LineVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.OnlyBelowRoot;
                //treeCtrl.BoxVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.Nowhere;
            }

            try
            {
                c.Ping();
                ElementInfo[] dimDimElems = dimDimElems = c.DimensionListElements(db, dim);

                int i, tmpCntDimElems = dimDimElems.Length;
                ElementInfo dimelem;

                dimelements.Clear();
                
                for (i = 0; i < tmpCntDimElems; i++)
                {
                    dimelem = dimDimElems[i];
                    if (!string.IsNullOrEmpty(dimelem.Name))
                    {
                        dimelements[dimelem.Identifier] = dimelem;
                    }
                }

                TreeFont = regFont;

                JNode tN;
                bool haschildren;
                for (i = 0; i < tmpCntDimElems; i++)
                {
                    dimelem = dimDimElems[i];
                    if (!string.IsNullOrEmpty(dimelem.Name))
                    {
                        tN = new JNode();
                        tN.Text = dimelem.Name;
                        tN.NodeFont = regFont;
                        tN.ForeColor = Color.Black;

                        haschildren = (dimelem.Children.LongLength > 0);
                        if (tree == true)
                        {
                            // display only root elements
                            if (!has_no_valid_parents(dimelem, dimelements))
                            {
                                continue;
                            }

                            if (haschildren)
                            {
                                tN.Tag = "C";
                                addSubNode(ref tN, dimelem);
                            }
                            else
                            {
                                if (dimelem.Type == Jedox.Palo.Comm.DimElementType.DimElementTypeNumeric)
                                {
                                    tN.Tag = "N";
                                    tN.SelectedImageIndex = 0;
                                }
                                else if (dimelem.Type == Jedox.Palo.Comm.DimElementType.DimElementTypeString)
                                {
                                    tN.Tag = "S";
                                    tN.SelectedImageIndex = 1;
                                }
                                else
                                {
                                    tN.Tag = "C";
                                    tN.SelectedImageIndex = 3;
                                }
                            }
                            treeCtrl.Nodes.Add(tN);
                            tN.EnsureVisible();
                            //treeCtrl.Expand();
                        }
                        else
                        {
                            if (dimelem.Type == Jedox.Palo.Comm.DimElementType.DimElementTypeNumeric)
                            {
                                tN.Tag = "N";
                                tN.ImageIndex = 0;
                                tN.SelectedImageIndex = 0;
                            }
                            else if (dimelem.Type == Jedox.Palo.Comm.DimElementType.DimElementTypeString)
                            {
                                tN.Tag = "S";
                                tN.ImageIndex = 1;
                                tN.SelectedImageIndex = 1;
                            }
                            else
                            {
                                tN.ImageIndex = 2;
                                tN.SelectedImageIndex = 2;
                                tN.Tag = "C";
                            }
                            treeCtrl.Nodes.Add(tN);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error getting dimensions elements!", exc);
            }
        }
        
        public static void showElements(Jedox.Palo.Comm.Connection c, string db, string dim, bool tree, ref JTreeView treeCtrl)
        {
            showElements(c, db, dim, tree, ResourceInitializer.RegularFont, ref treeCtrl);

        }

        public static bool has_no_valid_parents(ElementInfo dimDimElem, Hashtable dimelems)
        {
            int psize = dimDimElem.Parents.Length, i;
            for (i = 0; (i < psize) && !dimelems.ContainsKey(dimDimElem.Parents[i].Identifier); i++) ;

            return (i == psize);
        }



    }
}
