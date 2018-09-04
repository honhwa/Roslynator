<a name="_top"></a>

# SyntaxExtensions\.Add\(SyntaxList\<StatementSyntax>, StatementSyntax, Boolean\) Method

[Home](../../../../README.md#_top)

**Containing Type**: Roslynator\.CSharp\.[SyntaxExtensions](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Creates a new list with the specified node added or inserted\.

```csharp
public static SyntaxList<StatementSyntax> Add(this SyntaxList<StatementSyntax> statements, StatementSyntax statement, bool ignoreLocalFunctions)
```

### Parameters

**statements**

**statement**

**ignoreLocalFunctions**

Insert statement before local function statements at the end of the list\.

### Returns

Microsoft\.CodeAnalysis\.[SyntaxList](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.syntaxlist-1)\<[StatementSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.statementsyntax)>

