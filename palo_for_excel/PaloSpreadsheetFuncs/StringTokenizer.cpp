////////////////////////////////////////////////////////////////////////////////
/// @brief
///
/// @file
///
/// Copyright (C) 2006-2011 Jedox AG
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

#include "StringTokenizer.h"

using namespace Palo::Util;
using namespace Palo::Types;
using namespace std;

StringTokenizer::StringTokenizer( std::string s, std::string::value_type delim, bool parse_quotes ) : s( s ), delim( delim ), parse_quotes( parse_quotes ), quote( '\"' ), atEnd( s.length() == 0 ) {}


StringTokenizer::~StringTokenizer() {}


void StringTokenizer::removeDoubleQuotes( std::string& s ) {
	string::size_type pos;
	string pattern = "  ";
	pattern[0] = pattern[1] = quote;
	while (( pos = s.find( pattern ) ) != string::npos ) {
		s.erase( pos, 1 );
		pos += 1;
	}
}


StringTokenizer& StringTokenizer::operator>>( std::string& dest ) {
	string::size_type quote_pos = parse_quotes ? s.find( quote ) : string::npos;
	string::size_type delim_pos = s.find( delim );

	// find closing quote
	if(quote_pos != string::npos) {
		if(delim_pos > quote_pos) {
			quote_pos = s.find( quote, quote_pos+1 );

			if(quote_pos != string::npos) {
				while( delim_pos != string::npos && delim_pos < quote_pos )
					delim_pos = s.find( delim, delim_pos+1 );
			}
		}
	}

	if(delim_pos == string::npos) {
		dest = s;
		atEnd = true;
	} else {
		dest = s.substr( 0, delim_pos );
		s.erase( 0, delim_pos + 1 );
	}

	/* remove surrounding quotes */
	if(parse_quotes) {
		if(!dest.empty() && dest[0] == quote)
			dest = dest.substr(1);
		if(dest.size() > 0 && dest[dest.size()-1] == quote)
			dest.resize(dest.size()-1);
	}

	return *this;
}


StringArray StringTokenizer::getTokens() {
	StringArray sa;

	while ( !endReached() ) {
		string s;
		*this >> s;
		sa.push_back( s );
	}

	return sa;
}


bool StringTokenizer::endReached() const {
	return atEnd;
}
