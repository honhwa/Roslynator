<a name="_top"></a>

# WorkspaceExtensions\.RemoveCommentsAsync Method

[Home](../../../../README.md#_top)

**Containing Type**: Roslynator\.CSharp\.[WorkspaceExtensions](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.Workspaces\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [RemoveCommentsAsync(Document, CommentKinds, CancellationToken)](#Roslynator_CSharp_WorkspaceExtensions_RemoveCommentsAsync_Microsoft_CodeAnalysis_Document_Roslynator_CSharp_CommentKinds_System_Threading_CancellationToken_) | Creates a new document with comments of the specified kind removed\. |
| [RemoveCommentsAsync(Document, TextSpan, CommentKinds, CancellationToken)](#Roslynator_CSharp_WorkspaceExtensions_RemoveCommentsAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_Text_TextSpan_Roslynator_CSharp_CommentKinds_System_Threading_CancellationToken_) | Creates a new document with comments of the specified kind removed\. |

## RemoveCommentsAsync\(Document, CommentKinds, CancellationToken\) <a name="Roslynator_CSharp_WorkspaceExtensions_RemoveCommentsAsync_Microsoft_CodeAnalysis_Document_Roslynator_CSharp_CommentKinds_System_Threading_CancellationToken_"></a>

### Summary

Creates a new document with comments of the specified kind removed\.

```csharp
public static Task<Document> RemoveCommentsAsync(this Document document, CommentKinds kinds, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**kinds**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

## RemoveCommentsAsync\(Document, TextSpan, CommentKinds, CancellationToken\) <a name="Roslynator_CSharp_WorkspaceExtensions_RemoveCommentsAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_Text_TextSpan_Roslynator_CSharp_CommentKinds_System_Threading_CancellationToken_"></a>

### Summary

Creates a new document with comments of the specified kind removed\.

```csharp
public static Task<Document> RemoveCommentsAsync(this Document document, TextSpan span, CommentKinds kinds, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**span**

**kinds**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

