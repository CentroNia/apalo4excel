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

#include "XLCell.h"

#include <memory>

namespace Palo {
	namespace XLL {
		
		template<class ExcelStructsWrapper>
		class XLCellRange {
		public:
			
			struct CellID {
				typename ExcelStructsWrapper::IDSHEET sheetID;
				typename ExcelStructsWrapper::WORD rw;
				typename ExcelStructsWrapper::BYTE col;

				/*! hash_map support */
				operator size_t() const;
				/*! hash_map support */
				bool operator < (const typename XLCellRange<ExcelStructsWrapper>::CellID& right) const;
			};
			//typedef typename CellID_<ExcelStructsWrapper> CellID;
			
			XLCellRange( const XLCellRange<ExcelStructsWrapper>& other );
			XLCellRange( typename ExcelStructsWrapper::XLOPERX ref );
			XLCellRange( typename ExcelStructsWrapper::LPXLOPERX ref );
			XLCellRange( const typename CellID& ref );
			~XLCellRange();

			static XLCellRange getSelection();
			static XLCellRange getCaller();

			/*
			if return value is true, the content of xCaller must be freed by either calling
			getCallerProcess(&xCaller) or
			ExcelStructsWrapper::Excelx(xlFree, NULL, 0, (ExcelStructsWrapper::LPXLOPERX)&xCaller);
			*/
			static bool getCallerCheck(bool dothrow, typename ExcelStructsWrapper::XLOPERX *xCaller);
			static XLCellRange getCallerProcess(typename ExcelStructsWrapper::XLOPERX *xCaller);


			static std::string getSelectedBookSheetName();
			static std::string getCallingBookSheetName();

			RW getRows() const;
			COL getCols() const;

			RW getFirstRow() const;
			RW getLastRow() const;
			COL getFirstCol() const;
			COL getLastCol() const;

			XLCellRange<ExcelStructsWrapper>& operator= (const XLCellRange<ExcelStructsWrapper>& other);

			void select();

			struct Color {
				Color();

				/*! Convert from Excel */
				Color(int excel_color);
				
				/*! Convert to Excel
				 *  
				 *  Throws exception when called with color == Other. 
				 */
				operator int() const;

				enum ColorValue {
					Automatic = 0,
					Gray = 48,
					Blue = 5,
					Red = 3,
					Other = -1
				} color;
			};

			typename XLCellRange::Color getColor() const;
			/*! \warning Changes selection!!! */
			void setColor(Color color);

			// to be implemented on demand
			//std::unique_ptr<XLCell> deref();

			// arguments are offsets
			XLCellRange getSubrange( COL colfirst, COL collast, RW rowfirst, RW rowlast );

			typedef std::string CellKey;
			typedef std::vector<CellKey> CellKeyArray;
			CellKey getKey();
			CellKeyArray getKeys();

			static typename CellID getCallerID(void *dummy = NULL);
			typename CellID getCellID();

		private:
			static const int CellPropertyColor = 24;

			/*! used in assignment operator and copy ctor */
			void assign(const XLCellRange& other);
			void check();

			template<int xlfunc>
			static std::string getBookSheetName();

			typename ExcelStructsWrapper::XLMREFX _mref;
			typename ExcelStructsWrapper::XLOPERX _ref;
			typename ExcelStructsWrapper::LPXLOPERX ref;

			typename ExcelStructsWrapper::XLREFX getXLREF() const;
		};

		template< class ExcelStructsWrapper>
		inline bool XLCellRange<ExcelStructsWrapper>::CellID::operator < ( typename const  XLCellRange<ExcelStructsWrapper>::CellID& right) const {
			typename const XLCellRange<ExcelStructsWrapper>::CellID& left = *this;

			if( left.sheetID == right.sheetID ) {
				if( left.rw == right.rw ) {
					return left.col < right.col;
				} else {
					return left.rw < right.rw;
				}
			} else {
				return left.sheetID < right.sheetID;
			}
		}

		template< class ExcelStructsWrapper>
		inline XLCellRange<ExcelStructsWrapper>::CellID::operator size_t() const {
			
			return rw + col * XLCell<ExcelStructsWrapper>::max_rows + sheetID * XLCell<ExcelStructsWrapper>::max_rows * XLCell<ExcelStructsWrapper>::max_cols;
		}
	}
}
#endif
