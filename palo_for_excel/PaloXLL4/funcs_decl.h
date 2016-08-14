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



#ifdef __XLL_VERSION_4

LPSTR funcs[FUNCNUM][SECONDARG] =
{
    /* "name"											"params"	"displayed name"							"displayed params"	"type (0=hidden; 1=norm; 2=macro)"	"category"		"key"	"help topic"	"function_help"		"argument_help_arg1" "argument_help_arg2" ... (has to be terminated with NULL!!! */
    { FUNC_ENTRY_POINT_STR( enable_loop ),              "RR!",      FUNC_XL_NAME( "ENABLE_LOOP" ),				"",                 "0",								FUNC_CATEGORY,  "",     "",             "",					NULL },
    { FUNC_ENTRY_POINT_STR( enable_xll ),               "RR!",      FUNC_XL_NAME( "ENABLE_XLL" ),				"",                 "0",                                FUNC_CATEGORY,  "",     "",             "",					NULL },
    { FUNC_ENTRY_POINT_STR( cleanup ),					"R!",	    FUNC_XL_NAME( "CLEANUP" ),					"",                 "0",                                FUNC_CATEGORY,  "",     "",             "",					NULL },
	{ FUNC_ENTRY_POINT_STR( enable_undo_coloring ),     "RR!",      FUNC_XL_NAME( "ENABLE_UNDO_COLORING" ),		"",                 "0",                                FUNC_CATEGORY,  "",     "",             "",					NULL },
    { FUNC_ENTRY_POINT_STR( recalc_handler ),           "R#",       FUNC_XL_NAME( "RECALC_HANDLER" ),			"",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( calc_sheet ),				"R#",       FUNC_XL_NAME( "CALCSHEET" ),				"",                 "2",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
    { FUNC_ENTRY_POINT_STR( error_info ),               "R#",       FUNC_XL_NAME( "ERROR_INFO" ),               "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
    { FUNC_ENTRY_POINT_STR( clear_errors ),             "R#",       FUNC_XL_NAME( "CLEAR_ERRORS" ),             "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
    { FUNC_ENTRY_POINT_STR( write_array ),              "RRRR#",    FUNC_XL_NAME( "WRITE_ARRAY" ),              "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
    { FUNC_ENTRY_POINT_STR( close_connections ),        "R#",       FUNC_XL_NAME( "CLOSE_CONNECTIONS" ),        "",                 "2",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( excel_open ),               "RRR#",     FUNC_XL_NAME( "EXCEL.OPEN" ),               "",					"0",                                FUNC_CATEGORY,  "",     "",             "",					NULL },
    { FUNC_ENTRY_POINT_STR( prepare_snapshot ),         "R#",       FUNC_XL_NAME( "PREPARE_SNAPSHOT" ),         "",                 "2",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( set_recalc_handler ),       "R#",       FUNC_XL_NAME( "SET_RECALC_HANDLER" ),       "",                 "2",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( connection_user ),          "RP!#",     FUNC_XL_NAME( "CONNECTIONUSER" ),			"",                 "0",								FUNC_CATEGORY,  "",     "",             "",					NULL },
	{ FUNC_ENTRY_POINT_STR( user_groups ),				"RP!#",     FUNC_XL_NAME( "USERGROUPS" ),				"",                 "0",								FUNC_CATEGORY,  "",     "",             "",					NULL }
};

#else

LPSTR funcs[FUNCNUM][SECONDARG] =
{
	/* "name"											"params"	"displayed name"							"displayed params"	"type (0=hidden; 1=norm; 2=macro)"	"category"		"key"	"help topic"	"function_help"		"argument_help_arg1" "argument_help_arg2" ... (has to be terminated with NULL!!! */
	{ FUNC_ENTRY_POINT_STR( enable_loop ),              "UU!",      FUNC_XL_NAME( "ENABLE_LOOP" ),              "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( enable_xll ),               "UU!",      FUNC_XL_NAME( "ENABLE_XLL" ),               "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
    { FUNC_ENTRY_POINT_STR( cleanup ),					"U!",	    FUNC_XL_NAME( "CLEANUP" ),					"",                 "0",                                FUNC_CATEGORY,  "",     "",             "",					NULL },
	{ FUNC_ENTRY_POINT_STR( enable_undo_coloring ),     "UU!",      FUNC_XL_NAME( "ENABLE_UNDO_COLORING" ),     "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( recalc_handler ),           "U#",       FUNC_XL_NAME( "RECALC_HANDLER" ),           "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( calc_sheet ),				"U#",       FUNC_XL_NAME( "CALCSHEET" ),				"",                 "2",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( error_info ),               "U#",       FUNC_XL_NAME( "ERROR_INFO" ),               "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
    { FUNC_ENTRY_POINT_STR( clear_errors ),             "U#",       FUNC_XL_NAME( "CLEAR_ERRORS" ),             "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( write_array ),              "UUUU#",    FUNC_XL_NAME( "WRITE_ARRAY" ),              "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( close_connections ),        "U#",       FUNC_XL_NAME( "CLOSE_CONNECTIONS" ),        "",                 "2",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( excel_open ),               "UUU#",     FUNC_XL_NAME( "EXCEL.OPEN" ),               "",                 "0",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( prepare_snapshot ),         "U#",       FUNC_XL_NAME( "PREPARE_SNAPSHOT" ),         "",                 "2",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( set_recalc_handler ),       "U#",       FUNC_XL_NAME( "SET_RECALC_HANDLER" ),       "",                 "2",                                FUNC_CATEGORY,  "",     "",             "",                 NULL },
	{ FUNC_ENTRY_POINT_STR( connection_user ),          "UQ!#",     FUNC_XL_NAME( "CONNECTIONUSER" ),			"",                 "0",								FUNC_CATEGORY,  "",     "",             "",					NULL },
	{ FUNC_ENTRY_POINT_STR( user_groups ),				"UQ!#",     FUNC_XL_NAME( "USERGROUPS" ),				"",                 "0",								FUNC_CATEGORY,  "",     "",             "",					NULL }
};

#endif
