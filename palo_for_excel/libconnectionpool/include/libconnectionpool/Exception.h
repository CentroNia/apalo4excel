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

#ifndef CP_EXCEPTION_H
#define CP_EXCEPTION_H

#if defined(WIN32) || defined(WIN64)
#pragma warning(disable : 4251)
#endif

#include <exception>
#include <string>

#include "config_cp.h"

#undef GetMessage

namespace Palo {
	namespace Types {

// JMM 09-12-13 For 5.0 compatability:
#ifndef CurrentSourceLocation
		class CONNECTIONPOOL_CLASS_EXPORT SourceLocation {
		private:
			std::string file;
			unsigned int line;

		public:
			SourceLocation( const std::string& file, unsigned int line ) : file( file ), line( line ) {}

			std::string GetLocation() const;
		};

		/*! \brief The current source location.
		 */
#define CurrentSourceLocation SourceLocation(__FILE__, __LINE__)
#endif

		/*! \author Marek Pikulski <marek.pikulski@jedox.com>
		 *  \brief Exception class
		 *
		 *  This class is used to describe exceptions. All other exceptions should be
		 *  derived from this class and override the GetType() and GetMessage() members.
		 *  Usually you will want to pass CurrentSourceLocation to the constructor of this class.
		 */
		class CONNECTIONPOOL_CLASS_EXPORT CPException : public std::exception {
		private:
			std::string msg;
			SourceLocation loc;

		protected:
			CPException( const SourceLocation& location, const std::string& message ) : msg( message ), loc( location ) {}

			CPException( const SourceLocation& location ) : loc( location ) {}

		public:
			/*! \brief Returns a type string like "InvalidArgumentException"
			 */
			virtual const std::string& GetType() const;

			virtual const std::string& GetMessage() const;

			virtual std::string GetLocation() const;

			virtual const char * what() const throw();

			~CPException() throw() {}
		};
	}
}
#endif
