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

#ifndef HAS_XL_H
#define HAS_XL_H

#define XL_ARG_STRING           0
#define XL_ARG_DOUBLE           1
#define XL_ARG_INT              2
#define XL_ARG_STRING_ARRAY     5
#define XL_ARG_BOOL             6

#define XL_SUCCESS              0
#define XL_FAILURE              -1

/* this key is used if CALLER is invalid; this is needed for correct error reporting in entry_handler */
#define XL_TEMP_ERROR_MAP_KEY   "temp"

#ifdef __cplusplus
extern "C" {
#endif
	XLOPER TempStr_noalloc( LPSTR str, void( *free_func )( void * ) );
	LPXLOPER TempStr( LPSTR str, void( *free_func )( void * ), int dll_free );	
	LPXLOPER TempNum( double d );
	LPXLOPER TempInt( int i );
	LPXLOPER TempBool( int i );
	LPXLOPER TempErr( int err );
	char **get_string_array( unsigned int *len, short int *is_vertical, LPXLOPER oper );

	char *get_string( LPXLOPER oper );
	char *get_string_direct( LPXLOPER oper, size_t *length, short int *must_free);
	int get_int( LPXLOPER oper, int *n );
	int get_bool( LPXLOPER oper, short int *n );
	int get_double( LPXLOPER oper, double *d, short int get_upper_left, short int from_str );
	char *create_cleartext_key( LPXLOPER xCaller );
	char *create_cleartext_key_current();
	char *create_data_key( char *prefix );
	char *get_book_sheet( LPXLOPER xCaller, short int current);
	char *get_sheet( LPXLOPER xCaller );
	char *get_book( LPXLOPER xCaller );
	char *get_cell( LPXLOPER xCaller );
	int get_xl_args( unsigned int num_args, ... );	
#ifdef __cplusplus
}
#endif

#define XL_ERROR_MAP_RETURN(xlerror, str_error, libpalo_error, free_err) \
	return xl_error_map_prepare(xlerror, str_error, libpalo_error, free_err);
#endif
