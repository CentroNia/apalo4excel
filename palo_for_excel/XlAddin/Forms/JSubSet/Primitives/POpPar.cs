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
using Apalo.XlAddin.JSubSet.Controls;

namespace Apalo.XlAddin.JSubSet
{
    public partial class POpPar : UserControl, IPrimitive
    {
        private int cbOper1SelectedIndex = -1;
        private int cbOper2SelectedIndex = -1;

        public POpPar()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            
            this.cbOper1.Items.AddRange(new object[] {
            "(" + Utils.ResourceInitializer.TEXT_NONE + ")",
            "=",
            ">=",
            ">",
            "<=",
            "<",
            "<>"});

            this.cbOper2.Items.AddRange(new object[] {
            "(" + Utils.ResourceInitializer.TEXT_NONE + ")",
            "=",
            ">=",
            ">",
            "<=",
            "<",
            "<>"});
            this.SetDefault();
            Common.InternationalizeControl(lbAND, true, false, null);
            this.Show();
        }

        public bool Op1Selected
        {
            get 
            {
                if (cbOper1SelectedIndex == -1)
                    cbOper1SelectedIndex = cbOper1.SelectedIndex;

                return cbOper1SelectedIndex != 0 && cbOper1SelectedIndex != -1; 
            }
            set
            {
                if (!value)
                    cbOper1.SelectedIndex = 0;
            }
        }

        public bool Op2Selected
        {
            get
            {
                if (cbOper2SelectedIndex == -1)
                    cbOper2SelectedIndex = cbOper2.SelectedIndex;

                return cbOper2SelectedIndex != 0 && cbOper2SelectedIndex != -1;
            }
            set
            {
                if (!value)
                    cbOper2.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOper1SelectedIndex = cbOper1.SelectedIndex;

            if (!Op1Selected)
                Op2Selected = false;

            tbPar1.Enabled = Op1Selected;
            cbOper2.Enabled = Op1Selected;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOper2SelectedIndex = cbOper2.SelectedIndex;

            tbPar2.Enabled = Op2Selected;
        }

        #region IPrimitive Members

        public string SValue
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (Op1Selected)
                {
                    sb.Append(Common.Enclose(cbOper1.Items[cbOper1SelectedIndex].ToString(), '"', '"'));
                    sb.Append(Common.Separator);
                    sb.Append(Common.EnclosePossibleNumber(npPar1.SValue, '"', '"'));
                }
                if (Op2Selected)
                {
                    sb.Append(Common.Separator);
                    sb.Append(Common.Enclose(cbOper2.Items[cbOper2SelectedIndex].ToString(), '"', '"'));
                    sb.Append(Common.Separator);
                    sb.Append(Common.EnclosePossibleNumber(npPar2.SValue, '"', '"'));
                }

                if (sb.Length > 0)
                    return Common.Enclose(sb.ToString(), '{', '}');
                else
                    return "";
            }
            set
            {
                if (value == null) return;

                List<string> rows = Common.Parse(value, Common.Separator2[0]);
                if (rows.Count > 0)
                {
                    List<string> cells = Common.Parse(rows[0], Common.Separator[0]);
                    if (cells.Count == 2)
                    {
                        cbOper1.Text = Common.Declose(cells[0], '"', '"');
                        npPar1.SValue = Common.Declose(cells[1], '"', '"');
                    }
                }
                if (rows.Count > 1)
                {
                    List<string> cells = Common.Parse(rows[1], Common.Separator[0]);
                    if (cells.Count == 2)
                    {
                        cbOper2.Text = Common.Declose(cells[0], '"', '"');
                        npPar2.SValue = Common.Declose(cells[1], '"', '"');
                    }
                }
            }
        }

        public void SetDefault()
        {
            cbOper1.SelectedIndex = 0;
            cbOper2.SelectedIndex = 0;

            tbPar1.SetDefault();
            tbPar2.SetDefault();
        }

        public void FillXmlFromCtrl(System.Xml.XmlWriter w)
        {
            List<string> nodes = new List<string>();

            w.WriteStartElement("criteria");

            if (Op1Selected)
            {
                npPar1.FillXmlFromCtrl(w, "par1");
                w.WriteElementString("op1", cbOper1.Text);
            }
            if (Op2Selected)
            {
                npPar2.FillXmlFromCtrl(w, "par2");
                w.WriteElementString("op2", cbOper2.Text);
            }

            w.WriteEndElement();
        }

        public bool SetCtrlFromXml(System.Xml.XmlNode root)
        {
            this.SetDefault();
            try
            {
                cbOper1.SelectedItem = root.ChildNodes[1].ChildNodes[0].Value;
                npPar1.SetCtrlFromXml(root.ChildNodes[0]);
                cbOper2.SelectedItem = root.ChildNodes[3].ChildNodes[0].Value;
                npPar2.SetCtrlFromXml(root.ChildNodes[2]);
            }
            catch (Exception)
            {
            }

            return true;
        }

        // Set parameters for ArgDataFilterSettings:
        public void SetParams(ref string Op1, ref string Op2, ref double Par1d, ref string Par1s,
                        ref double Par2d, ref string Par2s, ref bool UseStrings)
        {
            if (cbOper1.SelectedIndex == 0)
                return;

            if (cbOper1.SelectedIndex != 0)
                Op1 = cbOper1.Text;
            if (cbOper2.SelectedIndex != 0)
                Op2 = cbOper2.Text;

            double tmp;
            UseStrings = true;
            if (Double.TryParse(npPar1.SValue, out tmp) && (Double.TryParse(npPar2.SValue, out tmp) || cbOper2.SelectedIndex == 0))
                UseStrings = false;

            Par1s = npPar1.SValue;
            if (cbOper2.SelectedIndex != 0)
                Par2s = npPar2.SValue;

            if (!UseStrings)
            {
                Par1d = Double.Parse(Par1s);
                if (cbOper2.SelectedIndex != 0)
                    Par2d = Double.Parse(Par2s); 
            }
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

        #endregion

        private CBParameter cbPar1;
        public CBParameter CBPPar1
        {
            get { return cbPar1; }
            set { cbPar1 = value; npPar1.CBParameter = value; }
        }

        private CBParameter cbPar2;
        public CBParameter CBPPar2
        {
            get { return cbPar2; }
            set { cbPar2 = value; npPar2.CBParameter = value; }
        }

    }
}
