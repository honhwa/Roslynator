<a name="_top"></a>

# TextLineCollectionSelection Class

[Home](../../../README.md#_top) &#x2022; [Constructors](#constructors) &#x2022; [Indexers](#indexers) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Explicit Interface Implementations](#explicit-interface-implementations) &#x2022; [Structs](#structs)

**Namespace**: [Roslynator.Text](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Represents selected lines in a [TextLineCollection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.text.textlinecollection)\.

```csharp
public class TextLineCollectionSelection : Roslynator.ISelection<Microsoft.CodeAnalysis.Text.TextLine>,
    System.Collections.Generic.IEnumerable<Microsoft.CodeAnalysis.Text.TextLine>,
    System.Collections.Generic.IReadOnlyCollection<Microsoft.CodeAnalysis.Text.TextLine>,
    System.Collections.Generic.IReadOnlyList<Microsoft.CodeAnalysis.Text.TextLine>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; TextLineCollectionSelection

### Implements

* System\.Collections\.Generic\.[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)\<[TextLine](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.text.textline)>
* System\.Collections\.Generic\.[IReadOnlyCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1)\<[TextLine](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.text.textline)>
* System\.Collections\.Generic\.[IReadOnlyList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)\<[TextLine](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.text.textline)>
* Roslynator\.[ISelection](../../ISelection-1/README.md#_top)\<[TextLine](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.text.textline)>

## Constructors

| Constructor | Summary |
| ----------- | ------- |
| [TextLineCollectionSelection(TextLineCollection, TextSpan, Int32, Int32)](-ctor/README.md#_top) | |

## Indexers

| Indexer | Summary |
| ------- | ------- |
| [Item\[Int32\]](Item/README.md#_top) | Gets the selected line at the specified index\. \(Implements [IReadOnlyList\<TextLine>.Item](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1.item)\) |

## Properties

| Property | Summary |
| -------- | ------- |
| [Count](Count/README.md#_top) | Gets a number of selected lines\. \(Implements [IReadOnlyCollection\<TextLine>.Count](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1.count)\) |
| [FirstIndex](FirstIndex/README.md#_top) | Gets an index of the first selected line\. \(Implements [ISelection\<TextLine>.FirstIndex](../../ISelection-1/FirstIndex/README.md#_top)\) |
| [LastIndex](LastIndex/README.md#_top) | Gets an index of the last selected line\. \(Implements [ISelection\<TextLine>.LastIndex](../../ISelection-1/LastIndex/README.md#_top)\) |
| [OriginalSpan](OriginalSpan/README.md#_top) | Gets the original span that was used to determine selected lines\. |
| [UnderlyingLines](UnderlyingLines/README.md#_top) | Gets an underlying collection that contains selected lines\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Create(TextLineCollection, TextSpan)](Create/README.md#_top) | Creates a new [TextLineCollectionSelection](#_top) based on the specified list and span\. |
| [Equals(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [First()](First/README.md#_top) | Gets the first selected line\. \(Implements [ISelection\<TextLine>.First](../../ISelection-1/First/README.md#_top)\) |
| [GetEnumerator()](GetEnumerator/README.md#_top) | Returns an enumerator that iterates through selected lines\. |
| [GetHashCode()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [Last()](Last/README.md#_top) | Gets the last selected line\. \(Implements [ISelection\<TextLine>.Last](../../ISelection-1/Last/README.md#_top)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [TryCreate(TextLineCollection, TextSpan, TextLineCollectionSelection)](TryCreate/README.md#_top) | Creates a new [TextLineCollectionSelection](#_top) based on the specified list and span\. |

## Explicit Interface Implementations

| Member | Summary |
| ------ | ------- |
| [IEnumerable.GetEnumerator()](System-Collections-IEnumerable-GetEnumerator/README.md#_top) | |
| [IEnumerable\<TextLine>.GetEnumerator()](System-Collections-Generic-IEnumerable-Microsoft-CodeAnalysis-Text-TextLine--GetEnumerator/README.md#_top) | |

## Structs

| Struct | Summary |
| ------ | ------- |
| [Enumerator](Enumerator/README.md#_top) | |

