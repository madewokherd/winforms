
RESX2SR=mono $(WINE_MONO_SRCDIR)/mono/mcs/class/lib/build-linux/resx2sr.exe

COMPILE_LIB=csc -target:library

LIB_FLAGS=-unsafe -delaysign+ -keyfile:../../ecma.pub -define:DRAWING_DESIGN_NAMESPACE -define:WINDOWS_FORMS_SWITCHES -define:WIN95_SUPPORT -define:OPTIMIZED_MEASUREMENTDC -langversion:7.3 -nowarn:CS0436 -nowarn:CS0618 -nostdlib -noconfig -lib:$(MONO_PREFIX)/lib/mono/4.5-api

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
	for i in `cat embeddedresources.list`; do printf -- '-resource:Resources/%s,%s\n' $$i `echo $$i|sed "s:/PropertyGrid/EventsTab:.Design.EventsTab:g"|sed "s:/PropertyGrid/PropertiesTab:.PropertyGridInternal.PropertiesTab:g"|sed "s:-Temporary::g"|sed "s:/PropertyGrid/:/:g"|sed "s:/Printing/:/:g"|sed "s:/ToolStripPanel.ico:/ToolStripPanel_standalone:g"|sed "s:/App/:/:g"|sed "s:/ToolStrip/:/:g"|sed "s:/ToolStripMenuItem.ico:.ToolStripMenuItem:g"|sed "s:/BlankToolstrip.ico:/blank:g"|sed "s:/SendToBackHS.ico:/sendToBack:g"|sed "s:/BringToFrontHS.ico:/bringToFront:g"|sed "s:/AlignToGridHS.ico:/alignToGrid:g"|sed "s:ToolStripMenuItem.ico::gi"|sed "s:\\.ico$$::g"|sed "s:/:.:g"`; done > $@ || rm -f $@

System.Windows.Forms.dll: sources.list $(LIB_SRCS) $(SIBLING_PATHS) embeddedresources.flags $(EMBEDDED_RES_PATHS)
	$(COMPILE_LIB) $(LIB_FLAGS) $(LIB_REFS) $(SIBLING_REFS) -out:$@ @sources.list @embeddedresources.flags
	sn -R $@ ../../mono.snk
