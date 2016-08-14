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
/// @brief  ComboBox Filter implementation for database-cube-dimension-element
///         chain
///
/// @file   Filter.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JControls
{   
    public class Filter
    {
        private List<CBEntity> cbeList;
        private Filter parent;
        private List<Filter> children;      // on the top of the hierarchy should be the
                                            // filter with unchangeable content (such as DBList.Instance)
        private ComboBox cbFilter;
        private CBEntity selectedCBEntity_cached;
        private bool containsBangDim;          // true: enable !'dimension' choice in filter ComboBox
        private string delimiter = Constants.SQUOTE;
        private bool isDirty = true;
        private bool usesOrdinal = false;   // true: in case of (Parent.SelectedCBEntity == null), restrict 
                                            // on the Parent's element which has the ordinal number
                                            // that corresponds to the ordinal number of this child 
                                            // in children list.

        private bool passThrough = false;   // true: passes through combobox data, even if we don't
                                            // explicitly select anything

        private bool usesAnyElement = false;   
                                            // true: default Element name is "<Any Element>"
                                            // false: default Element name is !'dimension'
        
        public bool Filtered = false;       //true: N Element 
                                            //false: C i N Element 

        public Filter()
        {
            cbeList = new List<CBEntity>();
            children = new List<Filter>();
        }

        public bool UsesAnyElement
        {
            get { return usesAnyElement; }
            set { usesAnyElement = value; }
        }

        public bool PassThrough
        {
            get { return passThrough; }
            set { passThrough = value; }
        }

        public List<CBEntity> CBEList
        {
            get { return cbeList; }
        }

        public int Ordinal
        {
            get { if (Parent != null) return Parent.children.IndexOf(this); else return -1; }
        }

        public bool UsesOrdinal
        {
            get { return usesOrdinal; }
            set { usesOrdinal = value; }
        }

        public string Delimiter
        {
            get { return delimiter; }
            set
            {
                if (delimiter != value)
                {
                    this.IsDirty = true;
                    this.SelectedCBEntity = null;
                    delimiter = value;
                    foreach (CBEntity e in cbeList)
                    {
                        e.Delimiter = value;
                    }
                }
            }
        }

        public bool IsDirty
        {
            get { return isDirty; }
            set 
            {
                isDirty = value;
                if ((cbFilter != null) && (cbFilter.Items.Count > 0) && (cbFilter.SelectedItem != null) && ((cbFilter.SelectedItem is CBEntity) || cbFilter.Text.StartsWith("!'") || cbFilter.Text.StartsWith("<")))
                {
                    cbFilter.Text = "";
                    CBFilter.SelectedItem = null;
                }
                if (isDirty)
                {
                    foreach (Filter f in this.children)
                    {
                        f.IsDirty = true;
                    }
                }
            }
        }

        private void AddDefaultElement(CBEntity coordinate)     // Add !'dimension'
        {
            if (cbFilter != null)
            {
                if (usesAnyElement)
                {
                    // cbFilter.Items.Insert(0, "<Any element>");
                    return;
                }
                else
                {
                    cbFilter.Items.Insert(0, "!'" + coordinate.Entity.Name.Replace("'", "''") + "'");
                }
            }
        }

        private void DelBangDim()     // Remove !'dimension'
        {
            if (cbFilter != null)
            {
                cbFilter.Items.RemoveAt(0);
            }
        }

        public bool ContainsBangDim
        {
            get { return containsBangDim; }
            set { containsBangDim = value; }
        }

        // Adds one entity
        public void AddEntity(Entity e)
        {
            if (cbeList.Count >= Constants.MAX_ENTITIES) return;
            CBEntity cbe = new CBEntity(e,delimiter);
            cbeList.Add(cbe);
            this.IsDirty = true;
            if (cbFilter != null)
            {
                cbFilter.Items.Insert(cbeList.Count - 1, cbe);
            }
        }

        // Adds a list of entities
        public void AddEntityRange(List<Entity> er, bool includeNonUnique)
        {
            foreach (Entity e in er)
            {
                if (e.Unique || includeNonUnique)
                {
                    AddEntity(e);
                }
                if (cbeList.Count >= Constants.MAX_ENTITIES) return;
            }
        }
        
        // Adds all the children of one entity
        public void AddEntityChildren(Entity ep, bool includeNonUnique)
        {
            foreach (Entity e in ep.Entities)
            {
                if (e.Entities.Count == 0 && e.C && this.Parent != null && this.Parent.Filtered)      //PALO.MARKER
                {
                    continue;
                }
                else if (this.Filtered && e.C) //[[...]]
                {
                    continue;
                }

                if (e.Unique || includeNonUnique)
                {
                    AddEntity(e);
                }
                
                if (cbeList.Count >= Constants.MAX_ENTITIES) return;
            }
        }

        // Adds child filter (next level filter)
        public void AddChild(Filter c)
        {
            children.Add(c);
            c.Parent = this;
        }

        public void RemoveChildAt(int index)
        {
            children.RemoveAt(index);
        }

        public void RemoveChild(Filter cf)
        {
            children.Remove(cf);
        }

        // Important: this has to be called after deletion of some CFChooser:
        public void RemoveLastChild()
        {
            if (children.Count > 1)
                children.RemoveAt(children.Count - 1);
        }

        public Filter Parent
        {
            get { return parent; }
            set { parent = value; this.IsDirty = true; }
        }

        public CBEntity SelectedCBEntity
        {
            set 
            { 
                selectedCBEntity_cached = value;
                foreach (Filter f in children)
                {
                    f.IsDirty = true;
                }
            }
            get
            {
                if (cbFilter != null)
                {
                    selectedCBEntity_cached = cbFilter.SelectedItem as CBEntity;
                }
                return selectedCBEntity_cached;
            }
        }

        private void ClearCB()
        {
            if (cbFilter == null) return;
            if (containsBangDim && cbFilter.Items.Count > 0 && (cbFilter.Items[0].ToString().StartsWith("!'") || cbFilter.Items[0].ToString().StartsWith("<")))
            {
                DelBangDim();
            }
            while (cbFilter.Items.Count > 0 && cbFilter.Items[0] is CBEntity)
            {
                cbFilter.Items.RemoveAt(0);
            }
        }

        private void FillCB()
        {
            int i = 0;
            foreach (CBEntity e in cbeList)
            {
                cbFilter.Items.Insert(i++, e);
            }
        }

        public Filter FValue      // restricted Filter
        {
            get
            {
                Filter f = new Filter(); 
                if (Parent != null && SelectedCBEntity == null && (passThrough || cbFilter == null))
                {
                    foreach (CBEntity cbe in Parent.FValue.CBEList)
                    f.AddEntityChildren(cbe.Entity, false);
                }
                else if (SelectedCBEntity != null)
                {
                    f.AddEntity(SelectedCBEntity.Entity);
                }
                return f;
            }
        }

        public void UpdateCombo()
        {
            if (Parent == null) return; 
            if (this.IsDirty)
            {
                SelectedCBEntity = null;
                ClearCB();
                CBEList.Clear();
                if (Parent.SelectedCBEntity != null)
                {
                    this.AddEntityChildren(Parent.SelectedCBEntity.Entity, true);    // include non-unique
                    if (containsBangDim)
                    {
                        AddDefaultElement(Parent.SelectedCBEntity);
                    }
                }
                else if (this.UsesOrdinal)
                {
                    if (this.Ordinal < Parent.FValue.CBEList.Count)
                    {
                        this.AddEntityChildren(Parent.FValue.CBEList[this.Ordinal].Entity, true);
                        if (containsBangDim) AddDefaultElement(Parent.FValue.CBEList[this.Ordinal]);
                    }
                }
                else if (Parent.PassThrough || Parent.CBFilter == null)
                {
                    foreach (CBEntity en in Parent.FValue.CBEList)
                    {
                        this.AddEntityChildren(en.Entity, false);   // do not include non-unique
                    }
                    foreach (Filter f in children)
                    {
                        f.UpdateCombo();
                    }
                }
                this.IsDirty = false;
            }
        }

        public void UpdateSiblingCombos(Filter f)
        {
            if (f.Parent == null) return;
            foreach (Filter fc in f.Parent.children)
            {
                fc.UpdateCombo();
            }
        }

        public void UpdateChildren()
        {
            foreach (Filter fc in this.children)
            {
                fc.UpdateCombo();
            }
        }

        public ComboBox CBFilter
        {
            get { return cbFilter; }
            set
            {
                cbFilter = value;
                this.IsDirty = true;
                UpdateCombo();
                cbFilter.SelectedIndexChanged += new EventHandler(CBFSelectedIndexChanged);
                CBFilter.DropDown += new EventHandler(CBFDropDown);
                CBFilter.TextChanged += new EventHandler(CBFTextChanged);
            }
        }

        private void CBFSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbFilter.SelectedItem as CBEntity) != selectedCBEntity_cached) // Notice 'selectedCBEntity_cached' NOT 'SelectedCBEntity'
            {
                foreach (Filter f in children)
                {
                    f.IsDirty = true;
                }
            }
        }

        private void CBFDropDown(object sender, EventArgs e)
        {
            UpdateCombo();
        }

        private void CBFTextChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "")
            {
                this.IsDirty = true;
            }
            if (IsDirty)
            {
                UpdateCombo();
            }
        }
        
    }
}
