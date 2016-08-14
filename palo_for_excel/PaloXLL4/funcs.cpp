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

#include "funcs.h"

extern "C" short int doexecute;

XLOPERX xDummy;

#define FUNC_DEFINITION( xl_name, spreadsheetfuncs_name, num_args, allow_error) \
	extern "C" LPXLOPERX FUNC_ENTRY_POINT_BASE( xl_name )( XL_ARG_DECL ) { \
		return ( doexecute || (num_args > -1) ) ? SpreadsheetFuncsWrapper( &XLSpreadsheetFuncs::getInstance(), XLSpreadsheetFuncs::getInstance().getSettings(), &XLSpreadsheetFuncs::spreadsheetfuncs_name )( num_args, allow_error, XL_ARG_PASS ) : &xDummy; \
	}

using namespace Palo::XLL;

#include "funcs_decl.h.h"

FUNC_DEFINITION( palo_close_connections, FPaloCloseConnections, 0, false )
FUNC_DEFINITION( palo_enable_loop, FPaloEnableLoop, 1, false )
FUNC_DEFINITION( palo_enable_undo_coloring, FPaloEnableUndoColoring, 1, false )
FUNC_DEFINITION( palo_error_info, FPaloError, 0, false )
FUNC_DEFINITION( palo_clear_errors, FPaloClearErrors, 0, false )
FUNC_DEFINITION( palo_calc_sheet, FPaloCalcSheet, 0, false )
FUNC_DEFINITION( palo_recalc_handler, FPaloRecalcHandler, 0, false )
FUNC_DEFINITION( palo_set_recalc_handler, FPaloSetRecalcHandler, 0, false )
FUNC_DEFINITION( palo_connection_user, FPaloConnectionUser, 1, false )
FUNC_DEFINITION( palo_user_groups, FPaloGetGroups, 1, false )
