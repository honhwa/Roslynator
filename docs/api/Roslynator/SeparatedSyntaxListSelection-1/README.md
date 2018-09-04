<a name="_top"></a>

# SeparatedSyntaxListSelection\<TNode> Class

[Home](../../README.md#_top) &#x2022; [Constructors](#constructors) &#x2022; [Indexers](#indexers) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Explicit Interface Implementations](#explicit-interface-implementations) &#x2022; [Structs](#structs)

**Namespace**: [Roslynator](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Represents selected nodes in a [SeparatedSyntaxList\<TNode>](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.separatedsyntaxlist-1)\.

```csharp
public class SeparatedSyntaxListSelection<TNode> : ISelection<TNode>,
    System.Collections.Generic.IEnumerable<TNode>,
    System.Collections.Generic.IReadOnlyCollection<TNode>,
    System.Collections.Generic.IReadOnlyList<TNode>
    where TNode : Microsoft.CodeAnalysis.SyntaxNode
```

### Type Parameters

**TNode**

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; SeparatedSyntaxListSelection\<TNode>

### Implements

* System\.Collections\.Generic\.[IEnumerable\<TNode>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)
* System\.Collections\.Generic\.[IReadOnlyCollection\<TNode>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1)
* System\.Collections\.Generic\.[IReadOnlyList\<TNode>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)
* Roslynator\.[ISelection\<TNode>](../ISelection-1/README.md#_top)

## Constructors

| Constructor | Summary |
| ----------- | ------- |
| [SeparatedSyntaxListSelection(SeparatedSyntaxList\<TNode>, TextSpan, Int32, Int32)](-ctor/README.md#_top) | Initializes a new instance of the [SeparatedSyntaxListSelection\<TNode>](#_top)\. |

## Indexers

| Indexer | Summary |
| ------- | ------- |
| [Item\[Int32\]](Item/README.md#_top) | Gets the selected node at the specified index\. \(Implements [IReadOnlyList\<TNode>.Item](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1.item)\) |

## Properties

| Property | Summary |
| -------- | ------- |
| [Count](Count/README.md#_top) | Gets a number of selected nodes\. \(Implements [IReadOnlyCollection\<TNode>.Count](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1.count)\) |
| [FirstIndex](FirstIndex/README.md#_top) | Gets an index of the first selected node\. \(Implements [ISelection\<TNode>.FirstIndex](../ISelection-1/FirstIndex/README.md#_top)\) |
| [LastIndex](LastIndex/README.md#_top) | Gets an index of the last selected node\. \(Implements [ISelection\<TNode>.LastIndex](../ISelection-1/LastIndex/README.md#_top)\) |
| [OriginalSpan](OriginalSpan/README.md#_top) | Gets the original span that was used to determine selected nodes\. |
| [UnderlyingList](UnderlyingList/README.md#_top) | Gets an underlying list that contains selected nodes\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Create(SeparatedSyntaxList\<TNode>, TextSpan)](Create/README.md#_top) | Creates a new [SeparatedSyntaxListSelection\<TNode>](#_top) based on the specified list and span\. |
| [Equals(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [First()](First/README.md#_top) | Gets the first selected node\. \(Implements [ISelection\<TNode>.First](../ISelection-1/First/README.md#_top)\) |
| [GetEnumerator()](GetEnumerator/README.md#_top) | Returns an enumerator that iterates through selected nodes\. |
| [GetHashCode()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [Last()](Last/README.md#_top) | Gets the last selected node\. \(Implements [ISelection\<TNode>.Last](../ISelection-1/Last/README.md#_top)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [TryCreate(SeparatedSyntaxList\<TNode>, TextSpan, SeparatedSyntaxListSelection\<TNode>)](TryCreate/README.md#_top) | Creates a new [SeparatedSyntaxListSelection\<TNode>](#_top) based on the specified list and span\. |

## Explicit Interface Implementations

| Member | Summary |
| ------ | ------- |
| [IEnumerable.GetEnumerator()](System-Collections-IEnumerable-GetEnumerator/README.md#_top) | |
| [IEnumerable\<TNode>.GetEnumerator()](System-Collections-Generic-IEnumerable-TNode--GetEnumerator/README.md#_top) | |

## Structs

| Struct | Summary |
| ------ | ------- |
| [Enumerator](Enumerator/README.md#_top) | |

