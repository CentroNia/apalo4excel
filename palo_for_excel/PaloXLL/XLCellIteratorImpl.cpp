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

#include "XLCellIteratorImpl.h"

#include "XLCellException.h"

using namespace Palo::XLL;
template<class ExcelStructsWrapper>
XLCellIteratorImpl<ExcelStructsWrapper>::XLCellIteratorImpl( GenericContext& settings, typename ExcelStructsWrapper::LPXLOPERX oper, size_t& rows, size_t& cols, bool is_retval ) : idx( 0 ), parent( oper ), settings( settings ), is_retval(is_retval) {
	if ( oper->xltype != xltypeMulti )
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_INVALID_ARGUMENT_TYPE );

	rows = parent->val.array.rows;
	cols = parent->val.array.columns;

	if ( rows * cols != 0 ) {		
		XLCell<ExcelStructsWrapper> *cel = new XLCell<ExcelStructsWrapper>( settings, &parent->val.array.lparray[idx], is_retval );	
		cel->offset.row = (RW)(idx / cols);
		cel->offset.col = idx % cols;
		data.reset( cel );		
	}
}

template<class ExcelStructsWrapper>
XLCellIteratorImpl<ExcelStructsWrapper>::~XLCellIteratorImpl() {}

template<class ExcelStructsWrapper>
GenericCellIteratorImpl& XLCellIteratorImpl<ExcelStructsWrapper>::operator ++() {
	if ( end() )
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_ARRAY_INDEX_OUT_OF_RANGE );

	idx++;
	if ( !end() ) 
	{
		XLCell<ExcelStructsWrapper> *cel = new XLCell<ExcelStructsWrapper>( settings, &parent->val.array.lparray[idx], is_retval );	
		cel->offset.row = idx / parent->val.array.columns;
		cel->offset.col = idx % parent->val.array.columns;
		data.reset( cel );
	}
	return *this;
}

template<class ExcelStructsWrapper>
GenericCell* XLCellIteratorImpl<ExcelStructsWrapper>::get( bool release ) {
	if ( end() ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_ARRAY_INDEX_OUT_OF_RANGE );
	}

	return release ? data.release() : data.get();
}

template<class ExcelStructsWrapper>
GenericCell* XLCellIteratorImpl<ExcelStructsWrapper>::operator ->() {
	return get();
}

template<class ExcelStructsWrapper>
GenericCell* XLCellIteratorImpl<ExcelStructsWrapper>::release() {
	return get( true );
}

template<class ExcelStructsWrapper>
bool XLCellIteratorImpl<ExcelStructsWrapper>::end() const {
	return minRemaining() == 0;
}

template<class ExcelStructsWrapper>
size_t XLCellIteratorImpl<ExcelStructsWrapper>::minRemaining() const {
	return ( parent->val.array.rows * parent->val.array.columns ) - idx;
}

#ifdef __XLL_VERSION_4
template class XLCellIteratorImpl<Excel4Types>;
#else
template class XLCellIteratorImpl<Excel12Types>;
#endif