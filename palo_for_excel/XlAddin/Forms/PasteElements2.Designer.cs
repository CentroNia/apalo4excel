using System.Windows.Forms;
using JControls;

namespace Apalo.XlAddin.Forms
	{
	partial class PasteElements2
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
			if (disposing)
				{
				if (components != null)
					components.Dispose();
				this.release_resource();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasteElements2));
            this.PDlabel_choose_server = new System.Windows.Forms.Label();
            this.PDdbelements = new System.Windows.Forms.CheckBox();
            this.PDTabPages = new Apalo.XlAddin.JTabControl();
            this.PDPageDimElements = new Apalo.XlAddin.JTabPage();
            this.PDpanel_right = new System.Windows.Forms.Panel();
            this.PDbutton_revers_sort = new System.Windows.Forms.Button();
            this.PDbutton_sort = new System.Windows.Forms.Button();
            this.PDbutton_clear = new System.Windows.Forms.Button();
            this.PDpanel_bottom_right = new System.Windows.Forms.Panel();
            this.PDbutton_distinct = new System.Windows.Forms.Button();
            this.PDadvancedpanel = new System.Windows.Forms.Panel();
            this.PDbutton_1 = new System.Windows.Forms.Button();
            this.PDbutton_2 = new System.Windows.Forms.Button();
            this.PDbutton_3 = new System.Windows.Forms.Button();
            this.PDbutton_4 = new System.Windows.Forms.Button();
            this.PDbutton_5 = new System.Windows.Forms.Button();
            this.PDbutton_B = new System.Windows.Forms.Button();
            this.PDbutton_horizontal = new System.Windows.Forms.Button();
            this.PDbutton_cancel = new System.Windows.Forms.Button();
            this.PDbutton_vertical = new System.Windows.Forms.Button();
            this.PDbutton_all = new System.Windows.Forms.Button();
            this.PDinput_search = new System.Windows.Forms.TextBox();
            this.PDlabel_tip = new System.Windows.Forms.Label();
            this.PDbutton_branch = new System.Windows.Forms.Button();
            this.PDbutton_invert = new System.Windows.Forms.Button();
            this.PDbutton_search = new System.Windows.Forms.Button();
            this.PDlabel_picklist = new System.Windows.Forms.Label();
            this.PDselected_items = new System.Windows.Forms.ListBox();
            this.PDpanel_left = new System.Windows.Forms.Panel();
            this.PDbutton_definition_order = new JControls.JButton();
            this.PDbutton_expand_all = new JControls.JButton();
            this.PDbutton_collaps_all = new JControls.JButton();
            this.PDpanel_bottom_left = new System.Windows.Forms.Panel();
            this.PDbutton_down = new JControls.JButton();
            this.PDbutton_remove = new JControls.JButton();
            this.PDbutton_add = new JControls.JButton();
            this.PDbutton_up = new JControls.JButton();
            this.PDpanel_bottom_left2 = new System.Windows.Forms.Panel();
            this.PDaliasformats = new System.Windows.Forms.ComboBox();
            this.PDlabel_alias_format = new System.Windows.Forms.Label();
            this.PDlabel_alias = new System.Windows.Forms.Label();
            this.PDattributes = new System.Windows.Forms.ComboBox();
            this.PDdim_elements = new JControls.JTreeView();
            this.PDbutton_expand = new JControls.JButton();
            this.PDbutton_collaps = new JControls.JButton();
            this.PDPageDBElements = new Apalo.XlAddin.JTabPage();
            this.PDPanelMeta2 = new System.Windows.Forms.Panel();
            this.PDradio_dims = new System.Windows.Forms.RadioButton();
            this.PDradio_cube = new System.Windows.Forms.RadioButton();
            this.PDradio_con = new System.Windows.Forms.RadioButton();
            this.PDcube_dims = new System.Windows.Forms.ListBox();
            this.PDPanelMeta1 = new System.Windows.Forms.Panel();
            this.PDPanelMeta3 = new System.Windows.Forms.Panel();
            this.PDbutton_db_horizontal = new System.Windows.Forms.Button();
            this.PDbutton_meta_cancel = new System.Windows.Forms.Button();
            this.PDbutton_meta_horizontal = new System.Windows.Forms.Button();
            this.PDbutton_meta_vertical = new System.Windows.Forms.Button();
            this.PDbutton_db_cancel = new System.Windows.Forms.Button();
            this.PDbutton_db_vertical = new System.Windows.Forms.Button();
            this.PDbutton_data = new JControls.JButton();
            this.PDbutton_attr = new JControls.JButton();
            this.PDbutton_user = new JControls.JButton();
            this.PDCubes = new Apalo.XlAddin.Forms.Controls.CubeComboBox();
            this.PDadvanced = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PDTabPages.SuspendLayout();
            this.PDPageDimElements.SuspendLayout();
            this.PDpanel_right.SuspendLayout();
            this.PDpanel_bottom_right.SuspendLayout();
            this.PDadvancedpanel.SuspendLayout();
            this.PDpanel_left.SuspendLayout();
            this.PDpanel_bottom_left.SuspendLayout();
            this.PDpanel_bottom_left2.SuspendLayout();
            this.PDPageDBElements.SuspendLayout();
            this.PDPanelMeta2.SuspendLayout();
            this.PDPanelMeta1.SuspendLayout();
            this.PDPanelMeta3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PDlabel_choose_server
            // 
            this.PDlabel_choose_server.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.PDlabel_choose_server.Location = new System.Drawing.Point(8, 9);
            this.PDlabel_choose_server.Name = "PDlabel_choose_server";
            this.PDlabel_choose_server.Size = new System.Drawing.Size(750, 16);
            this.PDlabel_choose_server.TabIndex = 40;
            this.PDlabel_choose_server.Text = "Choose Server/database:";
            this.PDlabel_choose_server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PDlabel_choose_server.UseMnemonic = false;
            // 
            // PDdbelements
            // 
            this.PDdbelements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PDdbelements.BackColor = System.Drawing.Color.Transparent;
            this.PDdbelements.Location = new System.Drawing.Point(320, 28);
            this.PDdbelements.Name = "PDdbelements";
            this.PDdbelements.Size = new System.Drawing.Size(192, 20);
            this.PDdbelements.TabIndex = 41;
            this.PDdbelements.Text = "insert database elements";
            this.PDdbelements.UseVisualStyleBackColor = false;
            this.PDdbelements.CheckedChanged += new System.EventHandler(this.PDdbelements_CheckedChanged);
            // 
            // PDTabPages
            // 
            this.PDTabPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDTabPages.Controls.Add(this.PDPageDimElements);
            this.PDTabPages.Controls.Add(this.PDPageDBElements);
            this.PDTabPages.HideTabs = true;
            this.PDTabPages.Location = new System.Drawing.Point(0, 52);
            this.PDTabPages.Name = "PDTabPages";
            this.PDTabPages.SelectedIndex = 0;
            this.PDTabPages.Size = new System.Drawing.Size(765, 460);
            this.PDTabPages.TabIndex = 39;
            // 
            // PDPageDimElements
            // 
            this.PDPageDimElements.BackColor = System.Drawing.SystemColors.Control;
            this.PDPageDimElements.Controls.Add(this.PDpanel_right);
            this.PDPageDimElements.Controls.Add(this.PDpanel_left);
            this.PDPageDimElements.Location = new System.Drawing.Point(4, 22);
            this.PDPageDimElements.Name = "PDPageDimElements";
            this.PDPageDimElements.Padding = new System.Windows.Forms.Padding(3);
            this.PDPageDimElements.Selected = true;
            this.PDPageDimElements.Size = new System.Drawing.Size(757, 434);
            this.PDPageDimElements.TabIndex = 0;
            this.PDPageDimElements.Text = "dimensions elements";
            this.PDPageDimElements.Title = "dimensions elements";
            // 
            // PDpanel_right
            // 
            this.PDpanel_right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PDpanel_right.BackColor = System.Drawing.SystemColors.Control;
            this.PDpanel_right.Controls.Add(this.PDbutton_revers_sort);
            this.PDpanel_right.Controls.Add(this.PDbutton_sort);
            this.PDpanel_right.Controls.Add(this.PDbutton_clear);
            this.PDpanel_right.Controls.Add(this.PDpanel_bottom_right);
            this.PDpanel_right.Controls.Add(this.PDlabel_picklist);
            this.PDpanel_right.Controls.Add(this.PDselected_items);
            this.PDpanel_right.Location = new System.Drawing.Point(332, 0);
            this.PDpanel_right.Name = "PDpanel_right";
            this.PDpanel_right.Size = new System.Drawing.Size(426, 429);
            this.PDpanel_right.TabIndex = 40;
            // 
            // PDbutton_revers_sort
            // 
            this.PDbutton_revers_sort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PDbutton_revers_sort.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_revers_sort.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_revers_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_revers_sort.Location = new System.Drawing.Point(228, 5);
            this.PDbutton_revers_sort.Name = "PDbutton_revers_sort";
            this.PDbutton_revers_sort.Size = new System.Drawing.Size(90, 24);
            this.PDbutton_revers_sort.TabIndex = 39;
            this.PDbutton_revers_sort.Text = "Descending";
            this.PDbutton_revers_sort.UseVisualStyleBackColor = false;
            // 
            // PDbutton_sort
            // 
            this.PDbutton_sort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PDbutton_sort.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_sort.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_sort.Location = new System.Drawing.Point(130, 5);
            this.PDbutton_sort.Name = "PDbutton_sort";
            this.PDbutton_sort.Size = new System.Drawing.Size(90, 24);
            this.PDbutton_sort.TabIndex = 40;
            this.PDbutton_sort.Text = "Ascending";
            this.PDbutton_sort.UseVisualStyleBackColor = false;
            // 
            // PDbutton_clear
            // 
            this.PDbutton_clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PDbutton_clear.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_clear.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_clear.Location = new System.Drawing.Point(326, 6);
            this.PDbutton_clear.Name = "PDbutton_clear";
            this.PDbutton_clear.Size = new System.Drawing.Size(90, 24);
            this.PDbutton_clear.TabIndex = 39;
            this.PDbutton_clear.Text = "Clear list";
            this.PDbutton_clear.UseVisualStyleBackColor = false;
            // 
            // PDpanel_bottom_right
            // 
            this.PDpanel_bottom_right.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PDpanel_bottom_right.Controls.Add(this.PDbutton_distinct);
            this.PDpanel_bottom_right.Controls.Add(this.PDadvancedpanel);
            this.PDpanel_bottom_right.Controls.Add(this.PDbutton_horizontal);
            this.PDpanel_bottom_right.Controls.Add(this.PDbutton_cancel);
            this.PDpanel_bottom_right.Controls.Add(this.PDbutton_vertical);
            this.PDpanel_bottom_right.Controls.Add(this.PDbutton_all);
            this.PDpanel_bottom_right.Controls.Add(this.PDinput_search);
            this.PDpanel_bottom_right.Controls.Add(this.PDlabel_tip);
            this.PDpanel_bottom_right.Controls.Add(this.PDbutton_branch);
            this.PDpanel_bottom_right.Controls.Add(this.PDbutton_invert);
            this.PDpanel_bottom_right.Controls.Add(this.PDbutton_search);
            this.PDpanel_bottom_right.Location = new System.Drawing.Point(0, 292);
            this.PDpanel_bottom_right.Name = "PDpanel_bottom_right";
            this.PDpanel_bottom_right.Size = new System.Drawing.Size(426, 136);
            this.PDpanel_bottom_right.TabIndex = 38;
            // 
            // PDbutton_distinct
            // 
            this.PDbutton_distinct.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_distinct.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_distinct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_distinct.Location = new System.Drawing.Point(212, 36);
            this.PDbutton_distinct.Name = "PDbutton_distinct";
            this.PDbutton_distinct.Size = new System.Drawing.Size(67, 24);
            this.PDbutton_distinct.TabIndex = 37;
            this.PDbutton_distinct.Text = "Distinct";
            this.toolTip1.SetToolTip(this.PDbutton_distinct, "Filters selection to eliminate duplicates");
            this.PDbutton_distinct.UseVisualStyleBackColor = false;
            this.PDbutton_distinct.Click += new System.EventHandler(this.PDbutton_distinct_Click);
            // 
            // PDadvancedpanel
            // 
            this.PDadvancedpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.PDadvancedpanel.Controls.Add(this.PDbutton_1);
            this.PDadvancedpanel.Controls.Add(this.PDbutton_2);
            this.PDadvancedpanel.Controls.Add(this.PDbutton_3);
            this.PDadvancedpanel.Controls.Add(this.PDbutton_4);
            this.PDadvancedpanel.Controls.Add(this.PDbutton_5);
            this.PDadvancedpanel.Controls.Add(this.PDbutton_B);
            this.PDadvancedpanel.Location = new System.Drawing.Point(8, 36);
            this.PDadvancedpanel.Name = "PDadvancedpanel";
            this.PDadvancedpanel.Size = new System.Drawing.Size(96, 24);
            this.PDadvancedpanel.TabIndex = 36;
            // 
            // PDbutton_1
            // 
            this.PDbutton_1.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_1.Location = new System.Drawing.Point(0, 0);
            this.PDbutton_1.Name = "PDbutton_1";
            this.PDbutton_1.Size = new System.Drawing.Size(16, 24);
            this.PDbutton_1.TabIndex = 9;
            this.PDbutton_1.Text = "1";
            this.PDbutton_1.UseVisualStyleBackColor = false;
            // 
            // PDbutton_2
            // 
            this.PDbutton_2.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_2.Location = new System.Drawing.Point(16, 0);
            this.PDbutton_2.Name = "PDbutton_2";
            this.PDbutton_2.Size = new System.Drawing.Size(16, 24);
            this.PDbutton_2.TabIndex = 10;
            this.PDbutton_2.Text = "2";
            this.PDbutton_2.UseVisualStyleBackColor = false;
            // 
            // PDbutton_3
            // 
            this.PDbutton_3.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_3.Location = new System.Drawing.Point(32, 0);
            this.PDbutton_3.Name = "PDbutton_3";
            this.PDbutton_3.Size = new System.Drawing.Size(16, 24);
            this.PDbutton_3.TabIndex = 11;
            this.PDbutton_3.Text = "3";
            this.PDbutton_3.UseVisualStyleBackColor = false;
            // 
            // PDbutton_4
            // 
            this.PDbutton_4.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_4.Location = new System.Drawing.Point(48, 0);
            this.PDbutton_4.Name = "PDbutton_4";
            this.PDbutton_4.Size = new System.Drawing.Size(16, 24);
            this.PDbutton_4.TabIndex = 12;
            this.PDbutton_4.Text = "4";
            this.PDbutton_4.UseVisualStyleBackColor = false;
            // 
            // PDbutton_5
            // 
            this.PDbutton_5.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_5.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_5.Location = new System.Drawing.Point(64, 0);
            this.PDbutton_5.Name = "PDbutton_5";
            this.PDbutton_5.Size = new System.Drawing.Size(16, 24);
            this.PDbutton_5.TabIndex = 13;
            this.PDbutton_5.Text = "5";
            this.PDbutton_5.UseVisualStyleBackColor = false;
            // 
            // PDbutton_B
            // 
            this.PDbutton_B.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_B.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_B.Location = new System.Drawing.Point(80, 0);
            this.PDbutton_B.Name = "PDbutton_B";
            this.PDbutton_B.Size = new System.Drawing.Size(16, 24);
            this.PDbutton_B.TabIndex = 14;
            this.PDbutton_B.Text = "B";
            this.PDbutton_B.UseVisualStyleBackColor = false;
            // 
            // PDbutton_horizontal
            // 
            this.PDbutton_horizontal.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PDbutton_horizontal.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_horizontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_horizontal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PDbutton_horizontal.Location = new System.Drawing.Point(289, 6);
            this.PDbutton_horizontal.Name = "PDbutton_horizontal";
            this.PDbutton_horizontal.Size = new System.Drawing.Size(131, 24);
            this.PDbutton_horizontal.TabIndex = 29;
            this.PDbutton_horizontal.Text = "Paste horizontally";
            // 
            // PDbutton_cancel
            // 
            this.PDbutton_cancel.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.PDbutton_cancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_cancel.Location = new System.Drawing.Point(289, 70);
            this.PDbutton_cancel.Name = "PDbutton_cancel";
            this.PDbutton_cancel.Size = new System.Drawing.Size(131, 24);
            this.PDbutton_cancel.TabIndex = 31;
            this.PDbutton_cancel.Text = "Cancel";
            this.PDbutton_cancel.UseVisualStyleBackColor = false;
            // 
            // PDbutton_vertical
            // 
            this.PDbutton_vertical.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PDbutton_vertical.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_vertical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_vertical.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PDbutton_vertical.Location = new System.Drawing.Point(289, 36);
            this.PDbutton_vertical.Name = "PDbutton_vertical";
            this.PDbutton_vertical.Size = new System.Drawing.Size(131, 24);
            this.PDbutton_vertical.TabIndex = 30;
            this.PDbutton_vertical.Text = "Paste vertically";
            // 
            // PDbutton_all
            // 
            this.PDbutton_all.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_all.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_all.Location = new System.Drawing.Point(8, 6);
            this.PDbutton_all.Name = "PDbutton_all";
            this.PDbutton_all.Size = new System.Drawing.Size(92, 24);
            this.PDbutton_all.TabIndex = 0;
            this.PDbutton_all.Text = "Select all";
            this.PDbutton_all.UseVisualStyleBackColor = false;
            // 
            // PDinput_search
            // 
            this.PDinput_search.Location = new System.Drawing.Point(8, 72);
            this.PDinput_search.Name = "PDinput_search";
            this.PDinput_search.Size = new System.Drawing.Size(142, 20);
            this.PDinput_search.TabIndex = 18;
            this.PDinput_search.Visible = false;
            // 
            // PDlabel_tip
            // 
            this.PDlabel_tip.BackColor = System.Drawing.SystemColors.Control;
            this.PDlabel_tip.Location = new System.Drawing.Point(11, 102);
            this.PDlabel_tip.Name = "PDlabel_tip";
            this.PDlabel_tip.Size = new System.Drawing.Size(408, 21);
            this.PDlabel_tip.TabIndex = 19;
            this.PDlabel_tip.Text = "Tip: Press SHIFT to extend current selection";
            this.PDlabel_tip.Visible = false;
            // 
            // PDbutton_branch
            // 
            this.PDbutton_branch.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_branch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_branch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_branch.Location = new System.Drawing.Point(112, 6);
            this.PDbutton_branch.Name = "PDbutton_branch";
            this.PDbutton_branch.Size = new System.Drawing.Size(92, 24);
            this.PDbutton_branch.TabIndex = 15;
            this.PDbutton_branch.Text = "Select branch";
            this.PDbutton_branch.UseVisualStyleBackColor = false;
            // 
            // PDbutton_invert
            // 
            this.PDbutton_invert.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_invert.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_invert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_invert.Location = new System.Drawing.Point(112, 36);
            this.PDbutton_invert.Name = "PDbutton_invert";
            this.PDbutton_invert.Size = new System.Drawing.Size(92, 24);
            this.PDbutton_invert.TabIndex = 16;
            this.PDbutton_invert.Text = "Invert selection";
            this.PDbutton_invert.UseVisualStyleBackColor = false;
            this.PDbutton_invert.Visible = false;
            // 
            // PDbutton_search
            // 
            this.PDbutton_search.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_search.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_search.Location = new System.Drawing.Point(156, 70);
            this.PDbutton_search.Name = "PDbutton_search";
            this.PDbutton_search.Size = new System.Drawing.Size(108, 24);
            this.PDbutton_search.TabIndex = 17;
            this.PDbutton_search.Text = "Search && Select";
            this.PDbutton_search.UseVisualStyleBackColor = false;
            this.PDbutton_search.Visible = false;
            // 
            // PDlabel_picklist
            // 
            this.PDlabel_picklist.Location = new System.Drawing.Point(6, 15);
            this.PDlabel_picklist.Name = "PDlabel_picklist";
            this.PDlabel_picklist.Size = new System.Drawing.Size(144, 16);
            this.PDlabel_picklist.TabIndex = 23;
            this.PDlabel_picklist.Text = "Elements to be pasted:";
            this.PDlabel_picklist.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // PDselected_items
            // 
            this.PDselected_items.AllowDrop = true;
            this.PDselected_items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDselected_items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PDselected_items.Location = new System.Drawing.Point(3, 34);
            this.PDselected_items.Name = "PDselected_items";
            this.PDselected_items.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PDselected_items.Size = new System.Drawing.Size(413, 236);
            this.PDselected_items.TabIndex = 35;
            // 
            // PDpanel_left
            // 
            this.PDpanel_left.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PDpanel_left.BackColor = System.Drawing.SystemColors.Control;
            this.PDpanel_left.Controls.Add(this.PDbutton_definition_order);
            this.PDpanel_left.Controls.Add(this.PDbutton_expand_all);
            this.PDpanel_left.Controls.Add(this.PDbutton_collaps_all);
            this.PDpanel_left.Controls.Add(this.PDpanel_bottom_left);
            this.PDpanel_left.Controls.Add(this.PDbutton_expand);
            this.PDpanel_left.Controls.Add(this.PDbutton_collaps);
            this.PDpanel_left.Location = new System.Drawing.Point(0, 0);
            this.PDpanel_left.Name = "PDpanel_left";
            this.PDpanel_left.Size = new System.Drawing.Size(332, 426);
            this.PDpanel_left.TabIndex = 39;
            // 
            // PDbutton_definition_order
            // 
            this.PDbutton_definition_order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PDbutton_definition_order.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_definition_order.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_definition_order.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_definition_order.ButtonImage")));
            this.PDbutton_definition_order.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.PDbutton_definition_order.FlatAppearance.BorderSize = 0;
            this.PDbutton_definition_order.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_definition_order.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_definition_order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_definition_order.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_definition_order.Image")));
            this.PDbutton_definition_order.Location = new System.Drawing.Point(242, 9);
            this.PDbutton_definition_order.Name = "PDbutton_definition_order";
            this.PDbutton_definition_order.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_definition_order.RolloverImage")));
            this.PDbutton_definition_order.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_definition_order.TabIndex = 27;
            this.PDbutton_definition_order.UseVisualStyleBackColor = false;
            // 
            // PDbutton_expand_all
            // 
            this.PDbutton_expand_all.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_expand_all.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_expand_all.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_expand_all.ButtonImage")));
            this.PDbutton_expand_all.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_expand_all.FlatAppearance.BorderSize = 0;
            this.PDbutton_expand_all.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_expand_all.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_expand_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_expand_all.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_expand_all.Image")));
            this.PDbutton_expand_all.Location = new System.Drawing.Point(68, 9);
            this.PDbutton_expand_all.Name = "PDbutton_expand_all";
            this.PDbutton_expand_all.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_expand_all.RolloverImage")));
            this.PDbutton_expand_all.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_expand_all.TabIndex = 26;
            this.PDbutton_expand_all.UseVisualStyleBackColor = false;
            // 
            // PDbutton_collaps_all
            // 
            this.PDbutton_collaps_all.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_collaps_all.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_collaps_all.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_collaps_all.ButtonImage")));
            this.PDbutton_collaps_all.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_collaps_all.FlatAppearance.BorderSize = 0;
            this.PDbutton_collaps_all.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_collaps_all.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_collaps_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_collaps_all.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_collaps_all.Image")));
            this.PDbutton_collaps_all.Location = new System.Drawing.Point(94, 9);
            this.PDbutton_collaps_all.Name = "PDbutton_collaps_all";
            this.PDbutton_collaps_all.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_collaps_all.RolloverImage")));
            this.PDbutton_collaps_all.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_collaps_all.TabIndex = 25;
            this.PDbutton_collaps_all.UseVisualStyleBackColor = false;
            // 
            // PDpanel_bottom_left
            // 
            this.PDpanel_bottom_left.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDpanel_bottom_left.Controls.Add(this.PDbutton_down);
            this.PDpanel_bottom_left.Controls.Add(this.PDbutton_remove);
            this.PDpanel_bottom_left.Controls.Add(this.PDbutton_add);
            this.PDpanel_bottom_left.Controls.Add(this.PDbutton_up);
            this.PDpanel_bottom_left.Controls.Add(this.PDpanel_bottom_left2);
            this.PDpanel_bottom_left.Controls.Add(this.PDdim_elements);
            this.PDpanel_bottom_left.Location = new System.Drawing.Point(8, 35);
            this.PDpanel_bottom_left.Name = "PDpanel_bottom_left";
            this.PDpanel_bottom_left.Size = new System.Drawing.Size(324, 387);
            this.PDpanel_bottom_left.TabIndex = 24;
            // 
            // PDbutton_down
            // 
            this.PDbutton_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PDbutton_down.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_down.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_down.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_down.ButtonImage")));
            this.PDbutton_down.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.PDbutton_down.FlatAppearance.BorderSize = 0;
            this.PDbutton_down.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_down.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_down.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PDbutton_down.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_down.Image")));
            this.PDbutton_down.Location = new System.Drawing.Point(286, 158);
            this.PDbutton_down.Name = "PDbutton_down";
            this.PDbutton_down.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_down.RolloverImage")));
            this.PDbutton_down.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_down.TabIndex = 26;
            this.PDbutton_down.UseVisualStyleBackColor = false;
            // 
            // PDbutton_remove
            // 
            this.PDbutton_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PDbutton_remove.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_remove.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_remove.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_remove.ButtonImage")));
            this.PDbutton_remove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.PDbutton_remove.FlatAppearance.BorderSize = 0;
            this.PDbutton_remove.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_remove.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_remove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PDbutton_remove.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_remove.Image")));
            this.PDbutton_remove.Location = new System.Drawing.Point(286, 118);
            this.PDbutton_remove.Name = "PDbutton_remove";
            this.PDbutton_remove.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_remove.RolloverImage")));
            this.PDbutton_remove.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_remove.TabIndex = 22;
            this.PDbutton_remove.UseVisualStyleBackColor = false;
            // 
            // PDbutton_add
            // 
            this.PDbutton_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PDbutton_add.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_add.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_add.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_add.ButtonImage")));
            this.PDbutton_add.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.PDbutton_add.FlatAppearance.BorderSize = 0;
            this.PDbutton_add.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_add.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PDbutton_add.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_add.Image")));
            this.PDbutton_add.Location = new System.Drawing.Point(286, 78);
            this.PDbutton_add.Name = "PDbutton_add";
            this.PDbutton_add.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_add.RolloverImage")));
            this.PDbutton_add.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_add.TabIndex = 21;
            this.PDbutton_add.UseVisualStyleBackColor = false;
            // 
            // PDbutton_up
            // 
            this.PDbutton_up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PDbutton_up.BackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_up.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_up.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_up.ButtonImage")));
            this.PDbutton_up.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.PDbutton_up.FlatAppearance.BorderSize = 0;
            this.PDbutton_up.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_up.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_up.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PDbutton_up.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_up.Image")));
            this.PDbutton_up.Location = new System.Drawing.Point(286, 38);
            this.PDbutton_up.Name = "PDbutton_up";
            this.PDbutton_up.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_up.RolloverImage")));
            this.PDbutton_up.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_up.TabIndex = 25;
            this.PDbutton_up.UseVisualStyleBackColor = false;
            // 
            // PDpanel_bottom_left2
            // 
            this.PDpanel_bottom_left2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PDpanel_bottom_left2.Controls.Add(this.PDaliasformats);
            this.PDpanel_bottom_left2.Controls.Add(this.PDlabel_alias_format);
            this.PDpanel_bottom_left2.Controls.Add(this.PDlabel_alias);
            this.PDpanel_bottom_left2.Controls.Add(this.PDattributes);
            this.PDpanel_bottom_left2.Location = new System.Drawing.Point(3, 330);
            this.PDpanel_bottom_left2.Name = "PDpanel_bottom_left2";
            this.PDpanel_bottom_left2.Size = new System.Drawing.Size(260, 54);
            this.PDpanel_bottom_left2.TabIndex = 41;
            // 
            // PDaliasformats
            // 
            this.PDaliasformats.BackColor = System.Drawing.SystemColors.Control;
            this.PDaliasformats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PDaliasformats.Location = new System.Drawing.Point(100, 30);
            this.PDaliasformats.Name = "PDaliasformats";
            this.PDaliasformats.Size = new System.Drawing.Size(156, 21);
            this.PDaliasformats.TabIndex = 40;
            // 
            // PDlabel_alias_format
            // 
            this.PDlabel_alias_format.BackColor = System.Drawing.SystemColors.Control;
            this.PDlabel_alias_format.Location = new System.Drawing.Point(3, 30);
            this.PDlabel_alias_format.Name = "PDlabel_alias_format";
            this.PDlabel_alias_format.Size = new System.Drawing.Size(91, 21);
            this.PDlabel_alias_format.TabIndex = 42;
            this.PDlabel_alias_format.Text = "Alias format";
            this.PDlabel_alias_format.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PDlabel_alias
            // 
            this.PDlabel_alias.BackColor = System.Drawing.SystemColors.Control;
            this.PDlabel_alias.Location = new System.Drawing.Point(3, 3);
            this.PDlabel_alias.Name = "PDlabel_alias";
            this.PDlabel_alias.Size = new System.Drawing.Size(91, 21);
            this.PDlabel_alias.TabIndex = 41;
            this.PDlabel_alias.Text = "Alias";
            this.PDlabel_alias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PDattributes
            // 
            this.PDattributes.BackColor = System.Drawing.SystemColors.Control;
            this.PDattributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PDattributes.Location = new System.Drawing.Point(100, 3);
            this.PDattributes.Name = "PDattributes";
            this.PDattributes.Size = new System.Drawing.Size(156, 21);
            this.PDattributes.TabIndex = 39;
            // 
            // PDdim_elements
            // 
            this.PDdim_elements.AllowSingleSelectedNode = false;
            this.PDdim_elements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDdim_elements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PDdim_elements.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.PDdim_elements.GroupAutoCollapse = false;
            this.PDdim_elements.GroupBackColor = System.Drawing.SystemColors.Control;
            this.PDdim_elements.GroupByRootNodes = true;
            this.PDdim_elements.GroupFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PDdim_elements.GroupForeColor = System.Drawing.Color.Black;
            this.PDdim_elements.GroupSelectedBackColor = System.Drawing.SystemColors.ControlDark;
            this.PDdim_elements.GroupSelectedFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PDdim_elements.GroupSelectedForeColor = System.Drawing.Color.Black;
            this.PDdim_elements.ItemHeight = 20;
            this.PDdim_elements.Location = new System.Drawing.Point(0, 0);
            this.PDdim_elements.Name = "PDdim_elements";
            this.PDdim_elements.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.PDdim_elements.SelectionMode = JControls.TreeViewSelectionMode.MultiSelect;
            this.PDdim_elements.ShowRootLines = false;
            this.PDdim_elements.Size = new System.Drawing.Size(276, 317);
            this.PDdim_elements.TabIndex = 23;
            // 
            // PDbutton_expand
            // 
            this.PDbutton_expand.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_expand.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_expand.ButtonImage")));
            this.PDbutton_expand.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.PDbutton_expand.FlatAppearance.BorderSize = 0;
            this.PDbutton_expand.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_expand.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_expand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_expand.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_expand.Image")));
            this.PDbutton_expand.Location = new System.Drawing.Point(8, 9);
            this.PDbutton_expand.Name = "PDbutton_expand";
            this.PDbutton_expand.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_expand.RolloverImage")));
            this.PDbutton_expand.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_expand.TabIndex = 19;
            // 
            // PDbutton_collaps
            // 
            this.PDbutton_collaps.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_collaps.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_collaps.ButtonImage")));
            this.PDbutton_collaps.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.PDbutton_collaps.FlatAppearance.BorderSize = 0;
            this.PDbutton_collaps.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_collaps.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_collaps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_collaps.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_collaps.Image")));
            this.PDbutton_collaps.Location = new System.Drawing.Point(34, 9);
            this.PDbutton_collaps.Name = "PDbutton_collaps";
            this.PDbutton_collaps.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_collaps.RolloverImage")));
            this.PDbutton_collaps.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_collaps.TabIndex = 20;
            // 
            // PDPageDBElements
            // 
            this.PDPageDBElements.BackColor = System.Drawing.SystemColors.Control;
            this.PDPageDBElements.Controls.Add(this.PDPanelMeta2);
            this.PDPageDBElements.Location = new System.Drawing.Point(4, 22);
            this.PDPageDBElements.Name = "PDPageDBElements";
            this.PDPageDBElements.Padding = new System.Windows.Forms.Padding(3);
            this.PDPageDBElements.Selected = false;
            this.PDPageDBElements.Size = new System.Drawing.Size(757, 434);
            this.PDPageDBElements.TabIndex = 1;
            this.PDPageDBElements.Text = "database elements";
            this.PDPageDBElements.Title = "database elements";
            // 
            // PDPanelMeta2
            // 
            this.PDPanelMeta2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDPanelMeta2.Controls.Add(this.PDradio_dims);
            this.PDPanelMeta2.Controls.Add(this.PDradio_cube);
            this.PDPanelMeta2.Controls.Add(this.PDradio_con);
            this.PDPanelMeta2.Controls.Add(this.PDcube_dims);
            this.PDPanelMeta2.Controls.Add(this.PDPanelMeta1);
            this.PDPanelMeta2.Controls.Add(this.PDCubes);
            this.PDPanelMeta2.Location = new System.Drawing.Point(0, 3);
            this.PDPanelMeta2.Name = "PDPanelMeta2";
            this.PDPanelMeta2.Size = new System.Drawing.Size(762, 432);
            this.PDPanelMeta2.TabIndex = 49;
            // 
            // PDradio_dims
            // 
            this.PDradio_dims.AutoSize = true;
            this.PDradio_dims.Location = new System.Drawing.Point(12, 86);
            this.PDradio_dims.Name = "PDradio_dims";
            this.PDradio_dims.Size = new System.Drawing.Size(139, 17);
            this.PDradio_dims.TabIndex = 54;
            this.PDradio_dims.TabStop = true;
            this.PDradio_dims.Text = "insert dimensions names";
            this.PDradio_dims.UseVisualStyleBackColor = true;
            // 
            // PDradio_cube
            // 
            this.PDradio_cube.AutoSize = true;
            this.PDradio_cube.Location = new System.Drawing.Point(12, 26);
            this.PDradio_cube.Name = "PDradio_cube";
            this.PDradio_cube.Size = new System.Drawing.Size(106, 17);
            this.PDradio_cube.TabIndex = 53;
            this.PDradio_cube.TabStop = true;
            this.PDradio_cube.Text = "insert cube name";
            this.PDradio_cube.UseVisualStyleBackColor = true;
            // 
            // PDradio_con
            // 
            this.PDradio_con.AutoSize = true;
            this.PDradio_con.Checked = true;
            this.PDradio_con.Location = new System.Drawing.Point(12, 3);
            this.PDradio_con.Name = "PDradio_con";
            this.PDradio_con.Size = new System.Drawing.Size(193, 17);
            this.PDradio_con.TabIndex = 52;
            this.PDradio_con.TabStop = true;
            this.PDradio_con.Text = "insert server/database (connection)";
            this.PDradio_con.UseVisualStyleBackColor = true;
            // 
            // PDcube_dims
            // 
            this.PDcube_dims.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDcube_dims.DisplayMember = "(none)";
            this.PDcube_dims.FormattingEnabled = true;
            this.PDcube_dims.Location = new System.Drawing.Point(31, 112);
            this.PDcube_dims.Name = "PDcube_dims";
            this.PDcube_dims.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PDcube_dims.Size = new System.Drawing.Size(520, 303);
            this.PDcube_dims.TabIndex = 49;
            // 
            // PDPanelMeta1
            // 
            this.PDPanelMeta1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDPanelMeta1.Controls.Add(this.PDPanelMeta3);
            this.PDPanelMeta1.Controls.Add(this.PDbutton_data);
            this.PDPanelMeta1.Controls.Add(this.PDbutton_attr);
            this.PDPanelMeta1.Controls.Add(this.PDbutton_user);
            this.PDPanelMeta1.Location = new System.Drawing.Point(557, 0);
            this.PDPanelMeta1.Name = "PDPanelMeta1";
            this.PDPanelMeta1.Size = new System.Drawing.Size(202, 429);
            this.PDPanelMeta1.TabIndex = 48;
            // 
            // PDPanelMeta3
            // 
            this.PDPanelMeta3.Controls.Add(this.PDbutton_db_horizontal);
            this.PDPanelMeta3.Controls.Add(this.PDbutton_meta_cancel);
            this.PDPanelMeta3.Controls.Add(this.PDbutton_meta_horizontal);
            this.PDPanelMeta3.Controls.Add(this.PDbutton_meta_vertical);
            this.PDPanelMeta3.Controls.Add(this.PDbutton_db_cancel);
            this.PDPanelMeta3.Controls.Add(this.PDbutton_db_vertical);
            this.PDPanelMeta3.Location = new System.Drawing.Point(0, 302);
            this.PDPanelMeta3.Name = "PDPanelMeta3";
            this.PDPanelMeta3.Size = new System.Drawing.Size(200, 117);
            this.PDPanelMeta3.TabIndex = 49;
            // 
            // PDbutton_db_horizontal
            // 
            this.PDbutton_db_horizontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_db_horizontal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PDbutton_db_horizontal.Location = new System.Drawing.Point(15, 333);
            this.PDbutton_db_horizontal.Name = "PDbutton_db_horizontal";
            this.PDbutton_db_horizontal.Size = new System.Drawing.Size(178, 24);
            this.PDbutton_db_horizontal.TabIndex = 48;
            this.PDbutton_db_horizontal.Text = "Paste horizontally";
            // 
            // PDbutton_meta_cancel
            // 
            this.PDbutton_meta_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.PDbutton_meta_cancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_meta_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_meta_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PDbutton_meta_cancel.Location = new System.Drawing.Point(15, 90);
            this.PDbutton_meta_cancel.Name = "PDbutton_meta_cancel";
            this.PDbutton_meta_cancel.Size = new System.Drawing.Size(178, 24);
            this.PDbutton_meta_cancel.TabIndex = 29;
            this.PDbutton_meta_cancel.Text = "cancel";
            // 
            // PDbutton_meta_horizontal
            // 
            this.PDbutton_meta_horizontal.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PDbutton_meta_horizontal.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_meta_horizontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_meta_horizontal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PDbutton_meta_horizontal.Location = new System.Drawing.Point(15, 24);
            this.PDbutton_meta_horizontal.Name = "PDbutton_meta_horizontal";
            this.PDbutton_meta_horizontal.Size = new System.Drawing.Size(178, 24);
            this.PDbutton_meta_horizontal.TabIndex = 48;
            this.PDbutton_meta_horizontal.Text = "Paste horizontally";
            // 
            // PDbutton_meta_vertical
            // 
            this.PDbutton_meta_vertical.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PDbutton_meta_vertical.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PDbutton_meta_vertical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_meta_vertical.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PDbutton_meta_vertical.Location = new System.Drawing.Point(15, 54);
            this.PDbutton_meta_vertical.Name = "PDbutton_meta_vertical";
            this.PDbutton_meta_vertical.Size = new System.Drawing.Size(178, 24);
            this.PDbutton_meta_vertical.TabIndex = 30;
            this.PDbutton_meta_vertical.Text = "Paste vertically";
            // 
            // PDbutton_db_cancel
            // 
            this.PDbutton_db_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_db_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PDbutton_db_cancel.Location = new System.Drawing.Point(15, 399);
            this.PDbutton_db_cancel.Name = "PDbutton_db_cancel";
            this.PDbutton_db_cancel.Size = new System.Drawing.Size(178, 24);
            this.PDbutton_db_cancel.TabIndex = 29;
            this.PDbutton_db_cancel.Text = "cancel";
            // 
            // PDbutton_db_vertical
            // 
            this.PDbutton_db_vertical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_db_vertical.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PDbutton_db_vertical.Location = new System.Drawing.Point(15, 363);
            this.PDbutton_db_vertical.Name = "PDbutton_db_vertical";
            this.PDbutton_db_vertical.Size = new System.Drawing.Size(178, 24);
            this.PDbutton_db_vertical.TabIndex = 30;
            this.PDbutton_db_vertical.Text = "Paste vertically";
            // 
            // PDbutton_data
            // 
            this.PDbutton_data.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_data.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_data.ButtonImage")));
            this.PDbutton_data.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.PDbutton_data.FlatAppearance.BorderSize = 0;
            this.PDbutton_data.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_data.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_data.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_data.Image")));
            this.PDbutton_data.Location = new System.Drawing.Point(15, 49);
            this.PDbutton_data.Name = "PDbutton_data";
            this.PDbutton_data.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_data.RolloverImage")));
            this.PDbutton_data.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_data.TabIndex = 43;
            this.PDbutton_data.UseVisualStyleBackColor = true;
            // 
            // PDbutton_attr
            // 
            this.PDbutton_attr.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_attr.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_attr.ButtonImage")));
            this.PDbutton_attr.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.PDbutton_attr.FlatAppearance.BorderSize = 0;
            this.PDbutton_attr.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_attr.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_attr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_attr.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_attr.Image")));
            this.PDbutton_attr.Location = new System.Drawing.Point(45, 49);
            this.PDbutton_attr.Name = "PDbutton_attr";
            this.PDbutton_attr.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_attr.RolloverImage")));
            this.PDbutton_attr.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_attr.TabIndex = 44;
            this.PDbutton_attr.UseVisualStyleBackColor = true;
            // 
            // PDbutton_user
            // 
            this.PDbutton_user.ButtonColor = System.Drawing.SystemColors.Control;
            this.PDbutton_user.ButtonImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_user.ButtonImage")));
            this.PDbutton_user.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.PDbutton_user.FlatAppearance.BorderSize = 0;
            this.PDbutton_user.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_user.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.PDbutton_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDbutton_user.Image = ((System.Drawing.Image)(resources.GetObject("PDbutton_user.Image")));
            this.PDbutton_user.Location = new System.Drawing.Point(77, 49);
            this.PDbutton_user.Name = "PDbutton_user";
            this.PDbutton_user.RolloverImage = ((System.Drawing.Image)(resources.GetObject("PDbutton_user.RolloverImage")));
            this.PDbutton_user.Size = new System.Drawing.Size(26, 23);
            this.PDbutton_user.TabIndex = 45;
            this.PDbutton_user.UseVisualStyleBackColor = false;
            // 
            // PDCubes
            // 
            this.PDCubes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDCubes.BackColor = System.Drawing.SystemColors.Control;
            this.PDCubes.DisplayMember = "Text";
            this.PDCubes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PDCubes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PDCubes.FormattingEnabled = true;
            this.PDCubes.Location = new System.Drawing.Point(31, 49);
            this.PDCubes.MaxLength = 0;
            this.PDCubes.Name = "PDCubes";
            this.PDCubes.SelectedIndex = -1;
            this.PDCubes.Size = new System.Drawing.Size(500, 21);
            this.PDCubes.TabIndex = 42;
            // 
            // PDadvanced
            // 
            this.PDadvanced.BackColor = System.Drawing.Color.Transparent;
            this.PDadvanced.Enabled = false;
            this.PDadvanced.ForeColor = System.Drawing.Color.DarkGray;
            this.PDadvanced.Location = new System.Drawing.Point(580, 28);
            this.PDadvanced.Name = "PDadvanced";
            this.PDadvanced.Size = new System.Drawing.Size(172, 20);
            this.PDadvanced.TabIndex = 42;
            this.PDadvanced.TabStop = false;
            this.PDadvanced.Text = "Show all selection controls";
            this.PDadvanced.UseVisualStyleBackColor = false;
            this.PDadvanced.Visible = false;
            // 
            // PasteElements2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.PDbutton_cancel;
            this.ClientSize = new System.Drawing.Size(766, 526);
            this.ControlBox = false;
            this.Controls.Add(this.PDadvanced);
            this.Controls.Add(this.PDdbelements);
            this.Controls.Add(this.PDlabel_choose_server);
            this.Controls.Add(this.PDTabPages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(774, 542);
            this.Name = "PasteElements2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paste Elements";
            this.PDTabPages.ResumeLayout(false);
            this.PDPageDimElements.ResumeLayout(false);
            this.PDpanel_right.ResumeLayout(false);
            this.PDpanel_bottom_right.ResumeLayout(false);
            this.PDpanel_bottom_right.PerformLayout();
            this.PDadvancedpanel.ResumeLayout(false);
            this.PDpanel_left.ResumeLayout(false);
            this.PDpanel_bottom_left.ResumeLayout(false);
            this.PDpanel_bottom_left2.ResumeLayout(false);
            this.PDPageDBElements.ResumeLayout(false);
            this.PDPanelMeta2.ResumeLayout(false);
            this.PDPanelMeta2.PerformLayout();
            this.PDPanelMeta1.ResumeLayout(false);
            this.PDPanelMeta3.ResumeLayout(false);
            this.ResumeLayout(false);

			}

		#endregion

		/*---------------*/
		/*	UI Controls  */
		/*---------------*/

		private JTabControl PDTabPages;
		private JTabPage PDPageDBElements;
		private JTabPage PDPageDimElements;
		private Panel PDpanel_left;
		private JButton PDbutton_expand_all;
		private JButton PDbutton_collaps_all;
		private Panel PDpanel_bottom_left;
		private ComboBox PDattributes;
		private JButton PDbutton_down;
		private JButton PDbutton_up;
		private JButton PDbutton_add;
		private JButton PDbutton_remove;
		private JTreeView PDdim_elements;
		private JButton PDbutton_expand;
		private Panel PDpanel_right;
		private Panel PDpanel_bottom_right;
		private Panel PDadvancedpanel;
		private Button PDbutton_revers_sort;
		private Button PDbutton_sort;
		private Button PDbutton_clear;
		private Button PDbutton_1;
		private Button PDbutton_2;
		private Button PDbutton_3;
		private Button PDbutton_4;
		private Button PDbutton_5;
		private Button PDbutton_B;
		private Button PDbutton_horizontal;
		private Button PDbutton_cancel;
		private Button PDbutton_vertical;
		private Button PDbutton_all;
		private Button PDbutton_branch;
		private Button PDbutton_invert;
		private Button PDbutton_search;
		private Button PDbutton_meta_horizontal;
		private Button PDbutton_meta_cancel;
		private Button PDbutton_meta_vertical;
		private Button PDbutton_db_horizontal;
		private Button PDbutton_db_cancel;
		private Button PDbutton_db_vertical;
		private TextBox PDinput_search;
        private Label PDlabel_tip;
		private Label PDlabel_picklist;
		private ListBox PDselected_items;
		private Label PDlabel_choose_server;
		private ComboBox PDaliasformats;
		private Apalo.XlAddin.Forms.Controls.CubeComboBox PDCubes;
		private JButton PDbutton_data;
		private JButton PDbutton_attr;
		private JButton PDbutton_user;
		private Panel PDPanelMeta1;
		private Panel PDPanelMeta2;
		private ListBox PDcube_dims;
		private RadioButton PDradio_dims;
		private RadioButton PDradio_cube;
		private RadioButton PDradio_con;
		private Panel PDPanelMeta3;
		private JButton PDbutton_definition_order;
		private Label PDlabel_alias;
		private Label PDlabel_alias_format;
		private Panel PDpanel_bottom_left2;
		private CheckBox PDdbelements;
		private JButton PDbutton_collaps;
        private CheckBox PDadvanced;
        private Button PDbutton_distinct;
        private ToolTip toolTip1;

		}
	}
