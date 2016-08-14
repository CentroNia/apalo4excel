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
using System.Windows.Forms;
using JControls;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms.Controls
{
    public partial class ConnComboBox : UserControl
    {
        private const int UNCONNECTED = 0;
        private const int CONNECTED = 1;
        private const int UNCLEARCONNECTSTATE = 2;
        private const int CONNECTEDWITHDB = 3;

        private const byte CONNECTIONNAMEINDEX = 2;
        private const byte DATABASEINDEX = 3;

        public ConnComboBox()
        {
            Connect.Checkinit();
            InitializeComponent();
            this.cb.ImageList = this.imgListServerIcons;
            this.comboL = new ArrayList();
            this.oldConnectionName = "";
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }

        private void FillDBList(IEnumerator dbL, int imgIndex, ConnInfo ci)
        {
            if ((-1 < imgIndex) && (imgIndex < 3))
            {
                this.cb.Items.Add(new ComboBoxImgItem(ci.connectionname.ToUpper(System.Globalization.CultureInfo.InvariantCulture) + " / " + ci.hostname + ":" + ci.service, imgIndex));
                comboL.Add(new object[] { ci.id, -1, ci.connectionname, "" });
            }
            else
            {
                string dbN;
                int j = 0;
                while (dbL.MoveNext())
                {
                    dbN = dbL.Current.ToString();
                    this.cb.Items.Add(new ComboBoxImgItem(dbN, imgIndex, 1));
                    comboL.Add(new object[] { ci.id, j, ci.connectionname, dbN });
                    j++;
                }
            }
        }

        private string GetItemHelper(int ind, int cbind)
        {
            if ((cbind < 0) || (cbind >= this.comboL.Count))
            {
                return "";
            }
            else
            {
                object[] o = (object[])this.comboL[cbind];
                return o[ind].ToString();
            }
        }

        private String GetConnectionName(int cbind)
        {
            return GetItemHelper(CONNECTIONNAMEINDEX, cbind);
        }

        public String GetConnectionName()
        {
            return GetConnectionName(this.cb.SelectedIndex);
        }

        public int GetServerId()
        {
            int cbind = this.cb.SelectedIndex;
            if ((cbind < 0) || (cbind >= this.comboL.Count))
            {
                return -1;
            }
            else
            {
                object[] o = (object[])this.comboL[cbind];
                return (int)o[0];
            }
        }

        private String GetDatabase(int cbind)
        {
            return GetItemHelper(DATABASEINDEX, cbind);
        }

        public String GetDatabase()
        {
            return GetDatabase(this.cb.SelectedIndex);
        }

        private void ConnItemHelper(ref string ConnectionName2, ref string ConnDb2, int i)
        {
            ConnectionName2 = this.GetConnectionName(i);
            ConnDb2 = this.GetDatabase(i);
        }

        private bool FillListhelper(ConnectionsHelper.HandleDatabase HandleDB, ConnInfo ci, string connectionname, string user, string pass)
        {
            try
            {
                // GetConnection executes ping
                Connection c = Connections.GetConnection(ci.hostname, ci.service, user, pass, connectionname);
                List<string> dbL = ConnectionsHelper.getListDB(c, HandleDB);
                FillDBList(null, CONNECTED, ci);
                FillDBList(dbL.GetEnumerator(), CONNECTEDWITHDB, ci);
                return true;
            }
            catch (Exception connExc)
            {
                ErrorHandler.DisplayError("Error Connecting to server!", connExc);
                FillDBList(null, UNCLEARCONNECTSTATE, ci);
                Connections.CloseConnection(connectionname, false);
                return false;
            }
        }

        public void FillList(int serverid, ConnectionsHelper.HandleDatabase HandleDB)
        {
            Text = ResourceInitializer.TIP_COMBO_CONNECTIONS;
            Clear();

            try
            {
                XmlUtils.ReadXmlInitial();
                DataTable myDt = XmlUtils.dsConnectionsTable;
                DataRow dr;

                bool spezialid;
                ConnInfo ci;
                for (int i = 0; i < myDt.Rows.Count; i++)
                {
                    dr = (DataRow)myDt.Rows[i];
                    ci = new ConnInfo(dr);

                    spezialid = (ci.id == serverid);
                    if (spezialid || (-1 == serverid))
                    {
                        ExcelHelper.SetExcelStatusbar(ResourceInitializer.Replace(ResourceInitializer.STATUS_LOOKING4SERVER_WAIT, new object[] { ci.connectionname }));

                        bool conn_made = false;

                        if (!ci.connected)
                        {
                            FillDBList(null, UNCONNECTED, ci);
                        }
                        else
                        {
                            string username = "", password = "";

                            ConnectionsHelper.GetUserPass(ci, dr, ref username, ref password);

                            if ((username.Length != 0) || Connections.ConnectionExists(ci.connectionname) )
                            {
                                conn_made = FillListhelper(HandleDB, ci, ci.connectionname, username, password);
                            }
                            else
                            {
                                FillDBList(null, UNCONNECTED, ci);
                            }

                            if (spezialid)
                            {
                                SelectedIndex = 0;
                                break;
                            }
                        }

                        if (!conn_made && ci.connected)
                        {
                            XmlUtils.dsConnectionsTable.Rows[i]["connected"] = Boolean.FalseString;
                            XmlUtils.WriteConnections();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error Reading List Items.", exc);
            }

            ExcelHelper.ResetExcelStatusbar();

        }

        public bool SetItem(string ConnectionName, string ConnDb)
        {
            string _ConnectionName = (String.IsNullOrEmpty(ConnectionName)) ? "" : ConnectionName;
            string _ConnDb = (String.IsNullOrEmpty(ConnDb)) ? "" : ConnDb;

            int index = -1, fallbackindex = -1;
            bool found = false;

            if (_ConnectionName != "")
            {
                int i = 0, j, asize = this.comboL.Count;
                string ConnectionName2 = "", ConnDb2 = "";

                while ((i < asize) && !found)
                {
                    this.ConnItemHelper(ref ConnectionName2, ref ConnDb2, i);

                    if (String.Equals(ConnectionName2, _ConnectionName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        index = i;
                        fallbackindex = index;

                        if (_ConnDb != "")
                        {
                            j = i + 1;
                            while (j < asize)
                            {
                                this.ConnItemHelper(ref ConnectionName2, ref ConnDb2, j);

                                if (!String.Equals(ConnectionName2, _ConnectionName, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    i = asize;
                                    break;
                                }

                                if (String.Equals(ConnDb2, _ConnDb, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    index = j;
                                    found = true;
                                    break;
                                }

                                j++;
                            }
                        }
                        else
                        {
                            found = true;
                        }
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    index = ++fallbackindex;
                    if (index < asize)
                    {
                        this.ConnItemHelper(ref ConnectionName2, ref ConnDb2, index);

                        if (!String.Equals(ConnectionName2, _ConnectionName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            index--;
                        }
                    }
                    else
                    {
                        index--;
                    }
                }

            }
            
            if ((this.cb.Items.Count > index) && (index > -1))
            {
                this.cb.SelectedIndex = index;
            }

            this.SaveItem();

            return found;
        }

        public void SetItem()
        {
            this.SetItem(RegUtils.ActiveConnection, RegUtils.ActiveDB);
        }

        public void SaveItem()
        {
            RegUtils.ActiveConnection = GetConnectionName();
            RegUtils.ActiveDB = GetDatabase();
        }

        public Connection GetConnection()
        {
            bool do_ping = false;
            string currName = GetConnectionName();
            if (!String.Equals(oldConnectionName, currName, StringComparison.InvariantCultureIgnoreCase))
            {
                oldConnectionName = currName;
                do_ping = true;
            }

            Connection c = null;

            if (!String.IsNullOrEmpty(GetDatabase()))
            {
                try
                {
                    c = Connections.GetConnection(currName, do_ping);
                }
                catch (Exception exc)
                {
                    ErrorHandler.DisplayError("Error getting Connection !", exc);
                }
            }
            return c;
        }
    }
 }

