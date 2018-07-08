﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Roslynator
{
    internal static class RuntimeMetadataReference
    {
        private static MetadataReference _corLibReference;
        private static ImmutableDictionary<string, string> _trustedPlatformAssemblyPaths;

        public static MetadataReference CorLibReference
        {
            get { return _corLibReference ?? (_corLibReference = MetadataReference.CreateFromFile(typeof(object).Assembly.Location)); }
        }

        public static ImmutableDictionary<string, string> TrustedPlatformAssemblyPaths
        {
            get { return _trustedPlatformAssemblyPaths ?? (_trustedPlatformAssemblyPaths = CreateTrustedPlatformAssemblies()); }
        }

        private static Compilation _compilation;

        public static Compilation Compilation
        {
            get
            {
                if (_compilation == null)
                {
                    IEnumerable<PortableExecutableReference> references = TrustedPlatformAssemblyPaths
                        .Select(f => MetadataReference.CreateFromFile(f.Value));

                    _compilation = CSharpCompilation.Create(
                        "Temp",
                        syntaxTrees: default(IEnumerable<SyntaxTree>),
                        references: references,
                        options: default(CSharpCompilationOptions));
                }

                return _compilation;
            }
        }

        private static ImmutableDictionary<string, string> CreateTrustedPlatformAssemblies()
        {
            return AppContext
                .GetData("TRUSTED_PLATFORM_ASSEMBLIES")
                .ToString()
                .Split(';')
                .ToImmutableDictionary(Path.GetFileName);
        }

        public static PortableExecutableReference CreateFromAssemblyName(string assemblyName)
        {
            string path = TrustedPlatformAssemblyPaths[assemblyName];

            return MetadataReference.CreateFromFile(path);
        }
    }
}
