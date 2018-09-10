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

dotnet pack -c Release --no-build -v normal "..\src\Documentation\Documentation.csproj"
dotnet pack -c Release --no-build -v normal "..\src\Documentation.CommandLine\Documentation.CommandLine.csproj"

copy "..\src\Documentation\bin\Release\Roslynator.Documentation.0.1.0-beta.nupkg" "E:\Dokumenty\LocalNuGet"
copy "..\src\Documentation.CommandLine\bin\Release\Roslynator.Documentation.CommandLine.0.1.0-beta.nupkg" "E:\Dokumenty\LocalNuGet"

echo OK
pause
