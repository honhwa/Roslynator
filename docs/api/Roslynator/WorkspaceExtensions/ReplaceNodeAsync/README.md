# WorkspaceExtensions\.ReplaceNodeAsync Method

**Namespace**: [Roslynator](../../README.md)

**Assembly**: Roslynator\.CSharp\.Workspaces\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [ReplaceNodeAsync(Document, SyntaxNode, IEnumerable\<SyntaxNode>, CancellationToken)](#Roslynator_WorkspaceExtensions_ReplaceNodeAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_SyntaxNode_System_Collections_Generic_IEnumerable_Microsoft_CodeAnalysis_SyntaxNode__System_Threading_CancellationToken_) | Creates a new document with the specified old node replaced with new nodes\. |
| [ReplaceNodeAsync(Document, SyntaxNode, SyntaxNode, CancellationToken)](#Roslynator_WorkspaceExtensions_ReplaceNodeAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_SyntaxNode_Microsoft_CodeAnalysis_SyntaxNode_System_Threading_CancellationToken_) | Creates a new document with the specified old node replaced with a new node\. |
| [ReplaceNodeAsync\<TNode>(Solution, TNode, TNode, CancellationToken)](../ReplaceNodeAsync-1/README.md#Roslynator_WorkspaceExtensions_ReplaceNodeAsync__1_Microsoft_CodeAnalysis_Solution___0___0_System_Threading_CancellationToken_) | Creates a new solution with the specified old node replaced with a new node\. |

## ReplaceNodeAsync\(Document, SyntaxNode, IEnumerable\<SyntaxNode>, CancellationToken\)<a name="Roslynator_WorkspaceExtensions_ReplaceNodeAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_SyntaxNode_System_Collections_Generic_IEnumerable_Microsoft_CodeAnalysis_SyntaxNode__System_Threading_CancellationToken_"></a>

### Summary

Creates a new document with the specified old node replaced with new nodes\.

```csharp
public static Task<Document> ReplaceNodeAsync(this Document document, SyntaxNode oldNode, IEnumerable<SyntaxNode> newNodes, CancellationToken cancellationToken = default(CancellationToken))
```

#### Parameters

| Name | Summary |
| ---- | ------- |
| document | |
| oldNode | |
| newNodes | |
| cancellationToken | |

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

## ReplaceNodeAsync\(Document, SyntaxNode, SyntaxNode, CancellationToken\)<a name="Roslynator_WorkspaceExtensions_ReplaceNodeAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_SyntaxNode_Microsoft_CodeAnalysis_SyntaxNode_System_Threading_CancellationToken_"></a>

### Summary

Creates a new document with the specified old node replaced with a new node\.

```csharp
public static Task<Document> ReplaceNodeAsync(this Document document, SyntaxNode oldNode, SyntaxNode newNode, CancellationToken cancellationToken = default(CancellationToken))
```

#### Parameters

| Name | Summary |
| ---- | ------- |
| document | |
| oldNode | |
| newNode | |
| cancellationToken | |

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

## ReplaceNodeAsync\<TNode>\(Solution, TNode, TNode, CancellationToken\)<a name="Roslynator_WorkspaceExtensions_ReplaceNodeAsync__1_Microsoft_CodeAnalysis_Solution___0___0_System_Threading_CancellationToken_"></a>

### Summary

Creates a new solution with the specified old node replaced with a new node\.

```csharp
public static Task<Solution> ReplaceNodeAsync<TNode>(this Solution solution, TNode oldNode, TNode newNode, CancellationToken cancellationToken = default(CancellationToken)) where TNode : Microsoft.CodeAnalysis.SyntaxNode
```

#### Type Parameters

| Name | Summary |
| ---- | ------- |
| TNode | |

#### Parameters

| Name | Summary |
| ---- | ------- |
| solution | |
| oldNode | |
| newNode | |
| cancellationToken | |

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Solution](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.solution)>
