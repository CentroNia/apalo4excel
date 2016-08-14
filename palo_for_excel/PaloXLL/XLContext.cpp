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

#include "XLContext.h"
#include "XLSpreadsheetFuncs.h"
#include "XLLException.h"

#include "xl.h"

using namespace Palo::XLL;
using namespace Palo::Types;

template<class ExcelStructsWrapper>
XLContext<ExcelStructsWrapper>::XLContext() : loop_enabled( false ), undo_coloring_enabled( false ) {
	GenericContext::setError( ErrorInfo( XLError::NAxl, 0, "No error information available." ) );

	clearCachedData();
}

template<class ExcelStructsWrapper>
bool XLContext<ExcelStructsWrapper>::splashingAllowed() {
	return true;
}

template<class ExcelStructsWrapper>
GenericContext::Conversions& XLContext<ExcelStructsWrapper>::getConversions() {
	using namespace jedox::i18n;

#ifdef __XLL_VERSION_4
	static Conversions c = Conversions( Local2UTF8Converter(), UTF82LocalConverter() );
#else
	static Conversions c = Conversions( Conversion(internal::ConverterUTF8(), internal::ConverterUTF8()), 
		Conversion(internal::ConverterUTF8(), internal::ConverterUTF8()) );
#endif
	
	return c;
}

template<class ExcelStructsWrapper>
void XLContext<ExcelStructsWrapper>::setError( const Palo::Types::ErrorInfo& ei ) {
	ExcelStructsWrapper::XLOPERX xCaller;

	if (XLCellRange<ExcelStructsWrapper>::getCallerCheck(false, &xCaller)) {
		XLCellRange<ExcelStructsWrapper>::CellKeyArray keys = XLCellRange<ExcelStructsWrapper>::getCallerProcess(&xCaller).getKeys();
		for ( XLCellRange<ExcelStructsWrapper>::CellKeyArray::const_iterator i = keys.begin(); i != keys.end(); ++i ) {
			if (ei.have_desc) {
				errMap[*i] = ei;
			} else {
				errMap.erase(*i);
			}
		}
	}
}

template<class ExcelStructsWrapper>
const Palo::Types::ErrorInfo XLContext<ExcelStructsWrapper>::getError() const {
	return getError( XLCellRange<ExcelStructsWrapper>::getSelection().getSubrange( 0, 0, 0, 0 ).getKey() );
}

template<class ExcelStructsWrapper>
const Palo::Types::ErrorInfo XLContext<ExcelStructsWrapper>::getError( const typename XLCellRange<ExcelStructsWrapper>::CellKey& key ) const {
	ErrorMap::const_iterator i = errMap.find( key );

	return ErrorInfo(XLError::NAxl, 0, (i != errMap.end() && i->second.have_desc && !i->second.desc.empty()) ? i->second.desc : "");
}

template<class ExcelStructsWrapper>
void XLContext<ExcelStructsWrapper>::enableLoop( bool enable ) {
	if ( !loop_enabled && enable ) {
		XLSpreadsheetFuncs<ExcelStructsWrapper>::getInstance().calculationBegin();
	}
	else {
		if ( loop_enabled && !enable ) {
			XLSpreadsheetFuncs<ExcelStructsWrapper>::getInstance().calculationEnd();
		}
	}

	loop_enabled = enable;
}

template<class ExcelStructsWrapper>
void XLContext<ExcelStructsWrapper>::enableUndoColoring( bool enable ) {
	if ( !undo_coloring_enabled && enable ) {
		XLSpreadsheetFuncs<ExcelStructsWrapper>::getInstance().calculationBegin();
	}else { 
		if ( undo_coloring_enabled && !enable ) {
			XLSpreadsheetFuncs<ExcelStructsWrapper>::getInstance().calculationEnd();
		}
	}

	undo_coloring_enabled = enable;
}

template<class ExcelStructsWrapper>
void XLContext<ExcelStructsWrapper>::setNeedFullRecalc( bool value ) {
	need_full_recalc = value;
}

template<class ExcelStructsWrapper>
bool XLContext<ExcelStructsWrapper>::getNeedFullRecalc() const {
	return need_full_recalc;
}

template<class ExcelStructsWrapper>
typename XLContext<ExcelStructsWrapper>::RecalcType XLContext<ExcelStructsWrapper>::getRecalcType() const {
	return recalc_type;
}

template<class ExcelStructsWrapper>
void XLContext<ExcelStructsWrapper>::setRecalcType(RecalcType rct) {
	recalc_type = rct;
}

template<class ExcelStructsWrapper>
void XLContext<ExcelStructsWrapper>::clearCachedData() {
	current_sheet = "";
	need_full_recalc = false;
	recalc_type = XLContext::FullRecalc;
}

template<class ExcelStructsWrapper>
const std::string& XLContext<ExcelStructsWrapper>::getCurrentBookSheetName() {
	current_sheet = XLCellRange<ExcelStructsWrapper>::getSelectedBookSheetName();
	return current_sheet;
}

template<class ExcelStructsWrapper>
bool XLContext<ExcelStructsWrapper>::getLoopState() const {
	return loop_enabled;
}

template<class ExcelStructsWrapper>
bool XLContext<ExcelStructsWrapper>::getUndoColorState() const {
	return undo_coloring_enabled;
}

template<class ExcelStructsWrapper>
void XLContext<ExcelStructsWrapper>::clearErrors() {
	errMap.clear();
}

template<class ExcelStructsWrapper>
void XLContext<ExcelStructsWrapper>::saveState() {
	if( ExcelStructsWrapper::Excelx( xlfSelection, (ExcelStructsWrapper::LPXLOPERX)&selection, 0) != xlretSuccess ) {
		throw XLLException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}

	if( ExcelStructsWrapper::Excelx( xlfActiveCell, (ExcelStructsWrapper::LPXLOPERX)&active_cell, 0) != xlretSuccess ) {
		throw XLLException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}
}

template<class ExcelStructsWrapper>
void XLContext<ExcelStructsWrapper>::restoreState() {
	ExcelStructsWrapper::Excelx( xlcSelect, 0, 2, (ExcelStructsWrapper::LPXLOPERX)&selection, (ExcelStructsWrapper::LPXLOPERX)&active_cell);
}

#ifdef __XLL_VERSION_4
template class XLContext<Excel4Types>;
#else
template class XLContext<Excel12Types>;
#endif