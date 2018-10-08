@echo off

rem dotnet restore "..\src\FixAll.sln"

"C:\Program Files\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild" "..\src\FixAll.sln" ^
/t:Clean,Build ^
/p:Configuration=Debug,RunCodeAnalysis=false ^
/v:minimal /m

pause
