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

#include <libconnectionpool/StringUtils.h>

#include <libpalo_ng/Palo/Database.h>
#include <libpalo_ng/Network/SocketException.h>

#include <PaloSpreadsheetFuncs/StringArrayArray.h>
#include <PaloSpreadsheetFuncs/CellValueArray.h>
#include <PaloSpreadsheetFuncs/QueryCache.h>
#include <PaloSpreadsheetFuncs/SpreadsheetFuncsException.h>

#include "QueryCacheEntryNotFoundException.h"

using namespace Palo::SpreadsheetFuncs;
using namespace Palo::Types;
using namespace Palo::Util;
using namespace jedox::palo;
using namespace std;


inline QueryCache::QueryCacheIndex::operator size_t() const {
	return STL_HASH_STRING(have_server ? server_srv->getSID() : server_str) + 81 * STL_HASH_STRING(database) + 2401 * STL_HASH_STRING(cube);
}

inline QueryCache::QueryCacheInnerIndex::operator size_t() const {
	size_t hash = 0;

	for(StringArray::const_iterator i = path.begin(); i != path.end(); ++i) {
		hash += STL_HASH_STRING(*i);
	}
	
	return hash;
}


QueryCache::QueryCacheIndex::QueryCacheIndex( boost::shared_ptr<jedox::palo::Server> s, const std::string& db, const std::string& c )
: have_server(true), server_srv( s ), database( StringUtils::toUpper( db ) ), cube( StringUtils::toUpper( c ) ) {}


QueryCache::QueryCacheIndex::QueryCacheIndex( const std::string& s, const std::string& db, const std::string& c )
: have_server(false), server_str( s ), database( StringUtils::toUpper( db ) ), cube( StringUtils::toUpper( c ) ) {}


QueryCache::QueryCacheInnerIndex::QueryCacheInnerIndex( const StringArray& p ) {
	path.reserve(p.size());

	for ( StringArray::const_iterator i = p.begin(); i != p.end(); i++ ) {
		path.push_back( StringUtils::toUpper( *i ) );
	}
}


bool Palo::SpreadsheetFuncs::operator < ( const QueryCache::QueryCacheIndex& left, const QueryCache::QueryCacheIndex& right ) {
	if (left.have_server && !right.have_server) {
		return false;
	} else { 
		if(!left.have_server && right.have_server) {
			return true;
		}
	}

	int cmp = left.have_server ? 
		left.server_srv->getSID().compare( right.server_srv->getSID() )
		: left.server_str.compare( right.server_str );
	if ( cmp != 0 ) {
		return (cmp < 0);
	} else {
		cmp = left.database.compare( right.database );
		if ( cmp != 0 ) {
			return (cmp < 0);
		} else {
			return ( left.cube.compare( right.cube ) < 0 );
		}
	}
}


bool Palo::SpreadsheetFuncs::operator < ( const QueryCache::QueryCacheInnerIndex& left, const QueryCache::QueryCacheInnerIndex& right ) {
	StringArray::const_iterator l = left.path.begin();
	StringArray::const_iterator r = right.path.begin();

	int cmp;
	for ( ; (l != left.path.end()) && (r != right.path.end()); l++, r++ ) {
		cmp = l->compare( *r );

		if ( cmp != 0 ) {
			return (cmp < 0);
		}
	}

	return ( (l == left.path.end()) && (r != right.path.end()) );
}


QueryCache::QueryCacheEntry::QueryCacheEntry() : result(new(CellValue::Pool) CellValue()), obsolete(false) {}

QueryCache::QueryCacheEntry::QueryCacheEntry( const CellValue& cv ) : result( new(CellValue::Pool) CellValue(cv) ), obsolete(false) {}

QueryCache::QueryCacheEntry::~QueryCacheEntry() {
	if (result) {
		CellValue::operator delete(result, CellValue::Pool);
		result = NULL;
	}
}

QueryCache::QueryCacheEntry::QueryCacheEntry( const QueryCacheEntry& other ) : result( new(CellValue::Pool) CellValue(*other.result)) {}


QueryCache::QueryCacheEntry& QueryCache::QueryCacheEntry::operator=( const QueryCacheEntry& other ) {
	obsolete = other.obsolete;
	*result = *other.result;

	return *this;
}


QueryCache::QueryCache(ConnectionPool& cp) : status( Collect ), cp(cp) {};


QueryCache::Status QueryCache::getStatus() const {
	return status;
}


bool QueryCache::setStatus( Status s, bool check_locks ) {
	bool result;
	bool lock_check;

	if ( (status == Collect) && (s == Return) ) {
		result = exec(&lock_check);
		result = check_locks ? (lock_check || result) : result;
	} else { 
		if ( (status == Return) && (s == Collect) ) {
			for(QueryCacheMap::iterator i = cache.begin(); i != cache.end(); ++i) {
				for(QueryCacheInnerMap::iterator j = i->second.begin(); j != i->second.end(); ++j) {
					j->second.obsolete = true;
				}
			}

			result = false;
		}
	}

	status = s;

	return result;
}


bool QueryCache::removeObsolete()
{
	bool changed = false;

	for(QueryCacheMap::iterator i = cache.begin(); i != cache.end();) {
		for(QueryCacheInnerMap::iterator j = i->second.begin(); j != i->second.end();) {
			if(j->second.obsolete) {
				changed = true;

				QueryCacheInnerMap::iterator tmp = j;

				++j;

				i->second.erase(tmp);
			} else {
				++j;
			}
		}

		// drop empty
		if(i->second.empty()) {
			QueryCacheMap::iterator tmp = i;

			++i;

			cache.erase(tmp);
		} else {
			++i;
		}
	}

	return changed;
}


jedox::palo::Cell_Values_Coordinates QueryCache::_Make_Cell_Value_Coordinates( jedox::palo::Cube c, QueryCacheInnerMap& im ) {
	Cell_Values_Coordinates cvc;

	cvc.rows = im.size();
	cvc.cols = c.getCacheData().number_dimensions;

	unique_ptr<char*> strings;
	strings.reset( new char*[cvc.rows*cvc.cols] );

	size_t count;
	for ( QueryCacheInnerMap::const_iterator i = im.begin(); i != im.end(); i++ ) {
		if ( i->first.path.size() != cvc.cols ) {
			throw SpreadsheetFuncsException( CurrentSourceLocation, SpreadsheetFuncsErrors::ERROR_INVALID_NUMBER_OF_DIMENSIONS );
		}

		count = 0;
		for ( StringArray::const_iterator j = i->first.path.begin(); j != i->first.path.end(); j++, count++ ) {
			strings.get()[count*cvc.cols + ( j - i->first.path.begin() )] = ( char* )j->c_str();
		}
	}

	cvc.a = strings.release();
	return cvc;
}

bool QueryCache::exec(bool *lock_changed) {
	bool changed = false;

	if (lock_changed) {
		*lock_changed = false;
	}

	QueryCacheMap::iterator begin = cache.begin(), end = cache.end();
	std::vector<CELL_VALUE> cv;
	QueryCacheInnerMap::iterator k;
	for ( QueryCacheMap::iterator i = begin; i != end; i++ ) {
		const QueryCacheIndex& idx = i->first;
		QueryCacheInnerMap& im = i->second;

		try {
			StringArrayArray sa;
			sa.reserve( im.size() );
			for ( QueryCacheInnerMap::const_iterator j = im.begin(); j != im.end(); j++ ) {
				sa.push_back( j->first.path ); // TODO: this copy is actually overhead only...
			}

			boost::shared_ptr<jedox::palo::Server> server = idx.have_server ? idx.server_srv : cp.get(idx.server_str);

			// assure that we are getting up-to-date data
			cv.clear();
			server->ping();

			( *server )[idx.database].cube[idx.cube].CellValues(cv, sa, 0, 1 );

			std::vector<CELL_VALUE>::const_iterator l = cv.begin();
			for ( k = im.begin(); l != cv.end() && k != im.end(); l++, k++ ) {
				if (*(k->second.result) != *l) {
					changed = true;
				}

				if (lock_changed && (k->second.result->lock_status != l->lock_status)) {
					*lock_changed = true;
				}

				*(k->second.result) = *l;
			}
			while ( k != im.end() ) {
				changed = true;
				*(k->second.result) = ErrorInfo(XLError::NAxl, 0, "No data returned!" );
				++k;
			}
		} catch ( const jedox::palo::PaloServerException& e ) {
			for ( k = im.begin(); k != im.end(); k++ ) {
				changed = true;
				*(k->second.result) = ErrorInfo(XLError::VALUExl, e.code(), "Palo returned error: " + e.longDescription() );
			}
		} catch ( const jedox::palo::PaloException& e ) {
			for ( k = im.begin(); k != im.end(); k++ ) {
				changed = true;
				*(k->second.result) = ErrorInfo(XLError::VALUExl, e.code(), "libpalo_ng returned error: " + e.longDescription() );
			}
		} catch ( const jedox::palo::SocketException& e ) {
			for ( k = im.begin(); k != im.end(); k++ ) {
				changed = true;
				*(k->second.result) = ErrorInfo(XLError::VALUExl, -1, std::string("libpalo_ng returned error: ") + e.what() );
			}
		} catch ( const CPException& e ) {
			for ( k = im.begin(); k != im.end(); k++ ) {
				changed = true;
				*(k->second.result) = ErrorInfo(XLError::VALUExl, -1, std::string("PaloXLL error: ") + e.what() );
			}
		}
	}

//  Try again with optimization
	return changed;

//	return begin != end;
}

template <class ServerType> 
void QueryCache::addRequest( ServerType s, const std::string& database, const std::string& cube, const StringArray& path, const CellValue* *const ptr ) {
	QueryCacheEntry& qce = cache[QueryCacheIndex( s, database, cube )][QueryCacheInnerIndex( path )];

	qce.obsolete = false;

	if (ptr) {
		*ptr = qce.result;
	}
}

template <class ServerType> 
const CellValue& QueryCache::getResult( ServerType s, const std::string& database, const std::string& cube, const StringArray& path ) const {
	QueryCacheMap::const_iterator i = cache.find( QueryCacheIndex( s, database, cube ) );
	if ( i == cache.end() ) {
		throw QueryCacheEntryNotFoundException( CurrentSourceLocation );
	}

	QueryCacheInnerMap::const_iterator j = i->second.find( QueryCacheInnerIndex( path ) );
	if ( j == i->second.end() ) {
		throw QueryCacheEntryNotFoundException( CurrentSourceLocation );
	}

	return *(j->second.result);
}


void QueryCache::addRequest( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& cube, const StringArray& path, const CellValue* *const ptr ) {
	addRequest<boost::shared_ptr<jedox::palo::Server> >(s, database, cube, path, ptr);
}


const CellValue& QueryCache::getResult( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& cube, const StringArray& path ) const {
	return getResult<boost::shared_ptr<jedox::palo::Server> >(s, database, cube, path);
}

void QueryCache::addRequest( const std::string& s, const std::string& database, const std::string& cube, const StringArray& path, const CellValue* *const ptr ) {
	addRequest<const std::string& >(s, database, cube, path, ptr);
}


const CellValue& QueryCache::getResult( const std::string& s, const std::string& database, const std::string& cube, const StringArray& path ) const {
	return getResult<const std::string& >(s, database, cube, path);
}
