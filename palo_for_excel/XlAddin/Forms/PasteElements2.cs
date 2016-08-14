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
//  JMM 09-03-14 added select distinct nodes
//  JMM 03-20-14 replaced DotNetMagic TreeControl with MultiSelectTreeView
//  JMM 09-17-13 replaced Node with JNode to correct Tag/Key definition
//  JMM 09-17-13 DimensionListDimElements is now DimensionListElements

using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using JControls;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Forms.Controls;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
    {
    [ComVisible(false)]
    public partial class PasteElements2 : Form
    {
        private class PasteHelper : object, IComparable
        {
            public string currname;
            public string origname;
            public string alias;
            public bool bold;
            public string pfad;
            public bool selected;
            public uint indent;

            public PasteHelper(string currname, string origname, string alias, bool bold, string pfad, uint indent)
            {
                this.currname = currname;
                this.origname = origname;
                this.bold = bold;
                this.pfad = pfad;
                this.indent = indent;
                this.alias = alias;
                this.selected = false;
            }

            public override string ToString()
            {
                return this.currname;
            }

            public int CompareTo(object obj)
            {
                return string.Compare(this.ToString(), obj.ToString());
            }

        };

        private const byte SEL_ALL = 0;
        private const byte SEL_NONE = 1;
        private const byte SEL_INVERT = 2;
        private const byte SEL_DISTINCT = 3;

        private const byte MODE_NORM = 0;
        private const byte MODE_SEL = 1;

        private const string PASTEELEMENTS = "PasteElements";

        private byte mode = MODE_NORM;

        private bool definition_order = true;

        private int max_exp_level = 0;
        private bool foundsearch;
        private int listboxoffset = 0;
        private int listboxoffset2 = 0;
        private string olddim = "";
        private string curdb = "";
        private string curdim = "";
        private string curServerName = "";
        private string curAttribute = "";
        private bool automatic_collaps = false;
        private bool automatic_expand = false;
        private bool automatic_selection = false;
        private bool dont_get_element = false;
        private bool is_doublclick = false;
        private ArrayList ElemList = new ArrayList();
        private ArrayList Optionen = new ArrayList();
        private Size oldsize = new Size(0, 0);
        private Connection currConn = null;
        private int rcount = 1;
        private int ccount = 1;
        private bool IsPageElement = false;
        private Hashtable dimelems0 = new Hashtable();
        private Hashtable dimelems2 = new Hashtable();
        private Hashtable dimattribs = new Hashtable();

        private string attrib_cube = "";

        private byte FilterType = GeneralConst.FILTER_DATA;

        private ConnComboBox PDserverlist = null;

        //  JMM 03-20-14
        private System.Collections.Generic.HashSet<string> distinct;
        private Color btnDistinctColor1, btnDistinctColor2 = SystemColors.ControlDark;
        private void resetDistinct() {PDbutton_distinct.BackColor = btnDistinctColor1;}


        public PasteElements2()
            {
            InitializeComponent();

            //
            // Add any constructor code after InitializeComponent call
            //
            this.PDlabel_choose_server.Text = ResourceInitializer.TEXT_CHOOSE_SERVER_DB;
            this.PDlabel_picklist.Text = ResourceInitializer.TEXT_ELEMENTS2PASTED;
            this.PDadvanced.Text = ResourceInitializer.TEXT_SHOW_SEL_TOOL;
            this.PDlabel_tip.Text = ResourceInitializer.TEXT_TIP_SHIFT;
            this.Text = ResourceInitializer.TEXT_PASTE_ELEMENTS_TITLE;
            this.PDlabel_alias.Text = ResourceInitializer.TEXT_ALIAS;
            this.PDlabel_alias_format.Text = ResourceInitializer.TEXT_ALIAS_FORMAT;
            this.PDradio_con.Text = ResourceInitializer.Replace(ResourceInitializer.TEXT_VAR_INSERT, new object[] { ResourceInitializer.TEXT_SERVER + "/" + ResourceInitializer.TEXT_DATABASE + " (" + ResourceInitializer.TEXT_CONNECTION + ")" });
            this.PDradio_cube.Text = ResourceInitializer.Replace(ResourceInitializer.TEXT_VAR_INSERT, new object[] { ResourceInitializer.TEXT_CUBE_NAME });
            this.PDradio_dims.Text = ResourceInitializer.Replace(ResourceInitializer.TEXT_VAR_INSERT, new object[] { ResourceInitializer.TEXT_DIMENSION_NAMES });

            btnDistinctColor1 = PDbutton_distinct.BackColor;

            string elementname = ResourceInitializer.TEXT_ELEMENT_NAME;
            string alias = ResourceInitializer.TEXT_ALIAS;
            string[] formatitems = new string[8];

            formatitems[0] = alias;
            formatitems[1] = elementname;
            formatitems[2] = elementname + " - " + alias;
            formatitems[3] = alias + " - " + elementname;
            formatitems[4] = elementname + " (" + alias + ")";
            formatitems[5] = alias + " (" + elementname + ")";
            formatitems[6] = elementname + " " + alias;
            formatitems[7] = alias + " " + elementname;

            this.PDaliasformats.Items.AddRange(formatitems);

            this.PDPageDBElements.Title = ResourceInitializer.TEXT_DATABASE_ELEMENTS;
            this.PDPageDimElements.Title = ResourceInitializer.TEXT_DIM_ELEMENTS;

            this.PDdbelements.Text = ResourceInitializer.Replace(ResourceInitializer.TEXT_VAR_INSERT, new object[] { ResourceInitializer.TEXT_DATABASE_ELEMENTS});

            this.listboxoffset = this.PDpanel_bottom_right.Top - this.PDselected_items.Top - this.PDselected_items.Height;
            this.listboxoffset2 = this.PDPanelMeta2.Top + this.PDPanelMeta2.Height - this.PDcube_dims.Top - this.PDcube_dims.Height;

            #if NOTUSED                         // CDNM Only:
            this.PDdim_elements.ImageGapLeft = 1;
            this.PDdim_elements.ImageGapRight = 1;
            this.PDdim_elements.GroupBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDdim_elements.GroupSelectedBackColor = ResourceInitializer.FormStdHighLightColor;
            this.PDdim_elements.GroupSelectedNoFocusBackColor = this.PDdim_elements.GroupSelectedBackColor;
            #endif

            this.change_buttons();

            this.PDTabPages.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDadvancedpanel.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDPageDimElements.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDlabel_tip.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDlabel_alias_format.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDlabel_alias.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDaliasformats.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDattributes.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDPageDBElements.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDCubes.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.BackColor = ResourceInitializer.FormStdBackgroundColor;

            this.PDdim_elements.AfterExpand += new TreeViewEventHandler(this.PDdim_elements_AfterExpand);
            this.PDdim_elements.BeforeExpand += new TreeViewCancelEventHandler(this.PDdim_elements_BeforeExpand);
            this.PDdim_elements.AfterCollapse += new TreeViewEventHandler(this.PDdim_elements_AfterCollapse);
            this.PDdim_elements.AfterSelect += new TreeViewEventHandler(this.PDdim_elements_AfterSelect);
            this.PDdim_elements.AfterDeselect += new TreeViewEventHandler(this.PDdim_elements_AfterDeselect);
            this.PDdim_elements.DoubleClick += new System.EventHandler(this.PDdim_elements_DoubleClick);
            this.PDselected_items.SelectedIndexChanged += new System.EventHandler(this.PDselected_items_SelectedIndexChanged);

            this.PDselected_items.DoubleClick += new System.EventHandler(this.PDselected_items_DoubleClick);
            this.PDselected_items.KeyDown += new KeyEventHandler(this.PDselected_items_KeyDown);
            this.PDadvanced.CheckedChanged += new System.EventHandler(this.PDadvanced_CheckedChanged);
            this.PDattributes.SelectedIndexChanged += new System.EventHandler(this.PDattributes_SelectedIndexChanged);
            this.PDaliasformats.SelectedIndexChanged += new System.EventHandler(this.PDformats_SelectedIndexChanged);
            this.oldsize = this.Size;
            this.Resize += new System.EventHandler(this.frmPasteDim_Resize);

            this.PDCubes.SelectedIndexChanged += new System.EventHandler(this.PDCubes_SelectedIndexChanged);
            this.PDcube_dims.SelectedIndexChanged += new System.EventHandler(this.PDcube_dims_SelectedIndexChanged);

            this.PDbutton_user.Visible = true;
            this.PDbutton_data.Visible = true;
            this.PDbutton_attr.Visible = true;
            this.PDbutton_data.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;

            int[] tmpProps = RegUtils.GetFormProperties(PASTEELEMENTS);

            if ((tmpProps[0] != -1) || (tmpProps[1] != -1))
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
            }
            
            //  JMM 03-20-14 Select page, advanced search always set
            this.PDTabPages.SelectedTab = PDTabPages.TabPages[0];
            this.PDTabPages.TabPages[0].Focus();
            this.PDadvanced.Checked = true;
            this.PDadvanced_CheckedChanged(this, EventArgs.Empty);
        }


        private void change_buttons()
        {

            this.PDbutton_revers_sort.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_sort.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_clear.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_1.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_2.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_3.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_4.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_5.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_B.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_cancel.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_all.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_branch.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_invert.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_distinct.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_search.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;

            this.PDbutton_horizontal.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_vertical.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_all.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_meta_horizontal.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_meta_cancel.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_meta_vertical.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_db_horizontal.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_db_cancel.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PDbutton_db_vertical.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;

            this.PDbutton_definition_order.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_expand_all.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_expand_all.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_expand_all.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_expand_all.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_collaps_all.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_collaps_all.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_collaps_all.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_collaps_all.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_down.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_down.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_down.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_down.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_up.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_up.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_up.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_up.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_add.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_add.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_add.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_add.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_remove.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_remove.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_remove.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_remove.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;

            this.PDbutton_horizontal.Text = ResourceInitializer.BUTTON_HPASTE;
            this.PDbutton_vertical.Text = ResourceInitializer.BUTTON_VPASTE;
            this.PDbutton_cancel.Text = ResourceInitializer.BUTTON_CANCEL;
            this.PDbutton_revers_sort.Text = ResourceInitializer.BUTTON_SORT_DOWN;
            this.PDbutton_sort.Text = ResourceInitializer.BUTTON_SORT_UP;
            this.PDbutton_clear.Text = ResourceInitializer.BUTTON_CLEAR_LIST;
            this.PDbutton_all.Text = ResourceInitializer.BUTTON_SELECT_ALL;
            this.PDbutton_branch.Text = ResourceInitializer.BUTTON_SELECT_BRANCH;
            //          this.PDbutton_none.Text = ResourceInitializer.BUTTON_SELECT_NONE;
            this.PDbutton_invert.Text = ResourceInitializer.BUTTON_SELECT_INVERT;
            this.PDbutton_search.Text = ResourceInitializer.BUTTON_SEARCH_SELECT;
            this.PDbutton_meta_cancel.Text = ResourceInitializer.BUTTON_CANCEL;
            this.PDbutton_meta_horizontal.Text = ResourceInitializer.BUTTON_HPASTE;
            this.PDbutton_meta_vertical.Text = ResourceInitializer.BUTTON_VPASTE;

            try
            {
                this.PDbutton_up.ButtonImage = (Image)ResourceInitializer.IconUp;
                this.PDbutton_up.RolloverImage = (Image)ResourceInitializer.IconUpH;
                this.PDbutton_add.ButtonImage = (Image)ResourceInitializer.IconRight;
                this.PDbutton_add.RolloverImage = (Image)ResourceInitializer.IconRightH;
                this.PDbutton_remove.ButtonImage = (Image)ResourceInitializer.IconLeft;
                this.PDbutton_remove.RolloverImage = (Image)ResourceInitializer.IconLeftH;
                this.PDbutton_down.ButtonImage = (Image)ResourceInitializer.IconDown;
                this.PDbutton_down.RolloverImage = (Image)ResourceInitializer.IconDownH;
                this.PDbutton_horizontal.Image = (Image)ResourceInitializer.IconPasteHorizontal;
                this.PDbutton_vertical.Image = (Image)ResourceInitializer.IconPasteVertical;
                this.PDbutton_data.ButtonImage = (Image)ResourceInitializer.IconToggleCube;
                this.PDbutton_data.RolloverImage = (Image)ResourceInitializer.IconToggleCubeH;
                this.PDbutton_attr.ButtonImage = (Image)ResourceInitializer.IconToggleAttribute;
                this.PDbutton_attr.RolloverImage = (Image)ResourceInitializer.IconToggleAttributeH;
                this.PDbutton_user.ButtonImage = (Image)ResourceInitializer.IconToggleUser;
                this.PDbutton_user.RolloverImage = (Image)ResourceInitializer.IconToggleUserH;
                this.PDbutton_meta_horizontal.Image = (Image)ResourceInitializer.IconPasteHorizontal;
                this.PDbutton_meta_vertical.Image = (Image)ResourceInitializer.IconPasteVertical;
                this.PDbutton_expand.ButtonImage = (Image)ResourceInitializer.IconExpand;
                this.PDbutton_expand.RolloverImage = (Image)ResourceInitializer.IconExpandH;
                this.PDbutton_collaps.ButtonImage = (Image)ResourceInitializer.IconCollapse;
                this.PDbutton_collaps.RolloverImage = (Image)ResourceInitializer.IconCollapseH;
                this.PDbutton_expand_all.ButtonImage = (Image)ResourceInitializer.IconExpandAllButton;
                this.PDbutton_expand_all.RolloverImage = (Image)ResourceInitializer.IconExpandAllButtonH;
                this.PDbutton_collaps_all.ButtonImage = (Image)ResourceInitializer.IconCollapseAllButton;
                this.PDbutton_collaps_all.RolloverImage = (Image)ResourceInitializer.IconCollapseAllButtonH;
                this.PDbutton_definition_order.ButtonImage = (Image)ResourceInitializer.IconShowHierarchyButtonP;
                this.PDbutton_definition_order.RolloverImage = this.PDbutton_definition_order.ButtonImage;
            }
            catch
            { }

            this.PDbutton_expand.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_collaps.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_expand_all.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_collaps_all.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_definition_order.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_up.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_add.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_remove.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_down.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.PDbutton_user.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_data.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDbutton_attr.ButtonColor = ResourceInitializer.FormStdBackgroundColor;

            this.PDbutton_expand.Click += new System.EventHandler(this.PDbutton_expand_Click);
            this.PDbutton_expand_all.Click += new System.EventHandler(this.PDbutton_expand_all_Click);
            this.PDbutton_collaps.Click += new System.EventHandler(this.PDbutton_collaps_Click);
            this.PDbutton_collaps_all.Click += new System.EventHandler(this.PDbutton_collaps_all_Click);
            this.PDbutton_up.Click += new System.EventHandler(this.PDbutton_up_Click);
            this.PDbutton_remove.Click += new System.EventHandler(this.PDbutton_remove_Click);
            this.PDbutton_add.Click += new System.EventHandler(this.PDbutton_add_Click);
            this.PDbutton_down.Click += new System.EventHandler(this.PDbutton_down_Click);
            this.PDbutton_sort.Click += new System.EventHandler(this.PDbutton_sort_Click);
            this.PDbutton_revers_sort.Click += new System.EventHandler(this.PDbutton_revers_sort_Click);
            this.PDbutton_horizontal.Click += new System.EventHandler(this.PDbutton_horizontal_Click);
            this.PDbutton_vertical.Click += new System.EventHandler(this.PDbutton_vertical_Click);
            this.PDbutton_cancel.Click += new System.EventHandler(this.PDbutton_cancel_Click);
            this.PDbutton_all.Click += new System.EventHandler(this.PDbutton_all_Click);
            this.PDbutton_branch.Click += new System.EventHandler(this.PDbutton_branch_Click);
            //          this.PDbutton_none.Click += new System.EventHandler(this.PDbutton_none_Click);
            this.PDbutton_invert.Click += new System.EventHandler(this.PDbutton_invert_Click);
            this.PDbutton_1.Click += new System.EventHandler(this.PDbutton_1_Click);
            this.PDbutton_2.Click += new System.EventHandler(this.PDbutton_2_Click);
            this.PDbutton_3.Click += new System.EventHandler(this.PDbutton_3_Click);
            this.PDbutton_4.Click += new System.EventHandler(this.PDbutton_4_Click);
            this.PDbutton_5.Click += new System.EventHandler(this.PDbutton_5_Click);
            this.PDbutton_B.Click += new System.EventHandler(this.PDbutton_B_Click);
            this.PDbutton_clear.Click += new System.EventHandler(this.PDbutton_clear_Click);
            this.PDbutton_search.Click += new System.EventHandler(this.PDbutton_search_Click);
            this.PDbutton_data.Click += new System.EventHandler(this.PDbutton_data_Click);
            this.PDbutton_attr.Click += new System.EventHandler(this.PDbutton_attr_Click);
            this.PDbutton_user.Click += new System.EventHandler(this.PDbutton_user_Click);
            this.PDbutton_meta_cancel.Click += new System.EventHandler(this.PDbutton_meta_cancel_Click);
            this.PDbutton_meta_horizontal.Click += new System.EventHandler(this.PDbutton_meta_horizontal_Click);
            this.PDbutton_meta_vertical.Click += new System.EventHandler(this.PDbutton_meta_vertical_Click);
            this.PDbutton_definition_order.Click += new System.EventHandler(this.PDbutton_definition_order_Click);

        }

        private string getCurrdim()
        {
            string dim = "";
            TreeNodeCollection nodes = this.PDdim_elements.Nodes;
            JNode node;
            int i, nsize = nodes.Count;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if (node.IsExpanded)
                {
                    dim = node.Text;
                    break;
                }
            }

            return dim;
        }

        static bool al_same_content(ArrayList a, ArrayList b)
        {
            bool ret = false;
            int anzahl = a.Count;

            if (b.Count == anzahl)
            {
                int i = 0;

                while ((i < anzahl) && ((string)a[i] == (string)b[i])) i++;
                if (i == anzahl) ret = true;
            }

            return ret;
        }

        static JNode look4node(string name, ArrayList al)
        {
            JNode ret = null;
            JNode node;
            int i, nsize = al.Count;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)al[i];
                if (node.Text == name)
                {
                    ret = node;
                    break;
                }
            }
            return ret;
        }

        private void check4pl(TreeNodeCollection nodes, ArrayList pl, ref ArrayList al, ref ArrayList al2)
        {
            TreeNodeCollection childs;
            JNode node;
            int i, nsize = nodes.Count;
            if (pl.Count > 0)
            {
                for (i = 0; i < nsize; i++)
                {
                    node = (JNode)nodes[i];
                    childs = node.Nodes;
                    if (pl.Contains(node.Text))
                    {
                        JNode tmpnode = (JNode)node.Parent;
                        do
                        {
                            if (tmpnode.IsExpanded)
                            {
                                break;
                            }
                            else
                            {
                                tmpnode.Expand();
                                //CDNM: tmpnode.Expanded = true;
                            }
                            tmpnode = (JNode)tmpnode.Parent;
                        }
                        while (tmpnode != null);
                        PDdim_elements.SelectNode(node);
                        //CDNM: node.Select(false);
                        pl.Remove(node.Text);
                        al.Add(node.Text);
                        al2.Add(node);
                    }

                    if ((pl.Count > 0) && (childs.Count > 0))
                    {
                        this.check4pl(childs, pl, ref al, ref al2);
                    }

                    if (pl.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        private bool check4pl2(TreeNodeCollection nodes, string dimelement)
        {
            bool ret = false;
            JNode node;
            int i, nsize = nodes.Count;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if ((node.Text == dimelement) && PDdim_elements.IsNodeSelected(node))
                //if ((node.Text == dimelement) && (node.IsSelected))
                {
                    if (node.IsExpanded) node.Collapse(); else node.Expand();
                    ret = true;
                    break;
                }
                else
                {
                    if (node.Nodes.Count > 0)
                    {
                        ret = this.check4pl2(node.Nodes, dimelement);
                    }
                }
            }
            return ret;
        }

        private string getpath(JNode element)
        {
            Hashtable dimelems = null;
            SetDimeelems(ref dimelems);
            ElementInfo ei = (ElementInfo)dimelems[element.Tag];
            string path = ((ElementInfo)dimelems[element.Tag]).Name;
            JNode node = element;
            while (node.Parent.Parent != null)
            {
                node = (JNode)node.Parent;
                path = ((ElementInfo)dimelems[node.Tag]).Name + GeneralConst.PATH_DELIMTER + path;
            }

            return path;
        }

        private bool check4pl6(TreeNodeCollection nodes, string dimelement, string pfad)
        {
            bool ret = false;
            JNode node;
            int i, nsize = nodes.Count;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if (ret)
                {
                    break;
                }
                if (PDdim_elements.IsNodeSelected(node) && (node.Text == dimelement) && (this.getpath(node) == pfad))
                {
                    if (node.IsExpanded) node.Collapse(); else node.Expand();
                    ret = true;
                    break;
                }
                else
                {
                    if ((node.Nodes.Count > 0) && !ret)
                    {
                        ret = this.check4pl6(node.Nodes, dimelement, pfad);
                    }
                }
            }
            return ret;
        }

        private void check4old2(TreeNodeCollection nodes, JNode old)
        {
            JNode node;
            int i, j, nsize = nodes.Count, nsize2;

            Hashtable dimelems = null;
            SetDimeelems(ref dimelems);
            ElementInfo el = (ElementInfo)dimelems[old.Tag];
            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if (node.Text == el.Name)
                {
                    if (old.IsExpanded)
                    {
                        node.Expand();
                        //CDNM: node.Expanded = true;
                        if (node.Nodes.Count > 0)
                        {
                            nsize2 = old.Nodes.Count;
                            for (j = 0; j < nsize2; j++)
                            {
                                this.check4old2(node.Nodes, (JNode)old.Nodes[j]);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void check4old1(TreeNodeCollection nodes, JNode old)
        {
            if (old.Nodes.Count > 0)
            {
                JNode node;
                int i, j, nsize = nodes.Count, nsize2;

                for (i = 0; i < nsize; i++)
                {
                    node = (JNode)nodes[i];
                    if (node.Text == old.Text)
                    {
                        if (old.IsExpanded)
                        {
                            node.Expand();
                        }

                        if (node.Nodes.Count > 0)
                        {
                            nsize2 = old.Nodes.Count;

                            for (j = 0; j < nsize2; j++)
                            {
                                this.check4old2(node.Nodes, (JNode)old.Nodes[j]);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void check_state_button_all()
        {
            bool expenabled = false;
            bool colenabled = false;

            TreeNodeCollection nodes = this.PDdim_elements.Nodes;
            JNode node;
            int i, nsize = nodes.Count;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if (node.IsExpanded)
                {
                    expenabled = true;
                    colenabled = true;
                    break;
                }
            }

            if (this.PDdim_elements.Nodes.Count == 1)
            {
                expenabled = true;
            }
            this.PDbutton_expand_all.Enabled = expenabled;
            this.PDbutton_collaps_all.Enabled = colenabled;
            this.PDformats_visible();
        }

        private void check_state_button()
        {
            bool enabled = (this.PDselected_items.SelectedItems.Count > 0);
            this.PDbutton_up.Enabled = enabled;
            this.PDbutton_down.Enabled = enabled;
            this.PDbutton_remove.Enabled = enabled;
            this.PDbutton_add.Enabled = (this.get_sel_node_counts() > 0);
        }

        private void check_state_button_select()
        {
            this.PDbutton_2.Enabled = this.definition_order;
            this.PDbutton_3.Enabled = this.definition_order;
            this.PDbutton_4.Enabled = this.definition_order;
            this.PDbutton_5.Enabled = this.definition_order;
            this.PDbutton_branch.Enabled = this.definition_order;
        }

        private bool check4elem(string element, string pfad, ref ArrayList liste)
        {
            bool ret = false;
            int i = 0;
            object[] o;
            while (i < liste.Count)
            {
                o = (object[])(liste[i]);
                if (((string)o[0] == element) && ((string)o[2] == pfad))
                {
                    ret = true;
                    liste.RemoveAt(i);
                    break;
                }
                i++;
            }
            return ret;
        }

        private void check4pl3(TreeNodeCollection nodes, ref ArrayList pl)
        {
            TreeNodeCollection childs;
            JNode node;
            int i, nsize = nodes.Count;

            if (pl.Count > 0)
            {
                for (i = 0; i < nsize; i++)
                {
                    node = (JNode)nodes[i];
                    childs = node.Nodes;
                    if (check4elem(node.Text, this.getpath(node), ref pl))
                    {
                        JNode tmpnode = (JNode)node.Parent;
                        do
                        {
                            if (tmpnode.IsExpanded)
                            {
                                break;
                            }
                            else
                            {
                                tmpnode.Expand();
                                //CDNM: tmpnode.Expanded = true;
                            }
                            tmpnode = (JNode)tmpnode.Parent;
                        }
                        while (tmpnode != null);
                        PDdim_elements.SelectNode(node);
                        //CDNM: node.Select(false);
                    }

                    if ((pl.Count > 0) && (childs.Count > 0))
                    {
                        this.check4pl3(childs, ref pl);
                    }

                    if (pl.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        private void check4pl4(TreeNodeCollection nodes, ref ArrayList pl)
        {
            TreeNodeCollection childs;
            JNode node;
            int i, nsize = nodes.Count;

            if (pl.Count > 0)
            {
                for (i = 0; i < nsize; i++)
                {
                    node = (JNode)nodes[i];
                    childs = node.Nodes;
                    if (!PDdim_elements.IsNodeSelected(node) && ((string)pl[0] == node.Text))
                    {
                        JNode tmpnode = (JNode)node.Parent;
                        do
                        {
                            if (tmpnode.IsExpanded)
                            {
                                break;
                            }
                            else
                            {
                                tmpnode.Expand();
                                //CDNM: tmpnode.Expanded = true;
                            }
                            tmpnode = (JNode)tmpnode.Parent;
                        }
                        while (tmpnode != null);
                        PDdim_elements.SelectNode(node);
                        //CDNM: node.Select(false);
                        pl.RemoveAt(0);
                    }

                    if ((pl.Count > 0) && (childs.Count > 0))
                    {
                        this.check4pl4(childs, ref pl);
                    }

                    if (pl.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        private void check4pl5(TreeNodeCollection nodes, ref ArrayList pl)
        {
            TreeNodeCollection childs;
            JNode node;
            int i, nsize = nodes.Count;

            if (pl.Count > 0)
            {
                for (i = 0; i < nsize; i++)
                {
                    node = (JNode)nodes[i];
                    childs = node.Nodes;
                    if (!PDdim_elements.IsNodeSelected(node) && pl.Contains(node.Text))
                    {
                        JNode tmpnode = (JNode)node.Parent;
                        do
                        {
                            if (tmpnode.IsExpanded)
                            {
                                break;
                            }
                            else
                            {
                                tmpnode.Expand();
                                //CDNM: tmpnode.Expanded = true;
                            }
                            tmpnode = (JNode)tmpnode.Parent;
                        }
                        while (tmpnode != null);
                        PDdim_elements.SelectNode(node);
                        //CDNM: node.Select(false);
                        pl.Remove(node.Text);
                    }

                    if ((pl.Count > 0) && (childs.Count > 0))
                    {
                        this.check4pl5(childs, ref pl);
                    }

                    if (pl.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        public void set_default()
        {
            //string olddim = "";
            this.mode = MODE_NORM;
            this.curAttribute = "";

            this.dont_get_element = true;
            int csrow = 1, cscol = 1, i, j, nsize;

            try
            {
                this.setCombo(-1);
                this.PDserverlist.SetItem();

                //this.olddim = olddim;

                string formula = "";

                this.curdb = this.PDserverlist.GetDatabase();

                if (!string.IsNullOrEmpty(this.curdb))
                {
                    this.get_elements();
                    this.get_cubes();

                    TreeNodeCollection Elems = this.PDdim_elements.Nodes;
                    JNode Element;

                    this.automatic_expand = true;

                    nsize = Elems.Count;
                    for (i = 0; i < nsize; i++)
                    {
                        Element = (JNode)Elems[i];

                        if (this.olddim == Element.Text)
                        {
                            Element.Expand();
                            //CDNM: Element.Expanded = true;
                            break;
                        }
                    }
                    this.automatic_expand = false;
                }

                string dummy = "";
                if (ExcelHelper.TestWithoutExcel) goto noexcel;
                ExcelHelper.SetExcelStatusbar(ResourceInitializer.STATUS_SCAN_SELECTION);

                ExcelHelper eH = new ExcelHelper();
                Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();

                Excel.Range eS = ExcelHelper.GetSelection();
                Excel.Range er = (Excel.Range)ws.UsedRange;


                int bCol = eS.Column;
                int bRow = eS.Row;
                string item = "";
                i = 0; j = 0;

                ArrayList ParamList = new ArrayList();

                this.rcount = eS.Rows.Count;
                this.ccount = eS.Columns.Count;

                cscol = this.ccount;
                csrow = this.rcount;

                if (cscol > er.Columns.Count - bCol + 1) cscol = er.Columns.Count - bCol + 1;
                if (csrow > er.Rows.Count - bRow + 1) csrow = er.Rows.Count - bRow + 1;

                if ((this.rcount == 1) || (this.ccount == 1))
                {
                    formula = eH.getFormulaFromSpreadsheet(bRow, bCol, ws);
                    for (i = 0; i < csrow; i++)
                    {
                        for (j = 0; j < cscol; j++)
                        {
                            item = eH.getItemFromSpreadsheet(bRow + i, bCol + j, ws);
                            if ((item.Length > 0) /*&& !ParamList.Contains(item)*/)
                            {
                                ParamList.Add(item);
                            }
                        }
                    }
                }

                if (ParamList.Count > 0)
                {
                    ArrayList pl = (ArrayList)ParamList.Clone();

                    pl.Sort();

                    if (!string.IsNullOrEmpty(this.curdb))
                    {
                        int count = pl.Count, k;
                        i = 0;
                        string[] elements = new String[count];

                        nsize = pl.Count;

                        for (k = 0; k < nsize; k++)
                        {
                            elements[i++] = (string)pl[k];
                        }

                        string dim = "";
                        try
                        {
                            dim = this.currConn.ElementDimension(this.curdb, elements, false);
                        }
                        catch
                        {
                            dim = "";
                        }

                        if (!String.IsNullOrEmpty(dim))
                        {
                            this.olddim = dim;
                        }
                        TreeNodeCollection Elems = this.PDdim_elements.Nodes;

                        this.automatic_expand = true;
                        JNode Element;
                        nsize = Elems.Count;

                        for (k = 0; k < nsize; k++)
                        {
                            Element = (JNode)Elems[k];
                            if (dim == Element.Text)
                            {
                                Element.Expand();
                                //CDNM: Element.Expanded = true;

                                ArrayList al = new ArrayList();
                                ArrayList al2 = new ArrayList();

                                if (/*(dim != this.getCurrdim()) && */ (Element.Nodes.Count > 0))
                                {
                                    this.check4pl(Element.Nodes, pl, ref al, ref al2/*, "",ref  ParamList*/);
                                    PDdim_elements.SelectNode(Element);
                                    //CDNM: Element.Select(false);
                                    //????: this.PDdim_elements.FocusNode = Element;
                                }

                                this.PDselected_items.Items.Clear();

                                if (!al_same_content(ParamList, al))
                                {
                                    nsize = ParamList.Count;

                                    for (k = 0; k < nsize; k++)
                                    {
                                        this.do_add_one(look4node((string)ParamList[k], al2));
                                    }
                                    this.do_gselect_click(SEL_NONE);
                                    break;
                                 }
                            }
                        }
                        this.automatic_expand = false;
                    }
                }

                if (formula.StartsWith("=PALO.ENAME(", true, CultureInfo.InvariantCulture))
                {
                    string olapdb = "";
                    string dim2 = "";
                    string olapdborig = "";
                    string dimorig = "";

                    olapdborig = eH.get_params(formula, 1, true);
                    olapdb = eH.DeEscapeDoubleQuote(eH.get_value(olapdborig, ws));

                    int pos = olapdb.IndexOf('/');
                    if (pos > -1)
                    {
                        olapdb = olapdb.Substring(pos + 1);
                    }

                    if (String.IsNullOrEmpty(this.curdb))
                    {
                        this.curdb = olapdb;
                    }

                    dimorig = eH.get_params(formula, 2, true);
                    dim2 = eH.DeEscapeDoubleQuote(eH.get_value(dimorig, ws));

                    if (!String.IsNullOrEmpty(dim2))
                    {
                        this.olddim = dim2;
                    }

                    dummy = eH.DeEscapeDoubleQuote(eH.get_params(formula, 6));

                }

noexcel:
                this.curdim = this.olddim;

                this.PDattributes.Items.Clear();

                if (!String.IsNullOrEmpty(this.curdb) && !String.IsNullOrEmpty(this.curdim))
                {
                    this.getAttributes(this.curdb, this.curdim);
                    if (!String.IsNullOrEmpty(dummy))
                    {
                        int acount = this.PDattributes.Items.Count;
                        for (i = 0; i < acount; i++)
                        {
                            if (String.Equals(dummy, this.PDattributes.Items[i].ToString(), StringComparison.InvariantCultureIgnoreCase))
                            {
                                this.PDattributes.SelectedIndex = i;
                                this.curAttribute = dummy;
                                break;
                            }
                        }

                    }
                }

                this.do_PDattributes_SelectedIndexChanged(false);
                this.PDformats_visible();
            }
            catch (Exception ex)
            {
                ErrorHandler.DisplayError("Error setting defaults!", ex);
            }
            finally
            {
                this.dont_get_element = false;
                this.PDselected_items_check();
                this.check_state_button_all();
                this.check_state_button();

                ExcelHelper.ResetExcelStatusbar();
            }


        }

        public void set_selection1(string dim, ArrayList elems)
        {
            string name;
            ArrayList pl = new ArrayList();
            int i, j, nsize = elems.Count, nsize2;

            for (i = 0; i < nsize; i++)
            {
                name = (string)(((object[])elems[i])[0]);
                //              if (!pl.Contains(name))
                //              {
                pl.Add(name);
                //              }
            }

            ArrayList ParamList = (ArrayList)pl.Clone();
            pl.Sort();

            TreeNodeCollection Elems = this.PDdim_elements.Nodes;
            JNode Element;
            this.automatic_expand = true;

            nsize = Elems.Count;
            for (i = 0; i < nsize; i++)
            {
                Element = (JNode)Elems[i];

                if (dim == Element.Text)
                {
                    Element.Expand();
                    //CDNM: Element.Expanded = true;

                    ArrayList al = new ArrayList();
                    ArrayList al2 = new ArrayList();

                    if (/*(dim != this.getCurrdim()) && */(Element.Nodes.Count > 0))
                    {
                        this.check4pl(Element.Nodes, pl, ref al, ref al2);
                        PDdim_elements.SelectNode(Element);
                        //CDNM: Element.Select(false);
                        //????: this.PDdim_elements.FocusNode = Element;
                    }

                    this.PDselected_items.Items.Clear();

                    if (!al_same_content(ParamList, al))
                    {
                        nsize2 = ParamList.Count;

                        for (j = 0; j < nsize2; j++)
                        {
                            this.do_add_one(look4node((string)ParamList[j], al2));
                        }
                        this.do_gselect_click(SEL_NONE);
                        break;
                    }
                }
            }
            this.automatic_expand = false;

        }

        public void set_selection2(string dim, ArrayList elems, string dimelem, string pfad)
        {
            ArrayList pl = (ArrayList)this.ElemList.Clone();
            TreeNodeCollection Elems = this.PDdim_elements.Nodes;
            JNode Element;
            int i, j, nsize = Elems.Count, nsize2;

            this.automatic_expand = true;

            for (i = 0; i < nsize; i++)
            {
                Element = (JNode)Elems[i];
                if (dim == Element.Text)
                {
                    Element.Expand();
                    //CDNM: Element.Expanded = true;

                    if (/*(dim != this.getCurrdim()) && */(Element.Nodes.Count > 0))
                    {
                        this.check4pl3(Element.Nodes, ref pl);
                        ArrayList pl2 = new ArrayList();
                        nsize2 = pl.Count;

                        for (j = 0; j < nsize2; j++)
                        {
                            pl2.Add((string)(((object[])pl[j])[0]));
                        }
                        this.check4pl4(Element.Nodes, ref pl2);
                        pl2.Sort();
                        this.check4pl5(Element.Nodes, ref pl2);
                        PDdim_elements.SelectNode(Element);
                        //CDNM: Element.Select(false);
                        //????: this.PDdim_elements.FocusNode = Element;
                    }

                    this.PDselected_items.Items.Clear();
                    this.automatic_expand = false;

                    if (!this.check4pl6(Element.Nodes, dimelem, pfad))
                    {
                        if (!this.check4pl2(Element.Nodes, dimelem))
                        {
                            ErrorHandler.ErrorPopup(ResourceInitializer.Replace(ResourceInitializer.TEXT_DIMELEMENT_NOT_FOUND, new object[] { dimelem, dim }), MessageBoxIcon.Warning);
                        }
                    }
                    break;
                }
            }
            this.automatic_expand = false;
        }

        public void set_selection(int serverid, string db, string dim, ref ArrayList elems, bool IsPageElement, string dimelem, string pfad, ref ArrayList Optionen)
        {
            string Attribute = "";
            this.mode = MODE_SEL;
            this.ElemList = elems;
            this.IsPageElement = IsPageElement;
            this.Optionen = Optionen;
            this.is_doublclick = !String.IsNullOrEmpty(pfad);

            this.PDTabPages.TabPages.Remove(this.PDPageDBElements);
            this.PDaliasformats.Visible = false;
            this.PDlabel_alias_format.Visible = false;
            this.PDdbelements.Visible = false;

            if (this.Optionen.Count > 0)
            {
                Attribute = (string)this.Optionen[0];
            }

            this.Optionen.Clear();

            if (this.IsPageElement)
            {
                PDdim_elements.SelectionMode = TreeViewSelectionMode.SingleSelect;
                //CDNM: this.PDdim_elements.SelectMode = SelectMode.Single;
                this.PDadvanced.Visible = false;
            }
            else
            {
                PDdim_elements.SelectionMode = TreeViewSelectionMode.MultiSelect;
                //CDNM: this.PDdim_elements.SelectMode = SelectMode.Multiple;
            }

            try
            {
                this.setCombo(serverid);

                this.PDserverlist.Enabled = false;
                this.curdb = db;
                this.olddim = dim;
                this.curdim = dim;

                this.PDserverlist.SetItem(this.PDserverlist.GetConnectionName(), db);

                this.get_elements(dim);

                TreeNodeCollection Elems = this.PDdim_elements.Nodes;
                JNode Element;
                int i, nsize = Elems.Count;

                this.automatic_expand = true;

                for (i = 0; i < nsize; i++)
                {
                    Element = (JNode)Elems[i];
                    if (this.getCurrdim() == Element.Text)
                    {
                        Element.Expand();
                        //CDNM: Element.Expanded = true;
                        break;
                    }
                }

                if (dimelem == "")
                {
                    set_selection1(dim, elems);
                }
                else
                {
                    set_selection2(dim, elems, dimelem, pfad);
                }

                this.automatic_expand = false;

                if (string.IsNullOrEmpty(this.curdim))
                {
                    this.curdim = this.getCurrdim();
                }

                getAttributes(this.curdb, this.curdim);

                if ((Attribute != "") && (this.mode == MODE_SEL))
                {
                    this.PDattributes.Text = Attribute;
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.DisplayError("Error setting selection!", ex);
            }
            finally
            {
                this.PDselected_items_check();
                this.check_state_button_all();
                this.check_state_button();
            }

            if (dimelem != "")
            {
                this.do_paste(0);
                //  JMM 03-20-14
                this.do_exit();
            }

        }

        private void do_exit()
        {
            this.do_exit(false);
        }

        private void do_exit(bool cancel)
        {
            RegUtils.SetFormProperties(PASTEELEMENTS, new int[4] { this.Left, this.Top, this.Width, this.Height });
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;

            if (this.mode == MODE_NORM)
            {
                this.olddim = this.getCurrdim();
                this.curdim = this.olddim;
                this.PDserverlist.SaveItem();
            }

            //  JMM 03-20-14
            TreeNodeCollection nodes = this.PDdim_elements.Nodes;
            JNode node = null;
            int nsize = nodes.Count;
            for (int i = 0; i < nsize; i++)
                {
                node = (JNode)nodes[i];
                if (node.IsExpanded)
                    {
                    olddim = node.Text;
                    break;
                    }
                }
            this.PDdim_elements.ClearNodes();           

            resetDistinct();
            this.PDbutton_cancel.ResetBackColor();
            if (!cancel)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }

        }

        private string getformat(int pdformatindex, string origname, string alias)
        {
            string format2 = origname;

            if (string.IsNullOrEmpty(alias.Trim()))
            {
                alias = origname;
            }

            switch (pdformatindex)
            {
                case 0:
                    format2 = alias;
                    break;

                case 1:
                    format2 = origname;
                    break;

                case 2:
                    format2 = origname + " - " + alias;
                    break;

                case 3:
                    format2 = alias + " - " + origname;
                    break;

                case 4:
                    format2 = origname + " (" + alias + ")";
                    break;

                case 5:
                    format2 = alias + " (" + origname + ")";
                    break;

                case 6:
                    format2 = origname + " " + alias;
                    break;

                case 7:
                    format2 = alias + " " + origname;
                    break;
            }

            return format2;
        }



        private void do_paste(int horizontal)
        {
            bool has_merged_Cells = false;

            //  JMM 03-20-14
            //this.do_exit();

            ListBox.ObjectCollection items;
            PasteHelper ph;

            bool frompicklist = true;

            if (this.PDselected_items.Items.Count == 0)
            {
                frompicklist = false;
                this.do_add_Click();
            }

            if (this.mode == MODE_NORM)
            {
                ExcelHelper eH = new ExcelHelper();
                Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();
                Excel.Range eS = ExcelHelper.GetSelection();

                Connect.InPaste = false;
                ExcelHelper.SetScreenUpdating(false);
                Excel.XlCalculation oldcalc = ExcelHelper.DisableAutomaticRecalc();

                items = this.PDselected_items.Items;

                int bCol = eS.Column, bRow = eS.Row, i, j, k, nsize, col = 1, row = 1, count = items.Count;

                Excel.Range er;
                string format = "";

                string database = this.PDserverlist.GetDatabase();

                if (count == 1)
                {
                    if (!string.IsNullOrEmpty(database))
                    {
                        try
                        {
                            ph = (PasteHelper)items[0];
                            er = eH.Create_Range(bRow, bCol, ws);
                            string formula = "=PALO.ENAME(" + '"' + this.PDserverlist.GetConnectionName() + "/" + database + '"' + "," + '"' + eH.EscapeDoubleQuote(this.getCurrdim()) + '"' + "," + '"' + eH.EscapeDoubleQuote(ph.origname) + '"' + ",1";

                            format = er.NumberFormat.ToString();

                            if (format.IndexOf(";;;") > 1)
                            {
                                eH.RemoveFormat(format);
                            }

                            if (format == "@")
                            {
                                er.NumberFormat = "General";
                            }

                            int index = PDattributes.SelectedIndex;

                            if (index > 0)
                            {
                                string att = (string)PDattributes.Items[index];
                                formula += ",\"\",\"" + att + "\"";

                                int pdformatindex = this.PDaliasformats.SelectedIndex;

                                if ((pdformatindex > -1) && (pdformatindex != 1))
                                {
                                    string formatname;
                                    string format2 = ph.currname;
                                    Random rand = new Random();

                                    if (string.IsNullOrEmpty(ws.CodeName))
                                    {
                                        formatname = ws.Name;
                                    }
                                    else
                                    {
                                        formatname = ws.CodeName;
                                    }

                                    formatname += "!__palo" + rand.Next(17, 1000000);

                                    formula += ",\"" + formatname + "\"";

                                    if (pdformatindex > 1)
                                    {
                                        format2 = this.getformat(pdformatindex, ph.origname, ph.alias);
                                    }

                                    format = "\"" + formatname + "\";;;\"" + format2 + "\"";

                                    int flen = 128;

                                    if (format.Length > flen)
                                    {
                                        format = format.Substring(0, flen) + "..." + '"';
                                    }

                                    er.NumberFormat = format;
                                }
                            }

                            formula += ")";

                            eH.AddFormulaToSpreadsheet(bRow, bCol, ws, formula, ph.bold);

                            if (format == "@")
                            {
                                er.NumberFormat = "@";
                            }
                        }
                        catch (System.Exception e)
                        {
                            ErrorHandler.DisplayError("Error setting Number Format =" + format, e);
                        }
                    }
                }
                else
                {
                    int count2 = this.ccount * horizontal + this.rcount * (1 - horizontal);
                    if ((count > count2) && (this.ccount * this.rcount > 1))
                    {
                        if (MessageBox.Show(ResourceInitializer.TEXT_RESTRICT_PASTE2CURR_SELECTION, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            count = count2;
                        }
                    }

                    try
                    {
                        i = 0;
                        int anzahl = items.Count, maxrow = GeneralConst.getMaxRow(), maxcol = GeneralConst.getMaxRow();

                        for (j = 0; j < anzahl; j++)
                        {
                            if (i >= count)
                            {
                                break;
                            }
                            row = bRow + (1 - horizontal) * i;
                            col = bCol + horizontal * i;

                            if ((row <= maxrow) && (col <= maxcol))
                            {
                                has_merged_Cells = eH.HasMergedCell(row, col, ws);
                                if (has_merged_Cells)
                                {
                                    ErrorHandler.ErrorPopup(ResourceInitializer.MESSAGE_MERGED_CELLS, MessageBoxIcon.Warning);
                                    break;
                                }
                                i++;
                            }
                        }
                    }
                    catch
                    {
                    }

                    if (!has_merged_Cells)
                    {
                        try
                        {
                            i = 0;

                            nsize = items.Count;
                            for (k = 0; k < nsize; k++)
                            {
                                if (i >= count)
                                {
                                    break;
                                }
                                row = bRow + (1 - horizontal) * i;
                                col = bCol + horizontal * i;

                                int maxrow = GeneralConst.getMaxRow(), maxcol = GeneralConst.getMaxRow();

                                if ((row <= maxrow) && (col <= maxcol))
                                {
                                    ph = (PasteHelper)(items[k]);

                                    er = eH.Create_Range(row, col, ws);
                                    format = er.NumberFormat.ToString();

                                    if (format.IndexOf(";;;") > 1)
                                    {
                                        eH.RemoveFormat(format);
                                    }

                                    if (format == "@")
                                    {
                                        er.NumberFormat = "General";
                                    }

                                    eH.AddItemRawToSpreadsheet(er, "'" + ph.currname, ph.bold);
                                    i++;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                ExcelHelper.SetCalculation(oldcalc);
                ExcelHelper.SetScreenUpdating(true);
                Connect.InPaste = true;
            }
            else
            {
                if (this.mode == MODE_SEL)
                {
                    this.Optionen.Clear();
                    this.Optionen.Add(frompicklist);

                    items = this.PDselected_items.Items;
                    try
                    {
                        this.ElemList.Clear();
                        int i, nsize = items.Count;
                        string Attribute = "";

                        if (this.PDattributes.SelectedIndex > 0)
                        {
                            Attribute = (string)this.PDattributes.Items[this.PDattributes.SelectedIndex];
                        }

                        this.Optionen.Add(Attribute);

                        for (i = 0; i < nsize; i++)
                        {
                            ph = (PasteHelper)(items[i]);

                            this.ElemList.Add(new object[] { ph.origname, ph.bold, ph.pfad, ph.currname });
                        }
                    }
                    catch (System.Exception e)
                    {
                        ErrorHandler.DisplayError("Error setting Element List!", e);
                    }
                }
            }

        }

        private void do_meta_paste(int horizontal)
        {
            //  JMM 03-20-14
            //this.do_exit();

            ArrayList items = new ArrayList();

            bool has_merged_Cells = false;


            int i, count;

            if (this.PDradio_con.Checked)
            {
                string db = this.PDserverlist.GetDatabase();

                if (!string.IsNullOrEmpty(db))
                {
                    items.Add(this.PDserverlist.GetConnectionName() + "/" + db);
                }
            }

            if (this.PDradio_cube.Checked)
            {
                items.Add(this.PDCubes.SelectedItem.ToString());
            }

            if (this.PDradio_dims.Checked)
            {
                count = PDcube_dims.SelectedItems.Count;
                for (i = 0; i < count; i++)
                {
                    items.Add(PDcube_dims.SelectedItems[i].ToString());
                }
            }

            ExcelHelper eH = new ExcelHelper();
            Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();
            Excel.Range eS = ExcelHelper.GetSelection();

            Connect.InPaste = false;
            ExcelHelper.SetScreenUpdating(false);
            Excel.XlCalculation oldcalc = ExcelHelper.DisableAutomaticRecalc();

            int bCol = eS.Column;
            int bRow = eS.Row;
            int j, k, nsize;
            int col = 1;
            int row = 1;

            count = items.Count;

            int count2 = this.ccount * horizontal + this.rcount * (1 - horizontal);
            if ((count > count2) && (this.ccount * this.rcount > 1))
            {
                if (MessageBox.Show(ResourceInitializer.TEXT_RESTRICT_PASTE2CURR_SELECTION, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    count = count2;
                }
            }

            try
            {
                i = 0;
                int anzahl = items.Count;
                for (j = 0; j < anzahl; j++)
                {
                    if (i >= count)
                    {
                        break;
                    }
                    row = bRow + (1 - horizontal) * i;
                    col = bCol + horizontal * i;

                    if ((row <= 65536) && (col <= 256))
                    {
                        has_merged_Cells = eH.HasMergedCell(bRow + (1 - horizontal) * i, bCol + horizontal * i, ws);
                        if (has_merged_Cells)
                        {
                            ErrorHandler.ErrorPopup(ResourceInitializer.MESSAGE_MERGED_CELLS, MessageBoxIcon.Warning);
                            break;
                        }
                        i++;
                    }
                }
            }
            catch
            {
            }

            if (!has_merged_Cells)
            {
                try
                {
                    i = 0;

                    string str;
                    nsize = items.Count;
                    for (k = 0; k < nsize; k++)
                    {
                        if (i >= count)
                        {
                            break;
                        }
                        row = bRow + (1 - horizontal) * i;
                        col = bCol + horizontal * i;

                        if ((row <= 65536) && (col <= 256))
                        {
                            str = (string)items[k];

                            eH.AddItemToSpreadsheet(bRow + (1 - horizontal) * i, bCol + horizontal * i, ws, str);
                            i++;
                        }
                    }
                }
                catch
                {
                }
            }
            ExcelHelper.SetCalculation(oldcalc);
            ExcelHelper.SetScreenUpdating(true);
            Apalo.XlAddin.Connect.InPaste = true;
        }

        static bool check_shift()
        {
            bool ret = false;
            if (((Control.ModifierKeys & Keys.Shift) == Keys.Shift) || ((Control.ModifierKeys & Keys.ShiftKey) == Keys.ShiftKey))
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

        private void do_search(TreeNodeCollection nodes, string test)
        {
            int i, nsize = nodes.Count;
            JNode node;
            string test2 = test.ToUpper();

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if (check_reg_exp(node.Text.ToUpper(), test2))
                {
                    PDdim_elements.SelectNode(node);
                    node.EnsureVisible();
                    //CDNM: node.Select(!this.foundsearch);
                    this.foundsearch = true;
                }
                if (node.Nodes.Count > 0)
                {
                    this.do_search(node.Nodes, test);
                }
            }
        }

        private void do_branch(TreeNodeCollection nodes)
        {
            int i, nsize = nodes.Count;
            JNode node;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if (node.IsExpanded && PDdim_elements.IsNodeSelected(node) && (node.Nodes.Count > 0))
                {
                    foreach (JNode childnode in node.Nodes)
                    {
                        PDdim_elements.SelectNode(childnode);
                        //CDNM: childnode.Select(false);
                    }

                }
                if (node.Nodes.Count > 0)
                {
                    this.do_branch(node.Nodes);
                }

            }
        }

        private void do_expand(TreeNodeCollection nodes)
        {
            this.automatic_expand = true;
            int i, nsize = nodes.Count;
            JNode node;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
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
            this.automatic_expand = false;
            this.check_state_button_all();
        }

        private void prepare_collaps(TreeNodeCollection nodes, int level)
        {
            int i, nsize = nodes.Count;
            JNode node;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
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
            this.automatic_collaps = true;
            int i, nsize = nodes.Count;
            JNode node;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if (node.IsExpanded && (node.Nodes.Count > 0))
                {
                    this.do_collaps(node.Nodes, level + 1);
                }
                else
                {
                    if ((level == this.max_exp_level) && (node.Parent != null))
                    {
                        PDdim_elements.SelectNode(node, false);
                        node.Parent.Collapse();
                        //CDNM:
                        //node.Deselect();
                        //node.Parent.Expanded = false;
                    }
                }
            }
            this.automatic_collaps = false;
        }

        private void do_gselect(TreeNodeCollection nodes, byte mode)
        {
            int i, nsize = nodes.Count;
            JNode node;

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                switch (mode)
                {
                    case SEL_ALL:
                        PDdim_elements.SelectNode(node);
                        //CDNM: node.Select(false);
                        break;
                    case SEL_NONE:
                        PDdim_elements.SelectNode(node, false);
                        //CDNM: node.Deselect();
                        break;
                    case SEL_INVERT:
                        if (PDdim_elements.IsNodeSelected(node))
                        {
                            PDdim_elements.SelectNode(node, false);
                            //CDNM: node.Deselect();
                        }
                        else
                        {
                            PDdim_elements.SelectNode(node, true);
                            //CDNM: node.Select(false);
                        }
                        break;
                    //  JMM 09-03-14
                    case SEL_DISTINCT:
                        if (PDdim_elements.IsNodeSelected(node))
                            {
                            if (distinct.Contains(node.Text))
                                PDdim_elements.SelectNode(node, false);
                            else
                                distinct.Add(node.Text);
                            }
                        break;
                }

                if (node.IsExpanded && (node.Nodes.Count > 0))
                {
                    this.do_gselect(node.Nodes, mode);
                }
            }
        }

        private void do_gselect_click(byte mode)
        {
            this.automatic_selection = true;
            TreeNodeCollection Elems = this.PDdim_elements.Nodes;
            //  JMM 09-03-14
            if (mode == SEL_DISTINCT) 
                {
                distinct = new System.Collections.Generic.HashSet<string>();
                PDbutton_distinct.BackColor = btnDistinctColor2;
                }
            else
                resetDistinct();
            
            int i, nsize = Elems.Count;
            JNode Element;

            for (i = 0; i < nsize; i++)
            {
                Element = (JNode)Elems[i];
                if (Element.IsExpanded)
                {
                    this.do_gselect(Element.Nodes, mode);
                }
            }
            
            distinct = null;
            this.automatic_selection = false;
            this.PDselected_items_check();
            this.check_state_button();
            this.PDdim_elements.Focus();
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
                    PDdim_elements.SelectNode(node);
                    //CDNM: node.Select(false);
                }
                else
                {
                    if (level == expected_level)
                    {
                        PDdim_elements.SelectNode(node);
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
                this.automatic_selection = true;

                TreeNodeCollection Elems = this.PDdim_elements.Nodes;
                int i, nsize = Elems.Count;
                JNode Element;

                for (i = 0; i < nsize; i++)
                {
                    Element = (JNode)Elems[i];

                    if (Element.IsExpanded)
                    {
                        if (!check_shift())
                        {
                            this.do_gselect(Element.Nodes, SEL_NONE);
                        }

                        this.do_special_selection(Element.Nodes, 1, expected_level);
                        break;
                    }
                }
                this.automatic_selection = false;
                this.PDselected_items_check();
                this.check_state_button();
                this.PDdim_elements.Focus();
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error special Selection", e);
            }
        }

        private int get_sel_node_counts()
        {
            NodesCollection selNodes = PDdim_elements.SelectedNodes;
            int count = selNodes.Count;

            if ((count == 1) || (count == 2))
            {
                count = 0;
                JNode node;
                int i, nsize = selNodes.Count;

                for (i = 0; i < nsize; i++)
                {
                    node = (JNode)selNodes[i];
                    if (node.Parent != null)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void PDselected_items_check()
        {
            this.SuspendLayout();

            int count = this.PDselected_items.Items.Count;

            if (count == 0)
            {
                count = this.get_sel_node_counts();
            }

            if ((count == 1) || (this.mode == MODE_SEL))
            {
                if (this.mode == MODE_SEL)
                {
                    this.PDbutton_horizontal.Text = ResourceInitializer.BUTTON_OK;
                    this.PDbutton_horizontal.Image = null;
                }
                else
                {
                    this.PDbutton_horizontal.Text = ResourceInitializer.BUTTON_PASTE;
                }
                this.PDbutton_horizontal.Enabled = true;
                this.PDbutton_vertical.Visible = false;
            }
            else
            {
                this.PDbutton_horizontal.Enabled = true;
                this.PDbutton_vertical.Enabled = true;
                this.PDbutton_horizontal.Text = ResourceInitializer.BUTTON_HPASTE;
                this.PDbutton_vertical.Visible = true;

                if ((this.ccount > 1) && (this.rcount == 1))
                {
                    this.PDbutton_vertical.Enabled = false;
                }
                else
                {
                    if ((this.rcount > 1) && (this.ccount == 1))
                    {
                        this.PDbutton_horizontal.Enabled = false;
                    }
                }
            }

            if (count == 0)
            {
                this.PDbutton_horizontal.Enabled = false;
                this.PDbutton_vertical.Enabled = false;
            }

            this.ResumeLayout();
        }

        private void prepare_add()
        {
            if (this.IsPageElement)
            {
                this.PDselected_items.Items.Clear();
            }
        }

        private void do_add_one(JNode Element)
        {
            if (PDdim_elements.IsNodeSelected(Element))
            {
                Hashtable dimelems = null;
                SetDimeelems(ref dimelems);
                ElementInfo ei = (ElementInfo)dimelems[Element.Tag];
                String name = ei.Name, aname = name;

                if (!String.IsNullOrEmpty(this.curAttribute))
                {
                    System.Collections.Specialized.StringDictionary anames = (System.Collections.Specialized.StringDictionary)this.dimattribs[this.curAttribute];
                    aname = anames[name];
                }

                PasteHelper ph = new PasteHelper(Element.Text, name, aname, ei.Children.Length > 0, this.getpath(Element), (uint)ei.Indent); ;
                this.PDselected_items.Items.Add(ph);
            }
        }

        private void do_add(TreeNodeCollection nodes)
        {
            int anzahl = nodes.Count;
            JNode Element;

            for (int i = 0; i < anzahl; i++)
            {
                Element = (JNode)nodes[i];
                this.do_add_one(Element);
                if (Element.Nodes.Count > 0)
                {
                    do_add(Element.Nodes);
                }
            }
        }

        private void do_add_Click()
        {
            prepare_add();
            TreeNodeCollection SelElems = this.PDdim_elements.Nodes;
            JNode Element;

            int i, nsize = SelElems.Count;

            for (i = 0; i < nsize; i++)
            {
                Element = (JNode)SelElems[i];
                if (Element.IsExpanded)
                {
                    this.do_add(Element.Nodes);
                }
            }

            this.PDselected_items_check();
        }

        private void do_up_Click()
        {
            this.automatic_selection = true;
            int[] indexes = new int[this.PDselected_items.SelectedIndices.Count];
            this.PDselected_items.SelectedIndices.CopyTo(indexes, 0);
            int anzahl = indexes.Length;
            if (anzahl > 0)
            {
                int maxitem = this.PDselected_items.Items.Count;
                int k = 0;

                while (this.PDselected_items.SelectedIndices.Contains(k) && (k++ < maxitem - 1)) ;

                if (k < maxitem - 1)
                {
                    PasteHelper ph = null;
                    bool selected = false;
                    int j = 0;
                    for (int i = 0; i < anzahl; i++)
                    {
                        j = indexes[i];
                        if (j > k)
                        {
                            ph = (PasteHelper)this.PDselected_items.Items[j];
                            selected = this.PDselected_items.GetSelected(j - 1);
                            this.PDselected_items.Items[j] = this.PDselected_items.Items[j - 1];
                            this.PDselected_items.Items[j - 1] = ph;
                            this.PDselected_items.SetSelected(j - 1, true);
                            this.PDselected_items.SetSelected(j, selected);
                        }
                    }
                }
            }
            this.automatic_selection = false;
        }

        private void do_down_Click()
        {
            this.automatic_selection = true;
            int[] indexes = new int[this.PDselected_items.SelectedIndices.Count];
            this.PDselected_items.SelectedIndices.CopyTo(indexes, 0);
            int anzahl = indexes.Length;
            if (anzahl > 0)
            {
                int maxitem = this.PDselected_items.Items.Count;
                int k = maxitem - 1;

                while (this.PDselected_items.SelectedIndices.Contains(k) && (k-- > 0)) ;

                if (k > 0)
                {
                    PasteHelper ph = null;
                    bool selected = false;
                    int j = maxitem;
                    for (int i = anzahl - 1; i >= 0; i--)
                    {
                        j = indexes[i];
                        if (j < k)
                        {
                            ph = (PasteHelper)this.PDselected_items.Items[j];
                            selected = this.PDselected_items.GetSelected(j + 1);
                            this.PDselected_items.Items[j] = this.PDselected_items.Items[j + 1];
                            this.PDselected_items.Items[j + 1] = ph;
                            this.PDselected_items.SetSelected(j, selected);
                            this.PDselected_items.SetSelected(j + 1, true);
                        }
                    }
                }
            }
            this.automatic_selection = false;
        }

        private void do_sort_Click(bool reverse)
        {
            int maxitem = this.PDselected_items.Items.Count;
            PasteHelper[] phs = new PasteHelper[maxitem];
            for (int i = 0; i < maxitem; i++)
            {
                phs[i] = (PasteHelper)this.PDselected_items.Items[i];
                phs[i].selected = this.PDselected_items.GetSelected(i);
            }

            Array.Sort(phs);

            if (reverse)
            {
                Array.Reverse(phs);
            }

            this.PDselected_items.Items.Clear();
            for (int i = 0; i < maxitem; i++)
            {
                this.PDselected_items.Items.Add(phs[i]);
                this.PDselected_items.SetSelected(i, phs[i].selected);
            }
        }

        private void do_remove_Click()
        {
            while (this.PDselected_items.SelectedIndices.Count > 0)
            {
                this.PDselected_items.Items.RemoveAt(this.PDselected_items.SelectedIndices[0]);
            }
            this.PDselected_items_check();
        }

        private void do_select_flat(TreeNodeCollection nodes, bool topelement)
        {
            int i, nsize = nodes.Count;
            JNode Element;
            ElementInfo el;

            Hashtable dimelems = null;
            SetDimeelems(ref dimelems);

            for (i = 0; i < nsize; i++)
            {
                Element = (JNode)nodes[i];
                el = (ElementInfo)dimelems[Element.Tag];

                if (topelement && (el.Parents.Length == 0))
                {
                    PDdim_elements.SelectNode(Element);
                    //CDNM: Element.Select(false);
                }
                else if (!topelement && (el.Children.Length == 0))
                {
                    PDdim_elements.SelectNode(Element);
                    //CDNM: Element.Select(false);
                }
            }
        }

        private void select_flat(bool topelement)
        {
            this.automatic_selection = true;

            TreeNodeCollection Elems = this.PDdim_elements.Nodes;
            int i, nsize = Elems.Count;
            JNode Element;

            for (i = 0; i < nsize; i++)
            {
                Element = (JNode)Elems[i];

                if (Element.IsExpanded)
                {
                    if (!check_shift())
                    {
                        this.do_gselect(Element.Nodes, SEL_NONE);
                    }
                    do_select_flat(Element.Nodes, topelement);
                    break;
                }
            }

            this.automatic_selection = false;
            this.PDselected_items_check();
            this.check_state_button();
            this.PDdim_elements.Focus();
        }


        private void PDbutton_1_Click(object sender, System.EventArgs e)
        {
            if (!this.definition_order)
            {
                select_flat(true);
            }
            else
            {
                this.prepare_special_selection(1);
            }
        }

        private void PDbutton_2_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(2);
        }

        private void PDbutton_3_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(3);
        }

        private void PDbutton_4_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(4);
        }

        private void PDbutton_5_Click(object sender, System.EventArgs e)
        {
            this.prepare_special_selection(5);
        }

        private void PDbutton_B_Click(object sender, System.EventArgs e)
        {
            if (!this.definition_order)
            {
                select_flat(false);
            }
            else
            {
                this.prepare_special_selection(0);
            }
        }

        private void PDbutton_clear_Click(object sender, System.EventArgs e)
        {
            this.PDselected_items.Items.Clear();
            this.PDselected_items_check();
            this.check_state_button();
        }

        private void PDbutton_search_Click(object sender, System.EventArgs e)
        {
            this.foundsearch = false;
            resetDistinct();

            if (this.PDinput_search.Text.Length > 0)
            {
                this.automatic_selection = true;
                TreeNodeCollection Elems = this.PDdim_elements.Nodes;

                foreach (JNode Element in Elems)
                {
                    if (Element.IsExpanded)
                    {
                        if (!check_shift())
                        {
                            this.do_gselect(Element.Nodes, SEL_NONE);
                        }
                        this.do_search(Element.Nodes, this.PDinput_search.Text);
                    }
                }
                this.automatic_selection = false;
                this.PDselected_items_check();
                this.check_state_button();
            }

            if (!this.foundsearch)
            {
                string mess = ResourceInitializer.Replace(ResourceInitializer.TEXT_DIMELEMENT_NOT_FOUND, new object[] { this.PDinput_search.Text, this.getCurrdim() });
                MessageBox.Show(mess);
            }

            this.foundsearch = false;
            this.PDdim_elements.Focus();
        }

        private void PDbutton_branch_Click(object sender, System.EventArgs e)
        {
            resetDistinct();
            this.automatic_selection = true;
            TreeNodeCollection Elems = this.PDdim_elements.Nodes;

            foreach (JNode Element in Elems)
            {
                if (Element.IsExpanded)
                {
                    this.do_branch(Element.Nodes);
                }
            }
            this.automatic_selection = false;
            this.PDselected_items_check();
            this.check_state_button();
            this.PDdim_elements.Focus();
        }

        private void PDbutton_all_Click(object sender, System.EventArgs e)
        {
            this.do_gselect_click(SEL_ALL);
        }

        private void PDbutton_none_Click(object sender, System.EventArgs e)
        {
            this.do_gselect_click(SEL_NONE);
        }

        private void PDbutton_invert_Click(object sender, System.EventArgs e)
        {
            this.do_gselect_click(SEL_INVERT);
        }
        
        private void PDbutton_distinct_Click(object sender, EventArgs e)
            {
            this.do_gselect_click(SEL_DISTINCT);
            }

        private void PDbutton_horizontal_Click(object sender, System.EventArgs e)
        {
            this.do_paste(1);
            //  JMM 03-20-14
            this.do_exit();
        }

        private void PDbutton_vertical_Click(object sender, System.EventArgs e)
        {
            this.do_paste(0);
            //  JMM 03-20-14
            this.do_exit();
        }

        private void PDbutton_cancel_Click(object sender, System.EventArgs e)
        {
            this.do_exit(true);
        }

        private void PDbutton_meta_horizontal_Click(object sender, System.EventArgs e)
        {
            this.do_meta_paste(1);
        }

        private void PDbutton_meta_vertical_Click(object sender, System.EventArgs e)
        {
            this.do_meta_paste(0);
            //  JMM 03-20-14
            this.do_exit();
        }

        private void PDbutton_meta_cancel_Click(object sender, System.EventArgs e)
        {
            this.do_exit(true);
            //  JMM 03-20-14
            this.do_exit();
        }

        private void PDbutton_expand_Click(object sender, System.EventArgs e)
        {
            TreeNodeCollection Elems = this.PDdim_elements.Nodes;
            foreach (JNode Element in Elems)
            {
                if (Element.IsExpanded)
                {
                    this.do_expand(Element.Nodes);
                }
            }
        }

        private void PDbutton_collaps_all_Click(object sender, System.EventArgs e)
        {
            TreeNodeCollection Elems = this.PDdim_elements.Nodes, Children;

            this.automatic_collaps = true;
            foreach (JNode Element in Elems)
            {
                if (Element.IsExpanded)
                {
                    Children = Element.Nodes;
                    foreach (JNode Child in Children)
                    {
                        Child.Collapse(false);
                        //CDNM: Child.CollapseAll();
                    }
                }
            }
//            if (Elems.Count == 1) this.PDdim_elements.Nodes[0].Expand();
            this.automatic_collaps = false;
            this.PDselected_items_check();
            this.check_state_button_all();
        }

        private void PDbutton_expand_all_Click(object sender, System.EventArgs e)
        {
            TreeNodeCollection Elems = this.PDdim_elements.Nodes;

            this.automatic_expand = true;

            int anzahl = Elems.Count;

            foreach (JNode Element in Elems)
            {
                if (Element.IsExpanded || (anzahl == 1))
                {
                    Element.ExpandAll();
                }
            }
            this.automatic_expand = false;
            this.PDselected_items_check();
            this.check_state_button_all();
        }

        private void PDbutton_collaps_Click(object sender, System.EventArgs e)
        {
            this.max_exp_level = 0;

            TreeNodeCollection Elems = this.PDdim_elements.Nodes;

            foreach (JNode Element in Elems)
            {
                //              if (Element.IsExpanded)
                {
                    TreeNodeCollection nodes = Element.Nodes;
                    foreach (JNode root in nodes)
                    {
                        if (root.IsExpanded)
                        {
                            this.prepare_collaps(root.Nodes, 2);
                        }
                    }
                    foreach (JNode root in nodes)
                    {
                        if (root.IsExpanded)
                        {
                            this.do_collaps(root.Nodes, 2);
                        }
                    }
                }
            }
        }

        private void PDbutton_add_Click(object sender, System.EventArgs e)
        {
            this.do_add_Click();
        }

        private void PDbutton_remove_Click(object sender, System.EventArgs e)
        {
            this.do_remove_Click();
        }

        private void PDbutton_up_Click(object sender, System.EventArgs e)
        {
            this.do_up_Click();
        }

        private void PDbutton_down_Click(object sender, System.EventArgs e)
        {
            this.do_down_Click();
        }

        private void PDbutton_sort_Click(object sender, System.EventArgs e)
        {
            this.do_sort_Click(false);
        }

        private void PDbutton_revers_sort_Click(object sender, System.EventArgs e)
        {
            this.do_sort_Click(true);
        }

        private void PDadvanced_CheckedChanged(object sender, System.EventArgs e)
        {
            this.PDbutton_invert.Visible = this.PDadvanced.Checked;
            this.PDbutton_distinct.Visible = this.PDadvanced.Checked;
            this.PDbutton_search.Visible = this.PDadvanced.Checked;
            this.PDinput_search.Visible = this.PDadvanced.Checked;
            this.PDlabel_tip.Visible = this.PDadvanced.Checked;
        }

        private void PDdbelements_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.PDdbelements.Checked)
            {
                this.PDTabPages.SelectedIndex = 1;
            }
            else
            {
                this.PDTabPages.SelectedIndex = 0;
            }
        }

        private void do_resetFromAttributes(JNode Element)
        {
            Hashtable dimelems = null;
            SetDimeelems(ref dimelems);
            if (dimelems == null) return;           

            ElementInfo ei = dimelems[Element.Tag] as ElementInfo;
            if (ei != null)
                Element.Text = ei.Name;

            int j, nsize2 = Element.Nodes.Count;
            for (j = 0; j < nsize2; j++)
            {
                do_resetFromAttributes((JNode)Element.Nodes[j]);
            }
        }

        private void resetFromAttributes()
        {
            TreeNodeCollection Elems = this.PDdim_elements.Nodes;
            JNode Element;

            int i, j, nsize = this.PDdim_elements.Nodes.Count, nsize2;
            this.curAttribute = "";
            for (i = 0; i < nsize; i++)
            {
                Element = (JNode)Elems[i];
                if (Element.IsExpanded)
                {
                    nsize2 = Element.Nodes.Count;
                    for (j = 0; j < nsize2; j++)
                    {
                        do_resetFromAttributes((JNode)Element.Nodes[j]);
                    }
                }
            }
        }

        private void getAttributesvalues(string db, string dimension, string Attribute)
        {
            System.Collections.Specialized.StringDictionary anames = new System.Collections.Specialized.StringDictionary();

            string[] elems = (string[])this.dimelems2[dimension];
            int i, count = elems.Length;

            ArrayList al = new ArrayList();

            for (i = 0; i < count; i++)
            {
                if (!String.IsNullOrEmpty(elems[i]))
                {
                    al.Add(elems[i]);
                }
            }

            string[] elems2 = (string[])al.ToArray(typeof(string));

            PasteUtils.getAttributesvalues(ref anames, this.currConn, db, dimension, Attribute, elems2, this.attrib_cube );

            this.dimattribs[Attribute] = anames;
        }

        private void Check4Attributesvalues(string db, string dimension, string Attribute)
        {
            if (!this.dimattribs.ContainsKey(Attribute))
            {
                getAttributesvalues(db, dimension, Attribute);
            }
        }


        private void do_ApplyFormats(JNode Element)
        {
            Hashtable dimelems = null;
            SetDimeelems(ref dimelems);

            ElementInfo ei = (ElementInfo)dimelems[Element.Tag];
            string name = ei.Name, aname = name;

            if (!String.IsNullOrEmpty(this.curAttribute))
            {
                System.Collections.Specialized.StringDictionary anames = (System.Collections.Specialized.StringDictionary)this.dimattribs[this.curAttribute];
                aname = anames[name];
            }

            Element.Text = this.getformat(PDaliasformats.SelectedIndex, name, aname);

            int j, nsize2 = Element.Nodes.Count;
            for (j = 0; j < nsize2; j++)
            {
                do_ApplyFormats((JNode)Element.Nodes[j]);
            }
        }

        private void do_ApplyAttributes(JNode Element, System.Collections.Specialized.StringDictionary anames)
        {
            Hashtable dimelems = null;
            SetDimeelems(ref dimelems);

            ElementInfo el = (ElementInfo)dimelems[Element.Tag];
            string ename = el.Name;
            string newname = anames[ename];

            if (mode == MODE_NORM)
            {
                Element.Text = this.getformat(PDaliasformats.SelectedIndex, ename, newname);
            }
            else
            {
                Element.Text = ((newname != null) && (newname.Trim() != "")) ? newname : ename;
            }

            int j, nsize2 = Element.Nodes.Count;
            for (j = 0; j < nsize2; j++)
            {
                do_ApplyAttributes((JNode)Element.Nodes[j], anames);
            }
        }

        private void ApplyAttributes(string db, string dimension, string Attribute)
        {
            Check4Attributesvalues(db, dimension, Attribute);

            System.Collections.Specialized.StringDictionary anames = (System.Collections.Specialized.StringDictionary)this.dimattribs[Attribute];

            TreeNodeCollection Elems = this.PDdim_elements.Nodes;
            JNode Element;

            int i, j, nsize = this.PDdim_elements.Nodes.Count, nsize2;

            for (i = 0; i < nsize; i++)
            {
                Element = (JNode)Elems[i];
                if (Element.IsExpanded)
                {
                    nsize2 = Element.Nodes.Count;
                    for (j = 0; j < nsize2; j++)
                    {
                        do_ApplyAttributes((JNode)Element.Nodes[j], anames);
                    }
                }
            }
        }

        private void getAttributes(string db, string dimension)
        {
            this.PDattributes.Visible = false;
            if (this.currConn.GetDimensionType(db, dimension) == DimensionType.NormalDimension)
            {
                try
                {
                    AttributeHelper.checkattributes(this.currConn, db, dimension, ref this.attrib_cube, ref this.PDattributes);
                }
                catch (PaloException exc)
                {
                    MessageBox.Show(exc.PaloMessage);
                }
            }

        }

        private void PDdim_elements_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (!this.automatic_expand)
            {
                if ((e.Node.Parent == null) && (this.olddim != e.Node.Text))
                {
                    this.olddim = e.Node.Text;
                    this.curdim = this.olddim;
                    this.PDselected_items.Items.Clear();
                    this.PDattributes.Items.Clear();
                    this.getAttributes(this.curdb, this.curdim);
                    // JMM 03-20-14:
                    PDdim_elements.UnselectAllNodesExceptNode(e.Node, TreeViewAction.Expand);
                }
                if ((e.Node.Parent != null) && PDdim_elements.IsNodeSelected(e.Node) && (this.mode == MODE_SEL))
                {
                    TreeNodeCollection nodes = e.Node.Nodes;
                    int i, nsize = nodes.Count;
                    for (i = 0; i < nsize; i++)
                    {
                        PDdim_elements.SelectNode(nodes[i]);
                        //CDNM: nodes[i].Select(false);
                    }
                }
                this.PDselected_items_check();
                this.check_state_button_all();
            }
        }

        private void PDdim_elements_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent == null)
            {
            if (!string.IsNullOrEmpty(this.olddim) && (this.PDattributes.SelectedIndex > 0))
                    this.PDattributes.SelectedIndex = 0;

            //  JMM 03-20-14, Clear old dimension
            if (!string.IsNullOrEmpty(this.olddim))
                {
                foreach (TreeNode node in PDdim_elements.Nodes)
                    {
                    if (node != e.Node && node.IsExpanded)
                        node.Collapse();
                    }
                }


            if ((e.Node.Nodes.Count == 1) && (((JNode)e.Node.Nodes[0]).Tag == null))
                {
                    e.Node.Nodes.Clear();
                    TreeNodeCollection nodes = get_dim_elements(e.Node.Text).Nodes;
                    int i, nsize = nodes.Count;
                    for (i = 0; i < nsize; i++)
                    {
                        e.Node.Nodes.Add(nodes[i]);
                    }
                }
            }
        }

        private void PDdim_elements_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (!this.automatic_collaps)
            {
                this.check_state_button_all();
            }
        }

        private void PDdim_elements_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.automatic_selection)
            {
                this.PDselected_items_check();
                this.check_state_button();
                resetDistinct();
            }
        }

        private void PDdim_elements_AfterDeselect(object sender, TreeViewEventArgs e)
        {
            if ((e.Node.Parent != null) && !this.automatic_selection)
            {
                this.PDselected_items_check();
                this.check_state_button();
            }
        }

        private void PDdim_elements_DoubleClick(object sender, System.EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            JNode elem = (JNode)PDdim_elements.GetNodeAt(me.X, me.Y);
            if (elem != null)
            //CDNM:
            //System.Drawing.Rectangle Bounds = ((JTreeView)sender).FocusNode.Bounds;
            //if (Bounds.Contains(PDdim_elements.ClientPointToNode(new Point(me.X, me.Y))))
            {
                prepare_add();
                //JNode elem = PDdim_elements.SelectedNode;
                if (elem != null)
                {
                    if ((elem.Parent != null) && !this.PDselected_items.Items.Contains(elem.Text))
                    {
                        this.do_add_one(elem);
                        this.PDselected_items_check();
                    }
                }
            }
        }

        private void PDselected_items_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!this.automatic_selection)
            {
                this.check_state_button();
            }
        }

        private void PDcube_dims_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool enabled = (this.PDcube_dims.SelectedItems.Count > 0);
            this.PDbutton_meta_horizontal.Enabled = enabled;
            this.PDbutton_meta_vertical.Enabled = enabled;
        }

        private void PDselected_items_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.PDselected_items.SelectedIndices.Count > 0)
            {
                PasteHelper ph = (PasteHelper)this.PDselected_items.Items[this.PDselected_items.SelectedIndices[0]];
                this.PDselected_items.Items.RemoveAt(this.PDselected_items.SelectedIndices[0]);
            }

            this.PDselected_items_check();
        }

        private void PDselected_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Delete)
            {
                e.Handled = true;
                this.do_remove_Click();
            }
        }

        private void do_defintion_order_Changed()
        {
            TreeNodeCollection nodes = PDdim_elements.Nodes, nodes2;
            JNode node = null;
            int i, j, nsize = nodes.Count, nsize2;

            if (!this.definition_order)
            {
                //????
                //CDNM:
                //this.PDdim_elements.LineVisibility = LineBoxVisibility.OnlyBelowRoot;
                //this.PDdim_elements.BoxVisibility = LineBoxVisibility.Nowhere;
            }
            else
            {
                this.PDdim_elements.ImageList = null;
                //CDNM:
                //this.PDdim_elements.LineVisibility = LineBoxVisibility.Everywhere;
                //this.PDdim_elements.BoxVisibility = LineBoxVisibility.Everywhere;
            }

            for (i = 0; i < nsize; i++)
            {
                node = (JNode)nodes[i];
                if (node.IsExpanded)
                {
                    node.Nodes.Clear();
                    GC.Collect();
                    nodes2 = this.get_dim_elements(node.Text).Nodes;
                    nsize2 = nodes2.Count;

                    for (j = 0; j < nsize2; j++)
                    {
                        node.Nodes.Add(nodes2[j]);
                    }
                    break;
                }
            }

            do_PDattributes_SelectedIndexChanged(false);

            this.check_state_button_select();

        }

        private void PDbutton_definition_order_Click(object sender, System.EventArgs e)
        {
            this.definition_order = !this.definition_order;

            if (this.definition_order)
            {
                PDbutton_definition_order.ButtonImage = (Image)ResourceInitializer.IconShowHierarchyButtonP;
            }
            else
            {
                PDbutton_definition_order.ButtonImage = (Image)ResourceInitializer.IconShowFlatButton;
            }

            PDbutton_definition_order.RolloverImage = PDbutton_definition_order.ButtonImage;

            do_defintion_order_Changed();
        }

        private void frmPasteDim_Resize(object sender, System.EventArgs e)
        {        
            Size newsize = ((Control)sender).Size;

            if (!this.oldsize.IsEmpty && !newsize.IsEmpty && this.Visible)
            {
                int oldheight = this.PDselected_items.Height;
                int dx = newsize.Width - this.oldsize.Width;
                int dy = newsize.Height - this.oldsize.Height;
                this.SuspendLayout();
                
                // JMM 03-20-14 Changed to use anchors                               
                this.PDpanel_left.Width += dx / 2;
                this.PDpanel_right.Left += dx / 2;
                this.PDpanel_right.Width += dx / 2;

                #if NOTUSED 
                int dy1 = this.PDselected_items.Height;



                //this.PDTabPages.Width += dx;
                //this.PDTabPages.Height += dy;

                //this.PDPageDBElements.Width += dx;
                //this.PDPageDBElements.Height += dy;

                //this.PDPageDBElements.Width += dx;
                //this.PDPageDimElements.Height += dy;

                //this.PDdbelements.Left += dx;

                //this.PDpanel_left.Width += dx;
                //this.PDpanel_left.Height += dy;

                //this.PDserverlist.Width += dx;

                //this.PDpanel_bottom_left.Width += dx;
                //this.PDpanel_bottom_left.Height += dy;

                //this.PDdim_elements.Width += dx;
                //this.PDdim_elements.Height += dy;

                //this.PDbutton_collaps_all.Left += dx;
                //this.PDbutton_expand_all.Left += dx;
                //this.PDbutton_definition_order.Left += dx;

                //this.PDpanel_right.Left += dx;
                //this.PDpanel_right.Height += dy;

                //this.PDpanel_bottom_right.Top += dy;
                //this.PDselected_items.Height = (this.PDpanel_bottom_right.Top - this.PDselected_items.Top - this.listboxoffset)
                //                               / PDselected_items.ItemHeight * PDselected_items.ItemHeight;

                dy1 = (this.PDselected_items.Height - dy1) / 2;

                //this.PDbutton_up.Left += dx;
                //this.PDbutton_up.Top += dy1;

                //this.PDbutton_add.Left += dx;
                //this.PDbutton_add.Top += dy1;

                //this.PDbutton_remove.Left += dx;
                //this.PDbutton_remove.Top += dy1;

                //this.PDbutton_down.Left += dx;
                //this.PDbutton_down.Top += dy1;

                //this.PDpanel_bottom_left2.Top += dy;
                //this.PDpanel_bottom_left2.Width += dx;

                //this.PDattributes.Width += dx;

                //this.PDaliasformats.Width += dx;

                //this.PDPanelMeta1.Left += dx;
                //this.PDPanelMeta1.Height += dy;

                //this.PDPanelMeta2.Width += dx;
                //this.PDPanelMeta2.Height += dy;

                //this.PDPanelMeta3.Top += dy;

                //this.PDCubes.Width += dx;

                //this.PDcube_dims.Width += dx;
                //this.PDcube_dims.Height += dy;

                //this.PDcube_dims.Height = this.PDPanelMeta2.Top + this.PDPanelMeta2.Height - this.PDcube_dims.Top - this.listboxoffset2;

                #endif
                
                this.ResumeLayout();
            }

            if ((!newsize.IsEmpty && this.Visible) || this.oldsize.IsEmpty)
            {
                this.oldsize = newsize;
            }

        }

        private void SetDimeelems(ref Hashtable dimelems)
        {
            if (string.IsNullOrEmpty(this.curdim))
            {
                this.curdim = this.getCurrdim();
            }
            dimelems = (Hashtable)this.dimelems0[this.curdim];
        }

        private JNode generateChildNodes(ElementInfo dimDimElem)
        {
            JNode outN = new JNode();
            string element;

            ElementInfo childdimDimElem;
            int csize, i, id;

            outN.Text = dimDimElem.Name;

            Hashtable dimelems = null;
            SetDimeelems(ref dimelems);

            csize = dimDimElem.Children.Length;
            JNode el;
            if (csize > 0)
            {
                for (i = 0; i < csize; i++)
                {
                    id = (int)dimDimElem.Children[i].Identifier;

                    if (dimelems.ContainsKey(id))
                    {
                        childdimDimElem = (ElementInfo)dimelems[id];
                        element = (string)childdimDimElem.Name;

                        if (childdimDimElem.Children.Length > 0)
                        {
                            outN.Nodes.Add(this.generateChildNodes(childdimDimElem));
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

        private void get_dim_elements_flat(ref ElementInfo[] dimDimElems, ref JNode tn)
        {
            int i, dsize = dimDimElems.Length;
            ElementInfo dimDimElem;
            string[] elnames = new String[dsize];
            string element;

            Hashtable dimelems = new Hashtable();
            PDdim_elements.ImageList = new ImageList();
            PDdim_elements.ImageList.Images.AddRange(new Image[] {ResourceInitializer.ConsolidatedElement, ResourceInitializer.NumericElement, ResourceInitializer.StringElement});
            JNode tn2 = null;

            for (i = 0; i < dsize; i++)
            {
                dimDimElem = dimDimElems[i];
                element = dimDimElem.Name;

                if (!String.IsNullOrEmpty(element))
                {
                    elnames[i] = element;

                    tn2 = new JNode(element);

                    if (dimDimElem.Children.Length > 0)
                    {
                        tn2.ImageIndex = 0;
                        //CDNM: tn2.Image = ResourceInitializer.ConsolidatedElement;
                    }
                    else
                    {
                        if (dimDimElem.Type == DimElementType.DimElementTypeNumeric)
                        {
                            tn2.ImageIndex = 1;
                            //CDNM: tn2.Image = ResourceInitializer.NumericElement;
                        }
                        else
                        {
                            if (dimDimElem.Type == DimElementType.DimElementTypeString)
                            {
                                tn2.ImageIndex = 2;
                                //CDNM: tn2.Image = ResourceInitializer.StringElement;
                            }
                        }
                    }

                    tn2.Tag = dimDimElem.Identifier;

                    tn.Nodes.Add(tn2);
                    dimelems[dimDimElem.Identifier] = dimDimElem;
                }

            }
            this.dimelems0[tn.Text] = dimelems;
            this.dimelems2[tn.Text] = elnames;
        }

        private void get_dim_elements_nonflat(ref ElementInfo[] dimDimElems, ref JNode tn)
        {
            int i, dsize = dimDimElems.Length;
            ElementInfo dimDimElem;
            string[] elnames = new String[dsize];
            string element;

            Hashtable dimelems = new Hashtable();
            PDdim_elements.ImageList = null;

            for (i = 0; i < dsize; i++)
            {
                dimDimElem = dimDimElems[i];
                element = dimDimElem.Name;

                if (!String.IsNullOrEmpty(element))
                {
                    elnames[i] = element;

                    dimelems[dimDimElem.Identifier] = dimDimElem;
                }
            }

            this.dimelems0[tn.Text] = dimelems;
            this.dimelems2[tn.Text] = elnames;

            for (i = 0; i < dsize; i++)
            {
                dimDimElem = dimDimElems[i];

                if (!String.IsNullOrEmpty(dimDimElem.Name) && TreeHelper.has_no_valid_parents(dimDimElem, dimelems))
                {
                    tn.Nodes.Add(this.generateChildNodes(dimDimElem));
                }
            }

        }

        private JNode get_dim_elements(string dimension)
        {
            JNode tn = new JNode(dimension);

            ExcelHelper.SetExcelStatusbar(ResourceInitializer.Replace(ResourceInitializer.STATUS_READING_ELEMENTS_SERVER, new object[] { this.curServerName }));
            this.dimattribs.Clear();

            try
            {
                ElementInfo[] dimDimElems = this.currConn.DimensionListElements(this.curdb, dimension);

                this.curdim = dimension;

                if (this.definition_order)
                {
                    this.get_dim_elements_nonflat(ref dimDimElems, ref tn);
                }
                else
                {
                   this.get_dim_elements_flat(ref dimDimElems, ref tn);
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error getting dimensions elements!", exc);
            }

            ExcelHelper.ResetExcelStatusbar();

            return tn;
        }

        private void get_elements(string dim)
        {
            string[] dbDims;
            int dsize, i;
            string Dim;
            string savedim = this.olddim;
            this.olddim = "";

            if (dim == "")
            {
                dbDims = this.currConn.DatabaseListDimensions(this.curdb, DimensionType.NormalDimension);
            }
            else
            {
                dbDims = this.currConn.DatabaseListDimensions(this.curdb);
            }

            dsize = dbDims.Length;
            this.PDdim_elements.ClearNodes();
            JNode node;

            for (i = 0; i < dsize; i++)
            {
                Dim = dbDims[i];
                if (((dim == "") && !ListBoxHelper.IsJPaloDim(Dim)) || (Dim == dim))
                {
                    if (dim == "")
                    {
                        node = new JNode(Dim);
                        JNode dummynode;
                        dummynode = new JNode("Dummy");
                        dummynode.Tag = null;
                        node.Nodes.Add(dummynode);
                    }
                    else
                    {
                        node = get_dim_elements(Dim);
                    }
                    this.PDdim_elements.Nodes.Add(node);
                    if (Dim == savedim)
                    {
                        this.olddim = savedim;
                    }
                }
            }
        }

        private void get_elements()
        {
            this.get_elements("");
        }

        private void update_selected_items()
        {
            System.Collections.Specialized.StringDictionary anames = null;
            if (!String.IsNullOrEmpty(this.curAttribute))
            {
                anames = (System.Collections.Specialized.StringDictionary)this.dimattribs[this.curAttribute];
            }

            int maxitem = this.PDselected_items.Items.Count;
            PasteHelper[] phs = new PasteHelper[maxitem];
            string aname;
            for (int i = 0; i < maxitem; i++)
            {
                phs[i] = (PasteHelper)this.PDselected_items.Items[i];
                aname = (anames != null) ? (string)anames[phs[i].origname] : "";
                phs[i].currname = this.getformat(PDaliasformats.SelectedIndex, phs[i].origname, aname);
                phs[i].selected = this.PDselected_items.GetSelected(i);
            }

            this.PDselected_items.Items.Clear();
            for (int i = 0; i < maxitem; i++)
            {
                this.PDselected_items.Items.Add(phs[i]);
                this.PDselected_items.SetSelected(i, phs[i].selected);
            }

        }

        private void do_PDattributes_SelectedIndexChanged(bool do_clear)
        {
            if (string.IsNullOrEmpty(this.curdim))
            {
                this.curdim = this.getCurrdim();
            }

            if (string.IsNullOrEmpty(this.curdim))
            {
                return;
            }

            this.PDformats_visible();

            if (do_clear)
            {
                this.PDselected_items.Items.Clear();
            }

            if (this.PDattributes.SelectedIndex > 0)
            {
                this.curAttribute = (string)this.PDattributes.Items[this.PDattributes.SelectedIndex];
                this.ApplyAttributes(this.curdb, this.curdim, this.curAttribute);
            }
            else
            {
                this.resetFromAttributes();
            }
            update_selected_items();
        }

        private void do_PDformats_SelectedIndexChanged()
        {
            JNode Element;
            TreeNodeCollection Elems = this.PDdim_elements.Nodes;
            int i, j, nsize = Elems.Count, nsize2;

            for (i = 0; i < nsize; i++)
            {
                Element = (JNode)Elems[i];
                if (Element.IsExpanded)
                {
                    nsize2 = Element.Nodes.Count;
                    for (j = 0; j < nsize2; j++)
                    {
                        this.do_ApplyFormats((JNode)Element.Nodes[j]);
                    }
                }
            }

            update_selected_items();

        }

        private void PDattributes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            do_PDattributes_SelectedIndexChanged(false);
        }

        private void PDformats_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            do_PDformats_SelectedIndexChanged();
        }

        private void PDserverlist_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.PDdim_elements.ClearNodes();
            this.dimelems2.Clear();
            this.dimattribs.Clear();
            this.PDattributes.Items.Clear();
            resetDistinct();

            this.currConn = this.PDserverlist.GetConnection();
            // JMM 03-20-14
            string newdb = this.PDserverlist.GetDatabase();
            if (newdb != curdb)
                {
                this.curdb = newdb;
                this.curdim = "";
                this.olddim = "";
                }
            release_dimelems0(false);

            if (this.PDserverlist.SelectedIndex != -1)
            {
                this.PDselected_items.Items.Clear();

                if (!string.IsNullOrEmpty(this.curdb))
                {
                    if (!this.dont_get_element)
                    {
                        this.get_elements();
                        this.get_cubes();
                    }
                }
            }
            else
            {
                this.olddim = "";
            }
        }

        private void PDCubes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.PDcube_dims.Items.Clear();
            resetDistinct();

            if (this.PDCubes.SelectedIndex != -1)
            {
                string[] dims = this.currConn.CubeListDimensions(this.curdb, this.PDCubes.SelectedItem.ToString());
                int i, count = dims.Length;
                for (i = 0; i < count; i++)
                {
                    this.PDcube_dims.Items.Add(dims[i]);
                }
            }
        }

        private void setCombo(int serverid)
        {
            Size serverlistsize = new System.Drawing.Size(this.PDdim_elements.Width, 21);

            if (this.PDserverlist != null)
            {
                serverlistsize = this.PDserverlist.Size;
                this.PDserverlist.Dispose();
            }

            this.PDpanel_left.SuspendLayout();
            this.SuspendLayout();
            this.PDserverlist = new ConnComboBox();

            this.PDserverlist.AccessibleRole = AccessibleRole.ComboBox;
            this.PDserverlist.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PDserverlist.CausesValidation = false;
            this.PDserverlist.DisplayMember = "Text";
            this.PDserverlist.DrawMode = DrawMode.OwnerDrawFixed;
            this.PDserverlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.PDserverlist.Location = new System.Drawing.Point(this.PDlabel_choose_server.Left, this.PDlabel_choose_server.Top + this.PDlabel_choose_server.Height + 5);
            this.PDserverlist.MaxLength = 1;
            this.PDserverlist.Name = "PDserverlist";
            this.PDserverlist.Size = serverlistsize;
            this.PDserverlist.TabIndex = 2;
            this.PDserverlist.ValueMember = "Text";
            this.PDserverlist.DropDownStyle = ComboBoxStyle.DropDownList;
            this.PDserverlist.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.PDserverlist.SelectedIndexChanged += new System.EventHandler(this.PDserverlist_SelectedIndexChanged);

            this.Controls.Add(this.PDserverlist);

            this.PDserverlist.SuspendLayout();

            this.PDdim_elements.ClearNodes();
            this.PDselected_items.Items.Clear();

            this.PDserverlist.FillList(serverid, (-1 == serverid) ? ConnectionsHelper.HandleDatabase.WithSystem : ConnectionsHelper.HandleDatabase.NoRestriction);

            this.PDserverlist.ResumeLayout();
            this.PDserverlist.Refresh();
            this.PDpanel_left.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void do_btnFilter(byte filtertype)
        {
            this.FilterType = filtertype;
            this.get_cubes();
        }

        private void PDbutton_data_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.FILTER_DATA);
        }

        private void PDbutton_attr_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.FILTER_ATTRIBUTE);
        }

        private void PDbutton_user_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.FILTER_USER);
        }


        private void get_cubes()
        {
            this.PDCubes.RefreshList(this.PDserverlist, this.currConn, this.FilterType, true);
        }

        private void PDformats_visible()
        {
            bool enable = ((this.mode == MODE_NORM) && (this.PDattributes.SelectedIndex > 0));

            if (enable && (this.PDaliasformats.SelectedIndex < 0))
            {
                this.PDaliasformats.SelectedIndex = 0;
            }

            this.PDaliasformats.Enabled = enable;
            this.PDlabel_alias_format.Enabled = enable;
        }

        private void release_dimelems0(bool all)
        {
            if (this.dimelems0 != null)
            {
                IDictionaryEnumerator myEnum = this.dimelems0.GetEnumerator();
                ArrayList al = new ArrayList();
                while (myEnum.MoveNext())
                {
                    if (myEnum.Value != null)
                    {
                        ((Hashtable)myEnum.Value).Clear();
                        al.Add(myEnum.Key);
                    }
                }
                int i, size = al.Count;
                for (i = 0; i < size; i++)
                {
                    this.dimelems0[al[i]] = null;
                }
                this.dimelems0.Clear();
                if (all)
                {
                    this.dimelems0 = null;
                }
            }
        }

        private void release_resource()
        {
            this.olddim = null;
            this.curdb = null;
            this.curdim = null;

            if (this.ElemList != null)
            {
                this.ElemList = null;
            }

            if (this.Optionen != null)
            {
                this.Optionen = null;
            }

            if (this.currConn != null)
            {
                this.currConn = null;
            }

            release_dimelems0(true);

            if (this.dimelems2 != null)
            {
                this.dimelems2.Clear();
                this.dimelems2 = null;
            }

            if (this.dimattribs != null)
            {
                this.dimattribs.Clear();
                this.dimattribs = null;
            }

            this.attrib_cube = null;

            if (this.PDserverlist != null)
            {
                this.PDserverlist.Dispose();
                this.PDserverlist = null;
            }
        }

    }

  }
