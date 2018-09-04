<a name="_top"></a>

# LocalDeclarationStatementInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about local declaration statement\.

```csharp
public readonly struct LocalDeclarationStatementInfo : System.IEquatable<LocalDeclarationStatementInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; LocalDeclarationStatementInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[LocalDeclarationStatementInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [Declaration](Declaration/README.md#_top) | The variable declaration\. |
| [Modifiers](Modifiers/README.md#_top) | The modifier list\. |
| [SemicolonToken](SemicolonToken/README.md#_top) | The semicolon token\. |
| [Statement](Statement/README.md#_top) | The local declaration statement\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |
| [Type](Type/README.md#_top) | The type of the declaration\. |
| [Variables](Variables/README.md#_top) | A list of variables\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(LocalDeclarationStatementInfo)](Equals/README.md#Roslynator_CSharp_Syntax_LocalDeclarationStatementInfo_Equals_Roslynator_CSharp_Syntax_LocalDeclarationStatementInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<LocalDeclarationStatementInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_LocalDeclarationStatementInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(LocalDeclarationStatementInfo, LocalDeclarationStatementInfo)](op_Equality/README.md#_top) | |
| [Inequality(LocalDeclarationStatementInfo, LocalDeclarationStatementInfo)](op_Inequality/README.md#_top) | |

