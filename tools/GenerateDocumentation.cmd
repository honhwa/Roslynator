@echo off

build.documentation.cmd

"C:\Program Files\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild" "..\src\Documentation.sln" ^
 /t:Build ^
 /p:Configuration=ReleaseDoc,RunCodeAnalysis=false,TreatWarningsAsErrors=false,WarningsNotAsErrors="1591" ^
 /v:normal ^
 /m

if errorlevel 1 (
 pause
 exit
)

echo OK
pause