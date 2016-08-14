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

#ifndef PALO_SPREADSHEET_FUNCS_WRAPPER
#define PALO_SPREADSHEET_FUNCS_WRAPPER

#include <PaloSpreadsheetFuncs\Wrapper.h>

#include "XLSpreadsheetFuncs.h"

namespace Palo {
	namespace XLL {

		class XLSpreadsheetFuncs;
		class SpreadsheetFuncsWrapper : public Wrapper< XLSpreadsheetFuncs> {
		public:
			SpreadsheetFuncsWrapper( XLSpreadsheetFuncs* thisptr, GenericContext& opts, void( XLSpreadsheetFuncs::*p )( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) );

			LPXLOPERX operator()( size_t count, bool allow_error, XL_ARG_DECL ) throw();
		};
	}
}
#endif
