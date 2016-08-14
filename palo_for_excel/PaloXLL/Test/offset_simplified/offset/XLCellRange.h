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

#ifndef XL_CELL_RANGE_H
#define XL_CELL_RANGE_H

#include <memory>
#include <string>
#include <vector>

#include <ctype.h>
#include <windows.h>

#include <xlcall.h>

namespace Palo {
	namespace XLL {
		
		template<class ExcelStructsWrapper>
		class XLCellRange {
		public:
			
			struct CellID {
				typename ExcelStructsWrapper::IDSHEET sheetID;
				typename ExcelStructsWrapper::WORD rw;
				typename ExcelStructsWrapper::BYTE col;

			};
		
			XLCellRange( const XLCellRange<ExcelStructsWrapper>& other );
			XLCellRange( typename ExcelStructsWrapper::XLOPERX ref );

			~XLCellRange();

			static XLCellRange getCaller();

			static bool getCallerCheck(bool dothrow, typename ExcelStructsWrapper::XLOPERX *xCaller);
			static XLCellRange getCallerProcess(typename ExcelStructsWrapper::XLOPERX *xCaller);


			static typename CellID getCallerID();
			typename CellID getCellID();

		private:
			/*! used in assignment operator and copy ctor */
			void assign(const XLCellRange& other);

			typename ExcelStructsWrapper::XLMREFX _mref;
			typename ExcelStructsWrapper::XLOPERX _ref;
			typename ExcelStructsWrapper::LPXLOPERX ref;

			typename ExcelStructsWrapper::XLREFX getXLREF() const;
		};

	}
}
#endif
