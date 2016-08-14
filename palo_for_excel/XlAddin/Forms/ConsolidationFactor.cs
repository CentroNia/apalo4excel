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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Apalo.XlAddin.Forms
{
	/// <summary>
	/// Summary description for ConsolidationFactor.
	/// </summary>
	[ComVisible(false)]
	public class ConsolidationFactor : System.Windows.Forms.Form
	{
		private Button btnCancel;
		private Button btnOk;
		private System.Windows.Forms.Label lblFactor;
		private System.Windows.Forms.NumericUpDown InputFactor;

		public decimal Factor
		{
			get
			{
				return this.InputFactor.Value;
			}
			set
			{
				decimal tmpFactor = System.Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture);
				this.InputFactor.Value = tmpFactor;
			}
		}

		private System.ComponentModel.Container components = null;

		public ConsolidationFactor()
		{
			InitializeComponent();
            this.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.lblFactor.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.lblFactor.Text = Utils.ResourceInitializer.LABEL_HEADER_FACTOR;
            this.btnCancel.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnCancel.Text = Utils.ResourceInitializer.BUTTON_CANCEL;
            this.btnOk.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnOk.Text = Utils.ResourceInitializer.BUTTON_OK;
            this.Text = Utils.ResourceInitializer.CMD_FACTOR;

		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsolidationFactor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblFactor = new System.Windows.Forms.Label();
            this.InputFactor = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.InputFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(96, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(16, 48);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            // 
            // lblFactor
            // 
            this.lblFactor.Location = new System.Drawing.Point(0, 5);
            this.lblFactor.Name = "lblFactor";
            this.lblFactor.Size = new System.Drawing.Size(72, 23);
            this.lblFactor.TabIndex = 0;
            this.lblFactor.Text = "Factor:";
            this.lblFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InputFactor
            // 
            this.InputFactor.DecimalPlaces = 3;
            this.InputFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.InputFactor.Location = new System.Drawing.Point(72, 8);
            this.InputFactor.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.InputFactor.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.InputFactor.Name = "InputFactor";
            this.InputFactor.Size = new System.Drawing.Size(76, 20);
            this.InputFactor.TabIndex = 1;
            this.InputFactor.ThousandsSeparator = true;
            this.InputFactor.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // ConsolidationFactor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(186, 80);
            this.Controls.Add(this.InputFactor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblFactor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsolidationFactor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consolidation Factor";
            ((System.ComponentModel.ISupportInitialize)(this.InputFactor)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}
