
# libPaloSpreadsheetFuncs Makefile
#
# Copyright (C) 2008-2012
# Dragan Simic <dragan.simic@jedox.com>
# Jedox AG, Freiburg, Germany
#

#
# Note: PALOINC, PALOLIB, BOOSTINC and BOOSTLIB
#       get used from the environment, if specified
#

ifneq "$(MAKECMDGOALS)" "clean"
LIBDIR=/usr/lib
OPENSSLINC ?= /usr/include
PALOINC ?= ../libpalo_ng/source/include
LIBCPOOLINC ?= ../libconnectionpool/include
endif

CXX     = g++
LIBRARY = libPaloSpreadsheetFuncs

SOURCES  =$(filter-out DocInitializer.h.cpp,$(wildcard *.cpp))
OBJECTS  =$(subst .cpp,.o,$(SOURCES))
DEPFILES =$(subst .cpp,.d,$(SOURCES))

ARCH      :=$(shell _MAKE_ARCH=`uname -m`; if echo $$_MAKE_ARCH | egrep '^i[356]86$$' > /dev/null; then echo i386; else echo $$_MAKE_ARCH; fi)
ARCH_FLAG :=$(if $(filter $(ARCH),i386),-m32,$(if $(filter $(ARCH),x86_64),-m64,))

override CXXFLAGS :=$(ARCH_FLAG) -D__UNIX__ -g -fPIC $(CXXFLAGS)
override LDFLAGS  :=$(ARCH_FLAG) -g -fPIC -lconnectionpool -lpalo_ng -licui18n -licudata -licuuc $(LDFLAGS) $(if $(PALOLIB),-L$(PALOLIB),) $(if $(BOOSTLIB),-L$(BOOSTLIB),) $(if $(ICULIB),-L$(ICULIB),) -L$(LIBCPOOLLIB)  -L/lib -L/usr/lib
override INCLUDES :=$(INCLUDES) -I. -Iinclude -I$(OPENSSLINC) -I$(LIBCPOOLINC) -I$(PALOINC) $(if $(BOOSTINC),-I$(BOOSTINC),) $(if $(ICUINC),-I$(ICUINC),)


vpath %.h ./include $(PALOINC) $(LIBCPOOLINC)

all: $(LIBRARY)

install: $(LIBRARY)
	cp $(LIBRARY).a $(LIBDIR)
	cp $(LIBRARY).so $(LIBDIR)

$(LIBRARY): $(OBJECTS)
	$(CXX) $(OBJECTS) $(LDFLAGS) -shared -o $@.so 
	$(AR) rcs $(LIBRARY).a *.o
	ranlib $(LIBRARY).a

%.o: %.cpp
	$(CXX) $(CXXFLAGS) $(INCLUDES) -c $< -o $@

%.d: %.cpp
	@set -e; $(RM) $@; \
	$(CXX) -M -MG $(CXXFLAGS) $(INCLUDES) $< > $@.$$$$; \
	sed 's,\($*\)\.o[ :]*,\1.o $@ : ,g' < $@.$$$$ > $@; \
	$(RM) $@.$$$$

clean:
	$(RM) *.o *.d $(LIBRARY).so $(LIBRARY).a

.PHONY: all clean

ifneq "$(MAKECMDGOALS)" "clean"
-include $(DEPFILES)
endif
