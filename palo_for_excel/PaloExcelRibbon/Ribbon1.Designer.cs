namespace PaloExcelRibbon
    {
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
            {
            InitializeComponent();
            }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.tabPalo = this.Factory.CreateRibbonTab();
            this.grpPalo = this.Factory.CreateRibbonGroup();
            this.btnModeller = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.btnPasteView = this.Factory.CreateRibbonButton();
            this.btnPasteElement = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.btnSaveSnapshot = this.Factory.CreateRibbonButton();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.btnAbout = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.tabPalo.SuspendLayout();
            this.grpPalo.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // tabPalo
            // 
            this.tabPalo.Groups.Add(this.grpPalo);
            this.tabPalo.Label = "Palo";
            this.tabPalo.Name = "tabPalo";
            // 
            // grpPalo
            // 
            this.grpPalo.Items.Add(this.btnModeller);
            this.grpPalo.Items.Add(this.separator1);
            this.grpPalo.Items.Add(this.btnPasteView);
            this.grpPalo.Items.Add(this.btnPasteElement);
            this.grpPalo.Items.Add(this.separator2);
            this.grpPalo.Items.Add(this.btnSaveSnapshot);
            this.grpPalo.Items.Add(this.separator3);
            this.grpPalo.Items.Add(this.btnAbout);
            this.grpPalo.Name = "grpPalo";
            // 
            // btnModeller
            // 
            this.btnModeller.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnModeller.Image = global::PaloExcelRibbon.Properties.Resources.Colored_Cube_32x32;
            this.btnModeller.Label = "Modeller";
            this.btnModeller.Name = "btnModeller";
            this.btnModeller.ShowImage = true;
            this.btnModeller.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnModeller_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // btnPasteView
            // 
            this.btnPasteView.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnPasteView.Image = global::PaloExcelRibbon.Properties.Resources.edit_paste_4;
            this.btnPasteView.Label = "Paste View";
            this.btnPasteView.Name = "btnPasteView";
            this.btnPasteView.ShowImage = true;
            this.btnPasteView.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPasteView_Click);
            // 
            // btnPasteElement
            // 
            this.btnPasteElement.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnPasteElement.Image = global::PaloExcelRibbon.Properties.Resources.gnome_planner_32;
            this.btnPasteElement.Label = "Paste Elements";
            this.btnPasteElement.Name = "btnPasteElement";
            this.btnPasteElement.ShowImage = true;
            this.btnPasteElement.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPasteElement_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // btnSaveSnapshot
            // 
            this.btnSaveSnapshot.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSaveSnapshot.Image = global::PaloExcelRibbon.Properties.Resources.document_save_as;
            this.btnSaveSnapshot.Label = "Snapshot";
            this.btnSaveSnapshot.Name = "btnSaveSnapshot";
            this.btnSaveSnapshot.ShowImage = true;
            this.btnSaveSnapshot.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSaveSnapshot_Click);
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // btnAbout
            // 
            this.btnAbout.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAbout.Image = global::PaloExcelRibbon.Properties.Resources.help_about_32x32;
            this.btnAbout.Label = "About Palo";
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ShowImage = true;
            this.btnAbout.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAbout_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.tabPalo);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tabPalo.ResumeLayout(false);
            this.tabPalo.PerformLayout();
            this.grpPalo.ResumeLayout(false);
            this.grpPalo.PerformLayout();

            }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabPalo;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpPalo;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnModeller;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPasteView;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPasteElement;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSaveSnapshot;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAbout;
        }

    partial class ThisRibbonCollection
        {
        internal Ribbon1 Ribbon1
            {
            get { return this.GetRibbon<Ribbon1>(); }
            }
        }
    }
