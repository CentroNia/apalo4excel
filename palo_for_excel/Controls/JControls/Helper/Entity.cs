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

////////////////////////////////////////////////////////////////////////////////
/// @brief  Entity definition
///
/// @file   Entity.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace JControls
{
    public class CBEntity
    {
        public Entity Entity;
        public string Delimiter = Constants.DQUOTE;

        public CBEntity(Entity e, string delimiter)
        {
            Entity = e;
            Delimiter = delimiter;
        }

        public override string ToString()
        {
            return Delimiter + Entity.Name.Replace(Delimiter.ToString(), Delimiter.ToString() + Delimiter.ToString())  + Delimiter;
        }
    }

    public class Entity
    {
        private string name;
        private List<Entity> entities;
        private bool unique = true;
        private Entity dimension;
        private bool c = false;

        public List<Entity> Entities
        {
            get { return entities; }
            set { entities = value; }
        }

        public bool Unique
        {
            get { return unique; }
            set { unique = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public bool C
        {
            get { return c; }
            set { c = value; }
        }
        public Entity Dimension
        {
            get { return dimension; }
            set { dimension = value; }
        }

        public Entity()
        {
            Entities = new List<Entity>();
        }

        public Entity(string name)
        {
            Name = name;
            Entities = new List<Entity>();
        }
        
        public Entity(string name, bool unique)
        {
            Name = name;
            Unique = unique;
            Entities = new List<Entity>();
        }
    }

    public class RBElements
    {
        public static Dictionary<string, Entity> Dictionary = new Dictionary<string,Entity>();
    }
}
