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

#ifndef _XLCELLSTYLER_H_
#define _XLCELLSTYLER_H_

#include <boost/noncopyable.hpp>
#include <map>

#include "XLCellRange.h"
#include "XLCellException.h"

namespace Palo {
	namespace XLL {
		
		template<class ExcelStructsWrapper>
		class XLCellStyler : boost::noncopyable {
		private:
			std::map<typename XLCellRange<ExcelStructsWrapper>::CellID, typename XLCellRange<ExcelStructsWrapper>::Color> cellList;
		public:	
			static XLCellStyler& getInstance() {
				static XLCellStyler instance;
				return instance;
			}

			void scheduleColorUpdate(typename XLCellRange<ExcelStructsWrapper>::Color color, typename XLCellRange<ExcelStructsWrapper>::CellID cellId) {
				cellList[cellId] = color;
			}

			void process(bool reset=false) 
			{
				// disable screenupdating
				ExcelStructsWrapper::XLOPERX xTemp;
				xTemp.xltype = xltypeBool;
				xTemp.val.xbool = false;

				if( ExcelStructsWrapper::Excelx( xlfEcho, 0, 1,(ExcelStructsWrapper::LPXLOPERX)&xTemp) != xlretSuccess ) {
					throw XLCellException( CurrentSourceLocation, XLLErrors::ERROR_EXCEL_CALL_FAILED );
				}
				
				// set cell color
				std::map<XLCellRange<ExcelStructsWrapper>::CellID, XLCellRange<ExcelStructsWrapper>::Color>::iterator it;
				for(it = cellList.begin(); it != cellList.end(); it++) 
				{						
					XLCellRange<ExcelStructsWrapper>& cr = XLCellRange<ExcelStructsWrapper>(it->first);

					if (cr.getColor() != it->second) {							
						cr.setColor(it->second);
					}
				}
							
				if(reset) {
					cellList.clear();
				}
			}

		private:
			XLCellStyler() {}
		};
	}
}

#endif