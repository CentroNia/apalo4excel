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
namespace Apalo.XlAddin.Utils
{
	using System;
	using System.Collections;
	using Microsoft.Win32;

	[System.Runtime.InteropServices.ComVisible(false)]
	public class OdbcMngr
	{
		private const string ODBC_LOC_IN_REGISTRY = "SOFTWARE\\ODBC\\";
		private const string ODBC_INI_LOC_IN_REGISTRY = ODBC_LOC_IN_REGISTRY+"ODBC.INI\\";
		private const string DSN_LOC_IN_REGISTRY = ODBC_INI_LOC_IN_REGISTRY+ "ODBC Data Sources\\";
		private const string ODBCINST_INI_LOC_IN_REGISTRY = ODBC_LOC_IN_REGISTRY+"ODBCINST.INI\\";
		private const string ODBC_DRIVERS_LOC_IN_REGISTRY = ODBCINST_INI_LOC_IN_REGISTRY+"ODBC Drivers\\";
		private string m_DSNName = null;
		private string m_DSNDriverName = null;
		private string m_DSNDescription = null;
		private string m_DSNServerName = null;
		private string m_DSNDrivr = null;
		private OdbcMngr(string dsnName, string dsnDriverName, string description, string server, string driver)
		{
			m_DSNName = dsnName;
			m_DSNDriverName = dsnDriverName;
			m_DSNDescription = description;
			m_DSNServerName = server;
			m_DSNDrivr = driver;
		}

		public static OdbcMngr ParseForODBCMngr(string dsnName, string dsnDriverName, string[] dsnElements, string[] dsnElmVals)
		{
			OdbcMngr OdbcMngr = null;

			if (dsnElements != null && dsnElmVals != null)
			{
				int i=0;
				string description = null;
				string server = null;
				string driver = null;

				// For each element defined for a typical DSN get
				// its value.
				foreach (string dsnElement in dsnElements)
				{
					switch (dsnElement.ToLower())
					{
						case "description":
							description = dsnElmVals[i];
							break;
						case "server":
							server = dsnElmVals[i];
							break;
						case "driver":
							driver = dsnElmVals[i];
							break;
					}
					i++;
				}
				OdbcMngr = new OdbcMngr(dsnName, dsnDriverName, description, server, driver); 
			}
			return OdbcMngr;
		}

		public string GetDSNName()
		{
			return m_DSNName;
		}

		public string GetDSNDriverName()
		{
			return m_DSNDriverName;
		}

		public string GetDSNDescription()
		{
			return m_DSNDescription;
		}

		public string GetDSNServerName()
		{
			return m_DSNServerName;
		}

		public string GetDSNDriverPath()
		{
			return m_DSNDrivr;
		}

		public override string ToString()
		{
			return GetDSNName();
		}

		private static OdbcMngr[] GetDSNList(RegistryKey baseKey)
		{
			ArrayList dsnList = new ArrayList();
			OdbcMngr[] ODBCMngrs = null;

			if (baseKey == null)
				return (new OdbcMngr[0]);

			// Get the key for (using the baseKey parmetre passed in)
			// "\\SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources\\" (DSN_LOC_IN_REGISTRY)
			// that contains all the configured Data Source Name (DSN) entries.
			RegistryKey dsnNamesKey = OpenComplexSubKey(baseKey, DSN_LOC_IN_REGISTRY, false);

			if (dsnNamesKey != null)
			{
				// Get all DSN entries defined in DSN_LOC_IN_Registry.
				string [] dsnNames =  dsnNamesKey.GetValueNames();
				if (dsnNames != null)
				{
					// Foreach DSN entry in the DSN_LOC_IN_REGISTRY, goto the
					// Key ODBC_INI_LOC_IN_REGISTRY+dsnName and get elements of
					// the DSN entry to create OdbcMngr objects.
					foreach (string dsnName in dsnNames)
					{
						// Get ODBC DSN object.
						OdbcMngr OdbcMngr = GetDSN(baseKey,dsnName);
						if(OdbcMngr != null)
							dsnList.Add(OdbcMngr);
					}
					if (dsnList.Count>0)
					{
						// Create OdbcMngr objects equal to number of valid objects
						// in the DSN ArrayList.
						ODBCMngrs = new OdbcMngr[dsnList.Count];
						dsnList.CopyTo(ODBCMngrs,0);
					}
				}

				dsnNamesKey.Close();
			}

			if (ODBCMngrs == null) ODBCMngrs = new OdbcMngr[0];
			return ODBCMngrs;
		}

		private static OdbcMngr GetDSN(RegistryKey baseKey, string dsnName)
		{
			int j=0;
			string dsnDriverName = null;
			RegistryKey dsnNamesKey = null;
			RegistryKey dsnNameKey = null;
			string [] dsnElements = null;
			string [] dsnElmVals = null;
			OdbcMngr OdbcMngr = null;

			// Get the key for (using the baseKey parmetre passed in)
			// "\\SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources\\" (DSN_LOC_IN_REGISTRY)
			// that contains all the configured Data Source name (DSN) entries.
			dsnNamesKey = OpenComplexSubKey(baseKey, DSN_LOC_IN_REGISTRY, false);

			if (dsnNamesKey != null)
			{
				// Get the name of the driver for which the DSN is 
				// defined.
				dsnDriverName = dsnNamesKey.GetValue(dsnName).ToString();
				dsnNamesKey.Close();
			}

			// Get the key for ODBC_INI_LOC_IN_REGISTRY+dsnName.
			dsnNameKey = OpenComplexSubKey(baseKey, ODBC_INI_LOC_IN_REGISTRY+dsnName,false);

			if (dsnNameKey != null)
			{
				// Get all elements defined in the above key
				dsnElements = dsnNameKey.GetValueNames();

				// Create DSN Element values array.
				dsnElmVals = new string[dsnElements.Length];

				// For each element defined for a typical DSN get
				// its value.
				foreach (string dsnElement in dsnElements)
				{
					dsnElmVals[j] = dsnNameKey.GetValue(dsnElement).ToString();
					j++;
				}

				// Create OdbcMngr Object.
				OdbcMngr = OdbcMngr.ParseForODBCMngr(dsnName,dsnDriverName, dsnElements, dsnElmVals);

				dsnNamesKey.Close();
			}
			return OdbcMngr;
		}

		public static OdbcMngr[] GetUserDSNList()
		{
			return GetDSNList(Registry.CurrentUser);
		}

		public static OdbcMngr[] GetSystemDSNList()
		{
			return GetDSNList(Registry.LocalMachine);
		}

		public static RegistryKey OpenComplexSubKey(RegistryKey baseKey,string complexKey, bool writable)
		{
			int prevLoc=0,currLoc = 0;
			string subKeyStr=complexKey;
			RegistryKey finalKey = baseKey;

			if (baseKey == null)
				return null;

			if (complexKey == null)
				return finalKey;

			// Search for the occurence of "\\" character in the complex string
			// and get all the characters upto "\\" from the start of search
			// point (prevLoc) as the keyString. Open a key out of string 
			// keyString.
			do
			{
				currLoc=complexKey.IndexOf("\\",prevLoc);
				if (currLoc != -1)
				{
					subKeyStr = complexKey.Substring(prevLoc, currLoc-prevLoc);
					prevLoc=currLoc+1;
				}
				else
				{
					subKeyStr = complexKey.Substring(prevLoc);
				}

				if (!String.IsNullOrEmpty(subKeyStr))
					finalKey = finalKey.OpenSubKey(subKeyStr, writable);
			}
			while(currLoc != -1);
			return finalKey;
		}	
	}
}
