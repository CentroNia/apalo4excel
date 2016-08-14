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

#include <ctime>
#include <ios>

#include "XLLCellLogger.h"
#include "XLRegistry.h"

#define MAX_TIME_SIZE 29

using namespace Palo::XLL;

XLLCellLogger::XLLCellLogger() {
	char delimeter = '\\';
	try {
		std::string logpath = XLRegistry::getLogFilePath();
	
		if (!logpath.empty() && (logpath[logpath.length()-1] != delimeter)) {
			logpath.push_back(delimeter);
		}

		m_log.swap(std::ofstream(logpath.append("PaloXLL.log"), std::ios_base::app));
	} catch(...) {
	}
}
	
XLLCellLogger::~XLLCellLogger() {
	try {
		m_log.close();
	} catch(...) {
	}
}


void XLLCellLogger::log( Type logtype, std::string msg, bool force_logging ) throw() {
	if (force_logging || XLRegistry::DoLogging()) {
		if (m_log.is_open()) {

			char buf[MAX_TIME_SIZE];
			time_t t = time(NULL);
			strftime(buf, MAX_TIME_SIZE, "[%a %b %d %H:%M:%S %Y] [", localtime(&t));

			m_log << buf;

			switch ( logtype ) {
				case AbstractLogger::LOG_ERROR:
					m_log << "Error";
					break;
				case AbstractLogger::LOG_WARNING:
					m_log << "Warning";
					break;
				case AbstractLogger::LOG_INFO:
					m_log << "info";
					break;
				default:
					m_log << "Unknow";
					break;
			}

			m_log << "] " << msg << std::endl;
		}
	}

}

