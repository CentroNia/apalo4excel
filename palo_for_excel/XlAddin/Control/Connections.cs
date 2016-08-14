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

//  Additional Revisions to Palo (c) Junction BI LLC:
//  JMM 09-24-13 Remove Server License Check

using System;
using System.Collections;
using System.Data;
using System.Runtime.InteropServices;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Utils;
using Apalo.XlAddin.Forms;

namespace Apalo.XlAddin
{
	[ComVisible(false)]
    public class Connections
	{
        public class credentials
        {
            public string user;
            public string password;
            public credentials(string newuser, string newpassword)
            {
                user = newuser;
                password = newpassword;
            }
        }

		private static Hashtable _arrConns = null;
        private static Hashtable arrConns
        {
            get
            {
                return gethelper(ref _arrConns);
            }
        }

        private static Hashtable _arrCredentials = null;
        private static Hashtable arrCredentials
        {
            get
            {
                return gethelper(ref _arrCredentials);
            }
        }

        private static void inithelper(ref Hashtable ht)
        {
            if (ht == null)
            {
                ht = new Hashtable();
            }
        }


        private static Hashtable gethelper(ref Hashtable ht)
        {
            inithelper(ref ht);
            return ht;
        }


		private Connections()
		{
		}

        public static void init()
        {
            inithelper(ref _arrCredentials);
            inithelper(ref _arrConns);
        }

        public static bool ConnectionExists(string name)
        {
            return Connections.arrConns.ContainsKey(name.ToUpper());
        }


        // close all
        public static void CloseConnection(bool remove_from_excel)
        {
            IDictionaryEnumerator myEnum = Connections.arrConns.GetEnumerator();

            while (myEnum.MoveNext())
            {
                Connection c = (Connection)myEnum.Value;
                try
                {
                    c.PrepareLogout();
                    c.Dispose();
                }
                catch (PaloException)
                { }
            }
            Connections.arrConns.Clear();
            Connections.arrCredentials.Clear();

            if (remove_from_excel)
            {
                object o = System.Reflection.Missing.Value;

                try
                {
                    ExcelHelper.oExcelApp.Run("PALO.CLOSE_CONNECTIONS", o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o);
                }
                catch (Exception ExcConnClose)
                {
                    ErrorHandler.DisplayError("PALO.CLOSE_CONNECTIONS failed!", ExcConnClose);
                }

            }

        }

        public static void CloseConnection()
        {
            CloseConnection(false);
        }

        // close specific
        public static void CloseConnection(string name, bool logout)
        {

            string keyname = name.ToUpper();

            if (ConnectionExists(keyname) == true)
            {

                Connection c = (Connection)Connections.arrConns[keyname];

                try
                {
                    if (logout)
                    {
                        c.PrepareLogout();
                    }
                    c.Dispose();
                }
                catch (PaloException)
                { }

                Connections.arrConns.Remove(keyname);
                Connections.arrCredentials.Remove(keyname);

                object o = System.Reflection.Missing.Value;

                ExcelHelper.oExcelApp.Run("PALO.REMOVE_CONNECTION", name, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o);

            }
        }

        // close specific
        public static void CloseConnection(string name)
        {
            CloseConnection(name, true);
        }

        private static Connection AddConnection(string hostName, string service, string userName, string password, string name, bool fromxll)
		{
            if (hostName == null)
            {
                ErrorHandler.WriteToLog("AddConnection : hostName is null\n");
            }

            if (service == null)
            {
                ErrorHandler.WriteToLog("AddConnection : service is null\n");
            }

            if (userName == null)
            {
                ErrorHandler.WriteToLog("AddConnection : userName is null\n");
            }

            if (password == null)
            {
                ErrorHandler.WriteToLog("AddConnection : password is null\n");
            }

            if (name == null)
            {
                ErrorHandler.WriteToLog("AddConnection : name is null\n");
            }

            string keyname = name.ToUpper();

            object o = System.Reflection.Missing.Value;

            if (!fromxll && (ExcelHelper.oExcelApp != null))
            {
                ExcelHelper.oExcelApp.Run("PALO.REMOVE_CONNECTION", name, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o);
            }

            try
            {
                Connection c = new Connection(hostName, service, userName, password);

                // JMM 09-24-13 Removed License check
                #if NOTUSED
                LicenseInfo li = c.ServerLicenseInformation();
                DateTime licenseExpires = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(li.ExpireDate);
                TimeSpan timeDiff = licenseExpires.Subtract(DateTime.UtcNow);
                int adjust = ((timeDiff.Hours + timeDiff.Minutes + timeDiff.Seconds) > 0) ? 1 : 0;
                int comparediff = 5 + adjust;

                if (timeDiff.Days <= comparediff)
                {
                    InfoBox a = new InfoBox();
                    a.displayLicensePage = true;
                    a.licenseTTL = timeDiff.Days + adjust;
                    a.ShowDialog();
                    a.Dispose();
                    a = null;
                }

                if (!fromxll && (ExcelHelper.oExcelApp != null))
                {
                    try
                    {
                        ExcelHelper.oExcelApp.Run("PALO.REGISTER", name, hostName, int.Parse(service), userName, password, false, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o);
                    }
                    catch (Exception exp)
                    {
                        ErrorHandler.DisplayError("Problem with palo.register !", exp);
                    }
                }
                #endif
                try
                    {
                    // refresh ServerCache
                    c.Ping();
                    }
                    catch (PaloException)
                    {
                    }


                Connections.arrConns.Add(keyname, c);
                Connections.arrCredentials.Add(keyname, new credentials(userName, password));

			    return c;
            }
            catch (PaloException exp)
            {
                switch(exp.ErrorCode)
                {
                    case -44:
                        ErrorHandler.ErrorPopup(exp.Message);
                        break;

                    case 3:
                        // todo show popup
                        // ErrorHandler.ErrorPopup(exp.Message)
                        break;
                }

                throw;
            }
		}


        private static Connection GetConnectionHelper(string name, bool do_ping)
        {
            Connection c = null;

            string keyname = name.ToUpper();

            if (ConnectionExists(keyname))
            {
                c = (Connection)arrConns[keyname];

                if (do_ping)
                {
                    try
                    {
                        // refresh ServerCache
                        c.Ping();
                    }
                    catch (PaloException)
                    {
                    }
                }
            }
            return c;
        }

		public static Connection GetConnection(string hostName, string service, string userName, string password, string name, bool fromxll)
		{
            if (name == null)
            {
                return null;
            }

            Connection c = GetConnectionHelper(name, !fromxll);

            if (c == null)
			{
				c = AddConnection(hostName, service, userName, password, name, fromxll );
			}

			return c;

		}

        public static Connection GetConnection(string hostName, string service, string userName, string password, string name)
        {
            return GetConnection(hostName, service, userName, password, name, false);
        }

        public static credentials GetCredentials(string name)
        {
            credentials c = null;
            string keyname = name.ToUpper();

            if (arrCredentials.ContainsKey(keyname))
            {
                c = (credentials)arrCredentials[keyname];
            }

            return c;
        }

        public static Connection GetConnection(string name, bool do_ping)
		{
            if (name == null)
            {
                return null;
            }
            
            Connection c = GetConnectionHelper(name, do_ping);

            string keyname = name.ToUpper();

            if (c == null)
            {
				DataTable myDt = XmlUtils.dsConnectionsTable;
		
                int iCntDr = myDt.Rows.Count;
                string uid = "", pwd = "";
                DataRow r;
                ConnInfo ci;

				for (int i=0; i<iCntDr; i++)
                {
                    r = myDt.Rows[i];
                    ci = new ConnInfo(r);

                    if (ci.connectionname.Equals(name, StringComparison.InvariantCultureIgnoreCase))
					{
                        ConnectionsHelper.GetUserPass(ci, r, ref uid, ref pwd);
                        c = Connections.AddConnection(ci.hostname, ci.service, uid, pwd, ci.connectionname, false);
                        XmlUtils.WriteConnections();
                        break;
					}
				}
			}
			return c;
		}

        public static Connection GetConnection(string name)
        {
            return GetConnection(name, true);
        }


		public static bool TestConnection(string hostName, string service, string userName, string password	)
		{
			try
			{
            // JMM 09-24-13 Use static test function
            uint Port = uint.Parse(service);
            Connection.TestConnection(hostName, Port, userName, password);

            #if NOTUSED
				Connection c = new Connection( hostName, service, userName, password );
                c.Dispose();
                c = null;				
            #endif
            return true;
			}
            catch (PaloException exc)
			{
                ErrorHandler.DisplayError("Error Testing Connection.", exc);
				return false;
			}
		}

	}
}
