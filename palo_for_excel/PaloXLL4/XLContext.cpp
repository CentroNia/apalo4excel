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

#include "XLContext.h"
#include "XLSpreadsheetFuncs.h"
#include "XLLException.h"

#include "xl.h"

using namespace Palo::XLL;
using namespace Palo::Types;


XLContext::XLContext() : loop_enabled( false ), undo_coloring_enabled( false ) {
	GenericContext::setError( ErrorInfo( XLError::NAxl, 0, "No error information available." ) );

	clearCachedData();
}


bool XLContext::splashingAllowed() {
	return true;
}


GenericContext::Conversions& XLContext::getConversions() {
	using namespace jedox::i18n;

#ifdef __XLL_VERSION_4
	static Conversions c = Conversions( Local2UTF8Converter(), UTF82LocalConverter() );
#else
	static Conversions c = Conversions( Conversion(internal::ConverterUTF8(), internal::ConverterUTF8()), 
		Conversion(internal::ConverterUTF8(), internal::ConverterUTF8()) );
#endif
	
	return c;
}


size_t XLContext::getStringPoolIndex(const std::string& message){
	size_t i, vsize = stringPool.size();

	for (i=0; i < vsize; i++) {
		if (stringPool[i] == message) {
			return i;
		}
	}

	stringPool.push_back(message);
	return vsize;
}


void XLContext::setError( const Palo::Types::ErrorInfo& ei ) {
	XLOPERX xCaller;

	if (XLCellRange::getCallerCheck(false, &xCaller)) {
		XLCellRange::CellKeyArray keys = XLCellRange::getCallerProcess(&xCaller).getKeys();
		for ( XLCellRange::CellKeyArray::const_iterator i = keys.begin(); i != keys.end(); ++i ) {
			if (ei.have_desc) {
				errMap[*i] = getStringPoolIndex(ei.desc);
			} else {
				errMap.erase(*i);
			}
		}
	}
}


const Palo::Types::ErrorInfo XLContext::getError() const {
	return getError( XLCellRange::getSelection().getSubrange( 0, 0, 0, 0 ).getKey() );
}


const Palo::Types::ErrorInfo XLContext::getError( const XLCellRange::CellKey& key ) const {
	ErrorMap::const_iterator i = errMap.find( key );

	return ErrorInfo(XLError::NAxl, 0, ((i != errMap.end()) && (i->second < stringPool.size()) ) ? stringPool[i->second] : "");
}


void XLContext::enableLoop( bool enable ) {
	if ( !loop_enabled && enable ) {
		XLSpreadsheetFuncs::getInstance().calculationBegin();
	}
	else {
		if ( loop_enabled && !enable ) {
			XLSpreadsheetFuncs::getInstance().calculationEnd();
		}
	}

	loop_enabled = enable;
}


void XLContext::enableUndoColoring( bool enable ) {
	if ( !undo_coloring_enabled && enable ) {
		XLSpreadsheetFuncs::getInstance().calculationBegin();
	}else { 
		if ( undo_coloring_enabled && !enable ) {
			XLSpreadsheetFuncs::getInstance().calculationEnd();
		}
	}

	undo_coloring_enabled = enable;
}


void XLContext::setNeedFullRecalc( bool value ) {
	need_full_recalc = value;
}


bool XLContext::getNeedFullRecalc() const {
	return need_full_recalc;
}


 XLContext::RecalcType XLContext::getRecalcType() const {
	return recalc_type;
}


void XLContext::setRecalcType(RecalcType rct) {
	recalc_type = rct;
}


void XLContext::clearCachedData() {
	current_sheet = "";
	need_full_recalc = false;
	recalc_type = XLContext::FullRecalc;
}


const std::string& XLContext::getCurrentBookSheetName() {
	current_sheet = XLCellRange::getSelectedBookSheetName();
	return current_sheet;
}


bool XLContext::getLoopState() const {
	return loop_enabled;
}


bool XLContext::getUndoColorState() const {
	return undo_coloring_enabled;
}


void XLContext::clearErrors() {
	errMap.clear();
	stringPool.clear();
}


void XLContext::saveState() {
	if( Excelx( xlfSelection, (LPXLOPERX)&selection, 0) != xlretSuccess ) {
		throw XLLException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}

	if( Excelx( xlfActiveCell, (LPXLOPERX)&active_cell, 0) != xlretSuccess ) {
		throw XLLException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}
}


void XLContext::restoreState() {
	Excelx( xlcSelect, 0, 2, (LPXLOPERX)&selection, (LPXLOPERX)&active_cell);
}
