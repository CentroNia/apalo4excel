using System.Runtime.InteropServices;
using System.Windows.Forms;
using CDNM = Crownwood.DotNetMagic;
﻿namespace Jedox.Palo.XlAddin.Forms
	{
	partial class PaloDesigner
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaloDesigner));
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
			this.treeViewDims = new Jedox.Palo.XlAddin.Forms.Controls.TreeViewNoBeep();
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
			this.chkFactor = new System.Windows.Forms.CheckBox();
			this.chkTree = new System.Windows.Forms.CheckBox();
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
			this.cmdDimExport = new System.Windows.Forms.ToolStripMenuItem();
			this.commandBarSeparatorItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdDimInfo = new System.Windows.Forms.ToolStripMenuItem();
			this.commandBarSeparatorItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.commandBarSeparatorItem9 = new System.Windows.Forms.ToolStripSeparator();
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
			this.commandBarSeparatorItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdCubeConvert = new System.Windows.Forms.ToolStripMenuItem();
			this.commandBarSeparatorItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdRuleEditor = new System.Windows.Forms.ToolStripMenuItem();
			this.cmdCubeInfo = new System.Windows.Forms.ToolStripMenuItem();
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
			this.lblConsolidatedElements = new System.Windows.Forms.Label();
			this.lblElements = new System.Windows.Forms.Label();
			this.treeElements = new Crownwood.DotNetMagic.Controls.TreeControl();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.btnLeft = new Jedox.Controls.JButton();
			this.btnRight = new Jedox.Controls.JButton();
			this.btnUp = new Jedox.Controls.JButton();
			this.btnDown = new Jedox.Controls.JButton();
			this.btnElementAdd = new Jedox.Controls.JButton();
			this.btnElementRemove = new Jedox.Controls.JButton();
			this.btnElementRename = new Jedox.Controls.JButton();
			this.btnElementEdit = new Jedox.Controls.JButton();
			this.btnElementCancelChanges = new Jedox.Controls.JButton();
			this.btnElementApplyChanges = new Jedox.Controls.JButton();
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
			this.tabMain.BackDark = System.Drawing.Color.Empty;
			this.tabMain.BackDarkDark = System.Drawing.Color.Empty;
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
			this.tabMain.TabPages.Add(this.tabSettings);
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
			this.btnHome.UseVisualStyleBackColor = true;
			this.btnHome.FlatStyle = FlatStyle.Flat;
			this.btnHome.FlatAppearance.BorderColor = this.btnClose.FlatAppearance.BorderColor;
			this.btnHome.TabIndex = 999;
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
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
			this.cmdAddN.Click += new System.EventHandler(this.cmdAddN_Click);
			//
			// cmdDel
			//
			this.cmdDel.Name = "cmdDel";
			resources.ApplyResources(this.cmdDel, "cmdDel");
			this.cmdDel.Click += new System.EventHandler(this.btnElementRemove_Click);
			//
			// cmdRen
			//
			this.cmdRen.Name = "cmdRen";
			resources.ApplyResources(this.cmdRen, "cmdRen");
			this.cmdRen.Click += new System.EventHandler(this.btnElementRename_Click);
			//
			// cmdEdit
			//
			this.cmdEdit.Name = "cmdEdit";
			resources.ApplyResources(this.cmdEdit, "cmdEdit");
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
			this.cmdNumeric.Click += new System.EventHandler(this.cmdNumeric_Click);
			//
			// cmdString
			//
			this.cmdString.Name = "cmdString";
			resources.ApplyResources(this.cmdString, "cmdString");
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
			this.cmdElemCopy.Click += new System.EventHandler(this.cmdElemCopy_Click);
			//
			// cmdElemPaste
			//
			resources.ApplyResources(this.cmdElemPaste, "cmdElemPaste");
			this.cmdElemPaste.Name = "cmdElemPaste";
			this.cmdElemPaste.Click += new System.EventHandler(this.cmdElemPaste_Click);
			//
			// cmdElemSelectAll
			//
			this.cmdElemSelectAll.Name = "cmdElemSelectAll";
			resources.ApplyResources(this.cmdElemSelectAll, "cmdElemSelectAll");
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
			this.cmdElementMoveBegin.Click += new System.EventHandler(this.cmdElementMoveBegin_Click);
			//
			// cmdElementMoveEnd
			//
			this.cmdElementMoveEnd.Name = "cmdElementMoveEnd";
			resources.ApplyResources(this.cmdElementMoveEnd, "cmdElementMoveEnd");
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
			this.cmdCountElements.Click += new System.EventHandler(this.cmdCountElements_Click);
			//
			// cmdSearchElements
			//
			this.cmdSearchElements.Name = "cmdSearchElements";
			resources.ApplyResources(this.cmdSearchElements, "cmdSearchElements");
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
			this.cmdFactor.Click += new System.EventHandler(this.cmdFactor_Click);
			//
			// cmdDelSrcElem
			//
			this.cmdDelSrcElem.Name = "cmdDelSrcElem";
			resources.ApplyResources(this.cmdDelSrcElem, "cmdDelSrcElem");
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
			this.cmdSrcElementMoveBegin.Click += new System.EventHandler(this.cmdSrcElementMoveBegin_Click);
			//
			// cmdSrcElementMoveEnd
			//
			this.cmdSrcElementMoveEnd.Name = "cmdSrcElementMoveEnd";
			resources.ApplyResources(this.cmdSrcElementMoveEnd, "cmdSrcElementMoveEnd");
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
			this.cmdNewDim.Click += new System.EventHandler(this.btnDimensionAdd_Click);
			//
			// cmdDelDim
			//
			this.cmdDelDim.Name = "cmdDelDim";
			resources.ApplyResources(this.cmdDelDim, "cmdDelDim");
			this.cmdDelDim.Click += new System.EventHandler(this.btnDimensionRemove_Click);
			//
			// cmdRenDim
			//
			this.cmdRenDim.Name = "cmdRenDim";
			resources.ApplyResources(this.cmdRenDim, "cmdRenDim");
			this.cmdRenDim.Click += new System.EventHandler(this.btnDimensionRename_Click);
			//
			// cmdEditDim
			//
			this.cmdEditDim.Name = "cmdEditDim";
			resources.ApplyResources(this.cmdEditDim, "cmdEditDim");
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
			this.cmdDimInfo.Click += new System.EventHandler(this.cmdDimInfo_Click);
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
			// cmdSubSetEditor
			//
			this.cmdSubSetEditor.Name = "cmdSubSetEditor";
			resources.ApplyResources(this.cmdSubSetEditor, "cmdSubSetEditor");
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
			this.cmdAddCube.Click += new System.EventHandler(this.btnCubeAdd_Click);
			//
			// cmdDelCube
			//
			this.cmdDelCube.Name = "cmdDelCube";
			resources.ApplyResources(this.cmdDelCube, "cmdDelCube");
			this.cmdDelCube.Click += new System.EventHandler(this.btnCubeRemove_Click);
			//
			// cmdCubeRename
			//
			this.cmdCubeRename.Name = "cmdCubeRename";
			resources.ApplyResources(this.cmdCubeRename, "cmdCubeRename");
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
			this.cmdClearCube.Click += new System.EventHandler(this.cmdClearCube_Click);
			//
			// cmdExportCube
			//
			this.cmdExportCube.Name = "cmdExportCube";
			resources.ApplyResources(this.cmdExportCube, "cmdExportCube");
			this.cmdExportCube.Click += new System.EventHandler(this.cmdExportCube_Click);
			//
			// cmdSVSWizard
			//
			this.cmdSVSWizard.Name = "cmdSVSWizard";
			resources.ApplyResources(this.cmdSVSWizard, "cmdSVSWizard");
			this.cmdSVSWizard.Click += new System.EventHandler(this.cmdSVSWizard_Click);
			//
			// commandBarSeparatorItem2
			//
			this.commandBarSeparatorItem2.Name = "commandBarSeparatorItem2";
			resources.ApplyResources(this.commandBarSeparatorItem2, "commandBarSeparatorItem2");
			//
			// cmdCubeConvert
			//
			this.cmdCubeConvert.Name = "cmdCubeConvert";
			resources.ApplyResources(this.cmdCubeConvert, "cmdCubeConvert");
			this.cmdCubeConvert.Click += new System.EventHandler(this.cmdCubeConvert_Click);
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
			this.cmdRuleEditor.Click += new System.EventHandler(this.cmdRuleEditor_Click);
			//
			// cmdCubeInfo
			//
			this.cmdCubeInfo.Name = "cmdCubeInfo";
			resources.ApplyResources(this.cmdCubeInfo, "cmdCubeInfo");
			this.cmdCubeInfo.Click += new System.EventHandler(this.cmdCubeInfo_Click);
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
			this.cmdChild.Click += new System.EventHandler(this.cmdChild_Click);
			//
			// cmdSibling
			//
			this.cmdSibling.Name = "cmdSibling";
			resources.ApplyResources(this.cmdSibling, "cmdSibling");
			this.cmdSibling.Click += new System.EventHandler(this.cmdSibling_Click);
			//
			// ChildSiblingCopy
			//
			this.ChildSiblingCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cmdChildCopy,
			this.cmdSiblingCopy});
			this.ChildSiblingCopy.Name = "ChildSiblingCopy";
			resources.ApplyResources(this.ChildSiblingCopy, "ChildSiblingCopy");
			this.ChildSiblingCopy.Opening += new System.ComponentModel.CancelEventHandler(this.ChildSiblingCopy_Opening);
			//
			// cmdChildCopy
			//
			this.cmdChildCopy.Name = "cmdChildCopy";
			resources.ApplyResources(this.cmdChildCopy, "cmdChildCopy");
			this.cmdChildCopy.Click += new System.EventHandler(this.cmdChildCopy_Click);
			//
			// cmdSiblingCopy
			//
			this.cmdSiblingCopy.Name = "cmdSiblingCopy";
			resources.ApplyResources(this.cmdSiblingCopy, "cmdSiblingCopy");
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
			this.cmdRemoveSubset.Click += new System.EventHandler(this.cmdRemoveSubset_Click);
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
			this.treeElements.SelectMode = Crownwood.DotNetMagic.Controls.SelectMode.Multiple;
			this.treeElements.ImageIndex = -1;
			this.treeElements.BorderStyle = Crownwood.DotNetMagic.Controls.TreeBorderStyle.Solid;
			this.treeElements.DoubleClickExpand = Crownwood.DotNetMagic.Controls.ClickExpandAction.Toggle;
			this.treeElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.treeElements.Top = this.treeViewDims.Top - 20;
			this.treeElements.Left= this.treeViewDims.Left;
			this.treeElements.Name = "treeElements";
			this.treeElements.SelectedImageIndex = 3;
			this.treeElements.Size = this.treeViewDims.Size;
			this.treeElements.TabIndex = 220;
			this.treeElements.ImageList = this.imgListElements;
			this.treeElements.AfterLabelEdit += new Crownwood.DotNetMagic.Controls.LabelEditEventHandler(this.treeElements_AfterLabelEdit);
			this.treeElements.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeElements_MouseUp);
			this.treeElements.DoubleClick += new System.EventHandler(this.treeElements_DoubleClick);
			this.treeElements.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeElements_KeyDown);
			this.treeElements.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeElements_KeyUp);
			this.treeElements.AutoEdit = false;
			this.treeElements.FocusNode = null;
			this.treeElements.LineVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.OnlyBelowRoot;
			this.treeElements.CheckStates = Crownwood.DotNetMagic.Controls.CheckStates.None;
			this.treeElements.ImageGapLeft = 1;
			this.treeElements.ImageGapRight = 1;
			this.treeElements.BoxVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.Nowhere;
			this.treeElements.NodesSelectable = true;
			this.treeElements.InstantUpdate = false;
			this.treeElements.LabelEdit = false;
			this.treeElements.SelectedNode = null;
			this.treeElements.AllowDrop = true;
			//
			this.columnHeader1.Width = this.treeSourceElements.Width;
			this.columnHeader1.Text = ResourceInitializer.LABEL_HEADER_NAME;
			this.columnHeader2.Width = 0;
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Text = ResourceInitializer.LABEL_HEADER_FACTOR;
			//
			// treeSourceElements
			//
			this.treeSourceElements = new ListView();
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
			//
			// PaloDesigner
			//
			this.AllowDrop = true;
			resources.ApplyResources(this, "$this");
			this.CancelButton = this.btnClose;
			this.Controls.Add(this.tabMain);
			this.KeyPreview = true;
			this.Name = "PaloDesigner";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Load += new System.EventHandler(this.Modeller_Load);
			this.VisibleChanged += new System.EventHandler(this.Modeller_VisibleChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Modeller_KeyDown);
			this.Resize += new System.EventHandler(this._Resize);
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

		private Jedox.Controls.JButton btnConnAdd;
		private CDNM.Controls.TabPage tabSettings;
		private int OldPageindex;
		private Jedox.Controls.JButton btnConnToggle;
		private System.Windows.Forms.Button btnClose;
		private Jedox.Palo.XlAddin.Forms.Controls.TreeViewNoBeep treeViewDims;
		private TreeView treeViewCubes;
		private System.Windows.Forms.Label lblDimensions;
		private System.Windows.Forms.Label lblCubes;
		private CDNM.Controls.TabControl tabMain;
		private Jedox.Controls.JButton btnDimensionAdd;
		private Jedox.Controls.JButton btnDimensionRename;
		private Jedox.Controls.JButton btnDimensionRemove;

		private Jedox.Controls.JButton btnCubeAdd;
		private Jedox.Controls.JButton btnCubeRemove;
		private CDNM.Controls.TabPage cTab;

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

		#region Expand/Collapse
		private Jedox.Controls.JButton btnExpandAll;
		private Jedox.Controls.JButton btnCollapseAll;
		private Jedox.Controls.JButton btnCollapse;
		private Jedox.Controls.JButton btnExpand;
		private Jedox.Controls.JButton btnExp1;
		private Jedox.Controls.JButton btnExp2;
		private Jedox.Controls.JButton btnExp3;
		private Jedox.Controls.JButton btnExp4;
		private Jedox.Controls.JButton btnExp5;
		private Jedox.Controls.JButton btnExp6;
		private Jedox.Controls.JButton btnExp7;
		private Jedox.Controls.JButton btnExp8;
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

		private Jedox.Controls.JButton btnDataManagment;
		private Jedox.Controls.JButton btnAttributeManagment;
		private Jedox.Controls.JButton btnUserManagment;
		private Button btnOrigDims;
		private Button btnAscDims;
		private Button btnDescDims;
		private Button btnOrigElems;
		private Button btnAscElems;
		private Button btnDescElems;

		private ToolStripMenuItem cmdRuleEditor;

		private ToolStripMenuItem cmdCubeInfo;
		private ToolStripSeparator commandBarSeparatorItem2;
		private Jedox.Controls.JButton btnRuleEditor;
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
		private Jedox.Controls.JButton btnEnableTree;
		private ToolStripMenuItem cmdCubeConvert;
		private ImageList imgListElements;
		private Button btnToggleSystemCubes;

		private System.Windows.Forms.CheckBox chkFactor;
		private System.Windows.Forms.CheckBox chkTree;
		private System.Windows.Forms.Button btnHome;

		private System.Windows.Forms.Label lblConsolidatedElements;
		private System.Windows.Forms.Label lblElements;
		private Crownwood.DotNetMagic.Controls.TreeControl treeElements;
		private ListView treeSourceElements;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;

		private Jedox.Controls.JButton btnLeft;
		private Jedox.Controls.JButton btnRight;
		private Jedox.Controls.JButton btnUp;
		private Jedox.Controls.JButton btnDown;

		private Jedox.Controls.JButton btnElementAdd;
		private Jedox.Controls.JButton btnElementRemove;
		private Jedox.Controls.JButton btnElementRename;
		private Jedox.Controls.JButton btnElementEdit;

		private Jedox.Controls.JButton btnElementCancelChanges;
		private Jedox.Controls.JButton btnElementApplyChanges;

		#endregion


		}
	}
