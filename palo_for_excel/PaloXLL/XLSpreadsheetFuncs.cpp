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
 *
 */

//  Additional Revisions to Palo (c) Junction BI LLC:
//  JMM 09-20-13 For 5.0 library compatability

#include <fstream>

#include <boost/lexical_cast.hpp>

#include "XLSpreadsheetFuncs.h"

#include <PaloSpreadsheetFuncs/SpreadsheetFuncsException.h>
#include <PaloSpreadsheetFuncs/WrongParamCountException.h>

#include "XLCellStyler.h"
#include "XLLException.h"
#include "XLSpecialConv.h"
#include "XLLCellLogger.h"

#include "main.h"

extern "C" short int doexecute;

using namespace Palo::XLL;
using namespace Palo::Types;

template<class ExcelStructsWrapper>
XLSpreadsheetFuncs<ExcelStructsWrapper>::XLSpreadsheetFuncs() : xlcp(), SpreadsheetFuncs( xlcp ), clear_errors( false ), have_ambiguous_datac( false ) {}

template<class ExcelStructsWrapper>
XLSpreadsheetFuncs<ExcelStructsWrapper>::~XLSpreadsheetFuncs() {}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloSetdataAWrap( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.rshift( 2 );
	SpreadsheetFuncs::FPaloSetdataA( retval, opts, arg );
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloSetdataWrap( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.rshift( 2 );
	SpreadsheetFuncs::FPaloSetdata( retval, opts, arg );
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloCloseConnections( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.checkArgCount( 0 );

	xlcp.clear();

	retval.set( true );
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloEnableLoop( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.checkArgCount( 1 );

	getSettings().enableLoop( arg[0].getBool() );

	retval.set( getSettings().getLoopState() );
}


template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloConnectionUser( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.checkArgCount( 1 );
	retval.set( xlcp.getUser(arg[0].getString(), true) );
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloEnableUndoColoring( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	arg.checkArgCount( 1 );

	getSettings().enableUndoColoring( arg[0].getBool() );	

	retval.set( getSettings().getUndoColorState() );
}
template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloElementAdd( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( getSettings().getLoopState() ) {
		SpreadsheetFuncs::FPaloElementAdd( retval, opts, arg );
	}
	else {
		retval.set( false );
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloElementUpdate( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( getSettings().getLoopState() ) {
		SpreadsheetFuncs::FPaloElementUpdate( retval, opts, arg );
	}
	else {
		retval.set( false );
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloElementDelete( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( getSettings().getLoopState() ) {
		SpreadsheetFuncs::FPaloElementDelete( retval, opts, arg );
	}
	else {
		retval.set( false );
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloElementRename( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( getSettings().getLoopState() ) {
		SpreadsheetFuncs::FPaloElementRename( retval, opts, arg );
	}
	else {
		retval.set( false );
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloServerSubset(GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
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

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloSubsetX( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if (static_cast<XLContext<ExcelStructsWrapper>&>(opts).getRecalcType() == XLContext<ExcelStructsWrapper>::FullRecalc) {
		/*! \todo Use SheetID instead of book+sheetname! */
		if (static_cast<XLContext<ExcelStructsWrapper>&>(opts).getCurrentBookSheetName() == XLCellRange<ExcelStructsWrapper>::getCallingBookSheetName()) {
			FPaloSubset( retval, opts, arg );
		} else {
			retval.set( CellValue( ErrorInfo(XLError::NAxl, 0) ) ); 
		}
	} else {
		FPaloSubset( retval, opts, arg );
	}
}

template<class ExcelStructsWrapper>
std::string XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloElementAdd( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& dimension, DimensionElementType type, const std::string& element, const std::string& parent, double cfactor, bool clear ) {
	if ( element.empty() ) {
		return "";
	} else {
		return SpreadsheetFuncsBase::FPaloElementAdd( s, database, dimension, type, element, parent, cfactor, clear );
	}
}

template<class ExcelStructsWrapper>
bool XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloElementDelete( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& dimension, const std::string& element ) {
	if ( element.empty() ) {
		return "";
	} else {
		return SpreadsheetFuncsBase::FPaloElementDelete( s, database, dimension, element );
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloElementRename( boost::shared_ptr<jedox::palo::Server> s, const std::string& database, const std::string& dimension, const std::string& old_name, const std::string& new_name ) {
	if ( old_name.empty() || new_name.empty() ) {
		return;
	} else {
		return SpreadsheetFuncsBase::FPaloElementRename( s, database, dimension, old_name, new_name );
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloError( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	std::string mesg;
	try {
		mesg = getSettings().getError().desc;
	} catch (std::exception exp) {
		mesg = std::string("Something strange went wrong getting error message :") + std::string(exp.what());
		XLLCellLogger::getInstance().log(AbstractLogger::LOG_WARNING, mesg);
	}

	retval.set( mesg);
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloLogSetdataError( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if ( arg.length() < 3 ) {
		throw WrongParamCountException( CurrentSourceLocation );
	}

	CellValue cv = arg[2].getCellValue();

	if ( dynamic_cast<XLCell<ExcelStructsWrapper>&>( arg[0] ).isError() ) {
		using namespace std;

		ofstream file( arg[1].getString().c_str(), ios_base::app | ios_base::out | ios_base::binary );

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
			XLCellRange<ExcelStructsWrapper> setdata_cell = dynamic_cast<XLCell<ExcelStructsWrapper>&>( arg[0] ).getAsRange();

			errmsg = getSettings().getError( setdata_cell.getKey() ).desc;
		} 
        // JMM 09-20-13
        //catch (const Palo::Types::Exception ) {
        catch (const CPException ) {
			errmsg = "Unknown error.";
		}

		file << errmsg << '\n';

		file.close();
	}

	retval.set( cv );
}

template<class ExcelStructsWrapper>
XLConnectionPool& XLSpreadsheetFuncs<ExcelStructsWrapper>::getConnectionPool() {
	return xlcp;
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloGetdataX( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if(static_cast<XLContext<ExcelStructsWrapper>&>(opts).getRecalcType() == XLContext<ExcelStructsWrapper>::FullRecalc) {
		/*! \todo Use SheetID instead of book+sheetname! */
		if(static_cast<XLContext<ExcelStructsWrapper>&>(opts).getCurrentBookSheetName() == XLCellRange<ExcelStructsWrapper>::getCallingBookSheetName()) {
			FPaloGetdataC( retval, opts, arg ); 
		} else {
			retval.set( CellValue( ErrorInfo(XLError::NAxl, 0) ) ); 
		}
	} else {
		FPaloGetdataC( retval, opts, arg );
	}
}

template<class ExcelStructsWrapper>
typename XLContext<ExcelStructsWrapper>& XLSpreadsheetFuncs<ExcelStructsWrapper>::getSettings() {
	ExcelStructsWrapper::XLOPERX xRes;

	if( clear_errors ) {
		if ( ExcelStructsWrapper::Excelx( xlfCaller, ( ExcelStructsWrapper::LPXLOPERX )&xRes, 0 ) == xlretSuccess ) {
			if ( xRes.xltype != xltypeErr ) {
				xs.clearErrors();
				clear_errors = false;
			}

			ExcelStructsWrapper::Excelx( xlFree, NULL, 1, ( ExcelStructsWrapper::LPXLOPERX )&xRes );
		}
	}

	return xs;
}

template<class ExcelStructsWrapper>
XLSpreadsheetFuncs<ExcelStructsWrapper>& XLSpreadsheetFuncs<ExcelStructsWrapper>::getInstance() {
	if ( !sf ) {
		sf = new XLSpreadsheetFuncs<ExcelStructsWrapper>();
	}

	return *sf;
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::clearInstance() {
	if ( sf ) {
		delete sf;
		sf = NULL;
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::scheduleClearErrors() {
	clear_errors = true;
}

extern "C" void XLSpreadsheetFuncsCleanup() {
#ifdef __XLL_VERSION_4
	XLSpreadsheetFuncs<Excel4Types>::clearInstance();
#else
	XLSpreadsheetFuncs<Excel12Types>::clearInstance();
#endif
}

template<class ExcelStructsWrapper>
std::string XLSpreadsheetFuncs<ExcelStructsWrapper>::createElementAddKey( const std::string& servername, const std::string& db, const std::string& dim ) {
	return "EADD|" + servername + "," + db + "," + dim;
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloGetdataAC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if(static_cast<XLContext<ExcelStructsWrapper>&>(opts).getLoopState()) {
		// map to DATA inside a loop
		FPaloGetdataA(retval, opts, arg);
	} else {
		SpreadsheetFuncs::FPaloGetdataAC( retval, opts, arg );
		if (static_cast<XLContext<ExcelStructsWrapper>&>( opts ).getRecalcType() == XLContext<ExcelStructsWrapper>::FullRecalc) {
			static_cast<XLContext<ExcelStructsWrapper>&>( opts ).setNeedFullRecalc(true);
		}
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloGetdataATC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if (static_cast<XLContext<ExcelStructsWrapper>&>(opts).getLoopState()) {
		// map to DATA inside a loop
		FPaloGetdataAT(retval, opts, arg);
	} else {
		SpreadsheetFuncs::FPaloGetdataATC( retval, opts, arg );
		if (static_cast<XLContext<ExcelStructsWrapper>&>( opts ).getRecalcType() == XLContext<ExcelStructsWrapper>::FullRecalc) {
			static_cast<XLContext<ExcelStructsWrapper>&>( opts ).setNeedFullRecalc(true);
		}
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloGetdataC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if(static_cast<XLContext<ExcelStructsWrapper>&>(opts).getLoopState()) {
		// map to DATA inside a loop
		FPaloGetdata(retval, opts, arg);
	} else {
		SpreadsheetFuncs::FPaloGetdataC( retval, opts, arg );
		if (static_cast<XLContext<ExcelStructsWrapper>&>( opts ).getRecalcType() == XLContext<ExcelStructsWrapper>::FullRecalc) {
			static_cast<XLContext<ExcelStructsWrapper>&>( opts ).setNeedFullRecalc(true);
		}
	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloGetdataTC( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	if (static_cast<XLContext<ExcelStructsWrapper>&>(opts).getLoopState()) {
		// map to DATA inside a loop
		FPaloGetdataT(retval, opts, arg);
	} else {
		SpreadsheetFuncs::FPaloGetdataTC( retval, opts, arg );
		if (static_cast<XLContext<ExcelStructsWrapper>&>( opts ).getRecalcType() == XLContext<ExcelStructsWrapper>::FullRecalc) {
			static_cast<XLContext<ExcelStructsWrapper>&>( opts ).setNeedFullRecalc(true);
		}
	}
}

template<class ExcelStructsWrapper>
XLSpreadsheetFuncs<ExcelStructsWrapper>* XLSpreadsheetFuncs<ExcelStructsWrapper>::sf = 0;

template<class ExcelStructsWrapper>
CellValue XLSpreadsheetFuncs<ExcelStructsWrapper>::_FPaloGetdataC( GenericCell& server, GenericCell& database, GenericCell& cube, GenericCell& path, const CellValue* *const) {
	if (qc.getStatus() == QueryCache::Collect) {
		const CellValue *latter_result = NULL;

		CellValue result = SpreadsheetFuncs::_FPaloGetdataC(server, database, cube, path, &latter_result);

		const CellValue*& dest = qc_shortcut[XLCellRange<ExcelStructsWrapper>::getCallerID()];

		if (dest != NULL) {
			latter_result = &_duplicate;
		}

		dest = latter_result; // Return last result (naive guess).
		have_ambiguous_datac = have_ambiguous_datac || (latter_result->type == CellValue::ERR);
		return *latter_result;
	} else {
		QCShortcut::const_iterator i = qc_shortcut.find(XLCellRange<ExcelStructsWrapper>::getCallerID());

		if ((i == qc_shortcut.end()) || (i->second == NULL)) {
			throw XLLException(CurrentSourceLocation, XLLErrors::ERROR_XLCELL_INTERNAL);
		}
		
		if (i->second == &_duplicate) {
			return SpreadsheetFuncs::_FPaloGetdataC(server, database, cube, path, NULL);
		}

		return *(i->second);

	}
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloSetRecalcHandler( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	set_recalc_handler();
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloRecalcHandler( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	doexecute = 1;

	XLSpreadsheetFuncs& xl = XLSpreadsheetFuncs::getInstance();

	//xl.getSettings().saveState();

	if ( xl.SpreadsheetFuncsBase::FPaloEndCacheCollect() || have_ambiguous_datac ) {
		xl.scheduleClearErrors();

		XLContext<ExcelStructsWrapper>& ctx = xl.getSettings();

		if( (ctx.getRecalcType() == XLContext<ExcelStructsWrapper>::FullRecalc && ctx.getNeedFullRecalc()) ) {
			ExcelStructsWrapper::Excelx( xlcCalculateNow, 0, 0 );
		} else {
			ExcelStructsWrapper::Excelx( xlcCalculateDocument, 0, 0 );
		}
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

	// set cell color (of locked cells)
	XLCellStyler<ExcelStructsWrapper>& cs = XLCellStyler<ExcelStructsWrapper>::getInstance();
	if (static_cast<XLContext<ExcelStructsWrapper>&>(opts).getUndoColorState()) {
		cs.process(true);
	}
	
	retval.set(true);
}

template<class ExcelStructsWrapper>
void XLSpreadsheetFuncs<ExcelStructsWrapper>::FPaloCalcSheet( GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) {
	static_cast<XLContext<ExcelStructsWrapper>&>(opts).setRecalcType(XLContext<ExcelStructsWrapper>::SheetRecalc);

	ExcelStructsWrapper::Excelx(xlcCalculateDocument, 0, 0);

	/* we need to call the handler explicitly
	 * -> no, Excel seems to call it automatically (which conflicts with the XLM-API specs)
	 */
	//FPaloRecalcHandler(retval, opts, arg);
}

#define MSG_DUPLICATE_DATAC	 MSG_NO_VALUE_YET " (Duplicate datac)"

template<class ExcelStructsWrapper>
CellValue XLSpreadsheetFuncs<ExcelStructsWrapper>::_duplicate = CellValue( ErrorInfo(XLError::NAxl, 0, MSG_DUPLICATE_DATAC) );

#ifdef __XLL_VERSION_4
template class XLSpreadsheetFuncs<Excel4Types>;
#else
template class XLSpreadsheetFuncs<Excel12Types>;
#endif