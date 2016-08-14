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
 * Hendrik Schmieder <hendrik.schmieder@jedox.com>
 *
 */

#ifndef XLCONNECTION_POOL_H
#define XLCONNECTION_POOL_H


#include <PaloSpreadsheetFuncs/ErrorInfo.h>

#include "../JedoxXlHelper/JedoxXLHelper.h"

#include "XLLComException.h"


namespace Palo {
	namespace XLL {

		/*! \author Marek Pikulski <marek.pikulski@jedox.com>
		 *  \brief Connection pool
		 *
		 *  This class wraps around the libpalo_ng ServerPool and provides a map "Server identifier"->Server handle.
		 */
		class XLConnectionPool {
		public:

			/*! \author Marek Pikulski <marek.pikulski@jedox.com>
			 *  \brief Describes a Palo server connection.
			 */
			struct ConnectionData {
			public:
				explicit ConnectionData( const std::string& hostname, unsigned short port, const std::string& username, const std::string& password )
					: hostname( hostname ), port( port ), username( username ), password( password ) {
					init();
				}

				ConnectionData() {
					init();
				}

				std::string hostname;
				unsigned short port;
				std::string username;
				std::string password;
				bool pinged;
				bool connect_failed;
				std::string errmsg;			
				boost::shared_ptr<jedox::palo::Server> server;
				bool server_ok;
			private:
				void init() {
					pinged = false;
					connect_failed = false;
					server_ok = false;
				}
			};

			XLConnectionPool();
			~XLConnectionPool();

			void add( const std::string& key, const ConnectionData& cd );
			boost::shared_ptr<jedox::palo::Server> get( const std::string&key, bool adjustFailedMap = true );
			boost::shared_ptr<jedox::palo::Server> get( ConnectionData& cd );
			std::string& getUser( const std::string& key, bool adjustFailedMap);

			/*! Reset status of server that could not be reached in previous connection attempts. */
			void resetInvalid();
			/*! Remove all connections. */
			void clear();
		    /*! Remove specific connection. */
			void remove(const std::string& key);

			void getServerSubset(const std::string& serverDatabase, const std::string& dimension, bool global,const std::string& subset, std::vector<std::vector<std::string>>& serverSubsetResult);

		private:
			typedef std::map<std::string, ConnectionData> ConnectionMap;
			ConnectionMap connMap;

			void HandleNoServer( ConnectionData& cd, const std::string &errmsg);

			ConnectionData* getConnectionData( const std::string& key, bool adjustFailedMap );

			class XLConnectionPoolImpl;
			std::unique_ptr<XLConnectionPoolImpl> impl;

			typedef std::map<std::string, XLLConnException> FailedQueryMap;

			FailedQueryMap failedMap;

		};
	}
}
#endif
