
# How to Fix All Diagnostics

1) Download package [Roslynator.CommandLine](http://www.nuget.org/packages/Roslynator.CommandLine/)&ensp;[![NuGet](https://img.shields.io/nuget/v/Roslynator.CommandLine.svg)](https://nuget.org/packages/Roslynator.CommandLine)

2) Extract package (for example to `C:\\roslynator`)

3) Open Command Line Prompt (cmd.exe)

4) Change directory to directory where **roslynator.exe** is located (for example `C:\\roslynator\\tools\\net46`)

5) Execute following command

```
roslynator.exe fix -s SOLUTION_PATH
```
## How to Reference Analyzer Assemblies

Roslynator will use analyzers and code fixes that are referenced as NuGet packages.
It will not use analyzers and code fixes that are part of Visual Studio extensions.
If you want to use these assemblies you have to use `--analyzers` option. For example:

```
roslynator.exe fix ^
  -s SOLUTION_PATH ^
  --analyzers "C:\Users\JohnDoe\AppData\Local\Microsoft\VisualStudio\15.0\Extensions\EXTENSION_THAT_CONTAINS_ANALYZERS"
```

## See Also

* [`fix` command](cli/fix-command.md)
