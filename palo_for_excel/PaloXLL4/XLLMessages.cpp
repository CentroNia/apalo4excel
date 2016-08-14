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

#include "XLLMessages.h"

using namespace Palo::XLL;

XLLMessages::XLLMessages() {
	msgs[XLLErrors::ERROR_EXCEL_CALL_FAILED] = "Excel API call failed.";
	msgs[XLLErrors::ERROR_XLCELL_INTERNAL] = "Internal cell value handling error.";
	msgs[XLLErrors::ERROR_INVALID_CONNECTION] = "Invalid connection passed.";
	msgs[XLLErrors::ERROR_INVALID_ARGUMENT_TYPE] = "Argument is of invalid type.";
	msgs[XLLErrors::ERROR_NOT_IMPLEMENTED] = "Function not implemented yet (this should never happen).";
	msgs[XLLErrors::ERROR_ARRAY_INDEX_OUT_OF_RANGE] = "Array index out of range.";
	msgs[XLLErrors::ERROR_CELL_NOT_REF] = "Given cell is not a reference.";
	msgs[XLLErrors::ERROR_ARGUMENT_IS_ERROR] = "An Excel error value has been passed as argument.";
	msgs[XLLErrors::ERROR_NO_MEMORY] = "Memory allocation failed.";
	msgs[XLLErrors::ERROR_INVALID_STRING_LENGTH] = "String lenght is invalid.";
	msgs[XLLErrors::ERROR_CONVERSION_FAILED] = "Conversion failed.";
}
