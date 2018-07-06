# TextLineCollectionSelection Class

Namespace: [Roslynator.Text](../README.md)

Assembly: Roslynator\.CSharp\.dll

## Summary

Represents selected lines in a [TextLineCollection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.text.textlinecollection)\.

```csharp
class TextLineCollectionSelection
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [Selection\<T>](../../Selection-1/README.md) &#x2192; TextLineCollectionSelection

### Implements

* [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)\<[TextLine](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.text.textline)>
* [IReadOnlyCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1)\<[TextLine](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.text.textline)>
* [IReadOnlyList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)\<[TextLine](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.text.textline)>

## Constructors

| Constructor | Summary |
| ----------- | ------- |
| [TextLineCollectionSelection(TextLineCollection, TextSpan, Int32, Int32)](-ctor/README.md) | |

## Properties

| Property | Summary |
| -------- | ------- |
| [Count](../../Selection-1/Count/README.md) |  \(Inherited from [Selection\<T>](../../Selection-1/README.md)\) |
| [FirstIndex](../../Selection-1/FirstIndex/README.md) |  \(Inherited from [Selection\<T>](../../Selection-1/README.md)\) |
| [Item\[Int32\]](../../Selection-1/Item/README.md) |  \(Inherited from [Selection\<T>](../../Selection-1/README.md)\) |
| [Items](Items/README.md) | Gets an underlying collection that contains selected lines\. |
| [LastIndex](../../Selection-1/LastIndex/README.md) |  \(Inherited from [Selection\<T>](../../Selection-1/README.md)\) |
| [OriginalSpan](../../Selection-1/OriginalSpan/README.md) |  \(Inherited from [Selection\<T>](../../Selection-1/README.md)\) |
| [UnderlyingLines](UnderlyingLines/README.md) | Gets an underlying collection that contains selected lines\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Create(TextLineCollection, TextSpan)](Create/README.md) | Creates a new [TextLineCollectionSelection](./README.md) based on the specified list and span\. |
| [Equals(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [First()](../../Selection-1/First/README.md) |  \(Inherited from [Selection\<T>](../../Selection-1/README.md)\) |
| [GetEnumerator()](GetEnumerator/README.md) | Returns an enumerator that iterates through selected items\. |
| [GetEnumeratorCore()](GetEnumeratorCore/README.md) | |
| [GetHashCode()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [Last()](../../Selection-1/Last/README.md) |  \(Inherited from [Selection\<T>](../../Selection-1/README.md)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [TryCreate(TextLineCollection, TextSpan, TextLineCollectionSelection)](TryCreate/README.md) | Creates a new [TextLineCollectionSelection](./README.md) based on the specified list and span\. |
