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
using System.Data;
using System.Runtime.InteropServices;

namespace Apalo.XlAddin.Utils
{
	[ComVisible(false)]
	public class XmlUtils : IDisposable
	{
        private const string SERVER = "server";

        private static DataSet _dsConnections = null;
        public static DataTable dsConnectionsTable
        {
            get
            {
                init();
                return _dsConnections.Tables[SERVER];
            }
        }

        private XmlUtils()
		{
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if(disposing == true)
			{
                cleanup();
			}
		}

        public static void cleanup()
        {
            _dsConnections.Dispose();
            _dsConnections = null;
        }

        private static void init()
        {
            if (_dsConnections == null)
            {
                try
                {
                    _dsConnections = new DataSet("servers");
                    _dsConnections.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    if (_dsConnections.Tables.Count < 1)
                    {
                        DataTable dtConn = _dsConnections.Tables.Add(SERVER);
                        DataColumn id = dtConn.Columns.Add("id", Type.GetType("System.Int32"));
                        DataColumn name = dtConn.Columns.Add("name", Type.GetType("System.String"));
                        name.ColumnName = "name";
                        name.Unique = true;
                        DataColumn[] keys = new DataColumn[1];
                        keys[0] = name;
                        dtConn.PrimaryKey = keys;
                        dtConn.Columns.Add("hostname");
                        dtConn.Columns.Add("service");
                        dtConn.Columns.Add("connected");
                        dtConn.Columns.Add("username");
                        dtConn.Columns.Add("password");
                        dtConn.Columns.Add("offline");
                        dtConn.Columns.Add("usewinauth");
                    }
                }
                catch (Exception e)
                {
                    ErrorHandler.DisplayError("Error in XmlUtils init!", e);
                    throw;
                }
            }
        }


		#region Read XML

		public static void ReadXmlInitial()
		{
            init();
            _dsConnections.Clear();
            string[] connKeys = RegUtils.GetConnSubKeys();
            
            for (int i = 0; i < connKeys.Length; i++)
            {
                string conn = connKeys[i];
                string pass = "";
                pass = Crypto.DESd(RegUtils.GetConnRegData(conn, "password"));
                _dsConnections.Tables[SERVER].Rows.Add(
                                                            new object[] { 
                                                                i + 1,
                                                                conn,
                                                                RegUtils.GetConnRegData(conn, "hostname"), 
                                                                RegUtils.GetConnRegData(conn, "service"), 
                                                                RegUtils.GetConnRegData(conn, "connected"),
                                                                RegUtils.GetConnRegData(conn, "username"),
                                                                pass,
                                                                RegUtils.GetConnRegData(conn, "offline"),
                                                                RegUtils.GetConnRegData(conn, "usewinauth")
                                                            });
            }
		}
		#endregion

        #region Write XML
		public static void WriteConnections()
		{
            init();
            try
            {
                RegUtils.ClearConnSubKeys();

                foreach (DataRow dr in _dsConnections.Tables[SERVER].Rows)
                {
                    string connName = (string)dr.ItemArray.GetValue(1);

                    RegUtils.CreateConnRegKey(connName);

                    RegUtils.SetConnRegData(connName, "hostname", (string)dr.ItemArray.GetValue(2));
                    RegUtils.SetConnRegData(connName, "service", (string)dr.ItemArray.GetValue(3));
                    RegUtils.SetConnRegData(connName, "connected", (string)dr.ItemArray.GetValue(4));
                    RegUtils.SetConnRegData(connName, "username", (string)dr.ItemArray.GetValue(5));
                    RegUtils.SetConnRegData(connName, "password", Crypto.DESe((string)dr.ItemArray.GetValue(6)));
                    RegUtils.SetConnRegData(connName, "offline", (string)dr.ItemArray.GetValue(7));
                    RegUtils.SetConnRegData(connName, "usewinauth", (string)dr.ItemArray.GetValue(8));
                }
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error in XmlUtils.WriteConnections!", e);
                throw;
            }

		}
		#endregion

	}
}
