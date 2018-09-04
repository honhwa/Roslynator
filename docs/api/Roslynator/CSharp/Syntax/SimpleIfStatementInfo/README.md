<a name="_top"></a>

# SimpleIfStatementInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about a simple if statement\.
Simple if statement is defined as follows: it is not a child of an else clause and it has no else clause\.

```csharp
public readonly struct SimpleIfStatementInfo : System.IEquatable<SimpleIfStatementInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; SimpleIfStatementInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[SimpleIfStatementInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [Condition](Condition/README.md#_top) | The condition\. |
| [IfStatement](IfStatement/README.md#_top) | The if statement\. |
| [Statement](Statement/README.md#_top) | The statement\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_SimpleIfStatementInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [Equals(SimpleIfStatementInfo)](Equals/README.md#Roslynator_CSharp_Syntax_SimpleIfStatementInfo_Equals_Roslynator_CSharp_Syntax_SimpleIfStatementInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<SimpleIfStatementInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(SimpleIfStatementInfo, SimpleIfStatementInfo)](op_Equality/README.md#_top) | |
| [Inequality(SimpleIfStatementInfo, SimpleIfStatementInfo)](op_Inequality/README.md#_top) | |

