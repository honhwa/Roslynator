<a name="_top"></a>

# WorkspaceExtensions\.ReplaceTriviaAsync Method

[Home](../../../README.md#_top)

**Containing Type**: Roslynator\.[WorkspaceExtensions](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.Workspaces\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [ReplaceTriviaAsync(Document, SyntaxTrivia, IEnumerable\<SyntaxTrivia>, CancellationToken)](#Roslynator_WorkspaceExtensions_ReplaceTriviaAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_SyntaxTrivia_System_Collections_Generic_IEnumerable_Microsoft_CodeAnalysis_SyntaxTrivia__System_Threading_CancellationToken_) | Creates a new document with the specified old trivia replaced with a new trivia\. |
| [ReplaceTriviaAsync(Document, SyntaxTrivia, SyntaxTrivia, CancellationToken)](#Roslynator_WorkspaceExtensions_ReplaceTriviaAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_SyntaxTrivia_Microsoft_CodeAnalysis_SyntaxTrivia_System_Threading_CancellationToken_) | Creates a new document with the specified old trivia replaced with a new trivia\. |

## ReplaceTriviaAsync\(Document, SyntaxTrivia, IEnumerable\<SyntaxTrivia>, CancellationToken\) <a name="Roslynator_WorkspaceExtensions_ReplaceTriviaAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_SyntaxTrivia_System_Collections_Generic_IEnumerable_Microsoft_CodeAnalysis_SyntaxTrivia__System_Threading_CancellationToken_"></a>

### Summary

Creates a new document with the specified old trivia replaced with a new trivia\.

```csharp
public static Task<Document> ReplaceTriviaAsync(this Document document, SyntaxTrivia oldTrivia, IEnumerable<SyntaxTrivia> newTrivia, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**oldTrivia**

**newTrivia**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

## ReplaceTriviaAsync\(Document, SyntaxTrivia, SyntaxTrivia, CancellationToken\) <a name="Roslynator_WorkspaceExtensions_ReplaceTriviaAsync_Microsoft_CodeAnalysis_Document_Microsoft_CodeAnalysis_SyntaxTrivia_Microsoft_CodeAnalysis_SyntaxTrivia_System_Threading_CancellationToken_"></a>

### Summary

Creates a new document with the specified old trivia replaced with a new trivia\.

```csharp
public static Task<Document> ReplaceTriviaAsync(this Document document, SyntaxTrivia oldTrivia, SyntaxTrivia newTrivia, CancellationToken cancellationToken = default(CancellationToken))
```

### Parameters

**document**

**oldTrivia**

**newTrivia**

**cancellationToken**

### Returns

System\.Threading\.Tasks\.[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)\<[Document](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.document)>

