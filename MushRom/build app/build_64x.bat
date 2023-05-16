@echo off
setlocal

set "folderPath=C:\Desktop\coding\MushRom"
set "extensions=.html .json .cs"

for %%x in (%extensions%) do (
    for %%f in ("%folderPath%\*%%x") do (
        echo Compiling: %%f
        cmd.exe /c "%%f"
        echo Compiled: %%f
    )
)

endlocal
