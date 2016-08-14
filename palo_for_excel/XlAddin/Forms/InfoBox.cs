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

// Additional Revisions to Palo (c) Junction BI LLC:
// JMM 10-31-13 Update revision #

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
    public partial class InfoBox : Form
    {
        public bool displayLicensePage;
        public int licenseTTL;

        public InfoBox()
        {
            InitializeComponent();
            // JMM 10-31-13
            this.Text = this.Text.Replace("$WCREV$", Properties.Resources.WCREV);

            // check/uncheck annoy box
            chkAnnoyBox.Checked = RegUtils.ShowInfoBox;

            #region Manually assigned resources
            //this.btnDemoApp.Text = ResourceInitializer.InfoBox_btnDemoApp;
            //this.btnFirstSteps.Text = ResourceInitializer.InfoBox_btnFirstSteps;
            //this.btnAdvancedManual.Text = ResourceInitializer.InfoBox_btnAdvancedManual;
            //this.btnTraining.Text = ResourceInitializer.InfoBox_btnTraining;
            this.bntAbout.Text = ResourceInitializer.InfoBox_bntAbout;
            this.btnClose.Text = ResourceInitializer.InfoBox_btnClose;
            this.adTitle.Text = ResourceInitializer.InfoBox_adTitle;
            //this.adTitleLogo.Text = ResourceInitializer.InfoBox_adTitleLogo;
            //this.lblDemoApp.Text = ResourceInitializer.InfoBox_lblDemoApp;
            //this.lblFirstSteps.Text = ResourceInitializer.InfoBox_lblFirstSteps;
            this.lblPaloMenu1.Text = ResourceInitializer.InfoBox_lblPaloMenu1;
            //this.lblMyPalo.Text = ResourceInitializer.InfoBox_lblMyPalo;
            this.lblPaloMenu2.Text = ResourceInitializer.InfoBox_lblPaloMenu2;
            this.chkAnnoyBox.Text = ResourceInitializer.InfoBox_chkAnnoyBox;

            this.btnContinue.Text = ResourceInitializer.LicenseBox_btnContinue;
            this.btnCompare.Text = ResourceInitializer.LicenseBox_btnCompare;
            this.btnCEDownload.Text = ResourceInitializer.LicenseBox_btnCEDownload;
            this.btnQuote.Text = ResourceInitializer.LicenseBox_btnQuote;
            this.lblLicense.Text = ResourceInitializer.LicenseBox_lblLicense;
            this.lblQuote.Text = ResourceInitializer.LicenseBox_lblQuote;
            this.lblComparison.Text = ResourceInitializer.LicenseBox_lblComparison;
            this.lblCommunity.Text = ResourceInitializer.LicenseBox_lblCommunity;
            #endregion

            if (displayLicensePage == true)
            {
                tabControl.SelectedIndex = 1;
            }
        }

        #region Button event handling InfoBox
        private void bntAbout_Click(object sender, EventArgs e)
        {
            About a = new About(false, "");
            a.ShowDialog();
            a.Dispose();
            a = null;
        }

        private void chkAnnoyBox_CheckedChanged(object sender, EventArgs e)
        {
            RegUtils.ShowInfoBox = chkAnnoyBox.Checked;
        }

        private void btnDemoApp_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Retry;                
            }
            catch
            { }
        }

        private void btnFirstSteps_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Connect.firstStepsURL);
            }
            catch
            { }
        }

        private void btnAdvancedManual_Click(object sender, EventArgs e)
        {
            if (Connect.mItemAdvancedHelp.Enabled == true)
            {
                Connect.myPalo();
            }
            else
            {
                PaloOnline.registerMyPalo();
            }
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Connect.PaloOnlineLanguage)
                {
                    case "de":
                        System.Diagnostics.Process.Start("http://www.jedox.com/de/services/schulungen.html");
                        break;

                    case "fr":
                        System.Diagnostics.Process.Start("http://www.jedox.com/fr/service/formation.html");
                        break;

                    default:
                        System.Diagnostics.Process.Start("http://www.jedox.com/en/services/Training.html");
                        break;
                }
            }
            catch
            { }
        }
        #endregion

        #region Button event Handling License Box
        private void btnContinue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Connect.PaloOnlineLanguage)
                {
                    case "de":
                        System.Diagnostics.Process.Start("http://www.jedox.com/de/produkte/price-wizard/price-wizard.html");
                        break;

                    case "fr":
                        System.Diagnostics.Process.Start("http://www.jedox.com/fr/produits/price-wizard/price-wizard.html");
                        break;

                    default:
                        System.Diagnostics.Process.Start("http://www.jedox.com/en/products/price-wizard/price-wizard.html");
                        break;
                }
                
            }
            catch
            { }
        }

        private void btnCEDownload_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Connect.PaloOnlineLanguage)
                {
                    case "de":
                        System.Diagnostics.Process.Start("http://www.jedox.com/de/download/palo-downloads-current-version/weitere-downloads-3.1.html");
                        break;

                    case "fr":
                        System.Diagnostics.Process.Start("http://www.jedox.com/fr/download/Palo-Downloads-current-version/plus-de-telechargement.html");
                        break;

                    default:
                        System.Diagnostics.Process.Start("http://www.jedox.com/en/downloads/Palo-Downloads-current-version/further-palo-downloads.html");
                        break;
                }

            }
            catch
            { }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Connect.PaloOnlineLanguage)
                {
                    case "de":
                        System.Diagnostics.Process.Start("http://www.jedox.com/de/produkte/Uebersicht-palo-supported-open-source-vs-premium.html");
                        break;

                    case "fr":
                        System.Diagnostics.Process.Start("http://www.jedox.com/fr/produits/apercu-palo-supported-open-source-vs-premium.html");
                        break;

                    default:
                        System.Diagnostics.Process.Start("http://www.jedox.com/en/products/overview-palo-supported-open-source-vs-premium.html");
                        break;
                }

            }
            catch
            { }
        }
        #endregion

        private void InfoBox_VisibleChanged(object sender, EventArgs e)
        {
            // display license tab if in "license mode"
            // othervise InfoBox
            if (this.displayLicensePage == true)
            {
                this.tabControl.SelectedIndex = 1;
                if (licenseTTL > 1)
                {
                    // as required display TTL for > 1 days left
                    this.lblLicense.Text = ResourceInitializer.Replace(ResourceInitializer.LicenseBox_lblLicense, new object[] { licenseTTL });
                }
                else
                {
                    // display expires if 1 day left or expired
                    this.lblLicense.Text = ResourceInitializer.LicenseBox_lblLicenseExpired;
                }
            }
            else
            {
                this.tabControl.SelectedIndex = 0;
            }
        }

        
    }
}