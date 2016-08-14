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

#ifndef _XLTYPES_H_
#define _XLTYPES_H_

#include <xlcall.h>

#define FUNCNUM 15

#ifdef __XLL_VERSION_4

# define Excelx Excel4
# define Excelxv Excel4v

# define SELECT_TYPE(name) name

//we have to split it like that, because otherwise we run into compiler limits (if !__XLL_VERSION_4)
# define SPLIT_XL_FUNC_MAX_ARGS1 28
# define SPLIT_XL_FUNC_MAX_ARGS2 1

# define SECONDARG 64

# define PARAM_TYPE "R"
# define PARAM2_TYPE "P"

#else

# define Excelx Excel12
# define Excelxv Excel12v

# define SELECT_TYPE(name) name ## 12

//we have to split it like that, because otherwise we run into compiler limits (if !__XLL_VERSION_4)
# define SPLIT_XL_FUNC_MAX_ARGS1 100
# define SPLIT_XL_FUNC_MAX_ARGS2 152

# define SECONDARG 256

# define PARAM_TYPE "U"
# define PARAM2_TYPE "Q"

#endif

#pragma region helper_macros
#define ADDX(name) name ## X
#define CREATE_TYPEDEF(name) typedef SELECT_TYPE(name) ADDX(name)


#define XL_ARG_PASS BOOST_PP_ENUM_PARAMS(SPLIT_XL_FUNC_MAX_ARGS1, o_), BOOST_PP_ENUM_PARAMS(SPLIT_XL_FUNC_MAX_ARGS2, o__)

#define XL_ARG_DECL BOOST_PP_ENUM_PARAMS(SPLIT_XL_FUNC_MAX_ARGS1, LPXLOPERX o_), BOOST_PP_ENUM_PARAMS(SPLIT_XL_FUNC_MAX_ARGS2, LPXLOPERX o__)

#pragma endregion helper_macros

CREATE_TYPEDEF(XLMREF);
CREATE_TYPEDEF(LPXLMREF);
CREATE_TYPEDEF(XLOPER);
CREATE_TYPEDEF(LPXLOPER);
CREATE_TYPEDEF(XLREF);
CREATE_TYPEDEF(XLMREF);

#pragma region some_defines

#define XL_FUNC_MAX_ARGS (SPLIT_XL_FUNC_MAX_ARGS1 + SPLIT_XL_FUNC_MAX_ARGS2)

#define XL_FUNC_MAX_DESC_LENGTH 255
#define XL_FUNC_MAX_SHORT_DESC_LENGTH 16
#define XL_EFFECTIVE_ARGS_TO_DESCRIBE_MAX 19

#define XL_ARG_STRING           0
#define XL_ARG_DOUBLE           1
#define XL_ARG_INT              2
#define XL_ARG_STRING_ARRAY     5
#define XL_ARG_BOOL             6

#define XL_SUCCESS              0
#define XL_FAILURE              -1
#pragma endregion some_defines

#endif
