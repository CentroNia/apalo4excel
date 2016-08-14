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

#include <sstream>
#include <libpalo_ng/Util/StringUtils.h>

#include "XLConnectionPool.h"

using namespace Palo::XLL;
using namespace Palo::Util;

#import "\DEV\Palo\Source50\palo_for_excel\Jedox.Palo.XlAddin.tlb"

using namespace Jedox_Palo_XlAddin;

#include <atlbase.h>

class XLConnectionPool::XLConnectionPoolImpl {
public:
	XLConnectionPoolImpl() : pec( NULL ) {}

	void updateCOM() {
		if ( pec == NULL ) {
			try {
				pec = _GetPaloDesigner();
			} catch (const _com_error &e ) {
				throw XLLComException( CurrentSourceLocation, e);
			}
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

	
private:
	IPaloEngineComPtr *_GetPaloDesigner() {

		const std::wstring string_to_look_for = std::wstring(OLESTR( "!Jedox.Palo.XlAddin.ComInterface" ));
		
		LPRUNNINGOBJECTTABLE	spTable;
		IEnumMoniker*			spEnum = NULL;
		LPDISPATCH pPD = NULL;


		HRESULT hr = GetRunningObjectTable( 0, &spTable ); /* Get the IROT interface pointer */

		if ( SUCCEEDED(hr) ){
			hr = spTable->EnumRunning( &spEnum );/* Get the moniker enumerator */ 
		}
		
		if ( SUCCEEDED(hr) ) {

			IMonikerPtr spMoniker = NULL;
			/* Loop through all the interfaces in the enumerator looking for our interface */
			while ( SUCCEEDED(spEnum->Next(1, &spMoniker, NULL)) && (NULL != spMoniker) ) {
				IBindCtxPtr spContext = NULL;
				hr = CreateBindCtx( 0, &spContext ); /* Create a bind context */

				if ( SUCCEEDED(hr) ) {
					WCHAR* wsCurName = NULL;
					hr = spMoniker->GetDisplayName( spContext, NULL, &wsCurName ); /* Get the display name */
					if (SUCCEEDED(hr) && string_to_look_for == wsCurName) {

						//found it, lets get it
						LPUNKNOWN pd;

						hr = spTable->GetObjectA(spMoniker,&pd);

						if ( SUCCEEDED(hr) ) {
							hr = pd->QueryInterface( IID_IDispatch, ( void ** ) & pPD );
							pd->Release();
						}

						spMoniker.Release();
						break;
					}
				}

				spMoniker.Release();
			}
		}
		if ( pPD == NULL || !SUCCEEDED(hr) ){
			return NULL;
		}
		return new IPaloEngineComPtr( pPD );
	}
};

XLConnectionPool::XLConnectionPool() : impl( new XLConnectionPool::XLConnectionPoolImpl() ) {}

XLConnectionPool::~XLConnectionPool() {}

XLConnectionPool::ConnectionData* XLConnectionPool::getConnectionData( const std::string& key, bool adjustFailedMap ) {
	ConnectionMap::iterator i;

	ConnectionData* cd = NULL;

	std::string mykey = jedox::util::StringUtils::toUpper( key );

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
	return get( *getConnectionData(key, adjustFailedMap));
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
}

void XLConnectionPool::remove(const std::string& key) {
	connMap.erase(jedox::util::StringUtils::toUpper(key));
	failedMap.erase(key);
}

void XLConnectionPool::resetInvalid() {
	failedMap.clear();
	for ( ConnectionMap::iterator i = connMap.begin(); i != connMap.end(); ++i ) {
		i->second.connect_failed = false;
		i->second.pinged = false;
		i->second.errmsg.clear();
	}
}

void XLConnectionPool::add( const std::string& key, const ConnectionData& cd ) {
	connMap[jedox::util::StringUtils::toUpper( key )] = cd;
}


void XLConnectionPool::HandleNoServer( ConnectionData& cd, const std::string &errmsg) {
	cd.connect_failed = true;
	cd.errmsg = errmsg;
	throw ConnectionException( CurrentSourceLocation, cd.errmsg );
}

boost::shared_ptr<jedox::palo::Server> XLConnectionPool::get( ConnectionData& cd ) {
	if ( cd.connect_failed ) {
		throw ConnectionException( CurrentSourceLocation, cd.errmsg );
	}

	std::string tmp_key;
	try {
		if (!cd.server_ok) {
			cd.server = jedox::palo::JedoxXLHelper::getInstance().getServer( cd.hostname, cd.port, cd.username, cd.password, tmp_key, jedox::palo::Https );
			cd.server_ok = true;
		}
	} catch (const std::exception& e ) {
		HandleNoServer(cd, e.what() ? e.what() : "No error information available.");
	}

	if (!cd.server_ok) {
		HandleNoServer(cd, "Got no Server");
	}

	if ( !cd.pinged ) {
		try {
			cd.pinged = true;
			cd.server->ping();
		} catch (const std::exception& e ) {
			HandleNoServer(cd, e.what() ? e.what() : "No error information available.");
		}
	}

	return cd.server;
}


