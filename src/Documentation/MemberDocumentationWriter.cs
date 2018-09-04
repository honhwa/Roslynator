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

        public virtual void WriteMember(MemberDocumentationModel model)
        {
            ISymbol symbol = model.Symbol;

            WriteTitle(symbol, isOverloaded: model.IsOverloaded);

            Writer.WriteContent(Array.Empty<string>(), addLinkToRoot: true);

            foreach (MemberDocumentationParts part in EnabledAndSortedMemberParts)
            {
                switch (part)
                {
                    case MemberDocumentationParts.ContainingType:
                        {
                            Writer.WriteContainingType(symbol, Resources.ContainingTypeTitle);
                            break;
                        }
                    case MemberDocumentationParts.ContainingAssembly:
                        {
                            Writer.WriteContainingAssembly(symbol, Resources.AssemblyTitle);
                            break;
                        }
                }
            }

            if (!model.IsOverloaded)
            {
                WriteContent(symbol);
            }
            else
            {
                SymbolDisplayFormat format = SymbolDisplayFormats.SimpleDeclaration;
                const SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.UseItemPropertyName | SymbolDisplayAdditionalMemberOptions.UseOperatorName;

                Writer.WriteTable(
                    model.Overloads,
                    heading: Resources.OverloadsTitle,
                    headingLevel: 2,
                    header1: Resources.GetName(symbol),
                    header2: Resources.SummaryTitle,
                    format: format,
                    additionalOptions: additionalOptions);

                foreach (ISymbol overloadSymbol in model.Overloads.OrderBy(f => f.ToDisplayString(format, additionalOptions)))
                {
                    string id = DocumentationUrlProvider.GetFragment(overloadSymbol);

                    Writer.WriteStartHeading(2);
                    Writer.WriteString(overloadSymbol.ToDisplayString(format, additionalOptions));
                    Writer.WriteSpace();
                    Writer.WriteLinkDestination(id);
                    Writer.WriteEndHeading();
                    WriteContent(overloadSymbol, headingLevelBase: 1);
                }
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

            const SymbolDisplayAdditionalMemberOptions additionalOptions = SymbolDisplayAdditionalMemberOptions.UseItemPropertyName;

            IEnumerable<ISymbol> implementedInterfaceMembers = null;

            if (Options.IncludeContainingNamespace)
            {
                implementedInterfaceMembers = symbol.FindImplementedInterfaceMembers()
                    .OrderBy(f => f.ContainingNamespace, NamespaceSymbolComparer.GetInstance(Options.PlaceSystemNamespaceFirst))
                    .ThenBy(f => f.ToDisplayString(format, additionalOptions));
            }
            else
            {
                implementedInterfaceMembers = symbol.FindImplementedInterfaceMembers()
                    .OrderBy(f => f.ToDisplayString(format, additionalOptions));
            }

            using (IEnumerator<ISymbol> en = implementedInterfaceMembers.GetEnumerator())
            {
                if (en.MoveNext())
                {
                    Writer.WriteHeading(3, Resources.ImplementsTitle);

                    Writer.WriteStartBulletList();

                    do
                    {
                        Writer.WriteStartBulletItem();

                        Writer.WriteLink(en.Current, format, additionalOptions, includeContainingNamespace: Options.IncludeContainingNamespace);
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
                            Writer.WriteTypeParameters(symbol);
                            break;
                        }
                    case MemberDocumentationParts.Parameters:
                        {
                            Writer.WriteParameters(symbol);
                            break;
                        }
                    case MemberDocumentationParts.ReturnValue:
                        {
                            Writer.WriteReturnValue(symbol, xmlDocumentation);
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
                        return new EventDocumentationWriter(writer);
                    }
                case SymbolKind.Field:
                    {
                        return new FieldDocumentationWriter(writer);
                    }
                case SymbolKind.Method:
                    {
                        var methodSymbol = (IMethodSymbol)symbol;

                        switch (methodSymbol.MethodKind)
                        {
                            case MethodKind.Constructor:
                                {
                                    return new ConstructorDocumentationWriter(writer);
                                }
                            case MethodKind.UserDefinedOperator:
                            case MethodKind.Conversion:
                                {
                                    return new OperatorDocumentationWriter(writer);
                                }
                        }

                        return new MethodDocumentationWriter(writer);
                    }
                case SymbolKind.Property:
                    {
                        return new PropertyDocumentationWriter(writer);
                    }
            }

            throw new InvalidOperationException();
        }

        private class ConstructorDocumentationWriter : MemberDocumentationWriter
        {
            public ConstructorDocumentationWriter(DocumentationWriter writer) : base(writer)
            {
            }

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
            public EventDocumentationWriter(DocumentationWriter writer) : base(writer)
            {
            }
        }

        private class FieldDocumentationWriter : MemberDocumentationWriter
        {
            public FieldDocumentationWriter(DocumentationWriter writer) : base(writer)
            {
            }
        }

        private class MethodDocumentationWriter : MemberDocumentationWriter
        {
            public MethodDocumentationWriter(DocumentationWriter writer) : base(writer)
            {
            }
        }

        private class OperatorDocumentationWriter : MemberDocumentationWriter
        {
            public OperatorDocumentationWriter(DocumentationWriter writer) : base(writer)
            {
            }
        }

        private class PropertyDocumentationWriter : MemberDocumentationWriter
        {
            public PropertyDocumentationWriter(DocumentationWriter writer) : base(writer)
            {
            }
        }
    }
}
