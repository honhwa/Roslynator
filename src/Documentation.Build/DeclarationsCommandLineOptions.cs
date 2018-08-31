// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using CommandLine;
using static Roslynator.Documentation.DeclarationListOptions;

namespace Roslynator.Documentation
{
    //TODO: no-precedence-for-system
    [Verb("declarations")]
    public class DeclarationsCommandLineOptions
    {
        [Option(longName: "assemblies", shortName: 'a', Required = true)]
        public IEnumerable<string> Assemblies { get; set; }

        [Option(longName: "output", shortName: 'o', Required = true)]
        public string OutputPath { get; set; }

        [Option(longName: "references", shortName: 'r', Required = true)]
        public string References { get; set; }

        [Option(longName: "additional-xml-documentation")]
        public IEnumerable<string> AdditionalXmlDocumentation { get; set; }

        [Option(longName: "empty-line-between-members", Default = DefaultValues.EmptyLineBetweenMembers)]
        public bool EmptyLineBetweenMembers { get; set; }

        [Option(longName: "format-base-list", Default = DefaultValues.FormatBaseList)]
        public bool FormatBaseList { get; set; }

        [Option(longName: "format-constraints", Default = DefaultValues.FormatConstraints)]
        public bool FormatConstraints { get; set; }

        [Option(longName: "ignored-names")]
        public IEnumerable<string> IgnoredNames { get; set; }

        [Option(longName: "include-ienumerable", Default = !DefaultValues.OmitIEnumerable)]
        public bool IncludeIEnumerable { get; set; }

        [Option(longName: "indent-chars", Default = DefaultValues.IndentChars)]
        public string IndentChars { get; set; }

        [Option(longName: "merge-attributes", Default = !DefaultValues.SplitAttributes)]
        public bool MergeAttributes { get; set; }

        [Option(longName: "no-indent", Default = !DefaultValues.Indent)]
        public bool NoIndent { get; set; }

        [Option(longName: "no-default-literal", Default = !DefaultValues.UseDefaultLiteral)]
        public bool NoDefaultLiteral { get; set; }

        [Option(longName: "no-new-line-before-open-brace", Default = !DefaultValues.NewLineBeforeOpenBrace)]
        public bool NoNewLineBeforeOpenBrace { get; set; }

        [Option(longName: "no-precedence-for-system", Default = !DocumentationOptions.DefaultValues.PlaceSystemNamespaceFirst)]
        public bool NoPrecedenceForSystem { get; set; }

        [Option(longName: "omit-attribute-arguments", Default = !DefaultValues.IncludeAttributeArguments)]
        public bool OmitAttributeArguments { get; set; }
    }
}
