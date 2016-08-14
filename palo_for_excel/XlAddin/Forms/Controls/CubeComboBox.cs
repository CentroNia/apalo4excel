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
using System.Windows.Forms;
using Apalo.XlAddin.Utils;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.Forms.Controls
{
    public partial class CubeComboBox : UserControl
    {
       
        public CubeComboBox()
        {
            InitializeComponent();
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }

        public void FillList(IEnumerator dbL, string activecube)
        {
            this.Items.Clear();
            bool selected = false;

            string dbN;
            while (dbL.MoveNext())
            {
                dbN = (string)dbL.Current;
                this.cb.Items.Add(dbN);

                if (string.Equals(dbN, activecube, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.SelectedItem = dbN;
                    selected = true;
                }
            }

            if (!selected)
            {
                this.SelectedIndex = 0;
            }
           
        }

        private void RefreshList(Connection c, string dbN, byte CubeViewStatus, bool withoutEmptyCubes)
        {
            List<string> dbCubes = ListBoxHelper.GetCubeList(c, dbN, CubeViewStatus, withoutEmptyCubes);
            FillList(dbCubes.GetEnumerator(), RegUtils.ActiveCube);
        }

        private void RefreshList(Connection c, string dbN, string cube, byte CubeViewStatus, bool withoutEmptyCubes)
        {
            if (!withoutEmptyCubes && !string.IsNullOrEmpty(cube))
            {
                try
                {
                    withoutEmptyCubes = (c.CubeInformation(dbN, cube).NumberCells > 0);
                }
                catch
                {
                }
            }

            RefreshList(c, dbN, CubeViewStatus, withoutEmptyCubes);
        }

        public void RefreshList(ConnComboBox ConnList, Connection c, byte CubeViewStatus, bool withoutEmptyCubes, string cube)
        {
            string database = ConnList.GetDatabase();
            if (!string.IsNullOrEmpty(database))
            {
                try
                {
                    RefreshList(c, database, cube, CubeViewStatus, withoutEmptyCubes);
                }
                catch (Exception exc)
                {
                    ErrorHandler.DisplayError("Error setting Cube Combobox.", exc);
                }
            }
        }

        public void RefreshList(ConnComboBox ConnList, Connection c, byte CubeViewStatus, bool withoutEmptyCubes)
        {
            RefreshList(ConnList, c, CubeViewStatus, withoutEmptyCubes, null);
        }

        public void SetItem(string actCube)
        {
            if ((actCube != null) && (actCube.Length != 0))
            {
                foreach (string tmpItemCb in this.cb.Items)
                {
                    if (string.Equals(tmpItemCb, actCube, StringComparison.InvariantCultureIgnoreCase))
                    {
                        cb.SelectedItem = tmpItemCb;
                        break;
                    }
                }
            }

            this.SaveItem();
        }

        public void SetItem()
        {
            this.SetItem(RegUtils.ActiveCube);
        }

        public void SaveItem()
        {
            if (cb.SelectedItem != null)
            {
                RegUtils.ActiveCube = cb.SelectedItem.ToString();
            }
        }

    }
 }

