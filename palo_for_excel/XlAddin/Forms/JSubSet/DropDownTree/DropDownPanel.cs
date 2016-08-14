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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Jedox.Windows.Forms.CustomControls
{
	/// <summary>
	/// Control that allows any other control that implements IDropDownAware to be displayed
	/// in it's own combo-like dropdown area. This Control tries to mimic the standard ComboBox
	/// as accurately as possible.
	/// </summary>
	public partial class DropDownPanel : UserControl, IDropDownAware
	{
	#region Private Variable Declarations
		private IDropDownAware			_dropDownControl	= null;
		private DropDownWindowHelper	_dropDownHelper		= null;
		private Form					_owner				= null;        
	#endregion
	#region Constructor / Destructor
		/// <summary>
		/// Default constructor
		/// </summary>
		public DropDownPanel()
		{
			InitializeComponent();

			_dropDownHelper = new DropDownWindowHelper();

			_dropDownHelper.DropDownClosed += new DropDownClosedEventHandler(DropDownHelper_DropDownClosed);
			_dropDownHelper.DropDownCancel += new DropDownCancelEventHandler(DropDownHelper_DropDownCancel);
			
			combo.DisplayMember = "Text";
			combo.ValueMember = "Id";
		}
       
	#endregion
	#region Control Events
		/// <summary>
		/// The owning form is set within this event, wich is required to
		/// force the owning form not to loose focus when the dropdown is
		/// being displayed. Inherited controls should provide the PopupControl
		/// within an overridden implementation of this event.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleCreated(EventArgs e)
		{	
			_owner = this.FindForm();
			_dropDownHelper.ReleaseHandle();
			
			if (_owner != null)
			{
				_dropDownHelper.AssignHandle(_owner.Handle);
			}
		}

		/// <summary>
		/// Make sure that the overall control's height is exactly the height
		/// of the internal ComboBox and that the ComboBox's widt is exactly the 
		/// width of the control.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			
			combo.Location = new Point(0, 0);
			combo.Width = this.ClientRectangle.Width;
			this.Height = combo.Height;
		}
	#endregion
	#region Event Handler
		/// <summary>
		/// We make our DropDownForm host the choosen control and show it instead
		/// of the dropdown portion of the ComboBox. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Combo_DropDown(object sender, EventArgs e)
		{
			if (!_dropDownHelper.DropDownShowing)
			{
				DropDownForm dropDown = new DropDownForm(_dropDownControl);

                //dropDown.FinishEditing += new DropDownValueChangedEventHandler(DropDown_FinishEditing);
                //dropDown.ValueChanged += new DropDownValueChangedEventHandler(DropDown_ValueChanged);
				
				combo.DroppedDown = false;
				_dropDownHelper.ShowDropDown(_owner, dropDown, GetDropDownPosition(dropDown), combo.Width);
			}
			else
			{
				_dropDownHelper.CloseDropDown();
				this.Focus();
			}
		}
		
		private void DropDownHelper_DropDownClosed(object sender, DropDownClosedEventArgs e)
		{
			IDropDownAware dropDown = (e.DropDown as IDropDownAware);
			
			if ((dropDown != null) && (dropDown.Value != null))
			{
                //dropDown.FinishEditing -= new DropDownValueChangedEventHandler(DropDown_FinishEditing);
                //dropDown.ValueChanged -= new DropDownValueChangedEventHandler(DropDown_ValueChanged);
			}
			
			combo.DroppedDown = false;
		}

		private void DropDownHelper_DropDownCancel(object sender, DropDownCancelEventArgs e)
		{
			if (this.Bounds.Contains(Parent.PointToClient(e.CursorLocation)))
			{
				e.Cancel = true;
			}
			else
			{
				IDropDownAware dropDown = (e.DropDown as IDropDownAware);
				
				if (dropDown != null)
				{
                    //dropDown.FinishEditing -= new DropDownValueChangedEventHandler(DropDown_FinishEditing);
                    //dropDown.ValueChanged -= new DropDownValueChangedEventHandler(DropDown_ValueChanged);
				}
			}
		}

        protected void DropDown_FinishEditing(object sender, DropDownValueChangedEventArgs e)
		{	
			if (e.Value != null)
			{
				SetValue(e.Value, true);
			}
			
			if (this.FinishEditing != null)
			{
				this.FinishEditing(this, e);
			}
			
            //_dropDownControl.FinishEditing -= new DropDownValueChangedEventHandler(DropDown_FinishEditing);
            //_dropDownControl.ValueChanged -= new DropDownValueChangedEventHandler(DropDown_ValueChanged);
			_dropDownHelper.CloseDropDown();
		}
		
		protected void DropDown_ValueChanged(object sender, DropDownValueChangedEventArgs e)
		{
            if (e.Value != null)
            {
                SetValue(e.Value, false);
            }

			if (this.ValueChanged != null)
			{
				this.ValueChanged(this, e);                
			}           
		}
	#endregion
	#region Public Properties
		/// <summary>
		/// Get or set the control (has to implement IDropDownAware) that is to 
		/// be displayed as the dropdown portion of the combobox. 
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IDropDownAware DropDownControl
		{
			get { return _dropDownControl; }
			set 
			{ 
				_dropDownControl = value; 
				
				this.Controls.Add(_dropDownControl as Control);
			}
		}
        
	#endregion
	#region Public Methods
		public override string ToString()
		{
			return this.Name;
		}
	#endregion
	#region Private Methods
		/// <summary>
		/// Calculate an acceptable position of the DropDownForm even in a 
		/// multi screen environment.
		/// </summary>
		/// <param name="DropDown"></param>
		/// <returns></returns>
		private Point GetDropDownPosition(DropDownForm DropDown)
		{
			Point		lt		= Parent.PointToScreen(new Point(Left, Top));
			Point		rb		= Parent.PointToScreen(new Point(Right, Bottom));
			Rectangle	screen	= Screen.FromControl(this).Bounds;
			Point		point	= new Point();
			
			if (((lt.X + DropDown.Width) > (screen.X + screen.Width)) && ((rb.X - DropDown.Width) >= screen.X))
			{
				point.X = rb.X - DropDown.Width; 
				
				if ((point.X + DropDown.Width) > (screen.X + screen.Width))
				{
					point.X = ((screen.X + screen.Width) - DropDown.Width); 
				}
			}
			else
			{
				point.X = lt.X;
				
				if (point.X < screen.X)
				{
					point.X = screen.X;
				}
			}
			
			if (((rb.Y + DropDown.Height) > (screen.Y + screen.Height)) && ((lt.Y - DropDown.Height) >= screen.Y))
			{
				point.Y = lt.Y - DropDown.Height;
				
				if (point.Y < screen.Y)
				{
					point.Y = screen.Y;
				}
			}
			else
			{
				point.Y = rb.Y;
				
				if ((point.Y + DropDown.Height) > (screen.Y + screen.Height))
				{
					point.Y = ((screen.Y + screen.Height) - DropDown.Height);
				}
			}
			
			return point;
		}
		
		/// <summary>
		/// In this implementation we don't the user to edit the ComboBox
		/// directly, so we add the new value to the item collection after
		/// clearing it first.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Value"></param>
        //private void SetValue<T>(ILookupItem<T> Value) where T: struct
        //{
        //    if (DropDownControl != null)
        //    {
        //        ILookupItem<T>[] arr = new ILookupItem<T>[0];
				
        //        combo.DataSource = arr;
				
        //        if ((Value != null) && (Value is ILookupItem<long>))
        //        {
        //            DropDownControl.Value = Value;
					
        //            arr = new ILookupItem<T>[1]{(ILookupItem<T>) Value};
        //            combo.DataSource = arr;
        //            combo.SelectedIndex = 0;
        //            combo.Focus();
        //        }
        //        else
        //        {
        //            DropDownControl.Value = null;
        //        }
        //    }
        //}
        protected void SetValue(object Value, bool Focus) 
        {
            if (DropDownControl != null)
            {
                object arr = new object[0];

                combo.DataSource = arr;

                if ((Value != null))
                {
                    TreeNode tn = Value as TreeNode;
                    
                    DropDownControl.Value = Value;

                    arr = new object[1] { tn!=null ? tn.Text : Value };
                    combo.DataSource = arr;
                    combo.SelectedIndex = 0;
                    if (Focus)
                        combo.Focus();
                }
                else
                {
                    DropDownControl.Value = null;
                    combo.SelectedIndex = -1;
                }
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
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object Value
		{
			get { return _dropDownControl.Value; }
			set { SetValue(value, false); }
		}
	#endregion
	}
}
