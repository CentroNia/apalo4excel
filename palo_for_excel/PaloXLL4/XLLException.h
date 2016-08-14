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

#ifndef XLL_EXCEPTION_H
#define XLL_EXCEPTION_H

#include <PaloSpreadsheetFuncs/PSFException.h>

#include "XLLMessages.h"

namespace Palo {
	namespace XLL {

		/*! \author Marek Pikulski <marek.pikulski@jedox.com>
		 *  \brief Exception class
		 *
		 *  This class is used to describe exceptions. All other exceptions should be
		 *  derived from this class and override the GetType() and GetMessage() members.
		 *  Usually you will want to pass CurrentSourceLocation to the constructor of this class.
		 */
		class Exception : public std::exception {
		private:
			std::string msg;
			Palo::Types::SourceLocation loc;

		protected:
			Exception( const Palo::Types::SourceLocation& location, const std::string& message ) : msg( message ), loc( location ) {}

			Exception( const Palo::Types::SourceLocation& location ) : loc( location ) {}

		public:
			/*! \brief Returns a type string like "InvalidArgumentException"
			 */
			virtual const std::string& GetType() const {
				static const std::string type = "Exception";
				return type;
			};

			virtual const std::string& GetMessage() const {
				return msg;
			};

			virtual std::string GetLocation() const {
				return loc.GetLocation();
			};

			virtual const char * what() const throw() {
				return GetMessage().c_str();
			};

			~Exception() throw() {}
		};

		class ConnectionException : public Exception {
		public:
			ConnectionException( const Palo::Types::SourceLocation& loc, const std::string& msg ) : Exception( loc, msg ) {}

		virtual const std::string& GetType() const {
				static const std::string type = "ConnectionException";
				return type;
			}

		protected:
			ConnectionException( const Palo::Types::SourceLocation& loc ) : Exception( loc, "" ) {}

		};

		class XLLException : public Exception {
		public:
			XLLException( const Palo::Types::SourceLocation& loc, XLLErrors::Errors e ) : Exception( loc, XLLMessages::getInstance()[e] ) {}

			XLLException( const Palo::Types::SourceLocation& loc, const std::string& s ) : Exception( loc, s ) {}

			const std::string& GetType() {
				static const std::string type = "XLLException";
				return type;
			}

			~XLLException() throw() {}
		};

		class XLLConnException : public ConnectionException {
		public:
			XLLConnException( const Palo::Types::SourceLocation& loc, XLLErrors::Errors e ) : ConnectionException( loc, XLLMessages::getInstance()[e]) {}

			XLLConnException( const Palo::Types::SourceLocation& loc, const std::string& s ) : ConnectionException( loc, s ) {}
			
			XLLConnException( ) : ConnectionException( Palo::Types::SourceLocation(__FILE__, __LINE__), "no information available!" ) {}

			const std::string& GetType() {
				static const std::string type = "XLLConnException";
				return type;
			}

			~XLLConnException() throw() {}
		};

	}
}
#endif
