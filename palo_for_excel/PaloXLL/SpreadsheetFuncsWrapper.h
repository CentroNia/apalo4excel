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

#ifndef PALO_SPREADSHEET_FUNCS_WRAPPER
#define PALO_SPREADSHEET_FUNCS_WRAPPER

#include <PaloSpreadsheetFuncs\Wrapper.h>
#include <PaloSpreadsheetFuncs\XLError.h>

#include "XLSpreadsheetFuncs.h"

#include "XLCell.h"

#define RETURN_XLERROR(err) ZendValue(return_value).set(Palo::SpreadsheetFuncs::XLError::err);

#define XL_WRAPPER_ARG_DECL typename ExcelStructsWrapper::LPXLOPERX o1, typename ExcelStructsWrapper::LPXLOPERX o2, typename ExcelStructsWrapper::LPXLOPERX o3, typename ExcelStructsWrapper::LPXLOPERX o4, typename ExcelStructsWrapper::LPXLOPERX o5, typename ExcelStructsWrapper::LPXLOPERX o6, typename ExcelStructsWrapper::LPXLOPERX o7, typename ExcelStructsWrapper::LPXLOPERX o8, typename ExcelStructsWrapper::LPXLOPERX o9, typename ExcelStructsWrapper::LPXLOPERX o10, typename ExcelStructsWrapper::LPXLOPERX o11, typename ExcelStructsWrapper::LPXLOPERX o12, typename ExcelStructsWrapper::LPXLOPERX o13, typename ExcelStructsWrapper::LPXLOPERX o14, typename ExcelStructsWrapper::LPXLOPERX o15, typename ExcelStructsWrapper::LPXLOPERX o16, typename ExcelStructsWrapper::LPXLOPERX o17, typename ExcelStructsWrapper::LPXLOPERX o18, typename ExcelStructsWrapper::LPXLOPERX o19, typename ExcelStructsWrapper::LPXLOPERX o20, typename ExcelStructsWrapper::LPXLOPERX o21, typename ExcelStructsWrapper::LPXLOPERX o22, typename ExcelStructsWrapper::LPXLOPERX o23, typename ExcelStructsWrapper::LPXLOPERX o24, typename ExcelStructsWrapper::LPXLOPERX o25, typename ExcelStructsWrapper::LPXLOPERX o26, typename ExcelStructsWrapper::LPXLOPERX o27, typename ExcelStructsWrapper::LPXLOPERX o28, typename ExcelStructsWrapper::LPXLOPERX o29

namespace Palo {
	namespace XLL {
		template<class ExcelStructsWrapper>
		class SpreadsheetFuncsWrapper : public Wrapper< XLSpreadsheetFuncs<ExcelStructsWrapper> > {
		public:
			SpreadsheetFuncsWrapper( XLSpreadsheetFuncs<ExcelStructsWrapper>* thisptr, GenericContext& opts, void( XLSpreadsheetFuncs<ExcelStructsWrapper>::*p )( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) );

			typename ExcelStructsWrapper::LPXLOPERX operator()( size_t count, bool allow_error, XL_WRAPPER_ARG_DECL ) throw();
		};
	}
}
#endif
