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

#include <wchar.h>
#include <windows.h>
#include <stdio.h>
#include <ctype.h>
#include <stdarg.h>

#include "CTypes.h"
#include "strdupf.h"
#include "xl.h"
#include "base64.h"
#include "math.h"
#ifndef __XLL_VERSION_4
#include "unicode_win.h"
#endif

int get_xl_args(unsigned int num_args, ...)
{
	va_list l;
	unsigned int i, *len;
	short int *is_vertical;
	int type;

	LPXLOPER xl_oper=NULL;
	double *to_double=NULL;
	char ***to_string_array=NULL;
	char **to_string=NULL;
	int *to_int=NULL;
	short int *to_short=NULL;

	va_start(l, num_args);
	for(i=0;i<num_args;i++) {
		type=va_arg(l, int);
		xl_oper=va_arg(l, LPXLOPER);
		switch(type) {
			case XL_ARG_STRING:
				to_string=va_arg(l, char**);
				*to_string=get_string(xl_oper);
				if(*to_string==NULL) {
					goto cleanup;
				}
				break;
			case XL_ARG_DOUBLE:
				to_double=va_arg(l, double*);
				if(get_double(xl_oper, to_double, 0, 1)!=XL_SUCCESS){
					goto cleanup;
				}
				break;
			case XL_ARG_INT:
				to_int=va_arg(l, int*);
				if(get_int(xl_oper, to_int)!=XL_SUCCESS) {
					goto cleanup;
				}
				break;
			case XL_ARG_STRING_ARRAY:
				len=va_arg(l, unsigned int*);
				is_vertical=va_arg(l, short int*);
				to_string_array=va_arg(l, char***);
				*to_string_array=get_string_array(len, is_vertical, xl_oper);
				if(*to_string_array==NULL) {
					goto cleanup;
				}
				break;
			case XL_ARG_BOOL:
				to_short=va_arg(l, short int *);
				if(get_bool(xl_oper, to_short)!=XL_SUCCESS) {
					goto cleanup;
				}
				break;
			default:
				goto cleanup;
				return XL_FAILURE;
		}
	}
	va_end(l);
	return XL_SUCCESS;

cleanup:
	va_end(l);
	va_start(l, num_args);
	for(num_args=0;num_args<i;num_args++) {
		type=va_arg(l, int);
		xl_oper=va_arg(l, LPXLOPER);
		switch(type) {
			case XL_ARG_STRING:
				to_string=va_arg(l, char**);
				if(*to_string!=NULL) {
					free(*to_string);
				    *to_string = NULL;
				}
				break;
			case XL_ARG_INT:
				to_int=va_arg(l, int*);
				break;
			case XL_ARG_DOUBLE:
				to_double=va_arg(l, double*);
				break;
		}
	}
	va_end(l);
	return XL_FAILURE;
}


XLOPER TempStr_noalloc(LPSTR str, void (*free_func)(void *))
{
	XLOPER oper;
	size_t tempcount;
#ifdef __XLL_VERSION_4
	char *t;
	BYTE count;
#else
	wchar_t count;
	wchar_t *w;
	unicode_win_err err;
#endif

#ifdef __XLL_VERSION_4
	t=str;
	str=strdup(t);
	if(free_func!=NULL) {
		free_func(t);
	}
	if(str==NULL) {
		oper.xltype=xltypeErr;
		oper.val.err=xlerrValue;
		return oper;
	}	
	tempcount=strlen(str);
	count=(tempcount>255 ? (BYTE)255:((BYTE)tempcount));
	memmove(str+1, str, count*sizeof(char));
	str[0]=count;
	oper.xltype=xltypeStr;
	oper.val.str=str;
#else
	err = utf82wcs(&w, str);
	if(free_func!=NULL) {
		free_func(str);
	}
	if(err != UNICODE_WIN_SUCCESS) {
		oper.xltype=xltypeErr;
		oper.val.err=xlerrValue;
		return oper;
	}
	tempcount=wcslen(w);
	count=(tempcount > 65535 ? (wchar_t)65535:((wchar_t)tempcount));
	memmove(w+1, w, count*sizeof(wchar_t));
	w[0]=count;
	oper.xltype=xltypeStr;
	oper.val.str=w;
#endif
	return oper;
}

LPXLOPER TempStr(LPSTR str, void (*free_func)(void *), int dll_free)
{
	LPXLOPER oper;

	oper=(LPXLOPER)malloc(sizeof(XLOPER));
	if (oper==NULL) {
		return NULL;
	}

	*oper=TempStr_noalloc(str, free_func);

	if (dll_free!=0) {
		oper->xltype|=xlbitDLLFree;
	}

	return oper;
}

LPXLOPER TempNum(double d)
{
	LPXLOPER oper;

	oper=(LPXLOPER)malloc(sizeof(XLOPER));
	if(oper==NULL) {
		return NULL;
	}

	oper->xltype=xltypeNum;
	oper->val.num=d;

	oper->xltype|=xlbitDLLFree;

	return oper;
}

LPXLOPER TempInt(int i)
{
	LPXLOPER oper;

	oper=(LPXLOPER)malloc(sizeof(XLOPER));
	if(oper==NULL) {
		return NULL;
	}

	oper->xltype=xltypeInt;
	oper->val.w=i;

	oper->xltype|=xlbitDLLFree;

	return oper;
}

LPXLOPER TempBool(int i)
{
	LPXLOPER oper;

	oper=(LPXLOPER)malloc(sizeof(XLOPER));
	if(oper==NULL) {
		return NULL;
	}

	oper->xltype=xltypeBool;
#ifdef __XLL_VERSION_4
	oper->val.bool=i;
#else
	oper->val.xbool=i;
#endif

	oper->xltype|=xlbitDLLFree;

	return oper;
}

LPXLOPER TempErr(int err)
{
	LPXLOPER oper;

	oper=(LPXLOPER)malloc(sizeof(XLOPER));
	if(oper==NULL) {
		return NULL;
	}

	oper->xltype=xltypeErr;
	oper->val.err=err;

	oper->xltype|=xlbitDLLFree;

	return oper;
}

char **get_string_array(unsigned int *len, short int *is_vertical, LPXLOPER oper)
{
	char **a=NULL;
	unsigned int i=0;
	XLOPER temp;

	switch(oper->xltype) {
		case xltypeSRef:
		case xltypeRef:
			if(Excel4(xlCoerce, &temp, 1, oper) != xlretSuccess) {
				return NULL;
			}
			a=get_string_array(len, is_vertical, &temp);
			Excel4(xlFree, 0, 1, &temp);
			return a;
		case xltypeMulti:
			if(oper->val.array.rows==1) {
				*is_vertical=0;
				*len=oper->val.array.columns;
			} else if(oper->val.array.columns==1) {
				*is_vertical=1;
				*len=oper->val.array.rows;
			} else {
				return NULL;
			}
			a=(char**)calloc(*len, sizeof(char*));
			if(a==NULL) {
				return NULL;
			}
			for(i=0;i<*len;i++) {
				a[i]=get_string(oper->val.array.lparray+i);
				if(a[i]==NULL) {
					for(i=0;i<*len;i++) {
						if(a[i]!=NULL) {
							free(a[i]);
						}
					}
					free(a);
					return NULL;
				}
			}
			return a;
			break;
		default:
			*len=1;
			a=(char**)malloc(sizeof(char*));
			if(a==NULL) {
				return NULL;
			}
			a[0]=get_string(oper);
			if(a[0]==NULL) {
				free(a);
				return NULL;
			} else {
				return a;
			}
	}
}

char *remove_trailing0s(char *in) {
	size_t i;

	if (strchr(in, '.') == NULL) {
		return in;
	}

	i = strlen(in) -1;

	while ((i >=0) && (in[i]== '0')) {
		i--;
	}

	i++;

	in = realloc(in, (i+1) * sizeof(char));

	in[i]='\0';

	return in;
}

char *get_string_direct( LPXLOPER oper, size_t *length, short int *must_free )
{
	XLOPER temp;
	char *s=NULL;
#ifndef __XLL_VERSION_4
	unicode_win_err err;
#endif

	*must_free = 0;

	switch(oper->xltype) {
		case xltypeStr:
			*length = (unsigned char)oper->val.str[0];
#ifdef __XLL_VERSION_4
			return oper->val.str+1;
#else
			err = wcs2utf8(&s, oper->val.str+1, *length);
			if(err != UNICODE_WIN_SUCCESS) {
				return NULL;
			}
			*must_free = 1;
			*length = strlen(s);
			return s;
#endif
		case xltypeSRef:
		case xltypeRef:
			if(Excel4(xlCoerce,&temp,1,oper) != xlretSuccess) {
				return NULL;
			}
			s = get_string_direct(&temp, length, must_free);
			Excel4(xlFree, 0, 1, &temp);
			return s;
		case xltypeNum:
			if(floor(oper->val.num)==oper->val.num) {
				s = strdupf("%.f", oper->val.num);
			} else {
				s = remove_trailing0s(strdupf("%.14f", oper->val.num));
			}
		case xltypeInt:
			s = strdupf("%d", oper->val.w);
		case xltypeNil:
			s = strdup("");
		case xltypeMulti:
		case xltypeMissing:
		case xltypeFlow:
		case xltypeBigData:
		case xltypeErr:
		case xltypeBool:
		default:
			return NULL;
	}

	if(s != NULL) {
		*must_free = 1;
		*length = strlen(s);
	}
	return s;
}

char *get_string(LPXLOPER oper)
{
	size_t length;
	short int must_free;
	char *s, *t;

	s = get_string_direct(oper, &length, &must_free);
	if(!must_free) {
		t = malloc((length + 1)*sizeof(char));
		if(t == NULL) {
			return t;
		}

		strncpy(t, s, length);
		t[length] = '\0';

		s = t;
	}

	return s;
}

int get_int(LPXLOPER oper, int *n)
{
	XLOPER temp;
	int i=0;
	switch(oper->xltype) {
		case xltypeInt:
			*n=oper->val.w;
			return XL_SUCCESS;
		case xltypeNum:
			/* TODO: check this */
			if(oper->val.num-((int)oper->val.num)==0.0) {
				*n=(int)oper->val.num;
				return XL_SUCCESS;
			}
			return XL_FAILURE;
		case xltypeSRef:
		case xltypeRef:
			if(Excel4(xlCoerce,&temp,1,oper) != xlretSuccess) {
				return XL_FAILURE;
			}
			i=get_int(&temp,n);
			Excel4(xlFree,0,1,&temp);
			if(i!=XL_SUCCESS) {
				return XL_FAILURE;
			}
			return XL_SUCCESS;
		case xltypeStr:
		case xltypeMulti:
		case xltypeNil:
		case xltypeMissing:
		case xltypeFlow:
		case xltypeBigData:
		case xltypeErr:
		case xltypeBool:
		default:
			return XL_FAILURE;
	}
}

int get_bool(LPXLOPER oper, short int *n)
{
	XLOPER temp;
	int i=0;
	switch(oper->xltype) {
		case xltypeBool:
#ifdef __XLL_VERSION_4
			*n=oper->val.bool;
#else
			*n=oper->val.xbool;
#endif
			return XL_SUCCESS;
			break;
		case xltypeSRef:
		case xltypeRef:
			if(Excel4(xlCoerce,&temp,1,oper) != xlretSuccess) {
				return XL_FAILURE;
			}
			i=get_bool(&temp,n);
			Excel4(xlFree,0,1,&temp);
			if(i!=XL_SUCCESS) {
				return XL_FAILURE;
			}
			return XL_SUCCESS;
		case xltypeStr:
		case xltypeMulti:
		case xltypeNil:
		case xltypeMissing:
		case xltypeFlow:
		case xltypeBigData:
		case xltypeErr:
		case xltypeInt:
		case xltypeNum:
		default:
			return XL_FAILURE;
	}
}

int get_double(LPXLOPER oper, double *d, short int get_upper_left, short int from_str)
{
	XLOPER temp;
	int i=0;
	switch(oper->xltype) {
		case xltypeInt:
			*d=(double)oper->val.w;
			return XL_SUCCESS;
		case xltypeNum:
			*d=oper->val.num;
			return XL_SUCCESS;
		case xltypeMulti:
			if(get_upper_left!=0) {
				return get_double(oper->val.array.lparray, d, 0, from_str);
			} else {
				return XL_FAILURE;
			}
		case xltypeStr:
			if(from_str!=0) {
				if(Excel4(xlCoerce, &temp, 2, oper, TempInt(xltypeNum)) != xlretSuccess) {
					return XL_FAILURE;
				}
				i=get_double(&temp, d, get_upper_left, from_str);
				Excel4(xlFree, 0, 1, &temp);
				if(i!=XL_SUCCESS) {
					return XL_FAILURE;
				}
				return XL_SUCCESS;
			} else {
				return XL_FAILURE;
			}
		case xltypeSRef:
		case xltypeRef:
			if(Excel4(xlCoerce, &temp, 1, oper) != xlretSuccess) {
				return XL_FAILURE;
			}
			i=get_double(&temp, d, get_upper_left, from_str);
			Excel4(xlFree, 0, 1, &temp);
			if(i!=XL_SUCCESS) {
				return XL_FAILURE;
			}
			return XL_SUCCESS;
		case xltypeNil:
//			*d=0.0;
//			return XL_SUCCESS;
			return XL_FAILURE;
		case xltypeMissing:
		case xltypeFlow:
		case xltypeBigData:
		case xltypeErr:
		case xltypeBool:
		default:
			return XL_FAILURE;
	}
}

char *create_cleartext_key_current()
{
	XLOPER xCaller;
	char *key;

	if(Excel4(xlfCaller, (LPXLOPER)&xCaller, 0)!=xlretSuccess || xCaller.xltype==xltypeErr) {
		return NULL;
	}

	key=create_cleartext_key((LPXLOPER)&xCaller);

	Excel4(xlFree, NULL, 1, (LPXLOPER)&xCaller);

	return key;
}

char *create_cleartext_key(LPXLOPER xCaller)
{
	char *name=NULL, *result=NULL, *cell;
	size_t len=0;

	// get
	name=get_book_sheet(xCaller, 1);
	if(name==NULL) {
		return NULL;
	}
	cell=get_cell(xCaller);
	if(cell==NULL) {
		free(name);
		return NULL;
	}

	// generate string
	len=_scprintf("%s:%s", name, cell);
	result=(char*)malloc((len+1)*sizeof(char));
	if(result==NULL) {
		free(name);
		free(cell);
		return NULL;
	}
	sprintf(result,"%s:%s", name, cell);
	free(name);
	free(cell);

	return result;
}

char *create_data_key(char *prefix)
{
	char *name=NULL, *result=NULL;
	int len=0;

	result=create_cleartext_key_current();
	if(result==NULL) {
		return NULL;
	}

	// Base64
	len=base64_encode_get_length(strlen(result));
	name=(char*)malloc((len+1)*sizeof(char));
	if(name==NULL) {
		free(result);
		return NULL;
	}
	if(base64_encode(result, strlen(result), name, &len)==FALSE) {
		free(result);
		free(name);
		return NULL;
	}
	free(result);
	name[len]='\0'; // termination

	// prefix
	len=_scprintf("%s|%s", prefix, name);
	result=(char*)malloc((len+1)*sizeof(char));
	if(result==NULL) {
		free(name);
		return NULL;
	}
	sprintf(result,"%s|%s", prefix, name);
	free(name);

	return result;
}

char *get_book_sheet(LPXLOPER xCaller, short int current)
{
	XLOPER xRes;
	char *name=NULL;
	IDSHEET oldsheetid = 0;
	int retcode = xlretSuccess;

	if ((current != 0) && (xCaller->xltype == xltypeRef)) {
		oldsheetid = xCaller->val.mref.idSheet;
		// we only need name of current sheet
		// will also avoid the corrupt message wich will happen in some case otherwise

		xCaller->val.mref.idSheet = 0;
	}

	// Caller / SheetName [Book]Sheet
	retcode = Excel4(xlSheetNm,(LPXLOPER)&xRes,1,xCaller);

	if ((current != 0) && (xCaller->xltype == xltypeRef)) {
		xCaller->val.mref.idSheet = oldsheetid;
	}

	// Caller / SheetName [Book]Sheet
	if (retcode!=xlretSuccess) {
		return NULL;
	}

	name=get_string((LPXLOPER)&xRes);
	Excel4(xlFree,NULL,1,(LPXLOPER)&xRes);

	return name;
}

char *get_sheet(LPXLOPER xCaller)
{
	int count=0, i=0;
	char *result=NULL, *name=get_book_sheet(xCaller, 1);
	if (name==NULL) {
		return NULL;
	}

	// strip leading [Book1]
	while(count!=0||i==0) {
		if(name[i]=='[') {
			count++;
		}
		if(name[i]==']') {
			count--;
		}
		i++;
	}

	result=strdup(name+i);
	free(name);

	return result;
}

char *get_book(LPXLOPER xCaller)
{
	int count=0, i=0;
	char *result=NULL, *name=get_book_sheet(xCaller, 1);
	if(name==NULL) {
		return NULL;
	}

	// strip leading [Book1]
	while(count!=0||i==0) {
		if(name[i]=='[') {
			count++;
		}
		if(name[i]==']') {
			count--;
		}
		i++;
	}

	name[--i]='\0';

	result=strdup(name+1);
	free(name);

	return result;
}

char *get_cell(LPXLOPER xCaller)
{
	char *result=NULL, *t=NULL;
	size_t len=0;

	// Caller-Coordinates
	if(xCaller->xltype!=xltypeSRef) {
		return NULL;
	}
	/* if(xCaller->val.sref.count!=1)
		return NULL; */

	// create string
	len=_scprintf("%d%d", xCaller->val.sref.ref.rwFirst+1, xCaller->val.sref.ref.rwLast+1);
	result=(char*)malloc((len+6)*sizeof(char));
	if(result==NULL) {
		return NULL;
	}
	t=result;
	if(xCaller->val.sref.ref.colFirst/26>0) {
		*(t++)=xCaller->val.sref.ref.colFirst/26+'A'-1;
	}
	*(t++)=xCaller->val.sref.ref.colFirst%26+'A';
	*t='\0';
	sprintf(t, "%d", xCaller->val.sref.ref.rwFirst+1);
	t=t+strlen(t);
	*(t++)=':';
	*t='\0';
	if(xCaller->val.sref.ref.colLast/26>0) {
		*(t++)=xCaller->val.sref.ref.colLast/26+'A'-1;
	}
	*(t++)=xCaller->val.sref.ref.colLast%26+'A';
	sprintf(t, "%d", xCaller->val.sref.ref.rwLast+1);

	return result;
}

