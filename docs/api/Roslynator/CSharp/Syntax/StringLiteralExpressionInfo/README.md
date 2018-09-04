<a name="_top"></a>

# StringLiteralExpressionInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about string literal expression\.

```csharp
public readonly struct StringLiteralExpressionInfo : System.IEquatable<StringLiteralExpressionInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; StringLiteralExpressionInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[StringLiteralExpressionInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [ContainsEscapeSequence](ContainsEscapeSequence/README.md#_top) | True if the string literal expression contains escape sequence\. |
| [ContainsLinefeed](ContainsLinefeed/README.md#_top) | True if the string literal contains linefeed\. |
| [Expression](Expression/README.md#_top) | The string literal expression\. |
| [InnerText](InnerText/README.md#_top) | The token text, not including leading ampersand, if any, and enclosing quotation marks\. |
| [IsRegular](IsRegular/README.md#_top) | True if this instance is regular string literal expression\. |
| [IsVerbatim](IsVerbatim/README.md#_top) | True if this instance is verbatim string literal expression\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |
| [Text](Text/README.md#_top) | The token text\. |
| [Token](Token/README.md#_top) | The token representing the string literal expression\. |
| [ValueText](ValueText/README.md#_top) | The token value text\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_StringLiteralExpressionInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [Equals(StringLiteralExpressionInfo)](Equals/README.md#Roslynator_CSharp_Syntax_StringLiteralExpressionInfo_Equals_Roslynator_CSharp_Syntax_StringLiteralExpressionInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<StringLiteralExpressionInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(StringLiteralExpressionInfo, StringLiteralExpressionInfo)](op_Equality/README.md#_top) | |
| [Inequality(StringLiteralExpressionInfo, StringLiteralExpressionInfo)](op_Inequality/README.md#_top) | |

