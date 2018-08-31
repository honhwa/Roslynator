// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Roslynator.Documentation
{
    public class DocumentationOptions
    {
        private readonly ImmutableArray<MetadataName> _ignoredMetadataNames;

        public DocumentationOptions(
            IEnumerable<string> ignoredNames = null,
            string preferredCultureName = null,
            string baseLocalUrl = null,
            int maxDerivedTypes = DefaultValues.MaxDerivedTypes,
            bool includeClassHierarchy = DefaultValues.IncludeClassHierarchy,
            bool includeContainingNamespace = DefaultValues.IncludeContainingNamespace,
            bool placeSystemNamespaceFirst = DefaultValues.PlaceSystemNamespaceFirst,
            bool formatDeclarationBaseList = DefaultValues.FormatDeclarationBaseList,
            bool formatDeclarationConstraints = DefaultValues.FormatDeclarationConstraints,
            bool markObsolete = DefaultValues.MarkObsolete,
            bool includeMemberInheritedFrom = DefaultValues.IncludeMemberInheritedFrom,
            bool includeMemberOverrides = DefaultValues.IncludeMemberOverrides,
            bool includeMemberImplements = DefaultValues.IncludeMemberImplements,
            bool includeMemberConstantValue = DefaultValues.IncludeMemberConstantValue,
            bool includeInheritedInterfaceMembers = DefaultValues.IncludeInheritedInterfaceMembers,
            bool includeAllDerivedTypes = DefaultValues.IncludeInheritedInterfaceMembers,
            bool includeAttributeArguments = DefaultValues.IncludeAttributeArguments,
            bool omitIEnumerable = DefaultValues.OmitIEnumerable,
            DocumentationDepth depth = DefaultValues.Depth,
            RootDocumentationParts ignoredRootParts = RootDocumentationParts.None,
            NamespaceDocumentationParts ignoredNamespaceParts = NamespaceDocumentationParts.None,
            TypeDocumentationParts ignoredTypeParts = TypeDocumentationParts.None,
            MemberDocumentationParts ignoredMemberParts = MemberDocumentationParts.None)
        {
            if (maxDerivedTypes < 0)
                throw new ArgumentOutOfRangeException(nameof(maxDerivedTypes), maxDerivedTypes, "Maximum number of derived items must be greater than or equal to 0.");

            _ignoredMetadataNames = ignoredNames?.Select(name => MetadataName.Parse(name)).ToImmutableArray() ?? default;

            IgnoredNames = ignoredNames?.ToImmutableArray() ?? ImmutableArray<string>.Empty;
            PreferredCultureName = preferredCultureName;
            BaseLocalUrl = baseLocalUrl;
            MaxDerivedTypes = maxDerivedTypes;
            IncludeClassHierarchy = includeClassHierarchy;
            IncludeContainingNamespace = includeContainingNamespace;
            PlaceSystemNamespaceFirst = placeSystemNamespaceFirst;
            FormatDeclarationBaseList = formatDeclarationBaseList;
            FormatDeclarationConstraints = formatDeclarationConstraints;
            MarkObsolete = markObsolete;
            IncludeMemberInheritedFrom = includeMemberInheritedFrom;
            IncludeMemberOverrides = includeMemberOverrides;
            IncludeMemberImplements = includeMemberImplements;
            IncludeMemberConstantValue = includeMemberConstantValue;
            IncludeInheritedInterfaceMembers = includeInheritedInterfaceMembers;
            IncludeAllDerivedTypes = includeAllDerivedTypes;
            IncludeAttributeArguments = includeAttributeArguments;
            OmitIEnumerable = omitIEnumerable;
            Depth = depth;
            IgnoredRootParts = ignoredRootParts;
            IgnoredNamespaceParts = ignoredNamespaceParts;
            IgnoredTypeParts = ignoredTypeParts;
            IgnoredMemberParts = ignoredMemberParts;
        }

        public static DocumentationOptions Default { get; } = new DocumentationOptions();

        public ImmutableArray<string> IgnoredNames { get; }

        public string PreferredCultureName { get; }

        public string BaseLocalUrl { get; }

        public int MaxDerivedTypes { get; }

        public bool IncludeClassHierarchy { get; }

        public bool IncludeContainingNamespace { get; }

        public bool PlaceSystemNamespaceFirst { get; }

        public bool FormatDeclarationBaseList { get; }

        public bool FormatDeclarationConstraints { get; }

        public bool MarkObsolete { get; }

        public bool IncludeMemberInheritedFrom { get; }

        public bool IncludeMemberOverrides { get; }

        public bool IncludeMemberImplements { get; }

        public bool IncludeMemberConstantValue { get; }

        public bool IncludeInheritedInterfaceMembers { get; }

        public bool IncludeAllDerivedTypes { get; }

        public bool IncludeAttributeArguments { get; }

        public bool OmitIEnumerable { get; }

        public DocumentationDepth Depth { get; }

        public RootDocumentationParts IgnoredRootParts { get; }

        public NamespaceDocumentationParts IgnoredNamespaceParts { get; }

        public TypeDocumentationParts IgnoredTypeParts { get; }

        public MemberDocumentationParts IgnoredMemberParts { get; }

        internal bool ShouldBeIgnored(INamedTypeSymbol typeSymbol)
        {
            foreach (MetadataName metadataName in _ignoredMetadataNames)
            {
                if (typeSymbol.HasMetadataName(metadataName))
                    return true;

                if (!metadataName.ContainingTypes.Any())
                {
                    INamespaceSymbol n = typeSymbol.ContainingNamespace;

                    while (n != null)
                    {
                        if (n.HasMetadataName(metadataName))
                            return true;

                        n = n.ContainingNamespace;
                    }
                }
            }

            return false;
        }

        internal static class DefaultValues
        {
            public const DocumentationDepth Depth = DocumentationDepth.Member;
            public const bool FormatDeclarationBaseList = true;
            public const bool FormatDeclarationConstraints = true;
            public const bool IncludeAllDerivedTypes = false;
            public const bool IncludeAttributeArguments = true;
            public const bool IncludeClassHierarchy = true;
            public const bool IncludeContainingNamespace = true;
            public const bool IncludeInheritedInterfaceMembers = false;
            public const bool IncludeMemberConstantValue = true;
            public const bool IncludeMemberImplements = true;
            public const bool IncludeMemberInheritedFrom = true;
            public const bool IncludeMemberOverrides = true;
            public const bool MarkObsolete = true;
            public const int MaxDerivedTypes = 5;
            public const bool OmitIEnumerable = true;
            public const bool PlaceSystemNamespaceFirst = true;
        }
    }
}
