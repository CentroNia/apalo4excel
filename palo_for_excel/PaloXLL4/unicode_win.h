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
#ifndef UNICODE_WIN_H
#define UNICODE_WIN_H

#include <wchar.h>

typedef enum unicode_win_err_t {
	UNICODE_WIN_SUCCESS = 0,
	UNICODE_WIN_FAILURE = -1
} unicode_win_err;

#ifdef __cplusplus
extern "C"
{
#endif

unicode_win_err utf82wcs_conv( wchar_t *r, const char *s, size_t max_len );
unicode_win_err wcs2utf8_conv( char *r, const wchar_t *s, size_t len, size_t max_len ); // len ignored if -1
size_t wcs2utf8_len( const wchar_t *s, size_t len, size_t max_len ); // len ignored if -1

unicode_win_err wcs2utf8( char **utf8_str, const wchar_t *s, size_t len ); // len ignored if -1
unicode_win_err utf82wcs( wchar_t **wcs, const char *utf8_str );

#ifdef __cplusplus
}
#endif

#endif
