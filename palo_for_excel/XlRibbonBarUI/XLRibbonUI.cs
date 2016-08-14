using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace ApaloExcelRibbon
{
[ComVisible(true)]
[GuidAttribute("32CA476C-AF52-4125-AB39-9667EBBDB9E4"), ProgId("Apalo.XlAddin.RibbonUI")]
public class XLRibbonUI : Extensibility.IDTExtensibility2, Office.IRibbonExtensibility
	{
	private Excel.Application excelApp;
	private Office.IRibbonUI ribbon;

	#region Excel/Office Interface Functions
	/// <summary>
	///  Loads the XML markup, either from an XML customization file or from XML markup
	/// embedded in the procedure, that customizes the Ribbon user interface.
	/// </summary>
	/// <param name="RibbonID">The ID for the RibbonX UI.</param>
	/// <returns>XML String</returns>
	public string GetCustomUI(string RibbonID)
		{
		return ApaloExcelRibbon.Properties.Resources.XlRibbon;
		}

	public void OnAddInsUpdate(ref Array custom)
		{
		}

	public void OnBeginShutdown(ref Array custom)
		{
		}

	public void OnConnection(object Application, Extensibility.ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
		{
		#if DEBUG
		//System.Windows.Forms.MessageBox.Show("Loading Apalo Excel Ribbon UI", "Debug");
		#endif
		excelApp = (Excel.Application)Application;
		ExcelUIFunctions.Init(excelApp);
		}

	public void OnDisconnection(Extensibility.ext_DisconnectMode RemoveMode, ref Array custom)
		{
		if (ExcelUIFunctions.Common != null)
			ExcelUIFunctions.Common.Dispose();
		}

	public void OnStartupComplete(ref Array custom)
		{
		}

	public void Ribbon_Load(Office.IRibbonUI ribbonUI)
		{
		this.ribbon = ribbonUI;
		}

	#endregion


	#region UI Events
	public void btnModeller_Click(Office.IRibbonControl c)
		{
		if (ExcelUIFunctions.Common.GetPalo())
			ExcelUIFunctions.Common.PaloConnect.ShowModeller();
		}

	public void btnPasteView_Click(Office.IRibbonControl c)
		{
		if (ExcelUIFunctions.Common.GetPalo())
			ExcelUIFunctions.Common.PaloConnect.DoPasteView();
		}

	public void btnPasteElement_Click(Office.IRibbonControl c)
		{
		if (ExcelUIFunctions.Common.GetPalo())
			ExcelUIFunctions.Common.PaloConnect.DoPasteElement();
		}
        
	public void btnPasteSubset_Click(Office.IRibbonControl c)
		{
		if (ExcelUIFunctions.Common.GetPalo())
			ExcelUIFunctions.Common.PaloConnect.DoPasteSubset();
		}

	public void btnSaveSnapshot_Click(Office.IRibbonControl ce)
		{
		if (ExcelUIFunctions.Common.GetPalo())
			ExcelUIFunctions.Common.PaloConnect.SaveSnapshot();
		}

	public void btnAbout_Click(Office.IRibbonControl c)
		{
		if (ExcelUIFunctions.Common.GetPalo())
			ExcelUIFunctions.Common.PaloConnect.DisplayInfoBox();
		}
	#endregion


	#region Helper Functons to Supply UI Elements
	/// <summary>
	/// Returns image for a ribbon element
	/// </summary>
	/// <param name="imageName"></param>
	/// <returns></returns>
	public stdole.IPictureDisp GetImage(string imageName)
		{
		Image i = null;
		switch (imageName)
			{
			case "btnModeller":
				i = Properties.Resources.Colored_Cube_32;
				break;
			case "btnPasteView":
				i = Properties.Resources.Edit_Paste_32;
				break;
			case "btnPasteElement":
				i = Properties.Resources.Gnome_Planner_32;
				break;
            case "btnPasteSubset":
                i = Properties.Resources.subset_icon_32x32;
                break;
			case "btnSaveSnapshot":
				i = Properties.Resources.Document_Save_As_32;
				break;
			case "btnAbout":
				i = Properties.Resources.Help_About_32;
				break;
			}
		return PictureConverter.ImageToPictureDisp(i ?? new System.Drawing.Bitmap(32, 32));
		}

	/// <summary>
	/// Supplies images for ribbon elements
	/// </summary>
	internal class PictureConverter : AxHost
		{
		private PictureConverter() : base(String.Empty) { }

		static public stdole.IPictureDisp ImageToPictureDisp(Image image)
			{
			return (stdole.IPictureDisp)GetIPictureDispFromPicture(image);
			}

		static public stdole.IPictureDisp IconToPictureDisp(Icon icon)
			{
			return ImageToPictureDisp(icon.ToBitmap());
			}

		static public Image PictureDispToImage(stdole.IPictureDisp picture)
			{
			return GetPictureFromIPicture(picture);
			}
		}
	#endregion
	}
}
