<a name="_top"></a>

# OmitContainingNamespaceParts Enum

[Home](../../../README.md#_top) &#x2022; [Fields](#fields)

**Namespace**: [Roslynator.Documentation](../README.md#_top)

**Assembly**: Roslynator\.Documentation\.dll

```csharp
[System.FlagsAttribute]
public enum OmitContainingNamespaceParts
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; [Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum) &#x2192; OmitContainingNamespaceParts

### Attributes

* System\.[FlagsAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute)

## Fields

| Name | Value | Combination of | Summary |
| ---- | ----- | -------------- | ------- |
| None | 0 | |
| Root | 1 | |
| ContainingType | 2 | |
| ReturnType | 4 | |
| BaseType | 8 | |
| Attribute | 16 | |
| DerivedType | 32 | |
| ImplementedInterface | 64 | |
| ImplementedMember | 128 | |
| Exception | 256 | |
| SeeAlso | 512 | |
| All | 1023 | Root \| ContainingType \| ReturnType \| BaseType \| Attribute \| DerivedType \| ImplementedInterface \| ImplementedMember \| Exception \| SeeAlso |

