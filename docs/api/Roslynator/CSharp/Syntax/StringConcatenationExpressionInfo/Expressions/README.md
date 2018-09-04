<a name="_top"></a>

# StringConcatenationExpressionInfo\.Expressions\(Boolean\) Method

[Home](../../../../../README.md#_top)

**Containing Type**: Roslynator\.CSharp\.Syntax\.[StringConcatenationExpressionInfo](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

**WARNING: This API is now obsolete\.**

This method is obsolete\. Use method 'AsChain' instead\.

## Summary

Returns expressions of this binary expression, including expressions of nested binary expressions of the same kind as parent binary expression\.

```csharp
[System.ObsoleteAttribute("This method is obsolete. Use method 'AsChain' instead.")]
public IEnumerable<ExpressionSyntax> Expressions(bool leftToRight = false)
```

### Parameters

**leftToRight**

If true expressions are enumerated as they are displayed in the source code\.

### Returns

System\.Collections\.Generic\.[IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)\<[ExpressionSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.expressionsyntax)>

### Attributes

* System\.[ObsoleteAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.obsoleteattribute)

