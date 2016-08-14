////////////////////////////////////////////////////////////////////////////////
/// @brief
///
/// @file
///
/// Copyright (C) 2006-2012 Jedox AG
///
/// This program is free software; you can redistribute it and/or modify it
/// under the terms of the GNU General Public License (Version 2) as published
/// by the Free Software Foundation at http://www.gnu.org/copyleft/gpl.html.
///
/// This program is distributed in the hope that it will be useful, but WITHOUT
/// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
/// FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
/// more details.
///
/// You should have received a copy of the GNU General Public License along with
/// this program; if not, write to the Free Software Foundation, Inc., 59 Temple
/// Place, Suite 330, Boston, MA 02111-1307 USA
///
/// You may obtain a copy of the License at
///
/// <a href="http://www.jedox.com/license_palo_bi_suite.txt">
///   http://www.jedox.com/license_palo_bi_suite.txt
/// </a>
///
/// If you are developing and distributing open source applications under the
/// GPL License, then you are free to use Palo under the GPL License.  For OEMs,
/// ISVs, and VARs who distribute Palo with their products, and do not license
/// and distribute their source code under the GPL, Jedox provides a flexible
/// OEM Commercial License.
///
/// @author Marek Pikulski (<a href="mailto:marek.pikulski@jedox.com">marek.pikulski@jedox.com</a>)
////////////////////////////////////////////////////////////////////////////////

#include "SpreadsheetFuncsDoc.h"

using namespace Palo::SpreadsheetFuncs;

#pragma warning(disable : 4748)

#pragma optimize ("", off)
Documentation::Documentation() {
#include "DocInitializer.cpp.inc"
}
#pragma optimize ("", on)


Documentation::~Documentation() {}

FunctionDocumentation::FunctionDocumentation() {}
FunctionDocumentation::~FunctionDocumentation() {}

XLFunctionDocumentation::XLFunctionDocumentation() : is_xl_function( false ) {}
XLFunctionDocumentation::~XLFunctionDocumentation() {}

PrototypeDocumentation::PrototypeDocumentation() {}
PrototypeDocumentation::~PrototypeDocumentation() {}

ArgumentDocumentation::ArgumentDocumentation() {}
ArgumentDocumentation::~ArgumentDocumentation() {}

LocalizedString::LocalizedString() {}
LocalizedString::~LocalizedString() {}

bool FunctionDocumentation::containsRepeatingArg() const {
	for ( ArgumentPool::const_iterator i = arg_pool.begin(); i != arg_pool.end(); ++i ) {
		if ( i->second.repeat ) {
			return true;
		}
	}

	return false;
}


const PrototypeDocumentation& FunctionDocumentation::getLongestPrototype() const {
	if ( prototypes.empty() ) {
		throw InvalidRequestException( CurrentSourceLocation );
	}

	size_t max_pos = -1, max_len = -1;

	for ( PrototypeList::const_iterator i = prototypes.begin(); i != prototypes.end(); ++i ) {
		if ( (i->arg_keys.size() > max_len) || (max_len == ( size_t ) - 1 )) {
			max_pos = i - prototypes.begin();
		}
		if ( !i->arg_keys.empty() && arg_pool.find( i->arg_keys[i->arg_keys.size()-1] )->second.repeat ) {
			return *i;
		}
	}

	return prototypes[max_pos];
}


const std::wstring& LocalizedString::operator []( const std::string& key ) const {
	LocalizedString::const_iterator i = find( key );
	if ( i == end() ) {
		if ( key != "en" ) {
			return operator []( "en" );
		} else {
			throw InvalidRequestException( CurrentSourceLocation );
		}
	}

	return i->second;
}


std::wstring& LocalizedString::operator []( const std::string& key ) {
	LocalizedString::iterator i = find( key );
	if ( i == end() ) {
		return std::map<std::string, std::wstring>::operator []( key );
	} else {
		return i->second;
	}
}
