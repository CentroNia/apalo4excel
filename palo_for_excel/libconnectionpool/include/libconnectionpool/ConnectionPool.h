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
//  JMM 10-10-13 For 5.0 library compatability

#ifndef CONNECTION_POOL_H
#define CONNECTION_POOL_H

#include <map>
#include <string>

#include <libpalo_ng/Palo/ServerPool.h>

#include "config_cp.h"

namespace Palo {
	namespace SpreadsheetFuncs {

		/*! \author Marek Pikulski <marek.pikulski@jedox.com>
		 *  \brief Connection pool
		 *
		 *  This class wraps around the libpalo_ng ServerPool and provides a map "Server identifier"->Server handle.
		 */
		class CONNECTIONPOOL_CLASS_EXPORT ConnectionPool {
		public:
			/*! \author Marek Pikulski <marek.pikulski@jedox.com>
			 *  \brief Describes a Palo server connection.
			 */
			struct ConnectionData {
				explicit ConnectionData( const std::string& hostname, unsigned short port, const std::string& username, const std::string& password )
						: hostname( hostname ), port( port ), username( username ), password( password ), have_sid( false ) {
					init();
				}

				explicit ConnectionData( const std::string& hostname, unsigned short port, const std::string& sid )
						: hostname( hostname ), port( port ),  have_sid( true ), sid( sid ) {
					init();
				}

				ConnectionData() {
					init();
				}

				std::string hostname;
				unsigned short port;
				std::string username;
				std::string password;
				bool have_sid;
				std::string sid;
				bool pinged;
				bool connect_failed;
				std::string errmsg;		

                // JMM 10-10-13 Added to use ServerPool key:
                std::string serverKey;
private:
				void init() {
					pinged = false;
					connect_failed = false;
				}
			};

			ConnectionPool();
			virtual ~ConnectionPool();

			virtual void add( const std::string& key, const ConnectionData& cd );
			virtual boost::shared_ptr<jedox::palo::Server> get( const std::string& key, bool adjustFailedMap = true );
			virtual void remove( const std::string& key, const bool do_logout = true );
			boost::shared_ptr<jedox::palo::Server> get( ConnectionData& cd );
		

		protected:
			typedef std::map<std::string, ConnectionData> ConnectionMap;

			ConnectionMap connMap;

			explicit ConnectionPool( const ConnectionPool& other );
		};
	}
}
#endif
