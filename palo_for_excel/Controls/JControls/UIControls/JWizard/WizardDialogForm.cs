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

using System.ComponentModel;
using System.Windows.Forms;

namespace JControls
{
    [Designer(typeof(MyUCDesigner))]
    public partial class WizardDialogForm : Form
    {

        public WizardDialogForm()
        {
            InitializeComponent();   
        }

        public virtual void wizardTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            SetBtns((TabPageStep)e.TabPage);
        }

        public void SetBtns(TabPageStep tps)
        {

            if (!tps.ShowBackButton) this.btnBack.Visible = this.btnBack.Enabled = false; else this.btnBack.Visible = this.btnBack.Enabled = true;

            if (!tps.ShowNextButton) this.btnNext.Visible = this.btnNext.Enabled = false; else this.btnNext.Visible = this.btnNext.Enabled = true;

            if (!tps.ShowFinishButton) this.btnFinish.Visible = this.btnFinish.Enabled = false; else this.btnFinish.Visible = this.btnFinish.Enabled = true;
        }

        public virtual void button_event(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;

            if ((string)btn.Tag == "1") //Next
            {
                if (this.wizardTabControl1.SelectedIndex < this.wizardTabControl1.TabPages.Count - 1)
                {

                    this.wizardTabControl1.SelectTab(this.wizardTabControl1.SelectedIndex + 1);
                }
            }
            if ((string)btn.Tag == "-1") //Back
            {
                if (this.wizardTabControl1.SelectedIndex > 0)
                {
                    this.wizardTabControl1.SelectTab(this.wizardTabControl1.SelectedIndex - 1);
                }
            }
            if ((string)btn.Tag == "0") //Finish
            {
                Close();
            }
        }

    }
}