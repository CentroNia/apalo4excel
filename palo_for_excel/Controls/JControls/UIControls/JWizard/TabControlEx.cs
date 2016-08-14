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
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JControls
{
    #region WizardTabControl Class

    /// <summary>
    /// Summary description for WizardTabControl.
    /// </summary>
    [ToolboxBitmap(typeof(System.Windows.Forms.TabControl)),
    Designer(typeof(Designers.TabControlExDesigner))]
    public class WizardTabControl : HideTongue
    {

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public WizardTabControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call

        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public TabPage HotTab = null;

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }


        #endregion

        #region Properties

        [Editor(typeof(TabpageExCollectionEditor), typeof(UITypeEditor))]
        public new TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }


        #endregion

        #region TabpageExCollectionEditor

        internal class TabpageExCollectionEditor : CollectionEditor
        {
            public TabpageExCollectionEditor(System.Type type)
                : base(type)
            {
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(TabPageStep);
            }
        }

        #endregion

        #region Interop for SelectedIndexChanging event

        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR
        {
            public IntPtr HWND;
            public uint idFrom;
            public int code;
            public override String ToString()
            {
                return String.Format("Hwnd: {0}, ControlID: {1}, Code: {2}", HWND, idFrom, code);
            }
        }

        private const int TCN_FIRST = 0 - 550;
        private const int TCN_SELCHANGING = (TCN_FIRST - 2);

        private const int WM_USER = 0x400;
        private const int WM_NOTIFY = 0x4E;
        private const int WM_REFLECT = WM_USER + 0x1C00;

        #endregion

        #region SelectedIndexChanging event Implementation

   


        #endregion

        #region HotTab Immplementation

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
           // HotTab = TestTab(new Point(e.X, e.Y));
        }


        #endregion

        #region Custom Methods

        public void InsertTabPage(TabPage tabpage, int index)
        {
            if (index < 0 || index > TabCount)
                throw new ArgumentException("Index out of Range.");

            TabPages.Add(tabpage);

            if (index < TabCount - 1)
            {
                do
                    SwapTabPages(tabpage, (TabPages[TabPages.IndexOf(tabpage) - 1]));
                while (TabPages.IndexOf(tabpage) != index);
            }

            SelectedTab = tabpage;
        }


        public void SwapTabPages(TabPage tp1, TabPage tp2)
        {
            if (!TabPages.Contains(tp1) || !TabPages.Contains(tp2))
                throw new ArgumentException("TabPages must be in the TabCotrols TabPageCollection.");
            int Index1 = TabPages.IndexOf(tp1);
            int Index2 = TabPages.IndexOf(tp2);
            TabPages[Index1] = tp2;
            TabPages[Index2] = tp1;
        }


        private TabPage TestTab(Point pt)
        {
            for (int index = 0; index <= TabCount - 1; index++)
            {
                if (GetTabRect(index).Contains(pt.X, pt.Y))
                    return TabPages[index];
            }
            return null;
        }


        #endregion

    }

    #region SelectedIndexChanging EventArgs Class/Delegate

    public class TabControlExEventArgs : EventArgs
    {
        private TabPage m_TabPage = null;
        private int m_TabPageIndex = -1;
        public bool Cancel = false;

        public TabPage tabPage
        {
            get
            {
                return m_TabPage;
            }
        }


        public int TabPageIndex
        {
            get
            {
                return m_TabPageIndex;
            }
        }


        public TabControlExEventArgs(TabPage tabPage, int TabPageIndex)
        {
            m_TabPage = tabPage;
            m_TabPageIndex = TabPageIndex;
        }


    }


    public delegate void TabControlExEventHandler(Object sender, TabControlExEventArgs e);

    #endregion

    #endregion

    #region TabPageStep Class

    [Designer(typeof(System.Windows.Forms.Design.ScrollableControlDesigner))]
    public class TabPageStep : TabPage
    {
     

        #region Properties


        private bool show_back_button = true;
        [Category("JWizard"), Description("ShowBackButton")]
        public bool ShowBackButton {

            get { return show_back_button; }
            set { show_back_button = value; }
        }

        private bool show_next_button = true;
        [Category("JWizard"), Description("ShowNextButton")]
        public bool ShowNextButton
        {

            get { return show_next_button; }
            set { show_next_button = value; }
        }

        private bool show_finish_button = true;
        [Category("JWizard"), Description("ShowFinishButton")]
        public bool ShowFinishButton
        {

            get { return show_finish_button; }
            set { show_finish_button = value; }
        }
        #endregion

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public TabPageStep()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call

        }

        public TabPageStep(String Text)
            : base()
        {
            base.Text = Text;
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Disposed += new EventHandler(TabpageEx_Disposed);
        }


        #endregion

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
         
                base.OnPaintBackground(pevent);

        }


        private void SetTabBrush()
        {
           

        }


        private void TabpageEx_Disposed(Object sender, System.EventArgs e)
        {
           
        }


 





      

    }

    #endregion

}


namespace Designers
{

    internal class TabControlExDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {

        #region Private Instance Variables

        private DesignerVerbCollection m_verbs = new DesignerVerbCollection();
        private IDesignerHost m_DesignerHost;
        private ISelectionService m_SelectionService;

        #endregion

        public TabControlExDesigner()
            : base()
        {
            DesignerVerb verb1 = new DesignerVerb("Add Tab", new EventHandler(OnAddPage));
           // DesignerVerb verb2 = new DesignerVerb("Insert Tab", new EventHandler(OnInsertPage));
            DesignerVerb verb3 = new DesignerVerb("Remove Tab", new EventHandler(OnRemovePage));
            m_verbs.AddRange(new DesignerVerb[] { verb1,  verb3 });
        }


        #region Properties

        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (m_verbs.Count == 2)
                {
                    JControls.WizardTabControl MyControl = (JControls.WizardTabControl)Control;
                    if (MyControl.TabCount > 0)
                    {
                        m_verbs[1].Enabled = true;
                       // m_verbs[2].Enabled = true;
                    }
                    else
                    {
                        m_verbs[1].Enabled = false;
                        //m_verbs[2].Enabled = false;
                    }
                }
                return m_verbs;
            }
        }


        public IDesignerHost DesignerHost
        {
            get
            {
                if (m_DesignerHost == null)
                    m_DesignerHost = (IDesignerHost)(GetService(typeof(IDesignerHost)));

                return m_DesignerHost;
            }
        }


        public ISelectionService SelectionService
        {
            get
            {
                if (m_SelectionService == null)
                    m_SelectionService = (ISelectionService)(this.GetService(typeof(ISelectionService)));
                return m_SelectionService;
            }
        }


        #endregion

        void OnAddPage(Object sender, EventArgs e)
        {
            JControls.WizardTabControl ParentControl = (JControls.WizardTabControl)Control;
            Control.ControlCollection oldTabs = ParentControl.Controls;

            RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);

            JControls.TabPageStep P = (JControls.TabPageStep)(DesignerHost.CreateComponent(typeof(JControls.TabPageStep)));
            P.BackColor = Color.White;
            int tp = ParentControl.TabPages.Count + 1;
            P.Text = "Step" + tp.ToString();
            P.Tag = tp;
            P.Location = new System.Drawing.Point(4, 22);        
            P.Padding = new System.Windows.Forms.Padding(3);
            P.Size = new System.Drawing.Size(453, 257);
            
           
            ParentControl.TabPages.Add(P);

            RaiseComponentChanged(TypeDescriptor.GetProperties(ParentControl)["TabPages"], oldTabs, ParentControl.TabPages);
            ParentControl.SelectedTab = P;

            SetVerbs();

        }


        void OnInsertPage(Object sender, EventArgs e)
        {
            JControls.WizardTabControl ParentControl = (JControls.WizardTabControl)Control;
            Control.ControlCollection oldTabs = ParentControl.Controls;
            int Index = ParentControl.SelectedIndex;

            RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);

            JControls.TabPageStep P = (JControls.TabPageStep)(DesignerHost.CreateComponent(typeof(JControls.TabPageStep)));
            P.BackColor = Color.White;
            int tp = ParentControl.TabPages.Count + 1;
            P.Text = "Step" + tp.ToString();
            P.Location = new System.Drawing.Point(4, 22);
            P.Padding = new System.Windows.Forms.Padding(3);
            P.Size = new System.Drawing.Size(453, 257);

            JControls.TabPageStep[] tpc = new JControls.TabPageStep[ParentControl.TabCount];
            //Starting at our Insert Position, store and remove all the tabpages.
            for (int i = Index; i <= tpc.Length - 1; i++)
            {
                tpc[i] = (JControls.TabPageStep)ParentControl.TabPages[Index];
                ParentControl.TabPages.Remove(ParentControl.TabPages[Index]);
            }
            //add the tabpage to be inserted.
            ParentControl.TabPages.Add(P);
            //then re-add the original tabpages.
            for (int i = Index; i <= tpc.Length - 1; i++)
            {
                ParentControl.TabPages.Add(tpc[i]);
            }

            RaiseComponentChanged(TypeDescriptor.GetProperties(ParentControl)["TabPages"], oldTabs, ParentControl.TabPages);
            ParentControl.SelectedTab = P;

            SetVerbs();

        }


        void OnRemovePage(Object sender, EventArgs e)
        {
            JControls.WizardTabControl ParentControl = (JControls.WizardTabControl)Control;
            Control.ControlCollection oldTabs = ParentControl.Controls;

            if (ParentControl.SelectedIndex < 0) return;

            RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);

            DesignerHost.DestroyComponent(ParentControl.TabPages[ParentControl.SelectedIndex]);

            RaiseComponentChanged(TypeDescriptor.GetProperties(ParentControl)["TabPages"], oldTabs, ParentControl.TabPages);

            SelectionService.SetSelectedComponents(new IComponent[] { ParentControl }, SelectionTypes.Auto);

            SetVerbs();

        }


        private void SetVerbs()
        {
            JControls.WizardTabControl ParentControl = (JControls.WizardTabControl)Control;

            switch (ParentControl.TabPages.Count)
            {
                case 0:
                    Verbs[1].Enabled = false;
                    //Verbs[2].Enabled = false;
                    break;
                case 1:
                    Verbs[1].Enabled = false;
                   // Verbs[2].Enabled = true;
                    break;
                default:
                    Verbs[1].Enabled = true;
                    //Verbs[2].Enabled = true;
                    break;
            }
        }

        private const int WM_NCHITTEST = 0x84;

        private const int HTTRANSPARENT = -1;
        private const int HTCLIENT = 1;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
            {
                //select tabcontrol when Tabcontrol clicked outside of TabItem.
                if (m.Result.ToInt32() == HTTRANSPARENT)
                    m.Result = (IntPtr)HTCLIENT;
            }

        }

        private enum TabControlHitTest
        {
            TCHT_NOWHERE = 1,
            TCHT_ONITEMICON = 2,
            TCHT_ONITEMLABEL = 4,
            TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
        }

        private const int TCM_HITTEST = 0x130D;

        private struct TCHITTESTINFO
        {
            public Point pt;
            public TabControlHitTest flags;
        }

        protected override bool GetHitTest(Point point)
        {
            if (this.SelectionService.PrimarySelection == this.Control)
            {
                TCHITTESTINFO hti = new TCHITTESTINFO();

                hti.pt = this.Control.PointToClient(point);
                hti.flags = 0;

                Message m = new Message();
                m.HWnd = this.Control.Handle;
                m.Msg = TCM_HITTEST;

                IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(hti));
                Marshal.StructureToPtr(hti, lparam, false);
                m.LParam = lparam;

                base.WndProc(ref m);
                Marshal.FreeHGlobal(lparam);

                if (m.Result.ToInt32() != -1)
                    return hti.flags != TabControlHitTest.TCHT_NOWHERE;

            }

            return false;
        }


        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            //Don't want DrawGrid dots.
        }


        //Fix the AllSizable selectiorule on DockStyle.Fill
        public override System.Windows.Forms.Design.SelectionRules SelectionRules
        {
            get
            {
                if (Control.Dock == DockStyle.Fill)
                    return System.Windows.Forms.Design.SelectionRules.Visible;
                return base.SelectionRules;
            }
        }


    }

}
