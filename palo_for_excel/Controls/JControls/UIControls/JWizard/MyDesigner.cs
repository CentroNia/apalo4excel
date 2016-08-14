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
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace JControls
{
    internal class MyUCDesigner : ControlDesigner
    {
        private DesignerActionListCollection alColletion;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (alColletion == null)
                {
                    alColletion = new DesignerActionListCollection();
                    alColletion.Add(new MyUCDesignerActionList((TabControlWizard)Control));
                }

                return alColletion;
            }
        }
    }

    internal class MyUCDesignerActionList : DesignerActionList
    {
        private TabControlWizard myUserControl;

        public MyUCDesignerActionList(TabControlWizard control)
            : base(control)
        {
            myUserControl = control;
            this.AutoShow = true;
        }

     

        private PropertyDescriptor GetPropertyByName(String propertyName)
        {
            PropertyDescriptor pDescriptor;
            pDescriptor = TypeDescriptor.GetProperties(myUserControl)[propertyName];

            if (pDescriptor == null)
                throw new ArgumentException("Matching property not found!", propertyName);
            else return pDescriptor;
        }

        private void InsertNewPage()
        {
            IComponentChangeService ICCS = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            IDesignerHost IDH = (IDesignerHost)GetService(typeof(IDesignerHost));
           
            TabPage tb;
            
            DesignerTransaction dTransaction = IDH.CreateTransaction("Add Tab");

            int i = myUserControl.tcMain.TabPages.Count +1;
            tb = (TabPage)IDH.CreateComponent(typeof(TabPage));

            ICCS.OnComponentChanging(myUserControl, null);

            tb.BackColor = System.Drawing.Color.White;

            tb.Location = new System.Drawing.Point(4, 22);
            tb.Name = "tbStep" + i.ToString();
            tb.Padding = new System.Windows.Forms.Padding(3);
            tb.Size = new System.Drawing.Size(453, 257);
            tb.TabIndex = i - 1;
            tb.Tag = i.ToString();
            tb.Text = "Step" + i.ToString();

            


            myUserControl.tcMain.Controls.Add(tb);
            myUserControl.tcMain.SelectTab(tb);

            ICCS.OnComponentChanged(myUserControl, null, null, null);
            dTransaction.Commit();
        }

        private void DeletePage()
        {
            IComponentChangeService ICCS = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            IDesignerHost IDH = (IDesignerHost)GetService(typeof(IDesignerHost));
            DesignerTransaction dTransaction = IDH.CreateTransaction("Delete Tab");

            int i = myUserControl.tcMain.TabPages.Count -1;

            if (i > -1)
            {

                myUserControl.tcMain.TabPages.RemoveAt(i);
                if(i>0)
                  myUserControl.tcMain.SelectTab(i - 1);


                ICCS.OnComponentChanged(myUserControl, null, null, null);
                dTransaction.Commit();
            }
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection itemCollection = new DesignerActionItemCollection();

            itemCollection.Add(new DesignerActionHeaderItem("Actions"));
            //itemCollection.Add(new DesignerActionHeaderItem("Appearance"));

            //itemCollection.Add(new DesignerActionPropertyItem("ToolStripBackColor",
                            // "ToolStrip Back Color", "Appearance", null));

            itemCollection.Add(new DesignerActionMethodItem(this,
                                 "InsertNewPage", "Add Tab",
                                 "Actions", null, true));
            itemCollection.Add(new DesignerActionMethodItem(this,
                                 "DeletePage", "Delete Tab",
                                 "Actions", null, true));


            return itemCollection;
        }
    }
}
