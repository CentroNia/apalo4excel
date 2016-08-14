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

#ifndef XL_CONTEXT_H
#define XL_CONTEXT_H

#include <map>
#include <set>

#include <PaloSpreadsheetFuncs/GenericContext.h>

#include "XLCellRange.h"

namespace Palo {
	namespace XLL {
		using namespace SpreadsheetFuncs;
		
		template<class ExcelStructsWrapper>
		class XLContext : public GenericContext {
		public:
			XLContext();

			bool splashingAllowed();

			Conversions& getConversions();

			void setError( const Palo::Types::ErrorInfo& ei );
			const Palo::Types::ErrorInfo getError() const;
			const Palo::Types::ErrorInfo getError( const typename XLCellRange<ExcelStructsWrapper>::CellKey& key ) const;

			void clearErrors();
			
			/*! Only applies to "current sheet name", got_datac */
			void clearCachedData();

			/*! returns the name of the currently selected sheet (and workbook) */
			const std::string& getCurrentBookSheetName();

			void setNeedFullRecalc( bool value );
			bool getNeedFullRecalc() const;

			enum RecalcType {
				FullRecalc,
				SheetRecalc
			} recalc_type;

			RecalcType getRecalcType() const;
			void setRecalcType(RecalcType rct);

			void saveState();
			void restoreState();

			void enableLoop( bool enable );
			bool getLoopState() const;

			void enableUndoColoring( bool enable );
			bool getUndoColorState() const;


		private:
			typedef std::map<typename XLCellRange<ExcelStructsWrapper>::CellKey, ErrorInfo> ErrorMap;
			ErrorMap errMap;

			std::string current_sheet;
			bool need_full_recalc;

			bool loop_enabled;
			bool undo_coloring_enabled;

			// saved state
			typename ExcelStructsWrapper::XLOPERX selection;
			typename ExcelStructsWrapper::XLOPERX active_cell;
		};
	}
}
#endif
