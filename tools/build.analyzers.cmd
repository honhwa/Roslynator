@echo off

"C:\Program Files\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild" "..\src\Analyzers.sln" ^
 /t:Clean,Build ^
 /p:Configuration=Release,TreatWarningsAsErrors=true,WarningsNotAsErrors=1591 ^
 /v:minimal ^
 /m

if errorlevel 1 (
 pause
 exit
)

rem dotnet test -c Release --no-build "..\src\Tests\Analyzers.Tests\Analyzers.Tests.csproj"

if errorlevel 1 (
 pause
 exit
)

dotnet pack -c Release --no-build -v normal "..\src\Analyzers.CodeFixes\Analyzers.CodeFixes.csproj"

echo OK
pause
