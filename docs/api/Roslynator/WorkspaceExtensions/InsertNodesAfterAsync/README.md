<a name="_top"></a>

# WorkspaceExtensions\.InsertNodesAfterAsync\(Document, SyntaxNode, IEnumerable\<SyntaxNode>, CancellationToken\) Method

[Home](../../../README.md#_top)

**Containing Type**: Roslynator\.[WorkspaceExtensions](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.Workspaces\.dll

## Summary

Creates a new document with new nodes inserted after the specified node\.

```csharp
public static Task<Document> InsertNodesAfterAsync(this Document document, SyntaxNode nodeInList, IEnumerable<SyntaxNode> newNodes, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**nodeInList**

**newNodes**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

