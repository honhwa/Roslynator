<a name="_top"></a>

# StringConcatenationExpressionInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about string concatenation, i\.e\. a binary expression that binds to string '\+' operator\.

```csharp
public readonly struct StringConcatenationExpressionInfo : System.IEquatable<StringConcatenationExpressionInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; StringConcatenationExpressionInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[StringConcatenationExpressionInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [BinaryExpression](BinaryExpression/README.md#_top) | The binary expression that represents the string concatenation\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [AsChain()](AsChain/README.md#_top) | |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_StringConcatenationExpressionInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [Equals(StringConcatenationExpressionInfo)](Equals/README.md#Roslynator_CSharp_Syntax_StringConcatenationExpressionInfo_Equals_Roslynator_CSharp_Syntax_StringConcatenationExpressionInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<StringConcatenationExpressionInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [Expressions(Boolean)](Expressions/README.md#_top) | \[deprecated\] Returns expressions of this binary expression, including expressions of nested binary expressions of the same kind as parent binary expression\. |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(StringConcatenationExpressionInfo, StringConcatenationExpressionInfo)](op_Equality/README.md#_top) | |
| [Inequality(StringConcatenationExpressionInfo, StringConcatenationExpressionInfo)](op_Inequality/README.md#_top) | |

