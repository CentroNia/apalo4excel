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
using Jedox.Palo.Comm;
using System.Xml;
using System.IO;
using System.Collections;
using Apalo.XlAddin.Utils;

 
 namespace Apalo.XlAddin.Forms
{
    public partial class RuleEditorAdvanced : Form
    {
        #region Defines

        private const string RULEEDITORADVANCED = "RuleEditorAdvanced";
        Entity SelectedCube;
        CubeType tmpCubeType;
        // JControls.Constants.MAX_ENTITIES controls the number of entities
        // can't be more than 500 anyway
        int elemCntLimit = 100;
        #endregion

        public Connection conn;
        public string currDb;
        public string currCube;
        private byte currCubeType;
        
        public RuleEditorAdvanced(Connection conn, string currCube, byte cubeType, string currDb)
        {
            if (conn == null)
            {
                return;
            }

            this.conn = conn;
            this.currCube = currCube;
            this.currDb = currDb;
            this.currCubeType = cubeType;

            JControls.Constants.strNone = ResourceInitializer.RB_PRIORITY_NONE;
            JControls.Constants.strNColon = ResourceInitializer.RB_PRIORITY_N;
            JControls.Constants.strCColon = ResourceInitializer.RB_PRIORITY_C;

            // read the definition from XML
            string xmlText = conn.ListRuleFunctions();
            System.Text.ASCIIEncoding myEncoder = new System.Text.ASCIIEncoding();
            byte[] bytes = myEncoder.GetBytes(xmlText);
            MemoryStream ms = new MemoryStream(bytes);
            XMLDescription.Instance.Reader = new XmlTextReader(ms);

            this.FillAutoCompleteList(false);

            InitializeComponent();
            this.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.btParse.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btCancel.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btCollapseAll.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btExpandAll.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btOk.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btRefreshList.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.btShowComment.BackColor = ResourceInitializer.FormStdButtonBackgroundColor;
            this.lbComment.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.lbRuleTitle.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.panel1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.rbRule.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.tableLayoutPanel1.BackColor = ResourceInitializer.FormStdBackgroundColor;
            this.Icon = ResourceInitializer.IconPalo;

            btOk.Text = ResourceInitializer.BUTTON_OK;
            btCancel.Text = ResourceInitializer.BUTTON_CANCEL;
            btExpandAll.Text = ResourceInitializer.TEXT_EXPAND_ALL;
            btCollapseAll.Text = ResourceInitializer.TEXT_COLLAPSE_ALL;
            btParse.Text = ResourceInitializer.BUTTON_PARSE;
            btRefreshList.Text = ResourceInitializer.BUTTON_REFRESH_LIST;
            lbRuleTitle.Text = ResourceInitializer.TEXT_RULE;
            this.Text = ResourceInitializer.TEXT_RULEEDITOR_ADVANCED;
            lbComment.Text = ResourceInitializer.TEXT_COMMENT;
            btShowComment.Text = ResourceInitializer.BUTTON_HIDECOMMENT;

            UpdateFromDBlist();

            rbRule.lbConsolidationPriority.Text = ResourceInitializer.RB_CONSOLIDATION_PRIORITY;
            #region Handling restore form's size/position
            this.MinimumSize = new System.Drawing.Size(700, 275);
            int[] tmpProps = RegUtils.GetFormProperties(RULEEDITORADVANCED);

            if (tmpProps[0] != -1)
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Size = new System.Drawing.Size(tmpProps[2], tmpProps[3]);
                this.Left = tmpProps[0];
                this.Top = tmpProps[1];
            }
            else
            {
                this.Width = Screen.GetWorkingArea(this).Width - 100;
                this.Height = Screen.GetWorkingArea(this).Height - 100;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            #endregion
        }

        private void UpdateFromDBlist()
        {
            DBList.Instance.DefaultCube = SelectedCube;
            rbRule.CTarget.AreaControl.Cube = SelectedCube;
            rbRule.CExpression.CFChooserAt(0).CBOption.SelectedIndex = 0;
        }


        private string GetHashkey(string db, string dim)
        {
            return db + "\t" + dim;
        }

        private void FillAutoCompleteList(bool doupdate)
        {
//            PaloMessage pmesg = new PaloMessage((doupdate) ? this : caller, ResourceInitializer.MSG_LONG_ACTION);
//            pmesg.Show();
           
            ExcelHelper.SetExcelStatusbar(ResourceInitializer.MSG_LONG_ACTION);
            SetError(ResourceInitializer.MSG_LONG_ACTION);

            Hashtable useddims = new Hashtable();
            // clears the autocomplete list
            DBList.Instance.Entities.Clear();

            // we do want to support other cube types since apparently server does it
            switch (currCubeType)
            {
                case 0:
                    tmpCubeType = CubeType.NormalCube;
                    break;

                case 2:
                    tmpCubeType = CubeType.AttributeCube;
                    break;

                case 1:
                    tmpCubeType = CubeType.SystemCube;
                    break;

                default:
                    tmpCubeType = CubeType.NormalCube;
                    break;
            }

            string[] dbs = conn.RootListDatabases(DatabaseType.NormalDatabase), dims, sysdbs;
            List<string> cubes;
            string idb, icube, idim;
            int i, j, k, l, countdb = dbs.Length, countcubes, countdims, countelems;
            Entity db, cube, dim, elem;
            ElementInfo ielem;
            ElementInfo[] elems;
            string hashkey;

            for (i = 0; i < countdb; i++ )
            {
                idb = dbs[i];
                db = new Entity(idb);
                DBList.Instance.Entities.Add(db);
                cubes = new List<string>(conn.DatabaseListCubes(idb, tmpCubeType));

                if (currCubeType == GeneralConst.NORMAL_CUBE_VIEW)
                {
                    cubes.AddRange(conn.DatabaseListCubes(idb, CubeType.AttributeCube, true)); // OnlyCubesWithCells
                    sysdbs = conn.DatabaseListCubes(idb, CubeType.SystemCube);
                    countcubes = sysdbs.Length;
                    for (j = 0; j < countcubes; j++)
                    {
                        icube = sysdbs[j];
                        if (icube.StartsWith(GeneralConst.PREFIX_CELL_RIGHTS))
                        {
                            cubes.Add(icube);
                        }
                    }
                }

                countcubes = cubes.Count;

                for (j= 0; j < countcubes; j++)
                {
                    icube = cubes[j];
                    cube = new Entity(icube);
                    if ((idb == currDb) && (icube == currCube))
                    {
                        SelectedCube = cube;
                        RBElements.Dictionary.Clear();
                    }

                    db.Entities.Add(cube);

                    dims = conn.CubeListDimensions(idb, icube);
                    countdims = dims.Length;

                    for (k = 0;  k < countdims; k++)
                    {
                        idim = dims[k];
                        hashkey = GetHashkey(idb, idim);

                        if (useddims.ContainsKey(hashkey))
                        {
                            dim = (Entity)useddims[hashkey];
                        }
                        else
                        {
                            dim = new Entity(idim);

                            elems = conn.DimensionRestrictedFlatListDimElements(idb, idim, 0, elemCntLimit);
                            countelems = elems.Length;

                            for (l = 0; (l< countelems); l++)
                            {
                                ielem = elems[l];
                                elem = new Entity(ielem.Name);

                                elem.Dimension = dim;
                                elem.Unique = false;
                                elem.C = (ielem.Type == DimElementType.DimElementTypeConsolidated);

                                if ((idb == currDb) && (icube == currCube)) // When working with current cube, make the Dictionary
                                {
                                    if (RBElements.Dictionary.ContainsKey(ielem.Name))
                                    {
                                        RBElements.Dictionary[ielem.Name].Unique = false;
                                        elem.Unique = false;
                                    }
                                    else
                                    {
                                        RBElements.Dictionary.Add(ielem.Name, elem);
                                        elem.Unique = true;
                                    }
                                }

                                dim.Entities.Add(elem);
                            }
                        }

                        cube.Entities.Add(dim);
                    }
                }
            }
            useddims.Clear();
            useddims = null;

            if (doupdate)
            {
                UpdateFromDBlist();
            }
            
            SetError("");
            ExcelHelper.ResetExcelStatusbar();

  //          pmesg.Close();
  //          pmesg.Dispose();
  //          pmesg = null;
        }

        public void SetError(string error)
        {
            if (this.lblStatus != null)
            {
                this.lblStatus.Text = error;
            }
        }

        private void DoParse()
        {
            JParser.JParser jp = new JParser.JParser();
            jp.String = tbRule.Text;
            string err;

            SetError("");

            try
            {
                jp.ParseRule(rbRule);
                tbRule.Text = rbRule.ExprValue;
            }
            catch (JParser.ParseException ex)
            {
                err = ex.Message + " at: " + ex.Position;
                SetError(err);
                MessageBox.Show(err, "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbRule.Select(ex.Position - 1, 1);
                tbRule.Focus();
            }
            catch (Exception ex)
            {
                err = ex.Message;
                SetError(err);
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InitRule()
        {
            DoParse();
        }

        public string Comment
        {
            get { return tbComment.Text; }
            set { tbComment.Text = value; }
        }

        private void tbUpdate(object sender, EventArgs e)
        {
            tbRule.Text = rbRule.ExprValue;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                conn.RuleParse(currDb, currCube, tbRule.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (PaloException pexc)
            {
                this.SetError(pexc.Message);
            }
        }

        private void btParse_Click(object sender, EventArgs e)
        {
            DoParse();
        }

        private void btRefreshList_Click(object sender, EventArgs e)
        {
            this.btRefreshList.Enabled = false;
            this.FillAutoCompleteList(true);
            this.btRefreshList.Enabled = true;
        }

        private void btExpandAll_Click(object sender, EventArgs e)
        {
            rbRule.ExpandAll();
        }

        private void btCollapseAll_Click(object sender, EventArgs e)
        {
            rbRule.CollapseAll();
        }

        private void btMaximize_Click(object sender, EventArgs e)
        {
            if (lbComment.Visible)
            {
                lbComment.Visible = tbComment.Visible = false;
                btShowComment.Text = ResourceInitializer.BUTTON_SHOWCOMMENT;
                tbRule.Size = new Size(tbRule.Size.Width, 81);
            }
            else
            {
                tbRule.Size = new Size(tbRule.Size.Width, 34);
                lbComment.Visible = tbComment.Visible = true;
                btShowComment.Text = ResourceInitializer.BUTTON_HIDECOMMENT;
            }
        }

        private void RuleEditorAdvanced_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegUtils.SetFormProperties(RULEEDITORADVANCED, new int[4] { this.Left, this.Top, this.Width, this.Height });
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        }

        private void tbRule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                DoParse();
                e.SuppressKeyPress = true;
            }
        }
    }
}
