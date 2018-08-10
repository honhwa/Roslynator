﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;

namespace Roslynator.Documentation
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public sealed class MemberDocumentationModel : SymbolDocumentationModel
    {
        internal MemberDocumentationModel(
            ISymbol symbol,
            ImmutableArray<ISymbol> overloads,
            DocumentationModel documentationModel) : base(symbol, documentationModel)
        {
            Overloads = overloads;
        }

        public ImmutableArray<ISymbol> Overloads { get; }

        public bool IsOverloaded
        {
            get { return Overloads.Length > 1; }
        }
    }
}