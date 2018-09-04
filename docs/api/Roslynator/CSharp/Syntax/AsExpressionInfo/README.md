<a name="_top"></a>

# AsExpressionInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about "as" expression\.

```csharp
public readonly struct AsExpressionInfo : System.IEquatable<AsExpressionInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; AsExpressionInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[AsExpressionInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [AsExpression](AsExpression/README.md#_top) | The "as" expression\. |
| [Expression](Expression/README.md#_top) | The expression that is being casted\. |
| [OperatorToken](OperatorToken/README.md#_top) | The "as" operator token\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |
| [Type](Type/README.md#_top) | The type to which the expression is being cast\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(AsExpressionInfo)](Equals/README.md#Roslynator_CSharp_Syntax_AsExpressionInfo_Equals_Roslynator_CSharp_Syntax_AsExpressionInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<AsExpressionInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_AsExpressionInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(AsExpressionInfo, AsExpressionInfo)](op_Equality/README.md#_top) | |
| [Inequality(AsExpressionInfo, AsExpressionInfo)](op_Inequality/README.md#_top) | |

