<a name="_top"></a>

# NamespaceDocumentationParts Enum

[Home](../../../README.md#_top) &#x2022; [Fields](#fields)

**Namespace**: [Roslynator.Documentation](../README.md#_top)

**Assembly**: Roslynator\.Documentation\.dll

```csharp
[System.FlagsAttribute]
public enum NamespaceDocumentationParts
```

### Inheritance

System\.[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  
&emsp;System\.[ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype)  
&emsp;&emsp;System\.[Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum)  
&emsp;&emsp;&emsp;NamespaceDocumentationParts

### Attributes

* System\.[FlagsAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute)

## Fields

| Name | Value | Combination of | Summary |
| ---- | ----- | -------------- | ------- |
| None | 0 | |
| Content | 1 | |
| ContainingNamespace | 2 | |
| Summary | 4 | |
| Examples | 8 | |
| Remarks | 16 | |
| Classes | 32 | |
| Structs | 64 | |
| Interfaces | 128 | |
| Enums | 256 | |
| Delegates | 512 | |
| SeeAlso | 1024 | |
| All | 2047 | Content \| ContainingNamespace \| Summary \| Examples \| Remarks \| Classes \| Structs \| Interfaces \| Enums \| Delegates \| SeeAlso |

