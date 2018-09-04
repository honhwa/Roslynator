<a name="_top"></a>

# MarkdownDocumentationWriter Class

[Home](../../../../README.md#_top) &#x2022; [Constructors](#constructors) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods)

**Namespace**: [Roslynator.Documentation.Markdown](../README.md#_top)

**Assembly**: Roslynator\.Documentation\.dll

```csharp
public class MarkdownDocumentationWriter : Roslynator.Documentation.DocumentationWriter
```

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) &#x2192; [DocumentationWriter](../../DocumentationWriter/README.md#_top) &#x2192; MarkdownDocumentationWriter

### Implements

* System\.[IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

## Constructors

| Constructor | Summary |
| ----------- | ------- |
| [MarkdownDocumentationWriter(DocumentationModel, DocumentationUrlProvider, DocumentationOptions, DocumentationResources)](-ctor/README.md#_top) | |

## Properties

| Property | Summary |
| -------- | ------- |
| [DocumentationModel](../../DocumentationWriter/DocumentationModel/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [Options](../../DocumentationWriter/Options/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [Resources](../../DocumentationWriter/Resources/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [UrlProvider](../../DocumentationWriter/UrlProvider/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |

## Methods

| Method | Summary |
| ------ | ------- |
| [Close()](Close/README.md#_top) |  \(Overrides [DocumentationWriter.Close](../../DocumentationWriter/Close/README.md#_top)\) |
| [Dispose()](../../DocumentationWriter/Dispose/README.md#Roslynator_Documentation_DocumentationWriter_Dispose) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [Dispose(Boolean)](../../DocumentationWriter/Dispose/README.md#Roslynator_Documentation_DocumentationWriter_Dispose_System_Boolean_) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [Equals(Object)](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [Flush()](Flush/README.md#_top) |  \(Overrides [DocumentationWriter.Flush](../../DocumentationWriter/Flush/README.md#_top)\) |
| [GetHashCode()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [GetType()](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [MemberwiseClone()](https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone) |  \(Inherited from [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)\) |
| [ToString()](ToString/README.md#_top) |  \(Overrides [Object.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring)\) |
| [WriteAttributes(ISymbol, Int32)](../../DocumentationWriter/WriteAttributes/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteBlockQuote(String)](../../DocumentationWriter/WriteBlockQuote/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteBold(String)](../../DocumentationWriter/WriteBold/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteBulletItem(String)](../../DocumentationWriter/WriteBulletItem/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteCodeBlock(String, String)](WriteCodeBlock/README.md#_top) |  \(Overrides [DocumentationWriter.WriteCodeBlock](../../DocumentationWriter/WriteCodeBlock/README.md#_top)\) |
| [WriteComment(String)](WriteComment/README.md#_top) |  \(Overrides [DocumentationWriter.WriteComment](../../DocumentationWriter/WriteComment/README.md#_top)\) |
| [WriteConstructors(IEnumerable\<IMethodSymbol>)](../../DocumentationWriter/WriteConstructors/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteContainingAssembly(ISymbol, String)](../../DocumentationWriter/WriteContainingAssembly/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteContainingNamespace(INamespaceSymbol, String)](../../DocumentationWriter/WriteContainingNamespace/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteContainingType(ISymbol, String)](../../DocumentationWriter/WriteContainingType/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteContent(IEnumerable\<String>, Boolean, Boolean)](../../DocumentationWriter/WriteContent/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteDeclaration(ISymbol)](../../DocumentationWriter/WriteDeclaration/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteDerivedTypes(IEnumerable\<INamedTypeSymbol>)](../../DocumentationWriter/WriteDerivedTypes/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteEndBlockQuote()](WriteEndBlockQuote/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndBlockQuote](../../DocumentationWriter/WriteEndBlockQuote/README.md#_top)\) |
| [WriteEndBold()](WriteEndBold/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndBold](../../DocumentationWriter/WriteEndBold/README.md#_top)\) |
| [WriteEndBulletItem()](WriteEndBulletItem/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndBulletItem](../../DocumentationWriter/WriteEndBulletItem/README.md#_top)\) |
| [WriteEndBulletList()](WriteEndBulletList/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndBulletList](../../DocumentationWriter/WriteEndBulletList/README.md#_top)\) |
| [WriteEndDocument()](WriteEndDocument/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndDocument](../../DocumentationWriter/WriteEndDocument/README.md#_top)\) |
| [WriteEndHeading()](WriteEndHeading/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndHeading](../../DocumentationWriter/WriteEndHeading/README.md#_top)\) |
| [WriteEndItalic()](WriteEndItalic/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndItalic](../../DocumentationWriter/WriteEndItalic/README.md#_top)\) |
| [WriteEndLink(String, String)](WriteEndLink/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndLink](../../DocumentationWriter/WriteEndLink/README.md#_top)\) |
| [WriteEndOrderedItem()](WriteEndOrderedItem/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndOrderedItem](../../DocumentationWriter/WriteEndOrderedItem/README.md#_top)\) |
| [WriteEndOrderedList()](WriteEndOrderedList/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndOrderedList](../../DocumentationWriter/WriteEndOrderedList/README.md#_top)\) |
| [WriteEndStrikethrough()](WriteEndStrikethrough/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndStrikethrough](../../DocumentationWriter/WriteEndStrikethrough/README.md#_top)\) |
| [WriteEndTable()](WriteEndTable/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndTable](../../DocumentationWriter/WriteEndTable/README.md#_top)\) |
| [WriteEndTableCell()](WriteEndTableCell/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndTableCell](../../DocumentationWriter/WriteEndTableCell/README.md#_top)\) |
| [WriteEndTableRow()](WriteEndTableRow/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEndTableRow](../../DocumentationWriter/WriteEndTableRow/README.md#_top)\) |
| [WriteEntityRef(String)](WriteEntityRef/README.md#_top) |  \(Overrides [DocumentationWriter.WriteEntityRef](../../DocumentationWriter/WriteEntityRef/README.md#_top)\) |
| [WriteEnumFields(IEnumerable\<IFieldSymbol>, INamedTypeSymbol)](../../DocumentationWriter/WriteEnumFields/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteEvents(IEnumerable\<IEventSymbol>, INamedTypeSymbol)](../../DocumentationWriter/WriteEvents/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteExamples(ISymbol, SymbolXmlDocumentation, Int32)](../../DocumentationWriter/WriteExamples/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteExceptions(ISymbol, SymbolXmlDocumentation, Int32)](../../DocumentationWriter/WriteExceptions/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteExplicitInterfaceImplementations(IEnumerable\<ISymbol>)](../../DocumentationWriter/WriteExplicitInterfaceImplementations/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteExtensionMethods(IEnumerable\<IMethodSymbol>)](../../DocumentationWriter/WriteExtensionMethods/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteFields(IEnumerable\<IFieldSymbol>, INamedTypeSymbol)](../../DocumentationWriter/WriteFields/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteHeading(Int32, String)](../../DocumentationWriter/WriteHeading/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteHeading1(String)](../../DocumentationWriter/WriteHeading1/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteHeading2(String)](../../DocumentationWriter/WriteHeading2/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteHeading3(String)](../../DocumentationWriter/WriteHeading3/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteHeading4(String)](../../DocumentationWriter/WriteHeading4/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteHeading5(String)](../../DocumentationWriter/WriteHeading5/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteHeading6(String)](../../DocumentationWriter/WriteHeading6/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteHorizontalRule()](WriteHorizontalRule/README.md#_top) |  \(Overrides [DocumentationWriter.WriteHorizontalRule](../../DocumentationWriter/WriteHorizontalRule/README.md#_top)\) |
| [WriteCharEntity(Char)](WriteCharEntity/README.md#_top) |  \(Overrides [DocumentationWriter.WriteCharEntity](../../DocumentationWriter/WriteCharEntity/README.md#_top)\) |
| [WriteImage(String, String, String)](WriteImage/README.md#_top) |  \(Overrides [DocumentationWriter.WriteImage](../../DocumentationWriter/WriteImage/README.md#_top)\) |
| [WriteImplementedInterfaces(IEnumerable\<INamedTypeSymbol>)](../../DocumentationWriter/WriteImplementedInterfaces/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteIndexers(IEnumerable\<IPropertySymbol>, INamedTypeSymbol)](../../DocumentationWriter/WriteIndexers/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteInheritance(INamedTypeSymbol)](../../DocumentationWriter/WriteInheritance/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteInlineCode(String)](WriteInlineCode/README.md#_top) |  \(Overrides [DocumentationWriter.WriteInlineCode](../../DocumentationWriter/WriteInlineCode/README.md#_top)\) |
| [WriteItalic(String)](../../DocumentationWriter/WriteItalic/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteLine()](WriteLine/README.md#_top) |  \(Overrides [DocumentationWriter.WriteLine](../../DocumentationWriter/WriteLine/README.md#_top)\) |
| [WriteLineBreak()](WriteLineBreak/README.md#_top) |  \(Overrides [DocumentationWriter.WriteLineBreak](../../DocumentationWriter/WriteLineBreak/README.md#_top)\) |
| [WriteLink(String, String, String)](WriteLink/README.md#_top) |  \(Overrides [DocumentationWriter.WriteLink](../../DocumentationWriter/WriteLink/README.md#_top)\) |
| [WriteLinkDestination(String)](WriteLinkDestination/README.md#_top) |  \(Overrides [DocumentationWriter.WriteLinkDestination](../../DocumentationWriter/WriteLinkDestination/README.md#_top)\) |
| [WriteLinkOrText(String, String, String)](../../DocumentationWriter/WriteLinkOrText/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteMethods(IEnumerable\<IMethodSymbol>, INamedTypeSymbol)](../../DocumentationWriter/WriteMethods/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteObsoleteMessage(ISymbol)](../../DocumentationWriter/WriteObsoleteMessage/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteOperators(IEnumerable\<IMethodSymbol>, INamedTypeSymbol)](../../DocumentationWriter/WriteOperators/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteOrderedItem(Int32, String)](../../DocumentationWriter/WriteOrderedItem/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteParameters(ISymbol)](../../DocumentationWriter/WriteParameters/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteProperties(IEnumerable\<IPropertySymbol>, INamedTypeSymbol)](../../DocumentationWriter/WriteProperties/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteRaw(String)](WriteRaw/README.md#_top) |  \(Overrides [DocumentationWriter.WriteRaw](../../DocumentationWriter/WriteRaw/README.md#_top)\) |
| [WriteRemarks(ISymbol, SymbolXmlDocumentation, Int32)](../../DocumentationWriter/WriteRemarks/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteReturnValue(ISymbol, SymbolXmlDocumentation)](../../DocumentationWriter/WriteReturnValue/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteSeeAlso(ISymbol, SymbolXmlDocumentation, Int32)](../../DocumentationWriter/WriteSeeAlso/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteStartBlockQuote()](WriteStartBlockQuote/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartBlockQuote](../../DocumentationWriter/WriteStartBlockQuote/README.md#_top)\) |
| [WriteStartBold()](WriteStartBold/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartBold](../../DocumentationWriter/WriteStartBold/README.md#_top)\) |
| [WriteStartBulletItem()](WriteStartBulletItem/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartBulletItem](../../DocumentationWriter/WriteStartBulletItem/README.md#_top)\) |
| [WriteStartBulletList()](WriteStartBulletList/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartBulletList](../../DocumentationWriter/WriteStartBulletList/README.md#_top)\) |
| [WriteStartDocument()](WriteStartDocument/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartDocument](../../DocumentationWriter/WriteStartDocument/README.md#_top)\) |
| [WriteStartHeading(Int32)](WriteStartHeading/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartHeading](../../DocumentationWriter/WriteStartHeading/README.md#_top)\) |
| [WriteStartItalic()](WriteStartItalic/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartItalic](../../DocumentationWriter/WriteStartItalic/README.md#_top)\) |
| [WriteStartLink()](WriteStartLink/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartLink](../../DocumentationWriter/WriteStartLink/README.md#_top)\) |
| [WriteStartOrderedItem(Int32)](WriteStartOrderedItem/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartOrderedItem](../../DocumentationWriter/WriteStartOrderedItem/README.md#_top)\) |
| [WriteStartOrderedList()](WriteStartOrderedList/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartOrderedList](../../DocumentationWriter/WriteStartOrderedList/README.md#_top)\) |
| [WriteStartStrikethrough()](WriteStartStrikethrough/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartStrikethrough](../../DocumentationWriter/WriteStartStrikethrough/README.md#_top)\) |
| [WriteStartTable(Int32)](WriteStartTable/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartTable](../../DocumentationWriter/WriteStartTable/README.md#_top)\) |
| [WriteStartTableCell()](WriteStartTableCell/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartTableCell](../../DocumentationWriter/WriteStartTableCell/README.md#_top)\) |
| [WriteStartTableRow()](WriteStartTableRow/README.md#_top) |  \(Overrides [DocumentationWriter.WriteStartTableRow](../../DocumentationWriter/WriteStartTableRow/README.md#_top)\) |
| [WriteStrikethrough(String)](../../DocumentationWriter/WriteStrikethrough/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteString(String)](WriteString/README.md#_top) |  \(Overrides [DocumentationWriter.WriteString](../../DocumentationWriter/WriteString/README.md#_top)\) |
| [WriteSummary(ISymbol, SymbolXmlDocumentation, Int32)](../../DocumentationWriter/WriteSummary/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteTableCell(String)](WriteTableCell/README.md#_top) |  \(Overrides [DocumentationWriter.WriteTableCell](../../DocumentationWriter/WriteTableCell/README.md#_top)\) |
| [WriteTableHeaderSeparator()](WriteTableHeaderSeparator/README.md#_top) |  \(Overrides [DocumentationWriter.WriteTableHeaderSeparator](../../DocumentationWriter/WriteTableHeaderSeparator/README.md#_top)\) |
| [WriteTypeParameters(ISymbol)](../../DocumentationWriter/WriteTypeParameters/README.md#_top) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteValue(Boolean)](../../DocumentationWriter/WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Boolean_) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteValue(Decimal)](../../DocumentationWriter/WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Decimal_) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteValue(Double)](../../DocumentationWriter/WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Double_) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteValue(Int32)](../../DocumentationWriter/WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Int32_) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteValue(Int64)](../../DocumentationWriter/WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Int64_) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |
| [WriteValue(Single)](../../DocumentationWriter/WriteValue/README.md#Roslynator_Documentation_DocumentationWriter_WriteValue_System_Single_) |  \(Inherited from [DocumentationWriter](../../DocumentationWriter/README.md#_top)\) |

