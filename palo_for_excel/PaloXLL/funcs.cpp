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

#include "SpreadsheetFuncsWrapper.h"

#include "xl.h"
#include "funcs.h"

extern "C" short int doexecute;

#define XL_ARG_PASS o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16, o17, o18, o19, o20, o21, o22, o23, o24, o25, o26, o27, o28, o29

#ifdef __XLL_VERSION_4
	#define XL_ARG_DECL LPXLOPER o1, LPXLOPER o2, LPXLOPER o3, LPXLOPER o4, LPXLOPER o5, LPXLOPER o6, LPXLOPER o7, LPXLOPER o8, LPXLOPER o9, LPXLOPER o10, LPXLOPER o11, LPXLOPER o12, LPXLOPER o13, LPXLOPER o14, LPXLOPER o15, LPXLOPER o16, LPXLOPER o17, LPXLOPER o18, LPXLOPER o19, LPXLOPER o20, LPXLOPER o21, LPXLOPER o22, LPXLOPER o23, LPXLOPER o24, LPXLOPER o25, LPXLOPER o26, LPXLOPER o27, LPXLOPER o28, LPXLOPER o29
	#define XL_RET_TYPE LPXLOPER
	#define EXCEL_TYPE Excel4Types
extern "C" XLOPER xDummy;
#else
	#define XL_ARG_DECL LPXLOPER12 o1, LPXLOPER12 o2, LPXLOPER12 o3, LPXLOPER12 o4, LPXLOPER12 o5, LPXLOPER12 o6, LPXLOPER12 o7, LPXLOPER12 o8, LPXLOPER12 o9, LPXLOPER12 o10, LPXLOPER12 o11, LPXLOPER12 o12, LPXLOPER12 o13, LPXLOPER12 o14, LPXLOPER12 o15, LPXLOPER12 o16, LPXLOPER12 o17, LPXLOPER12 o18, LPXLOPER12 o19, LPXLOPER12 o20, LPXLOPER12 o21, LPXLOPER12 o22, LPXLOPER12 o23, LPXLOPER12 o24, LPXLOPER12 o25, LPXLOPER12 o26, LPXLOPER12 o27, LPXLOPER12 o28, LPXLOPER12 o29
	#define XL_RET_TYPE LPXLOPER12
	#define EXCEL_TYPE Excel12Types
extern "C" XLOPER12 xDummy;
#endif

#define FUNC_DEFINITION_CALL( spreadsheetfuncs_name, num_args, allow_error) \
		SpreadsheetFuncsWrapper<EXCEL_TYPE>( &XLSpreadsheetFuncs<EXCEL_TYPE>::getInstance(), XLSpreadsheetFuncs<EXCEL_TYPE>::getInstance().getSettings(), &XLSpreadsheetFuncs<EXCEL_TYPE>::spreadsheetfuncs_name )( num_args, allow_error, XL_ARG_PASS );

#define FUNC_DEFINITION( xl_name, spreadsheetfuncs_name, num_args, allow_error) \
	extern "C" XL_RET_TYPE FUNC_ENTRY_POINT_BASE( xl_name )( XL_ARG_DECL ) { \
		/*XLFUNC_CRASH_GUARD()*/ \
		return ( doexecute || (num_args > -1) ) ? SpreadsheetFuncsWrapper<EXCEL_TYPE>( &XLSpreadsheetFuncs<EXCEL_TYPE>::getInstance(), XLSpreadsheetFuncs<EXCEL_TYPE>::getInstance().getSettings(), &XLSpreadsheetFuncs<EXCEL_TYPE>::spreadsheetfuncs_name )( num_args, allow_error, XL_ARG_PASS ) : &xDummy; \
	}

using namespace Palo::XLL;

#include "funcs_decl.h.h"

FUNC_DEFINITION( palo_close_connections, FPaloCloseConnections, 0, false )
FUNC_DEFINITION( palo_enable_loop, FPaloEnableLoop, 1, false )
FUNC_DEFINITION( palo_enable_undo_coloring, FPaloEnableUndoColoring, 1, false )
FUNC_DEFINITION( palo_error_info, FPaloError, 0, false )
FUNC_DEFINITION( palo_calc_sheet, FPaloCalcSheet, 0, false )
FUNC_DEFINITION( palo_recalc_handler, FPaloRecalcHandler, 0, false )
FUNC_DEFINITION( palo_set_recalc_handler, FPaloSetRecalcHandler, 0, false )
FUNC_DEFINITION( palo_connection_user, FPaloConnectionUser, 1, false )
FUNC_DEFINITION( palo_user_groups, FPaloGetGroups, 1, false )

