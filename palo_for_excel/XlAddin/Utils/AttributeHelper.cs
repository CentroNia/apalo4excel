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

using System.Collections;
// using System.IO;
using Jedox.Palo.Comm;

namespace Apalo.XlAddin.Utils
{
    public class AttributeHelper
    {
        private static bool checkattributes1(ElementInfo[] attribs, ref ArrayList attr, ref ArrayList attrId)
        {
            bool ret = false;
            int i = 0, j, clength, length = attribs.Length;
            ChildInfoRaw[] children;
            ElementInfo ei;

            while ((i < length) && !ret)
            {
                if (attribs[i].Name.ToUpper() == GeneralConst.ATTRIBUT_ALIAS)
                {
                    children = attribs[i].Children;
                    clength = children.Length;
                    ret = (clength > 0);
                    if (ret)
                    {
                        int asize = attribs.Length;
                        ElementInfo attrib;

                        Hashtable id2attribs = new Hashtable();

                        for (j = 0; j < asize; j++)
                        {
                            attrib = attribs[j];
                            id2attribs[attrib.Identifier] = attrib;
                        }

                        for (j = 0; j < clength; j++)
                        {
                            ei = (ElementInfo)id2attribs[children[j].Identifier];
                            if (ei.Type == DimElementType.DimElementTypeString)
                            {
                                attr.Add(ei.Name);
                                attrId.Add(ei.Identifier);
                            }
                        }
                    }
                }
                i++;
            }
            return ret;

        }

        private static void checkattributes2(ElementInfo[] attribs, ref ArrayList attr, ref ArrayList attrId, bool is_paste)
        {
            int i = 0, length = attribs.Length;

            while (i < length)
            {
                if (!is_paste || ((attribs[i].NumberChildren == 0) && (attribs[i].Type == DimElementType.DimElementTypeString)))
                {
                    attr.Add(attribs[i].Name);
                    attrId.Add(attribs[i].Identifier);
                }
                i++;
            }
        }

        private static ElementInfo[] checkattributes(Connection c, string db, string dim, ref ArrayList attr, ref ArrayList attrId, bool is_paste)
        {
            string attrib_dim = c.GetAttributeDimension(db, dim);

            ElementInfo[] attribs = c.DimensionListElements(db, attrib_dim);


            if (!checkattributes1(attribs, ref attr, ref attrId))
            {
                checkattributes2(attribs, ref attr, ref attrId, is_paste);
            }

            return attribs;
        }

        public static ElementInfo[] checkattributes(Connection c, string db, string dim, ref ArrayList attr, ref ArrayList attrId)
        {
            return checkattributes(c, db, dim, ref attr, ref attrId, false);
        }

        public static void checkattributes(Connection c, string db, string dim, ref string attribute_cube, ref System.Windows.Forms.ComboBox cb)
        {
            attribute_cube = c.GetAttributeCube(db, dim);

            cb.Items.Add("<" + ResourceInitializer.TEXT_NONE + ">");

            ArrayList attr = new ArrayList();
            ArrayList attrId = new ArrayList();
            checkattributes(c, db, dim, ref attr, ref attrId, true);
            int i, asize = attr.Count;
            for (i = 0; i < asize; i++)
            {
               cb.Items.Add(attr[i]);
            }
            cb.Visible = true;
        }

    }
}
