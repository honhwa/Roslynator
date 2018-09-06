// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace Roslynator.Documentation
{
    internal class ParameterEqualityComparer : EqualityComparer<IParameterSymbol>
    {
        public static ParameterEqualityComparer Instance { get; } = new ParameterEqualityComparer();

        public static bool ParametersEqual(ImmutableArray<IParameterSymbol> parameters1, ImmutableArray<IParameterSymbol> parameters2)
        {
            int length = parameters1.Length;

            if (length != parameters2.Length)
                return false;

            for (int i = 0; i < length; i++)
            {
                if (!Instance.Equals(parameters1[i], parameters2[i]))
                    return false;
            }

            return true;
        }

        public override bool Equals(IParameterSymbol x, IParameterSymbol y)
        {
            if (object.ReferenceEquals(x, y))
                return true;

            if (x == null)
                return false;

            if (y == null)
                return false;

            return x.RefKind == y.RefKind
                && x.Type == y.Type;
        }

        public override int GetHashCode(IParameterSymbol obj)
        {
            if (obj == null)
                return 0;

            return Hash.Combine(obj.Type, (int)obj.RefKind);
        }
    }
}
