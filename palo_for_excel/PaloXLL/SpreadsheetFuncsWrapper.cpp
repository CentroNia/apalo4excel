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

#include "SpreadsheetFuncsWrapper.h"
#include "XLLCellLogger.h"
#include "XLCellException.h"

#include <PaloSpreadsheetFuncs/WrongParamCountException.h>

using namespace Palo::XLL;
using namespace Palo::SpreadsheetFuncs;
using namespace std;

template< class ExcelStructsWrapper>
SpreadsheetFuncsWrapper<ExcelStructsWrapper>::SpreadsheetFuncsWrapper( XLSpreadsheetFuncs<ExcelStructsWrapper>* thisptr, GenericContext& opts, void( XLSpreadsheetFuncs<ExcelStructsWrapper>::*p )( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) )
		: Wrapper< XLSpreadsheetFuncs<ExcelStructsWrapper> >( XLLCellLogger::getInstance(), thisptr, opts, p ) {}

/*! \TODO: Use Excel's faster "modify in place" (return-by-ref) interface to return results. */
template< class ExcelStructsWrapper>
typename ExcelStructsWrapper::LPXLOPERX SpreadsheetFuncsWrapper<ExcelStructsWrapper>::operator()( size_t count, bool allow_error, XL_WRAPPER_ARG_DECL ) throw() {
	try {
		XLCell<ExcelStructsWrapper> return_value( opts, true );

		try {
			vector<GenericCell*> v;

			vector<typename ExcelStructsWrapper::LPXLOPERX> xlargs;

			xlargs.reserve(29);

			xlargs.push_back( o1 );
			xlargs.push_back( o2 );
			xlargs.push_back( o3 );
			xlargs.push_back( o4 );
			xlargs.push_back( o5 );
			xlargs.push_back( o6 );
			xlargs.push_back( o7 );
			xlargs.push_back( o8 );
			xlargs.push_back( o9 );
			xlargs.push_back( o10 );
			xlargs.push_back( o11 );
			xlargs.push_back( o12 );
			xlargs.push_back( o13 );
			xlargs.push_back( o14 );
			xlargs.push_back( o15 );
			xlargs.push_back( o16 );
			xlargs.push_back( o17 );
			xlargs.push_back( o18 );
			xlargs.push_back( o19 );
			xlargs.push_back( o20 );
			xlargs.push_back( o21 );
			xlargs.push_back( o22 );
			xlargs.push_back( o23 );
			xlargs.push_back( o24 );
			xlargs.push_back( o25 );
			xlargs.push_back( o26 );
			xlargs.push_back( o27 );
			xlargs.push_back( o28 );
			xlargs.push_back( o29 );

			if ( count != ( size_t )( -1 ) ) {
				xlargs.resize( count );
			}

			try {
				size_t trailing = 0;
				if ( count == -1 ) {
					for ( vector<ExcelStructsWrapper::LPXLOPERX>::const_reverse_iterator r = xlargs.rbegin(); r != xlargs.rend(); ++r ) {
						if (( *r )->xltype == xltypeMissing ) {
							trailing++;
						} else if (false == allow_error && (( *r )->xltype == xltypeErr )) {
							return *r;
						} else {
							break;
						}
					}
					xlargs.resize( xlargs.size() - trailing );
				}

				v.reserve(xlargs.size());
				for ( vector<ExcelStructsWrapper::LPXLOPERX>::const_iterator i = xlargs.begin(); i != xlargs.end(); ++i ) {
					v.push_back( new XLCell<ExcelStructsWrapper>( opts, *i ) );
				}

				GenericArgumentArray gv( v );

				Wrapper<XLSpreadsheetFuncs< ExcelStructsWrapper> >::operator()( return_value, opts, gv );

				// cleanup
				for ( vector<GenericCell*>::iterator i = v.begin(); i != v.end(); i++ )
					delete *i;
			} catch ( ... ) {
				// cleanup
				for ( vector<GenericCell*>::iterator i = v.begin(); i != v.end(); i++ ) {
					delete *i;
				}

				throw;
			}
		} catch (const WrongParamCountException& ) {
			log.log( AbstractLogger::LOG_WARNING, WRONG_PARAM_COUNT_EXCEPTION_ERROR_STRING );
			return_value.setError( ErrorInfo(XLError::VALUExl, WRONG_PARAM_COUNT_EXCEPTION_ERROR_CODE, WRONG_PARAM_COUNT_EXCEPTION_ERROR_STRING) ); 
		} catch (XLCellException &e ) {
			if (e.getErrorCode() != XLLErrors::ERROR_EXCEL_CALL_FAILED) {
				log.log( AbstractLogger::LOG_WARNING, e.what() );
			}
			return NULL;
		}

		return return_value.release();
	} catch ( ... ) {
		try {
			XLLCellLogger::getInstance().log( AbstractLogger::LOG_WARNING, "Unexpected exception caught! (This should never happen)." );
		} catch ( ... ) {}

		return NULL;
	}
}

#ifdef __XLL_VERSION_4
template class SpreadsheetFuncsWrapper<Excel4Types>;
#else
template class SpreadsheetFuncsWrapper<Excel12Types>;
#endif
