using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Runtime.InteropServices;
using Apalo.CommonInterfaces;

namespace PaloExcelRibbon
    {
    public partial class Ribbon1
        {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
            {

            }

        private void btnModeller_Click(object sender, RibbonControlEventArgs e)
            {
            if (ExcelUIFunctions.Common.GetPalo())
                ExcelUIFunctions.Common.PaloConnect.ShowModeller();                
            }

        private void btnPasteView_Click(object sender, RibbonControlEventArgs e)
            {
            if (ExcelUIFunctions.Common.GetPalo())
                ExcelUIFunctions.Common.PaloConnect.DoPasteView();
            }

        private void btnPasteElement_Click(object sender, RibbonControlEventArgs e)
            {
            if (ExcelUIFunctions.Common.GetPalo())
                ExcelUIFunctions.Common.PaloConnect.DoPasteElement();
            }

        private void btnSaveSnapshot_Click(object sender, RibbonControlEventArgs e)
            {
            if (ExcelUIFunctions.Common.GetPalo())
                ExcelUIFunctions.Common.PaloConnect.SaveSnapshot();
            }

        private void btnAbout_Click(object sender, RibbonControlEventArgs e)
            {
            if (ExcelUIFunctions.Common.GetPalo())
                ExcelUIFunctions.Common.PaloConnect.DisplayInfoBox();
            }
        }
    }
