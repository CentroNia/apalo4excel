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

#include <sstream>

#include <libconnectionpool/StringUtils.h>

#include "XLConnectionPool.h"

using namespace Palo::XLL;
using namespace Palo::Util;

#import "Apalo.XlAddin.tlb"

using namespace Apalo_XlAddin;

#include <atlbase.h>

class XLConnectionPool::XLConnectionPoolImpl {
public:
	XLConnectionPoolImpl() : WSZ_PALODSGNPROGID( OLESTR( "Apalo.XlAddin.ComInterface" ) ), pec( NULL ) {}

	void updateCOM() {
		if ( pec == NULL ) {
			try {
				pec = new IPaloEngineComPtr( WSZ_PALODSGNPROGID, NULL, CLSCTX_INPROC_SERVER );
			} catch (const _com_error &e ) {
				throw XLLComException( CurrentSourceLocation, e);
			}
		}
	}

	void updatePaloDesigner() {
		updateCOM();

		try {
			pec->ForceServerListUpdate();
		} catch (const _com_error &e ) {
			throw XLLComException( CurrentSourceLocation, e);
		}
	}

	void getServerSubset(const std::string& serverDatabase, const std::string& dimension, bool global,const std::string& subset, std::vector<std::vector<std::string>>& subsetVecor) {
		updateCOM();
		
		SAFEARRAY *sa;
		try {
			sa = pec->GetServerSubSetContent(serverDatabase.c_str(), dimension.c_str(), global, subset.c_str());
		} catch (const _com_error &e ) {
			throw XLLComException( CurrentSourceLocation, e);
		}	

		try {
			int lower0 = sa->rgsabound[0].lLbound;
			int upper0 = sa->rgsabound[0].cElements + lower0;

			long* index = new long();
			for(int i = lower0; i < upper0; i++) 
			{
				index[1] = i;
				int lower1 = sa->rgsabound[1].lLbound;
				int upper1 = sa->rgsabound[1].cElements + lower1;
				std::vector<std::string> tmp;
				for(int j = lower1; j < upper1; j++) 
				{	
					index[0] = j;	
					CComBSTR bstr;				
					if (SafeArrayGetElement( sa, index, &bstr ) == S_OK ) 
					{
						CW2CT astr( bstr );
						SysFreeString( bstr );

						tmp.push_back(std::string( astr ));
					}				
				}
				subsetVecor.push_back(tmp);
			}
		} catch(...) {
			throw XLLException( CurrentSourceLocation, "Error retrieving data from PaloDesigner" );
			SafeArrayDestroy( sa );
		}
		SafeArrayDestroy( sa );
	}

	/*! Get a login data from PALO designer. */
	XLConnectionPool::ConnectionData queryDesigner( const std::string& localname ) {
		updateCOM();

		XLConnectionPool::ConnectionData cd;
		cd.have_sid = false;

		SAFEARRAY *sa;
		try {
			sa = pec->GetConnectionDataInfo( localname.c_str() );
		} catch (const _com_error &e ) {
			throw XLLComException( CurrentSourceLocation, e);
		}

		try {
			try {
				if ( !( sa->fFeatures & FADF_BSTR ) || (sa->cDims != 1) || (sa->rgsabound[0].cElements != 5) ) {
					throw XLLConnException( CurrentSourceLocation, "PaloDesigner returned invalid data" );
				}

				long i = sa->rgsabound[0].lLbound;
				while ( i < ( long )sa->rgsabound[0].cElements + sa->rgsabound[0].lLbound ) {
					CComBSTR bstr;

					HRESULT res;
					if (( res = SafeArrayGetElement( sa, &i, &bstr ) ) != S_OK ){
						throw XLLConnException( CurrentSourceLocation, "Error retrieving data from PaloDesigner" );
					}

					CW2CT astr( bstr );
					SysFreeString( bstr );

					std::string s( astr );

					if ( i == sa->rgsabound[0].lLbound ) {
						if ( !s.empty() ) {
							throw XLLConnException( CurrentSourceLocation, "PaloDesigner returned error: " + s );
						} else {
							i++;
							continue;
						}
					}

					switch ( i - sa->rgsabound[0].lLbound ) {
						case 1:
							cd.hostname = s;
							break;
						case 2: 
							{
								std::istringstream istr( s );
								istr >> cd.port;
							}
							break;
						case 3:
							cd.username = s;
							break;
						case 4:
							cd.password = s;
							break;
						default:
							throw XLLConnException( CurrentSourceLocation, "PaloDesigner returned invalid data: " + s );
					}

					i++;
				}
			} catch (const _com_error &e ) {
				throw XLLComException( CurrentSourceLocation, e);
			}
		} catch ( ... ) {
			SafeArrayDestroy( sa );

			throw;
		}

		SafeArrayDestroy( sa );

		return cd;
	}

protected:
	IPaloEngineComPtr pec;

	const wchar_t *WSZ_PALODSGNPROGID;

private:
	/*IPaloEngineComPtr *_GetPaloDesigner() {
		CLSID clsid;
		HRESULT hr;
		LPUNKNOWN pd;
		LPDISPATCH pPD = NULL;

		hr = CLSIDFromProgID( WSZ_PALODSGNPROGID, &clsid );
		if ( hr == S_OK ) {
			hr = GetActiveObject( clsid, NULL, &pd );

			if ( hr == S_OK ) {
				hr = pd->QueryInterface( IID_IDispatch, ( void ** ) & pPD );
				pd->Release();
			}
		}

		if ( hr != S_OK ) {
			return NULL;
		} else {
			if ( pPD == NULL )
				return NULL;
			return new IPaloEngineComPtr( pPD );
		}
	}*/
};

XLConnectionPool::XLConnectionPool() : impl( new XLConnectionPool::XLConnectionPoolImpl() ) {}

XLConnectionPool::~XLConnectionPool() {}

XLConnectionPool::ConnectionData* XLConnectionPool::getConnectionData( const std::string& key, bool adjustFailedMap ) {
	ConnectionMap::iterator i;

	ConnectionData* cd = NULL;

	std::string mykey = StringUtils::toUpper( key );

	if (( i = connMap.find( mykey ) ) == connMap.end() ) {
		FailedQueryMap::iterator j;
		if ((j = failedMap.find( mykey ) ) == failedMap.end() ) {
			if (adjustFailedMap) {
				try {
					ConnectionData dcd = impl->queryDesigner( mykey );
					add( mykey, dcd );
				} catch (const XLLConnException& e ) {
					failedMap[mykey] = e;
					throw;
				}
			} else {
				throw XLLConnException(CurrentSourceLocation, "Connection is unused");
			}

		} else {
			throw j->second;
		}
		cd = &connMap.find( mykey )->second;
	} else {
		cd = &i->second;

		if ( cd->connect_failed ) {
			throw XLLConnException( CurrentSourceLocation, cd->errmsg );
		}
	}

	return cd;
}

boost::shared_ptr<jedox::palo::Server> XLConnectionPool::get( const std::string& key, bool adjustFailedMap ) {
	return ConnectionPool::get( *getConnectionData(key, adjustFailedMap));
}

std::string& XLConnectionPool::getUser( const std::string& key, bool adjustFailedMap ) {
	return getConnectionData(key, adjustFailedMap)->username;
}

void XLConnectionPool::getServerSubset(const std::string& serverDatabase, const std::string& dimension, bool global,const std::string& subset, std::vector<std::vector<std::string>>& serverSubsetResult) {
	impl->getServerSubset(serverDatabase, dimension, global, subset, serverSubsetResult);
}

void XLConnectionPool::clear() {
	connMap.clear();
	failedMap.clear();
	impl->updatePaloDesigner();
}

void XLConnectionPool::remove(const std::string& key) {
	ConnectionPool::remove(key);
	connMap.erase(key);
	failedMap.erase(key);
	impl->updatePaloDesigner();
}

void XLConnectionPool::resetInvalid() {
	failedMap.clear();
	for ( ConnectionMap::iterator i = connMap.begin(); i != connMap.end(); ++i ) {
		i->second.connect_failed = false;
		i->second.pinged = false;
		i->second.errmsg.clear();
	}
}
