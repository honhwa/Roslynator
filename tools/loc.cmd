@echo off

"..\src\CommandLine\bin\Debug\net461\roslynator" loc "..\src\Roslynator.sln" --ignore-block-boundary

pause
