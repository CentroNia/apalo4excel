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

#ifndef XLL_MESSAGES_H
#define XLL_MESSAGES_H

#include <PaloSpreadsheetFuncs/Messages.h>

namespace Palo {
	namespace XLL {
		class XLLErrors {
		public:
			enum Errors
			{
			    ERROR_EXCEL_CALL_FAILED,
			    ERROR_XLCELL_INTERNAL,
			    ERROR_INVALID_CONNECTION,
			    ERROR_INVALID_ARGUMENT_TYPE,
			    ERROR_NOT_IMPLEMENTED,
			    ERROR_ARRAY_INDEX_OUT_OF_RANGE,
			    ERROR_CELL_NOT_REF,
				ERROR_ARGUMENT_IS_ERROR,
				ERROR_NO_MEMORY,
				ERROR_INVALID_STRING_LENGTH,
				ERROR_CONVERSION_FAILED

			};
		};

		class XLLMessages : public Palo::Util::Messages<XLLErrors::Errors> {
		private:
			XLLMessages();

		public:
			static XLLMessages& getInstance() {
				static XLLMessages m;
				return m;
			}
		};
	}
}
#endif
