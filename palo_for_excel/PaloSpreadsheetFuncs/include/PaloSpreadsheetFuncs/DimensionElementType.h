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

#ifndef DIMENSION_ELEMENT_TYPE_H
#define DIMENSION_ELEMENT_TYPE_H

#include <libpalo_ng/Palo/Server.h>

#include "InvalidRequestException.h"
#include "ArgumentException.h"

namespace Palo {
	namespace Types {
		/*! \author Marek Pikulski <marek.pikulski@jedox.com>
		 *  \brief Stores the type of a dimension element.
		 */
		class DimensionElementType {
		public:
			enum Type
			{
			    Numeric,
			    String,
			    Consolidated
			} type;

			DimensionElementType( const jedox::palo::ELEMENT_INFO::TYPE other ) {
				switch ( other ) {
					case jedox::palo::ELEMENT_INFO::CONSOLIDATED:
						type = Consolidated;
						break;
					case jedox::palo::ELEMENT_INFO::NUMERIC:
						type = Numeric;
						break;
					case jedox::palo::ELEMENT_INFO::STRING:
						type = String;
						break;
					default:
						throw InvalidRequestException( CurrentSourceLocation );
				}
			}

			DimensionElementType( const Type other ) {
				type = other;
			}

			/*! \brief Default construct (default type numeric) required for STL containers.
			 */
			// for vector
			DimensionElementType() {
				type = Numeric;
			}

			jedox::palo::ELEMENT_INFO::TYPE toPalo() const {
				switch ( type ) {
					case Consolidated:
						return jedox::palo::ELEMENT_INFO::CONSOLIDATED;
					case Numeric:
						return jedox::palo::ELEMENT_INFO::NUMERIC;
					case String:
						return jedox::palo::ELEMENT_INFO::STRING;
					default:
						throw ArgumentException( CurrentSourceLocation, SpreadsheetFuncsErrors::ERROR_INVALID_ARGUMENT_TYPE );
				}
			}

			bool operator ==( const Type other ) const {
				return type == other;
			}
		};
	}
}
#endif
