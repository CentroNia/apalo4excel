/*
 *	Apalo.CommonInterfaces.IPaloConnect class - Access to Palo Add-In functions
 *
 *	(c) 2014 Junction BI LLC
 *
 *	Revision History -
 *
 *	03/29/14 JMM Initial Version
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Apalo.CommonInterfaces
{
/// <summary>
/// Provides an interface for access to Palo Add-In functions through VSTO
/// </summary>
public interface IPaloConnect
	{
	/// <summary>Display the modeller</summary>
	void ShowModeller();

	/// <summary>Perform paste View</summary>
	void DoPasteView();

	/// <summary>Perform paste element</summary>
	void DoPasteElement();
    
	/// <summary>Perform paste subset</summary>
	void DoPasteSubset();

	/// <summary>Save as snapshot</summary>
	void SaveSnapshot();

	/// <summary>Display add-in information</summary>
	void DisplayInfoBox();
	}
}
