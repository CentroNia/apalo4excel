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

//  Additional Revisions to Palo (c) Junction BI LLC:
//  JMM 09-20-13 For 5.0 library compatability

#ifndef CONNECTION_EXCEPTION_H
#define CONNECTION_EXCEPTION_H

#include "libconnectionpool/Exception.h"

namespace Palo {
	namespace Types {

		/*! \author Marek Pikulski <marek.pikulski@jedox.com>
		 *
		 *  What the name suggests.
		 */
        // JMM 09-12-13 for 3.2 compatability:
		class CONNECTIONPOOL_CLASS_EXPORT ConnectionException : public CPException {
		public:
			ConnectionException( const SourceLocation& loc, const std::string& msg ) : CPException( loc, msg ) {}

		virtual const std::string& GetType() const {
				static const std::string type = "ConnectionException";
				return type;
			}

		protected:
			ConnectionException( const SourceLocation& loc ) : CPException( loc, "" ) {}

		};
	}
}
#endif
