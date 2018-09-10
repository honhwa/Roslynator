
# How to Generate Documentation for .NET Project

1) Install package [Roslynator.Documentation.CommandLine](http://www.nuget.org/packages/Roslynator.Documentation.CommandLine/)&ensp;[![NuGet](https://img.shields.io/nuget/v/Roslynator.Documentation.CommandLine.svg)](https://nuget.org/packages/Roslynator.Documentation.CommandLine)

2) Add MSBuild Target to your csproj (vbproj) file

```xml
<Target Name="DotDoc" AfterTargets="DotDocInitialize" Condition=" '$(Configuration)' == 'Release'">

  <PropertyGroup>

    <!-- One or more assembly paths you want generator documentation for, for example: A.dll B.dll -->
    <DotDocAssemblies>&quot;$(TargetPath)&quot;</DotDocAssemblies>

  </PropertyGroup>

    <!-- Execute 'doc' command. This command will generate documentation files from specified assemblies -->
  <Exec Command="$(DotDocExe) doc ^
    -a $(DotDocAssemblies) ^
    -r &quot;$(DotDocAssemblyReferences)&quot; ^
    -o &quot;$(SolutionDir)docs&quot; ^
    -h &quot;API Reference&quot;"
        LogStandardErrorAsError="true"
        ConsoleToMSBuild="true">
    <Output TaskParameter="ConsoleOutput" PropertyName="OutputOfExec" />
  </Exec>

    <!-- Execute 'declarations' command. This command will generate a single file that contains all declarations from specified assemblies -->
  <Exec Command="$(DotDocExe) declarations ^
    -a $(DotDocAssemblies) ^
    -r &quot;$(DotDocAssemblyReferences)&quot; ^
    -o &quot;$(SolutionDir)docs\api.cs&quot;"
        LogStandardErrorAsError="true"
        ConsoleToMSBuild="true">
    <Output TaskParameter="ConsoleOutput" PropertyName="OutputOfExec" />
  </Exec>

</Target>
```

#### Commands

* [`doc`](cli/doc-command.md)
* [`declarations`](cli/declarations-command.md)
* [`root`](cli/root-command.md)

3) Build project in **Release** configuration

4) Publish documentation to GitHub

## See Also

* [MSBuild reserved and well-known properties](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-reserved-and-well-known-properties?view=vs-2017)
* [Common MSBuild project properties](https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties?view=vs-2017)
* [Common macros for build commands and properties](https://docs.microsoft.com/en-us/cpp/ide/common-macros-for-build-commands-and-properties?view=vs-2017)
