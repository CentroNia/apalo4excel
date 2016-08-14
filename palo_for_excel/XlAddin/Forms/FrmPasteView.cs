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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Crownwood.DotNetMagic.Controls;
using JControls;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Utils;
using Apalo.XlAddin.Forms.Controls;

namespace Apalo.XlAddin.Forms
{
    public partial class FrmPasteView : Form
    {
        #region DimDescription class
        public class DimDescription
        {
            public int ID;  // Ordinal number
            public string Name;
            public string Attribute;
            //  Elements[i][0]:     element name
            //  Elements[i][1]:     element has children
            //  Elements[i][2]:     path of element
            //  Elements[i][3]:     attribute name for element
            public ArrayList Elements;
            public ArrayList MultipleElements;
            public ArrayList SingleElement;
            public string ElementListString
            {
                get
                {
                    StringBuilder sb = new StringBuilder();
                    int i = 0;

                    foreach (object[] s in Elements)
                    {
                        string text = String.IsNullOrEmpty((string)s[3]) ? (string)s[0] : (string)s[3];
                        sb.Append(text + ", ");
                        if (++i > 5) break;
                    }
                    if (sb.Length > 2) sb.Remove(sb.Length - 2, 2);  // Remove trailing ", "
                    if (Elements.Count > i) sb.Append("...");

                    // @Vlado: If you want to remove "Dimension (Element)" format, 
                    // please remove the following lines (50-55)
                    if (sb.Length > 0)
                    {
                        sb.Insert(0, "(");
                        sb.Append(")");
                    }
                    sb.Insert(0, Name + " ");

                    return sb.ToString();
                }
            }

            public DimDescription(string name, int id)
            {
                this.Name = name;
                this.ID = id;
                this.Attribute = "";
                SingleElement = new ArrayList();
                MultipleElements = new ArrayList();
            }
        }
        #endregion


        private const string PASTEVIEW = "PasteView";
        private const string DEFAULTSTYLENAMEPATH = "DefaultStyleName";

        #region Control Initialization

        public FrmPasteView()
        {
            InitializeComponent();
            InitializeControls();
            InitializePalo();
        }

        private void InitializeControls()
        {
            List<JTreeView> tcList = new List<JTreeView>();
            tcList.Add(tcColumns);
            tcList.Add(tcRows);
            tcList.Add(tcPageSelector);

            cbDataMode.SelectedIndex = 1;

            foreach (JTreeView tc in tcList)
            {
                //tc.SetTreeControlStyle(TreeControlStyles.GroupOfficeLight);
                tc.CollapseAll();
                //tc.GroupDoubleClickExpand = ClickExpandAction.None;
                //tc.GroupClickExpand = ClickExpandAction.Toggle;
                //tc.ExpandOnDragHover = false;
                //tc.GroupExpandOnDragHover = false;
                //tc.SelectSameLevel = true;
                //tc.AutoEdit = false;
                tc.AllowDrop = true;
                tc.GroupAutoCollapse = true;

                //  JMM 03-22-14 replace CDNM:
                tc.GroupByRootNodes = true;
                tc.ShowLines = false;
                tc.ShowPlusMinus = false;
                tc.CheckBoxes = true;
                tc.BorderStyle = BorderStyle.FixedSingle;
                tc.SelectionMode = TreeViewSelectionMode.SingleSelect;     
                tc.FullRowSelect = true;           

                //tc.GroupColoring = GroupColoring.ControlProperties;
                tc.GroupBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                tc.GroupSelectedBackColor = Utils.ResourceInitializer.FormStdHighLightColor;
                //tc.GroupSelectedNoFocusBackColor = tc.GroupSelectedBackColor;
                tc.GroupFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tc.AfterSelect += new TreeViewEventHandler(treeControl_AfterSelect);
                tc.AfterCheck += new TreeViewEventHandler(treeControl_AfterCheck);
                //tc.GroupDragOver += new NodeDragDropEventHandler(treeControl_GroupDragOver);
                //tc.ClientDragOver += new DragEventHandler(treeControl_DragOver);
                //tc.GroupDragDrop += new NodeDragDropEventHandler(treeControl_GroupDragDrop);
                //tc.ClientDragDrop += new DragEventHandler(treeControl_DragDrop);
                //tc.NodeDrag += new StartDragEventHandler(tc_NodeDrag);
                tc.DragOver += new DragEventHandler(treeControl_DragOver);
                tc.ItemDrag += new ItemDragEventHandler(tc_ItemDrag);
                tc.DragDrop += new DragEventHandler(treeControl_DragDrop);
            }

            this.cbCubes.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.cbDataMode.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            
            this.tcColumns.GroupBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.tcRows.GroupBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.tcPageSelector.GroupBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.Icon = Utils.ResourceInitializer.IconPalo;

            this.cbFixedWidth.Checked = GeneralConst.PASTE_VIEW_DEFAULT_FIXEDWIDTH_CHECKED;
            this.tbColWidth.Text = GeneralConst.PASTE_VIEW_DEFAULT_FIXEDWIDTH.ToString();
            this.cbWrap.Checked = GeneralConst.PASTE_VIEW_DEFAULT_WRAP_CHECKED;
            this.cbShowSelector.Checked = GeneralConst.PASTE_VIEW_DEFAULT_SHOWSELECTOR_CHECKED;

            this.btDefault.Click += new EventHandler(btDefault_Click);
            // unfortunatly there's no other resource
            this.btDefault.Text = ResourceInitializer.PWW_T1ConnectionMarkDefault;
        }


        private void tcClear()
        {              
            tcPageSelector.ClearNodes();
            tcRows.ClearNodes();
            tcColumns.ClearNodes();
        }

        private JNode CreateGroupNode(string name, int id)
        {
            JNode n = new JNode(name);
            JNode subNode = CreateLeafNode(ResourceInitializer.TEXT_CHOOSE_ELEMENT);
            n.Nodes.Add(subNode);
            n.Tag = new DimDescription(name, id);
            subNode.Checked = true;
            subNode.ForeColor = System.Drawing.Color.FromArgb(10, 10, 128);
            subNode.BackColor = System.Drawing.Color.FromArgb(240, 240, 255);

            return n;
        }

        private JNode CreateLeafNode(string name)
        {
            JNode nS = new JNode(name);            
            nS.CheckStates = JNode.NodeCheckStates.Radio;
            //CDNM:
            //nS.CheckStateChanged += new EventHandler(subNode_CheckStateChanged);            
            return nS;
        }

        private void subNode_CheckStateChanged(object sender, EventArgs e)
        {
            JNode n = sender as JNode;
            JNode dimNode = n.Parent as JNode;
            if (n.Checked)
                dimNode.ToolTipText = n.Text;
        }

        private string GetOperationString(JTreeView tc)
        {
            return (tc == tcPageSelector) ? ResourceInitializer.TEXT_CHOOSE_ELEMENT : ResourceInitializer.TEXT_SELECT_ELEMENTS;
        }

        #endregion

        #region Drag & Drop
        
   
        void tc_ItemDrag(object sender, ItemDragEventArgs e)
            {
            DoDragDrop(e.Item, DragDropEffects.Move);
            }
            
        private void tc_NodeDrag(JTreeView tc, DragEventArgs e)
        {
            #if NOTUSED          // TEMPORARY, TO UPDATE:
            if (tc.Nodes.IndexOf(e.Node) >= 0)
            {
                //e.Object = tc.SelectedNodes;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            #endif
        }

        #if NOTUSED                         // CDNM Only:
        private void treeControl_GroupDragOver(JTreeView tc, JNode n, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(NodesCollection)))
            {
                NodesCollection tnodes = (NodesCollection)e.Data.GetData(typeof(NodesCollection));
                if (tc != tcPageSelector &&
                    tnodes[0].TreeView != tc &&
                    tnodes.Count > 1 &&
                    tnodes.Count > 3 - tc.Nodes.Count) // Case when we're carrying too many nodes
                {
                    return;
                }
                else
                {
                    if (tc != tcPageSelector &&
                     tnodes[0].TreeView != tc &&
                     tnodes.Count > 1 &&
                     tc.Nodes.Count == 3) // Case when we're carrying more than one node, and the list is full
                    {
                        return;
                    }
                    else
                    {
                        tc.CollapseAll();
                        e.Effect = DragDropEffects.Move;
                    }
                }
            }
        }
        #endif

        private void treeControl_DragOver(object sender, DragEventArgs e)
        {
            JTreeView tc = sender as JTreeView;
            if (e.Data.GetDataPresent(typeof(NodesCollection)))
            {
                NodesCollection tnodes = (NodesCollection)e.Data.GetData(typeof(NodesCollection));                
                if (tnodes.Count == 0) return;                
                if (tnodes.Count == 1 && tnodes[0].Parent != null)
                    {
                    //  Only allow dragging group nodes here ...
                    return;
                    }
                if (tc != tcPageSelector &&
                    tnodes[0].TreeView != tc &&
                    tnodes.Count > 3 - tc.Nodes.Count) 
                {
                    // Maximum number of nodes exceeded ...
                    return;
                }
                else
                {
                    tc.CollapseAll();
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        #if NOTUSED                         // CDNM Only:
        private void treeControl_GroupDragDrop(JTreeView tc, JNode n, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(NodesCollection))) return;
            NodesCollection tnodes = (NodesCollection)e.Data.GetData(typeof(NodesCollection));
            tc.SelectedNode = null;

            foreach (JNode tn in tnodes)
            {
                if (tn == n) return;
            }

            int pos = tc.Nodes.IndexOf(n);
            // Hidden fature: Holding CTRL means insert after the current node:
            if (e.KeyState == 8 && tnodes[0].TreeView != tc) pos++;
            JTreeView srcTree = tnodes[0].TreeView as JTreeView;
            foreach (JNode tn in tnodes)
            {
                int srcpos = srcTree.Nodes.IndexOf(tnodes[0]);

                tn.TreeView.Nodes.Remove(tn);
                AdjustNodeForControl(tn, tc);
                tc.Nodes.Insert(pos, tn);
                tn.Expand();

                // If the tc is full, and we're carrying one item, then swap:
                if (tc != tcPageSelector && tc != srcTree && tc.Nodes.Count > 3)
                {
                    tc.Nodes.Remove(n);
                    srcTree.Nodes.Insert(srcpos, n);
                    srcTree.SelectedNode = n;
                    n.Expand();
                }
            }

            if (srcTree.Nodes.Count > 0)
            {
                srcTree.Nodes[srcTree.Nodes.Count - 1].Expand();
            }

            this.cbZeroSupresionVisible();
        }
        #endif

        private void treeControl_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(NodesCollection))) return;
            NodesCollection tnodes = (NodesCollection)e.Data.GetData(typeof(NodesCollection));
            if (tnodes.Count == 0) 
                return;
            JTreeView tc = (JTreeView)sender;
            JTreeView srcTree = tnodes[0].TreeView as JTreeView;
            if (srcTree == null) 
                return;
            bool frompage = (srcTree == tcPageSelector);
            DimDescription dDesc;

            //  Allow drop to a position:            
            int pos = -1;
            Point pt = tc.PointToClient(new Point(e.X, e.Y));
            TreeNode target = tc.GetNodeAt(pt);
            while (target != null && target.Parent != null)
                target = target.Parent;
            if (target != null)
                pos = target.Index;

            foreach (JNode tn in tnodes)
            {
                if (tn.Parent != null) continue;
                srcTree.SelectNode(tn, false);
                srcTree.Nodes.Remove(tn);

                if (frompage)
                {
                    dDesc = (tn is JNode) ? ((JNode)tn).Tag as DimDescription : null;
                    dDesc.Elements.Clear();
                    dDesc.MultipleElements.Clear();
                    dDesc.SingleElement.Clear();
                    ((object[])SelectedElements[dDesc.ID])[1] = dDesc.Elements; 
                    SetToolTip(tn);
                }

                AdjustNodeForControl(tn, tc);
                if (pos < 0)
                    tc.Nodes.Add(tn);
                else
                    tc.Nodes.Insert(pos++, tn);
                tc.SelectedNode = tn;
                tn.Expand();
            }
            
            if (srcTree.Nodes.Count > 0)
            {
            // srcTree.Nodes[srcTree.Nodes.Count - 1].Expand();
            }

            this.cbZeroSupresionVisible();
        }

        private void AdjustNodeForControl(JNode n, JTreeView tc)
        {
            DimDescription dd = n.Tag as DimDescription;

            if (tc == tcPageSelector)
            {
                dd.Elements = dd.SingleElement;
            }
            else
            {
                dd.Elements = dd.MultipleElements;
            }

            n.Nodes[0].Text = GetOperationString(tc);
            n.Nodes[0].ToolTipText = dd.ElementListString;
            if (n.Nodes[0].Checked)
            {
                n.ToolTipText = n.Nodes[0].ToolTipText;
            }
        }

        #endregion

        #region Moving Items Within and Between TreeControls (unused)

        private void MoveItemsDown(JTreeView tc)
        {
            if (tc.SelectedNodes != null && tc.SelectedNodes.Count > 0 && tc.SelectedNode.Parent == null)
            {
                int pos;
                TreeNode next;
                foreach (TreeNode n in tc.SelectedNodes)
                {
                    if (n.Index != tc.Nodes.Count - 1)
                    {
                        pos = n.Index;
                        next = tc.Nodes[pos + 1];
                        tc.Nodes.RemoveAt(pos + 1);
                        tc.Nodes.Insert(pos, next);
                    }
                }
            }
            tc.Focus();
        }

        private void MoveItemsUp(JTreeView tc)
        {
            if (tc.SelectedNodes != null && tc.SelectedNodes.Count > 0 && tc.SelectedNode.Parent == null)
            {
                foreach (TreeNode n in tc.SelectedNodes)
                    if (n.Index != 0)
                    {
                        int pos = n.Index;
                        TreeNode prev = tc.Nodes[pos - 1];
                        tc.Nodes.RemoveAt(pos - 1);
                        tc.Nodes.Insert(pos, prev);
                    }
            }
            tc.Focus();
        }

        private void MoveItems(JTreeView tcSrc, JTreeView tcDest)
        {
            if (tcSrc.SelectedNodes != null && tcSrc.SelectedNodes.Count > 0 && tcSrc.SelectedNode.Parent == null)
            {
                foreach (JNode n in tcSrc.SelectedNodes)
                {
                    tcSrc.Nodes.Remove(n);
                    AdjustNodeForControl(n, tcDest);
                    tcDest.Nodes.Add(n);
                    tcDest.SelectedNode = n;
                }
            }
            tcDest.Focus();
        }

        private void MoveAllItems(JTreeView tcSrc, JTreeView tcDest)
        {
            while (tcSrc.Nodes.Count > 0)
            {
                JNode n = (JNode)tcSrc.Nodes[0];
                tcSrc.Nodes.Remove(n);
                AdjustNodeForControl(n, tcDest);
                tcDest.Nodes.Add(n);
                tcDest.SelectedNode = n;
            }
            tcDest.Focus();
        }
        #endregion

        #region General Event Handlers

        private void treeControl_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!e.Node.Checked)
                return;

            if (e.Node.Parent == null) return;

            JTreeView tc = sender as JTreeView;
            JNode n = e.Node as JNode;
            JNode dimNode = n.Parent as JNode;

            bool ispage = (tc == tcPageSelector);

            DimDescription dDesc = dimNode.Tag as DimDescription;

            if (n.Index == 0) // "Choose elements..." ?
            {
                dDesc.Elements = (ispage) ? dDesc.SingleElement : dDesc.MultipleElements;

                ((object[])SelectedElements[dDesc.ID])[1] = dDesc.Elements;
                return;
            }

            // Subset?
            Cursor.Current = Cursors.WaitCursor;
            SubsetResult[] results = null;
            try
            {
                string dimname = dimNode.Text;

                if (this.currConn.DimensionInformationSimple(this.ActiveDB, dimname).Type == DimensionType.NormalDimension)
                {
                    int subsetlen = ((ispage) ? 1 : GeneralConst.getMaxColumn());

                    if (tc == tcRows)
                    {
                        subsetlen = GeneralConst.getMaxRow();
                    }

                    SubSetEditor ast = new SubSetEditor(EditorType.GlobalOnly, this.ActiveHostname, this.ActiveDB, dimname);
                    ast.LoadSubset(n.Text, SubsetType.Global);
                    results = ast.aSubSet.GetSubSetResults(this.currConn, this.ActiveDB, subsetlen);
                    ast.Dispose();
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            int len;
            if ((results == null) || (results.Length == 0))
            {
                len = 0;
            }
            else
            {
                len = (ispage) ? 1 : results.Length; // only one if we're on Page
            }

            dDesc.Elements = new ArrayList();

            for (int i = 0; i < len; i++)
            {
                dDesc.Elements.Add(new object[] { results[i].Name, results[i].HasChildren, results[i].Path, results[i].Name });
            }

            dDesc.Attribute = "";

            ((object[])SelectedElements[dDesc.ID])[1] = dDesc.Elements;
        }

        private void treeControl_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Checked = true;
        }

        private void SetToolTip(JNode dimNode)
        {
            string eList = (dimNode.Tag as DimDescription).ElementListString;
            dimNode.ToolTipText = dimNode.Nodes[0].ToolTipText = eList;
        }

        private void treeControl_DoubleClick(object sender, EventArgs e)
        {
            JTreeView tc = sender as JTreeView;
            MouseEventArgs me = e as MouseEventArgs;

            if (tc.SelectedNode == null) return;

            JNode n = (JNode)tc.SelectedNode;

            JNode dimNode = (JNode)n.Parent;
            if (dimNode is JNode && n.Index == 0) // "Choose elements...";
            {
                JTreeView tcParent = n.TreeView as JTreeView;
                if (tcParent == tcPageSelector)
                {
                    ChooseSingleElement(dimNode);
                }
                else
                {
                    ChooseMultipleElements(dimNode, "", "");
                }

                SetToolTip(dimNode);
            }
        }

        private void cbCubes_EnabledChanged(object sender, EventArgs e)
        {
            if (!cbCubes.Enabled)
            {
                btData.Enabled = false;
                btUser.Enabled = false;
                btAttr.Enabled = false;
                cbCubes.Items.Clear();
            }
        }

        private void cbFixedWidth_CheckedChanged(object sender, EventArgs e)
        {
            tbColWidth.Enabled = cbFixedWidth.Checked;
        }

        private void tbColWidth_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(tbColWidth.Text) <= 0) throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Parameter! Please enter a positive double value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbColWidth.SelectAll();
                tbColWidth.Focus();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
           // this.saveSettings();
            this.Close();
        }

        #endregion

        #region Essential properties

        public NodesCollection Reverse(NodesCollection nc)
        {
            NodesCollection nnc = new NodesCollection();
            foreach (JNode n in nc)
                nnc.Insert(0, n);
            return nnc;
        }

        public NodesCollection Reverse(TreeNodeCollection nc)
        {
            NodesCollection nnc = new NodesCollection();
            foreach (JNode n in nc)
                nnc.Insert(0, n);
            return nnc;
        }

        public NodesCollection PageDims
        {
            get
            {
                return new NodesCollection(tcPageSelector.Nodes);
            }
        }

        public NodesCollection RowDims
        {
            get
            {
                // For some reason, btParse_Click wants this in reverse order:
                return Reverse(tcRows.Nodes);
            }
        }

        public NodesCollection ColDims
        {
            get
            {
                // For some reason, btParse_Click wants this in reverse order:
                return Reverse(tcColumns.Nodes);
            }
        }

        public double ColWidth
        {
            get
            {
                try
                {
                    return Double.Parse(tbColWidth.Text);
                }
                catch (Exception)
                {
                    return GeneralConst.PASTE_VIEW_DEFAULT_FIXEDWIDTH;
                }
            }
        }

        #endregion

        /*
         * Please put all PasteView code below this point!
         * 
         **/

        private void InitializePalo()
        {
            initPosition();
            initFirst();
        }

        private void ChooseSingleElement(JNode dimNode)
        {
            ChooseElements frm = new ChooseElements(ActiveHostname + "/" + ActiveDB, dimNode.Text);
            DimDescription dDesc = (dimNode is JNode) ? ((JNode)dimNode).Tag as DimDescription : null;

            frm.set_selection(ref dDesc.SingleElement, false, dDesc.Attribute);
            dDesc.Elements = dDesc.SingleElement;

            frm.ShowDialog();

            if (dDesc.SingleElement.Count > 0)
            {
                if (((dDesc.MultipleElements.Count > 0) && (dDesc.SingleElement[0] != dDesc.MultipleElements[0]))
                    || (dDesc.MultipleElements.Count == 0))
                {
                    dDesc.MultipleElements.Clear();
                    dDesc.MultipleElements.Add(dDesc.SingleElement[0]);
                }
            }

            ((object[])SelectedElements[dDesc.ID])[1] = dDesc.Elements;

            if (dDesc.Elements.Count > 0)
            {
                object[] element = (object[])dDesc.Elements[0];
                if (element.Length > 4)
                {
                    dDesc.Attribute = (string)element[4];
                }
            }
        }

        private void ChooseMultipleElements(JNode dimNode, string dimElem, string pFad)
        {
            PasteElements2 frm = new PasteElements2();
            ArrayList Options = new ArrayList();
            DimDescription dDesc = ((JNode)dimNode).Tag as DimDescription;

            PickListDefined = false;
            // IN: Options[0] holds Attribute:
            Options.Add(dDesc.Attribute);

            frm.set_selection(this.ActiveServerID, this.ActiveDB, dimNode.Text, ref dDesc.MultipleElements, false, dimElem, pFad, ref Options);

            dDesc.Elements = dDesc.MultipleElements;

            this.returnValue = true;
            if ((String.IsNullOrEmpty(dimElem)) && (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel))
            {
                this.returnValue = false;
            }

            if (dDesc.MultipleElements.Count > 0)
            {
                dDesc.SingleElement.Clear();
                dDesc.SingleElement.Add(dDesc.MultipleElements[0]);
            }

            // OUT: Options[0] holds PickListDefined
            //      Options[1] holds Attribute
            if (Options.Count > 0)
            {
                PickListDefined = (bool)Options[0];
            }
            if (Options.Count > 1)
            {
                dDesc.Attribute = (string)Options[1];
            }

            ((object[])SelectedElements[dDesc.ID])[1] = dDesc.Elements;

            frm.Dispose();
            frm = null;
        }

        #region Code From Hell

        #region DummyDim

        private class DummyDim : object
        {
            public string dim;
            public string refer;

            public DummyDim(string dim)
            {
                this.dim = dim;
                this.refer = "";
            }
        }

        #endregion


        #region Define vars

        private ArrayList SelectedElements;
        private ArrayList ButtonNames;

        private byte FilterType;
        private const int MAX_NUMBER_OF_CELLS = 20000;
        private static bool PickListDefined;
        private bool returnValue = true;

        private ExcelHelper eH;
        private int ActiveServerID;
        private string ActiveDB;
        private string ActiveHostname;

        #region ComboConn Related

        private Connection currConn;
        private ConnComboBox comboConnList;

        #endregion

        #region TIMI Possible bug inducers (wrong initialization?)

        private bool ChangeTableOnly;
        private bool view_exists;
        private string tmpPageSheet;

        private string GlobalDataMode;
        private ArrayList GlobalDb;
        private ArrayList GlobalCube;
        private ArrayList GlobalPages;
        private ArrayList GlobalRows;
        private ArrayList GlobalCols;
        private string GlobalPrefix;
        private string GlobalPostfix;
        private ArrayList GlobalPageCoordinates;
        private ArrayList GlobalTableCoordinates;
        private ArrayList GlobalOptions;

        // Less likely:
        private string tmpConnCoordinates;
        private string tmpCubeCoordinates;


        #endregion

        #endregion

        #region Handling restore form's size/position

        private void initPosition()
        {

            int[] tmpProps = RegUtils.GetFormProperties(PASTEVIEW);

            if (tmpProps[0] >= 0)
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        #endregion

        private string GetDefaultStylename()
        {
            string val = RegUtils.GetStringValue4Form(PASTEVIEW, DEFAULTSTYLENAMEPATH);
            return (string.IsNullOrEmpty(val)) ? "Standard_Ice" : val;
        }

        private void SetDefaultStylename(string stylename)
        {
            RegUtils.SetKeyValue4Form(PASTEVIEW, DEFAULTSTYLENAMEPATH, stylename);
        }

        private void FillStyleList(string stylename)
        {
            this.cbStyle.Items.Clear();

            string stylepath = PasteUtils.GetStylesDirectory(true);

            FileHelper.checkdir(stylepath);

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(stylepath);

            foreach (System.IO.FileInfo f in dir.GetFiles(PasteUtils.STYLEFILESTART + "*.xls" ))
            {
                this.cbStyle.Items.Add(new PasteUtils.StyleItem(f.FullName));
            }

            string tmpstyle = (string.IsNullOrEmpty(stylename)) ? GetDefaultStylename() : stylename;

            this.cbStyle.SelectedIndex = this.cbStyle.FindString(tmpstyle);
        
        }

        private void initFirst()
        {
            GlobalPageCoordinates = new ArrayList();
            GlobalTableCoordinates = new ArrayList();
            GlobalOptions = new ArrayList();

            SelectedElements = new ArrayList();
            ButtonNames = new ArrayList();

            this.ActiveDB = "";
            this.ActiveHostname = "";
            this.initCombo();

            FillStyleList("");

            this.btClose.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.btClose.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.btClose.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.btPaste.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.btPaste.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.btPaste.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.eH = new Apalo.XlAddin.Utils.ExcelHelper();

            this.Text = ResourceInitializer.PASTE_VIEW_TITLE;
            this.lbChooseServer.Text = ResourceInitializer.TEXT_CHOOSE_SERVER_DB;
            this.lbChooseCube.Text = ResourceInitializer.TEXT_CHOOSE_CUBE;
            this.lbChooseStyle.Text = ResourceInitializer.TEXT_CHOOSE_STYLE;
            this.gbPageSelect.Text = ResourceInitializer.PASTE_VIEW_LABEL3;
            this.gbColSelect.Text = ResourceInitializer.PASTE_VIEW_LABEL4;
            this.gbRowSelect.Text = ResourceInitializer.PASTE_VIEW_LABEL5;
            this.gbData.Text = ResourceInitializer.PASTE_VIEW_LABEL6;
            this.cbFixedWidth.Text = ResourceInitializer.LABEL_CHECK_AUTOFIT;
            this.btPaste.Text = ResourceInitializer.BUTTON_PASTE;
            this.btClose.Text = ResourceInitializer.BUTTON_CLOSE;
            this.cbWrap.Text = ResourceInitializer.LABEL_CHECK_WORDWRAP;
            this.cbIndent.Text = ResourceInitializer.LABEL_CHECK_INDENT;
            this.cbShowSelector.Text = ResourceInitializer.LABEL_CHECK_ELEMENT_SELECTOR;
            this.cbZeroSuppression.Text = ResourceInitializer.LABEL_CHECK_ZERO_SUPPRESSION;
            this.cbZeroSuppressionAlsoCalculatedNull.Text = ResourceInitializer.LABEL_CHECK_ZERO_SUPPRESSION_ALSO_CALULATED_NULL;

            this.cbZeroSuppression.CheckedChanged += new System.EventHandler(this.cbZeroSuppression_CheckedChanged);

            this.do_cbZeroSuppression_Checked();

            this.toolTip.SetToolTip(this.cbDataMode, ResourceInitializer.TIP_FUCTION_TYPE);
            this.toolTip.SetToolTip(this.cbFixedWidth, ResourceInitializer.TIP_AUTOFIT);
            this.toolTip.SetToolTip(this.btPaste, ResourceInitializer.TIP_BUTTON_PASTE_VIEW);
            this.toolTip.SetToolTip(this.btClose, ResourceInitializer.TIP_BUTTON_CLOSE_PASTE_VIEW);
            this.toolTip.SetToolTip(this.cbCubes, ResourceInitializer.TIP_CHOOSE_CUBE);
            this.toolTip.SetToolTip(this.cbWrap, ResourceInitializer.LABEL_CHECK_WORDWRAP);
            this.toolTip.SetToolTip(this.cbShowSelector, ResourceInitializer.LABEL_CHECK_ELEMENT_SELECTOR);
            this.toolTip.SetToolTip(this.cbIndent, ResourceInitializer.LABEL_CHECK_INDENT);
            this.toolTip.SetToolTip(this.btData, ResourceInitializer.TipCubeFilterData);
            this.toolTip.SetToolTip(this.btAttr, ResourceInitializer.TipCubeFilterAttribute);
            this.toolTip.SetToolTip(this.btUser, ResourceInitializer.TipCubeFilterUser);

            this.btUser.Image = (Image)ResourceInitializer.IconFilterUserOn;
            this.btData.Image = (Image)ResourceInitializer.IconFilterDataOn;
            this.btAttr.Image = (Image)ResourceInitializer.IconFilterAttributeOn;
            this.btUser.Visible = true;
            this.btData.Visible = true;
            this.btAttr.Visible = true;
            this.cbIndent.Visible = true;
            this.btData.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void preselectComboConnList()
        {
           comboConnList.SetItem();
        }

        private void initCombo()
        {
            this.comboConnList = new ConnComboBox();
            // 
            // comboConnList
            // 
            this.comboConnList.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.comboConnList.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.comboConnList.CausesValidation = false;
            this.comboConnList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboConnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.comboConnList.MaxLength = 1;
            this.comboConnList.Location = new System.Drawing.Point(10, 24);
            this.comboConnList.Name = "comboConnList";
            this.comboConnList.Size = new System.Drawing.Size(440, 21);
            this.comboConnList.TabIndex = 2;
            this.comboConnList.Tag = "myCustomCombo";
            this.comboConnList.Text = ResourceInitializer.TIP_COMBO_CONNECTIONS;
            this.comboConnList.Dock = DockStyle.Fill;
            this.pPanel.Controls.Add(this.comboConnList);
            this.comboConnList.SelectedIndexChanged += new System.EventHandler(this.comboConnList_SelectedIndexChanged);
            this.comboConnList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void setCombo()
        {
            this.toolTip.SetToolTip(this.comboConnList, ResourceInitializer.TIP_COMBO_CONNECTIONS);
            this.comboConnList.FillList(-1, ConnectionsHelper.HandleDatabase.WithSystem);
        }

        private void comboConnList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // set tooltip to selected option
            if (this.comboConnList.Text != null)
            {
                this.toolTip.SetToolTip(this.comboConnList, this.comboConnList.Text);
            }

            this.ActiveServerID = this.comboConnList.GetServerId();
            this.ActiveHostname = this.comboConnList.GetConnectionName();
            this.currConn = this.comboConnList.GetConnection();
            this.ActiveDB = this.comboConnList.GetDatabase();

            tcClear();
            this.btPaste.Enabled = false;

            if (string.IsNullOrEmpty(this.ActiveDB))
            {
                this.cbCubes.Enabled = false;
            }
            else
            {
                this.cbCubes.Enabled = true;
                this.get_cubes();

                if (String.Equals(this.ActiveDB, GeneralConst.SYSTEM_DB_NAME, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.do_btnFilter(GeneralConst.FILTER_USER);
                    this.btData.Enabled = false;
                    this.btAttr.Enabled = false;
                    this.btUser.Enabled = false;
                }
                else
                {
                    this.do_btnFilter(GeneralConst.FILTER_DATA);
                    this.btData.Enabled = true;
                    this.btAttr.Enabled = true;
                    this.btUser.Enabled = true;
                }
            }
        }

        private void get_cubes()
        {
            this.cbCubes.RefreshList(this.comboConnList, this.currConn, this.FilterType, !this.view_exists, (this.GlobalCube.Count > 3) ? this.GlobalCube[2].ToString() : null);
        }

        #region Filter Cubes

        private void do_btnFilter(byte filtertype)
        {
            this.FilterType = filtertype;
            this.btData.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btAttr.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btUser.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;

            if (filtertype == GeneralConst.FILTER_DATA)
            {
                this.btData.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            else if (filtertype == GeneralConst.FILTER_ATTRIBUTE)
            {
                this.btAttr.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            else if (filtertype == GeneralConst.FILTER_USER)
            {
                this.btUser.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            this.ChangeActiveCube();
        }

        private void ChangeActiveCube()
        {
            tcClear();
            this.btPaste.Enabled = false;
            this.get_cubes();
        }

        private void btData_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.FILTER_DATA);
        }

        private void btAttr_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.FILTER_ATTRIBUTE);
        }

        private void btUser_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.FILTER_USER);
        }

        #endregion

        #region Cubes combo

        private void AddSubsets(JNode n)
        {
            
            try
            {
                DimDescription dd = n.Tag as DimDescription;

                string dimname = dd.Name;

                if (this.currConn.DimensionInformationSimple(this.ActiveDB, dimname).Type == DimensionType.NormalDimension)
                {
                    List<string> globalSub = SubsetHelper.GetGlobalSubsetList(this.currConn, this.ActiveDB, dd.Name);
                    foreach (string subset in globalSub)
                    {
                        n.Nodes.Add(CreateLeafNode(subset));
                    }
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void cbCubes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.btPaste.Enabled = false;
            
            this.SelectedElements.Clear();
            this.ButtonNames.Clear();

            if (this.cbCubes.SelectedIndex != -1 && this.comboConnList.SelectedIndex != -1)
            {
                try
                {
                    this.toolTip.SetToolTip(this.cbCubes, this.cbCubes.SelectedItem.ToString());
                }
                catch
                { }
                this.btPaste.Enabled = true;
                tcClear();

                if (this.currConn == null)
                {
                    return;
                }

                string[] cubDims = this.currConn.CubeListDimensions(this.comboConnList.GetDatabase(), this.cbCubes.SelectedItem.ToString());

                int id = 0;
                JNode n;
                foreach (string dim in cubDims)
                {
                    n = CreateGroupNode(dim, id++);
                    AddSubsets(n);

                    SelectedElements.Add(new object[] { dim, new ArrayList() });
                    ButtonNames.Add(dim);

                    AdjustNodeForControl(n, tcPageSelector);
                    tcPageSelector.Nodes.Add(n);
                }

                if ((this.FilterType == GeneralConst.FILTER_ATTRIBUTE) || (tcPageSelector.Nodes.Count < 3))
                {

                    // Automagically distribute Dimensions into Columns/Rows
                    if (tcPageSelector.Nodes.Count > 1)
                    {
                        n = (JNode)tcPageSelector.Nodes[tcPageSelector.Nodes.Count - 1];
                        tcPageSelector.Nodes.Remove(n);
                        AdjustNodeForControl(n, tcRows);
                        tcRows.Nodes.Add(n);
                        n.Expand();
                    }

                    if (tcPageSelector.Nodes.Count > 0)
                    {
                        n = (JNode)tcPageSelector.Nodes[tcPageSelector.Nodes.Count - 1];
                        tcPageSelector.Nodes.Remove(n);
                        AdjustNodeForControl(n, tcColumns);
                        tcColumns.Nodes.Add(n);
                        n.Expand();
                    }
                }

                if (tcPageSelector.Nodes.Count > 0)
                {
                    /*
                    tcPageSelector.Nodes[tcPageSelector.Nodes.Count - 1].Expand();
                    tcPageSelector.Nodes[tcPageSelector.Nodes.Count - 1].Select(true);
                    if (tcPageSelector.SelectedNode.Nodes.Count > 0)
                        tcPageSelector.SelectedNode.Nodes[0].Select(true);
                     */
                    tcPageSelector.Nodes[0].Expand();
                    tcPageSelector.SelectNode(tcPageSelector.Nodes[0]);
                    //CDNM: tcPageSelector.Nodes[0].Select(true);
                }
            }
        }

        #endregion

        private void btDefault_Click(object sender, EventArgs e)
        {
            SetDefaultStylename(this.cbStyle.Text);
        }

        private void cbZeroSupresionVisible()
        {
            this.cbZeroSuppression.Visible = true;
//            this.cbZeroSuppression.Visible = (this.tcColumns.Nodes.Count < 2) && (this.tcRows.Nodes.Count < 2);
        }

        private void FillDimensionHelperArray(ref PasteUtils.DimensionHelper[] dha, NodesCollection nc, int len, string dbN, bool ispage)
        {
            int i, j, len2;
            string dim, attrib;
            ArrayList currElements;
            JNode dimNode;
            object[] o;

            for (i = 0; i < len; i++)
            {
                dimNode = nc[i] as JNode;
                dim = ((DimDescription)dimNode.Tag).Name;
                attrib = ((DimDescription)dimNode.Tag).Attribute;
                dha[i] = new PasteUtils.DimensionHelper(dim, attrib);

                currElements = new ArrayList();

                int currItem = 0;
                if (SearchArrayList(this.ButtonNames, dim, ref currItem))
                {
                    System.Object[] tmpSelection2 = (System.Object[])this.SelectedElements[currItem];
                    currElements = (ArrayList)tmpSelection2[1];
                }
                
                len2 = currElements.Count;

                if (len2 > 0)
                {
                    if (ispage)
                    {
                        len2 = 1;
                    }

                    for (j = 0; j < len2; j++)
                    {
                        o = (object[])currElements[j];
                        dha[i].elements.Add(new PasteUtils.ElementHelper((string)o[0], (string)o[3],(string)o[2], (bool)o[1]));
                    }
                }
            }
        }

        private void do_btPaste_Click()
        {
            Connect.InPaste = false;
            PasteUtils.DimensionHelper[] pages, rows, cols;

            this.saveSettings();
            if ((this.cbCubes.SelectedIndex != -1) && (this.comboConnList.SelectedIndex != -1) && (this.cbDataMode.SelectedIndex != -1))
            {
                string cube = this.cbCubes.SelectedItem.ToString();

                int len = PageDims.Count;
                pages = new PasteUtils.DimensionHelper[len];
                this.FillDimensionHelperArray(ref pages, PageDims, len, this.ActiveDB, true);

                len = RowDims.Count;
                rows = new PasteUtils.DimensionHelper[len];
                this.FillDimensionHelperArray(ref rows, RowDims, len, this.ActiveDB, false);

                len = ColDims.Count;
                cols = new PasteUtils.DimensionHelper[len];
                this.FillDimensionHelperArray(ref cols, ColDims, len, this.ActiveDB, false);

                if (PasteUtils.do_paste_view(this.ActiveHostname, this.ActiveDB, cube, this.cbDataMode.SelectedItem.ToString(), pages, rows, cols, this.ChangeTableOnly, this.GlobalDb, this.GlobalCube, this.GlobalPageCoordinates, this.GlobalTableCoordinates, this.GlobalPages, (this.GlobalRows != null) ? this.GlobalRows.Count : 0, this.cbZeroSuppression.Checked, this.cbZeroSuppressionAlsoCalculatedNull.Checked, this.cbShowSelector.Checked, this.cbWrap.Checked, this.cbFixedWidth.Checked, ColWidth, this.cbIndent.Checked, this.cbStyle.Text))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            Connect.InPaste = true;

        }

        private void btPaste_Click(object sender, EventArgs e)
        {
            do_btPaste_Click();
        }

        #region Paste functions
        static bool SearchArrayList(ArrayList haystack, object needle, ref int currItem)
        {
            try
            {
                for (int i = 0; i < haystack.Count; i++)
                {
                    object o = haystack[i];
                    if (o.ToString().Equals(needle.ToString()))
                    {
                        return true;
                    }
                    currItem++;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region saveSettings

        private void saveSettings()
        {
            this.cbCubes.SaveItem();
            this.comboConnList.SaveItem();
        }

        #endregion

        #region Handle Show/Hide Event
        private void FrmPasteView_VisibleChanged(object sender, System.EventArgs e)
        {
            if (this.Visible == true)
            {
                this.ChangeTableOnly = false;
                this.SetFromCurrentState();
            }
            else
            {
                RegUtils.SetFormProperties(PASTEVIEW, new int[4] { this.Left, this.Top, this.Width, this.Height });
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                tcClear();
            }
        }
        #endregion

        #region SetFromCurrentState

        private void SetFromCurrentState()
        {
            this.tmpConnCoordinates = '$' + "A" + '$' + "1";
            this.tmpCubeCoordinates = '$' + "A" + '$' + "2";
            this.tmpPageSheet = "";
            this.GlobalDataMode = "";
            this.GlobalDb = new ArrayList();
            this.GlobalCube = new ArrayList();
            this.GlobalPages = new ArrayList();
            this.GlobalRows = new ArrayList();
            this.GlobalCols = new ArrayList();
            this.GlobalPrefix = "";
            this.GlobalPostfix = "";

            Apalo.XlAddin.Utils.ExcelHelper eH = this.eH;
            string datamode = "";
            string host = "";
            string db = "";
            string cube = "";
            CubeType cubetyp = CubeType.NormalCube;
            ArrayList pages = new ArrayList();
            ArrayList rows = new ArrayList();
            ArrayList cols = new ArrayList();
            double usewidth = -1;
            string stylename = "";

            if (!ExcelHelper.TestWithoutExcel)
            this.view_exists = eH.get_ws_params2(ref this.GlobalDataMode, ref this.GlobalDb, ref this.GlobalCube, ref this.GlobalPages, ref this.GlobalRows, ref this.GlobalCols, ref this.GlobalPrefix, ref this.GlobalPostfix, ref this.GlobalPageCoordinates, ref this.GlobalTableCoordinates, ref this.GlobalOptions);
            
            if (this.view_exists)
            {
                datamode = this.GlobalDataMode;

                if (this.GlobalDb != null && this.GlobalDb.Count > 0)
                {
                    host = this.GlobalDb[2].ToString();
                    db = this.GlobalDb[3].ToString();
                }

                if (this.GlobalCube != null && this.GlobalCube.Count > 2)
                {
                    cube = this.GlobalCube[2].ToString();
                }

                if (this.GlobalCube != null && this.GlobalCube.Count > 5)
                {
                    cubetyp = (CubeType)this.GlobalCube[5];
                }

                if (this.GlobalPages != null && this.GlobalPages.Count > 0)
                {
                    object[] tmpPage = (object[])this.GlobalPages[0];
                    if ((tmpPage[4] != null) && (tmpPage[4].ToString().Length != 0))
                    {
                        this.tmpPageSheet = tmpPage[4].ToString() + '!';
                    }
                }

                pages = this.GlobalPages;
                rows = this.GlobalRows;
                cols = this.GlobalCols;

                if (this.GlobalOptions.Count > 0)
                {
                    PickListDefined = (bool)this.GlobalOptions[0];
                }
                if (this.GlobalOptions.Count > 1)
                {
                    this.cbIndent.Checked = (bool)this.GlobalOptions[1];
                }

                if (this.GlobalOptions.Count > 2)
                {
                    this.cbZeroSuppression.Checked = (bool)this.GlobalOptions[2];
                }

                if (this.GlobalOptions.Count > 3)
                {
                    usewidth = (double)this.GlobalOptions[3];
                    this.cbFixedWidth.Checked = (usewidth > -1);
                    usewidth = (this.cbFixedWidth.Checked) ? usewidth : GeneralConst.PASTE_VIEW_DEFAULT_FIXEDWIDTH;
                    this.tbColWidth.Text = usewidth.ToString();
                }

                if (this.GlobalOptions.Count > 5)
                {
                    this.cbShowSelector.Checked  = (bool)this.GlobalOptions[5];
                }

                if (this.GlobalOptions.Count > 6)
                {
                    stylename = this.GlobalOptions[6].ToString();
                }

                this.setCombo();

                try
                {
                    this.cbDataMode.SelectedItem = datamode;
                    this.comboConnList.SetItem(host, db);

                    switch (cubetyp)
                    {
                        case CubeType.NormalCube:
                        case CubeType.GpuCube:
                            do_btnFilter(GeneralConst.FILTER_DATA);
                            break;

                        case CubeType.AttributeCube:
                            do_btnFilter(GeneralConst.FILTER_ATTRIBUTE);
                            break;

                        case CubeType.SystemCube:
                            do_btnFilter(GeneralConst.FILTER_USER);
                            break;
                    };

                    this.cbCubes.SelectedItem = cube;

                    tcClear();
                    this.SelectedElements.Clear();
                    this.ButtonNames.Clear();

                    AddPageNodes(pages);
                    AddRowNodes(rows);
                    AddColNodes(cols);
                }
                catch (Exception err1)
                {
                    Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Major error in FrmPasteView", err1);
                }
            }
            else
            {
                this.setCombo();
                this.preselectComboConnList();
                cbCubes.SetItem(RegUtils.ActiveCube);
            }
            this.cbZeroSupresionVisible();
            this.FillStyleList(stylename);
        }

        #endregion

        #region Add{Page,Row,Col}Nodes

        private void AddPageNodes(ArrayList pages)
        {
            ArrayList elements;
            object[] element;
            string dimName, displayName;
            JNode n;
            DimDescription desc;
            foreach (object[] pageDim in pages)
            {
                elements = (ArrayList)pageDim[3];
                dimName = (string)pageDim[2];
                element = (object[])elements[0];
                displayName = dimName;
                if (element.Length > 3)
                {
                    displayName = (string)element[3];
                }

                n = CreateGroupNode(dimName, SelectedElements.Count);
                desc = ((JNode)n).Tag as DimDescription;
                desc.Attribute = (string)pageDim[6];
                desc.SingleElement = elements;
                AddSubsets(n);

                SelectedElements.Add(new object[] { dimName, elements });
                ButtonNames.Add(dimName);

                AdjustNodeForControl(n, tcPageSelector);              
                tcPageSelector.Nodes.Add(n);
            }
        }

        private void AddRowNodes(ArrayList rows)
        {
            ArrayList elements;
            string dimName, displayName;
            object[] element;
            JNode n;
            DimDescription desc;

            foreach (object[] rowDim in rows)
            {
                elements = (ArrayList)rowDim[3];
                dimName = (string)rowDim[2];
                element = (object[])elements[0];
                displayName = dimName;
                if (element.Length > 3)
                {
                    displayName = (string)element[3];
                }

                n = CreateGroupNode(dimName, SelectedElements.Count);
                desc = n.Tag as DimDescription;
                desc.Attribute = (string)rowDim[6];
                desc.MultipleElements = elements;
                AddSubsets(n);

                SelectedElements.Add(new object[] { dimName, elements });
                ButtonNames.Add(dimName);

                AdjustNodeForControl(n, tcRows);
                // Again, reverse order:                
                tcRows.Nodes.Insert(0,n);
            }
        }

        private void AddColNodes(ArrayList cols)
        {
            ArrayList elements;
            string dimName, displayName;
            object[] element;
            JNode n;
            DimDescription desc;
            foreach (object[] colDim in cols)
            {
                elements = (ArrayList)colDim[3];
                dimName = (string)colDim[2];
                element = (object[])elements[0];
                displayName = dimName;
                if (element.Length > 3)
                {
                    displayName = (string)element[3];
                }

                n = CreateGroupNode(dimName, SelectedElements.Count);
                desc = n.Tag as DimDescription;
                desc.Attribute = (string)colDim[6];
                desc.MultipleElements = elements;
                AddSubsets(n);

                SelectedElements.Add(new object[] { dimName, elements });
                ButtonNames.Add(dimName);

                AdjustNodeForControl(n, tcColumns);
                // Again, reverse order:                
                tcColumns.Nodes.Insert(0, n);
            }
        }

        #endregion

        #region ChangeTableOnly

        public void DrawTableOnly()
        {
            this.ChangeTableOnly = true;
        }

        #endregion

        public bool EditDimensionNode(string dim, string dimelement, string pfad, string Attribute)
        {
            this.SetFromCurrentState();

            if (this.view_exists)
            {
                try
                {
                    foreach (JNode n in ColDims)
                    {
                        if (((DimDescription)n.Tag).Name == dim)
                        {
                            ChooseMultipleElements(n, dimelement, pfad);
                            break;
                        }
                    }
                }
                catch
                { }

                try
                {
                    foreach (JNode n in RowDims)
                    {
                        if (((DimDescription)n.Tag).Name == dim)
                        {
                            ChooseMultipleElements(n, dimelement, pfad);
                            break;
                        }
                    }
                }
                catch
                { }

                if (this.returnValue)
                {
                    this.do_btPaste_Click();
                }

                return this.returnValue;
            }
            return false;
        }

        #endregion

        void do_cbZeroSuppression_Checked()
        {
            this.cbZeroSuppressionAlsoCalculatedNull.Visible = this.cbZeroSuppression.Checked;
        }

        private void cbZeroSuppression_CheckedChanged(object sender, System.EventArgs e)
        {
            this.do_cbZeroSuppression_Checked();
        }

        private void FrmPasteView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.saveSettings();
        }
    }
}
