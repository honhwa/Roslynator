﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;

namespace Roslynator.Documentation
{
    public class OperatorDocumentationMarkdownWriter : MemberDocumentationWriter
    {
        public OperatorDocumentationMarkdownWriter(
            ImmutableArray<ISymbol> symbols,
            SymbolDocumentationInfo directoryInfo,
            DocumentationGenerator generator) : base(symbols, directoryInfo, generator)
        {
        }

        public override string CategoryName => "Operator";

        public override void WriteTitle(ISymbol symbol)
        {
            WriteStartHeading(1 + HeadingBaseLevel);

            SymbolDisplayFormat format = (Symbols.Length == 1) ? FormatProvider.MemberTitleFormat : FormatProvider.OverloadedMemberTitleFormat;

            WriteString(symbol.ToDisplayString(format, SymbolDisplayAdditionalOptions.UseOperatorName));
            WriteString(" ");
            WriteString(CategoryName);
            WriteEndHeading();
        }

        public override void WriteMemberTitle(ISymbol symbol)
        {
            if (Symbols.Length > 1)
            {
                WriteStartHeading(1 + HeadingBaseLevel);
                WriteString(symbol.ToDisplayString(FormatProvider.MethodFormat, SymbolDisplayAdditionalOptions.UseOperatorName));
                WriteEndHeading();
            }
        }

        public override void WriteContent(ISymbol symbol)
        {
            WriteSummary(symbol);
            WriteSignature(symbol);
            WriteParameters(symbol);
            WriteValue((IMethodSymbol)symbol);
            WriteAttributes(symbol);
            WriteExceptions(symbol);
            WriteExamples(symbol);
            WriteRemarks(symbol);
            WriteSeeAlso(symbol);
        }

        private void WriteValue(IMethodSymbol methodSymbol)
        {
            WriteHeading(3 + HeadingBaseLevel, "Returns");
            WriteLink(Generator.GetDocumentationInfo(methodSymbol.ReturnType), SymbolDisplayAdditionalOptions.None);
            WriteLine();
            WriteLine();

            XElement element = Generator.GetDocumentationElement(methodSymbol, "returns");

            if (element != null)
            {
                WriteElementContent(element);
                WriteLine();
                WriteLine();
            }
        }
    }
}