/*
 *	PaloExcelRibbon.ExcelUIFunctions class - User Interface functionality for Excel
 *
 *	(c) 2014 Junction BI LLC
 *
 *	Revision History -
 *
 *	03/29/14 JMM Initial Version
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Apalo.CommonInterfaces;

namespace ApaloExcelRibbon
{
/// <summary>
/// Provides user interface functionality for the Excel Add-In
/// </summary>
internal class ExcelUIFunctions : IDisposable
	{
	/// <summary>Common access controller for an application.</summary>
	public static ExcelUIFunctions Common
		{get; private set;}

	/// <summary>The Excel application object.</summary>
	public Excel.Application ExcelApp;

	/// <summary>This is the PALO COM object and type.</summary>
	public object Palo;
	public IPaloConnect PaloConnect;

	/// <summary>Static initialization.</summary>
	public static void Init(Excel.Application ExcelApp)
		{
		Common = new ExcelUIFunctions(ExcelApp);
		}

	/// <summary>
	/// Constructor
	/// </summary>
	public ExcelUIFunctions(Excel.Application XlApp)
		{
		ExcelApp = XlApp;
		}

	///
	/// <summary>
	/// Destructor
	/// </summary>
	///
	~ExcelUIFunctions()
		{
		Dispose(false);
		}

	///
	/// <summary>
	/// Dispose the object.
	/// </summary>
	///
	public void Dispose()
		{
		Dispose(true);
		GC.SuppressFinalize(this);
		}

	/// <summary>
	/// Dispose function
	/// </summary>
	/// <param name="Disposing"></param>
	protected virtual void Dispose(bool Disposing)
		{
		if (Disposing)
			{
			if (Palo != null && Palo is IDisposable)
				{
				((IDisposable)Palo).Dispose();
				Palo = null;
				PaloConnect = null;
				}
			}
		}

	/// <summary>
	/// Gets access to the PALO connector
	/// </summary>
	/// <returns></returns>
	public bool GetPalo()
		{
		if (Palo == null)
			{
			try
				{
				Office.COMAddIn PaloCom = ExcelApp.COMAddIns.Item("Apalo.XlAddin.Connect");
				if (PaloCom.Connect)
					{
					Palo = PaloCom.Object;
					PaloConnect = (IPaloConnect)Palo;
					}
				}
			catch (Exception)
				{
				return false;
				}
			}
		return PaloConnect != null;
		}

	}
}
