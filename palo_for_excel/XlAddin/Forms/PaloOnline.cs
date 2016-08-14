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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
    public partial class PaloOnline : Form
    {
        private const string PALOONLINE = "PaloOnline";
        private const string STAYLOGGEDIN = "StayLoggedIn";


        public PaloOnline()
        {
            InitializeComponent();
            
            #region Handling restore form's size/position
            int[] tmpProps = RegUtils.GetFormProperties(PALOONLINE);
            if (tmpProps[0] != -1)
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Size = new System.Drawing.Size(tmpProps[2], tmpProps[3]);
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
            }
            else
            {
                this.Size = new System.Drawing.Size(487, 312);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            #endregion			

            #region Resources
            //this.keepLoginData.Text = ResourceInitializer.AddSubset;
            this.lblUsername.Text = ResourceInitializer.lblPaloOnlineUsername;
            this.lblPassword.Text = ResourceInitializer.lblPaloOnlinePassword;
            this.lnkPaloOnline.Text = ResourceInitializer.lblPaloOnlineLink;
            this.lblWhyRegister.Text = ResourceInitializer.lblPaloOnlineText;
            this.txtWhyRegister.Text = ResourceInitializer.txtPaloOnline;
            this.Text = ResourceInitializer.strPaloOnlineTitle;
            this.btnOk.Text = ResourceInitializer.btnPaloOnlineOK;
            this.btnCancel.Text = ResourceInitializer.btnPaloOnlineCancel;
            #endregion

            #region Registry
            // read initial settings from registry
            this.inpUsername.Text = Crypto.DESd(RegUtils.PaloOnlineUsername);
            this.inpPassword.Text = Crypto.DESd(RegUtils.PaloOnlinePassword);
            #endregion
        }

        private static string url
        {
            get
            {
                switch (Connect.PaloOnlineLanguage)
                {
                    case "de":
                        return Connect.myPaloURL + "?id=1198";

                    case "fr":
                        return Connect.myPaloURL + "?id=1208";

                    default:
                        return Connect.myPaloURL + "?id=1202";
                }
            }
        }

        private int GetUDRegData()
        {
            return RegUtils.GetIntValue4Form(PALOONLINE, STAYLOGGEDIN, 0);
        }

        private void SetUDRegData(object value)
        {
            RegUtils.SetKeyValue4Form(PALOONLINE, STAYLOGGEDIN, value);
        }

        public static void registerMyPalo()
        {
            System.Diagnostics.Process.Start(url);
        }

        private void lnkPaloOnline_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registerMyPalo();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // write username/password to registry on exit
            RegUtils.PaloOnlineUsername = Crypto.DESe(this.inpUsername.Text);
            RegUtils.PaloOnlinePassword = Crypto.DESe(this.inpPassword.Text);

            // enable/disable advanced button
            Connect.enablePaloOnline = ((this.inpUsername.Text.Length != 0) && (this.inpPassword.Text.Length != 0));
        }
    }
}