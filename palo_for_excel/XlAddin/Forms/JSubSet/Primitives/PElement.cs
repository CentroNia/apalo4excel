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
using Apalo.XlAddin.Utils;
using Jedox.Windows.Forms.CustomControls;
using System.Xml;

namespace Apalo.XlAddin.JSubSet
{
    public class PElement : DropDownTree, IPrimitive
    {
        public PElement()
        {
        }

        public String SValue
        {
            get 
            { 
                if (this.SelectedNode == null || this.SelectedNode.Text == SubsetHelper.GetI18String("All Elements", "SB_CB_"))
                    return "";

                return Common.Enclose(this.SelectedNode.Text, '"', '"'); 
            }
            set 
            {
                if (Common.Declose(value, '"', '"') == "")
                    try
                    {
                        System.Windows.Forms.TreeNode[] Nodes = this.Nodes.Find(SubsetHelper.GetI18String("All Elements", "SB_CB_"), true);
                        this.SelectedNode = Nodes.Length > 0 ? Nodes[0] : null;
                    }
                    catch
                    {
                    }
                else
                    try
                    {
                        this.SelectedNode = this.Nodes.Find(Common.Declose(value, '"', '"'), true)[0];
                    }
                    catch
                    {
                    }
            }
        }

        public void FillXmlFromCtrl(XmlWriter w)
        {
            string value = Common.Declose(this.SValue, '"', '"');
            w.WriteString(PaloInfo.Instance.GetElementId(value).ToString());
        }

        public bool SetCtrlFromXml(XmlNode root)
        {
            string value = root.ChildNodes[0].Value;
            try
            {
                this.SValue = PaloInfo.Instance.GetElementName(Int32.Parse(value));
            }
            catch
            {
                this.SValue = value;
            }
            return true;
        }

        public void SetDefault()
        {
            this.SValue = "";
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
            // 
            // PElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "PElement";
            this.PopupHeight = 400;
            this.ResumeLayout(false);
        }
    }
}
