
# `fix` Command

Fix all diagnostics in the specified solution.

## Synopsis

```
roslynator fix
-s|--solution
[-a|--analyzers]
[-p|--properties]
[--msbuild-path]
[--ignore-analyzer-references]
[--ignore-compiler-errors]
[--ignored-diagnostics]
[--ignored-compiler-diagnostics]
[--ignored-projects]
[--batch-size]
```

## Options

### Required Options

**`-s|--solution`**

Defines a path to the solution file.

### Optional Options

**`a-|--analyzers`**

Defines one or more paths to:

* analyzer assembly
* directory that should be searched recursively for analyzer assemblies

**`-p|--properties`** `<NAME=VALUE>`

Defines one or more MSBuild properties.

**`--msbuild-path`**

Defines a path to MSBuild. If there are installed multiple instances of MSBuild the instance with the highest version will be used.

**`--ignore-compiler-errors`**

Indicates whether fixing should continue even if compilation has errors.

**`--ignore-analyzer-references`**

Indicates whether Roslynator should ignore analyzers that are referenced in projects.

**`--ignored-diagnostics`**

Defines diagnostic identifiers that should not be fixed.

**`--ignored-compiler-diagnostics`**

Defines compiler diagnostic identifiers that should be ignored even if **`--ignore-compiler-errors`** is set to `false`.

**`--ignored-projects`**

Defines project names that should not be fixed.

**`--batch-size`**

Defines maximum number of diagnostics that can be fixed in one batch.

## See Also

* [Roslynator Command-Line Interface](README.md)
