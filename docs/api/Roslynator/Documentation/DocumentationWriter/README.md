<a name="_top"></a>

# DocumentationWriter Class

[Home](../../../README.md#_top) &#x2022; [Constructors](#constructors) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods)

**Namespace**: [Roslynator.Documentation](../README.md#_top)

**Assembly**: Roslynator\.Documentation\.dll

```csharp
public abstract class DocumentationWriter : System.IDisposable
```

### Inheritance

System\.[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  
&emsp;DocumentationWriter

### Derived

* Roslynator\.Documentation\.Markdown\.[MarkdownDocumentationWriter](../Markdown/MarkdownDocumentationWriter/README.md#_top)

### Implements

* System\.[IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

## Constructors

| Constructor | Summary |
| ----------- | ------- |
| [DocumentationWriter(DocumentationModel, DocumentationUrlProvider, DocumentationOptions, DocumentationResources)](-ctor/README.md#_top) | |

## Properties

| Property | Summary |
| -------- | ------- |
| [DocumentationModel](DocumentationModel/README.md#_top) | |
| [Options](Options/README.md#_top) | |
| [Resources](Resources/README.md#_top) | |
| [UrlProvider](UrlProvider/README.md#_top) | |

## Methods

| Method | Summary |
| ------ | ------- |
| [Close()](Close/README.md#_top) | |
| [Dispose()](Dispose/README.md#Roslynator_Documentation_DocumentationWriter_Dispose) |  \(Implements [IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose)\) |
| [Dispose(Boolean)](Dispose/README.md#Roslynator_Documentation_DocumentationWriter_Dispose_System_Boolean_) | |
| [Equals(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [Flush()](Flush/README.md#_top) | |
| [GetHashCode()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [WriteAttributes(ISymbol, Int32)](WriteAttributes/README.md#_top) | |
| [WriteBlockQuote(String)](WriteBlockQuote/README.md#_top) | |
| [WriteBold(String)](WriteBold/README.md#_top) | |
| [WriteBulletItem(String)](WriteBulletItem/README.md#_top) | |
| [WriteCodeBlock(String, String)](WriteCodeBlock/README.md#_top) | |
| [WriteComment(String)](WriteComment/README.md#_top) | |
| [WriteConstructors(IEnumerable\<IMethodSymbol>)](WriteConstructors/README.md#_top) | |
| [WriteContainingAssembly(ISymbol, String)](WriteContainingAssembly/README.md#_top) | |
| [WriteContainingNamespace(INamespaceSymbol, String)](WriteContainingNamespace/README.md#_top) | |
| [WriteContainingType(ISymbol, String)](WriteContainingType/README.md#_top) | |
| [WriteContent(IEnumerable\<String>, Boolean, Boolean)](WriteContent/README.md#_top) | |
| [WriteDeclaration(ISymbol)](WriteDeclaration/README.md#_top) | |
| [WriteDerivedTypes(IEnumerable\<INamedTypeSymbol>)](WriteDerivedTypes/README.md#_top) | |
| [WriteEndBlockQuote()](WriteEndBlockQuote/README.md#_top) | |
| [WriteEndBold()](WriteEndBold/README.md#_top) | |
| [WriteEndBulletItem()](WriteEndBulletItem/README.md#_top) | |
| [WriteEndBulletList()](WriteEndBulletList/README.md#_top) | |
| [WriteEndDocument()](WriteEndDocument/README.md#_top) | |
| [WriteEndHeading()](WriteEndHeading/README.md#_top) | |
| [WriteEndItalic()](WriteEndItalic/README.md#_top) | |
| [WriteEndLink(String, String)](WriteEndLink/README.md#_top) | |
| [WriteEndOrderedItem()](WriteEndOrderedItem/README.md#_top) | |
| [WriteEndOrderedList()](WriteEndOrderedList/README.md#_top) | |
| [WriteEndStrikethrough()](WriteEndStrikethrough/README.md#_top) | |
| [WriteEndTable()](WriteEndTable/README.md#_top) | |
| [WriteEndTableCell()](WriteEndTableCell/README.md#_top) | |
| [WriteEndTableRow()](WriteEndTableRow/README.md#_top) | |
| [WriteEntityRef(String)](WriteEntityRef/README.md#_top) | |
| [WriteEnumFields(IEnumerable\<IFieldSymbol>, INamedTypeSymbol)](WriteEnumFields/README.md#_top) | |
| [WriteEvents(IEnumerable\<IEventSymbol>, INamedTypeSymbol)](WriteEvents/README.md#_top) | |
| [WriteExamples(ISymbol, SymbolXmlDocumentation, Int32)](WriteExamples/README.md#_top) | |
| [WriteExceptions(ISymbol, SymbolXmlDocumentation, Int32)](WriteExceptions/README.md#_top) | |
| [WriteExplicitInterfaceImplementations(IEnumerable\<ISymbol>)](WriteExplicitInterfaceImplementations/README.md#_top) | |
| [WriteExtensionMethods(IEnumerable\<IMethodSymbol>)](WriteExtensionMethods/README.md#_top) | |
| [WriteFields(IEnumerable\<IFieldSymbol>, INamedTypeSymbol)](WriteFields/README.md#_top) | |
| [WriteHeading(Int32, String)](WriteHeading/README.md#_top) | |
| [WriteHeading1(String)](WriteHeading1/README.md#_top) | |
| [WriteHeading2(String)](WriteHeading2/README.md#_top) | |
| [WriteHeading3(String)](WriteHeading3/README.md#_top) | |
| [WriteHeading4(String)](WriteHeading4/README.md#_top) | |
| [WriteHeading5(String)](WriteHeading5/README.md#_top) | |
| [WriteHeading6(String)](WriteHeading6/README.md#_top) | |
| [WriteHorizontalRule()](WriteHorizontalRule/README.md#_top) | |
| [WriteCharEntity(Char)](WriteCharEntity/README.md#_top) | |
| [WriteImage(String, String, String)](WriteImage/README.md#_top) | |
| [WriteImplementedInterfaces(IEnumerable\<INamedTypeSymbol>)](WriteImplementedInterfaces/README.md#_top) | |
| [WriteIndexers(IEnumerable\<IPropertySymbol>, INamedTypeSymbol)](WriteIndexers/README.md#_top) | |
| [WriteInheritance(INamedTypeSymbol)](WriteInheritance/README.md#_top) | |
| [WriteInlineCode(String)](WriteInlineCode/README.md#_top) | |
| [WriteItalic(String)](WriteItalic/README.md#_top) | |
| [WriteLine()](WriteLine/README.md#_top) | |
| [WriteLink(String, String, String)](WriteLink/README.md#_top) | |
| [WriteLinkDestination(String)](WriteLinkDestination/README.md#_top) | |
| [WriteLinkOrText(String, String, String)](WriteLinkOrText/README.md#_top) | |
| [WriteMethods(IEnumerable\<IMethodSymbol>, INamedTypeSymbol)](WriteMethods/README.md#_top) | |
| [WriteObsoleteMessage(ISymbol)](WriteObsoleteMessage/README.md#_top) | |
| [WriteOperators(IEnumerable\<IMethodSymbol>, INamedTypeSymbol)](WriteOperators/README.md#_top) | |
| [WriteOrderedItem(Int32, String)](WriteOrderedItem/README.md#_top) | |
| [WriteParameters(ISymbol)](WriteParameters/README.md#_top) | |
| [WriteProperties(IEnumerable\<IPropertySymbol>, INamedTypeSymbol)](WriteProperties/README.md#_top) | |
| [WriteRaw(String)](WriteRaw/README.md#_top) | |
| [WriteRemarks(ISymbol, SymbolXmlDocumentation, Int32)](WriteRemarks/README.md#_top) | |
| [WriteReturnValue(ISymbol, SymbolXmlDocumentation)](WriteReturnValue/README.md#_top) | |
| [WriteSeeAlso(ISymbol, SymbolXmlDocumentation, Int32)](WriteSeeAlso/README.md#_top) | |
| [WriteStartBlockQuote()](WriteStartBlockQuote/README.md#_top) | |
| [WriteStartBold()](WriteStartBold/README.md#_top) | |
| [WriteStartBulletItem()](WriteStartBulletItem/README.md#_top) | |
| [WriteStartBulletList()](WriteStartBulletList/README.md#_top) | |
| [WriteStartDocument()](WriteStartDocument/README.md#_top) | |
| [WriteStartHeading(Int32)](WriteStartHeading/README.md#_top) | |
| [WriteStartItalic()](WriteStartItalic/README.md#_top) | |
| [WriteStartLink()](WriteStartLink/README.md#_top) | |
| [WriteStartOrderedItem(Int32)](WriteStartOrderedItem/README.md#_top) | |
| [WriteStartOrderedList()](WriteStartOrderedList/README.md#_top) | |
| [WriteStartStrikethrough()](WriteStartStrikethrough/README.md#_top) | |
| [WriteStartTable(Int32)](WriteStartTable/README.md#_top) | |
| [WriteStartTableCell()](WriteStartTableCell/README.md#_top) | |
| [WriteStartTableRow()](WriteStartTableRow/README.md#_top) | |
| [WriteStrikethrough(String)](WriteStrikethrough/README.md#_top) | |
| [WriteString(String)](WriteString/README.md#_top) | |
| [WriteSummary(ISymbol, SymbolXmlDocumentation, Int32)](WriteSummary/README.md#_top) | |
| [WriteTableCell(String)](WriteTableCell/README.md#_top) | |
| [WriteTableHeaderSeparator()](WriteTableHeaderSeparator/README.md#_top) | |
| [WriteTypeParameters(ISymbol)](WriteTypeParameters/README.md#_top) | |
| [WriteValue(Boolean)](WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Boolean_) | |
| [WriteValue(Decimal)](WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Decimal_) | |
| [WriteValue(Double)](WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Double_) | |
| [WriteValue(Int32)](WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Int32_) | |
| [WriteValue(Int64)](WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Int64_) | |
| [WriteValue(Single)](WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Single_) | |

