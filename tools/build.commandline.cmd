@echo off

rem dotnet restore "..\src\CommandLine.sln"

"C:\Program Files\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild" "..\src\CommandLine.sln" ^
 /t:Clean,Build ^
 /p:Configuration=Release,TreatWarningsAsErrors=true,WarningsNotAsErrors="1591" ^
 /v:normal ^
 /m

if errorlevel 1 (
 pause
 exit
)

dotnet pack -c Release --no-build -v normal "..\src\CommandLine\CommandLine.csproj"

copy "..\src\CommandLine\bin\Release\Roslynator.CommandLine.0.1.0-beta.nupkg" "E:\Dokumenty\LocalNuGet"

rd /S /Q "C:\Users\Jojo\.nuget\packages\roslynator.commandline" 

echo OK
pause
