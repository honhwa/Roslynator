<a name="_top"></a>

# XmlElementInfo Struct

[Home](../../../../README.md#_top) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods) &#x2022; [Operators](#operators)

**Namespace**: [Roslynator.CSharp.Syntax](../README.md#_top)

**Assembly**: Roslynator\.CSharp\.dll

## Summary

Provides information about a [XmlElementSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.xmlelementsyntax) or [XmlEmptyElementSyntax](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntax.xmlemptyelementsyntax)\.

```csharp
public readonly struct XmlElementInfo : System.IEquatable<XmlElementInfo>
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) &#x2192; XmlElementInfo

### Implements

* System\.[IEquatable](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\<[XmlElementInfo](#_top)>

## Properties

| Property | Summary |
| -------- | ------- |
| [Element](Element/README.md#_top) | The xml element\. |
| [IsEmptyElement](IsEmptyElement/README.md#_top) | Determines whether the element is [SyntaxKind.XmlEmptyElement](https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.syntaxkind.xmlemptyelement)\. |
| [Kind](Kind/README.md#_top) | Element kind\. |
| [LocalName](LocalName/README.md#_top) | Local name of the element\. |
| [Success](Success/README.md#_top) | Determines whether this struct was initialized with an actual syntax\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Equals(Object)](Equals/README.md#Roslynator_CSharp_Syntax_XmlElementInfo_Equals_System_Object_) | Determines whether this instance and a specified object are equal\. \(Overrides [ValueType.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals)\) |
| [Equals(XmlElementInfo)](Equals/README.md#Roslynator_CSharp_Syntax_XmlElementInfo_Equals_Roslynator_CSharp_Syntax_XmlElementInfo_) | Determines whether this instance is equal to another object of the same type\. \(Implements [IEquatable\<XmlElementInfo>.Equals](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals)\) |
| [GetHashCode()](GetHashCode/README.md#_top) | Returns the hash code for this instance\. \(Overrides [ValueType.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.gethashcode)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) | Returns the string representation of the underlying syntax, not including its leading and trailing trivia\. \(Overrides [ValueType.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.tostring)\) |

## Operators

| Operator | Summary |
| -------- | ------- |
| [Equality(XmlElementInfo, XmlElementInfo)](op_Equality/README.md#_top) | |
| [Inequality(XmlElementInfo, XmlElementInfo)](op_Inequality/README.md#_top) | |

