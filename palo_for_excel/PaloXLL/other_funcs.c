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
 * Marek Pikulski <marek.pikulski@jedox.com>
 * Dominik Danehl <dominik.danehl@jedox.com>
 *
 */


#include <stdio.h>
#include <assert.h>
#include <string.h>

#include <windows.h>


#include "CTypes.h"

#include "xl.h"
#include "funcs.h"

extern short int doexecute;

LPXLOPER FUNC_ENTRY_POINT(prepare_snapshot)()
{
	int i, len, iLastRow, iLastColumn;
	XLOPER xWorkbook, xWorksheetName, xWorksheet, xRef, xRef2;
	XLMREF xlmref;

	Excel4(xlfGetWorkbook, (LPXLOPER)&xWorkbook, 1, TempNum(1));
	xWorksheetName.xltype = xltypeStr;

	len = xWorkbook.val.array.columns;

	for(i=0; i<len; i++)
	{
		// Aktuelles Blatt setzen
		xWorksheetName.val.str = xWorkbook.val.array.lparray[i].val.str; 
		
		Excel4(xlSheetId, &xRef2, 1, (LPXLOPER)&xWorksheetName);
		xRef.val.mref.idSheet = xRef2.val.mref.idSheet;
		Excel4(xlFree, NULL, 1, (LPXLOPER)&xRef2);
		xRef.xltype = xltypeRef;
		xRef.val.mref.lpmref = (LPXLMREF)&xlmref;	

		// LastRow
		Excel4(xlfGetDocument, (LPXLOPER)&xWorksheet, 2, TempNum(10), (LPXLOPER)&xWorksheetName);
		iLastRow = (int)xWorksheet.val.num;
		Excel4(xlFree, NULL, 1, (LPXLOPER)&xWorksheet);

		// LastColumn
		Excel4(xlfGetDocument, (LPXLOPER)&xWorksheet, 2, TempNum(12), (LPXLOPER)&xWorksheetName);
		iLastColumn = (int)xWorksheet.val.num;		
		Excel4(xlFree, NULL, 1, (LPXLOPER)&xWorksheet);
		
		if(iLastColumn > 0 && iLastRow > 0)
		{
			// Referenz erstellen
			xlmref.count = 1;
			xlmref.reftbl[0].rwFirst	= 0;
			xlmref.reftbl[0].colFirst	= 0;
			xlmref.reftbl[0].rwLast		= iLastRow-1;
			xlmref.reftbl[0].colLast	= iLastColumn-1;		
		
			// Werte setzen
			Excel4(xlSet, 0, 2, (LPXLOPER)&xRef, (LPXLOPER)&xRef);
		}
	}
	Excel4(xlFree, NULL, 1, (LPXLOPER)&xWorkbook);
	return TempBool(1);
}

LPXLOPER FUNC_ENTRY_POINT(write_array)(LPXLOPER xArg, LPXLOPER xRows, LPXLOPER xWriteRow)
{
	int row, rows, iWriteRow = 0;
	XLOPER xTempRef, xTempA, xA;
	
	if(get_xl_args(1, XL_ARG_INT, xRows, &rows) != XL_SUCCESS) {
		return NULL;
	}

	if(Excel4(xlCoerce, (LPXLOPER)&xA, 1, xArg)!=xlretSuccess) {
		return NULL;
	}

	if(xA.xltype!=xltypeMulti) {
		Excel4(xlFree, 0, 1, (LPXLOPER)&xA);
		return NULL;
	}
	
	if (xWriteRow->xltype == xltypeNum) {
		iWriteRow = (int)xWriteRow->val.num;
	}
	
	xTempRef.xltype=xltypeSRef;
	xTempRef.val.sref.count=1;
	xTempRef.val.sref.ref.colFirst=0;
	xTempRef.val.sref.ref.rwFirst=iWriteRow;
	xTempRef.val.sref.ref.colLast=xA.val.array.columns-1;
	xTempRef.val.sref.ref.rwLast=iWriteRow;
	
	xTempA=xA;
	xTempA.val.array.rows=1;

	for(row=0; row<min(xA.val.array.rows, rows); row++) {
		xTempA.val.array.lparray=xA.val.array.lparray+row*xA.val.array.columns;

		if(Excel4(xlSet, NULL, 2, (LPXLOPER)&xTempRef, (LPXLOPER)&xTempA)!=xlretSuccess) {
			Excel4(xlFree, 0, 1, (LPXLOPER)&xA);
			return NULL;
		}

		if(Excel4(xlcCalculateDocument, NULL, 0)!=xlretSuccess) {
			Excel4(xlFree, 0, 1, (LPXLOPER)&xA);
			return NULL;
		}
	}
	

	Excel4(xlFree, 0, 1, (LPXLOPER)&xA);

	return TempBool(1);
}

LPXLOPER FUNC_ENTRY_POINT(excel_open)(LPXLOPER xPath, LPXLOPER xShowErrorPopup)
{
	static XLOPER xRes, xLinks;
	const char *basemesg = "Open of %s failed with rc = %i";
	int ret = xlretSuccess;
	short int show = 0;

	xLinks.xltype = xltypeInt;
	xLinks.val.w = 0;

	get_bool(xShowErrorPopup, &show);

	ret = Excel4(xlcOpen , (LPXLOPER)&xRes, 2, xPath, (LPXLOPER)&xLinks);

	if ((ret != xlretSuccess) && (show != 0)) {
		char *path = get_string(xPath);
		size_t len = strlen(basemesg) + strlen(path);
		char *mesg = malloc(len * sizeof(char));
		if (mesg == NULL) {
			MessageBox(NULL, "Memory allocation failed !", "Palo XLL", MB_OK | MB_ICONERROR);
		} else {
			_snprintf(mesg, len, basemesg, path, ret);
			MessageBox(NULL, mesg, "Palo XLL", MB_OK | MB_ICONERROR);
			free(mesg);
		}
		free(path);
	}

	xRes.xltype |= xlbitXLFree;

	return (LPXLOPER)&xRes;
}

LPXLOPER FUNC_ENTRY_POINT(enable_xll)(LPXLOPER xEnable)
{
	get_bool(xEnable, &doexecute);
	return TempBool( (int)doexecute );
}
