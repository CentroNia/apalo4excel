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

#ifndef XL_FUNCS_DOC_H
#define XL_FUNCS_DOC_H

#include "funcs.h"

struct xl_func_decl {
	const char *a[SECONDARG];
	size_t count;
	short int is_xl_func;
};

#ifdef __cplusplus
#undef ERROR_NOT_FOUND
#include "SpreadsheetFuncsDoc.h"

#include "unicode_win.h"

using namespace Palo::Types;

namespace Palo {
	namespace XLL {
		struct XLFuncsDoc {
		public:
			static const XLFuncsDoc& getInstance();
			/* zero terminated array */
			StringArray getDecl( const Palo::SpreadsheetFuncs::FunctionDocumentation& fd ) const;
		private :
				XLFuncsDoc();
		};
	}
}

extern "C" size_t xl_funcs_get_func_num();
extern "C" const struct xl_func_decl *xl_func_get_func( size_t idx );

#else

size_t xl_funcs_get_func_num();
const struct xl_func_decl *xl_func_get_func( size_t idx );
#endif
#endif
