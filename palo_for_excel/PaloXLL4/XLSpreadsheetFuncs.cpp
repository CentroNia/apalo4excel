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

#include <fstream>

#include <boost/lexical_cast.hpp>

#include "XLSpreadsheetFuncs.h"

#include <PaloSpreadsheetFuncs/SpreadsheetFuncsException.h>
#include <PaloSpreadsheetFuncs/WrongParamCountException.h>

#include  "../JedoxXlHelper/JedoxXlHelper.h"

#include "XLCellStyler.h"
#include "XLLException.h"
#include "XLSpecialConv.h"
#include "XLLCellLogger.h"

#include "main.h"

extern "C" short int doexecute;

using namespace Palo::XLL;
using namespace Palo::Types;


XLSpreadsheetFuncs::XLSpreadsheetFuncs() : xlcp(), SpreadsheetFuncs(), clear_errors( false ), have_ambiguous_datac( false ) {}


XLSpreadsheetFuncs::~XLSpreadsheetFuncs() {}


void XLSpreadsheetFuncs::FPaloSetdataAWrap( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.rshift( 2 );
	SpreadsheetFuncs::FPaloSetdataA( retval, opts, arg );
}


void XLSpreadsheetFuncs::FPaloSetdataWrap( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.rshift( 2 );
	SpreadsheetFuncs::FPaloSetdata( retval, opts, arg );
}


void XLSpreadsheetFuncs::FPaloCloseConnections( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.checkArgCount( 0 );

	xlcp.clear();

	retval.set( true );
}


void XLSpreadsheetFuncs::FPaloEnableLoop( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.checkArgCount( 1 );

	getSettings().enableLoop( arg[0].getBool() );

	retval.set( getSettings().getLoopState() );
}


void XLSpreadsheetFuncs::FPaloRegisterServer( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	switch(arg.length()) {
		case 6:
			retval.set( _FPaloRegisterServer( arg[0].getString(), arg[1].getString(), arg[2].getUInt(), arg[3].getString(), arg[4].getString(), arg[5].getBool() ) );
			break;

		case 5:
			retval.set( _FPaloRegisterServer( arg[0].getString(), arg[1].getString(), arg[2].getUInt(), arg[3].getString(), arg[4].getString() ) );
			break;

		default:
			throw WrongParamCountException( CurrentSourceLocation );
	}
}



void XLSpreadsheetFuncs::FPaloRemoveConnection( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.checkArgCount(1);

	_FPaloRemoveConnection(arg[0].getString());
	retval.set(true);
}


void XLSpreadsheetFuncs::FPaloConnectionUser( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.checkArgCount( 1 );
	retval.set( xlcp.getUser(arg[0].getString(), true) );
}


void XLSpreadsheetFuncs::FPaloEnableUndoColoring( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.checkArgCount( 1 );

	getSettings().enableUndoColoring( arg[0].getBool() );	

	retval.set( getSettings().getUndoColorState() );
}


void XLSpreadsheetFuncs::FPaloElementAdd( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( getSettings().getLoopState() ) {
		SpreadsheetFuncs::FPaloElementAdd( retval, opts, arg );
	}
	else {
		retval.set( false );
	}
}


void XLSpreadsheetFuncs::FPaloElementUpdate( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( getSettings().getLoopState() ) {
		SpreadsheetFuncs::FPaloElementUpdate( retval, opts, arg );
	}
	else {
		retval.set( false );
	}
}


void XLSpreadsheetFuncs::FPaloElementDelete( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( getSettings().getLoopState() ) {
		SpreadsheetFuncs::FPaloElementDelete( retval, opts, arg );
	}
	else {
		retval.set( false );
	}
}


void XLSpreadsheetFuncs::FPaloElementRename( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( getSettings().getLoopState() ) {
		SpreadsheetFuncs::FPaloElementRename( retval, opts, arg );
	}
	else {
		retval.set( false );
	}
}


void XLSpreadsheetFuncs::FPaloElementName( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
//	IfDebugLogging("FPaloElementName called");
	SpreadsheetFuncs::FPaloElementName( retval, opts, arg );
//	IfDebugLogging(std::string("retval=#").append(retval.getString()).append("#").c_str());
}




void XLSpreadsheetFuncs::FPaloServerSubset(GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	std::vector<std::vector<std::string>> serverSubsetResult;

	xlcp.getServerSubset( arg[0].getString(), arg[1].getString(), arg[2].getBool(), arg[3].getString(), serverSubsetResult);
	
	SubsetResults srs;
	if(serverSubsetResult.size() == 3) {
		size_t numSubsetResult = serverSubsetResult[0].size();
		for(size_t i = 0; i < numSubsetResult; i++) {
			srs.push_back(SubsetResult(XLSpecialConv::local2utf8(serverSubsetResult[1][i]), XLSpecialConv::local2utf8(serverSubsetResult[2][i]), boost::lexical_cast<int>(serverSubsetResult[0][i])));
		}		
	}	
	serverSubsetResult.clear();
	retval.set(srs);
}


void XLSpreadsheetFuncs::FPaloSubsetX( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if (static_cast<XLContext&>(opts).getRecalcType() == XLContext::FullRecalc) {
		/*! \todo Use SheetID instead of book+sheetname! */
		if (static_cast<XLContext&>(opts).getCurrentBookSheetName() == XLCellRange::getCallingBookSheetName()) {
			FPaloSubset( retval, opts, arg );
		} else {
			retval.set( CellValue( ErrorInfo(XLError::NAxl, 0) ) ); 
		}
	} else {
		FPaloSubset( retval, opts, arg );
	}
}


void XLSpreadsheetFuncs::_FPaloRemoveConnection(const std::string& key) {
	xlcp.remove(key);
}



std::string XLSpreadsheetFuncs::FPaloElementAdd( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& dimension, DimensionElementType type, const std::string& element, const std::string& parent, double cfactor, bool clear ) {
	if ( element.empty() ) {
		return "";
	} else {
		return SpreadsheetFuncsBase::FPaloElementAdd( s, database, dimension, type, element, parent, cfactor, clear );
	}
}


bool XLSpreadsheetFuncs::FPaloElementDelete( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& dimension, const std::string& element ) {
	if ( element.empty() ) {
		return "";
	} else {
		return SpreadsheetFuncsBase::FPaloElementDelete( s, database, dimension, element );
	}
}


void XLSpreadsheetFuncs::FPaloElementRename( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& dimension, const std::string& old_name, const std::string& new_name ) {
	if ( old_name.empty() || new_name.empty() ) {
		return;
	} else {
		return SpreadsheetFuncsBase::FPaloElementRename( s, database, dimension, old_name, new_name );
	}
}


void XLSpreadsheetFuncs::FPaloError( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	std::string mesg;
	try {
		mesg = getSettings().getError().desc;
	} catch (const std::exception& exp) {
		mesg = std::string("Something strange went wrong getting error message : ") + std::string(exp.what());
		XLLCellLogger::getInstance().log(AbstractLogger::LOG_WARNING, mesg);
	}

	retval.set( mesg);
}



void XLSpreadsheetFuncs::FPaloClearErrors( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	getSettings().clearErrors();
	retval.set(true);
}



void XLSpreadsheetFuncs::FPaloLogSetdataError( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( arg.length() < 3 ) {
		throw WrongParamCountException( CurrentSourceLocation );
	}

	CellValue cv = arg[2].getCellValue();

	if ( dynamic_cast<XLCell&>( arg[0] ).isError() ) {
		using namespace std;

		ofstream file( XLSpecialConv::utf82local(arg[1].getString()), ios_base::app | ios_base::out | ios_base::binary );

		if ( file.fail() ) {
			throw XLLException( CurrentSourceLocation, "Error opening file." );
		}

		std::string delim = "\t";

		file << cv << delim;

		if( arg.length() > 3) {		
			// cube
			file << arg[3].getString() << delim;

			arg.collapseToArray( 4 );
			StringArray coords = arg[4].getStringArray();

			for ( StringArray::const_iterator i = coords.begin(); i != coords.end(); ++i ) {
				file << *i << delim;
			}
		}
		string errmsg;

		try {
			XLCellRange setdata_cell = dynamic_cast<XLCell&>( arg[0] ).getAsRange();

			errmsg = getSettings().getError( setdata_cell.getKey() ).desc;
		} catch (... ) {
			errmsg = "Unknown error.";
		}

		file << errmsg << '\n';

		file.close();
	}

	retval.set( cv );
}


XLConnectionPool& XLSpreadsheetFuncs::getConnectionPool() {
	return xlcp;
}


void XLSpreadsheetFuncs::FPaloGetdataX( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if(static_cast<XLContext&>(opts).getRecalcType() == XLContext::FullRecalc) {
		/*! \todo Use SheetID instead of book+sheetname! */
		if(static_cast<XLContext&>(opts).getCurrentBookSheetName() == XLCellRange::getCallingBookSheetName()) {
			FPaloGetdataC( retval, opts, arg ); 
		} else {
			retval.set( CellValue( ErrorInfo(XLError::NAxl, 0) ) ); 
		}
	} else {
		FPaloGetdataC( retval, opts, arg );
	}
}


XLContext& XLSpreadsheetFuncs::getSettings() {
	XLOPERX xRes;

	if( clear_errors ) {
		if ( Excelx( xlfCaller, ( LPXLOPERX )&xRes, 0 ) == xlretSuccess ) {
			if ( xRes.xltype != xltypeErr ) {
				xs.clearErrors();
				clear_errors = false;
			}

			Excelx( xlFree, NULL, 1, ( LPXLOPERX )&xRes );
		}
	}

	return xs;
}


XLSpreadsheetFuncs& XLSpreadsheetFuncs::getInstance() {
	if ( !sf ) {
		sf = new XLSpreadsheetFuncs();
	}

	return *sf;
}


void XLSpreadsheetFuncs::clearInstance() {
	if ( sf ) {
		delete sf;
		sf = NULL;
	}
}


void XLSpreadsheetFuncs::scheduleClearErrors() {
	clear_errors = true;
}

extern "C" void XLSpreadsheetFuncsCleanup() {
	jedox::palo::JedoxXLHelper::getInstance().Cleanup();
	XLSpreadsheetFuncs::clearInstance();
}


std::string XLSpreadsheetFuncs::createElementAddKey( const std::string& servername, const std::string& db, const std::string& dim ) {
	return "EADD|" + servername + "," + db + "," + dim;
}


void XLSpreadsheetFuncs::FPaloGetdataAC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if(static_cast<XLContext&>(opts).getLoopState()) {
		// map to DATA inside a loop
		FPaloGetdataA(retval, opts, arg);
	} else {
		SpreadsheetFuncs::FPaloGetdataAC( retval, opts, arg );
		if (static_cast<XLContext&>( opts ).getRecalcType() == XLContext::FullRecalc) {
			static_cast<XLContext&>( opts ).setNeedFullRecalc(true);
		}
	}
}


void XLSpreadsheetFuncs::FPaloGetdataATC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if (static_cast<XLContext&>(opts).getLoopState()) {
		// map to DATA inside a loop
		FPaloGetdataAT(retval, opts, arg);
	} else {
		SpreadsheetFuncs::FPaloGetdataATC( retval, opts, arg );
		if (static_cast<XLContext&>( opts ).getRecalcType() == XLContext::FullRecalc) {
			static_cast<XLContext&>( opts ).setNeedFullRecalc(true);
		}
	}
}


void XLSpreadsheetFuncs::FPaloGetdataC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if(static_cast<XLContext&>(opts).getLoopState()) {
		// map to DATA inside a loop
		FPaloGetdata(retval, opts, arg);
	} else {
		SpreadsheetFuncs::FPaloGetdataC( retval, opts, arg );
		if (static_cast<XLContext&>( opts ).getRecalcType() == XLContext::FullRecalc) {
			static_cast<XLContext&>( opts ).setNeedFullRecalc(true);
		}
	}
}


void XLSpreadsheetFuncs::FPaloGetdataTC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if (static_cast<XLContext&>(opts).getLoopState()) {
		// map to DATA inside a loop
		FPaloGetdataT(retval, opts, arg);
	} else {
		SpreadsheetFuncs::FPaloGetdataTC( retval, opts, arg );
		if (static_cast<XLContext&>( opts ).getRecalcType() == XLContext::FullRecalc) {
			static_cast<XLContext&>( opts ).setNeedFullRecalc(true);
		}
	}
}


XLSpreadsheetFuncs* XLSpreadsheetFuncs::sf = 0;


CellValue XLSpreadsheetFuncs::_FPaloGetdataC( GenericCell& server, GenericCell& database, GenericCell& cube, GenericCell& path, const CellValue* *const) {
	if (qc.getStatus() == QueryCache::Collect) {
		const CellValue *latter_result = NULL;

		CellValue result = SpreadsheetFuncs::_FPaloGetdataC(server, database, cube, path, &latter_result);

		const CellValue*& dest = qc_shortcut[XLCellRange::getCallerID()];

		if (dest != NULL) {
			latter_result = &_duplicate;
		}

		dest = latter_result; // Return last result (naive guess).
		have_ambiguous_datac = have_ambiguous_datac || (latter_result->type == CellValue::ERR);
		return *latter_result;
	} else {
		QCShortcut::const_iterator i = qc_shortcut.find(XLCellRange::getCallerID());

		if ((i == qc_shortcut.end()) || (i->second == NULL)) {
			throw XLLException(CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL);
		}
		
		if (i->second == &_duplicate) {
			return SpreadsheetFuncs::_FPaloGetdataC(server, database, cube, path, NULL);
		}

		return *(i->second);

	}
}


std::string XLSpreadsheetFuncs::_FPaloRegisterServer( const std::string& key, const std::string& hostname, unsigned short int port, const std::string& username, const std::string& password, bool do_connect) {
	XLConnectionPool::ConnectionData cd(hostname, port, username, password);
	xlcp.add( key, cd );
	if (do_connect) {
		xlcp.get( cd );
	};
	return key;
}


void XLSpreadsheetFuncs::FPaloSetRecalcHandler( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	set_recalc_handler();
}


void XLSpreadsheetFuncs::FPaloRecalcHandler( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	doexecute = 1;

	XLSpreadsheetFuncs& xl = XLSpreadsheetFuncs::getInstance();

	//xl.getSettings().saveState();

	if ( xl.SpreadsheetFuncsBase::FPaloEndCacheCollect() || have_ambiguous_datac ) {
		xl.scheduleClearErrors();

		XLContext& ctx = xl.getSettings();

		if( (ctx.getRecalcType() == XLContext::FullRecalc && ctx.getNeedFullRecalc()) ) {
			Excelx( xlcCalculateNow, 0, 0 );
		} else {
			Excelx( xlcCalculateDocument, 0, 0 );
		}
	}

	try {
		// set cell color (of locked cells)
		XLCellStyler& cs = XLCellStyler::getInstance();
		if (static_cast<XLContext&>(opts).getUndoColorState()) {
			cs.process(true);
		}
	}
	catch(...) {
	}

	xl.SpreadsheetFuncsBase::FPaloStartCacheCollect();

	have_ambiguous_datac = false;

	for (QCShortcut::iterator i = qc_shortcut.begin(), e = qc_shortcut.end(); i != e; ++i) {
		i->second = NULL;
	}

	xl.scheduleClearErrors();

	// retry failed connections on next recalc (requested in ticket 0001194)
	xl.getConnectionPool().resetInvalid();

	xl.getSettings().clearCachedData();

	//xl.getSettings().restoreState();

	retval.set(true);
}


void XLSpreadsheetFuncs::FPaloCalcSheet( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	static_cast<XLContext&>(opts).setRecalcType(XLContext::SheetRecalc);

	Excelx(xlcCalculateDocument, 0, 0);

	FPaloRecalcHandler(retval, opts, arg);
}

#define MSG_DUPLICATE_DATAC	 MSG_NO_VALUE_YET " (Duplicate datac)"

CellValue XLSpreadsheetFuncs::_duplicate = CellValue( ErrorInfo(XLError::NAxl, 0, MSG_DUPLICATE_DATAC) );