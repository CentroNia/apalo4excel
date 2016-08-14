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
using System.Collections;
using Apalo.XlAddin.Forms;
using Jedox.Palo.Comm;
using Apalo.XlAddin.JSubSet.Controls;
using System.Xml;

namespace Apalo.XlAddin.JSubSet.Primitives
{
    public partial class PDataPicker : UserControl, IPrimitive
    {
        public void ClearList()
        {
            tlpList.Controls.Clear();

            if (npDimensionSubsets != null)
            {
                foreach (NPrimitive np in npDimensionSubsets)
                         np.ClearNamedParams();
            }
        }

        List<PDimensionSlice> pDimensionSubsets;
        List<NPrimitive> npDimensionSubsets;
        public void SetDimensions(string[] dimsA)
        {
            pDimensionSubsets = new List<PDimensionSlice>();
            npDimensionSubsets = new List<NPrimitive>();

            tlpList.SuspendLayout();
            tlpList.Controls.Clear();

            foreach (string dim in dimsA)
            {
                PDimensionSlice pds = new PDimensionSlice();
                CBParameter cbParam = new CBParameter();
                NPrimitive npds = new NPrimitive();

                pds.Text = dim;
                pds.PName = "[" + dim + "]";
                cbParam.Text = "As Parameter";
                cbParam.Margin = new Padding(0, 0, 0, 1);

                if (dim == Common.CurrentASubset.Dimension)
                    pds.Enabled = cbParam.Enabled = false;

                npds.IPrimitive = pds;
                npds.CBParameter = cbParam;
                
                tlpList.Controls.Add(pds);
                tlpList.Controls.Add(pds.LBElements);
                tlpList.Controls.Add(cbParam);

                pDimensionSubsets.Add(pds);
                npDimensionSubsets.Add(npds);
            }

            tlpList.ResumeLayout();
        }

        public PDataPicker()
        {
            InitializeComponent();
        }

        public string SValue
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                
                if (pDimensionSubsets == null) return "";
                foreach (NPrimitive npds in npDimensionSubsets)
                {
                    sb.Append(npds.SValue);
                    sb.Append(Common.Separator);
                }

                if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
            set
            {
            }
        }

        public void SetCoords(ref BoolStringArray[] Coords, ref bool CoordsSet)
        {
            List<BoolStringArray> list = new List<BoolStringArray>();

            CoordsSet = false;
            Coords = list.ToArray();

            if (pDimensionSubsets == null) return;

            foreach (PDimensionSlice pds in pDimensionSubsets) {
                BoolStringArray bsa = new BoolStringArray();

                if (pds.Dimension == Common.CurrentASubset.Dimension)
                    bsa.BoolVal = false;
                // Strange... This will always make CoordsSet to true
                else
                {
                    bsa.BoolVal = true;
                    CoordsSet = true;
                }

                List<String> strings = new List<string>();
                foreach (object[] o in pds.Selection)
                {
                    strings.Add((string)o[0]);
                    bsa.BoolVal = false;
                    CoordsSet = true;
                }

                bsa.Str = strings.ToArray();
                list.Add(bsa);
            }

            Coords = list.ToArray();
        }

        public void SetDefault()
        {
            if (npDimensionSubsets == null) return;
            foreach (NPrimitive npds in npDimensionSubsets)
            {
                if (npds.IPrimitive != null)
                    npds.IPrimitive.SetDefault();

                if (npds.CBParameter != null)
                    npds.CBParameter.Checked = false;
            }
        }

        public void FillXmlFromCtrl(System.Xml.XmlWriter w)
        {
            foreach (NPrimitive npds in npDimensionSubsets)
            {
                npds.FillXmlFromCtrl(w, "dimension_coordinates");
            }
        }

        public bool SetCtrlFromXml(System.Xml.XmlNode root)
        {
            int i = 0;
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "dimension_coordinates")
                {
                    npDimensionSubsets[i++].SetCtrlFromXml(node);
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

    }
}
