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

using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using JControls;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
    [ComVisible(false)]
    public class DimTemplate : WizardDialogForm
    {


        private Font regularFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

        private Jedox.Palo.Comm.Connection currConn;
        private string dbN;

       
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCaption;
   
        private System.Windows.Forms.TextBox dimName;
        public string DimName
        {
            get
            {
                return this.dimName.Text;
            }
        }
        private Label labelComment;
        private ListBox listBoxTemplates;
        private Label labelTemplates;
        private System.Windows.Forms.ToolTip toolTip;
      
 
        public string Template
        {
            get
            {
                return this.listBoxTemplates.SelectedItem as string;
            }
        }
        private System.ComponentModel.IContainer components;

        #region Construct / Destruct
        public DimTemplate(Jedox.Palo.Comm.Connection connection, string database)
        {
       

            InitializeComponent();
            this.wizardTabControl1.SelectTab(0);
            base.SetBtns((TabPageStep)this.wizardTabControl1.SelectedTab);

            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.wizardTabControl1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.pnlBottom.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PanelContenerTabs.BackColor = ResourceInitializer.FormStdBackgroundColor;

            this.btnBack.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnNext.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnFinish.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;

            this.currConn = connection;
            this.dbN = database;

            this.LeftPanelImage= ResourceInitializer.WizardLogo;
 

            this.labelCaption.Text = ResourceInitializer.LabelDimTemplateCaption;
            this.labelName.Text = ResourceInitializer.LabelDimName;
            this.TitleLabel = ResourceInitializer.TitleDimTemplate;
            this.labelTemplates.Text = ResourceInitializer.LabelTemplate;
            this.toolTip.SetToolTip(this.dimName, ResourceInitializer.TIP_BUTTON_MOVE_UP_DIMENSION);
            this.btnFinish.Text = ResourceInitializer.BUTTON_FINISH;
            this.toolTip.SetToolTip(this.btnFinish, ResourceInitializer.TIP_BUTTON_OK_CUBE_WIZARD);
            this.btnNext.Text = ResourceInitializer.BUTTON_CANCEL;
            this.toolTip.SetToolTip(this.btnNext, ResourceInitializer.TIP_BUTTON_CLOSE_WIZARD);
            this.Text = ResourceInitializer.TitleDimTemplate;
            this.dimName.Focus();
            this.dimName.Select();

        }

        #endregion




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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DimTemplate));
            this.labelComment = new System.Windows.Forms.Label();
            this.listBoxTemplates = new System.Windows.Forms.ListBox();
            this.labelTemplates = new System.Windows.Forms.Label();
            this.dimName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCaption = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBottom.SuspendLayout();
            this.PanelContenerTabs.SuspendLayout();
            this.wizardTabControl1.SuspendLayout();
            this.tabPageStep1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(3, 370);
            this.pnlBottom.Size = new System.Drawing.Size(528, 29);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinish.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnFinish.Location = new System.Drawing.Point(418, 2);
            this.btnFinish.Size = new System.Drawing.Size(99, 23);
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.xpFinish_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.Enabled = false;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBack.Location = new System.Drawing.Point(27, 4);
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNext.Location = new System.Drawing.Point(313, 2);
            this.btnNext.Size = new System.Drawing.Size(99, 23);
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.xpCancel_Click);
            // 
            // PanelContenerTabs
            // 
            this.PanelContenerTabs.BackColor = System.Drawing.SystemColors.Control;
            this.PanelContenerTabs.Size = new System.Drawing.Size(530, 402);
            // 
            // wizardTabControl1
            // 
            this.wizardTabControl1.Location = new System.Drawing.Point(3, 49);
            this.wizardTabControl1.Size = new System.Drawing.Size(524, 319);
            // 
            // tabPageStep1
            // 
            this.tabPageStep1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStep1.Controls.Add(this.labelComment);
            this.tabPageStep1.Controls.Add(this.listBoxTemplates);
            this.tabPageStep1.Controls.Add(this.labelTemplates);
            this.tabPageStep1.Controls.Add(this.dimName);
            this.tabPageStep1.Controls.Add(this.labelName);
            this.tabPageStep1.Controls.Add(this.labelCaption);
            this.tabPageStep1.ShowBackButton = false;
            this.tabPageStep1.Size = new System.Drawing.Size(516, 293);
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(3, 93);
            this.labelComment.MaximumSize = new System.Drawing.Size(190, 200);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(73, 13);
            this.labelComment.TabIndex = 22;
            this.labelComment.Text = "labelComment";
            // 
            // listBoxTemplates
            // 
            this.listBoxTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTemplates.FormattingEnabled = true;
            this.listBoxTemplates.Location = new System.Drawing.Point(148, 68);
            this.listBoxTemplates.Name = "listBoxTemplates";
            this.listBoxTemplates.Size = new System.Drawing.Size(365, 225);
            this.listBoxTemplates.TabIndex = 21;
            this.listBoxTemplates.SelectedIndexChanged += new System.EventHandler(this.listBoxTemplates_SelectedIndexChanged);
            this.listBoxTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxTemplates_KeyDown);
            // 
            // labelTemplates
            // 
            this.labelTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplates.Location = new System.Drawing.Point(3, 64);
            this.labelTemplates.Name = "labelTemplates";
            this.labelTemplates.Size = new System.Drawing.Size(139, 16);
            this.labelTemplates.TabIndex = 19;
            this.labelTemplates.Text = "labelTemplates";
            // 
            // dimName
            // 
            this.dimName.AcceptsReturn = true;
            this.dimName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dimName.Location = new System.Drawing.Point(148, 38);
            this.dimName.MaxLength = 186;
            this.dimName.Name = "dimName";
            this.dimName.Size = new System.Drawing.Size(365, 20);
            this.dimName.TabIndex = 1;
            this.dimName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dimName_KeyDown);
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(3, 41);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(139, 23);
            this.labelName.TabIndex = 18;
            this.labelName.Text = "labelName";
            // 
            // labelCaption
            // 
            this.labelCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaption.Location = new System.Drawing.Point(1, 3);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(513, 32);
            this.labelCaption.TabIndex = 17;
            this.labelCaption.Text = "labelCaption";
            // 
            // DimTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 400);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DimTemplate";
            this.Load += new System.EventHandler(this.DimTemplate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DimTemplate_KeyDown);
            this.pnlBottom.ResumeLayout(false);
            this.PanelContenerTabs.ResumeLayout(false);
            this.wizardTabControl1.ResumeLayout(false);
            this.tabPageStep1.ResumeLayout(false);
            this.tabPageStep1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region Button Actions

        private void xpFinish_Click(object sender, System.EventArgs e)
        {
            this.do_finish();
        }

        private void do_finish()
        {
            string[] dbDims = null;
            try
            {
                Jedox.Palo.Comm.Connection c = this.currConn;
                dbDims = c.DatabaseListDimensions(this.dbN);

            }
            catch (System.Exception ex)
            {
                Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error getting dimensions.", ex);
            }

            if (this.dimName.Text.Length == 0)
            {
                MessageBox.Show(ResourceInitializer.ERROR_DIMENSION_NAME_EMPTY);
                this.dimName.Focus();
                return;
            }
            else
            {
                // if cube already exists then make some noise
                foreach (string tmpDim in dbDims)
                {
                    if (this.dimName.Text == tmpDim)
                    {
                        MessageBox.Show(ResourceInitializer.ERROR_DIMENSION_EXISTS);//"Dimension already exists");
                        this.dimName.Focus();
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        #endregion

        #region OnLoad

        private void DimTemplate_Load(object sender, System.EventArgs e)
        {
            this.labelComment.Text = "";
            this.listBoxTemplates.Items.Clear();

            try
            {
                this.listBoxTemplates.Items.Add(ResourceInitializer.TextWithoutTemplate);
                string[] files = Directory.GetFiles(RegUtils.DimensionTemplatePath, "*.txt");
             
                foreach (string file in files)
                {
                    this.listBoxTemplates.Items.Add(FileHelper.getbasename(file));
                }

                if (files.Length > 0)
                {
                    this.listBoxTemplates.SelectedIndex = 0;
                }
            }
            catch (System.Exception ep)
            {
                Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error reading Dimension templates !", ep);
            }
        }

        #endregion

        #region Button events
        private void xpCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        private void listBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = RegUtils.DimensionTemplatePath + "\\" + (this.listBoxTemplates.SelectedItem as string) + ".txt"; // containing the whole path
            string Data = "";
            labelComment.Text = "";
            try
            {
                StreamReader sr = new StreamReader(fileName, System.Text.Encoding.GetEncoding(0));
                //Loop till no further data is available
                while(sr.Peek() > 0)
                {
                    //Read a line of data from the StreamReader object
                    Data = sr.ReadLine();
                    if (Data.StartsWith("## Comment:"))
                    {
                        string comment = Data.Substring(12);
                        labelComment.Text += comment + GeneralConst.UNIX_NEWLINE;
                    }
                }
            }
            catch
            {

            }
        }

        private void DimTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            // RETURN
            if (e.KeyValue == (int)System.Windows.Forms.Keys.Return)
            {
                e.Handled = true;
                try
                {
                    this.do_finish();
                }
                catch
                { }
            }
        }

        private void dimName_KeyDown(object sender, KeyEventArgs e)
        {
            // RETURN
            if (e.KeyValue == (int)System.Windows.Forms.Keys.Return)
            {
                e.Handled = true;
                try
                {
                    this.do_finish();
                }
                catch
                { }
            }
        }

        private void listBoxTemplates_KeyDown(object sender, KeyEventArgs e)
        {
            // RETURN
            if (e.KeyValue == (int)System.Windows.Forms.Keys.Return)
            {
                e.Handled = true;
                try
                {
                    this.do_finish();
                }
                catch
                { }
            }
        }
    }
}
