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
using System.Drawing;
using System.Windows.Forms;

namespace Jedox.Windows.Forms.CustomControls
{
	/// <summary>
	/// A Message Loop filter which detect mouse events whilst the popup form is shown
	/// and notifies the owning <see cref="PopupWindowHelper"/> class when a mouse
	/// click outside the popup occurs.
	/// 
	/// Thousand thanks to Steve McMahon:
	/// http://www.vbaccelerator.com/home/NET/Code/Controls/Popup_Windows/Popup_Windows/Popup_Form_Demonstration.asp
	/// </summary>
	internal class DropDownMessageFilter : IMessageFilter
	{
	#region Private Constants
		private const int WM_LBUTTONDOWN	= 0x201;
		private const int WM_RBUTTONDOWN	= 0x204;
		private const int WM_MBUTTONDOWN	= 0x207;
		private const int WM_NCLBUTTONDOWN	= 0x0A1;
		private const int WM_NCRBUTTONDOWN	= 0x0A4;
		private const int WM_NCMBUTTONDOWN	= 0x0A7;
	#endregion
	#region Private Variable Declarations
		private Form					_dropDown	= null;
		private DropDownWindowHelper	_owner		= null;
	#endregion
	#region Event Declarations
		public event DropDownCancelEventHandler DropDownCancel;
	#endregion
	#region Constructor / Destructor
		/// <summary>
		/// Constructs a new instance of this class and sets the owning
		/// object.
		/// </summary>
		/// <param name="Owner">The <see cref="DropDownWindowHelper"/> object
		/// which owns this class.</param>
		public DropDownMessageFilter(DropDownWindowHelper Owner)
		{
			_owner = Owner;
		}
	#endregion
	#region Public Properties
		/// <summary>
		/// Gets/sets the dropdown form which is being displayed.
		/// </summary>
		public Form DropDown
		{
			get { return _dropDown; }
			set { _dropDown = value; }
		}
	#endregion
	#region Private Methods
		private void OnMouseDown()
		{
			Point cursorPos = Cursor.Position;											// Get the cursor location

			if (!_dropDown.Bounds.Contains(cursorPos))									// Check if it is within the popup form
			{
				OnDropDownCancel(new DropDownCancelEventArgs(_dropDown, cursorPos));	// If not, then call to see if it should be closed
			}
		}
	#endregion
	#region DropDownCancelEvent Implementation
		protected virtual void OnDropDownCancel(DropDownCancelEventArgs e)
		{
			if (this.DropDownCancel != null)
			{
				this.DropDownCancel(this, e);
			}

			if (!e.Cancel)
			{
				_owner.CloseDropDown();
				_dropDown = null;					// Clear reference for GC
			}
		}
	#endregion
	#region IMessageFilter Implementation
		/// <summary>
		/// Checks the message loop for mouse messages whilst the popup
		/// window is displayed.  If one is detected the position is
		/// checked to see if it is outside the form, and the owner
		/// is notified if so.
		/// </summary>
		/// <param name="m">Windows Message about to be processed by the
		/// message loop</param>
		/// <returns><c>true</c> to filter the message, <c>false</c> otherwise.
		/// This implementation always returns <c>false</c>.</returns>
		public bool PreFilterMessage(ref Message m)
		{
			if (_dropDown != null)
			{
				switch (m.Msg)
				{
					case WM_LBUTTONDOWN:
					case WM_RBUTTONDOWN:
					case WM_MBUTTONDOWN:
					case WM_NCLBUTTONDOWN:
					case WM_NCRBUTTONDOWN:
					case WM_NCMBUTTONDOWN:	OnMouseDown();	break;
				}
			}

			return false;
		}
	#endregion
	}
}
