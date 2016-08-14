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

using Apalo.XlAddin.Forms.Controls;

namespace Apalo.XlAddin.Forms
{
    #region ComboConn related

    using System.Collections;
    using Jedox.Palo.Comm;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Apalo.XlAddin.Utils;
    using JControls;

    #endregion
    

    partial class ClearCube
    {
        #region Defs

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolTip toolTip1;
        private ArrayList SelectedElements;
        private CubeComboBox comboCubes;
        private System.Windows.Forms.SplitContainer splitContainer1;
      
        private System.Windows.Forms.Panel panel3;
     
        private System.Windows.Forms.Label PFlabel2;
        private System.Windows.Forms.Label PFlabel1;
     
        private Panel panel4;
    
        // Filter-buttons
        private Button btData;
        private Button btAttr;
        private Button btUser;
        private int entryTabIndex = 100;

        #region ComboConn Related

        private Connection currConn;
        private ConnComboBox comboConnList;
        private string ActiveDB;
        private string ActiveHostname;

        #endregion

        #endregion

        #region Destruct
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

                #endregion

        /// <summary>
        /// Required designer variable.
        /// </summary>
     

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>






        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClearCube));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PFlabel1 = new System.Windows.Forms.Label();
            this.PFlabel2 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.PanelContenerTabs.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(3, 361);
            this.pnlBottom.Size = new System.Drawing.Size(460, 33);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFinish.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnFinish.Location = new System.Drawing.Point(335, 2);
            this.btnFinish.Size = new System.Drawing.Size(116, 23);
            this.btnFinish.TabIndex = 2002;
            this.btnFinish.Text = "";
            this.btnFinish.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBack.Location = new System.Drawing.Point(19, 2);
            this.btnBack.Size = new System.Drawing.Size(116, 23);
            this.btnBack.TabIndex = 2000;
            this.btnBack.Text = "";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNext.Location = new System.Drawing.Point(146, 2);
            this.btnNext.Size = new System.Drawing.Size(116, 23);
            this.btnNext.TabIndex = 2001;
            this.btnNext.Text = "";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // PanelContenerTabs
            // 
            this.PanelContenerTabs.BackColor = System.Drawing.SystemColors.Control;
            // 
            // wizardTabControl1
            // 
            this.wizardTabControl1.Location = new System.Drawing.Point(3, 53);
            this.wizardTabControl1.Size = new System.Drawing.Size(460, 310);
            // 
            // tabPageStep1
            // 
            this.tabPageStep1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep1.Controls.Add(this.panel3);
            this.tabPageStep1.Controls.Add(this.panel4);
            this.tabPageStep1.Size = new System.Drawing.Size(452, 284);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(3, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(449, 203);
            this.panel3.TabIndex = 101;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Location = new System.Drawing.Point(-2, -6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(457, 87);
            this.panel4.TabIndex = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(150, 100);
            this.splitContainer1.TabIndex = 0;
            // 
            // PFlabel1
            // 
            this.PFlabel1.Location = new System.Drawing.Point(0, 0);
            this.PFlabel1.Name = "PFlabel1";
            this.PFlabel1.Size = new System.Drawing.Size(100, 23);
            this.PFlabel1.TabIndex = 0;
            // 
            // PFlabel2
            // 
            this.PFlabel2.Location = new System.Drawing.Point(0, 0);
            this.PFlabel2.Name = "PFlabel2";
            this.PFlabel2.Size = new System.Drawing.Size(100, 23);
            this.PFlabel2.TabIndex = 0;
            // 
            // ClearCube
            // 
            this.AcceptButton = this.btnFinish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(618, 395);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClearCube";
            this.Text = "";
            this.VisibleChanged += new System.EventHandler(this.ClearCube_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClearCube_FormClosing);
            this.pnlBottom.ResumeLayout(false);
            this.PanelContenerTabs.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region Combo related

        #region Helpers

        public void set_default()
        {
            this.setCombo();
            
            this.CubeViewStatus = GeneralConst.NORMAL_CUBE_VIEW;

            this.get_cubes();
        }

        private void get_cubes()
        {
            this.clearGroupBoxes();
            this.comboCubes.RefreshList(this.comboConnList, this.currConn, this.CubeViewStatus, true);
        }

        #endregion

        #region Conn Combo

        private void initCombo()
        {
            if (this.panel4 != null && this.panel4.Controls != null)
            {
                this.panel4.Controls.Clear();
            }

            // 
            // PFlabel1
            // 
            this.PFlabel1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PFlabel1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.PFlabel1.Location = new System.Drawing.Point(12, 4);
            this.PFlabel1.Name = "PFlabel1";
            this.PFlabel1.Size = new System.Drawing.Size(224, 16);
            //this.PFlabel1.TabIndex = 22;
            this.PFlabel1.Text = ResourceInitializer.TEXT_CHOOSE_SERVER_DB;
            this.PFlabel1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.PFlabel1.UseMnemonic = false;
            // 
            // PFlabel2
            // 
            this.PFlabel2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PFlabel2.Location = new System.Drawing.Point(12, 42);
            this.PFlabel2.Name = "PFlabel2";
            this.PFlabel2.Size = new System.Drawing.Size(224, 16);
            //this.PFlabel2.TabIndex = 23;
            this.PFlabel2.Text = ResourceInitializer.TEXT_CHOOSE_CUBE;
            this.PFlabel2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

            this.comboConnList = new ConnComboBox();
            this.comboCubes = new CubeComboBox();
            // Filter-buttons
            this.btData = new Button();
            this.btAttr = new Button();
            this.btUser = new Button();
            // 
            // comboCubes
            // 
            this.comboCubes.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.comboCubes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCubes.Enabled = false;
            this.comboCubes.Location = new System.Drawing.Point(12, 60);
            this.comboCubes.MaxLength = 1;
            this.comboCubes.Name = "comboCubes";
            this.comboCubes.Size = new System.Drawing.Size(262, 21);
            this.comboCubes.TabIndex = 11;
            this.toolTip1.SetToolTip(this.comboCubes, ResourceInitializer.TIP_CHOOSE_CUBE);
            //this.Controls.Add(this.comboCubes);
            this.comboCubes.EnabledChanged += new EventHandler(comboCubes_EnabledChanged);
            this.comboCubes.SelectedIndexChanged += new System.EventHandler(this.comboCubes_SelectedIndexChanged);
            //
            // btData
            //
            this.btData.Enabled = false;
            this.btData.FlatAppearance.BorderColor = Color.LightSteelBlue;
            this.btData.FlatStyle = FlatStyle.Flat;
            this.btData.Location = new Point(280, 60);
            this.btData.Name = "btData";
            this.btData.Size = new Size(21, 21);
            this.btData.TabIndex = 12;
            this.btData.UseVisualStyleBackColor = true;
            this.btData.Click += new EventHandler(btData_Click);
            //
            // btAttr
            //
            this.btAttr.Enabled = false;
            this.btAttr.FlatAppearance.BorderColor = Color.LightSteelBlue;
            this.btAttr.FlatStyle = FlatStyle.Flat;
            this.btAttr.Location = new Point(307, 60);
            this.btAttr.Name = "btAttr";
            this.btAttr.Size = new Size(21, 21);
            this.btAttr.TabIndex = 13;
            this.btAttr.UseVisualStyleBackColor = false;
            this.btAttr.Click += new EventHandler(btAttr_Click);
            //
            // btUser
            //
            this.btUser.Enabled = false;
            this.btUser.FlatAppearance.BorderColor = Color.LightSteelBlue;
            this.btUser.FlatStyle = FlatStyle.Flat;
            this.btUser.Location = new Point(334, 60);
            this.btUser.Name = "btUser";
            this.btUser.Size = new Size(21, 21);
            this.btUser.TabIndex = 14;
            this.btUser.UseVisualStyleBackColor = false;
            this.btUser.Click += new EventHandler(btUser_Click);

            // 
            // comboConnList
            // 
            this.comboConnList.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.comboConnList.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.comboConnList.CausesValidation = false;
            this.comboConnList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboConnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.comboConnList.MaxLength = 1;
            this.comboConnList.Location = new System.Drawing.Point(12, 19);//8, 17);//10);
            this.comboConnList.Name = "comboConnList";
            this.comboConnList.Size = new System.Drawing.Size(262, 21);
            this.comboConnList.TabIndex = 10;
            this.comboConnList.Tag = "myCustomCombo";
            this.Controls.Add(this.comboConnList);
            this.comboConnList.SelectedIndexChanged += new System.EventHandler(this.comboConnList_SelectedIndexChanged);
            this.comboConnList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.panel4.Controls.Add(this.comboConnList);
            this.panel4.Controls.Add(this.PFlabel1);
            this.panel4.Controls.Add(this.PFlabel2);
            this.panel4.Controls.Add(this.comboCubes);
            this.panel4.Controls.Add(this.btData);
            this.panel4.Controls.Add(this.btAttr);
            this.panel4.Controls.Add(this.btUser);
            this.toolTip1.SetToolTip(this.btData, ResourceInitializer.TipCubeFilterData);
            this.toolTip1.SetToolTip(this.btAttr, ResourceInitializer.TipCubeFilterAttribute);
            this.toolTip1.SetToolTip(this.btUser, ResourceInitializer.TipCubeFilterUser);
            this.btUser.Image = (Image)ResourceInitializer.IconFilterUserOn;
            this.btData.Image = (Image)ResourceInitializer.IconFilterDataOn;
            this.btAttr.Image = (Image)ResourceInitializer.IconFilterAttributeOn;
            switch (this.CubeViewStatus)
            {
                case GeneralConst.NORMAL_CUBE_VIEW:
                    this.btData.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
                    break;
                case GeneralConst.ATTRIBUTE_CUBE_VIEW:
                    this.btAttr.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
                    break;
                case GeneralConst.SYSTEM_CUBE_VIEW:
                    this.btUser.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
                    break;
            }
        }

        private void refreshCombo()
        {
            XmlUtils.ReadXmlInitial();
            if (this.comboConnList == null)
            {
                this.initCombo();
            }
            this.setCombo();
        }

        private void setCombo()
        {
            this.comboConnList.Text = ResourceInitializer.TIP_COMBO_CONNECTIONS;
            this.toolTip1.SetToolTip(this.comboConnList, ResourceInitializer.TIP_COMBO_CONNECTIONS);

            comboConnList.FillList(-1, ConnectionsHelper.HandleDatabase.NoRestriction);
            preselectComboConnList();
        }

        private void comboConnList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.ActiveHostname = this.comboConnList.GetConnectionName();
            this.ActiveDB = this.comboConnList.GetDatabase();
            this.currConn = this.comboConnList.GetConnection();

            this.clearGroupBoxes();

            if (string.IsNullOrEmpty(this.ActiveDB))
            {
                this.comboCubes.Enabled = false;
                this.btnBack.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                this.comboCubes.Enabled = true;
                this.get_cubes();

                this.do_btnFilter(this.CubeViewStatus);
                this.btnBack.Enabled = true;
                this.btnNext.Enabled = true;

                this.comboConnList.SaveItem();
            }

            if (this.comboConnList.Text != null)
            {
                this.toolTip1.SetToolTip(this.comboConnList, this.comboConnList.Text);
            }
        }

        #endregion

        #region Cubes combo

        private void clearGroupBoxes()
        {
            this.panel3.Controls.Clear();
            this.SelectedElements.Clear();
        }

        private void comboCubes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.clearGroupBoxes();
            if (this.comboCubes.SelectedIndex != -1 && this.comboConnList.SelectedIndex != -1)
            {
                string[] cubDims = this.currConn.CubeListDimensions(this.comboConnList.GetDatabase(), this.comboCubes.SelectedItem.ToString());

                int currTmpBtn = 0;
                entryTabIndex = 100;
                foreach (string cubDim in cubDims)
                {
                    this.AddDimensionEntry(ref this.PanelContenerTabs, cubDim, currTmpBtn);//Kleut
                    this.SelectedElements.Add(new object[] { cubDim, new ArrayList() });
                    currTmpBtn++;
                    entryTabIndex += 10;
                }
                this.btnBack.Enabled = true;
                this.btnNext.Enabled = true;
                this.comboCubes.SaveItem();
            }
            else
            {
                this.btnBack.Enabled = false;
                this.btnNext.Enabled = false;
            }

        }

        #endregion

        #endregion


        #region Add dimension entry in the list

        public void b_Click(object sender, System.EventArgs e)
        {
            Button b = (Button)sender;
            int currItem = 0;
            for (int i = 0; i < this.SelectedElements.Count; i++)
            {
                object[] o = (object[])this.SelectedElements[i];

                if ((string)o[0] == (string)b.Tag)
                    break;
                currItem++;
            }

            System.Object[] tmpSelection = (System.Object[])this.SelectedElements[currItem];
            ArrayList currElements = (ArrayList)tmpSelection[1];

            Apalo.XlAddin.Forms.ChooseElements frmename = new Apalo.XlAddin.Forms.ChooseElements(this.ActiveHostname + "/" + this.ActiveDB, (string)b.Tag);
            frmename.set_selection(ref currElements, true, "");
            if (frmename.ShowDialog() == DialogResult.OK)
            {
                string tmpToolTip = " ";
                int tmpCounter = 0;
                tmpSelection[1] = currElements;
                foreach (object[] s in currElements)
                {
                    if (tmpCounter > 10)
                    {
                        tmpToolTip += (string)s[0] + "...,";
                        break;
                    }

                    tmpToolTip += (string)s[0] + ",";

                    tmpCounter++;
                }

                tmpToolTip = tmpToolTip.Substring(0, tmpToolTip.Length - 1).Trim();

                if (String.IsNullOrEmpty(tmpToolTip))
                {
                    tmpToolTip = "(" + ResourceInitializer.LABEL_SELECT_ALL_ELEMENTS + ")";
                }

                for (int i = 0; i < this.panel3.Controls.Count; i++)
                {
                    System.Windows.Forms.Control l = (System.Windows.Forms.Control)this.panel3.Controls[i];
                    if (l.Tag != null && l.Name != null && l.Name == "label" && l.Tag == b.Tag)
                    {
                        if (tmpToolTip.Length < 55)
                            l.Text = tmpToolTip;
                        else
                            l.Text = tmpToolTip.Substring(0, 54) + "...";
                        break;
                    }
                }
            }
            frmename.Dispose();
            frmename = null;

        }

        public void AddDimensionEntry(ref System.Windows.Forms.Panel p1, string dim, int pos)
        {
            if (p1 == null || String.IsNullOrEmpty(dim))
                return;

            System.Windows.Forms.Button d = new System.Windows.Forms.Button();
            System.Windows.Forms.Button b = new System.Windows.Forms.Button();
            Label l = new Label();
            string dimLabel = "";

            if (dim.Length < 12)
                dimLabel = dim;
            else
                dimLabel = dim.Substring(0, 11);

            d.BackColor = ResourceInitializer.FormStdBackgroundColor;
            d.Text = dimLabel;
            d.FlatStyle = FlatStyle.Flat;
            d.Width = 85;
            d.Height = 23;
            d.Left = 6;
            d.Top = 8 + pos * 23;
            d.Tag = dim;
            this.toolTip1.SetToolTip(d, dim);
            d.TabIndex = entryTabIndex;

            b.BackColor = ResourceInitializer.FormStdBackgroundColor;
            b.Text = "...";
            b.FlatStyle = FlatStyle.Flat;
            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.01f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b.Margin = new System.Windows.Forms.Padding(0);
            b.Padding = new System.Windows.Forms.Padding(0);
            b.Width = 24;
            b.Height = d.Height;
            b.Left = d.Right - 1;
            b.Top = d.Top;
            b.Click += new EventHandler(b_Click);
            b.Tag = d.Tag;
            this.toolTip1.SetToolTip(b, ResourceInitializer.TIP_CHOOSE_ELEMENTS);
            b.Name = "sibling";
            b.TabIndex = entryTabIndex + 1;

            l.BackColor = ResourceInitializer.FormStdBackgroundColor;
            l.Text = "(" + ResourceInitializer.LABEL_SELECT_ALL_ELEMENTS + ")";
            l.FlatStyle = FlatStyle.Flat;
            l.Width = 325;
            l.Height = d.Height - 1;
            l.Left = b.Right + 7;
            l.Top = d.Top + 1;
            l.Tag = d.Tag;
            l.Name = "label";
            l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            panel3.Controls.Add(d);
            panel3.Controls.Add(b);
            panel3.Controls.Add(l);
        }

        #endregion

        #region filter buttons

        private void btData_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.NORMAL_CUBE_VIEW);
        }

        private void btAttr_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.ATTRIBUTE_CUBE_VIEW);
        }

        private void btUser_Click(object sender, System.EventArgs e)
        {
            this.do_btnFilter(GeneralConst.SYSTEM_CUBE_VIEW);
        }

        private void do_btnFilter(byte CubeViewStatus)
        {
            this.CubeViewStatus = CubeViewStatus;
            this.btData.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btAttr.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btUser.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;

            if (CubeViewStatus == GeneralConst.NORMAL_CUBE_VIEW)
            {
                this.btData.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            else if (CubeViewStatus == GeneralConst.ATTRIBUTE_CUBE_VIEW)
            {
                this.btAttr.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            else if (CubeViewStatus == GeneralConst.SYSTEM_CUBE_VIEW)
            {
                this.btUser.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            this.get_cubes();
        }

        private void comboCubes_EnabledChanged(object sender, EventArgs e)
        {
            if (comboCubes.Enabled)
            {
                btData.Enabled = true;
                btUser.Enabled = true;
                btAttr.Enabled = true;
            }
            else
            {
                btData.Enabled = false;
                btUser.Enabled = false;
                btAttr.Enabled = false;
            }
        }

        #endregion








































    }
}