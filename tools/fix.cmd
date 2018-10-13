@echo off

"..\src\CommandLine\bin\Debug\net461\roslynator" fix "..\src\Roslynator.sln" ^
 -p TreatWarningsAsErrors=false ^
 -a "analyzers" ^
 --ignore-analyzer-references ^
 --ignore-compiler-errors ^
 --batch-size 2000

echo OK
pause
