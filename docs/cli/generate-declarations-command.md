
# `generate-declarations` Command

Generates a single file that contains all declarations from specified assemblies.

## Synopsis

```
roslynator declarations
-a|--assemblies
-o|--output
-r|--references
[--depth]
[--empty-line-between-members]
[--format-base-list]
[--format-constraints]
[--format-parameters]
[--fully-qualified-names]
[--ignored-names]
[--ignored-parts]
[--include-ienumerable]
[--indent-chars]
[--merge-attributes]
[--nest-namespaces]
[--no-default-literal]
[--no-indent]
[--no-new-line-before-open-brace]
[--no-precedence-for-system]
[--omit-attribute-arguments]
[--visibility]
```

## Options

### Required Options

**`-a|--assemblies`** `<ASSEMBLIES-TO-DOCUMENT>`

Defines one or more assemblies that should be used as a source for the documentation.

**`-o|--output`** `<OUTPUT-DIRECTORY>`

Defines a path for the output directory.

**`-r|--references`** `<ASSEMBLY-REFERENCE> <ASSEMBLY-REFERENCES-FILE>`

Defines one or more values where each value can be:

* Path to assembly file.
* Path to a file that contains a list of all assemblies. Each assembly must be on separate line.

### Optional Options

**`[--depth]`** `{member|type|namespace}`

Defines a depth of a documentation. Default value is `member`.

**`[--empty-line-between-members]`**

Indicates whether an empty line should be added between two member declarations.

**`[--format-base-list]`**

Indicates whether a base list should be formatted on a multiple lines.

**`[--format-constraints]`**

Indicates whether constraints should be formatted on a multiple lines.

**`[--format-parameters]`**

Indicates whether parameters should be formatted on a multiple lines.

**`[--fully-qualified-names]`**

Indicates whether type names should be fully qualified.

**`[--ignored-names]`** `<FULLY-QUALIFIED-METADATA-NAMES-TO-IGNORE>`

Defines a list of metadata names that should be excluded from a documentation. Namespace of type names can be specified.

**`[--ignored-parts]`** `{auto-generated-comment | assembly-attributes}`

Defines parts of a declaration list that should be excluded.

**`[--include-ienumerable]`**

Indicates whether interface `System.Collections.IEnumerable` should be included in a documentation if a type also implements interface `System.Collections.Generic.IEnumerable<T>`.

**`[--indent-chars]`** `<INDENT-CHARS>`

Defines characters that should be used for indentation. Default value is four spaces.

**`[--merge-attributes]`**

Indicates whether attributes should be displayed in a single attribute list.

**`[--nest-namespaces]`**

Indicates whether namespaces should be nested.

**`[--no-default-literal]`**

Indicates whether default expression (`default(T)`) should be used instead of default literal (`default`).

**`[--no-indent]`**

Indicates whether declarations should not be indented.

**`[--no-new-line-before-open-brace]`**

Indicates whether opening braced should not be placed on a new line.

**`[--no-precedence-for-system]`**

Indicates whether symbols contained in `System` namespace should be ordered as any other symbols and not before other symbols.

**`[--omit-attribute-arguments]`**

Indicates whether attribute arguments should be omitted when displaying an attribute.

**`[--visibility]`** `{publicly|publicly-or-internally|all}`

Defines a visibility of a type or a member. Default value is `publicly`.

## See Also

* [Roslynator Command-Line Interface](README.md)
