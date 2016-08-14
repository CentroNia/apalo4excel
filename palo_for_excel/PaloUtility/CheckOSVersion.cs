using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace DWSupport
{
/// <summary>
/// Ths class provides checks for the OS version currently running. 
/// </summary>
public class CheckOSVersion
    {
    [DllImport("kernel32.dll")]
    static extern IntPtr GetCurrentProcess();

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr GetModuleHandle(string moduleName);

    [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
    static extern IntPtr GetProcAddress(IntPtr hModule,
        [MarshalAs(UnmanagedType.LPStr)]string procName);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

    [DllImport("kernel32.dll")]
    static extern bool GetBinaryType(string lpApplicationName, out BinaryType lpBinaryType);

    private enum BinaryType : uint
        {
        SCS_32BIT_BINARY = 0, // A 32-bit Windows-based application
        SCS_64BIT_BINARY = 6, // A 64-bit Windows-based application.
        SCS_DOS_BINARY = 1, // An MS-DOS – based application
        SCS_OS216_BINARY = 5, // A 16-bit OS/2-based application
        SCS_PIF_BINARY = 3, // A PIF file that executes an MS-DOS – based application
        SCS_POSIX_BINARY = 4, // A POSIX – based application
        SCS_WOW_BINARY = 2 // A 16-bit Windows-based application
        }    

    private enum MachineType {Native = 0, I386 = 0x014c, Itanium = 0x0200, x64 = 0x8664}

    /// <summary>
    /// The function determines whether the current operating system is a 
    /// 64-bit operating system.
    /// </summary>
    /// <returns>
    /// The function returns true if the operating system is 64-bit; 
    /// otherwise, it returns false.
    /// </returns>
    public static bool Is64BitOperatingSystem()
        {
        if (IntPtr.Size == 8)  // 64-bit programs run only on Win64
            {
            return true;
            }
        else  // 32-bit programs run on both 32-bit and 64-bit Windows
            {
            // Detect whether the current process is a 32-bit process 
            // running on a 64-bit system.
            bool flag;
            try
                {
                return ((DoesWin32MethodExist("kernel32.dll", "IsWow64Process") &&
                        IsWow64Process(GetCurrentProcess(), out flag)) && flag);
                }
            catch (Exception)
                {
                return false;
                }
            }
        }

    /// <summary>
    /// Determines if an application is a 64-bit executable
    /// </summary>
    /// <remarks>
    /// Registry keys for executables are in HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\
    /// </remarks>
    /// <param name="FileName">The file name or registry subkey</param>
    /// <param name="UseRegKey"></param>
    /// <returns></returns>
    public static bool Is64BitApplication(string FileName, bool UseRegKey)
        {
        if (!Is64BitOperatingSystem()) return false;
        const string sRegKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\";
        if (UseRegKey)
            {
            Registry64BitKey Key = Registry64BitKey.LocalMachine.OpenSubKey(sRegKey + FileName);
            if (Key == null) return false;                 
            FileName = Key.GetValue("");                
            }

        #if NOTUSED
        //  Note: GetBinaryType does not work reliably
        BinaryType FT;
        if (System.IO.File.Exists(FileName) && GetBinaryType(FileName, out FT) && FT == BinaryType.SCS_64BIT_BINARY)
            return true;
        #endif

        if (System.IO.File.Exists(FileName) && GetMachineType(FileName) == MachineType.x64)
            return true;

        return false;
        }

    /// <summary>
    /// The function determines whether a method exists in the export 
    /// table of a certain module.
    /// </summary>
    /// <param name="moduleName">The name of the module</param>
    /// <param name="methodName">The name of the method</param>
    /// <returns>
    /// The function returns true if the method specified by methodName 
    /// exists in the export table of the module specified by moduleName.
    /// </returns>
    static bool DoesWin32MethodExist(string moduleName, string methodName)
        {
        IntPtr moduleHandle = GetModuleHandle(moduleName);
        if (moduleHandle == IntPtr.Zero)
            {
            return false;
            }
        return (GetProcAddress(moduleHandle, methodName) != IntPtr.Zero);
        }
    
    /// <summary>
    /// Determines the machine type of an executable file
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private static MachineType GetMachineType(string fileName)
        {
        const int PE_POINTER_OFFSET = 60;            
        const int MACHINE_OFFSET = 4;
        byte[] data = new byte[4096];
        using (System.IO.Stream s = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)) 
            {
            s.Read(data, 0, 4096);
            }
        // dos header is 64 bytes, last element, long (4 bytes) is the address of the PE header
        int PE_HEADER_ADDR = BitConverter.ToInt32(data, PE_POINTER_OFFSET);
        int machineUint = BitConverter.ToUInt16(data, PE_HEADER_ADDR + MACHINE_OFFSET);
        return (MachineType)machineUint;
        }
    }
}
