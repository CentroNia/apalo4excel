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

#include <memory.h>

#include <PaloSpreadsheetFuncs/GenericCellException.h>

#include "XLCellException.h"
#include "XLCell.h"
#include "XLCellIteratorImpl.h"
#include "XLArrayBuilderImpl.h"
#include "XLCellRange.h"
#include "XLCellStyler.h"
#include "XLContext.h"

#include "xl.h"
#include "funcs.h"

#ifdef __XLL_VERSION_4
#	define MAX_ROWS_BASE 0xFFFF
#	define MAX_COLS_BASE 0xFF
#else
#	define MAX_ROWS_BASE 0xFFFFF
#	define MAX_COLS_BASE 0x3FFF
#endif

extern "C" void free_xloper(LPXLOPER px, int free_oper);

/* defines due to missing constructor-chaining */
#define MAX_ROWS (MAX_ROWS_BASE + 1)
#define MAX_COLS (MAX_COLS_BASE + 1)

using namespace jedox::palo;
using namespace Palo::XLL;
using namespace Palo::Util;

template<class ExcelStructsWrapper>
const size_t XLCell<ExcelStructsWrapper>::max_rows = MAX_ROWS;

template<class ExcelStructsWrapper>
const size_t XLCell<ExcelStructsWrapper>::max_cols = MAX_COLS;

template<class ExcelStructsWrapper>
XLCell<ExcelStructsWrapper>::XLCell( GenericContext& settings, bool is_retval, bool free_content_by_dll ) : ConvertingCell( settings ), coerced( false ), modified( false ), is_retval( is_retval), original_oper( NULL ), dont_pad(false), free_content_by_dll(free_content_by_dll) {
	oper = &_oper;
	memset( oper, 0, sizeof( ExcelStructsWrapper::XLOPERX ) );
	to_be_freed.clear();
}

template<class ExcelStructsWrapper>
XLCell<ExcelStructsWrapper>::XLCell( GenericContext& settings, typename ExcelStructsWrapper::LPXLOPERX o, bool is_retval ) : ConvertingCell( settings ), coerced( false ), modified( false ), oper( o ), is_retval( is_retval ), original_oper( oper ), dont_pad(false), free_content_by_dll(false) {
	to_be_freed.clear();
		
	/* If a "special range" (entire row or column!) has been passed we will choose
	 * a cell inside the range which "corresponds" to the caller's position.
	 * (cmp. behavior of SUM in such situations).
	 */
	const size_t rows = original_oper->val.sref.ref.rwLast - original_oper->val.sref.ref.rwFirst + 1;
	const size_t cols = original_oper->val.sref.ref.colLast - original_oper->val.sref.ref.colFirst + 1;

	if (((cols == max_cols) && (rows == 1)) || ((rows == max_rows) && (cols == 1))) 
	{
		bool is_vertical = (cols == 1);

		XLCellRange<ExcelStructsWrapper> xcr = XLCellRange<ExcelStructsWrapper>::getCaller();

		if ((xcr.getRows() == 1) && (xcr.getCols() == 1)) {
			if (is_vertical) {
				original_oper->val.sref.ref.rwFirst = original_oper->val.sref.ref.rwLast = xcr.getFirstRow();
			} else {
				original_oper->val.sref.ref.colFirst = original_oper->val.sref.ref.colLast = xcr.getFirstCol();
			}
		}
	} 

	/* dereference */
	if ( (oper->xltype == xltypeSRef) || (oper->xltype == xltypeRef) ) {
        int rc = ExcelStructsWrapper::Excelx( xlCoerce, &_oper, 1, oper );
		//if ( ExcelStructsWrapper::Excelx( xlCoerce, &_oper, 1, oper ) != xlretSuccess ) {
        if (rc != xlretSuccess ) {
			throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
		}

		coerced = true;

		oper = &_oper;
	}

}

template<class ExcelStructsWrapper>
void XLCell<ExcelStructsWrapper>::coerce( int types ) {
	bool err_allowed = ((types & xltypeErr) != 0);

	types |= xltypeErr;

	if(!(oper->xltype & types)) {
		if( (oper == &_oper) && coerced ) {
			ExcelStructsWrapper::Excelx( xlFree, 0, 1, &_oper );
		}

		coerced = true; 

		ExcelStructsWrapper::XLOPERX xArg;

		xArg.xltype = xltypeInt;
		xArg.val.w = types;

		if( ExcelStructsWrapper::Excelx(xlCoerce, (ExcelStructsWrapper::LPXLOPERX)&_oper, 2, original_oper, (ExcelStructsWrapper::LPXLOPERX)&xArg) != xlretSuccess ) {
			throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
		}

		oper = &_oper;
		coerced = true;
	}

	if( oper->xltype == xltypeErr && !err_allowed ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_ARGUMENT_IS_ERROR );
	}
}

template<class ExcelStructsWrapper>
XLCell<ExcelStructsWrapper>::~XLCell() {
	if ( (oper == &_oper) && coerced ) {
		ExcelStructsWrapper::Excelx( xlFree, 0, 1, &_oper );
	}
	else {
	 	if (free_content_by_dll) {
			free_xloper(&_oper, 0);
		}
	}

	std::vector<void *>::iterator i, end = to_be_freed.end();
	for (i = to_be_freed.begin(); i != end; ++i) {
		free(*i);
	}
}

template<class ExcelStructsWrapper>
typename ExcelStructsWrapper::LPXLOPERX XLCell<ExcelStructsWrapper>::release() {

	// the last one will be freed in free_xloper
	if (!to_be_freed.empty()) {
		to_be_freed.pop_back();
	}

	if ( oper == &_oper && !coerced ) {
		ExcelStructsWrapper::LPXLOPERX ret = ( ExcelStructsWrapper::LPXLOPERX )malloc( sizeof( ExcelStructsWrapper::XLOPERX ) );
		if ( ret == NULL ) {
			throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
		}
		*ret = *oper;
		ret->xltype |= xlbitDLLFree;
		return ret;
	} else {
		return oper;
	}
}

template<class ExcelStructsWrapper>
typename XLCell<ExcelStructsWrapper>::Type XLCell<ExcelStructsWrapper>::getType() {
	switch ( oper->xltype ) {
		case xltypeStr:
			return TString;
		case xltypeBool:
			return TBool;
		case xltypeInt:
			return TInt;
		case xltypeNum:
			return TDouble;
		case xltypeMulti:
			return TArray;
		case xltypeNil:
			return TNull;
		default:
			return TOther;
	}
}

template<class ExcelStructsWrapper>
bool XLCell<ExcelStructsWrapper>::isMissing() {
	return (oper->xltype == xltypeMissing) || (oper->xltype == xltypeNil);
}

template<class ExcelStructsWrapper>
bool XLCell<ExcelStructsWrapper>::empty( typename ExcelStructsWrapper::LPXLOPERX oper ) {
	if ( isMissing() ) {
		return true;
	} else if ( (oper->xltype == xltypeStr) && (oper->val.str[0] == 0) ) {
		return true;
	} else if ( oper->xltype == xltypeMulti ) {
		for ( int i = 0; i < oper->val.array.rows*oper->val.array.columns; ++i ) {
			if ( !empty( oper->val.array.lparray + i ) ) {
				return false;
			}
		}
		return true;
	} else {
		return false;
	}
}

template<class ExcelStructsWrapper>
std::unique_ptr<GenericCell> XLCell<ExcelStructsWrapper>::create() const {
	return std::unique_ptr<GenericCell>( new XLCell<ExcelStructsWrapper>( settings, false, true ) );
}

template<class ExcelStructsWrapper>
std::unique_ptr<GenericCell> XLCell<ExcelStructsWrapper>::clone() const {
    return std::unique_ptr<GenericCell>( new XLCell<ExcelStructsWrapper>( *this ) );
}

template<class ExcelStructsWrapper>
bool XLCell<ExcelStructsWrapper>::empty(bool dummy) {
	return empty( oper );
}

template<class ExcelStructsWrapper>
void XLCell<ExcelStructsWrapper>::check_unset() {
	if ( modified ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
	}
}

template<class ExcelStructsWrapper>
void XLCell<ExcelStructsWrapper>::set_set() {
	modified = true;
}

template<class ExcelStructsWrapper>
std::string XLCell<ExcelStructsWrapper>::getStringImpl() {
	coerce( xltypeStr );
	
	size_t length;
	short int must_free;
	char *s = ExcelStructsWrapper::get_string_direct_x( oper, &length, &must_free );

	if ( s == NULL ) {
		s = "";
	}

	std::string str( s, length );
	if (must_free) {
		free( s );
	}

	return str;
}

template<class ExcelStructsWrapper>
unsigned int XLCell<ExcelStructsWrapper>::getUInt() {
	if ( !(oper->xltype == xltypeNum) ){
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_INVALID_ARGUMENT_TYPE );
	}
	return static_cast<unsigned int>( oper->val.num );
}

template<class ExcelStructsWrapper>
int XLCell<ExcelStructsWrapper>::getSInt() {
	coerce( xltypeInt );
	
	int n;

	if ( ExcelStructsWrapper::get_int_x( oper, &n ) != XL_SUCCESS ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_INVALID_ARGUMENT_TYPE );
	}

	return n;
}

template<class ExcelStructsWrapper>
unsigned long int XLCell<ExcelStructsWrapper>::getULong() {
	if ( !oper->xltype == xltypeNum ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_INVALID_ARGUMENT_TYPE );
	}
	return static_cast<unsigned long>( oper->val.num );
}

template<class ExcelStructsWrapper>
long int XLCell<ExcelStructsWrapper>::getSLong() {
	if ( !oper->xltype == xltypeNum ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_INVALID_ARGUMENT_TYPE );
	}
	return static_cast<long int>( oper->val.num );
}

template<class ExcelStructsWrapper>
bool XLCell<ExcelStructsWrapper>::getBool() {
	coerce( xltypeBool );
	
	short int n;

	if ( ExcelStructsWrapper::get_bool_x( oper, &n ) != XL_SUCCESS ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_INVALID_ARGUMENT_TYPE );
	}

	return (n != 0);
}

template<class ExcelStructsWrapper>
double XLCell<ExcelStructsWrapper>::getDouble() {
	coerce( xltypeNum );
	
	double n;

	if ( ExcelStructsWrapper::get_double_x( oper, &n, 0, 1 ) != XL_SUCCESS ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_INVALID_ARGUMENT_TYPE );
	}

	return n;
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( boost::shared_ptr<jedox::palo::Server> s ) {
	throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_NOT_IMPLEMENTED );
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( int i ) {
	return set(( double )i );
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( unsigned int i ) {
	return set(( double )i );
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( long int i ) {
	return set(( double )i );
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( unsigned long int i ) {
	return set(( double )i );
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( double d ) {
	check_unset();
	oper->xltype = xltypeNum;
	oper->val.num = d;
	set_set();

	return *this;
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( long double d ) {
	return set(( double )d );
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::setImpl( const std::string& s ) {
	check_unset();
	*oper = ExcelStructsWrapper::TempStr_noalloc_x(( LPSTR )s.c_str(), NULL );
	set_set();

	return *this;
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( bool b ) {
	check_unset();
	oper->xltype = xltypeBool;
	oper->val.xbool = b;
	set_set();

	return *this;
}

template<class ExcelStructsWrapper>
template<class CellValueType>
GenericCell& XLCell<ExcelStructsWrapper>::setHelper( const CellValueType& v, bool set_error_desc){
	GenericCell::set(v, set_error_desc);

	if (is_retval && static_cast<XLContext<ExcelStructsWrapper>&>(settings).getUndoColorState()) {
		XLCellStyler<ExcelStructsWrapper>& cs = XLCellStyler<ExcelStructsWrapper>::getInstance();	
		
		XLCellRange<ExcelStructsWrapper>::CellID cellId = XLCellRange<ExcelStructsWrapper>::getCallerID();

		cellId.col += offset.col;
		cellId.rw += offset.row;

		switch (v.lock_status) {
			case LockedByMe:
				cs.scheduleColorUpdate(XLCellRange<ExcelStructsWrapper>::Color::Blue, cellId);
				break;
			case LockedByOther:
				cs.scheduleColorUpdate(XLCellRange<ExcelStructsWrapper>::Color::Gray, cellId);
				break;
			case Unlocked:
			default:
				cs.scheduleColorUpdate(typename XLCellRange<ExcelStructsWrapper>::Color::Automatic, cellId);
				break;
		}

	}

	return *this;
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set(const CellValue& v, bool set_error_desc ) {
	return setHelper<CellValue>(v, set_error_desc);
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set(const CellValueWithProperties& v, bool set_error_desc ) {
	return setHelper<CellValueWithProperties>(v, set_error_desc);
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::setError( const ErrorInfo& ei, bool set_error_desc ) {
	check_unset();

	oper->xltype = xltypeErr;
	
	switch ( ei.errcode ) {
		case XLError::DIVxl:
			oper->val.err = xlerrDiv0;
			break;
		case XLError::NAMExl:
			oper->val.err = xlerrName;
			break;
		case XLError::NAxl:
			oper->val.err = xlerrNA;
			break;
		case XLError::NULLxl:
			oper->val.err = xlerrNull;
			break;
		case XLError::NUMxl:
			oper->val.err = xlerrNum;
			break;
		case XLError::REFxl:
			oper->val.err = xlerrRef;
			break;
		case XLError::VALUExl:
			oper->val.err = xlerrValue;
			break;
		default:
			oper->val.err = xlerrNull;
	}

	set_set();

	if (set_error_desc && ei.have_desc) {
		settings.setError( ei );
	}

	return *this;
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::setNull() {
	check_unset();
	oper->xltype = xltypeNil;
	set_set();

	return *this;
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::setEmpty() {
	return ConvertingCell::set( std::string( "" ) );
}

template<class ExcelStructsWrapper>
GenericCell::Iterator XLCell<ExcelStructsWrapper>::getMatrix( size_t& rows, size_t& cols ) {
	return Iterator( new XLCellIteratorImpl<ExcelStructsWrapper>( settings, oper, rows, cols, is_retval ) );
}

template<class ExcelStructsWrapper>
GenericCell::Iterator XLCell<ExcelStructsWrapper>::getArray() {
	coerce( xltypeMulti );
	
	size_t rows, cols;

	Iterator i( new XLCellIteratorImpl<ExcelStructsWrapper>( settings, oper, rows, cols, is_retval ) );
	if ( (rows != 1) && (cols != 1 )) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_INVALID_ARGUMENT_TYPE );
	} else {
		return i;
	}
}

template<class ExcelStructsWrapper>
ConsolidationElementArray XLCell<ExcelStructsWrapper>::getConsolidationElementArray() {
	ConsolidationElementArray cea;

	cea.reserve( getArray().minRemaining() );

	for ( GenericCell::Iterator i = getArray(); !i.end(); ++i ) {
		ConsolidationElement ce;

		ce.name = i->getString();
		++i;
		if (i.end()) {
			throw GenericCellException( CurrentSourceLocation, SpreadsheetFuncsErrors::ERROR_INVALID_CONSOLIDATION_ELEMENT_SPECIFICATION );
		}
		ce.weight = i->getDouble();

		cea.push_back( ce );
	}

	return cea;
}

template<class ExcelStructsWrapper>
GenericArrayBuilder XLCell<ExcelStructsWrapper>::setArray( size_t length, bool pad ) {
	// transpose or not
	bool return_column = true;
	ExcelStructsWrapper::XLOPERX xRes;

	if ( ExcelStructsWrapper::Excelx( xlfCaller, ( ExcelStructsWrapper::LPXLOPERX )&xRes, 0 ) != xlretSuccess ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}

	if ( (xRes.xltype == xltypeSRef) && (xRes.val.sref.ref.rwLast - xRes.val.sref.ref.rwFirst == 0) && (xRes.val.sref.ref.colLast - xRes.val.sref.ref.colFirst > 0) ) {
		return_column = false;
	}

	ExcelStructsWrapper::Excelx( xlFree, NULL, 1, ( ExcelStructsWrapper::LPXLOPERX )&xRes );

	return setMatrix( return_column ? length : 1, return_column ? 1 : length, !pad ? false : (is_retval && !dont_pad) );
}

template<class ExcelStructsWrapper>
GenericArrayBuilder XLCell<ExcelStructsWrapper>::setMatrix( size_t rows, size_t cols ) {
	return setMatrix( rows, cols, is_retval );
}

template<class ExcelStructsWrapper>
GenericArrayBuilder XLCell<ExcelStructsWrapper>::setMatrix( size_t rows, size_t cols, bool pad ) {
	check_unset();
	oper->xltype = xltypeMulti;
	oper->val.array.columns = (COL)cols;
	oper->val.array.rows = (RW)rows;
	oper->val.array.lparray = NULL;
	set_set();

	return GenericArrayBuilder( new XLArrayBuilderImpl<ExcelStructsWrapper>( settings, this, rows, cols, pad ) );
}

template<class ExcelStructsWrapper>
void XLCell<ExcelStructsWrapper>::setDimensionElementInfoSimple( GenericArrayBuilder& a, const DimensionElementInfoSimple& dis, unsigned int num_entries) {
	a.append( "name", a.createGenericCell()->set( dis.name ) );

	if ( num_entries > 1 ) {
		a.append( "type", a.createGenericCell()->set( dis.type ) );
	}

	if ( num_entries > 2 ) {
		a.append( "identifier", a.createGenericCell()->set( dis.identifier ) );
	}
}

template<class ExcelStructsWrapper>
void XLCell<ExcelStructsWrapper>::setConsolidationElementInfo( GenericArrayBuilder& a, const ConsolidationElementInfo& cei, unsigned int num_entries) {
	a.append( "name", a.createGenericCell()->set( cei.name ) );

	if ( num_entries > 1 ) {
		a.append( "weight", a.createGenericCell()->set( cei.weight ) );
	}

	if ( num_entries > 2 ) {
		a.append( "type", a.createGenericCell()->set( cei.type ) );
	}

	if ( num_entries > 3 ) {
		a.append( "identifier", a.createGenericCell()->set( cei.identifier ) );
	}
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( const ConsolidationElementInfoArray& ceia ) {
	return set<4>(ceia, &setConsolidationElementInfo);
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( const DimensionElementInfoSimpleArray& ei ) {
	return set<3>(ei, &setDimensionElementInfoSimple);
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( const ConsolidationElementInfo& ei ) {
	throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_NOT_IMPLEMENTED );
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( const DimensionElementInfo& ei ) {
	throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_NOT_IMPLEMENTED );
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( const DimensionElementInfoSimple& ei ) {
	throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_NOT_IMPLEMENTED );
}

template<class ExcelStructsWrapper>
template<unsigned int max_entries, typename MultiColumn, typename Functor>
GenericCell& XLCell<ExcelStructsWrapper>::set( const std::vector<MultiColumn>& mc, Functor setter ) {
	bool vertical = true;		            // return as column
	unsigned int num_entries = max_entries; // return everything

	/* We want our functions to be usable from VBA, where xlfCaller fails. */
	try {
		if ( is_retval ) {
			XLCellRange<ExcelStructsWrapper> xcr = XLCellRange<ExcelStructsWrapper>::getCaller();

			size_t rows = xcr.getRows();
			size_t cols = xcr.getCols();

			if ( cols > 3 && cols >= rows) {
				vertical = false;
				num_entries = xcr.getRows();
			} else {
				num_entries = xcr.getCols();
			}

			if (num_entries > max_entries) {
				num_entries = max_entries;
			}
		}

#ifdef _DEBUG
	} catch ( const XLCellException& exp) {
		const char *what = exp.what();
	} catch ( const std::exception& exp) {
		const char *what = exp.what();
#endif
	} catch(...) {
	}

	GenericArrayBuilder a = setMatrix( vertical ? mc.size() : num_entries, vertical ? num_entries : mc.size() );

	for ( std::vector<MultiColumn>::const_iterator i = mc.begin(); i != mc.end(); ++i ) {
		const MultiColumn& mcr = *i;

		setter(a, mcr, num_entries);
	}

	if ( !vertical ) {
		a.transpose();
	}

	return *this;
}

template<class ExcelStructsWrapper>
void XLCell<ExcelStructsWrapper>::setSubsetResult( GenericArrayBuilder& a, const SubsetResult& sr, unsigned int num_entries) {
	if ( num_entries > 2 ) {
		a.append( "indent", a.createGenericCell()->set( sr.idx ) );
	}

	a.append( "name", a.createGenericCell()->set( sr.name ) );

	if ( num_entries > 1 ) {
		a.append( "alias", a.createGenericCell()->set( sr.alias ) );
	}
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::set( const SubsetResults& srs ) {
	return set<3>(srs, &setSubsetResult);
}

template<class ExcelStructsWrapper>
bool XLCell<ExcelStructsWrapper>::isError() {
	ExcelStructsWrapper::XLOPERX xRes;

	ExcelStructsWrapper::Excelx( xlfIserror, ( ExcelStructsWrapper::LPXLOPERX )&xRes, 1, oper );

	bool res = ( xRes.val.xbool == 1 );

	ExcelStructsWrapper::Excelx( xlFree, NULL, 1, ( ExcelStructsWrapper::LPXLOPERX )&xRes );

	return res;
}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper> XLCell<ExcelStructsWrapper>::getAsRange() {
	return XLCellRange<ExcelStructsWrapper>( original_oper );
}

template<class ExcelStructsWrapper>
GenericCell& XLCell<ExcelStructsWrapper>::supressPadding() {
	dont_pad = true;

	return GenericCell::supressPadding();
}

const std::string GenericCell::ELEMENTS_ALL = "*";

#ifdef __XLL_VERSION_4
template class XLCell<Excel4Types>;
#else
template class XLCell<Excel12Types>;
#endif