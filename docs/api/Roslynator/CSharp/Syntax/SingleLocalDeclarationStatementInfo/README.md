<a name="_top"></a>

# SingleLocalDeclarationStatementInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about a local declaration statement with a single variable\.

```csharp
public readonly struct SingleLocalDeclarationStatementInfo : System.IEquatable<SingleLocalDeclarationStatementInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; SingleLocalDeclarationStatementInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[SingleLocalDeclarationStatementInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [Declaration](Declaration/README.md#_top) | The variable declaration\. |
| [Declarator](Declarator/README.md#_top) | The variable declarator\. |
| [EqualsToken](EqualsToken/README.md#_top) | The equals token\. |
| [Identifier](Identifier/README.md#_top) | Variable identifier\. |
| [IdentifierText](IdentifierText/README.md#_top) | Variable name\. |
| [Initializer](Initializer/README.md#_top) | The variable initializer, if any\. |
| [Modifiers](Modifiers/README.md#_top) | The modifier list\. |
| [SemicolonToken](SemicolonToken/README.md#_top) | The semicolon\. |
| [Statement](Statement/README.md#_top) | The local declaration statement\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |
| [Type](Type/README.md#_top) | The type of a declaration\. |
| [Value](Value/README.md#_top) | The initialized value, if any\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_SingleLocalDeclarationStatementInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [Equals(SingleLocalDeclarationStatementInfo)](Equals/README.md#Roslynator_CSharp_Syntax_SingleLocalDeclarationStatementInfo_Equals_Roslynator_CSharp_Syntax_SingleLocalDeclarationStatementInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<SingleLocalDeclarationStatementInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(SingleLocalDeclarationStatementInfo, SingleLocalDeclarationStatementInfo)](op_Equality/README.md#_top) | |
| [Inequality(SingleLocalDeclarationStatementInfo, SingleLocalDeclarationStatementInfo)](op_Inequality/README.md#_top) | |

