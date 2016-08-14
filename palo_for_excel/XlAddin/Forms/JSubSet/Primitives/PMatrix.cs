 /* 
 *
 * Copyright (C) 2006-2009 Jedox AG
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Jedox.Palo.XlAddin.JSubSet.Primitives
{
    public partial class PMatrix : ListView, IPrimitive
    {
        public PMatrix()
        {
            this.View = View.Details;
            this.GridLines = true;
            this.FullRowSelect = true;
        }

        public string SValue
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                int countActive = 0;
                foreach (ListViewItem lvi in this.Items)
                    if (lvi.Checked) countActive++;

                if (countActive == 0) return "";

                int i = 0;
                for ( ; i < this.Columns.Count-1; i++)
                {
                    sb.Append(Common.Enclose(this.Columns[i+1].Text, '"', '"'));
                    sb.Append(Common.Separator);
                }
                if (i > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(Common.Separator2);
                }
                foreach (ListViewItem lvi in this.Items)
                {
                    if (!lvi.Checked) continue;
                    int j = 1;
                    for ( ; j < lvi.SubItems.Count; j++)
                    {

                        sb.Append(Common.Enclose(lvi.SubItems[j].Text, '"', '"'));
                        sb.Append(Common.Separator);
                    }
                    if (j > 1) sb.Remove(sb.Length - 1, 1);
                    sb.Append(Common.Separator2);
                    i++;
                }
                if (i > 0)
                    sb.Remove(sb.Length - 1, 1);

                if (sb.Length > 0)
                    return Common.Enclose(sb.ToString(), '{', '}');
                else
                    return "";
            }
            set
            {
                this.BeginUpdate();
                this.Items.Clear();
                List<string> el = Common.Parse(Common.Declose(value,'{','}'), Common.Separator2[0]);
                foreach (string s in el)
                {
                    ListViewItem lvi = new ListViewItem();
                    List<string> els = Common.Parse(s, Common.Separator[0]);
                    foreach (string ss in els)
                        lvi.SubItems.Add(Common.Declose(value, '"', '"'));
                    this.Items.Add(lvi);
                }
            }
        }

        public void SetDefault()
        {
            this.BeginUpdate();
            this.Items.Clear();
            this.EndUpdate();
        }

        public void FillXmlFromCtrl(System.Xml.XmlWriter w)
        {
        }

        public bool SetCtrlFromXml(System.Xml.XmlNode root)
        {
            return false;
        }

        private string pName;
        public string PName
        {
            get
            {
                return (pName != null && pName != "") ? pName : "Untitled";
            }
            set
            {
                pName = value;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
