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
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Apalo.XlAddin.JSubSet
{
    public class PCube : ComboBox, IPrimitive
    {
        private int hardSelectedIndex = -1;
        public PCube()
        {
            this.DataSource = PaloInfo.Instance.Cubes;
            this.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public String SValue
        {
            get 
            {
                if (this.hardSelectedIndex == -1)
                    this.hardSelectedIndex = this.SelectedIndex;

                try
                {
                    return Common.Enclose(this.Items[this.hardSelectedIndex].ToString(), '"', '"');
                }
                catch
                {
                    return "\"\"";
                }
            }
            set { this.Text = Common.Declose(value, '"', '"'); }
        }

        public void FillXmlFromCtrl(XmlWriter w)
        {
            w.WriteString(PaloInfo.Instance.GetCubeId(this.Text).ToString());
        }

        public bool SetCtrlFromXml(XmlNode root)
        {
            string value = root.ChildNodes[0].Value;
            try
            {
                this.Text = PaloInfo.Instance.GetCubeName(Int32.Parse(value));
            }
            catch
            {
                this.Text = value;
            }
            return true;
        }

        public void SetDefault()
        {
            if (this.Items.Count > 0)
                this.SelectedIndex = 0;
            else
                this.Text = "";
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

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            hardSelectedIndex = this.SelectedIndex;
        }
    }
}
