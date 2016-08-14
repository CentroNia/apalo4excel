#
# libconnectionpool Makefile
#
# Copyright (C) 2008
# Dragan Simic <dragan.simic@jedox.com>
# Jedox AG, Freiburg, Germany
#

#
# Note: PALOINC gets used from the environment, if specified
#

ifneq "$(MAKECMDGOALS)" "clean"
PALOINC ?= ../libpalo_ng/source/include
# $(if $(PALOINC),,$(error PALOINC has to be specified))
endif

CXX     = g++
LIBRARY = libconnectionpool

SOURCES  = $(wildcard *.cpp)
OBJECTS  = $(subst .cpp,.o,$(SOURCES))
DEPFILES = $(subst .cpp,.d,$(SOURCES))
LIBDIR   ?= /usr/lib

ARCH      := $(shell _MAKE_ARCH=`uname -m`; if echo $$_MAKE_ARCH | egrep '^i[356]86$$' > /dev/null; then echo i386; else echo $$_MAKE_ARCH; fi)
ARCH_FLAG := $(if $(filter $(ARCH),i386),-m32,$(if $(filter $(ARCH),x86_64),-m64,))

override CXXFLAGS := $(ARCH_FLAG) -D__UNIX__ -g -fPIC $(CXXFLAGS)
override LDFLAGS  := $(ARCH_FLAG) -g -fPIC -lpalo_ng $(LDFLAGS)
override INCLUDES := $(INCLUDES) -I. -Iinclude $(if $(PALOINC),-I$(PALOINC),)

vpath %.h ./include $(PALOINC)

all: $(LIBRARY)

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

install: $(LIBRARY)
	cp $(LIBRARY).a $(LIBDIR)
	cp $(LIBRARY).so $(LIBDIR)

.PHONY: all clean install

ifneq "$(MAKECMDGOALS)" "clean"
-include $(DEPFILES)
endif
