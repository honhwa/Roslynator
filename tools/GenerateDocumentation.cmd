@echo off

"C:\Program Files\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild" "..\src\Roslynator.sln" ^
 /t:Clean,Build ^
 /p:Configuration=ReleaseDoc,TreatWarningsAsErrors=true,WarningsNotAsErrors="1591" ^
 /v:normal ^
 /m

if errorlevel 1 (
 pause
 exit
)

copy "E:\Dokumenty\Visual Studio 2017\Projects\Roslynator\src\Documentation.Build\bin\Release\publish\net46" "C:\Users\Jojo\.nuget\packages\roslynator.documentation.build\0.1.0-beta\tools\net46" /Y
copy "E:\Dokumenty\Visual Studio 2017\Projects\Roslynator\src\Documentation.Build\bin\Release\publish\netcoreapp1.0" "C:\Users\Jojo\.nuget\packages\roslynator.documentation.build\0.1.0-beta\tools\netcoreapp1.0" /Y

"C:\Program Files\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild" "..\src\Roslynator.sln" ^
 /t:Clean,Build ^
 /p:Configuration=ReleaseDocGen,RunCodeAnalysis=false,TreatWarningsAsErrors=false,WarningsNotAsErrors="1591" ^
 /v:normal ^
 /m

if errorlevel 1 (
 pause
 exit
)

echo OK
pause
