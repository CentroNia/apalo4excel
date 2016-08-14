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

#include "libconnectionpool/ConnectionPool.h"
#include "libconnectionpool/StringUtils.h"

#include "libconnectionpool/ConnectionException.h"

using namespace Palo::SpreadsheetFuncs;
using namespace Palo::Util;
using namespace Palo::Types;
using namespace std;
using namespace jedox::palo;

ConnectionPool::ConnectionPool() {}

ConnectionPool::~ConnectionPool() {}

void ConnectionPool::add( const std::string& key, const ConnectionData& cd ) {
	connMap[StringUtils::toUpper( key )] = cd;
}


boost::shared_ptr<jedox::palo::Server> ConnectionPool::get( const std::string& key, bool adjustFailedMap ) {
	ConnectionMap::iterator i;

	if (( i = connMap.find( StringUtils::toUpper( key ) ) ) == connMap.end() ) {
		throw ConnectionException( CurrentSourceLocation, "Unknown connection '" + key + "'."  );
	}

	ConnectionData& cd = i->second;

	return get( cd );
}


boost::shared_ptr<jedox::palo::Server> ConnectionPool::get( ConnectionData& cd ) {
	ServerPool& sp = ServerPool::getInstance();

	if ( cd.connect_failed ) {
		throw ConnectionException( CurrentSourceLocation, cd.errmsg );
	}

	boost::shared_ptr<jedox::palo::Server> s;
	string tmp_key;
	try {
        // JMM 09-12-13:
        //std::string connectServer(const std::string& host, const unsigned int port, const std::string& user, const std::string& password, const std::string& machineString, const std::string& requiredFeatures, std::string& optionalFeatures, ServerProtocol protocol = Http);
        //getServer(const std::string& key);
        if (cd.serverKey.length() > 0)
            tmp_key = cd.serverKey;
        else
            {        
            string machineString;
            string requiredFeatures;
            string optionalFeatures;
		    if ( cd.have_sid ) {
                machineString = cd.sid;
			    //s = sp.getServer( cd.hostname, cd.port, cd.sid, tmp_key );
		    } else {            
			    //s = sp.getServer( cd.hostname, cd.port, cd.username, cd.password, tmp_key, Https );
		    }
            tmp_key = sp.connectServer(cd.hostname, cd.port, cd.username, cd.password, machineString, requiredFeatures, optionalFeatures, Https );
            if (tmp_key.length() > 0)
                cd.serverKey = tmp_key;
            }
        s = sp.getServer(tmp_key);
	} catch (const std::exception& e ) {
		cd.connect_failed = true;
		cd.errmsg = std::string( e.what() ? e.what() : "No error information available." );

		throw ConnectionException( CurrentSourceLocation, cd.errmsg );
	}

	if ( !cd.pinged ) {
		try {
			cd.pinged = true;
			s->ping();
		} catch (const std::exception& e ) {
			cd.connect_failed = true;
			cd.errmsg = std::string( e.what() ? e.what() : "No error information available." );
			throw ConnectionException( CurrentSourceLocation, cd.errmsg );
		}
	}

	return s;
}

void ConnectionPool::remove( const std::string& key, const bool do_logout /* = true */ ) {
    if ( do_logout ) {
        try {
            boost::shared_ptr<jedox::palo::Server> server = get( key, false );
            if( server ) {
                // JMM 09-12-13:
                server->logout();
            }
        }
        catch (...) {
        }
    }
    connMap.erase( StringUtils::toUpper(key) );	
}

