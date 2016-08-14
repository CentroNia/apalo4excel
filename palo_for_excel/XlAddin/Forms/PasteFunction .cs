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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Apalo.XlAddin.Forms.Controls;
using Apalo.XlAddin.Utils;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.Forms
{
	[ComVisible(false)]
	public class PasteFunction : Form
	{
		private Size oldsize = new Size(0,0);
        private ArrayList Opts;

		private Connection currConn;
		
		private System.ComponentModel.IContainer components = null;
		private Label PFlabel2;
		private Label PFlabel1;

        private Button PFbutton_paste;
        private Button PFbutton_cancel;

		private ListBox PFcubeslist;
		private CheckBox PFcheck_guess;
		private ComboBox PFdatamode;
        private CheckBox PFattribute;
        private ConnComboBox PFserverlist;

        public PasteFunction(ref ArrayList opts)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //
			// Add any constructor code after InitializeComponent call
			//

            this.PFbutton_paste.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PFbutton_paste.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PFbutton_paste.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;

            this.PFbutton_cancel.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.PFbutton_cancel.FlatAppearance.MouseDownBackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PFbutton_cancel.FlatAppearance.MouseOverBackColor = ResourceInitializer.FormStdBackgroundColor;

            this.PFdatamode.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.BackColor = ResourceInitializer.FormStdBackgroundColor;

            this.PFbutton_paste.Text = ResourceInitializer.BUTTON_PASTE;
            this.PFbutton_cancel.Text = ResourceInitializer.BUTTON_CANCEL;

            this.PFlabel2.Text = ResourceInitializer.TEXT_CHOOSE_CUBE;

            this.PFlabel1.Text = ResourceInitializer.TEXT_CHOOSE_SERVER_DB;
            this.PFcheck_guess.Text = ResourceInitializer.TEXT_GUESS_ARG;
            this.PFattribute.Text = ResourceInitializer.TEXT_ATTRIBUTE_CUBES;

            this.Text = ResourceInitializer.TITLE_PASTE_FUNCTION;

			this.PFdatamode.SelectedIndex = 1;
			this.PFbutton_cancel.Click += new System.EventHandler(this.PFbutton_cancel_Click);
			this.PFbutton_paste.Click += new System.EventHandler(this.PFbutton_paste_Click);
            this.PFattribute.CheckedChanged += new System.EventHandler(this.PFattribute_CheckedChanged);
            
			this.oldsize = this.Size;
			this.Resize += new System.EventHandler(this.frmPasteFunc_Resize);

            this.PFattribute.Visible = true;
            this.initCombo();

            this.set_default(ref opts);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasteFunction));
            this.PFbutton_cancel = new System.Windows.Forms.Button();
            this.PFbutton_paste = new System.Windows.Forms.Button();
            this.PFcubeslist = new System.Windows.Forms.ListBox();
            this.PFlabel2 = new System.Windows.Forms.Label();
            this.PFlabel1 = new System.Windows.Forms.Label();
            this.PFcheck_guess = new System.Windows.Forms.CheckBox();
            this.PFdatamode = new System.Windows.Forms.ComboBox();
            this.PFattribute = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // PFbutton_cancel
            // 
            this.PFbutton_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.PFbutton_cancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PFbutton_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PFbutton_cancel.Location = new System.Drawing.Point(211, 384);
            this.PFbutton_cancel.Name = "PFbutton_cancel";
            this.PFbutton_cancel.Size = new System.Drawing.Size(80, 24);
            this.PFbutton_cancel.TabIndex = 2;
            this.PFbutton_cancel.Text = "Cancel";
            // 
            // PFbutton_paste
            // 
            this.PFbutton_paste.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PFbutton_paste.Enabled = false;
            this.PFbutton_paste.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.PFbutton_paste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PFbutton_paste.Location = new System.Drawing.Point(211, 352);
            this.PFbutton_paste.Name = "PFbutton_paste";
            this.PFbutton_paste.Size = new System.Drawing.Size(80, 26);
            this.PFbutton_paste.TabIndex = 1;
            this.PFbutton_paste.Text = "Paste";
            // 
            // PFcubeslist
            // 
            this.PFcubeslist.Location = new System.Drawing.Point(8, 64);
            this.PFcubeslist.Name = "PFcubeslist";
            this.PFcubeslist.Size = new System.Drawing.Size(283, 277);
            this.PFcubeslist.Sorted = true;
            this.PFcubeslist.TabIndex = 5;
            // 
            // PFlabel2
            // 
            this.PFlabel2.Location = new System.Drawing.Point(8, 48);
            this.PFlabel2.Name = "PFlabel2";
            this.PFlabel2.Size = new System.Drawing.Size(121, 16);
            this.PFlabel2.TabIndex = 21;
            this.PFlabel2.Text = "Choose Cubes:";
            this.PFlabel2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // PFlabel1
            // 
            this.PFlabel1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.PFlabel1.Location = new System.Drawing.Point(8, 8);
            this.PFlabel1.Name = "PFlabel1";
            this.PFlabel1.Size = new System.Drawing.Size(224, 16);
            this.PFlabel1.TabIndex = 20;
            this.PFlabel1.Text = "Choose Server/database:";
            this.PFlabel1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.PFlabel1.UseMnemonic = false;
            // 
            // PFcheck_guess
            // 
            this.PFcheck_guess.Location = new System.Drawing.Point(8, 352);
            this.PFcheck_guess.Name = "PFcheck_guess";
            this.PFcheck_guess.Size = new System.Drawing.Size(201, 24);
            this.PFcheck_guess.TabIndex = 22;
            this.PFcheck_guess.Text = "Guess Arguments";
            // 
            // PFdatamode
            // 
            this.PFdatamode.BackColor = System.Drawing.SystemColors.Control;
            this.PFdatamode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PFdatamode.Items.AddRange(new object[] {
            "PALO.DATA",
            "PALO.DATAC",
            "PALO.DATAX",
            "PALO.DATAV",
            "PALO.SETDATA"});
            this.PFdatamode.Location = new System.Drawing.Point(8, 376);
            this.PFdatamode.Name = "PFdatamode";
            this.PFdatamode.Size = new System.Drawing.Size(121, 21);
            this.PFdatamode.TabIndex = 23;
            // 
            // PFattribute
            // 
            this.PFattribute.BackColor = System.Drawing.Color.Transparent;
            this.PFattribute.Location = new System.Drawing.Point(144, 48);
            this.PFattribute.Name = "PFattribute";
            this.PFattribute.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PFattribute.Size = new System.Drawing.Size(147, 16);
            this.PFattribute.TabIndex = 39;
            this.PFattribute.Text = "Attributes";
            this.PFattribute.UseVisualStyleBackColor = false;
            // 
            // PasteFunction
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.PFbutton_cancel;
            this.ClientSize = new System.Drawing.Size(299, 432);
            this.Controls.Add(this.PFattribute);
            this.Controls.Add(this.PFdatamode);
            this.Controls.Add(this.PFcheck_guess);
            this.Controls.Add(this.PFlabel2);
            this.Controls.Add(this.PFlabel1);
            this.Controls.Add(this.PFcubeslist);
            this.Controls.Add(this.PFbutton_paste);
            this.Controls.Add(this.PFbutton_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(307, 456);
            this.Name = "PasteFunction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Cube";
            this.ResumeLayout(false);

		}
		#endregion

		public void set_default(ref ArrayList opts)
		{
            this.Opts = opts;
            this.Opts.Clear();

			this.setCombo();
            this.PFserverlist.SetItem();

            string actCube = RegUtils.ActiveCube;
			if (actCube != "")
			{
				this.PFcubeslist.SelectedItem = actCube;
			}
		}
		
		private void do_exit(bool cancel)
		{
            this.PFserverlist.SaveItem();

            if (this.PFcubeslist.SelectedItem != null)
            {
                RegUtils.ActiveCube = this.PFcubeslist.SelectedItem.ToString();
            }
            
            if (cancel) this.DialogResult = DialogResult.Cancel; else this.DialogResult = DialogResult.OK;
		}

        private void do_paste()
        {
            string database = this.PFserverlist.GetDatabase();

            if (!string.IsNullOrEmpty(database))
            {
                ExcelHelper eH = new ExcelHelper();
                Connect.InPaste = false;
                ExcelHelper.SetScreenUpdating(false);
                ExcelHelper.SetScreenUpdating(true);

                string datamode = GeneralConst.PALO_DATAX;

                if (this.PFdatamode.SelectedIndex != -1)
                {
                    datamode = this.PFdatamode.Items[this.PFdatamode.SelectedIndex].ToString();
                }
                ExcelHelper.SetScreenUpdating(true);
                Excel.XlCalculation oldcalc = ExcelHelper.DisableAutomaticRecalc();
                ExcelHelper.SetScreenUpdating(false);
                if (this.PFcubeslist.SelectedItem != null)
                {
                    this.Opts.Add(eH.paste_func(this.currConn, this.PFserverlist.GetConnectionName(), database, this.PFcubeslist.SelectedItem.ToString(), datamode, this.PFcheck_guess.Checked));
                }

                if (oldcalc != Excel.XlCalculation.xlCalculationAutomatic)
                {
                    ExcelHelper.CalculateSpreadsheet();
                }

                ExcelHelper.SetCalculation(oldcalc);

                ExcelHelper.SetScreenUpdating(true);
                Connect.InPaste = true;
            }
        }

		private void PFbutton_cancel_Click(object sender, System.EventArgs e)
		{
			this.do_exit(true);
		}
		
		private void PFbutton_paste_Click(object sender, System.EventArgs e)
		{
			this.do_exit(false);
			this.do_paste();
		}

		private void frmPasteFunc_Resize(object sender, System.EventArgs e)
		{
			Size newsize = ((Control)sender).Size;

			if (!this.oldsize.IsEmpty && !newsize.IsEmpty && this.Visible)
			{
				int dx = newsize.Width - this.oldsize.Width;
				int dy = newsize.Height - this.oldsize.Height;

				this.SuspendLayout();

				this.PFserverlist.Width += dx;

				this.PFbutton_paste.Left += dx; 
				this.PFbutton_paste.Top += dy; 

				this.PFcheck_guess.Top += dy;
                this.PFattribute.Left += dx;

                this.PFbutton_cancel.Left += dx; 
				this.PFbutton_cancel.Top += dy; 

				this.PFdatamode.Width += dx;
				this.PFdatamode.Top += dy;

				this.PFcubeslist.Width += dx;
				this.PFcubeslist.Height = this.PFbutton_paste.Top - this.PFcubeslist.Top - 8;

				this.ResumeLayout();
			}

			if ((!newsize.IsEmpty && this.Visible) || this.oldsize.IsEmpty)
			{
				this.oldsize = newsize;
			}

		}

		private void get_cubes(string dbN)
		{
            try
            {
                this.currConn = this.PFserverlist.GetConnection();
                List<string> dbCubes = ListBoxHelper.GetCubeList(this.currConn, dbN, (this.PFattribute.Checked) ? GeneralConst.ATTRIBUTE_CUBE_VIEW : GeneralConst.NORMAL_CUBE_VIEW, true);

                this.PFcubeslist.SelectedIndex = -1;
                this.PFcubeslist.Items.Clear();

                int i, lsize = dbCubes.Count;

                for(i=0; i < lsize; i++)
			    {
                    this.PFcubeslist.Items.Add(dbCubes[i]);
			    }

			    if (this.PFcubeslist.Items.Count > 0)
			    {
				    this.PFcubeslist.SelectedIndex = 0;
			    }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error setting Cube Combobox.", exc);
            }
        }

        private void get_cubes()
        {
            this.PFcubeslist.Items.Clear();
            string database = this.PFserverlist.GetDatabase();
            this.PFattribute.Enabled = !string.IsNullOrEmpty(database);

            if (PFattribute.Enabled)
            {
                this.get_cubes(database);
            }
            this.PFbutton_paste.Enabled = (this.PFcubeslist.SelectedItem != null);
        }

        
        private void PFserverlist_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            this.get_cubes();
        }

        private void initCombo()
        {
            Size serverlistsize = new System.Drawing.Size(this.PFcubeslist.Width, 21);

            if (this.PFserverlist == null)
            {

                this.SuspendLayout();
                this.PFserverlist = new ConnComboBox();

                this.PFserverlist.AccessibleRole = AccessibleRole.ComboBox;
                this.PFserverlist.BackColor = ResourceInitializer.FormStdBackgroundColor; ;
                this.PFserverlist.CausesValidation = false;
                this.PFserverlist.DisplayMember = "Text";
                this.PFserverlist.DrawMode = DrawMode.OwnerDrawFixed;
                this.PFserverlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                this.PFserverlist.Location = new System.Drawing.Point(this.PFlabel1.Left, this.PFlabel1.Top + this.PFlabel1.Height);
                this.PFserverlist.MaxLength = 1;
                this.PFserverlist.Name = "PFserverlist";
                this.PFserverlist.Size = serverlistsize;
                this.PFserverlist.TabIndex = 2;
                this.PFserverlist.Text = ResourceInitializer.TIP_COMBO_CONNECTIONS;
                this.PFserverlist.ValueMember = "Text";
                this.PFserverlist.DropDownStyle = ComboBoxStyle.DropDownList;

                this.PFserverlist.SelectedIndexChanged += new System.EventHandler(this.PFserverlist_SelectedIndexChanged);

                this.PFserverlist.SuspendLayout();
                this.PFcubeslist.Items.Clear();
                this.PFserverlist.ResumeLayout();
                this.PFserverlist.Refresh();
                this.Controls.Add(this.PFserverlist);
                this.ResumeLayout(false);
            }
        }

		private void setCombo()
		{
            this.PFserverlist.FillList(-1, ConnectionsHelper.HandleDatabase.WithSystem);
		}

        private void PFattribute_CheckedChanged(object sender, System.EventArgs e)
        {
            this.get_cubes();
        }

	}
}
