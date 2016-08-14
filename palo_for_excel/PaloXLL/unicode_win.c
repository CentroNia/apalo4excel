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
#include "unicode_win.h"

#define SIZE_T_TO_MAX_INT(s) (((s)>INT_MAX && (s)!=(size_t)-1) ? INT_MAX : (int)(s))
#define SIZE_T_TO_MAX_UINT(s) ((s)>UINT_MAX ? UINT_MAX : (unsigned int)(s))

#include <windows.h>

unicode_win_err utf82wcs_conv( wchar_t *r, const char *s, size_t max_len ) {
	if ( MultiByteToWideChar( CP_UTF8, 0, s, -1, r, SIZE_T_TO_MAX_INT( max_len ) ) == 0 ) {
		if ( GetLastError() != ERROR_INSUFFICIENT_BUFFER ) {
			return UNICODE_WIN_FAILURE;
		}
	}

	return UNICODE_WIN_SUCCESS;
}

unicode_win_err wcs2utf8_conv( char *r, const wchar_t *s, size_t len, size_t max_len ) {
	if ( WideCharToMultiByte( CP_UTF8, 0, s, (int)len, r, SIZE_T_TO_MAX_INT( max_len ), NULL, NULL ) == 0 ) {
		if ( GetLastError() != ERROR_INSUFFICIENT_BUFFER ) {
			return UNICODE_WIN_FAILURE;
		}
	}
	return UNICODE_WIN_SUCCESS;
}

size_t wcs2utf8_len( const wchar_t *s, size_t len, size_t max_len ) {
	size_t _len;

	if ( max_len == 0 ) {
		return 0;
	}

	_len = WideCharToMultiByte( CP_UTF8, 0, s, (int)len, NULL, 0, NULL, NULL );
	if ( _len == 0 ) {
		return ( size_t ) - 1;
	}

	return _len;
}

unicode_win_err wcs2utf8( char **utf8_str, const wchar_t *s, size_t len ) {
	size_t _len;

	if (( _len = wcs2utf8_len( s, len, (size_t)(-1) ) ) == ( size_t ) - 1 ) {
		return UNICODE_WIN_FAILURE;
	}
	
	/* len in bytes */
	*utf8_str = ( char* )malloc( _len + 1 );
	if ( *utf8_str == NULL ) {
		return UNICODE_WIN_FAILURE;
	}
	wcs2utf8_conv( *utf8_str, s, len, _len );
	(*utf8_str)[_len] = '\0';

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
