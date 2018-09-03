// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Roslynator.CSharp;

namespace Roslynator.Documentation
{
    public abstract class DocumentationGenerator
    {
        private ImmutableArray<RootDocumentationParts> _enabledAndSortedRootParts;
        private ImmutableArray<TypeDocumentationParts> _enabledAndSortedTypeParts;
        private ImmutableArray<NamespaceDocumentationParts> _enabledAndSortedNamespaceParts;

        protected DocumentationGenerator(
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

        public DocumentationOptions Options { get; }

        public DocumentationResources Resources { get; }

        public DocumentationUrlProvider UrlProvider { get; }

        public virtual IComparer<RootDocumentationParts> RootPartComparer
        {
            get { return RootDocumentationPartComparer.Instance; }
        }

        public virtual IComparer<NamespaceDocumentationParts> NamespacePartComparer
        {
            get { return NamespaceDocumentationPartComparer.Instance; }
        }

        public virtual IComparer<TypeDocumentationParts> TypePartComparer
        {
            get { return TypeDocumentationPartComparer.Instance; }
        }

        public virtual IComparer<MemberDocumentationParts> MemberPartComparer
        {
            get { return MemberDocumentationPartComparer.Instance; }
        }

        internal ImmutableArray<RootDocumentationParts> EnabledAndSortedRootParts
        {
            get
            {
                if (_enabledAndSortedRootParts.IsDefault)
                {
                    _enabledAndSortedRootParts = Enum.GetValues(typeof(RootDocumentationParts))
                        .Cast<RootDocumentationParts>()
                        .Where(f => f != RootDocumentationParts.None
                            && f != RootDocumentationParts.All
                            && f != RootDocumentationParts.Types
                            && (Options.IgnoredRootParts & f) == 0)
                        .OrderBy(f => f, RootPartComparer)
                        .ToImmutableArray();
                }

                return _enabledAndSortedRootParts;
            }
        }

        internal ImmutableArray<NamespaceDocumentationParts> EnabledAndSortedNamespaceParts
        {
            get
            {
                if (_enabledAndSortedNamespaceParts.IsDefault)
                {
                    _enabledAndSortedNamespaceParts = Enum.GetValues(typeof(NamespaceDocumentationParts))
                        .Cast<NamespaceDocumentationParts>()
                        .Where(f => f != NamespaceDocumentationParts.None
                            && f != NamespaceDocumentationParts.All
                            && (Options.IgnoredNamespaceParts & f) == 0)
                        .OrderBy(f => f, NamespacePartComparer)
                        .ToImmutableArray();
                }

                return _enabledAndSortedNamespaceParts;
            }
        }

        internal ImmutableArray<TypeDocumentationParts> EnabledAndSortedTypeParts
        {
            get
            {
                if (_enabledAndSortedTypeParts.IsDefault)
                {
                    _enabledAndSortedTypeParts = Enum.GetValues(typeof(TypeDocumentationParts))
                        .Cast<TypeDocumentationParts>()
                        .Where(f => f != TypeDocumentationParts.None
                            && f != TypeDocumentationParts.All
                            && f != TypeDocumentationParts.NestedTypes
                            && f != TypeDocumentationParts.AllExceptNestedTypes
                            && (Options.IgnoredTypeParts & f) == 0)
                        .OrderBy(f => f, TypePartComparer)
                        .ToImmutableArray();
                }

                return _enabledAndSortedTypeParts;
            }
        }

        private DocumentationWriter CreateWriter(ISymbol currentSymbol = null)
        {
            DocumentationWriter writer = CreateWriterCore();

            writer.CurrentSymbol = currentSymbol;
            writer.CanCreateMemberLocalUrl = Options.Depth == DocumentationDepth.Member;
            writer.CanCreateTypeLocalUrl = Options.Depth <= DocumentationDepth.Type;

            return writer;
        }

        protected abstract DocumentationWriter CreateWriterCore();

        public IEnumerable<DocumentationGeneratorResult> Generate(string heading = null)
        {
            DocumentationDepth depth = Options.Depth;

            DocumentationGeneratorResult objectModel = default;
            DocumentationGeneratorResult externalTypesExtensions = GenerateExternalTypesExtensions();

            using (DocumentationWriter writer = CreateWriter())
            {
                yield return GenerateRoot(writer, heading, addExtensionsLink: externalTypesExtensions.HasContent);
            }

            if (depth <= DocumentationDepth.Namespace)
            {
                IEnumerable<INamedTypeSymbol> typeSymbols = DocumentationModel.Types.Where(f => !Options.ShouldBeIgnored(f));

                foreach (INamespaceSymbol namespaceSymbol in typeSymbols
                    .Select(f => f.ContainingNamespace)
                    .Distinct(MetadataNameEqualityComparer<INamespaceSymbol>.Instance))
                {
                    yield return GenerateNamespace(namespaceSymbol);
                }

                if (depth <= DocumentationDepth.Type)
                {
                    foreach (INamedTypeSymbol typeSymbol in typeSymbols)
                    {
                        if (!Options.ShouldBeIgnored(typeSymbol))
                        {
                            TypeDocumentationModel typeModel = DocumentationModel.GetTypeModel(typeSymbol);

                            yield return GenerateType(typeModel);

                            if (depth == DocumentationDepth.Member)
                            {
                                foreach (DocumentationGeneratorResult result in GenerateMembers(typeModel))
                                    yield return result;
                            }
                        }
                    }
                }
            }

            if (objectModel.HasContent)
                yield return objectModel;

            if (externalTypesExtensions.HasContent)
            {
                yield return externalTypesExtensions;

                foreach (INamedTypeSymbol typeSymbol in DocumentationModel.GetExtendedExternalTypes())
                {
                    if (!Options.ShouldBeIgnored(typeSymbol))
                    {
                        yield return GenerateExtendedExternalType(typeSymbol);
                    }
                }
            }
        }

        public DocumentationGeneratorResult GenerateRoot(
            string heading,
            bool addExtensionsLink = false)
        {
            using (DocumentationWriter writer = CreateWriter())
            {
                return GenerateRoot(writer, heading, addExtensionsLink: addExtensionsLink);
            }
        }

        internal DocumentationGeneratorResult GenerateRoot(
            DocumentationWriter writer,
            string heading,
            bool addExtensionsLink = false)
        {
            writer.WriteStartDocument();

            writer.WriteLinkDestination(WellKnownNames.TopFragmentName);
            writer.WriteStartHeading(1);
            writer.WriteString(heading);
            writer.WriteEndHeading();

            GenerateRoot(writer, addExtensionsLink: addExtensionsLink);

            writer.WriteEndDocument();

            return CreateResult(writer, DocumentationFileKind.Root);
        }

        private void GenerateRoot(DocumentationWriter writer, bool addExtensionsLink = false)
        {
            SymbolDisplayFormat format = SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters;

            IEnumerable<INamedTypeSymbol> typeSymbols = DocumentationModel.Types.Where(f => !Options.ShouldBeIgnored(f));

            IEnumerable<INamespaceSymbol> namespaceSymbols = typeSymbols
                .Select(f => f.ContainingNamespace)
                .Distinct(MetadataNameEqualityComparer<INamespaceSymbol>.Instance);

            foreach (RootDocumentationParts part in EnabledAndSortedRootParts)
            {
                switch (part)
                {
                    case RootDocumentationParts.Content:
                        {
                            writer.WriteContent(GetContentParts().OrderBy(f => f, RootPartComparer).Select(f => Resources.GetHeading(f)));
                            break;
                        }
                    case RootDocumentationParts.Namespaces:
                        {
                            writer.WriteList(namespaceSymbols, Resources.NamespacesTitle, 2, SymbolDisplayFormats.TypeNameAndContainingTypesAndNamespaces);
                            break;
                        }
                    case RootDocumentationParts.Classes:
                        {
                            if (Options.IncludeClassHierarchy)
                            {
                                if (typeSymbols.Any(f => !f.IsStatic && f.TypeKind == TypeKind.Class))
                                {
                                    INamedTypeSymbol objectType = DocumentationModel.Compilation.ObjectType;

                                    IEnumerable<INamedTypeSymbol> instanceClasses = typeSymbols.Where(f => !f.IsStatic && f.TypeKind == TypeKind.Class);

                                    writer.WriteHeading2(Resources.GetPluralName(TypeKind.Class));

                                    writer.WriteClassHierarchy(objectType, instanceClasses, format, includeContainingNamespace: Options.IncludeContainingNamespace);

                                    writer.WriteLine();
                                }
                            }
                            else
                            {
                                writer.WriteList(
                                    typeSymbols.Where(f => f.TypeKind == TypeKind.Class),
                                    Resources.ClassesTitle,
                                    2,
                                    SymbolDisplayFormats.TypeNameAndContainingTypes,
                                    includeContainingNamespace: true);

                                break;
                            }

                            break;
                        }
                    case RootDocumentationParts.StaticClasses:
                        {
                            if (Options.IncludeClassHierarchy)
                            {
                                using (IEnumerator<INamedTypeSymbol> en = typeSymbols
                                    .Where(f => f.IsStatic && f.TypeKind == TypeKind.Class)
                                    .OrderBy(f => f.ContainingNamespace, NamespaceSymbolComparer.GetInstance(Options.PlaceSystemNamespaceFirst))
                                    .ThenBy(f => f.ToDisplayString(format))
                                    .GetEnumerator())
                                {
                                    if (en.MoveNext())
                                    {
                                        writer.WriteHeading2(Resources.StaticClassesTitle);

                                        do
                                        {
                                            WriteBulletItemLink(en.Current);
                                        }
                                        while (en.MoveNext());
                                    }
                                }
                            }

                            break;
                        }
                    case RootDocumentationParts.Structs:
                        {
                            WriteTypes(TypeKind.Struct);
                            break;
                        }
                    case RootDocumentationParts.Interfaces:
                        {
                            WriteTypes(TypeKind.Interface);
                            break;
                        }
                    case RootDocumentationParts.Enums:
                        {
                            WriteTypes(TypeKind.Enum);
                            break;
                        }
                    case RootDocumentationParts.Delegates:
                        {
                            WriteTypes(TypeKind.Delegate);
                            break;
                        }
                    case RootDocumentationParts.Other:
                        {
                            if (addExtensionsLink)
                            {
                                writer.WriteHeading2(Resources.OtherTitle);
                                writer.WriteStartBulletItem();
                                writer.WriteLink(Resources.ExtensionsOfExternalTypesTitle, WellKnownNames.Extensions + "#" + WellKnownNames.TopFragmentName);
                                writer.WriteEndBulletItem();
                            }

                            break;
                        }
                }
            }

            void WriteTypes(TypeKind typeKind)
            {
                using (IEnumerator<INamedTypeSymbol> en = typeSymbols
                    .Where(f => f.TypeKind == typeKind)
                    .OrderBy(f => f.ContainingNamespace, NamespaceSymbolComparer.GetInstance(Options.PlaceSystemNamespaceFirst))
                    .ThenBy(f => f.ToDisplayString(format))
                    .GetEnumerator())
                {
                    if (en.MoveNext())
                    {
                        writer.WriteHeading2(Resources.GetPluralName(typeKind));

                        do
                        {
                            WriteBulletItemLink(en.Current);
                        }
                        while (en.MoveNext());
                    }
                }
            }

            void WriteBulletItemLink(INamedTypeSymbol typeSymbol)
            {
                writer.WriteStartBulletItem();

                INamespaceSymbol containingNamespace = typeSymbol.ContainingNamespace;

                if (!containingNamespace.IsGlobalNamespace)
                {
                    writer.WriteNamespaceSymbol(containingNamespace);
                    writer.WriteString(".");
                }

                writer.WriteLink(typeSymbol, format);
                writer.WriteEndBulletItem();
            }

            IEnumerable<RootDocumentationParts> GetContentParts()
            {
                foreach (RootDocumentationParts part in EnabledAndSortedRootParts)
                {
                    if (IsAvailable(part))
                        yield return part;
                }
            }

            bool IsAvailable(RootDocumentationParts part)
            {
                switch (part)
                {
                    case RootDocumentationParts.Content:
                        {
                            return false;
                        }
                    case RootDocumentationParts.Namespaces:
                        {
                            return typeSymbols.Any();
                        }
                    case RootDocumentationParts.Classes:
                        {
                            return typeSymbols.Any(f => !f.IsStatic && f.TypeKind == TypeKind.Class);
                        }
                    case RootDocumentationParts.StaticClasses:
                        {
                            return Options.IncludeClassHierarchy
                                && typeSymbols.Any(f => f.IsStatic && f.TypeKind == TypeKind.Class);
                        }
                    case RootDocumentationParts.Structs:
                        {
                            return typeSymbols.Any(f => f.TypeKind == TypeKind.Struct);
                        }
                    case RootDocumentationParts.Interfaces:
                        {
                            return typeSymbols.Any(f => f.TypeKind == TypeKind.Interface);
                        }
                    case RootDocumentationParts.Enums:
                        {
                            return typeSymbols.Any(f => f.TypeKind == TypeKind.Enum);
                        }
                    case RootDocumentationParts.Delegates:
                        {
                            return typeSymbols.Any(f => f.TypeKind == TypeKind.Delegate);
                        }
                    case RootDocumentationParts.Other:
                        {
                            return addExtensionsLink;
                        }
                    default:
                        {
                            throw new InvalidOperationException();
                        }
                }
            }
        }

        private DocumentationGeneratorResult GenerateNamespace(INamespaceSymbol namespaceSymbol)
        {
            IEnumerable<INamedTypeSymbol> typeSymbols = DocumentationModel
                .Types
                .Where(f => MetadataNameEqualityComparer<INamespaceSymbol>.Instance.Equals(f.ContainingNamespace, namespaceSymbol));

            using (DocumentationWriter writer = CreateWriter(namespaceSymbol))
            {
                writer.WriteStartDocument();

                SymbolXmlDocumentation xmlDocumentation = DocumentationModel.GetXmlDocumentation(namespaceSymbol, Options.PreferredCultureName);

                writer.WriteHeading(1, namespaceSymbol, SymbolDisplayFormats.TypeNameAndContainingTypesAndNamespaces, addLink: false, linkDestination: WellKnownNames.TopFragmentName);

                foreach (NamespaceDocumentationParts part in EnabledAndSortedNamespaceParts)
                {
                    switch (part)
                    {
                        case NamespaceDocumentationParts.Content:
                            {
                                writer.WriteContent(GetContentParts().OrderBy(f => f, NamespacePartComparer).Select(f => Resources.GetHeading(f)), addLinkToRoot: true);
                                break;
                            }
                        case NamespaceDocumentationParts.ContainingNamespace:
                            {
                                INamespaceSymbol containingNamespace = namespaceSymbol.ContainingNamespace;

                                if (containingNamespace?.IsGlobalNamespace == false)
                                    writer.WriteContainingNamespace(containingNamespace, Resources.ContainingNamespaceTitle);

                                break;
                            }
                        case NamespaceDocumentationParts.Summary:
                            {
                                xmlDocumentation?.Element(WellKnownTags.Summary)?.WriteContentTo(writer);
                                break;
                            }
                        case NamespaceDocumentationParts.Examples:
                            {
                                if (xmlDocumentation != null)
                                    writer.WriteExamples(namespaceSymbol, xmlDocumentation);

                                break;
                            }
                        case NamespaceDocumentationParts.Remarks:
                            {
                                if (xmlDocumentation != null)
                                    writer.WriteRemarks(namespaceSymbol, xmlDocumentation);

                                break;
                            }
                        case NamespaceDocumentationParts.Classes:
                            {
                                WriteTypes(typeSymbols, TypeKind.Class);
                                break;
                            }
                        case NamespaceDocumentationParts.Structs:
                            {
                                WriteTypes(typeSymbols, TypeKind.Struct);
                                break;
                            }
                        case NamespaceDocumentationParts.Interfaces:
                            {
                                WriteTypes(typeSymbols, TypeKind.Interface);
                                break;
                            }
                        case NamespaceDocumentationParts.Enums:
                            {
                                WriteTypes(typeSymbols, TypeKind.Enum);
                                break;
                            }
                        case NamespaceDocumentationParts.Delegates:
                            {
                                WriteTypes(typeSymbols, TypeKind.Delegate);
                                break;
                            }
                        case NamespaceDocumentationParts.SeeAlso:
                            {
                                if (xmlDocumentation != null)
                                    writer.WriteSeeAlso(namespaceSymbol, xmlDocumentation);

                                break;
                            }
                        default:
                            {
                                throw new InvalidOperationException();
                            }
                    }
                }

                writer.WriteEndDocument();

                return CreateResult(writer, DocumentationFileKind.Namespace, namespaceSymbol);

                void WriteTypes(
                    IEnumerable<INamedTypeSymbol> types,
                    TypeKind typeKind)
                {
                    writer.WriteTable(
                        types.Where(f => f.TypeKind == typeKind),
                        Resources.GetPluralName(typeKind),
                        headingLevel: 2,
                        Resources.GetName(typeKind),
                        Resources.SummaryTitle,
                        SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters,
                        addLink: Options.Depth <= DocumentationDepth.Type);
                }

                IEnumerable<NamespaceDocumentationParts> GetContentParts()
                {
                    foreach (NamespaceDocumentationParts part in EnabledAndSortedNamespaceParts)
                    {
                        if (IsAvailable(part))
                            yield return part;
                    }
                }

                bool IsAvailable(NamespaceDocumentationParts part)
                {
                    switch (part)
                    {
                        case NamespaceDocumentationParts.Content:
                        case NamespaceDocumentationParts.Summary:
                        case NamespaceDocumentationParts.ContainingNamespace:
                            {
                                return false;
                            }
                        case NamespaceDocumentationParts.Examples:
                            {
                                return xmlDocumentation?.HasElement(WellKnownTags.Example) == true;
                            }
                        case NamespaceDocumentationParts.Remarks:
                            {
                                return xmlDocumentation?.HasElement(WellKnownTags.Remarks) == true;
                            }
                        case NamespaceDocumentationParts.Classes:
                            {
                                return typeSymbols.Any(f => f.TypeKind == TypeKind.Class);
                            }
                        case NamespaceDocumentationParts.Structs:
                            {
                                return typeSymbols.Any(f => f.TypeKind == TypeKind.Struct);
                            }
                        case NamespaceDocumentationParts.Interfaces:
                            {
                                return typeSymbols.Any(f => f.TypeKind == TypeKind.Interface);
                            }
                        case NamespaceDocumentationParts.Enums:
                            {
                                return typeSymbols.Any(f => f.TypeKind == TypeKind.Enum);
                            }
                        case NamespaceDocumentationParts.Delegates:
                            {
                                return typeSymbols.Any(f => f.TypeKind == TypeKind.Delegate);
                            }
                        case NamespaceDocumentationParts.SeeAlso:
                            {
                                return xmlDocumentation?.Elements(WellKnownTags.SeeAlso).Any() == true;
                            }
                        default:
                            {
                                throw new InvalidOperationException();
                            }
                    }
                }
            }
        }

        private DocumentationGeneratorResult GenerateExternalTypesExtensions()
        {
            IEnumerable<INamedTypeSymbol> extendedExternalTypes = DocumentationModel.GetExtendedExternalTypes()
                .Where(f => !Options.ShouldBeIgnored(f));

            IEnumerable<INamespaceSymbol> namespaces = extendedExternalTypes
                .Select(f => f.ContainingNamespace)
                .Distinct(MetadataNameEqualityComparer<INamespaceSymbol>.Instance);

            if (!namespaces.Any())
                return CreateResult(null, DocumentationFileKind.Extensions);

            using (DocumentationWriter writer = CreateWriter())
            {
                writer.WriteStartDocument();

                writer.WriteLinkDestination(WellKnownNames.TopFragmentName);
                writer.WriteLine();
                writer.WriteStartHeading(1);
                writer.WriteString(Resources.ExtensionsOfExternalTypesTitle);
                writer.WriteEndHeading();

                writer.WriteLink(Resources.HomeTitle, UrlProvider.GetUrlToRoot(0, '/'));
                writer.WriteContentSeparator();
                writer.WriteLink(Resources.NamespacesTitle, UrlProvider.GetFragment(Resources.NamespacesTitle));

                writer.WriteContent(extendedExternalTypes
                    .Select(f => f.TypeKind.ToNamespaceDocumentationPart())
                    .Where(f => (Options.IgnoredNamespaceParts & f) == 0)
                    .Distinct()
                    .OrderBy(f => f, NamespacePartComparer)
                    .Select(f => Resources.GetHeading(f)), beginWithSeparator: true);

                writer.WriteList(namespaces, Resources.NamespacesTitle, 2, SymbolDisplayFormats.TypeNameAndContainingTypesAndNamespaces);

                foreach (IGrouping<TypeKind, INamedTypeSymbol> typesByKind in extendedExternalTypes
                    .Where(f => (Options.IgnoredNamespaceParts & f.TypeKind.ToNamespaceDocumentationPart()) == 0)
                    .GroupBy(f => f.TypeKind)
                    .OrderBy(f => f.Key.ToNamespaceDocumentationPart(), NamespacePartComparer))
                {
                    writer.WriteList(
                        typesByKind,
                        Resources.GetPluralName(typesByKind.Key),
                        headingLevel: 2,
                        SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters,
                        includeContainingNamespace: true,
                        canCreateExternalUrl: false);
                }

                writer.WriteEndDocument();

                return CreateResult(writer, DocumentationFileKind.Extensions);
            }
        }

        private DocumentationGeneratorResult GenerateExtendedExternalType(INamedTypeSymbol typeSymbol)
        {
            using (DocumentationWriter writer = CreateWriter(typeSymbol))
            {
                writer.WriteStartDocument();
                writer.WriteLinkDestination(WellKnownNames.TopFragmentName);
                writer.WriteLine();
                writer.WriteStartHeading(1);
                writer.WriteLink(typeSymbol, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters);
                writer.WriteSpace();
                writer.WriteString(Resources.GetName(typeSymbol.TypeKind));
                writer.WriteSpace();
                writer.WriteString(Resources.ExtensionsTitle);
                writer.WriteEndHeading();
                writer.WriteContent(Array.Empty<string>(), addLinkToRoot: true);

                writer.WriteTable(
                    DocumentationModel.GetExtensionMethods(typeSymbol),
                    heading: null,
                    headingLevel: -1,
                    Resources.ExtensionMethodTitle,
                    Resources.SummaryTitle,
                    SymbolDisplayFormats.SimpleDeclaration);

                writer.WriteEndDocument();

                return CreateResult(writer, DocumentationFileKind.Type, typeSymbol);
            }
        }

        private DocumentationGeneratorResult GenerateType(TypeDocumentationModel typeModel)
        {
            INamedTypeSymbol typeSymbol = typeModel.Symbol;

            ImmutableArray<INamedTypeSymbol> nestedTypes = default;

            ImmutableArray<INamedTypeSymbol> derivedTypes = ImmutableArray<INamedTypeSymbol>.Empty;

            if (EnabledAndSortedTypeParts.Contains(TypeDocumentationParts.Derived))
            {
                derivedTypes = (Options.IncludeAllDerivedTypes)
                    ? typeModel.GetAllDerivedTypes().ToImmutableArray()
                    : typeModel.GetDerivedTypes().ToImmutableArray();
            }

            bool includeInherited = typeSymbol.TypeKind != TypeKind.Interface || Options.IncludeInheritedInterfaceMembers;

            SymbolXmlDocumentation xmlDocumentation = DocumentationModel.GetXmlDocumentation(typeModel.Symbol, Options.PreferredCultureName);

            using (DocumentationWriter writer = CreateWriter(typeSymbol))
            {
                writer.WriteStartDocument();

                writer.WriteHeading(1, typeSymbol, SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters, SymbolDisplayAdditionalMemberOptions.UseItemPropertyName | SymbolDisplayAdditionalMemberOptions.UseOperatorName, addLink: false, linkDestination: WellKnownNames.TopFragmentName);

                foreach (TypeDocumentationParts part in EnabledAndSortedTypeParts)
                {
                    switch (part)
                    {
                        case TypeDocumentationParts.Content:
                            {
                                writer.WriteContent(GetContentParts().OrderBy(f => f, TypePartComparer).Select(f => Resources.GetHeading(f)), addLinkToRoot: true);
                                break;
                            }
                        case TypeDocumentationParts.ContainingNamespace:
                            {
                                INamespaceSymbol containingNamespace = typeSymbol.ContainingNamespace;

                                if (containingNamespace != null)
                                    writer.WriteContainingNamespace(containingNamespace, Resources.NamespaceTitle);

                                break;
                            }
                        case TypeDocumentationParts.ContainingAssembly:
                            {
                                writer.WriteContainingAssembly(typeSymbol, Resources.AssemblyTitle);
                                break;
                            }
                        case TypeDocumentationParts.ObsoleteMessage:
                            {
                                if (typeSymbol.HasAttribute(MetadataNames.System_ObsoleteAttribute))
                                    writer.WriteObsoleteMessage(typeSymbol);

                                break;
                            }
                        case TypeDocumentationParts.Summary:
                            {
                                if (xmlDocumentation != null)
                                    writer.WriteSummary(typeSymbol, xmlDocumentation);

                                break;
                            }
                        case TypeDocumentationParts.Declaration:
                            {
                                writer.WriteDeclaration(typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.TypeParameters:
                            {
                                writer.WriteTypeParameters(typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.Parameters:
                            {
                                writer.WriteParameters(typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.ReturnValue:
                            {
                                if (xmlDocumentation != null)
                                    writer.WriteReturnValue(typeSymbol, xmlDocumentation);

                                break;
                            }
                        case TypeDocumentationParts.Inheritance:
                            {
                                writer.WriteInheritance(typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.Attributes:
                            {
                                writer.WriteAttributes(typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.Derived:
                            {
                                if (derivedTypes.Any())
                                    writer.WriteDerivedTypes(derivedTypes);

                                break;
                            }
                        case TypeDocumentationParts.Implements:
                            {
                                writer.WriteImplementedInterfaces(typeModel.GetImplementedInterfaces(Options.OmitIEnumerable));
                                break;
                            }
                        case TypeDocumentationParts.Examples:
                            {
                                if (xmlDocumentation != null)
                                    writer.WriteExamples(typeSymbol, xmlDocumentation);

                                break;
                            }
                        case TypeDocumentationParts.Remarks:
                            {
                                if (xmlDocumentation != null)
                                    writer.WriteRemarks(typeSymbol, xmlDocumentation);

                                break;
                            }
                        case TypeDocumentationParts.Constructors:
                            {
                                writer.WriteConstructors(typeModel.GetConstructors());
                                break;
                            }
                        case TypeDocumentationParts.Fields:
                            {
                                if (typeModel.TypeKind == TypeKind.Enum)
                                {
                                    writer.WriteEnumFields(typeModel.GetFields(), typeSymbol);
                                }
                                else
                                {
                                    writer.WriteFields(typeModel.GetFields(includeInherited: true), containingType: typeSymbol);
                                }

                                break;
                            }
                        case TypeDocumentationParts.Indexers:
                            {
                                writer.WriteIndexers(typeModel.GetIndexers(includeInherited: includeInherited), containingType: typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.Properties:
                            {
                                writer.WriteProperties(typeModel.GetProperties(includeInherited: includeInherited), containingType: typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.Methods:
                            {
                                writer.WriteMethods(typeModel.GetMethods(includeInherited: includeInherited), containingType: typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.Operators:
                            {
                                writer.WriteOperators(typeModel.GetOperators(includeInherited: true), containingType: typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.Events:
                            {
                                writer.WriteEvents(typeModel.GetEvents(includeInherited: includeInherited), containingType: typeSymbol);
                                break;
                            }
                        case TypeDocumentationParts.ExplicitInterfaceImplementations:
                            {
                                writer.WriteExplicitInterfaceImplementations(typeModel.GetExplicitInterfaceImplementations());
                                break;
                            }
                        case TypeDocumentationParts.ExtensionMethods:
                            {
                                writer.WriteExtensionMethods(typeModel.GetExtensionMethods());
                                break;
                            }
                        case TypeDocumentationParts.Classes:
                            {
                                if (nestedTypes.IsDefault)
                                    nestedTypes = typeSymbol.GetTypeMembers();

                                WriteTypes(writer, nestedTypes, TypeKind.Class);
                                break;
                            }
                        case TypeDocumentationParts.Structs:
                            {
                                if (nestedTypes.IsDefault)
                                    nestedTypes = typeSymbol.GetTypeMembers();

                                WriteTypes(writer, nestedTypes, TypeKind.Struct);
                                break;
                            }
                        case TypeDocumentationParts.Interfaces:
                            {
                                if (nestedTypes.IsDefault)
                                    nestedTypes = typeSymbol.GetTypeMembers();

                                WriteTypes(writer, nestedTypes, TypeKind.Interface);
                                break;
                            }
                        case TypeDocumentationParts.Enums:
                            {
                                if (nestedTypes.IsDefault)
                                    nestedTypes = typeSymbol.GetTypeMembers();

                                WriteTypes(writer, nestedTypes, TypeKind.Enum);
                                break;
                            }
                        case TypeDocumentationParts.Delegates:
                            {
                                if (nestedTypes.IsDefault)
                                    nestedTypes = typeSymbol.GetTypeMembers();

                                WriteTypes(writer, nestedTypes, TypeKind.Delegate);
                                break;
                            }
                        case TypeDocumentationParts.SeeAlso:
                            {
                                if (xmlDocumentation != null)
                                    writer.WriteSeeAlso(typeSymbol, xmlDocumentation);

                                break;
                            }
                    }
                }

                if (derivedTypes.Any()
                    && derivedTypes.Length > Options.MaxDerivedTypes)
                {
                    if (Options.IncludeClassHierarchy)
                    {
                        writer.WriteHeading(2, Resources.DerivedAllTitle);

                        writer.WriteClassHierarchy(
                            typeSymbol,
                            derivedTypes,
                            SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters,
                            includeContainingNamespace: Options.IncludeContainingNamespace,
                            addBaseType: false,
                            addSeparatorAtIndex: (derivedTypes.Length > Options.MaxDerivedTypes) ? Options.MaxDerivedTypes : -1);

                        writer.WriteLine();
                    }
                    else
                    {
                        writer.WriteList(
                            derivedTypes,
                            heading: Resources.DerivedAllTitle,
                            headingLevel: 2,
                            format: SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters,
                            includeContainingNamespace: Options.IncludeContainingNamespace);
                    }
                }

                writer.WriteEndDocument();

                return CreateResult(writer, DocumentationFileKind.Type, typeSymbol);
            }

            void WriteTypes(
                DocumentationWriter writer,
                IEnumerable<INamedTypeSymbol> types,
                TypeKind typeKind)
            {
                writer.WriteTable(
                    types.Where(f => f.TypeKind == typeKind && DocumentationModel.IsVisible(f)),
                    Resources.GetPluralName(typeKind),
                    headingLevel: 2,
                    Resources.GetName(typeKind),
                    Resources.SummaryTitle,
                    SymbolDisplayFormats.TypeNameAndTypeParameters);
            }

            IEnumerable<TypeDocumentationParts> GetContentParts()
            {
                foreach (TypeDocumentationParts part in EnabledAndSortedTypeParts)
                {
                    if (IsAvailable(part))
                        yield return part;
                }
            }

            bool IsAvailable(TypeDocumentationParts part)
            {
                switch (part)
                {
                    case TypeDocumentationParts.Content:
                    case TypeDocumentationParts.ContainingNamespace:
                    case TypeDocumentationParts.ContainingAssembly:
                    case TypeDocumentationParts.ObsoleteMessage:
                    case TypeDocumentationParts.Summary:
                    case TypeDocumentationParts.Declaration:
                    case TypeDocumentationParts.TypeParameters:
                    case TypeDocumentationParts.Parameters:
                    case TypeDocumentationParts.ReturnValue:
                    case TypeDocumentationParts.Inheritance:
                    case TypeDocumentationParts.Attributes:
                    case TypeDocumentationParts.Derived:
                    case TypeDocumentationParts.Implements:
                        {
                            return false;
                        }
                    case TypeDocumentationParts.Examples:
                        {
                            return xmlDocumentation?.HasElement(WellKnownTags.Example) == true;
                        }
                    case TypeDocumentationParts.Remarks:
                        {
                            return xmlDocumentation?.HasElement(WellKnownTags.Remarks) == true;
                        }
                    case TypeDocumentationParts.Constructors:
                        {
                            return typeModel.GetConstructors().Any();
                        }
                    case TypeDocumentationParts.Fields:
                        {
                            if (typeModel.TypeKind == TypeKind.Enum)
                            {
                                return typeModel.GetFields().Any();
                            }
                            else
                            {
                                return typeModel.GetFields(includeInherited: true).Any();
                            }
                        }
                    case TypeDocumentationParts.Indexers:
                        {
                            return typeModel.GetIndexers(includeInherited: includeInherited).Any();
                        }
                    case TypeDocumentationParts.Properties:
                        {
                            return typeModel.GetProperties(includeInherited: includeInherited).Any();
                        }
                    case TypeDocumentationParts.Methods:
                        {
                            return typeModel.GetMethods(includeInherited: includeInherited).Any();
                        }
                    case TypeDocumentationParts.Operators:
                        {
                            return typeModel.GetOperators(includeInherited: true).Any();
                        }
                    case TypeDocumentationParts.Events:
                        {
                            return typeModel.GetEvents(includeInherited: includeInherited).Any();
                        }
                    case TypeDocumentationParts.ExplicitInterfaceImplementations:
                        {
                            return typeModel.GetExplicitInterfaceImplementations().Any();
                        }
                    case TypeDocumentationParts.ExtensionMethods:
                        {
                            return typeModel.GetExtensionMethods().Any();
                        }
                    case TypeDocumentationParts.Classes:
                        {
                            if (nestedTypes.IsDefault)
                                nestedTypes = typeSymbol.GetTypeMembers();

                            return nestedTypes.Any(f => f.TypeKind == TypeKind.Class && DocumentationModel.IsVisible(f));
                        }
                    case TypeDocumentationParts.Structs:
                        {
                            if (nestedTypes.IsDefault)
                                nestedTypes = typeSymbol.GetTypeMembers();

                            return nestedTypes.Any(f => f.TypeKind == TypeKind.Struct && DocumentationModel.IsVisible(f));
                        }
                    case TypeDocumentationParts.Interfaces:
                        {
                            if (nestedTypes.IsDefault)
                                nestedTypes = typeSymbol.GetTypeMembers();

                            return nestedTypes.Any(f => f.TypeKind == TypeKind.Interface && DocumentationModel.IsVisible(f));
                        }
                    case TypeDocumentationParts.Enums:
                        {
                            if (nestedTypes.IsDefault)
                                nestedTypes = typeSymbol.GetTypeMembers();

                            return nestedTypes.Any(f => f.TypeKind == TypeKind.Enum && DocumentationModel.IsVisible(f));
                        }
                    case TypeDocumentationParts.Delegates:
                        {
                            if (nestedTypes.IsDefault)
                                nestedTypes = typeSymbol.GetTypeMembers();

                            return nestedTypes.Any(f => f.TypeKind == TypeKind.Delegate && DocumentationModel.IsVisible(f));
                        }
                    case TypeDocumentationParts.SeeAlso:
                        {
                            return xmlDocumentation?.Elements(WellKnownTags.SeeAlso).Any() == true;
                        }
                    default:
                        {
                            throw new InvalidOperationException();
                        }
                }
            }
        }

        private IEnumerable<DocumentationGeneratorResult> GenerateMembers(TypeDocumentationModel typeModel)
        {
            if (!typeModel.TypeKind.Is(TypeKind.Enum, TypeKind.Delegate))
            {
                foreach (MemberDocumentationModel model in typeModel.CreateMemberModels(Options.IgnoredTypeParts))
                {
                    using (DocumentationWriter writer = CreateWriter(model.Symbol))
                    {
                        writer.WriteStartDocument();

                        MemberDocumentationWriter memberWriter = MemberDocumentationWriter.Create(model.Symbol, writer);

                        memberWriter.WriteMember(model);

                        writer.WriteEndDocument();

                        yield return CreateResult(writer, DocumentationFileKind.Member, model.Symbol);
                    }
                }
            }
        }

        private DocumentationGeneratorResult CreateResult(DocumentationWriter writer, DocumentationFileKind kind, ISymbol symbol = null)
        {
            string fileName = UrlProvider.GetFileName(kind);

            return new DocumentationGeneratorResult(writer?.ToString(), GetPath(), kind);

            string GetPath()
            {
                switch (kind)
                {
                    case DocumentationFileKind.Root:
                    case DocumentationFileKind.Extensions:
                        return fileName;
                    case DocumentationFileKind.Namespace:
                    case DocumentationFileKind.Type:
                    case DocumentationFileKind.Member:
                        return DocumentationUrlProvider.GetUrl(fileName, UrlProvider.GetFolders(symbol), Path.DirectorySeparatorChar);
                    default:
                        throw new ArgumentException("", nameof(kind));
                }
            }
        }
    }
}
