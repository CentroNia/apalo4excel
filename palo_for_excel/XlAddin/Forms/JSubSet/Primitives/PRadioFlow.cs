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
using Apalo.XlAddin.JSubSet.Primitives;

namespace Apalo.XlAddin.JSubSet
{
    public class PRadioFlow : FlowLayoutPanel, IPrimitive
    {

        public PRadioFlow()
        {
        }

        private int startCount = 0;
        public int StartCount
        {
            get { return startCount; }
            set { startCount = value; }
        }

        private PRadioPanelType pRadioFlowType = PRadioPanelType.Bool;
        public PRadioPanelType PRadioFlowType
        {
            get { return pRadioFlowType; }
            set { pRadioFlowType = value; }
        }

        private bool inverse = false;
        public bool Inverse
        {
            get { return inverse; }
            set { inverse = value; }
        }

        private void SetRadio(int ordinal, bool value)
        {
            if (ordinal < 0)
            {
                foreach (RadioButton rb in Controls)
                    rb.Checked = false;
                return;
            }
            (Controls[ordinal] as RadioButton).Checked = value;
        }

        private bool GetRadio(int ordinal)
        {
            try
            {
                return (Controls[ordinal] as RadioButton).Checked;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string SValue
        {
            get
            {
                if (this.PRadioFlowType == PRadioPanelType.Bool)
                {
                    if (!this.Inverse)
                        return GetRadio(0) ? "False" : "True";
                    else
                        return GetRadio(1) ? "False" : "True";
                }
                else // PRadioFlowType.Int
                {
                    int i = 0;
                    for (; i < Controls.Count; i++)
                        if (GetRadio(i)) return "" + (i + startCount);

                    return "" + startCount;
                }
            }
                  
            set
            {
                try
                {
                    if (this.PRadioFlowType == PRadioPanelType.Bool)
                    {
                        if (!this.Inverse)
                        {
                            if (value == "0" || value == "1")
                            {
                                SetRadio(0, value == "0");
                                SetRadio(1, value == "1");
                            }
                            else
                            {
                                SetRadio(0, !Boolean.Parse(value));
                                SetRadio(1, Boolean.Parse(value));
                            }
                        }
                        else
                        {
                            if (value == "0" || value == "1")
                            {
                                SetRadio(0, value == "1");
                                SetRadio(1, value == "0");
                            }
                            else
                            {
                                SetRadio(0, Boolean.Parse(value));
                                SetRadio(1, !Boolean.Parse(value));
                            }
                        }
                    }
                    else // PRadioFlowType.Int
                    {
                        SetRadio(Int32.Parse(value)-startCount, true);
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        SetRadio(0, true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public void FillXmlFromCtrl(XmlWriter w)
        {
            w.WriteString(this.SValue.ToLower());
        }

        public bool SetCtrlFromXml(XmlNode root)
        {
            string value = root.ChildNodes[0].Value;
            if (this.PRadioFlowType == PRadioPanelType.Bool)
            {
                SValue = value.ToLower();
            }
            else // PRadioFlowType.Int
            {
                try
                {
                    SValue = "" + Int32.Parse(value);
                }
                catch (Exception)
                {
                    SValue = "" + startCount;
                }
            }
            return true;
        }

        public void SetDefault()
        {
            try
            {
                (this.Controls[0] as RadioButton).Checked = true;
            }
            catch (Exception)
            {
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

    }
}
