using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Xml;

namespace PaloUtility
{
/// <summary>
/// Provides utility functions for palo and palo installer
/// </summary>
class Program
	{
	static int Main(string[] args)
		{

		if (args.Length < 1)
			{
			Console.WriteLine("No function specified.");
			return 1;
			}

		int RC = 1;
		string Function = args[0].ToLower();
		switch (Function)
			{


			/*-------------------------------*/
			/* Check if Windows OS is 64-bit */
			/*-------------------------------*/

			case "check64bitos":
				{
				try
					{
					bool is64 = DWSupport.CheckOSVersion.Is64BitOperatingSystem();
					RC = is64 ? 64 : 0;
					}
				catch (Exception Ex)
					{
					Console.WriteLine(Ex.Message);
					break;
					}
				break;
				}


			/*----------------------------------*/
			/* Check if a windows app is 64-bit */
			/*----------------------------------*/

			case "check64bitapp":
				{
				if (args.Length < 2)
					{
					Console.WriteLine("Too few arguments for check64bitapp function.");
					Console.WriteLine("Usage: PaloUtility check64bitapp app-name <set-env-var>");
					break;
					}

				string appName = args[1];
				string varName = args.Length > 2 ? args[2] : null;

				try
					{
					bool is64 = DWSupport.CheckOSVersion.Is64BitApplication(appName, true);
					if (!string.IsNullOrEmpty(varName))
						{
						string val = is64 ? "X64" : "X86";
						Environment.SetEnvironmentVariable(varName, val, EnvironmentVariableTarget.Machine);
						}
					RC = is64 ? 64 : 0;
					}
				catch (Exception Ex)
					{
					Console.WriteLine(Ex.Message);
					break;
					}
				break;
				}

			case "getofficeversion":
				{
				if (args.Length < 2)
					{
					Console.WriteLine("Too few arguments for getofficeversion function.");
					Console.WriteLine("Usage: PaloUtility getofficeversion app-name <set-env-var>");
					break;
					}

				string appName = args[1];
				string varName = args.Length > 2 ? args[2] : null;

				const string sInstallKey = "Software\\Microsoft\\Office\\{0}.0\\{1}\\InstallRoot";
				const string sInstallKey32 = "Software\\Wow6432Node\\Microsoft\\Office\\{0}.0\\{1}\\InstallRoot";
				const int FirstVersion = 11;
				const int LastVersion = 20;
				int FoundVer = 0;
				bool is64 = DWSupport.CheckOSVersion.Is64BitOperatingSystem();

				//	First pass: try normal registry, second pass: Wow64 registry
				for (int pass=0;pass<(is64?2:1);pass++)
					{
					//	Look for all application versions
					for (int ver=FirstVersion; ver <= LastVersion; ver++)
						{
						string sKey = string.Format(pass==0 ? sInstallKey : sInstallKey32, ver, appName);
						DWSupport.Registry64BitKey Key = DWSupport.Registry64BitKey.LocalMachine.OpenSubKey(sKey);
						if (Key != null)
							{
							if (ver > FoundVer)
								FoundVer = ver;
							Key.Close();
							}
						}
					}
				RC = FoundVer;
				break;
				}


			/*--------------------------------------------*/
			/*	Check for an existing palo/jedox service  */
			/*--------------------------------------------*/

			//	TODO, not yet used
			case "checkpaloservice":
				{
				//	No Palo Service found
				RC = 0;
				break;
				}


			/*-----------------------------------------*/
			/*	Sets folder access rights for a group  */
			/*-----------------------------------------*/
			//
			//	Function:
			//
			//		Sets folder access rights for a group
			//
			//	Syntax:
			//		setfolderaccess  account-name  folder-name	logfile
			//
			//	Note:
			//		If "logfile" is present, any errors are written there
			//
			case "setfolderaccess":
				{
				if (args.Length < 3)
					{
					Console.WriteLine("Too few arguments for setfolderaccess function.");
					Console.WriteLine("Usage: PaloUtility setfolderaccess account-name folder-name");
					break;
					}

				string acctName = args[1];
				string dirName = args[2];
				string logFile = args.Length > 3 ? args[3] : null;

				try
					{
					//var dirSecurity = Directory.GetAccessControl(dirName, AccessControlSections.Access);
					var dirSecurity = new DirectorySecurity();
					var rule = new FileSystemAccessRule(acctName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
					dirSecurity.SetAccessRule(rule);
					rule = new FileSystemAccessRule("BUILTIN\\Administrators", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
					dirSecurity.SetAccessRule(rule);
					rule = new FileSystemAccessRule("CREATOR OWNER", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
					dirSecurity.SetAccessRule(rule);
					rule = new FileSystemAccessRule("NT AUTHORITY\\SYSTEM", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
					dirSecurity.SetAccessRule(rule);
					dirSecurity.SetAccessRuleProtection(true, false);
					Directory.SetAccessControl(dirName, dirSecurity);

					#if NOTUSED
					AuthorizationRuleCollection rules = dirSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
					bool FoundAcct = false;

					foreach (AccessRule R in rules)
						{
						var FR = R as FileSystemAccessRule;
						if (FR == null) continue;
						string name = FR.IdentityReference.Value;
						if (name.StartsWith("BUILTIN\\"))
							name = name.Substring(8);
						if (name.Equals(acctName, StringComparison.OrdinalIgnoreCase))
							{
							FoundAcct = true;
							if (FR.FileSystemRights != FileSystemRights.FullControl || FR.InheritanceFlags != (InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit))
								{
								var newSecurity = Directory.GetAccessControl(dirName, AccessControlSections.Group);
								var rule = new FileSystemAccessRule(acctName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
								newSecurity.SetAccessRule(rule);
								newSecurity.SetAccessRuleProtection(true, false);
								Directory.SetAccessControl(dirName, newSecurity);
								}
							}
						}
					if (!FoundAcct)
						{
						//DirectorySecurity newSecurity = new DirectorySecurity(dirName, AccessControlSections.Group);
						var rule = new FileSystemAccessRule(acctName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
						dirSecurity.SetAccessRule(rule);
						dirSecurity.SetAccessRuleProtection(true, false);
						Directory.SetAccessControl(dirName, dirSecurity);
						}
					#endif
					}
				catch (Exception Ex)
					{
					Console.WriteLine(Ex.Message);
					#if DEBUG
					Console.WriteLine("Press Enter to continue ...");
					Console.ReadLine();
					#endif
					if (!string.IsNullOrEmpty(logFile))
						{
						using (StreamWriter wrt = new StreamWriter(logFile))
							{
							wrt.WriteLine(Ex.Message);
							}
						}
					break;
					}

				RC = 0;
				break;
				}


			/*---------------------------------------------------*/
			/*	Sets environment variable values in a data file  */
			/*---------------------------------------------------*/
			//
			//	Function:
			//
			//		Scans a text file for %variable% and replaces with the value of the
			//		named environment variable.
			//
			//	Syntax:
			//		setenvfile filename logfile
			//
			//	Note:
			//		If "logfile" is present, any errors are written there
			//
			case "setenvfile":
				{
				if (args.Length < 2)
					{
					Console.WriteLine("Too few arguments for setenvfile function.");
					Console.WriteLine("Usage: PaloUtility setenvfile filename");
					break;
					}

				//Console.WriteLine("PaloUtility setenvfile {0}", args[1]);
				//Console.ReadLine();

				string inFile = args[1];
				string logFile = args.Length > 2 ? args[2] : null;
				try
					{
					string[] Lines = File.ReadAllLines(inFile);
					StringBuilder bld = new System.Text.StringBuilder();
					int updcnt = 0;
					for (int i=0; i<Lines.Length; i++)
						{
						int at=0;
						while (at<Lines[i].Length && (at=Lines[i].IndexOf('%', at)) >= 0)
							{
							int end = Lines[i].IndexOf('%', at+1);
							string var = Lines[i].Substring(at+1,end-at-1);
							string val = System.Environment.GetEnvironmentVariable(var);
							if (string.IsNullOrEmpty(val))
								{
								at = end+1;
								#if DEBUG
								Console.WriteLine("Missing variable {0}. Press Enter to continue ...", var);
								Console.ReadLine();
								#endif
								continue;
								}
							bld.Length = 0;
							bld.Append(Lines[i].Substring(0,at));
							bld.Append(val);
							bld.Append(Lines[i].Substring(++end));
							Lines[i] = bld.ToString();
							updcnt++;
							at += val.Length;
							}
						}
					if (updcnt > 0) File.WriteAllLines(inFile, Lines);
					}
				catch (Exception Ex)
					{
					Console.WriteLine(Ex.Message);
					#if DEBUG
					Console.WriteLine("Press Enter to continue ...");
					Console.ReadLine();
					#endif
					if (!string.IsNullOrEmpty(logFile))
						{
						using (StreamWriter wrt = new StreamWriter(logFile))
							{
							wrt.WriteLine(Ex.Message);
							}
						}
					break;
					}

				RC = 0;
				break;
				}
			}

		return RC;
		}

	/// <summary>
	/// Locates a windows application path
	/// </summary>
	/// <remarks>
	/// Registry keys for executables are in HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\
	/// </remarks>
	/// <param name="FileName">The file name (e.g. "excel.exe")</param>
	/// <returns></returns>
	public static string FindWindowsApp(string FileName)
		{

		const string sRegKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\";
		DWSupport.Registry64BitKey Key = DWSupport.Registry64BitKey.LocalMachine.OpenSubKey(sRegKey + FileName);
		if (Key == null) return null;
		string PathName = Key.GetValue("Path");
		Key.Close();
		return PathName;
		}
	}
}
