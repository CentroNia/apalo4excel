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

#include <string>
#include <vector>

#include "XLRegistry.h"
#include "XLFuncsDoc.h"

#define NOMINMAX

#ifdef __XLL_VERSION_4		
#	define	PARAM_TYPE "R"
#	define	PARAM2_TYPE "P"
#else
#	define	PARAM_TYPE "U"
#	define	PARAM2_TYPE "Q"
#endif


using namespace Palo::XLL;
using namespace Palo::SpreadsheetFuncs;

const std::string XLFuncsDoc::lang = XLRegistry::getLanguage();
const std::string XLFuncsDoc::emptyString("");

XLFuncsDoc::XLFuncsDoc() {}

const XLFuncsDoc& XLFuncsDoc::getInstance() {
	static XLFuncsDoc doc;
	return doc;
}


/*	"entry point",
	"param types",
	"displayed name",
	"displayed params",
	"type (0=hidden; 1=norm; 2=macro)",
	"category",
	"key",
	"help topic",
	"function_help",
	"argument_help_arg1", "argument_help_arg2" ... (terminated with NULL) */
StringArray XLFuncsDoc::getDecl( const Palo::SpreadsheetFuncs::FunctionDocumentation& fd ) const {
	/*! \todo pass as argument */
	
	// number argument that can be described (limitation imposed by xlfRegister)

	std::vector<std::string> decl;

	decl.push_back(CheckCodePage("xll_" + fd.c_name));

	/* use the longest signature */
	const PrototypeDocumentation& p = fd.getLongestPrototype();
	std::string param_types = PARAM_TYPE;
	std::string param_type2 = (fd.xl_doc.xl_special) ? PARAM2_TYPE : PARAM_TYPE;

	if ( !fd.containsRepeatingArg() && fd.prototypes.size() == 1 ) {
		for ( PrototypeDocumentation::ArgKeys::const_iterator i = p.arg_keys.begin(); i != p.arg_keys.end(); ++i ) {
			param_types += param_type2;
		}
	} else {
		for ( size_t i = 0; i < max_args; i++ ) {
			param_types += param_type2;
		}
	}
	if ( fd.xl_doc.xl_volatile ) {
		param_types += "!";
	}
	if ( fd.xl_doc.xl_special ) {
		param_types += "#";
	}
	decl.push_back(CheckCodePage(param_types));

	decl.push_back(CheckCodePage(fd.xl_doc.xl_name));

	std::string param_names;
	size_t params_to_describe = 0;
	for ( PrototypeDocumentation::ArgKeys::const_iterator i = p.arg_keys.begin(); i != p.arg_keys.end(); ++i ) {
		const ArgumentDocumentation& a = fd.arg_pool.find( *i )->second;

		for ( size_t j = i - p.arg_keys.begin(); j < ( a.repeat ? effective_max_args : std::min(( size_t )( i - p.arg_keys.begin() + 1 ), effective_max_args ) ); ++j ) {
			std::string t, desc(a.short_desc[lang]);

			if (!desc.empty()) {
				if (!param_names.empty()) {
					t = ", ";
				}

				t += CheckLen(desc, max_short_desc_length);

				if ( param_names.size() + t.size() <= max_desc_length ) {
					params_to_describe = j + 1;
					param_names += t;
				} else {
					break;
				}
			}
		}
	}

	decl.push_back(CheckCodePage(param_names));

	decl.push_back((fd.xl_doc.xl_func_type == 2) ? "2" : ( (fd.xl_doc.xl_func_type == 1) ? "1" : "0" ) );

	decl.push_back("PALO");

	decl.push_back("");
	decl.push_back("");

	decl.push_back(CheckLen(CheckCodePage(fd.long_desc[lang]),max_desc_length));

	for ( PrototypeDocumentation::ArgKeys::const_iterator i = p.arg_keys.begin(); i != p.arg_keys.end(); ++i ) {
		const ArgumentDocumentation& a = fd.arg_pool.find( *i )->second;

		if (( size_t )( i - p.arg_keys.begin() ) >= params_to_describe ) {
			break;
		}

		if ( !a.repeat ) {
			decl.push_back(CheckLen(CheckCodePage(a.long_desc[lang]),max_desc_length));
		} else {
			size_t j = ( size_t )( i - p.arg_keys.begin() );
			while ( j++ < params_to_describe ) {
				decl.push_back(CheckLen(CheckCodePage(a.long_desc[lang]),max_desc_length));
			}
		}
	}

	// Because of Excel Bug
	decl.push_back(emptyString);
	return decl;
}

extern "C" size_t xl_funcs_get_func_num() {
	try {
		return Documentation::getInstance().functions.size();
	} catch ( ... ) {
		/* indicates invalid references in Documentation.xml */
	}

	return -1;
}


extern "C" const struct xl_func_decl *xl_func_get_func( size_t idx ) {
		static struct xl_func_decl fd;
		static StringArray decl;

		const FunctionDocumentation& fncdoc = Documentation::getInstance().functions[idx];
		if ( !fncdoc.xl_doc.is_xl_function ) {
			fd.is_xl_func = 0;
		} else {
			fd.is_xl_func = 1;

			decl = XLFuncsDoc::getInstance().getDecl( fncdoc );

			for ( StringArray::const_iterator i = decl.begin(); i != decl.end(); ++i )
				fd.a[i-decl.begin()] = i->c_str();

			fd.count = decl.size();
		}

		return &fd;
	}
