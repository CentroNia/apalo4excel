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

//  Additional Revisions to Palo (c) Junction BI LLC:
//  JMM 09-20-13 For 5.0 library compatability

#ifndef XLL_EXCEPTION_H
#define XLL_EXCEPTION_H

#include <libconnectionpool/ConnectionException.h>

#include "XLLMessages.h"

namespace Palo {
	namespace XLL {
		using namespace Types;
        
        // JMM 09-12-13 For 5.0 compatability:
		class XLLException : public CPException {
		public:
			XLLException( const SourceLocation& loc, XLLErrors::Errors e ) : CPException( loc, XLLMessages::getInstance()[e] ) {}

			XLLException( const SourceLocation& loc, const std::string& s ) : CPException( loc, s ) {}

			const std::string& GetType() {
				static const std::string type = "XLLException";
				return type;
			}

			~XLLException() throw() {}
		};

		class XLLConnException : public ConnectionException {
		public:
			XLLConnException( const SourceLocation& loc, XLLErrors::Errors e ) : ConnectionException( loc, XLLMessages::getInstance()[e]) {}

			XLLConnException( const SourceLocation& loc, const std::string& s ) : ConnectionException( loc, s ) {}
			
			XLLConnException( ) : ConnectionException( SourceLocation(__FILE__, __LINE__), "no information available!" ) {}

			const std::string& GetType() {
				static const std::string type = "XLLConnException";
				return type;
			}

			~XLLConnException() throw() {}
		};

	}
}
#endif
