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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Apalo.XlAddin.JSubSet.Primitives
{
    public partial class PPickList : ListView, IPrimitive
    {
        public PPickList()
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
                foreach (ListViewItem lvi in this.Items)
                {
                    sb.Append(Common.Enclose(lvi.Text, '"', '"'));
                    sb.Append(Common.Separator);
                }
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);

                if (sb.Length > 0)
                    return Common.Enclose(sb.ToString(), '{', '}');
                else
                    return "";
            }
            set
            {
                if (value == null) return;

                this.BeginUpdate();
                this.Items.Clear();
                List<string> el = Common.Parse(value, Common.Separator2[0]);
                foreach (string s in el)
                    this.Items.Add(Common.Declose(s, '"', '"'));
                this.EndUpdate();
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
            foreach (ListViewItem lvi in this.Items) 
                w.WriteElementString("pick_elem", PaloInfo.Instance.GetElementId(lvi.Text).ToString());
        }

        public bool SetCtrlFromXml(System.Xml.XmlNode root)
        {
            this.Items.Clear();
            foreach (XmlNode n in root.ChildNodes)
            {
                if (n.Name == "pick_elem")
                {
                    try
                    {
                        int id = Int32.Parse(n.ChildNodes[0].Value);
                        this.Items.Add(PaloInfo.Instance.GetElementName(id));
                    }
                    catch
                    {
                        this.Items.Add(n.ChildNodes[0].Value);
                    }
                }
            }

            return true;            
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
