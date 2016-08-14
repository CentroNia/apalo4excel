/*
 *	DWSupport.Registry64BitKey class - Manage 64-bit registry in a 32-bit application.
 *
 *  (c) 2013 Junction BI LLC
 *
 *	Revision History -
 *
 *	09/30/13 JMM Initial Version
*/
using System;
using System.Runtime.InteropServices;
using System.Text;
using RegistryValueKind=Microsoft.Win32.RegistryValueKind;

namespace DWSupport
{
/// <summary>
/// Allows reading from the 64-bit registry in a 32-bit application.
/// </summary>
/// <remarks>
/// This class is structured similar to the Microsoft.Win32.RegistryKey class. One difference is that the hive
/// root keys are static members of this class.
/// </remarks>
public class Registry64BitKey
	{
	private UIntPtr _handle;
	private uint _hKey {get {return _handle.ToUInt32();}}
	private static UIntPtr HKEY_LOCAL_MACHINE = new UIntPtr(0x80000002u);
	private static UIntPtr HKEY_CURRENT_USER = new UIntPtr(0x80000001u);

	/// <summary>The Local Machine hive key.</summary>
	public static Registry64BitKey LocalMachine
		{get {return new Registry64BitKey(HKEY_LOCAL_MACHINE);}}

	/// <summary>The Current User hive key.</summary>
	public static Registry64BitKey CurrentUser
		{get {return new Registry64BitKey(HKEY_CURRENT_USER);}}

	/// <summary>
	/// Constructor, private
	/// </summary>
	/// <param name="hKey"></param>
	private Registry64BitKey(UIntPtr hKey)
		{
		_handle = hKey;
		}

	/// <summary>
	/// Open a subkey
	/// </summary>
	/// <param name="SubKeyName"></param>
	/// <param name="ForUpdate"></param>
	/// <returns></returns>
	public Registry64BitKey OpenSubKey(string SubKeyName, bool ForUpdate=false)
		{
		uint hkey;
		uint lResult = RegOpenKeyEx(_handle, SubKeyName, 0, (int)RegSAM.QueryValue | (int)RegSAM.EnumerateSubKeys | (ForUpdate ?  (int)RegSAM.Write : 0) | (int)RegSAM.WOW64_64Key, out hkey);
		if (lResult != 0)
			return null;
		return new Registry64BitKey(new UIntPtr(hkey));
		}

	/// <summary>
	/// Close a key
	/// </summary>
	public void Close()
		{
		if (_handle.ToUInt32() != 0)
			RegCloseKey(_handle.ToUInt32());
		}

	/// <summary>
	/// Enumerate subkeys of a key
	/// </summary>
	/// <param name="Index"></param>
	/// <returns></returns>
	public string GetNextSubKey(uint Index)
		{
		uint cbName = 255;
		var KeyName = new StringBuilder((int)cbName+1);
		IntPtr reserved = IntPtr.Zero;
		IntPtr lpClass = IntPtr.Zero, lpcbClass = IntPtr.Zero;
		long lpftLastWriteTime;
		if (RegEnumKeyEx(_handle, Index, KeyName, ref cbName, reserved, lpClass, lpcbClass, out lpftLastWriteTime) != 0)
			return null;
		return KeyName.ToString().Trim();
		}

	/// <summary>
	/// Read a string value
	/// </summary>
	/// <param name="ValueName"></param>
	/// <returns></returns>
	public string GetValue(string ValueName)
		{
		uint lpType = 0;
		uint lpcbData = 1024;
		StringBuilder AgeBuffer = new StringBuilder(1024);
		RegQueryValueExStr(_hKey, ValueName, 0, ref lpType, AgeBuffer, ref lpcbData);
		string Age = AgeBuffer.ToString();
		return Age;
		}

	/// <summary>
	/// Read a DWORD value
	/// </summary>
	/// <param name="ValueName"></param>
	/// <returns></returns>
	public Int32 GetDWValue(string ValueName)
		{
		object DW = getNamedValue(ValueName);
		return (DW is Int32) ? (Int32)DW : 0;
		}

	private object getNamedValue(string ValueName)
		{
		UIntPtr hKey = UIntPtr.Zero;
		IntPtr pResult = IntPtr.Zero;

		int size = 0;
		RegistryValueKind type = RegistryValueKind.Unknown;

		// Get the size of buffer we will need
		uint retVal = RegQueryValueEx(_hKey, ValueName, 0, ref type, IntPtr.Zero, ref size);
		if (size == 0) return null;
		pResult = Marshal.AllocHGlobal(size);

		try
			{
			retVal = RegQueryValueEx(_hKey, ValueName, 0, ref type, pResult, ref size);
			if (retVal != 0)
				{
				//Logger.WriteLog("Error querying value '{0}\\{1}: 0x{2:x}, return code: {3}", registryPath, valName, Marshal.GetLastWin32Error(), retVal);
				}
			else
				{
				switch (type)
					{
					case RegistryValueKind.String:
						return Marshal.PtrToStringAnsi(pResult);
					case RegistryValueKind.DWord:
						return Marshal.ReadInt32(pResult);
					case RegistryValueKind.QWord:
						return Marshal.ReadInt64(pResult);
					}
				}
			}
		catch (Exception)
			{
			throw;
			}
		finally
			{
			if (pResult != IntPtr.Zero)
				Marshal.FreeHGlobal(pResult);
			}

		return null;
		}

	/// <summary>
	/// Check whether a value exists.
	/// </summary>
	/// <param name="valName"></param>
	/// <returns></returns>
	public bool HasValue(string valName)
		{
		return getNamedValue(valName) != null;
		}

	/// <summary>
	/// Sets a string value
	/// </summary>
	/// <param name="valName"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public bool SetValue(string valName, string value)
		{
		return setNamedValue(valName, value, RegistryValueKind.String);
		}

	/// <summary>
	/// Sets a DWORD value
	/// </summary>
	/// <param name="valName"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public bool SetDWValue(string valName, Int32 value)
		{
		return setNamedValue(valName, value, RegistryValueKind.DWord);
		}

	private bool setNamedValue(string valName, object value, RegistryValueKind type)
		{

		int size = 0;
		IntPtr pData = IntPtr.Zero;
		uint retVal = 1;
		try
				{
			switch (type)
				{
				case RegistryValueKind.String:
					size = ((string)value).Length+1;
					pData = Marshal.StringToHGlobalAnsi((string)value);
					break;
				case RegistryValueKind.DWord:
					size = Marshal.SizeOf(typeof(Int32));
					pData = Marshal.AllocHGlobal(size);
					Marshal.WriteInt32(pData, (int)value);
					break;
				case RegistryValueKind.QWord:
					size = Marshal.SizeOf(typeof(Int64));
					pData = Marshal.AllocHGlobal(size);
					Marshal.WriteInt64(pData, (long)value);
					break;
				}
					retVal = RegSetValueEx(_handle, valName, 0, type, pData, size);
				}
			catch (Exception)
				{
					throw;
				}
		finally
			{
			if (pData != IntPtr.Zero)
				Marshal.FreeHGlobal(pData);
			}
		return retVal == 0;
		}

	/// <summary>
	/// Windows registry definitions
	/// </summary>
	private enum RegSAM
		{
		QueryValue = 0x0001,
		SetValue = 0x0002,
		CreateSubKey = 0x0004,
		EnumerateSubKeys = 0x0008,
		Notify = 0x0010,
		CreateLink = 0x0020,
		WOW64_32Key = 0x0200,
		WOW64_64Key = 0x0100,
		WOW64_Res = 0x0300,
		Read = 0x00020019,
		Write = 0x00020006,
		Execute = 0x00020019,
		AllAccess = 0x000f003f
		}

	[DllImport("Advapi32.dll")]
	private static extern uint RegOpenKeyEx(UIntPtr hKey, string lpSubKey, uint ulOptions, int samDesired, out uint phkResult);

	[DllImport("Advapi32.dll")]
	private static extern uint RegCloseKey(uint hKey);

	//	Read a string value:
	[DllImport("advapi32.dll", EntryPoint = "RegQueryValueEx")]
	private static extern int RegQueryValueExStr(uint hKey, string lpValueName, int lpReserved, ref uint lpType, System.Text.StringBuilder lpData, ref uint lpcbData);

	// Alternate definition for any value:
	[DllImport("advapi32.dll", EntryPoint = "RegQueryValueEx", SetLastError = true)]
	private static extern uint RegQueryValueEx(uint hKey, string lpValueName, int lpReserved, ref RegistryValueKind lpType, IntPtr lpData, ref int lpcbData);

	[DllImport("advapi32.dll", SetLastError = true)]
	private static extern uint RegSetValueEx(UIntPtr hKey, string lpValueName, int Reserved, RegistryValueKind dwType, IntPtr lpData, int cbData);

	//	Enumerate subkeys:
	[DllImport("advapi32.dll", EntryPoint = "RegEnumKeyEx")]
	private static extern int RegEnumKeyEx(UIntPtr hkey, uint index, StringBuilder lpName, ref uint lpcbName, IntPtr reserved, IntPtr lpClass, IntPtr lpcbClass, out long lpftLastWriteTime);

	}
}
