<a name="_top"></a>

# UsingDirectiveListInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Indexers](#indexers) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators) &#x2022; [Explicit Interface Implementations](#explicit-interface-implementations)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about a list of using directives\.

```csharp
public readonly struct UsingDirectiveListInfo : System.IEquatable<UsingDirectiveListInfo>,
    System.Collections.Generic.IEnumerable<Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax>,
    System.Collections.Generic.IReadOnlyCollection<Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax>,
    System.Collections.Generic.IReadOnlyList<Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; UsingDirectiveListInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[UsingDirectiveListInfo](#_top)>
* System\.Collections\.Generic\.[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)\<[UsingDirectiveSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.usingdirectivesyntax)>
* System\.Collections\.Generic\.[IReadOnlyCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1)\<[UsingDirectiveSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.usingdirectivesyntax)>
* System\.Collections\.Generic\.[IReadOnlyList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)\<[UsingDirectiveSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.usingdirectivesyntax)>

## Indexers

| Indexer | Summary |
| ------- | ------- |
| [Item\[Int32\]](Item/README.md#_top) | Gets the using directive at the specified index in the list\. \(Implements [IReadOnlyList\<UsingDirectiveSyntax>.Item](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1.item)\) |

## Properties

| Property | Summary |
| -------- | ------- |
| [Count](Count/README.md#_top) | A number of usings in the list\. \(Implements [IReadOnlyCollection\<UsingDirectiveSyntax>.Count](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1.count)\) |
| [Parent](Parent/README.md#_top) | The declaration that contains the usings\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |
| [Usings](Usings/README.md#_top) | A list of usings\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Add(UsingDirectiveSyntax)](Add/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the specified using directive added at the end\. |
| [AddRange(IEnumerable\<UsingDirectiveSyntax>)](AddRange/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the specified usings added at the end\. |
| [Any()](Any/README.md#_top) | True if the list has at least one using directive\. |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_UsingDirectiveListInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [Equals(UsingDirectiveListInfo)](Equals/README.md#Roslynator_CSharp_Syntax_UsingDirectiveListInfo_Equals_Roslynator_CSharp_Syntax_UsingDirectiveListInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<UsingDirectiveListInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [First()](First/README.md#_top) | The first using directive in the list\. |
| [FirstOrDefault()](FirstOrDefault/README.md#_top) | The first using directive in the list or null if the list is empty\. |
| [GetEnumerator()](GetEnumerator/README.md#_top) | Gets the enumerator for the list of usings\. |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [IndexOf(Func\<UsingDirectiveSyntax, Boolean>)](IndexOf/README.md#Roslynator_CSharp_Syntax_UsingDirectiveListInfo_IndexOf_System_Func_Microsoft_CodeAnalysis_CSharp_Syntax_UsingDirectiveSyntax_System_Boolean__) | Searches for an using directive that matches the predicate and returns returns zero\-based index of the first occurrence in the list\. |
| [IndexOf(UsingDirectiveSyntax)](IndexOf/README.md#Roslynator_CSharp_Syntax_UsingDirectiveListInfo_IndexOf_Microsoft_CodeAnalysis_CSharp_Syntax_UsingDirectiveSyntax_) | The index of the using directive in the list\. |
| [Insert(Int32, UsingDirectiveSyntax)](Insert/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the specified using directive inserted at the index\. |
| [InsertRange(Int32, IEnumerable\<UsingDirectiveSyntax>)](InsertRange/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the specified usings inserted at the index\. |
| [Last()](Last/README.md#_top) | The last using directive in the list\. |
| [LastIndexOf(Func\<UsingDirectiveSyntax, Boolean>)](LastIndexOf/README.md#Roslynator_CSharp_Syntax_UsingDirectiveListInfo_LastIndexOf_System_Func_Microsoft_CodeAnalysis_CSharp_Syntax_UsingDirectiveSyntax_System_Boolean__) | Searches for an using directive that matches the predicate and returns returns zero\-based index of the last occurrence in the list\. |
| [LastIndexOf(UsingDirectiveSyntax)](LastIndexOf/README.md#Roslynator_CSharp_Syntax_UsingDirectiveListInfo_LastIndexOf_Microsoft_CodeAnalysis_CSharp_Syntax_UsingDirectiveSyntax_) | Searches for an using directive and returns zero\-based index of the last occurrence in the list\. |
| [LastOrDefault()](LastOrDefault/README.md#_top) | The last using directive in the list or null if the list is empty\. |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [Remove(UsingDirectiveSyntax)](Remove/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the specified using directive removed\. |
| [RemoveAt(Int32)](RemoveAt/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the using directive at the specified index removed\. |
| [RemoveNode(SyntaxNode, SyntaxRemoveOptions)](RemoveNode/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the specified node removed\. |
| [Replace(UsingDirectiveSyntax, UsingDirectiveSyntax)](Replace/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the specified using directive replaced with the new using directive\. |
| [ReplaceAt(Int32, UsingDirectiveSyntax)](ReplaceAt/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the using directive at the specified index replaced with a new using directive\. |
| [ReplaceNode(SyntaxNode, SyntaxNode)](ReplaceNode/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the specified old node replaced with a new node\. |
| [ReplaceRange(UsingDirectiveSyntax, IEnumerable\<UsingDirectiveSyntax>)](ReplaceRange/README.md#_top) | Creates a new [UsingDirectiveListInfo](#_top) with the specified using directive replaced with new usings\. |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |
| [WithUsings(IEnumerable\<UsingDirectiveSyntax>)](WithUsings/README.md#Roslynator_CSharp_Syntax_UsingDirectiveListInfo_WithUsings_System_Collections_Generic_IEnumerable_Microsoft_CodeAnalysis_CSharp_Syntax_UsingDirectiveSyntax__) | Creates a new [UsingDirectiveListInfo](#_top) with the usings updated\. |
| [WithUsings(SyntaxList\<UsingDirectiveSyntax>)](WithUsings/README.md#Roslynator_CSharp_Syntax_UsingDirectiveListInfo_WithUsings_Microsoft_CodeAnalysis_SyntaxList_Microsoft_CodeAnalysis_CSharp_Syntax_UsingDirectiveSyntax__) | Creates a new [UsingDirectiveListInfo](#_top) with the usings updated\. |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(UsingDirectiveListInfo, UsingDirectiveListInfo)](op_Equality/README.md#_top) | |
| [Inequality(UsingDirectiveListInfo, UsingDirectiveListInfo)](op_Inequality/README.md#_top) | |

## Explicit Interface Implementations

| Member | Summary |
| ------ | ------- |
| [IEnumerable.GetEnumerator()](System-Collections-IEnumerable-GetEnumerator/README.md#_top) | |
| [IEnumerable\<UsingDirectiveSyntax>.GetEnumerator()](System-Collections-Generic-IEnumerable-Microsoft-CodeAnalysis-CSharp-Syntax-UsingDirectiveSyntax--GetEnumerator/README.md#_top) | |

