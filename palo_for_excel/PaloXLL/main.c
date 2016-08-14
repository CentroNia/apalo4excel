 /* 
 *
 * Copyright (C) 2006-2012 Jedox AG
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

//  Additional Revisions to Palo (c) Junction BI LLC:
//  JMM 09-20-13 For 5.0 library compatability

#include <ctype.h>
#include <windows.h>
#include <locale.h>
#include <stdlib.h>

#include "CTypes.h"

#include "xl.h"
#include "main.h"
#include "funcs.h"
#include "XLSpreadsheetFuncs.h"
#include "XLFuncsDoc.h"

#include "c2c_plus_plus.h"

// handles
HANDLE hInst;

short int doexecute;
short int enablederegister;
short int autoclosecalled;

XLOPER xDummy;
LPXLOPER xIDs;

size_t func_num  = 0;	
size_t func_num2  = 0;	

// library's main functions
// int FAR PASCAL Lib
int WINAPI DllMain(HANDLE hInstance, WORD wDataSeg, WORD wHeapSize, LPSTR lpszCmdLine) 
{
    hInst = hInstance;

	return 1;
}

short int set_recalc_handler()
{
	XLOPER xRes, xTemp;
	LPXLOPER xRecalc;

	short int retval = 1;

	// set recalculation handler
	xTemp.xltype=xltypeMissing;
	xRecalc = TempStr(FUNC_XL_NAME("RECALC_HANDLER"), NULL, 1);
	if(Excel4(xlcOnRecalc, (LPXLOPER)&xRes, 2, (LPXLOPER)&xTemp, xRecalc)!=0 
#ifdef __XLL_VERSION_4
		|| xRes.xltype!=xltypeBool || xRes.val.bool!=1) {
#else
		|| xRes.xltype!=xltypeBool || xRes.val.xbool!=1) {
#endif
			MessageBox(NULL, "Failed to set recalculation handler", "Error", MB_OK);
			retval = 0;
	}
	free_xloper(xRecalc, 1);

	return retval;
}

void Free_Oper_Array(size_t count, LPXLOPER* xArgs)
{
	size_t i;
	for (i=1; i < count; i++) {
		free_xloper(xArgs[i], 1);
	}
}

short int xlAutoOpen() 
{
	XLOPER name;
	unsigned int i, j, k; 
	LPXLOPER xArgs[64];
	const struct xl_func_decl *fd;

	doexecute = 1;
	enablederegister = 0;
	autoclosecalled = 0;
	xDummy.val.w = 0;
	xDummy.xltype = xltypeInt;

	//	JMM 09-30-13 Added for testing:
#ifdef _DEBUG
    //MessageBox(NULL, "Palo XLL Open.", "Palo XLL", MB_OK);
#endif

	// set recalculation handler
	if(set_recalc_handler() == 0) {
		return 0;
	}

	func_num = xl_funcs_get_func_num();

	if(func_num == (size_t)(-1)) {
		MessageBox(NULL, "Failed to initialize internal function registry.", "Palo XLL", MB_OK | MB_ICONERROR);
		func_num = 0;
	}

	func_num2 = func_num + FUNCNUM;

	xIDs = (LPXLOPER)calloc(func_num2, sizeof(XLOPER));

	Excel4(xlGetName,&name,0); // determine the DLL's name

	for(i = 0; i < FUNCNUM; i++) { // register provided functions
		for(j = 0; funcs[i][9+j]!=NULL; j++);

		xArgs[0] = (LPXLOPER)&name; // register ID
		xArgs[1] = TempStr(funcs[i][0], NULL, 0);	// function/procedure name (string or ordinal)
		xArgs[2] = TempStr(funcs[i][1], NULL, 0);	// parameter types as string
		xArgs[3] = TempStr(funcs[i][2], NULL, 0);	// function text (copied to preserve string for fUnregistration
		xArgs[4] = TempStr(funcs[i][3], NULL, 0);	// argument text
		xArgs[5] = TempStr(funcs[i][4], NULL, 0);	// function type
		xArgs[6] = TempStr(funcs[i][5], NULL, 0);	// Category
		xArgs[7] = TempStr(funcs[i][6], NULL, 0);	// Shortcut key
		xArgs[8] = TempStr(funcs[i][7], NULL, 0);   // help_topic
		xArgs[9] = TempStr(funcs[i][8], NULL, 0);   // function_help

		for(k = 0; k < j; ++k) {
			xArgs[10+k] = TempStr(funcs[i][9+k], NULL, 0);    // argument_help for argument k
		}

		if(Excel4v(xlfRegister, xIDs+i, 10+j,   // 10+j param's to be passed
				xArgs) != 0 || xIDs[i].xltype==xltypeErr)	{
				MessageBox(NULL, funcs[i][0], "Failed to register function!", MB_OK);
		}

		Free_Oper_Array(10+j, xArgs);
 	}


	for(i = 0; i < func_num; i++) { // register provided functions
		fd = xl_func_get_func(i);

		if(fd->is_xl_func) {
			xArgs[0] = (LPXLOPER)&name; // register ID
			
			for(k = 0; k < fd->count; ++k) {
				xArgs[1+k] = TempStr((char*)fd->a[k], NULL, 0);    // argument_help for argument k
			}

			j= i+FUNCNUM;
			if(Excel4v(xlfRegister, xIDs+j, (int)(1+fd->count),   // number of param's to be passed
				xArgs) != 0 || xIDs[j].xltype==xltypeErr) {
				MessageBox(NULL, fd->a[0], "Failed to register function!", MB_OK);
			}
			Free_Oper_Array(1+fd->count, xArgs);
		}
	}

	Excel4(xlFree, NULL, 1, &name);

	setlocale(LC_CTYPE, "");
		
	return 1;
}

short int xlAutoRemove() 
{
    // JMM 09-19-13
	// InfoLogging("xlAutoRemove called");
	enablederegister = 1;
	return 1;
}

void cleanup()
{
	size_t i;
	if (autoclosecalled && (xIDs != NULL)) {
		for (i=0; i < func_num2; i++) {
			Excel4(xlFree, NULL, 1, xIDs+i);
		}

		free(xIDs);
		xIDs = NULL;

		XLSpreadsheetFuncsCleanup();
	}
}


short int xlAutoClose() 
{
	size_t i;
	XLOPER xRes, xTemp;
	LPXLOPER xName;
	const struct xl_func_decl *fd;

	if (enablederegister) {
        // JMM 09-19-13
		//InfoLogging("Deregistering enabled");

		for(i=0; i<FUNCNUM; i++) {
			Excel4(xlfUnregister, NULL, 1, xIDs+i);
			xName = TempStr(funcs[i][2], NULL, 0);
			Excel4(xlfSetName, NULL, 1, xName);
			free_xloper(xName,1);
		}

		for(i=0; i<func_num; i++) {
			Excel4(xlfUnregister, NULL, 1, xIDs+(i+FUNCNUM));
			fd = xl_func_get_func(i);
			xName = TempStr((char*)fd->a[2], NULL, 0);
			Excel4(xlfSetName, NULL, 1, xName);
			free_xloper(xName,1);
		}

		/*  6753
		// reset recalculation handler
		if(Excel4(xlcOnRecalc, NULL, 0)!=0) {
			MessageBox(NULL, "Failed to reset recalculation handler", "Error", MB_OK);
			return 0;
		}
		*/
		xTemp.xltype=xltypeMissing;

		Excel4(xlcOnRecalc, (LPXLOPER)&xRes, 2, (LPXLOPER)&xTemp, (LPXLOPER)&xTemp);

		cleanup();
	}

	autoclosecalled = 1;

	return 1;
}

void free_xloper(LPXLOPER px, int free_oper)
{
	int i, len;

	switch (px->xltype & ~xlbitDLLFree) {
		case xltypeStr:
			free(px->val.str);
			px->val.str = NULL;
			break;
		case xltypeMulti:
			len = px->val.array.columns*px->val.array.rows;
			for(i=0; i<len; i++) {
				free_xloper(px->val.array.lparray+i, 0);
			}
			free(px->val.array.lparray);
			px->val.array.lparray = NULL;
			break;
		case xltypeRef:
			free(px->val.mref.lpmref);
			px->val.mref.lpmref = NULL;
			break;
	}

	if(free_oper!=0) {
		free(px);
		px = NULL;
	}
}

void WINAPI xlAutoFree(LPXLOPER px)
{
	free_xloper(px, 1);
}

void WINAPI xlAutoFree12(LPXLOPER px)
{
	free_xloper(px, 1);
}


LPXLOPER FUNC_ENTRY_POINT(cleanup)()
{
	cleanup();
	return TempBool( 1 );
}
