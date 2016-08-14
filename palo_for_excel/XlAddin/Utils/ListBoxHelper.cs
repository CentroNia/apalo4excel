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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.Utils
{

    [ComVisible(false)]
    public class ListBoxHelper : System.IDisposable
    {

        private ListBoxHelper()
        {
        }

        ~ListBoxHelper()
        {
        }

        public void Dispose()
        {
        }
        
        private static bool IsJPaloObject(string dim, ArrayList JPalo)
        {
            if (dim == null)
            {
                return false;
            }
            return JPalo.Contains(dim.ToLower());
        }

        public static bool IsJPaloDim(string dim)
        {
            return IsJPaloObject(dim, new ArrayList(new string[] { "#viewcolumns", "#viewrows", "#subsetrows", "#subsetcolumns" }));
        }

        private static bool IsJPaloCube(string cube)
        {
            return IsJPaloObject(cube, new ArrayList(new string[] { "#views" }));
        }
        
        public static List<string> GetCubeList(Connection c, string dbN, byte CubeViewStatus, bool withoutEmptyCubes)
        {
            List<string> dbCubes = new List<string>();
            List<string> dbCubes2 = new List<string>();


            CubeType cubetype = CubeType.NormalCube;

            if (c != null)
            {
                if (CubeViewStatus == GeneralConst.ATTRIBUTE_CUBE_VIEW)
                {
                    cubetype = CubeType.AttributeCube;
                }
                else
                {
                    if (CubeViewStatus == GeneralConst.SYSTEM_CUBE_VIEW)
                    {
                        cubetype = CubeType.SystemCube;
                    }
                    else
                    {
                        cubetype = CubeType.NormalCube;
                    }
                }

                try
                {
                    // if debug mode, display also empty system cubes
                    if (RegUtils.DebugMode && cubetype == CubeType.SystemCube)
                    {
                        dbCubes.AddRange(c.DatabaseListCubes(dbN, cubetype, false));
                    }
                    else
                    {
                        dbCubes.AddRange(c.DatabaseListCubes(dbN, cubetype, withoutEmptyCubes));
                    }

                    if (cubetype == CubeType.NormalCube)
                    {
                        dbCubes.AddRange(c.DatabaseListCubes(dbN, CubeType.GpuCube, withoutEmptyCubes));
                    }
                }
                catch (Exception e)
                {
                    ErrorHandler.DisplayError("Error getting list of cubes!", e);
                }

                foreach (string s in dbCubes)
                {
                    if (!IsJPaloCube(s))
                    {
                        dbCubes2.Add(s);
                    }
                }
            }
            return dbCubes2;
        }

        private static bool ConnToggleHelper(ref DataRow dR, bool connMade, string connectionname, string user, string pass)
        {
            dR[4] = connMade.ToString().ToLower();
            XmlUtils.WriteConnections();

            RegUtils.ActiveConnection = connectionname;
            RegUtils.ActiveDB = "";

            if (connMade)
            {
                if (!string.IsNullOrEmpty(user))
                {
                    try
                    {
                        Connection c = Connections.GetConnection((string)dR[2], (string)dR[3], user, pass, connectionname);
                        string[] db = c.RootListDatabases(DatabaseType.NormalDatabase);

                        if (db.Length > 0)
                        {
                            RegUtils.ActiveDB = db[0];
                        }
                    }
                    catch (Exception connExc)
                    {
                        dR = XmlUtils.dsConnectionsTable.Rows.Find(connectionname);
                        dR[4] = Boolean.FalseString;
                        XmlUtils.WriteConnections();
                        ErrorHandler.DisplayError("Error Connecting to server!", connExc);
                    }
                }
	        }
            else
            {
                Connections.CloseConnection(connectionname);
            }
            return connMade;
        }

        private static bool ConnToggleHelper(ref DataRow dR, bool connMade, string connectionname)
        {
            return ConnToggleHelper(ref dR, connMade, connectionname, "", "");
        }

        public static bool ConnToggle(String connectionname)
		{
            bool ConnMade = false;

            DataRow dR = XmlUtils.dsConnectionsTable.Rows.Find(connectionname);

			if (Connections.ConnectionExists(connectionname))
			{
                ConnMade = ConnToggleHelper(ref dR, false, connectionname);
			}
			else
			{
                string username = "", password = "";
                ConnectionsHelper.GetUserPass(new ConnInfo(dR), dR, ref username, ref password);
                ConnMade = ConnToggleHelper(ref dR, username.Length > 0, connectionname, username, password);
			}

            return ConnMade;
        }
    }
}
