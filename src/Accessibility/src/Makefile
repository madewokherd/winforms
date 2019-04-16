COMPILE_IL=ilasm /dll

all: Accessibility.dll

clean:
	rm -f Accessibility.dll

Accessibility.dll: references.h Accessibility.il
	$(COMPILE_IL) Accessibility.il /output:$@
	sn -R $@ ../../mono.snk
