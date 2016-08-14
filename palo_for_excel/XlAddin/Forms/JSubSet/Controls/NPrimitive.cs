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
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Apalo.XlAddin.JSubSet.Controls
{
    public partial class NPrimitive : Component
    {
        public NPrimitive()
        {
            InitializeComponent();
        }

        private CBParameter cbp;
        public CBParameter CBParameter
        {
            get { return cbp; }
            set 
            { 
                cbp = value;
                if (cbp != null)
                {
                    cbp.CheckedChanged += new EventHandler(cbp_CheckedChanged);
                    cbp.ANamedParameter.UpdateNPValue += new EventHandler(ANamedParameter_UpdateNPValue);
                }
            }
        }

        private IPrimitive ip;
        public IPrimitive IPrimitive 
        {
            get { return ip; }
            set { ip = value; }
        }

        private TableLayoutPanel tlpNamedParams
        {
            get { return Common.CurrentASubset.TlpNamedParams; }
        }

        public NPrimitive(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public string SValue
        {
            get 
            {
                if (ip == null) return "";

                if (cbp != null && cbp.Checked)
                {
                    if (cbp.Text != "")
                        return cbp.ANamedParameter.CBValue.Text;
                    else
                    {
                        ip.SetDefault();
                        return ip.SValue;
                    }
                }
                else
                    return ip.SValue;
            }
            set 
            {
                if (ip == null) return;

                if (cbp != null && cbp.Checked)
                    cbp.ANamedParameter.CBValue.Text = value;
                else
                    ip.SValue = value;
            }
        }

        public bool SetCtrlFromXml(XmlNode node)
        {
            int i = 0;
            try
            {
                if (cbp != null) cbp.Checked = false;
                if (node.ChildNodes[i].Name == "parameter")
                {
                    if (node.ChildNodes[i].ChildNodes[0] != null)
                    {
                        cbp.Checked = true;
                        cbp.ANamedParameter.CBValue.Text = node.ChildNodes[i].ChildNodes[0].Value;
                        this.RefreshNPValue();
                    }
                    i++;
                }

                if (node.ChildNodes[i].Name == "value")
                {
                    ip.SetCtrlFromXml(node.ChildNodes[i]);
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (Exception)
            {
                throw new FormatException();
            }  

            return true;
        }

        public void FillXmlFromCtrl(XmlWriter w, string pName)
        {
            w.WriteStartElement(pName);

            if (cbp != null && cbp.Checked)
                w.WriteElementString("parameter", cbp.ANamedParameter.CBValue.Text);
            
            w.WriteStartElement("value");
            ip.FillXmlFromCtrl(w);
            w.WriteEndElement();

            w.WriteEndElement();
        }

        private void cbp_CheckedChanged(object sender, EventArgs e)
        {
            if (ip is Control)
                (ip as Control).Enabled = !cbp.Checked;

            cbp.ANamedParameter.PName = ip.PName;

            if (cbp.Checked)
            {
                if (tlpNamedParams != null && !tlpNamedParams.Controls.Contains(cbp.ANamedParameter))
                    tlpNamedParams.Controls.Add(cbp.ANamedParameter);
            }
            else
            {
                if (tlpNamedParams != null && tlpNamedParams.Controls.Contains(cbp.ANamedParameter))
                    tlpNamedParams.Controls.Remove(cbp.ANamedParameter);
            }
        }

        public void RefreshNPValue()
        {
            QueryXCellEventArgs qe = new QueryXCellEventArgs();
            qe.CellRange = this.cbp.ANamedParameter.CBValue.Text;

            Common.CurrentASubset.OnQueryXCell(qe);

            //MessageBox.Show("DEBUG: [" + qe.CellRange + "]: " + qe.ExcelValue);
            this.IPrimitive.SValue = qe.ExcelValue;
        }

        private void ANamedParameter_UpdateNPValue(object sender, EventArgs e)
        {
            RefreshNPValue();
        }

        public void ClearNamedParams()
        {
            if (tlpNamedParams != null && tlpNamedParams.Controls.Contains(cbp.ANamedParameter))
                tlpNamedParams.Controls.Remove(cbp.ANamedParameter);          
        }
    }
}
