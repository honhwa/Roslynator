﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Roslynator.Documentation
{
    internal sealed class NamespaceSymbolComparer : IComparer<INamespaceSymbol>
    {
        public static NamespaceSymbolComparer Instance { get; } = new NamespaceSymbolComparer();

        public int Compare(INamespaceSymbol x, INamespaceSymbol y)
        {
            if (object.ReferenceEquals(x, y))
                return 0;

            if (x == null)
                return -1;

            if (y == null)
                return 1;

            if (x.IsGlobalNamespace)
            {
                return (y.IsGlobalNamespace) ? 0 : 1;
            }
            else if (y.IsGlobalNamespace)
            {
                return -1;
            }

            INamespaceSymbol a = GetRootNamespace(x);
            INamespaceSymbol b = GetRootNamespace(y);

            if (a.Name == "System")
            {
                if (b.Name != "System")
                    return -1;
            }
            else if (b.Name == "System")
            {
                return 1;
            }

            return string.Compare(
                x.ToDisplayString(SymbolDisplayFormats.TypeNameAndContainingTypesAndNamespaces),
                y.ToDisplayString(SymbolDisplayFormats.TypeNameAndContainingTypesAndNamespaces),
                StringComparison.Ordinal);
        }

        private static INamespaceSymbol GetRootNamespace(INamespaceSymbol namespaceSymbol)
        {
            INamespaceSymbol n = namespaceSymbol;

            while (true)
            {
                INamespaceSymbol containingNamespace = n.ContainingNamespace;

                if (containingNamespace.IsGlobalNamespace)
                    return n;

                n = containingNamespace;
            }
        }
    }
}