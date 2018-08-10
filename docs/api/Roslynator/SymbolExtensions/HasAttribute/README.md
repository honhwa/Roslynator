# SymbolExtensions\.HasAttribute Method

**Namespace**: [Roslynator](../../README.md)

**Assembly**: Roslynator\.CSharp\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [HasAttribute(ISymbol, INamedTypeSymbol)](#Roslynator_SymbolExtensions_HasAttribute_Microsoft_CodeAnalysis_ISymbol_Microsoft_CodeAnalysis_INamedTypeSymbol_) | Returns true if the symbol has the specified attribute\. |
| [HasAttribute(ITypeSymbol, INamedTypeSymbol, Boolean)](#Roslynator_SymbolExtensions_HasAttribute_Microsoft_CodeAnalysis_ITypeSymbol_Microsoft_CodeAnalysis_INamedTypeSymbol_System_Boolean_) | Returns true if the type symbol has the specified attribute\. |

## HasAttribute\(ISymbol, INamedTypeSymbol\)<a name="Roslynator_SymbolExtensions_HasAttribute_Microsoft_CodeAnalysis_ISymbol_Microsoft_CodeAnalysis_INamedTypeSymbol_"></a>

### Summary

Returns true if the symbol has the specified attribute\.

```csharp
public static bool HasAttribute(this ISymbol symbol, INamedTypeSymbol attributeClass)
```

#### Parameters

| Name | Summary |
| ---- | ------- |
| symbol | |
| attributeClass | |

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)

## HasAttribute\(ITypeSymbol, INamedTypeSymbol, Boolean\)<a name="Roslynator_SymbolExtensions_HasAttribute_Microsoft_CodeAnalysis_ITypeSymbol_Microsoft_CodeAnalysis_INamedTypeSymbol_System_Boolean_"></a>

### Summary

Returns true if the type symbol has the specified attribute\.

```csharp
public static bool HasAttribute(this ITypeSymbol typeSymbol, INamedTypeSymbol attributeClass, bool includeBaseTypes)
```

#### Parameters

| Name | Summary |
| ---- | ------- |
| typeSymbol | |
| attributeClass | |
| includeBaseTypes | |

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)
