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
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin
{
	#region ROT Related helper

	internal class NativeMethods
	{
		private const long ACTIVEOBJECT_STRONG = 0;
		private const long ACTIVEOBJECT_WEAK = 1;

		private NativeMethods()
		{
		}
		/*[DllImport("ole32.dll", EntryPoint = "CLSIDFromString")]
			private static extern int CLSIDFromString(byte[] lpszCLSID, out Guid pclsid);
			[DllImport("oleaut32.dll", EntryPoint = "RegisterActiveObject")]
			private static extern int RegisterActiveObject([MarshalAs(UnmanagedType.IUnknown)] object punk, ref Guid rclsid, uint dwFlags, out uint pdwRegister);
			*/
#if !(VS2003)
		[DllImport("ole32.dll", EntryPoint = "GetRunningObjectTable")]
		internal static extern int GetRunningObjectTable(int reserved, out System.Runtime.InteropServices.ComTypes.IRunningObjectTable /*UCOMIRunningObjectTable */ROT);
		[DllImport("ole32.dll", EntryPoint = "CreateItemMoniker")]
        internal static extern int CreateItemMoniker(byte[] lpszDelim, byte[] lpszItem, out System.Runtime.InteropServices.ComTypes.IMoniker /*UCOMIMoniker*/ppmk);

		// UCOMI-Version
		internal static int Register_UCOMI(/*ref Jedox.Palo.Comm.Connection c*/)
		{
			System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
			int errorcode;
            System.Runtime.InteropServices.ComTypes.IRunningObjectTable rot;// UCOMIRunningObjectTable rot;
            System.Runtime.InteropServices.ComTypes.IMoniker moniker;// UCOMIMoniker moniker;
			//int register;

			string delimname = "!";
			byte[] del = enc.GetBytes(delimname);
			string itemname = "Apalo.XlAddin.ComInterface";
			byte[] item = enc.GetBytes(itemname);

			errorcode = GetRunningObjectTable(0, out rot);
			Marshal.ThrowExceptionForHR(errorcode);
			errorcode = CreateItemMoniker(del, item, out moniker);
			Marshal.ThrowExceptionForHR(errorcode);
			return rot.Register(0, new object(), moniker);// out register);
			//return register;
		}
#else
		[DllImport("ole32.dll", EntryPoint = "GetRunningObjectTable")]
		internal static extern int GetRunningObjectTable(int reserved, out UCOMIRunningObjectTable ROT);
		[DllImport("ole32.dll", EntryPoint = "CreateItemMoniker")]
		internal static extern int CreateItemMoniker(byte[] lpszDelim, byte[] lpszItem, out UCOMIMoniker ppmk);

		// UCOMI-Version
		internal static int Register_UCOMI(/*ref Jedox.Palo.Comm.Connection c*/)
		{
			System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
			int errorcode;
			UCOMIRunningObjectTable rot;
			UCOMIMoniker moniker;
			int register;

			string delimname = "!";
			byte[] del = enc.GetBytes(delimname);
			string itemname = "Apalo.XlAddin.ComInterface";
			byte[] item = enc.GetBytes(itemname);

			errorcode = GetRunningObjectTable(0, out rot);
			Marshal.ThrowExceptionForHR(errorcode);
			errorcode = CreateItemMoniker(del, item, out moniker);
			Marshal.ThrowExceptionForHR(errorcode);
			rot.Register(0, new object(), moniker, out register);
			return register;
		}
#endif
	}
	#endregion

    #region COM visible definitions

    [ComVisible(true)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IPaloEngineCom
	{
        [DispId(1)]
        String[] GetConnectionDataInfo( String connectionName );

		[DispId(2)]
        void ForceServerListUpdate();

		[DispId(3)]
        void SetPaloError( String error );

        [DispId(4)]
        String ChooseElements(String serverDatabase, String dimensionName);

        [DispId(5)]
        String[] ChooseElementsEx(String serverDatabase, String dimensionName, Boolean multi, String attribute);

        [DispId(6)]
        String[] ChooseElementsEx(String serverDatabase, String dimensionName, Boolean multi, String attribute, Boolean returnName);

        [DispId(7)]
        Boolean DataExportFromCube(String serverDatabase, String cubeName, Object elementsArray, String compareValue1, Int32 compareOperator1, Int32 boolOperator, String compareValue2, Int32 compareOperator2, Boolean ignoreEmptyCells, Boolean baseElementsOnly, String fileName, String valueSeparator, Boolean append);

        [DispId(8)]
        Boolean DataExportFromCubeEx(String serverDatabase, String cubeName, Object elementsArray, String compareValue1, Int32 compareOperator1, Int32 boolOperator, String compareValue2, Int32 compareOperator2, Boolean ignoreEmptyCells, Boolean baseElementsOnly, String fileName, String valueSeparator, Boolean append, Boolean useRules);

        [DispId(9)]
        Boolean DataExportFromCubeEx2(String serverDatabase, String cubeName, Object elementsArray, String compareValue1, Int32 compareOperator1, Int32 boolOperator, String compareValue2, Int32 compareOperator2, Boolean ignoreEmptyCells, Boolean baseElementsOnly, String fileName, String valueSeparator, Boolean append, Boolean useRules, Boolean withHeader);

        [DispId(10)]
        Boolean ClearWholeCube(String serverDatabase, String cubeName);

        [DispId(11)]
        Boolean ClearPartialCube(String serverDatabase, String cubeName, Object elementsArray);

        [ComVisible(true)]
        [DispId(12)]
        Boolean DataImportFromCSV(String importCsvFileName, Boolean hasHeader, String separator, String decimalPoint, Boolean screenupdate);

        [ComVisible(true)]
        [DispId(13)]
        Boolean DataImportFromODBC(String dsn, String username, String password, String sqlExpression, Boolean screenupdate);

        [ComVisible(true)]
        [DispId(14)]
        Boolean DataImportFromCube(String serverDatabase, String cubeName, Object elementsArray, String compareValue1, Int32 compareOperator1, Int32 boolOperator, String compareValue2, Int32 compareOperator2, Boolean ignoreEmptyCells, Boolean baseElementsOnly, bool screenupdate);

        [ComVisible(true)]
        [DispId(15)]
        Boolean DataImportFromInternalLoop(Boolean screenupdate);

        [DispId(16)]
        String[,] GetServerSubSetContent(String serverDatabase, String dimension, Boolean global, String subset);

        [DispId(17)]
        String AliasLookup(String serverDatabase, String dimension, String  attribute, String alias, int index);

        [DispId(18)]
        String GetTrustFile();
    }
    #endregion

    #region Implementation
    [ComVisible(true)]
    [GuidAttribute("4A910541-7C9B-4A92-8BBB-F404EDD9C1D0"), ProgId("Apalo.XlAddin.ComInterface")]
	[ ClassInterface( ClassInterfaceType.AutoDispatch ) ]
    public class ComInterface : IPaloEngineCom, System.IDisposable
    {

        #region Construct/Destruct

        public ComInterface()
        {
            Connect.Checkinit();
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                XmlUtils.cleanup();
            }
        }

        #endregion

        #endregion

        private bool GetDBServerAndConn(String serverDatabase, ref Jedox.Palo.Comm.Connection conn, ref String servername, ref String db)
        {
            string[] conninfo;
            int pos = -1;

            pos = serverDatabase.IndexOf('/');

            if (pos > -1)
            {
                servername = serverDatabase.Substring(0, pos);
                db = serverDatabase.Substring(pos + 1);
            }
            else
            {
                return false;
            }
            conninfo = GetConnectionDataInfo(servername);

            if (conninfo[0] != "")
            {
                return false;
            }

            conn = Connections.GetConnection(conninfo[1], conninfo[2], conninfo[3], conninfo[4], servername, true);
            return true;
        }

        private bool GetDBAndConn(String serverDatabase, ref Jedox.Palo.Comm.Connection conn, ref String db)
        {
            string servername = null;
            return GetDBServerAndConn(serverDatabase, ref conn, ref servername, ref db);
        }

        #region ForceServerListUpdate
        [ComVisible(false)]
		public void ForceServerListUpdate()
		{
			XmlUtils.ReadXmlInitial();
        }
        #endregion

        #region GetConnection
        [ComVisible(false)]
		public static void GetConnection()
		{
			try
			{
				int ret = NativeMethods.Register_UCOMI();
			}
			catch(Exception e)
            {
                ErrorHandler.DisplayError("Error registering to ROT!", e);
            }
        }
        #endregion

        #region SetPaloError
        // just for backwards compatibility
        [ComVisible(false)]
		public void SetPaloError(String error) 
		{
		}
        #endregion

        #region GetConnectionInfo
		[ComVisible(false)]
		public String[] GetConnectionDataInfo( String serverName ) 
		{

            if (String.IsNullOrEmpty(serverName))
            {
                return new String[] { "", "", "", "", "" };
            }

			string hostName = "";
			string service = "";
			string userName = "";
			string passWord = "";

            try
            {
                Connect.Checkinit();
                DataTable myDt = XmlUtils.dsConnectionsTable;
                foreach (DataRow r in myDt.Rows)
                {
                    if (ConnectionsHelper.Look4conn(serverName, r, ref hostName, ref service, ref userName, ref passWord))
                    {
                        break;
                    }
                }
            }
            catch (Jedox.Palo.Comm.PaloException)
            {
            }

			String[] sa = new String[5];

			if(hostName.Length == 0)
			{
				sa[0] = "Error: Unknown connection '" + serverName + "'!";
					
			}
			else if(userName.Length == 0)
			{
				sa[0] = "Error: Logon data not provided for '" + serverName + "'!";
			}
			else
			{
				sa[0] = "";
			}
			
			sa[1] = hostName;
			sa[2] = service;
			sa[3] = userName;
			sa[4] = passWord;

			return sa;
        }
        #endregion

        #region ChooseElements
        [ComVisible(false)]
        public String ChooseElements(String serverDatabase, String dimension)
        {
            String[] elems = ChooseElementsEx(serverDatabase, dimension, false, "");
            if (elems.Length == 0)
            {
                return "";
            }
            return elems[0];
        }

        [ComVisible(false)]
        public String[] ChooseElementsEx(String serverDatabase, String dimension, bool multi, String attribute, bool returnName)
        {
            if (String.IsNullOrEmpty(serverDatabase) || String.IsNullOrEmpty(dimension))
            {
                return new String[0];
            }

            Connect.Checkinit();

            Forms.ChooseElements ce = new Forms.ChooseElements(serverDatabase, dimension);
            System.Collections.ArrayList tmpArrayList = new System.Collections.ArrayList();
            object[] tmpObject = new object[] { "", false, "" };
            tmpArrayList.Add(tmpObject);
            ce.set_selection(ref tmpArrayList, multi, attribute, true);
            System.Windows.Forms.DialogResult tmpDr = ce.ShowDialog();
            ce.Dispose();

            if (tmpDr == System.Windows.Forms.DialogResult.Cancel)
            {
                tmpArrayList.Clear();
            }
            int i, count = tmpArrayList.Count, index = (returnName) ? 0 : 3;;
            object[] aa;
            string[] elems = new string[count];
            for (i = 0; i < count; i++)
            {
                aa = (object[])tmpArrayList[i];
                elems[i] = aa[index].ToString();
            }

            return elems;
        }

        [ComVisible(false)]
        public String[] ChooseElementsEx(String serverDatabase, String dimension, bool multi, String attribute)
        {
            return ChooseElementsEx(serverDatabase, dimension, multi, attribute, false);
        }
        #endregion

        #region DataExport/Import

        private bool do_import(System.Collections.ArrayList parameters, bool screenupdate)
        {
            Connect.Checkinit();
        	CultureInfo CurrentCulture = Thread.CurrentThread.CurrentCulture;
		    CultureInfo CurrentUICulture = Thread.CurrentThread.CurrentUICulture;
            bool go_on = true;
            ExcelHelper eH = null;
            System.Windows.Forms.ProgressBar progess = null;
            ImportCore impcore = null;
            bool oldscreenupdate = ExcelHelper.GetScreenUpdating();

            try
			{
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                ExcelHelper.SetScreenUpdating(screenupdate);

                object om = Type.Missing;
                eH = new ExcelHelper();

                progess = new System.Windows.Forms.ProgressBar();
                impcore = new ImportCore(System.Threading.Thread.CurrentThread.CurrentUICulture, eH, ref progess, null);

                if (ExcelHelper.oExcelApp == null)
                {
                    System.Windows.Forms.MessageBox.Show("ExcelHelper.oExcelApp is null");
                }

                switch ((byte)parameters[0])
                {
                    case ImportCore.IMPORT_CSV :
                        impcore.set_csv_params((string)parameters[1], (bool)parameters[2], (char)parameters[3], (string)parameters[4], false, 0, false);
                        break;

                    case ImportCore.IMPORT_ODBC:
                        impcore.set_odbc_params((string)parameters[1], (string)parameters[2], (string)parameters[3], (string)parameters[4]);
                        break;

                    case ImportCore.IMPORT_CUBE:
                        impcore.set_cube_params((Jedox.Palo.Comm.Connection)parameters[1], (string)parameters[2], (string)parameters[3], (System.Collections.ArrayList)parameters[4], new System.Collections.ArrayList(new object[] {parameters[5], parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11]}));
                        break;

                    case ImportCore.IMPORT_INTERNAL_LOOP:
                        impcore.set_internal_mode_params();
                        break;

                    default:
                        go_on = false;
                        break;
                }

                if (go_on)
                {
                    impcore.start();

                    if (!impcore.empty())
                    {
                        impcore.set_screenupdating(false);
                        ExcelHelper.PaloEnableLoop(true);
                        ExcelHelper.AddNameValue(Utils.GeneralConst.IMPORT_ACTIVE, true);

                        impcore.t_insertRow();

                        ExcelHelper.AddNameValue(Utils.GeneralConst.IMPORT_ACTIVE, false);
                        ExcelHelper.PaloEnableLoop(true);
                        impcore.set_screenupdating(true);
                    }
                }
            }
            catch (Exception exc)
            {
                string importsource = "";

                switch ((byte)parameters[0])
                {
                    case ImportCore.IMPORT_CSV:
                        importsource = "file";
                        break;

                    case ImportCore.IMPORT_ODBC:
                        importsource = "ODBC";
                        break;

                    case ImportCore.IMPORT_CUBE:
                        importsource = "cube";
                        break;

                    case ImportCore.IMPORT_INTERNAL_LOOP:
                        importsource = "internal loop";
                        break;

                    default:
                        go_on = false;
                        break;
                }

                ErrorHandler.DisplayError("Error importing data from " + importsource+ " in VBA", exc);
                ExcelHelper.ResetExcelStatusbar();
                go_on = false;
            } 
            finally
		    {
                if (impcore != null)
                {
                    impcore.clean_up();
                    impcore.Dispose();
                    impcore = null;
                }

                if (progess != null) 
                {
                    progess.Dispose();
                    progess = null;
                }

                if (eH != null)
                {
                    eH.Dispose();
                    eH = null;
                }

                ExcelHelper.SetScreenUpdating(oldscreenupdate);

                // Restore the culture information for the thread after the
				// Excel calls have completed.
                Thread.CurrentThread.CurrentCulture = CurrentCulture;
                Thread.CurrentThread.CurrentUICulture = CurrentUICulture;
                GC.Collect();
            }

            return go_on;

        }

        private bool PrepareCube(String serverDatabase, Object sElements, ref System.Collections.ArrayList elements, ref Jedox.Palo.Comm.Connection conn, ref string db)
        {

            // convert COM Object into ArrayList
            System.Collections.ArrayList pElements = (System.Collections.ArrayList)CastComObjectIntoArrayList(sElements);
            elements = new System.Collections.ArrayList();
            foreach (object tmpStrArr in pElements)
            {
                System.Collections.ArrayList tmpObjectArray = (System.Collections.ArrayList)CastComObjectIntoArrayList(tmpStrArr);
                elements.Add(new object[] { "", tmpObjectArray });
            }

            return GetDBAndConn(serverDatabase, ref conn, ref db);
        }


        [ComVisible(false)]
        public Boolean DataImportFromCSV(string fname, bool has_header, string separator, string decpoint, bool screenupdate)
        {
            if (String.IsNullOrEmpty(fname) || String.IsNullOrEmpty(separator) || String.IsNullOrEmpty(decpoint))
            {
                return false;
            }
            return this.do_import(new System.Collections.ArrayList(new object[] { ImportCore.IMPORT_CSV, fname, has_header, separator[0], decpoint }), screenupdate);
        }

        [ComVisible(false)]
        public Boolean DataImportFromODBC(string dsn, string user, string password, string sql_cmd, bool screenupdate)
        {
            if (String.IsNullOrEmpty(dsn) || user == null || password == null || String.IsNullOrEmpty(sql_cmd))
            {
                return false;
            }

            string tmpstr = sql_cmd.Trim();
            int pos = tmpstr.ToUpper().IndexOf("SELECT");

            if (pos < 0)
            {
                return false;
            }

            tmpstr = tmpstr.Substring(pos);
            int count = tmpstr.Length;
            bool instring = false;

            for (int i = 0; i < count; i++)
            {
                if (tmpstr[i] == System.Convert.ToChar("'"))
                {
                    instring = !instring;
                }
                if ((tmpstr[i] == ';') && !instring)
                {
                    tmpstr = tmpstr.Substring(0, i + 1);
                    break;
                }
            }
            if (tmpstr.Length == 0)
            {
                return false;
            }

            return this.do_import(new System.Collections.ArrayList(new object[] { ImportCore.IMPORT_ODBC, dsn, user, password, tmpstr }), screenupdate);

        }

        [ComVisible(false)]
        public Boolean DataImportFromCube(String serverDatabase, string cube, Object sElements, string comparevalue1, Int32 compareop1, Int32 boolop, string comparevalue2, Int32 compareop2, Boolean ignoreEmptyCells, Boolean baseElementsOnly, bool screenupdate)
        {
            if (String.IsNullOrEmpty(serverDatabase) || String.IsNullOrEmpty(cube) || (sElements == null) || String.IsNullOrEmpty(comparevalue1) || String.IsNullOrEmpty(comparevalue2) )
            {
                return false;
            }

            String db = null;
            System.Collections.ArrayList elements = null;
            Jedox.Palo.Comm.Connection conn = null;

            return this.PrepareCube(serverDatabase, sElements, ref elements, ref conn, ref db) && this.do_import(new System.Collections.ArrayList(new object[] { ImportCore.IMPORT_CUBE, conn, db, cube, elements, comparevalue1, compareop1, boolop, compareop2, comparevalue1, ignoreEmptyCells, baseElementsOnly }), screenupdate);
        }

        [ComVisible(false)]
        public Boolean DataImportFromInternalLoop(bool screenupdate)
        {
            return this.do_import(new System.Collections.ArrayList(new object[] { ImportCore.IMPORT_INTERNAL_LOOP }), screenupdate);
        }

        [ComVisible(false)]
        public Boolean DataExportFromCubeEx2(String serverDatabase, string cube, Object sElements, string comparevalue1, Int32 compareop1, Int32 boolop, string comparevalue2, Int32 compareop2, Boolean ignoreEmptyCells, Boolean baseElementsOnly, String fileName, String valueSeparator, Boolean append, Boolean useRules, Boolean withHeader)
        {
            Connect.Checkinit();
            bool go_on = true;
            try
            {
                if (String.IsNullOrEmpty(serverDatabase) || String.IsNullOrEmpty(cube) || String.IsNullOrEmpty(comparevalue1) || String.IsNullOrEmpty(comparevalue2) || (sElements == null) || String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(valueSeparator))
                {
                    return false;
                }

                String db = null;
                System.Collections.ArrayList elements = null;
                Jedox.Palo.Comm.Connection conn = null;

                go_on = this.PrepareCube(serverDatabase, sElements, ref elements, ref conn, ref db);

                if (go_on)
                {
                    System.Windows.Forms.ProgressBar progess = new System.Windows.Forms.ProgressBar();
                    ImportCore impcore = new ImportCore(System.Threading.Thread.CurrentThread.CurrentUICulture, new ExcelHelper(), ref progess, null);

                    try
                    {
                        impcore.set_csv_params(fileName, false, (char)(valueSeparator[0]), ".", append, 0, true);
                        impcore.set_withHeader(withHeader);
                        impcore.set_cube_params(conn, db, cube, elements, new System.Collections.ArrayList(new object[] { comparevalue1, compareop1, boolop, compareop2, comparevalue1, ignoreEmptyCells, baseElementsOnly, useRules }));
                        impcore.start();

                        if (!impcore.empty())
                        {
                            impcore.t_insertRowCsv();
                        }

                    }
                    catch (Exception exc)
                    {
                        ErrorHandler.DisplayError("Error exporting data from cube for VBA", exc);
                        go_on = false;
                    }
                    impcore.clean_up();
                }
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error exporting data from cube for VBA Part 2", exc);
                throw;
            }

            
            return go_on;
        }

        [ComVisible(false)]
        public Boolean DataExportFromCubeEx(String serverDatabase, string cube, Object sElements, string comparevalue1, Int32 compareop1, Int32 boolop, string comparevalue2, Int32 compareop2, Boolean ignoreEmptyCells, Boolean baseElementsOnly, String fileName, String valueSeparator, Boolean append, Boolean useRules)
        {
            return DataExportFromCubeEx2(serverDatabase, cube, sElements, comparevalue1, compareop1, boolop, comparevalue2, compareop2, ignoreEmptyCells, baseElementsOnly, fileName, valueSeparator, append, useRules, false);
        }

        [ComVisible(false)]
        public Boolean DataExportFromCube(String serverDatabase, string cube, Object sElements, string comparevalue1, Int32 compareop1, Int32 boolop, string comparevalue2, Int32 compareop2, Boolean ignoreEmptyCells, Boolean baseElementsOnly, String fileName, String valueSeparator, Boolean append)
        {
            return DataExportFromCubeEx2(serverDatabase, cube, sElements, comparevalue1, compareop1, boolop, comparevalue2, compareop2, ignoreEmptyCells, baseElementsOnly, fileName, valueSeparator, append, false, false);
        }


        #endregion

        #region ClearCube
        [ComVisible(false)]
        public Boolean ClearWholeCube(String serverDatabase, String cube)
        {
            if (String.IsNullOrEmpty(serverDatabase) || String.IsNullOrEmpty(cube))
            {
                return false;
            }

            string db = null;
            Jedox.Palo.Comm.Connection conn = null;

            if (!GetDBAndConn(serverDatabase, ref conn, ref db))
            {
                return false;
            }

            String[][] dimelements;

            dimelements = new String[0][];

            conn.CubeClear(db, cube);
            return true;
        }

        #region CastComObjectIntoArrayList
        [ComVisible(false)]
        private System.Collections.ArrayList CastComObjectIntoArrayList(object comObject)
        {
            if (comObject == null)
                return new System.Collections.ArrayList();

            Type thisType = comObject.GetType();
            Type objType = Type.GetType("System.Object[*]");
            Type objType2 = Type.GetType("System.Object[,]");
            Type objType3 = Type.GetType("System.Object[]");
            Type objType4 = Type.GetType("System.String");
            System.Collections.ArrayList objectArray = new System.Collections.ArrayList();
            // temporary allocation to keep compiler happy.

            if ((thisType == objType) || (thisType == objType3))
            {
                object[] args = new object[1];
                int numEntries = (int)thisType.InvokeMember("Length",
                                         BindingFlags.GetProperty,
                                         null, comObject, null);

                Object obj;
                Object[,] strobj;
                Object[] strar;
                int k, len;
                for (int j = 0; j < numEntries; j++)
                {
                    // since VB arrays index from 1
                    args[0] = j + ((thisType == objType) ? 1 : 0);
                    obj = (object)thisType.InvokeMember("GetValue",
                                       BindingFlags.InvokeMethod,
                                          null, comObject, args);
                    if ((obj != null) && (obj.GetType() == objType2))
                    {
                        strobj = (Object[,])obj;
                        len = strobj.GetLength(0);
                        strar = new Object[len];
                        for (k = 0; k < len; k++)
                        {
                            strar[k] = strobj[k + 1, 1];
                        }
                        objectArray.Add(strar);
                    }
                    else
                    {
                        objectArray.Add(obj);
                    }
                }
            }
            else
            {
                if (thisType == objType4)
                {
                    objectArray.Add(comObject);
                }
            }
            return objectArray;
        } // ~ CastComObjectIntoArrayList()
        #endregion

        #region CastComObjectIntoObjectArray
       /* [ComVisible(false)]
        private System.Collections.ArrayList CastComObjectIntoObjectArray(object comObject)
        {
            if (comObject == null)
                return new object[] { };

            Type thisType = comObject.GetType();
            Type objType = Type.GetType("System.Object[*]");
            object[] objectArray = new object[2];
            // temporary allocation to keep compiler happy.
            if (thisType == objType)
            {
                object[] args = new object[1];
                int numEntries = (int)thisType.InvokeMember("Length",
                                         BindingFlags.GetProperty,
                                         null, comObject, null);
                objectArray = new System.Collections.ArrayList();
                for (int j = 0; j < numEntries; j++)
                {
                    // since VB arrays index from 1
                    args[0] = j + 1;
                    objectArray[j] = new object[]{(
                        (object)thisType.InvokeMember("GetValue",
                                       BindingFlags.InvokeMethod,
                                          null, comObject, args)
                                    )};
                }
            }
            return objectArray;
        } // ~ CastComObjectIntoObjectArray()*/
        #endregion

        [ComVisible(false)]
        public Boolean ClearPartialCube(String serverDatabase, String cube, Object sElements)
        {
            if (String.IsNullOrEmpty(serverDatabase) || String.IsNullOrEmpty(cube) || (sElements == null))
            {
                return false;
            }

            System.Collections.ArrayList pElements = (System.Collections.ArrayList)CastComObjectIntoArrayList(sElements);
            System.Collections.ArrayList elements = new System.Collections.ArrayList();
            foreach (object tmpStrArr in pElements)
            {
                System.Collections.ArrayList tmpObjectArray = (System.Collections.ArrayList)CastComObjectIntoArrayList(tmpStrArr);
                elements.Add(tmpObjectArray);
            }
            
            string db = null;
            Jedox.Palo.Comm.Connection conn = null;

            if (!GetDBAndConn(serverDatabase, ref conn, ref db))
            {
                return false;
            }

            String[][] dimelements;
            long anzahl = elements.Count;
            long anzahl2;

            System.Collections.ArrayList werte;

            dimelements = new String[anzahl][];
            for (int i = 0; i < anzahl; i++)
            {
                werte = (System.Collections.ArrayList)elements[i];
                anzahl2 = werte.Count;
                if (anzahl2 != 0)
                {
                    dimelements[i] = new String[anzahl2];
                    for (int j = 0; j < anzahl2; j++)
                    {
                        dimelements[i][j] = (string)(werte[j]);
                    }
                }
                else
                    dimelements[i] = new String[0] { };
            }

            try
            {
                conn.CubeClear(db, cube, dimelements);
            }
            catch (Exception exc)
            {
                ErrorHandler.DisplayError("Error partially clearing cube from VBA", exc);
                return false;
            }
            return true;
        }
        #endregion

        #region PALO.SERVER_SUBSET

        /// PALO.SERVER_SUBSET(connection_string;dimension;typ;subset_name;arg1;...;argN)
        [ComVisible(false)]
        public String[,] GetServerSubSetContent(String serverDatabase, String dimension, Boolean global, String subset)
        {
            if (String.IsNullOrEmpty(serverDatabase) || String.IsNullOrEmpty(dimension) || String.IsNullOrEmpty(subset))
            {
                return new String[0, 0];
            }
            string db = null;
            Jedox.Palo.Comm.Connection conn = null;

            string servername = null;

            if (!GetDBServerAndConn(serverDatabase, ref conn, ref servername, ref db))
            {
                return new String[0, 0];
            }
            //System.Collections.ArrayList namedParameters = (System.Collections.ArrayList)CastComObjectIntoArrayList(parameters);
            
            Forms.SubSetEditor ast = new Forms.SubSetEditor( Forms.EditorType.GlobalOnly, servername, db, dimension);
            Jedox.Palo.Comm.SubsetResult[] results;
            try
            {
                ast.LoadSubset(subset, (global ? SubsetType.Global : SubsetType.Local));
                results = ast.aSubSet.GetSubSetResults(conn, db, -1);
            }
            catch (Exception e)
            {
                ErrorHandler.DisplayError("Error getting subset in ComInterface", e);
                throw;
            }
            ast.Dispose();


            if (results != null)
            {
                String[,] resultObject = new String[results.Length, 3];
                for (int i = 0; i < results.Length; i++)
                {
                    Jedox.Palo.Comm.SubsetResult res = results[i];

                    resultObject[i, 0] = res.Index.ToString();
                    resultObject[i, 1] = res.Name;
                    resultObject[i, 2] = res.Alias;
                }

                return resultObject;
            }
            else
            {
                return new String[0, 0];
            }
            
        }
        #endregion

        #region AliasLookup
        [ComVisible(false)]
        public String AliasLookup(String serverDatabase, String dimension, String attribute, String alias, int index)
        {
            string db = null;
            Jedox.Palo.Comm.Connection conn = null;

            if (!GetDBAndConn(serverDatabase, ref conn, ref db))
            {
                return "";
            }

            uint blocksize = 10000;
            Jedox.Palo.Comm.GetDataExportOptions opts = new Jedox.Palo.Comm.GetDataExportOptions();

            string[][] dimelements = new String[2][];
            dimelements[0] = new string[1];
            dimelements[0][0] = attribute;
            dimelements[1] = new string[0];

            opts.Filter.CmpOp1 = Jedox.Palo.Comm.CompareOp.CompareOpTRUE;
            opts.Filter.Value1.Type = Jedox.Palo.Comm.CellValueType.CellValueTypeDouble;
            opts.Filter.Value1.Value.DblValue = 0;
            opts.Filter.AndOr12 = Jedox.Palo.Comm.BoolOp.BoolOpAND;
            opts.Filter.CmpOp2 = Jedox.Palo.Comm.CompareOp.CompareOpTRUE;
            opts.Filter.Value2.Type = Jedox.Palo.Comm.CellValueType.CellValueTypeDouble;
            opts.Filter.Value2.Value.DblValue = 0;

            opts.IngoreEmptyCells = false;
            opts.BaseElementsOnly = false;

            opts.LastCoordinates = new String[0];
            opts.NumDatasets = blocksize;
            
            Jedox.Palo.Comm.Dataset[] dsa = null;
            Jedox.Palo.Comm.Dataset ds;
            int i, dsasize, counteq = 1;
            string elem = "", avalue;
            do
            {
                dsa = conn.GetDataExport(db, conn.GetAttributeCube(db, dimension), dimelements, opts);

                dsasize = dsa.Length;

                for (i = 0; i < dsasize; i++)
                {
                    ds = dsa[i];
                    if (ds.Value.Type == Jedox.Palo.Comm.CellValueType.CellValueTypeDouble)
                    {
                        avalue = ds.Value.Value.DblValue.ToString();
                    }
                    else
                    {
                        avalue = ds.Value.Value.StrValue;
                    }
                    if (String.Equals(alias, avalue,StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (index == counteq++)
                        {
                            elem = ds.Coordinates[1];
                            break;
                        }
                    }
                }
                if (dsasize > 0)
                {
                    opts.LastCoordinates = dsa[dsasize - 1].Coordinates;
                }
            }
            while ((dsasize == blocksize) && string.IsNullOrEmpty(elem));

            return elem;
        }
        #endregion

        #region TrustFile
        [ComVisible(false)]
        public String GetTrustFile()
        {
            return RegUtils.GetTrustfile();
        }
        #endregion
    }


    #endregion
}
