<a name="_top"></a>

# SyntaxAccessibility\.GetExplicitAccessibility Method

[Home](../../../../README.md#_top)

**Containing Type**: Roslynator\.CSharp\.[SyntaxAccessibility](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [GetExplicitAccessibility(SyntaxNode)](#Roslynator_CSharp_SyntaxAccessibility_GetExplicitAccessibility_Microsoft_CodeAnalysis_SyntaxNode_) | Returns an explicit accessibility of the specified declaration\. |
| [GetExplicitAccessibility(SyntaxTokenList)](#Roslynator_CSharp_SyntaxAccessibility_GetExplicitAccessibility_Microsoft_CodeAnalysis_SyntaxTokenList_) | Returns an explicit accessibility of the specified modifiers\. |

## GetExplicitAccessibility\(SyntaxNode\) <a name="Roslynator_CSharp_SyntaxAccessibility_GetExplicitAccessibility_Microsoft_CodeAnalysis_SyntaxNode_"></a>

### Summary

Returns an explicit accessibility of the specified declaration\.

```csharp
public static Accessibility GetExplicitAccessibility(SyntaxNode declaration)
```

### Parameters

**declaration**

### Returns

Microsoft\.CodeAnalysis\.[Accessibility](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.accessibility)

## GetExplicitAccessibility\(SyntaxTokenList\) <a name="Roslynator_CSharp_SyntaxAccessibility_GetExplicitAccessibility_Microsoft_CodeAnalysis_SyntaxTokenList_"></a>

### Summary

Returns an explicit accessibility of the specified modifiers\.

```csharp
public static Accessibility GetExplicitAccessibility(SyntaxTokenList modifiers)
```

### Parameters

**modifiers**

### Returns

Microsoft\.CodeAnalysis\.[Accessibility](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.accessibility)

