<a name="_top"></a>

# GenericInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about generic syntax \(class, struct, interface, delegate, method or local function\)\.

```csharp
public readonly struct GenericInfo : System.IEquatable<GenericInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; GenericInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[GenericInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [ConstraintClauses](ConstraintClauses/README.md#_top) | A list of constraint clauses\. |
| [Kind](Kind/README.md#_top) | The kind of this syntax node\. |
| [Node](Node/README.md#_top) | The syntax node that can be generic \(for example [ClassDeclarationSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.classdeclarationsyntax) for a class or [LocalDeclarationStatementSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.localdeclarationstatementsyntax) for a local function\)\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |
| [TypeParameterList](TypeParameterList/README.md#_top) | The type parameter list\. |
| [TypeParameters](TypeParameters/README.md#_top) | A list of type parameters\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(GenericInfo)](Equals/README.md#Roslynator_CSharp_Syntax_GenericInfo_Equals_Roslynator_CSharp_Syntax_GenericInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<GenericInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_GenericInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [FindConstraintClause(String)](FindConstraintClause/README.md#_top) | Searches for a constraint clause with the specified type parameter name and returns the first occurrence within the constraint clauses\. |
| [FindTypeParameter(String)](FindTypeParameter/README.md#_top) | Searches for a type parameter with the specified name and returns the first occurrence within the type parameters\. |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [RemoveAllConstraintClauses()](RemoveAllConstraintClauses/README.md#_top) | Creates a new [GenericInfo](#_top) with all constraint clauses removed\. |
| [RemoveConstraintClause(TypeParameterConstraintClauseSyntax)](RemoveConstraintClause/README.md#_top) | Creates a new [GenericInfo](#_top) with the specified constraint clause removed\. |
| [RemoveTypeParameter(TypeParameterSyntax)](RemoveTypeParameter/README.md#_top) | Creates a new [GenericInfo](#_top) with the specified type parameter removed\. |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |
| [WithConstraintClauses(SyntaxList\<TypeParameterConstraintClauseSyntax>)](WithConstraintClauses/README.md#_top) | Creates a new [GenericInfo](#_top) with the constraint clauses updated\. |
| [WithTypeParameterList(TypeParameterListSyntax)](WithTypeParameterList/README.md#_top) | Creates a new [GenericInfo](#_top) with the type parameter list updated\. |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(GenericInfo, GenericInfo)](op_Equality/README.md#_top) | |
| [Inequality(GenericInfo, GenericInfo)](op_Inequality/README.md#_top) | |

