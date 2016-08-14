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
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Apalo.XlAddin.Utils
{
	[ComVisible(false)]
	public sealed class ErrorHandler
	{
		//private static string LOG_FILE = Apalo.XlAddin.Connect.ApplicationPath + "PaloDesigner.log";// = System.Environment.GetFolderPath((System.Environment.SpecialFolder)0x0026) + "\\Jedox\\Palo\\PaloDesigner.log";

        private static string LOGFILENAME = "PaloXlAddin.log";
        private static string LOGFILEPATH = RegUtils.GetStringValue(GeneralConst.LOG_FILE_PATH);
        private static string LOG_FILE = LOGFILEPATH + Path.DirectorySeparatorChar + LOGFILENAME;

        private ErrorHandler()
		{
		}

        public static void WriteToLog(string msg)
        {
            try
            {
                if (string.IsNullOrEmpty(LOGFILEPATH))
                    {
                    LOGFILEPATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string TryLogPath = Path.Combine(Path.GetDirectoryName(LOGFILEPATH),"Logs");
                    if (Directory.Exists(TryLogPath))
                        LOGFILEPATH = TryLogPath;
                    LOG_FILE = Path.Combine(LOGFILEPATH, LOGFILENAME);
                    }

                using (StreamWriter sw = File.AppendText(LOG_FILE))
                {
                    sw.WriteLine(DateTime.Now.ToString("f"));
                    sw.WriteLine(msg);
                    sw.WriteLine("------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                ErrorPopup("Error writing " + LOGFILENAME + " :\n" + ex.Message + " : \n\n" + msg, MessageBoxIcon.Error);
            }
        }

        private static void ProcessError(string msgBoxTitle, string msgText, Exception exceptionMessage, bool dopopup)
        {
            string msg = msgText;
            if (exceptionMessage != null)
                msg += "\r\n\nException Data:\r\n" + exceptionMessage.ToString();
            if (dopopup)
            {
                MessageBox.Show(msg, msgBoxTitle);
            }
            WriteToLog(msg);
        }

        public static void ProcessError(string msgText, Exception exceptionMessage)
        {
            ProcessError("Error", msgText, exceptionMessage, false);
        }

        public static void DisplayError(string msgBoxTitle, string msgText, Exception exceptionMessage)
		{
            bool dopopup = false;
#if DEBUG
            dopopup = true;
#endif
            ProcessError(msgBoxTitle, msgText, exceptionMessage, dopopup);
        }

		public static void DisplayError(string msgText, Exception exceptionMessage)
		{
			DisplayError("Error", msgText, exceptionMessage);
		}

        public static void ErrorPopup(string errmsg, MessageBoxIcon type)
        {
            MessageBox.Show(errmsg, ResourceInitializer.XLL_ERROR_TITLE, MessageBoxButtons.OK, type, MessageBoxDefaultButton.Button1);
        }

        public static void ErrorPopup(string errmsg)
        {
            ErrorPopup(errmsg, MessageBoxIcon.Exclamation);
        }

        public static void HandleErrorElement(Jedox.Palo.Comm.PaloException pe, string displayerror)
        {
            string errmsg = "";
            switch (pe.ErrorCode)
            {
                case -50:
                case 4000:
                    errmsg = ResourceInitializer.ERROR_ELEMENT_EXISTS;
                    break;

                case -71:
                case 4006:
                    errmsg = ResourceInitializer.ERROR_ELEMENT_NAME_INVALID;
                    break;

                default:
                    errmsg = pe.Message;
                    ErrorHandler.DisplayError(displayerror, pe);
                    break;

            }
            ErrorHandler.ErrorPopup(errmsg);
        }

        public static void HandleErrorElementRename(Jedox.Palo.Comm.PaloException pe)
        {
            HandleErrorElement(pe, "Error Renaming element!");
        }

        public static void WriteDebugLog(string msg)
        {
            if (RegUtils.DebugMode)
            {
                WriteToLog(msg);
            }
        }

	}
}
