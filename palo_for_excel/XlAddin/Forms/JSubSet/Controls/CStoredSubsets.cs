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
//  JMM 10-21-15 fixed err adding new subset

using System;
using System.Windows.Forms;
//using Crownwood.DotNetMagic.Controls;
using System.ComponentModel;
using JControls;
using Apalo.XlAddin.Utils;
using Apalo.XlAddin.Forms;

namespace Apalo.XlAddin.JSubSet.Controls
{
    public partial class CStoredSubsets : UserControl
    {
        private TreeNode defaultGroupNode;
        private TreeNode currentGroupNode;
        private TreeNode loadedSubsetNode;
        private TreeNode loadedSubsetGroup;
        private EditorType editorType;
        private string originalSubsetName;

        private bool isEditing = false;
        private bool isRenaming = false;
        // true when we're renaming an item,
        // false when we're creating a new one
        
        //  JMM 2015-10-21
        //  New subset is being added:
        public bool IsNewSubset {get; private set;}

        public JControls.JButton BTAdd
        {
            get { return btAdd; }
        }

        public JControls.JButton BTRename
        {
            get { return btEdit; }
        }

        public JControls.JButton BTRemove
        {
            get { return btRemove; }
        }

        public CStoredSubsets()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Opening += new CancelEventHandler(cmsOpening);
            cms.Items.Add(SubsetHelper.GetI18String("Add", "SB_"), imlList.Images[1]);
            cms.Items[0].Click += new EventHandler(addSubset_Chosen);
            //TODO:
            //tcSubsets.ContextMenuSpace = cms;

            ContextMenuStrip cmsNode = new ContextMenuStrip();
            cmsNode.Opening += new CancelEventHandler(cmsOpening);
            cmsNode.Items.Add(SubsetHelper.GetI18String("Add", "SB_"), imlList.Images[1]);
            cmsNode.Items[0].Click += new EventHandler(addSubset_Chosen);
            cmsNode.Items.Add(SubsetHelper.GetI18String("Delete", "SB_"), imlList.Images[2]);
            cmsNode.Items[1].Click += new EventHandler(deleteSubset_Chosen);
            cmsNode.Items.Add(SubsetHelper.GetI18String("Rename", "SB_"), imlList.Images[3]);
            cmsNode.Items[2].Click += new EventHandler(renameSubset_Chosen);
            //TODO:
            //tcSubsets.ContextMenuNode = cmsNode;

            btEdit.Enabled = (tcSubsets.SelectedNode != null);
            btRemove.Enabled = (tcSubsets.SelectedNode != null);
            
            tcSubsets.LabelEdit = true;
            tcSubsets.BeforeLabelEdit += new NodeLabelEditEventHandler(tcSubsets_BeforeLabelEdit);
            tcSubsets.AfterLabelEdit += new NodeLabelEditEventHandler(tcSubsets_AfterLabelEdit);
            tcSubsets.AfterExpand += new TreeViewEventHandler(tcSubsets_AfterExpand);

            //this.tcSubsets.GroupColoring = GroupColoring.ControlProperties;
            //this.tcSubsets.GroupBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            //this.tcSubsets.GroupSelectedBackColor = Utils.ResourceInitializer.FormStdHighLightColor;
            //this.tcSubsets.GroupSelectedNoFocusBackColor = this.tcSubsets.GroupSelectedBackColor;
            //this.tcSubsets.GroupFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }


        private TreeNodeCollection NodesOfType(SubsetType type)
        {
            foreach (TreeNode n in tcSubsets.Nodes)
            {
                if ((SubsetType)n.Tag == type)
                {
                    return n.Nodes;
                }
            }

            return null;
        }

        public void AddStoredSubSet(string subsetName, SubsetType type)
        {
            TreeNodeCollection parentNodes = NodesOfType(type);
            if (parentNodes != null)
            {
                // JMM 09-17-13
                JNode n = new JNode();                
                n.Name = n.Text = subsetName;
                n.ImageIndex = 0;
                parentNodes.Add(n);
            }
                  
        }

        public void SelectNode(string Name, SubsetType type)
        {
            TreeNodeCollection parentNodes = NodesOfType(type);
            if ( parentNodes != null )
            {
                foreach ( JNode node in parentNodes )
                {
                    if ((node.Text == Name) && node.Name != null && node.Name == Name)
                    {
                        node.Select(true);
                    }
                }
            }

        }

        public void ClearNodesOfType(SubsetType type)
        {
            NodesOfType(type).Clear();
        }

        private JNode SubsetGroupNode(string text, SubsetType type)
        {
            // JMM 09-17-13
            JNode n = new JNode(text);            
            //n.ExpandedChanged += new EventHandler(SetGroupAsCurrent);
            n.ImageIndex = -1;
            n.Tag = (int)type;

            return n;
        }

        private void tcSubsets_AfterExpand(object sender, TreeViewEventArgs e)
            {
            if (e.Node.Parent == null)
                SetGroupAsCurrent(e.Node, e);
            }

        private void SetGroupAsCurrent(object groupNode, EventArgs e)
        {
            if ((groupNode as JNode).IsExpanded)
                currentGroupNode = groupNode as JNode;
        }

        private void SetGlobalEditor()
        {
            //tcSubsets.ClearNodes();
            tcSubsets.Nodes.Clear();

            string title = SubsetHelper.GetI18String("Global Subsets", "SB_");
            tcSubsets.Nodes.Add(SubsetGroupNode(title, SubsetType.Global));
            
            currentGroupNode = defaultGroupNode = tcSubsets.Nodes[0];
            defaultGroupNode.ExpandAll();
        }

        private void SetLocalEditor()
        {
            //tcSubsets.ClearNodes();
            tcSubsets.Nodes.Clear();
            string title = SubsetHelper.GetI18String("Formula Subset", "SB_");
            tcSubsets.Nodes.Add(SubsetGroupNode(title, SubsetType.Formula));
                tcSubsets.Nodes[0].Nodes.Add(new JNode("[" + title + "]"));
                
            title = SubsetHelper.GetI18String("Local Subsets", "SB_");
            tcSubsets.Nodes.Add(SubsetGroupNode(title, SubsetType.Local));
            
            title = SubsetHelper.GetI18String("Global Subsets", "SB_");
            tcSubsets.Nodes.Add(SubsetGroupNode(title, SubsetType.Global));

            defaultGroupNode = tcSubsets.Nodes[0];
            defaultGroupNode.ExpandAll();
            //tcSubsets.SelectNode(defaultGroupNode.Nodes[0]);
            tcSubsets.SelectedNode = defaultGroupNode.Nodes[0];
        }

        public EditorType EditorType
        {
            get { return editorType; }
            set
            {
                editorType = value;

                if (value == EditorType.GlobalOnly)
                    SetGlobalEditor();
                else
                    SetLocalEditor();               
            }
        }

        public void SelectFormulaSubset()
        {
            if ((tcSubsets.Nodes.Count > 0) && (tcSubsets.Nodes[0].Nodes.Count > 0))
            {
                tcSubsets.SelectedNode = tcSubsets.Nodes[0].Nodes[0];
            }
        }

        public SubsetType SelectedSubsetType
        {
            get { return currentGroupNode == null ? (SubsetType)defaultGroupNode.Tag : (SubsetType)currentGroupNode.Tag; }
        }

        public TreeNode LoadedSubsetNode
        {
            get { return loadedSubsetNode; }
            set { loadedSubsetNode = value; }
        }

        public TreeNode LoadedSubsetGroup
        {
            get { return loadedSubsetGroup; }
            set { loadedSubsetGroup = value; }
        }

        public SubsetType LoadedSubsetType
        {
            get 
            {
                try
                {
                    return (SubsetType)LoadedSubsetGroup.Tag;
                }
                catch
                {
                    return SubsetType.Local;
                }
            }
        }

        private bool GroupContainsSubset(TreeNode group, String subsetName)
        {
            foreach (TreeNode n in group.Nodes)
                if (n.Text == subsetName) return true;
            return false;
        }

        private bool IsSubsetSelected()
        {
            return (tcSubsets.SelectedNode != null && tcSubsets.SelectedNode.Parent != null);
        }

        //
        // Handle keys: 
        //          DELETE (delete Subset)
        //          ENTER (create new subset / finish susbet editing)
        //
        private void tcSubsets_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (SelectedSubsetType == SubsetType.Formula) return;
                    if (!this.isEditing)
                    {
                        addSubset_Chosen(sender, e);
                        e.Handled = true;
                    }
                    else
                    {
                        this.isEditing = false;
                    }
                    break;

                case Keys.Delete:
                    if (SelectedSubsetType == SubsetType.Formula)
                    {
                        return;
                    }
                    if ((tcSubsets.SelectedNode != null) && (tcSubsets.SelectedNode.Parent is JNode))
                    {
                        this.isEditing = true;
                        deleteSubset_Chosen(sender, e);
                    }
                    break;
            }
        }

        #region Add/Remove/Rename handlers
        
        private DialogResult SafelyAskForSave()
        {
            if (Common.CurrentASubset == null)
            {
                return DialogResult.No;
            }
            else
            {
                return Common.CurrentASubset.SubsetEditor.AskAndSaveChangesIfNeeded();
            }
        }

        private void RollbackLoadedSubset()
        {
            try
            {
                LoadedSubsetGroup.ExpandAll();
                tcSubsets.SelectedNode = LoadedSubsetNode;
            }
            catch { }
        }

        private void loadSubset_Chosen()
        {
            if (SafelyAskForSave() == DialogResult.Cancel)
            {
                RollbackLoadedSubset();
                return;
            }

            LoadedSubsetNode = tcSubsets.SelectedNode;
            LoadedSubsetGroup = tcSubsets.SelectedNode.Parent;

            Common.CurrentASubset.SubsetEditor.LoadSubset(LoadedSubsetNode.Text, SelectedSubsetType);
        }

        private void addSubset_Chosen(object sender, EventArgs e)
        {
            if (SafelyAskForSave() == DialogResult.Cancel)
            {
                RollbackLoadedSubset();
                return;
            }
            tcSubsets.SelectedNode = null;

            String key = "New Subset";
            JNode n = new JNode(key);
            n.ImageIndex = 0;
            int i = 0;
            while (GroupContainsSubset(currentGroupNode, n.Text))
                n.Text = key + " (" + (++i) + ")";

            IsNewSubset = true;
            this.currentGroupNode.Nodes.Add(n);
            this.currentGroupNode.Expand();
            tcSubsets.SelectedNode = n;
            Common.CurrentASubset.SubsetEditor.SetDefault();
            n.BeginEdit();
            // Real save work happens on AfterLabelEdit
        }

        private void renameSubset_Chosen(object sender, EventArgs e)
        {
            //if (SafelyAskForSave() == DialogResult.Cancel)
            //{
            //    RollbackLoadedSubset();
            //    return;
            //}

            this.isRenaming = true;
            this.originalSubsetName = tcSubsets.SelectedNode.Text;
            tcSubsets.SelectedNode.BeginEdit();
            // Real rename work happens on firing AfterLabelEdit event.
        }

        private void deleteSubset_Chosen(object sender, EventArgs e)
        {
            if (tcSubsets.SelectedNode == null) return;

            JNode sn = (JNode)tcSubsets.SelectedNode;
            String name = sn.Text;
            SubsetType st = SelectedSubsetType;

            if (SubsetUtils.ConfirmSubsetDelete(name))
            {
                if (Common.CurrentASubset.SubsetEditor.DeleteSubset(name, st))
                {
                    tcSubsets.SelectedNode.Remove();
                }

                if (!IsSubsetSelected())
                {
                    this.SelectFormulaSubset();
                }
            }
        }
        
        private void tcSubsets_BeforeLabelEdit(object sender, EventArgs e)
        {
            this.isEditing = true;
        }

        private void tcSubsets_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            IsNewSubset = false;
            if (this.isRenaming)
            {
                if (Common.CurrentASubset.SubsetEditor.RenameSubset(originalSubsetName, e.Label))
                {
                    e.Node.Text = e.Label;
                    tcSubsets.SelectedNode = e.Node;
                }
                else
                    e.CancelEdit = true;

                this.isRenaming = false;
            }
            else // Saving existing subset, or adding a new one
            {
                if (Common.CurrentASubset.SubsetEditor.SaveSubset(e.Label, SelectedSubsetType))
                {
                    e.Node.Text = e.Label;
                    tcSubsets.SelectedNode = e.Node;
                }
                else
                    e.Node.Remove();
            }

            e.CancelEdit = true;
            // We are not resetting isEditing, because of required Enter behavior.
        }
        #endregion

        private void tcSubsets_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btEdit.Enabled = IsSubsetSelected() && (SelectedSubsetType != SubsetType.Formula);
            btRemove.Enabled = IsSubsetSelected() && (SelectedSubsetType != SubsetType.Formula);
            btAdd.Enabled = (SelectedSubsetType != SubsetType.Formula);

            if (IsSubsetSelected() && e.Node != LoadedSubsetNode)
                loadSubset_Chosen();
        }

        private void cmsOpening(object sender, CancelEventArgs e)
        {
            if (SelectedSubsetType == SubsetType.Formula)
                e.Cancel = true;
        }

        private void tcSubsets_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
        }

        private void tcSubsets_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
        }
    }
}
