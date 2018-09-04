<a name="_top"></a>

# CommentKinds Enum

[Home](../../../README.md#_top) &#x2022; [Fields](#fields)

**Namespace**: [Roslynator.CSharp](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Specifies C\# comments\.

```csharp
[System.FlagsAttribute]
public enum CommentKinds
```

### Inheritance

System\.[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  
&emsp;System\.[ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype)  
&emsp;&emsp;System\.[Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum)  
&emsp;&emsp;&emsp;CommentKinds

### Attributes

* System\.[FlagsAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute)

## Fields

| Name | Value | Combination of | Summary |
| ---- | ----- | -------------- | ------- |
| None | 0 | | None comment specified\. |
| SingleLine | 1 | | Single\-line comment\. |
| MultiLine | 2 | | Multi\-line comment\. |
| NonDocumentation | 3 | SingleLine \| MultiLine | Non\-documentation comment \(single\-line or multi\-line\)\. |
| SingleLineDocumentation | 4 | | Single\-line documentation comment\. |
| MultiLineDocumentation | 8 | | Multi\-line documentation comment\. |
| Documentation | 12 | SingleLineDocumentation \| MultiLineDocumentation | Documentation comment \(single\-line or multi\-line\)\. |
| All | 15 | NonDocumentation \| Documentation | Documentation or non\-documentation comment\. |

