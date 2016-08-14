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
/// @author Hendrik Schmieder
////////////////////////////////////////////////////////////////////////////////

#ifndef LICENSE_INFO_H
#define LICENSE_INFO_H

#include <climits>

#include <libpalo_ng/Palo/types.h>

namespace Palo {
	namespace Types {

		struct LicenseInfo {
		public:
			enum LicenseType
			{
				UNKNOWN = 0, //jedox::palo::LICENSE_INFO::UNKNOWN,
				NORMAL = 1, //jedox::palo::LICENSE_INFO::NORMAL
			};

			LicenseInfo() : name( "" ), users( INT_MAX ), expiredate( LONG_MAX ), type( UNKNOWN ) {}

            // JMM 09-12-13 For 5.0/5.1 compatability:
            #if NOTUSED
			LicenseInfo( const jedox::palo::LICENSE_INFO& li ) : name( li.name ), users( li.users ), expiredate( li.expiredate ), type( (LicenseType)li.type ) {
				// Workaround for ST

				if (expiredate <= 0) {
					users = INT_MAX;
					expiredate = LONG_MAX;
				}

				if (((unsigned long)users) > INT_MAX) {
					users = INT_MAX;
				}

				if (((unsigned long long)expiredate) > LONG_MAX) {
					expiredate = LONG_MAX;
				}            
			}
            #endif

			std::string name;
			unsigned int users;
			time_t expiredate;
			LicenseType type;
		};

	}
}
#endif
