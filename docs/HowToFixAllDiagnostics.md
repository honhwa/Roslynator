
# How to Fix All Diagnostics in a Solution

1) Download package [Roslynator.CommandLine](http://www.nuget.org/packages/Roslynator.CommandLine/)&ensp;[![NuGet](https://img.shields.io/nuget/v/Roslynator.CommandLine.svg)](https://nuget.org/packages/Roslynator.CommandLine)

2) Extract package (for example to `C:\\roslynator`)

3) Open Command Line Prompt (cmd.exe)

4) Change directory to directory where **roslynator.exe** is located (for example `C:\\roslynator\\tools\\net46`)

5) Execute following command:

```
roslynator fix -s SOLUTION_PATH
```
## How to Reference Analyzer Assemblies

Roslynator will use analyzers and code fixes that are referenced as NuGet packages.
It will not use analyzers and code fixes that are part of Visual Studio extensions.
If you want to use these assemblies you have to use `--analyzers` option. For example:

```
roslynator fix ^
  -s SOLUTION_PATH ^
  --analyzers PATH_TO_ASSEMBLY_WITH_ANALYZERS PATH_TO_DIRECTORY_WITH_ANALYZERS
```

## How to Use Custom Rule Set

```
roslynator fix ^
  -s SOLUTION_PATH ^
  -p CodeAnalysisRuleSet=FULL_PATH_TO_RULESET_FILE
```

## See Also

* [`fix` command](cli/fix-command.md)
