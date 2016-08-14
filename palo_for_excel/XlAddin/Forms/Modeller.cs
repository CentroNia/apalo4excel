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
 * this program; if not, write to the Free Software Foundation, Inthis.currConn., 59 Temple
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
//  JMM 09-01-15 Updates to connection function calls for 5.1 compatability
//  JMM 01-26-15 Correct out of memory issue in TreeView
//  JMM 05-07-14 Allow default w/o template
//  JMM 03-20-14 replaced DotNetMagic TabControl with .NET TabControl
//  JMM 03-20-14 replaced DotNetMagic TreeControl with MultiSelectTreeView
//  JMM 09-17-13 DimensionListDimElements is now DimensionListElements

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using JControls;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Forms.Controls;
using Apalo.XlAddin.Utils;
//using JNode = System.Windows.Forms.TreeNode;

namespace Apalo.XlAddin.Forms
{
    [ComVisible(false)] 
    public class Modeller : System.Windows.Forms.Form
    {
        #region TabTagObject
        private class TabTagObject
        {
            public String DimName;
            public String AttributeDimName;

            public TabTagObject(String dim, String AttributeDimnName)
            {
                DimName = dim;
                AttributeDimName = AttributeDimnName;
            }
        }
        #endregion

        private const string GroupDimensionName = "#_GROUP_";
        private const string UserDimensionName = "#_USER_";
        private const string RoleDimensionName = "#_ROLE_";

        #region Define Vars
        private CultureInfo originalCulture;
        private JNode StartNode;
        private JNode TargetNode;
        private int formX;
        private int formY;
        private ConnComboBox comboConnList;
        private bool EditUsersState;
        private bool ActivateCubeBtn;
        private string olddim = "";
        private string oldactivedb = ""; // for state change
        private bool ShowSystemCubes = false;
        private string ReadingMessage = "";
        private bool TabsAreCleared = false;
        private bool DontExcuteAfterLabelEdit = false;

        private Font boldFont;
        private Font regularFont;
        private Hashtable ConsolidatedElements;
        
        private System.ComponentModel.IContainer components;
        private bool InElementchange = false;

        private Connection currConn = null;
        private string currHostname;
        private string currDb;
        private string currCube;
        private string currDimension;

        private ClearCube ccw = null;
        private int oldIndex;
        private string oldCube;

        private JNode currElementNode;
        private JNode cElementNode;
        private int cElementNodeIndex;
        private bool nfoAddDataAxis;
        private bool nfoAddElement;
        
        private int CurrentExpandState;
        private bool DoCopyNode;

        #region TreeViewNoBeep
        private class TreeViewNoBeep : TreeView
        {
            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                if(e.KeyChar == (int)System.Windows.Forms.Keys.Return || e.KeyChar == (int)System.Windows.Forms.Keys.Escape || e.KeyChar == (int)System.Windows.Forms.Keys.Delete)
                    e.Handled = true;
                else
                    base.OnKeyPress(e);
            }
        }
        #endregion

        private JButton btnConnAdd;
        private JTabPage tabSettings;
        private int OldPageindex;
        private JButton btnConnToggle;         
        private System.Windows.Forms.Button btnClose;
        private Modeller.TreeViewNoBeep treeViewDims;
        private TreeView treeViewCubes;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.Label lblCubes;
        private JTabControl tabMain;
        private JButton btnDimensionAdd;
        private JButton btnDimensionRename;
        private JButton btnDimensionRemove;

        private JButton btnCubeAdd;
        private JButton btnCubeRemove;
        private JTabPage cTab;

        #region Edit DataAxis Elements
        private System.Windows.Forms.Label lblConsolidatedElements = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label lblElements = new System.Windows.Forms.Label();
        private JTreeView treeElements = new JTreeView();
        private ListView treeSourceElements;
        
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

        private JButton btnLeft = new JButton();
        private JButton btnRight = new JButton();
        private JButton btnUp = new JButton();
        private JButton btnDown = new JButton();

        private JButton btnElementAdd = new JButton();
        private JButton btnElementRemove = new JButton();
        private JButton btnElementRename = new JButton();
        private JButton btnElementEdit = new JButton();

        private JButton btnElementCancelChanges = new JButton();
        private JButton btnElementApplyChanges = new JButton();

        //private JButton xpEditDataAxis;
        private System.Windows.Forms.CheckBox chkFactor;
        private System.Windows.Forms.CheckBox chkTree;
        private System.Windows.Forms.Button btnHome;
        
        private ToolStripMenuItem cmdAddN;
        private ToolStripMenuItem cmdDel;
        private ToolStripMenuItem cmdEdit;
        private ToolStripMenuItem cmdRen;
        private ToolStripMenuItem cmdShowParents;
        private ContextMenuStrip elemCmdMenu;
        private ToolStripSeparator separator2;
        private ToolStripMenuItem cmdNumeric;
        private ToolStripMenuItem cmdString;
        private ContextMenuStrip srcElemCmdMenu;
        private ToolStripMenuItem cmdFactor;
        private ToolStripMenuItem cmdDelSrcElem;
        private ContextMenuStrip dimCmdMenu;
        private ToolStripMenuItem cmdNewDim;
        private ToolStripMenuItem cmdDelDim;
        private ToolStripMenuItem cmdRenDim;
        private ToolStripMenuItem cmdEditDim;
        private ContextMenuStrip cubeCmdMenu;
        private ToolStripMenuItem cmdDelCube;
        private ToolStripMenuItem cmdAddCube;
        private ContextMenuStrip cubeDimCmdMenu;
        private ToolStripMenuItem cmdMeasure;
        private ToolStripMenuItem cmdTime;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripSeparator separator3;
        private ToolStripMenuItem cmdElemCopy;
        private ToolStripMenuItem cmdElemPaste;
        private ToolStripMenuItem cmdClearCube;
        private ToolStripMenuItem cmdElemSelectAll;
        private ToolStripSeparator separator1;
        private ToolStripMenuItem cmdCountElements;
        private ToolStripMenuItem cmdChild;
        private ContextMenuStrip ChildSibling;
        private ToolStripMenuItem cmdSibling;
        private System.Windows.Forms.Label labelChooseServer;
        private ToolStripMenuItem cmdExportCube;
        private ToolStripMenuItem cmdSVSWizard;
        private ContextMenuStrip tabCmdMenu;
        private ToolStripMenuItem cmdTabDatabase;

        #endregion

        #region Expand/Collapse

        private JButton btnExpandAll;       
        private JButton btnCollapseAll;
        private JButton btnCollapse;
        private JButton btnExpand;
        private JButton btnExp1;
        private JButton btnExp2;
        private JButton btnExp3;
        private JButton btnExp4;
        private JButton btnExp5;
        private JButton btnExp6;
        private JButton btnExp7;
        private JButton btnExp8;
        private ContextMenuStrip ChildSiblingCopy;
        private ToolStripMenuItem cmdChildCopy;
        private ToolStripMenuItem cmdSiblingCopy;
        private ToolStripSeparator separator4;
        private ToolStripMenuItem cmdElementMoveBegin;
        private ToolStripMenuItem cmdElementMoveEnd;
        private ToolStripSeparator commandBarSeparatorItem1;
        private ToolStripMenuItem cmdSrcElementMoveBegin;
        private ToolStripMenuItem cmdSrcElementMoveEnd;
        private ToolStripMenuItem cmdSearchElements;
        
        private JButton btnDataManagment;
        private JButton btnAttributeManagment;
        private JButton btnUserManagment;
        private Button btnOrigDims;
        private Button btnAscDims;
        private Button btnDescDims;
        private Button btnOrigElems;
        private Button btnAscElems;
        private Button btnDescElems;

        private ToolStripMenuItem cmdRuleEditor;
        private int max_exp_level;

        private ToolStripMenuItem cmdCubeInfo;
        private ToolStripSeparator commandBarSeparatorItem2;
        private JButton btnRuleEditor;
        private ToolStripSeparator commandBarSeparatorItem3;
        private ToolStripMenuItem cmdDimInfo;
        private ToolStripSeparator commandBarSeparatorItem4;
        private ToolStripMenuItem cmdDimExport;
        private ToolStripMenuItem cmdCubeRename;
        private ToolStripSeparator commandBarSeparatorItem6;
        private ToolStripSeparator commandBarSeparatorItem5;
        private ToolStripSeparator commandBarSeparatorItem7;
        private ToolStripSeparator commandBarSeparatorItem8;
        private ToolStripSeparator commandBarSeparatorItem9;
        private ToolStripMenuItem cmdSubSetEditor;
        private JControls.JComboBox cmbElementType;
        private ContextMenuStrip mnuSubSet;
        private ToolStripMenuItem cmdAddSubset;
        private ToolStripMenuItem cmdRemoveSubset;
        private ToolStripMenuItem cmdEditSubset;
        private JButton btnEnableTree;
        private ToolStripMenuItem cmdCubeConvert;
        private ImageList imgListElements;
        private Button btnToggleSystemCubes;

        private byte CubeViewStatus; 

        #endregion

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modeller));
            this.btnConnAdd = new JControls.JButton();
            this.tabMain = new JTabControl();
            this.tabSettings = new JTabPage();
            this.btnToggleSystemCubes = new System.Windows.Forms.Button();
            this.btnRuleEditor = new JControls.JButton();
            this.btnAttributeManagment = new JControls.JButton();
            this.btnUserManagment = new JControls.JButton();
            this.btnDataManagment = new JControls.JButton();
            this.btnOrigDims = new System.Windows.Forms.Button();
            this.btnAscDims = new System.Windows.Forms.Button();
            this.btnDescDims = new System.Windows.Forms.Button();
            this.labelChooseServer = new System.Windows.Forms.Label();
            this.lblCubes = new System.Windows.Forms.Label();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.btnConnToggle = new JControls.JButton();
            this.treeViewDims = new Apalo.XlAddin.Forms.Modeller.TreeViewNoBeep();
            this.treeViewCubes = new System.Windows.Forms.TreeView();
            this.btnDimensionAdd = new JControls.JButton();
            this.btnDimensionRename = new JControls.JButton();
            this.btnDimensionRemove = new JControls.JButton();
            this.btnCubeAdd = new JControls.JButton();
            this.btnCubeRemove = new JControls.JButton();
            this.btnOrigElems = new System.Windows.Forms.Button();
            this.btnAscElems = new System.Windows.Forms.Button();
            this.btnDescElems = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.cmbElementType = new JControls.JComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.elemCmdMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdAddN = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRen = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdNumeric = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdString = new System.Windows.Forms.ToolStripMenuItem();
            this.separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdElemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdElemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdElemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdElementMoveBegin = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdElementMoveEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdCountElements = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSearchElements = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdShowParents = new System.Windows.Forms.ToolStripMenuItem();
            this.srcElemCmdMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdFactor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDelSrcElem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandBarSeparatorItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdSrcElementMoveBegin = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSrcElementMoveEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.dimCmdMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdNewDim = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDelDim = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRenDim = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdEditDim = new System.Windows.Forms.ToolStripMenuItem();
            this.commandBarSeparatorItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.commandBarSeparatorItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.commandBarSeparatorItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdDimExport = new System.Windows.Forms.ToolStripMenuItem();
            this.commandBarSeparatorItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdDimInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSubSetEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.commandBarSeparatorItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.cubeCmdMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdAddCube = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDelCube = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCubeRename = new System.Windows.Forms.ToolStripMenuItem();
            this.commandBarSeparatorItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdClearCube = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdExportCube = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSVSWizard = new System.Windows.Forms.ToolStripMenuItem();
            this.commandBarSeparatorItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdRuleEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.commandBarSeparatorItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdCubeInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCubeConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeDimCmdMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdMeasure = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCmdMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdTabDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnExpandAll = new JControls.JButton();
            this.btnCollapseAll = new JControls.JButton();
            this.btnExpand = new JControls.JButton();
            this.btnCollapse = new JControls.JButton();
            this.btnExp1 = new JControls.JButton();
            this.btnExp2 = new JControls.JButton();
            this.btnExp3 = new JControls.JButton();
            this.btnExp4 = new JControls.JButton();
            this.btnExp5 = new JControls.JButton();
            this.btnExp6 = new JControls.JButton();
            this.btnExp7 = new JControls.JButton();
            this.btnExp8 = new JControls.JButton();
            this.ChildSibling = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdChild = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSibling = new System.Windows.Forms.ToolStripMenuItem();
            this.ChildSiblingCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdChildCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSiblingCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSubSet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdAddSubset = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRemoveSubset = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdEditSubset = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEnableTree = new JControls.JButton();
            this.imgListElements = new System.Windows.Forms.ImageList(this.components);
            this.tabMain.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.elemCmdMenu.SuspendLayout();
            this.srcElemCmdMenu.SuspendLayout();
            this.dimCmdMenu.SuspendLayout();
            this.cubeCmdMenu.SuspendLayout();
            this.cubeDimCmdMenu.SuspendLayout();
            this.tabCmdMenu.SuspendLayout();
            this.ChildSibling.SuspendLayout();
            this.ChildSiblingCopy.SuspendLayout();
            this.mnuSubSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnAdd
            // 
            this.btnConnAdd.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnConnAdd.ButtonImage = null;
            this.btnConnAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnConnAdd.FlatAppearance.BorderSize = 0;
            this.btnConnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnConnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnConnAdd, "btnConnAdd");
            this.btnConnAdd.Name = "btnConnAdd";
            this.btnConnAdd.RolloverImage = null;
            this.btnConnAdd.Tag = "+";
            this.btnConnAdd.Click += new System.EventHandler(this.btnConnAdd_Click);
            // 
            // tabMain
            // 
            this.tabMain.AllowDrop = false;
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Dock = DockStyle.Fill;
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.TabPages.AddRange(new JTabPage[] {this.tabSettings});
            this.tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectionChanged);
            this.tabMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabMain_MouseUp);
            //CDNM only:
            //this.tabMain.AllowDragReorder = false;
            //this.tabMain.IDE2005HeaderBorder = true;
            //this.tabMain.IDE2005PixelBorder = false;
            //this.tabMain.IDE2005Style = Crownwood.DotNetMagic.Controls.IDE2005Style.StandardDark;
            //this.tabMain.OfficeDockSides = false;
            //this.tabMain.OfficeStyle = Crownwood.DotNetMagic.Controls.OfficeStyle.Light;
            //this.tabMain.PositionTop = true;
            //this.tabMain.ShowDropSelect = false;
            //this.tabMain.ShrinkPagesToFit = false;
            //this.tabMain.Style = Crownwood.DotNetMagic.Common.VisualStyle.IDE2005;
            //this.tabMain.TextTips = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.btnToggleSystemCubes);
            this.tabSettings.Controls.Add(this.btnRuleEditor);
            this.tabSettings.Controls.Add(this.btnAttributeManagment);
            this.tabSettings.Controls.Add(this.btnUserManagment);
            this.tabSettings.Controls.Add(this.btnDataManagment);
            this.tabSettings.Controls.Add(this.btnOrigDims);
            this.tabSettings.Controls.Add(this.btnAscDims);
            this.tabSettings.Controls.Add(this.btnDescDims);
            this.tabSettings.Controls.Add(this.labelChooseServer);
            this.tabSettings.Controls.Add(this.lblCubes);
            this.tabSettings.Controls.Add(this.lblDimensions);
            this.tabSettings.Controls.Add(this.btnConnToggle);
            this.tabSettings.Controls.Add(this.btnConnAdd);
            this.tabSettings.Controls.Add(this.treeViewDims);
            this.tabSettings.Controls.Add(this.treeViewCubes);
            this.tabSettings.Controls.Add(this.btnDimensionAdd);
            this.tabSettings.Controls.Add(this.btnDimensionRename);
            this.tabSettings.Controls.Add(this.btnDimensionRemove);
            this.tabSettings.Controls.Add(this.btnCubeAdd);
            this.tabSettings.Controls.Add(this.btnCubeRemove);
            //this.tabSettings.InactiveBackColor = System.Drawing.Color.Empty;
            //this.tabSettings.InactiveTextBackColor = System.Drawing.Color.Empty;
            //this.tabSettings.InactiveTextColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Name = "tabSettings";
            //this.tabSettings.SelectBackColor = System.Drawing.Color.Empty;
            //this.tabSettings.SelectTextBackColor = System.Drawing.Color.Empty;
            //this.tabSettings.SelectTextColor = System.Drawing.Color.Empty;
            // 
            // btnToggleSystemCubes
            // 
            this.btnToggleSystemCubes.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.btnToggleSystemCubes, "btnToggleSystemCubes");
            this.btnToggleSystemCubes.Name = "btnToggleSystemCubes";
            this.btnToggleSystemCubes.UseVisualStyleBackColor = true;
            // 
            // btnRuleEditor
            // 
            this.btnRuleEditor.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnRuleEditor.ButtonImage = null;
            this.btnRuleEditor.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnRuleEditor.FlatAppearance.BorderSize = 0;
            this.btnRuleEditor.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnRuleEditor.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnRuleEditor, "btnRuleEditor");
            this.btnRuleEditor.Name = "btnRuleEditor";
            this.btnRuleEditor.RolloverImage = null;
            this.btnRuleEditor.UseVisualStyleBackColor = true;
            this.btnRuleEditor.Click += new System.EventHandler(this.btnRuleEditor_Click);
            // 
            // btnAttributeManagment
            // 
            this.btnAttributeManagment.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnAttributeManagment.ButtonImage = null;
            this.btnAttributeManagment.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnAttributeManagment.FlatAppearance.BorderSize = 0;
            this.btnAttributeManagment.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnAttributeManagment.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnAttributeManagment, "btnAttributeManagment");
            this.btnAttributeManagment.Name = "btnAttributeManagment";
            this.btnAttributeManagment.RolloverImage = null;
            this.btnAttributeManagment.UseVisualStyleBackColor = true;
            // 
            // btnUserManagment
            // 
            this.btnUserManagment.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnUserManagment.ButtonImage = null;
            this.btnUserManagment.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnUserManagment.FlatAppearance.BorderSize = 0;
            this.btnUserManagment.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnUserManagment.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnUserManagment, "btnUserManagment");
            this.btnUserManagment.Name = "btnUserManagment";
            this.btnUserManagment.RolloverImage = null;
            this.btnUserManagment.UseVisualStyleBackColor = true;
            this.btnUserManagment.Click += new System.EventHandler(this.btnUserManagment_Click);
            // 
            // btnDataManagment
            // 
            this.btnDataManagment.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnDataManagment.ButtonImage = null;
            this.btnDataManagment.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDataManagment.FlatAppearance.BorderSize = 0;
            this.btnDataManagment.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnDataManagment.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnDataManagment, "btnDataManagment");
            this.btnDataManagment.Name = "btnDataManagment";
            this.btnDataManagment.RolloverImage = null;
            this.btnDataManagment.UseVisualStyleBackColor = true;
            this.btnDataManagment.Click += new System.EventHandler(this.btnDataManagment_Click);
            // 
            // btnOrigDims
            // 
            this.btnOrigDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.btnOrigDims, "btnOrigDims");
            this.btnOrigDims.Name = "btnOrigDims";
            this.btnOrigDims.UseVisualStyleBackColor = true;
            this.btnOrigDims.Click += new System.EventHandler(this.btnOrigDims_Click);
            // 
            // btnAscDims
            // 
            this.btnAscDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.btnAscDims, "btnAscDims");
            this.btnAscDims.Name = "btnAscDims";
            this.btnAscDims.UseVisualStyleBackColor = true;
            this.btnAscDims.Click += new System.EventHandler(this.btnAscDims_Click);
            // 
            // btnDescDims
            // 
            this.btnDescDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.btnDescDims, "btnDescDims");
            this.btnDescDims.Name = "btnDescDims";
            this.btnDescDims.UseVisualStyleBackColor = true;
            this.btnDescDims.Click += new System.EventHandler(this.btnDescDims_Click);
            // 
            // labelChooseServer
            // 
            resources.ApplyResources(this.labelChooseServer, "labelChooseServer");
            this.labelChooseServer.Name = "labelChooseServer";
            // 
            // lblCubes
            // 
            resources.ApplyResources(this.lblCubes, "lblCubes");
            this.lblCubes.Name = "lblCubes";
            // 
            // lblDimensions
            // 
            resources.ApplyResources(this.lblDimensions, "lblDimensions");
            this.lblDimensions.Name = "lblDimensions";
            // 
            // btnConnToggle
            // 
            this.btnConnToggle.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnConnToggle.ButtonImage = null;
            this.btnConnToggle.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnConnToggle.FlatAppearance.BorderSize = 0;
            this.btnConnToggle.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnConnToggle.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnConnToggle, "btnConnToggle");
            this.btnConnToggle.Name = "btnConnToggle";
            this.btnConnToggle.RolloverImage = null;
            this.btnConnToggle.Click += new System.EventHandler(this.btnConnToggle_Click);
            // 
            // treeViewDims
            // 
            resources.ApplyResources(this.treeViewDims, "treeViewDims");
            this.treeViewDims.Name = "treeViewDims";
            // 
            // treeViewCubes
            // 
            this.treeViewCubes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.treeViewCubes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.treeViewCubes, "treeViewCubes");
            this.treeViewCubes.ItemHeight = 16;
            this.treeViewCubes.Name = "treeViewCubes";
            this.treeViewCubes.ShowPlusMinus = false;
            this.treeViewCubes.ShowRootLines = false;
            this.treeViewCubes.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewCubes_AfterLabelEdit);
            this.treeViewCubes.DoubleClick += new System.EventHandler(this.treeViewCubes_DoubleClick);
            this.treeViewCubes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewCubes_MouseUp);
            // 
            // btnDimensionAdd
            // 
            this.btnDimensionAdd.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnDimensionAdd.ButtonImage = null;
            this.btnDimensionAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDimensionAdd.FlatAppearance.BorderSize = 0;
            this.btnDimensionAdd.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnDimensionAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnDimensionAdd, "btnDimensionAdd");
            this.btnDimensionAdd.Name = "btnDimensionAdd";
            this.btnDimensionAdd.RolloverImage = null;
            this.btnDimensionAdd.UseVisualStyleBackColor = false;
            this.btnDimensionAdd.Click += new System.EventHandler(this.btnDimensionAdd_Click);
            // 
            // btnDimensionRename
            // 
            this.btnDimensionRename.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnDimensionRename.ButtonImage = null;
            this.btnDimensionRename.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDimensionRename.FlatAppearance.BorderSize = 0;
            this.btnDimensionRename.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnDimensionRename.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnDimensionRename, "btnDimensionRename");
            this.btnDimensionRename.Name = "btnDimensionRename";
            this.btnDimensionRename.RolloverImage = null;
            this.btnDimensionRename.UseVisualStyleBackColor = false;
            this.btnDimensionRename.Click += new System.EventHandler(this.btnDimensionRename_Click);
            // 
            // btnDimensionRemove
            // 
            this.btnDimensionRemove.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnDimensionRemove.ButtonImage = null;
            this.btnDimensionRemove.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDimensionRemove.FlatAppearance.BorderSize = 0;
            this.btnDimensionRemove.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnDimensionRemove.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnDimensionRemove, "btnDimensionRemove");
            this.btnDimensionRemove.Name = "btnDimensionRemove";
            this.btnDimensionRemove.RolloverImage = null;
            this.btnDimensionRemove.UseVisualStyleBackColor = false;
            this.btnDimensionRemove.Click += new System.EventHandler(this.btnDimensionRemove_Click);
            // 
            // btnCubeAdd
            // 
            this.btnCubeAdd.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnCubeAdd.ButtonImage = null;
            this.btnCubeAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCubeAdd.FlatAppearance.BorderSize = 0;
            this.btnCubeAdd.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnCubeAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCubeAdd, "btnCubeAdd");
            this.btnCubeAdd.Name = "btnCubeAdd";
            this.btnCubeAdd.RolloverImage = null;
            this.btnCubeAdd.UseVisualStyleBackColor = false;
            this.btnCubeAdd.Click += new System.EventHandler(this.btnCubeAdd_Click);
            // 
            // btnCubeRemove
            // 
            this.btnCubeRemove.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnCubeRemove.ButtonImage = null;
            this.btnCubeRemove.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCubeRemove.FlatAppearance.BorderSize = 0;
            this.btnCubeRemove.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnCubeRemove.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCubeRemove, "btnCubeRemove");
            this.btnCubeRemove.Name = "btnCubeRemove";
            this.btnCubeRemove.RolloverImage = null;
            this.btnCubeRemove.UseVisualStyleBackColor = false;
            this.btnCubeRemove.Click += new System.EventHandler(this.btnCubeRemove_Click);
            // 
            // btnOrigElems
            // 
            this.btnOrigElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.btnOrigElems, "btnOrigElems");
            this.btnOrigElems.Name = "btnOrigElems";
            this.btnOrigElems.UseVisualStyleBackColor = true;
            this.btnOrigElems.Click += new System.EventHandler(this.btnOrigElems_Click);
            // 
            // btnAscElems
            // 
            this.btnAscElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.btnAscElems, "btnAscElems");
            this.btnAscElems.Name = "btnAscElems";
            this.btnAscElems.UseVisualStyleBackColor = true;
            this.btnAscElems.Click += new System.EventHandler(this.btnAscElems_Click);
            // 
            // btnDescElems
            // 
            this.btnDescElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.btnDescElems, "btnDescElems");
            this.btnDescElems.Name = "btnDescElems";
            this.btnDescElems.UseVisualStyleBackColor = true;
            this.btnDescElems.Click += new System.EventHandler(this.btnDescElems_Click);
            // 
            // btnHome
            // 
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.Name = "btnHome";
            // 
            // cmbElementType
            // 
            this.cmbElementType.DisplayMember = "Text";
            this.cmbElementType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElementType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbElementType, "cmbElementType");
            this.cmbElementType.Name = "cmbElementType";
            this.cmbElementType.SelectedIndexChanged += new System.EventHandler(this.cmbElementType_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // elemCmdMenu
            // 
            this.elemCmdMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAddN,
            this.cmdDel,
            this.cmdRen,
            this.cmdEdit,
            this.separator2,
            this.cmdNumeric,
            this.cmdString,
            this.separator3,
            this.cmdElemCopy,
            this.cmdElemPaste,
            this.cmdElemSelectAll,
            this.separator4,
            this.cmdElementMoveBegin,
            this.cmdElementMoveEnd,
            this.separator1,
            this.cmdCountElements,
            this.cmdSearchElements,
            this.cmdShowParents});
            this.elemCmdMenu.Name = "elemCmdMenu";
            resources.ApplyResources(this.elemCmdMenu, "elemCmdMenu");
            // 
            // cmdAddN
            // 
            this.cmdAddN.Name = "cmdAddN";
            resources.ApplyResources(this.cmdAddN, "cmdAddN");
            this.cmdAddN.Text = null;
            this.cmdAddN.Click += new System.EventHandler(this.cmdAddN_Click);
            // 
            // cmdDel
            // 
            this.cmdDel.Name = "cmdDel";
            resources.ApplyResources(this.cmdDel, "cmdDel");
            this.cmdDel.Text = null;
            this.cmdDel.Click += new System.EventHandler(this.btnElementRemove_Click);
            // 
            // cmdRen
            // 
            this.cmdRen.Name = "cmdRen";
            resources.ApplyResources(this.cmdRen, "cmdRen");
            this.cmdRen.Text = null;
            this.cmdRen.Click += new System.EventHandler(this.btnElementRename_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Name = "cmdEdit";
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Text = null;
            this.cmdEdit.Click += new System.EventHandler(this.btnElementEdit_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            resources.ApplyResources(this.separator2, "separator2");
            // 
            // cmdNumeric
            // 
            this.cmdNumeric.Name = "cmdNumeric";
            resources.ApplyResources(this.cmdNumeric, "cmdNumeric");
            this.cmdNumeric.Text = null;
            this.cmdNumeric.Click += new System.EventHandler(this.cmdNumeric_Click);
            // 
            // cmdString
            // 
            this.cmdString.Name = "cmdString";
            resources.ApplyResources(this.cmdString, "cmdString");
            this.cmdString.Text = null;
            this.cmdString.Click += new System.EventHandler(this.cmdString_Click);
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            resources.ApplyResources(this.separator3, "separator3");
            // 
            // cmdElemCopy
            // 
            resources.ApplyResources(this.cmdElemCopy, "cmdElemCopy");
            this.cmdElemCopy.Name = "cmdElemCopy";
            this.cmdElemCopy.Text = null;
            this.cmdElemCopy.Click += new System.EventHandler(this.cmdElemCopy_Click);
            // 
            // cmdElemPaste
            // 
            resources.ApplyResources(this.cmdElemPaste, "cmdElemPaste");
            this.cmdElemPaste.Name = "cmdElemPaste";
            this.cmdElemPaste.Text = null;
            this.cmdElemPaste.Click += new System.EventHandler(this.cmdElemPaste_Click);
            // 
            // cmdElemSelectAll
            // 
            this.cmdElemSelectAll.Name = "cmdElemSelectAll";
            resources.ApplyResources(this.cmdElemSelectAll, "cmdElemSelectAll");
            this.cmdElemSelectAll.Text = null;
            this.cmdElemSelectAll.Click += new System.EventHandler(this.cmdElemSelectAll_Click);
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            resources.ApplyResources(this.separator4, "separator4");
            // 
            // cmdElementMoveBegin
            // 
            this.cmdElementMoveBegin.Name = "cmdElementMoveBegin";
            resources.ApplyResources(this.cmdElementMoveBegin, "cmdElementMoveBegin");
            this.cmdElementMoveBegin.Text = null;
            this.cmdElementMoveBegin.Click += new System.EventHandler(this.cmdElementMoveBegin_Click);
            // 
            // cmdElementMoveEnd
            // 
            this.cmdElementMoveEnd.Name = "cmdElementMoveEnd";
            resources.ApplyResources(this.cmdElementMoveEnd, "cmdElementMoveEnd");
            this.cmdElementMoveEnd.Text = null;
            this.cmdElementMoveEnd.Click += new System.EventHandler(this.cmdElementMoveEnd_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            resources.ApplyResources(this.separator1, "separator1");
            // 
            // cmdCountElements
            // 
            this.cmdCountElements.Name = "cmdCountElements";
            resources.ApplyResources(this.cmdCountElements, "cmdCountElements");
            this.cmdCountElements.Text = null;
            this.cmdCountElements.Click += new System.EventHandler(this.cmdCountElements_Click);
            // 
            // cmdSearchElements
            // 
            this.cmdSearchElements.Name = "cmdSearchElements";
            resources.ApplyResources(this.cmdSearchElements, "cmdSearchElements");
            this.cmdSearchElements.Text = null;
            this.cmdSearchElements.Click += new System.EventHandler(this.cmdSearchElements_Click);
            // 
            // cmdShowParents
            // 
            this.cmdShowParents.Name = "cmdShowParents";
            resources.ApplyResources(this.cmdShowParents, "cmdShowParents");
            this.cmdShowParents.Click += new System.EventHandler(this.cmdShowParents_Click);
            // 
            // srcElemCmdMenu
            // 
            this.srcElemCmdMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdFactor,
            this.cmdDelSrcElem,
            this.commandBarSeparatorItem1,
            this.cmdSrcElementMoveBegin,
            this.cmdSrcElementMoveEnd});
            this.srcElemCmdMenu.Name = "srcElemCmdMenu";
            resources.ApplyResources(this.srcElemCmdMenu, "srcElemCmdMenu");
            // 
            // cmdFactor
            // 
            this.cmdFactor.Name = "cmdFactor";
            resources.ApplyResources(this.cmdFactor, "cmdFactor");
            this.cmdFactor.Text = null;
            this.cmdFactor.Click += new System.EventHandler(this.cmdFactor_Click);
            // 
            // cmdDelSrcElem
            // 
            this.cmdDelSrcElem.Name = "cmdDelSrcElem";
            resources.ApplyResources(this.cmdDelSrcElem, "cmdDelSrcElem");
            this.cmdDelSrcElem.Text = null;
            this.cmdDelSrcElem.Click += new System.EventHandler(this.cmdDelSrcElem_Click);
            // 
            // commandBarSeparatorItem1
            // 
            this.commandBarSeparatorItem1.Name = "commandBarSeparatorItem1";
            resources.ApplyResources(this.commandBarSeparatorItem1, "commandBarSeparatorItem1");
            // 
            // cmdSrcElementMoveBegin
            // 
            this.cmdSrcElementMoveBegin.Name = "cmdSrcElementMoveBegin";
            resources.ApplyResources(this.cmdSrcElementMoveBegin, "cmdSrcElementMoveBegin");
            this.cmdSrcElementMoveBegin.Text = null;
            this.cmdSrcElementMoveBegin.Click += new System.EventHandler(this.cmdSrcElementMoveBegin_Click);
            // 
            // cmdSrcElementMoveEnd
            // 
            this.cmdSrcElementMoveEnd.Name = "cmdSrcElementMoveEnd";
            resources.ApplyResources(this.cmdSrcElementMoveEnd, "cmdSrcElementMoveEnd");
            this.cmdSrcElementMoveEnd.Text = null;
            this.cmdSrcElementMoveEnd.Click += new System.EventHandler(this.cmdSrcElementMoveEnd_Click);
            // 
            // dimCmdMenu
            // 
            this.dimCmdMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNewDim,
            this.cmdDelDim,
            this.cmdRenDim,
            this.cmdEditDim,
            this.commandBarSeparatorItem7,
            this.cmdDimExport,
            this.commandBarSeparatorItem3,
            this.cmdDimInfo});
            this.dimCmdMenu.Name = "dimCmdMenu";
            resources.ApplyResources(this.dimCmdMenu, "dimCmdMenu");
            // 
            // cmdNewDim
            // 
            this.cmdNewDim.Name = "cmdNewDim";
            resources.ApplyResources(this.cmdNewDim, "cmdNewDim");
            this.cmdNewDim.Text = null;
            this.cmdNewDim.Click += new System.EventHandler(this.btnDimensionAdd_Click);
            // 
            // cmdDelDim
            // 
            this.cmdDelDim.Name = "cmdDelDim";
            resources.ApplyResources(this.cmdDelDim, "cmdDelDim");
            this.cmdDelDim.Text = null;
            this.cmdDelDim.Click += new System.EventHandler(this.btnDimensionRemove_Click);
            // 
            // cmdRenDim
            // 
            this.cmdRenDim.Name = "cmdRenDim";
            resources.ApplyResources(this.cmdRenDim, "cmdRenDim");
            this.cmdRenDim.Text = null;
            this.cmdRenDim.Click += new System.EventHandler(this.btnDimensionRename_Click);
            // 
            // cmdEditDim
            // 
            this.cmdEditDim.Name = "cmdEditDim";
            resources.ApplyResources(this.cmdEditDim, "cmdEditDim");
            this.cmdEditDim.Text = null;
            this.cmdEditDim.Click += new System.EventHandler(this.btnDimensionEdit_Click);
            // 
            // commandBarSeparatorItem7
            // 
            this.commandBarSeparatorItem7.Name = "commandBarSeparatorItem7";
            resources.ApplyResources(this.commandBarSeparatorItem7, "commandBarSeparatorItem7");
            // 
            // cmdDimExport
            // 
            this.cmdDimExport.Name = "cmdDimExport";
            resources.ApplyResources(this.cmdDimExport, "cmdDimExport");
            this.cmdDimExport.Click += new System.EventHandler(this.cmdDimExport_Click);
            // 
            // commandBarSeparatorItem3
            // 
            this.commandBarSeparatorItem3.Name = "commandBarSeparatorItem3";
            resources.ApplyResources(this.commandBarSeparatorItem3, "commandBarSeparatorItem3");
            // 
            // cmdDimInfo
            // 
            this.cmdDimInfo.Name = "cmdDimInfo";
            resources.ApplyResources(this.cmdDimInfo, "cmdDimInfo");
            this.cmdDimInfo.Text = null;
            this.cmdDimInfo.Click += new System.EventHandler(this.cmdDimInfo_Click);
            // 
            // cmdSubSetEditor
            // 
            this.cmdSubSetEditor.Name = "cmdSubSetEditor";
            resources.ApplyResources(this.cmdSubSetEditor, "cmdSubSetEditor");
            this.cmdSubSetEditor.Text = null;
            // 
            // commandBarSeparatorItem4
            // 
            this.commandBarSeparatorItem4.Name = "commandBarSeparatorItem4";
            resources.ApplyResources(this.commandBarSeparatorItem4, "commandBarSeparatorItem4");
            // 
            // cubeCmdMenu
            // 
            this.cubeCmdMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAddCube,
            this.cmdDelCube,
            this.cmdCubeRename,
            this.commandBarSeparatorItem6,
            this.cmdClearCube,
            this.cmdExportCube,
            this.commandBarSeparatorItem8,
            this.cmdSVSWizard,
            this.commandBarSeparatorItem2,
            this.cmdCubeConvert,
            this.commandBarSeparatorItem5,
            this.cmdRuleEditor,
            this.commandBarSeparatorItem9,
            this.cmdCubeInfo});
            this.cubeCmdMenu.Name = "cubeCmdMenu";
            resources.ApplyResources(this.cubeCmdMenu, "cubeCmdMenu");
            // 
            // cmdAddCube
            // 
            this.cmdAddCube.Name = "cmdAddCube";
            resources.ApplyResources(this.cmdAddCube, "cmdAddCube");
            this.cmdAddCube.Text = null;
            this.cmdAddCube.Click += new System.EventHandler(this.btnCubeAdd_Click);
            // 
            // cmdDelCube
            // 
            this.cmdDelCube.Name = "cmdDelCube";
            resources.ApplyResources(this.cmdDelCube, "cmdDelCube");
            this.cmdDelCube.Text = null;
            this.cmdDelCube.Click += new System.EventHandler(this.btnCubeRemove_Click);
            // 
            // cmdCubeRename
            // 
            this.cmdCubeRename.Name = "cmdCubeRename";
            resources.ApplyResources(this.cmdCubeRename, "cmdCubeRename");
            this.cmdCubeRename.Text = null;
            this.cmdCubeRename.Click += new System.EventHandler(this.cmdCubeRename_Click);
            // 
            // commandBarSeparatorItem6
            // 
            this.commandBarSeparatorItem6.Name = "commandBarSeparatorItem6";
            resources.ApplyResources(this.commandBarSeparatorItem6, "commandBarSeparatorItem6");
            // 
            // cmdClearCube
            // 
            this.cmdClearCube.Name = "cmdClearCube";
            resources.ApplyResources(this.cmdClearCube, "cmdClearCube");
            this.cmdClearCube.Text = null;
            this.cmdClearCube.Click += new System.EventHandler(this.cmdClearCube_Click);
            // 
            // cmdExportCube
            // 
            this.cmdExportCube.Name = "cmdExportCube";
            resources.ApplyResources(this.cmdExportCube, "cmdExportCube");
            this.cmdExportCube.Click += new System.EventHandler(this.cmdExportCube_Click);
            // 
            // commandBarSeparatorItem8
            // 
            this.commandBarSeparatorItem8.Name = "commandBarSeparatorItem8";
            resources.ApplyResources(this.commandBarSeparatorItem8, "commandBarSeparatorItem8");
            // 
            // commandBarSeparatorItem9
            // 
            this.commandBarSeparatorItem9.Name = "commandBarSeparatorItem9";
            resources.ApplyResources(this.commandBarSeparatorItem9, "commandBarSeparatorItem9");
            // 
            // cmdSVSWizard
            // 
            this.cmdSVSWizard.Name = "cmdSVSWizard";
            resources.ApplyResources(this.cmdSVSWizard, "cmdSVSWizard");
            this.cmdSVSWizard.Click += new System.EventHandler(this.cmdSVSWizard_Click);
            // 
            // commandBarSeparatorItem5
            // 
            this.commandBarSeparatorItem5.Name = "commandBarSeparatorItem5";
            resources.ApplyResources(this.commandBarSeparatorItem5, "commandBarSeparatorItem5");
            // 
            // cmdRuleEditor
            // 
            this.cmdRuleEditor.Name = "cmdRuleEditor";
            resources.ApplyResources(this.cmdRuleEditor, "cmdRuleEditor");
            // 
            // commandBarSeparatorItem2
            // 
            this.commandBarSeparatorItem2.Name = "commandBarSeparatorItem2";
            resources.ApplyResources(this.commandBarSeparatorItem2, "commandBarSeparatorItem2");
            // 
            // cmdCubeInfo
            // 
            this.cmdCubeInfo.Name = "cmdCubeInfo";
            resources.ApplyResources(this.cmdCubeInfo, "cmdCubeInfo");
            this.cmdCubeInfo.Text = null;
            // 
            // cmdCubeConvert
            // 
            this.cmdCubeConvert.Name = "cmdCubeConvert";
            resources.ApplyResources(this.cmdCubeConvert, "cmdCubeConvert");
            this.cmdCubeConvert.Click += new System.EventHandler(this.cmdCubeConvert_Click);
            // 
            // cubeDimCmdMenu
            // 
            this.cubeDimCmdMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdMeasure,
            this.cmdTime});
            this.cubeDimCmdMenu.Name = "cubeDimCmdMenu";
            resources.ApplyResources(this.cubeDimCmdMenu, "cubeDimCmdMenu");
            // 
            // cmdMeasure
            // 
            this.cmdMeasure.Name = "cmdMeasure";
            resources.ApplyResources(this.cmdMeasure, "cmdMeasure");
            this.cmdMeasure.Click += new System.EventHandler(this.cmdMeasure_Click);
            // 
            // cmdTime
            // 
            this.cmdTime.Name = "cmdTime";
            resources.ApplyResources(this.cmdTime, "cmdTime");
            this.cmdTime.Click += new System.EventHandler(this.cmdTime_Click);
            // 
            // tabCmdMenu
            // 
            this.tabCmdMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdTabDatabase});
            this.tabCmdMenu.Name = "tabCmdMenu";
            resources.ApplyResources(this.tabCmdMenu, "tabCmdMenu");
            // 
            // cmdTabDatabase
            // 
            this.cmdTabDatabase.Name = "cmdTabDatabase";
            resources.ApplyResources(this.cmdTabDatabase, "cmdTabDatabase");
            this.cmdTabDatabase.Click += new System.EventHandler(this.cmdTabDatabase_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExpandAll.ButtonImage = null;
            this.btnExpandAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExpandAll.FlatAppearance.BorderSize = 0;
            this.btnExpandAll.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExpandAll.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExpandAll, "btnExpandAll");
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.RolloverImage = null;
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnCollapseAll.ButtonImage = null;
            this.btnCollapseAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCollapseAll.FlatAppearance.BorderSize = 0;
            this.btnCollapseAll.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnCollapseAll.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCollapseAll, "btnCollapseAll");
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.RolloverImage = null;
            // 
            // btnExpand
            // 
            this.btnExpand.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExpand.ButtonImage = null;
            this.btnExpand.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExpand.FlatAppearance.BorderSize = 0;
            this.btnExpand.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExpand.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExpand, "btnExpand");
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.RolloverImage = null;
            // 
            // btnCollapse
            // 
            this.btnCollapse.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnCollapse.ButtonImage = null;
            this.btnCollapse.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCollapse.FlatAppearance.BorderSize = 0;
            this.btnCollapse.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnCollapse.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCollapse, "btnCollapse");
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.RolloverImage = null;
            // 
            // btnExp1
            // 
            this.btnExp1.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExp1.ButtonImage = null;
            this.btnExp1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExp1.FlatAppearance.BorderSize = 0;
            this.btnExp1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExp1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExp1, "btnExp1");
            this.btnExp1.Name = "btnExp1";
            this.btnExp1.RolloverImage = null;
            // 
            // btnExp2
            // 
            this.btnExp2.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExp2.ButtonImage = null;
            this.btnExp2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExp2.FlatAppearance.BorderSize = 0;
            this.btnExp2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExp2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExp2, "btnExp2");
            this.btnExp2.Name = "btnExp2";
            this.btnExp2.RolloverImage = null;
            // 
            // btnExp3
            // 
            this.btnExp3.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExp3.ButtonImage = null;
            this.btnExp3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExp3.FlatAppearance.BorderSize = 0;
            this.btnExp3.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExp3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExp3, "btnExp3");
            this.btnExp3.Name = "btnExp3";
            this.btnExp3.RolloverImage = null;
            // 
            // btnExp4
            // 
            this.btnExp4.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExp4.ButtonImage = null;
            this.btnExp4.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExp4.FlatAppearance.BorderSize = 0;
            this.btnExp4.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExp4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExp4, "btnExp4");
            this.btnExp4.Name = "btnExp4";
            this.btnExp4.RolloverImage = null;
            // 
            // btnExp5
            // 
            this.btnExp5.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExp5.ButtonImage = null;
            this.btnExp5.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExp5.FlatAppearance.BorderSize = 0;
            this.btnExp5.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExp5.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExp5, "btnExp5");
            this.btnExp5.Name = "btnExp5";
            this.btnExp5.RolloverImage = null;
            // 
            // btnExp6
            // 
            this.btnExp6.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExp6.ButtonImage = null;
            this.btnExp6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExp6.FlatAppearance.BorderSize = 0;
            this.btnExp6.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExp6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExp6, "btnExp6");
            this.btnExp6.Name = "btnExp6";
            this.btnExp6.RolloverImage = null;
            // 
            // btnExp7
            // 
            this.btnExp7.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExp7.ButtonImage = null;
            this.btnExp7.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExp7.FlatAppearance.BorderSize = 0;
            this.btnExp7.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExp7.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExp7, "btnExp7");
            this.btnExp7.Name = "btnExp7";
            this.btnExp7.RolloverImage = null;
            // 
            // btnExp8
            // 
            this.btnExp8.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnExp8.ButtonImage = null;
            this.btnExp8.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExp8.FlatAppearance.BorderSize = 0;
            this.btnExp8.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnExp8.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnExp8, "btnExp8");
            this.btnExp8.Name = "btnExp8";
            this.btnExp8.RolloverImage = null;
            // 
            // ChildSibling
            // 
            this.ChildSibling.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdChild,
            this.cmdSibling});
            this.ChildSibling.Name = "ChildSibling";
            resources.ApplyResources(this.ChildSibling, "ChildSibling");
            // 
            // cmdChild
            // 
            this.cmdChild.Name = "cmdChild";
            resources.ApplyResources(this.cmdChild, "cmdChild");
            this.cmdChild.Text = null;
            this.cmdChild.Click += new System.EventHandler(this.cmdChild_Click);
            // 
            // cmdSibling
            // 
            this.cmdSibling.Name = "cmdSibling";
            resources.ApplyResources(this.cmdSibling, "cmdSibling");
            this.cmdSibling.Text = null;
            this.cmdSibling.Click += new System.EventHandler(this.cmdSibling_Click);
            // 
            // ChildSiblingCopy
            // 
            this.ChildSiblingCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdChildCopy,
            this.cmdSiblingCopy});
            this.ChildSiblingCopy.Name = "ChildSiblingCopy";
            resources.ApplyResources(this.ChildSiblingCopy, "ChildSiblingCopy");
            // 
            // cmdChildCopy
            // 
            this.cmdChildCopy.Name = "cmdChildCopy";
            resources.ApplyResources(this.cmdChildCopy, "cmdChildCopy");
            this.cmdChildCopy.Text = null;
            this.cmdChildCopy.Click += new System.EventHandler(this.cmdChildCopy_Click);
            // 
            // cmdSiblingCopy
            // 
            this.cmdSiblingCopy.Name = "cmdSiblingCopy";
            resources.ApplyResources(this.cmdSiblingCopy, "cmdSiblingCopy");
            this.cmdSiblingCopy.Text = null;
            this.cmdSiblingCopy.Click += new System.EventHandler(this.cmdSiblingCopy_Click);
            // 
            // mnuSubSet
            // 
            this.mnuSubSet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAddSubset,
            this.cmdRemoveSubset,
            this.cmdEditSubset});
            this.mnuSubSet.Name = "subsetCmdMenu";
            resources.ApplyResources(this.mnuSubSet, "mnuSubSet");
            // 
            // cmdAddSubset
            // 
            this.cmdAddSubset.Name = "cmdAddSubset";
            resources.ApplyResources(this.cmdAddSubset, "cmdAddSubset");
            this.cmdAddSubset.Click += new EventHandler(this.cmdAddSubset_Click);
            // 
            // cmdRemoveSubset
            // 
            this.cmdRemoveSubset.Name = "cmdRemoveSubset";
            resources.ApplyResources(this.cmdRemoveSubset, "cmdRemoveSubset");
            this.cmdRemoveSubset.Click += new EventHandler(cmdRemoveSubset_Click);
            // 
            // cmdEditSubset
            // 
            this.cmdEditSubset.Name = "cmdEditSubset";
            resources.ApplyResources(this.cmdEditSubset, "cmdEditSubset");
            this.cmdEditSubset.Click += new EventHandler(this.cmdEditSubset_Click);
            // 
            // btnEnableTree
            // 
            this.btnEnableTree.ButtonColor = System.Drawing.SystemColors.Control;
            this.btnEnableTree.ButtonImage = null;
            this.btnEnableTree.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnEnableTree.FlatAppearance.BorderSize = 0;
            this.btnEnableTree.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnEnableTree.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnEnableTree, "btnEnableTree");
            this.btnEnableTree.Name = "btnEnableTree";
            this.btnEnableTree.RolloverImage = null;
            this.btnEnableTree.UseVisualStyleBackColor = true;
            this.btnEnableTree.Click += new System.EventHandler(this.btnEnableTree_Click);
            // 
            // imgListElements
            // 
            this.imgListElements.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListElements.ImageStream")));
            this.imgListElements.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListElements.Images.SetKeyName(0, "");
            this.imgListElements.Images.SetKeyName(1, "");
            this.imgListElements.Images.SetKeyName(2, "");
            this.imgListElements.Images.SetKeyName(3, "Subset.png");
            // 
            // Modeller
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.tabMain);
            this.KeyPreview = true;
            this.Name = "Modeller";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.Modeller_Load);
            this.VisibleChanged += new System.EventHandler(this.Modeller_VisibleChanged);
            this.Resize += new System.EventHandler(this._Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Modeller_KeyDown);
            this.tabMain.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.elemCmdMenu.ResumeLayout(false);
            this.srcElemCmdMenu.ResumeLayout(false);
            this.dimCmdMenu.ResumeLayout(false);
            this.cubeCmdMenu.ResumeLayout(false);
            this.cubeDimCmdMenu.ResumeLayout(false);
            this.tabCmdMenu.ResumeLayout(false);
            this.ChildSibling.ResumeLayout(false);
            this.ChildSiblingCopy.ResumeLayout(false);
            this.mnuSubSet.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private void UpdateSubsetList()
        {
            try
            {
                System.Collections.Generic.List<string> sl = SubsetHelper.GetGlobalSubsetList(currConn, this.currDb, currDimension);
                JNode tmpNode;
                int i, lsize = sl.Count;

                treeElements.ClearNodes();
                for (i = 0; i < lsize; i++)
                {
                    tmpNode = new JNode(sl[i]);
                    tmpNode.ImageIndex = 3;
                    treeElements.Nodes.Add(tmpNode);
                }
            }
            catch (Exception connExc)
            {
                ErrorHandler.DisplayError("Error in UpdateSubsetList!", connExc);
            }

        }

        private void doElementTypeSelectedIndexChangedHelper()
        {
            if (!string.IsNullOrEmpty(this.currDb))
            {
                this.SetcurrDimension();

                if (!string.IsNullOrEmpty(this.currDimension))
                {
                    this.showElements(this.chkTree.Checked);

                    if (this.treeElements.Nodes.Count == 0)
                    {
                        this.showHitElements(ref this.treeElements);
                        this.chkTree.Checked = false;
                        this.chkTree.Enabled = false;
                        this.btnEnableTree.Enabled = false;
                    }
                    else
                    {
                        this.chkTree.Enabled = true;
                        this.btnEnableTree.Enabled = true;
                    }
                }
            }
        }

        private void doElementTypeSelectedIndexChanged0()
        {

            switch (cmbElementType.SelectedIndex)
            {

                case 0: // show elements
                case 1: // show attributes
                    doElementTypeSelectedIndexChangedHelper();
                    break;

                case 2: // make sure we show first subset
                    if (cmbElementType.Items.Count > 3)
                    {
                        cmbElementType.SelectedIndex = 3;
                    }
                    break;
            }
            FixToolTip();
            // show subset content
            if (cmbElementType.SelectedIndex > 1)
            {
                /// TODO: add subset content
                treeSourceElements.Items.Clear();
                //  JMM 03-20-14:
                if (!this.treeElements.Font.Equals(this.regularFont))  
                    treeElements.Font = this.regularFont;
                chkTree.Enabled = false;
                btnEnableTree.Enabled = false;
                btnDown.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                btnUp.Enabled = false;
                enableButtonsAddDelRenDims(true);
                lblConsolidatedElements.Text = ResourceInitializer.LabelSubsetElements;
                this.toolTip.SetToolTip(this.btnElementAdd, ResourceInitializer.AddSubset);
                this.toolTip.SetToolTip(this.btnElementRemove, ResourceInitializer.DeleteSubset);
                this.toolTip.SetToolTip(this.btnElementRename, ResourceInitializer.RenameSubset);
                this.toolTip.SetToolTip(this.treeElements, ResourceInitializer.TooltipSubsetElements);

                UpdateSubsetList();
            }
            else
            {
                lblConsolidatedElements.Text = ResourceInitializer.LABEL_ELEMENTS_CONSOLIDATED;
                this.toolTip.SetToolTip(this.btnElementAdd, ResourceInitializer.TIP_BUTTON_ADD_ELEMENT);
                this.toolTip.SetToolTip(this.btnElementRemove, ResourceInitializer.TIP_BUTTON_DELETE_ELEMENT);
                this.toolTip.SetToolTip(this.btnElementRename, ResourceInitializer.TIP_BUTTON_RENAME_ELEMENT);
                this.toolTip.SetToolTip(this.treeElements, ResourceInitializer.TIP_TREE_ELEMENTS);
                treeSourceElements.Items.Clear();
                treeElements1();
                treeElements2();
                chkTree.Enabled = true;
                btnEnableTree.Enabled = true;
            }
        }

        private void doElementTypeSelectedIndexChanged()
        {
            this.treeElements.ClearNodes();
            this.SetcurrDimension();
            if (cmbElementType.SelectedIndex < 0)
            {
               return;
            }

            this.doElementTypeSelectedIndexChanged0();

            if (btnAscElems.FlatAppearance.BorderColor == System.Drawing.SystemColors.GradientActiveCaption)
            {
                this.btnUp.Enabled = false;
                this.btnDown.Enabled = false;
                this.cmdElementMoveBegin.Enabled = false;
                this.cmdElementMoveEnd.Enabled = false;
                this.sortElems(false);
            }

            if (btnDescElems.FlatAppearance.BorderColor == System.Drawing.SystemColors.GradientActiveCaption)
            {
                this.btnUp.Enabled = false;
                this.btnDown.Enabled = false;
                this.cmdElementMoveBegin.Enabled = false;
                this.cmdElementMoveEnd.Enabled = false;
                this.sortElems(true);
            }
        }

        private void cmbElementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            doElementTypeSelectedIndexChanged();
        }

        #endregion

        #region Construct/Destruct

        public Modeller(CultureInfo originalCulture)
        {
            InitializeComponent();
            this.toolTip.ShowAlways = true;
            this.boldFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.regularFont = ResourceInitializer.RegularFont;
            this.ConsolidatedElements = new Hashtable();
            this.originalCulture = originalCulture;
            this.InitializeFormElements();
            this.initCombo();
            this.MinimumSize = new System.Drawing.Size(680, 480);
            this.CubeViewStatus = GeneralConst.NORMAL_CUBE_VIEW;

            this.btnUserManagment.Visible = true;
            this.btnToggleSystemCubes.Visible = true;
            this.btnAttributeManagment.Visible = true;
            this.btnDataManagment.Visible = true;
            this.btnOrigDims.Visible = true;
            this.btnAscDims.Visible = true;
            this.btnDescDims.Visible = true;
            this.btnOrigDims.Enabled = false;
            this.btnAscDims.Enabled = true;
            this.btnDescDims.Enabled = true;

            #region Handling restore form's size/position
            int[] tmpProps = RegUtils.GetFormProperties(GeneralConst.MODELLER);
            if (tmpProps[0] != -1)
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Size = new System.Drawing.Size(tmpProps[2], tmpProps[3]);
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
            }
            else
            {
                this.Size = new System.Drawing.Size(773, 547);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            #endregion          

            this.btnAttributeManagment.Click += new System.EventHandler(this.btnAttributeManagment_Click);
            this.btnToggleSystemCubes.Click += new System.EventHandler(this.btnToggleSystemCubes_Click);

            this.ActivateCubeBtn = true;

            btnDimensionRemove.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            btnDimensionAdd.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            btnDimensionRename.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            btnCubeAdd.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            btnCubeRemove.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            btnRuleEditor.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            btnUserManagment.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            btnAttributeManagment.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            btnDataManagment.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            btnConnAdd.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            btnConnToggle.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.tabMain.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            ReadingMessage = ResourceInitializer.Replace(ResourceInitializer.STATUS_READING_ELEMENTS_SERVER, new object[] { "" });

            //  JMM 03-20-14 replaced DotNetMagic TabControl with .NET TabControl
            lastSelectedPage = tabSettings;
        }
        
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (this.ccw != null)
                {
                    this.ccw.Dispose();
                }
                this.ccw = null;

                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }


        #region Manage treeSourceElements Headers

        private void ListViewShowHeaderR()
        {
            this.columnHeader1.Width =  this.treeSourceElements.Width - 46;
            this.columnHeader2.Width = 46;
            //this.columnHeader3.Width = 0;
            //this.columnHeader4.Width = 0;
        }

        private void ListViewShowHeaderL()
        {
            this.columnHeader1.Width = 0;
            this.columnHeader2.Width = 46;
            //this.columnHeader3.Width = this.treeSourceElements.Width - 46;
            //this.columnHeader4.Width = 0;
        }

        private void ListViewHideHeader()
        {
            this.columnHeader1.Width =  this.treeSourceElements.Width;
            this.columnHeader2.Width = 0;
            //this.columnHeader3.Width = 0;
            //this.columnHeader4.Width = 0;
        }


        #endregion

        private void InitializeFormElements()
        {
            #region Controls

            this.cmdRuleEditor.Click += new System.EventHandler(this.cmdRuleEditor_Click);
            this.cmdCubeInfo.Click += new System.EventHandler(this.cmdCubeInfo_Click);

            this.chkFactor = new System.Windows.Forms.CheckBox();
            this.chkTree = new System.Windows.Forms.CheckBox();
            
            // 
            // btnHome
            //
            //
            this.btnHome.Name = "btnHome";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.FlatStyle = FlatStyle.Flat;
            this.btnHome.FlatAppearance.BorderColor = this.btnClose.FlatAppearance.BorderColor;
            this.btnHome.TabIndex = 999;
            //
            // label3
            // 
            this.lblConsolidatedElements.Location = this.lblCubes.Location;
            this.lblConsolidatedElements.Name = "lblConsolidatedElements";
            this.lblConsolidatedElements.Size = new System.Drawing.Size(130, 16);
            this.lblConsolidatedElements.TabIndex = 0;
            
            // 
            // chkFactor
            // 
            this.chkFactor.Top = this.lblConsolidatedElements.Top - 5;
            this.chkFactor.Left = this.lblConsolidatedElements.Left + 110;
            this.chkFactor.Name = "chkFactor";
            this.chkFactor.Size = new System.Drawing.Size(152, 24);
            this.chkFactor.TabIndex = 210;
            this.chkFactor.CheckedChanged += new System.EventHandler(this.chkFactor_CheckedChanged);
            this.chkFactor.Visible = false;
            
            // 
            // chkTree
            // 
            this.chkTree.Top = this.lblElements.Top - 5;
            this.chkTree.Left = this.lblConsolidatedElements.Left + 110;
            this.chkTree.Name = "chkTree";
            this.chkTree.Size = new System.Drawing.Size(152, 24);
            this.chkTree.TabIndex = 210;
            this.chkTree.CheckedChanged += new System.EventHandler(this.chkTree_CheckedChanged);
            this.chkTree.Visible = false;
            this.chkTree.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            
            // 
            // label4
            // 
            this.lblElements.Location = this.lblDimensions.Location;
            this.lblElements.Name = "label4";
            this.lblElements.Size = new System.Drawing.Size(100, 16);
            this.lblElements.TabIndex = 0;
            // 
            // treeElements
            // 
            this.treeElements.SelectionMode = TreeViewSelectionMode.MultiSelect;
            this.treeElements.AllowSingleSelectedNode = true;
            this.treeElements.ImageIndex = -1;
            this.treeElements.BorderStyle = BorderStyle.FixedSingle;
            this.treeElements.Font = this.regularFont;
            this.treeElements.Top = this.treeViewDims.Top - 20;
            this.treeElements.Left= this.treeViewDims.Left;
            this.treeElements.Name = "treeElements";
            this.treeElements.SelectedImageIndex = 3;
            this.treeElements.Size = this.treeViewDims.Size;
            this.treeElements.TabIndex = 220;
            this.treeElements.ImageList = this.imgListElements;            
            this.treeElements.AfterLabelEdit += new NodeLabelEditEventHandler(this.treeElements_AfterLabelEdit);
            this.treeElements.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp);
            this.treeElements.DoubleClick += new System.EventHandler(this.treeElements_DoubleClick);
            this.treeElements.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeElements_KeyDown);
            this.treeElements.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeElements_KeyUp);
 
            //  JMM 03-20-14 replaced DotNetMagic TreeControl with MultiSelectTreeView
            this.treeElements.ShowLines = false;
            this.treeElements.ShowPlusMinus = false;
            this.treeElements.ShowRootLines = false;
            #if NOTUSED
            //CDNM only:
            this.treeElements.AutoEdit = false;
            this.treeElements.DoubleClickExpand = Crownwood.DotNetMagic.Controls.ClickExpandAction.Toggle;
            this.treeElements.FocusNode = null;
            this.treeElements.LineVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.OnlyBelowRoot;
            this.treeElements.CheckStates = Crownwood.DotNetMagic.Controls.CheckStates.None;
            this.treeElements.ImageGapLeft = 1;
            this.treeElements.ImageGapRight = 1;
            this.treeElements.BoxVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.Nowhere;
            this.treeElements.NodesSelectable = true;
            this.treeElements.InstantUpdate = false;
            #endif
            this.treeElements.LabelEdit = false;
            this.treeElements.SelectedNode = null;
            this.treeElements.AllowDrop = true;
 
            // 
            // treeSourceElements
            //
            this.treeSourceElements = new ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1.Width = this.treeSourceElements.Width;
            this.columnHeader1.Text = ResourceInitializer.LABEL_HEADER_NAME;
            this.columnHeader2.Width = 0;
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Text = ResourceInitializer.LABEL_HEADER_FACTOR;
            this.treeSourceElements.AutoArrange = false;
            this.treeSourceElements.AllowColumnReorder = false;
            this.treeSourceElements.AllowDrop = false;
            this.treeSourceElements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {  
                this.columnHeader1,
                this.columnHeader2
            });
            this.treeSourceElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.treeSourceElements.ForeColor = System.Drawing.SystemColors.InfoText;
            this.treeSourceElements.FullRowSelect = true;
            this.treeSourceElements.GridLines = false;
            this.treeSourceElements.LabelWrap = false;
            this.treeSourceElements.Location = new System.Drawing.Point(32, 32);
            this.treeSourceElements.Name = "treeSourceElements";
            this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.treeSourceElements.TabIndex = 230;
            this.treeSourceElements.View = System.Windows.Forms.View.Details;
            this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.treeSourceElements.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.treeSourceElements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeSourceElements.Top = this.treeViewCubes.Top - 20;
            this.treeSourceElements.Left = this.treeViewCubes.Left;
            this.treeSourceElements.Name = "treeSourceElements";
            this.treeSourceElements.LabelEdit = false;
            this.treeSourceElements.Size = this.treeViewCubes.Size;
            this.treeSourceElements.Columns[1].TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.treeSourceElements.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeSourceElements_MouseUp);
            this.treeSourceElements.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeSourceElements_KeyDown); 
            //
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(280, 168);
            this.btnUp.Name = "btnUp";
            this.btnUp.Text = "";
            this.btnUp.TabIndex = 221;
            this.btnUp.Enabled = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(280, 200);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = this.btnDimensionAdd.Size;
            this.btnRight.TabIndex = 222;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(280, 224);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.TabIndex = 223;
            this.btnLeft.Enabled = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(280, 232);
            this.btnDown.Name = "btnDown";
            this.btnDown.TabIndex = 224;
            this.btnDown.Enabled = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnElementAdd
            // 
            this.btnElementAdd.Location = this.btnDimensionAdd.Location;
            this.btnElementAdd.Name = "btnElementAdd";
            this.btnElementAdd.Size = this.btnDimensionAdd.Size;
            this.btnElementAdd.TabIndex = 993;
            this.btnElementAdd.Enabled = false;
            this.btnElementAdd.Click += new System.EventHandler(this.btnElementAdd_Click);
            // 
            // btnElementRemove
            //
            this.btnElementRemove.Location = this.btnDimensionRemove.Location;
            this.btnElementRemove.Name = "btnElementRemove";
            this.btnElementRemove.Size = this.btnDimensionRemove.Size;
            this.btnElementRemove.TabIndex = 994;
            this.btnElementRemove.Enabled = false;
            this.btnElementRemove.Click += new System.EventHandler(this.btnElementRemove_Click);
            // 
            // btnElementRename
            // 
            this.btnElementRename.Location = this.btnDimensionRename.Location;
            this.btnElementRename.Name = "btnElementRename";
            this.btnElementRename.Size = this.btnDimensionRename.Size;
            this.btnElementRename.TabIndex = 995;
            this.btnElementRename.Enabled = false;
            this.btnElementRename.Click += new System.EventHandler(this.btnElementRename_Click);
            // 
            // btnElementEdit
            // 
            this.btnElementEdit.Name = "btnElementEdit";
            this.btnElementEdit.TabIndex = 996;
            this.btnElementEdit.Enabled = false;
            this.btnElementEdit.Click += new System.EventHandler(this.btnElementEdit_Click);
            // 
            // btnElementApplyChanges
            // 
            this.btnElementApplyChanges.Name = "btnElementApplyChanges";
            this.btnElementApplyChanges.Size = this.btnElementEdit.Size;
            this.btnElementApplyChanges.TabIndex = 997;
            this.btnElementApplyChanges.Enabled = false;
            this.btnElementApplyChanges.Visible = false;
            this.btnElementApplyChanges.Click += new System.EventHandler(this.btnElementApplyChanges_Click);
            // 
            // btnElementCancelChanges
            // 
            this.btnElementCancelChanges.Top = this.btnElementApplyChanges.Top;
            this.btnElementCancelChanges.Left = this.btnElementApplyChanges.Left + this.btnElementApplyChanges.Width + 10;
            this.btnElementCancelChanges.Name = "btnElementCancelChanges";
            this.btnElementCancelChanges.Size = this.btnElementEdit.Size;
            this.btnElementCancelChanges.TabIndex = 998;
            this.btnElementCancelChanges.Enabled = false;
            this.btnElementCancelChanges.Visible = false;
            this.btnElementCancelChanges.Click += new System.EventHandler(this.btnElementCancelChanges_Click);
            // 
            // treeViewDims
            // 
            this.treeViewDims.ImageIndex = -1;
            this.treeViewDims.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewDims.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));            
            this.treeViewDims.Name = "treeViewDims";
            this.treeViewDims.Location = new System.Drawing.Point(16, 64);
            this.treeViewDims.SelectedImageIndex = -1;
            this.treeViewDims.ShowLines = true;
            this.treeViewDims.ShowPlusMinus = true;
            this.treeViewDims.ShowRootLines = true;
            this.treeViewDims.Sorted = false;
            this.treeViewDims.Size = new System.Drawing.Size(256, 360);
            this.treeViewDims.TabIndex = 110;
            this.treeViewDims.Scrollable = true;
            this.treeViewDims.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewDims_KeyDown);
            this.treeViewDims.DoubleClick += new System.EventHandler(this.treeViewDims_DoubleClick);
            this.treeViewDims.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewDims_AfterLabelEdit);
            this.treeViewDims.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewDims_MouseUp);
            this.tabSettings.Controls.Add(this.treeViewDims);
            // 
            // PDbutton_expand_all
            // 
            this.btnExpandAll.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.btnExpandAll.ButtonImage = (Image)ResourceInitializer.IconExpandAllButton;
            this.btnExpandAll.RolloverImage = (Image)ResourceInitializer.IconExpandAllButtonH;
            this.btnExpandAll.Location = new System.Drawing.Point(60, 51);
            this.btnExpandAll.Name = "PDbutton_expand_all";
            this.btnExpandAll.TabIndex = 208;
            this.btnExpandAll.Visible = false;
            // 
            // PDbutton_collaps_all
            // 
            this.btnCollapseAll.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.btnCollapseAll.ButtonImage = (Image)ResourceInitializer.IconCollapseAllButton;
            this.btnCollapseAll.RolloverImage = (Image)ResourceInitializer.IconCollapseAllButtonH;
            this.btnCollapseAll.Location = new System.Drawing.Point(164, 51);
            this.btnCollapseAll.Name = "PDbutton_collaps_all";
            this.btnCollapseAll.TabIndex = 209;
            this.btnCollapseAll.Visible = false;
            // 
            // PDbutton_expand
            // 
            btnExpand.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Location = new System.Drawing.Point(8, 51);
            this.btnExpand.Name = "PDbutton_expand";
            this.btnExpand.Size = new System.Drawing.Size(18, 21);
            this.btnExpand.TabIndex = 206;
            this.btnExpand.Visible = false;
            // 
            // PDbutton_collaps
            // 
            btnCollapse.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapse.Location = new System.Drawing.Point(26, 51);
            this.btnCollapse.Name = "PDbutton_collaps";
            this.btnCollapse.Size = new System.Drawing.Size(18, 21);
            this.btnCollapse.TabIndex = 207;
            this.btnCollapse.Visible = false;
            this.btnExpand.Click += new System.EventHandler(this.PDbutton_expand_Click);
            this.btnExpandAll.Click += new System.EventHandler(this.PDbutton_expand_all_Click);
            this.btnCollapse.Click += new System.EventHandler(this.PDbutton_collaps_Click);
            this.btnCollapseAll.Click += new System.EventHandler(this.PDbutton_collaps_all_Click);

            btnExp1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp1.Location = new System.Drawing.Point(8, 51);
            this.btnExp1.Size = new System.Drawing.Size(18, 21);
            this.btnExp1.TabIndex = 211;
            this.btnExp1.Visible = false;
            this.btnExp1.Click += new System.EventHandler(this.btnExp1_Click);

            btnExp2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExp2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp2.Location = new System.Drawing.Point(8, 51);
            this.btnExp2.Size = new System.Drawing.Size(18, 21);
            this.btnExp2.TabIndex = 212;
            this.btnExp2.Visible = false;
            this.btnExp2.Click += new System.EventHandler(this.btnExp2_Click);

            btnExp3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExp3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp3.Location = new System.Drawing.Point(8, 51);
            this.btnExp3.Size = new System.Drawing.Size(18, 21);
            this.btnExp3.TabIndex = 213;
            this.btnExp3.Visible = false;
            this.btnExp3.Click += new System.EventHandler(this.btnExp3_Click);

            btnExp4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExp4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp4.Location = new System.Drawing.Point(8, 51);
            this.btnExp4.Size = new System.Drawing.Size(18, 21);
            this.btnExp4.TabIndex = 214;
            this.btnExp4.Visible = false;
            this.btnExp4.Click += new System.EventHandler(this.btnExp4_Click);

            btnExp5.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExp5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp5.Location = new System.Drawing.Point(8, 51);
            this.btnExp5.Size = new System.Drawing.Size(18, 21);
            this.btnExp5.TabIndex = 215;
            this.btnExp5.Visible = false;
            this.btnExp5.Click += new System.EventHandler(this.btnExp5_Click);

            btnExp6.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExp6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp6.Location = new System.Drawing.Point(8, 51);
            this.btnExp6.Size = new System.Drawing.Size(18, 21);
            this.btnExp6.TabIndex = 216;
            this.btnExp6.Visible = false;
            this.btnExp6.Click += new System.EventHandler(this.btnExp6_Click);

            btnExp7.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExp7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp7.Location = new System.Drawing.Point(8, 51);
            this.btnExp7.Size = new System.Drawing.Size(18, 21);
            this.btnExp7.TabIndex = 217;
            this.btnExp7.Visible = false;
            this.btnExp7.Click += new System.EventHandler(this.btnExp7_Click);

            btnExp8.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExp8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp8.Location = new System.Drawing.Point(8, 51);
            this.btnExp8.Size = new System.Drawing.Size(18, 21);
            this.btnExp8.TabIndex = 218;
            this.btnExp8.Visible = false;
            this.btnExp8.Click += new System.EventHandler(this.btnExp8_Click);
            #endregion

            #region Other manually assigned resources

            this.btnDimensionAdd.ButtonImage = (Image)ResourceInitializer.IconDimensionAdd;
            this.btnDimensionAdd.RolloverImage = (Image)ResourceInitializer.IconDimensionAddH;

            this.btnDimensionRemove.ButtonImage = (Image)ResourceInitializer.IconDimensionDelete;
            this.btnDimensionRemove.RolloverImage = (Image)ResourceInitializer.IconDimensionDeleteH;

            this.btnDimensionRename.ButtonImage = (Image)ResourceInitializer.IconDimensionEdit;
            this.btnDimensionRename.RolloverImage = (Image)ResourceInitializer.IconDimensionEditH;

            this.btnCubeAdd.ButtonImage = (Image)ResourceInitializer.IconCubeAdd;
            this.btnCubeAdd.RolloverImage = (Image)ResourceInitializer.IconCubeAddH;

            this.btnCubeRemove.ButtonImage = (Image)ResourceInitializer.IconCubeDelete;
            this.btnCubeRemove.RolloverImage = (Image)ResourceInitializer.IconCubeDeleteH;

            this.btnConnAdd.ButtonImage = (Image)ResourceInitializer.IconWizard;
            this.btnConnAdd.RolloverImage = (Image)ResourceInitializer.IconWizardH;

            this.btnConnToggle.ButtonImage = (Image)ResourceInitializer.IconConnect;
            this.btnConnToggle.RolloverImage = null;// (Image)ResourceInitializer.IconConnectH;

            this.btnDataManagment.ButtonImage = (Image)ResourceInitializer.IconToggleCube;
            this.btnDataManagment.RolloverImage = (Image)ResourceInitializer.IconToggleCubeH;

            this.btnAttributeManagment.ButtonImage = (Image)ResourceInitializer.IconToggleAttribute;
            this.btnAttributeManagment.RolloverImage = (Image)ResourceInitializer.IconToggleAttributeH;

            this.btnUserManagment.ButtonImage = (Image)ResourceInitializer.IconToggleUser;
            this.btnUserManagment.RolloverImage = (Image)ResourceInitializer.IconToggleUserH;

            this.btnToggleSystemCubes.Image = (Image)ResourceInitializer.IconToggleSystemCubes;

            this.btnOrigDims.Image = (Image)ResourceInitializer.ListOrderHistory;

            this.btnAscDims.Image = (Image)ResourceInitializer.ListOrderAZ;

            this.btnDescDims.Image = (Image)ResourceInitializer.ListOrderZA;

            this.btnRuleEditor.ButtonImage = (Image)ResourceInitializer.IconCubeRule;
            this.btnRuleEditor.RolloverImage = (Image)ResourceInitializer.IconCubeRuleH;

            this.btnElementAdd.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconElementAdd;
            this.btnElementAdd.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconElementAddH;
            this.btnElementAdd.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnElementRemove.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconElementDelete;
            this.btnElementRemove.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconElementDeleteH;
            this.btnElementRemove.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnElementRename.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconElementRename;
            this.btnElementRename.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconElementRenameH;
            this.btnElementRename.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnElementEdit.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconElementEdit;
            this.btnElementEdit.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconElementEditH;
            this.btnElementEdit.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnElementApplyChanges.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconApply;
            this.btnElementApplyChanges.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconApplyH;
            this.btnElementApplyChanges.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnLeft.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconLeft;
            this.btnLeft.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconLeftH;
            this.btnLeft.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnUp.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconUp;
            this.btnUp.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconUpH;
            this.btnUp.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnRight.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconRight;
            this.btnRight.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconRightH;
            this.btnRight.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnDown.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconDown;
            this.btnDown.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconDownH;
            this.btnDown.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExpand.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExpand;
            this.btnExpand.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExpandH;
            this.btnExpand.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnCollapse.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconCollapse;
            this.btnCollapse.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconCollapseH;
            this.btnCollapse.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExp1.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExpand1;
            this.btnExp1.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExpand1H;
            this.btnExp1.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExp2.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExpand2;
            this.btnExp2.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExpand2H;
            this.btnExp2.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExp3.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExpand3;
            this.btnExp3.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExpand3H;
            this.btnExp3.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExp4.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExpand4;
            this.btnExp4.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExpand4H;
            this.btnExp4.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExp5.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExpand5;
            this.btnExp5.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExpand5H;
            this.btnExp5.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExp6.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExpand6;
            this.btnExp6.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExpand6H;
            this.btnExp6.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExp7.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExpand7;
            this.btnExp7.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExpand7H;
            this.btnExp7.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnExp8.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconExpand8;
            this.btnExp8.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconExpand8H;
            this.btnExp8.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            //this.btnHome.ButtonImage = (Image)ResourceInitializer.IconHome;
            //this.btnHome.RolloverImage = (Image)ResourceInitializer.IconHomeH;
            this.btnHome.Text = ResourceInitializer.BUTTON_DATABASE;

            this.btnElementCancelChanges.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconCancel;
            this.btnElementCancelChanges.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconCancelH;
            this.btnElementCancelChanges.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnEnableTree.ButtonImage = (Image)ResourceInitializer.IconShowFlatButton;
            this.btnEnableTree.RolloverImage = (Image)ResourceInitializer.IconShowFlatButton;
            this.btnEnableTree.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnOrigElems.Image = (Image)ResourceInitializer.ListOrderHistory;

            this.btnAscElems.Image = (Image)ResourceInitializer.ListOrderAZ;

            this.btnDescElems.Image = (Image)ResourceInitializer.ListOrderZA;

            this.labelChooseServer.Text = ResourceInitializer.TEXT_CHOOSE_SERVER_DB;
            this.lblDimensions.Text = ResourceInitializer.LABEL_DIMENSIONS;
            this.lblCubes.Text = ResourceInitializer.LABEL_CUBES;
            this.btnClose.Text = ResourceInitializer.BUTTON_CLOSE;
            
            this.cmdAddN.Text = ResourceInitializer.CMD_ADD_ELEMENT;
            this.cmdDel.Text = ResourceInitializer.CMD_DELETE_ELEMENT;
            this.cmdRen.Text = ResourceInitializer.CMD_RENAME_ELEMENT;
            this.cmdShowParents.Text = ResourceInitializer.CMD_SHOW_PARENTS;

            this.cmdEdit.Text = ResourceInitializer.CMD_EDIT_ELEMENT;
            this.cmdNumeric.Text = ResourceInitializer.CMD_NUMERIC_ELEMENT;
            this.cmdString.Text = ResourceInitializer.CMD_STRING_ELEMENT;
            this.cmdElemCopy.Text = ResourceInitializer.CMD_COPY_ELEMENT;
            this.cmdElemPaste.Text = ResourceInitializer.CMD_PASTE_ELEMENT;
            this.cmdElemSelectAll.Text = ResourceInitializer.CMD_SELECTALL_ELEMENT;
            this.cmdCountElements.Text = ResourceInitializer.CMD_COUNT_ELEMENT;

            this.cmdFactor.Text = ResourceInitializer.CMD_FACTOR;
            this.cmdDelSrcElem.Text = ResourceInitializer.CMD_DELETE_SOURCE_ELEMENT;

            this.cmdNewDim.Text = ResourceInitializer.CMD_ADD_DIMENSION;
            this.cmdDelDim.Text = ResourceInitializer.CMD_DELETE_DIMENSION;
            this.cmdRenDim.Text = ResourceInitializer.CMD_RENAME_DIMENSION;
            this.cmdEditDim.Text = ResourceInitializer.CMD_EDIT_DIMENSION;
            this.cmdDimInfo.Text = ResourceInitializer.CommandDimensionInfo;

            this.cmdAddCube.Text = ResourceInitializer.CMD_ADD_CUBE;
            this.cmdDelCube.Text = ResourceInitializer.CMD_DELETE_CUBE;
            this.cmdClearCube.Text = ResourceInitializer.CMD_CLEAR_CUBE;
            this.cmdExportCube.Text = ResourceInitializer.CMD_EXPORT_CUBE;
            this.cmdSVSWizard.Text = ResourceInitializer.CMD_SVS_WIZARD;
            this.cmdDimExport.Text = ResourceInitializer.CMD_EXPORT_DIM;
            this.cmdRuleEditor.Text = ResourceInitializer.CmdRuleEditor;
            this.cmdCubeInfo.Text = ResourceInitializer.CMD_CUBE_INFO;
            this.cmdCubeRename.Text = ResourceInitializer.CommandCubeRename;
            this.cmdCubeConvert.Text = ResourceInitializer.CMD_CONVERT_CUBE;

            this.cmdMeasure.Text = ResourceInitializer.CmdMeasure;
            this.cmdTime.Text = ResourceInitializer.CmdTime;

            this.cmdChild.Text = ResourceInitializer.CMD_ADD_CHILD;
            this.cmdSibling.Text = ResourceInitializer.CMD_ADD_SIBLING;

            this.cmdChildCopy.Text = ResourceInitializer.CMD_COPY_CHILD;
            this.cmdSiblingCopy.Text = ResourceInitializer.CMD_COPY_SIBLING;
            this.Text = ResourceInitializer.TITLE_MODELLER;

            this.lblConsolidatedElements.Text = ResourceInitializer.LABEL_ELEMENTS_CONSOLIDATED;

            this.chkFactor.Text = ResourceInitializer.LABEL_CHECK_FACTOR;
            this.chkTree.Text = ResourceInitializer.LABEL_CHECK_TREE;
            
            this.lblElements.Text = ResourceInitializer.LABEL_ELEMENTS;

            this.cmdElementMoveBegin.Text = ResourceInitializer.MoveElementToBeginning;
            this.cmdElementMoveEnd.Text = ResourceInitializer.MoveElementToEnd;
            this.cmdSrcElementMoveBegin.Text = ResourceInitializer.MoveElementToBeginning;
            this.cmdSrcElementMoveEnd.Text = ResourceInitializer.MoveElementToEnd;
            this.cmdSearchElements.Text = ResourceInitializer.CommandSearchElement;

            this.btnClose.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnHome.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabMain.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabSettings.BackColor = ResourceInitializer.FormStdBackgroundColor;

            this.cmdAddSubset.Text = ResourceInitializer.AddSubset;
            this.cmdRemoveSubset.Text = ResourceInitializer.DeleteSubset;
            this.cmdEditSubset.Text = ResourceInitializer.RenameSubset;
            this.Icon = ResourceInitializer.IconPalo;
            #endregion
        }

        
        #region ToolTip

        private void FixToolTip()
        {
            this.toolTip.RemoveAll();
            this.toolTip.Active = true;

            //this.Modellerbutton_expand_all.Text = ResourceInitializer.BUTTON_EXPAND_ALL;
            //this.Modellerbutton_collaps_all.Text = ResourceInitializer.BUTTON_COLLAPSE_ALL;
            this.toolTip.SetToolTip(this.btnExpandAll, ResourceInitializer.BUTTON_EXPAND_ALL);
            this.toolTip.SetToolTip(this.btnCollapseAll, ResourceInitializer.BUTTON_COLLAPSE_ALL);

            this.toolTip.SetToolTip(this.comboConnList, ResourceInitializer.TIP_COMBO_CONNECTIONS);
            this.toolTip.SetToolTip(this.btnDimensionAdd, ResourceInitializer.TIP_BUTTON_ADD_DIMENSION);
            this.toolTip.SetToolTip(this.btnDimensionRemove, ResourceInitializer.TIP_BUTTON_DELETE_DIMENSION);
            this.toolTip.SetToolTip(this.btnDimensionRename, ResourceInitializer.TIP_BUTTON_RENAME_DIMENSION);
            //this.toolTip.SetToolTip(this.xpEditDataAxis, ResourceInitializer.TIP_BUTTON_EDIT_DIMENSION);
            this.toolTip.SetToolTip(this.btnCubeAdd, ResourceInitializer.TIP_BUTTON_ADD_CUBE);
            this.toolTip.SetToolTip(this.btnCubeRemove, ResourceInitializer.TIP_BUTTON_DELETE_CUBE);
            this.toolTip.SetToolTip(this.btnRuleEditor, ResourceInitializer.TipRuleEditor);

            this.toolTip.SetToolTip(this.btnElementAdd, ResourceInitializer.TIP_BUTTON_ADD_ELEMENT);
            this.toolTip.SetToolTip(this.btnElementRemove, ResourceInitializer.TIP_BUTTON_DELETE_ELEMENT);
            this.toolTip.SetToolTip(this.btnElementRename, ResourceInitializer.TIP_BUTTON_RENAME_ELEMENT);
            this.toolTip.SetToolTip(this.btnElementEdit, ResourceInitializer.TIP_BUTTON_CONSOLIDATE_ELEMENT);

            this.toolTip.SetToolTip(this.btnUp, ResourceInitializer.TIP_BUTTON_MOVE_ELEMENT_UP);
            this.toolTip.SetToolTip(this.btnLeft, ResourceInitializer.TIP_BUTTON_MOVE_ELEMENT_LEFT);
            this.toolTip.SetToolTip(this.btnRight, ResourceInitializer.TIP_BUTTON_MOVE_ELEMENT_RIGHT);
            this.toolTip.SetToolTip(this.btnDown, ResourceInitializer.TIP_BUTTON_MOVE_ELEMENT_DOWN);
            //this.toolTip.SetToolTip(this.xpCopy, "Copy selected element for export into Excel");
            //this.toolTip.SetToolTip(this.xpPaste, "Paste from Excel imported Elements into list of Elements");

            this.toolTip.SetToolTip(this.btnElementApplyChanges, ResourceInitializer.TIP_BUTTON_APPLY_CHANGES);
            this.toolTip.SetToolTip(this.btnElementCancelChanges, ResourceInitializer.TIP_BUTTON_CANCEL_CHANGES);
            this.toolTip.SetToolTip(this.chkFactor, ResourceInitializer.TIP_CHECK_FACTOR);
            this.toolTip.SetToolTip(this.chkTree, ResourceInitializer.TIP_CHECK_TREE);

            this.toolTip.SetToolTip(this.btnEnableTree, ResourceInitializer.TIP_CHECK_TREE);

            this.toolTip.SetToolTip(this.btnHome, ResourceInitializer.TIP_BUTTON_DATABASE);
            this.toolTip.SetToolTip(this.btnClose, ResourceInitializer.TIP_BUTTON_MODELLER_CLOSE);

            this.toolTip.SetToolTip(this.btnConnToggle, ResourceInitializer.TIP_BUTTON_TOGGLE_CONNECTION);
            this.toolTip.SetToolTip(this.btnConnAdd, ResourceInitializer.TIP_BUTTON_PALO_WIZARD);

            this.toolTip.SetToolTip(this.treeViewDims, ResourceInitializer.TIP_TREE_DIMENSIONS);
            this.toolTip.SetToolTip(this.treeViewCubes, ResourceInitializer.TIP_TREE_CUBES);
            this.toolTip.SetToolTip(this.treeElements, ResourceInitializer.TIP_TREE_ELEMENTS);
            this.toolTip.SetToolTip(this.treeSourceElements, ResourceInitializer.TIP_TREE_ELEMENTS_CONSOLIDATED);
        
            this.toolTip.SetToolTip(this.btnDataManagment, ResourceInitializer.TipFilterData);
            this.toolTip.SetToolTip(this.btnUserManagment, ResourceInitializer.TipFilterUser);
            this.toolTip.SetToolTip(this.btnAttributeManagment, ResourceInitializer.TipFilterAttribute);
            this.toolTip.SetToolTip(this.btnOrigDims, ResourceInitializer.TipButtonCreationOrder);
            this.toolTip.SetToolTip(this.btnOrigElems, ResourceInitializer.TipButtonCreationOrder);
            this.toolTip.SetToolTip(this.btnAscDims, ResourceInitializer.TipButtonSortAscending);
            this.toolTip.SetToolTip(this.btnAscElems, ResourceInitializer.TipButtonSortAscending);
            this.toolTip.SetToolTip(this.btnDescDims, ResourceInitializer.TipButtonSortDescending);
            this.toolTip.SetToolTip(this.btnDescElems, ResourceInitializer.TipButtonSortDescending);

            this.toolTip.SetToolTip(this.btnToggleSystemCubes, ResourceInitializer.ToolTipShowSystemCubes);

        }

        #endregion

        #endregion

        #region Set/Init combo
        
        private void setCombo()
        {
            this.clearTabs();
            this.btnConnToggle.Enabled = false;
            this.treeViewDims.Nodes.Clear();
            this.treeViewCubes.Nodes.Clear();
            this.enableButtonsAddDelCub(true);
            this.enableButtonsAddDelRenDims(true);

            this.comboConnList.FillList(-1, (this.EditUsersState) ? ConnectionsHelper.HandleDatabase.NoRestriction : ConnectionsHelper.HandleDatabase.WithoutSystem);
            this.comboConnList.SetItem();
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
            this.comboConnList.DisplayMember = "Text";
            this.comboConnList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboConnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.comboConnList.Location = new System.Drawing.Point(16, 29);
            this.comboConnList.MaxLength = 1;
            this.comboConnList.Name = "comboConnList";
            this.comboConnList.Size = new System.Drawing.Size(466, 21);
            this.comboConnList.TabIndex = 101;
            this.comboConnList.Tag = "myCustomCombo";
            //this.comboConnList.Text = "Click here to change active server...";
            this.comboConnList.SelectedIndexChanged += new System.EventHandler(this.comboConnList_SelectedIndexChanged);
            this.comboConnList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.tabSettings.Controls.Add(this.comboConnList);
        }

        private void refreshCombo()
        {
            XmlUtils.ReadXmlInitial();
            this.setCombo();
            this.comboConnList.Width = this.btnConnToggle.Left - 5 - this.comboConnList.Left;
            this.comboConnList.Top = this.labelChooseServer.Top + this.labelChooseServer.Height + 5;
        }
        #endregion

        #region Fix button position on form resize

        private int GethSpace()
        {
            return 5;
        }

        private int GetBtnDist()
        {
            return this.treeViewDims.Top + this.treeViewDims.Height + this.GethSpace();
        }

        private void SetCubeBtnState()
        {

            if (this.tabMain.SelectedIndex > 0)
            {
                this.btnCubeAdd.Visible = this.ActivateCubeBtn;
                this.btnCubeRemove.Visible = this.ActivateCubeBtn;
                this.btnRuleEditor.Visible = this.ActivateCubeBtn;
            }
            else
            {
                bool visible = (this.CubeViewStatus == GeneralConst.NORMAL_CUBE_VIEW);
                bool visible2 = this.ActivateCubeBtn && visible;
                this.btnCubeAdd.Visible = visible2;
                this.btnCubeRemove.Visible = visible2;
                this.btnRuleEditor.Visible = visible2;
                this.cmdAddCube.Visible = visible;
                this.cmdDelCube.Visible = visible;
                this.cmdCubeRename.Visible = visible;
                
                this.cmdCubeInfo.Visible = !this.EditUsersState;
            }

            this.btnOrigDims.Enabled = false;
            this.btnAscDims.Enabled = true;
            this.btnDescDims.Enabled = true;
        }

        private void setSizes()
        {
            this.tabMain.SuspendLayout();
            //this.tabMain.BeginUpdate();

            this.treeViewDims.SuspendLayout();
            this.treeViewDims.BeginUpdate();

            this.treeViewCubes.SuspendLayout();
            this.treeViewCubes.BeginUpdate();

            this.treeElements.SuspendLayout();
            this.treeSourceElements.SuspendLayout();
            this.treeSourceElements.BeginUpdate();

            #region Tab Settings Controls

            int hSpace = this.GethSpace();
            this.formX = tabMain.SelectedTab.Width;     //this.tabSettings.Width;
            this.formY = tabMain.SelectedTab.Height;    //this.tabSettings.Height;
            this.lblDimensions.Top = this.comboConnList.Bottom + hSpace * 2;
            this.treeViewDims.BringToFront();
            this.treeViewDims.Top = this.lblDimensions.Bottom - 10 + hSpace;
            this.treeViewDims.Width = this.formX / 2 - 36; // 42
            this.treeViewDims.Height = (this.formY - 120)
                                       / this.treeViewDims.ItemHeight * this.treeViewDims.ItemHeight;            
            
            this.lblCubes.Top = this.lblDimensions.Top;
            this.treeViewCubes.Top = this.treeViewDims.Top;
            this.treeViewCubes.Width = this.treeViewDims.Width;
            this.treeViewCubes.Height = this.treeViewDims.Height;
            this.treeViewCubes.Left = this.Width - treeViewDims.Width - treeViewDims.Left - 10;
            this.lblCubes.Left = this.treeViewCubes.Left;
            this.lblDimensions.Left = this.treeViewDims.Left;
            this.lblDimensions.Width = this.treeViewDims.Width;


            int btnDist = this.GetBtnDist();

            this.btnDimensionAdd.Top = btnDist;
            this.btnDimensionAdd.Left = this.lblDimensions.Left - 2;
            this.btnDimensionAdd.Width = 26;
            this.btnDimensionAdd.Height = 23;

            this.btnConnAdd.Left = this.treeViewCubes.Right - this.btnConnAdd.Width;
            this.btnConnAdd.Size = this.btnDimensionAdd.Size;
            this.btnConnAdd.Top = this.comboConnList.Bottom - this.btnConnAdd.Height;
            this.btnConnToggle.Top = this.btnConnAdd.Top;
            
            this.btnConnToggle.Left = this.btnConnAdd.Left - hSpace - this.btnConnToggle.Width;
            this.btnConnToggle.Size = this.btnDimensionAdd.Size;
            this.comboConnList.Width = this.btnConnToggle.Left - hSpace - this.comboConnList.Left;
            this.labelChooseServer.Width = this.comboConnList.Width;

            this.btnDimensionRemove.Top = btnDist;
            this.btnDimensionRemove.Left = this.btnDimensionAdd.Left + this.btnDimensionAdd.Width + hSpace;
            this.btnDimensionRemove.Size = this.btnDimensionAdd.Size;

            this.btnDimensionRename.Top = btnDist;
            this.btnDimensionRename.Left = this.btnDimensionRemove.Left + this.btnDimensionRemove.Width + hSpace; // this.btnDimensionAdd.Left + 128;
            this.btnDimensionRename.Size = this.btnDimensionAdd.Size;
            
            this.btnToggleSystemCubes.Height = this.btnOrigDims.Height;
            this.btnToggleSystemCubes.Width = this.btnOrigDims.Width;
            this.btnToggleSystemCubes.Top = this.lblCubes.Top - hSpace - 1;
            this.btnToggleSystemCubes.Left = this.treeViewCubes.Left + this.treeViewCubes.Width - this.btnToggleSystemCubes.Width;
            
            this.btnUserManagment.Height = this.btnDimensionAdd.Height;
            this.btnUserManagment.Width = this.btnDimensionAdd.Width;
            this.btnUserManagment.Top = this.btnDimensionAdd.Bottom - this.btnUserManagment.Height;
            this.btnUserManagment.Left = this.treeViewDims.Right - this.btnUserManagment.Width;

            this.btnAttributeManagment.Height = this.btnUserManagment.Height;
            this.btnAttributeManagment.Width = this.btnUserManagment.Width;
            this.btnAttributeManagment.Top = this.btnUserManagment.Top;
            this.btnAttributeManagment.Left = this.btnUserManagment.Left - this.btnDataManagment.Width - hSpace;

            this.btnDataManagment.Height = this.btnAttributeManagment.Height;
            this.btnDataManagment.Width = this.btnAttributeManagment.Width;
            this.btnDataManagment.Top = this.btnAttributeManagment.Top;
            this.btnDataManagment.Left = this.btnAttributeManagment.Left - this.btnDataManagment.Width - hSpace;            

            this.btnDescDims.Top = this.lblDimensions.Top - hSpace - 1;
            this.btnDescDims.Left = this.treeViewDims.Left + this.treeViewDims.Width - this.btnDescDims.Width;// / 2 + 21;

            this.btnAscDims.Top = this.lblDimensions.Top - hSpace - 1;
            this.btnAscDims.Left = this.btnDescDims.Left - hSpace - 21;

            this.btnOrigDims.Top = this.lblDimensions.Top - hSpace - 1;
            this.btnOrigDims.Left = this.btnAscDims.Left - hSpace - 21;

            this.btnCubeAdd.Top = btnDist;
            this.btnCubeAdd.Left = this.lblCubes.Left - 2;
            this.btnCubeAdd.Size = this.btnDimensionAdd.Size;

            this.btnCubeRemove.Top = btnDist;
            this.btnCubeRemove.Left = this.btnCubeAdd.Right + hSpace;
            this.btnCubeRemove.Size = this.btnDimensionAdd.Size;

            this.btnRuleEditor.Top = btnDist;
            this.btnRuleEditor.Left = this.btnCubeRemove.Right + hSpace;
            this.btnRuleEditor.Size = this.btnDimensionAdd.Size;

            #endregion

            #region Tab Dimensions Controls
            int vSpace = 40;// 22
            this.lblConsolidatedElements.Top = this.lblCubes.Top - vSpace;
            this.lblConsolidatedElements.Left = this.lblCubes.Left;
            this.lblConsolidatedElements.Width = this.lblCubes.Width;
            this.lblElements.Top = this.lblDimensions.Top - vSpace;
            this.lblElements.Left = this.lblDimensions.Left;
            this.lblElements.Width = this.lblDimensions.Width;
            this.treeElements.Top = this.treeViewDims.Top - vSpace;
            this.treeElements.Left= this.treeViewDims.Left;
            this.treeElements.Width = this.treeViewDims.Width;
            this.treeElements.Height = (this.treeViewDims.Height + vSpace) / treeElements.ItemHeight * treeElements.ItemHeight;
            this.treeSourceElements.Top = this.treeElements.Top;
            this.treeSourceElements.Left = this.treeViewCubes.Left;
            this.treeSourceElements.Size = this.treeElements.Size;

            cmbElementType.Left = treeElements.Left;
            cmbElementType.Top = treeElements.Top - cmbElementType.Height - 4;

            int vSpaceDirButtons = 10;
            this.btnUp.Left = this.treeSourceElements.Left - 39;
            this.btnUp.Top = this.lblDimensions.Top + this.treeElements.Height / 2 - 90;
            
            this.btnRight.Left = this.btnUp.Left;
            this.btnRight.Top = this.btnUp.Bottom + vSpaceDirButtons;
            this.btnRight.Size = this.btnUp.Size;

            this.btnLeft.Left = this.btnUp.Left;
            this.btnLeft.Top = this.btnRight.Bottom + vSpaceDirButtons;
            this.btnLeft.Size = this.btnUp.Size;

            this.btnDown.Left = this.btnUp.Left;
            this.btnDown.Top = this.btnLeft.Bottom + vSpaceDirButtons;
            this.btnDown.Size = this.btnUp.Size;

            this.btnElementAdd.Left = this.btnDimensionAdd.Left;
            this.btnElementAdd.Top = this.btnDimensionAdd.Top;
            this.btnRight.Size = this.btnUp.Size;

            this.btnElementRemove.Left = this.btnElementAdd.Left + this.btnElementAdd.Width + hSpace;
            this.btnElementRemove.Top = this.btnElementAdd.Top;
            this.btnElementRemove.Size = this.btnUp.Size;

            this.btnElementRename.Left = this.btnElementRemove.Left + this.btnElementRemove.Width + hSpace;
            this.btnElementRename.Top = this.btnElementAdd.Top;
            this.btnElementRename.Size = this.btnUp.Size;

            this.btnElementEdit.Left = this.btnElementRename.Left + this.btnElementRename.Width + 5;
            this.btnElementEdit.Top = this.btnElementAdd.Top;
            this.btnElementEdit.Size = this.btnUp.Size;

            this.btnElementApplyChanges.Top = this.btnElementAdd.Top;
            this.btnElementApplyChanges.Left = this.treeSourceElements.Left - 2;
            this.btnElementApplyChanges.Size = this.btnUp.Size;

            this.btnElementCancelChanges.Top = btnElementAdd.Top;
            this.btnElementCancelChanges.Left = this.btnElementApplyChanges.Right + hSpace;
            this.btnElementCancelChanges.Size = this.btnUp.Size;

            this.chkFactor.Top = this.lblConsolidatedElements.Top - 5;
            this.chkFactor.Left = this.treeSourceElements.Right - this.chkFactor.Width + hSpace;

            this.chkTree.Top = this.btnElementAdd.Top + 4;
            this.chkTree.Left = this.treeElements.Right - this.chkTree.Width + 1;

            this.btnClose.Height = 23;
            this.btnClose.Width = 90;
            this.btnClose.Left = this.treeSourceElements.Right - this.btnClose.Width - 5;
            this.btnClose.Top = this.btnElementApplyChanges.Top + 2;

            this.btnHome.Height = this.btnClose.Height;
            this.btnHome.Width = this.btnClose.Width;
            this.btnHome.Left = this.btnClose.Left - hSpace - this.btnHome.Width - 2;
            this.btnHome.Top = this.btnClose.Top;

            //this.btnHome.Size = new System.Drawing.Size(this.btnClose.Size.Width + 30, this.btnClose.Size.Height);

            if(this.chkFactor.Checked == true)
            {
                this.ListViewShowHeaderL();
            }
            else if(this.chkFactor.Checked == false)
            {
                bool HasOther = false;
                if(this.treeSourceElements != null 
                    && this.treeSourceElements.Items != null)
                {
                    for(int i=0; i<this.treeSourceElements.Items.Count; i++)
                    {
                        ListViewItem lvi = this.treeSourceElements.Items[i];
                        if(lvi.SubItems.Count == 2
                            && lvi.SubItems[1].Text != null
                            && lvi.SubItems[1].Text.Length != 0
                            && System.Convert.ToDouble(lvi.SubItems[1].Text) != (double)1)
                            HasOther = true;
                    }
                }

                if(HasOther == true)
                {
                    this.ListViewShowHeaderR();
                }
                else
                {
                    this.ListViewHideHeader();
                }
            }

            this.btnEnableTree.Left = this.treeElements.Right - this.btnEnableTree.Width;
            this.btnEnableTree.Top = this.treeElements.Top - this.btnEnableTree.Height - 3;

            if(this.chkTree.Checked == true)
            {
                this.treeElements.Width = this.treeElements.Width + this.treeSourceElements.Width + this.treeSourceElements.Left - this.treeElements.Right;
            }
            
            this.btnExpand.Left = this.treeElements.Left - 2;
            this.btnExpand.Top = this.btnEnableTree.Top;

            this.btnCollapse.Left = this.btnExpand.Right;
            this.btnCollapse.Top = this.btnEnableTree.Top;

            this.btnExpandAll.Left = this.btnCollapse.Right + 16;
            this.btnExpandAll.Top = this.btnEnableTree.Top;

            this.btnCollapseAll.Left = this.btnExpandAll.Right;// +hSpace;
            this.btnCollapseAll.Top = this.btnEnableTree.Top;

            this.btnExp1.Left = this.btnEnableTree.Right + 16;
            this.btnExp1.Top = this.btnEnableTree.Top;

            this.btnExp2.Left = this.btnExp1.Right;
            this.btnExp2.Top = this.btnEnableTree.Top;

            this.btnExp3.Left = this.btnExp2.Right;
            this.btnExp3.Top = this.btnEnableTree.Top;

            this.btnExp4.Left = this.btnExp3.Right;
            this.btnExp4.Top = this.btnEnableTree.Top;

            this.btnExp5.Left = this.btnExp4.Right;
            this.btnExp5.Top = this.btnEnableTree.Top;

            this.btnExp6.Left = this.btnExp5.Right;
            this.btnExp6.Top = this.btnEnableTree.Top;

            this.btnExp7.Left = this.btnExp6.Right;
            this.btnExp7.Top = this.btnEnableTree.Top;

            this.btnExp8.Left = this.btnExp7.Right;
            this.btnExp8.Top = this.btnEnableTree.Top;

            this.btnDescElems.Left = this.btnEnableTree.Left - btnDescElems.Width - hSpace * 3;
            this.btnDescElems.Top = this.btnEnableTree.Top + hSpace/2;

            this.btnAscElems.Left = this.btnDescElems.Left - btnAscElems.Width - hSpace;
            this.btnAscElems.Top = this.btnEnableTree.Top + hSpace/2;

            this.btnOrigElems.Left = this.btnAscElems.Left - btnOrigElems.Width - hSpace;
            this.btnOrigElems.Top = this.btnEnableTree.Top + hSpace/2;
            #endregion

            this.SetCubeBtnState();

            this.treeViewDims.EndUpdate();
            this.treeViewDims.ResumeLayout();

            this.treeViewCubes.EndUpdate();
            this.treeViewCubes.ResumeLayout();
            this.treeElements.Update();
            this.treeElements.ResumeLayout();
            
            this.treeSourceElements.EndUpdate();
            this.treeSourceElements.ResumeLayout();

            //this.tabMain.EndUpdate();
            this.tabMain.ResumeLayout();

            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabMain.BackColor = ResourceInitializer.FormStdBackgroundColor;
            //CDNM only:
            //this.tabMain.ButtonActiveColor = ResourceInitializer.FormStdBackgroundColor;
            //this.tabMain.ButtonInactiveColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabSettings.BackColor = ResourceInitializer.FormStdBackgroundColor;
        }

        private void _Resize(object sender, System.EventArgs e)
        {
            this.setSizes();
        }
        #endregion

        #region Form Buttons/Events - Load,Wizard and Close (btnConnAdd_Click + btnClose_Click + Modeller_Load + Modeller_KeyDown + Modeller_VisibleChanged)

        private void SetcurrDimension()
        {
            if (this.tabMain.SelectedIndex > 0)
            {
                if (cmbElementType.SelectedIndex == 1)
                {
                    this.currDimension = ((TabTagObject)(this.tabMain.SelectedTab.Tag)).AttributeDimName;
                }
                else
                {
                    this.currDimension = ((TabTagObject)(this.tabMain.SelectedTab.Tag)).DimName;
                }
            }
            else
            {
                this.currDimension = "";
            }
        }

        private void btnConnAdd_Click(object sender, System.EventArgs e)
        {
            if( Apalo.XlAddin.Connect.WizardForm == null )
            {
                // show main form
                Apalo.XlAddin.Connect.WizardForm = new Apalo.XlAddin.Forms.PaloWizard();
                Apalo.XlAddin.Connect.WizardForm.Tag = "Database Wizard Window";
            }

            Apalo.XlAddin.Connect.WizardForm.ShowDialog();
            refreshCombo();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.CubeViewStatus = GeneralConst.NORMAL_CUBE_VIEW;
            this.comboConnList.SaveItem();
            
            // hide form
            this.OldPageindex = this.tabMain.SelectedIndex;
            RegUtils.SetFormProperties(GeneralConst.MODELLER, new int[4] { this.Left, this.Top, this.Width, this.Height });
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.DialogResult = DialogResult.OK;            
        }

        private void Modeller_Load(object sender, System.EventArgs e)
        {
            if (this.tabMain.SelectedTab == null)
                this.tabMain.SelectedIndex = 0;
            this.tabMain.SelectedTab.Controls.Add(this.btnClose);
            this.setSizes();
        }

        private string GetNewLabelText()
        {
            string labeltext = ResourceInitializer.LABEL_NEW_ELEMENT;

            switch (cmbElementType.SelectedIndex)
            {
                case 1:
                    labeltext = ResourceInitializer.LABEL_NEW_ATTRIBUTE;
                    break;

                case 2:
                    labeltext = ResourceInitializer.LABEL_NEW_SUBSET;
                    break;

                default:
                    break;
            }

            return labeltext;
        }

        private string GetHitLabelText()
        {
            string labeltext = ResourceInitializer.TEXT_HIT_RETURN_ELEMENTS;

            switch (cmbElementType.SelectedIndex)
            {
                case 1:
                    labeltext = ResourceInitializer.TEXT_HIT_RETURN_ATTRIBUTES;
                    break;

                case 2:
                    labeltext = ResourceInitializer.TEXT_HIT_RETURN_SUBSETS;
                    break;

                default:
                    break;
            }

            return labeltext;
        }


        private bool NoElements(JTreeView tc)
        {
            return (tc.Nodes != null) && (tc.Nodes.Count > 0) && (tc.Nodes[0].Text == GetHitLabelText());
        }

        private void Modeller_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (this.tabMain.SelectedTab == null)
            {
                return;
            }

            #region <ESC> Elements
            if((this.tabMain.SelectedIndex > 0) && (this.treeElements.Nodes != null)
                && (this.treeElements.Nodes.Count > 0))
            {
                if(e.KeyValue == (int)System.Windows.Forms.Keys.Escape)
                {
                    try
                    {
                        if(this.treeElements != null
                            && this.treeElements.Nodes != null
                            && this.currElementNode != null
                            && this.currElementNode.Text == this.GetNewLabelText())
                        {
                            ElementInfo[] dimNames = this.currConn.DimensionListElements(this.currDb, this.currDimension);
                            int matches = 0;
                            
                            for(int i=0;i<dimNames.Length;i++)
                            {
                                ElementInfo dei = (ElementInfo)dimNames[i];
                                if(dei.Name == this.currElementNode.Text)
                                {
                                    matches++;
                                    break;
                                }
                            }
                            
                            //delete node if not in DB
                            if(matches == 0 || matches == 1)
                            {
                                this.treeElements.Nodes.Remove(this.currElementNode);
                            }
                            this.currElementNode = null;
                            if (this.treeElements.Nodes.Count == 0)
                            {
                                DontExcuteAfterLabelEdit = true;
                                this.showHitElements(ref this.treeElements);
                                DontExcuteAfterLabelEdit = false;
                            }

                            this.nfoAddElement = false;

                            return;
                        }
                    }
                    catch
                    {}
                }
            }
            #endregion
            #region <RETURN>
            if ((this.tabMain.SelectedIndex > 0) & this.NoElements(this.treeElements))
            {
                // disable action if in edit mode
                if(this.cElementNode == null)
                {
                    // RETURN 13
                    if(e.KeyValue == (int)System.Windows.Forms.Keys.Return)
                    {
                        e.Handled = true;
                        try
                        {
                            this.addNewElement();
                        }
                        catch
                        {}
                    }
                }
            }
            else if(this.tabMain.SelectedIndex == 0
                && this.treeViewDims.Nodes != null 
                && this.treeViewDims.Nodes.Count > 0 
                && this.treeViewDims.Nodes[0].Text == ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS)
            {
                // RETURN
                if(e.KeyValue == (int)System.Windows.Forms.Keys.Return)
                {
                    e.Handled = true;
                    try
                    {
                        this.addNewDimension();
                    }
                    catch
                    {}
                }
            }
            #endregion
        }

        private void Modeller_VisibleChanged(object sender, System.EventArgs e)
        {
            // If VisibleChanged and Visible re-read and re-init some things
            if (this.Visible == true)
            {
                try
                {
                    ArrayList a = new ArrayList();

                    //if(ReadClipBoard(ref a) == false)
                    if (ReadClipBoard(ref a) == true)// || this.ClipboardContent.Count > 0)
                    {
                        this.cmdElemPaste.Enabled = true;
                    }
                    else
                    {
                        this.cmdElemPaste.Enabled = false;
                    }
                }
                catch
                { }

                this.refreshCombo();

                try
                {
                    this.tabMain.SelectedIndex = this.OldPageindex;
                }
                catch
                { }
                this.EnableUMControls();
                if (this.btnEnableTree.Visible && this.chkTree.Checked)
                {
                    this.treeElements.ImageList = null;
                }
                this.FixToolTip();
            }
            else
            {
                // make sure we turn user management mode off
                this.EditUsersState = false;
                this.btnEnableTree.Visible = true;
            }
        }
        
        #endregion

        #region Connection Toggle + Helper functions

        private void comboConnList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.olddim = "";
            if (this.comboConnList.SelectedIndex == -1)
            {
                return;
            }

            if (this.comboConnList.Text != null)
            {
                this.toolTip.SetToolTip(this.comboConnList, this.comboConnList.Text);
            }

            this.currConn = this.comboConnList.GetConnection();
            this.currHostname = this.comboConnList.GetConnectionName();
            this.currDb = this.comboConnList.GetDatabase();

            bool withdb = !string.IsNullOrEmpty(this.currDb);
            this.btnToggleSystemCubes.Enabled = withdb;
            
            this.btnConnToggle.Enabled = !withdb;

            if (!withdb)
            {
                this.treeViewDims.Nodes.Clear();
                this.treeViewCubes.Nodes.Clear();
                this.clearTabs();
                if (Connections.ConnectionExists(this.currHostname))
                {
                    this.toolTip.SetToolTip(this.btnConnToggle, ResourceInitializer.TIP_BUTTON_TOGGLE_DISCONNECT);
                    this.btnConnToggle.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconDisconnect;
                    this.btnConnToggle.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconDisconnectH;
                }
                else
                {
                    this.toolTip.SetToolTip(this.btnConnToggle, ResourceInitializer.TIP_BUTTON_TOGGLE_CONNECT);
                    this.btnConnToggle.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconConnect;
                    this.btnConnToggle.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconConnectH;
                }
                this.enableButtonsAddDelRenDims(true);
                this.enableButtonsAddDelCub(true);
                this.btnUserManagment.Enabled = false;
                this.btnAttributeManagment.Enabled = false;
                this.btnDataManagment.Enabled = false;
                this.EditUsersState = false;
                // set title to standard value
                this.Text = ResourceInitializer.TITLE_MODELLER;
            }
            else
            {
                this.toolTip.SetToolTip(this.btnConnToggle, ResourceInitializer.TIP_BUTTON_TOGGLE_DISCONNECT);
                this.btnConnToggle.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconDisconnect;
                this.btnConnToggle.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconDisconnectH;
                this.enableButtonsAddDelRenDims(false);
                this.enableButtonsAddDelCub(false);
                this.pumpDbData();
                this.fixShowHideDataStoreButtons();

                this.AllowUserManagement();

                //set title to <standard> - <db>
                this.Text = ResourceInitializer.TITLE_MODELLER + " - "  + currHostname.ToUpper() + " / " + this.currDb;
            }
            this.setSizes();
            this.comboConnList.SaveItem();
        }

        private void RefreshCubesHelper(string Cube, bool doexpand)
        {
            string[] cubDims = this.currConn.CubeListDimensions(this.currDb, Cube);
            JNode tmpNode = new JNode();
            tmpNode.Text = Cube;

            int j, iCntCubeDims = cubDims.Length;
            for (j = 0; j < iCntCubeDims; j++)
            {
                tmpNode.Nodes.Add((string)cubDims[j]);
            }

            if (doexpand)
            {
                tmpNode.Expand();
            }

            treeViewCubes.Nodes.Add(tmpNode);

        }

        private void RefreshCubes(string specialcube)
        {
            List<string> dbCubes = ListBoxHelper.GetCubeList(this.currConn, this.currDb, this.CubeViewStatus, false);
            treeViewCubes.Nodes.Clear();
            treeViewCubes.ShowLines = true;
            treeViewCubes.ShowPlusMinus = false;
            treeViewCubes.ShowRootLines = false;

            string Cube;

            int i;

            string[] sysdbs = (this.ShowSystemCubes) ? this.currConn.DatabaseListCubes(this.currDb, CubeType.SystemCube) : new String[0];
            ArrayList sysdbsal = new ArrayList(sysdbs);

            for (i = 0; i < dbCubes.Count; i++)
            {
                Cube = dbCubes[i];
                RefreshCubesHelper(Cube, !string.IsNullOrEmpty(specialcube) && (string.Equals(specialcube, Cube, StringComparison.InvariantCultureIgnoreCase)));
                Cube = GeneralConst.PREFIX_CELL_RIGHTS + Cube;
                if (this.ShowSystemCubes && sysdbsal.Contains(Cube))
                {
                    RefreshCubesHelper(Cube, false);
                }
            }

            if ((this.treeViewCubes.Nodes.Count == 0) && (this.treeViewDims.Nodes.Count >= 1) && (this.treeViewDims.Nodes[0].Text != ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS))
            {
                this.showHitCubes();
            }
        }

        private void RefreshCubes()
        {
            RefreshCubes(null);
        }

        /// <summary>
        /// Pumps data into list boxes(dimensions and cubes)
        /// </summary>
        private void pumpDbData()
        {
            try
            {
                string[] tmpDbDims = new string[] { };
       
                if (this.EditUsersState && !RegUtils.DebugMode)
                {
                    tmpDbDims = new string[3] { UserDimensionName, GroupDimensionName, RoleDimensionName };
                    this.comboConnList.Enabled = false;
                }
                else
                {
                    DimensionType dbtype = (this.EditUsersState) ? DimensionType.SystemDimension : DimensionType.NormalDimension;
                    try
                    {
                        tmpDbDims = this.currConn.DatabaseListDimensions(this.currDb, dbtype);
                    }
                    catch (PaloException)
                    { }
                    this.treeViewCubes.Enabled = true;
                }
                int tmpCnt = tmpDbDims.Length;
                string[] dbDims = new string[tmpCnt + 1];
                dbDims = tmpDbDims;
                
                this.treeViewDims.Nodes.Clear();
                this.clearTabs();
                this.clearItems();
                this.tabMain.SuspendLayout();
                string Dim, Attributedim;
                bool showLines = false;
                TreeNode tn;
                JTabPage tmpTab;

                for (int i = 0; i < dbDims.Length; i++)
                {
                    Dim = (string)dbDims[i];
                    if (ListBoxHelper.IsJPaloDim(Dim))
                    {
                        continue;
                    }

                    tn = new JNode(Dim);
                    if (!this.EditUsersState)
                    {
                        Attributedim = this.currConn.GetAttributeDimension(this.currDb, Dim);
                    }
                    else
                    {
                        Attributedim = "";
                    }
   
                    this.treeViewDims.Nodes.Add(tn);
                    tmpTab = new JTabPage(Dim);
                    tmpTab.Title = tmpTab.Title.Replace("&", "&&");
                    tmpTab.Tag = new TabTagObject(Dim, Attributedim);
                    this.tabMain.TabPages.Add(tmpTab);
                    ToolStripMenuItem cmdTabDim = new ToolStripMenuItem();
                    cmdTabDim.Text = Dim;
                    cmdTabDim.Click += new System.EventHandler(this.cmdTabDim_Click);
                    cmdTabDim.Checked = false;
                    this.tabCmdMenu.Items.Add(cmdTabDim);
                }

                if (showLines)
                {
                    this.treeViewDims.ShowPlusMinus = true;
                    this.treeViewDims.ShowRootLines = true;
                }
                else
                {
                    this.treeViewDims.ShowPlusMinus = false;
                    this.treeViewDims.ShowRootLines = false;
                }

                if(this.tabMain.TabPages.Count < 10)
                {
                    this.tabMain.Multiline = true;
                    //CDNM only:
                    //this.tabMain.Appearance = //Crownwood.DotNetMagic.Controls.VisualAppearance.MultiForm;
                    //this.tabMain.PositionTop = true;
                    //this.tabMain.BoldSelectedPage = true;
                }
                else
                {
                    this.tabMain.Multiline = false;
                    //CDNM only:
                    ///this.tabMain.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiDocument;
                }
                //CDNM only:
                //tabMain.ShowClose = false;
                this.setSizes();
                this.tabMain.ResumeLayout();

                if(this.treeViewDims.Nodes.Count == 0)
                {
                    this.showHitDims();
                }

                this.RefreshCubes();
                this.treeViewDims.SelectedNode = null;
                this.treeViewCubes.SelectedNode = null;
            }
            catch(PaloException e)
            {
                ErrorHandler.DisplayError("Error regenerating Server/DB list!", e);
            }
        }

        private void btnConnToggle_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.currDb))
                {
                    ListBoxHelper.ConnToggle(this.currHostname);
                    this.refreshCombo();
                }
            }
            catch(Exception connExc)
            {
                ErrorHandler.DisplayError("Error Connecting to server!", connExc);
            }
        }

        #endregion

        #region Init Tab Dim Elements Controls
        private void CloseBtnToPage(JTabPage tP, bool setCancel)
        {
            tP.Controls.Add(this.btnClose);
            if (setCancel)
            {
                this.CancelButton = this.btnClose;
            }
        }

        private void initElementsTab(JTabPage tP)
        {
            try
            {
                btnElementCancelChanges.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                btnElementApplyChanges.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                btnElementEdit.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                btnElementRename.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                btnElementRemove.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                btnElementAdd.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                btnUp.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                btnLeft.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                btnRight.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;
                btnDown.FlatAppearance.BorderColor = Utils.ResourceInitializer.FormStdBackgroundColor;

                tP.Controls.Add(this.btnElementCancelChanges);
                tP.Controls.Add(this.btnElementApplyChanges);
                tP.Controls.Add(this.btnElementEdit);
                tP.Controls.Add(this.btnElementRename);
                tP.Controls.Add(this.btnElementRemove);
                tP.Controls.Add(this.btnElementAdd);
                tP.Controls.Add(this.btnDown);
                tP.Controls.Add(this.btnUp);
                tP.Controls.Add(this.btnRight);
                tP.Controls.Add(this.btnLeft);
                tP.Controls.Add(this.lblConsolidatedElements);
                tP.Controls.Add(this.treeElements);
                tP.Controls.Add(this.treeSourceElements);
                tP.Controls.Add(this.chkFactor);
                tP.Controls.Add(this.chkTree);
                tP.Controls.Add(this.btnExpand);
                tP.Controls.Add(this.btnExpandAll);
                tP.Controls.Add(this.btnCollapse);
                tP.Controls.Add(this.btnCollapseAll);
                tP.Controls.Add(this.btnExp1);
                tP.Controls.Add(this.btnExp2);
                tP.Controls.Add(this.btnExp3);
                tP.Controls.Add(this.btnExp4);
                tP.Controls.Add(this.btnExp5);
                tP.Controls.Add(this.btnExp6);
                tP.Controls.Add(this.btnExp7);
                tP.Controls.Add(this.btnExp8);
                tP.Controls.Add(this.btnHome);
                tP.Controls.Add(this.cmbElementType);
                tP.Controls.Add(this.btnEnableTree);
                tP.Controls.Add(this.btnOrigElems);
                tP.Controls.Add(this.btnAscElems);
                tP.Controls.Add(this.btnDescElems);
                CloseBtnToPage(tP, false);
            }
            catch
            {}  
        }
        #endregion

        #region dimension Elements/Source Elements Button Events

        #region Helper functions
        private void fixChkFactor()
        {
            this.chkFactor.Enabled = true;
            if(this.chkFactor.Checked == true)
            {
                this.chkFactor.Checked = false;
                this.chkFactor.Checked = true;
            }
            else
            {
                this.chkFactor.Checked = true;
                this.chkFactor.Checked = false;
            }
        }

        private void showHitElements(ref JTreeView t)
        {
            t.Nodes.Clear();
            t.ImageList = null;
            JNode tN = new JNode();
            tN.NodeFont = this.regularFont;
            tN.ForeColor = Color.Black;
            t.ForeColor = Color.Black;
            tN.Text = GetHitLabelText();
            tN.Tag = "R";
            this.btnElementRemove.Enabled = false;
            this.btnElementRename.Enabled = false;
            this.btnElementEdit.Enabled = false;
            t.Nodes.Add(tN);
            this.btnUp.Enabled = false;
            this.btnLeft.Enabled = false;
            this.btnRight.Enabled = false;
            this.btnDown.Enabled = false;
            this.chkTree.Enabled = false;
            this.btnEnableTree.Enabled = false;
            t.Focus();
        }

        private void removeHitMessage()
        {
            if(this.treeElements.SelectedNode != null 
                && this.treeElements.SelectedNodes.Count > 0 
                && this.treeSourceElements.Items.Count == 1 
                && this.treeSourceElements.Items[0].SubItems[0].Text == ResourceInitializer.TEXT_HIT_RETURN_SOURCEELEMENTS)
            {
                this.treeSourceElements.Items.Clear();
                this.fixChkFactor();
            }
        }

        private void addNewElement()
        {
            string type = "N";

            if ((this.CubeViewStatus == GeneralConst.SYSTEM_CUBE_VIEW) || (cmbElementType.SelectedIndex == 1))
            {
                type = "S";
            }
            this.addNewElement(type);
        }

        private void addNewElement(string type)
        {
            JNode tN = new JNode();
            //  JMM 03-20-14:
            if (!this.treeElements.Font.Equals(this.regularFont))                        
                this.treeElements.Font = this.regularFont;
            this.treeElements.LabelEdit = true;
            if (this.NoElements(this.treeElements))
            {
                this.treeElements.Nodes.Remove(this.treeElements.Nodes[0]);
                this.treeElements.ImageList = this.imgListElements;
            }

            tN.Text = this.GetNewLabelText();
            tN.Tag = type;
            if(type=="S")
            {
                tN.ImageIndex = 1;
                tN.SelectedImageIndex = 1;
            }
            else
            {
                tN.ImageIndex = 0;
                tN.SelectedImageIndex = 0;
            }
            if(this.treeElements.SelectedNode != null)
            {
                this.treeElements.SelectedNode.NodeFont = this.regularFont;
                this.treeElements.Nodes.Insert(this.treeElements.SelectedNode.Index+1,tN);
            }
            else
            {
                this.treeElements.Nodes.Add(tN);
            }
            this.treeElements.SelectedNode = tN;
            this.currElementNode = tN;
            this.nfoAddElement = true;

            #region Clear C list
            this.ListViewHideHeader();
            this.treeSourceElements.View = System.Windows.Forms.View.Details;
            this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.chkFactor.Visible = false;
            this.treeSourceElements.Items.Clear();
            #endregion

            tN.BeginEdit();
        }

        private void CheckIfCElementsEmpty()
        {
            if (String.IsNullOrEmpty(currDb) || String.IsNullOrEmpty(currDimension) || (this.currConn == null))
            {
                return;
            }

            ElementInfo[] elems = currConn.DimensionListElements(currDb, currDimension);
            ElementInfo d;
            bool do_ping = false;

            for (int i = 0; i < elems.Length; i++)
            {
                d = elems[i];
                if (d.Type == DimElementType.DimElementTypeConsolidated)
                {
                    //ConsolidationInfo[] cnfo = this.currConn.DimElementListConsolidated(db, dim, (string)d.Name);

                    if (d.Children.LongLength == 0)
                    {
                        currConn.DimensionAddOrUpdateElement(currDb, currDimension, d.Name, AddOrUpdateElementMode.AddOrUpdateElementModeUpdate, DimElementType.DimElementTypeNumeric, new ConsolidationInfo[] { }, false);
                        do_ping = true;
                    }
                }
            }

            if (do_ping)
            {
                currConn.Ping();
            }
        }

        private void delElement()
        {
            // disable action if in edit mode
            if (this.cElementNode != null)
            {
                return;
            }

            if (cmbElementType.SelectedIndex > 1)
            {
                this.RemoveSubset();
            }
            else
            {

                if (this.treeElements.SelectedNode != null
                    && this.treeElements.Nodes[0].Text != GetHitLabelText()
                    && this.treeElements.SelectedNodes.Count > 0
                    && this.treeElements.SelectedNode.Index != -1)
                {
                    System.Text.StringBuilder strSelectedNodes = new System.Text.StringBuilder();
                    int tmpCounter = 0;
                    ArrayList tC = new ArrayList(this.treeElements.SelectedNodes);
                    //foreach(JNode t in this.treeElements.SelectedNodes)
                    for (int i = 0; i < this.treeElements.SelectedNodes.Count; i++)
                    {
                        string sNodeText = this.treeElements.SelectedNodes[i].Text;
                        strSelectedNodes.Append(sNodeText + ", ");

                        if (tmpCounter > 9)
                        {
                            strSelectedNodes.Append(sNodeText + ",..., ");
                            break;
                        }

                        tmpCounter++;
                    }
                    string strSelectedNodesString = (string)strSelectedNodes.ToString().Substring(0, strSelectedNodes.ToString().Length - 2);

                    if (MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.TEXT_DELETE_ELEMENTS, new object[] { strSelectedNodesString }), ResourceInitializer.TEXT_DELETE_ELEMENTS_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        // empty the source nodes list
                        this.treeSourceElements.Items.Clear();
                        try
                        {
                            string[] elements = new string[tC.Count];

                            for (int i = 0; i < tC.Count; i++)
                            {
                                JNode t = (JNode)tC[i];
                                elements[i] = t.Text;
                            }

                            try
                            {
                                this.currConn.DimElementDeleteMulti(this.currDb, this.currDimension, elements);
                                this.currConn.Ping();

                                this.treeElements.Visible = false;

                                for (int i = 0; i < tC.Count; i++)
                                {
                                    JNode t = (JNode)tC[i];
                                    try
                                    {
                                        this.treeElements.Nodes.Remove(t);
                                    }
                                    catch (Exception ex)
                                    {
                                        ErrorHandler.DisplayError("Error removing elements from tree", ex);
                                    }
                                }

                                this.treeElements.Visible = true;

                            }
                            catch (PaloException ex)
                            {
                                ErrorHandler.ErrorPopup(ex.Message, MessageBoxIcon.Error);
                            }

                            if (this.treeElements.Nodes.Count == 0)
                            {
                                this.showHitElements(ref this.treeElements);
                            }
                            else
                            {
                                CheckIfCElementsEmpty();
                                this.showElements(false);
                            }
                        }
                        catch (Exception exc)
                        {
                            ErrorHandler.DisplayError("Error deleting element!", exc);
                        }
                    }
                }
            }
        }
           

        private void editElement()
        {
            // avoid element editing if in UserManagement modus
            if (this.EditUsersState == true)
            {
                return;
            }

            this.MakeElementSortButtonVisible(false);

            if (this.treeElements.SelectedNode != null && this.treeElements.Nodes.Count > 1)
            {
                for(int i=0; i<this.treeElements.Nodes.Count; i++)
                {
                    JNode t = (JNode)this.treeElements.Nodes[i];
                    t.ForeColor = Color.Black;
                    t.BackColor = SystemColors.ControlLightLight;
                }

                this.chkTree.Enabled = false;
                this.btnEnableTree.Enabled = false;
                this.cmbElementType.Enabled = false;
                this.cmdElemCopy.Enabled = false;
                this.cmdElemPaste.Enabled = false;
                this.btnDown.Enabled = false;
                this.btnLeft.Enabled = false;
                this.btnRight.Enabled = false;
                this.btnUp.Enabled = false;
                this.treeElements.DoubleClick -= new System.EventHandler(this.treeElements_DoubleClick);
                this.treeElements.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp);
                this.treeElements.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp2);
                this.treeSourceElements.DoubleClick += new System.EventHandler(this.treeSourceElements_DoubleClick);
                this.cTab = this.tabMain.SelectedTab as JTabPage;
                this.treeElements.DoubleClick += new System.EventHandler(this.treeElements_DoubleClick2);
                this.btnElementAdd.Enabled = false;
                this.btnElementRemove.Enabled = false;
                this.btnElementRename.Enabled = false;
                this.btnElementEdit.Enabled = false;
                this.btnHome.Enabled = false;
                this.treeElements.LabelEdit = false;
                this.btnClose.Enabled = false;
                this.btnElementApplyChanges.Visible = true;
                this.btnElementApplyChanges.Enabled = true;
                this.btnElementCancelChanges.Visible = true;
                this.btnElementCancelChanges.Enabled = true;
                this.treeElements.SelectedNode.NodeFont = this.boldFont;
                this.treeElements.SelectedNode.ForeColor = Color.Black;
                // Per MS KB937215:
                this.treeElements.SelectedNode.Text += string.Empty;
                this.cElementNode = (JNode)((JNode)this.treeElements.SelectedNode).Clone();
                this.cElementNode.ForeColor = Color.Black;
                this.cElementNodeIndex = (int)this.treeElements.SelectedNode.Index;

                try
                {
                    this.ConsolidatedElements.Clear();

                    if (this.currConn.ElementType(this.currDb, this.currDimension, this.cElementNode.Text) != DimElementType.DimElementTypeConsolidated)
                    {
                        this.treeSourceElements.Items.Clear();
                    }
                    else
                    {
                        this.FillTreeSource();
                    }
                }
                catch
                {}

                this.treeElements.SelectedNode = null;
                this.treeElements.SelectedNodes.Clear();
            }

            if ((this.treeSourceElements.Items.Count == 0) && (this.treeElements.Nodes.Count > 1 && this.treeElements.SelectedNode != null))
            {
                string[] t = new string[]{(string)ResourceInitializer.TEXT_HIT_RETURN_SOURCEELEMENTS, "", (string)ResourceInitializer.TEXT_HIT_RETURN_SOURCEELEMENTS, ""};
                ListViewItem lvi = new ListViewItem(t);
                this.treeSourceElements.Items.Add(lvi);
                this.treeSourceElements.View = System.Windows.Forms.View.Details;
                this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                this.ListViewHideHeader();
                this.btnElementApplyChanges.Enabled = false;
                this.btnLeft.Enabled = false;
                this.chkFactor.Visible = false;
            }

        }

        private void removeSelectedSourceElements()
        {
            if(this.treeSourceElements.Items != null && this.treeSourceElements.SelectedItems != null && this.treeSourceElements.Items.Count > 0)
            {
                ArrayList tn = new ArrayList(this.treeSourceElements.SelectedItems);
                //foreach(ListViewItem t in tn)
                ListViewItem lvi;
                for(int i=0; i<tn.Count; i++)
                {
                    lvi = (ListViewItem)tn[i];
                    this.treeSourceElements.Items.Remove(lvi);
                    this.ConsolidatedElements.Remove(lvi.Text);
                }
            }

            if(this.treeSourceElements.Items.Count == 0)
            {
                this.ListViewHideHeader();
                string[] t = new string[]{(string)ResourceInitializer.TEXT_HIT_RETURN_SOURCEELEMENTS, "", (string)ResourceInitializer.TEXT_HIT_RETURN_SOURCEELEMENTS, ""};
                ListViewItem lvi = new ListViewItem(t);
                this.treeSourceElements.Items.Add(lvi);
                this.treeSourceElements.View = System.Windows.Forms.View.Details;
                this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                this.btnElementApplyChanges.Enabled = true;
                this.btnLeft.Enabled = false;
                this.chkFactor.Visible = false;
            }

            //this.xpCopy.Enabled = false;
            this.cmdElemCopy.Enabled = false;
            this.btnUp.Enabled = false;
            this.btnLeft.Enabled = false;
            this.btnRight.Enabled = false;
            this.btnDown.Enabled = false;
        }

        #endregion

        #region Move Element to Begin/End
        private void cmdElementMoveBegin_Click(object sender, EventArgs e)
        {
            if (this.treeElements.SelectedNode == null)
                return;

            try
            {
                int numberSelected = this.treeElements.SelectedNodes.Count;
                int[] Inds = new int[numberSelected];
                JNode[] tNs = new JNode[numberSelected];

                for (int i = 0; i < numberSelected; i++)
                {
                    Inds[i] = this.treeElements.SelectedNodes[i].Index;
                    JNode tN = (JNode)((JNode)this.treeElements.SelectedNodes[i]).Clone();
                    tNs[i] = tN;
                }
                this.treeElements.DeselectAll();
                Array.Sort(Inds, tNs);
                for (int i = 0; i < numberSelected; i++)
                {
                    // Check if this element is already at the beginning.
                    if (Inds[i] == i)
                    {
                        continue;
                    }
                    this.currConn.DimElementMove(this.currDb, this.currDimension, tNs[i].Text, (uint)i);
                    this.currConn.Ping();
                    this.treeElements.Nodes.RemoveAt(Inds[i]);
                    this.treeElements.Nodes.Insert(i, tNs[i]);                    
                    //CDMN: this.treeElements.Nodes[i].Select(true);
                    this.treeElements.SelectNode(treeElements.Nodes[i]);
                }                          
            }
            catch (PaloException pec)
            {
                ErrorHandler.DisplayError("Error moving element to the beginning!", pec);
            }
        }

        private void cmdElementMoveEnd_Click(object sender, EventArgs e)
        {
            if (this.treeElements.SelectedNode == null)
                return;

            try
            {
                int numberExistent = this.treeElements.Nodes.Count;
                int numberSelected = this.treeElements.SelectedNodes.Count;
                int[] Inds = new int[numberSelected];
                JNode[] tNs = new JNode[numberSelected];
                for (int i = 0; i < numberSelected; i++)
                {
                    Inds[i] = this.treeElements.SelectedNodes[i].Index;
                    JNode tN = (JNode)((JNode)this.treeElements.SelectedNodes[i]).Clone();
                    tNs[i] = tN;
                }
                this.treeElements.DeselectAll();
                Array.Sort(Inds, tNs);
                for (int i = 0; i < numberSelected; i++)
                {
                    // Check if this element is already at the end.
                    if (Inds[numberSelected - i - 1] == numberExistent - i - 1)
                    {
                        continue;
                    }
                    this.currConn.DimElementMove(this.currDb, this.currDimension, tNs[numberSelected - i - 1].Text, (uint)(numberExistent - i - 1));
                    this.currConn.Ping();
                    this.treeElements.Nodes.RemoveAt(Inds[numberSelected - i - 1]);
                    this.treeElements.Nodes.Insert(numberExistent - i - 1, tNs[numberSelected - i - 1]);
                    //CDMN: this.treeElements.Nodes[numberExistent - i - 1].Select(true);
                    this.treeElements.SelectNode(this.treeElements.Nodes[numberExistent - i - 1]);      //Select(true);
                }
            }
            catch (PaloException pec)
            {
                ErrorHandler.DisplayError("Error moving element to the end!", pec);
            }
        }

        private void cmdSrcElementMoveBegin_Click(object sender, EventArgs e)
        {
            if (this.treeSourceElements.SelectedItems == null)
                return;

            int numberSelected = this.treeSourceElements.SelectedItems.Count;
            int[] Inds = new int[numberSelected];
            ListViewItem[] tNs = new ListViewItem[numberSelected];

            for (int i = 0; i < numberSelected; i++)
            {
                Inds[i] = this.treeSourceElements.SelectedItems[i].Index;
                ListViewItem tN = (ListViewItem)this.treeSourceElements.SelectedItems[i].Clone();
                tNs[i] = tN;
            }
            this.treeSourceElements.SelectedItems.Clear();
            Array.Sort(Inds, tNs);
            for (int i = 0; i < numberSelected; i++)
            {
                // Check if this element is already at the beginning.
                if (Inds[i] == i)
                {
                    continue;
                }
                this.treeSourceElements.Items.RemoveAt(Inds[i]);
                this.treeSourceElements.Items.Insert(i, tNs[i]);
                this.treeSourceElements.Items[i].Selected = true;
            }
        }

        private void cmdSrcElementMoveEnd_Click(object sender, EventArgs e)
        {
            if (this.treeSourceElements.SelectedItems == null)
                return;

            int numberExistent = this.treeSourceElements.Items.Count;
            int numberSelected = this.treeSourceElements.SelectedItems.Count;
            int[] Inds = new int[numberSelected];
            ListViewItem[] tNs = new ListViewItem[numberSelected];

            for (int i = 0; i < numberSelected; i++)
            {
                Inds[i] = this.treeSourceElements.SelectedItems[i].Index;
                ListViewItem tN = (ListViewItem)this.treeSourceElements.SelectedItems[i].Clone();
                tNs[i] = tN;
            }
            this.treeSourceElements.SelectedItems.Clear();
            Array.Sort(Inds, tNs);
            for (int i = 0; i < numberSelected; i++)
            {
                // Check if this element is already at the end.
                if (Inds[numberSelected - i - 1] == numberExistent - i - 1)
                {
                    continue;
                }
                this.treeSourceElements.Items.RemoveAt(Inds[numberSelected - i - 1]);
                this.treeSourceElements.Items.Insert(numberExistent - i - 1, tNs[numberSelected - i - 1]);
                this.treeSourceElements.Items[numberExistent - i - 1].Selected = true;
            }
        }
        #endregion

        #region Button functions

        private void btnCopy_Click(object sender, System.EventArgs e)
        {
            try
            {
                ArrayList tmpSN = new ArrayList();
                int tnCount = treeElements.Nodes.Count;

                for (int i=0;i<tnCount;i++)
                {
                    JNode n = (JNode)treeElements.Nodes[i];                    
                    //CDNM: if (n.IsSelected)
                    if (treeElements.IsNodeSelected(n))
                        tmpSN.Add(n);
                }

                this.CopyToClipboard(tmpSN);
                ArrayList a = new ArrayList();

                if(ReadClipBoard(ref a) == true)
                    this.cmdElemPaste.Enabled = true;
                else
                    this.cmdElemPaste.Enabled = false;

            }
            catch//(Exception err)
            {
                //ErrorHandler.DisplayError("Error in xpCopy_Click", err);
            }
        }

        private void btnPaste_Click(object sender, System.EventArgs e)
        {
            uint MovePos;
            ArrayList a = new ArrayList();

            try
            {
                if(this.treeElements.SelectedNode != null && this.treeElements.SelectedNode.Index != -1)
                {
                    MovePos = (uint)this.treeElements.SelectedNode.Index;
                }
                else
                {
                    MovePos = 0;
                }

                if(ReadClipBoard(ref a) == true)
                {
                    if(this.InsertClipBoard(a, MovePos, this.treeElements) || (this.treeElements.Nodes != null && this.treeElements.Nodes.Count > 1))
                    {
                        this.chkTree.Enabled = true;
                        this.btnEnableTree.Enabled = true;
                    }
                }
            }
            catch(Exception ep)
            {
                ErrorHandler.DisplayError("Error pasting elements!", ep);
            }
        }

        #region Workaround for SelectedNodes sorting

        private bool checkExisting(string item)
        {
            int tmpCnt = this.treeSourceElements.Items.Count;
            for (int i = 0; i < tmpCnt; i++)
            {
                System.Windows.Forms.ListViewItem lvi = this.treeSourceElements.Items[i];
                if (item == lvi.SubItems[0].Text)
                    return true;
            }
            return false;
        }

        #endregion

        private void moveRight()
        {
            if (this.treeElements.Nodes == null && this.treeElements.SelectedNodes == null)
                return;
            
            if(this.treeElements.SelectedNode != null && this.treeElements.SelectedNode.Text != this.cElementNode.Text)
                this.removeHitMessage();

            if(this.treeSourceElements.Items.Count == 0)
                this.ListViewHideHeader();

            // JMM 03-20-14:
            NodesCollection SelNodes = treeElements.SelectedNodes;
            for (int i = 0; i < SelNodes.Count; i++)
            {
                JNode t = (JNode)SelNodes[i];
                if(this.cElementNode.Text != t.Text)
                {
                    string[] it = new string[]{t.Text, "1   "};
                    System.Windows.Forms.ListViewItem lvi = new ListViewItem(it);

                    if ((this.ConsolidatedElements.ContainsKey(t.Text) == false) && (this.checkExisting(t.Text) == false))
                    {
                        this.treeSourceElements.Items.Add(lvi);
                        this.ConsolidatedElements.Add(t.Text, t.Text);
                    }
                }
            }

            this.btnElementApplyChanges.Enabled = true;
        }

        private void btnRight_Click(object sender, System.EventArgs e)
        {
            this.moveRight();
        }

        private void btnLeft_Click(object sender, System.EventArgs e)
        {
            this.removeSelectedSourceElements();
        }

        private void cmdDelSrcElem_Click(object sender, System.EventArgs e)
        {
            this.removeSelectedSourceElements();
        }

        private void btnUp_Click(object sender, System.EventArgs e)
        {
            if (this.cElementNode == null)
            {
                if (this.treeElements.SelectedNode != null)
                {
                    try
                    {
                        for (int i = 0; i < this.treeElements.Nodes.Count; i++)
                        {
                            this.treeElements.Nodes[i].NodeFont = this.regularFont;
                        }

                        int numberSelected = this.treeElements.SelectedNodes.Count;
                        int[] Inds = new int[numberSelected];
                        JNode[] tNs = new JNode[numberSelected];

                        for (int i = 0; i < numberSelected; i++)
                        {
                            Inds[i] = this.treeElements.SelectedNodes[i].Index;
                            tNs[i] = (JNode)((JNode)this.treeElements.SelectedNodes[i]).Clone(); ;

                            if (Inds[i] == 0)
                            {   // If the first Node is selected, no change.
                                return;
                            }
                        }
                        this.treeElements.DeselectAll();
                        Array.Sort(Inds, tNs);
                        for (int i = 0; i < numberSelected; i++)
                        {
                            this.currConn.DimElementMove(this.currDb, this.currDimension, tNs[i].Text, (uint)(Inds[i] - 1));
                            this.currConn.Ping();
                            this.treeElements.Nodes.RemoveAt(Inds[i]);
                            this.treeElements.Nodes.Insert(Inds[i] - 1, tNs[i]);
                            //CDMN: this.treeElements.Nodes[Inds[i] - 1].Select(true);
                            this.treeElements.SelectNode(this.treeElements.Nodes[Inds[i] - 1]); //Select(true);
                        }
                        Connect.changesMade = true;
                    }
                    catch (Exception connExc)
                    {
                        ErrorHandler.DisplayError("Error in moving up element!", connExc);
                    }
                }
            }
            else
            {
                if (this.treeSourceElements.SelectedItems != null)
                {
                    try
                    {
                        int i;
                        for (i = 0; i < this.treeSourceElements.Items.Count; i++)
                        {
                            this.treeSourceElements.Items[i].Font = this.regularFont;
                        }

                        int numberSelected = this.treeSourceElements.SelectedItems.Count;
                        int[] Inds = new int[numberSelected];
                        ListViewItem[] tNs = new ListViewItem[numberSelected];

                        for (i = 0; i < numberSelected; i++)
                        {
                            Inds[i] = this.treeSourceElements.SelectedItems[i].Index;
                            tNs[i] = (ListViewItem)this.treeSourceElements.SelectedItems[i].Clone(); ;

                            if (Inds[i] == 0)
                            {   // If the first Item is selected, no change.
                                return;
                            }
                        }
                        this.treeSourceElements.SelectedItems.Clear();
                        Array.Sort(Inds, tNs);
                        for (i = 0; i < numberSelected; i++)
                        {
                            this.treeSourceElements.Items.RemoveAt(Inds[i]);
                            this.treeSourceElements.Items.Insert(Inds[i] - 1, tNs[i]);
                            this.treeSourceElements.Items[Inds[i] - 1].Selected = true;
                            this.treeSourceElements.Items[Inds[i] - 1].Focused = true;
                        }
                        this.treeSourceElements.Focus();
                    }
                    catch (Exception connExc)
                    {
                        ErrorHandler.DisplayError("Error in moving up child!", connExc);
                    }
                }
            }
        }

        private void btnDown_Click(object sender, System.EventArgs e)
        {
            if (this.cElementNode == null)
            {
                if (this.treeElements.SelectedNode != null)
                {
                    try
                    {
                        int numberExistent = this.treeElements.Nodes.Count;
                        for (int i = 0; i < numberExistent; i++)
                        {
                            this.treeElements.Nodes[i].NodeFont = this.regularFont;
                        }

                        int numberSelected = this.treeElements.SelectedNodes.Count;
                        int[] Inds = new int[numberSelected];
                        JNode[] tNs = new JNode[numberSelected];
                        
                        for (int i = 0; i < numberSelected; i++)
                        {
                            Inds[i] = this.treeElements.SelectedNodes[i].Index;
                            tNs[i] = (JNode)((JNode)this.treeElements.SelectedNodes[i]).Clone();
                            
                            if (Inds[i] == numberExistent - 1)
                            {   // If the last Node is selected, no change.
                                return;
                            }
                        }
                        this.treeElements.DeselectAll();
                        Array.Sort(Inds, tNs);
                        for (int i = numberSelected - 1; i > -1; i--)
                        {
                            this.currConn.DimElementMove(this.currDb, this.currDimension, tNs[i].Text, (uint)(Inds[i] + 1));
                            this.currConn.Ping();
                            this.treeElements.Nodes.RemoveAt(Inds[i]);
                            this.treeElements.Nodes.Insert(Inds[i] + 1, tNs[i]);
                            //CDMN: this.treeElements.Nodes[Inds[i] + 1].Select(true);
                            this.treeElements.SelectNode(this.treeElements.Nodes[Inds[i] + 1]);     //Select(true);
                        }
                        Connect.changesMade = true;
                    }
                    catch (Exception connExc)
                    {
                        ErrorHandler.DisplayError("Error in moving down element!", connExc);
                    }

                }
            }
            else
            {
                if (this.treeSourceElements.SelectedItems != null)
                {
                    try
                    {
                        int i, numberExistent = this.treeSourceElements.Items.Count;
                        for (i = 0; i < numberExistent; i++)
                        {
                            this.treeSourceElements.Items[i].Font = this.regularFont;
                        }

                        int numberSelected = this.treeSourceElements.SelectedItems.Count;
                        int[] Inds = new int[numberSelected];
                        ListViewItem[] tNs = new ListViewItem[numberSelected];

                        for (i = 0; i < numberSelected; i++)
                        {
                            Inds[i] = this.treeSourceElements.SelectedItems[i].Index;
                            tNs[i] = (ListViewItem)this.treeSourceElements.SelectedItems[i].Clone(); ;
                            
                            if (Inds[i] == numberExistent - 1)
                            {   // If the last Item is selected, no change.
                                return;
                            }
                        }
                        this.treeSourceElements.SelectedItems.Clear();
                        Array.Sort(Inds, tNs);
                        for (i = numberSelected - 1; i > -1; i--)
                        {
                            this.treeSourceElements.Items.RemoveAt(Inds[i]);
                            this.treeSourceElements.Items.Insert(Inds[i] + 1, tNs[i]);
                            this.treeSourceElements.Items[Inds[i] + 1].Selected = true;
                            this.treeSourceElements.Items[Inds[i] + 1].Focused = true;
                        }
                        this.treeSourceElements.Focus();
                    }
                    catch (Exception connExc)
                    {
                        ErrorHandler.DisplayError("Error in moving down child!", connExc);
                    }
                }
            }
        }

        private void btnElementAdd_Click(object sender, System.EventArgs e)
        {
            if (cmbElementType.SelectedIndex == 2)
            {
                DoCallSubSetEditor();
            }
            else
            {
                if (this.cElementNode == null)// disable action if in edit mode
                {
                    this.addNewElement();
                }
            }
        }

        private void btnElementRemove_Click(object sender, System.EventArgs e)
        {
            this.delElement();
        }

        private void btnElementRename_Click(object sender, System.EventArgs e)
        {
            // disable action if in edit mode
            if(this.cElementNode == null)
            {
                if (this.treeElements.SelectedNode != null && this.treeElements.Nodes[0].Text != GetHitLabelText())
                {
                    try
                    {
                        if(this.treeElements.SelectedNode.Index != -1)
                        {
                            this.treeElements.LabelEdit = true;
                            this.treeElements.SelectedNode.NodeFont = this.regularFont;
                            //  JMM 03-20-14:
                            if (!this.treeElements.Font.Equals(this.regularFont))  
                                this.treeElements.Font = this.regularFont;
                            this.treeElements.SelectedNode.BeginEdit();
                        }
                    }
                    catch(Exception renDimExc)
                    {
                        ErrorHandler.DisplayError("Error renaming element!", renDimExc);
                    }
                }
            }
        }

        private void cmdShowParents_Click(object sender, System.EventArgs e)
        {
            // disable action if in edit mode
            if (this.cElementNode == null)
            {
                if (this.treeElements.SelectedNode != null && this.treeElements.Nodes[0].Text != GetHitLabelText())
                {
                    try
                    {
                        ElementInfo ei = this.currConn.ElementInformationSimple(this.currDb, this.currDimension, this.treeElements.SelectedNode.Text);

                        int i, pcount = ei.Parents.Length, len;
                        string parents = "", parent;

                        for (i = 0; i < pcount; i++)
                        {
                            // JMM 09-01-15 Modified for 5.1 library compatibility
                            parent = this.currConn.GetElementNameFromID(this.currDb, this.currDimension, ei.Parents[i].Identifier);                            
                            //ei.Parents[i].Name;
                            if (!string.IsNullOrEmpty(parent))
                            {
                                parents += parent + GeneralConst.UNIX_NEWLINE;
                            }
                        }

                        len = parents.Length;

                        if (len > 0)
                        {
                            parents = parents.Substring(0, len - 1);
                        }

                        MessageBox.Show(parents);
                    }
                    catch (Exception showParentsEx)
                    {
                        ErrorHandler.DisplayError("Error show Parents!", showParentsEx);
                    }
                }
            }
        }



        private void btnElementEdit_Click(object sender, System.EventArgs e)
        {
            if (this.treeElements.SelectedNodes.Count > 0 && this.treeElements.SelectedNode != null && this.treeElements.Nodes[0].Text != GetHitLabelText())
            {
                // disable action if in edit mode
                if(this.cElementNode == null)
                {
                    this.InElementchange = true;
                    this.editElement();
                }
            }
        }
                
        private void activateElementNode(String element)
        {
            int i, slenght = this.treeElements.Nodes.Count;
            TreeNode node;

            this.treeElements.UnselectAllNodes();

            for (i = 0; i < slenght; i++)
            {
                node = this.treeElements.Nodes[i];
                if (node.Text == element)
                {
                    //CDNM: node.Select(false);
                    treeElements.SelectedNode = node;
                    break;
                }
            }

        }

        private void btnElementCancelChanges_Click(object sender, System.EventArgs e)
        {
            this.InElementchange = false;
            this.treeElements.DoubleClick -= new System.EventHandler(this.treeElements_DoubleClick2);
            this.treeElements.DoubleClick += new System.EventHandler(this.treeElements_DoubleClick);
            this.treeElements.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp2);
            this.treeElements.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp);
            this.treeSourceElements.DoubleClick -= new System.EventHandler(this.treeSourceElements_DoubleClick);
            this.cTab = null;

            for(int i=0; i< this.treeElements.Nodes.Count; i++)
            {
                JNode t = (JNode)this.treeElements.Nodes[i];
                t.NodeFont = this.regularFont;
                t.ForeColor = Color.Black;
                t.BackColor = SystemColors.ControlLightLight;
            }
            this.btnElementApplyChanges.Enabled = false;
            this.btnElementApplyChanges.Visible = false;
            this.btnElementCancelChanges.Enabled = false;
            this.btnElementCancelChanges.Visible = false;
            this.btnElementAdd.Enabled = true;
            this.btnElementRemove.Enabled = false;
            this.btnElementRename.Enabled = false;
            this.btnElementEdit.Enabled = false;
            this.btnHome.Enabled = true;
            this.treeElements.SelectedNode = null;
            this.treeElements.SelectedNodes.Clear();
            this.treeSourceElements.View = System.Windows.Forms.View.Details;
            this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.chkFactor.Visible = false;
            this.cmbElementType.Enabled = true;
            this.btnRight.Enabled = false;
            this.btnLeft.Enabled = false;
            this.treeElements.LabelEdit = false;
            this.btnClose.Enabled = true;
            this.chkTree.Enabled = true;
            this.btnEnableTree.Enabled = true;
            this.treeSourceElements.Items.Clear();
            activateElementNode(this.cElementNode.Text);
            this.FillTreeSource();
            this.cElementNode = null;
            this.MakeElementSortButtonVisible(true);
        }

        private void HandleCircular(PaloException pe)
        {
            string msg;

            switch (pe.ErrorCode)
            {
                case -55:
                case 4001:
                    msg = ResourceInitializer.ERROR_CIRCULAR;
                    break;

                default:
                    msg = pe.Message;
                    break;
            }

            ErrorHandler.ErrorPopup(msg);
        }

        private void btnElementApplyChanges_Click(object sender, System.EventArgs e)
        {
            this.InElementchange = false;
            try
            {
                ConsolidationInfo[] ci = new ConsolidationInfo[this.treeSourceElements.Items.Count];
                int i, counter = 0, slenght = this.treeSourceElements.Items.Count;
                ListViewItem t;
                string tmpNodeText;
                double tmpNodeValue;
                
                for(i=0; i< slenght; i++)
                {
                    t = this.treeSourceElements.Items[i];
                    tmpNodeText = t.SubItems[0].Text;

                    // if only hint message is displayed then save element as N element
                    if(tmpNodeText == ResourceInitializer.TEXT_HIT_RETURN_SOURCEELEMENTS)
                    {
                        counter = 0;
                        break;
                    }

                    tmpNodeValue = System.Convert.ToDouble(t.SubItems[1].Text);
                    ci[counter] =  new ConsolidationInfo(tmpNodeText,tmpNodeValue);
                    counter++;
                }

                // if no subelements selected then insert N element
                if(counter == 0)
                {
                    this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, this.cElementNode.Text);
                    this.currConn.Ping();
                    Connect.changesMade = true;
                }
                else
                {
                    try
                    {
                        this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, this.cElementNode.Text, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, ci, false);
                        this.currConn.Ping();
                        Connect.changesMade = true;
                    }
                    catch(PaloException excDau)
                    {
                        HandleCircular(excDau);
                    }
                }

                this.showElements(false);

                // cleanup
                this.btnElementApplyChanges.Enabled = false;
                this.btnElementApplyChanges.Visible = false;
                this.btnElementCancelChanges.Enabled = false;
                this.btnElementCancelChanges.Visible = false;
                this.btnElementAdd.Enabled = true;
                this.btnElementRemove.Enabled = false;
                this.btnElementRename.Enabled = false;
                this.btnElementEdit.Enabled = false;
                this.btnHome.Enabled = true;
                this.treeElements.SelectedNode = null;
                this.treeElements.SelectedNodes.Clear();
                this.treeSourceElements.View = System.Windows.Forms.View.Details;
                this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                this.chkFactor.Visible = false;
                this.cmbElementType.Enabled = true;
                this.treeElements.LabelEdit = false;
                this.btnClose.Enabled = true;
                this.chkTree.Enabled = true;
                this.btnEnableTree.Enabled = true;
                this.btnLeft.Enabled = false;
                this.btnRight.Enabled = false;
                this.treeElements.DoubleClick -= new System.EventHandler(this.treeElements_DoubleClick2);
                this.treeElements.DoubleClick += new System.EventHandler(this.treeElements_DoubleClick);
                this.treeElements.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp2);
                this.treeElements.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp);
                this.treeSourceElements.DoubleClick -= new System.EventHandler(this.treeSourceElements_DoubleClick);
                this.cTab = null;
                activateElementNode(this.cElementNode.Text);
                this.cElementNode = null;
                this.MakeElementSortButtonVisible(true);
            }
            catch(Exception exc)
            {
                ErrorHandler.DisplayError("Error applying changes!", exc);
            }           
        }


        #endregion

        #region TreeView / ListView Events

        #region treeElements

        #region showElements
        private void showElements(bool tree)
        {
            showElements(tree, ref this.treeElements);
        }

        public void showElements(bool tree, ref JTreeView treeCtrl)
        {

            string selectedNodeText = "";

            if (treeCtrl.SelectedNode != null)
            {
                selectedNodeText = treeCtrl.SelectedNode.Text;
            }

            TreeHelper.showElements(this.currConn, this.currDb, this.currDimension, tree, this.regularFont, ref treeCtrl);

            int i, tmpNodesCnt = treeCtrl.Nodes.Count;

            for(i=0;i<tmpNodesCnt;i++)
            {
                if((treeCtrl.Nodes[i].Text == selectedNodeText) && (treeCtrl.Nodes[i] != null))
                {
                    try
                    {                        
                        //CDNM: treeCtrl.Nodes[i].Select();
                        if (treeCtrl.Nodes.Contains(treeCtrl.Nodes[i]))
                            {
                            treeCtrl.SelectNode(treeCtrl.Nodes[i]);
                            }

                        //CDNM: if(treeCtrl.Nodes[i].IsSelected == true)
                        if (treeCtrl.IsNodeSelected(treeCtrl.Nodes[i]))
                            {
                            //CDNM: treeCtrl.Nodes[i].Visible = true;
                            //CDNM: treeCtrl.EnsureDisplayed(treeCtrl.Nodes[i]);
                            treeCtrl.Nodes[i].EnsureVisible();
                            }
                    }
                    catch
                    {}
                }

                if (treeCtrl.Nodes[i].Nodes != null && treeCtrl.Nodes[i].Nodes.Count > 0)
                {
                    this.ActivateNode((JNode)treeCtrl.Nodes[i], selectedNodeText);
                }
            }
        }

        private void ActivateNode(JNode tN, string selectedNodeText)
        {
            for(int i=0;i<tN.Nodes.Count;i++)
            {
                JNode t = (JNode)tN.Nodes[i];
                if(t.Nodes != null && t.Nodes.Count > 0)
                    this.ActivateNode(t, selectedNodeText);

                if(t.Text == selectedNodeText)
                {
                    //CDNM: t.Select();
                    try
                    {
                    //CDNM: this.treeElements.SelectedNode = t;
                    treeElements.SelectNode(t);
                    }
                    catch
                    {}
                }
            }
        }

      
        #endregion

        #region chkTree
        private void btnEnableTree_Click(object sender, System.EventArgs e)
        {
            if (chkTree.Checked == true)
            {
                chkTree.Checked = false;
                btnEnableTree.ButtonImage = (Image)ResourceInitializer.IconShowFlatButton;
                btnEnableTree.RolloverImage = (Image)ResourceInitializer.IconShowFlatButton;
            }
            else
            {
                chkTree.Checked = true;
                btnEnableTree.ButtonImage = (Image)ResourceInitializer.IconShowHierarchyButtonP;
                btnEnableTree.RolloverImage = (Image)ResourceInitializer.IconShowHierarchyButtonP;
            }
        }

        private void chkTree_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.cElementNode != null)
            {
                return;
            }

            // JMM 1-26-15 Corrects out of memory issue in TreeView ...
            this.treeElements.BeginUpdate();
            this.treeElements.ImageList = this.imgListElements;
            this.SetcurrDimension();

            this.treeSourceElements.Items.Clear();

            if (!this.chkTree.Checked)
            {
                this.cmbElementType.Visible = true;
                //this.treeElements.SelectMode = //CDNM.Controls.SelectMode.Multiple;
                this.treeElements.SelectionMode = TreeViewSelectionMode.MultiSelect;
                this.treeElements.ShowLines = false;
                this.treeElements.ShowPlusMinus = false;
                this.treeElements.ShowRootLines = false;
                this.treeSourceElements.Enabled = true;
                this.btnElementAdd.Enabled = true;
                this.btnUp.Visible = true;
                this.btnLeft.Visible = true;
                this.btnRight.Visible = true;
                this.btnDown.Visible = true;
                this.MakeElementSortButtonVisible(true);
                this.btnOrigElems.Enabled = false;
                this.btnAscElems.Enabled = true;
                this.btnDescElems.Enabled = true;
                this.btnOrigElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
                this.btnAscElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
                this.btnDescElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
                this.lblConsolidatedElements.Visible = true;
                this.lblElements.Visible = true;
                this.btnCollapse.Visible = false;
                this.btnCollapseAll.Visible = false;
                this.btnExpand.Visible = false;
                this.btnExpandAll.Visible = false;
                this.btnExp1.Visible = false;
                this.btnExp2.Visible = false;
                this.btnExp3.Visible = false;
                this.btnExp4.Visible = false;
                this.btnExp5.Visible = false;
                this.btnExp6.Visible = false;
                this.btnExp7.Visible = false;
                this.btnExp8.Visible = false;
                this.treeSourceElements.Visible = true;
                this.setSizes();
                this.treeElements.AfterLabelEdit += new NodeLabelEditEventHandler(this.treeElements_AfterLabelEdit);
                this.treeElements.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp);
                this.treeElements.DoubleClick += new System.EventHandler(this.treeElements_DoubleClick);
                this.treeElements.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeElements_KeyDown);
                this.treeElements.AllowDrop = false;
                this.treeElements.DragOver -= treeElements_NodeDragOver;
                this.treeElements.DragDrop -= treeElements_NodeDragDrop;
                this.treeElements.ItemDrag -= treeElements_NodeDrag;
                
            }
            else
            {
                this.cmbElementType.Visible = false;
                this.treeElements.SelectionMode = TreeViewSelectionMode.SingleSelect;
                //this.treeElements.SelectMode = CDNM.Controls.SelectMode.Single;
                this.treeElements.ShowLines = true;
                this.treeElements.ShowPlusMinus = true;
                this.treeElements.ShowRootLines = true;
                this.chkFactor.Visible = false;
                this.treeSourceElements.Enabled = false;
                this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                this.btnUp.Enabled = false;
                this.btnLeft.Enabled = false;
                this.btnRight.Enabled = false;
                this.btnDown.Enabled = false;
                this.btnOrigElems.Enabled = false;
                this.btnAscElems.Enabled = false;
                this.btnDescElems.Enabled = false;
                this.btnElementAdd.Enabled = false;
                this.btnElementRemove.Enabled = false;
                this.btnElementRename.Enabled = false;
                this.btnElementEdit.Enabled = false;
                this.btnUp.Visible = false;
                this.btnLeft.Visible = false;
                this.btnRight.Visible = false;
                this.btnDown.Visible = false;
                this.MakeElementSortButtonVisible(false);
                this.lblElements.Visible = false;
                this.lblConsolidatedElements.Visible = false;
                this.btnCollapse.Visible = true;
                this.btnCollapseAll.Visible = true;
                this.btnExpand.Visible = true;
                this.btnExpandAll.Visible = true;
                this.btnExp1.Visible = true;
                this.btnExp2.Visible = true;
                this.btnExp3.Visible = true;
                this.btnExp4.Visible = true;
                this.btnExp5.Visible = true;
                this.btnExp6.Visible = true;
                this.btnExp7.Visible = true;
                this.btnExp8.Visible = true;
                this.treeSourceElements.Visible = false;
                this.treeElements.Width = this.treeElements.Width + this.treeSourceElements.Width + this.treeSourceElements.Left - this.treeElements.Right;
                this.treeElements.AfterLabelEdit -= new NodeLabelEditEventHandler(this.treeElements_AfterLabelEdit);
                this.treeElements.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp);
                this.treeElements.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp2);
                this.treeElements.DoubleClick -= new System.EventHandler(this.treeElements_DoubleClick);
                this.treeElements.DoubleClick -= new System.EventHandler(this.treeElements_DoubleClick2);
                this.treeElements.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.treeElements_KeyDown);
                this.treeElements.AllowDrop = true;
                this.treeElements.DragOver += new DragEventHandler(treeElements_NodeDragOver);
                this.treeElements.DragDrop += new DragEventHandler(treeElements_NodeDragDrop);
                this.treeElements.ItemDrag += new ItemDragEventHandler(treeElements_NodeDrag);
            }

            // JMM 1-26-15
            this.treeElements.EndUpdate();

            ExcelHelper.SetExcelStatusbar(ReadingMessage);

            if (this.tabMain.SelectedIndex > 0)
            {
                this.showElements(this.chkTree.Checked);
            }
            this.treeSourceElements.Focus();

            ExcelHelper.ResetExcelStatusbar();

        }

        #endregion

        #region LabelEdit

        private void treeElements_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string tN = "";

            // if no node text then remove the node and do nothing
            if (!DontExcuteAfterLabelEdit && (e.Node.Text != null))
            {
                tN = (e.Label != null) ? e.Label : e.Node.Text;

                if (tN.Length > 255)
                {
                    tN = tN.Substring(0, 255);
                }

                // insert element
                if( this.nfoAddElement == true)
                {
                    this.nfoAddElement = false;
                    try
                    {
                        DimElementType etype = DimElementType.DimElementTypeNumeric;
                        if ((this.CubeViewStatus == GeneralConst.SYSTEM_CUBE_VIEW) || (cmbElementType.SelectedIndex == 1))
                        {
                            etype = DimElementType.DimElementTypeString;
                        }

                        this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tN, AddOrUpdateElementMode.AddOrUpdateElementModeForceAdd, etype, new ConsolidationInfo[] { }, false);
                        this.currConn.DimElementMove(this.currDb, this.currDimension, tN, (uint)(e.Node.Index));//, true);
                        this.currConn.Ping();
                        this.chkTree.Enabled = true;
                        this.btnEnableTree.Enabled = true;
                        Connect.changesMade = true;
                    }
                    catch(PaloException addElmExc)
                    {
                        ErrorHandler.HandleErrorElement(addElmExc, "Error adding element!"); 

                        try
                        {
                            this.treeElements.Nodes.Remove(e.Node);
                        }
                        catch
                        {}  
                    }
                }
                else// rename element
                {
                    if(e.Label != null 
                        && (string)e.Label != (string)e.Node.Text)
                    {
                        try
                        {
                            this.currConn.DimElementRename(this.currDb, this.currDimension, e.Node.Text, tN);
                            this.currConn.Ping();
                            Connect.changesMade = true;
                        }
                        catch(PaloException renDimExc)
                        {                       
                            e.CancelEdit = true;
                            ErrorHandler.HandleErrorElementRename(renDimExc);
                        }
                    }
                }
            }
            else
            {
                if(this.treeElements.SelectedNode != null)
                {
                    this.treeElements.Nodes.Remove(e.Node);
                }
            }
            this.treeElements.LabelEdit = false;
            this.treeElements.Font = this.boldFont;
            if(this.treeElements.SelectedNode != null)
            {
                this.treeElements.SelectedNode.NodeFont = this.regularFont;
            }
            DontExcuteAfterLabelEdit = false;
        }

        #endregion

        #region Key


        private void treeElements_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!this.InElementchange && (cmbElementType.SelectedIndex == 0))
            {
                this.treeElements1();
                this.treeElements2();
            }
        }
        
        private void treeElements_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // disable action if in edit mode
            if (this.cElementNode == null)
            {
                // RETURN 13
                if (e.KeyValue == (int)System.Windows.Forms.Keys.Return)
                {
                    e.Handled = true;
                    try
                    {
                        if (cmbElementType.SelectedIndex == 2)
                        {
                            DoCallSubSetEditor();
                        }
                        else if (this.EditUsersState == true)
                        {
                            // in case we are in Edit User mode
                            // we want to make sure we add S element                        
                            this.addNewElement("S");
                        }
                        else
                        {
                            this.addNewElement();
                        }
                    }
                    catch
                    {}
                }// DELETE 46
                else if (e.KeyValue == (int)System.Windows.Forms.Keys.Delete)
                {
                    e.Handled = true;
                    try
                    {
                        this.delElement();
                    }
                    catch
                    {}
                }
                else
                { 
                    e.Handled = true;
                }
            }

            #region <CTRL>
            if ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
            {// handle CTRL + A
                if (e.KeyValue == (int)System.Windows.Forms.Keys.A)
                {
                    e.Handled = true;
                    for(int i=0; i<this.treeElements.Nodes.Count; i++)
                        {
                        //CDNM: this.treeElements.Nodes[i].Select(false);
                        this.treeElements.SelectNode(treeElements.Nodes[i]);
                        }
                }
                else if (e.KeyValue == (int)System.Windows.Forms.Keys.C)
                {
                    e.Handled = true;
                    this.btnCopy_Click(new object(), new System.EventArgs());
                }
                else if (e.KeyValue == (int)System.Windows.Forms.Keys.V)
                {
                    e.Handled = true;
                    this.btnPaste_Click(new object(), new System.EventArgs());
                }
                else if (e.KeyValue == (int)System.Windows.Forms.Keys.X)
                {
                    e.Handled = true;
                    this.btnCopy_Click(new object(), new System.EventArgs());
                    this.btnElementRemove_Click(new object(), new System.EventArgs());
                }
                else if (e.KeyValue == (int)System.Windows.Forms.Keys.F)
                {
                    e.Handled = true;
                    this.cmdSearchElements_Click(new object(), new System.EventArgs());
                }
            }
            #endregion

            #region F2
            if (this.treeElements.SelectedNode != null && e.KeyValue == (int)System.Windows.Forms.Keys.F2)
            {
                e.Handled = true;
                if (cmbElementType.SelectedIndex > 1)
                {
                    renameSubset();
                }
                else
                {
                    JNode tmpNode = (JNode)this.treeElements.SelectedNode;
                    this.treeElements.LabelEdit = true;
                    tmpNode.BeginEdit();
                }
            }
            #endregion

            #region F3
            if (e.KeyValue == (int)System.Windows.Forms.Keys.F3)
            {
                e.Handled = true;
                //this.cmdSearchElements_Click(new object(), new System.EventArgs());
                if (this.treeElements.Nodes.Count <= 1)
                {
                    return;
                }
                string test = RegUtils.SearchElement;
                string test2 = test.ToUpper();
                if (test2.Length > 0)
                {
                    TreeNodeCollection Elems = this.treeElements.Nodes;
                    TreeNode Element;
                    bool found = false;

                    TreeNode ElementSelected = null;
                    ElementSelected = this.treeElements.SelectedNode;
                    if ( ElementSelected == null )
                    {
                        return;
                    }

                    bool foundSelected = false;
                    for (int i = 0; i < Elems.Count; i++)
                    {
                        if ( !foundSelected )
                        {
                            if ( Elems[i] == ElementSelected )
                            {
                                foundSelected = true;
                            }
                            continue;
                        }
                                               
                        Element = Elems[i];

                        if (check_reg_exp(Element.Text.ToUpper(), test2))
                        {
                            this.treeElements.DeselectAll();
                            //CDNM: Element.Select();
                            this.treeElements.SelectedNode = Element;
                            Element.EnsureVisible();
                            found = true;
                            break;
                        }
                    }

                    if ((!found) && !test2.EndsWith("*"))
                    {
                        foundSelected = false;
                        for (int i = 0; i < Elems.Count; i++)
                        {
                            if (!foundSelected)
                            {
                                if ( Elems[i] == ElementSelected )
                                {
                                    foundSelected = true;
                                }
                                continue;
                            }

                            Element = Elems[i];

                            if (check_reg_exp(Element.Text.ToUpper(), test2 + "*"))
                            {
                                this.treeElements.DeselectAll();
                                //CDNM: Element.Select();
                                treeElements.SelectNode(Element);
                                Element.EnsureVisible();
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        string mess = Apalo.XlAddin.Utils.ResourceInitializer.Replace(Apalo.XlAddin.Utils.ResourceInitializer.TEXT_NO_FURTHER_DIMELEMENT, new object[] { test });
                        System.Windows.Forms.MessageBox.Show(mess);
                    }
                }
            }
            #endregion
        }

        #endregion

        # region MouseUp

        private void FillTreeSource()
        {
            bool ShowDetails = false;

            this.treeSourceElements.SuspendLayout();
            this.treeSourceElements.Items.Clear();

            try
            {
                JNode tmpNode = (JNode)this.treeElements.SelectedNodes[0];
                string tmpNodeName = (string)tmpNode.Text;

                if (!string.IsNullOrEmpty(this.currDimension) && (this.currConn.ElementType(this.currDb, this.currDimension, tmpNodeName) == DimElementType.DimElementTypeConsolidated))
                {
                    ConsolidationInfo[] dimDimElemsCons = this.currConn.DimElementListConsolidated(this.currDb, this.currDimension, tmpNodeName);

                    for (int i = 0; i < dimDimElemsCons.Length; i++)
                    {
                        ConsolidationInfo dimDimElemCons = dimDimElemsCons[i];
                        string tmpName = dimDimElemCons.Name.ToString();
                        double tmpFactor = (double)dimDimElemCons.Factor;
                        string tmpFactorStr;

                        if (Math.Round(tmpFactor) == tmpFactor)
                        {
                            tmpFactorStr = tmpFactor.ToString() + "   ";
                        }
                        else
                        {
                            tmpFactorStr = tmpFactor.ToString();
                        }

                        string[] t = new string[] { tmpName, tmpFactorStr };
                        ListViewItem lvi = new ListViewItem(t);

                        if (tmpFactor < 0)
                        {
                            lvi.ForeColor = Color.Red;
                        }
                        else if (tmpFactor != (double)1)
                        {
                            lvi.ForeColor = Color.Blue;
                        }
                        else
                        {
                            lvi.ForeColor = Color.Black;
                        }

                        this.treeSourceElements.Items.Add(lvi);

                        if (ShowDetails == false && tmpFactor != (double)1)
                        {
                            ShowDetails = true;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error editing Elements", exc);
            }

            #region Manage Tree/List View and chkFactor
            if (ShowDetails == false)
            {
                this.ListViewHideHeader();
                this.treeSourceElements.View = System.Windows.Forms.View.Details;
                this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                this.chkFactor.Visible = false;
            }
            else
            {
                this.ListViewShowHeaderR();
                this.treeSourceElements.View = System.Windows.Forms.View.Details;
                this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                this.chkFactor.Visible = false;
                this.treeSourceElements.SuspendLayout();
                this.treeSourceElements.BeginUpdate();
                if (this.chkFactor.Checked == true)
                {
                    this.chkFactor.Checked = false;
                    this.chkFactor.Checked = true;
                }
                else
                {
                    this.chkFactor.Checked = true;
                    this.chkFactor.Checked = false;
                }
                this.treeSourceElements.EndUpdate();
            }
            #endregion

            this.treeSourceElements.ResumeLayout();

        }
        
        private void treeElements1()
        {
            //  JMM 03-20-14:
            if (!this.treeElements.Font.Equals(this.regularFont))  
                treeElements.Font = regularFont;
        }

        private void treeElements2()
        {
            if (this.treeElements.SelectedNode != null && this.treeElements.Nodes[0].Text != GetHitLabelText())
            {
                this.cmdElemCopy.Enabled = true;
                this.cmdCountElements.Enabled = true;
                this.cmdElemSelectAll.Enabled = true;
                this.cmdSearchElements.Enabled = true;

                this.btnLeft.Enabled = false;
                this.btnRight.Enabled = false;
                if (this.btnOrigElems.FlatAppearance.BorderColor == System.Drawing.SystemColors.GradientActiveCaption)
                {
                    this.btnUp.Enabled = true;
                    this.btnDown.Enabled = true;
                } 
                else
                {
                    this.btnUp.Enabled = false;
                    this.btnDown.Enabled = false;
                }

                FillTreeSource();
            }

            #region Disable multiple actions
            if (this.treeElements.SelectedNodes.Count == 0)
            {
                this.cmdEdit.Enabled = false;
                this.cmdAddN.Enabled = false;
                this.cmdRen.Enabled = false;
                this.cmdShowParents.Enabled = false;
                this.btnElementEdit.Enabled = false;
                this.btnElementAdd.Enabled = true;
                this.btnElementRename.Enabled = false;
                this.btnElementRemove.Enabled = false;
                this.cmdDel.Enabled = false;
                this.cmdNumeric.Enabled = false;
                this.cmdString.Enabled = false;
                this.cmdElementMoveBegin.Enabled = false;
                this.cmdElementMoveEnd.Enabled = false;
            }
            else if (this.treeElements.SelectedNodes.Count == 1)
            {
                if (this.chkTree.Checked)
                {
                    this.btnElementEdit.Enabled = false;
                    this.btnElementAdd.Enabled = false;
                    this.btnElementRename.Enabled = false;
                    this.btnElementRemove.Enabled = false;
                }
                else
                {
                    this.cmdEdit.Enabled = true;
                    this.cmdAddN.Enabled = true;
                    this.cmdRen.Enabled = true;
                    this.cmdShowParents.Enabled = true;
                    this.btnElementEdit.Enabled = true;
                    this.btnElementAdd.Enabled = true;
                    this.btnElementRename.Enabled = true;
                    this.btnElementRemove.Enabled = true;
                    this.cmdDel.Enabled = true;
                    this.cmdNumeric.Enabled = true;
                    this.cmdString.Enabled = true;
                    this.cmdElementMoveBegin.Enabled = true;
                    this.cmdElementMoveEnd.Enabled = true;
                }
            }
            else
            {
                this.cmdEdit.Enabled = false;
                this.cmdAddN.Enabled = true;
                this.cmdRen.Enabled = false;
                this.cmdShowParents.Enabled = false;
                this.btnElementEdit.Enabled = false;
                this.btnElementAdd.Enabled = true;
                this.btnElementRename.Enabled = false;
                this.btnElementRemove.Enabled = true;
                this.cmdDel.Enabled = true;
                this.cmdNumeric.Enabled = false;
                this.cmdString.Enabled = false;
                this.cmdElementMoveBegin.Enabled = true;
                this.cmdElementMoveEnd.Enabled = true;
            }
            #endregion

            #region Disable more buttons in case of HIT message
            if (this.treeElements.Nodes.Count > 0)
            {
                if (this.NoElements(this.treeElements))
                {
                    this.btnElementEdit.Enabled = false;
                    this.btnElementRename.Enabled = false;
                    this.btnElementRemove.Enabled = false;
                }
            }
            else
            {
                this.btnElementAdd.Enabled = true;
                this.btnElementEdit.Enabled = false;
                this.btnElementRename.Enabled = false;
                this.btnElementRemove.Enabled = false;
            }
            #endregion
        }

        private void treeElements_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Clicks > 1)
            {
                return;
            }

            this.treeElements1();

            #region RightClick

            if (e.Button == MouseButtons.Right)
            {
                int selcount = this.treeElements.SelectedNodes.Count;
                if (cmbElementType.SelectedIndex > 1)
                {
                    bool allentries = (selcount == 1);
                    mnuSubSet.Items[0].Enabled = true;
                    mnuSubSet.Items[1].Enabled = (selcount > 0);
                    mnuSubSet.Items[2].Enabled = allentries;
                    mnuSubSet.Show(this.treeElements, new Point(e.X, e.Y));
                }
                else if (/*this.cElementNode == null && */ selcount > 0)
                {
                    if (selcount == 1)
                    {
                        JNode jn = this.treeElements.SelectedNode as JNode;
                        if ((string)jn.Tag == "N")
                        {
                            this.cmdNumeric.Checked = true;
                            this.cmdString.Checked = false;
                        }
                        else if ((string)jn.Tag == "S")
                        {
                            this.cmdNumeric.Checked = false;
                            this.cmdString.Checked = true;
                        }
                        else
                        {
                            this.cmdNumeric.Checked = false;
                            this.cmdString.Checked = false;
                        }

                        if (this.NoElements(this.treeElements))
                        {
                            ArrayList a = new ArrayList();
                            if (ReadClipBoard(ref a) == true)// || this.ClipboardContent.Count > 0)
                                this.cmdElemPaste.Enabled = true;

                            this.cmdAddN.Enabled = false;
                            this.cmdDel.Enabled = false;
                            this.cmdRen.Enabled = false;
                            this.cmdShowParents.Enabled = false;
                            this.cmdEdit.Enabled = false;

                            this.cmdNumeric.Enabled = false;
                            this.cmdString.Enabled = false;

                            this.cmdElemCopy.Enabled = false;
                            this.cmdCountElements.Enabled = false;
                            this.cmdElemSelectAll.Enabled = false;
                            this.cmdSearchElements.Enabled = false;

                            this.cmdElementMoveBegin.Enabled = false;
                            this.cmdElementMoveEnd.Enabled = false;
                        }
                        else
                        {
                            this.cmdAddN.Enabled = true;
                            this.cmdDel.Enabled = true;
                            this.cmdRen.Enabled = true;
                            this.cmdShowParents.Enabled = true;
                            this.cmdEdit.Enabled = true;

                            this.cmdNumeric.Enabled = true;
                            this.cmdString.Enabled = true;

                            this.cmdElemCopy.Enabled = true;
                            this.cmdCountElements.Enabled = true;
                            this.cmdElemSelectAll.Enabled = true;
                            this.cmdSearchElements.Enabled = true;
                            if (this.btnOrigElems.FlatAppearance.BorderColor == System.Drawing.SystemColors.GradientActiveCaption)
                            {
                                this.cmdElementMoveBegin.Enabled = true;
                                this.cmdElementMoveEnd.Enabled = true;
                            }
                            else
                            {
                                this.cmdElementMoveBegin.Enabled = false;
                                this.cmdElementMoveEnd.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        this.cmdElemPaste.Enabled = false;
                        this.cmdAddN.Enabled = false;
                        this.cmdDel.Enabled = true;
                        this.cmdRen.Enabled = false;
                        this.cmdShowParents.Enabled = false;
                        this.cmdEdit.Enabled = false;
                        this.cmdNumeric.Enabled = false;
                        this.cmdString.Enabled = false;
                        this.cmdElemCopy.Enabled = true;
                        this.cmdCountElements.Enabled = true;
                        this.cmdElemSelectAll.Enabled = (selcount != this.treeElements.Nodes.Count);
                        this.cmdSearchElements.Enabled = true;
                        if (this.btnOrigElems.FlatAppearance.BorderColor == System.Drawing.SystemColors.GradientActiveCaption)
                        {
                            this.cmdElementMoveBegin.Enabled = true;
                            this.cmdElementMoveEnd.Enabled = true;
                        }
                        else
                        {
                            this.cmdElementMoveBegin.Enabled = false;
                            this.cmdElementMoveEnd.Enabled = false;
                        }
                    }
                    this.elemCmdMenu.Show(this.treeElements, new Point(e.X, e.Y));
                }
            }
            else if (cmbElementType.SelectedIndex > 1 && treeElements.SelectedNode != null)
            {
                SubSetEditor ast = new SubSetEditor(EditorType.GlobalOnly, this.currHostname, this.currDb, currDimension);
                ast.LoadSubset(treeElements.SelectedNode.Text, SubsetType.Global);
                SubsetResult[] results = ast.aSubSet.GetSubSetResults(currConn, this.currDb, GeneralConst.SUBSET_LIMIT);
                treeSourceElements.Items.Clear();

                if (results != null)
                {
                    foreach (SubsetResult res in results)
                    {
                        string[] t = new string[] { res.Name, "" };//res.Index.ToString() };
                        ListViewItem lvi = new ListViewItem(t);
                        lvi.ForeColor = Color.Black;
                        treeSourceElements.Items.Add(lvi);
                    }
                }
                ast.Dispose();
            }
            else
            {
                this.treeElements2();
            }

            #endregion
        }


        private void treeElements_MouseUp2(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            treeElements1();

            // workaround for setting color of edited element in red
            this.treeElements.Nodes[this.cElementNodeIndex].ForeColor = Color.Black;
            this.treeElements.Nodes[this.cElementNodeIndex].NodeFont = this.boldFont;
            this.cmdElemCopy.Enabled = false;
            this.btnDown.Enabled = false;
            this.btnLeft.Enabled = false;
            this.btnRight.Enabled = true;
            this.btnUp.Enabled = false;
        }


        #region SubSetEditor

        private void SubsetListUpdate()
        {
            treeSourceElements.Items.Clear();
            UpdateSubsetList();
        }

        private void DoCallSubSetEditor()
        {
            SubSetEditor ast = new SubSetEditor(EditorType.GlobalOnly, this.currHostname, this.currDb, currDimension);

            if ((treeElements.SelectedNode != null) && !string.IsNullOrEmpty(treeElements.SelectedNode.Text))
            {
                ast.LoadSubset(treeElements.SelectedNode.Text, SubsetType.Global);
            }

            ast.ShowDialog();
            mnuSubSet.Close();
            //Utils.SubsetUtils.FillTable(server);
            SubsetListUpdate();
            
            ast.Dispose();
        }

        private void renameSubset()
        {
            DoCallSubSetEditor();
        }

        private void cmdAddSubset_Click(object sender, EventArgs e)
        {
            DoCallSubSetEditor();
        }


        private void cmdEditSubset_Click(object sender, EventArgs e)
        {
            renameSubset(); 
        }

        private void RemoveSubset()
        {
            int i, count = this.treeElements.SelectedNodes.Count;
            string subset;
            bool doupdate = (count > 0);
            bool dodelete;
            for (i = 0; i < count; i++)
            {
                subset = this.treeElements.SelectedNodes[i].Text;
                dodelete = SubsetUtils.ConfirmSubsetDelete(subset);
                if (dodelete)
                {
                    SubsetHelper.DeleteSubset(currConn, currHostname, currDb, currDimension, subset, SubsetType.Global);
                }
                doupdate = doupdate || dodelete;
            }

            if (doupdate)
            {
                SubsetListUpdate();
            }


        }

        private void cmdRemoveSubset_Click(object sender, EventArgs e)
        {
            RemoveSubset();
        }

        #endregion

        #endregion

        #region DoubleClick

        private void treeElements_DoubleClick2(object sender, System.EventArgs e)
        {
            if(this.treeElements.SelectedNode.Text != this.cElementNode.Text)
            {
                this.removeHitMessage();
                if (this.treeSourceElements.Items.Count == 0)
                {
                    this.ListViewHideHeader();
                }

                string[] t = new string[]{this.treeElements.SelectedNode.Text,"1   "};//,this.treeElements.SelectedNode.Text, "1"};
                ListViewItem lvi = new ListViewItem(t);
                if (!this.checkExisting(this.treeElements.SelectedNode.Text))
                {
                    this.treeSourceElements.Items.Add(lvi);
                }
                this.btnElementApplyChanges.Enabled = true;
                this.btnLeft.Enabled = true;
            }
        }


        private void treeElements_DoubleClick(object sender, System.EventArgs e)
        {
            if (cmbElementType.SelectedIndex == 2)
            {
                DoCallSubSetEditor();
            }
            else
            {
                if ((this.treeElements.SelectedNode == null) || (this.treeElements.SelectedNode.Text != GetHitLabelText()))
                {
                    this.InElementchange = true;
                    this.editElement();
                    this.treeSourceElements.Focus();
                }
            }

        }

        #endregion

        #endregion

        #region treeSourceElements

        private void chkFactor_CheckedChanged(object sender, System.EventArgs e)
        {
            if(this.chkFactor.Checked == false)
            {
                this.ListViewShowHeaderR();
            }
            else
            {
                this.ListViewShowHeaderL();
            }
        }

        
        private void treeSourceElements_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(this.cElementNode != null)
            {
                Point pt = new Point(e.X, e.Y);
                ListViewItem Node = this.treeSourceElements.GetItemAt( e.X, e.Y );
                if ( Node == null ) return;
                if ( Node.Bounds.Contains( pt ) )
                {
                    //this.treeSourceElements.SelectedItems[0] = Node;
                    Node.Selected = true;
                }

                if(this.treeSourceElements.SelectedItems.Count > 0 
                    && this.treeSourceElements.Items[0].SubItems[0].Text != ResourceInitializer.TEXT_HIT_RETURN_SOURCEELEMENTS)
                {
                    //this.xpCopy.Enabled = false;
                    this.cmdElemCopy.Enabled = false;
                    this.cmdCountElements.Enabled = false;
                    this.cmdElemSelectAll.Enabled = false;
                    this.cmdSearchElements.Enabled = false;

                    this.btnUp.Enabled = true;
                    this.btnLeft.Enabled = true;
                    this.btnRight.Enabled = false;
                    this.btnDown.Enabled = true;
                    

                    //foreach(ListViewItem t in this.treeSourceElements.Items)
                    for(int i=0; i<this.treeSourceElements.Items.Count; i++)
                    {
                        ListViewItem t = (ListViewItem)this.treeSourceElements.Items[i];
                        t.Font = this.regularFont;
                    }
                    //this.treeSourceElements.SelectedItems[0].Font = this.boldFont;
                }

                if(e.Button == MouseButtons.Right)
                {
                    // disable items in context menu if hint message
                    if(this.treeSourceElements.Items.Count == 1 
                        && this.treeSourceElements.Items[0].SubItems[0].Text == ResourceInitializer.TEXT_HIT_RETURN_SOURCEELEMENTS)
                    {
                        this.cmdFactor.Enabled = false;
                        this.cmdDelSrcElem.Enabled = false;
                        this.cmdSrcElementMoveBegin.Enabled = false;
                        this.cmdSrcElementMoveEnd.Enabled = false;
                        //this.treeSourceElements.SelectedItems[0].Font = this.regularFont;
                    }
                    else
                    {
                        // disable factor item in context menu for more than one item selected
                        if(this.treeSourceElements.SelectedItems.Count > 1)
                        {
//                          this.cmdFactor.Enabled = false;
                            this.cmdSrcElementMoveBegin.Enabled = true;
                            this.cmdSrcElementMoveEnd.Enabled = true;
                        }
                        else
                        {
                            this.cmdFactor.Enabled = true;
                            this.cmdSrcElementMoveBegin.Enabled = true;
                            this.cmdSrcElementMoveEnd.Enabled = true;
                        }
                        this.cmdDelSrcElem.Enabled = true;
                    }

                    this.srcElemCmdMenu.Show(this.treeSourceElements, new Point(e.X,e.Y));
                }
            }
        }


        private void treeSourceElements_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // disable action if not in edit mode
            if(this.cElementNode != null)
            {
                // DELETE 46
                if(e.KeyValue == (int)System.Windows.Forms.Keys.Delete)
                {
                    e.Handled = true;
                    try
                    {
                        this.removeSelectedSourceElements();
                    }
                    catch
                    {}
                }
                if((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
                {// handle CTRL + A
                    if(e.KeyValue == (int)System.Windows.Forms.Keys.A)
                    {
                        e.Handled = true;
                        //foreach(System.Windows.Forms.ListViewItem lvi in this.treeSourceElements.Items)
                        for(int i=0; i<this.treeSourceElements.Items.Count; i++)
                        {
                            System.Windows.Forms.ListViewItem lvi = (System.Windows.Forms.ListViewItem)this.treeSourceElements.Items[i];
                            lvi.Selected = true;
                        }
                    }
                }
            }
        }


        private void cmdFactor_Click(object sender, System.EventArgs e)
        {
            this.showFactor();
        }


        private void showFactor()
        {
            if(this.treeSourceElements.SelectedItems != null 
                && this.treeSourceElements.SelectedItems[0].SubItems[0].Text != ResourceInitializer.TEXT_HIT_RETURN_SOURCEELEMENTS)
            {
                Apalo.XlAddin.Forms.ConsolidationFactor cf = new Apalo.XlAddin.Forms.ConsolidationFactor();
                cf.Factor = System.Convert.ToDecimal(this.treeSourceElements.SelectedItems[0].SubItems[1].Text);
                if (cf.ShowDialog() == DialogResult.OK)
                {
                    double tmpFactor = (double)cf.Factor;
                    string tmpFactorStr;
                    if (Math.Round(tmpFactor) == tmpFactor)
                    {
                        tmpFactorStr = tmpFactor.ToString() + "   ";
                    }
                    else
                    {
                        tmpFactorStr = tmpFactor.ToString();
                    }

                    int i, vsize = this.treeSourceElements.SelectedItems.Count;

                    for (i = 0; i < vsize; i++)
                    {

                        this.treeSourceElements.SelectedItems[i].SubItems[1].Text = tmpFactorStr;
                        if (cf.Factor < 0)
                        {
                            this.treeSourceElements.SelectedItems[i].ForeColor = Color.Red;
                        }
                        else if (cf.Factor != (decimal)1)
                        {
                            this.treeSourceElements.SelectedItems[i].ForeColor = Color.Blue;
                            if (this.chkFactor.Checked == true)
                            {
                                this.ListViewShowHeaderL();
                            }
                            else
                            {
                                this.ListViewShowHeaderR();
                            }
                            this.treeSourceElements.View = System.Windows.Forms.View.Details;
                            this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                            this.chkFactor.Visible = false;
                        }
                        else
                        {
                            this.treeSourceElements.SelectedItems[i].ForeColor = Color.Black;
                        }
                    }

                    if (cf.Factor != (decimal)1)
                    {
                        if (this.chkFactor.Checked == true)
                        {
                            this.ListViewShowHeaderL();
                        }
                        else
                        {
                            this.ListViewShowHeaderR();
                        }
                        this.treeSourceElements.View = System.Windows.Forms.View.Details;
                        this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.chkFactor.Visible = false;
                    }
                    cf.Dispose();
                    cf = null;
                }

            }
        }


        private void treeSourceElements_DoubleClick(object sender, System.EventArgs e)
        {
            this.removeSelectedSourceElements();
        }

        #endregion

        #endregion

        #endregion

        #region Enable/Disable Add/Del/Ren/Up/Dn Buttons on Dim Tab functionality

        private void enableButtonsAddDelSrcElem(bool off)
        {
            if(off==true)
            {
                this.btnElementApplyChanges.Enabled = false;
                this.btnElementApplyChanges.Visible = false;
                this.btnElementCancelChanges.Enabled = false;
                this.btnElementCancelChanges.Visible = false;
            }
            else
            {
                this.btnElementApplyChanges.Enabled = true;
                this.btnElementApplyChanges.Visible = true;
                this.btnElementCancelChanges.Enabled = true;
                this.btnElementCancelChanges.Visible = true;
            }
        }
        #endregion

        #region Switch between tabs (SelectionChanged + SelectionChanging + clearTabs)

        private void doTabMain_SelectionChanged0(JTabPage oldPage, JTabPage newPage, string attrDimName, int oldSelection)
        {
            // JMM 03-20-14 replaced DotNetMagic:
            treeElements.UnselectAllNodes();

            if ((oldPage != (JTabPage)this.tabMain.TabPages[0]) || (this.olddim != newPage.Title))
            {
                this.cmbElementType.SelectedIndex = -1; // Call cmbElementType_SelectedIndexChanged at least once.
            }

            if (((oldSelection == 1) && !String.IsNullOrEmpty(attrDimName) && (this.currConn.DimensionListElements(this.currDb, attrDimName).Length != 0)) || (oldSelection != 1))
            {
                // If attributes were selected and the selected dimension has attributes, show attributes.
                this.cmbElementType.SelectedIndex = oldSelection;
            }
            else
            {
                this.cmbElementType.SelectedIndex = 0;
            }
        }

        // JMM 03-20-14 replaced DotNetMagic:
        private JTabPage lastSelectedPage;
        
        void tabMain_SelectionChanged(object sender, EventArgs e)
            {
            tabMain_SelectionChanged(tabMain, lastSelectedPage, (JTabPage)tabMain.SelectedTab);
            lastSelectedPage = (JTabPage)tabMain.SelectedTab;
            }

        private void tabMain_SelectionChanged(JTabControl sender, JTabPage oldPage, JTabPage newPage)
        {
            if ((oldPage == null) || this.TabsAreCleared)
            {
                return;
            }

            if (oldPage != (JTabPage)this.tabMain.TabPages[0])
            {
                this.olddim = oldPage.Title;
            }

            lblConsolidatedElements.Text = ResourceInitializer.LABEL_ELEMENTS_CONSOLIDATED;

            if(this.cTab != null)
            {
                this.tabMain.SelectedTab = this.cTab;
                return;
            }

            if (this.cElementNode != null)
            {
                this.cElementNode = null;
            }

            if (comboConnList == null || this.comboConnList.SelectedIndex == -1 && this.tabMain.SelectedTab == null)
            {
                return;
            }

            this.tabMain.SuspendLayout();

            if ((this.tabMain.SelectedTab.Controls != null) && (this.tabMain.SelectedTab.Controls.Count > 0 && !this.tabMain.SelectedTab.Controls.Contains(this.btnClose)))
            {
                CloseBtnToPage((JTabPage)this.tabMain.SelectedTab, this.tabMain.SelectedIndex == 0);
            }

            this.SetcurrDimension();

            if (this.tabMain.SelectedIndex > 0)
            {

                this.cmdElemCopy.Enabled = false;
                this.cmdCountElements.Enabled = false;
                this.cmdElemSelectAll.Enabled = false;
                this.cmdSearchElements.Enabled = false;

                this.btnDown.Enabled = false;
                this.btnLeft.Enabled = false;
                this.btnRight.Enabled = false;
                this.btnUp.Enabled = false;

                if (!String.IsNullOrEmpty(this.currDb))
                {
                    string attrDimName = ((TabTagObject)(newPage.Tag)).AttributeDimName;
                    int oldSelection = this.cmbElementType.SelectedIndex;

                    ExcelHelper.SetExcelStatusbar(ReadingMessage);

                    doTabMain_SelectionChanged0(oldPage, newPage, attrDimName, oldSelection);

                    this.SetcurrDimension();
                    string dim = this.currDimension;

                    this.treeSourceElements.View = System.Windows.Forms.View.Details;
                    this.treeSourceElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                    this.chkFactor.Visible = false;
                    this.treeSourceElements.Items.Clear();
                    this.enableButtonsAddDelRenDims(false);
                    this.enableButtonsAddDelCub(false);
                    this.btnHome.Visible = true;

                    if ((this.tabMain.SelectedTab.Controls != null) && (this.tabMain.SelectedTab.Controls.Count == 0))
                    {
                        this.initElementsTab((JTabPage)this.tabMain.SelectedTab);

                        if (this.cmbElementType.Items.Count == 0)
                        {
                            this.cmbElementType.Items.AddRange(new object[] {
                                ResourceInitializer.ItemElements,
                                ResourceInitializer.ItemAttributes,
                                ResourceInitializer.ItemSubsets });

                            doTabMain_SelectionChanged0(oldPage, newPage, attrDimName, 0);
                        }
                    }

                    try
                    {
                        // disable multiple actions
                        this.cmdEdit.Enabled = false;
                        this.cmdAddN.Enabled = false;
                        this.cmdRen.Enabled = false;
                        this.cmdShowParents.Enabled = false;
                        this.btnElementEdit.Enabled = false;
                        this.btnElementAdd.Enabled = false;
                        this.btnElementRename.Enabled = false;
                        this.btnElementRemove.Enabled = false;
                        this.cmdElementMoveBegin.Enabled = false;
                        this.cmdElementMoveEnd.Enabled = false;

                        if (this.chkTree.Checked)
                        {
                            this.btnElementAdd.Enabled = false;
                            if (this.treeElements.Nodes == null || this.treeElements.Nodes.Count == 0)
                            {
                                this.chkTree.Checked = false;
                                this.chkTree.Enabled = false;
                                this.btnEnableTree.Enabled = false;
                                this.btnEnableTree.ButtonImage = ResourceInitializer.IconShowFlatButton;
                                this.treeElements.ImageList = null;
                                // JMM 03-20-14 replaced DotNetMagic:
                                //this.treeElements.LineVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.OnlyBelowRoot;
                                //this.treeElements.BoxVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.Nowhere;
                                this.showHitElements(ref this.treeElements);
                            }
                        }
                        else
                        {
                            // set hint element
                            if ((this.treeElements.Nodes == null) || (this.treeElements.Nodes.Count == 0) ) 
                            {
                                if (this.cmbElementType.SelectedIndex < 2)
                                {
                                    this.showHitElements(ref this.treeElements);
                                }
                            }
                            else
                            {
                                this.treeElements.ImageList = this.imgListElements;
                                //CDNM: this.treeElements.Nodes[0].Select(true);
                                this.treeElements.DeselectAll();
                                this.chkTree.Enabled = true;
                                this.btnEnableTree.Enabled = true;
                                this.cmbElementType.Visible = this.CubeViewStatus != GeneralConst.SYSTEM_CUBE_VIEW;
                            }
                        }
                    }
                    catch (Exception tabxc)
                    {
                        ErrorHandler.DisplayError("Error changing tabs!", tabxc);
                    }
                    ExcelHelper.ResetExcelStatusbar();
                }


                if ((this.treeElements.Nodes.Count > 0) && !this.chkTree.Checked )
                {
                    this.btnElementAdd.Enabled = true;
                }

                if (btnAscElems.FlatAppearance.BorderColor == System.Drawing.SystemColors.GradientActiveCaption)
                {
                    this.btnUp.Enabled = false;
                    this.btnDown.Enabled = false;
                    this.cmdElementMoveBegin.Enabled = false;
                    this.cmdElementMoveEnd.Enabled = false;
                    this.sortElems(false);
                }

                if (btnDescElems.FlatAppearance.BorderColor == System.Drawing.SystemColors.GradientActiveCaption)
                {
                    this.btnUp.Enabled = false;
                    this.btnDown.Enabled = false;
                    this.cmdElementMoveBegin.Enabled = false;
                    this.cmdElementMoveEnd.Enabled = false;
                    this.sortElems(true);
                }
            }
            else
            {
                this.treeViewDims.SelectedNode = null;
                this.treeViewCubes.SelectedNode = null;
                this.enableButtonsAddDelRenDims(false);
                this.enableButtonsAddDelCub(false);
                this.fixShowHideDataStoreButtons();
                this.btnHome.Visible = false;

                this.AllowUserManagement();

                this.treeViewDims.Focus();
                
            }
            
            this.tabMain.ResumeLayout();
        }

        private void tabMain_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Clicks > 1)
            {
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                if (this.tabMain.SelectedIndex == 0)
                {
                    this.cmdTabDatabase.Checked = true;
                    for (int i = 1; i < this.tabCmdMenu.Items.Count; i++)
                    {
                        ToolStripMenuItem cmdTabDimi = (ToolStripMenuItem)this.tabCmdMenu.Items[i];
                        cmdTabDimi.Checked = false;
                    }
                }
                else
                {
                    this.cmdTabDatabase.Checked = false;
                    string tagName = ((TabTagObject)(this.tabMain.SelectedTab.Tag)).DimName;
                    for (int i = 1; i < this.tabCmdMenu.Items.Count; i++)
                    {
                        ToolStripMenuItem cmdTabDimi = (ToolStripMenuItem)this.tabCmdMenu.Items[i];
                        cmdTabDimi.Checked = (String.Equals(cmdTabDimi.Text, tagName));
                    }
                }
                this.tabCmdMenu.Show(this.tabMain, new Point(e.X, e.Y));

            }
        }

        private void EnableStatusBtns()
        {
            if (this.EditUsersState == true)
            {
                this.btnUserManagment.Enabled = false;
                this.btnAttributeManagment.Enabled = true;
                this.btnDataManagment.Enabled = true;
            }
            else
            {
                this.btnUserManagment.Enabled = true;

                this.btnDataManagment.Enabled = (this.CubeViewStatus != GeneralConst.NORMAL_CUBE_VIEW);
                this.btnAttributeManagment.Enabled = (this.CubeViewStatus != GeneralConst.ATTRIBUTE_CUBE_VIEW);

            }
        }

        private void AllowUserManagement()
        {
            try
            {
                if (this.currConn.RootListDatabases(DatabaseType.SystemDatabase).Length == 0)
                {
                    this.btnUserManagment.Enabled = false;
                    this.btnAttributeManagment.Enabled = false;
                    this.btnDataManagment.Enabled = false;
                }
                else
                {
                    EnableStatusBtns();
                }
            }
            catch
            { }
        }

        private void clearTabs()
        {
            this.TabsAreCleared = true;
            ArrayList tList = new ArrayList(this.tabMain.TabPages);
            for (int i = 1; i < tList.Count; i++)
            {
                this.tabMain.TabPages.Remove((JTabPage)tList[i]);
            }
            tList = null;
            this.TabsAreCleared = false;
        }

        private void clearItems()
        {
            ArrayList tList = new ArrayList(this.tabCmdMenu.Items);
            for (int i = tList.Count - 1; i > 0;  i--)
            {
                this.tabCmdMenu.Items.RemoveAt(i);
            }
            tList = null;
        }

        #endregion

        #region Enable/Disable Add/Del/Ren/Up/Dn Buttons functionality
        private void enableButtonsAddDelRenDims(bool off)
        {
            if(off)
            {
                this.btnDimensionAdd.Enabled = false;
                this.btnDimensionRemove.Enabled = false;
                this.btnDimensionRename.Enabled = false;
                //this.xpEditDataAxis.Enabled = false;
            }
            else
            {
                this.btnDimensionAdd.Enabled = true;
                if(this.treeViewDims.SelectedNode != null 
                    && this.treeViewDims.Nodes[0].Text != ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS)
                {
                    this.btnDimensionRemove.Enabled = true;
                    this.btnDimensionRename.Enabled = true;
                    //this.xpEditDataAxis.Enabled = true;
                }
                else
                {
                    this.btnDimensionRemove.Enabled = false;
                    this.btnDimensionRename.Enabled = false;
                    //this.xpEditDataAxis.Enabled = false;
                }
            }
        }

        private void enableButtonsAddDelCub(bool off)
        {
            if(off==true)
            {
                this.btnCubeAdd.Enabled = false;
                this.btnCubeRemove.Enabled = false;
                this.btnRuleEditor.Enabled = false;
            }
            else
            {
                if((this.treeViewDims.Nodes.Count > 0)
                    && (this.treeViewDims.Nodes[0].Text != ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS)
                    && ((this.treeViewCubes.Nodes.Count == 0) || (this.treeViewCubes.Nodes[0].Text != ResourceInitializer.TEXT_HIT_RETURN_VIEWCUBES)))
                {
                    this.btnCubeAdd.Enabled = true;
                    if(this.treeViewCubes.SelectedNode != null
                        && (string)this.treeViewCubes.SelectedNode.Text == (string)this.treeViewCubes.SelectedNode.FullPath.ToString())
                    {
                        this.btnCubeRemove.Enabled = true;
                        this.btnRuleEditor.Enabled = true;
                        this.cmdRuleEditor.Enabled = true;
                        this.cmdCubeInfo.Enabled = true;
                        this.cmdDelCube.Enabled = true;
                        this.cmdClearCube.Enabled = true;
                        //this.cmdClearCube.Enabled = false;
                        this.cmdExportCube.Enabled = true;
                    }
                    else
                    {
                        this.btnCubeRemove.Enabled = false;
                        this.btnRuleEditor.Enabled = false;
                        this.cmdRuleEditor.Enabled = false;
                        this.cmdCubeInfo.Enabled = false;
                        this.cmdDelCube.Enabled = false;
                        this.cmdClearCube.Enabled = false;
                        this.cmdExportCube.Enabled = false;
                    }


                }
            }
        }
        #endregion

        #region Jump to edit dimension tab(treeViewDims_DoubleClick + treeViewCubes_DoubleClick + xpEditDataAxis_Click)

        private void treeViewDims_DoubleClick(object sender, System.EventArgs e)
        {
            if(this.treeViewDims.SelectedNode != null && this.treeViewDims.SelectedNode.Text.Length != 0)
            {
                for(int i=1; i<this.tabMain.TabPages.Count; i++)
                {
                    JTabPage tP = (JTabPage)this.tabMain.TabPages[i];
                    if (this.treeViewDims.SelectedNode.Text == ((TabTagObject)(tP.Tag)).DimName)
                    {
                        tP.Select();
                        tP.Selected = true;
                    }
                }
            }
        }

        private void treeViewCubes_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.treeViewCubes.SelectedNode != null &&
                this.treeViewCubes.SelectedNode.Text.Length != 0)
            {
                for (int i = 1; i < this.tabMain.TabPages.Count; i++)
                {
                    JTabPage tP = (JTabPage)this.tabMain.TabPages[i];
                    if (this.treeViewCubes.SelectedNode.Text == ((TabTagObject)(tP.Tag)).DimName)
                    {
                        tP.Select();
                        tP.Selected = true;
                    }
                }
            }
        }

        private void btnDimensionEdit_Click(object sender, System.EventArgs e)
        {
            if(this.treeViewDims.SelectedNode != null && this.treeViewDims.SelectedNode.Text.Length != 0)
            {
                for (int i = 1; i < this.tabMain.TabPages.Count; i++)
                {
                    JTabPage tP = (JTabPage)this.tabMain.TabPages[i];
                    if (this.treeViewDims.SelectedNode.Text == tP.Title)
                    {
                        tP.Select();
                        tP.Selected = true;
                    }
                }
            }
        }

        private void btnHome_Click(object sender, System.EventArgs e)
        {
            if(this.cElementNode == null)
            {
                if (this.tabMain.TabPages.Count > 0)
                {
                    this.tabMain.TabPages[0].Select();
                    ((JTabPage)this.tabMain.TabPages[0]).Selected = true;
                }
            }
        }

        #endregion

        #region Handle Button Actions to add/del/ren DataAxis/DataStores

        private void showHitDims()
        {
            //this.xpEditDataAxis.Enabled = false;
            this.btnDimensionRename.Enabled = false;
            this.btnDimensionRemove.Enabled = false;
            this.cmdDelDim.Enabled = false;
            this.cmdRenDim.Enabled = false;
            this.cmdEditDim.Enabled = false;
            this.cmdElementMoveBegin.Enabled = false;
            this.cmdElementMoveEnd.Enabled = false;
            this.treeViewDims.Font = this.regularFont;
            this.treeViewDims.ImageList = null;
            TreeNode tN = new JNode(ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS);
            tN.NodeFont = this.regularFont;
            this.treeViewDims.Nodes.Add(tN);
            this.treeViewDims.Focus();
        }

        private void showHitCubes()
        {
            this.btnCubeRemove.Enabled = false;
            this.btnRuleEditor.Enabled = false;
            this.cmdRuleEditor.Enabled = false;
            this.cmdCubeInfo.Enabled = false;
            this.cmdDelCube.Enabled = false;
            this.cmdClearCube.Enabled = false;
            this.cmdExportCube.Enabled = false;
            this.treeViewCubes.Font = this.regularFont;
            this.treeViewCubes.ImageList = null;
            this.treeViewCubes.ShowLines = false;
            this.treeViewCubes.ShowPlusMinus = false;
            this.treeViewCubes.ShowRootLines = false;
            TreeNode tN = new JNode((string)ResourceInitializer.TEXT_HIT_RETURN_VIEWCUBES);
            tN.NodeFont = this.regularFont;
            this.treeViewCubes.Nodes.Add(tN);
        }

        private void fixShowHideDataStoreButtons()
        {
            if(this.treeViewDims.Nodes != null)
            {
                if(this.treeViewDims.Nodes.Count >= 1 && this.treeViewDims.Nodes[0].Text != ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS)
                {
                    this.btnCubeAdd.Enabled = true;
                    if(this.treeViewCubes.SelectedNode != null)
                    {
                        this.btnCubeRemove.Enabled = true;
                        this.btnRuleEditor.Enabled = true;
                    }
                    else
                    {
                        this.btnCubeRemove.Enabled = false;
                        this.btnRuleEditor.Enabled = false;
                    }

                    if(this.treeViewCubes.Nodes.Count == 0)
                    {
                        this.showHitCubes();
                    }
                }
                else
                {
                    this.btnCubeAdd.Enabled = false;
                    this.btnCubeRemove.Enabled = false;
                    this.btnRuleEditor.Enabled = false;
                    this.treeViewCubes.Nodes.Clear();
                }
            }
        }

        private void addNewDimension()
        {
            this.cmdDelDim.Enabled = true;
            this.cmdRenDim.Enabled = true;
            this.cmdEditDim.Enabled = true;
            this.cmdElementMoveBegin.Enabled = true;
            this.cmdElementMoveEnd.Enabled = true;
            if(this.treeViewDims.Nodes != null && this.treeViewDims.Nodes.Count == 1 && this.treeViewDims.Nodes[0].Text == ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS)
            {
                this.treeViewDims.Nodes.Remove(this.treeViewDims.Nodes[0]);
            }
            TreeNode tN = new JNode();
            tN.Text = ResourceInitializer.LABEL_NEW_DIMENSION;
            this.treeViewDims.Nodes.Add(tN);
            this.setSizes();            
            this.treeViewDims.SelectedNode = tN;
            this.nfoAddDataAxis = true;
            this.treeViewDims.LabelEdit = true;
            tN.BeginEdit();
        }

        private void HandleDimensionError(PaloException pe, string displayerror)
        {
            string msg;

            switch (pe.ErrorCode)
            {
                case -51:
                case 3001:
                    msg = ResourceInitializer.ERROR_DIMENSION_EXISTS;
                    break;

                case -70:
                case 3003:
                    msg = ResourceInitializer.ERROR_DIMENSION_NAME_INVALID;
                    break;

                default:
                    msg = pe.Message;
                    ErrorHandler.DisplayError(displayerror, pe);
                    break;
            }

            ErrorHandler.ErrorPopup(msg);
        }


        private void btnDimensionAdd_Click(object sender, System.EventArgs e)
        {
            this.dimFromTemplate();
        }

        private void dimFromTemplate()
        {
            if (!String.IsNullOrEmpty(this.currDb))
            {
                Apalo.XlAddin.Forms.DimTemplate dt = new Apalo.XlAddin.Forms.DimTemplate(this.currConn, this.currDb);
                if (dt.ShowDialog() == DialogResult.OK)
                {
                    // JMM 05-07-14:
                    #if NOTUSED     // Allow default w/o template
                    if (String.IsNullOrEmpty(dt.Template))
                        {
                        return;
                        }
                    #endif
                    string dim = dt.DimName;
                    if (dim.Length > 255)
                    {
                        dim = dim.Substring(0, 255);
                    }

                    try
                    {
                        this.currConn.DatabaseAddDimension(this.currDb, dim, DimensionType.NormalDimension); // new dimension in db
                        this.currConn.Ping();
                        this.currDimension = dim;

                        if ((this.treeViewDims.Nodes.Count > 0) && (this.treeViewDims.Nodes[0].Text == ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS))
                        {
                            this.treeViewDims.Nodes.RemoveAt(0);
                        }
                        this.treeViewDims.Nodes.Add(new JNode(dim)); // new dimension in tree
                        JTabPage np = new JTabPage();
                        np.Tag = new TabTagObject(dim, this.currConn.GetAttributeDimension(this.currDb, dim));
                        np.Title = dim.Replace("&", "&&");
                        this.tabMain.TabPages.Add(np); // new dimension in tabpage
                        if (this.tabMain.TabPages.Count < 10)
                        {
                            this.tabMain.Multiline = true;
                            //CDNM:
                            //this.tabMain.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiForm;
                            //this.tabMain.PositionTop = true;
                            //this.tabMain.BoldSelectedPage = true;
                        }
                        else
                        {
                            this.tabMain.Multiline = false;
                            //CDNM:
                            //this.tabMain.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiDocument;
                        }
                        ToolStripMenuItem cmdTabDim = new ToolStripMenuItem();
                        cmdTabDim.Text = dim;
                        cmdTabDim.Click += new System.EventHandler(this.cmdTabDim_Click);
                        cmdTabDim.Checked = false;
                        this.tabCmdMenu.Items.Add(cmdTabDim); // new dimension in tabCmdMenu
                        if (this.CubeViewStatus == GeneralConst.ATTRIBUTE_CUBE_VIEW)
                        {
                            this.RefreshCubes(); // new attribute-cube
                        }
                        this.setSizes();
                    }
                    catch (PaloException addDimExc)
                    {
                        HandleDimensionError(addDimExc, "Error adding to database.");

                        dt.Close();
                        dt.Dispose();
                        dt = null;
                        return;
                    }

                    // JMM 05-07-14:
                    if (!string.IsNullOrEmpty(dt.Template)) {
                    string fileName = RegUtils.DimensionTemplatePath + "\\" + dt.Template + ".txt"; // containing the whole path
                    char[] separator = new char[] { '\t' };

                    ArrayList a = new ArrayList();
                    try
                    {
                        if (ReadTemplate(fileName, separator, ref a))
                        {
                            this.InsertTemplate(a);
                            this.tabMain.SelectedIndex = this.tabMain.TabPages.Count - 1; // Select new tabPage.
                        }
                    }
                    catch (System.Exception ep)
                    {
                        ErrorHandler.DisplayError("Error pasting elements!", ep);
                    }
                    }

                    dt.Close();
                    dt.Dispose();
                    dt = null;
                }
            }
        }

        private static bool ReadTemplate( string fileName, char[] separator, ref ArrayList Cells )
        {
            try
            {
                StreamReader sr = new StreamReader(fileName, System.Text.Encoding.GetEncoding(0));
                
                //Loop till no further data is available
                while(sr.Peek() > 0)
                {
                    //Read a line of data from the StreamReader object
                    string Data = sr.ReadLine();                        
                    //Separator
                    char[] sep = separator;
                    string tmpSep = sep[0].ToString();
                    if(Data.Length > 0)
                    {
                        if (Data.StartsWith("#"))
                        {
                            continue;
                        }
                        tmpSep = Data.Substring(Data.Length - 1);
                    }
                    // Check if separator is tabulator
                    if(Data.Length > 2 && (tmpSep.Equals('\t') || Data[0].Equals('\t') || Data[1].Equals('\t')))
                    {
                        sep = new char[]{'\t'};
                    }
                    // Check if separator is comma
                    if(Data.Length > 2 && (tmpSep.Equals(',') || Data[0].Equals(',') || Data[1].Equals(',')))
                    {
                        sep = new char[]{','};
                    }
                    // Check if separator is semicolon
                    if (Data.Length > 2 && (tmpSep.Equals(';') || Data[0].Equals(';') || Data[1].Equals(';')))
                    {
                        sep = new char[]{';'};
                    }
                    // Check if separator is blank
                    if (Data.Length > 2 && (tmpSep.Equals(' ') || Data[0].Equals(' ') || Data[1].Equals(' ')))
                    {
                        sep = new char[]{' '};
                    }

                    try
                    {
                        Array NewData;
                        // If the second cell in Data contains the delimiter, then \" is inserted at the beginning and at the end of the second string.
                        if (Data.Contains("\""))
                        {
                            int pos = Data.IndexOf("\"");
                            string first = Data.Substring(0, pos - 1);
                            int last = Data.LastIndexOf("\"");
                            string second = Data.Substring(pos + 1, last - pos - 1);
                            string third = "";
                            if (Data.Length > last + 1)
                            {
                                third = Data.Substring(last + 2);
                            }
                            //Error if there is more than one left
                            if (third.Contains(new String(sep)))
                            {
                                 return false;
                            }

                            if (String.IsNullOrEmpty(third))
                            {
                                NewData = new string[]{first, second};
                            }
                            else
                            {
                                NewData = new string[]{first, second, third};
                            }
                        }
                        else
                        {
                            //Split the string contents into an array
                            NewData = Data.Split(sep);
                        }
                        //Error if there are more than 3 items
                        if(NewData.Length > 3)
                        {
                            return false; 
                        }
                        else if(NewData.GetValue(0).ToString().Length != 0 || NewData.GetValue(1).ToString().Length != 0)
                        {
                            Cells.Add(NewData);
                        }
                    }
                    catch
                    {}
                }
                
                if(Cells.Count == 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private bool InsertTemplate(ArrayList Cells)
        {
            string tmpDataType = "";
            string tmpDataContent = "";
            string errmsg = "Error pasting elements!";
            int tmpCounter = 1;
            
            Array testContent = (Array)Cells[0];
            
            if (testContent.LongLength > 1)
            {
                try
                {
                    ArrayList tmpCells = new ArrayList();
                    string name;
                    Array a;
                    for (int i = 0; i < Cells.Count; i++)
                    {
                        a = (Array)Cells[i];
                        name = (string)a.GetValue(1);
                        tmpCells.Add(name);
                    }
                }
                catch
                {}
            }
            else
            {
                for (int i = 0; i < Cells.Count; i++)
                {
                    Array data = (Array)Cells[i];
                    tmpDataContent = data.GetValue(0).ToString();
                    if (tmpDataContent.Length != 0)
                    {
                        if (tmpDataContent.StartsWith("#"))
                        {
                            continue;
                        }

                        try
                        {
                            this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tmpDataContent);
                            this.currConn.Ping();
                        }
                        catch (System.Exception pexc)
                        {
                            ErrorHandler.DisplayError(errmsg, pexc);
                            return false;
                        }
                    }
                }
                return true;
            }
  
            for (int i = 0; i < Cells.Count; i++)
            {
                Array data = (Array)Cells[i];
                tmpDataType = data.GetValue(0).ToString();
                tmpDataContent = data.GetValue(1).ToString();
                if ((tmpDataType == "N") && (tmpDataContent.Length != 0))
                {
                    try
                    {
                        this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tmpDataContent);
                        this.currConn.Ping();
                    }
                    catch (System.Exception ex)
                    {
                        ErrorHandler.DisplayError(errmsg, ex);
                        MessageBox.Show(errmsg + GeneralConst.UNIX_NEWLINE + ex.Message);
                        return false;
                    }
                }
                else if ((tmpDataType == "S") && (tmpDataContent.Length != 0))
                {
                    try
                    {
                        this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tmpDataContent, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeString, new ConsolidationInfo[] { }, false);
                        this.currConn.Ping();
                    }
                    catch (System.Exception ex)
                    {
                        ErrorHandler.DisplayError(errmsg, ex);
                        MessageBox.Show(errmsg + GeneralConst.UNIX_NEWLINE + ex.Message);
                        return false;
                    }
                }
                else if (tmpDataType == "C" && tmpDataContent.Length != 0)
                {
                    try
                    {
                        this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tmpDataContent, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, new ConsolidationInfo[] { }, true);
                        this.currConn.Ping();
                    }
                    catch (System.Exception ex)
                    {
                        ErrorHandler.DisplayError(errmsg, ex);
                        MessageBox.Show(errmsg + GeneralConst.UNIX_NEWLINE + ex.Message);
                        return false;
                    }
                }
            }
            int id = 1;
            tmpCounter = 1;
            for (int i = 0; i < Cells.Count; i++)
            {
                Array data = (Array)Cells[i];
                tmpDataType = data.GetValue(0).ToString();
                tmpDataContent = data.GetValue(1).ToString();
                if (tmpDataType == "C")
                {
                    try
                    {
                        ArrayList list = new ArrayList();
                        CreateConsolidationData(id, Cells, ref list);
                        ConsolidationInfo[] ci = new ConsolidationInfo[list.Count];
                        int counter = 0;
                        for (int j = 0; j < list.Count; j++)
                        {
                            Array val = (Array)list[j];
                            if (val.GetValue(2).ToString().Length != 0)
                            {
                                string tmpNodeText = val.GetValue(1).ToString();
                                double tmpNodeValue = System.Convert.ToDouble(val.GetValue(2));
                                ci[counter] = new ConsolidationInfo(tmpNodeText, tmpNodeValue);
                            } 
                            else
                            {
                                string tmpNodeText = val.GetValue(1).ToString();
                                ci[counter] = new ConsolidationInfo(tmpNodeText, 1.0);
                            }
                            counter++;
                        }

                        try
                        {
                            this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tmpDataContent, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, ci, true);
                            this.currConn.Ping();
                            tmpCounter++;
                        }
                        catch(System.Exception pexc)
                        {
                            ErrorHandler.DisplayError(errmsg, pexc);
                            return false;
                        }
                    }
                    catch (System.Exception e)
                    {
                        ErrorHandler.DisplayError("Error in InsertTemplate", e);
                    }
                }
                id++;
                continue;
            }
            return true;
        }

        private void delDataAxis()
        {
            if(this.treeViewDims.SelectedNode != null 
                && this.treeViewDims.SelectedNode.Index != -1
                && this.treeViewDims.Nodes.Count > 0 
                && this.treeViewDims.Nodes[0].Text != ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS
                )
            {
                string dim = (string)this.treeViewDims.SelectedNode.Text;

                // determine if dimension if is a part of cube and if so then make some noise
                List<string> cubes = new List<string>(this.currConn.DimensionListCubes(this.currDb, dim, CubeType.NormalCube));
                cubes.AddRange(this.currConn.DimensionListCubes(this.currDb, dim, CubeType.GpuCube));
                if(cubes.Count > 0)
                {
                    MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.TEXT_DATAAXIS_INUSE, new object[] { dim, cubes.Count }), ResourceInitializer.TEXT_DATAAXIS_INUSE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.treeViewDims.SelectedNode = null;
                    //this.xpEditDataAxis.Enabled = false;
                    this.btnDimensionRemove.Enabled = false;
                    return;
                }

                if (MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.TEXT_DELETE_DATAAXIS, new object[] { dim }), ResourceInitializer.TEXT_DELETE_DATAAXIS_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    try
                    {
                        this.currConn.DeleteDimension(this.currDb, dim);
                        this.currConn.Ping();
                        for(int i=1; i<this.tabMain.TabPages.Count; i++)
                        {
                            JTabPage p = (JTabPage)this.tabMain.TabPages[i];

                            if (dim == ((TabTagObject)(p.Tag)).DimName)
                            {
                                this.tabMain.TabPages.Remove(p);
                                break;
                            }
                        }

                        if (this.tabMain.TabPages.Count < 10)
                        {
                            this.tabMain.Multiline = true;
                            //CDNM Only:
                            //this.tabMain.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiForm;
                            //this.tabMain.PositionTop = true;
                            //this.tabMain.BoldSelectedPage = true;
                        }
                        else
                        {
                            this.tabMain.Multiline = false;
                            //CDNM Only:
                            //this.tabMain.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiDocument;
                        }
                        this.treeViewDims.Nodes.Remove(this.treeViewDims.SelectedNode);
                        for (int i = 1; i < this.tabCmdMenu.Items.Count; i++)
                        {
                            ToolStripMenuItem cmdTabDim = (ToolStripMenuItem)this.tabCmdMenu.Items[i];
                            if (dim == cmdTabDim.Text)
                            {
                                this.tabCmdMenu.Items.Remove(cmdTabDim);
                                break;
                            }
                        }

                        if (this.CubeViewStatus == GeneralConst.ATTRIBUTE_CUBE_VIEW)
                        {
                            this.RefreshCubes();
                        }
                    }
                    catch(Exception exc)
                    {
                        ErrorHandler.DisplayError("Error deleting dimension \""+this.treeViewDims.SelectedNode.Text+"\".", exc);
                    }

                    if(this.treeViewDims.Nodes.Count == 0)
                    {
                        this.showHitDims();
                    }
                    this.fixShowHideDataStoreButtons();
                }

                this.treeViewDims.SelectedNode = null;
                //this.xpEditDataAxis.Enabled = false;
                this.btnDimensionRemove.Enabled = false;
                this.comboConnList.Focus();
            }
        }

        private void btnDimensionRemove_Click(object sender, System.EventArgs e)
        {
            this.delDataAxis();
        }

        private void btnDimensionRename_Click(object sender, System.EventArgs e)
        {
            if(this.treeViewDims.SelectedNode != null 
                && this.treeViewDims.Nodes[0].Text != ResourceInitializer.TEXT_HIT_RETURN_VIEWDIMS
                && this.treeViewDims.Nodes.Count > 0)
            {
                try
                {
                    if(this.treeViewDims.SelectedNode.Index != -1)
                    {
                        this.treeViewDims.LabelEdit = true;
                        this.treeViewDims.SelectedNode.NodeFont = this.regularFont;
                        this.treeViewDims.SelectedNode.BeginEdit();
                    }
                }
                catch(Exception renDimExc)
                {
                    ErrorHandler.DisplayError("Error renaming dimension \""+this.treeViewDims.SelectedNode.Text+"\".", renDimExc);
                }
            }
        }

        private void treeViewDims_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            string nT = "";

            // if no node text then remove the node and do nothing
            if(e.Node.Text != null)
            {
                if(e.Label == null)
                {
                    nT = e.Node.Text;
                }
                else
                {
                    nT = e.Label;
                }

                if (nT.Length > 255)
                {
                    nT = nT.Substring(0, 255);
                }

                if( this.nfoAddDataAxis == true)
                {
                    this.nfoAddDataAxis = false;
                    try
                    {
                        this.currConn.DatabaseAddDimension(this.currDb, nT);
                        this.currConn.Ping();
                       
                        JTabPage np = new JTabPage();
                        np.Tag = new TabTagObject(nT, this.currConn.GetAttributeDimension(this.currDb, nT));
                        np.Title = nT.Replace("&", "&&");
                        this.tabMain.TabPages.Add(np);
                        if (this.tabMain.TabPages.Count < 10)
                        {
                            this.tabMain.Multiline = true;
                            //CDNM Only:
                            //this.tabMain.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiForm;
                            //this.tabMain.PositionTop = true;
                            //this.tabMain.BoldSelectedPage = true;
                        }
                        else
                        {
                            this.tabMain.Multiline = false;
                            //CDNM Only:
                            //this.tabMain.Appearance = Crownwood.DotNetMagic.Controls.VisualAppearance.MultiDocument;
                        }
                        ToolStripMenuItem cmdTabDim = new ToolStripMenuItem();
                        cmdTabDim.Text = nT;
                        cmdTabDim.Click += new System.EventHandler(this.cmdTabDim_Click);
                        cmdTabDim.Checked = false;
                        this.tabCmdMenu.Items.Add(cmdTabDim); // new dimension in tabCmdMenu
                        Connect.changesMade = true;
                        if (this.CubeViewStatus == GeneralConst.ATTRIBUTE_CUBE_VIEW)
                        {
                            this.RefreshCubes(); // new attribute-cube
                        }
                    }
                    catch(PaloException addDimExc)
                    {
                        HandleDimensionError(addDimExc, "Error adding DataAxis \"" + this.treeViewDims.SelectedNode.Text + "\".");

                        try
                        {
                            if(this.treeViewDims.SelectedNode != null)
                            {
                                this.treeViewDims.Nodes.Remove(e.Node);
                            }
                        }
                        catch
                        {}
                    }
                }
                else
                {
                    // only if changes were really made
                    if(e.Label != null && e.Node.Text != nT)
                    {
                        try
                        {
                            this.currConn.DatabaseRenameDimension(this.currDb, e.Node.Text, nT);
                            this.currConn.Ping();
                            Connect.changesMade = true;
                            
                            for (int i = 1; i < this.tabMain.TabPages.Count; i++)
                            {
                                JTabPage p = (JTabPage)this.tabMain.TabPages[i];
                                if(((TabTagObject)(p.Tag)).DimName == e.Node.Text)
                                {
                                    p.Tag = new TabTagObject(nT, this.currConn.GetAttributeDimension(this.currDb, nT));
                                    p.Title = nT.Replace("&", "&&");
                                    break;
                                }
                            }

                            for (int i = 1; i < this.tabCmdMenu.Items.Count; i++)
                            {
                                ToolStripMenuItem cmdTabDim = (ToolStripMenuItem)this.tabCmdMenu.Items[i];
                                if (cmdTabDim.Text == e.Node.Text)
                                {
                                    cmdTabDim.Text = nT; // new name in tabCmdMenu
                                    break;
                                }
                            }
                            // update list of cubes
                            this.RefreshCubes();
                        }
                        catch(PaloException renDimExc)
                        {
                            e.CancelEdit = true;
                            HandleDimensionError(renDimExc, "Error renaming DataAxis \"" + this.treeViewDims.SelectedNode.Text + "\".");
                        }
                    }
                }
            }
            else
            {
                if(this.treeViewDims.SelectedNode != null)
                {
                    this.treeViewDims.Nodes.Remove(e.Node);
                }
            }
            this.treeViewDims.LabelEdit = false;
            this.fixShowHideDataStoreButtons();
        }

        private void treeViewDims_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Drawing.Point pt = new System.Drawing.Point( e.X, e.Y );
            TreeNode Node = this.treeViewDims.GetNodeAt( pt );
            if ( Node == null ) return;
            if ( Node.Bounds.Contains( pt ) )
            {
                this.treeViewDims.SelectedNode = Node;
            }

            if(e.Button == MouseButtons.Right && Node.Parent == null)
            {
                this.dimCmdMenu.Show(this.treeViewDims, new Point(e.X,e.Y));
            }

            this.enableButtonsAddDelRenDims(false);
            this.treeViewCubes.SelectedNode = null;
            this.enableButtonsAddDelCub(false);
        }

        private CubeType getCubeandType(ref string cube)
        {
            if (this.treeViewCubes.SelectedNode == null)
            {
                return CubeType.UnknownCubeType;
            }
            
            cube = this.treeViewCubes.SelectedNode.Text;

            return this.currConn.CubeInformation(this.currDb, cube).Type;

        }

        private CubeType getCubeype()
        {
            string cube = "";

            return this.getCubeandType(ref cube);
        }



        private void treeViewCubes_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Drawing.Point pt = new System.Drawing.Point( e.X, e.Y );
            TreeNode Node = this.treeViewCubes.GetNodeAt( pt );
            if ( Node == null ) return;            
            if ( Node.Bounds.Contains( pt ) )            
                this.treeViewCubes.SelectedNode = Node;            

            try
            {
                // JMM 03-20-14
                CubeType CT = Node.Parent == null ? this.getCubeype() : CubeType.UnknownCubeType;
                switch (CT)
                {
                    case CubeType.NormalCube:
                    case CubeType.GpuCube:
                        this.cmdCubeConvert.Visible = true;
                        break;

                    default:
                        this.cmdCubeConvert.Visible = false;
                        break;
                }
            }
            catch
            {

            }

            if (Node.Parent != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    try
                    {
                        this.currDimension = Node.Text;
                        this.currCube = Node.Parent.Text;
                        // Look if there are MDXMeasure_... and MDXTime_...
                        ElementInfo[] de = this.currConn.DimensionListElements(this.currDb, "#_CONFIGURATION_");
                        string sMeasure = "MDXMeasure_" + this.currCube;
                        string sTime = "MDXTime_" + this.currCube;
                        bool foundMeasure = false;
                        bool foundTime = false;
                        for (int i = 0; i < de.Length; i++)
                        {
                            foundMeasure = foundMeasure || String.Equals(de[i].Name, sMeasure);
                            foundTime = foundTime || String.Equals(de[i].Name, sTime);

                        }
                        bool do_ping = false;

                        // Create MDXMeasure_...
                        if (!foundMeasure)
                        {
                            this.currConn.DimensionAddOrUpdateElement(this.currDb, "#_CONFIGURATION_", sMeasure, AddOrUpdateElementMode.AddOrUpdateElementModeForceAdd, DimElementType.DimElementTypeString, new ConsolidationInfo[] { }, false);
                            do_ping = true;
                        }
                        // Create MDXTime_...
                        if (!foundTime)
                        {
                            this.currConn.DimensionAddOrUpdateElement(this.currDb, "#_CONFIGURATION_", sTime, AddOrUpdateElementMode.AddOrUpdateElementModeForceAdd, DimElementType.DimElementTypeString, new ConsolidationInfo[] { }, false);
                            do_ping = true;
                        }
                        if (do_ping)
                        {

                            this.currConn.Ping();
                        }
                        // Look after value of cube #_CONFIGURATION
                        double d = 0.0;
                        string s = null;
                        this.currConn.GetData(ref s, ref d, this.currDb, "#_CONFIGURATION", new string[] { sMeasure });
                        this.cmdMeasure.Checked = (String.Equals(s, this.currDimension));
                        this.currConn.GetData(ref s, ref d, this.currDb, "#_CONFIGURATION", new string[] { sTime });
                        this.cmdTime.Checked = (String.Equals(s, this.currDimension));
                    }
                    catch(Exception /* ex */)
                    {}
                    this.cubeDimCmdMenu.Show(this.treeViewCubes, new Point(e.X, e.Y));
                }
                return;
            }

            this.enableButtonsAddDelCub(false);
            if (e.Button == MouseButtons.Right && this.EditUsersState == false)
            {
                this.cubeCmdMenu.Show(this.treeViewCubes, new Point(e.X,e.Y));

                // ensure there is no toggling on right click
                // that's why we return here
                return;
            }

            if (this.treeViewCubes.SelectedNode != null)
            {
                if(this.treeViewCubes.SelectedNode.IsExpanded)
                    this.treeViewCubes.SelectedNode.Collapse();
                else
                    this.treeViewCubes.SelectedNode.Expand();
                this.treeViewDims.SelectedNode = null;
            }

            this.enableButtonsAddDelRenDims(false);
        }

        private void treeViewDims_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(this.currDb))
            {
                return;
            }

            // RETURN
            if (e.KeyValue == (char)13)//(int)System.Windows.Forms.Keys.Return)
            {
                e.Handled = true;
                try
                {
                    this.addNewDimension();
                }
                catch
                { }
            }

            #region F2
            if (this.treeViewDims.SelectedNode != null && e.KeyValue == (int)System.Windows.Forms.Keys.F2)
            {
                e.Handled = true;
                System.Windows.Forms.TreeNode tmpNode = this.treeViewDims.SelectedNode;// tv.SelectedNode;
                this.treeViewDims.LabelEdit = true;
                tmpNode.BeginEdit();
            }
            #endregion
        }


        #region Add/Del Cubes

        #region Add Cube Wizard
        private void btnCubeAdd_Click(object sender, System.EventArgs e)
        {
            CubeWizard frmCube = new CubeWizard(this.currConn, this.currDb);
            if(frmCube.ShowDialog() == DialogResult.OK)
            {
                try
                {   
                    string[] tmpCubes = new string[frmCube.TreeCube.Nodes.Count];
                    for(int i=0;i<frmCube.TreeCube.Nodes.Count;i++)
                    {
                        tmpCubes.SetValue(frmCube.TreeCube.Nodes[i].Text, i);
                    }
                    this.currConn.DatabaseAddCube(this.currDb, frmCube.CubeName, (string[])tmpCubes);
                    this.currConn.Ping();
                    Connect.changesMade = true;

                    RefreshCubes(frmCube.CubeName );

                    this.cmdDelCube.Enabled = true;
                    this.cmdClearCube.Enabled = true;
                    this.cmdExportCube.Enabled = true;
                    this.cmdRuleEditor.Enabled = true;
                    this.cmdCubeInfo.Enabled = true;
                }
                catch(PaloException exc)
                {
                    string msg;

                    switch (exc.ErrorCode)
                    {
                        case -69:
                        case 5001:
                            msg = ResourceInitializer.ERROR_CUBE_NAME_INVALID;
                            break;

                        default:
                            msg = exc.Message;
                            ErrorHandler.DisplayError("Error adding Data Store", exc);
                            break;

                    }
                    ErrorHandler.ErrorPopup(msg);
                }
            }
            frmCube.Dispose();
            frmCube = null;
        }
        #endregion

        private void btnCubeRemove_Click(object sender, System.EventArgs e)
        {
            if(this.treeViewCubes.SelectedNode != null 
                && this.treeViewCubes.Nodes[0].Text != ResourceInitializer.TEXT_HIT_RETURN_VIEWCUBES
                && this.treeViewCubes.SelectedNode.Index != -1)
            {
                string tmpCube = this.treeViewCubes.SelectedNode.Text;

                // if root node then node is cube
                if(this.treeViewCubes.SelectedNode.FullPath.ToString() == tmpCube)
                {
                    if (MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.TEXT_DELETE_DATASTORE, new object[] { this.treeViewCubes.SelectedNode.Text }), ResourceInitializer.TEXT_DELETE_DATASTORE_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            this.currConn.DeleteCube(this.currDb, tmpCube);
                            this.currConn.Ping();
                            Connect.changesMade = true;
                            RefreshCubes();
                        }
                        catch(Exception cexc)
                        {
                            ErrorHandler.DisplayError("Error deleting cube", cexc);
                        }
                    }
                }
            }

            this.treeViewCubes.SelectedNode = null;
            this.btnCubeRemove.Enabled = false;
            this.btnRuleEditor.Enabled = false;
            this.comboConnList.Focus();
        }

        private void btnRuleEditor_Click(object sender, EventArgs e)
        {
            if (this.treeViewCubes.SelectedNode != null
                && this.treeViewCubes.Nodes[0].Text != ResourceInitializer.TEXT_HIT_RETURN_VIEWCUBES
                && this.treeViewCubes.SelectedNode.Index != -1)
            {
                string tmpCube = this.treeViewCubes.SelectedNode.Text;

                // if root node then node is cube
                if (this.treeViewCubes.SelectedNode.FullPath.ToString() == tmpCube)
                {
                    this.cmdRuleEditor_Click(sender, e);
                }
            }
            this.treeViewCubes.Focus();
        }

        #endregion

        #endregion

        #region ContextMenu Handling(cmdNumeric_Click + cmdString_Click + cmdAddN_Click + cmdElemCopy_Click + cmdElemPaste_Click + cmdClearCube_Click)

        private void cmdNumeric_Click(object sender, System.EventArgs e)
        {
            // if only one element selected and it's of type numeric then no need to make changes => return
            if(this.treeElements.SelectedNodes.Count == 1)
            {
                JNode tn = (JNode)this.treeElements.SelectedNodes[0] as JNode;
                if ((string)tn.Tag == "N")
                {
                    return;
                }
            }

            ArrayList tC = new ArrayList(this.treeElements.SelectedNodes);
            // determine if dimension if is a part of cube and if so then make some noise
            if (!checkCubes(this.currDb, ResourceInitializer.TEXT_CONVERT_TO_NUMERIC, ResourceInitializer.TEXT_CONVERT_TO_NUMERIC_TITLE))
            {
                return;
            }

            for(int i=0; i<tC.Count; i++)
            {
                JNode t = (JNode)tC[i] as JNode;
                // if type consolidated make some noise
                if ((string)t.Tag == "C"
                    && MessageBox.Show(ResourceInitializer.TEXT_CONVERT_CONS_TO_NUMERIC, ResourceInitializer.TEXT_CONVERT_CONS_TO_NUMERIC_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    break;
                }

                try
                {
                    this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, t.Text, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeNumeric, new ConsolidationInfo[] { }, false);
                    this.currConn.Ping();
                    t.Tag = "N";
                    t.ImageIndex = 0;
                    t.SelectedImageIndex = 0;
                }
                catch (PaloException pexc)
                {
                    ErrorHandler.DisplayError("Error converting element type to  string.", pexc);
                }
            }
        }

        private void cmdString_Click(object sender, System.EventArgs e)
        {
            // if only one element selected and it's of type string then no need to make changes => return
            if(this.treeElements.SelectedNodes.Count == 1)
            {
                JNode tn = (JNode)this.treeElements.SelectedNodes[0] as JNode;
                if ((string)tn.Tag == "S")
                {
                    return;
                }
            }

            ArrayList tC = new ArrayList(this.treeElements.SelectedNodes);

            // determine if dimension if is a part of cube and if so then make some noise
            if (!checkCubes(this.currDb, ResourceInitializer.TEXT_CONVERT_TO_STRING, ResourceInitializer.TEXT_CONVERT_TO_STRING_TITLE))
            {
                return;
            }

            for (int i = 0; i < tC.Count; i++)
            {
                JNode t = (JNode)tC[i] as JNode;
                // if type consolidated make some noise
                if ((string)t.Tag == "C"
                    && MessageBox.Show(ResourceInitializer.TEXT_CONVERT_CONS_TO_STRING, ResourceInitializer.TEXT_CONVERT_CONS_TO_STRING_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    break;
                }
                try
                {
                    this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, t.Text, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeString, new ConsolidationInfo[] { }, false);
                    this.currConn.Ping();
                    t.Tag = "S";
                    t.ImageIndex = 1;
                    t.SelectedImageIndex = 1;
                }
                catch (PaloException pexc)
                {
                    ErrorHandler.DisplayError("Error converting element type to  string.", pexc);
                }
            }
        }

        private bool checkCubes(string db, string question, string header)
        {
            // determine if dimension if is a part of cube and if so then make some noise
            List<string> cubes = new List<string>(this.currConn.DimensionListCubes(db, this.currDimension, CubeType.NormalCube));
            cubes.AddRange(this.currConn.DimensionListCubes(db, this.currDimension, CubeType.GpuCube));

            if ((cubes.Count > 0)
                && MessageBox.Show(question, header, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return false;
            }
            return true;
        }


        private void cmdAddN_Click(object sender, System.EventArgs e)
        {
            if(this.cmdString.Checked == false)
            {
                this.addNewElement("N");
            }
            else
            {
                this.addNewElement("S");
            }
        }

        private void cmdElemCopy_Click(object sender, System.EventArgs e)
        {
            this.btnCopy_Click(sender, e);
        }

        private void cmdElemPaste_Click(object sender, System.EventArgs e)
        {
            this.btnPaste_Click(sender, e);
        }

        private void cmdElemSelectAll_Click(object sender, System.EventArgs e)
        {
            for(int i=0; i<this.treeElements.Nodes.Count; i++)
            {
                JNode n = (JNode)this.treeElements.Nodes[i];
                //CDNM: n.Select(false);
                treeElements.SelectNode(n);
            }
        }

        private void cmdClearCube_Click(object sender, System.EventArgs e)
        {
            string tmpCube = "";
            byte cubeview = CubeViewStatus;

            try
            {
                tmpCube = this.treeViewCubes.SelectedNode.Text;
            }
            catch
            {}

            try
            {
                this.comboConnList.SaveItem();
                RegUtils.ActiveCube = tmpCube;
                
                if ((this.ccw == null) || (this.comboConnList.SelectedIndex != this.oldIndex) || (tmpCube != this.oldCube) && !String.IsNullOrEmpty(tmpCube))
                {
                    if (this.ccw != null)
                    {
                        this.ccw.Dispose();
                    }
                    this.oldIndex = this.comboConnList.SelectedIndex;
                    this.oldCube = tmpCube;
                    if ((cubeview == GeneralConst.NORMAL_CUBE_VIEW) && tmpCube.StartsWith(GeneralConst.PREFIX_CELL_RIGHTS))
                    {
                        cubeview = GeneralConst.SYSTEM_CUBE_VIEW;
                    }

                    this.ccw = new ClearCube(1, tmpCube, cubeview);
                }
                
                this.ccw.ShowDialog();
                //ccw.Dispose();
                //ccw = null;
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error invoking Clear Cube", exc);
            }
        }

        private void cmdExportCube_Click(object sender, System.EventArgs e)
        {
            if (this.treeViewCubes.SelectedNode == null)
            {
                return;
            }

            ExportWizard ew = new ExportWizard(".", this.originalCulture, this.currHostname, this.currDb, this.treeViewCubes.SelectedNode.Text);
            ew.ShowDialog();
            ew.Dispose();
            ew = null;
        }

        private void cmdSVSWizard_Click(object sender, System.EventArgs e)
        {
        // JMM 03-20-14 Fireball is no longer available
        #if UNUSED
            if (this.treeViewCubes.SelectedNode == null)
            {
                return;
            }

            Apalo.XlAddin.Forms.SVSWizard ew = new SVSWizard(this.originalCulture, this.currHostname, this.currDb, this.treeViewCubes.SelectedNode.Text);
            ew.ShowDialog();
            ew.Dispose();
            ew = null;
        #endif
        }

        private void cmdCubeConvert_Click(object sender, System.EventArgs e)
        {
            PaloMessage pmsg = new PaloMessage(this, ResourceInitializer.MSG_LONG_ACTION);

            if (MessageBox.Show(ResourceInitializer.QUESTION_LONG_ACTION, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    string cube = "";
                    CubeType type = this.getCubeandType(ref cube);
                    ExcelHelper.SetExcelStatusbar(ResourceInitializer.MSG_LONG_ACTION);
                    pmsg.Show();
                    this.currConn.CubeConvert(this.currDb, cube, (type == CubeType.NormalCube) ? CubeType.GpuCube : CubeType.NormalCube);
                }
                catch (Exception exc)
                {
                    ErrorHandler.ErrorPopup(exc.Message);
                    ErrorHandler.DisplayError("Problem Converting Cube", exc);
                }
                finally
                {
                    pmsg.Close();
                    pmsg.Dispose();
                    pmsg = null;
                    ExcelHelper.ResetExcelStatusbar();
                }
            }
       }


        private void cmdRuleEditor_Click(object sender, System.EventArgs e)
        {
            if ((treeViewCubes == null) || (treeViewCubes.SelectedNode == null))
            {
                return;
            }

            try
            {
                RuleEditorKiss rek = new RuleEditorKiss(this.currHostname, this.currDb, this.treeViewCubes.SelectedNode.Text, CubeViewStatus, originalCulture);
                rek.ShowDialog();
                rek.Close();
                rek.Dispose();
                rek = null;
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Problem initializing Rule Editor", exc);
            }
        }

        private void cmdCountElements_Click(object sender, System.EventArgs e)
        {
            if (this.cElementNode == null)
            {
                if (this.NoElements(this.treeElements))
                {
                    return;
                }
                else
                {
                    int cntN = 0, cntS = 0, cntC = 0, tmpCount = this.treeElements.Nodes.Count;
                    for (int i = 0; i < tmpCount; i++)
                    {
                        JNode tn = (JNode)this.treeElements.Nodes[i] as JNode;
                        string tmpType = (string)tn.Tag;
                        if (tmpType == "N")
                            cntN++;
                        else if (tmpType == "S")
                            cntS++;
                        else if (tmpType == "C")
                            cntC++;
                    }

                    MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.MESSAGE_COUNT_ELEMENTS, new object[] { tmpCount, cntN, cntS, cntC }), ResourceInitializer.CMD_COUNT_ELEMENT, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
        }

        private void cmdDimExport_Click(object sender, EventArgs e)
        {
            if (this.treeViewDims.SelectedNode == null)
            {
                return;
            }

            DimExportForm frm = new DimExportForm(this.originalCulture, this.currHostname, this.currDb, this.treeViewDims.SelectedNode.Text);
            frm.ShowDialog();
            frm.Close();
            frm.Dispose();
            frm = null;
        }

        #region Info Panels
        private void cmdCubeInfo_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.currDb))
            {

                string tmpCube = "";

                try
                {
                    tmpCube = this.treeViewCubes.SelectedNode.Text;
                }
                catch
                { }

                CubeInfo ci = this.currConn.CubeInformation(this.currDb, tmpCube);

                int i, count = ci.Dimensions.Length;
                string dims = "", status, type;

                for (i = 0; i < count; i++)
                {
                    dims += ci.Dimensions[i] + ',';
                }

                dims = dims.Substring(0, dims.Length - 1);

                switch (ci.Status)
                {
                    case CubeStatus.ChangedCube:
                        status = ResourceInitializer.TEXT_CHANGED;
                        break;

                    case CubeStatus.LoadedCube:
                        status = ResourceInitializer.TEXT_LOADED;
                        break;

                    case CubeStatus.UnloadedCube:
                        status = ResourceInitializer.TEXT_UNLOADED;
                        break;

                    default:
                        status = ResourceInitializer.TEXT_UNKNOWN;
                        break;
                }

                switch (ci.Type)
                {
                    case CubeType.AttributeCube:
                        type = ResourceInitializer.TEXT_ATTRIBUT;
                        break;

                    case CubeType.NormalCube:
                        type = ResourceInitializer.TEXT_NORMAL;
                        break;

                    case CubeType.SystemCube:
                        type = ResourceInitializer.TEXT_SYSTEM;
                        break;

                    case CubeType.UserInfoCube:
                        type = ResourceInitializer.TEXT_USER_INFO;
                        break;

                    case CubeType.GpuCube:
                        type = "GPU";
                        break;

                    default:
                        type = ResourceInitializer.TEXT_UNKNOWN;
                        break;
                }

                InformationDialog idd = new InformationDialog();

                idd.Title = ResourceInitializer.CubeInfoTitle;

                idd.l1 = ResourceInitializer.CubeInfoIdentifier;
                idd.v1 = ci.id.ToString();

                idd.l2 = ResourceInitializer.CubeInfoName;
                idd.v2 = ci.Name;

                idd.l3 = ResourceInitializer.CubeInfoNumberDimensions;
                idd.v3 = ci.NumberDimensions.ToString();

                idd.l4 = ResourceInitializer.CubeInfoDimensions;
                idd.v4 = dims;

                idd.l5 = ResourceInitializer.CubeInfoNumberCells;
                idd.v5 = ci.NumberCells.ToString();

                idd.l6 = ResourceInitializer.CubeInfoNumberFilledCells;
                idd.v6 = ci.NumberFilledCells.ToString();

                idd.l7 = ResourceInitializer.CubeInfoFillRatio;
                idd.v7 = (System.Math.Round((ci.NumberCells > 0 ? ci.NumberFilledCells * 100 / ci.NumberCells : 0), 2, MidpointRounding.AwayFromZero)).ToString();

                idd.l8 = ResourceInitializer.CubeInfoStatus;
                idd.v8 = status;

                idd.l9 = ResourceInitializer.CubeInfoType;
                idd.v9 = type;

                idd.ShowDialog(true);
                idd.Dispose();
                idd = null;
            }
        }

        private void cmdDimInfo_Click(object sender, EventArgs e)
        {
            int index = this.comboConnList.SelectedIndex;

            if (!String.IsNullOrEmpty(this.currDb))
            {
                string tmpDim = "";
                System.Text.StringBuilder elements = new System.Text.StringBuilder();

                try
                {
                    tmpDim = this.treeViewDims.SelectedNode.Text;
                }
                catch
                { }

                int shownlength = 100;

                DimensionInfoSimple di = this.currConn.DimensionInformationSimple(this.currDb, tmpDim);
                ElementInfo[] de = this.currConn.DimensionListElements(this.currDb, tmpDim);

                int cntC = 0, cntN = 0, cntS = 0, decount = de.Length;
                int showcount = (decount < shownlength) ? decount : shownlength;


                for (int i = 0; i < decount; ++i)
                {
                    if (i < showcount)
                    {
                        elements.Append(de[i].Name + ",");
                    }

                    switch (de[i].Type)
                    {
                        case DimElementType.DimElementTypeConsolidated:
                            ++cntC;
                            break;

                        case DimElementType.DimElementTypeNumeric:
                            ++cntN;
                            break;

                        case DimElementType.DimElementTypeString:
                            ++cntS;
                            break;
                    }
                }

                if (showcount < decount)
                {
                    elements.Append("...,");
                }


                string type;
                switch (di.Type)
                {
                    case DimensionType.AttributeDimension:
                        type = ResourceInitializer.TEXT_ATTRIBUT;
                        break;

                    case DimensionType.NormalDimension:
                        type = ResourceInitializer.TEXT_NORMAL;
                        break;

                    case DimensionType.SystemDimension:
                        type = ResourceInitializer.TEXT_SYSTEM;
                        break;

                    case DimensionType.UserInfoDimension:
                        type = ResourceInitializer.TEXT_USER_INFO;
                        break;

                    default:
                        type = ResourceInitializer.TEXT_UNKNOWN;
                        break;
                }

                InformationDialog idd = new InformationDialog();
                idd.Title = ResourceInitializer.DimensionInfoTitle;

                idd.l1 = ResourceInitializer.DimensionInfoIdentifier;
                idd.v1 = di.id.ToString();

                idd.l2 = ResourceInitializer.DimensionInfoName;
                idd.v2 = di.Name;

                idd.l3 = ResourceInitializer.DimensionInfoNumberElements;
                idd.v3 = di.NumberElements.ToString();

                idd.l4 = ResourceInitializer.DimensionInfoElements;
                int length = elements.Length;
                length = (length == 0) ? 0 : length - 1;
                idd.v4 = elements.ToString().Substring(0, length);

                idd.l5 = ResourceInitializer.DimensionInfoNElements;
                idd.v5 = cntN.ToString();

                idd.l6 = ResourceInitializer.DimensionInfoSElements;
                idd.v6 = cntS.ToString();

                idd.l7 = ResourceInitializer.DimensionInfoCElements;
                idd.v7 = cntC.ToString();

                idd.l8 = ResourceInitializer.DimensionInfoMaximumLevel;
                idd.v8 = di.MaximumLevel.ToString();

                idd.l9 = ResourceInitializer.DimensionInfoMaximumIndent;
                idd.v9 = di.MaximumIndent.ToString();

                idd.l10 = ResourceInitializer.DimensionInfoMaximumDepth;
                idd.v10 = di.MaximumDepth.ToString();

                idd.l11 = ResourceInitializer.DimensionInfoType;
                idd.v11 = type;

                idd.ShowDialog(true);
                idd.Dispose();
                idd = null;
            }
        }
        #endregion

        private void cmdMeasure_Click(object sender, EventArgs e)
        {
            this.cmdMeasure.Checked = !this.cmdMeasure.Checked;
            string sMeasure = "MDXMeasure_" + this.currCube;
            if (this.cmdMeasure.Checked)
            {
                this.currConn.SetData(this.currDb, "#_CONFIGURATION", new string[] { sMeasure }, this.currDimension);
            } 
            else
            {
                this.currConn.SetData(this.currDb, "#_CONFIGURATION", new string[] { sMeasure }, "");
            }

            if (this.cmdTime.Checked)
            {
                this.cmdTime.Checked = false;
                string sTime = "MDXTime_" + this.currCube;
                this.currConn.SetData(this.currDb, "#_CONFIGURATION", new string[] { sTime }, "");
            }
            this.currConn.Ping();
        }

        private void cmdTime_Click(object sender, EventArgs e)
        {
            this.cmdTime.Checked = !this.cmdTime.Checked;
            string sTime = "MDXTime_" + this.currCube;
            if (this.cmdTime.Checked)
            {
                this.currConn.SetData(this.currDb, "#_CONFIGURATION", new string[] { sTime }, this.currDimension);
            } 
            else
            {
                this.currConn.SetData(this.currDb, "#_CONFIGURATION", new string[] { sTime }, "");
            }

            if (this.cmdMeasure.Checked)
            {
                this.cmdMeasure.Checked = false;
                string sMeasure = "MDXMeasure_" + this.currCube;
                this.currConn.SetData(this.currDb, "#_CONFIGURATION", new string[] { sMeasure }, "");
            }
            this.currConn.Ping();
        }

        private void cmdTabDatabase_Click(object sender, EventArgs e)
        {
            this.tabSettings.Select();
            this.tabMain.SelectedTab = tabSettings;
            //CDNM Only:
            //this.tabSettings.Selected = true;
        }

        private void cmdTabDim_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem cmdTab = (ToolStripMenuItem)sender;
            for (int i = 1; i < this.tabMain.TabPages.Count; i++)
            {
                JTabPage tP = this.tabMain.TabPages[i] as JTabPage;
                if (String.Equals(cmdTab.Text, ((TabTagObject)(tP.Tag)).DimName))
                {
                    tP.Select();
                    tP.Selected = true;
                    break;
                }
            }
        }

        #endregion

        #region Copy/Paste

        #region Helper

        private static bool TestExistingElements(ref JTreeView tw, JNode data)
        {
            bool ret = false;
            //foreach(JNode t in tw.Nodes)
            for(int i=0;i<tw.Nodes.Count;i++)
            {
                JNode t = (JNode)tw.Nodes[i];
                if(t.Text == data.Text.ToString())
                {
                    ret = true;
                    break;
                }   
            }

            return ret;
        }

        private static bool TestExistingElements(ref JTreeView tw, Array data)
        {
            bool ret = false;
            //foreach(JNode t in tw.Nodes)
            for(int i=0;i<tw.Nodes.Count;i++)
            {
                JNode t = (JNode)tw.Nodes[i];
                if(data.LongLength > 1)
                {
                    if(t.Text == data.GetValue(1).ToString())
                    {
                        ret = true;
                        break;
                    }
                }
                else
                {
                    if(t.Text == data.GetValue(0).ToString())
                    {
                        ret = true;
                        break;
                    }
                }
            }

            return ret;
        }

        private static bool TestExistingElements(ref JTreeView tw, out JNode tn, Array data)
        {
            bool ret = false;
            tn = null;
//          foreach(TreeNode t in tw.Nodes)
            //foreach(JNode t in tw.Nodes)
            for(int i=0;i<tw.Nodes.Count;i++)
            {
                JNode t = (JNode)tw.Nodes[i];
                if(data.LongLength > 1)
                {
                    if(t.Text == data.GetValue(1).ToString())
                    {
                        ret = true;
                        tn = t;
                        break;
                    }
                }
                else
                {
                    if(t.Text == data.GetValue(0).ToString())
                    {
                        ret = true;
                        tn = t;
                        break;
                    }
                }
            }

            return ret;
        }


        #endregion

        #region Copy

        private void CopyToClipboard(ArrayList Cells)
        {
            //string InsertString = null;
            System.Text.StringBuilder InsertString = new System.Text.StringBuilder();

            //ensure nodes are sorted
            //SortNodeList(ref Cells);

            for(int i=0;i<Cells.Count;i++)
            {
                JNode t = (JNode)Cells[i] as JNode;
                if(t.Tag.ToString() != "C")
                {
                    //InsertString += (string)t.Tag + (char)9 + t.Text + Environment.NewLine;
                    InsertString.AppendLine((string)t.Tag + (char)9 + t.Text);
                }
                else
                {
                    //InsertString += (string)t.Tag + (char)9 + t.Text + Environment.NewLine;
                    InsertString.AppendLine((string)t.Tag + (char)9 + t.Text);
                    ConsolidationInfo[] tmpData = this.currConn.DimElementListConsolidated(this.currDb, this.currDimension, t.Text);

                    for(int j=0;j<tmpData.Length;j++)
                    {
                        ConsolidationInfo data = (ConsolidationInfo)tmpData[j];
                        //InsertString += (char)9 + data.Name + (char)9 + (float)data.Factor + Environment.NewLine;
                        InsertString.AppendLine((char)9 + data.Name + (char)9 + (float)data.Factor);
                    }                                          
                }
            }
            
            Clipboard.SetDataObject(InsertString.ToString());
        }

        
        #endregion

        private bool InsertClipBoard(ArrayList Cells, uint MovePos, JTreeView tw)
        {
            uint tmpMovePos = MovePos;
            string tmpDataType = "";
            string tmpDataContent = "";
            int tmpCounter = 1;

            Array testContent = (Array)Cells[0];

            if(testContent.LongLength > 1)
            {
                if (this.treeElements.Nodes.Count > 1 || this.treeElements.Nodes[0].Text != GetHitLabelText())
                {
                    if (MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.TEXT_PASTE_ELEMENTS, new object[] { this.currDimension }), ResourceInitializer.TEXT_PASTE_ELEMENTS_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        return false;
                    }
                }
                try
                {
                    ArrayList tmpCells = new ArrayList();
                    string name;
                    Array a;
                    for(int i=0;i<Cells.Count;i++)
                    {
                        a = (Array)Cells[i];
                        name = (string)a.GetValue(1);
                        tmpCells.Add(name);
                    }

                    ElementInfo[] tmpElems = this.currConn.DimensionListElements(this.currDb, this.currDimension);

                    for(int i=0;i<tmpElems.Length;i++)
                    {
                        ElementInfo tmpInfo = (ElementInfo)tmpElems[i];
                        name = tmpInfo.Name;
                        if (!tmpCells.Contains(name))
                        {
                            this.currConn.DimElementDelete(this.currDb, this.currDimension, name);
                        }
                        else if (tmpInfo.Type == DimElementType.DimElementTypeConsolidated)
                        {
                            this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, name, DimElementType.DimElementTypeNumeric, new ConsolidationInfo[] { });
                        }
                    }
                    this.currConn.Ping();
                    this.treeElements.ClearNodes();
                    this.treeElements.ImageList = this.imgListElements;
                }
                catch
                {}
            }
            else
            {
                for(int i=0;i<Cells.Count;i++)
                {
                    Array data = (Array)Cells[i];
                    if(TestExistingElements(ref tw, data) == true)
                        continue;

                    tmpDataContent = (string)data.GetValue(0).ToString();

                    if(tmpDataContent.Length != 0)
                    {
                        if (this.NoElements(tw))
                        {
                            tw.Nodes.Remove(tw.Nodes[0]);
                            tw.ImageList = this.imgListElements;
                        }

                        try
                        {
                            this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tmpDataContent);
                            if (tmpMovePos > 0)
                            {
                                this.currConn.DimElementMove(this.currDb, this.currDimension, tmpDataContent, tmpMovePos);
                            }
                            this.currConn.Ping();
    
                            JNode tn = new JNode();
                            tn.Text = tmpDataContent;
                            tn.Tag = "N";
                            tn.ImageIndex = 0;
                            tn.SelectedImageIndex = 0;
                            tn.NodeFont = this.regularFont;
                            if (tmpMovePos > 0)
                            {
                                tw.Nodes.Insert((int)tmpMovePos, tn);
                            }
                            else
                            {
                                tw.Nodes.Add(tn);
                            }
                            if (tmpMovePos > 0)
                            {
                                tmpMovePos++;
                            }
                        }
                        catch(Exception pexc)
                        {
                            ErrorHandler.DisplayError("Error pasting elements from clipboard!",pexc);
                            MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.ERROR_CLIPBOARD_PASTE, new object[] { tmpDataContent }), ResourceInitializer.ERROR_CLIPBOARD_PASTE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return false;
                        }
                    }
                }

                try
                {
                    ElementInfo[] nfo = this.currConn.DimensionListElements(this.currDb, this.currDimension);

                    if(nfo.LongLength > 0)
                    {
                        this.currConn.DimElementMove(this.currDb, this.currDimension, (string)nfo[0].Name, 0);
                        this.currConn.Ping();
                    }
                }
                catch
                {}

                return true;
            }

            for(int i=0;i<Cells.Count;i++)
            {
                Array data = (Array)Cells[i];
                tmpDataType = data.GetValue(0).ToString();
                tmpDataContent = data.GetValue(1).ToString();
                if(tmpDataType == "N" && tmpDataContent.Length != 0)
                {       
                    JNode tn = new JNode();
                    tn.Text = tmpDataContent;
                    tn.Tag = "N";
                    tn.ImageIndex = 0;
                    tn.SelectedImageIndex = 0;
                    tn.NodeFont = this.regularFont;

                    try
                    {
                        this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, (string)tn.Text);
                        this.currConn.Ping();
                        tw.Nodes.Add(tn);
                    }
                    catch
                    {
                        MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.ERROR_CLIPBOARD_PASTE, new object[] { tn.Text }), ResourceInitializer.ERROR_CLIPBOARD_PASTE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }
                else if(tmpDataType == "S" && tmpDataContent.Length != 0)
                {
                    JNode tn = new JNode();
                    tn.Text = tmpDataContent;
                    tn.Tag = "S";
                    tn.ImageIndex = 1;
                    tn.SelectedImageIndex = 1;
                    tn.NodeFont = this.regularFont;

                    try
                    {
                        this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, (string)tn.Text, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeString, new ConsolidationInfo[] { }, false);
                        this.currConn.Ping();
                        tw.Nodes.Add(tn);
                    }
                    catch
                    {
                        MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.ERROR_CLIPBOARD_PASTE, new object[] { tn.Text }), ResourceInitializer.ERROR_CLIPBOARD_PASTE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }
                else if(tmpDataType == "C" && tmpDataContent.Length != 0)
                {
                    JNode tn = new JNode();
                    tn.Text = tmpDataContent;
                    tn.Tag = "C";
                    tn.ImageIndex = 2;
                    tn.SelectedImageIndex = 2;
                    tn.NodeFont = this.regularFont;

                    try
                    {
                        this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, (string)tn.Text, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, new ConsolidationInfo[] { }, true);
                        this.currConn.Ping();
                        tw.Nodes.Add(tn);
                    }
                    catch
                    {
                        MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.ERROR_CLIPBOARD_PASTE, new object[] { tn.Text }), ResourceInitializer.ERROR_CLIPBOARD_PASTE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }
            }

            int id = 1;
            tmpCounter = 1;
            for(int i=0;i<Cells.Count;i++)
            {
                Array data = (Array)Cells[i];
                JNode testNode;
                tmpDataType = data.GetValue(0).ToString();
                tmpDataContent = (string)data.GetValue(1).ToString();
                if(TestExistingElements(ref tw, out testNode, data) == true)
                {
                    if(tmpDataType == "C")
                    {
                        try
                        {
                            ArrayList list = new ArrayList();
                            CreateConsolidationData(id, Cells, ref list);
                
                            ConsolidationInfo[] ci = new ConsolidationInfo[list.Count];
                            int counter = 0;
                            //foreach(Array val in list)
                            for(int j=0;j<list.Count;j++)
                            {
                                Array val = (Array)list[j];
                                if(val.GetValue(2).ToString().Length != 0)
                                {
                                    string tmpNodeText = val.GetValue(1).ToString();
                                    double tmpNodeValue = System.Convert.ToDouble(val.GetValue(2));
                                    ci[counter] =  new ConsolidationInfo(tmpNodeText,tmpNodeValue);
                                }
                                else
                                {
                                    string tmpNodeText = val.GetValue(1).ToString();
                                    double tmpNodeValue = System.Convert.ToDouble(1);
                                    ci[counter] =  new ConsolidationInfo(tmpNodeText, tmpNodeValue);
                                }
                                counter++;                      
                            }

                            try
                            {
                                if (tmpCounter != Cells.Count)
                                {
                                    this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tmpDataContent, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, ci, true);
                                }
                                else
                                {
                                    this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tmpDataContent, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, ci, true);
                                }

                                this.currConn.Ping();
                                tmpCounter++;
        
                                ((JNode)testNode).Tag = "C";
                                testNode.ImageIndex = 2;
                                testNode.SelectedImageIndex =2;
                            }
                            catch(Exception pexc)
                            {
                                ErrorHandler.DisplayError("Error pasting elements!",pexc);
                                MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.ERROR_CLIPBOARD_PASTE, new object[] { tmpDataContent }), ResourceInitializer.ERROR_CLIPBOARD_PASTE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                return false;
                            }
                        }
                        catch(Exception e)
                        {
                            ErrorHandler.DisplayError("Error in InsertClipboard", e);
                        }
                    }
                    else if(data.GetValue(0).ToString() == "S")
                    {
                        ((JNode)testNode).Tag = "S";
                        testNode.ImageIndex = 1;
                        testNode.SelectedImageIndex = 1;
                    }
                    id++;
                    continue;
                }
            }

            try
            {
                ElementInfo[] nfo = this.currConn.DimensionListElements(this.currDb, this.currDimension);

                if(nfo.LongLength > 0)
                {
                    this.currConn.DimElementMove(this.currDb, this.currDimension, (string)nfo[0].Name, 0);
                    this.currConn.Ping();
                }
            }
            catch
            {
                //MessageBox.Show("Import failed!");
                //return false;
            }
            
            return true;
        }

        // Dominik ?!
        private static bool CreateConsolidationData(int pos, ArrayList Cells, ref ArrayList list)
        {
            int id = 0;
            //foreach(Array data in Cells)
            for(int i=0;i<Cells.Count;i++)
            {
                Array data = (Array)Cells[i];
                if(data.GetValue(0).ToString().Length == 0 && data.GetValue(1).ToString().Length != 0 && id >= pos)
                {
                    try
                    {
                        list.Add(data);
                    }
                    catch(Exception e)
                    {
                        ErrorHandler.DisplayError("Error creating consolidation data!", e);
                    }
                }
                else if(data.GetValue(0).ToString().Length != 0 && id >= pos)
                {
                    break;
                }
                id++;
            }
            return true;
        }

        private static bool ReadClipBoard(ref ArrayList Cells)
        {
            try
            {
                //Read the copied data from the Clipboard
                IDataObject iData = Clipboard.GetDataObject();          
                //Next proceed only of the copied data is in the CSV format indicating Excel content
                if(iData.GetDataPresent(DataFormats.CommaSeparatedValue, false))
                {
                    //Cast the copied data in the CommaSeparatedValue format & hold in a StreamReader Object
                    StreamReader sr = new StreamReader((Stream)iData.GetData(DataFormats.CommaSeparatedValue), System.Text.Encoding.GetEncoding(0));

                    //Loop till no further data is available
                    while(sr.Peek() > 0)
                    {
                        //Read a line of data from the StreamReader object
                        string Data = sr.ReadLine();                        
                        //Separator
                        char[] sep = {';'}; // German Excel
                        // check if separator is comma
                        string tmpSep = ";";
                        if(Data.Length > 0)
                            tmpSep = Data.Substring(Data.Length - 1);

                        if(Data.Length > 2 && (tmpSep.Equals(',') || Data[0].Equals(',') || Data[1].Equals(',')))
                            sep = new char[]{','}; // English Excel

                        try
                        {
                            Array NewData;
                            // If the second cell in Data contains the delimiter, then \" is inserted at the beginning and at the end of the second string.
                            if (Data.Contains("\""))
                            {
                                int pos = Data.IndexOf("\"");
                                string first = Data.Substring(0, pos - 1);
                                int last = Data.LastIndexOf("\"");
                                string second = Data.Substring(pos + 1, last - pos - 1);
                                string third = "";
                                if (Data.Length > last + 1)
                                {
                                    third = Data.Substring(last + 2);
                                }
                                //Error if there is more than one left
                                if (third.Contains(new String(sep)))
                                {
                                    return false;
                                }

                                if (String.IsNullOrEmpty(third))
                                {
                                    NewData = new string[]{first, second};
                                }
                                else
                                {
                                    NewData = new string[]{first, second, third};
                                }
                            }
                            else
                            {
                                //Split the string contents into an array
                                NewData = Data.Split(sep);
                            }
                            //Error if there are more than 3 items
                            if(NewData.Length > 3)
                            {
                                return false; 
                            }
                            else if(NewData.GetValue(0).ToString().Length != 0 || NewData.GetValue(1).ToString().Length != 0)
                            {
                                Cells.Add(NewData);
                            }
                        }
                        catch
                        {}
                    }
                }
                else
                {
                    return false;
                }
                
                if(Cells.Count == 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region DragDrop Elements

        // Helper

        private bool ElementInUse(string elem)
        {
            if (String.IsNullOrEmpty(this.currDb) || String.IsNullOrEmpty(this.currDimension) || (this.currConn == null))
            {
                return false;
            }

            ElementInfo[] elems = this.currConn.DimensionListElements(this.currDb, this.currDimension);
            int i, j, cntElems = 0, cnfolength;
            ElementInfo d;
            bool found = false;
            long id = -1;
            string cmpstr = elem.ToUpper();

            for (i = 0; i < elems.Length; i++)
            {
                if (elems[i].Name.ToUpper() == cmpstr)
                {
                    id = elems[i].Identifier;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return false;
            }

            for(i=0;i<elems.Length;i++)
            {
                d = elems[i];
                if (d.Type == DimElementType.DimElementTypeConsolidated)
                {
                    cnfolength = d.Children.Length;
                    for(j=0;j<cnfolength;j++)
                    {
                        if (d.Children[j].Identifier == id)
                        {
                            cntElems++;
                        }
                    }
                }
            }

            if(cntElems > 1)
                return true;
            else
                return false;
        }

        // Start dragging and enable move effect
        private void treeElements_NodeDragOver(object sender, DragEventArgs e)
        {
            if((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.Move;
        }

        // Get the start element
        private void treeElements_NodeDrag(object sender, ItemDragEventArgs e)
        {
        NodesCollection nc = e.Item as NodesCollection;
        if (nc.Count > 0)
            {
            StartNode = nc[0] as JNode;
            DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        // Finish dragging - do the actual move
        private void treeElements_NodeDragDrop(object sender, DragEventArgs e)
        {
            #region Find Target, Parent Nodes

            // Find Target Node, exit if empty or same
            Point pt = treeElements.PointToClient(new Point(e.X, e.Y));
            JNode n = treeElements.GetNodeAt(pt) as JNode;
            if(n == null)
                return;
            if(StartNode.Text == n.Text)
                return;                        

            this.TargetNode = n;

            // Find out parent node - parent element
            string sPath = StartNode.FullPath;
            string tPath = TargetNode.FullPath;
            string sParent = "";
            string tParent = "";

            int sPos = sPath.LastIndexOf("\\");
            if(sPos > 0)
            {
                sParent = sPath.Substring(0, sPos);
                sPos = sParent.LastIndexOf("\\");
                if(sPos > 0)
                    sParent = sParent.Substring(sPos + 1);
            }

            int tPos = tPath.LastIndexOf("\\");
            if(tPos > 0)
            {
                tParent = tPath.Substring(0, tPos);
                tPos = tParent.LastIndexOf("\\");
                if(tPos > 0)
                    tParent = tParent.Substring(tPos + 1);              
            }
                    
            #endregion

            #region Implementation

            // If C or Root element than show options else move it
            if (this.currConn.ElementType(this.currDb, this.currDimension, this.TargetNode.Text) == DimElementType.DimElementTypeConsolidated ||
                this.currConn.ElementParentCount(this.currDb, this.currDimension, this.TargetNode.Text) == 0)
            {
                if((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    this.DoCopyNode = true;
                    this.ChildSiblingCopy.Show(new Point(e.X, e.Y));
                }
                else
                {
                    this.DoCopyNode = false;
                    this.ChildSibling.Show(new Point(e.X, e.Y));
                }
            }
            else
            {
                // form the new ci
                ConsolidationInfo[] ci = this.currConn.DimElementListConsolidated(this.currDb, this.currDimension, tParent);
                ConsolidationInfo[] nci = null;
                int tmpCounter = 0;

                if(tParent != sParent)
                {
                    nci = new ConsolidationInfo[ci.Length + 1];
                    //foreach(ConsolidationInfo nfo in ci)
                    for(int i=0; i<ci.Length; i++)
                    {
                        ConsolidationInfo nfo = (ConsolidationInfo)ci[i];
                        nci[tmpCounter].Name = nfo.Name;
                        nci[tmpCounter].Factor = nfo.Factor;
                        if((string)nfo.Name == (string)this.TargetNode.Text)
                        {
                            tmpCounter++;
                            nci[tmpCounter].Name = StartNode.Text;
                            nci[tmpCounter].Factor = (double)1;
                        }
                        tmpCounter++;
                    }
                }
                else
                {
                    // create new ci
                    nci = new ConsolidationInfo[ci.Length];
                    
                    // if dragging from top to button
                    if(StartNode.Index < TargetNode.Index)
                    {
                        // fill everything from start to dragging element
                        for(int i = 0; i < this.StartNode.Index; i++)
                        {
                            nci[i].Name = ci[i].Name;
                            nci[i].Factor = ci[i].Factor;
                        }

                        // fill everything from dragging to target element
                        for(int i = this.StartNode.Index; i < this.TargetNode.Index; i++)
                        {
                            nci[i].Name = ci[i + 1].Name;
                            nci[i].Factor = ci[i + 1].Factor;
                        }

                        //target node is always start node
                        nci[this.TargetNode.Index].Name = ci[this.StartNode.Index].Name;
                        nci[this.TargetNode.Index].Factor = ci[this.StartNode.Index].Factor;

                        // fill the rest
                        for(int i = this.TargetNode.Index + 1; i < ci.Length; i++)
                        {
                            nci[i].Name = ci[i].Name;
                            nci[i].Factor = ci[i].Factor;
                        }
                    }
                    else
                    {// if dragging from bottom to top

                        // fill everything from start to dragging element
                        for(int i = 0; i < this.TargetNode.Index; i++)
                        {
                            nci[i].Name = ci[i].Name;
                            nci[i].Factor = ci[i].Factor;
                        }

                        //target node is always start node
                        nci[this.TargetNode.Index].Name = ci[this.StartNode.Index].Name;
                        nci[this.TargetNode.Index].Factor = ci[this.StartNode.Index].Factor;

                        // from target element to end
                        for(int i = this.TargetNode.Index + 1; i <= this.StartNode.Index; i++)
                        {
                            nci[i].Name = ci[i - 1].Name;
                            nci[i].Factor = ci[i - 1].Factor;
                        }

                        // fill the rest
                        for(int i = this.StartNode.Index + 1; i < ci.Length; i++)
                        {
                            nci[i].Name = ci[i].Name;
                            nci[i].Factor = ci[i].Factor;
                        }
                    }
                }

                try
                {
                    // add it to the new C element
                    this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, tParent, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, nci, false);
                    this.currConn.Ping();

                    // remove it from the old one if not within the same C element
                    if(tParent != sParent && (!String.IsNullOrEmpty(sParent))
                        && (System.Windows.Forms.Control.ModifierKeys & Keys.Control) != Keys.Control)
                    {
                        if (this.currConn.ElementType(this.currDb, this.currDimension, this.StartNode.Text) != DimElementType.DimElementTypeConsolidated ||
                            this.currConn.ElementParentCount(this.currDb, this.currDimension, this.StartNode.Text) != 0)
                        {
                            ci = this.currConn.DimElementListConsolidated(this.currDb, this.currDimension, sParent);
                            nci = new ConsolidationInfo[ci.Length - 1];

                            tmpCounter = 0;
                            //foreach(ConsolidationInfo nfo in ci)
                            for (int i = 0; i < ci.Length; i++)
                            {
                                ConsolidationInfo nfo = (ConsolidationInfo)ci[i];

                                if ((string)nfo.Name != (string)this.StartNode.Text)
                                {
                                    nci[tmpCounter].Name = nfo.Name;
                                    nci[tmpCounter].Factor = nfo.Factor;
                                }
                                tmpCounter++;
                            }

                            try
                            {
                                this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, sParent, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, nci, false);
                                this.currConn.Ping();
                            }
                            catch(PaloException excDau)
                            {
                                HandleCircular(excDau);
                            }
                        }

                        Connect.changesMade = true;
                    }
                }
                catch(Exception drag)
                {
                    ErrorHandler.DisplayError("Error doing drag-drop elements!", drag);
                }

                // refresh the tree
                Hashtable tmpHt = new Hashtable();
                for(int i=0;i<this.treeElements.Nodes.Count;i++)
                {
                    JNode tmpNode = (JNode)this.treeElements.Nodes[i];
                    if(!tmpHt.ContainsKey(tmpNode.FullPath))
                        tmpHt.Add(tmpNode.FullPath, tmpNode.IsExpanded);

                    if(tmpNode.Nodes.Count > 0)
                        DoChildren(tmpNode, ref tmpHt);
                }
                this.treeSourceElements.Items.Clear();
                this.treeElements.ClearNodes();
                CheckIfCElementsEmpty();

                this.showElements(true);
                this.btnExpandAll.PerformClick();
                for(int i=0;i<this.treeElements.Nodes.Count;i++)
                {
                    JNode tmpNode = (JNode)this.treeElements.Nodes[i];
                    if(!tmpHt.ContainsKey(tmpNode.FullPath))
                    {
                        tmpNode.Expand();
                        continue;
                    }
                    else
                    {
                        if((bool)tmpHt[tmpNode.FullPath])
                            tmpNode.Expand();
                        else
                            tmpNode.Collapse();

                        if(tmpNode.Nodes.Count > 0)
                            DoChildrenExpand(tmpNode, tmpHt);
                    }
                }

                //  JMM 09-17-13 Clone collection ...
                //TreeNodeCollection tmpTc = (TreeNodeCollection)/*this.treeElements.Nodes.Clone();*/
                //                                     CJNode.CloneCollection(this.treeElements.Nodes);
            }

            #endregion
        }

        #region Helper recursion functions
        private void DoChildrenExpand(JNode n, Hashtable ht)
        {
            for(int i=0;i<n.Nodes.Count;i++)
            {
                JNode tN = (JNode)n.Nodes[i];
                if(!ht.ContainsKey(tN.FullPath))
                {
                    tN.Expand();
                    continue;
                }
                else
                {
                    if((bool)ht[tN.FullPath])
                        tN.Expand();
                    else
                        tN.Collapse();

                    if(tN.Nodes.Count > 0)
                        DoChildrenExpand(tN, ht);
                }

            }
        }

        private void DoChildren(JNode n, ref Hashtable ht)
        {
            for(int i=0;i<n.Nodes.Count;i++)
            {
                JNode tN = (JNode)n.Nodes[i];
                if(!ht.ContainsKey(tN.FullPath))
                    ht.Add(tN.FullPath, tN.IsExpanded);

                if(tN.Nodes.Count > 0)
                    DoChildren(tN, ref ht);
            }
        }
        #endregion
        
        private void cmdChild_Click(object sender, System.EventArgs e)
        {
            if(this.StartNode == null || this.TargetNode == null)
                return;

            #region Find out parent node - parent element

            string sPath = this.StartNode.FullPath;
            string tPath = this.TargetNode.FullPath;
            string sParent = "";
            string tParent = "";

            int sPos = sPath.LastIndexOf("\\");
            if(sPos > 0)
            {
                sParent = sPath.Substring(0, sPos);
                sPos = sParent.LastIndexOf("\\");
                if(sPos > 0)
                    sParent = sParent.Substring(sPos + 1);
            }

            int tPos = tPath.LastIndexOf("\\");
            if(tPos > 0)
            {
                tParent = tPath.Substring(0, tPos);
                tPos = tParent.LastIndexOf("\\");
                if(tPos > 0)
                    tParent = tParent.Substring(tPos + 1);              
            }

            #endregion

            #region Implementation

            ConsolidationInfo[] ci = null;
            ConsolidationInfo[] nci = null;
            int tmpCounter = 1;
            int cntUnique = 0;

            if (this.currConn.ElementType(this.currDb, this.currDimension, this.TargetNode.Text) == DimElementType.DimElementTypeConsolidated)
            {
                // form the new ci
                ci = this.currConn.DimElementListConsolidated(this.currDb, this.currDimension, this.TargetNode.Text);

                //foreach(ConsolidationInfo nfo in ci)
                for (int i = 0; i < ci.Length; i++)
                {
                    ConsolidationInfo nfo = (ConsolidationInfo)ci[i];
                    if((string)nfo.Name == this.StartNode.Text)
                        cntUnique++; // StartNode is already child of TargetNode.
                }
            }

            try
            {
                // first remove it from the old one.
                if ((this.currConn.ElementType(this.currDb, this.currDimension, this.StartNode.Text) != DimElementType.DimElementTypeConsolidated
                    || this.currConn.ElementParentCount(this.currDb, this.currDimension, this.StartNode.Text) != 0)
                    && cntUnique == 0
                    && this.DoCopyNode == false)
                {
                    if(!String.IsNullOrEmpty(sParent)) // a numerical root-element must not be removed - automatically it is no root-element any more, if it has a new parent now.
                    {
                        // remove StartNode from consolidated parent element.
                        ci = this.currConn.DimElementListConsolidated(this.currDb, this.currDimension, sParent);
                        nci = new ConsolidationInfo[ci.Length - 1];

                        tmpCounter = 0;
                        //foreach(ConsolidationInfo nfo in ci)
                        for (int i = 0; i < ci.Length; i++)
                        {
                            ConsolidationInfo nfo = (ConsolidationInfo)ci[i];
                            if ((string)nfo.Name == (string)this.StartNode.Text)
                                continue;

                            nci[tmpCounter].Name = nfo.Name;
                            nci[tmpCounter].Factor = nfo.Factor;
                            tmpCounter++;
                        }
                        try
                        {
                            this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, sParent, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, nci, false);
                            this.currConn.Ping();
                        }
                        catch (PaloException excDau)
                        {
                            HandleCircular(excDau);
                        }
                    }
                }

                if (this.currConn.ElementType(this.currDb, this.currDimension, this.TargetNode.Text) == DimElementType.DimElementTypeConsolidated)
                {
                    // form the new ci
                    ci = this.currConn.DimElementListConsolidated(this.currDb, this.currDimension, this.TargetNode.Text);
                    nci = new ConsolidationInfo[ci.Length + 1];
                    nci[0].Name = this.StartNode.Text; // StartNode as first child of target.
                    nci[0].Factor = (double)1.0;
                    tmpCounter = 1;
                    //foreach(ConsolidationInfo nfo in ci)
                    for (int i = 0; i < ci.Length; i++)
                    {
                        ConsolidationInfo nfo = (ConsolidationInfo)ci[i];
                        nci[tmpCounter].Name = nfo.Name;
                        nci[tmpCounter].Factor = nfo.Factor;
                        tmpCounter++;
                    }
                }
                else
                {
                    nci = new ConsolidationInfo[1]; // target will be changed into consolidated.
                    nci[0].Name = this.StartNode.Text;
                    nci[0].Factor = (double)1.0;
                }
                // second add it to the new C element.
                if (cntUnique == 0)
                {
                    this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, this.TargetNode.Text, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, nci, false);
                    this.currConn.Ping();
                }
                // If StartNode is already child of TargetNode, no change! Also do not remove StartNode, if cntUnique > 0.
            }
            catch(Exception drag)
            {
                ErrorHandler.DisplayError("Error doing drag-drop elements!", drag);
            }

            // refresh the tree
            this.treeSourceElements.Items.Clear();
            this.treeElements.ClearNodes();
            CheckIfCElementsEmpty();

            this.showElements(true);
            switch(this.CurrentExpandState)
            {
                case 0:
                    this.PDbutton_collaps_all_Click(new object(), new System.EventArgs());
                    break;

                case 1:
                    this.btnExp1_Click(new object(), new System.EventArgs());
                    break;

                case 2:
                    this.btnExp2_Click(new object(), new System.EventArgs());
                    break;

                case 3:
                    this.btnExp3_Click(new object(), new System.EventArgs());
                    break;

                case 4:
                    this.btnExp4_Click(new object(), new System.EventArgs());
                    break;

                case 5:
                    this.btnExp5_Click(new object(), new System.EventArgs());
                    break;

                default:
                    this.PDbutton_expand_all_Click(new object(), new System.EventArgs());
                    break;
            }

            for(int i=0;i<this.treeElements.Nodes.Count;i++)
            {
                JNode tmpN = (JNode)this.treeElements.Nodes[i];
                if(tmpN.Text == this.StartNode.Text
                    || tmpN.Text == this.TargetNode.Text)
                    tmpN.Expand();
            }

            #endregion
        }

        private void cmdSibling_Click(object sender, System.EventArgs e)
        {
            if ((this.StartNode == null) || (this.TargetNode == null) || (this.StartNode == this.TargetNode))
            {
                return;
            }

            #region Find out parent node - parent element

            string sPath = this.StartNode.FullPath;
            string tPath = this.TargetNode.FullPath;
            string sParent = "";
            string tParent = "";

            int sPos = sPath.LastIndexOf("\\");
            if (sPos > 0)
            {
                sParent = sPath.Substring(0, sPos);
                sPos = sParent.LastIndexOf("\\");
                if (sPos > 0)
                    sParent = sParent.Substring(sPos + 1);
            }

            int tPos = tPath.LastIndexOf("\\");
            if (tPos > 0)
            {
                tParent = tPath.Substring(0, tPos);
                tPos = tParent.LastIndexOf("\\");
                if (tPos > 0)
                    tParent = tParent.Substring(tPos + 1);
            }

            #endregion

            #region Implementation

            ConsolidationInfo[] ci = null;
            ConsolidationInfo[] nci = null;
            int tmpCounter = 0;
            string ElementToChange = "";

            if (tParent.Length != 0)
            {
                // form the new ci
                ci = this.currConn.DimElementListConsolidated(this.currDb, this.currDimension, tParent);
                ElementToChange = tParent;

                if (tParent == sParent)
                {
                    nci = new ConsolidationInfo[ci.Length];
                    //foreach(ConsolidationInfo nfo in ci)
                    for (int i = 0; i < ci.Length; i++)
                    {
                        ConsolidationInfo nfo = (ConsolidationInfo)ci[i];
                        if ((string)nfo.Name == this.StartNode.Text)
                        {
                            // Skip StartNode.
                            continue;
                        }
                        nci[tmpCounter].Name = nfo.Name;
                        nci[tmpCounter].Factor = nfo.Factor;
                        tmpCounter++;
                        if ((string)nfo.Name == this.TargetNode.Text)
                        {
                            // Insert StartNode after TargetNode.
                            nci[tmpCounter].Name = this.StartNode.Text;
                            nci[tmpCounter].Factor = (double)1.0;
                            tmpCounter++;
                        }
                    }
                }
                else
                {
                    nci = new ConsolidationInfo[ci.Length + 1];

                    //foreach(ConsolidationInfo nfo in ci)
                    for (int i = 0; i < ci.Length; i++)
                    {
                        ConsolidationInfo nfo = (ConsolidationInfo)ci[i];
                        nci[tmpCounter].Name = nfo.Name;
                        nci[tmpCounter].Factor = nfo.Factor;
                        tmpCounter++;
                        if ((string)nfo.Name == this.TargetNode.Text)
                        {
                            // Insert StartNode after TargetNode.
                            nci[tmpCounter].Name = this.StartNode.Text;
                            nci[tmpCounter].Factor = (double)1.0;
                            tmpCounter++;
                        }
                    }
                }
                //nci[tmpCounter].Name = this.StartNode.Text;
                //nci[tmpCounter].Factor = (double)1.0;
            }
            else
            {
                // We remove StartNode from its parent. So it will be a root-element (if it is not in use any more).
                //nci = new ConsolidationInfo[1];
                //nci[0].Name = this.StartNode.Text;
                //nci[0].Factor = (double)1.0;
                //ElementToChange = this.StartNode.Text;
            }

            try
            {
                if (tParent.Length != 0)
                {
                    // add it to the new C element
                    this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, ElementToChange, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, nci, false);
                    this.currConn.Ping();
                }
                else
                {
                    // We remove StartNode from its parent. So it will be a root-element, if it is not in use any more, else show a message.
                    if (ElementInUse(this.StartNode.Text))
                    {
                        ErrorHandler.ErrorPopup(ResourceInitializer.Replace(ResourceInitializer.MESSAGE_ELEMENT_DROP, new object[] { this.StartNode.Text, sParent }));
                    }
                }

                // remove it from the old one
                if ((this.currConn.ElementType(this.currDb, this.currDimension, this.StartNode.Text) != DimElementType.DimElementTypeConsolidated
                    || this.currConn.ElementParentCount(this.currDb, this.currDimension, this.StartNode.Text) != 0)
                    && tParent != sParent
                    && this.DoCopyNode == false)
                {
                    if (!String.IsNullOrEmpty(sParent)) // a numerical root-element must not be removed - automatically it is no root-element any more, if it has a new parent now.
                    {
                        ci = this.currConn.DimElementListConsolidated(this.currDb, this.currDimension, sParent);
                        nci = new ConsolidationInfo[ci.Length - 1];

                        tmpCounter = 0;
                        //foreach(ConsolidationInfo nfo in ci)
                        for (int i = 0; i < ci.Length; i++)
                        {
                            ConsolidationInfo nfo = (ConsolidationInfo)ci[i];
                            // Skip StartNode.
                            if ((string)nfo.Name != (string)this.StartNode.Text)
                            {
                                nci[tmpCounter].Name = nfo.Name;
                                nci[tmpCounter].Factor = nfo.Factor;
                            }

                            tmpCounter++;
                        }

                        try
                        {
                            this.currConn.DimensionAddOrUpdateElement(this.currDb, this.currDimension, sParent, AddOrUpdateElementMode.AddOrUpdateElementModeAddOrUpdate, DimElementType.DimElementTypeConsolidated, nci, false);
                            this.currConn.Ping();
                        }
                        catch (PaloException excDau)
                        {
                            HandleCircular(excDau);
                        }
                    }
                }
            }
            catch (Exception drag)
            {
                ErrorHandler.DisplayError("Error doing drag-drop elements!", drag);
            }

            // refresh the tree
            this.treeSourceElements.Items.Clear();
            this.treeElements.ClearNodes();
            CheckIfCElementsEmpty();
 
            this.showElements(true);
            switch (this.CurrentExpandState)
            {
                case 0:
                    this.PDbutton_collaps_all_Click(new object(), new System.EventArgs());
                    break;

                case 1:
                    this.btnExp1_Click(new object(), new System.EventArgs());
                    break;

                case 2:
                    this.btnExp2_Click(new object(), new System.EventArgs());
                    break;

                case 3:
                    this.btnExp3_Click(new object(), new System.EventArgs());
                    break;

                case 4:
                    this.btnExp4_Click(new object(), new System.EventArgs());
                    break;

                case 5:
                    this.btnExp5_Click(new object(), new System.EventArgs());
                    break;

                default:
                    this.PDbutton_expand_all_Click(new object(), new System.EventArgs());
                    break;
            }

            for (int i = 0; i < this.treeElements.Nodes.Count; i++)
            {
                JNode n = (JNode)this.treeElements.Nodes[i];
                if (n.Text == this.StartNode.Text
                    || n.Text == this.TargetNode.Text)
                    n.Expand();
            }

            #endregion
        }

        private void cmdChildCopy_Click(object sender, System.EventArgs e)
        {
            this.cmdChild_Click(sender, e);
        }

        private void cmdSiblingCopy_Click(object sender, System.EventArgs e)
        {
            this.cmdSibling_Click(sender, e);
        }

        #endregion

        #region Expande/Colapse events

        private void prepare_collaps(TreeNodeCollection nodes, int level)
        {
            int cntElems = nodes.Count;
            for(int i=0;i<cntElems;i++)
            {
                if (nodes[i].IsExpanded && (nodes[i].Nodes.Count > 0))
                {
                    this.prepare_collaps(nodes[i].Nodes, level + 1);
                }
                else
                {
                    if (level > this.max_exp_level)
                    {
                        this.max_exp_level = level;
                    }
                }
            }
        }

        private void do_collaps(TreeNodeCollection nodes, int level)
        {
            int cntElems = nodes.Count;
            for(int i=0;i<cntElems;i++)
            {
                if (nodes[i].IsExpanded && (nodes[i].Nodes.Count > 0))
                {
                    this.do_collaps(nodes[i].Nodes, level + 1);
                }
                else
                {
                    if ((level == this.max_exp_level) && (nodes[i].Parent != null))
                    {
                        //CDNM:
                        //nodes[i].Deselect();
                        //nodes[i].Parent.Expanded =false;
                        treeElements.SelectNode(nodes[i], false);
                        nodes[i].Parent.Collapse();     
                    }
                }
            }
        }

        private void do_expand(TreeNodeCollection nodes)
        {
            int cntElems = nodes.Count;
            for(int i=0;i<cntElems;i++)
            {
                if (nodes[i].IsExpanded && (nodes[i].Nodes.Count > 0))
                {
                    this.do_expand(nodes[i].Nodes);
                }
                else
                {
                    nodes[i].Expand();      // CDNM: Expanded = true;
                }
            }
        }

        private void PDbutton_expand_Click(object sender, System.EventArgs e)
        {
            TreeNodeCollection Elems = this.treeElements.Nodes; 
            this.do_expand(Elems);
            if(this.CurrentExpandState >= 6)
                this.CurrentExpandState = 6;
            else
                this.CurrentExpandState++;
        }

        private void PDbutton_collaps_all_Click(object sender, System.EventArgs e)
        {
            TreeNodeCollection Elems = this.treeElements.Nodes;
            int cntElems = Elems.Count;
            for(int i=0;i<cntElems;i++)
            {
                Elems[i].Collapse();        //CDNM: CollapseAll();
            }
            this.CurrentExpandState = 0;
        }

        private void PDbutton_expand_all_Click(object sender, System.EventArgs e)
        {
            TreeNodeCollection Elems = this.treeElements.Nodes;
            int cntElems = Elems.Count;
            for(int i=0;i<cntElems;i++)
            {
                Elems[i].ExpandAll();
            }
            this.CurrentExpandState = 6;
        }

        private void PDbutton_collaps_Click(object sender, System.EventArgs e)
        {
            this.max_exp_level = 0;
            TreeNodeCollection Elems = this.treeElements.Nodes;
            int cntElems = Elems.Count;
            for(int i=0;i<cntElems;i++)
            {
                if (Elems[i].IsExpanded)
                {
                    this.prepare_collaps(Elems[i].Nodes, 2);
                }
            }
            for(int i=0;i<cntElems;i++)
            {
                if (Elems[i].IsExpanded)
                {
                    this.do_collaps(Elems[i].Nodes, 2);
                }
            }
            if(this.CurrentExpandState <= 0)
                this.CurrentExpandState = 0;
            else
                this.CurrentExpandState--;
        }


        private void btnExp1_Click(object sender, System.EventArgs e)
        {
            this.PDbutton_collaps_all_Click(sender, e);
        }

        private void btnExp2_Click(object sender, System.EventArgs e)
        {
            this.PDbutton_collaps_all_Click(sender, e);
            this.prepare_special_selection(1);
            this.CurrentExpandState = 1;
        }

        private void btnExp3_Click(object sender, System.EventArgs e)
        {
            this.PDbutton_collaps_all_Click(sender, e);
            this.prepare_special_selection(2);
            this.CurrentExpandState = 2;
        }

        private void btnExp4_Click(object sender, System.EventArgs e)
        {
            this.PDbutton_collaps_all_Click(sender, e);
            this.prepare_special_selection(3);
            this.CurrentExpandState = 3;
        }

        private void btnExp5_Click(object sender, System.EventArgs e)
        {
            this.PDbutton_collaps_all_Click(sender, e);
            this.prepare_special_selection(4);
            this.CurrentExpandState = 4;
        }

        private void btnExp6_Click(object sender, System.EventArgs e)
        {
            this.PDbutton_collaps_all_Click(sender, e);
            this.prepare_special_selection(5);
            this.CurrentExpandState = 5;
        }

        private void btnExp7_Click(object sender, System.EventArgs e)
        {
            this.PDbutton_collaps_all_Click(sender, e);
            this.prepare_special_selection(6);
            this.CurrentExpandState = 6;
        }

        private void btnExp8_Click(object sender, System.EventArgs e)
        {
            this.PDbutton_collaps_all_Click(sender, e);
            this.prepare_special_selection(7);
            this.CurrentExpandState = 7;
        }

        private void prepare_special_selection(int expected_level)
        {
            try
            {
                this.do_special_selection(this.treeElements.Nodes, 1, expected_level, this.treeElements.Nodes);
            }
            catch(Exception e)
            {
                ErrorHandler.DisplayError("Error special Selection", e);
            }
        }

        private void do_special_selection(TreeNodeCollection nodes, int level, int expected_level, TreeNodeCollection orig)
        {
            int cntElems = nodes.Count;
            for(int i=0;i<cntElems;i++)
            {
                if (level <= expected_level)
                {
                    nodes[i].Expand();
                }

                if (level < expected_level)
                {
                    if (nodes[i].Nodes.Count > 0)
                    {
                        this.do_special_selection(nodes[i].Nodes, level + 1, expected_level, orig);
                    }
                }
            }
        }


        #endregion      


        #region Advanced Control Checkboxes

        #region Helpers

        private void HandleUMControlsHelper(ToolStripItem menuitem, bool enabled)
        {
            if (enabled)
            {
                if (!this.elemCmdMenu.Items.Contains(menuitem))
                {
                    this.elemCmdMenu.Items.Add(menuitem);
                }
            }
            else
            {
                if (this.elemCmdMenu.Items.Contains(menuitem))
                {
                    this.elemCmdMenu.Items.Remove(menuitem);
                }
            }
        }

        private void HandleUMControls(bool enabled)
        {
            HandleUMControlsHelper(this.cmdEdit, enabled);
            HandleUMControlsHelper(this.separator2, enabled);
            HandleUMControlsHelper(this.cmdNumeric, enabled);
            HandleUMControlsHelper(this.cmdString, enabled);

            HandleUMControlsHelper(this.cmdEdit, enabled);
            HandleUMControlsHelper(this.cmdEdit, enabled);
            HandleUMControlsHelper(this.cmdEdit, enabled);

            this.btnElementEdit.Visible = enabled;
            this.ActivateCubeBtn = enabled;
            this.SetCubeBtnState();

            this.lblConsolidatedElements.Visible = enabled && !this.chkTree.Checked;
            this.treeSourceElements.Visible = enabled;
            this.cmbElementType.Visible = this.lblConsolidatedElements.Visible && (this.CubeViewStatus != GeneralConst.SYSTEM_CUBE_VIEW);

            EnableStatusBtns();

            this.comboConnList.Enabled = enabled;

        }

        private void DisableUMControls()
        {
            HandleUMControls(false);
        }

        private void EnableUMControls()
        {
            HandleUMControls(true);
        }
        #endregion

        private void btnToggleSystemCubes_Click(object sender, EventArgs e)
        {
            this.ShowSystemCubes = !this.ShowSystemCubes;

            this.btnToggleSystemCubes.FlatAppearance.BorderColor = (this.ShowSystemCubes) ? System.Drawing.SystemColors.GradientActiveCaption : System.Drawing.SystemColors.ControlDark;

            if (this.comboConnList.SelectedIndex > -1)
            {
                this.RefreshCubes();
            }
        }

        private void btnUserManagment_Click(object sender, EventArgs e)
        {
            this.chkTree.Checked = false;
            this.btnEnableTree.Visible = false;
            this.EditUsersState = true;
            this.btnToggleSystemCubes.Visible = false;
            this.CubeViewStatus = GeneralConst.SYSTEM_CUBE_VIEW;

            if (this.comboConnList.SelectedIndex > -1)
            {
                this.oldactivedb = this.currDb;
                this.refreshCombo();
                this.comboConnList.SetItem(this.currHostname, GeneralConst.SYSTEM_DB_NAME);
            }

            this.DisableUMControls();
        }

        private void HandleDataAttributeClick(bool is_data)
        {
            if (this.EditUsersState)
            {
                RegUtils.ActiveDB = this.oldactivedb;
            }

            this.btnToggleSystemCubes.Visible = is_data;
            this.btnEnableTree.Visible = true;
            this.EditUsersState = false;
            this.CubeViewStatus = (is_data) ? GeneralConst.NORMAL_CUBE_VIEW : GeneralConst.ATTRIBUTE_CUBE_VIEW; 
            this.refreshCombo();
            this.EnableUMControls();
        }

        private void btnDataManagment_Click(object sender, EventArgs e)
        {
            HandleDataAttributeClick(true);
        }

        private void btnAttributeManagment_Click(object sender, EventArgs e)
        {
            HandleDataAttributeClick(false);
        }

        private void btnOrigDims_Click(object sender, EventArgs e)
        {
            this.btnOrigDims.Enabled = false;
            this.btnAscDims.Enabled = true;
            this.btnDescDims.Enabled = true;

            this.btnOrigDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAscDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnDescDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;

            if (String.IsNullOrEmpty(this.currDb))
            {
                return;
            }

            // Get original data.
            this.pumpDbData();
        }

        private void btnAscDims_Click(object sender, EventArgs e)
        {
            this.btnOrigDims.Enabled = true;
            this.btnAscDims.Enabled = false;
            this.btnDescDims.Enabled = true;

            this.btnOrigDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnAscDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDescDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;

            this.sortDims(false);
        }

        private void btnDescDims_Click(object sender, EventArgs e)
        {
            this.btnOrigDims.Enabled = true;
            this.btnAscDims.Enabled = true;
            this.btnDescDims.Enabled = false;

            this.btnOrigDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnAscDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnDescDims.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;

            this.sortDims(true);
        }

        private void sortDims(bool reverse)
        {
            if (String.IsNullOrEmpty(this.currDb))
            {
                return;
            }

            int maxitem = this.treeViewDims.Nodes.Count;
            string[] sDims = new string[maxitem];
            string selectedDim = "", Attributedim;
            for (int i = 0; i < maxitem; i++)
            {
                sDims[i] = (string)this.treeViewDims.Nodes[i].Text;
                if (this.treeViewDims.SelectedNode == this.treeViewDims.Nodes[i])
                {
                    selectedDim = sDims[i];
                }
            }
            Array.Sort(sDims);
            if(reverse)
            {
                Array.Reverse(sDims);
            }
            this.treeViewDims.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.treeViewDims.BeginUpdate();
            this.treeViewDims.Nodes.Clear();
            this.clearItems();
            for (int i = maxitem; i > 0; i--)
            {
                this.tabMain.TabPages.RemoveAt(i);
            }

            for (int i = 0; i < maxitem; i++)
            {
                this.treeViewDims.Nodes.Add(sDims[i]);
                if (!this.EditUsersState)
                {
                    Attributedim = this.currConn.GetAttributeDimension(this.currDb, sDims[i]);
                }
                else
                {
                    Attributedim = "";
                }
                JTabPage tmpTab = new JTabPage(sDims[i]);
                tmpTab.Title = tmpTab.Title.Replace("&", "&&");
                tmpTab.Tag = new TabTagObject(sDims[i], Attributedim);
                this.tabMain.TabPages.Add(tmpTab);
                ToolStripMenuItem cmdTabDim = new ToolStripMenuItem();
                cmdTabDim.Text = sDims[i];
                cmdTabDim.Click += new System.EventHandler(this.cmdTabDim_Click);
                cmdTabDim.Checked = false;
                this.tabCmdMenu.Items.Add(cmdTabDim);

                if (String.Equals(sDims[i], selectedDim))
                {
                    TreeNode t = this.treeViewDims.Nodes[i];
                    try
                    {
                        this.treeViewDims.SelectedNode = t; // Doesn't work!
                    }
                    catch
                    {}
                }
            }
            this.treeViewDims.EndUpdate();
            this.tabMain.ResumeLayout();
            this.treeViewDims.ResumeLayout();
        }

        private void btnOrigElems_Click(object sender, System.EventArgs e)
        {
            this.btnOrigElems.Enabled = false;
            this.btnAscElems.Enabled = true;
            this.btnDescElems.Enabled = true;
            this.btnUp.Enabled = true;
            this.btnDown.Enabled = true;
            this.cmdElementMoveBegin.Enabled = true;
            this.cmdElementMoveEnd.Enabled = true;

            this.btnOrigElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAscElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnDescElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            
            // JMM 03-20-14
            string[] selectedElems = treeElements.GetSelectedNodeLabels();
            #if NOTUSED
            int maxitem = this.treeElements.Nodes.Count;
            string selectedElem = "";
            for (int i = 0; i < maxitem; i++)
            {
                if (this.treeElements.Nodes[i].IsSelected)
                {
                    selectedElem = this.treeElements.Nodes[i].Text;
                }
            }
            #endif

            this.doElementTypeSelectedIndexChanged0();

            for (int i = 0; i < treeElements.Nodes.Count; i++)
            {
                if (Array.IndexOf(selectedElems, treeElements.Nodes[i].Text) >= 0)
                    treeElements.SelectNode(treeElements.Nodes[i]);
                    
                #if NOTUSED
                if (String.Equals(this.treeElements.Nodes[i].Text, selectedElem))
                {
                    JNode t = this.treeElements.Nodes[i];
                    //CDNM: t.Select();
                    try
                    {
                        this.treeElements.SelectedNode = t;
                    }
                    catch
                    { }
                }
                #endif
            }
        }

        private void btnAscElems_Click(object sender, System.EventArgs e)
        {
            this.btnOrigElems.Enabled = true;
            this.btnAscElems.Enabled = false;
            this.btnDescElems.Enabled = true;
            this.btnUp.Enabled = false;
            this.btnDown.Enabled = false;
            this.cmdElementMoveBegin.Enabled = false;
            this.cmdElementMoveEnd.Enabled = false;

            this.btnOrigElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnAscElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDescElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;

            this.sortElems(false);
        }

        private void btnDescElems_Click(object sender, System.EventArgs e)
        {
            this.btnOrigElems.Enabled = true;
            this.btnAscElems.Enabled = true;
            this.btnDescElems.Enabled = false;
            this.btnUp.Enabled = false;
            this.btnDown.Enabled = false;
            this.cmdElementMoveBegin.Enabled = false;
            this.cmdElementMoveEnd.Enabled = false;

            this.btnOrigElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnAscElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnDescElems.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;

            this.sortElems(true);
        }

        private void sortElems(bool reverse)
        {
            int maxitem = this.treeElements.Nodes.Count;
            JNode[] elems = new JNode[maxitem];

            // JMM 03-20-14
            string[] selectedElems = treeElements.GetSelectedNodeLabels();            
            //string selectedElem = "";
            for (int i = 0; i < maxitem; i++)
            {
                elems[i] = (JNode)this.treeElements.Nodes[i];
                #if NOTUSED
                if (this.treeElements.Nodes[i].IsSelected)
                {
                    selectedElem = elems[i].Text;
                }
                #endif
            }
            

            Array.Sort(elems, CompareNodes);
            if (reverse)            
                Array.Reverse(elems);
            
            this.treeElements.SuspendLayout();
            this.treeElements.ClearNodes();

            for (int i = 0; i < maxitem; i++)
            {
                int pos = this.treeElements.Nodes.Add(elems[i]);

                if (Array.IndexOf(selectedElems, elems[i]) >= 0)
                    treeElements.SelectNode(treeElements.Nodes[pos]);
                #if NOTUSED
                if (String.Equals(elems[i].Text, selectedElem))
                {
                    JNode t = this.treeElements.Nodes[i];
                    //CDNM: t.Select();
                    try
                    {
                        this.treeElements.SelectedNode = t;
                    }
                    catch
                    { }
                }
                #endif
            }
            this.treeElements.ResumeLayout();
        }

        private void MakeElementSortButtonVisible(bool isvisible)
        {
            this.btnAscElems.Visible = isvisible;
            this.btnDescElems.Visible = isvisible;
            this.btnOrigElems.Visible = isvisible;
        }

        private static int CompareNodes(JNode n1, JNode n2)
        {
            return String.Compare(n1.Text, n2.Text);
        }

        #endregion

        #region SearchElements

        static bool check_reg_exp(string text, string test)
        {
            bool ret = false;

            bool first = (test[0] == '*');
            bool last = (test[test.Length - 1] == '*');

            int first2 = (first) ? 1 : 0;
            int last2 = (last) ? test.Length - 1 : test.Length;
            int count = last2 - first2;

            string test2 = test.Substring(first2, (count < 0) ? 0 : count);

            if (!first)
            {
                if (!last)
                {
                    ret = text.Equals(test);
                }
                else
                {
                    ret = text.StartsWith(test2);
                }
            }
            else
            {
                if (!last)
                {
                    ret = text.EndsWith(test2);
                }
                else
                {
                    string text2 = text;
                    int length = test2.Length;

                    while (!ret && (text2.Length >= length))
                    {
                        ret = text2.StartsWith(test2);
                        text2 = text2.Substring(1);
                    }
                }
            }

            return ret;
        }       

        private void cmdSearchElements_Click(object sender, EventArgs e)
        {
            if (this.treeElements.Nodes.Count <= 1)
            {
                return;
            }

            SearchElement se = new SearchElement();
            if (se.ShowDialog() == DialogResult.OK)
            {
                string test = se.GetSearchValue;
                RegUtils.SearchElement = test;
                string test2 = test.ToUpper();
                if (test2.Length > 0)
                {
                    TreeNodeCollection Elems = this.treeElements.Nodes;
                    JNode Element;
                    bool found = false;

                    for (int i = 0; i < Elems.Count; i++)
                    {
                        Element = (JNode)Elems[i];

                        if (check_reg_exp(Element.Text.ToUpper(), test2))
                        {
                            this.treeElements.DeselectAll();
                            //CDNM: Element.Select();
                            this.treeElements.SelectNode(Element);
                            Element.EnsureVisible();
                            found = true;
                            break;
                        }
                    }

                    if ((!found) && !test2.EndsWith("*"))
                    {
                        for (int i = 0; i < Elems.Count; i++)
                        {
                            Element = (JNode)Elems[i];

                            if (check_reg_exp(Element.Text.ToUpper(), test2 + "*"))
                            {
                                this.treeElements.DeselectAll();
                                //CDNM: Element.Select();
                                this.treeElements.SelectNode(Element);
                                Element.EnsureVisible();
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        string mess = Apalo.XlAddin.Utils.ResourceInitializer.Replace(Apalo.XlAddin.Utils.ResourceInitializer.TEXT_DIMELEMENT_NOT_FOUND, new object[] { test, this.currDimension });
                        System.Windows.Forms.MessageBox.Show(mess);
                    }
                }
            }
        }
  
        #endregion   

        #region Cube Rename
        private void cmdCubeRename_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(currDb))
            {
                try
                {
                    currCube = this.treeViewCubes.SelectedNode.Text;
                }
                catch
                { }

                this.treeViewCubes.LabelEdit = true;
                this.treeViewCubes.SelectedNode.NodeFont = this.regularFont;
                this.treeViewCubes.SelectedNode.BeginEdit();
            }
        }
                    
        private void treeViewCubes_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (currCube != null && currCube.Length > 0 && e.Label != null && e.Label != currCube && e.Label.Length > 0)
            {
                try
                {
                    this.currConn.DatabaseRenameCube(currDb, currCube, e.Label);
                    this.currConn.Ping();
                    Connect.changesMade = true;
                    this.treeViewCubes.LabelEdit = false;
                }
                catch
                { }
            }
        }
        #endregion
  
    }
}
