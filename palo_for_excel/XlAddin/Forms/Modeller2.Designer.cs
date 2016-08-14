using CDNM = Crownwood.DotNetMagic;
using Jedox.Controls;
using Jedox.Palo.Comm;
using aPalo.XlAddin.Forms.Controls;
using aPalo.XlAddin.Utils;
using System.Windows.Forms;

namespace aPalo.XlAddin
    {
    partial class Modeller2
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modeller2));
            this.btnConnAdd = new Jedox.Controls.JButton();
            this.tabMain = new Crownwood.DotNetMagic.Controls.TabControl();
            this.tabSettings = new Crownwood.DotNetMagic.Controls.TabPage();
            this.btnToggleSystemCubes = new System.Windows.Forms.Button();
            this.btnRuleEditor = new Jedox.Controls.JButton();
            this.btnAttributeManagment = new Jedox.Controls.JButton();
            this.btnUserManagment = new Jedox.Controls.JButton();
            this.btnDataManagment = new Jedox.Controls.JButton();
            this.btnOrigDims = new System.Windows.Forms.Button();
            this.btnAscDims = new System.Windows.Forms.Button();
            this.btnDescDims = new System.Windows.Forms.Button();
            this.labelChooseServer = new System.Windows.Forms.Label();
            this.lblCubes = new System.Windows.Forms.Label();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.btnConnToggle = new Jedox.Controls.JButton();
            this.treeViewDims = new TreeViewNoBeep();
            this.treeViewCubes = new System.Windows.Forms.TreeView();
            this.btnDimensionAdd = new Jedox.Controls.JButton();
            this.btnDimensionRename = new Jedox.Controls.JButton();
            this.btnDimensionRemove = new Jedox.Controls.JButton();
            this.btnCubeAdd = new Jedox.Controls.JButton();
            this.btnCubeRemove = new Jedox.Controls.JButton();
            this.btnOrigElems = new System.Windows.Forms.Button();
            this.btnAscElems = new System.Windows.Forms.Button();
            this.btnDescElems = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.cmbElementType = new Jedox.Controls.JComboBox();
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
            this.btnExpandAll = new Jedox.Controls.JButton();
            this.btnCollapseAll = new Jedox.Controls.JButton();
            this.btnExpand = new Jedox.Controls.JButton();
            this.btnCollapse = new Jedox.Controls.JButton();
            this.btnExp1 = new Jedox.Controls.JButton();
            this.btnExp2 = new Jedox.Controls.JButton();
            this.btnExp3 = new Jedox.Controls.JButton();
            this.btnExp4 = new Jedox.Controls.JButton();
            this.btnExp5 = new Jedox.Controls.JButton();
            this.btnExp6 = new Jedox.Controls.JButton();
            this.btnExp7 = new Jedox.Controls.JButton();
            this.btnExp8 = new Jedox.Controls.JButton();
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
            this.btnEnableTree = new Jedox.Controls.JButton();
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
            this.tabMain.AllowDragReorder = false;
            this.tabMain.AllowDrop = false;
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.IDE2005HeaderBorder = true;
            this.tabMain.IDE2005PixelBorder = false;
            this.tabMain.IDE2005Style = Crownwood.DotNetMagic.Controls.IDE2005Style.StandardDark;
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.OfficeDockSides = false;
            this.tabMain.OfficeStyle = Crownwood.DotNetMagic.Controls.OfficeStyle.Light;
            this.tabMain.PositionTop = true;
            this.tabMain.SelectedIndex = 0;
            this.tabMain.ShowDropSelect = false;
            this.tabMain.ShrinkPagesToFit = false;
            this.tabMain.Style = Crownwood.DotNetMagic.Common.VisualStyle.IDE2005;
            this.tabMain.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
            this.tabSettings});
            this.tabMain.TextTips = true;
            this.tabMain.SelectionChanged += new Crownwood.DotNetMagic.Controls.SelectTabHandler(this.tabMain_SelectionChanged);
            this.tabMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabMain_MouseUp);
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
            this.tabSettings.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabSettings.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabSettings.InactiveTextColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectBackColor = System.Drawing.Color.Empty;
            this.tabSettings.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabSettings.SelectTextColor = System.Drawing.Color.Empty;
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
            this.cmdAddSubset.Click += new System.EventHandler(this.cmdAddSubset_Click);
            // 
            // cmdRemoveSubset
            // 
            this.cmdRemoveSubset.Name = "cmdRemoveSubset";
            resources.ApplyResources(this.cmdRemoveSubset, "cmdRemoveSubset");
            this.cmdRemoveSubset.Click += new System.EventHandler(cmdRemoveSubset_Click);
            // 
            // cmdEditSubset
            // 
            this.cmdEditSubset.Name = "cmdEditSubset";
            resources.ApplyResources(this.cmdEditSubset, "cmdEditSubset");
            this.cmdEditSubset.Click += new System.EventHandler(this.cmdEditSubset_Click);
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

        #endregion


        private JButton btnConnAdd;
        private CDNM.Controls.TabPage tabSettings;
        private int OldPageindex;
        private JButton btnConnToggle;         
        private System.Windows.Forms.Button btnClose;
        private TreeViewNoBeep treeViewDims;
        private TreeView treeViewCubes;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.Label lblCubes;
        private CDNM.Controls.TabControl tabMain;
        private JButton btnDimensionAdd;
        private JButton btnDimensionRename;
        private JButton btnDimensionRemove;

        private JButton btnCubeAdd;
        private JButton btnCubeRemove;
        private CDNM.Controls.TabPage cTab;

      
        #region Edit DataAxis Elements
        private System.Windows.Forms.Label lblConsolidatedElements = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label lblElements = new System.Windows.Forms.Label();
        private Crownwood.DotNetMagic.Controls.TreeControl treeElements = new Crownwood.DotNetMagic.Controls.TreeControl();
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
        private Jedox.Controls.JComboBox cmbElementType;
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

        }
    }
