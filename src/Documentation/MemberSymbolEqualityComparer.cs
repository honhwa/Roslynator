// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Roslynator.Documentation
{
    internal class MemberSymbolEqualityComparer : EqualityComparer<ISymbol>
    {
        public static MemberSymbolEqualityComparer Instance { get; } = new MemberSymbolEqualityComparer();

        public override bool Equals(ISymbol x, ISymbol y)
        {
            if (object.ReferenceEquals(x, y))
                return true;

            if (x == null)
                return false;

            if (y == null)
                return false;

            if (x.Kind != y.Kind)
                return false;

            if (x.IsStatic != y.IsStatic)
                return false;

            if (!string.Equals(x.Name, y.Name, StringComparison.Ordinal))
                return false;

            switch (x.Kind)
            {
                case SymbolKind.Event:
                case SymbolKind.Field:
                    {
                        return true;
                    }
                case SymbolKind.Method:
                    {
                        var a = (IMethodSymbol)x;
                        var b = (IMethodSymbol)y;

                        return a.MethodKind == MethodKind.Ordinary
                            && b.MethodKind == MethodKind.Ordinary
                            && a.TypeParameters.Length == b.TypeParameters.Length
                            && ParameterEqualityComparer.ParametersEqual(a.Parameters, b.Parameters);
                    }
                case SymbolKind.Property:
                    {
                        var a = (IPropertySymbol)x;
                        var b = (IPropertySymbol)y;

                        return a.IsIndexer == b.IsIndexer
                            && ParameterEqualityComparer.ParametersEqual(a.Parameters, b.Parameters);
                    }
                case SymbolKind.NamedType:
                    {
                        var a = (INamedTypeSymbol)x;
                        var b = (INamedTypeSymbol)y;

                        if (a.TypeKind != b.TypeKind)
                            return false;

                        switch (a.TypeKind)
                        {
                            case TypeKind.Class:
                            case TypeKind.Interface:
                            case TypeKind.Struct:
                                {
                                    return a.TypeParameters.Length == b.TypeParameters.Length;
                                }
                            case TypeKind.Delegate:
                                {
                                    return a.TypeParameters.Length == b.TypeParameters.Length
                                        && ParameterEqualityComparer.ParametersEqual(a.DelegateInvokeMethod.Parameters, b.DelegateInvokeMethod.Parameters);
                                }
                            case TypeKind.Enum:
                                {
                                    return true;
                                }
                            default:
                                {
                                    throw new InvalidOperationException($"Unknown type kind '{a.TypeKind.ToString()}'.");
                                }
                        }
                    }
                default:
                    {
                        throw new InvalidOperationException($"Unknown symbol kind '{x.Kind.ToString()}'.");
                    }
            }
        }

        public override int GetHashCode(ISymbol obj)
        {
            SymbolKind kind = obj.Kind;

            if (kind == SymbolKind.NamedType)
            {
                var namedType = (INamedTypeSymbol)obj;

                TypeKind typeKind = namedType.TypeKind;

                int hashCode = Hash.Combine(StringComparer.Ordinal.GetHashCode(namedType.Name), (int)typeKind);

                switch (typeKind)
                {
                    case TypeKind.Class:
                    case TypeKind.Interface:
                    case TypeKind.Struct:
                        {
                            return Hash.Combine(namedType.TypeParameters.Length, hashCode);
                        }
                    case TypeKind.Delegate:
                        {
                            return Hash.Combine(namedType.TypeParameters.Length,
                                Hash.Combine(Hash.CombineValues(namedType.DelegateInvokeMethod.Parameters, ParameterEqualityComparer.Instance), hashCode));
                        }
                }

                return hashCode;
            }
            else
            {
                int hashCode = Hash.Combine(StringComparer.Ordinal.GetHashCode(obj.Name), (int)kind);

                switch (kind)
                {
                    case SymbolKind.Method:
                        {
                            var methodSymbol = (IMethodSymbol)obj;

                            return Hash.Combine((int)methodSymbol.MethodKind,
                                Hash.Combine(methodSymbol.TypeParameters.Length,
                                Hash.Combine(Hash.CombineValues(methodSymbol.Parameters, ParameterEqualityComparer.Instance), hashCode)));
                        }
                    case SymbolKind.Property:
                        {
                            var propertySymbol = (IPropertySymbol)obj;

                            return Hash.Combine(propertySymbol.IsIndexer,
                                Hash.Combine(Hash.CombineValues(propertySymbol.Parameters, ParameterEqualityComparer.Instance), hashCode));
                        }
                }

                return hashCode;
            }
        }
    }
}
