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
 * Hendrik Schmieder <hendrik.schmieder@jedox.com>
 *
 */

#ifndef XLCONNECTION_POOL_H
#define XLCONNECTION_POOL_H

#include <memory>

#include <libconnectionpool/ConnectionPool.h>

#include <PaloSpreadsheetFuncs/ErrorInfo.h>

#include "XLLComException.h"


namespace Palo {
	namespace XLL {
		/*! \author Marek Pikulski <marek.pikulski@jedox.com>
		 *  \brief Connection pool
		 *
		 *  This class wraps around the libpalo_ng ServerPool and provides a map "Server identifier"->Server handle.
		 */
		class XLConnectionPool : public Palo::SpreadsheetFuncs::ConnectionPool {
		public:
			XLConnectionPool();
			~XLConnectionPool();

			boost::shared_ptr<jedox::palo::Server> get( const std::string&key, bool adjustFailedMap );
			std::string& getUser( const std::string& key, bool adjustFailedMap);

			/*! Reset status of server that could not be reached in previous connection attempts. */
			void resetInvalid();
			/*! Remove all connections. */
			void clear();
		    /*! Remove specific connection. */
			void remove(const std::string& key);

			void getServerSubset(const std::string& serverDatabase, const std::string& dimension, bool global,const std::string& subset, std::vector<std::vector<std::string>>& serverSubsetResult);
		private:
			ConnectionData* getConnectionData( const std::string& key, bool adjustFailedMap );

			class XLConnectionPoolImpl;
			std::unique_ptr<XLConnectionPoolImpl> impl;

			typedef std::map<std::string, XLLConnException> FailedQueryMap;

			FailedQueryMap failedMap;

		};
	}
}
#endif
