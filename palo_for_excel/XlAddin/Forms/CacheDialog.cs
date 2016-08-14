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
 *	 http://www.jedox.com/license_palo_bi_suite.txt
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using aPalo.XlAddin.Utils;

namespace aPalo.XlAddin.Forms
{
	public partial class CacheDialog : Form
	{
		private Jedox.Palo.Comm.Connection m_conn;
		private string m_db;

		public CacheDialog(Jedox.Palo.Comm.Connection c, string db)
		{
			#region Assign private members
			m_conn = c;
			m_db = db;
			#endregion

			InitializeComponent();
			this.BackColor = ResourceInitializer.FormStdBackgroundColor;
			this.tabCacheSettings.BackColor = ResourceInitializer.FormStdBackgroundColor;
			this.groupBox1.BackColor = ResourceInitializer.FormStdBackgroundColor;
			this.radioButton1.BackColor = ResourceInitializer.FormStdBackgroundColor;
			this.radioButton2.BackColor = ResourceInitializer.FormStdBackgroundColor;
			this.radioButton3.BackColor = ResourceInitializer.FormStdBackgroundColor;
			this.button1.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;

			#region Manually assigned resources
			button1.Text = Utils.ResourceInitializer.BUTTON_OK;
			radioButton1.Text = Utils.ResourceInitializer.CacheRadio1Label;
			radioButton2.Text = Utils.ResourceInitializer.CacheRadio2Label;
			radioButton3.Text = Utils.ResourceInitializer.CacheRadio3Label;
			groupBox1.Text = Utils.ResourceInitializer.CacheDialogGroupCaption;
			this.tabCacheSettings.Title = Utils.ResourceInitializer.CacheDialogGroupCaption;
			this.Text = Utils.ResourceInitializer.CacheDialogCaption;

			toolTip1.SetToolTip(radioButton1, Utils.ResourceInitializer.TipCacheRadio1);
			toolTip1.SetToolTip(radioButton2, Utils.ResourceInitializer.TipCacheRadio2);
			toolTip1.SetToolTip(radioButton3, Utils.ResourceInitializer.TipCacheRadio3);
			toolTip1.SetToolTip(button1, Utils.ResourceInitializer.TIP_BUTTON_OK_CUBE_WIZARD);
			#endregion

			#region Set initial values
			string tmpStrVal = "";
			double tmpDblVal = 0;

			try
			{
				m_conn.GetData(ref tmpStrVal, ref tmpDblVal, m_db, "#_CONFIGURATION", new string[] { "ClientCache" });
			}
			catch (Jedox.Palo.Comm.PaloException)
			{ }

			if (tmpStrVal == "N")
				this.radioButton1.Checked = true;
			else if (tmpStrVal == "Y")
				this.radioButton2.Checked = true;
			else
				this.radioButton3.Checked = true;
			#endregion
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{

			try
			{
				m_conn.SetData(m_db, "#_CONFIGURATION", new string[] { "ClientCache" }, "N");
			}
			catch (Jedox.Palo.Comm.PaloException)
			{ }
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				m_conn.SetData(m_db, "#_CONFIGURATION", new string[] { "ClientCache" }, "Y");
			}
			catch (Jedox.Palo.Comm.PaloException)
			{ }
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				m_conn.SetData(m_db, "#_CONFIGURATION", new string[] { "ClientCache" }, "E");
			}
			catch (Jedox.Palo.Comm.PaloException)
			{ }
		}
	}
}
