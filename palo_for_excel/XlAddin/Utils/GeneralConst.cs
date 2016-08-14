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
using System.Runtime.InteropServices;

namespace Apalo.XlAddin.Utils
{
    // this class should hold all constants which are used in more than one file.

	[ComVisible(false)]
    public class GeneralConst
    {
        public const string VERSION = "3.2.A01";
        
        public const string WINDOWS_NEWLINE = "\r\n";
        public const string UNIX_NEWLINE = "\n";
        public const string MAC_NEWLINE = "\n\r";

        //  JMM 10-29-13
        public const string XlAddinFileName = "apalo.xladdin.dll";

        public const string LOG_FILE_PATH = "LogFilePath";

        public const byte NORMAL_CUBE_VIEW = 0;
        public const byte SYSTEM_CUBE_VIEW = 1;
        public const byte ATTRIBUTE_CUBE_VIEW = 2;

        public const byte FILTER_DATA = NORMAL_CUBE_VIEW;
        public const byte FILTER_ATTRIBUTE = ATTRIBUTE_CUBE_VIEW;
        public const byte FILTER_USER = SYSTEM_CUBE_VIEW;

        public const string SYSTEM_DB_NAME = "System";

        public const string PALO_DATA = "PALO.DATA";
        public const string PALO_DATAC = "PALO.DATAC";
        public const string PALO_DATAT = "PALO.DATAT";
        public const string PALO_DATATC = "PALO.DATATC";
        public const string PALO_DATAV = "PALO.DATAV";
        public const string PALO_DATAX = "PALO.DATAX";
        public const string PATH_DELIMTER = "\\";

        public const string PASTE_VIEW_IDENT = "_palopasteviewident";
        public const string PASTE_VIEW_ZEROSUPPRESSION = "_palopasteviewzerosuppression";
        public const string PASTE_VIEW_ZEROSUPPRESSIONALSOCALCULATEDNULL = "_palopasteviewzerosuppressionalsocalculatednull";
        public const string PASTE_VIEW_X_CALC = "__palo_x_calc";
        public const string PASTE_VIEW_COLWIDTH = "_palopasteviewcolwidth";
        public const string PASTE_VIEW_STYLE = "_palopasteviewstyle";
        public const string SUBSET_DIM = "#_SUBSET_";
        public const string GLOBAL_SUBSET_CUBE = "#_SUBSET_GLOBAL";
        public const string LOCAL_SUBSET_CUBE = "#_SUBSET_LOCAL";
        public const string ATTRIBUT_ALIAS = "ALIAS";
        public const string IMPORT_ACTIVE = "_paloimportactive";

        public const bool PASTE_VIEW_DEFAULT_WRAP_CHECKED = true;
        public const bool PASTE_VIEW_DEFAULT_FIXEDWIDTH_CHECKED = true;
        public const bool PASTE_VIEW_DEFAULT_SHOWSELECTOR_CHECKED = false;

        public const float PASTE_VIEW_DEFAULT_FIXEDWIDTH = 14;

        public const string MODELLER = "Modeller";

        public const string PREFIX_CELL_RIGHTS = "#_GROUP_CELL_DATA_";

        public const int SUBSET_LIMIT = 1000;


        public static bool isNewExcel()
        {
            return (ExcelHelper.oExcelApp != null) && (System.Double.Parse(ExcelHelper.oExcelApp.Version, new System.Globalization.CultureInfo("en-US").NumberFormat) > 11);
        }

        public static int getMaxColumn()
        {
            int MaxColumn = 256;

            if (isNewExcel())
            {
                MaxColumn = 16384; 
            }

            return MaxColumn;
        }

        public static int getMaxRow()
        {
            int MaxRow = 65536;

            if (isNewExcel())
            {
                MaxRow = 1048576;
            }

            return MaxRow;
        }

        public static string ExecutePath
        {
            get
            {
                string ep = System.Reflection.Assembly.GetExecutingAssembly().Location.ToLower(System.Globalization.CultureInfo.InvariantCulture);
                return ep.Substring(0, ep.IndexOf(XlAddinFileName));
            }
        }

        public static bool isClickToRun()
        {
            bool retval = false;
            try
            {
                retval = RegUtils.isClickToRun((ExcelHelper.oExcelApp == null) ? "14.0" : ExcelHelper.oExcelApp.Version);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.DisplayError("Error in isClickToRun", ex);
            }
            return retval;
        }

    }
}
