<a name="_top"></a>

# ModifierListInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about modifier list\.

```csharp
public readonly struct ModifierListInfo : System.IEquatable<ModifierListInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; ModifierListInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[ModifierListInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [ExplicitAccessibility](ExplicitAccessibility/README.md#_top) | The explicit accessibility\. |
| [IsAbstract](IsAbstract/README.md#_top) | True if the modifier list contains "abstract" modifier\. |
| [IsAsync](IsAsync/README.md#_top) | True if the modifier list contains "async" modifier\. |
| [IsConst](IsConst/README.md#_top) | True if the modifier list contains "const" modifier\. |
| [IsExtern](IsExtern/README.md#_top) | True if the modifier list contains "extern" modifier\. |
| [IsIn](IsIn/README.md#_top) | True if the modifier list contains "in" modifier\. |
| [IsNew](IsNew/README.md#_top) | True if the modifier list contains "new" modifier\. |
| [IsOut](IsOut/README.md#_top) | True if the modifier list contains "out" modifier\. |
| [IsOverride](IsOverride/README.md#_top) | True if the modifier list contains "override" modifier\. |
| [IsParams](IsParams/README.md#_top) | True if the modifier list contains "params" modifier\. |
| [IsPartial](IsPartial/README.md#_top) | True if the modifier list contains "partial" modifier\. |
| [IsReadOnly](IsReadOnly/README.md#_top) | True if the modifier list contains "readonly" modifier\. |
| [IsRef](IsRef/README.md#_top) | True if the modifier list contains "ref" modifier\. |
| [IsSealed](IsSealed/README.md#_top) | True if the modifier list contains "sealed" modifier\. |
| [IsStatic](IsStatic/README.md#_top) | True if the modifier list contains "static" modifier\. |
| [IsUnsafe](IsUnsafe/README.md#_top) | True if the modifier list contains "unsafe" modifier\. |
| [IsVirtual](IsVirtual/README.md#_top) | True if the modifier list contains "virtual" modifier\. |
| [IsVolatile](IsVolatile/README.md#_top) | True if the modifier list contains "volatile" modifier\. |
| [Modifiers](Modifiers/README.md#_top) | The modifier list\. |
| [Parent](Parent/README.md#_top) | The node that contains the modifiers\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(ModifierListInfo)](Equals/README.md#Roslynator_CSharp_Syntax_ModifierListInfo_Equals_Roslynator_CSharp_Syntax_ModifierListInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<ModifierListInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_ModifierListInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetKinds()](GetKinds/README.md#_top) | Gets the modifier kinds\. |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |
| [WithExplicitAccessibility(Accessibility, IComparer\<SyntaxKind>)](WithExplicitAccessibility/README.md#_top) | Creates a new [ModifierListInfo](#_top) with accessibility modifiers updated\. |
| [WithModifiers(SyntaxTokenList)](WithModifiers/README.md#_top) | Creates a new [ModifierListInfo](#_top) with the specified modifiers updated\. |
| [WithoutExplicitAccessibility()](WithoutExplicitAccessibility/README.md#_top) | Creates a new [ModifierListInfo](#_top) with accessibility modifiers removed\. |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(ModifierListInfo, ModifierListInfo)](op_Equality/README.md#_top) | |
| [Inequality(ModifierListInfo, ModifierListInfo)](op_Inequality/README.md#_top) | |

