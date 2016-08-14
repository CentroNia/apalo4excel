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
//  JMM 09-17-13 Various changes for 5.0 library compatability

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Jedox.Palo.Comm;
using JControls;
using Apalo.XlAddin.Utils;
//using CNode = Crownwood.DotNetMagic.Controls.Node;
//using JNode = System.Windows.Forms.TreeNode;

namespace Apalo.XlAddin.Forms
{
	[ComVisible(false)]
	public class ChooseElements : System.Windows.Forms.Form
	{
        private const byte SEL_ALL = 0;
        private const byte SEL_NONE = 1;
        private const byte SEL_INVERT = 2;

        private const byte MODE_NORM = 0;
		private const byte MODE_SEL = 1;

        private const string PFAD_TRENNER = "\\";
        private const string CHOOSEELEMENTS = "ChooseElements";

        private string attrib_cube = "";
        private string currdb = "";
        private bool foundsearch;
        private Int64 last_search_pos = -1;
        string[] elnames;
        private Hashtable dimelems = new Hashtable();
        private Hashtable dattribs = new Hashtable();

        private byte mode = MODE_NORM;
		private string olapdb = "";		
		private string olapdborig = "";		
		private string currentdim = "";
		private ArrayList ElemList = new ArrayList();
		private string dimorig = "";		
		private ArrayList currentelem = new ArrayList();
		private Excel.Range range;
		private int max_exp_level = 0;
		private Size oldsize = new Size(0,0);
		private Connection currConn = null;
        private bool endrec = false;
		private System.ComponentModel.IContainer components;

		private JTreeView ENdim_elements;
        //

        private Button ENbutton_cancel;
        private JButton ENbutton_collaps;
        private JButton ENbutton_expand;
        private Button ENbutton_all;
        private JButton ENbutton_expand_all;
        private JButton ENbutton_collaps_all;
        private TextBox ENinput_search;
        private Button ENbutton_search;
        private ComboBox ENattributes;
		private Button ENbutton_ok;
        private Panel ENadvancedpanel;
        private Button ENbutton_1;
        private Button ENbutton_2;
        private Button ENbutton_3;
        private Button ENbutton_4;
        private Button ENbutton_5;
        private Button ENbutton_B;
        private Button ENbutton_branch;
        private string formatname;
        private bool return_all = false;

		public ChooseElements(string olapdb, string dimension)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.components = new System.ComponentModel.Container();

       
    		//
			// Add any constructor code after InitializeComponent call
			//
            
            this.ENbutton_cancel.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_cancel.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_cancel.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_ok.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_ok.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_ok.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_all.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_all.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_all.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_search.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_search.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_search.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_branch.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_branch.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_branch.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_1.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_1.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_1.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_2.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_2.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_2.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_3.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_3.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_3.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_4.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_4.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_4.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_5.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_5.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_5.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_B.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.ENbutton_B.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_B.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_expand_all.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_expand_all.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_expand_all.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_expand_all.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_collaps_all.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_collaps_all.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_collaps_all.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_collaps_all.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_expand.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_expand.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_expand.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_expand.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_collaps.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_collaps.ButtonColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_collaps.FlatAppearance.MouseDownBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENbutton_collaps.FlatAppearance.MouseOverBackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENattributes.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.ENadvancedpanel.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;


            this.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.ENbutton_expand.ButtonImage = (Image)ResourceInitializer.IconExpand;
            this.ENbutton_expand.RolloverImage = (Image)ResourceInitializer.IconExpandH;
            this.ENbutton_collaps.ButtonImage = (Image)ResourceInitializer.IconCollapse;
            this.ENbutton_collaps.RolloverImage = (Image)ResourceInitializer.IconCollapseH;
            this.ENbutton_expand_all.ButtonImage = (Image)ResourceInitializer.IconExpandAllButton;
            this.ENbutton_expand_all.RolloverImage = (Image)ResourceInitializer.IconExpandAllButtonH;
            this.ENbutton_collaps_all.ButtonImage = (Image)ResourceInitializer.IconCollapseAllButton;
            this.ENbutton_collaps_all.RolloverImage = (Image)ResourceInitializer.IconCollapseAllButtonH;

            this.ENbutton_cancel.Text = ResourceInitializer.BUTTON_CANCEL;
            this.ENbutton_ok.Text = ResourceInitializer.BUTTON_OK;
			this.ENbutton_all.Text = ResourceInitializer.BUTTON_ALL;
            this.ENbutton_search.Text = ResourceInitializer.BUTTON_SEARCH_SELECT;

			this.Text = ResourceInitializer.TITLE_CHOOSE_ELEMENT;
            this.ENbutton_branch.Text = ResourceInitializer.BUTTON_SELECT_BRANCH;

			this.ENbutton_expand_all.Click += new System.EventHandler(this.ENbutton_expand_all_Click);
			this.ENbutton_collaps_all.Click += new System.EventHandler(this.ENbutton_collaps_all_Click);
			this.ENbutton_expand.Click += new System.EventHandler(this.ENbutton_expand_Click);
			this.ENbutton_collaps.Click += new System.EventHandler(this.ENbutton_collaps_Click);
			this.ENbutton_cancel.Click += new System.EventHandler(this.ENbutton_cancel_Click);
			this.ENbutton_ok.Click += new System.EventHandler(this.ENbutton_ok_Click);
			this.ENbutton_all.Click += new System.EventHandler(this.ENbutton_all_Click);
			this.ENdim_elements.DoubleClick += new System.EventHandler(this.ENdim_elements_DoubleClick);
            this.ENbutton_search.Click += new System.EventHandler(this.ENbutton_search_Click);
            this.ENinput_search.TextChanged += new System.EventHandler(this.ENinput_search_TextChanged);
            this.ENattributes.SelectedIndexChanged += new System.EventHandler(this.ENattributes_SelectedIndexChanged);

            this.ENbutton_branch.Click += new System.EventHandler(this.ENbutton_branch_Click);
            this.ENbutton_1.Click += new System.EventHandler(this.ENbutton_1_Click);
            this.ENbutton_2.Click += new System.EventHandler(this.ENbutton_2_Click);
            this.ENbutton_3.Click += new System.EventHandler(this.ENbutton_3_Click);
            this.ENbutton_4.Click += new System.EventHandler(this.ENbutton_4_Click);
            this.ENbutton_5.Click += new System.EventHandler(this.ENbutton_5_Click);
            this.ENbutton_B.Click += new System.EventHandler(this.ENbutton_B_Click);
            this.ENdim_elements.KeyDown += new KeyEventHandler(ENdim_elements_KeyDown);

            this.oldsize = this.Size;
			this.Resize += new System.EventHandler(this.frmEName_Resize);

			this.olapdb = olapdb;
			this.currentdim = dimension;
            this.formatname = "";

            int[] tmpProps = RegUtils.GetFormProperties(CHOOSEELEMENTS);

            if ((tmpProps[0] != -1) || (tmpProps[1] != -1))
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
            }

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseElements));
            this.ENbutton_expand = new JControls.JButton();
            this.ENbutton_collaps = new JControls.JButton();
            this.ENdim_elements = new JControls.JTreeView();
            this.ENbutton_cancel = new System.Windows.Forms.Button();
            this.ENbutton_ok = new System.Windows.Forms.Button();
            this.ENbutton_all = new System.Windows.Forms.Button();
            this.ENbutton_expand_all = new JControls.JButton();
            this.ENbutton_collaps_all = new JControls.JButton();
            this.ENinput_search = new System.Windows.Forms.TextBox();
            this.ENbutton_search = new System.Windows.Forms.Button();
            this.ENattributes = new System.Windows.Forms.ComboBox();
            this.ENadvancedpanel = new System.Windows.Forms.Panel();
            this.ENbutton_1 = new System.Windows.Forms.Button();
            this.ENbutton_2 = new System.Windows.Forms.Button();
            this.ENbutton_3 = new System.Windows.Forms.Button();
            this.ENbutton_4 = new System.Windows.Forms.Button();
            this.ENbutton_5 = new System.Windows.Forms.Button();
            this.ENbutton_B = new System.Windows.Forms.Button();
            this.ENbutton_branch = new System.Windows.Forms.Button();
            this.ENadvancedpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ENbutton_expand
            // 
            this.ENbutton_expand.ButtonColor = System.Drawing.SystemColors.Control;
            this.ENbutton_expand.ButtonImage = ((System.Drawing.Image)(resources.GetObject("ENbutton_expand.ButtonImage")));
            this.ENbutton_expand.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_expand.FlatAppearance.BorderSize = 0;
            this.ENbutton_expand.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_expand.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_expand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_expand.Image = ((System.Drawing.Image)(resources.GetObject("ENbutton_expand.Image")));
            this.ENbutton_expand.Location = new System.Drawing.Point(8, 6);
            this.ENbutton_expand.Name = "ENbutton_expand";
            this.ENbutton_expand.RolloverImage = ((System.Drawing.Image)(resources.GetObject("ENbutton_expand.RolloverImage")));
            this.ENbutton_expand.Size = new System.Drawing.Size(26, 23);
            this.ENbutton_expand.TabIndex = 3;
            // 
            // ENbutton_collaps
            // 
            this.ENbutton_collaps.ButtonColor = System.Drawing.SystemColors.Control;
            this.ENbutton_collaps.ButtonImage = ((System.Drawing.Image)(resources.GetObject("ENbutton_collaps.ButtonImage")));
            this.ENbutton_collaps.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_collaps.FlatAppearance.BorderSize = 0;
            this.ENbutton_collaps.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_collaps.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_collaps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_collaps.Image = ((System.Drawing.Image)(resources.GetObject("ENbutton_collaps.Image")));
            this.ENbutton_collaps.Location = new System.Drawing.Point(34, 6);
            this.ENbutton_collaps.Name = "ENbutton_collaps";
            this.ENbutton_collaps.RolloverImage = ((System.Drawing.Image)(resources.GetObject("ENbutton_collaps.RolloverImage")));
            this.ENbutton_collaps.Size = new System.Drawing.Size(26, 23);
            this.ENbutton_collaps.TabIndex = 4;
            // 
            // ENdim_elements
            // 
            this.ENdim_elements.AllowSingleSelectedNode = true;
            this.ENdim_elements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ENdim_elements.GroupAutoCollapse = false;
            this.ENdim_elements.GroupBackColor = System.Drawing.Color.Empty;
            this.ENdim_elements.GroupByRootNodes = false;
            this.ENdim_elements.GroupFont = null;
            this.ENdim_elements.GroupForeColor = System.Drawing.Color.Empty;
            this.ENdim_elements.GroupSelectedBackColor = System.Drawing.Color.Empty;
            this.ENdim_elements.GroupSelectedFont = null;
            this.ENdim_elements.GroupSelectedForeColor = System.Drawing.Color.Empty;
            this.ENdim_elements.Location = new System.Drawing.Point(8, 32);
            this.ENdim_elements.Name = "ENdim_elements";
            this.ENdim_elements.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.ENdim_elements.SelectionMode = JControls.TreeViewSelectionMode.SingleSelect;
            this.ENdim_elements.Size = new System.Drawing.Size(290, 296);
            this.ENdim_elements.TabIndex = 5;
            // 
            // ENbutton_cancel
            // 
            this.ENbutton_cancel.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ENbutton_cancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_cancel.Location = new System.Drawing.Point(208, 456);
            this.ENbutton_cancel.Name = "ENbutton_cancel";
            this.ENbutton_cancel.Size = new System.Drawing.Size(90, 24);
            this.ENbutton_cancel.TabIndex = 2;
            this.ENbutton_cancel.Text = "Cancel";
            this.ENbutton_cancel.UseVisualStyleBackColor = false;
            // 
            // ENbutton_ok
            // 
            this.ENbutton_ok.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ENbutton_ok.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_ok.Location = new System.Drawing.Point(104, 456);
            this.ENbutton_ok.Name = "ENbutton_ok";
            this.ENbutton_ok.Size = new System.Drawing.Size(90, 24);
            this.ENbutton_ok.TabIndex = 1;
            this.ENbutton_ok.Text = "OK";
            this.ENbutton_ok.UseVisualStyleBackColor = false;
            // 
            // ENbutton_all
            // 
            this.ENbutton_all.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ENbutton_all.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_all.Location = new System.Drawing.Point(8, 456);
            this.ENbutton_all.Name = "ENbutton_all";
            this.ENbutton_all.Size = new System.Drawing.Size(90, 24);
            this.ENbutton_all.TabIndex = 6;
            this.ENbutton_all.Text = "All";
            this.ENbutton_all.Visible = false;
            // 
            // ENbutton_expand_all
            // 
            this.ENbutton_expand_all.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ENbutton_expand_all.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ENbutton_expand_all.ButtonImage = ((System.Drawing.Image)(resources.GetObject("ENbutton_expand_all.ButtonImage")));
            this.ENbutton_expand_all.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_expand_all.FlatAppearance.BorderSize = 0;
            this.ENbutton_expand_all.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ENbutton_expand_all.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ENbutton_expand_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_expand_all.Image = ((System.Drawing.Image)(resources.GetObject("ENbutton_expand_all.Image")));
            this.ENbutton_expand_all.Location = new System.Drawing.Point(64, 6);
            this.ENbutton_expand_all.Name = "ENbutton_expand_all";
            this.ENbutton_expand_all.RolloverImage = ((System.Drawing.Image)(resources.GetObject("ENbutton_expand_all.RolloverImage")));
            this.ENbutton_expand_all.Size = new System.Drawing.Size(26, 23);
            this.ENbutton_expand_all.TabIndex = 28;
            this.ENbutton_expand_all.UseVisualStyleBackColor = false;
            // 
            // ENbutton_collaps_all
            // 
            this.ENbutton_collaps_all.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ENbutton_collaps_all.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ENbutton_collaps_all.ButtonImage = ((System.Drawing.Image)(resources.GetObject("ENbutton_collaps_all.ButtonImage")));
            this.ENbutton_collaps_all.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_collaps_all.FlatAppearance.BorderSize = 0;
            this.ENbutton_collaps_all.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ENbutton_collaps_all.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ENbutton_collaps_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_collaps_all.Image = ((System.Drawing.Image)(resources.GetObject("ENbutton_collaps_all.Image")));
            this.ENbutton_collaps_all.Location = new System.Drawing.Point(90, 6);
            this.ENbutton_collaps_all.Name = "ENbutton_collaps_all";
            this.ENbutton_collaps_all.RolloverImage = ((System.Drawing.Image)(resources.GetObject("ENbutton_collaps_all.RolloverImage")));
            this.ENbutton_collaps_all.Size = new System.Drawing.Size(26, 23);
            this.ENbutton_collaps_all.TabIndex = 27;
            this.ENbutton_collaps_all.UseVisualStyleBackColor = false;
            // 
            // ENinput_search
            // 
            this.ENinput_search.Location = new System.Drawing.Point(8, 379);
            this.ENinput_search.Name = "ENinput_search";
            this.ENinput_search.Size = new System.Drawing.Size(136, 20);
            this.ENinput_search.TabIndex = 30;
            this.ENinput_search.TextChanged += new System.EventHandler(this.ENinput_search_TextChanged);
            // 
            // ENbutton_search
            // 
            this.ENbutton_search.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_search.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_search.Location = new System.Drawing.Point(158, 379);
            this.ENbutton_search.Name = "ENbutton_search";
            this.ENbutton_search.Size = new System.Drawing.Size(132, 24);
            this.ENbutton_search.TabIndex = 29;
            this.ENbutton_search.Text = "Search && Select";
            this.ENbutton_search.UseVisualStyleBackColor = false;
            // 
            // ENattributes
            // 
            this.ENattributes.BackColor = System.Drawing.SystemColors.Control;
            this.ENattributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ENattributes.Location = new System.Drawing.Point(8, 336);
            this.ENattributes.Name = "ENattributes";
            this.ENattributes.Size = new System.Drawing.Size(121, 21);
            this.ENattributes.TabIndex = 41;
            // 
            // ENadvancedpanel
            // 
            this.ENadvancedpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ENadvancedpanel.Controls.Add(this.ENbutton_1);
            this.ENadvancedpanel.Controls.Add(this.ENbutton_2);
            this.ENadvancedpanel.Controls.Add(this.ENbutton_3);
            this.ENadvancedpanel.Controls.Add(this.ENbutton_4);
            this.ENadvancedpanel.Controls.Add(this.ENbutton_5);
            this.ENadvancedpanel.Controls.Add(this.ENbutton_B);
            this.ENadvancedpanel.Enabled = false;
            this.ENadvancedpanel.Location = new System.Drawing.Point(8, 415);
            this.ENadvancedpanel.Name = "ENadvancedpanel";
            this.ENadvancedpanel.Size = new System.Drawing.Size(96, 24);
            this.ENadvancedpanel.TabIndex = 42;
            // 
            // ENbutton_1
            // 
            this.ENbutton_1.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_1.Location = new System.Drawing.Point(0, 0);
            this.ENbutton_1.Name = "ENbutton_1";
            this.ENbutton_1.Size = new System.Drawing.Size(16, 24);
            this.ENbutton_1.TabIndex = 9;
            this.ENbutton_1.Text = "1";
            this.ENbutton_1.UseVisualStyleBackColor = false;
            // 
            // ENbutton_2
            // 
            this.ENbutton_2.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_2.Location = new System.Drawing.Point(16, 0);
            this.ENbutton_2.Name = "ENbutton_2";
            this.ENbutton_2.Size = new System.Drawing.Size(16, 24);
            this.ENbutton_2.TabIndex = 10;
            this.ENbutton_2.Text = "2";
            this.ENbutton_2.UseVisualStyleBackColor = false;
            // 
            // ENbutton_3
            // 
            this.ENbutton_3.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_3.Location = new System.Drawing.Point(32, 0);
            this.ENbutton_3.Name = "ENbutton_3";
            this.ENbutton_3.Size = new System.Drawing.Size(16, 24);
            this.ENbutton_3.TabIndex = 11;
            this.ENbutton_3.Text = "3";
            this.ENbutton_3.UseVisualStyleBackColor = false;
            // 
            // ENbutton_4
            // 
            this.ENbutton_4.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_4.Location = new System.Drawing.Point(48, 0);
            this.ENbutton_4.Name = "ENbutton_4";
            this.ENbutton_4.Size = new System.Drawing.Size(16, 24);
            this.ENbutton_4.TabIndex = 12;
            this.ENbutton_4.Text = "4";
            this.ENbutton_4.UseVisualStyleBackColor = false;
            // 
            // ENbutton_5
            // 
            this.ENbutton_5.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_5.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_5.Location = new System.Drawing.Point(64, 0);
            this.ENbutton_5.Name = "ENbutton_5";
            this.ENbutton_5.Size = new System.Drawing.Size(16, 24);
            this.ENbutton_5.TabIndex = 13;
            this.ENbutton_5.Text = "5";
            this.ENbutton_5.UseVisualStyleBackColor = false;
            // 
            // ENbutton_B
            // 
            this.ENbutton_B.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_B.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_B.Location = new System.Drawing.Point(80, 0);
            this.ENbutton_B.Name = "ENbutton_B";
            this.ENbutton_B.Size = new System.Drawing.Size(16, 24);
            this.ENbutton_B.TabIndex = 14;
            this.ENbutton_B.Text = "B";
            this.ENbutton_B.UseVisualStyleBackColor = false;
            // 
            // ENbutton_branch
            // 
            this.ENbutton_branch.BackColor = System.Drawing.SystemColors.Control;
            this.ENbutton_branch.Enabled = false;
            this.ENbutton_branch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ENbutton_branch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENbutton_branch.Location = new System.Drawing.Point(158, 415);
            this.ENbutton_branch.Name = "ENbutton_branch";
            this.ENbutton_branch.Size = new System.Drawing.Size(132, 24);
            this.ENbutton_branch.TabIndex = 43;
            this.ENbutton_branch.Text = "Select branch";
            this.ENbutton_branch.UseVisualStyleBackColor = false;
            this.ENbutton_branch.Visible = false;
            // 
            // ChooseElements
            // 
            this.AcceptButton = this.ENbutton_ok;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.ENbutton_cancel;
            this.ClientSize = new System.Drawing.Size(302, 503);
            this.Controls.Add(this.ENbutton_branch);
            this.Controls.Add(this.ENadvancedpanel);
            this.Controls.Add(this.ENattributes);
            this.Controls.Add(this.ENinput_search);
            this.Controls.Add(this.ENbutton_search);
            this.Controls.Add(this.ENbutton_expand_all);
            this.Controls.Add(this.ENbutton_collaps_all);
            this.Controls.Add(this.ENbutton_all);
            this.Controls.Add(this.ENbutton_ok);
            this.Controls.Add(this.ENdim_elements);
            this.Controls.Add(this.ENbutton_collaps);
            this.Controls.Add(this.ENbutton_expand);
            this.Controls.Add(this.ENbutton_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 527);
            this.Name = "ChooseElements";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose element";
            this.LocationChanged += new System.EventHandler(this.frmEName_LocationChanged);
            this.ENadvancedpanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void set_default(string element, Excel.Range range, string olapdborig, string dimorig, string Attribute, string formatname)
		{
			this.mode = MODE_NORM;

            this.ENadvancedpanel.Enabled = false;
            this.ENbutton_branch.Enabled = false;
            this.ENbutton_branch.Visible = false;

			this.olapdborig = olapdborig;
			this.dimorig = dimorig;
			string dim = this.dimorig;
			if (dim.StartsWith('"'.ToString())) dim = dim.Substring(1);
			if (dim.EndsWith('"'.ToString())) dim = dim.Substring(0,dim.Length-1);
			this.Text = ResourceInitializer.Replace(ResourceInitializer.TITLE_CHOOSE_ELEMENT2, new object[]{dim});
			this.range = range;
			this.currentelem.Add(element);
			this.fill_dim_elements();
            this.formatname = formatname;

            Attribute = Attribute.Trim();

            if (Attribute != "")
            {
                this.ENattributes.Text = Attribute;
            }
            else
            {
                if (this.ENattributes.Items.Count > 0)
                {
                    this.ENattributes.SelectedIndex = 0;
                }
            }
			this.check_state_button_all();
		}

		public void set_selection(ref ArrayList element, bool multi, string Attribute, bool return_all)
		{
			this.mode = MODE_SEL;
			this.ElemList = element;
            this.return_all = return_all;

			if (multi)
			{
				//CDNM:this.ENdim_elements.SelectMode = Crownwood.DotNetMagic.Controls.SelectMode.Multiple;
                this.ENdim_elements.SelectionMode = TreeViewSelectionMode.MultiSelect;
				this.ENbutton_all.Visible = true;
                this.ENadvancedpanel.Enabled = true;
                this.ENbutton_branch.Enabled = true;
                this.ENbutton_branch.Visible = true;
			}

			int anzahl = this.ElemList.Count;
			if (anzahl > 0)
			{
				object[] o = (object[])this.ElemList[0];
				if (o.Length > 0)
				{
					this.currentelem.Add((string)o[0]);
				}
				if (multi)
				{
					for (int i = 1; i < anzahl; i++)
					{
						o = (object[])this.ElemList[i];
						if (o.Length > 0)
						{
							this.currentelem.Add((string)o[0]);
						}
					}
				}
			}
			else
			{
				this.currentelem.Clear();
			}
			this.fill_dim_elements();
            this.ENattributes.Text = Attribute;
			this.check_state_button_all();

            if ((this.ENdim_elements.SelectedNodes.Count == 0) && (this.ENdim_elements.Nodes.Count > 0))
            {
                //CDNM:this.ENdim_elements.Nodes[0].Select();
                ENdim_elements.SelectNode(ENdim_elements.Nodes[0]);
            }
            this.ENdim_elements.Focus();
            GC.Collect();
		}

        private string getpath(TreeNode element)
        {
            string path = element.Text;
            TreeNode node = element;
            while (node.Parent != null)
            {
                node = node.Parent;
                path = node.Text + PFAD_TRENNER + path;
            }

            return path;
        }


        private void do_add(TreeNodeCollection nodes, string attribute)
        {
            int anzahl = nodes.Count;
            JNode Element;
            ElementInfo ei;

            for (int i = 0; i < anzahl; i++)
            {
                Element = nodes[i] as JNode;
                if (Element.IsSelected)
                {
                    ei = (ElementInfo)this.dimelems[Element.Tag];
                    this.ElemList.Add(new object[] { ei.Name, Element.Nodes.Count > 0, this.getpath(Element), Element.Text, attribute });
                }

                if (Element.Nodes.Count > 0)
                {
                    do_add(Element.Nodes, attribute);
                }
            }
        }

   		public void set_selection(ref ArrayList element, bool multi, string Attribute )
		{
            this.set_selection(ref element, multi, Attribute, false);
        }

		private void do_paste()
		{
            this.SavePosition();
			this.DialogResult = System.Windows.Forms.DialogResult.OK;

			try
			{
                int i, lsize;
                JNode node;
                string attribute = "";
                if (this.ENattributes.SelectedIndex > 0)
                {
                    attribute = (string)this.ENattributes.Items[this.ENattributes.SelectedIndex];
                }

				if (this.mode == MODE_NORM)
				{
                    //Crownwood.DotNetMagic.Controls.SelectedNodeCollection nodes = this.ENdim_elements.SelectedNodes;
                    NodesCollection nodes = this.ENdim_elements.SelectedNodes;
                    lsize = nodes.Count;
                    string element, formula;
                    ExcelHelper eH = new ExcelHelper();
                    ElementInfo ei;
                    for (i=0; i < lsize; i++)
					{
                        node = nodes[i] as JNode;
                        ei = (ElementInfo)this.dimelems[node.Tag];
                        string attvalue = node.Text;
                                           
                        element = eH.EscapeDoubleQuote(ei.Name);

                        formula = "=PALO.ENAME(" + this.olapdborig + "," + this.dimorig + "," + '"' + element + '"' + ",1," + '"' + '"';

                        if (string.IsNullOrEmpty(this.formatname))
                        {
                            Random rand = new Random();
                            Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();

                            if (string.IsNullOrEmpty(ws.CodeName))
                            {
                                formatname = ws.Name;
                            }
                            else
                            {
                                formatname = ws.CodeName;
                            }

                            formatname += "!__palo" + rand.Next(17, 1000000);
                        }

                        if (attribute != "")
                        {
                            formula += "," + '"' + attribute + '"' + "," + '"' + this.formatname + '"';
                        }
                        
                        formula += ')';

                        string format = this.range.NumberFormat.ToString();
                        int pos = format.IndexOf(";;;");
                        bool SuccessRemove = true;
                        if (pos > 0)
                        {
                            SuccessRemove =eH.RemoveFormat(format);
                            format = format.Substring(0, pos) + ";;;\"" + node.Text + "\"";
                        }

                        Apalo.XlAddin.Connect.InPaste = false;
                        eH.AddFormulaToSpreadsheet(this.range, formula, node.Nodes.Count > 0);
                        if (attribute != "")
                        {
                            format = "\"" + this.formatname + "\";;;\"" + node.Text + "\"";

                            int flen = 128;

                            if (format.Length > flen)
                            {
                                format = format.Substring(0, flen) + "..." + '"';
                            }

                            this.range.NumberFormat = format;
                        }
                        else
                        {
                            if (!SuccessRemove)
                            {
                                this.range.NumberFormat = "General";
                            }
                        }

                        Apalo.XlAddin.Connect.InPaste = true;
					}
				}
				else
				{
					this.ElemList.Clear();
                    GC.Collect();
                    do_add(this.ENdim_elements.Nodes, attribute);

				}
			}
			catch(Exception ex)
			{
				ErrorHandler.DisplayError("Error pasting PALO.ENAME!", ex);
			}

		}

		private void check_state_button_all()   
		{
            /*
			bool expenabled = false;
			bool colenabled = false;

			Crownwood.DotNetMagic.Controls.NodeCollection Nodes = this.ENdim_elements.Nodes;
			foreach(Crownwood.DotNetMagic.Controls.Node node in Nodes)
			{
				if (node.IsExpanded)
				{
					expenabled = true;
					colenabled = true;
					break;
				}
			}

			if (this.ENdim_elements.Nodes.Count == 1)
			{
				expenabled = true;
			}
			this.ENbutton_expand_all.Enabled = expenabled;
			this.ENbutton_collaps_all.Enabled = colenabled;
            */
		}
		
		private void do_expand(TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.IsExpanded && (node.Nodes.Count > 0))
				{
					this.do_expand(node.Nodes);
				}
				else
				{
                    node.Expand();
					//CDNM: node.Expanded = true;
				}
			}
		}

		private void prepare_collaps(TreeNodeCollection nodes, int level)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.IsExpanded && (node.Nodes.Count > 0))
				{
					this.prepare_collaps(node.Nodes, level + 1);
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
			foreach (TreeNode node in nodes)
			{
				if (node.IsExpanded && (node.Nodes.Count > 0))
				{
					this.do_collaps(node.Nodes, level + 1);
				}
				else
				{
					if ((level == this.max_exp_level) && (node.Parent != null))
					{
                        ENdim_elements.SelectNode(node, false);
                        node.Parent.Collapse();
                        //CDNM:
						//node.Deselect();
						//node.Parent.Expanded =false;
					}
				}
			}
		}

        private void SavePosition()
        {
            RegUtils.SetFormProperties(CHOOSEELEMENTS, new int[4] { this.Left, this.Top, this.Width, this.Height });
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        }

		private void ENbutton_cancel_Click(object sender, System.EventArgs e)
		{
            this.SavePosition();
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}
		
		private void ENbutton_ok_Click(object sender, System.EventArgs e)
		{
			this.do_paste();
		}

        private void addChildren(TreeNodeCollection Elems, string attribute )
        {
            ElementInfo ei;
		    foreach (TreeNode Element in Elems)
		    {
                ei = (ElementInfo)this.dimelems[Element.Tag];
                this.ElemList.Add(new object[] { ei.Name, Element.Nodes.Count > 0, this.getpath(Element), Element.Text, attribute });
              
                if (Element.Nodes.Count > 0)
				{
                    this.addChildren(Element.Nodes, attribute);
				}
            }
        }

		private void ENbutton_all_Click(object sender, System.EventArgs e)
		{
			this.ElemList.Clear();
            GC.Collect();

            if (this.return_all)
            {
                string attribute = "";
                if (this.ENattributes.SelectedIndex > 0)
                {
                    attribute = (string)this.ENattributes.Items[this.ENattributes.SelectedIndex];
                }

                this.addChildren(this.ENdim_elements.Nodes, attribute);
            }

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void ENbutton_expand_Click(object sender, System.EventArgs e)
		{
			this.do_expand(this.ENdim_elements.Nodes);
            this.last_search_pos = -1;
            this.check_state_button_all();
		}

		private void ENbutton_collaps_Click(object sender, System.EventArgs e)
		{
			this.max_exp_level = 0;
            
			TreeNodeCollection Elems = this.ENdim_elements.Nodes;

			this.prepare_collaps(Elems, 1);
			this.do_collaps(Elems, 1);
            this.last_search_pos = -1;
            this.check_state_button_all();

		}
		
		private void ENbutton_collaps_all_Click(object sender, System.EventArgs e)
		{
			TreeNodeCollection Elems = this.ENdim_elements.Nodes;
						
			foreach (TreeNode Element in Elems)
			{
				if (Element.IsExpanded)
				{
                    Element.Collapse(false);
					//CDNM: Element.CollapseAll();
				}

			}
            this.last_search_pos = -1;
            this.check_state_button_all();
        }

		private void ENbutton_expand_all_Click(object sender, System.EventArgs e)
		{
			TreeNodeCollection Elems = this.ENdim_elements.Nodes;
			
			int i, anzahl = Elems.Count;

            for (i=0; i < anzahl; i++)
			{
				Elems[i].ExpandAll();
			}
            this.last_search_pos = -1;
            this.check_state_button_all();
		}

		private void ENdim_elements_DoubleClick(object sender, System.EventArgs e)
		{
			this.do_paste();
		}
		
		private void frmEName_Resize(object sender, System.EventArgs e)
		{
			Size newsize = ((System.Windows.Forms.Control)sender).Size;

			if (!this.oldsize.IsEmpty && !newsize.IsEmpty && this.Visible)
			{
				int dx = newsize.Width - this.oldsize.Width;
				int dy = newsize.Height - this.oldsize.Height;

				this.SuspendLayout();

				this.ENdim_elements.Width += dx;
				this.ENdim_elements.Height += dy;

				this.ENbutton_all.Left += dx; 
				this.ENbutton_all.Top += dy; 

				this.ENbutton_ok.Left += dx; 
				this.ENbutton_ok.Top += dy; 

				this.ENbutton_cancel.Left += dx; 
				this.ENbutton_cancel.Top += dy;

                this.ENinput_search.Width += dx;
                this.ENinput_search.Top += dy;

                this.ENbutton_search.Left += dx;
                this.ENbutton_search.Top += dy;

                this.ENattributes.Width += dx;
                this.ENattributes.Top += dy;

                this.ENadvancedpanel.Top += dy;

                this.ENbutton_branch.Top += dy;
                this.ENbutton_branch.Left += dx;

				this.ResumeLayout();
			}

			if ((!newsize.IsEmpty && this.Visible) || this.oldsize.IsEmpty)
			{
				this.oldsize = newsize;
			}

		}

        private JNode generateChildNodes(ElementInfo dimDimElem, string parent)
        {
            JNode outN = new JNode();
            string element;

            ElementInfo childdimDimElem;
            int csize, i, id;

            outN.Text = dimDimElem.Name;
            string pfad = parent + outN.Text;

            csize = dimDimElem.Children.Length;
            JNode el;
            if (csize > 0)
            {
                for (i = 0; i < csize; i++)
                {
                    id = (int)dimDimElem.Children[i].Identifier;

                    if (this.dimelems.ContainsKey(id))
                    {

                        childdimDimElem = (ElementInfo)this.dimelems[id];
                        element = (string)childdimDimElem.Name;

                        if (childdimDimElem.Children.Length > 0)
                        {
                            outN.Nodes.Add(this.generateChildNodes(childdimDimElem, pfad + PFAD_TRENNER));
                        }
                        else
                        {
                            el = new JNode();
                            el.Text = element;
                            el.Tag = id;
                            outN.Nodes.Add(el);
                        }
                    }
                }
            }
            outN.Tag = dimDimElem.Identifier;
            return outN;
        }

        private void set_elements(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (!endrec)
                {
                    if (this.currentelem.Contains(node.Text))
                    {
                        ENdim_elements.SelectNode(node);
                        //CDNM: node.Select();
                        this.currentelem.Remove(node.Text);
                        endrec = (this.currentelem.Count == 0);
                    }
                    if (!endrec && (node.Nodes.Count > 0))
                    {
                        this.set_elements(node.Nodes);
                    }
                }
            }
        }

        private void fill_dim_elements()
		{

			this.ENdim_elements.ClearNodes();
            GC.Collect();

			int pos = this.olapdb.IndexOf("/");

			if (pos > 0)
			{
				string host = this.olapdb.Substring(0,pos);
				this.currdb = this.olapdb.Substring(pos+1);
				
				try
				{
					DataTable myDt = XmlUtils.dsConnectionsTable;

					foreach (DataRow r in myDt.Rows)
					{
                        if (ConnectionsHelper.Look4conn(host, r, ref this.currConn))
                        {
                            break;
                        }
					}
				}
				catch(Exception connExc)
				{
					ErrorHandler.DisplayError("Error Connecting to server!", connExc);
				}

				
				if (this.currConn != null)
				{
					try
					{
                        int i, dsize;
                        try
                        {
                            if (!ExcelHelper.TestWithoutExcel)
                            ExcelHelper.oExcelApp.StatusBar = ResourceInitializer.Replace(ResourceInitializer.STATUS_READING_ELEMENTS_SERVER, new object[] { host });
                        }
                        catch (Exception exc)
                        {
                            ErrorHandler.DisplayError("Error Setting Excel Statusbar.", exc);
                        }

						ElementInfo[] dimDimElems = this.currConn.DimensionListElements(this.currdb, this.currentdim);
                        ElementInfo dimDimElem;
                        dsize = dimDimElems.Length;

                        this.dimelems.Clear();
                        GC.Collect();

                        this.elnames = new String[dsize];

                        for (i = 0; i < dsize; i++)
                        {
                           dimDimElem = dimDimElems[i];
                           this.elnames[i] = dimDimElem.Name;
                           this.dimelems[dimDimElem.Identifier] = dimDimElem;
                        }

                        string element;
                        for (i = 0; i < dsize; i++)
						{
                            dimDimElem = dimDimElems[i];
							element = (string)dimDimElem.Name;
                            if (!String.IsNullOrEmpty(element) && TreeHelper.has_no_valid_parents(dimDimElem, this.dimelems))
							{
								this.ENdim_elements.Nodes.Add(this.generateChildNodes(dimDimElem, ""));
							}
						}
						this.set_elements(this.ENdim_elements.Nodes);

                        getAttributes(this.currdb, this.currentdim);

					}
					catch(Exception exc)
					{
						ErrorHandler.DisplayError("Error filling elements", exc);
					}

                    try
                    {
                        if (!ExcelHelper.TestWithoutExcel)
                        ExcelHelper.oExcelApp.StatusBar = null;
                    }
                    catch (Exception exc)
                    {
                        ErrorHandler.DisplayError("Error Setting Excel Statusbar.", exc);
                    }
				}
			}
		}

		private void frmEName_LocationChanged(object sender, System.EventArgs e)
		{
			this.ENbutton_ok.Focus();
		}

        private void do_gselect(TreeNodeCollection nodes, byte mode)
        {
            int i, nsize = nodes.Count;
            TreeNode node;

            for (i = 0; i < nsize; i++)
            {
                node = nodes[i];
                switch (mode)
                {
                    case SEL_ALL:
                        ENdim_elements.SelectNode(node);
                        //CDNM: node.Select(false);
                        break;
                    case SEL_NONE:
                        ENdim_elements.SelectNode(node, false);
                        //CDNM: node.Deselect();
                        break;
                    case SEL_INVERT:
                        if (node.IsSelected)
                        {
                            ENdim_elements.SelectNode(node, false);
                            //CDNM: node.Deselect();
                        }
                        else
                        {
                            ENdim_elements.SelectNode(node, true);
                            //CDNM: node.Select(false);
                        }
                        break;
                }

                if (node.IsExpanded && (node.Nodes.Count > 0))
                {
                    this.do_gselect(node.Nodes, mode);
                }
            }
        }

        static bool check_shift()
        {
            bool ret = false;
            if (((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) == Keys.Shift) || ((System.Windows.Forms.Control.ModifierKeys & Keys.ShiftKey) == Keys.ShiftKey))
            {
                ret = true;
            }
            return ret;
        }

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

        private string addstar(string text)
        {
            int i;
            string tmptest = text;
            char last;

            if (((i = tmptest.Length) == 0) || ((last = tmptest[i - 1]) != '*') && (last != '?'))
            {
                tmptest += '*';
            }
            return tmptest.ToUpper();
        }

        private bool do_search(TreeNodeCollection nodes, string test, int lastpos)
        {

            bool ret = false, single = (this.ENdim_elements.SelectionMode == TreeViewSelectionMode.SingleSelect);
            int i, nsize = nodes.Count;
            JNode node;
            string tmptest = addstar(test).ToUpper();
            int pos = lastpos;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                pos++;
                if (check_reg_exp(node.Text.ToUpper(), tmptest))
                {
                    if (!single || (last_search_pos < pos))
                    {
                        ENdim_elements.SelectNode(node);
                        node.EnsureVisible();
                        //CDNM: node.Select();
                        this.foundsearch = true;
                        last_search_pos = pos;
                        if (single)
                        {
                            ret = true;
                            break;
                        }
                    }
                }
                //  JMM: 09-17-13
                if (/* node.IsExpanded && */ (node.Nodes.Count > 0))
                {
                    ret =this.do_search(node.Nodes, test, pos);
                }
                if (ret)
                {
                    break;
                }
            }
            return ret;
        }

        private void do_EnButton_search()
        {
            this.foundsearch = false;

            if (this.ENinput_search.Text.Length > 0)
            {

                TreeNodeCollection Elems = this.ENdim_elements.Nodes;

                foreach (TreeNode Element in Elems)
                {
                    if (!check_shift())
                    {
                        ENdim_elements.SelectNode(Element, false);
                        //CDNM: Element.Deselect();
                        this.do_gselect(Element.Nodes, SEL_NONE);
                    }
                }
                this.do_search(Elems, this.ENinput_search.Text, -1);

            }

            if (!this.foundsearch)
            {
                string mess = ResourceInitializer.Replace(ResourceInitializer.TEXT_DIMELEMENT_NOT_FOUND, new object[] { this.ENinput_search.Text, this.currentdim });
                System.Windows.Forms.MessageBox.Show(mess);
            }

            this.ENdim_elements.Focus();
        }

        private void ENbutton_search_Click(object sender, System.EventArgs e)
        {
            do_EnButton_search();
        }

        private void do_resetFromAttributes(TreeNode Element)
        {
            Element.Text = ((ElementInfo)this.dimelems[Element.Tag]).Name;
            int j, nsize2 = Element.Nodes.Count;
            for (j = 0; j < nsize2; j++)
            {
                do_resetFromAttributes(Element.Nodes[j]);
            }
        }

        private void resetFromAttributes()
        {
            TreeNodeCollection Elems = this.ENdim_elements.Nodes;
            int i, nsize = this.ENdim_elements.Nodes.Count;

            for (i = 0; i < nsize; i++)
            {
                do_resetFromAttributes(Elems[i]);
            }
        }

        private void getAttributesvalues(string db, string dimension, string Attribute)
        {

            System.Collections.Specialized.StringDictionary anames = new System.Collections.Specialized.StringDictionary();
            string ename, avalue;
            GetDataExportOptions opts = new GetDataExportOptions();

            string[][] dimelements = new String[2][];
            dimelements[0] = new string[1];
            dimelements[0][0] = Attribute;

            int i, count =  this.elnames.Length;

            ArrayList al = new ArrayList();

            for (i = 0; i < count; i++)
            {
                if (!String.IsNullOrEmpty(this.elnames[i]))
                {
                    al.Add(this.elnames[i]);
                }
            }

            dimelements[1]  = (string[])al.ToArray(typeof(string));

            opts.Filter.CmpOp1 = CompareOp.CompareOpTRUE;
            opts.Filter.Value1.Type = CellValueType.CellValueTypeDouble;
            opts.Filter.Value1.Value.DblValue = 0;
            opts.Filter.AndOr12 = BoolOp.BoolOpAND;
            opts.Filter.CmpOp2 = CompareOp.CompareOpTRUE;
            opts.Filter.Value2.Type = CellValueType.CellValueTypeDouble;
            opts.Filter.Value2.Value.DblValue = 0;

            opts.IngoreEmptyCells = false;
            opts.BaseElementsOnly = false;

            opts.LastCoordinates = new String[0];
            opts.NumDatasets = (uint)this.elnames.Length;
            Dataset[] dsa = null;
            Dataset ds;

            dsa = this.currConn.GetDataExport(db, this.attrib_cube, dimelements, opts);

            int dsasize = dsa.Length;

            for (i = 0; i < dsasize; i++)
            {
                ds = dsa[i];
                ename = ds.Coordinates[1];
                if (ds.Value.Type == CellValueType.CellValueTypeDouble)
                {
                    avalue = ds.Value.Value.DblValue.ToString();
                }
                else
                {
                    avalue = ds.Value.Value.StrValue;
                }

                anames[ename] = avalue;
            }

            this.dattribs[Attribute] = anames;
        }

        private void Check4Attributesvalues(string db, string dimension, string Attribute)
        {
            if (!this.dattribs.ContainsKey(Attribute))
            {
                getAttributesvalues(db, dimension, Attribute);
            }
        }

        private void do_ApplyAttributes(TreeNode Element, System.Collections.Specialized.StringDictionary anames)
        {
            string ename = ((ElementInfo)this.dimelems[Element.Tag]).Name;
            string newname = anames[ename];

            if ((newname == null) ||(newname.Trim() == ""))
            {
                newname = ename;
            }
            
            Element.Text = newname;

            int j, nsize2 = Element.Nodes.Count;
            for (j = 0; j < nsize2; j++)
            {
                do_ApplyAttributes(Element.Nodes[j], anames);
            }
        }

        private void ApplyAttributes(string db, string dimension, string Attribute)
        {
            Check4Attributesvalues(db, dimension, Attribute);

            System.Collections.Specialized.StringDictionary anames = (System.Collections.Specialized.StringDictionary)dattribs[Attribute];

            TreeNodeCollection Elems = this.ENdim_elements.Nodes;
            int i, nsize = this.ENdim_elements.Nodes.Count;

            for (i = 0; i < nsize; i++)
            {
                TreeNode Element = Elems[i];
                do_ApplyAttributes(Element, anames);
            }
        }

        private void getAttributes(string db, string dimension)
        {
            this.ENattributes.Items.Clear();
            GC.Collect();

            if (this.currConn.GetDimensionType(db, dimension) == DimensionType.NormalDimension)
            {
                AttributeHelper.checkattributes(this.currConn, db, dimension, ref this.attrib_cube, ref this.ENattributes);
            }
            else
            {
                this.ENattributes.Visible = false;
            }
        }


        private void ENattributes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.ENattributes.SelectedIndex > 0)
            {
                this.ApplyAttributes(this.currdb, this.currentdim, (string)this.ENattributes.Items[this.ENattributes.SelectedIndex]);
            }
            else
            {
                this.resetFromAttributes();
            }
        }
        
        private void do_special_selection(TreeNodeCollection nodes, int level, int expected_level)
        {
            int i, nsize = nodes.Count;
            JNode node;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if ((expected_level == 0) && (node.Nodes.Count == 0))
                {
                    ENdim_elements.SelectNode(node);
                    //CDNM: node.Select(false);
                }
                else
                {
                    if (level == expected_level)
                    {
                        ENdim_elements.SelectNode(node);
                        //CDNM: node.Select(false);
                    }
                    else
                    {
                        if (node.IsExpanded && (node.Nodes.Count > 0))
                        {
                            this.do_special_selection(node.Nodes, level + 1, expected_level);
                        }
                    }
                }
            }
        }

        private void prepare_special_selection(int expected_level)
        {
            try
            {
                TreeNodeCollection Elems = this.ENdim_elements.Nodes;

                if (Elems.Count > 0)
                {
                    if (!check_shift())
                    {
                        this.do_gselect(Elems, SEL_NONE);
                    }

                    this.do_special_selection(Elems, 1, expected_level);
                    this.ENdim_elements.Focus();
                }

            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error special Selection", e);
            }
        }
        
        private void ENbutton_1_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(1);
        }

        private void ENbutton_2_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(2);
        }

        private void ENbutton_3_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(3);
        }

        private void ENbutton_4_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(4);
        }

        private void ENbutton_5_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(5);
        }

        private void ENbutton_B_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(0);
        }

        private void do_branch(TreeNodeCollection nodes)
        {
            int i, nsize = nodes.Count;
            JNode node;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if (node.IsExpanded && node.IsSelected && (node.Nodes.Count > 0))
                {
                    foreach (JNode childnode in node.Nodes)
                    {
                        ENdim_elements.SelectNode(node);
                        //CDNM: childnode.Select(false);
                    }

                }
                if (node.Nodes.Count > 0)
                {
                    this.do_branch(node.Nodes);
                }

            }
        }

        private void ENbutton_branch_Click(object sender, System.EventArgs e)
        {
            this.do_branch(this.ENdim_elements.Nodes);
            this.ENdim_elements.Focus();
        }

        private void ENinput_search_TextChanged(object sender, EventArgs e)
        {
            this.last_search_pos = -1;
        }


        private void ENdim_elements_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == (int)System.Windows.Forms.Keys.F3)
            {
                e.Handled = true;
                do_EnButton_search();                
            }
        }

	}
}
