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

#include "XLCellRange.h"
#include "XLCellException.h"
#include "xl.h"

using namespace Palo::XLL;


XLCellRange::XLCellRange( const XLCellRange& other ) {
	assign(other);
}


XLCellRange::XLCellRange( XLOPERX aref ) : _ref( aref ), ref( &_ref ) {
	check();
}


XLCellRange::XLCellRange( LPXLOPERX aref ) : ref( aref ) {
	check();
}


XLCellRange::XLCellRange( const CellID& aref ) : ref( &_ref ) {
	_ref.xltype = xltypeRef;
	_ref.val.mref.idSheet = aref.sheetID;
	_ref.val.mref.lpmref = &_mref;

	_mref.count = 1;
	_mref.reftbl[0].colFirst = _mref.reftbl[0].colLast = aref.col;
	_mref.reftbl[0].rwFirst = _mref.reftbl[0].rwLast = aref.rw;
}

XLCellRange& XLCellRange::operator= (const XLCellRange& other) {
	assign(other);

	return *this;
}


void XLCellRange::assign(const XLCellRange& other) {
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


XLREFX XLCellRange::getXLREF() const {
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



void XLCellRange::select() {
	if( Excelx( xlcSelect, NULL, 1, ref) != xlretSuccess ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}
}


XLCellRange::Color XLCellRange::getColor() const {
	XLOPERX xTemp, xRes;

	xTemp.xltype = xltypeInt;
	xTemp.val.w = CellPropertyColor;

	if ( Excelx( xlfGetCell, (LPXLOPERX)&xRes, 2, (LPXLOPERX)&xTemp, ref) != xlretSuccess ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}

	int result = (int)xRes.val.num;

	bool failed = (xRes.xltype != xltypeNum);
	Excelx( xlFree, NULL, 1, (LPXLOPERX)&xRes);
	
	if (failed) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}

	return Color::Color(result);
}


void XLCellRange::setColor(Color color) {	
	select();

	XLOPERX xColor, xMissing;

	xColor.xltype = xltypeNum;
	xColor.val.num = (int)color;

	xMissing.xltype = xltypeMissing;

	if( Excelx(xlcFontProperties, NULL, 14, (LPXLOPERX)&xMissing, (LPXLOPERX)&xMissing, (LPXLOPERX)&xMissing,
		(LPXLOPERX)&xMissing, (LPXLOPERX)&xMissing, (LPXLOPERX)&xMissing, (LPXLOPERX)&xMissing, (LPXLOPERX)&xMissing,
		(LPXLOPERX)&xMissing, (LPXLOPERX)&xColor, (LPXLOPERX)&xMissing, (LPXLOPERX)&xMissing,
		(LPXLOPERX)&xMissing, (LPXLOPERX)&xMissing) != xlretSuccess ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}
}

template<int xlfunc>
std::string XLCellRange::getBookSheetName() {
	XLOPERX xRes;

	if( Excelx(xlfunc, (LPXLOPERX)&xRes, 0) != xlretSuccess || xRes.xltype == xltypeErr) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
	}

	try {
		char *result = get_book_sheet(&xRes, 0);

		Excelx(xlFree, NULL, 1, (LPXLOPERX)&xRes);

		if (result == NULL) {
			throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
		}

		std::string real_result = result;

		free(result);

		return real_result;
	} catch(...) {
		Excelx(xlFree, NULL, 1, (LPXLOPERX)&xRes);

		throw;
	}
}


std::string XLCellRange::getSelectedBookSheetName() {
	return getBookSheetName<xlfSelection>();
}


std::string XLCellRange::getCallingBookSheetName() {
	return getBookSheetName<xlfCaller>();
}


XLCellRange::CellID XLCellRange::getCallerID(void *dummy) {
	return XLCellRange::getCaller().getCellID();
}


XLCellRange::CellID XLCellRange::getCellID() {
	XLOPERX xRes2, xTemp;
	int res;
	
	xTemp.xltype = xltypeInt;
	xTemp.val.w = xltypeRef;
	res = Excelx(xlCoerce, (LPXLOPERX)&xRes2, 2, ref, (LPXLOPERX)&xTemp);
	if (res != xlretSuccess || xRes2.xltype != xltypeRef) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}

	struct CellID cid;

	cid.col = xRes2.val.mref.lpmref->reftbl[0].colFirst;
	cid.rw = xRes2.val.mref.lpmref->reftbl[0].rwFirst;
	cid.sheetID = xRes2.val.mref.idSheet;

	Excelx(xlFree, NULL, 1, (LPXLOPERX)&xRes2);

	return cid;
}


void XLCellRange::check() {
	if (( ref->xltype != xltypeSRef ) && ( ref->xltype != xltypeRef )){
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_CELL_NOT_REF );
	}
}


XLCellRange::~XLCellRange() {}


XLCellRange XLCellRange::getSelection() {
	XLOPERX xCaller;

	if ( Excelx( xlfSelection, ( LPXLOPERX )&xCaller, 0 ) != xlretSuccess || xCaller.xltype == xltypeErr ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
	}

	XLCellRange range = XLCellRange( xCaller );

	Excelx(xlFree, NULL, 0, (LPXLOPERX)&xCaller);

	return range;
}



bool XLCellRange::getCallerCheck(bool dothrow, XLOPERX *xCaller) {
	if ( (Excelx( xlfCaller, ( LPXLOPERX )xCaller, 0 ) != xlretSuccess) || (xCaller->xltype == xltypeErr) ) {
		if (dothrow) {
			throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
		} else {
			return false;
		}
	}

	return true;

}


XLCellRange XLCellRange::getCallerProcess(XLOPERX *xCaller) {

	XLCellRange range = XLCellRange( *xCaller );

	Excelx(xlFree, NULL, 0, (LPXLOPERX)xCaller);

	return range;
}



XLCellRange XLCellRange::getCaller() {
	XLOPERX xCaller;

	XLCellRange::getCallerCheck(true, &xCaller);

	return XLCellRange::getCallerProcess(&xCaller);
}


RW XLCellRange::getRows() const {
	const XLREFX& xlref = getXLREF();
	return xlref.rwLast - xlref.rwFirst + 1;
}


COL XLCellRange::getCols() const {
	const XLREFX& xlref = getXLREF();
	return xlref.colLast - xlref.colFirst + 1;
}


RW XLCellRange::getFirstRow() const {
	return getXLREF().rwFirst;
}


RW XLCellRange::getLastRow() const {
	return getXLREF().rwLast;
}


COL XLCellRange::getFirstCol() const {
	return getXLREF().colFirst;
}


COL XLCellRange::getLastCol() const {
	return getXLREF().colLast;
}


XLCellRange XLCellRange::getSubrange( COL colfirst, COL collast, RW rowfirst, RW rowlast ) {
	XLOPERX r = *ref;

	r.val.sref.ref.colLast = r.val.sref.ref.colFirst;
	r.val.sref.ref.colFirst += colfirst;
	r.val.sref.ref.colLast += collast;
	r.val.sref.ref.rwLast = r.val.sref.ref.rwFirst;
	r.val.sref.ref.rwFirst += rowfirst;
	r.val.sref.ref.rwLast += rowlast;

	return XLCellRange( r );
}


XLCellRange::CellKey XLCellRange::getKey() {
	char *k = create_cleartext_key( ref );

	if (!k) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
	}

	CellKey key( k );

	free( k );

	return key;
}


XLCellRange::CellKeyArray XLCellRange::getKeys() {
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


XLCellRange::Color::Color() {
	color = Automatic;
}


XLCellRange::Color::Color(int excel_color) {
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


XLCellRange::Color::operator int() const {
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
