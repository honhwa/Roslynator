<a name="_top"></a>

# NullCheckExpressionInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about a null check expression\.

```csharp
public readonly struct NullCheckExpressionInfo : System.IEquatable<NullCheckExpressionInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; NullCheckExpressionInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[NullCheckExpressionInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [Expression](Expression/README.md#_top) | The expression that is evaluated whether is \(not\) null\. for example "x" in "x == null"\. |
| [IsCheckingNotNull](IsCheckingNotNull/README.md#_top) | Determines whether this null check is checking if the expression is not null\. |
| [IsCheckingNull](IsCheckingNull/README.md#_top) | Determines whether this null check is checking if the expression is null\. |
| [NullCheckExpression](NullCheckExpression/README.md#_top) | The null check expression, e\.g\. "x == null"\. |
| [Style](Style/README.md#_top) | The style of this null check\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(NullCheckExpressionInfo)](Equals/README.md#Roslynator_CSharp_Syntax_NullCheckExpressionInfo_Equals_Roslynator_CSharp_Syntax_NullCheckExpressionInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<NullCheckExpressionInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_NullCheckExpressionInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(NullCheckExpressionInfo, NullCheckExpressionInfo)](op_Equality/README.md#_top) | |
| [Inequality(NullCheckExpressionInfo, NullCheckExpressionInfo)](op_Inequality/README.md#_top) | |

