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
﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Subset.Parser
{
    class XmlHelper
    {
        XmlElement e;
        XmlDocument d;

        public XmlHelper(XmlDocument d, XmlElement e)
        {
            this.d = d;
            this.e = e;
        }
        public XmlHelper InsertElement(String name)
        {
            XmlElement ne = d.CreateElement(name, e.NamespaceURI);
            e.AppendChild(ne);
            return new XmlHelper(d, ne);
        }

        public XmlHelper SetAttribute(String name, String value)
        {
            e.SetAttribute(name, value);
            return this;
        }

        public String InnerText { get { return e.InnerText; } set { e.InnerText = value; } }

        public void InsertValueElement(String InnerText)
        {
            this.InsertElement("value").InnerText = InnerText;
        }

        public void InsertValueListElement(String ListItemName, String[] Values)
        {
            XmlHelper eh = this.InsertElement("value");
            foreach (String v in Values)
                eh.InsertElement(ListItemName).InnerText = v;
        }

        public void InsertParameterElement(String InnerText)
        {
            this.InsertElement("parameter").InnerText = InnerText;
            this.InsertElement("value").InnerText = "undefined";
        }

        public XmlHelper InsertElementAndValueElement(String name, String value)
        {
            if (!String.IsNullOrEmpty(value))
                this.InsertElement(name).InsertValueElement(value);
            return this;
        }

        public XmlHelper InsertElementAndEmptyValueElement(String name)
        {
            this.InsertElement(name).InsertValueElement("");
            return this;
        }

        public XmlHelper InsertElementAndParameterValue(String name, ParameterValue pv)
        {
            if (pv != null)
            {
                XmlHelper eh = this.InsertElement(name);
                if (!String.IsNullOrEmpty(pv.Value))
                    eh.InsertValueElement(pv.Value);
                if (!String.IsNullOrEmpty(pv.Parameter))
                    eh.InsertParameterElement(pv.Parameter);
            }
            return this;
        }

        public XmlHelper InsertElementAndParameterValueList(String name, ParameterValueList pvl)
        {
            if (pvl != null)
            {
                XmlHelper eh = this.InsertElement(name);
                if (pvl.Values != null)
                    eh.InsertValueListElement(pvl.ItemName, pvl.Values);
                if (!String.IsNullOrEmpty(pvl.Parameter))
                    eh.InsertParameterElement(pvl.Parameter);
            }
            return this;
        }

        public void InsertRawElement(String name, String value)
        {
            this.InsertElement(name).InnerText = value;
        }

        public XmlHelper AppendChild(XmlHelper eh)
        {
            e.AppendChild(eh.e);
            return this;
        }
    }
}
