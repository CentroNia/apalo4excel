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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
//using CDNM = Crownwood.DotNetMagic;
using JControls;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
    [ComVisible(false)]
    public  class CubeWizard : WizardDialogForm
    {
        #region Define vars

        private Font regularFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

        private Jedox.Palo.Comm.Connection currConn;
        private string dbN;
        private TextBox cubeName;
        private Label lblDesc2;
        private JButton btnLeft;
        private JButton btnDown;
        private JButton btnUp;
        private Label lblSelectedDims;
        private Label lblAvailDims;
        private JButton btnRight;
        private JTreeView treeCubes;
        private JTreeView treeDims;
        private Label lblDesc1;
        private ToolTip toolTip;
        private System.ComponentModel.IContainer components = null;

        public string CubeName
        {
            get
            {
                return this.cubeName.Text;
            }
        }

        public JTreeView TreeCube
        {
            get
            {
                return this.treeCubes;
            }
        }

   

        #endregion


        public CubeWizard(Jedox.Palo.Comm.Connection connection, string database)
        {
            #region Init

            InitializeComponent();
            this.wizardTabControl1.SelectTab(0);
            base.SetBtns((TabPageStep)this.wizardTabControl1.SelectedTab);

            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.pnlBottom.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PanelContenerTabs.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.lblDesc1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.lblDesc2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.lblAvailDims.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.lblSelectedDims.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnBack.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnNext.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnFinish.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnUp.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnUp.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnUp.FlatAppearance.BorderColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnUp.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnUp.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnLeft.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnLeft.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnLeft.FlatAppearance.BorderColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnLeft.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnLeft.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnRight.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnRight.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnRight.FlatAppearance.BorderColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnRight.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnRight.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnDown.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnDown.ButtonColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnDown.FlatAppearance.BorderColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnDown.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnDown.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;

            this.currConn = connection;
            this.dbN = database;

            this.btnUp.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconUp;
            this.btnUp.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconUpH;
            this.btnRight.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconRight;
            this.btnRight.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconRightH;
            this.btnLeft.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconLeft;
            this.btnLeft.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconLeftH;
            this.btnDown.ButtonImage = (System.Drawing.Image)ResourceInitializer.IconDown;
            this.btnDown.RolloverImage = (System.Drawing.Image)ResourceInitializer.IconDownH;

            this.lblDesc1.Text = ResourceInitializer.LABEL_CUBE_WIZARD_1;
            this.lblDesc2.Text = ResourceInitializer.LABEL_CUBE_WIZARD_2;
            this.TitleLabel = ResourceInitializer.TITLE_CUBE_WIZARD;
            this.lblAvailDims.Text = ResourceInitializer.LABEL_AVAILABLE_DIMENSIONS;
            this.lblSelectedDims.Text = ResourceInitializer.LABEL_SELECTED_DIMENSIONS;
            this.toolTip.SetToolTip(this.cubeName, ResourceInitializer.TIP_BUTTON_MOVE_UP_DIMENSION);
            this.btnFinish.Text = ResourceInitializer.BUTTON_FINISH;
            this.toolTip.SetToolTip(this.btnFinish, ResourceInitializer.TIP_BUTTON_OK_CUBE_WIZARD);
            this.btnNext.Text = ResourceInitializer.BUTTON_CANCEL;
            this.toolTip.SetToolTip(this.btnNext, ResourceInitializer.TIP_BUTTON_CLOSE_WIZARD);
            this.toolTip.SetToolTip(this.treeDims, ResourceInitializer.TIP_TREE_AVAILABLE_DIMENSIONS);
            this.toolTip.SetToolTip(this.treeCubes, ResourceInitializer.TIP_TREE_SELECTED_DIMENSIONS);
            this.toolTip.SetToolTip(this.btnRight, ResourceInitializer.TIP_BUTTON_MOVE_RIGHT_DIMENSION);
            this.toolTip.SetToolTip(this.btnDown, ResourceInitializer.TIP_BUTTON_MOVE_DOWN_DIMENSION);
            this.toolTip.SetToolTip(this.btnUp, ResourceInitializer.TIP_BUTTON_MOVE_UP_DIMENSION);
            this.toolTip.SetToolTip(this.btnLeft, ResourceInitializer.TIP_BUTTON_MOVE_LEFT_DIMENSION);
            this.Text = ResourceInitializer.TITLE_CUBE_WIZARD;

            #endregion

        }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CubeWizard));
            this.cubeName = new System.Windows.Forms.TextBox();
            this.lblDesc2 = new System.Windows.Forms.Label();
            this.btnLeft = new JControls.JButton();
            this.btnDown = new JControls.JButton();
            this.btnUp = new JControls.JButton();
            this.lblSelectedDims = new System.Windows.Forms.Label();
            this.lblAvailDims = new System.Windows.Forms.Label();
            this.btnRight = new JControls.JButton();
            this.treeCubes = new JControls.JTreeView();
            this.treeDims = new JControls.JTreeView();
            this.lblDesc1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBottom.SuspendLayout();
            this.PanelContenerTabs.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(3, 360);
            this.pnlBottom.Size = new System.Drawing.Size(524, 34);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinish.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnFinish.Location = new System.Drawing.Point(399, 2);
            this.btnFinish.Size = new System.Drawing.Size(99, 23);
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.xpFinish_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.Enabled = false;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBack.Location = new System.Drawing.Point(29, 2);
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNext.Location = new System.Drawing.Point(290, 2);
            this.btnNext.Size = new System.Drawing.Size(99, 23);
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.xpCancel_Click);
            // 
            // PanelContenerTabs
            // 
            this.PanelContenerTabs.BackColor = System.Drawing.SystemColors.Control;
            this.PanelContenerTabs.Size = new System.Drawing.Size(526, 394);
            // 
            // wizardTabControl1
            // 
            this.wizardTabControl1.Size = new System.Drawing.Size(524, 306);
            // 
            // tabPageStep1
            // 
            this.tabPageStep1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep1.Controls.Add(this.lblDesc1);
            this.tabPageStep1.Controls.Add(this.btnLeft);
            this.tabPageStep1.Controls.Add(this.btnDown);
            this.tabPageStep1.Controls.Add(this.btnUp);
            this.tabPageStep1.Controls.Add(this.lblSelectedDims);
            this.tabPageStep1.Controls.Add(this.lblAvailDims);
            this.tabPageStep1.Controls.Add(this.btnRight);
            this.tabPageStep1.Controls.Add(this.treeCubes);
            this.tabPageStep1.Controls.Add(this.treeDims);
            this.tabPageStep1.Controls.Add(this.cubeName);
            this.tabPageStep1.Controls.Add(this.lblDesc2);
            this.tabPageStep1.ShowBackButton = false;
            this.tabPageStep1.Size = new System.Drawing.Size(516, 280);
            // 
            // cubeName
            // 
            this.cubeName.Location = new System.Drawing.Point(126, 33);
            this.cubeName.MaxLength = 186;
            this.cubeName.Name = "cubeName";
            this.cubeName.Size = new System.Drawing.Size(192, 20);
            this.cubeName.TabIndex = 1;
            // 
            // lblDesc2
            // 
            this.lblDesc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc2.Location = new System.Drawing.Point(22, 33);
            this.lblDesc2.Name = "lblDesc2";
            this.lblDesc2.Size = new System.Drawing.Size(64, 23);
            this.lblDesc2.TabIndex = 2;
            // 
            // btnLeft
            // 
            this.btnLeft.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnLeft.ButtonImage = null;
            this.btnLeft.Enabled = false;
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Location = new System.Drawing.Point(242, 169);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.RolloverImage = null;
            this.btnLeft.Size = new System.Drawing.Size(32, 28);
            this.btnLeft.TabIndex = 5;
            this.btnLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnDown.ButtonImage = null;
            this.btnDown.Enabled = false;
            this.btnDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(242, 201);
            this.btnDown.Name = "btnDown";
            this.btnDown.RolloverImage = null;
            this.btnDown.Size = new System.Drawing.Size(32, 28);
            this.btnDown.TabIndex = 6;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnUp.ButtonImage = null;
            this.btnUp.Enabled = false;
            this.btnUp.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(242, 105);
            this.btnUp.Name = "btnUp";
            this.btnUp.RolloverImage = null;
            this.btnUp.Size = new System.Drawing.Size(32, 28);
            this.btnUp.TabIndex = 3;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblSelectedDims
            // 
            this.lblSelectedDims.Location = new System.Drawing.Point(286, 65);
            this.lblSelectedDims.Name = "lblSelectedDims";
            this.lblSelectedDims.Size = new System.Drawing.Size(200, 16);
            this.lblSelectedDims.TabIndex = 9;
            // 
            // lblAvailDims
            // 
            this.lblAvailDims.Location = new System.Drawing.Point(22, 65);
            this.lblAvailDims.Name = "lblAvailDims";
            this.lblAvailDims.Size = new System.Drawing.Size(208, 16);
            this.lblAvailDims.TabIndex = 8;
            // 
            // btnRight
            // 
            this.btnRight.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnRight.ButtonImage = null;
            this.btnRight.Enabled = false;
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRight.Location = new System.Drawing.Point(242, 137);
            this.btnRight.Name = "btnRight";
            this.btnRight.RolloverImage = null;
            this.btnRight.Size = new System.Drawing.Size(32, 28);
            this.btnRight.TabIndex = 4;
            this.btnRight.Click += new System.EventHandler(this.btnAddSelected_Click);
            // 
            // treeCubes
            // 
            //this.treeCubes.AutoEdit = false;
            this.treeCubes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;          //Crownwood.DotNetMagic.Controls.TreeBorderStyle.Solid;
            //this.treeCubes.ColumnWidth = 1;
            //this.treeCubes.FocusNode = null;
            this.treeCubes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.treeCubes.HotBackColor = System.Drawing.Color.Empty;
            //this.treeCubes.HotForeColor = System.Drawing.Color.Empty;
            //this.treeCubes.LineVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.OnlyBelowRoot;
            this.treeCubes.Location = new System.Drawing.Point(286, 81);
            this.treeCubes.Name = "treeCubes";
            this.treeCubes.SelectedNode = null;
            //this.treeCubes.SelectedNoFocusBackColor = System.Drawing.SystemColors.Control;
            this.treeCubes.Size = new System.Drawing.Size(208, 200);
            this.treeCubes.TabIndex = 7;
            this.treeCubes.DoubleClick += new System.EventHandler(this.treeCubes_DoubleClick);
            this.treeCubes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeCubes_KeyDown);
            this.treeCubes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeCubes_MouseUp);
            // 
            // treeDims
            // 
            //this.treeDims.AutoEdit = false;
            this.treeDims.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;           //Crownwood.DotNetMagic.Controls.TreeBorderStyle.Solid;
            //this.treeDims.ColumnWidth = 1;
            //this.treeDims.FocusNode = null;
            this.treeDims.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.treeDims.HotBackColor = System.Drawing.Color.Empty;
            //this.treeDims.HotForeColor = System.Drawing.Color.Empty;
            //this.treeDims.LineVisibility = Crownwood.DotNetMagic.Controls.LineBoxVisibility.OnlyBelowRoot;
            this.treeDims.Location = new System.Drawing.Point(22, 81);
            this.treeDims.Name = "treeDims";
            this.treeDims.SelectedNode = null;
            //this.treeDims.SelectedNoFocusBackColor = System.Drawing.SystemColors.Control;
            this.treeDims.Size = new System.Drawing.Size(208, 200);
            this.treeDims.TabIndex = 2;
            this.treeDims.DoubleClick += new System.EventHandler(this.treeDims_DoubleClick);
            this.treeDims.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeDims_KeyDown);
            this.treeDims.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeDims_MouseUp);
            // 
            // lblDesc1
            // 
            this.lblDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc1.Location = new System.Drawing.Point(6, -1);
            this.lblDesc1.Name = "lblDesc1";
            this.lblDesc1.Size = new System.Drawing.Size(536, 24);
            this.lblDesc1.TabIndex = 16;
            // 
            // CubeWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnNext;
            this.ClientSize = new System.Drawing.Size(682, 395);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CubeWizard";
            this.Load += new System.EventHandler(this.frmWizCube_Load);
            this.pnlBottom.ResumeLayout(false);
            this.PanelContenerTabs.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.tabPageStep1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        #region Button Actions

        static void SortNodeList(NodesCollection snc, ref ArrayList sncal)
        {
            ArrayList tn = new ArrayList(snc);
            ArrayList a = new ArrayList();
            ArrayList b = new ArrayList();

            foreach (JNode t in tn)
            {
                a.Add(t.Index);
            }
            a.Sort();
            foreach (int tmpA in a)
            {
                foreach (JNode t in tn)
                {
                    if (t.Index == tmpA)
                    {
                        b.Add(t);
                        break;
                    }
                }
            }
            sncal = b;
            tn = null;
            a = null;
            b = null;
        }

        private bool FoundDimensionInCube(string dim)
        {
            foreach (JNode tN in this.treeCubes.Nodes)
            {
                if (dim.Equals(tN.Text))
                    return true;
            }
            return false;
        }
        private void btnAddSelected_Click(object sender, System.EventArgs e)
        {
            if (this.treeDims.SelectedNodes != null)
            {
                ArrayList sL = new ArrayList();
                SortNodeList(this.treeDims.SelectedNodes, ref sL);
                foreach (JNode t in sL)
                {
                    bool found = false;
                    found = FoundDimensionInCube(t.Text);
                    if (found == false)
                    {
                        JNode tc = (JNode)t.Clone();
                        this.treeCubes.Nodes.Add(tc);
                    }
                }
            }
        }

        private void btnMoveLeft_Click(object sender, System.EventArgs e)
        {
            this.removeDims();
        }
        /*
        private void btnRemoveAll_Click(object sender, System.EventArgs e)
        {
            this.treeCubes.Nodes.Clear();
        }*/

        private void removeDims()
        {
            if (this.treeCubes.SelectedNode != null)
            {
                if (this.treeCubes.SelectedNodes.Count > 0)
                {
                    try
                    {
                        System.Collections.IEnumerator myEnum = this.treeCubes.SelectedNodes.GetEnumerator();
                        while (myEnum.MoveNext())
                        {
                            JNode t = (JNode)myEnum.Current;
                            this.treeCubes.Nodes.Remove(t);
                        }
                    }
                    catch
                    { }
                }
                this.treeCubes.SelectedNodes.Clear();
                this.treeCubes.SelectedNode = null;
                this.cubeName.Focus();
            }
        }

        private void btnRemoveSelected_Click(object sender, System.EventArgs e)
        {
            this.removeDims();
        }

        private void xpFinish_Click(object sender, System.EventArgs e)
        {
            Jedox.Palo.Comm.Connection c = this.currConn;
            string[] dbCubes = c.DatabaseListCubes(this.dbN);

            if (this.cubeName.Text.Length == 0)
            {
                MessageBox.Show(ResourceInitializer.ERROR_CUBE_NAME_EMPTY);
                this.cubeName.Focus();
                return;
            }
            else if (this.treeCubes.Nodes.Count < 1)
            {
                MessageBox.Show(ResourceInitializer.ERROR_CUBE_NO_DIMENSION);
                return;
            }
            else
            {
                // if cube already exists then make some noise
                foreach (string tmpCube in dbCubes)
                {
                    if (this.cubeName.Text == tmpCube)
                    {
                        MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.ERROR_CUBE_EXISTS, new object[] { tmpCube, this.dbN }));//"Cube " + tmpCube + " already exists in database " + this.dbN + "!\nPlease enter a different name for a current cube.");
                        this.cubeName.Focus();
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnUp_Click(object sender, System.EventArgs e)
        {
            if (this.treeCubes.SelectedNode != null)
            {
                try
                {
                    JNode tN = (JNode)this.treeCubes.SelectedNode.Clone();
                    int tmpInd = this.treeCubes.SelectedNode.Index - 1;
                    if (tmpInd < 0)
                    {
                        tmpInd = 0;
                    }
                    this.treeCubes.SelectedNode.Remove();
                    this.treeCubes.Nodes.Insert(tmpInd, tN);
                    this.treeCubes.SelectedNode = tN;
                }
                finally
                { }
            }
        }

        private void btnDown_Click(object sender, System.EventArgs e)
        {
            if (this.treeCubes.SelectedNode != null)
            {
                try
                {
                    JNode tN = (JNode)this.treeCubes.SelectedNode.Clone();
                    int tmpInd = this.treeCubes.SelectedNode.Index + 1;
                    if (tmpInd >= this.treeCubes.Nodes.Count)
                    {
                        tmpInd = this.treeCubes.Nodes.Count - 1;
                    }
                    this.treeCubes.SelectedNode.Remove();
                    this.treeCubes.Nodes.Insert(tmpInd, (JNode)tN);
                    this.treeCubes.SelectedNode = tN;
                }
                finally
                { }
            }
        }


        #endregion

        #region TreeView

        #region Dims

        private void setDimensionList(Jedox.Palo.Comm.Connection c, string database)
        {
            c.Ping();

            string[] dbDims = c.DatabaseListDimensions(database, Jedox.Palo.Comm.DimensionType.NormalDimension);

            this.treeDims.ClearNodes();

            JNode tN;
            foreach (string Dim in dbDims)
            {
                if (!ListBoxHelper.IsJPaloDim(Dim))
                {
                    tN = new JNode(Dim);
                    tN.NodeFont = this.regularFont;
                    this.treeDims.Nodes.Add(tN);
                }
            }
        }

        private void treeDims_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                                System.Drawing.Point pt = new System.Drawing.Point( e.X, e.Y );
                                this.treeDims.PointToClient( pt );

                                TreeNode Node = this.treeDims.GetNodeAt( pt );
                                if ( Node == null ) return;
                                if ( Node.Bounds.Contains( pt ) )
                                {
                                    this.treeDims.SelectedNode = Node;
                                }
                */
                if (this.treeDims.SelectedNodes.Count > 0)
                {
                    foreach (JNode t in this.treeDims.Nodes)
                    {
                        t.NodeFont = this.regularFont;
                    }
                    //this.treeDims.SelectedNode.NodeFont = this.boldFont;
                }
                this.btnUp.Enabled = false;
                this.btnRight.Enabled = true;
                //this.btnRemoveSelected.Enabled = false;
                this.btnLeft.Enabled = false;
                this.btnDown.Enabled = false;
            }
        }

        private void treeDims_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.treeDims.Nodes != null && this.treeDims.SelectedNode != null)
            {
                JNode tN = (JNode)this.treeDims.SelectedNode.Clone();
                tN.BackColor = System.Drawing.Color.White;
                foreach (JNode t in this.treeCubes.Nodes)
                    {
                    if (t.Text == tN.Text)
                        return;
                    }
                this.treeCubes.Nodes.Add(tN);
                foreach (JNode t in this.treeCubes.Nodes)
                    {
                    t.NodeFont = this.regularFont;
                    }
            }
        }

        #region Tree events
        private void treeDims_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
            {// handle CTRL + A
                if (e.KeyValue == (int)System.Windows.Forms.Keys.A)
                {
                    e.Handled = true;
                    foreach (JNode n in this.treeDims.Nodes)
                    {
                        n.Select(false);
                    }
                }
            }
        }

        private void treeCubes_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
            {// handle CTRL + A
                if (e.KeyValue == (int)System.Windows.Forms.Keys.A)
                {
                    e.Handled = true;
                    foreach (JNode n in this.treeCubes.Nodes)
                    {
                        n.Select(false);
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Cubes

        private void treeCubes_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                                System.Drawing.Point pt = new System.Drawing.Point( e.X, e.Y );
                                this.treeCubes.PointToClient( pt );

                                TreeNode Node = this.treeCubes.GetNodeAt( pt );
                                if ( Node == null ) return;
                                if ( Node.Bounds.Contains( pt ) )
                                {
                                    this.treeCubes.SelectedNode = Node;
                                }
                */
                if (this.treeCubes.SelectedNodes.Count > 0)
                {
                    foreach (JNode t in this.treeCubes.Nodes)
                    {
                        t.NodeFont = this.regularFont;
                    }
                    //this.treeCubes.SelectedNode.NodeFont = this.boldFont;
                }
                this.btnUp.Enabled = true;
                this.btnRight.Enabled = false;
                //this.btnRemoveSelected.Enabled = true;
                this.btnLeft.Enabled = true;
                this.btnDown.Enabled = true;
            }
        }

        private void treeCubes_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.treeCubes.SelectedNode != null)
                this.treeCubes.Nodes.Remove(this.treeCubes.SelectedNode);
        }


        #endregion

        #endregion

        #region OnLoad

        private void frmWizCube_Load(object sender, System.EventArgs e)
        {
            //	this.treeDims.BeginUpdate();
            this.treeDims.ClearNodes();
            this.treeDims.Nodes.Add(new JNode("                                                                                               "));
            //	this.treeDims.EndUpdate();

            //	this.treeCubes.BeginUpdate();
            this.treeCubes.ClearNodes();
            this.treeCubes.Nodes.Add(new JNode("                                                                                               "));
            //	this.treeCubes.EndUpdate();

            this.setDimensionList(this.currConn, this.dbN);
            this.treeCubes.Nodes.Clear();
            this.btnRight.Enabled = false;
            this.cubeName.Select();
            this.cubeName.Focus();
        }


        #endregion



        private void xpCancel_Click(object sender, EventArgs e)
        {
            if (this.treeCubes.Nodes != null
                && this.treeCubes.Nodes.Count > 0)
            {
                if (MessageBox.Show(Apalo.XlAddin.Utils.ResourceInitializer.QUESTION_CUBE_WIZARD, Apalo.XlAddin.Utils.ResourceInitializer.TITLE_CUBE_WIZARD, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    this.DialogResult = DialogResult.Cancel;
                else
                    this.DialogResult = DialogResult.None;
            }
            else
                this.DialogResult = DialogResult.Cancel;
        }












    }
}