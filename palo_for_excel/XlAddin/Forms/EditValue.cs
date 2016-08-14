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
using System.Windows.Forms;
using Apalo.XlAddin.Utils;
using Excel = Microsoft.Office.Interop.Excel;

namespace Apalo.XlAddin.Forms
{
	/// <summary>
	/// Summary description for EditValue.
	/// </summary>
	public class EditValue : System.Windows.Forms.Form
	{
		private Button xpButton1;
		private Button xpButton2;
		private System.Windows.Forms.Label labelValue;
		public System.Windows.Forms.TextBox Value;
		private string[] tmpConnStr;
		private string tmpCube;
		private string[] tmpCoords;
		private double dbl_result;
		private string str_result;
		private Jedox.Palo.Comm.Connection currConn;
		public string Formula;
		private System.Windows.Forms.TextBox numChars;
		private System.Windows.Forms.Label labelChars;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditValue()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.labelValue.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.labelChars.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.xpButton1.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.xpButton2.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;

			this.xpButton1.Text = ResourceInitializer.BUTTON_OK;
			this.xpButton2.Text = ResourceInitializer.BUTTON_CANCEL;
			this.Text = ResourceInitializer.TITLE_EDIT_VALUE;
			this.labelValue.Text = (GeneralConst.isNewExcel()) ? ResourceInitializer.LABEL_EDIT_VALUE_2007 : ResourceInitializer.LABEL_EDIT_VALUE;
			this.labelChars.Text = ResourceInitializer.LABEL_CHARS_NUMBER;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditValue));
            this.xpButton1 = new System.Windows.Forms.Button();
            this.xpButton2 = new System.Windows.Forms.Button();
            this.labelValue = new System.Windows.Forms.Label();
            this.Value = new System.Windows.Forms.TextBox();
            this.numChars = new System.Windows.Forms.TextBox();
            this.labelChars = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xpButton1
            // 
            this.xpButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.xpButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpButton1.Location = new System.Drawing.Point(501, 248);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(75, 24);
            this.xpButton1.TabIndex = 21;
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // xpButton2
            // 
            this.xpButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.xpButton2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.xpButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpButton2.Location = new System.Drawing.Point(416, 248);
            this.xpButton2.Name = "xpButton2";
            this.xpButton2.Size = new System.Drawing.Size(75, 24);
            this.xpButton2.TabIndex = 20;
            // 
            // labelValue
            // 
            this.labelValue.Location = new System.Drawing.Point(16, 8);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(560, 40);
            this.labelValue.TabIndex = 0;
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Value
            // 
            this.Value.AcceptsReturn = true;
            this.Value.AcceptsTab = true;
            this.Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Value.Location = new System.Drawing.Point(16, 48);
            this.Value.MaxLength = 8388608;
            this.Value.Multiline = true;
            this.Value.Name = "Value";
            this.Value.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Value.Size = new System.Drawing.Size(560, 192);
            this.Value.TabIndex = 10;
            this.Value.TextChanged += new System.EventHandler(this.Value_TextChanged);
            this.Value.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Value_KeyDown);
            // 
            // numChars
            // 
            this.numChars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numChars.Location = new System.Drawing.Point(269, 248);
            this.numChars.Name = "numChars";
            this.numChars.ReadOnly = true;
            this.numChars.Size = new System.Drawing.Size(56, 20);
            this.numChars.TabIndex = 11;
            this.numChars.TabStop = false;
            // 
            // labelChars
            // 
            this.labelChars.Location = new System.Drawing.Point(16, 248);
            this.labelChars.Name = "labelChars";
            this.labelChars.Size = new System.Drawing.Size(248, 24);
            this.labelChars.TabIndex = 0;
            this.labelChars.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EditValue
            // 
            this.AcceptButton = this.xpButton1;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.xpButton2;
            this.ClientSize = new System.Drawing.Size(594, 288);
            this.Controls.Add(this.labelChars);
            this.Controls.Add(this.numChars);
            this.Controls.Add(this.Value);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.xpButton2);
            this.Controls.Add(this.xpButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditValue";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditValue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ParseFormula()
		{
			// parse old formula
			string tmpFormula = this.Formula.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
            int pos = 0;

            if (tmpFormula.IndexOf("=" + GeneralConst.PALO_DATA + "(") != -1)
            {
                pos = 11;
            }
            else if (tmpFormula.IndexOf("=" + GeneralConst.PALO_DATAC + "(") != -1)
            {
                pos = 12;
            }
            else if (tmpFormula.IndexOf("=" + GeneralConst.PALO_DATAX + "(") != -1)
            {
                pos = 12;
            }
            else if (tmpFormula.IndexOf("=" + GeneralConst.PALO_DATAT + "(") != -1)
            {
                pos = 12;
            }
            else if (tmpFormula.IndexOf("=" + GeneralConst.PALO_DATATC + "(") != -1)
            {
                pos = 13;
            }

            tmpFormula = this.Formula.Substring(pos);
			tmpFormula = tmpFormula.Substring(0, tmpFormula.Length - 1);

			string[] b = tmpFormula.Split(',');
            if (b.LongLength == 1)
            {
                b = tmpFormula.Split(';');
            }

			// write data to server	
			ExcelHelper eH = new ExcelHelper();
            Excel._Worksheet ws = ExcelHelper.GetActiveWorkSheet();

			try
			{
				this.tmpConnStr = eH.get_value(b[0], ws).Split('/');
				this.tmpCube = eH.get_value(b[1], ws);
				this.tmpCoords = new string[b.LongLength - 2];
				this.dbl_result = 0;
				this.str_result = null;
				
				for(int i = 2; i < b.LongLength; i++)
				{
					this.tmpCoords.SetValue( eH.get_value(b[i], ws), i - 2);
				}
			}
			catch
			{}
		}

		public void CheckValue()
		{
			try
			{
				if(this.currConn == null)
				{
					this.ParseFormula();
                    this.currConn = Apalo.XlAddin.Connections.GetConnection(tmpConnStr[0]);
				}

				this.currConn.GetData(ref this.str_result, ref this.dbl_result, this.tmpConnStr[1], this.tmpCube, this.tmpCoords);
                if (str_result != null)
                {
                    this.Value.Text = this.str_result.Replace(GeneralConst.UNIX_NEWLINE, GeneralConst.WINDOWS_NEWLINE);
                }
                else
                {
                    this.Value.Text = this.dbl_result.ToString();
                }
			}
			catch
			{}

			this.numChars.Text = this.Value.Text.Length.ToString();
		}

		private void xpButton1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.currConn == null)
				{
					this.ParseFormula();
                    this.currConn = Apalo.XlAddin.Connections.GetConnection(this.tmpConnStr[0]);
				}

				if(this.Value.Text != null)
				{
                    string tmpText = this.Value.Text.Replace(System.Environment.NewLine.ToString(), GeneralConst.UNIX_NEWLINE);
					this.currConn.SetData(tmpConnStr[1], tmpCube, tmpCoords, tmpText);
				}
			}
			catch(Exception writeExc)
			{
				ErrorHandler.DisplayError("Error writing Value", writeExc);
			}
			finally
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private void Value_TextChanged(object sender, System.EventArgs e)
		{
			this.numChars.Text = this.Value.Text.Length.ToString();
		}

		private void Value_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.Alt && (e.KeyValue == (int)Keys.Enter))
            {// handle Alt + Enter
                e.Handled = true;
                int tmpPos = this.Value.SelectionStart;
                string partOne = this.Value.Text.Substring(0, tmpPos);
                string partTwo = this.Value.Text.Substring(tmpPos);
                this.Value.Text = partOne + System.Environment.NewLine + partTwo;
                this.Value.Focus();
                this.Value.Select(tmpPos + System.Environment.NewLine.Length, 1);
            }
            else
            {
                if (e.Control && (e.KeyValue == (int)Keys.A))
                {// handle CTRL + A
                    e.Handled = true;
                    this.Value.SelectAll();
                }
            }
		}

		private void EditValue_Load(object sender, System.EventArgs e)
		{
			this.Value.Focus();
			this.Value.Select(this.Value.Text.Length, 1);
		}
	}
}
