<a name="_top"></a>

# WorkspaceExtensions\.WithTextChangesAsync Method

[Home](../../../README.md#_top)

**Containing Type**: Roslynator\.[WorkspaceExtensions](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.Workspaces\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [WithTextChangesAsync(Document, IEnumerable\<TextChange>, CancellationToken)](#Roslynator_WorkspaceExtensions_WithTextChangesAsync_Microsoft_CodeAnalysis_Document_System_Collections_Generic_IEnumerable_Microsoft_CodeAnalysis_Text_TextChange__System_Threading_CancellationToken_) | Creates a new document updated with the specified text changes\. |
| [WithTextChangesAsync(Document, TextChange\[\], CancellationToken)](#Roslynator_WorkspaceExtensions_WithTextChangesAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_Text_TextChange___System_Threading_CancellationToken_) | Creates a new document updated with the specified text changes\. |

## WithTextChangesAsync\(Document, IEnumerable\<TextChange>, CancellationToken\) <a name="Roslynator_WorkspaceExtensions_WithTextChangesAsync_Microsoft_CodeAnalysis_Document_System_Collections_Generic_IEnumerable_Microsoft_CodeAnalysis_Text_TextChange__System_Threading_CancellationToken_"></a>

### Summary

Creates a new document updated with the specified text changes\.

```csharp
public static Task<Document> WithTextChangesAsync(this Document document, IEnumerable<TextChange> textChanges, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**textChanges**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

## WithTextChangesAsync\(Document, TextChange\[\], CancellationToken\) <a name="Roslynator_WorkspaceExtensions_WithTextChangesAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_Text_TextChange___System_Threading_CancellationToken_"></a>

### Summary

Creates a new document updated with the specified text changes\.

```csharp
public static Task<Document> WithTextChangesAsync(this Document document, TextChange[] textChanges, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**textChanges**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

