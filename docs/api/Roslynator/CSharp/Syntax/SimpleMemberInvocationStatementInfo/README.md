<a name="_top"></a>

# SimpleMemberInvocationStatementInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about invocation expression in an expression statement\.

```csharp
public readonly struct SimpleMemberInvocationStatementInfo : System.IEquatable<SimpleMemberInvocationStatementInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; SimpleMemberInvocationStatementInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[SimpleMemberInvocationStatementInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [ArgumentList](ArgumentList/README.md#_top) | The argument list\. |
| [Arguments](Arguments/README.md#_top) | A list of arguments\. |
| [Expression](Expression/README.md#_top) | The expression that contains the member being invoked\. |
| [InvocationExpression](InvocationExpression/README.md#_top) | The invocation expression\. |
| [MemberAccessExpression](MemberAccessExpression/README.md#_top) | The member access expression\. |
| [Name](Name/README.md#_top) | The name of the member being invoked\. |
| [NameText](NameText/README.md#_top) | The name of the member being invoked\. |
| [Statement](Statement/README.md#_top) | The expression statement that contains the invocation expression\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_SimpleMemberInvocationStatementInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [Equals(SimpleMemberInvocationStatementInfo)](Equals/README.md#Roslynator_CSharp_Syntax_SimpleMemberInvocationStatementInfo_Equals_Roslynator_CSharp_Syntax_SimpleMemberInvocationStatementInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<SimpleMemberInvocationStatementInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(SimpleMemberInvocationStatementInfo, SimpleMemberInvocationStatementInfo)](op_Equality/README.md#_top) | |
| [Inequality(SimpleMemberInvocationStatementInfo, SimpleMemberInvocationStatementInfo)](op_Inequality/README.md#_top) | |

