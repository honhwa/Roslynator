<a name="_top"></a>

# WorkspaceExtensions\.ReplaceNodesAsync Method

[Home](../../../README.md#_top)

**Containing Type**: Roslynator\.[WorkspaceExtensions](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.Workspaces\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [ReplaceNodesAsync\<TNode>(Document, IEnumerable\<TNode>, Func\<TNode, TNode, SyntaxNode>, CancellationToken)](#Roslynator_WorkspaceExtensions_ReplaceNodesAsync__1_Microsoft_CodeAnalysis_Document_System_Collections_Generic_IEnumerable___0__System_Func___0___0_Microsoft_CodeAnalysis_SyntaxNode__System_Threading_CancellationToken_) | Creates a new document with the specified old nodes replaced with new nodes\. |
| [ReplaceNodesAsync\<TNode>(Solution, IEnumerable\<TNode>, Func\<TNode, TNode, SyntaxNode>, CancellationToken)](#Roslynator_WorkspaceExtensions_ReplaceNodesAsync__1_Microsoft_CodeAnalysis_Solution_System_Collections_Generic_IEnumerable___0__System_Func___0___0_Microsoft_CodeAnalysis_SyntaxNode__System_Threading_CancellationToken_) | Creates a new solution with the specified old nodes replaced with new nodes\. |

## ReplaceNodesAsync\<TNode>\(Document, IEnumerable\<TNode>, Func\<TNode, TNode, SyntaxNode>, CancellationToken\) <a name="Roslynator_WorkspaceExtensions_ReplaceNodesAsync__1_Microsoft_CodeAnalysis_Document_System_Collections_Generic_IEnumerable___0__System_Func___0___0_Microsoft_CodeAnalysis_SyntaxNode__System_Threading_CancellationToken_"></a>

### Summary

Creates a new document with the specified old nodes replaced with new nodes\.

```csharp
public static Task<Document> ReplaceNodesAsync<TNode>(this Document document, IEnumerable<TNode> nodes, Func<TNode, TNode, SyntaxNode> computeReplacementNode, CancellationToken cancellationToken = default(CancellationToken)) where TNode : Microsoft.CodeAnalysis.SyntaxNode
```

### Type Parameters

**TNode**

### Parameters

**document**

**nodes**

**computeReplacementNode**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

## ReplaceNodesAsync\<TNode>\(Solution, IEnumerable\<TNode>, Func\<TNode, TNode, SyntaxNode>, CancellationToken\) <a name="Roslynator_WorkspaceExtensions_ReplaceNodesAsync__1_Microsoft_CodeAnalysis_Solution_System_Collections_Generic_IEnumerable___0__System_Func___0___0_Microsoft_CodeAnalysis_SyntaxNode__System_Threading_CancellationToken_"></a>

### Summary

Creates a new solution with the specified old nodes replaced with new nodes\.

```csharp
public static Task<Solution> ReplaceNodesAsync<TNode>(this Solution solution, IEnumerable<TNode> nodes, Func<TNode, TNode, SyntaxNode> computeReplacementNodes, CancellationToken cancellationToken = default(CancellationToken)) where TNode : Microsoft.CodeAnalysis.SyntaxNode
```

### Type Parameters

**TNode**

### Parameters

**solution**

**nodes**

**computeReplacementNodes**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Solution](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.solution)>

