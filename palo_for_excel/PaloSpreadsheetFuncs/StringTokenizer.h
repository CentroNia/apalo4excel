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

#ifndef STRING_TOKENIZER_H
#define STRING_TOKENIZER_H

#include <string>

#include <PaloSpreadsheetFuncs/StringArray.h>

namespace Palo {
	namespace Util {
		/*! \author Marek Pikulski <marek.pikulski@jedox.com>
		 *  \brief A basic string tokenizer.
		 */
		class StringTokenizer {
		public:
			/*! \brief Constructor.
			 *  \param s string to be tokenized
			 *  \param delim delimiter separating tokens from eachother
			 *  \param parse_quotes specifies whether double-quotes should be matched
			 */
			StringTokenizer( std::string s, std::string::value_type delim, bool parse_quotes );
			~StringTokenizer();

			/*! \brief Return the next token.
			 *  \warning Make sure that there is at least one token left.
			 */
			StringTokenizer& operator>>( std::string& dest );

			/*! \brief Return all tokens in an array.
			 */
			Types::StringArray getTokens();

			/*! \brief Check if there are tokens left.
			 */
			bool endReached() const;

			/*! \brief Exception being thrown on parsing errors or if you request
			 *         an invalid operation.
			 */
			class StringTokenizerException {};

		private:
			bool atEnd;
			std::string s;
			const std::string::value_type delim;
			const bool parse_quotes;
			const std::string::value_type quote;

			void removeDoubleQuotes( std::string& s );
		};
	}
}
#endif
