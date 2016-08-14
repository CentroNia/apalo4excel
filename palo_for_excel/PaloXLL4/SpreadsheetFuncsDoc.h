////////////////////////////////////////////////////////////////////////////////
/// @brief
///
/// @file
///
/// Copyright (C) 2006-2012 Jedox AG
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

#ifndef SPREADSHEETFUNCS_DOC
#define SPREADSHEETFUNCS_DOC

#include <string>
#include <memory>
#include <map>

#include <PaloSpreadsheetFuncs/GenericCell.h>

#include <PaloSpreadsheetFuncs/GenericContext.h>

#include <PaloSpreadsheetFuncs/GenericArgumentArray.h>

namespace Palo {
	namespace SpreadsheetFuncs {
		class SpreadsheetFuncs;

		class LocalizedString : public std::map<std::string, std::wstring> {
		public:
			LocalizedString();
			~LocalizedString();

			const std::wstring& operator []( const std::string& key ) const;
			std::wstring& operator []( const std::string& key );
		};

		struct ArgumentDocumentation {
			ArgumentDocumentation();
			~ArgumentDocumentation();

			typedef GenericCell::Type Type;

			static Type getType( const std::string& s ) {
				if ( s == "string" )
					return GenericCell::TString;
				else if ( s == "int" )
					return GenericCell::TInt;
				else if ( s == "CellValue" )
					return GenericCell::TCellValue;
				else if ( s == "double" )
					return GenericCell::TDouble;
				else if ( s == "bool" )
					return GenericCell::TBool;
				else
					throw InvalidRequestException( CurrentSourceLocation );
			}

			Type type;
			std::string name;

			LocalizedString short_desc;
			LocalizedString long_desc;

			bool repeat;
		};

		struct PrototypeDocumentation {
			PrototypeDocumentation();
			~PrototypeDocumentation();

			typedef std::vector<std::string> ArgKeys;
			ArgKeys arg_keys;
		};

		struct XLFunctionDocumentation {
			XLFunctionDocumentation();
			~XLFunctionDocumentation();

			bool is_xl_function;

			std::string xl_name;
			short int xl_func_type;
			bool xl_special;
			bool xl_volatile;
		};

		struct FunctionDocumentation {
			FunctionDocumentation();
			~FunctionDocumentation();

			std::string name;
			std::string c_name;

			XLFunctionDocumentation xl_doc;

			LocalizedString short_desc;
			LocalizedString long_desc;

			typedef std::vector<PrototypeDocumentation> PrototypeList;
			PrototypeList prototypes;

			typedef std::map<std::string, ArgumentDocumentation> ArgumentPool;
			ArgumentPool arg_pool;

			bool containsRepeatingArg() const;
			const PrototypeDocumentation& getLongestPrototype() const;
		};

		class Documentation {
		public:
			Documentation();
			~Documentation();

			static const Documentation& getInstance() {
				static Documentation doc;
				return doc;
			}

			std::vector<FunctionDocumentation> functions;
		};

		// the following classes are not being used yet

		class FuncData {
		public:
			FuncData() {}
			virtual ~FuncData() {}

			void setDoc( Documentation* doc ) {
				this->doc.reset( doc	);
			}

			const Documentation& getDoc() const {
				return *doc;
			}

			virtual void operator()( SpreadsheetFuncs* base, GenericCell& retval, GenericContext& opts, GenericArgumentArray& arg ) = 0;

		protected:
			std::unique_ptr<Documentation> doc;
		};

		template<class Base, const FuncData* SpreadsheetFuncs::* func>
		class FuncImplementation : public FuncData {};

		template<typename func_ptr_t, func_ptr_t func_ptr, class base_type>
		class FuncDataBinding : public FuncImplementation<base_type, func_ptr> {};
	}
}
#endif
