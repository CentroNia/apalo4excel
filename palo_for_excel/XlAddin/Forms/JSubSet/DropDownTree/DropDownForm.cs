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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Jedox.Windows.Forms.CustomControls
{
	/// <summary>
	/// The form that pops up instead of the dropdown portion of the 
	/// DropDownPanel's combobox. It containes the actual control to
	/// display.
	/// </summary>
	internal partial class DropDownForm : Form, IDropDownAware
	{ 
	#region Private Variable Declaration
		private IDropDownAware _control = null;
	#endregion
	#region Constructor / Destructor
		/// <summary>
		/// Default Constructor
		/// </summary>
		public DropDownForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Constructor to initialize the for with the control to display.
		/// </summary>
		/// <param name="Ctrl">The control to display.</param>
		public DropDownForm(IDropDownAware Ctrl) : this()
		{	
			if (Ctrl != null)
			{
				_control = Ctrl;
				
				InitializeControl(_control as Control);
			}
		}
	#endregion
	#region Form Events
		protected override void OnClosing(CancelEventArgs e)
		{
			this.Controls.Remove(_control as Control);
			base.OnClosing(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
            //_control.FinishEditing += new DropDownValueChangedEventHandler(Ctrl_FinishEditing);
            //_control.ValueChanged += new DropDownValueChangedEventHandler(Ctrl_ValueChanged);
		}
	#endregion
	#region Event Handler
	    private void Ctrl_FinishEditing(object sender, DropDownValueChangedEventArgs e)
	    {
			if (this.FinishEditing != null)
			{
				this.FinishEditing(this, e);
			}

        //    _control.FinishEditing -= new DropDownValueChangedEventHandler(Ctrl_FinishEditing);
        //    _control.ValueChanged -= new DropDownValueChangedEventHandler(Ctrl_ValueChanged);
        }
	    
	    private void Ctrl_ValueChanged(object sender, DropDownValueChangedEventArgs e)
	    {
			if (this.ValueChanged != null)
			{
				this.ValueChanged(this, e);
			}
	    }
	#endregion
	#region IDropDownAware Implementation
		/// <summary>
		/// Fired either on OK, Cancel or a click outside the control to indicate
		/// that the user has finished editing.
		/// </summary>
		public event DropDownValueChangedEventHandler FinishEditing;
		
		/// <summary>
		/// Fired on any change of the controls's value during the editing process. 
		/// </summary>
		public event DropDownValueChangedEventHandler ValueChanged;
		
		/// <summary>
		/// Gets or sets the controls' value.
		/// </summary>
		public object Value
		{
			get { return _control.Value; }
			set { _control.Value = value; }
		}
	#endregion
	#region Private Methods
		private void InitializeControl(Control Ctrl)
		{
			Size	size	= Ctrl.Size;
			Size	inner	= this.ClientRectangle.Size;
			Size	outer	= this.Size;
			int		gap		= outer.Width - inner.Width;
			
			size.Width += gap;
			size.Height += gap;
			
			this.Size = size;
			this.Controls.Add(Ctrl);
			Ctrl.Location = new Point(0, 0);
			Ctrl.Visible = true;
			Ctrl.Invalidate();
		}
	#endregion
	}
}
