<a name="_top"></a>

# MemberDeclarationListSelection Class

[Home](../../../README.md#_top) &#x2022; [Indexers](#indexers) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods)

**Namespace**: [Roslynator.CSharp](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Represents selected member declarations in a [SyntaxList\<TNode>](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.syntaxlist-1)\.

```csharp
public sealed class MemberDeclarationListSelection : Roslynator.SyntaxListSelection<Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top) &#x2192; MemberDeclarationListSelection

### Implements

* System\.Collections\.Generic\.[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)\<[MemberDeclarationSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.memberdeclarationsyntax)>
* System\.Collections\.Generic\.[IReadOnlyCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1)\<[MemberDeclarationSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.memberdeclarationsyntax)>
* System\.Collections\.Generic\.[IReadOnlyList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)\<[MemberDeclarationSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.memberdeclarationsyntax)>
* Roslynator\.[ISelection](../../ISelection-1/README.md#_top)\<[MemberDeclarationSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.memberdeclarationsyntax)>

## Indexers

| Indexer | Summary |
| ------- | ------- |
| [Item\[Int32\]](../../SyntaxListSelection-1/Item/README.md#_top) | Gets the selected node at the specified index\. \(Inherited from [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top)\) |

## Properties

| Property | Summary |
| -------- | ------- |
| [Count](../../SyntaxListSelection-1/Count/README.md#_top) | Gets a number of selected nodes\. \(Inherited from [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top)\) |
| [FirstIndex](../../SyntaxListSelection-1/FirstIndex/README.md#_top) | Gets an index of the first selected node\. \(Inherited from [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top)\) |
| [LastIndex](../../SyntaxListSelection-1/LastIndex/README.md#_top) | Gets an index of the last selected node\. \(Inherited from [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top)\) |
| [OriginalSpan](../../SyntaxListSelection-1/OriginalSpan/README.md#_top) | Gets the original span that was used to determine selected nodes\. \(Inherited from [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top)\) |
| [Parent](Parent/README.md#_top) | Gets a node that contains selected members\. |
| [UnderlyingList](../../SyntaxListSelection-1/UnderlyingList/README.md#_top) | Gets an underlying list that contains selected nodes\. \(Inherited from [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top)\) |

## Methods

| Method | Summary |
| ------ | ------- |
| [Create(CompilationUnitSyntax, TextSpan)](Create/README.md#Roslynator_CSharp_MemberDeclarationListSelection_Create_Microsoft_CodeAnalysis_CSharp_Syntax_CompilationUnitSyntax_Microsoft_CodeAnalysis_Text_TextSpan_) | Creates a new [MemberDeclarationListSelection](#_top) based on the specified compilation unit and span\. |
| [Create(NamespaceDeclarationSyntax, TextSpan)](Create/README.md#Roslynator_CSharp_MemberDeclarationListSelection_Create_Microsoft_CodeAnalysis_CSharp_Syntax_NamespaceDeclarationSyntax_Microsoft_CodeAnalysis_Text_TextSpan_) | Creates a new [MemberDeclarationListSelection](#_top) based on the specified namespace declaration and span\. |
| [Create(TypeDeclarationSyntax, TextSpan)](Create/README.md#Roslynator_CSharp_MemberDeclarationListSelection_Create_Microsoft_CodeAnalysis_CSharp_Syntax_TypeDeclarationSyntax_Microsoft_CodeAnalysis_Text_TextSpan_) | Creates a new [MemberDeclarationListSelection](#_top) based on the specified type declaration and span\. |
| [Equals(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [First()](../../SyntaxListSelection-1/First/README.md#_top) | Gets the first selected node\. \(Inherited from [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top)\) |
| [GetEnumerator()](../../SyntaxListSelection-1/GetEnumerator/README.md#_top) | Returns an enumerator that iterates through selected nodes\. \(Inherited from [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top)\) |
| [GetHashCode()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [Last()](../../SyntaxListSelection-1/Last/README.md#_top) | Gets the last selected node\. \(Inherited from [SyntaxListSelection\<TNode>](../../SyntaxListSelection-1/README.md#_top)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [TryCreate(NamespaceDeclarationSyntax, TextSpan, MemberDeclarationListSelection)](TryCreate/README.md#Roslynator_CSharp_MemberDeclarationListSelection_TryCreate_Microsoft_CodeAnalysis_CSharp_Syntax_NamespaceDeclarationSyntax_Microsoft_CodeAnalysis_Text_TextSpan_Roslynator_CSharp_MemberDeclarationListSelection__) | Creates a new [MemberDeclarationListSelection](#_top) based on the specified namespace declaration and span\. |
| [TryCreate(TypeDeclarationSyntax, TextSpan, MemberDeclarationListSelection)](TryCreate/README.md#Roslynator_CSharp_MemberDeclarationListSelection_TryCreate_Microsoft_CodeAnalysis_CSharp_Syntax_TypeDeclarationSyntax_Microsoft_CodeAnalysis_Text_TextSpan_Roslynator_CSharp_MemberDeclarationListSelection__) | Creates a new [MemberDeclarationListSelection](#_top) based on the specified type declaration and span\. |

