// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Roslynator.Documentation
{
    internal class MemberDocumentationWriter
    {
        private ImmutableArray<MemberDocumentationParts> _enabledAndSortedMemberParts;

        protected MemberDocumentationWriter(DocumentationWriter writer)
        {
            Writer = writer;
        }

        public DocumentationWriter Writer { get; }

        public DocumentationModel DocumentationModel => Writer.DocumentationModel;

        public DocumentationOptions Options => Writer.Options;

        public DocumentationResources Resources => Writer.Resources;

        public virtual IComparer<MemberDocumentationParts> Comparer
        {
            get { return MemberDocumentationPartComparer.Instance; }
        }

        internal ImmutableArray<MemberDocumentationParts> EnabledAndSortedMemberParts
        {
            get
            {
                if (_enabledAndSortedMemberParts.IsDefault)
                {
                    _enabledAndSortedMemberParts = Enum.GetValues(typeof(MemberDocumentationParts))
                        .Cast<MemberDocumentationParts>()
                        .Where(f => f != MemberDocumentationParts.None
                            && f != MemberDocumentationParts.All
                            && (Options.IgnoredMemberParts & f) == 0)
                        .OrderBy(f => f, Comparer)
                        .ToImmutableArray();
                }

                return _enabledAndSortedMemberParts;
            }
        }

        public virtual void WriteTitle(ISymbol symbol, bool isOverloaded)
        {
            Writer.WriteLinkDestination(WellKnownNames.TopFragmentName);
            Writer.WriteLine();

            Writer.WriteStartHeading(1);

            SymbolDisplayFormat format = (isOverloaded)
                ? SymbolDisplayFormats.OverloadedMemberTitle
                : SymbolDisplayFormats.MemberTitle;

            Writer.WriteString(symbol.ToDisplayString(format, SymbolDisplayAdditionalMemberOptions.UseItemPropertyName | SymbolDisplayAdditionalMemberOptions.UseOperatorName));
            Writer.WriteSpace();
            Writer.WriteString(Resources.GetName(symbol));
            Writer.WriteEndHeading();
        }

        public virtual void WriteImplements(ISymbol symbol)
        {
            SymbolDisplayFormat format = SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters;
            bool includeContainingNamespace = Options.IncludeContainingNamespace(OmitContainingNamespaceParts.ImplementedMember);
            const SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.UseItemPropertyName;

            using (IEnumerator<ISymbol> en = symbol.FindImplementedInterfaceMembers()
                .Sort(format, systemNamespaceFirst: Options.PlaceSystemNamespaceFirst, includeContainingNamespace: includeContainingNamespace, additionalOptions: additionalOptions)
                .GetEnumerator())
            {
                if (en.MoveNext())
                {
                    Writer.WriteHeading(3, Resources.ImplementsTitle);

                    Writer.WriteStartBulletList();

                    do
                    {
                        Writer.WriteStartBulletItem();

                        Writer.WriteLink(en.Current, format, additionalOptions, includeContainingNamespace: includeContainingNamespace);
                        Writer.WriteEndBulletItem();
                    }
                    while (en.MoveNext());

                    Writer.WriteEndBulletList();
                }
            }
        }

        public void WriteContent(ISymbol symbol, int headingLevelBase = 0)
        {
            SymbolXmlDocumentation xmlDocumentation = DocumentationModel.GetXmlDocumentation(symbol, Options.PreferredCultureName);

            foreach (MemberDocumentationParts part in EnabledAndSortedMemberParts)
            {
                switch (part)
                {
                    case MemberDocumentationParts.ObsoleteMessage:
                        {
                            if (symbol.HasAttribute(MetadataNames.System_ObsoleteAttribute))
                                Writer.WriteObsoleteMessage(symbol);

                            break;
                        }
                    case MemberDocumentationParts.Summary:
                        {
                            if (xmlDocumentation != null)
                                Writer.WriteSummary(symbol, xmlDocumentation, headingLevelBase: headingLevelBase);

                            break;
                        }
                    case MemberDocumentationParts.Declaration:
                        {
                            Writer.WriteDeclaration(symbol);
                            break;
                        }
                    case MemberDocumentationParts.TypeParameters:
                        {
                            Writer.WriteTypeParameters(symbol.GetTypeParameters());
                            break;
                        }
                    case MemberDocumentationParts.Parameters:
                        {
                            Writer.WriteParameters(symbol.GetParameters());
                            break;
                        }
                    case MemberDocumentationParts.ReturnValue:
                        {
                            Writer.WriteReturnType(symbol, xmlDocumentation);
                            break;
                        }
                    case MemberDocumentationParts.Implements:
                        {
                            WriteImplements(symbol);
                            break;
                        }
                    case MemberDocumentationParts.Attributes:
                        {
                            Writer.WriteAttributes(symbol);
                            break;
                        }
                    case MemberDocumentationParts.Exceptions:
                        {
                            if (xmlDocumentation != null)
                                Writer.WriteExceptions(symbol, xmlDocumentation);

                            break;
                        }
                    case MemberDocumentationParts.Examples:
                        {
                            if (xmlDocumentation != null)
                                Writer.WriteExamples(symbol, xmlDocumentation, headingLevelBase: headingLevelBase);

                            break;
                        }
                    case MemberDocumentationParts.Remarks:
                        {
                            if (xmlDocumentation != null)
                                Writer.WriteRemarks(symbol, xmlDocumentation, headingLevelBase: headingLevelBase);

                            break;
                        }
                    case MemberDocumentationParts.SeeAlso:
                        {
                            if (xmlDocumentation != null)
                                Writer.WriteSeeAlso(symbol, xmlDocumentation, headingLevelBase: headingLevelBase);

                            break;
                        }
                }
            }
        }

        public static MemberDocumentationWriter Create(ISymbol symbol, DocumentationWriter writer)
        {
            switch (symbol.Kind)
            {
                case SymbolKind.Event:
                    {
                        return new EventDocumentationWriter(writer, (IEventSymbol)symbol);
                    }
                case SymbolKind.Field:
                    {
                        return new FieldDocumentationWriter(writer, (IFieldSymbol)symbol);
                    }
                case SymbolKind.Method:
                    {
                        var methodSymbol = (IMethodSymbol)symbol;

                        switch (methodSymbol.MethodKind)
                        {
                            case MethodKind.Constructor:
                                {
                                    return new ConstructorDocumentationWriter(writer, methodSymbol);
                                }
                            case MethodKind.UserDefinedOperator:
                            case MethodKind.Conversion:
                                {
                                    return new OperatorDocumentationWriter(writer, methodSymbol);
                                }
                        }

                        return new MethodDocumentationWriter(writer, methodSymbol);
                    }
                case SymbolKind.Property:
                    {
                        return new PropertyDocumentationWriter(writer, (IPropertySymbol)symbol);
                    }
            }

            throw new InvalidOperationException();
        }

        private class ConstructorDocumentationWriter : MemberDocumentationWriter
        {
            public ConstructorDocumentationWriter(DocumentationWriter writer, IMethodSymbol methodSymbol) : base(writer)
            {
                MethodSymbol = methodSymbol;
            }

            public IMethodSymbol MethodSymbol { get; }

            public override void WriteTitle(ISymbol symbol, bool isOverloaded)
            {
                Writer.WriteStartHeading(1);

                if (!isOverloaded)
                {
                    Writer.WriteString(symbol.ToDisplayString(SymbolDisplayFormats.SimpleDeclaration));
                    Writer.WriteSpace();
                    Writer.WriteString(Resources.ConstructorTitle);
                }
                else
                {
                    Writer.WriteString(symbol.ContainingType.ToDisplayString(SymbolDisplayFormats.TypeNameAndContainingTypesAndTypeParameters));
                    Writer.WriteSpace();
                    Writer.WriteString(Resources.ConstructorsTitle);
                }

                Writer.WriteEndHeading();
            }
        }

        private class EventDocumentationWriter : MemberDocumentationWriter
        {
            public EventDocumentationWriter(DocumentationWriter writer, IEventSymbol eventSymbol) : base(writer)
            {
                EventSymbol = eventSymbol;
            }

            public IEventSymbol EventSymbol { get; }
        }

        private class FieldDocumentationWriter : MemberDocumentationWriter
        {
            public FieldDocumentationWriter(DocumentationWriter writer, IFieldSymbol fieldSymbol) : base(writer)
            {
                FieldSymbol = fieldSymbol;
            }

            public IFieldSymbol FieldSymbol { get; }
        }

        private class MethodDocumentationWriter : MemberDocumentationWriter
        {
            public MethodDocumentationWriter(DocumentationWriter writer, IMethodSymbol methodSymbol) : base(writer)
            {
                MethodSymbol = methodSymbol;
            }

            public IMethodSymbol MethodSymbol { get; }
        }

        private class OperatorDocumentationWriter : MemberDocumentationWriter
        {
            public OperatorDocumentationWriter(DocumentationWriter writer, IMethodSymbol methodSymbol) : base(writer)
            {
                MethodSymbol = methodSymbol;
            }

            public IMethodSymbol MethodSymbol { get; }
        }

        private class PropertyDocumentationWriter : MemberDocumentationWriter
        {
            public PropertyDocumentationWriter(DocumentationWriter writer, IPropertySymbol propertySymbol) : base(writer)
            {
                PropertySymbol = propertySymbol;
            }

            public IPropertySymbol PropertySymbol { get; }
        }
    }
}
