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
using System.Runtime.InteropServices;

namespace Jedox.Windows.Forms.CustomControls
{
	public static class UIApiCalls
	{
	#region Public Constants
		public const int WM_ACTIVATE		= 0x006;
		public const int WM_ACTIVATEAPP		= 0x01C;
		public const int WM_NCACTIVATE		= 0x086;
		public const int KEYEVENTF_KEYUP	= 0x0002;
	#endregion
	#region Public Static API Calls
		[DllImport("user32", CharSet = CharSet.Auto)]
		public extern static int SendMessage(IntPtr handle, int msg, int wParam, IntPtr lParam);

		[DllImport("user32", CharSet = CharSet.Auto)]
		public extern static int PostMessage(IntPtr handle, int msg, int wParam, IntPtr lParam);

		[DllImport("user32")]
		public extern static void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
	#endregion
	}
}
