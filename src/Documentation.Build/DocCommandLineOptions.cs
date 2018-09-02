// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using CommandLine;
using static Roslynator.Documentation.DocumentationOptions;

namespace Roslynator.Documentation
{
    [Verb("doc")]
    public class DocCommandLineOptions
    {
        [Option(longName: "assemblies", shortName: 'a', Required = true)]
        public IEnumerable<string> Assemblies { get; set; }

        [Option(longName: "heading", shortName: 'h', Required = true)]
        public string Heading { get; set; }

        [Option(longName: "output", shortName: 'o', Required = true)]
        public string OutputDirectory { get; set; }

        [Option(longName: "references", shortName: 'r', Required = true)]
        public string References { get; set; }

        [Option(longName: "additional-xml-documentation")]
        public IEnumerable<string> AdditionalXmlDocumentation { get; set; }

        [Option(longName: "depth", Default = DefaultValues.Depth)]
        public DocumentationDepth Depth { get; set; }

        [Option(longName: "ignored-member-parts")]
        public IEnumerable<string> IgnoredMemberParts { get; set; }

        [Option(longName: "ignored-names")]
        public IEnumerable<string> IgnoredNames { get; set; }

        [Option(longName: "ignored-namespace-parts")]
        public IEnumerable<string> IgnoredNamespaceParts { get; set; }

        [Option(longName: "ignored-root-parts")]
        public IEnumerable<string> IgnoredRootParts { get; set; }

        [Option(longName: "ignored-type-parts")]
        public IEnumerable<string> IgnoredTypeParts { get; set; }

        [Option(longName: "include-all-derived-types", Default = DefaultValues.IncludeAllDerivedTypes)]
        public bool IncludeAllDerivedTypes { get; set; }

        [Option(longName: "include-ienumerable", Default = !DefaultValues.OmitIEnumerable)]
        public bool IncludeIEnumerable { get; set; }

        [Option(longName: "include-inherited-interface-members", Default = DefaultValues.IncludeInheritedInterfaceMembers)]
        public bool IncludeInheritedInterfaceMembers { get; set; }

        [Option(longName: "max-derived-types", Default = DefaultValues.MaxDerivedTypes)]
        public int MaxDerivedTypes { get; set; }

        [Option(longName: "mode", Default = "github")]
        public string Mode { get; set; }

        [Option(longName: "no-class-hierarchy", Default = !DefaultValues.IncludeClassHierarchy)]
        public bool NoClassHierarchy { get; set; }

        [Option(longName: "no-delete", Default = false)]
        public bool NoDelete { get; set; }

        [Option(longName: "no-format-base-list", Default = !DefaultValues.FormatDeclarationBaseList)]
        public bool NoFormatBaseList { get; set; }

        [Option(longName: "no-format-constraints", Default = !DefaultValues.FormatDeclarationConstraints)]
        public bool NoFormatConstraints { get; set; }

        [Option(longName: "no-mark-obsolete", Default = !DefaultValues.MarkObsolete)]
        public bool NoMarkObsolete { get; set; }

        [Option(longName: "no-precedence-for-system", Default = !DefaultValues.PlaceSystemNamespaceFirst)]
        public bool NoPrecedenceForSystem { get; set; }

        [Option(longName: "omit-attribute-arguments", Default = !DefaultValues.IncludeAttributeArguments)]
        public bool OmitAttributeArguments { get; set; }

        [Option(longName: "omit-containing-namespace", Default = !DefaultValues.IncludeContainingNamespace)]
        public bool OmitContainingNamespace { get; set; }

        [Option(longName: "omit-member-constant-value", Default = !DefaultValues.IncludeMemberConstantValue)]
        public bool OmitMemberConstantValue { get; set; }

        [Option(longName: "omit-member-implements", Default = !DefaultValues.IncludeMemberImplements)]
        public bool OmitMemberImplements { get; set; }

        [Option(longName: "omit-member-inherited-from", Default = !DefaultValues.IncludeMemberInheritedFrom)]
        public bool OmitMemberInheritedFrom { get; set; }

        [Option(longName: "omit-member-overrides", Default = !DefaultValues.IncludeMemberOverrides)]
        public bool OmitMemberOverrides { get; set; }

        [Option(longName: "preferred-culture")]
        public string PreferredCulture { get; set; }
    }
}
