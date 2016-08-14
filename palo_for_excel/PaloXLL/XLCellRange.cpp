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

#include "XLCellRange.h"
#include "XLCellException.h"
#include "xl.h"

using namespace Palo::XLL;

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper>::XLCellRange( const XLCellRange<ExcelStructsWrapper>& other ) {
	assign(other);
}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper>::XLCellRange( typename ExcelStructsWrapper::XLOPERX aref ) : _ref( aref ), ref( &_ref ) {
	check();
}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper>::XLCellRange( typename ExcelStructsWrapper::LPXLOPERX aref ) : ref( aref ) {
	check();
}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper>::XLCellRange( const typename CellID& aref ) : ref( &_ref ) {
	_ref.xltype = xltypeRef;
	_ref.val.mref.idSheet = aref.sheetID;
	_ref.val.mref.lpmref = &_mref;

	_mref.count = 1;
	_mref.reftbl[0].colFirst = _mref.reftbl[0].colLast = aref.col;
	_mref.reftbl[0].rwFirst = _mref.reftbl[0].rwLast = aref.rw;
}
template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper>& XLCellRange<ExcelStructsWrapper>::operator= (const XLCellRange<ExcelStructsWrapper>& other) {
	assign(other);

	return *this;
}

template<class ExcelStructsWrapper>
void XLCellRange<ExcelStructsWrapper>::assign(const XLCellRange& other) {
	_mref = other._mref;
	
	_ref = other._ref;
	if(other._ref.xltype == xltypeRef && other._ref.val.mref.lpmref == &other._mref) {
		_ref.val.mref.lpmref = &_mref;
	}

	ref = other.ref;
	if(other.ref == &other._ref) {
		ref = &_ref;
	}
}

template<class ExcelStructsWrapper>
typename ExcelStructsWrapper::XLREFX XLCellRange<ExcelStructsWrapper>::getXLREF() const {
	if (ref->xltype == xltypeSRef) {
		return ref->val.sref.ref;
	} else {
		if ((ref->xltype == xltypeRef) && (ref->val.mref.lpmref->count > 0)) {
			return ref->val.mref.lpmref->reftbl[0];
		} else {
			throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_CELL_NOT_REF );
		}
	}
}


template<class ExcelStructsWrapper>
void XLCellRange<ExcelStructsWrapper>::select() {
	if( ExcelStructsWrapper::Excelx( xlcSelect, NULL, 1, ref) != xlretSuccess ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}
}

template<class ExcelStructsWrapper>
typename XLCellRange<ExcelStructsWrapper>::Color XLCellRange<ExcelStructsWrapper>::getColor() const {
	typename ExcelStructsWrapper::XLOPERX xTemp, xRes;

	xTemp.xltype = xltypeInt;
	xTemp.val.w = CellPropertyColor;

	if ( ExcelStructsWrapper::Excelx( xlfGetCell, (ExcelStructsWrapper::LPXLOPERX)&xRes, 2, (ExcelStructsWrapper::LPXLOPERX)&xTemp, ref) != xlretSuccess ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}

	int result = (int)xRes.val.num;

	bool failed = (xRes.xltype != xltypeNum);
	ExcelStructsWrapper::Excelx( xlFree, NULL, 1, (ExcelStructsWrapper::LPXLOPERX)&xRes);
	
	if (failed) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}

	return Color::Color(result);
}

template<class ExcelStructsWrapper>
void XLCellRange<ExcelStructsWrapper>::setColor(Color color) {	
	select();

	ExcelStructsWrapper::XLOPERX xColor, xMissing;

	xColor.xltype = xltypeNum;
	xColor.val.num = (int)color;

	xMissing.xltype = xltypeMissing;

	if( ExcelStructsWrapper::Excelx(xlcFontProperties, NULL, 14, (ExcelStructsWrapper::LPXLOPERX)&xMissing, (ExcelStructsWrapper::LPXLOPERX)&xMissing, (ExcelStructsWrapper::LPXLOPERX)&xMissing,
		(ExcelStructsWrapper::LPXLOPERX)&xMissing, (ExcelStructsWrapper::LPXLOPERX)&xMissing, (ExcelStructsWrapper::LPXLOPERX)&xMissing, (ExcelStructsWrapper::LPXLOPERX)&xMissing, (ExcelStructsWrapper::LPXLOPERX)&xMissing,
		(ExcelStructsWrapper::LPXLOPERX)&xMissing, (ExcelStructsWrapper::LPXLOPERX)&xColor, (ExcelStructsWrapper::LPXLOPERX)&xMissing, (ExcelStructsWrapper::LPXLOPERX)&xMissing,
		(ExcelStructsWrapper::LPXLOPERX)&xMissing, (ExcelStructsWrapper::LPXLOPERX)&xMissing) != xlretSuccess ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}
}

template< class ExcelStructsWrapper>
template<int xlfunc>
std::string XLCellRange<ExcelStructsWrapper>::getBookSheetName() {
	typename ExcelStructsWrapper::XLOPERX xRes;

	if( ExcelStructsWrapper::Excelx(xlfunc, (ExcelStructsWrapper::LPXLOPERX)&xRes, 0) != xlretSuccess || xRes.xltype == xltypeErr) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
	}

	try {
		char *result = ExcelStructsWrapper::get_book_sheet_x(&xRes);

		ExcelStructsWrapper::Excelx(xlFree, NULL, 1, (ExcelStructsWrapper::LPXLOPERX)&xRes);

		if (result == NULL) {
			throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
		}

		std::string real_result = result;

		free(result);

		return real_result;
	} catch(...) {
		ExcelStructsWrapper::Excelx(xlFree, NULL, 1, (ExcelStructsWrapper::LPXLOPERX)&xRes);

		throw;
	}
}

template<class ExcelStructsWrapper>
std::string XLCellRange<ExcelStructsWrapper>::getSelectedBookSheetName() {
	return getBookSheetName<xlfSelection>();
}

template<class ExcelStructsWrapper>
std::string XLCellRange<ExcelStructsWrapper>::getCallingBookSheetName() {
	return getBookSheetName<xlfCaller>();
}

template<class ExcelStructsWrapper>
typename XLCellRange<ExcelStructsWrapper>::CellID XLCellRange<ExcelStructsWrapper>::getCallerID(void *dummy) {
	return XLCellRange<ExcelStructsWrapper>::getCaller().getCellID();
}

template<class ExcelStructsWrapper>
typename XLCellRange<ExcelStructsWrapper>::CellID XLCellRange<ExcelStructsWrapper>::getCellID() {
	ExcelStructsWrapper::XLOPERX xRes2, xTemp;
	int res;
	
	xTemp.xltype = xltypeInt;
	xTemp.val.w = xltypeRef;
	res = ExcelStructsWrapper::Excelx(xlCoerce, (ExcelStructsWrapper::LPXLOPERX)&xRes2, 2, ref, (ExcelStructsWrapper::LPXLOPERX)&xTemp);
	if (res != xlretSuccess || xRes2.xltype != xltypeRef) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}

	struct CellID cid;

	cid.col = xRes2.val.mref.lpmref->reftbl[0].colFirst;
	cid.rw = xRes2.val.mref.lpmref->reftbl[0].rwFirst;
	cid.sheetID = xRes2.val.mref.idSheet;

	ExcelStructsWrapper::Excelx(xlFree, NULL, 1, (ExcelStructsWrapper::LPXLOPERX)&xRes2);

	return cid;
}

template<class ExcelStructsWrapper>
void XLCellRange<ExcelStructsWrapper>::check() {
	if (( ref->xltype != xltypeSRef ) && ( ref->xltype != xltypeRef )){
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_CELL_NOT_REF );
	}
}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper>::~XLCellRange() {}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper> XLCellRange<ExcelStructsWrapper>::getSelection() {
	ExcelStructsWrapper::XLOPERX xCaller;

	if ( ExcelStructsWrapper::Excelx( xlfSelection, ( ExcelStructsWrapper::LPXLOPERX )&xCaller, 0 ) != xlretSuccess || xCaller.xltype == xltypeErr ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
	}

	XLCellRange range = XLCellRange( xCaller );

	ExcelStructsWrapper::Excelx(xlFree, NULL, 0, (ExcelStructsWrapper::LPXLOPERX)&xCaller);

	return range;
}


template<class ExcelStructsWrapper>
bool XLCellRange<ExcelStructsWrapper>::getCallerCheck(bool dothrow, typename ExcelStructsWrapper::XLOPERX *xCaller) {
	if ( (ExcelStructsWrapper::Excelx( xlfCaller, ( ExcelStructsWrapper::LPXLOPERX )xCaller, 0 ) != xlretSuccess) || (xCaller->xltype == xltypeErr) ) {
		if (dothrow) {
			throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
		} else {
			return false;
		}
	}

	return true;

}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper> XLCellRange<ExcelStructsWrapper>::getCallerProcess(typename ExcelStructsWrapper::XLOPERX *xCaller) {

	XLCellRange range = XLCellRange( *xCaller );

	ExcelStructsWrapper::Excelx(xlFree, NULL, 0, (ExcelStructsWrapper::LPXLOPERX)xCaller);

	return range;
}


template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper> XLCellRange<ExcelStructsWrapper>::getCaller() {
	ExcelStructsWrapper::XLOPERX xCaller;

	XLCellRange<ExcelStructsWrapper>::getCallerCheck(true, &xCaller);

	return XLCellRange<ExcelStructsWrapper>::getCallerProcess(&xCaller);
}

template<class ExcelStructsWrapper>
RW XLCellRange<ExcelStructsWrapper>::getRows() const {
	const ExcelStructsWrapper::XLREFX& xlref = getXLREF();
	return xlref.rwLast - xlref.rwFirst + 1;
}

template<class ExcelStructsWrapper>
COL XLCellRange<ExcelStructsWrapper>::getCols() const {
	const ExcelStructsWrapper::XLREFX& xlref = getXLREF();
	return xlref.colLast - xlref.colFirst + 1;
}

template<class ExcelStructsWrapper>
RW XLCellRange<ExcelStructsWrapper>::getFirstRow() const {
	return getXLREF().rwFirst;
}

template<class ExcelStructsWrapper>
RW XLCellRange<ExcelStructsWrapper>::getLastRow() const {
	return getXLREF().rwLast;
}

template<class ExcelStructsWrapper>
COL XLCellRange<ExcelStructsWrapper>::getFirstCol() const {
	return getXLREF().colFirst;
}

template<class ExcelStructsWrapper>
COL XLCellRange<ExcelStructsWrapper>::getLastCol() const {
	return getXLREF().colLast;
}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper> XLCellRange<ExcelStructsWrapper>::getSubrange( COL colfirst, COL collast, RW rowfirst, RW rowlast ) {
	ExcelStructsWrapper::XLOPERX r = *ref;

	r.val.sref.ref.colLast = r.val.sref.ref.colFirst;
	r.val.sref.ref.colFirst += colfirst;
	r.val.sref.ref.colLast += collast;
	r.val.sref.ref.rwLast = r.val.sref.ref.rwFirst;
	r.val.sref.ref.rwFirst += rowfirst;
	r.val.sref.ref.rwLast += rowlast;

	return XLCellRange( r );
}

template<class ExcelStructsWrapper>
typename XLCellRange<ExcelStructsWrapper>::CellKey XLCellRange<ExcelStructsWrapper>::getKey() {
	char *k = ExcelStructsWrapper::create_cleartext_key_x( ref );

	if (!k) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
	}

	CellKey key( k );

	free( k );

	return key;
}

template<class ExcelStructsWrapper>
typename XLCellRange<ExcelStructsWrapper>::CellKeyArray XLCellRange<ExcelStructsWrapper>::getKeys() {
	CellKeyArray keys;
	COL i_max = getCols();
	RW j_max = getRows();

	for ( COL i = 0; i < i_max; i++ ) {
		for ( RW j = 0; j < j_max; j++ ) {
			keys.push_back( getSubrange( i, i, j, j ).getKey() );
		}
	}

	return keys;
}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper>::Color::Color() {
	color = Automatic;
}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper>::Color::Color(int excel_color) {
	/*! \TODO implement */
	switch(excel_color) {
		case 0:
			color = Automatic;
			break;
		case 48:
			color = Gray;
			break;
		case 5:
			color = Blue;
			break;
		case 3:
			color = Red;
			break;
		default:
			color = Other;
			break;
	}
}

template<class ExcelStructsWrapper>
XLCellRange<ExcelStructsWrapper>::Color::operator int() const {
	/*! \TODO implement */
	switch(color) {
		case Automatic:
			return 0;			
		case Gray:
			return 48;
		case Blue:
			return 5;
		case Red:
			return 3;
		case Other:
		default:
			throw XLCellException(CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL);
	}
}

#ifdef __XLL_VERSION_4
template class XLCellRange<Excel4Types>;
#else
template class XLCellRange<Excel12Types>;
#endif
