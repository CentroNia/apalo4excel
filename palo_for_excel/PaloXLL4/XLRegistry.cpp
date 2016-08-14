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
 * Hendrik Schmieder <hendrik.schmieder@jedox.com>
 *
 */

#include <windows.h>

#include "XLRegistry.h"

#define mkstr2(s) # s
#define mkstr(s) mkstr2(s)

#define _CURRENT_USER Software\\Jedox\\Palo\\XlAddin
#define CURRENT_USER TEXT(mkstr(_CURRENT_USER))
#define ALL_USERS    TEXT(mkstr(.DEFAULT\\##_CURRENT_USER))


using namespace Palo::XLL;

const bool XLRegistry::bLogging = XLRegistry::DoLogging();
const bool XLRegistry::bDebug = XLRegistry::IsDebug();

std::string XLRegistry::getRegistryValue(unsigned short whichpath, char *keyname) {
	HKEY m_hkey; 
	DWORD dwType = REG_SZ;	
	DWORD dwSize = MAX_PATH;
	long rc = ERROR_SUCCESS;
	HKEY key = HKEY_CURRENT_USER;
	char *path = CURRENT_USER;
	wchar_t lpValue[MAX_PATH];

	if (whichpath != 0) {
		key = HKEY_USERS;
		path = ALL_USERS;
	}

	memset( &lpValue, 0, sizeof(lpValue) );
	
	RegOpenKeyEx(key, path, 0, KEY_READ, &m_hkey);
	rc = RegQueryValueEx(m_hkey, keyname, NULL, &dwType, (LPBYTE)&lpValue, &dwSize);
	RegCloseKey(m_hkey);

	return (rc == ERROR_SUCCESS) ? (char*)lpValue : "";
}


std::string XLRegistry::getRegistryValue(char * keyname) {
	// First look at Current user
	std::string val = getRegistryValue(0, keyname);
	return (!val.empty()) ? val : getRegistryValue(1, keyname);
}


std::string XLRegistry::getLanguage() {
	return getRegistryValue(TEXT("ActiveLanguage"));
}

std::string XLRegistry::getLogFilePath() {
	return getRegistryValue(TEXT("LogFilePath"));
}

bool XLRegistry::DoLogging() {
	std::string value(getRegistryValue(TEXT("XllLogging")));
	return (value.length() == 1) && (value[0] != '0');
}

bool XLRegistry::IsDebug() {
	std::string value(getRegistryValue(TEXT("DebugMode")));
	return (stricmp(value.c_str(), "true") == 0);
}


