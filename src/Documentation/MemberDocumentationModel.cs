// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Microsoft.CodeAnalysis;

namespace Roslynator.Documentation
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public sealed class MemberDocumentationModel : IEquatable<MemberDocumentationModel>
    {
        internal MemberDocumentationModel(
            ISymbol symbol,
            DocumentationModel documentationModel)
        {
            Symbol = symbol;
            DocumentationModel = documentationModel;
        }

        public ISymbol Symbol { get; }

        internal DocumentationModel DocumentationModel { get; }

        public IAssemblySymbol ContainingAssembly => Symbol.ContainingAssembly;

        public INamespaceSymbol ContainingNamespace => Symbol.ContainingNamespace;

        public INamedTypeSymbol ContainingType => Symbol.ContainingType;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get { return $"{Symbol.Kind} {Symbol.ToDisplayString(Roslynator.SymbolDisplayFormats.Test)}"; }
        }

        public bool Equals(MemberDocumentationModel other)
        {
            return Symbol.Equals(other);
        }

        public override bool Equals(object obj)
        {
            return obj is MemberDocumentationModel other
                && Equals(other);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }
    }
}
