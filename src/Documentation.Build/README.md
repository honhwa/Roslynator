
# Roslynator.Documentation Command-Line Interface

<!-- [![NuGet](https://img.shields.io/nuget/v/Roslynator.Documentation.Build.svg)](https://nuget.org/packages/Roslynator.Documentation.Build) -->

## Commands

* [doc](#doc-command)
* [declarations](#declarations-command)
* [root](#root-command)

## `doc` Command

Generates documentation files from specified assemblies.

```
doc
-a|--assemblies
-h|--heading
-o|--output
-r|--references
[--additional-xml-documentation]
[--depth]
[--ignored-member-parts]
[--ignored-names]
[--ignored-namespace-parts]
[--ignored-root-parts]
[--ignored-type-parts]
[--include-all-derived-types]
[--include-ienumerable]
[--include-inherited-interface-members]
[--omit-attribute-arguments]
[--omit-containing-namespace]
[--omit-member-constant-value]
[--omit-member-inherited-from]
[--omit-member-implements]
[--omit-member-overrides]
[--max-derived-types]
[--mode]
[--no-format-base-list]
[--no-class-hierarchy]
[--no-format-constraints]
[--no-delete]
[--no-mark-obsolete]
[--no-precedence-for-system]
[--preferred-culture]
```

### Options

#### `-a|--assemblies <ASSEMBLIES-TO-DOCUMENT>`
Defines one or more assemblies that should be used as a source for the documentation.

#### `-h|--heading <ROOT-FILE-HEADING>`
Defines a heading of the root documentation file.

#### `-o|--output <OUTPUT-DIRECTORY>`
Defines a path for the output directory.

#### `-r|--references <PATH-TO-FILE-WITH-ASSEMBLY-REFERENCES>`

Defines one of two following options:

* Path to a file that contains a list of all assemblies necessary to compile a project. Each assembly must be on separate line.
* Semicolon separated list of assemblies necessary to compile a project.

#### `[--additional-xml-documentation] <XML-DOCUMENTATION-FILES>`
Defines one or more xml documentation files that should be included. These files can contain a documentation for namespaces, for instance.

#### `[--depth] {member|type|namespace}`
Defines a depth of a documentation. Default value is `member`.

#### `[--ignored-member-parts] {overloads containing-type containing-assembly obsolete-message summary declaration type-parameters parameters return-value implements attributes exceptions examples remarks see-also}`
Defines parts of a member documentation that should be excluded. No part is excluded by default.

#### `[--ignored-names] <FULLY-QUALIFIED-METADATA-NAMES-TO-IGNORE>`
Defines a list of metadata names that should be excluded from a documentation. Namespace of type names can be specified.

#### `[--ignored-namespace-parts] {content containing-namespace summary examples remarks classes structs interfaces enums delegates see-also}`
Defines parts of a namespace documentation that should be excluded. No part is excluded by default.

#### `[--ignored-root-parts] {content | namespaces | classes | static-classes | structs | interfaces | enums | delegates | other}`
Defines parts of a root documentation that should be excluded. No part is excluded by default.

#### `[--ignored-type-parts] {content containing-namespace containing-assembly obsolete-message summary declaration type-parameters parameters return-value inheritance attributes derived implements examples remarks constructors fields indexers properties methods operators events explicit-interface-implementations extension-methods classes structs interfaces enums delegates see-also}`
Defines parts of a type documentation that should be excluded. No part is excluded by default.

#### `[--include-all-derived-types]`
Indicates whether all derived types should be included in the list of derived types. By default only types that directly inherits from a specified type are displayed. Default value is `false`.

#### `[--include-ienumerable]`
Indicates whether interface `System.Collections.IEnumerable` should be included in a documentation if a type also implements interface `System.Collections.Generic.IEnumerable<T>`.

#### `[--include-inherited-interface-members]`
Indicates whether inherited interface members should be displayed in a list of members. Default values is `false`.

#### `[--omit-attribute-arguments]`
Indicates whether attribute arguments should be omitted when displaying an attribute.

#### `[--omit-containing-namespace]`
Indicates whether a containing namespace should be omitted when displaying type name.

#### `[--omit-member-constant-value]`
Indicates whether a constant value of a member should be omitted.

#### `[--omit-member-inherited-from]`
Indicates whether a containing member of an inherited member should be omitted.

#### `[--omit-member-implements]`
Indicates whether an interface member that is being implemented should be omitted.

#### `[--omit-member-overrides]`
Indicates whether an overridden member should be omitted.

#### `[--max-derived-types]`
Defines maximum number derived types that should be displayed. Default value is `5`.

#### `[--mode] {github}`
Defines documentation generation mode. Currently only supported mode is `github`.

#### `[--no-format-base-list]`
Indicates whether a base list should not be formatted on a multiple lines.

#### `[--no-class-hierarchy]`
Indicates whether classes should be displayed as a list instead of hierarchy tree.

#### `[--no-format-constraints]`
Indicates whether constraints should not be formatted on a multiple lines.

#### `[--no-delete]`
Indicates whether output directory should not be deleted at the beginning of the process.

#### `[--no-mark-obsolete]`
Indicates whether obsolete types and members should not be marked as `[deprecated]`.

#### `[--no-precedence-for-system]`
Indicates whether symbols contained in `System` namespace should be ordered as any other symbols and not before other symbols.

#### `[--preferred-culture]`
Defines culture that should be used when searching for xml documentation files.

## `declarations` Command
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

### Options

#### `-a|--assemblies <ASSEMBLIES-TO-DOCUMENT>`
Defines one or more assemblies that should be used as a source for the documentation.

#### `-o|--output <OUTPUT-DIRECTORY>`
Defines a path for the output directory.

#### `-r|--references <PATH-TO-FILE-WITH-ASSEMBLY-REFERENCES>`
Defines a path to a file that contains a list of all assemblies necessary to compile a project. Each assembly must be on separate line.

#### `[--empty-line-between-declarations]`
Indicates whether an empty line should be added between two declarations. Default value is `false`.

#### `[--format-base-list]`
Indicates whether a base list should be formatted on a multiple lines. Default value is `false`.

#### `[--format-constraints]`
Indicates whether constraints should be formatted on a multiple lines. Default value is `false`.

#### `[--ignored-names] <FULLY-QUALIFIED-METADATA-NAMES-TO-IGNORE>`
Defines a list of metadata names that should be excluded from a documentation. Namespace of type names can be specified.

#### `[--include-ienumerable]`
Indicates whether interface `System.Collections.IEnumerable` should be included in a documentation if a type also implements interface `System.Collections.Generic.IEnumerable<T>`.

#### `[--indent-chars] <INDENT-CHARS>`
Defines characters that should be used for indentation. Default value are four spaces.

#### `[--merge-attributes]`
Indicates whether attributes should be displayed in a single attribute list.

#### `[--no-indent]`
Indicates whether declarations should not be indented.

#### `[--no-new-line-before-open-brace]`
Indicates whether opening braced should not be placed on a new line.

#### `[--omit-attribute-arguments]`
Indicates whether attribute arguments should be omitted when displaying an attribute.

#### `[--no-default-literal]`
Indicates whether default expression (`default(T)`) should be used instead of default literal (`default`).

#### `[--no-precedence-for-system]`
Indicates whether symbols contained in `System` namespace should be ordered as any other symbols and not before other symbols.

## `root` Command

Generates root documentation file from specified assemblies.

```
doc
-a|--assemblies
-h|--heading
-o|--output
-r|--references
[--depth]
[--ignored-names]
[--ignored-parts]
[--mode]
[--no-class-hierarchy]
[--no-mark-obsolete]
[--no-precedence-for-system]
[--omit-containing-namespace]
[--root-url]
```

### Options

#### `-a|--assemblies <ASSEMBLIES-TO-DOCUMENT>`
Defines one or more assemblies that should be used as a source for the documentation.

#### `-h|--heading <ROOT-FILE-HEADING>`
Defines a heading of the root documentation file.

#### `-o|--output <OUTPUT-DIRECTORY>`
Defines a path for the output directory.

#### `-r|--references <PATH-TO-FILE-WITH-ASSEMBLY-REFERENCES>`

Defines one of two following options:

* Path to a file that contains a list of all assemblies necessary to compile a project. Each assembly must be on separate line.
* Semicolon separated list of assemblies necessary to compile a project.

#### `[--depth] {member|type|namespace}`
Defines a depth of a documentation. Default value is `member`.

#### `[--ignored-names] <FULLY-QUALIFIED-METADATA-NAMES-TO-IGNORE>`
Defines a list of metadata names that should be excluded from a documentation. Namespace of type names can be specified.

#### `[--ignored-parts] {content | namespaces | classes | static-classes | structs | interfaces | enums | delegates | other}`
Defines parts of a root documentation that should be excluded. No part is excluded by default.

#### `[--mode] {github}`
Defines documentation generation mode. Currently only supported mode is `github`.

#### `[--no-class-hierarchy]`
Indicates whether classes should be displayed as a list instead of hierarchy tree.

#### `[--no-mark-obsolete]`
Indicates whether obsolete types and members should not be marked as `[deprecated]`.

#### `[--no-precedence-for-system]`
Indicates whether symbols contained in `System` namespace should be ordered as any other symbols and not before other symbols.

#### `[--omit-containing-namespace]`
Indicates whether a containing namespace should be omitted when displaying type name.

#### `[--root-url]`
Defines a relative url to the documentation root directory.
