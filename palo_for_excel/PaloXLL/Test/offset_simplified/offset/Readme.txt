- prerequisites:
In offset/SDK there must exists xlcall.h and xlcall.cpp from the Excel 2010 SDK.

- recreate Problem:
use either release or debug build of x64 (no problem with win32).
The exe prints out the value of two pointers which should be identical, but it isn't with x64.
The lines 159 and 168 of XLCellRange.cpp are the most important one.
Release|x64:
&range==this+0x10
Debug|x64:
this==&range+0xa0







