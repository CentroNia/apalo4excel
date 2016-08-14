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
using JControls;
using Apalo.XlAddin.Utils;
using System.Collections;

namespace Apalo.XlAddin.Forms
{
    public partial class ClearCube : WizardDialogForm
    {

        private const string CLEARCUBE = "ClearCube";
        private byte CubeViewStatus;

        #region Construct

        public ClearCube(int dummyid, string cube, byte CubeViewStatus)
        {
            if (String.IsNullOrEmpty(cube) && dummyid != 0)
            {
                return;
            }

            this.CubeViewStatus = CubeViewStatus;
            InitializeComponent();
            this.wizardTabControl1.SelectTab(0);
            base.SetBtns((TabPageStep)this.wizardTabControl1.SelectedTab);
            this.panel4.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.panel3.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.pnlBottom.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.PanelContenerTabs.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tabPageStep1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.splitContainer1.Panel2.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btnNext.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnFinish.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btnBack.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;

            this.SelectedElements = new ArrayList();

            this.btnNext.Text = ResourceInitializer.ButtonClearCube;
            this.btnFinish.Text = ResourceInitializer.BUTTON_CLOSE;
            this.btnBack.Text = ResourceInitializer.ButtonClearWholeCube;
            this.TitleLabel = ResourceInitializer.ClearCubeCaption;
            this.Text = ResourceInitializer.ClearCubeCaption;
            this.LeftPanelImage = ResourceInitializer.WizardLogo;

            this.toolTip1.SetToolTip(this.btnNext, ResourceInitializer.ButtonClearCubeTip);
            this.toolTip1.SetToolTip(this.btnFinish, ResourceInitializer.BUTTON_CANCEL);
            this.toolTip1.SetToolTip(this.btnBack, ResourceInitializer.ButtonClearWholeCubeTip);

            this.refreshCombo();

            this.comboCubes.SelectedItem = cube;

            if (String.IsNullOrEmpty(cube) && dummyid == 0)
            {
                this.comboConnList.Enabled = true;
                this.comboCubes.Enabled = true;
                try
                {
                    this.preselectComboConnList();
                    this.comboCubes.SetItem(RegUtils.ActiveCube);
                }
                catch
                {}
            }
            else
            {
                this.comboConnList.Enabled = false;
                // If cube is already empty, cube cannot be selected.
                if (!String.Equals(this.comboCubes.SelectedItem.ToString(), cube, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.comboCubes.SelectedIndex = -1;
                }
                this.comboCubes.Enabled = false;
            }
        }
        #endregion

        private void preselectComboConnList()
        {
            comboConnList.SetItem();
        }

        #region  Clear All
        private void button3_Click(object sender, EventArgs e)
        {
            string dbN = this.comboConnList.GetDatabase();
            string tmpCube = this.comboCubes.SelectedItem.ToString();
            
            if (MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.TEXT_CLEAR_CUBE, new object[] { tmpCube }), ResourceInitializer.TEXT_CLEAR_CUBE_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.ClearCubeStatus);

                try
                {
                    this.currConn.CubeClear(dbN, tmpCube);
                    MessageBox.Show(ResourceInitializer.MessageWholeClearCube, ResourceInitializer.ButtonClearWholeCube, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, ResourceInitializer.ButtonClearWholeCube, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ErrorHandler.DisplayError("Error clearing cube.", exc);
                }

                ExcelHelper.SetExcelStatusbar(null);
            }
        }
        #endregion

        #region Clear Slice
        private void button1_Click(object sender, EventArgs e)
        {
            string dbN = this.comboConnList.GetDatabase();
            string tmpCube = this.comboCubes.SelectedItem.ToString();

            long anzahl = this.SelectedElements.Count;
            long anzahl2;
            object[] werte;
            System.Collections.ArrayList tmpL;
            bool clearAll = true;

            if (MessageBox.Show(ResourceInitializer.Replace(ResourceInitializer.TEXT_CLEAR_CUBE, new object[] { tmpCube }), ResourceInitializer.TEXT_CLEAR_CUBE_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                for (int i = 0; i < anzahl; i++)
                {
                    werte = (object[])this.SelectedElements[i];
                    if (((ArrayList)werte[1]).Count != 0)
                    {
                        clearAll = false;
                        break;
                    }
                }

                ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.ClearCubeStatus);

                try
                {
                    if (clearAll)
                    {
                        this.currConn.CubeClear(dbN, tmpCube);
                    }
                    else
                    {
                        String[][] dimelements = new String[anzahl][];
                        for (int i = 0; i < anzahl; i++)
                        {
                            werte = (object[])this.SelectedElements[i];
                            tmpL = (System.Collections.ArrayList)werte[1];
                            anzahl2 = tmpL.Count;
                            if (anzahl2 != 0)
                            {
                                dimelements[i] = new String[anzahl2];
                                for (int j = 0; j < anzahl2; j++)
                                {
                                    dimelements[i][j] = (string)((object[])tmpL[j])[0];
                                }
                            }
                            else
                            {
                                dimelements[i] = new String[0];
                            }
                        }
                        this.currConn.CubeClear(dbN, tmpCube, dimelements);
                    }

                    MessageBox.Show(ResourceInitializer.MessageClearCube, ResourceInitializer.ButtonClearCube, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, ResourceInitializer.ButtonClearCube, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Apalo.XlAddin.Utils.ErrorHandler.DisplayError("Error clearing cube.", exc);
                }
                ExcelHelper.SetExcelStatusbar(null);
            }
        }
        #endregion

        #region Handling restore form's size/position
        private void ClearCube_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                RegUtils.SetFormProperties(CLEARCUBE, new int[4] { this.Left, this.Top, this.Width, this.Height });
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            }
            else
            {
                int[] tmpProps = RegUtils.GetFormProperties(CLEARCUBE);

                if (tmpProps[0] != -1)
                {
                    this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                    this.Left = tmpProps[0];
                    this.Top = tmpProps[1];
                }
                else
                {
                    this.StartPosition = FormStartPosition.CenterScreen;
                }
            }
        }
        #endregion

        private void ClearCube_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.comboCubes.SaveItem();
        }










    }
}