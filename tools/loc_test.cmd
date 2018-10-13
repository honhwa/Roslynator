@echo off

"..\src\CommandLine\bin\Debug\net461\roslynator" loc "..\src\Roslynator.MetricsTest.sln" --ignore-block-boundary

pause
