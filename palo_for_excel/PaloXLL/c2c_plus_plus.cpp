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
////////////////////////////////////////////////////////////////////////////////

//  Additional Revisions to Palo (c) Junction BI LLC:
//  JMM 09-20-13 For 5.0 library compatability

#include <PaloSpreadsheetFuncs/SpreadsheetFuncsBase.h>
// JMM 09-30-13
#ifdef NOTUSED
#include "PHPPaloLogger.h"
#endif

#include "c2c_plus_plus.h"

extern "C" void ChangeToNewStartIndex(void) {
	Palo::SpreadsheetFuncs::SpreadsheetFuncsBase::ChangeToNewStartIndex();
};

extern "C" void PHPInitSSL(const char * trustfile) {
	Palo::SpreadsheetFuncs::SpreadsheetFuncsBase::InitSSL((trustfile==NULL) ? std::string(): std::string(trustfile));
};

// JMM 09-30-13
#ifdef NOTUSED
extern "C" void InternalPaloWeb(long value) {
	Palo::PHPPalo::PHPPaloLogger::InternalPaloWeb(value);
};

extern "C" void ActivateLogStderr(long value) {
	Palo::PHPPalo::PHPPaloLogger::ActivateLogStderr(value);
};
#endif

extern "C" long GetGoalSeekType(PHPPaloGoalSeekType type) {
	switch (type) {
		case PHPPalo_GOALSEEK_COMPLETE:
			return Palo::Types::GoalSeekComplete;

		case PHPPalo_GOALSEEK_EQUAL:
			return Palo::Types::GoalSeekEqual;

		case PHPPalo_GOALSEEK_RELATIVE:
			return Palo::Types::GoalSeekRelative;

		default:
			return -1;
	}
};

