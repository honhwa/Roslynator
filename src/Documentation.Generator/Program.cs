// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Roslynator.Documentation.Markdown;
using Roslynator.Utilities;

namespace Roslynator.Documentation
{
    internal static class Program
    {
        private static readonly UTF8Encoding _utf8NoBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        [SuppressMessage("Redundancy", "RCS1163")]
        private static void Main(string[] args)
        {
            GenerateDocumentation(
                @"..\..\..\..\..\docs\api",
                "Roslynator API Reference",
                "api.cs",
                new string[] { "Roslynator.Documentation.dll", "Roslynator.CSharp.dll", "Roslynator.CSharp.Workspaces.dll" });

            GenerateDocumentation(
                @"..\..\..\..\..\docs\apitest",
                "Foo API Reference",
                "apitest.cs",
                new string[] { "Roslynator.Documentation.TestProject.dll" },
                inheritedInterfaceMembers: true);
        }

        private static void GenerateDocumentation(
            string directoryPath,
            string heading,
            string declarationListFileName,
            string[] assemblyNames,
            bool inheritedInterfaceMembers = false)
        {
            DocumentationModel documentationModel = CreateFromTrustedPlatformAssemblies(assemblyNames);

            var ignoredNames = new string[] { "Roslynator.Documentation.Test2" };

            var documentationOptions = new DocumentationOptions(ignoredNames: ignoredNames, includeInheritedInterfaceMembers: inheritedInterfaceMembers);

            var generator = new MarkdownDocumentationGenerator(documentationModel, WellKnownUrlProviders.GitHub, documentationOptions);

            Directory.CreateDirectory(directoryPath);

            foreach (DocumentationGeneratorResult result in generator.Generate(heading))
            {
                string path = Path.Combine(directoryPath, result.FilePath);

                Directory.CreateDirectory(Path.GetDirectoryName(path));

                FileHelper.WriteAllText(path, result.Content, _utf8NoBom, onlyIfChanges: true, fileMustExists: false);
            }

            var declarationListOptions = new DeclarationListOptions(ignoredNames: ignoredNames);

            string declarationList = DeclarationListGenerator.GenerateAsync(documentationModel, declarationListOptions).Result;

            FileHelper.WriteAllText(Path.Combine(Path.GetDirectoryName(directoryPath), declarationListFileName), declarationList, Encoding.UTF8, onlyIfChanges: true, fileMustExists: false);
        }

        internal static DocumentationModel CreateFromTrustedPlatformAssemblies(string[] assemblyNames)
        {
            ImmutableDictionary<string, string> paths = AppContext
                .GetData("TRUSTED_PLATFORM_ASSEMBLIES")
                .ToString()
                .Split(';')
                .ToImmutableDictionary(Path.GetFileName, StringComparer.OrdinalIgnoreCase);

            List<PortableExecutableReference> references = assemblyNames
                .Select(f => MetadataReference.CreateFromFile(paths[f]))
                .ToList();

            IEnumerable<PortableExecutableReference> compilationReferences = paths
                .Values
                .Where(path => !references.Any(reference => reference.FilePath == path))
                .Select(f => MetadataReference.CreateFromFile(f))
                .Concat(references);

            CSharpCompilation compilation = CSharpCompilation.Create(
                "",
                syntaxTrees: default(IEnumerable<SyntaxTree>),
                references: compilationReferences,
                options: default(CSharpCompilationOptions));

            return new DocumentationModel(
                compilation,
                references.Select(f => (IAssemblySymbol)compilation.GetAssemblyOrModuleSymbol(f)),
                additionalXmlDocumentationPaths: new string[] { @"..\..\..\test.xml" });
        }
    }
}

