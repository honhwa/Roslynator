<a name="_top"></a>

# WorkspaceExtensions\.RemovePreprocessorDirectivesAsync Method

[Home](../../../../README.md#_top)

**Containing Type**: Roslynator\.CSharp\.[WorkspaceExtensions](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.Workspaces\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [RemovePreprocessorDirectivesAsync(Document, PreprocessorDirectiveKinds, CancellationToken)](#Roslynator_CSharp_WorkspaceExtensions_RemovePreprocessorDirectivesAsync_Microsoft_CodeAnalysis_Document_Roslynator_CSharp_PreprocessorDirectiveKinds_System_Threading_CancellationToken_) | Creates a new document with preprocessor directives of the specified kind removed\. |
| [RemovePreprocessorDirectivesAsync(Document, TextSpan, PreprocessorDirectiveKinds, CancellationToken)](#Roslynator_CSharp_WorkspaceExtensions_RemovePreprocessorDirectivesAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_Text_TextSpan_Roslynator_CSharp_PreprocessorDirectiveKinds_System_Threading_CancellationToken_) | Creates a new document with preprocessor directives of the specified kind removed\. |

## RemovePreprocessorDirectivesAsync\(Document, PreprocessorDirectiveKinds, CancellationToken\) <a name="Roslynator_CSharp_WorkspaceExtensions_RemovePreprocessorDirectivesAsync_Microsoft_CodeAnalysis_Document_Roslynator_CSharp_PreprocessorDirectiveKinds_System_Threading_CancellationToken_"></a>

### Summary

Creates a new document with preprocessor directives of the specified kind removed\.

```csharp
public static Task<Document> RemovePreprocessorDirectivesAsync(this Document document, PreprocessorDirectiveKinds directiveKinds, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**directiveKinds**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

## RemovePreprocessorDirectivesAsync\(Document, TextSpan, PreprocessorDirectiveKinds, CancellationToken\) <a name="Roslynator_CSharp_WorkspaceExtensions_RemovePreprocessorDirectivesAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_Text_TextSpan_Roslynator_CSharp_PreprocessorDirectiveKinds_System_Threading_CancellationToken_"></a>

### Summary

Creates a new document with preprocessor directives of the specified kind removed\.

```csharp
public static Task<Document> RemovePreprocessorDirectivesAsync(this Document document, TextSpan span, PreprocessorDirectiveKinds directiveKinds, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**span**

**directiveKinds**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

