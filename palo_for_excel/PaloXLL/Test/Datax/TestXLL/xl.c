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

#include <wchar.h>

#include "xl.h"

#define SIZE_T_TO_MAX_INT(s) (((s)>INT_MAX && (s)!=(size_t)-1) ? INT_MAX : (int)(s))

typedef enum unicode_win_err_t {
	UNICODE_WIN_SUCCESS = 0,
	UNICODE_WIN_FAILURE = -1
} unicode_win_err;

unicode_win_err utf82wcs_conv( wchar_t *r, const char *s, size_t max_len ) {
	if ( MultiByteToWideChar( CP_UTF8, 0, s, -1, r, SIZE_T_TO_MAX_INT( max_len ) ) == 0 ) {
		if ( GetLastError() != ERROR_INSUFFICIENT_BUFFER ) {
			return UNICODE_WIN_FAILURE;
		}
	}

	return UNICODE_WIN_SUCCESS;
}

unicode_win_err utf82wcs( wchar_t **wcs, const char *utf8_str ) {
	int len;

	if (( len = MultiByteToWideChar( CP_UTF8, 0, utf8_str, -1, NULL, 0 ) ) == 0 ) {
		return UNICODE_WIN_FAILURE;
	}
	/* len in wchar's */

	*wcs = ( wchar_t* )malloc( len*sizeof( wchar_t ) );
	if ( *wcs == NULL ) {
		return UNICODE_WIN_FAILURE;
	}
	utf82wcs_conv( *wcs, utf8_str, len );

	return UNICODE_WIN_SUCCESS;
}



XLOPER12 TempStr_noalloc(LPSTR str)
{
	XLOPER12 oper;
	size_t tempcount;
	wchar_t count;
	wchar_t *w;
	unicode_win_err err;

	err = utf82wcs(&w, str);

	if(err != UNICODE_WIN_SUCCESS) {
		oper.xltype=xltypeErr;
		oper.val.err=xlerrValue;
		return oper;
	}
	tempcount=wcslen(w);
	count=(tempcount > 65535 ? (wchar_t)65535:((wchar_t)tempcount));
	memmove(w+1, w, count*sizeof(wchar_t));
	w[0]=count;
	oper.xltype=xltypeStr;
	oper.val.str=w;
	return oper;
}

LPXLOPER12 TempStr(LPSTR str, int dll_free)
{
	LPXLOPER12 oper;

	oper=(LPXLOPER12)malloc(sizeof(XLOPER12));
	if(oper==NULL) {
		return NULL;
	}

	*oper=TempStr_noalloc(str);

	if (dll_free!=0) {
		oper->xltype|=xlbitDLLFree;
	}

	return oper;
}

