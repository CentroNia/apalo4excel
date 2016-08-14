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
#ifndef _XLTYPES_H_
#define _XLTYPES_H_

#include <xlcall.h>
#ifndef __XLL_VERSION_4
#	include "CTypes.h"
#endif
#include "xl.h"

#ifdef __XLL_VERSION_4

class Excel4Types 
{
public:
	typedef XLOPER XLOPERX;
	typedef LPXLOPER LPXLOPERX;
	typedef XLREF XLREFX;
	typedef XLMREF XLMREFX;
	typedef WORD WORD;
	typedef DWORD DWORD;
	typedef BYTE BYTE;
	typedef IDSHEET IDSHEET;

	inline static XLOPER TempStr_noalloc_x( LPSTR str, void( *free_func )( void * ) ) {
		return TempStr_noalloc(str, free_func);
	}

	inline static int get_int_x( LPXLOPER oper, int *n ) {
		return get_int( oper, n );
	}

	inline static int get_bool_x( LPXLOPER oper, short int *n ) {
		return get_bool( oper, n );
	}

	inline static int get_double_x( LPXLOPER oper, double *d, short int get_upper_left, short int from_str ) {
		return get_double( oper, d, get_upper_left, from_str );
	}

	inline static char *get_string_direct_x( LPXLOPER oper, size_t *length, short int *must_free) {
		return get_string_direct( oper, length, must_free );
	}

	inline static char *create_cleartext_key_x(LPXLOPER xCaller ) {
		return create_cleartext_key(xCaller);
	}

	inline static char *get_book_sheet_x(LPXLOPER xCaller) {
		return get_book_sheet(xCaller, 0);
	}

	inline static int Excelx(int xlfn, LPXLOPER operRes, int count){
		return Excel4( xlfn, operRes, 0 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1 ){
		return Excel4( xlfn, operRes, 1, l1 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2 ){
		return Excel4( xlfn, operRes, 2, l1, l2 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3 ){
		return Excel4( xlfn, operRes, 3, l1, l2, l3 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4 ){
		return Excel4( xlfn, operRes, 4, l1, l2, l3, l4 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5 ){
		return Excel4( xlfn, operRes, 5, l1, l2, l3, l4, l5 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6 ){
		return Excel4( xlfn, operRes, 6, l1, l2, l3, l4, l5, l6 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7 ){
		return Excel4( xlfn, operRes, 7, l1, l2, l3, l4, l5, l6, l7);
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8 ){
		return Excel4( xlfn, operRes, 8, l1, l2, l3, l4, l5, l6, l7, l8 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8, LPXLOPER l9 ){
		return Excel4( xlfn, operRes, 9, l1, l2, l3, l4, l5, l6, l7, l8, l9 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8, LPXLOPER l9, LPXLOPER l10 ){
		return Excel4( xlfn, operRes, 10, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8, LPXLOPER l9, LPXLOPER l10, LPXLOPER l11 ){
		return Excel4( xlfn, operRes, 11, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8, LPXLOPER l9, LPXLOPER l10, LPXLOPER l11, LPXLOPER l12 ){
		return Excel4( xlfn, operRes, 12, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8, LPXLOPER l9, LPXLOPER l10, LPXLOPER l11, LPXLOPER l12, LPXLOPER l13 ){
		return Excel4( xlfn, operRes, 13, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8, LPXLOPER l9, LPXLOPER l10, LPXLOPER l11, LPXLOPER l12, LPXLOPER l13, LPXLOPER l14 ){
		return Excel4( xlfn, operRes, 14, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8, LPXLOPER l9, LPXLOPER l10, LPXLOPER l11, LPXLOPER l12, LPXLOPER l13, LPXLOPER l14, LPXLOPER l15 ){
		return Excel4( xlfn, operRes, 15, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8, LPXLOPER l9, LPXLOPER l10, LPXLOPER l11, LPXLOPER l12, LPXLOPER l13, LPXLOPER l14, LPXLOPER l15, LPXLOPER l16 ){
		return Excel4( xlfn, operRes, 16, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16 );
	}
	inline static int Excelx(int xlfn, LPXLOPER operRes, int count, LPXLOPER l1, LPXLOPER l2, LPXLOPER l3, LPXLOPER l4, LPXLOPER l5, LPXLOPER l6, LPXLOPER l7, LPXLOPER l8, LPXLOPER l9, LPXLOPER l10, LPXLOPER l11, LPXLOPER l12, LPXLOPER l13, LPXLOPER l14, LPXLOPER l15, LPXLOPER l16, LPXLOPER l17 ){
		return Excel4( xlfn, operRes, 17, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17 );
	}
};

#else

class Excel12Types 
{
public:
	typedef XLOPER12 XLOPERX;
	typedef LPXLOPER12 LPXLOPERX;
	typedef XLREF12 XLREFX;
	typedef XLMREF12 XLMREFX;
	typedef DWORD WORD;
	typedef DWORD DWORD;
	typedef BYTE BYTE;
	typedef IDSHEET IDSHEET;

	inline static XLOPER TempStr_noalloc_x( LPSTR str, void( *free_func )( void * ) ) {
		return TempStr_noalloc(str, free_func);
	}

	inline static int get_int_x( LPXLOPER12 oper, int *n ) {
		return get_int( oper, n );
	}

	inline static int get_bool_x( LPXLOPER12 oper, short int *n ) {
		return get_bool( oper, n );
	}

	inline static int get_double_x( LPXLOPER12 oper, double *d, short int get_upper_left, short int from_str ) {
		return get_double( oper, d, get_upper_left, from_str );
	}
	
	inline static char *get_string_direct_x( LPXLOPER12 oper, size_t *length, short int *must_free) {
		return get_string_direct( oper, length, must_free );
	}

	inline static char *create_cleartext_key_x(LPXLOPER12 xCaller ) {
		return create_cleartext_key(xCaller);
	}

	inline static char *get_book_sheet_x(LPXLOPER12 xCaller) {
		return get_book_sheet(xCaller, 0);
	}

	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count){
		return Excel12( xlfn, operRes, 0 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1 ){
		return Excel12( xlfn, operRes, 1, l1 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2 ){
		return Excel12( xlfn, operRes, 2, l1, l2 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3 ){
		return Excel12( xlfn, operRes, 3, l1, l2, l3 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4 ){
		return Excel12( xlfn, operRes, 4, l1, l2, l3, l4 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5 ){
		return Excel12( xlfn, operRes, 5, l1, l2, l3, l4, l5 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6 ){
		return Excel12( xlfn, operRes, 6, l1, l2, l3, l4, l5, l6 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7 ){
		return Excel12( xlfn, operRes, 7, l1, l2, l3, l4, l5, l6, l7);
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8 ){
		return Excel12( xlfn, operRes, 8, l1, l2, l3, l4, l5, l6, l7, l8 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8, LPXLOPER12 l9 ){
		return Excel12( xlfn, operRes, 9, l1, l2, l3, l4, l5, l6, l7, l8, l9 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8, LPXLOPER12 l9, LPXLOPER12 l10 ){
		return Excel12( xlfn, operRes, 10, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8, LPXLOPER12 l9, LPXLOPER12 l10, LPXLOPER12 l11 ){
		return Excel12( xlfn, operRes, 11, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8, LPXLOPER12 l9, LPXLOPER12 l10, LPXLOPER12 l11, LPXLOPER12 l12 ){
		return Excel12( xlfn, operRes, 12, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8, LPXLOPER12 l9, LPXLOPER12 l10, LPXLOPER12 l11, LPXLOPER12 l12, LPXLOPER12 l13 ){
		return Excel12( xlfn, operRes, 13, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8, LPXLOPER12 l9, LPXLOPER12 l10, LPXLOPER12 l11, LPXLOPER12 l12, LPXLOPER12 l13, LPXLOPER12 l14 ){
		return Excel12( xlfn, operRes, 14, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8, LPXLOPER12 l9, LPXLOPER12 l10, LPXLOPER12 l11, LPXLOPER12 l12, LPXLOPER12 l13, LPXLOPER12 l14, LPXLOPER12 l15 ){
		return Excel12( xlfn, operRes, 15, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8, LPXLOPER12 l9, LPXLOPER12 l10, LPXLOPER12 l11, LPXLOPER12 l12, LPXLOPER12 l13, LPXLOPER12 l14, LPXLOPER12 l15, LPXLOPER12 l16 ){
		return Excel12( xlfn, operRes, 16, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16 );
	}
	inline static int Excelx(int xlfn, LPXLOPER12 operRes, int count, LPXLOPER12 l1, LPXLOPER12 l2, LPXLOPER12 l3, LPXLOPER12 l4, LPXLOPER12 l5, LPXLOPER12 l6, LPXLOPER12 l7, LPXLOPER12 l8, LPXLOPER12 l9, LPXLOPER12 l10, LPXLOPER12 l11, LPXLOPER12 l12, LPXLOPER12 l13, LPXLOPER12 l14, LPXLOPER12 l15, LPXLOPER12 l16, LPXLOPER12 l17 ){
		return Excel12( xlfn, operRes, 17, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17 );
	}	
};
#endif // __XLL_VERSION_4

#endif