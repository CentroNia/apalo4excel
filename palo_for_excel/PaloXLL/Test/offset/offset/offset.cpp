// offset.cpp : Defines the entry point for the console application.
//

#include <iostream>

#include "XLCellRange.h"
#include "XLTypes.h"

using namespace Palo::XLL;

int main(int argc, char* argv[])
{
	XLCellRange<Excel12Types>::getCallerID();

	std::cout << "press return";
	getc(stdin);

	return 0;
}

