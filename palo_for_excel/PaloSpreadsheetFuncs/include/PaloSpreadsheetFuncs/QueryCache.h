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

#ifndef QUERY_CACHE_H
#define QUERY_CACHE_H

#include <string>

#include <boost/functional/hash.hpp>

#include <libpalo_ng/Palo/Server.h>
#include <libpalo_ng/Palo/Cube.h>

#include <libconnectionpool/ConnectionPool.h>

#include <PaloSpreadsheetFuncs/StringArray.h>
#include <PaloSpreadsheetFuncs/CellValue.h>

#if defined(WIN32) || defined(WIN64)
	#include <hash_map>
	#define STDEXT	stdext
#elif defined(__UNIX__)
#include <ext/hash_map>
	#define STDEXT	__gnu_cxx
#endif

#define STL_HASH_STRING boost::hash_value
#if defined(WIN32) || defined(WIN64)
	#define STL_HASH_MAP(key, val) STDEXT::hash_map<key, val>
#elif defined(__UNIX__)
	#define STL_HASH_MAP(key, val) STDEXT::hash_map<key, val, my_hash<key> >
#endif

namespace Palo {
	namespace SpreadsheetFuncs {
		using namespace Types;

#if defined(__UNIX__)
		template <class key>
		struct my_hash {
			inline size_t operator()(const key& idx) const {
				return (size_t)idx;
			}
		};
#endif

		/*! \author Marek Pikulski <marek.pikulski@jedox.com>
		 *  \brief Query cache.
		 *
		 *  This class provides the functionality needed by DATAC. Set the cache status to "Collect"
		 *  in order to add requests to it using addRequest().
		 *  Changing it to "Return" later will execute all stored queries and you will be able to retrieve the
		 *  results using getResult().
		 */
		class QueryCache {
		public:
			QueryCache(ConnectionPool& cp);

			enum Status
			{
			    Collect,
			    Return
			};

			Status getStatus() const;
			/*! \return true if cache was not empty and data (and/or locks - if requested) changed */
			bool setStatus( Status s, bool check_locks = false );
			/*! \return true if cache was changed. */
			bool removeObsolete();

			void addRequest( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& cube, const StringArray& path, const CellValue* *const ptr = 0 );
			const CellValue& getResult( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& cube, const StringArray& path ) const;
			void addRequest( const std::string& s, const std::string& database, const std::string& cube, const StringArray& path, const CellValue* *const ptr = 0 );
			const CellValue& getResult( const std::string& s, const std::string& database, const std::string& cube, const StringArray& path ) const;

			struct QueryCacheIndex {
				QueryCacheIndex( boost::shared_ptr<jedox::palo::Server> s, const std::string& db, const std::string& c );
				QueryCacheIndex( const std::string& s, const std::string& db, const std::string& c );

				friend bool operator < ( const QueryCacheIndex& left, const QueryCacheIndex& right );

				boost::shared_ptr<jedox::palo::Server> server_srv;
				const std::string server_str;
				const std::string database;
				const std::string cube;
				bool have_server;

				operator size_t() const; // for hash_map

private:
				QueryCacheIndex();
			};

			struct QueryCacheInnerIndex {
				QueryCacheInnerIndex( const StringArray& p );

				friend bool operator < ( const QueryCacheInnerIndex& left, const QueryCacheInnerIndex& right );

				StringArray path;

				operator size_t() const; // for hash_map

private:
				QueryCacheInnerIndex();
			};

			struct QueryCacheEntry {
				QueryCacheEntry();
				QueryCacheEntry( const CellValue& cv );
				QueryCacheEntry( const QueryCacheEntry& other );
				~QueryCacheEntry();

				QueryCacheEntry& operator=( const QueryCacheEntry& other );

				CellValue* result;
				bool obsolete;
			};

		private:
			typedef STL_HASH_MAP(QueryCacheInnerIndex, QueryCacheEntry) QueryCacheInnerMap;
			typedef STL_HASH_MAP(QueryCacheIndex, QueryCacheInnerMap) QueryCacheMap;

			bool exec(bool *lock_changed = 0);

			Status status;
			QueryCacheMap cache;
			ConnectionPool& cp;

			jedox::palo::Cell_Values_Coordinates _Make_Cell_Value_Coordinates( jedox::palo::Cube c, QueryCacheInnerMap& im );

			template <class ServerType> void addRequest( ServerType s, const std::string& database, const std::string& cube, const StringArray& path, const CellValue* *const ptr );
			template <class ServerType> const CellValue& getResult( ServerType s, const std::string& database, const std::string& cube, const StringArray& path ) const;
		};
	}
}
#endif
