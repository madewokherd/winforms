
RESX2SR=mono $(WINE_MONO_SRCDIR)/mono/mcs/class/lib/build-linux/resx2sr.exe

COMPILE_LIB=csc -target:library

LIB_FLAGS=-unsafe -delaysign+ -keyfile:../../ecma.pub -define:DRAWING_DESIGN_NAMESPACE -define:WINDOWS_FORMS_SWITCHES -define:WIN95_SUPPORT -define:OPTIMIZED_MEASUREMENTDC -langversion:7.2 -nowarn:CS0436 -nostdlib -noconfig -lib:$(WINE_MONO_BUILDDIR)/build-cross-cli-install/lib/mono/4.5-api

LIB_REFS=-r:mscorlib.dll -r:System.dll -r:System.Configuration.dll -r:System.Core.dll -r:System.Drawing.dll -r:System.Xml.dll

SIBLING_LIBS=Accessibility

SIBLING_PATHS=$(foreach lib,$(SIBLING_LIBS),../../$(lib)/src/$(lib).dll)

SIBLING_REFS=$(foreach lib,$(SIBLING_LIBS),-r:../../$(lib)/src/$(lib).dll)

LIB_SRCS=$(shell cat sources.list)

all: System.Windows.Forms.dll

SR.resources.cs: Resources/SR.resx
	$(RESX2SR) $< > $@ || rm -f $@

%.resources: %.resx
	resgen $< $@

EMBEDDED_RESOURCES=$(shell cat embeddedresources.list)

EMBEDDED_RES_PATHS=$(foreach f,$(EMBEDDED_RESOURCES),Resources/$(f))

embeddedresources.flags: embeddedresources.list
	for i in `cat embeddedresources.list`; do printf -- '-resource:Resources/%s,%s\n' $$i `echo $$i|sed 's:/:.:g'`; done > $@ || rm -f $@

System.Windows.Forms.dll: sources.list $(LIB_SRCS) $(SIBLING_PATHS) embeddedresources.flags $(EMBEDDED_RES_PATHS)
	$(COMPILE_LIB) $(LIB_FLAGS) $(LIB_REFS) $(SIBLING_REFS) -out:$@ @sources.list @embeddedresources.flags
