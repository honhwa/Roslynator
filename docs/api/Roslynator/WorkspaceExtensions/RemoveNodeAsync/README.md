<a name="_top"></a>

# WorkspaceExtensions\.RemoveNodeAsync\(Document, SyntaxNode, SyntaxRemoveOptions, CancellationToken\) Method

[Home](../../../README.md#_top)

**Containing Type**: Roslynator\.[WorkspaceExtensions](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.Workspaces\.dll

## Summary

Creates a new document with the specified node removed\.

```csharp
public static Task<Document> RemoveNodeAsync(this Document document, SyntaxNode node, SyntaxRemoveOptions options, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**node**

**options**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

