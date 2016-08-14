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

#ifndef XL_ARRAY_BUILDER_IMPL_H
#define XL_ARRAY_BUILDER_IMPL_H

#include <vector>

#include <PaloSpreadsheetFuncs\GenericArrayBuilder.h>

#include "XLCell.h"

namespace Palo {
	namespace XLL {
		using namespace SpreadsheetFuncs;
		
		template<class ExcelStructsWrapper>
		class XLArrayBuilderImpl : public GenericArrayBuilderImpl {
		private:
			typename ExcelStructsWrapper::LPXLOPERX parent;
			bool pad;

			size_t rows, cols;
			bool is_retval;
			typename XLCell<ExcelStructsWrapper> *parentcell;

		public:
			XLArrayBuilderImpl( GenericContext& settings, XLCell<ExcelStructsWrapper> *parent, size_t rows, size_t cols, bool pad_to_caller );
			~XLArrayBuilderImpl();

			void append( GenericCell& v );
			void append( const std::string key, GenericCell& v );
			void transpose();

			std::unique_ptr<GenericCell> createGenericCell();

			// TODO: use some other datatype (-> refcounts...)
			std::vector< typename ExcelStructsWrapper::XLOPERX> a;

			GenericContext& settings;
		};
	}
}
#endif
