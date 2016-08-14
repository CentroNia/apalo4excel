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

﻿////////////////////////////////////////////////////////////////////////////////
/// @brief  Collapsible Control (Base Class)
///
/// @file   Collapsible.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;

namespace JControls
{
    public partial class Collapsible : UserControl
    {
        private TableLayoutPanel tGrid;
        private TableLayoutPanel cGrid;
        private TableLayoutPanel capGrid;
        private Button bCollapse;
        private Button bExpand;
        private LinkLabel captionLabel;
        private Color bc;
        private bool hasBackColor = false;
        private Color borderColor;
        private bool isCollapsed = false;
        private bool autoCollapse = false;
        private int level = 0;
        private int dim = 10;

        protected TableLayoutPanel CapGrid
        {
            get { return capGrid; }
        }

        protected TableLayoutPanel CGrid
        {
            get { return cGrid; }
        }

        protected TableLayoutPanel TGrid
        {
            get { return tGrid; }
        }

        protected Button BCollapse
        {
            get { return bCollapse; }
        }

        protected Button BUnCollapse
        {
            get { return bExpand; }
        }

        protected LinkLabel CaptionLabel
        {
            get { return captionLabel; }
        }

        public Control TitleControl
        {
            get
            {
                return (cGrid.Controls.Count > 1) ? cGrid.Controls[1] : null;
            }
            protected set
            {
                if (cGrid.Controls.Count > 1)
                {
                    cGrid.Controls.RemoveAt(1);
                }
                cGrid.Controls.Add(value, 1, 0);
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        public int Level
        {
            get
            {
                if (level == 0)
                {
                    Control c = this;
                    while (c.Parent != null)
                    {
                        level++;
                        c = c.Parent;
                    }                     
                }
                return level;
            }
        }

        protected Control AdditionalCtrl
        {
            get
            {
                return (cGrid.Controls.Count > 2) ? cGrid.Controls[2] : null;
            }
            set
            {
                if (cGrid.Controls.Count > 2)
                {
                    cGrid.Controls.RemoveAt(2);
                }
                cGrid.Controls.Add(value, 2, 0);
            }
        }

        protected TableLayoutPanel TLPanel
        {
            get { return TLPanel; }
        }

        public virtual bool Collapsed
        {
            get { return isCollapsed; }
            set
            {
                if (isCollapsed == value) return;

                isCollapsed = value;
                
                if (isCollapsed)
                {
                    SuspendLayout();
                    for (int i = 1; i < TControls.Count; i++)
                        TControls[i].Hide();
                    capGrid.Show();
                    ResumeLayout();
                }
                else
                {
                    SuspendLayout();
                    foreach (Control c in tGrid.Controls)
                        try
                        {
                            c.Show();
                        }
                        catch (Exception)
                        {
                            ResumeLayout();
                            MessageBox.Show("Expression too complex. No more controls can be expanded. We are sorry for the inconvenience.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Collapse();
                            break;
                        }
                    capGrid.Hide();
                    ResumeLayout();
                }
            }
        }

        public bool AutoCollapse
        {
            get { return autoCollapse; }
            set { autoCollapse = value; }
        }

        public ControlCollection TControls
        {
            get { return tGrid.Controls; }
        }

        public bool HasBackColor
        {
            get { return hasBackColor; }
            set { hasBackColor = value; }
        }

        public Collapsible()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            tGrid = new TableLayoutPanel();
            capGrid = new TableLayoutPanel();
            cGrid = new TableLayoutPanel();

            this.SuspendLayout();
            tGrid.SuspendLayout();
            capGrid.SuspendLayout();
            cGrid.SuspendLayout();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            
            tGrid.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tGrid.AutoSize = true;
            tGrid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tGrid.Dock = DockStyle.Fill;
            tGrid.Paint += new PaintEventHandler(tGrid_Paint);

            //tGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            captionLabel = new LinkLabel();
            captionLabel.Anchor = AnchorStyles.Left;
            captionLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            captionLabel.Text = Constants.nullStr;
            captionLabel.Margin = new Padding(0, 0, 0, 0);
            captionLabel.AutoSize = true;
            captionLabel.MaximumSize = new Size(240, 13);
            captionLabel.AutoEllipsis = true;
            captionLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(captionLabel_LinkClicked);

            capGrid.AutoSize = true;
            capGrid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            capGrid.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            capGrid.ColumnCount = 2;
            capGrid.Margin = new Padding(1, 1, 1, 1);
            bExpand = new Button();
            bExpand.Anchor = AnchorStyles.None;
            bExpand.TabStop = false;
            bExpand.Image = JControls.Properties.Resources.lp;
            bExpand.FlatStyle = FlatStyle.Flat;
            bExpand.FlatAppearance.BorderSize = 0;
            bExpand.Size = new Size(12, 12);
            bExpand.Margin = new Padding(3, 3, 3, 1);
            bExpand.Click += new EventHandler(bUnCollapse_Click);

            capGrid.Controls.Add(bExpand,0,0);
            capGrid.Controls.Add(captionLabel, 1, 0);
            capGrid.Dock = DockStyle.Fill;
            capGrid.Visible = false;
            
            cGrid.AutoSize = true;
            cGrid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cGrid.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            cGrid.ColumnCount = 3;
            cGrid.Dock = DockStyle.Fill;
            cGrid.Margin = new Padding(1, 1, 1, 1);
            bCollapse = new Button();
            bCollapse.Anchor = AnchorStyles.None;
            bCollapse.TabStop = false;
            bCollapse.Image = JControls.Properties.Resources.lm;
            bCollapse.FlatStyle = FlatStyle.Flat;
            bCollapse.FlatAppearance.BorderSize = 0;
            bCollapse.Size = new Size(12, 12);
            bCollapse.Margin = new Padding(2, 2, 0, 0);
            bCollapse.Click += new EventHandler(bCollapse_Click);
            cGrid.Controls.Add(bCollapse, 0, 0);
            
            tGrid.Controls.Add(capGrid);
            tGrid.Controls.Add(cGrid);
            
            this.Controls.Add(tGrid);

            bCollapse.MouseEnter += new EventHandler(bCollapse_MouseEnter);
            bCollapse.MouseLeave += new EventHandler(bCollapse_MouseLeave);

            tGrid.ResumeLayout();
            cGrid.ResumeLayout();
            capGrid.ResumeLayout();
            this.ResumeLayout();

            bc = this.BackColor;
        }
        
        public void Collapse()
        {
            Collapsed = true;
        }

        public void Expand()
        {
            Collapsed = false;
        }

        public void ExpandAll()
        {
            for (int i = 2; i < TControls.Count; i++)
            {
                if (TControls[i] is Collapsible)
                    ((Collapsible)TControls[i]).ExpandAll();
            }
            Expand();
        }

        public void CollapseUnder()
        {
            for (int i = 2; i < TControls.Count; i++)
            {
                if (TControls[i] is Collapsible)
                {
                    ((Collapsible)TControls[i]).Collapse();
                    ((Collapsible)TControls[i]).CollapseUnder();
                }
            }
        }

        public void AddControl(Control c)
        {
            if (this.Level > 32)
            {
                throw new OutOfMemoryException();
            }
            TControls.Add(c);
        }

        public void AddControlDim(Control c)
        {
            int R = (this.BackColor.R > 2 * dim) ? (this.BackColor.R - dim) : (byte)dim;
            int G = (this.BackColor.G > 2 * dim) ? (this.BackColor.G - dim) : (byte)dim;
            int B = (this.BackColor.B > 2 * dim) ? (this.BackColor.B - dim) : (byte)dim;

            c.BackColor = Color.FromArgb(R, G, B);
            if (c is Collapsible)
            {
                ((Collapsible)c).HasBackColor = true;
            }
            AddControl(c);
        }

        protected void TCDisposeAt(int index)
        {
            // BUG solver: ToolTip, AutoComplete, ContextMenuStrip memory leak
            //
            // ToolTip, AutoComplete (for ComboBox) and ContextMenuStrip all have nasty bug
            // that they do not automatically dispose references, so every
            // time control that contains one of these is instantiated, the number
            // of GDI object increases. The problem is explained in:
            // (TODO)

            Control t = TControls[index];
            TControls.RemoveAt(index);
            t.Dispose();
        }

        private void bCollapse_Click(object sender, EventArgs e)
        {
            Collapse();
        }

        private void bUnCollapse_Click(object sender, EventArgs e)
        {
            Expand();
        }

        private void captionLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Expand();
        }

        public void Highlight()
        {
            bc = (HasBackColor) ? BackColor : Color.Empty;
            BackColor = Color.LightGoldenrodYellow;
        }

        public void UnHighlight()
        {
            BackColor = bc;
        }

        private void bCollapse_MouseEnter(object sender, EventArgs e)
        {
            Highlight();
        }

        private void bCollapse_MouseLeave(object sender, EventArgs e)
        {
            UnHighlight();
        }

        private void tGrid_Paint(object sender, PaintEventArgs e)
        {
            if (this.BorderColor != Color.Empty)
            {
                Pen pen = new Pen(BorderColor);
                e.Graphics.DrawRectangle(pen, 0, 0, tGrid.Width - 1, tGrid.Height - 1);
                pen.Dispose();
                pen = null;
            }
        }
    }
}
