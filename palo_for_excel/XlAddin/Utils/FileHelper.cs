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

using System.IO;

namespace Apalo.XlAddin.Utils
{
    public class FileHelper
    {
        /// <summary>
        /// Extract the directory from a filename
        /// </summary>
        /// <param name="fname">filename</param>
        /// <returns>directory</returns>
        public static string getdirname(string fname)
        {
            string dirname = "";
            int pos = fname.LastIndexOf("\\");
            if (pos > -1)
            {
                dirname = fname.Substring(0, pos);
            }
            return dirname;
        }

        public static string getfilename(string fname)
        {
            string filename = fname;
            int pos = filename.LastIndexOf("\\");
            if (pos > -1)
            {
                filename = filename.Substring(pos + 1);
            }

            return filename;
        }


        public static string getbasename(string fname)
        {
            string basename = getfilename(fname);
            int pos = basename.LastIndexOf(".");
            if (pos > -1)
            {
                basename = basename.Substring(0, pos);
            }
            return basename;
        }

        public static void checkdir(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
