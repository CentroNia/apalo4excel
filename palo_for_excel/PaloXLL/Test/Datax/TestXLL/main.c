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

#include <locale.h>

#include "xl.h"

#define XL_ARG_DECL LPXLOPER12 o1, LPXLOPER12 o2, LPXLOPER12 o3, LPXLOPER12 o4, LPXLOPER12 o5, LPXLOPER12 o6, LPXLOPER12 o7, LPXLOPER12 o8, LPXLOPER12 o9, LPXLOPER12 o10, LPXLOPER12 o11, LPXLOPER12 o12, LPXLOPER12 o13, LPXLOPER12 o14, LPXLOPER12 o15, LPXLOPER12 o16, LPXLOPER12 o17, LPXLOPER12 o18, LPXLOPER12 o19, LPXLOPER12 o20, LPXLOPER12 o21, LPXLOPER12 o22, LPXLOPER12 o23, LPXLOPER12 o24, LPXLOPER12 o25, LPXLOPER12 o26, LPXLOPER12 o27, LPXLOPER12 o28, LPXLOPER12 o29

// handles
HANDLE hInst;

LPXLOPER12 xIDs;

size_t func_num  = 2;

// library's main functions
// int FAR PASCAL Lib
int WINAPI DllMain(HANDLE hInstance, WORD wDataSeg, WORD wHeapSize, LPSTR lpszCmdLine) 
{
    hInst = hInstance;

	return 1;
}

void free_xloper(LPXLOPER12 px, int free_oper)
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

	if (free_oper != 0) {
		free(px);
		px = NULL;
	}

}


void Free_Oper_Array(size_t count, LPXLOPER12* xArgs)
{
	size_t i;
	for (i=1; i < count; i++) {
		free_xloper(xArgs[i], 1);
	}
}

short int xlAutoOpen() 
{
	XLOPER12 name;
	int i, num_arg; 
	LPXLOPER12 xArgs[64];

	xIDs = (LPXLOPER12)calloc(func_num, sizeof(XLOPER12));

	Excel12(xlGetName,&name,0); // determine the DLL's name
	xArgs[0] = (LPXLOPER12)&name; // register ID

	//TPALO.ENAME
	num_arg = 13;
	xArgs[1] = TempStr((LPSTR)"xll_tpalo_ename", 0);
	xArgs[2] = TempStr((LPSTR)"UUUUUUUUUUUUUUUUUUUUUUUUUUUUUU!", 0);
	xArgs[3] = TempStr((LPSTR)"TPALO.ENAME", 0);
	xArgs[4] = TempStr((LPSTR)"Server/Database, Dimension, Index", 0);
	xArgs[5] = TempStr((LPSTR)"1", 0);
	xArgs[6] = TempStr((LPSTR)"TPALO", 0);
	xArgs[7] = TempStr((LPSTR)"", 0);
	xArgs[8] = TempStr((LPSTR)"", 0);
	xArgs[9] = TempStr((LPSTR)"Returns the value of a cell from the cube only if the function is on the active sheet.", 0);
	xArgs[10] = TempStr((LPSTR)"Server/Database", 0);
	xArgs[11] = TempStr((LPSTR)"Name of the dimension.", 0);
	xArgs[12] = TempStr((LPSTR)"Index number, that specifies the position of the element in the dimension", 0);

	if (Excel12v(xlfRegister, xIDs, num_arg, xArgs) != 0 || xIDs->xltype==xltypeErr) {
				MessageBox(NULL, "xll_tpalo_ename", "Failed to register function!", MB_OK);
	}
	Free_Oper_Array(num_arg, xArgs);


	//TPALO.DATAX
	num_arg = 28;
	xArgs[1] = TempStr((LPSTR)"xll_tpalo_datax", 0);
	xArgs[2] = TempStr((LPSTR)"UUUUUUUUUUUUUUUUUUUUUUUUUUUUUU!#", 0);
	xArgs[3] = TempStr((LPSTR)"TPALO.DATAX", 0);
	xArgs[4] = TempStr((LPSTR)"Server/Database, Cube, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate, Coordinate", 0);
	xArgs[5] = TempStr((LPSTR)"1", 0);
	xArgs[6] = TempStr((LPSTR)"TPALO", 0);
	xArgs[7] = TempStr((LPSTR)"", 0);
	xArgs[8] = TempStr((LPSTR)"", 0);
	xArgs[9] = TempStr((LPSTR)"Returns the name of the element with the positionnumber INDEX (First element has positionnumber 1)", 0);
	xArgs[10] = TempStr((LPSTR)"Server/Database", 0);
	xArgs[11] = TempStr((LPSTR)"Cube", 0);

	for (i = 12; i < 28; i++) {
		xArgs[i] = TempStr((LPSTR)"Index number, that specifies the position of the element in the dimension", 0);
	}



	if (Excel12v(xlfRegister, xIDs, num_arg, xArgs) != 0 || xIDs->xltype==xltypeErr) {
				MessageBox(NULL, "xll_tpalo_datax", "Failed to register function!", MB_OK);
	}
	Free_Oper_Array(num_arg, xArgs);

	Excel12(xlFree, NULL, 1, &name);

	setlocale(LC_CTYPE, "");
		
	return 1;

}

short int xlAutoClose() 
{
	LPXLOPER12 xName;

	Excel12(xlfUnregister, NULL, 1, xIDs);
	xName = TempStr((LPSTR)"TPALO.ENAME", 0);
	Excel12(xlfSetName, NULL, 1, xName);
	free_xloper(xName,1);
	Excel12(xlFree, NULL, 1, xIDs);

	Excel12(xlfUnregister, NULL, 1, xIDs+1);
	xName = TempStr((LPSTR)"TPALO.DATAX", 0);
	Excel12(xlfSetName, NULL, 1, xName);
	free_xloper(xName,1);
	Excel12(xlFree, NULL, 1, xIDs+1);

	free(xIDs);

	return 1;
}


void WINAPI xlAutoFree12(LPXLOPER12 px)
{
	free_xloper(px, 1);
}


LPXLOPER12 xll_tpalo_ename( XL_ARG_DECL ) { 
	return TempStr((LPSTR)"Dummy", 1);
}

LPXLOPER12 xll_tpalo_datax( XL_ARG_DECL ) { 
	LPXLOPER12 return_value = (LPXLOPER12)calloc(1, sizeof( XLOPER12 ));
	return_value->xltype = xltypeNum | xlbitDLLFree;
	return_value->val.num = 5.25;
	return return_value;
}
