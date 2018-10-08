@echo off

set _solutionPath=

"..\src\CommandLine\bin\Debug\net461\roslynator" fix ^
 -s "%_solutionPath%" ^
 -p TreatWarningsAsErrors=false "CodeAnalysisRuleSet=E:\Dokumenty\Visual Studio 2017\Projects\Roslynator\src\CommandLine\FixAll.ruleset" ^
 -a "analyzers" ^
 --ignore-analyzer-references ^
 --ignore-compiler-errors ^
 --batch-size 2000

pause
