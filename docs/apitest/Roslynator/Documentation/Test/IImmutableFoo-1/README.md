<a name="_top"></a>

# IImmutableFoo\<T> Interface

[Home](../../../../README.md#_top) &#x2022; [Indexers](#indexers) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods)

**Namespace**: [Roslynator.Documentation.Test](../README.md#_top)

**Assembly**: Roslynator\.Documentation\.TestProject\.dll

```csharp
public interface IImmutableFoo<T> : System.IEquatable<IImmutableFoo<T>>,
    System.Collections.ICollection,
    System.Collections.IList,
    System.Collections.IStructuralComparable,
    System.Collections.IStructuralEquatable,
    System.Collections.Generic.ICollection<T>,
    System.Collections.Generic.IEnumerable<T>,
    System.Collections.Generic.IList<T>,
    System.Collections.Generic.IReadOnlyCollection<T>,
    System.Collections.Generic.IReadOnlyList<T>,
    System.Collections.Immutable.IImmutableList<T>
```

### Type Parameters

**T**

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[IImmutableFoo\<T>](#_top)>
* System\.Collections\.[ICollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection)
* System\.Collections\.[IList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist)
* System\.Collections\.[IStructuralComparable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralcomparable)
* System\.Collections\.[IStructuralEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralequatable)
* System\.Collections\.Generic\.[ICollection\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)
* System\.Collections\.Generic\.[IEnumerable\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)
* System\.Collections\.Generic\.[IList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1)
* System\.Collections\.Generic\.[IReadOnlyCollection\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1)
* System\.Collections\.Generic\.[IReadOnlyList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)
* System\.Collections\.Immutable\.[IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)

## Indexers

| Indexer | Summary |
| ------- | ------- |
| [Item\[Int32\]](Item/README.md#_top) | |

## Properties

| Property | Summary |
| -------- | ------- |
| [Count](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.count) |  \(Inherited from [ICollection\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)\) |
| [IsFixedSize](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist.isfixedsize) |  \(Inherited from [IList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist)\) |
| [IsReadOnly](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.isreadonly) |  \(Inherited from [ICollection\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)\) |
| [IsSynchronized](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection.issynchronized) |  \(Inherited from [ICollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection)\) |
| [SyncRoot](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection.syncroot) |  \(Inherited from [ICollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection)\) |

## Methods

| Method | Summary |
| ------ | ------- |
| [Add(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist.add) |  \(Inherited from [IList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist)\) |
| [Add(T)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.add) |  \(Inherited from [ICollection\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)\) |
| [AddRange(IEnumerable\<T>)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.addrange) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |
| [Clear()](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.clear) |  \(Inherited from [ICollection\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)\) |
| [CompareTo(Object, IComparer)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralcomparable.compareto) |  \(Inherited from [IStructuralComparable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralcomparable)\) |
| [Contains(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist.contains) |  \(Inherited from [IList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist)\) |
| [Contains(T)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.contains) |  \(Inherited from [ICollection\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)\) |
| [CopyTo(Array, Int32)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection.copyto) |  \(Inherited from [ICollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection)\) |
| [CopyTo(T\[\], Int32)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.copyto) |  \(Inherited from [ICollection\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)\) |
| [Equals(IImmutableFoo\<T>)](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals) |  \(Inherited from [IEquatable\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\) |
| [Equals(Object, IEqualityComparer)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralequatable.equals) |  \(Inherited from [IStructuralEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralequatable)\) |
| [GetEnumerator()](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1.getenumerator) |  \(Inherited from [IEnumerable\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)\) |
| [GetHashCode(IEqualityComparer)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralequatable.gethashcode) |  \(Inherited from [IStructuralEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.istructuralequatable)\) |
| [IndexOf(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist.indexof) |  \(Inherited from [IList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist)\) |
| [IndexOf(T)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1.indexof) |  \(Inherited from [IList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1)\) |
| [IndexOf(T, Int32, Int32, IEqualityComparer\<T>)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.indexof) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |
| [Insert(Int32, Object)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist.insert) |  \(Inherited from [IList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist)\) |
| [Insert(Int32, T)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1.insert) |  \(Inherited from [IList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1)\) |
| [InsertRange(Int32, IEnumerable\<T>)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.insertrange) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |
| [LastIndexOf(T, Int32, Int32, IEqualityComparer\<T>)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.lastindexof) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |
| [Remove(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist.remove) |  \(Inherited from [IList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist)\) |
| [Remove(T)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.remove) |  \(Inherited from [ICollection\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)\) |
| [Remove(T, IEqualityComparer\<T>)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.remove) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |
| [RemoveAll(Predicate\<T>)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.removeall) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |
| [RemoveAt(Int32)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1.removeat) |  \(Inherited from [IList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1)\) |
| [RemoveRange(IEnumerable\<T>, IEqualityComparer\<T>)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.removerange) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |
| [RemoveRange(Int32, Int32)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.removerange) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |
| [Replace(T, T, IEqualityComparer\<T>)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.replace) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |
| [SetItem(Int32, T)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1.setitem) |  \(Inherited from [IImmutableList\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.immutable.iimmutablelist-1)\) |

