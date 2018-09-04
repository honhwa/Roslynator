<a name="_top"></a>

# StatementListInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Indexers](#indexers) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators) &#x2022; [Explicit Interface Implementations](#explicit-interface-implementations)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about a list of statements\.

```csharp
public readonly struct StatementListInfo : System.IEquatable<StatementListInfo>,
    System.Collections.Generic.IEnumerable<Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax>,
    System.Collections.Generic.IReadOnlyCollection<Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax>,
    System.Collections.Generic.IReadOnlyList<Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; StatementListInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[StatementListInfo](#_top)>
* System\.Collections\.Generic\.[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)\<[StatementSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.statementsyntax)>
* System\.Collections\.Generic\.[IReadOnlyCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1)\<[StatementSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.statementsyntax)>
* System\.Collections\.Generic\.[IReadOnlyList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1)\<[StatementSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.statementsyntax)>

## Indexers

| Indexer | Summary |
| ------- | ------- |
| [Item\[Int32\]](Item/README.md#_top) | Gets the statement at the specified index in the list\. \(Implements [IReadOnlyList\<StatementSyntax>.Item](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1.item)\) |

## Properties

| Property | Summary |
| -------- | ------- |
| [Count](Count/README.md#_top) | The number of statement in the list\. \(Implements [IReadOnlyCollection\<StatementSyntax>.Count](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1.count)\) |
| [IsParentBlock](IsParentBlock/README.md#_top) | Determines whether the statements are contained in a [BlockSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.blocksyntax)\. |
| [IsParentSwitchSection](IsParentSwitchSection/README.md#_top) | Determines whether the statements are contained in a [SwitchSectionSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.switchsectionsyntax)\. |
| [Parent](Parent/README.md#_top) | The node that contains the statements\. It can be either a [BlockSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.blocksyntax) or a [SwitchSectionSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.switchsectionsyntax)\. |
| [ParentAsBlock](ParentAsBlock/README.md#_top) | Gets a block that contains the statements\. Returns null if the statements are not contained in a block\. |
| [ParentAsSwitchSection](ParentAsSwitchSection/README.md#_top) | Gets a switch section that contains the statements\. Returns null if the statements are not contained in a switch section\. |
| [Statements](Statements/README.md#_top) | The list of statements\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Add(StatementSyntax)](Add/README.md#_top) | Creates a new [StatementListInfo](#_top) with the specified statement added at the end\. |
| [AddRange(IEnumerable\<StatementSyntax>)](AddRange/README.md#_top) | Creates a new [StatementListInfo](#_top) with the specified statements added at the end\. |
| [Any()](Any/README.md#_top) | True if the list has at least one statement\. |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_StatementListInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [Equals(StatementListInfo)](Equals/README.md#Roslynator_CSharp_Syntax_StatementListInfo_Equals_Roslynator_CSharp_Syntax_StatementListInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<StatementListInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [First()](First/README.md#_top) | The first statement in the list\. |
| [FirstOrDefault()](FirstOrDefault/README.md#_top) | The first statement in the list or null if the list is empty\. |
| [GetEnumerator()](GetEnumerator/README.md#_top) | Gets the enumerator the list of statements\. |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [IndexOf(Func\<StatementSyntax, Boolean>)](IndexOf/README.md#Roslynator_CSharp_Syntax_StatementListInfo_IndexOf_System_Func_Microsoft_CodeAnalysis_CSharp_Syntax_StatementSyntax_System_Boolean__) | Searches for a statement that matches the predicate and returns returns zero\-based index of the first occurrence in the list\. |
| [IndexOf(StatementSyntax)](IndexOf/README.md#Roslynator_CSharp_Syntax_StatementListInfo_IndexOf_Microsoft_CodeAnalysis_CSharp_Syntax_StatementSyntax_) | The index of the statement in the list\. |
| [Insert(Int32, StatementSyntax)](Insert/README.md#_top) | Creates a new [StatementListInfo](#_top) with the specified statement inserted at the index\. |
| [InsertRange(Int32, IEnumerable\<StatementSyntax>)](InsertRange/README.md#_top) | Creates a new [StatementListInfo](#_top) with the specified statements inserted at the index\. |
| [Last()](Last/README.md#_top) | The last statement in the list\. |
| [LastIndexOf(Func\<StatementSyntax, Boolean>)](LastIndexOf/README.md#Roslynator_CSharp_Syntax_StatementListInfo_LastIndexOf_System_Func_Microsoft_CodeAnalysis_CSharp_Syntax_StatementSyntax_System_Boolean__) | Searches for a statement that matches the predicate and returns returns zero\-based index of the last occurrence in the list\. |
| [LastIndexOf(StatementSyntax)](LastIndexOf/README.md#Roslynator_CSharp_Syntax_StatementListInfo_LastIndexOf_Microsoft_CodeAnalysis_CSharp_Syntax_StatementSyntax_) | Searches for a statement and returns zero\-based index of the last occurrence in the list\. |
| [LastOrDefault()](LastOrDefault/README.md#_top) | The last statement in the list or null if the list is empty\. |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [Remove(StatementSyntax)](Remove/README.md#_top) | Creates a new [StatementListInfo](#_top) with the specified statement removed\. |
| [RemoveAt(Int32)](RemoveAt/README.md#_top) | Creates a new [StatementListInfo](#_top) with the statement at the specified index removed\. |
| [RemoveNode(SyntaxNode, SyntaxRemoveOptions)](RemoveNode/README.md#_top) | Creates a new [StatementListInfo](#_top) with the specified node removed\. |
| [Replace(StatementSyntax, StatementSyntax)](Replace/README.md#_top) | Creates a new [StatementListInfo](#_top) with the specified statement replaced with the new statement\. |
| [ReplaceAt(Int32, StatementSyntax)](ReplaceAt/README.md#_top) | Creates a new [StatementListInfo](#_top) with the statement at the specified index replaced with a new statement\. |
| [ReplaceNode(SyntaxNode, SyntaxNode)](ReplaceNode/README.md#_top) | Creates a new [StatementListInfo](#_top) with the specified old node replaced with a new node\. |
| [ReplaceRange(StatementSyntax, IEnumerable\<StatementSyntax>)](ReplaceRange/README.md#_top) | Creates a new [StatementListInfo](#_top) with the specified statement replaced with new statements\. |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |
| [WithStatements(IEnumerable\<StatementSyntax>)](WithStatements/README.md#Roslynator_CSharp_Syntax_StatementListInfo_WithStatements_System_Collections_Generic_IEnumerable_Microsoft_CodeAnalysis_CSharp_Syntax_StatementSyntax__) | Creates a new [StatementListInfo](#_top) with the statements updated\. |
| [WithStatements(SyntaxList\<StatementSyntax>)](WithStatements/README.md#Roslynator_CSharp_Syntax_StatementListInfo_WithStatements_Microsoft_CodeAnalysis_SyntaxList_Microsoft_CodeAnalysis_CSharp_Syntax_StatementSyntax__) | Creates a new [StatementListInfo](#_top) with the statements updated\. |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(StatementListInfo, StatementListInfo)](op_Equality/README.md#_top) | |
| [Inequality(StatementListInfo, StatementListInfo)](op_Inequality/README.md#_top) | |

## Explicit Interface Implementations

| Member | Summary |
| ------ | ------- |
| [IEnumerable.GetEnumerator()](System-Collections-IEnumerable-GetEnumerator/README.md#_top) | |
| [IEnumerable\<StatementSyntax>.GetEnumerator()](System-Collections-Generic-IEnumerable-Microsoft-CodeAnalysis-CSharp-Syntax-StatementSyntax--GetEnumerator/README.md#_top) | |

