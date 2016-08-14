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

#ifndef XL_CELL_H
#define XL_CELL_H

#include <PaloSpreadsheetFuncs/ConvertingCell.h>

#include <windows.h>

#include "XLTypes.h"
#include "XLConnectionPool.h"

// TODO: this may leek (destructor frees only coerced cells)
// now destructor als frees if created via create method

namespace Palo {
	namespace XLL {
		using namespace SpreadsheetFuncs;		
		
		
		class XLCellRange;
		
		class XLCell : public ConvertingCell {
		public:
			explicit XLCell( GenericContext& settings, bool is_retval = false, bool free_content_by_dll = false );
			explicit XLCell( GenericContext& settings, LPXLOPERX oper, bool is_retval = false );
			~XLCell();

			LPXLOPERX release();

			Type getType();

			bool isMissing();

			bool empty(bool allelements = true);
			GenericCell& setEmpty();

			Iterator getArray();
			Iterator getMatrix( size_t& rows, size_t& cols );
			std::string getStringImpl();
			long int getSLong();
			unsigned long int getULong();
			unsigned int getUInt();
			int getSInt();
			bool getBool();
			double getDouble();

			/*!
             * \brief
             * clone the current object.
             *
             * \author
             * Florian Schaper <florian.schaper@jedox.com>
             */
           std::unique_ptr<GenericCell> clone() const;

            /*!
             * \brief
             * create an object of the current type.
             *
             * \author
             * Florian Schaper <florian.schaper@jedox.com>
             */
            std::unique_ptr<GenericCell> create() const;

			boost::shared_ptr<jedox::palo::Server> getConnection();


			ConsolidationElementArray getConsolidationElementArray();

			GenericCell& set( boost::shared_ptr<jedox::palo::Server> s );
			GenericCell& set( int i );
			GenericCell& set( unsigned int i );
			GenericCell& set( long int i );
			GenericCell& set( unsigned long int i );
			GenericCell& set( double d );
			GenericCell& set( long double d );
			GenericCell& setImpl( const std::string& s );
			GenericCell& set( bool b );
			GenericCell& set( const DimensionElementInfo& ei );
			GenericCell& set( const DimensionElementInfoSimple& ei );
			GenericCell& set( const ConsolidationElementInfo& ei );
			GenericCell& set( const DimensionElementInfoSimpleArray& ei );
			GenericCell& set( const ConsolidationElementInfoArray& ceia );
			GenericCell& set( const SubsetResults& srs );
			GenericCell& set( const CellValue& v, bool set_error_desc = true );
			GenericCell& set( const CellValueWithProperties& v, bool set_error_desc = true );
			GenericCell& setError( const ErrorInfo& ei, bool set_error_desc = true);
			GenericCell& setNull();
			GenericArrayBuilder setArray( size_t length, bool pad = true );
			GenericArrayBuilder setMatrix( size_t rows, size_t cols );
			GenericArrayBuilder setMatrix( size_t rows, size_t cols, bool pad );

			GenericCell& supressPadding();

			bool isError();

			XLCellRange getAsRange();

			inline void freeAtEnd(void *vpointer) {
				to_be_freed.push_back(vpointer);
			}

			static const size_t max_cols;
			static const size_t max_rows;

			struct Offset {
				Offset() : row(0), col(0) {}
				RW row;
				COL col;
			} offset;

		private:
			XLConnectionPool& xlcp;

			
			friend class XLArrayBuilderImpl;

			/*! helper function for set() */
			static void setDimensionElementInfoSimple( GenericArrayBuilder& a, const DimensionElementInfoSimple& dis, unsigned int num_entries);

			/*! helper function for set() */
			static void setSubsetResult( GenericArrayBuilder& a, const SubsetResult& sr, unsigned int num_entries);

			/*! helper function for set() */
			static void setConsolidationElementInfo( GenericArrayBuilder& a, const ConsolidationElementInfo& cei, unsigned int num_entries);
			
			/*! helper function for set() */
			template<unsigned int max_entries, typename MultiColumn, typename Functor>
			GenericCell& set( const std::vector<MultiColumn>& mc, Functor setter );

			template<class CellValueType>
			GenericCell& setHelper( const CellValueType& v, bool set_error_desc = true );

			/* convert to something */
			void coerce( int types );

			bool empty( LPXLOPERX oper );

			LPXLOPERX oper, original_oper;
			XLOPERX _oper;

			bool is_retval;
			bool modified;
			bool coerced;
			bool dont_pad;
			bool free_content_by_dll;
			std::vector<void *> to_be_freed;

			void check_unset();
			void set_set();
		};
	}
}
#endif
