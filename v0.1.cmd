@echo off
set minecraft="C:\minecraft.exe"

setlocal enabledelayedexpansion
Powershell -command "&{Get-WmiObject -Query 'Select * from Win32_OperatingSystem' | Select FreePhysicalMemory | Format-Table -AutoSize;}" > temp.txt
for /f "tokens=* delims= " %%a in (temp.txt) do ( set mem=%%a )
set mem=!mem:~0,-1!
del temp.txt /Q

if %mem% LSS 262144 ( echo Less than 256MB free memory.
set /P user="Run anyway? (Y/N) " ) 
if %mem% GEQ 262144 ( echo How much memory to allocate to Minecraft?
if %mem% LSS 1048576 ( echo A. 256MB
if %mem% GEQ 524288 ( echo B. 512MB )
set /P user="Enter letter: " )
if %mem% GEQ 1048576 ( 
set /A blarg=%mem%/1048576
echo Available: !blarg! GB
set /P user="In GB: " ) )

if %user% == "Y" ( javaw -jar %minecraft% 
goto skip)
if %user% == "N" ( exit )
if %user% == "A" ( javaw -Xmx256m -Xms256m -jar %minecraft% 
goto skip)
if %user% == "B" ( javaw -Xmx512m -Xms512m -jar %minecraft% 
goto skip)
set /A user=%user%*1
set /A mib=%user%*1024
javaw -Xmx%mib%m -Xms%mib%m -jar %minecraft% 

:skip