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
using System.Windows.Forms;
using JControls;

namespace Apalo.XlAddin.Forms.Controls
{
    partial class CubeComboBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
  
        [Description("The Items associated with the control"), Category("JControls")]
        public ComboBox.ObjectCollection Items
        {
            get { return this.cb.Items; }
            set { this.cb.Items.Add(value); }
        }

        [Description("The SelectedIndex associated with the control"), Category("JControls")]
        public int SelectedIndex
        {
            get { return this.cb.SelectedIndex; }
            set {
                if ((value > -1 && this.cb.Items.Count > 0) || (value == -1))
                {
                    this.cb.SelectedIndex = value;
                }
            
            }
        }

        [Description("The MaxLength associated with the control"), Category("JControls")]
        public int MaxLength
        {
            get { return this.cb.MaxLength; }
            set { this.cb.MaxLength = value; }
        }

        [Description("The DropDownStyle associated with the control"), Category("JControls")]
        public ComboBoxStyle DropDownStyle
        {
            get { return this.cb.DropDownStyle; }
            set { this.cb.DropDownStyle = value; }
        }

        [Description("The DrawMode associated with the control"), Category("JControls")]
        public DrawMode DrawMode
        {
            get { return this.cb.DrawMode; }
            set { this.cb.DrawMode = value; }
        }

        [Description("The DisplayMember associated with the control"), Category("JControls")]
        public string DisplayMember
        {
            get { return this.cb.DisplayMember; }
            set { this.cb.DisplayMember = value; }
        }

        //[Description("The ValueMember associated with the control"), Category("JControls")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ValueMember
        {
            get { return this.cb.ValueMember; }
            set { this.cb.ValueMember = value; }
        }

        [Description("The FormattingEnabled associated with the control"), Category("JControls")]
        public bool FormattingEnabled
        {
            get { return this.cb.FormattingEnabled; }
            set { this.cb.FormattingEnabled = value; }
        }
        
        //[Description("The Selected Item"), Category("JControls")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get { return (this.cb.SelectedItem == null) ? "" : this.cb.SelectedItem; }
            set { this.cb.SelectedItem = value; }
        }
        
        [Description("The Items associated with the control"), Category("Action")]
        public event EventHandler SelectedIndexChanged;
              
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb = new JControls.JComboBox();
            this.SuspendLayout();
            // 
            // cb
            // 
            this.cb.AccessibleRole = this.AccessibleRole;
            this.cb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cb.BackColor = this.BackColor;
            this.cb.CausesValidation = false;
            this.cb.DisplayMember = "Text";
            this.cb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb.Font = this.Font;
            this.cb.Location = new System.Drawing.Point(0, 0);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(466, 21);
            this.cb.TabIndex = 101;
            this.cb.Tag = "myCustomCombo";
            this.cb.Text = this.Text;
            this.cb.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // CubeComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb);
            this.Name = "CubeComboBox";
            this.Size = new System.Drawing.Size(466, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private JComboBox cb;
    }
}
