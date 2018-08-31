
# `declarations` Command
Generates a single file that contains all declarations from specified assemblies.

```
declarations
-a|--assemblies
-o|--output
-r|--references
[--empty-line-between-declarations]
[--format-base-list]
[--format-constraints]
[--ignored-names]
[--include-ienumerable]
[--indent-chars]
[--merge-attributes]
[--no-indent]
[--no-new-line-before-open-brace]
[--no-precedence-for-system]
[--omit-attribute-arguments]
[--no-default-literal]
```

## Options

### `-a|--assemblies <ASSEMBLIES-TO-DOCUMENT>`
Defines one or more assemblies that should be used as a source for the documentation.

### `-o|--output <OUTPUT-DIRECTORY>`
Defines a path for the output directory.

### `-r|--references <PATH-TO-FILE-WITH-ASSEMBLY-REFERENCES>`
Defines a path to a file that contains a list of all assemblies necessary to compile a project. Each assembly must be on separate line.

### `[--empty-line-between-declarations]`
Indicates whether an empty line should be added between two declarations. Default value is `false`.

### `[--format-base-list]`
Indicates whether a base list should be formatted on a multiple lines. Default value is `false`.

### `[--format-constraints]`
Indicates whether constraints should be formatted on a multiple lines. Default value is `false`.

### `[--ignored-names] <FULLY-QUALIFIED-METADATA-NAMES-TO-IGNORE>`
Defines a list of metadata names that should be excluded from a documentation. Namespace of type names can be specified.

### `[--include-ienumerable]`
Indicates whether interface `System.Collections.IEnumerable` should be included in a documentation if a type also implements interface `System.Collections.Generic.IEnumerable<T>`.

### `[--indent-chars] <INDENT-CHARS>`
Defines characters that should be used for indentation. Default value are four spaces.

### `[--merge-attributes]`
Indicates whether attributes should be displayed in a single attribute list.

### `[--no-indent]`
Indicates whether declarations should not be indented.

### `[--no-new-line-before-open-brace]`
Indicates whether opening braced should not be placed on a new line.

### `[--omit-attribute-arguments]`
Indicates whether attribute arguments should be omitted when displaying an attribute.

### `[--no-default-literal]`
Indicates whether default expression (`default(T)`) should be used instead of default literal (`default`).

### `[--no-precedence-for-system]`
Indicates whether symbols contained in `System` namespace should be ordered as any other symbols and not before other symbols.
