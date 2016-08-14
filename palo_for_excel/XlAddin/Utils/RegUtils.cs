 /* 
 *
 * Copyright (C) 2006-2011 Jedox AG
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General private License (Version 2) as published
 * by the Free Software Foundation at http://www.gnu.org/copyleft/gpl.html.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General private License for
 * more details.
 *
 * You should have received a copy of the GNU General private License along with
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

// Additional Revisions to Palo (c) Junction BI LLC:
// JMM 04-04-14 Added validation to form position

using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Apalo.XlAddin.Utils
{
	/// <summary>
	/// Summary description for RegUtils.
	/// </summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public class RegUtils
	{
        #region Define constants

        private const int NOIENTRY = -1;
        private const string NOSENTRY = "";

        public const int IPOSBOTTOM = 0;
        public const int IPOSFLOATING = 1;
        public const int IPOSLEFT = 2;
        public const int IPOSMENUBAR = 3;
        public const int IPOSPOPUP = 4;
        public const int IPOSRIGHT = 5;
        public const int IPOSTOP = 6;

        private const string XLADDIN = "XlAddin";
        private const string PALOBARBASE = "Palobar";
        private const string PALOBARPATH = XLADDIN + @"\" + PALOBARBASE + @"\";
        private const string FORMSPATH = XLADDIN + @"\Forms\";
        private const string LEFT = "Left";
        private const string TOP = "Top";
        private const string WIDTH = "Width";
        private const string HEIGHT = "Height";

        private const string DEFAULT = @".DEFAULT\";
        private const string BASEPATH = @"Software\Apalo\";
         
        private const string BASEPATHCONNECTION = BASEPATH + XLADDIN + @"\Connections\";
        private const string BASEPATHPWCONNECTION = BASEPATH + XLADDIN + @"\PWConn\";
        private const string BASEPATHCONNECTION2 = DEFAULT + BASEPATHCONNECTION;

        #endregion

        #region Define vars

        private static RegistryKey BaseKey = null;
        private static string BasePath = null;


        #endregion

        #region Helper

        private static object GetkeyValue(bool standard, string key, string path)
        {
            object Item = null;
            try
            {
                RegistryKey regKey = OpenRegKey(standard, key);
                if (regKey != null)
                {
                    Item = regKey.GetValue(path);
                    regKey.Close();
                }
            }
            catch (Exception ecx)
            {
                ErrorHandler.DisplayError("Error getting registry value for key=" + key + " and path=" + path, ecx);
            }
            return Item;
        }


        private static int GetIntValue(bool standard, string key, string path, int defaultvalue)
        {
            int Item = defaultvalue;
            try
            {
                object value = GetkeyValue(standard, key, path);
                if (value != null)
                {
                    Item = (int)value;
                }
            }
            catch (Exception ecx)
            {
                ErrorHandler.DisplayError("Error getting registry int value for key=" + key + " and path=" + path, ecx);
            }
            return Item;
        }

        private static int GetIntValue(string key, string path, int defaultvalue)
        {
            return GetIntValue(true, key, path, defaultvalue);

        }

        private static int GetIntValue(bool standard, string path, int defaultvalue)
        {
            return GetIntValue(standard, XLADDIN, path, defaultvalue);
        }


        private static int GetIntValue(string path, int defaultvalue)
        {
            return GetIntValue(XLADDIN, path, defaultvalue);
        }

        private static int GetIntValue(bool standard, string key, string path)
        {
            return GetIntValue(standard, key, path, NOIENTRY);
        }

        private static int GetIntValue(string key, string path)
        {
            return GetIntValue(true, key, path);
        }

        private static int GetIntValue(string path)
        {
            return GetIntValue(path, NOIENTRY);
        }

        public static int GetIntValue4Form(string form, string path)
        {
            return GetIntValue(false, FORMSPATH + form, path);
        }

        public static int GetIntValue4Form(string form, string path, int defaultvalue)
        {
            return GetIntValue(false, FORMSPATH + form, path, defaultvalue);
        }

        private static string GetStringValue(bool standard, string key, string path, string defaultvalue)
        {
            string Item = defaultvalue;
            try
            {
                object value = GetkeyValue(standard, key, path);
                if (value != null)
                {
                    Item = value.ToString();
                }
                if (String.IsNullOrEmpty(Item))
                {
                    Item = defaultvalue;
                }
            }
            catch (Exception ecx)
            {
                ErrorHandler.DisplayError("Error getting registry string value for key=" + key + " and path=" + path, ecx);
            }
            return Item;
        }

        private static string GetStringValue(bool standard, string path, string defaultvalue)
        {
            return GetStringValue(standard, XLADDIN, path, defaultvalue);
        }

        private static string GetStringValue(string path, string defaultvalue)
        {
            return GetStringValue(true, path, defaultvalue);
        }

        public static string GetStringValue(bool standard, string path)
        {
            return GetStringValue(standard, path, NOSENTRY);
        }

        public static string GetStringValue(string path)
        {
            return GetStringValue(true, path, NOSENTRY);
        }

        public static string GetStringValue4Form(string form, string path)
        {
            return GetStringValue(false, FORMSPATH + form, path, NOSENTRY);
        }

        private static void SetKeyValue(bool standard, string key, string path, object value)
        {
            try
            {
                RegistryKey regKey = OpenRegKey(standard, key, true);
                if (regKey == null)
                {
                    regKey = CreateRegKey(standard, key);
                }
                regKey.SetValue(path, value);
                regKey.Close();
            }
            catch (Exception ecx)
            {
                ErrorHandler.DisplayError("Error setting registry value for key=" + key + " , path=" + path + " and value=" + value.ToString(), ecx);
            }
        }

        private static void SetKeyValue(string key, string path, object value)
        {
            SetKeyValue(true, key, path, value);
        }

        public static void SetKeyValue(bool standard, string path, object value)
        {
            SetKeyValue(standard, XLADDIN, path, value);
        }

        public static void SetKeyValue(string path, object value)
        {
            SetKeyValue(true, path, value);
        }

        public static void SetKeyValue4Form(string form, string path, object value)
        {
            SetKeyValue(false, FORMSPATH + form, path, value);
        }

        public static void DeleteValue(string valuename)
        {
            RegistryKey XladdinKey = OpenRegKey(XLADDIN, true);
            if (XladdinKey != null)
            {
                XladdinKey.DeleteValue(valuename, false);
            }
        }

        #endregion

        #region unused

        /*
        private const String ADVANCENDCONTROL = "AdvancedControl"";
		private static bool AdvancedControl
		{
			get
			{
                return System.Convert.ToBoolean(GetIntValue(ADVANCENDCONTROL, 0))
			}
			set
			{
                SetKeyValue(ADVANCENDCONTROL, value);
			}
		}

        private static int LoadBehavior
        {
            get
            {
                int actItem = NOIENTRY;
                try
                {
                    RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Office\Excel\AddIns\Apalo.XlAddin.Connect");
                    actItem = (int)regKey.GetValue("LoadBehavior");
                    regKey.Close();
                }
                catch
                { }
                return actItem;
            }
            set
            {
                try
                {
                    RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Office\Excel\AddIns\Apalo.XlAddin.Connect", true);
                    regKey.SetValue("LoadBehavior", value);
                    regKey.Close();
                }
                catch
                { }
            }
        }
  */
        #endregion

        #region ClickToRun

        public static bool isClickToRun(string version)
        {
            string tmpstr = "";
            string path = @"\Microsoft\Office\" + version + @"\Common\InstallRoot\Virtual";

            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE" + path);

            if (regKey == null)
            {
                try
                {
                    regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node" + path);
                }
                catch
                {
                }
            }

            if (regKey != null)
            {
                object keyvalue = regKey.GetValue("VirtualExcel");
                if (keyvalue != null)
                {
                    tmpstr = keyvalue.ToString();
                }
            }

            return !string.IsNullOrEmpty(tmpstr);
        }

        #endregion

        #region Active Values

        private const String ACTIVEPATH = "Active";
        public static int Active
		{
			get
			{
                return GetIntValue(ACTIVEPATH);
			}
            /* read only
			set
			{
                SetKeyValue(ACTIVEPATH, value);
			}
             */
		}

        private const String ACTIVELANGUAGEPATH = "ActiveLanguage";
        public static string ActiveLanguage
		{
			get
			{
                return GetStringValue(ACTIVELANGUAGEPATH, "en-US");
			}
            /* read only
			set
			{
                SetKeyValue(ACTIVEPATH, value);
			}
             */
		}

        private const String ACTIVECONNECTION = "ActiveConnection";
        public static string ActiveConnection
        {
            get
            {
                return GetStringValue(ACTIVECONNECTION);
            }
            set
            {
                SetKeyValue(ACTIVECONNECTION, value);
            }
        }

        private const String ACTIVEDB = "ActiveDB";
        public static string ActiveDB
        {
            get
            {
                return GetStringValue(ACTIVEDB);
            }
            set
            {
                SetKeyValue(ACTIVEDB, value);
            }
        }

        private const String ACTIVECUBE = "ActiveCube";
        public static string ActiveCube
		{
			get
			{
                return GetStringValue(ACTIVECUBE);
			}
			set
			{
                SetKeyValue(ACTIVECUBE, value);
			}
        }
        #endregion

        #region Prism
        private const string PWCONNSPATH = "PWConnsPath";
        public static string PWConnsPath
        {
            get
            {
                return GetStringValue(PWCONNSPATH, System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + @"\JunctionBI\Palo\prism\pwrepo\conns\");
            }
            /* read only
            set
            {
                SetKeyValue(PWCONNSPATH, value);
            }
             */
        }

        private const string PWPRISMPATH = "PWPrismPath";
        public static string PWPrismPath
        {
            get
            {
                return GetStringValue(PWPRISMPATH);
            }
            /* read only
            set
            {
                SetKeyValue(PWPRISMPATH, value);
            }
             */
        }

        private const string PWDEFAULTCONN = "PWDefaultConn";
        public static string PWDefaultConn
        {
            get
            {
                return GetStringValue(false, PWDEFAULTCONN).Trim();
            }
            set
            {
                SetKeyValue(false, PWDEFAULTCONN, value);
            }
        }
        #endregion

        #region Misc values
        private const string DIMENSIONTEMPLATEPATH = "DimensionTemplatePath";
        public static string DimensionTemplatePath
        {
            get
            {
                string path = GetStringValue(DIMENSIONTEMPLATEPATH, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\DimensionTemplates");
                FileHelper.checkdir(path);
                return path;
            }
            /* read only
            set
            {
                SetKeyValue(DIMENSIONTEMPLATEPATH, value);
            }
            */
        }

        private const String SEARCHELEMENTPATH = "SearchElement";
        public static string SearchElement
        {
            get
            {
                return GetStringValue(SEARCHELEMENTPATH);
            }
            set
            {
                SetKeyValue(SEARCHELEMENTPATH, value);
            }
        }

        private const String SAVEPATHPATH = "SavePath";
        public static string SavePath
        {
            get
            {
                return GetStringValue(SAVEPATHPATH, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            }
            set
            {
                SetKeyValue(SAVEPATHPATH, value);
            }
        }

        private const String PALOONLINEUSERNAMEPATH = "PaloOnlineUsername";
        public static string PaloOnlineUsername
        {
            get
            {
                return GetStringValue(PALOONLINEUSERNAMEPATH);
            }
            set
            {
                SetKeyValue(PALOONLINEUSERNAMEPATH, value);
            }
        }

        private const String PALOONLINEPASSWORDPATH = "PaloOnlinePassword";
        public static string PaloOnlinePassword
        {
            get
            {
                return GetStringValue(PALOONLINEPASSWORDPATH);
            }
            set
            {
                SetKeyValue(PALOONLINEPASSWORDPATH, value);
            }
        }

        private const String SHOWINFOBOXPATH = "ShowInfoBox";
        public static Boolean ShowInfoBox
        {
            get
            {
                string showinfobox = GetStringValue(SHOWINFOBOXPATH);
                return (showinfobox.Length == 0) || (showinfobox == "True");
            }
            set
            {
                SetKeyValue(SHOWINFOBOXPATH, (value) ? "True" : "False");
            }
        }
        
        private const String DEBUGBREAKPATH = "DebugBreak";
        public static Boolean DebugBreak
        {
            get
            {
                string debugbox = GetStringValue(DEBUGBREAKPATH);
                return (debugbox.Length == 0) || (debugbox.Equals("true",StringComparison.OrdinalIgnoreCase));
            }
            set
            {
                SetKeyValue(DEBUGBREAKPATH, (value) ? "True" : "False");
            }
        }
        #endregion

        private const String HEARTBEATPATH = "HeartBeat";
        public static int HeartBeat
        {
            get
            {
                return GetIntValue(false, HEARTBEATPATH, 0);
            }
            set
            {
                SetKeyValue(false, HEARTBEATPATH, value);
            }
        }

        private const String SVSWINDOWSAUTHKEYPATH = "SVSWindowsAuthKey";
        public static string SVSWindowsAuthKey
        {
            get
            {
                return GetStringValue(SVSWINDOWSAUTHKEYPATH, "");
            }
        }


        private const String DEBUGMODEPATH = "DebugMode";
        public static bool DebugMode
        {
            get
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(GetStringValue(DEBUGMODEPATH, Boolean.FalseString));
                }
                catch
                {
                }
                return value;
            }
        }

        #region PaloBar
        private static int GetPaloBarIntValue(string path, int defaultvalue)
        {
            return GetIntValue(PALOBARPATH, path, defaultvalue);
        }

        private static int GetPaloBarIntValue(string path)
        {
            return GetPaloBarIntValue(path, 1);
        }

        private static void SetPaloBarKeyValue(string path, object value)
        {
            SetKeyValue(PALOBARPATH, path, value);
        }
        
        private const String POSITION = "Position";
		public static int PalobarPosition
		{
			get
			{
                return GetPaloBarIntValue(POSITION, IPOSTOP);
			}
			set
			{
                SetPaloBarKeyValue(POSITION, value);
			}
		}

        private const String VISIBLE = "Visible";
        public static int PalobarVisible
		{
			get
			{
                return GetPaloBarIntValue(VISIBLE, 1);
			}
			set
			{
                SetPaloBarKeyValue(VISIBLE, value);
			}
		}

        private const String ENABLED = "Enabled";
        public static int PalobarEnabled
        {
            get
            {
                return GetPaloBarIntValue(ENABLED, 1);
            }
            set
            {
                SetPaloBarKeyValue(ENABLED, value);
            }
        }

        public static int PalobarLeft
        {
            get
            {
                return GetPaloBarIntValue(LEFT, -1);
            }
            set
            {
                SetPaloBarKeyValue(LEFT, value);
            }
        }

        public static int PalobarTop
        {
            get
            {
                return GetPaloBarIntValue(TOP, -1);
            }
            set
            {
                SetPaloBarKeyValue(TOP, value);
            }
        }
        #endregion


        #region Export
        // @@@
        public static string ExportHostName
        {
            get
            {
                string hostname = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    hostname = (string)regKey.GetValue("ExportHostName");
                    regKey.Close();
                }
                catch
                {}
                return hostname;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportHostName", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportDB
        {
            get
            {
                string db = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    db = (string)regKey.GetValue("ExportDB");
                    regKey.Close();
                }
                catch
                {}
                return db;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportDB", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportCube
        {
            get
            {
                string cube = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    cube = (string)regKey.GetValue("ExportCube");
                    regKey.Close();
                }
                catch
                {}
                return cube;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportCube", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportFirstComparator
        {
            get
            {
                string comp = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    comp = (string)regKey.GetValue("ExportFirstComparator");
                    regKey.Close();
                }
                catch
                {}
                return comp;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportFirstComparator", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportFirstNumber
        {
            get
            {
                string number = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    number = (string)regKey.GetValue("ExportFirstNumber");
                    regKey.Close();
                }
                catch
                {}
                return number;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportFirstNumber", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportCombination
        {
            get
            {
                string combination = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    combination = (string)regKey.GetValue("ExportCombination");
                    regKey.Close();
                }
                catch
                {}
                return combination;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportCombination", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportSecondComparator
        {
            get
            {
                string comp = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    comp = (string)regKey.GetValue("ExportSecondComparator");
                    regKey.Close();
                }
                catch
                {}
                return comp;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportSecondComparator", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportSecondNumber
        {
            get
            {
                string number = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    number = (string)regKey.GetValue("ExportSecondNumber");
                    regKey.Close();
                }
                catch
                {}
                return number;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportSecondNumber", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static int ExportSkipEmpty
        {
            get
            {
                int skip = NOIENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    skip = (int)regKey.GetValue("ExportSkipEmpty");
                    regKey.Close();
                }
                catch
                {}
                return skip;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportSkipEmpty", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static int ExportBaseOnly
        {
            get
            {
                int only = NOIENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    only = (int)regKey.GetValue("ExportBaseOnly");
                    regKey.Close();
                }
                catch
                {}
                return only;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportBaseOnly", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static int ExportRules
        {
            get
            {
                int rules = NOIENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    rules = (int)regKey.GetValue("ExportRules");
                    regKey.Close();
                }
                catch
                {}
                return rules;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportRules", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportFile
        {
            get
            {
                string file = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    file = (string)regKey.GetValue("ExportFile");
                    regKey.Close();
                }
                catch
                {}
                return file;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportFile", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportSeparator
        {
            get
            {
                string separator = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    separator = (string)regKey.GetValue("ExportSeparator");
                    regKey.Close();
                }
                catch
                {}
                return separator;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportSeparator", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static int ExportAppend
        {
            get
            {
                int bAppend = NOIENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    bAppend = (int)regKey.GetValue("ExportAppend");
                    regKey.Close();
                }
                catch
                {}
                return bAppend;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportAppend", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static string ExportNewLine
        {
            get
            {
                string newLine = NOSENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    newLine = (string)regKey.GetValue("ExportNewLine");
                    regKey.Close();
                }
                catch
                {}
                return newLine;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportNewLine", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }

        public static int ExportHeader
        {
            get
            {
                int header = NOIENTRY;
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN);
                    header = (int)regKey.GetValue("ExportHeader");
                    regKey.Close();
                }
                catch
                {}
                return header;
            }
            set
            {
                try
                {
                    RegistryKey regKey = OpenRegKey(XLADDIN, true);
                    regKey.SetValue("ExportHeader", value);
                    regKey.Close();
                }
                catch
                {}
            }
        }
        #endregion

        #region Init

        private RegUtils()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private static void cleanup()
        {
            try
            {
                String[] keys = { "ActiveServerID", "ActiveItem", "PaloOnlineStayLoggedIn" };
                List<string> keys2 = new List<string>(keys);

                RegistryKey XladdinKey = OpenRegKey(XLADDIN, true);
                if (XladdinKey != null)
                {

                    string[] names = XladdinKey.GetValueNames();
                    string lower;

                    foreach (string s in names)
                    {
                        lower = s.ToLower();
                        if (lower.StartsWith("export") || lower.StartsWith("sb_"))
                        {
                            keys2.Add(s);
                        }
                    }

                    foreach (string s in keys2)
                    {
                        // @@@ not yet    XladdinKey.DeleteValue(s, false);
                    }

                    String[] keys3 = { "RuleEditor", "DimensionTemplate" };
                    List<string> keys4 = new List<string>(keys3);

                    foreach (string s in keys4)
                    {
                        try
                        {
                            XladdinKey.DeleteSubKeyTree(s);
                        }
                        catch
                        {
                        }
                    }
                    XladdinKey.Close();
                }
            }
            catch
            { }
        }

        public static void Init()
        {
            if (System.IO.File.Exists(GeneralConst.ExecutePath + @"LOCAL"))
            {
                BaseKey = Registry.CurrentUser;
                BasePath = BASEPATH;
            }
            else
            {
                BaseKey = Registry.Users;
                BasePath = DEFAULT + BASEPATH;
            }

            cleanup();

            try
            {
                CreateRegKey(@"\MRU");
                CreateConnRegKey(@"");
            }
            catch
            {
            }
        }
 
        #endregion

        #region FormProperties
        
        public static int[] GetFormProperties(string sFormName, bool CheckDeskTop=true)
        {
            // JMM 04-04-14 Added validation:
            int[] tmpRet = new int[] { -1, -1, -1, -1 };
            if (string.IsNullOrEmpty(sFormName))
                {
                return tmpRet;
                }            

            int l = GetIntValue4Form(sFormName, LEFT);
            int t = GetIntValue4Form(sFormName, TOP);
            int w = GetIntValue4Form(sFormName, WIDTH);
            int h = GetIntValue4Form(sFormName, HEIGHT);            
            if (CheckDeskTop)
                {
                if (w < 100 || h <= 2 * System.Windows.Forms.SystemInformation.CaptionHeight)
                    return tmpRet;

                var rc = new System.Drawing.Rectangle(l, t, w, h);
                var Screens = System.Windows.Forms.Screen.AllScreens;
                foreach (System.Windows.Forms.Screen s in Screens)
                    {
                    var b = s.Bounds;
                    b.Intersect(rc);
                    if (b.Width >= 100 && b.Height >= System.Windows.Forms.SystemInformation.CaptionHeight)
                        {
                        CheckDeskTop = false;
                        break;
                        }
                    }
                if (CheckDeskTop)
                    return tmpRet;
                }
            return new int[] { l, t, w, h };
        }

        public static void SetFormProperties(string sFormName, int[] iProperties)
        {

            if (string.IsNullOrEmpty(sFormName))
            {
                return;
            }

            SetKeyValue4Form(sFormName, LEFT, iProperties[0]);
            SetKeyValue4Form(sFormName, TOP, iProperties[1]);
            SetKeyValue4Form(sFormName, WIDTH, iProperties[2]);
            SetKeyValue4Form(sFormName, HEIGHT, iProperties[3]);
        }

        #endregion

        #region ConnData

        public static bool ClearConnSubKeys()
        {
            if (ExcelHelper.TestWithoutExcel) return true;
            try
            {
                RegistryKey regKey = OpenConnRegKey("", true);
                regKey.DeleteSubKeyTree("");
                regKey.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string[] GetConnSubKeys()
        {
            try
            {
                RegistryKey regKey = OpenConnRegKey("", false);
                string[] sResult = (string[])regKey.GetSubKeyNames();
                regKey.Close();
                return sResult;
            }
            catch
            {
                return new string[] { };
            }
        }

        public static string GetConnRegData(string sConnection, string sItem)
        {
            string sResult = "";
            try
            {
                RegistryKey regKey = OpenConnRegKey(sConnection, false);
                sResult = (string)regKey.GetValue(sItem);
                regKey.Close();
            }
            catch
            { }
            if (String.IsNullOrEmpty(sResult))
                return "";
            else
                return sResult;
        }

        public static bool SetConnRegData(string sConnection, string sItem, string sValue)
        {
            bool bResult = false;
            try
            {
                RegistryKey regKey = OpenConnRegKey(sConnection, true);
                regKey.SetValue(sItem, sValue);
                regKey.Close();
                bResult = true;
            }
            catch
            { }
            return bResult;
        }

        public static string GetTrustfile()
        {
            string addto = "\\cert\\client.pem";
            string trustfile = GeneralConst.ExecutePath + addto;
            if (!System.IO.File.Exists(trustfile))
            {
                trustfile = GeneralConst.ExecutePath + "..\\..\\signed" + addto;
                if (!System.IO.File.Exists(trustfile))
                {
                    trustfile = "";
                }
            }

            return trustfile;
        }

        #endregion

        #region RegUtility Functions

        private static RegistryKey getUsedKey(bool standard)
        {
            return (standard) ? BaseKey : Registry.CurrentUser;
        }

        private static string getUsedPath(bool standard)
        {
            return (standard) ? BasePath : BASEPATH;
        }

        // VBA related
        private static void CheckBaseValues()
        {
            if ((BaseKey == null) || (BasePath == null))
            {
                Connect.SimpleInit();
            }
        }

        private static RegistryKey OpenRegKey(bool standard, string sKey)
        {
            return OpenRegKey(standard, sKey, false);
        }

        private static RegistryKey OpenRegKey(string sKey)
        {
            return OpenRegKey(true, sKey);
        }

        private static RegistryKey OpenRegKey(string sKey, bool bWrite)
        {
            return OpenRegKey(true, sKey, bWrite);
        }

        private static RegistryKey OpenRegKey(bool standard, string sKey, bool bWrite)
        {
            CheckBaseValues();
            return getUsedKey(standard).OpenSubKey(getUsedPath(standard) + sKey, bWrite);
        }

        private static RegistryKey CreateRegKey(string sKey)
        {
            return CreateRegKey(true, sKey);
        }

        private static RegistryKey CreateRegKey(bool standard, string sKey)
        {
            try
            {
                return getUsedKey(standard).CreateSubKey(getUsedPath(standard) + sKey);
            }
            catch (System.UnauthorizedAccessException)
            {
                return null;
            }
        }

        public static bool CreateConnRegKey(string sKey)
        {
            try
            {
#if HORVATH
                Registry.Users.CreateSubKey(BASEPATHCONNECTION2 + sKey);
#else
                Registry.CurrentUser.CreateSubKey(BASEPATHCONNECTION + sKey);
#endif
                return true;
            }
            catch (System.UnauthorizedAccessException)
            {
                return false;
            }
        }

        private static RegistryKey OpenConnRegKeyHelper(string sKey, bool bWrite)
        {
#if HORVATH
            return Registry.Users.OpenSubKey(BASEPATHCONNECTION2 + sKey, bWrite);
#else
            return Registry.CurrentUser.OpenSubKey(BASEPATHCONNECTION + sKey, bWrite);
#endif

        }

        private static RegistryKey OpenConnRegKey(string sKey, bool bWrite)
        {
            RegistryKey item;
            try
            {
                item = OpenConnRegKeyHelper(sKey, bWrite);
            }
            catch
            {
                if (CreateConnRegKey(sKey))
                {
                    item = OpenConnRegKeyHelper(sKey, bWrite);
                }
                else
                {
                    item = Registry.CurrentUser.OpenSubKey(BASEPATHCONNECTION + sKey, bWrite);
                }
            }

            return item;
        }

        #endregion

        #region PWConns handling

        #region Helpers
        public static bool CreatePWConnRegKey(string sKey)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey(BASEPATHPWCONNECTION + sKey);
                return true;
            }
            catch (System.UnauthorizedAccessException)
            {
                return false;
            }
        }

        private static RegistryKey OpenPWConnRegKeyHelper(string sKey, bool bWrite)
        {
            return Registry.CurrentUser.OpenSubKey(BASEPATHPWCONNECTION + sKey, bWrite);
        }

        private static RegistryKey OpenPWConnRegKey(string sKey, bool bWrite)
        {
            RegistryKey item;
            try
            {
                item = OpenPWConnRegKeyHelper(sKey, bWrite);
            }
            catch
            {
                if (CreateConnRegKey(sKey))
                {
                    item = OpenPWConnRegKeyHelper(sKey, bWrite);
                }
                else
                {
                    item = Registry.CurrentUser.OpenSubKey(BASEPATHPWCONNECTION + sKey, bWrite);
                }
            }

            return item;
        }
        #endregion

        public static bool DeletePWConn(string connName)
        {
            try
            {

                RegistryKey regKey = OpenPWConnRegKey("", true);
                regKey.DeleteSubKeyTree(connName);
                regKey.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string[] GetPWConnSubKeys()
        {
            try
            {
                RegistryKey regKey = OpenPWConnRegKey("", false);
                string[] sResult = (string[])regKey.GetSubKeyNames();
                regKey.Close();
                return sResult;
            }
            catch
            {
                return new string[] { };
            }
        }

        public static string GetPWConnRegData(string sConnection, string sItem)
        {
            string sResult = "";
            try
            {
                RegistryKey regKey = OpenPWConnRegKey(sConnection, false);
                sResult = (string)regKey.GetValue(sItem);
                regKey.Close();
            }
            catch
            { }
            if (String.IsNullOrEmpty(sResult))
            {
                return "";
            }
            else
            {
                return sResult;
            }
        }

        public static bool SetPWConnRegData(string sConnection, string sItem, string sValue)
        {
            bool bResult = false;
            try
            {
                RegistryKey regKey = OpenPWConnRegKey(sConnection, true);
                regKey.SetValue(sItem, sValue);
                regKey.Close();
                bResult = true;
            }
            catch
            { }
            return bResult;
        }
        #endregion



        private static RegistryKey CompatibilityPackInstalledHelper(string key)
        {
            return Registry.ClassesRoot.OpenSubKey(@"Installer\Products\" + key);
        }


        public static bool CompatibilityPackInstalled()
        {
            bool installed = (GetIntValue("ForceEnablePublish", 0) != 0);

            if (!installed)
            {
                RegistryKey regKey = CompatibilityPackInstalledHelper("00002109020070400000000000F01FEC");

                if (regKey == null)
                {
                    regKey = CompatibilityPackInstalledHelper("00002109020090400000000000F01FEC");
                }

                if (regKey != null)
                {
                    installed = true;
                    regKey.Close();
                }
            }

            return installed;
        }
    }
}