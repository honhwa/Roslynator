<a name="_top"></a>

# MemberDeclarationListInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Indexers](#indexers) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators) &#x2022; [Explicit Interface Implementations](#explicit-interface-implementations)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about a list of member declaration list\.

```csharp
public readonly struct MemberDeclarationListInfo : System.IEquatable<MemberDeclarationListInfo>,
    System.Collections.Generic.IEnumerable<Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax>,
    System.Collections.Generic.IReadOnlyCollection<Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax>,
    System.Collections.Generic.IReadOnlyList<Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; MemberDeclarationListInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[MemberDeclarationListInfo](#_top)>
* System\.Collections\.Generic\.[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)\<[MemberDeclarationSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.memberdeclarationsyntax)>
* System\.Collections\.Generic\.[IReadOnlyCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1)\<[MemberDeclarationSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.memberdeclarationsyntax)>
* System\.Collections\.Generic\.[IReadOnlyList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)\<[MemberDeclarationSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.memberdeclarationsyntax)>

## Indexers

| Indexer | Summary |
| ------- | ------- |
| [Item\[Int32\]](Item/README.md#_top) | Gets the member at the specified index in the list\. \(Implements [IReadOnlyList\<MemberDeclarationSyntax>.Item](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1.item)\) |

## Properties

| Property | Summary |
| -------- | ------- |
| [Count](Count/README.md#_top) | A number of members in the list\. \(Implements [IReadOnlyCollection\<MemberDeclarationSyntax>.Count](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1.count)\) |
| [Members](Members/README.md#_top) | A list of members\. |
| [Parent](Parent/README.md#_top) | The declaration that contains the members\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Add(MemberDeclarationSyntax)](Add/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the specified member added at the end\. |
| [AddRange(IEnumerable\<MemberDeclarationSyntax>)](AddRange/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the specified members added at the end\. |
| [Any()](Any/README.md#_top) | True if the list has at least one member\. |
| [Equals(MemberDeclarationListInfo)](Equals/README.md#Roslynator_CSharp_Syntax_MemberDeclarationListInfo_Equals_Roslynator_CSharp_Syntax_MemberDeclarationListInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<MemberDeclarationListInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_MemberDeclarationListInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [First()](First/README.md#_top) | The first member in the list\. |
| [FirstOrDefault()](FirstOrDefault/README.md#_top) | The first member in the list or null if the list is empty\. |
| [GetEnumerator()](GetEnumerator/README.md#_top) | Gets the enumerator for the list of members\. |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [IndexOf(Func\<MemberDeclarationSyntax, Boolean>)](IndexOf/README.md#Roslynator_CSharp_Syntax_MemberDeclarationListInfo_IndexOf_System_Func_Microsoft_CodeAnalysis_CSharp_Syntax_MemberDeclarationSyntax_System_Boolean__) | Searches for a member that matches the predicate and returns returns zero\-based index of the first occurrence in the list\. |
| [IndexOf(MemberDeclarationSyntax)](IndexOf/README.md#Roslynator_CSharp_Syntax_MemberDeclarationListInfo_IndexOf_Microsoft_CodeAnalysis_CSharp_Syntax_MemberDeclarationSyntax_) | The index of the member in the list\. |
| [Insert(Int32, MemberDeclarationSyntax)](Insert/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the specified member inserted at the index\. |
| [InsertRange(Int32, IEnumerable\<MemberDeclarationSyntax>)](InsertRange/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the specified members inserted at the index\. |
| [Last()](Last/README.md#_top) | The last member in the list\. |
| [LastIndexOf(Func\<MemberDeclarationSyntax, Boolean>)](LastIndexOf/README.md#Roslynator_CSharp_Syntax_MemberDeclarationListInfo_LastIndexOf_System_Func_Microsoft_CodeAnalysis_CSharp_Syntax_MemberDeclarationSyntax_System_Boolean__) | Searches for a member that matches the predicate and returns returns zero\-based index of the last occurrence in the list\. |
| [LastIndexOf(MemberDeclarationSyntax)](LastIndexOf/README.md#Roslynator_CSharp_Syntax_MemberDeclarationListInfo_LastIndexOf_Microsoft_CodeAnalysis_CSharp_Syntax_MemberDeclarationSyntax_) | Searches for a member and returns zero\-based index of the last occurrence in the list\. |
| [LastOrDefault()](LastOrDefault/README.md#_top) | The last member in the list or null if the list is empty\. |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [Remove(MemberDeclarationSyntax)](Remove/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the specified member removed\. |
| [RemoveAt(Int32)](RemoveAt/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the member at the specified index removed\. |
| [RemoveNode(SyntaxNode, SyntaxRemoveOptions)](RemoveNode/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the specified node removed\. |
| [Replace(MemberDeclarationSyntax, MemberDeclarationSyntax)](Replace/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the specified member replaced with the new member\. |
| [ReplaceAt(Int32, MemberDeclarationSyntax)](ReplaceAt/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the member at the specified index replaced with a new member\. |
| [ReplaceNode(SyntaxNode, SyntaxNode)](ReplaceNode/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the specified old node replaced with a new node\. |
| [ReplaceRange(MemberDeclarationSyntax, IEnumerable\<MemberDeclarationSyntax>)](ReplaceRange/README.md#_top) | Creates a new [MemberDeclarationListInfo](#_top) with the specified member replaced with new members\. |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |
| [WithMembers(IEnumerable\<MemberDeclarationSyntax>)](WithMembers/README.md#Roslynator_CSharp_Syntax_MemberDeclarationListInfo_WithMembers_System_Collections_Generic_IEnumerable_Microsoft_CodeAnalysis_CSharp_Syntax_MemberDeclarationSyntax__) | Creates a new [MemberDeclarationListInfo](#_top) with the members updated\. |
| [WithMembers(SyntaxList\<MemberDeclarationSyntax>)](WithMembers/README.md#Roslynator_CSharp_Syntax_MemberDeclarationListInfo_WithMembers_Microsoft_CodeAnalysis_SyntaxList_Microsoft_CodeAnalysis_CSharp_Syntax_MemberDeclarationSyntax__) | Creates a new [MemberDeclarationListInfo](#_top) with the members updated\. |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(MemberDeclarationListInfo, MemberDeclarationListInfo)](op_Equality/README.md#_top) | |
| [Inequality(MemberDeclarationListInfo, MemberDeclarationListInfo)](op_Inequality/README.md#_top) | |

## Explicit Interface Implementations

| Member | Summary |
| ------ | ------- |
| [IEnumerable.GetEnumerator()](System-Collections-IEnumerable-GetEnumerator/README.md#_top) | |
| [IEnumerable\<MemberDeclarationSyntax>.GetEnumerator()](System-Collections-Generic-IEnumerable-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax--GetEnumerator/README.md#_top) | |

