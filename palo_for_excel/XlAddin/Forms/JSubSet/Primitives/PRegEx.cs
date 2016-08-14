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

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.JSubSet.Primitives
{
    public partial class PRegEx : UserControl, IPrimitive
    {
        public PRegEx()
        {
            InitializeComponent();
            InitializeControls();
        }

        public DataGridView DGVRegexes
        {
            get { return dgvRegexes; }
        }

        private void InitializeControls()
        {
            this.Column.HeaderText = SubsetHelper.GetI18String("Regexes", "SB_");
            //this.Column.ToolTipText = SubsetHelper.GetI18String("Regexes Desc Long", "SB_");
            dgvRegexes.BackgroundColor = Utils.ResourceInitializer.FormStdBackgroundColor;
        }

        #region IPrimitive Members

        public string SValue
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow row in dgvRegexes.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        sb.Append(Common.Enclose(row.Cells[0].Value.ToString(), '"', '"'));
                        sb.Append(Common.Separator);
                    }
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
                dgvRegexes.Rows.Clear();
                if (value == null) return;

                List<string> el = Common.Parse(value, Common.Separator2[0]);
                foreach (string s in el)
                    dgvRegexes.Rows.Add(new object[] { Common.Declose(s, '"', '"') });

                dgvRegexes.Update();
            }
        }

        public void SetDefault()
        {
            dgvRegexes.Rows.Clear();
        }

        public void FillXmlFromCtrl(System.Xml.XmlWriter w)
        {
            foreach (DataGridViewRow row in dgvRegexes.Rows)
            {
                if (row.Cells[0].Value != null)
                    w.WriteElementString("expression", row.Cells[0].Value.ToString());
            }
        }

        public bool SetCtrlFromXml(System.Xml.XmlNode root)
        {
            dgvRegexes.Rows.Clear();
            foreach (XmlNode n in root.ChildNodes)
            {
                if (n.Name == "expression")
                {
                    // JPalo bugfix
                    if (n.ChildNodes[0].Value != null)
                        dgvRegexes.Rows.Add(new object[] { Common.Declose(n.ChildNodes[0].Value.ToString(), '"', '"') });
                    else
                        dgvRegexes.Rows.Add(new object[] { "" });
                }
            }

            return true;
        }

        #endregion

        #region IPrimitive Members

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

        #endregion
    }
}
