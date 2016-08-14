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

namespace Apalo.XlAddin.Forms
{
    public partial class InformationDialog : Form
    {
        public InformationDialog()
        {
            InitializeComponent();
            this.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label1.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label2.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label3.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label4.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label5.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label6.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label7.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label8.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label9.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label10.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label11.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label12.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.label13.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.panel1.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.panel2.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox1.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox2.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox3.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox4.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox5.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox6.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox7.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox8.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox9.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox10.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox11.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox12.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.textBox13.BackColor = Utils.ResourceInitializer.FormStdBackgroundColor;
            this.button1.BackColor = Utils.ResourceInitializer.FormStdButtonBackgroundColor;
        }

        public void ShowDialog(bool update)
        {
            int tmpHiddenCnt = 0;
            for (int i = 0; i < this.panel1.Controls.Count; ++i )
            {
                Control c = (Control)this.panel1.Controls[i];
                if (c.Text.Length == 0)
                {
                    c.Visible = false;
                    ++tmpHiddenCnt;
                }
            }

            this.Height -= (tmpHiddenCnt / 2) * 23;
            this.ShowDialog();
        }

        public string Title
        {
            set
            {
                this.Text = value;
            }
        }

        public string l1
        {
            set
            {
                this.label1.Text = value;
            }
        }

        public string l2
        {
            set
            {
                this.label2.Text = value;
            }
        }

        public string l3
        {
            set
            {
                this.label3.Text = value;
            }
        }

        public string l4
        {
            set
            {
                this.label4.Text = value;
            }
        }

        public string l5
        {
            set
            {
                this.label5.Text = value;
            }
        }

        public string l6
        {
            set
            {
                this.label6.Text = value;
            }
        }

        public string l7
        {
            set
            {
                this.label7.Text = value;
            }
        }

        public string l8
        {
            set
            {
                this.label8.Text = value;
            }
        }

        public string l9
        {
            set
            {
                this.label9.Text = value;
            }
        }

        public string l10
        {
            set
            {
                this.label10.Text = value;
            }
        }


        public string l11
        {
            set
            {
                this.label11.Text = value;
            }
        }

        public string l12
        {
            set
            {
                this.label12.Text = value;
            }
        }

        public string l13
        {
            set
            {
                this.label13.Text = value;
            }
        }


        public string v1
        {
            set
            {
                this.textBox1.Text = value;
            }
        }

        public string v2
        {
            set
            {
                this.textBox2.Text = value;
            }
        }

        public string v3
        {
            set
            {
                this.textBox3.Text = value;
            }
        }

        public string v4
        {
            set
            {
                this.textBox4.Text = value;
            }
        }

        public string v5
        {
            set
            {
                this.textBox5.Text = value;
            }
        }

        public string v6
        {
            set
            {
                this.textBox6.Text = value;
            }
        }

        public string v7
        {
            set
            {
                this.textBox7.Text = value;
            }
        }

        public string v8
        {
            set
            {
                this.textBox8.Text = value;
            }
        }

        public string v9
        {
            set
            {
                this.textBox9.Text = value;
            }
        }

        public string v10
        {
            set
            {
                this.textBox10.Text = value;
            }
        }

        public string v11
        {
            set
            {
                this.textBox11.Text = value;
            }
        }

        public string v12
        {
            set
            {
                this.textBox12.Text = value;
            }
        }

        public string v13
        {
            set
            {
                this.textBox13.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}