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

#ifndef XL_CELL_ITERATOR_H
#define XL_CELL_ITERATOR_H

#include "XLCell.h"

#include <memory>

namespace Palo {
	namespace XLL {
		using namespace SpreadsheetFuncs;
		
		class XLCellIteratorImpl : public GenericCellIteratorImpl {
		public:
			XLCellIteratorImpl( GenericContext& settings, LPXLOPERX oper, size_t& rows, size_t& cols, bool is_retval=false );
			~XLCellIteratorImpl();

			GenericCellIteratorImpl& operator ++();

			GenericCell* get( bool release = false );
			GenericCell* operator ->();
			GenericCell* release();

			bool end() const;
			size_t minRemaining() const;

		private:
			LPXLOPERX parent;
			unsigned int idx;
			bool is_retval;

			std::unique_ptr<GenericCell> data;

			GenericContext& settings;
		};
	}
}
#endif
