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

#ifndef XL_SPREADSHEET_FUNCS_H
#define XL_SPREADSHEET_FUNCS_H

#ifdef __cplusplus

#include <memory>

#include <PaloSpreadsheetFuncs/SpreadsheetFuncs.h>

#include "XLContext.h"
#include "XLConnectionPool.h"
#include "XLFuncsDoc.h"

namespace Palo {
	namespace XLL {
		using namespace Palo::SpreadsheetFuncs;
		
		
		class XLSpreadsheetFuncs : public SpreadsheetFuncs {
			XLSpreadsheetFuncs();

		public:
			~XLSpreadsheetFuncs();

			void FPaloElementName( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );


			void FPaloSetdataAWrap( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloSetdataWrap( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );

			/*! Calculates the active sheet only, DATAX is then mapped to DATAC. */
			void FPaloCalcSheet( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );

			void FPaloCloseConnections( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );

			void FPaloEnableLoop( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloConnectionUser( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloEnableUndoColoring( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );


			void FPaloRegisterServer( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloRemoveConnection( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );

			void FPaloElementAdd( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloElementDelete( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloElementRename( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloElementUpdate( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );

			void FPaloServerSubset( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloSubsetX( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
		
			void FPaloError( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloClearErrors( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloLogSetdataError( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );

			std::string FPaloElementAdd( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& dimension, DimensionElementType type, const std::string& element, const std::string& parent, double cfactor, bool clear );
			bool FPaloElementDelete( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& dimension, const std::string& element );
			void FPaloElementRename( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& dimension, const std::string& old_name, const std::string& new_name );

			static XLSpreadsheetFuncs& getInstance();
			static void clearInstance();
			XLContext& getSettings();

			XLConnectionPool& getConnectionPool();

			void scheduleClearErrors();

			/* wrappers to choose correct recalculation setting */
			void FPaloGetdataAC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloGetdataATC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloGetdataC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloGetdataTC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloGetdataX( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );

			void FPaloRecalcHandler( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );
			void FPaloSetRecalcHandler( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg );

		private:
			std::string createElementAddKey( const std::string& servername, const std::string& db, const std::string& dim );

			/*! override that uses faster lookup */
			CellValue _FPaloGetdataC( GenericCell& server, GenericCell& database, GenericCell& cube, GenericCell& path, const CellValue* *const = NULL );

			std::string _FPaloRegisterServer( const std::string& key, const std::string& hostname, unsigned short int port, const std::string& username, const std::string& password, bool do_connect = true);
			void _FPaloRemoveConnection(const std::string& key);

			bool clear_errors;
			XLContext xs;
			static XLSpreadsheetFuncs* sf;

			static CellValue _duplicate; // to indicate two DATAC's in one cell

			/* faster lookup structure */
			typedef std::unordered_map<typename XLCellRange::CellID, const CellValue*> QCShortcut;
			QCShortcut qc_shortcut;

			XLConnectionPool xlcp;

			bool have_ambiguous_datac;
		};
	}
}


#else							 // __cplusplus
void XLSpreadsheetFuncsCleanup();
#endif							 // __cplusplus
#endif
