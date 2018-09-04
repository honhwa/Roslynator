<a name="_top"></a>

# RootDocumentationParts Enum

[Home](../../../README.md#_top) &#x2022; [Fields](#fields)

**Namespace**: [Roslynator.Documentation](../README.md#_top)

**Assembly**: Roslynator\.Documentation\.dll

```csharp
[System.FlagsAttribute]
public enum RootDocumentationParts
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; [Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum) &#x2192; RootDocumentationParts

### Attributes

* System\.[FlagsAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute)

## Fields

| Name | Value | Combination of | Summary |
| ---- | ----- | -------------- | ------- |
| None | 0 | |
| Content | 1 | |
| Namespaces | 2 | |
| Classes | 4 | |
| StaticClasses | 8 | |
| Structs | 16 | |
| Interfaces | 32 | |
| Enums | 64 | |
| Delegates | 128 | |
| Types | 252 | Classes \| StaticClasses \| Structs \| Interfaces \| Enums \| Delegates |
| Other | 256 | |
| All | 511 | Content \| Namespaces \| Types \| Other |

