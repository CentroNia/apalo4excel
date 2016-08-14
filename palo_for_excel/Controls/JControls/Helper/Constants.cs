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
////////////////////////////////////////////////////////////////////////////////
/// @brief  Predefined constants
///
/// @file   Constants.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

namespace JControls
{
    public class Constants
    {
        public static string DQUOTE = "\"";
        public static string SQUOTE = "\'";

        public static string nullStr = "";
        public static string tooComplex = "<TooComplex>";
        public static string error = "<Error>";
        public static string strParen = "(...)";
        public static string strBrack = "[...]";
        public static string strMarker = "[[...]]";
        public static string strNot = "!";
        public static string strMinus = "-";
        public static string strAt = "@";


        public static string[] strPrs = new string[] {"", "B:", "C:"};
        public static string strNone = "None";
        public static string strNColon = "B:";
        public static string strCColon = "C:";

        public static int MAX_ENTITIES = 500;

        public static CPriority PriorityFromString(string s)
        {
            int ii = 0;
            foreach (string ss in strPrs)
            {
                if (ss == s) return (CPriority)ii;
                ii++;
            }
            return 0;
        }
        public static string StringFromPriority(CPriority cp)
        {
            return strPrs[(int)cp];
        }
    }
    public enum CPriority { None = 0, CColon = 1, NColon = 2  }
}
