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


#include <iostream>

#include "XLCellRange.h"
#include "XLTypes.h"

using namespace Palo::XLL;

template<class ExcelStructsWrapper>
Palo::XLL::XLCellRange<ExcelStructsWrapper>::XLCellRange( const XLCellRange<ExcelStructsWrapper>& other ) {
	assign(other);
}

template<class ExcelStructsWrapper>
Palo::XLL::XLCellRange<ExcelStructsWrapper>::XLCellRange( typename ExcelStructsWrapper::XLOPERX aref ) : _ref( aref ), ref( &_ref ) {
}

template<class ExcelStructsWrapper>
void Palo::XLL::XLCellRange<ExcelStructsWrapper>::assign(const XLCellRange& other) {
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
typename ExcelStructsWrapper::XLREFX Palo::XLL::XLCellRange<ExcelStructsWrapper>::getXLREF() const {
	if (ref->xltype == xltypeSRef) {
		return ref->val.sref.ref;
	} else {
		return ref->val.mref.lpmref->reftbl[0];
	}
}

template<class ExcelStructsWrapper>
typename Palo::XLL::XLCellRange<ExcelStructsWrapper>::CellID Palo::XLL::XLCellRange<ExcelStructsWrapper>::getCallerID() {
	XLCellRange range = XLCellRange::getCaller();
	std::cout << "range ptr: \t '" << &range << '\'' << std::endl;
	XLCellRange<ExcelStructsWrapper>::CellID cid = range.getCellID();
	return cid;
}

template<class ExcelStructsWrapper>
typename Palo::XLL::XLCellRange<ExcelStructsWrapper>::CellID
Palo::XLL::XLCellRange<ExcelStructsWrapper>::getCellID() {
	ExcelStructsWrapper::XLOPERX xRes2, xTemp;
	
	std::cout << "this ptr: \t '" << this << '\'' << std::endl;

	xTemp.xltype = xltypeInt;
	xTemp.val.w = xltypeRef;
	/*
	res = ExcelStructsWrapper::Excelx(xlCoerce, (ExcelStructsWrapper::LPXLOPERX)&xRes2, 2, ref, (ExcelStructsWrapper::LPXLOPERX)&xTemp);

	if (res != xlretSuccess || xRes2.xltype != xltypeRef) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
	}
	*/

	xRes2 = *ref;

	struct CellID cid;

	cid.col = 8;
	cid.rw = 1;
	cid.sheetID = 1;

//	ExcelStructsWrapper::Excelx(xlFree, NULL, 1, (ExcelStructsWrapper::LPXLOPERX)&xRes2);

	return cid;
}

template<class ExcelStructsWrapper>
Palo::XLL::XLCellRange<ExcelStructsWrapper>::~XLCellRange() {}

template<class ExcelStructsWrapper>
bool Palo::XLL::XLCellRange<ExcelStructsWrapper>::getCallerCheck(bool dothrow, typename ExcelStructsWrapper::XLOPERX *xCaller) {
	/*
	if ( (ExcelStructsWrapper::Excelx( xlfCaller, ( ExcelStructsWrapper::LPXLOPERX )xCaller, 0 ) != xlretSuccess) || (xCaller->xltype == xltypeErr) ) {
		return false;
	} */

	xCaller->xltype = xltypeSRef;
	xCaller->val.sref.count = 1;
	xCaller->val.sref.ref.rwFirst = 8;
	xCaller->val.sref.ref.rwLast = 8;
	xCaller->val.sref.ref.colFirst = 1;
	xCaller->val.sref.ref.colLast = 1;

	return true;

}

template<class ExcelStructsWrapper>
Palo::XLL::XLCellRange<ExcelStructsWrapper> Palo::XLL::XLCellRange<ExcelStructsWrapper>::getCallerProcess(typename ExcelStructsWrapper::XLOPERX *xCaller) {

	XLCellRange range = XLCellRange( *xCaller );

//	ExcelStructsWrapper::Excelx(xlFree, NULL, 0, (ExcelStructsWrapper::LPXLOPERX)xCaller);

	return range;
}


template<class ExcelStructsWrapper>
Palo::XLL::XLCellRange<ExcelStructsWrapper> Palo::XLL::XLCellRange<ExcelStructsWrapper>::getCaller() {
	ExcelStructsWrapper::XLOPERX xCaller;

	XLCellRange<ExcelStructsWrapper>::getCallerCheck(true, &xCaller);

	return XLCellRange<ExcelStructsWrapper>::getCallerProcess(&xCaller);
}

#ifdef __XLL_VERSION_4
template class Palo::XLL::XLCellRange<Excel4Types>;
#else
template class Palo::XLL::XLCellRange<Excel12Types>;
#endif
