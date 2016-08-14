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

using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.Utils
{

    [ComVisible(false)]
    public class ConnInfo
    {
        public string connectionname = "";
        public string hostname = "";
        public string service = "";
        public string username = "";
        public string password = "";
        public int id = -1;
        public bool connected = false;
        public bool usewinauth = false;

        private bool Check(string index, DataRow r)
        {
            return (r[index].ToString().ToLower() == "true");
        }

        public ConnInfo(DataRow r)
        {
            if ((r.RowState == DataRowState.Detached) || (r.RowState == DataRowState.Deleted))
            {
                return;
            }

            connectionname = r["name"].ToString();
            hostname = r["hostname"].ToString();
            service = r["service"].ToString();
            id = (int)r["id"];
            username = r["username"].ToString();
            password = r["password"].ToString();
            connected = Check("connected", r);
            usewinauth = Check("usewinauth", r);
        }
    }

    [ComVisible(false)]
    public class ConnectionsHelper : System.IDisposable
    {
        public enum HandleDatabase
        {
            NoRestriction = 0,
            OnlySystem = 1,
            WithSystem = 2,
            WithoutSystem = 3
        }

        private static Forms.LogOn fL = new Forms.LogOn();

        public void Dispose()
        {
        }

        public static void GetWindowsUser(ref string userName, ref string password)
        {
            string userIdentity = WindowsIdentity.GetCurrent().Name;
            int pos = userIdentity.LastIndexOf("\\");
            string onlyName = userIdentity.Substring(pos + 1);
            string domain = "";
            try
            {
                domain = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().ToString();
            }
            catch (System.Exception exc)
            {
                ErrorHandler.DisplayError("Error getting domain.", exc);
            }

            userName = onlyName + "@" + domain;

            string key = RegUtils.SVSWindowsAuthKey;
            ArrayList asizes = new ArrayList(new object[]{16,32});

            if (!string.IsNullOrEmpty(key) && asizes.Contains(key.Length))
            {
                password = Crypto.Rijndaele(userName, key, userName);
            }
            else
            {
                password = "dummy";
            }
        }

        public static void GetUserPass(ConnInfo ci, DataRow r, ref string userName, ref string passWord)
        {
            if (ci.usewinauth)
            {
                GetWindowsUser(ref userName, ref passWord);
            }
            else
            {
                userName = ci.username;
                passWord = ci.password;

                if ((userName.Length == 0) || (passWord.Length == 0))
                {
                    Connections.credentials credits = Connections.GetCredentials(ci.connectionname);

                    if (credits != null)
                    {
                        userName = credits.user;
                        passWord = credits.password;
                    }
                }

                if ((userName.Length == 0) || (passWord.Length == 0))
                {

                    fL.ConnectionName = ci.connectionname;
                    DialogResult dialogLogin = fL.ShowDialog();

                    if (dialogLogin == DialogResult.OK)
                    {
                        userName = fL.InputUserName;
                        passWord = fL.InputPassword;

                        r["connected"] = System.Boolean.TrueString;

                        if (fL.KeepLogOnData == true)
                        {
                            r["username"] = userName;
                            r["password"] = passWord;
                        }

                    }
                    else
                    {
                        r["connected"] = System.Boolean.FalseString;
                    }
                    fL.InputUserName = "";
                    fL.InputPassword = "";

                    XmlUtils.WriteConnections();
                }

            }
        }

        private static bool Look4conn(string serverName, DataRow r, ref string hostName, ref string service, ref string userName, ref string passWord, ref Jedox.Palo.Comm.Connection con, bool fromxll)
        {
            bool found = false;
            ConnInfo ci = new ConnInfo(r);

            // for 4890 we need  "connected" 
            if (ci.connected &&
                (System.String.Equals(ci.connectionname, serverName, System.StringComparison.InvariantCultureIgnoreCase)))
			{
                found = true;
				hostName = ci.hostname;
				service = ci.service;

                GetUserPass(ci, r, ref userName, ref passWord);
                con = Connections.GetConnection(hostName, service, userName, passWord, ci.connectionname, fromxll);
			}

            return found;
             
        }

        public static bool Look4conn(string serverName, DataRow r, ref string hostName, ref string service, ref string userName, ref string passWord)
        {
            Connection con = null;
            return Look4conn(serverName, r, ref hostName, ref service, ref userName, ref passWord, ref con, true);

        }

        public static bool Look4conn(string serverName, DataRow r, ref Connection con)
        {
            string hostName = "", service = "", userName = "", passWord = "";
            return Look4conn(serverName, r, ref hostName, ref service, ref userName, ref passWord, ref con, false);

        }

        public static List<string> getListDB(Connection con, HandleDatabase HandleDB)
        {
            List<string> dbL = new List<string>();

            if (HandleDB == HandleDatabase.NoRestriction)
            {
                dbL.AddRange(con.RootListDatabases());
            }
            else
            {
                if (HandleDB != HandleDatabase.OnlySystem)
                {
                    dbL.AddRange(con.RootListDatabases(DatabaseType.NormalDatabase));
                    if (RegUtils.DebugMode)
                    {
                        dbL.AddRange(con.RootListDatabases(DatabaseType.UserinfoDatabase));
                    }
                 }

                 if (HandleDB != HandleDatabase.WithoutSystem)
                 {
                    dbL.AddRange(con.RootListDatabases(DatabaseType.SystemDatabase));
                 }
            }

            return dbL;

        }

    }
}
