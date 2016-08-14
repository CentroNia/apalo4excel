@echo off
echo maketlb: Platform=%1 FileName=%2 Target=%3.tlb
if %1==x86 goto win32
"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\bin\NETFX 4.0 Tools\tlbexp" %2 /win64 /out:%3.tlb
goto done
:win32
"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\bin\NETFX 4.0 Tools\tlbexp" %2 /out:%3.tlb
:done


