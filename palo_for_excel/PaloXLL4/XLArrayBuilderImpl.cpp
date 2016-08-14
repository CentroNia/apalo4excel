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

#include "XLArrayBuilderImpl.h"
#include "XLCellException.h"

#include "xl.h"

using namespace Palo::XLL;


XLArrayBuilderImpl::XLArrayBuilderImpl( GenericContext& settings, XLCell *parent, size_t rows, size_t cols, bool pad_to_caller )
: settings( settings ), parent( parent->oper ), pad( pad_to_caller ), rows( rows ), cols( cols ), parentcell(parent)
{
	a.reserve( rows * cols );
}


XLArrayBuilderImpl::~XLArrayBuilderImpl() {
	size_t real_rows = rows, real_cols = cols;
	XLOPERX xRes;

	if ( rows == 0 ) {
		rows = a.size();
	}
	else {
		if ( cols == 0 ) {
			cols = a.size();
		}
	}

	if ( pad ) {
		if ( Excelx( xlfCaller, ( LPXLOPERX )&xRes, 0 ) != xlretSuccess ) {
			throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
		}

		if ( xRes.xltype != xltypeSRef ) {
			real_rows = rows;
			real_cols = cols;
		} else {
			real_rows = xRes.val.sref.ref.rwLast - xRes.val.sref.ref.rwFirst + 1;
			real_cols = xRes.val.sref.ref.colLast - xRes.val.sref.ref.colFirst + 1;
		}

		Excelx( xlFree, NULL, 1, ( LPXLOPERX )&xRes );
	}

	if ( rows > real_rows ) {
		real_rows = rows;
	}
	if ( cols > real_cols ) {
		real_cols = cols;
	}

	parent->val.array.lparray = ( LPXLOPERX )malloc( real_rows * real_cols * sizeof( XLOPERX ) );
	if ( parent->val.array.lparray == NULL && real_rows * real_cols != 0 ) {
		throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL );
	}
	parentcell->freeAtEnd(parent->val.array.lparray);
	parent->val.array.rows = (RW)real_rows;
	parent->val.array.columns = (COL)real_cols;

	for ( size_t row = 0; row < real_rows; ++row ) {
		size_t col = 0;
		for ( ; row < rows && col < cols; ++col ) {
			parent->val.array.lparray[row * real_cols + col] = a[row * cols + col];
		}
		for ( ; col < real_cols; ++col ) {
			parent->val.array.lparray[row * real_cols + col] = TempStr_noalloc( "", NULL );
		}
	}
}


void XLArrayBuilderImpl::append( GenericCell& v ) {
	a.push_back( *static_cast<XLCell&>( v ).oper );
}


void XLArrayBuilderImpl::append( const std::string key, GenericCell& v ) {
	append( v );
}

/*! Assumes that elements are "misordered", which means row
 *  and column counts are swapped.
 */

void XLArrayBuilderImpl::transpose() {
	std::vector<XLOPERX> opers;

	opers.reserve( a.size() );

	for ( unsigned int i = 0; i < rows; i++ )
		for ( unsigned int j = 0; j < cols; j++ )
			opers.push_back( a[j * rows + i] );

	a = opers;
}


std::unique_ptr<GenericCell> XLArrayBuilderImpl::createGenericCell() {
	std::unique_ptr<GenericCell> p;
	
	p.reset( new XLCell( settings ) );
		
	XLCell* xp = static_cast<XLCell*>(p.get());
	xp->is_retval = is_retval;

	if(cols > 0) {
		xp->offset.col = (COL)(a.size() % cols);
		xp->offset.row = (RW)(a.size() / cols);
	}	
	return p;
}
