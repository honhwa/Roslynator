<a name="_top"></a>

# SimpleIfElseInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about a simple if\-else\.
Simple if\-else is defined as follows: it is not a child of an else clause and it has an else clause and the else clause does not continue with another if statement\.

```csharp
public readonly struct SimpleIfElseInfo : System.IEquatable<SimpleIfElseInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; SimpleIfElseInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[SimpleIfElseInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [Condition](Condition/README.md#_top) | The condition\. |
| [Else](Else/README.md#_top) | The else clause\. |
| [IfStatement](IfStatement/README.md#_top) | The if statement\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |
| [WhenFalse](WhenFalse/README.md#_top) | The statement that is executed if the condition evaluates to false\. |
| [WhenTrue](WhenTrue/README.md#_top) | The statement that is executed if the condition evaluates to true\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_SimpleIfElseInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [Equals(SimpleIfElseInfo)](Equals/README.md#Roslynator_CSharp_Syntax_SimpleIfElseInfo_Equals_Roslynator_CSharp_Syntax_SimpleIfElseInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<SimpleIfElseInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(SimpleIfElseInfo, SimpleIfElseInfo)](op_Equality/README.md#_top) | |
| [Inequality(SimpleIfElseInfo, SimpleIfElseInfo)](op_Inequality/README.md#_top) | |

