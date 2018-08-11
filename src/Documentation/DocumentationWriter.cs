﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Roslynator.CSharp;

namespace Roslynator.Documentation
{
    public abstract class DocumentationWriter : IDisposable
    {
        private bool _disposed;

        protected DocumentationWriter(
            DocumentationModel documentationModel,
            DocumentationUrlProvider urlProvider,
            DocumentationOptions options = null,
            DocumentationResources resources = null)
        {
            DocumentationModel = documentationModel;
            UrlProvider = urlProvider;
            Options = options ?? DocumentationOptions.Default;
            Resources = resources ?? DocumentationResources.Default;
        }

        public DocumentationModel DocumentationModel { get; }

        internal bool CanCreateTypeLocalUrl { get; set; } = true;

        internal bool CanCreateMemberLocalUrl { get; set; } = true;

        internal ISymbol CurrentSymbol { get; set; }

        protected internal int HeadingLevelBase { get; set; }

        public DocumentationOptions Options { get; }

        public DocumentationResources Resources { get; }

        public DocumentationUrlProvider UrlProvider { get; }

        private SymbolXmlDocumentation GetXmlDocumentation(ISymbol symbol)
        {
            return DocumentationModel.GetXmlDocumentation(symbol, Options.PreferredCultureName);
        }

        public abstract void WriteStartDocument();

        public abstract void WriteEndDocument();

        public abstract void WriteStartBold();

        public abstract void WriteEndBold();

        public virtual void WriteBold(string text)
        {
            WriteStartBold();
            WriteString(text);
            WriteEndBold();
        }

        public abstract void WriteStartItalic();

        public abstract void WriteEndItalic();

        public virtual void WriteItalic(string text)
        {
            WriteStartItalic();
            WriteString(text);
            WriteEndItalic();
        }

        public abstract void WriteStartStrikethrough();

        public abstract void WriteEndStrikethrough();

        public virtual void WriteStrikethrough(string text)
        {
            WriteStartStrikethrough();
            WriteString(text);
            WriteEndStrikethrough();
        }

        public abstract void WriteInlineCode(string text);

        public abstract void WriteStartHeading(int level);

        public abstract void WriteEndHeading();

        public virtual void WriteHeading1(string text)
        {
            WriteHeading(1, text);
        }

        public virtual void WriteHeading2(string text)
        {
            WriteHeading(2, text);
        }

        public virtual void WriteHeading3(string text)
        {
            WriteHeading(3, text);
        }

        public virtual void WriteHeading4(string text)
        {
            WriteHeading(4, text);
        }

        public virtual void WriteHeading5(string text)
        {
            WriteHeading(5, text);
        }

        public virtual void WriteHeading6(string text)
        {
            WriteHeading(6, text);
        }

        public virtual void WriteHeading(int level, string text)
        {
            WriteStartHeading(level);
            WriteString(text);
            WriteEndHeading();
        }

        public abstract void WriteStartBulletList();

        public abstract void WriteEndBulletList();

        public abstract void WriteStartBulletItem();

        public abstract void WriteEndBulletItem();

        public virtual void WriteBulletItem(string text)
        {
            WriteStartBulletItem();
            WriteString(text);
            WriteEndBulletItem();
        }

        public abstract void WriteStartOrderedList();

        public abstract void WriteEndOrderedList();

        public abstract void WriteStartOrderedItem(int number);

        public abstract void WriteEndOrderedItem();

        public virtual void WriteOrderedItem(int number, string text)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), number, "Item number must be greater than or equal to 0.");

            WriteStartOrderedItem(number);
            WriteString(text);
            WriteEndOrderedItem();
        }

        public abstract void WriteImage(string text, string url, string title = null);

        public abstract void WriteLink(string text, string url, string title = null);

        public void WriteLinkOrText(string text, string url = null, string title = null)
        {
            if (!string.IsNullOrEmpty(url))
            {
                WriteLink(text, url, title);
            }
            else
            {
                WriteString(text);
            }
        }

        public abstract void WriteCodeBlock(string text, string language = null);

        public abstract void WriteStartBlockQuote();

        public abstract void WriteEndBlockQuote();

        public virtual void WriteBlockQuote(string text)
        {
            WriteStartBlockQuote();
            WriteString(text);
            WriteEndBlockQuote();
        }

        public abstract void WriteHorizontalRule();

        public abstract void WriteStartTable(int columnCount);

        public abstract void WriteEndTable();

        public abstract void WriteStartTableRow();

        public abstract void WriteEndTableRow();

        public abstract void WriteStartTableCell();

        public abstract void WriteEndTableCell();

        public abstract void WriteTableHeaderSeparator();

        public abstract void WriteCharEntity(char value);

        public abstract void WriteEntityRef(string name);

        public abstract void WriteComment(string text);

        public abstract void Flush();

        public abstract void WriteString(string text);

        public abstract void WriteRaw(string data);

        public abstract void WriteLine();

        public virtual void WriteValue(bool value)
        {
            WriteString((value) ? Resources.TrueValue : Resources.FalseValue);
        }

        public virtual void WriteValue(int value)
        {
            WriteString(value.ToString(null, CultureInfo.InvariantCulture));
        }

        public virtual void WriteValue(long value)
        {
            WriteString(value.ToString(null, CultureInfo.InvariantCulture));
        }

        public virtual void WriteValue(float value)
        {
            WriteString(value.ToString(null, CultureInfo.InvariantCulture));
        }

        public virtual void WriteValue(double value)
        {
            WriteString(value.ToString(null, CultureInfo.InvariantCulture));
        }

        public virtual void WriteValue(decimal value)
        {
            WriteString(value.ToString(null, CultureInfo.InvariantCulture));
        }

        internal void WriteSpace()
        {
            WriteString(" ");
        }

        internal void WriteSymbol(ISymbol symbol, SymbolDisplayFormat format = null, SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.None)
        {
            WriteString(symbol.ToDisplayString(format, additionalOptions));
        }

        public void WriteTableCell(string text)
        {
            WriteStartTableCell();
            WriteString(text);
            WriteEndTableCell();
        }

        public void WriteContent(IEnumerable<string> names)
        {
            IEnumerator<string> en = names.GetEnumerator();

            if (en.MoveNext())
            {
                string heading = en.Current;

                if (en.MoveNext())
                {
                    WriteLink(heading, UrlProvider.GetFragment(heading));
                    WriteContentSeparator();

                    while (true)
                    {
                        heading = en.Current;

                        WriteLink(heading, UrlProvider.GetFragment(heading));

                        if (en.MoveNext())
                        {
                            WriteContentSeparator();
                        }
                        else
                        {
                            break;
                        }
                    }

                    WriteLine();
                    WriteLine();
                }
            }

            void WriteContentSeparator()
            {
                WriteSpace();
                WriteCharEntity(Resources.ContentSeparatorChar);
                WriteSpace();
            }
        }

        public virtual void WriteTitle(ISymbol symbol)
        {
            WriteHeading(1, symbol, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters, SymbolDisplayAdditionalMemberOptions.UseItemPropertyName | SymbolDisplayAdditionalMemberOptions.UseOperatorName, addLink: false);
        }

        public virtual void WriteNamespace(ISymbol symbol)
        {
            WriteBold(Resources.NamespaceTitle);
            WriteString(Resources.Colon);
            WriteSpace();
            WriteLink(symbol.ContainingNamespace, SymbolDisplayFormats.TypeNameAndContainingTypesAndNamespaces);
            WriteLine();
            WriteLine();
        }

        public virtual void WriteAssembly(ISymbol symbol)
        {
            WriteBold(Resources.AssemblyTitle);
            WriteString(Resources.Colon);
            WriteSpace();
            WriteString(symbol.ContainingAssembly.Name);
            WriteString(Resources.Dot);
            WriteString(Resources.DllExtension);
            WriteLine();
            WriteLine();
        }

        public virtual void WriteObsoleteMessage(ISymbol symbol)
        {
            WriteBold(Resources.ObsoleteMessage);
            WriteLine();
            WriteLine();

            TypedConstant typedConstant = symbol.GetAttribute(MetadataNames.System_ObsoleteAttribute).ConstructorArguments.FirstOrDefault();

            if (typedConstant.Type?.SpecialType == SpecialType.System_String)
            {
                string message = typedConstant.Value?.ToString();

                if (!string.IsNullOrEmpty(message))
                    WriteString(message);

                WriteLine();
            }

            WriteLine();
        }

        public virtual void WriteSummary(ISymbol symbol, SymbolXmlDocumentation xmlDocumentation)
        {
            WriteSection(heading: Resources.SummaryTitle, xmlDocumentation: xmlDocumentation, elementName: WellKnownTags.Summary);
        }

        public virtual void WriteDefinition(ISymbol symbol)
        {
            ImmutableArray<SymbolDisplayPart> parts = SymbolDefinitionBuilder.GetDisplayParts(
                symbol,
                SymbolDisplayFormats.FullDefinition,
                typeDeclarationOptions: SymbolDisplayTypeDeclarationOptions.IncludeAccessibility | SymbolDisplayTypeDeclarationOptions.IncludeModifiers,
                isVisibleAttribute: f => DocumentationUtility.IsVisibleAttribute(f),
                formatBaseList: Options.FormatDefinitionBaseList,
                formatConstraints: Options.FormatDefinitionConstraints,
                attributeArguments: Options.AttributeArguments,
                omitIEnumerable: Options.OmitIEnumerable,
                useNameOnlyIfPossible: true);

            WriteCodeBlock(parts.ToDisplayString(), symbol.Language);
        }

        public virtual void WriteTypeParameters(ISymbol symbol)
        {
            ImmutableArray<ITypeParameterSymbol> typeParameters = symbol.GetTypeParameters();

            if (typeParameters.Any())
                WriteTable(typeParameters, Resources.TypeParametersTitle, 3, Resources.NameTitle, Resources.SummaryTitle, SymbolDisplayFormats.TypeName);
        }

        public virtual void WriteParameters(ISymbol symbol)
        {
            switch (symbol.Kind)
            {
                case SymbolKind.Method:
                    {
                        var methodSymbol = (IMethodSymbol)symbol;

                        WriteTable(
                            methodSymbol.Parameters,
                            Resources.ParametersTitle,
                            3,
                            Resources.NameTitle,
                            Resources.SummaryTitle,
                            SymbolDisplayFormats.TypeName);

                        break;
                    }
                case SymbolKind.NamedType:
                    {
                        var namedTypeSymbol = (INamedTypeSymbol)symbol;

                        IMethodSymbol methodSymbol = namedTypeSymbol.DelegateInvokeMethod;

                        if (methodSymbol != null)
                        {
                            WriteTable(
                                methodSymbol.Parameters,
                                Resources.ParametersTitle,
                                3,
                                Resources.NameTitle,
                                Resources.SummaryTitle,
                                SymbolDisplayFormats.TypeName);
                        }

                        break;
                    }
                case SymbolKind.Property:
                    {
                        var propertySymbol = (IPropertySymbol)symbol;

                        WriteTable(
                            propertySymbol.Parameters,
                            Resources.ParametersTitle,
                            3,
                            Resources.NameTitle,
                            Resources.SummaryTitle,
                            SymbolDisplayFormats.TypeName);

                        break;
                    }
            }
        }

        public virtual void WriteReturnValue(ISymbol symbol, SymbolXmlDocumentation xmlDocumentation)
        {
            switch (symbol.Kind)
            {
                case SymbolKind.NamedType:
                    {
                        var namedTypeSymbol = (INamedTypeSymbol)symbol;

                        IMethodSymbol methodSymbol = namedTypeSymbol.DelegateInvokeMethod;

                        if (methodSymbol != null)
                        {
                            ITypeSymbol returnType = methodSymbol.ReturnType;

                            if (returnType.SpecialType == SpecialType.System_Void)
                                return;

                            WriteHeading(3, Resources.ReturnValueTitle);
                            WriteTypeLink(returnType);
                            WriteLine();

                            xmlDocumentation?.Element(WellKnownTags.Returns)?.WriteContentTo(this);
                        }

                        break;
                    }
            }
        }

        public virtual void WriteInheritance(ITypeSymbol typeSymbol)
        {
            TypeKind typeKind = typeSymbol.TypeKind;

            if (typeKind == TypeKind.Interface)
                return;

            if (typeKind == TypeKind.Class
                && typeSymbol.IsStatic)
            {
                return;
            }

            WriteHeading(3, Resources.InheritanceTitle);

            using (IEnumerator<ITypeSymbol> en = typeSymbol.BaseTypesAndSelf().Reverse().GetEnumerator())
            {
                if (en.MoveNext())
                {
                    ITypeSymbol symbol = en.Current;

                    bool isLast = !en.MoveNext();

                    WriterLinkOrText(symbol, isLast);

                    do
                    {
                        WriteSpace();
                        WriteCharEntity(Resources.InheritanceChar);
                        WriteSpace();

                        symbol = en.Current;
                        isLast = !en.MoveNext();

                        WriterLinkOrText(symbol.OriginalDefinition, isLast);
                    }
                    while (!isLast);
                }
            }

            WriteLine();

            void WriterLinkOrText(ITypeSymbol symbol, bool isLast)
            {
                if (isLast)
                {
                    WriteSymbol(symbol, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters);
                }
                else
                {
                    WriteLink(symbol, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters);
                }
            }
        }

        public virtual void WriteAttributes(ISymbol symbol)
        {
            ImmutableArray<AttributeInfo> attributes;

            if (symbol is INamedTypeSymbol typeSymbol)
            {
                attributes = typeSymbol.GetAttributesIncludingInherited(f => DocumentationUtility.IsVisibleAttribute(f));
            }
            else
            {
                attributes = symbol
                    .GetAttributes()
                    .Where(f => DocumentationUtility.IsVisibleAttribute(f.AttributeClass))
                    .Select(f => new AttributeInfo(symbol, f))
                    .ToImmutableArray();
            }

            if (!attributes.Any())
                return;

            using (IEnumerator<AttributeInfo> en = attributes
                .OrderBy(f => f.AttributeClass.ToDisplayString(SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters))
                .GetEnumerator())
            {
                if (en.MoveNext())
                {
                    WriteHeading(3, Resources.AttributesTitle);

                    while (true)
                    {
                        WriteLink(en.Current.AttributeClass, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters);

                        if (symbol != en.Current.Target)
                        {
                            WriteInheritedFrom(en.Current.Target.OriginalDefinition, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters);
                        }

                        if (en.MoveNext())
                        {
                            WriteSpace();
                            WriteCharEntity(Resources.ContentSeparatorChar);
                            WriteSpace();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            WriteLine();
        }

        public virtual void WriteDerivedTypes(IEnumerable<INamedTypeSymbol> derivedTypes)
        {
            WriteList(
                derivedTypes,
                heading: Resources.DerivedTitle,
                headingLevel: 3,
                format: SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters,
                maxItems: Options.MaxDerivedItems,
                addNamespace: true);
        }

        public virtual void WriteImplementedInterfaces(IEnumerable<INamedTypeSymbol> implementedInterfaces)
        {
            SymbolDisplayFormat format = SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters;

            using (IEnumerator<INamedTypeSymbol> en = implementedInterfaces
                .OrderBy(f => f.ToDisplayString(format))
                .GetEnumerator())
            {
                if (en.MoveNext())
                {
                    WriteHeading(3, Resources.ImplementsTitle);

                    while (true)
                    {
                        WriteLink(en.Current, format, addLinkForTypeParameters: true);

                        if (en.MoveNext())
                        {
                            WriteSpace();
                            WriteCharEntity(Resources.ContentSeparatorChar);
                            WriteSpace();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        public virtual void WriteExceptions(ISymbol symbol, SymbolXmlDocumentation xmlDocumentation)
        {
            using (IEnumerator<(XElement element, ISymbol exceptionSymbol)> en = GetExceptions().GetEnumerator())
            {
                if (en.MoveNext())
                {
                    WriteHeading(3, Resources.ExceptionsTitle);

                    do
                    {
                        XElement element = en.Current.element;
                        ISymbol exceptionSymbol = en.Current.exceptionSymbol;

                        WriteLink(exceptionSymbol, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters);
                        WriteLine();
                        WriteLine();
                        element.WriteContentTo(this);
                        WriteLine();
                        WriteLine();
                    }
                    while (en.MoveNext());
                }
            }

            IEnumerable<(XElement element, ISymbol exceptionSymbol)> GetExceptions()
            {
                foreach (XElement element in xmlDocumentation.Elements(WellKnownTags.Exception))
                {
                    string commentId = element.Attribute("cref")?.Value;

                    if (commentId != null)
                    {
                        ISymbol exceptionSymbol = DocumentationModel.GetFirstSymbolForReferenceId(commentId);

                        if (exceptionSymbol != null)
                            yield return (element, exceptionSymbol);
                    }
                }
            }
        }

        public virtual void WriteExamples(ISymbol symbol, SymbolXmlDocumentation xmlDocumentation)
        {
            WriteSection(heading: Resources.ExamplesTitle, xmlDocumentation: xmlDocumentation, elementName: WellKnownTags.Example);
        }

        public virtual void WriteRemarks(ISymbol symbol, SymbolXmlDocumentation xmlDocumentation)
        {
            WriteSection(heading: Resources.RemarksTitle, xmlDocumentation: xmlDocumentation, elementName: WellKnownTags.Remarks);
        }

        public virtual void WriteEnumFields(IEnumerable<IFieldSymbol> fields, INamedTypeSymbol enumType)
        {
            using (IEnumerator<IFieldSymbol> en = fields.GetEnumerator())
            {
                if (en.MoveNext())
                {
                    bool hasCombinedValue = false;

                    ImmutableArray<EnumFieldInfo> fieldInfos = default;

                    if (enumType.HasAttribute(MetadataNames.System_FlagsAttribute))
                    {
                        fieldInfos = EnumUtility.GetFields(enumType);

                        foreach (IFieldSymbol field in fields)
                        {
                            if (!EnumUtility.GetMinimalConstituentFields(field, fieldInfos).IsDefault)
                            {
                                hasCombinedValue = true;
                                break;
                            }
                        }
                    }

                    WriteHeading(2, Resources.FieldsTitle);

                    WriteStartTable((hasCombinedValue) ? 4 : 3);
                    WriteStartTableRow();
                    WriteTableCell(Resources.NameTitle);
                    WriteTableCell(Resources.ValueTitle);

                    if (hasCombinedValue)
                        WriteTableCell(Resources.CombinationOfTitle);

                    WriteTableCell(Resources.SummaryTitle);
                    WriteEndTableRow();
                    WriteTableHeaderSeparator();

                    do
                    {
                        IFieldSymbol fieldSymbol = en.Current;

                        WriteStartTableRow();
                        WriteTableCell(fieldSymbol.ToDisplayString(SymbolDisplayFormats.SimpleDefinition));
                        WriteTableCell(fieldSymbol.ConstantValue.ToString());

                        if (hasCombinedValue)
                        {
                            WriteStartTableCell();

                            ImmutableArray<EnumFieldInfo> constitiuentFields = EnumUtility.GetMinimalConstituentFields(en.Current, fieldInfos);

                            if (!constitiuentFields.IsDefault)
                            {
                                WriteString(constitiuentFields[0].Name);

                                for (int i = 1; i < constitiuentFields.Length; i++)
                                {
                                    WriteString(" | ");
                                    WriteString(constitiuentFields[i].Name);
                                }
                            }

                            WriteEndTableCell();
                        }

                        SymbolXmlDocumentation xmlDocumentation = DocumentationModel.GetXmlDocumentation(fieldSymbol, Options.PreferredCultureName);

                        if (xmlDocumentation != null)
                        {
                            WriteStartTableCell();
                            xmlDocumentation?.Element(WellKnownTags.Summary)?.WriteContentTo(this, inlineOnly: true);
                            WriteEndTableCell();
                        }

                        WriteEndTableRow();
                    }
                    while (en.MoveNext());

                    WriteEndTable();
                }
            }
        }

        public virtual void WriteConstructors(IEnumerable<IMethodSymbol> constructors)
        {
            WriteTable(constructors, Resources.ConstructorsTitle, 2, Resources.ConstructorTitle, Resources.SummaryTitle, SymbolDisplayFormats.SimpleDefinition);
        }

        public virtual void WriteFields(IEnumerable<IFieldSymbol> fields, INamedTypeSymbol containingType)
        {
            WriteTable(fields, Resources.FieldsTitle, 2, Resources.FieldTitle, Resources.SummaryTitle, SymbolDisplayFormats.SimpleDefinition, containingType: containingType);
        }

        public virtual void WriteProperties(IEnumerable<IPropertySymbol> properties, INamedTypeSymbol containingType)
        {
            WriteTable(properties, Resources.PropertiesTitle, 2, Resources.PropertyTitle, Resources.SummaryTitle, SymbolDisplayFormats.SimpleDefinition, SymbolDisplayAdditionalMemberOptions.UseItemPropertyName, containingType: containingType);
        }

        public virtual void WriteMethods(IEnumerable<IMethodSymbol> methods, INamedTypeSymbol containingType)
        {
            WriteTable(methods, Resources.MethodsTitle, 2, Resources.MethodTitle, Resources.SummaryTitle, SymbolDisplayFormats.SimpleDefinition, containingType: containingType);
        }

        public virtual void WriteOperators(IEnumerable<IMethodSymbol> operators, INamedTypeSymbol containingType)
        {
            WriteTable(operators, Resources.OperatorsTitle, 2, Resources.OperatorTitle, Resources.SummaryTitle, SymbolDisplayFormats.SimpleDefinition, SymbolDisplayAdditionalMemberOptions.UseOperatorName, containingType: containingType);
        }

        public virtual void WriteEvents(IEnumerable<IEventSymbol> events, INamedTypeSymbol containingType)
        {
            WriteTable(events, Resources.EventsTitle, 2, Resources.EventTitle, Resources.SummaryTitle, SymbolDisplayFormats.SimpleDefinition, containingType: containingType);
        }

        public virtual void WriteExplicitInterfaceImplementations(IEnumerable<ISymbol> explicitInterfaceImplementations)
        {
            WriteTable(explicitInterfaceImplementations, Resources.ExplicitInterfaceImplementationsTitle, 2, Resources.MemberTitle, Resources.SummaryTitle, SymbolDisplayFormats.SimpleDefinition, SymbolDisplayAdditionalMemberOptions.UseItemPropertyName, canIndicateInterfaceImplementation: false);
        }

        public virtual void WriteExtensionMethods(IEnumerable<IMethodSymbol> methods)
        {
            WriteTable(
                methods,
                Resources.ExtensionMethodsTitle,
                2,
                Resources.MethodTitle,
                Resources.SummaryTitle,
                SymbolDisplayFormats.SimpleDefinition);
        }

        public virtual void WriteSeeAlso(ISymbol symbol, SymbolXmlDocumentation xmlDocumentation)
        {
            using (IEnumerator<ISymbol> en = GetSymbols().GetEnumerator())
            {
                if (en.MoveNext())
                {
                    WriteHeading(2, Resources.SeeAlsoTitle);

                    WriteStartBulletList();

                    do
                    {
                        WriteBulletItemLink(en.Current, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters, SymbolDisplayAdditionalMemberOptions.UseItemPropertyName | SymbolDisplayAdditionalMemberOptions.UseOperatorName);
                    }
                    while (en.MoveNext());

                    WriteEndBulletList();
                }
            }

            IEnumerable<ISymbol> GetSymbols()
            {
                foreach (XElement element in xmlDocumentation.Elements(WellKnownTags.SeeAlso))
                {
                    string commentId = element.Attribute("cref")?.Value;

                    if (commentId != null)
                    {
                        ISymbol s = DocumentationModel.GetFirstSymbolForReferenceId(commentId);

                        if (s != null)
                            yield return s;
                    }
                }
            }
        }

        private void WriteSection(string heading, SymbolXmlDocumentation xmlDocumentation, string elementName)
        {
            XElement element = xmlDocumentation.Element(elementName);

            if (element == null)
                return;

            if (heading != null)
            {
                WriteHeading(2, heading);
            }
            else
            {
                WriteLine();
            }

            element.WriteContentTo(this);
        }

        internal void WriteTable(
            IEnumerable<ISymbol> symbols,
            string heading,
            int headingLevel,
            string header1,
            string header2,
            SymbolDisplayFormat format,
            SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.None,
            bool addLink = true,
            bool canIndicateInterfaceImplementation = true,
            INamedTypeSymbol containingType = null)
        {
            using (IEnumerator<ISymbol> en = symbols
                .OrderBy(f => f.ToDisplayString(format, additionalOptions))
                .GetEnumerator())
            {
                if (en.MoveNext())
                {
                    if (heading != null)
                        WriteHeading(headingLevel, heading);

                    WriteStartTable(2);
                    WriteStartTableRow();
                    WriteTableCell(header1);
                    WriteTableCell(header2);
                    WriteEndTableRow();
                    WriteTableHeaderSeparator();

                    do
                    {
                        ISymbol symbol = en.Current;

                        WriteStartTableRow();
                        WriteStartTableCell();

                        if (symbol.IsKind(SymbolKind.Parameter, SymbolKind.TypeParameter))
                        {
                            WriteString(symbol.Name);
                        }
                        else if (addLink)
                        {
                            WriteLink(symbol, format, additionalOptions);
                        }
                        else
                        {
                            WriteString(symbol.ToDisplayString(format, additionalOptions));
                        }

                        WriteEndTableCell();
                        WriteStartTableCell();

                        if (Options.IndicateObsolete
                            && symbol.HasAttribute(MetadataNames.System_ObsoleteAttribute))
                        {
                            WriteString("[");
                            WriteString(Resources.DeprecatedTitle);
                            WriteString("] ");
                        }

                        bool isInherited = containingType != null
                            && symbol.ContainingType != containingType;

                        if (symbol.Kind == SymbolKind.Parameter)
                        {
                            GetXmlDocumentation(symbol.ContainingSymbol)?.Element(WellKnownTags.Param, "name", symbol.Name)?.WriteContentTo(this);
                        }
                        else if (symbol.Kind == SymbolKind.TypeParameter)
                        {
                            GetXmlDocumentation(symbol.ContainingSymbol)?.Element(WellKnownTags.TypeParam, "name", symbol.Name)?.WriteContentTo(this);
                        }
                        else
                        {
                            ISymbol symbol2 = (isInherited) ? symbol.OriginalDefinition : symbol;

                            GetXmlDocumentation(symbol2)?.Element(WellKnownTags.Summary)?.WriteContentTo(this, inlineOnly: true);
                        }

                        if (isInherited)
                        {
                            if (Options.IndicateInheritedMember)
                                WriteInheritedFrom(symbol.ContainingType.OriginalDefinition, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters, additionalOptions);
                        }
                        else
                        {
                            if (Options.IndicateOverriddenMember)
                                WriteOverrides(symbol);

                            if (canIndicateInterfaceImplementation
                                && Options.IndicateInterfaceImplementation)
                            {
                                WriteImplements(symbol);
                            }
                        }

                        WriteEndTableCell();
                        WriteEndTableRow();
                    }
                    while (en.MoveNext());

                    WriteEndTable();
                }
            }

            void WriteOverrides(ISymbol symbol)
            {
                if (symbol.IsOverride)
                {
                    ISymbol overriddenSymbol = symbol.OverriddenSymbol();

                    if (overriddenSymbol != null)
                    {
                        WriteSpace();
                        WriteString(Resources.OpenParenthesis);
                        WriteString(Resources.OverridesTitle);
                        WriteSpace();
                        WriteLink(overriddenSymbol, SymbolDisplayFormats.TypeNameAndTypeParameters, additionalOptions);
                        WriteString(Resources.CloseParenthesis);
                    }
                }
            }

            void WriteImplements(ISymbol symbol)
            {
                using (IEnumerator<ISymbol> en = symbol.FindImplementedInterfaceMembers().GetEnumerator())
                {
                    if (en.MoveNext())
                    {
                        WriteSpace();
                        WriteString(Resources.OpenParenthesis);
                        WriteString(Resources.ImplementsTitle);

                        while (true)
                        {
                            WriteSpace();
                            WriteLink(en.Current, SymbolDisplayFormats.TypeNameAndTypeParameters, additionalOptions);

                            if (en.MoveNext())
                            {
                                WriteString(Resources.Comma);
                            }
                            else
                            {
                                break;
                            }
                        }

                        WriteString(Resources.CloseParenthesis);
                    }
                }
            }
        }

        private void WriteInheritedFrom(ISymbol symbol, SymbolDisplayFormat format, SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.None)
        {
            WriteSpace();
            WriteString(Resources.OpenParenthesis);
            WriteString(Resources.InheritedFrom);
            WriteSpace();
            WriteLink(symbol, format, additionalOptions);
            WriteString(Resources.CloseParenthesis);
        }

        internal void WriteList(
            IEnumerable<ISymbol> symbols,
            string heading,
            int headingLevel,
            SymbolDisplayFormat format,
            SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.None,
            int maxItems = -1,
            bool addLink = true,
            bool addLinkForTypeParameters = false,
            bool addNamespace = false,
            bool canCreateExternalUrl = true)
        {
            Debug.Assert(!addNamespace || format.TypeQualificationStyle != SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces, "");

            if (maxItems == 0)
                return;

            IEnumerable<ISymbol> sortedSymbols = null;

            if (addNamespace)
            {
                sortedSymbols = symbols
                    .OrderBy(f => f.ContainingNamespace, NamespaceSymbolComparer.Instance)
                    .ThenBy(f => f.ToDisplayString(format, additionalOptions));
            }
            else
            {
                sortedSymbols = symbols.OrderBy(f => f.ToDisplayString(format, additionalOptions));
            }

            using (IEnumerator<ISymbol> en = sortedSymbols.GetEnumerator())
            {
                if (en.MoveNext())
                {
                    if (heading != null)
                        WriteHeading(headingLevel, heading);

                    WriteStartBulletList();

                    int count = 0;

                    do
                    {
                        if (addLink)
                        {
                            WriteStartBulletItem();

                            if (addNamespace
                                && !en.Current.ContainingNamespace.IsGlobalNamespace)
                            {
                                WriteSymbol(en.Current.ContainingNamespace, SymbolDisplayFormats.TypeNameAndContainingTypesAndNamespaces);
                                WriteString(".");
                            }

                            WriteLink(en.Current, format, addLinkForTypeParameters: addLinkForTypeParameters, canCreateExternalUrl: canCreateExternalUrl);
                            WriteEndBulletItem();
                        }
                        else
                        {
                            WriteBulletItem(en.Current.ToDisplayString(format));
                        }

                        count++;

                        if (count == maxItems)
                        {
                            if (en.MoveNext())
                                WriteBulletItem(Resources.Ellipsis);

                            break;
                        }
                    }
                    while (en.MoveNext());

                    WriteEndBulletList();
                }
            }
        }

        internal void WriteHeading(
            int level,
            ISymbol symbol,
            SymbolDisplayFormat format,
            SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.None,
            bool addLink = true)
        {
            WriteStartHeading(level);

            if (addLink)
            {
                WriteLink(symbol, format, additionalOptions);
            }
            else
            {
                WriteSymbol(symbol, format, additionalOptions);
            }

            if (symbol.Kind != SymbolKind.Namespace
                || !((INamespaceSymbol)symbol).IsGlobalNamespace)
            {
                WriteSpace();
                WriteString(Resources.GetName(symbol));
            }

            WriteEndHeading();
        }

        internal void WriteBulletItemLink(
            ISymbol symbol,
            SymbolDisplayFormat format,
            SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.None,
            bool canCreateExternalUrl = true)
        {
            WriteStartBulletItem();
            WriteLink(symbol, format, additionalOptions: additionalOptions, canCreateExternalUrl: canCreateExternalUrl);
            WriteEndBulletItem();
        }

        protected internal void WriteLink(
            ISymbol symbol,
            SymbolDisplayFormat format,
            SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.None,
            bool addLinkForTypeParameters = false,
            bool canCreateExternalUrl = true)
        {
            if (addLinkForTypeParameters
                && symbol is INamedTypeSymbol namedType)
            {
                bool containingTypes = format.TypeQualificationStyle != SymbolDisplayTypeQualificationStyle.NameOnly;

                WriteTypeLink(namedType, containingTypes: containingTypes, canCreateExternalUrl: canCreateExternalUrl);
            }
            else
            {
                string url = GetUrl(symbol, canCreateExternalUrl);

                WriteLinkOrText(symbol.ToDisplayString(format, additionalOptions), url);
            }
        }

        internal void WriteTypeLink(
            ITypeSymbol typeSymbol,
            bool containingTypes = true,
            bool canCreateExternalUrl = true)
        {
            if (typeSymbol is INamedTypeSymbol namedTypeSymbol)
            {
                WriteTypeLink(namedTypeSymbol, containingTypes: containingTypes, canCreateExternalUrl: canCreateExternalUrl);
            }
            else
            {
                SymbolDisplayFormat format = (containingTypes)
                    ? SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters
                    : SymbolDisplayFormats.TypeNameAndTypeParameters;

                WriteLink(typeSymbol, format, canCreateExternalUrl: canCreateExternalUrl);
            }
        }

        protected void WriteTypeLink(
            INamedTypeSymbol typeSymbol,
            bool containingTypes = true,
            bool canCreateExternalUrl = true)
        {
            ImmutableArray<ITypeSymbol> typeArguments = typeSymbol.TypeArguments;

            if (typeSymbol.IsNullableType())
            {
                ITypeSymbol typeArgument = typeSymbol.TypeArguments[0];

                WriteTypeLink(typeArgument, containingTypes: containingTypes, canCreateExternalUrl: canCreateExternalUrl);
                WriteString("?");
            }
            else if (typeArguments.Any(f => f.Kind != SymbolKind.TypeParameter))
            {
                SymbolDisplayFormat format = (containingTypes)
                    ? SymbolDisplayFormats.TypeNameAndContainingTypes
                    : SymbolDisplayFormats.TypeName;

                string url = GetUrl(typeSymbol, canCreateExternalUrl);

                WriteLinkOrText(typeSymbol.ToDisplayString(format), url);

                ImmutableArray<ITypeSymbol>.Enumerator en = typeArguments.GetEnumerator();

                if (en.MoveNext())
                {
                    WriteString("<");

                    while (true)
                    {
                        if (en.Current.Kind == SymbolKind.NamedType)
                        {
                            WriteTypeLink((INamedTypeSymbol)en.Current, containingTypes: containingTypes, canCreateExternalUrl: canCreateExternalUrl);
                        }
                        else
                        {
                            Debug.Assert(en.Current.Kind == SymbolKind.TypeParameter, en.Current.Kind.ToString());

                            WriteString(en.Current.Name);
                        }

                        if (en.MoveNext())
                        {
                            WriteString(", ");
                        }
                        else
                        {
                            break;
                        }
                    }

                    WriteString(">");
                }
            }
            else
            {
                SymbolDisplayFormat format = (containingTypes)
                    ? SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters
                    : SymbolDisplayFormats.TypeNameAndTypeParameters;

                string url = GetUrl(typeSymbol, canCreateExternalUrl);

                WriteLinkOrText(typeSymbol.ToDisplayString(format), url);
            }
        }

        private string GetUrl(
            ISymbol symbol,
            bool canCreateExternalUrl = true)
        {
            ImmutableArray<string> folders = UrlProvider.GetFolders(symbol);

            if (folders.IsDefault)
                return null;

            switch (symbol.Kind)
            {
                case SymbolKind.NamedType:
                    {
                        if (!CanCreateTypeLocalUrl)
                            return null;

                        break;
                    }
                case SymbolKind.Event:
                case SymbolKind.Field:
                case SymbolKind.Method:
                case SymbolKind.Property:
                    {
                        if (!CanCreateMemberLocalUrl)
                            return null;

                        break;
                    }
                case SymbolKind.Parameter:
                case SymbolKind.TypeParameter:
                    {
                        return null;
                    }
            }

            if (DocumentationModel.IsExternal(symbol)
                && canCreateExternalUrl)
            {
                return UrlProvider.GetExternalUrl(folders).Url;
            }

            ImmutableArray<string> containingFolders = (CurrentSymbol != null)
                ? UrlProvider.GetFolders(CurrentSymbol)
                : default;

            string id = GetId();

            string fragment = (id != null) ? "#" + id : null;

            string url = UrlProvider.GetLocalUrl(folders, containingFolders, fragment).Url;

            return Options.BaseLocalUrl + url;

            string GetId()
            {
                if (symbol.Kind == SymbolKind.Method
                    || (symbol.Kind == SymbolKind.Property && ((IPropertySymbol)symbol).IsIndexer))
                {
                    TypeDocumentationModel typeModel = DocumentationModel.GetTypeModel(symbol.ContainingType);

                    IEnumerable<ISymbol> members = GetMembers(typeModel);

                    if (members != null)
                    {
                        using (IEnumerator<ISymbol> en = members.Where(f => f.Name == symbol.Name).GetEnumerator())
                        {
                            if (en.MoveNext()
                                && en.MoveNext())
                            {
                                return DocumentationUrlProvider.GetFragment(symbol);
                            }
                        }
                    }
                }

                return null;
            }

            IEnumerable<ISymbol> GetMembers(TypeDocumentationModel model)
            {
                switch (symbol.Kind)
                {
                    case SymbolKind.Method:
                        {
                            var methodSymbol = (IMethodSymbol)symbol;

                            switch (methodSymbol.MethodKind)
                            {
                                case MethodKind.Constructor:
                                    {
                                        return model.GetConstructors();
                                    }
                                case MethodKind.Ordinary:
                                    {
                                        return model.GetMethods();
                                    }
                                case MethodKind.Conversion:
                                case MethodKind.UserDefinedOperator:
                                    {
                                        return model.GetOperators();
                                    }
                                case MethodKind.ExplicitInterfaceImplementation:
                                    {
                                        ImmutableArray<IMethodSymbol> explicitInterfaceImplementations = methodSymbol.ExplicitInterfaceImplementations;

                                        if (!explicitInterfaceImplementations.IsDefaultOrEmpty)
                                            return model.GetExplicitInterfaceImplementations();

                                        break;
                                    }
                            }

                            break;
                        }
                    case SymbolKind.Property:
                        {
                            var propertySymbol = (IPropertySymbol)symbol;

                            if (propertySymbol.IsIndexer)
                            {
                                ImmutableArray<IPropertySymbol> explicitInterfaceImplementations = propertySymbol.ExplicitInterfaceImplementations;

                                if (!explicitInterfaceImplementations.IsDefaultOrEmpty)
                                {
                                    return model.GetExplicitInterfaceImplementations();
                                }
                                else
                                {
                                    return model.GetProperties().Where(f => f.IsIndexer);
                                }
                            }

                            break;
                        }
                }

                return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    Close();

                _disposed = true;
            }
        }

        public virtual void Close()
        {
        }
    }
}
