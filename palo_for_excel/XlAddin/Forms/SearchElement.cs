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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms
{
    public partial class SearchElement : Form
    {
        public SearchElement()
        {
            InitializeComponent();
            this.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.button1.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.button2.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;

            this.button1.Text = Utils.ResourceInitializer.ButtonSearch;
            this.button2.Text = Utils.ResourceInitializer.BUTTON_CANCEL;
            this.Text = Utils.ResourceInitializer.SearchElementCaption;
            this.toolTip1.SetToolTip(this.textBox1, Utils.ResourceInitializer.SearchElementTip);
            this.toolTip1.SetToolTip(this.button1, Utils.ResourceInitializer.ButtonSearch);
            this.toolTip1.SetToolTip(this.button2, Utils.ResourceInitializer.BUTTON_CANCEL);
            this.textBox1.Text = RegUtils.SearchElement;
        }

        public string GetSearchValue
        {
            get
            {
                return this.textBox1.Text;
            }
        }
    }
}