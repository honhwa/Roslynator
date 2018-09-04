<a name="_top"></a>

# IfStatementOrElseClause Struct

[Home](../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

A wrapper for either an [IfStatementSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.ifstatementsyntax) or an [ElseClauseSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.elseclausesyntax)\.

```csharp
public readonly struct IfStatementOrElseClause : System.IEquatable<IfStatementOrElseClause>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; IfStatementOrElseClause

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[IfStatementOrElseClause](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [FullSpan](FullSpan/README.md#_top) | The absolute span of this node in characters, including its leading and trailing trivia\. |
| [IsElse](IsElse/README.md#_top) | Determines whether this [IfStatementOrElseClause](#_top) is wrapping an else clause\. |
| [IsIf](IsIf/README.md#_top) | Determines whether this [IfStatementOrElseClause](#_top) is wrapping an if statement\. |
| [Kind](Kind/README.md#_top) | Gets an underlying node kind\. |
| [Parent](Parent/README.md#_top) | The node that contains the underlying node in its [SyntaxNode.ChildNodes](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.syntaxnode.childnodes) collection\. |
| [Span](Span/README.md#_top) | The absolute span of this node in characters, not including its leading and trailing trivia\. |
| [Statement](Statement/README.md#_top) | Gets [IfStatementSyntax.Statement](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.ifstatementsyntax.statement) or [ElseClauseSyntax.Statement](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.elseclausesyntax.statement)\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [AsElse()](AsElse/README.md#_top) | Returns the underlying else clause if this [ElseClauseSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.elseclausesyntax) is wrapping else clause\. |
| [AsIf()](AsIf/README.md#_top) | Returns the underlying if statement if this [IfStatementOrElseClause](#_top) is wrapping if statement\. |
| [Equals(IfStatementOrElseClause)](Equals/README.md#Roslynator_CSharp_IfStatementOrElseClause_Equals_Roslynator_CSharp_IfStatementOrElseClause_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<IfStatementOrElseClause>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_IfStatementOrElseClause_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying node, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(IfStatementOrElseClause, IfStatementOrElseClause)](op_Equality/README.md#_top) | |
| [Implicit(ElseClauseSyntax to IfStatementOrElseClause)](op_Implicit/README.md#Roslynator_CSharp_IfStatementOrElseClause_op_Implicit_Microsoft_CodeAnalysis_CSharp_Syntax_ElseClauseSyntax__Roslynator_CSharp_IfStatementOrElseClause) | |
| [Implicit(IfStatementOrElseClause to ElseClauseSyntax)](op_Implicit/README.md#Roslynator_CSharp_IfStatementOrElseClause_op_Implicit_Roslynator_CSharp_IfStatementOrElseClause___Microsoft_CodeAnalysis_CSharp_Syntax_ElseClauseSyntax) | |
| [Implicit(IfStatementOrElseClause to IfStatementSyntax)](op_Implicit/README.md#Roslynator_CSharp_IfStatementOrElseClause_op_Implicit_Roslynator_CSharp_IfStatementOrElseClause___Microsoft_CodeAnalysis_CSharp_Syntax_IfStatementSyntax) | |
| [Implicit(IfStatementSyntax to IfStatementOrElseClause)](op_Implicit/README.md#Roslynator_CSharp_IfStatementOrElseClause_op_Implicit_Microsoft_CodeAnalysis_CSharp_Syntax_IfStatementSyntax__Roslynator_CSharp_IfStatementOrElseClause) | |
| [Inequality(IfStatementOrElseClause, IfStatementOrElseClause)](op_Inequality/README.md#_top) | |

