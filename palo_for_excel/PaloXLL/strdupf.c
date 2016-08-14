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

#include "strdupf.h"

#include <stdio.h>
#include <malloc.h>

#if !defined(WIN32) && !defined(WIN64)
#ifndef va_copy
#define va_copy(dest, src) __va_copy((dest), (src));
#endif
#else
#define va_copy(dest, src) (dest)=(src)
#endif

char *strdupf( const char *format, ... ) {
	va_list l, temp;
	int len;
	char *s;

	va_start( l, format );

#ifdef VS6
#warning "TODO: this is a hack!"
	s = ( char * )malloc( STRBUFSIZE * sizeof( char ) );
#else
	va_copy( temp, l );
	len = vsnprintf( NULL, 0, format, temp ) + 1;
	va_end( temp );

	if ( len < 0 ) {
		va_end( l );
		return NULL;
	}

	s = ( char * )malloc( len * sizeof( char ) );
#endif
	if ( s == NULL ) {
		va_end( l );
		return NULL;
	}

	vsprintf( s, format, l );
	va_end( l );

	return s;
}
