// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Roslynator.Documentation.Markdown;
using System.Threading.Tasks;

namespace Roslynator.Documentation
{
    internal static class Program
    {
        private static readonly Encoding _defaultEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<DocCommandLineOptions, DeclarationsCommandLineOptions, RootCommandLineOptions>(args)
                .MapResult(
                  (DocCommandLineOptions options) => ExecuteDoc(options),
                  (DeclarationsCommandLineOptions options) => ExecuteDeclarations(options),
                  (RootCommandLineOptions options) => ExecuteRoot(options),
                  _ => 1);
        }

        private static int ExecuteDoc(DocCommandLineOptions options)
        {
            if (options.MaxDerivedTypes < 0)
            {
                Console.WriteLine("Maximum number of derived items must be equal or greater than 0.");
                return 1;
            }

            if (!TryGetIgnoredRootParts(options.IgnoredRootParts, out RootDocumentationParts ignoredRootParts))
                return 1;

            if (!TryGetIgnoredNamespaceParts(options.IgnoredNamespaceParts, out NamespaceDocumentationParts ignoredNamespaceParts))
                return 1;

            if (!TryGetIgnoredTypeParts(options.IgnoredTypeParts, out TypeDocumentationParts ignoredTypeParts))
                return 1;

            if (!TryGetIgnoredMemberParts(options.IgnoredMemberParts, out MemberDocumentationParts ignoredMemberParts))
                return 1;

            if (!TryGetOmitContainingNamespaceParts(options.OmitContainingNamespaceParts, out OmitContainingNamespaceParts omitContainingNamespaceParts))
                return 1;

            DocumentationModel documentationModel = CreateDocumentationModel(options.References, options.Assemblies, options.AdditionalXmlDocumentation);

            if (documentationModel == null)
                return 1;

            var documentationOptions = new DocumentationOptions(
                ignoredNames: options.IgnoredNames,
                preferredCultureName: options.PreferredCulture,
                maxDerivedTypes: options.MaxDerivedTypes,
                includeClassHierarchy: !options.NoClassHierarchy,
                placeSystemNamespaceFirst: !options.NoPrecedenceForSystem,
                formatDeclarationBaseList: !options.NoFormatBaseList,
                formatDeclarationConstraints: !options.NoFormatConstraints,
                markObsolete: !options.NoMarkObsolete,
                includeMemberInheritedFrom: !options.OmitMemberInheritedFrom,
                includeMemberOverrides: !options.OmitMemberOverrides,
                includeMemberImplements: !options.OmitMemberImplements,
                includeMemberConstantValue: !options.OmitMemberConstantValue,
                includeInheritedInterfaceMembers: options.IncludeInheritedInterfaceMembers,
                includeAllDerivedTypes: options.IncludeAllDerivedTypes,
                includeAttributeArguments: !options.OmitAttributeArguments,
                includeInheritedAttributes: !options.OmitInheritedAttributes,
                omitIEnumerable: !options.IncludeIEnumerable,
                depth: options.Depth,
                inheritanceStyle: options.InheritanceStyle,
                ignoredRootParts: ignoredRootParts,
                ignoredNamespaceParts: ignoredNamespaceParts,
                ignoredTypeParts: ignoredTypeParts,
                ignoredMemberParts: ignoredMemberParts,
                omitContainingNamespaceParts: omitContainingNamespaceParts);

            var generator = new MarkdownDocumentationGenerator(documentationModel, WellKnownUrlProviders.GitHub, documentationOptions);

            string directoryPath = options.OutputDirectory;

            if (!options.NoDelete
                && Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.Delete(directoryPath, recursive: true);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            Console.WriteLine($"Documentation is being generated to '{options.OutputDirectory}'.");

            foreach (DocumentationGeneratorResult documentationFile in generator.Generate(heading: options.Heading))
            {
                string path = Path.Combine(directoryPath, documentationFile.FilePath);

#if DEBUG
                Console.WriteLine($"saving '{path}'");
#else
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, documentationFile.Content, _defaultEncoding);
#endif
            }

            Console.WriteLine($"Documentation successfully generated to '{options.OutputDirectory}'.");

            return 0;
        }

        private static int ExecuteDeclarations(DeclarationsCommandLineOptions options)
        {
            if (!TryGetIgnoredDeclarationListParts(options.IgnoredParts, out DeclarationListParts ignoredParts))
                return 1;

            DocumentationModel documentationModel = CreateDocumentationModel(options.References, options.Assemblies, options.AdditionalXmlDocumentation);

            if (documentationModel == null)
                return 1;

            var declarationListOptions = new DeclarationListOptions(
                ignoredNames: options.IgnoredNames,
                indent: !options.NoIndent,
                indentChars: options.IndentChars,
                nestNamespaces: options.NestNamespaces,
                newLineBeforeOpenBrace: !options.NoNewLineBeforeOpenBrace,
                emptyLineBetweenMembers: options.EmptyLineBetweenMembers,
                formatBaseList: options.FormatBaseList,
                formatConstraints: options.FormatConstraints,
                formatParameters: options.FormatParameters,
                splitAttributes: !options.MergeAttributes,
                includeAttributeArguments: !options.OmitAttributeArguments,
                omitIEnumerable: !options.IncludeIEnumerable,
                useDefaultLiteral: !options.NoDefaultLiteral,
                fullyQualifiedNames: options.FullyQualifiedNames,
                depth: options.Depth,
                ignoredParts: ignoredParts);

            Console.WriteLine($"Declaration list is being generated to '{options.OutputPath}'.");

            Task<string> task = DeclarationListGenerator.GenerateAsync(
                documentationModel,
                declarationListOptions,
                namespaceComparer: NamespaceSymbolComparer.GetInstance(systemNamespaceFirst: !options.NoPrecedenceForSystem));

            string content = task.Result;

            string path = options.OutputPath;

#if DEBUG
            Console.WriteLine($"saving '{path}'");
#else
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, content, Encoding.UTF8);
#endif

            Console.WriteLine($"Declaration list successfully generated to '{options.OutputPath}'.");

            return 0;
        }

        private static int ExecuteRoot(RootCommandLineOptions options)
        {
            DocumentationModel documentationModel = CreateDocumentationModel(options.References, options.Assemblies);

            if (documentationModel == null)
                return 1;

            if (!TryGetIgnoredRootParts(options.Parts, out RootDocumentationParts ignoredParts))
                return 1;

            var documentationOptions = new DocumentationOptions(
                ignoredNames: options.IgnoredNames,
                rootDirectoryUrl: options.RootDirectoryUrl,
                includeClassHierarchy: !options.NoClassHierarchy,
                placeSystemNamespaceFirst: !options.NoPrecedenceForSystem,
                markObsolete: !options.NoMarkObsolete,
                depth: options.Depth,
                ignoredRootParts: ignoredParts,
                omitContainingNamespaceParts: (options.OmitContainingNamespace) ? OmitContainingNamespaceParts.Root : OmitContainingNamespaceParts.None);

            var generator = new MarkdownDocumentationGenerator(documentationModel, WellKnownUrlProviders.GitHub, documentationOptions);

            string path = options.OutputPath;

            Console.WriteLine($"Documentation root is being generated to '{path}'.");

            string heading = options.Heading;

            if (string.IsNullOrEmpty(heading))
            {
                string fileName = Path.GetFileName(options.OutputPath);

                heading = (fileName.EndsWith(".dll", StringComparison.Ordinal))
                    ? Path.GetFileNameWithoutExtension(fileName)
                    : fileName;
            }

            DocumentationGeneratorResult result = generator.GenerateRoot(heading);

            File.WriteAllText(path, result.Content, _defaultEncoding);

            Console.WriteLine($"Documentation root successfully generated to '{path}'.");

            return 0;
        }

        private static DocumentationModel CreateDocumentationModel(string assemblyReferencesValue, IEnumerable<string> assemblies, IEnumerable<string> additionalXmlDocumentationPaths = null)
        {
            IEnumerable<string> assemblyReferences = GetAssemblyReferences(assemblyReferencesValue);

            if (assemblyReferences == null)
                return null;

            List<PortableExecutableReference> references = assemblyReferences
                .Select(f => MetadataReference.CreateFromFile(f))
                .ToList();

            foreach (string assemblyPath in assemblies)
            {
                if (!TryGetReference(references, assemblyPath, out PortableExecutableReference reference))
                {
                    if (File.Exists(assemblyPath))
                    {
                        reference = MetadataReference.CreateFromFile(assemblyPath);
                        references.Add(reference);
                    }
                    else
                    {
                        Console.WriteLine($"Assembly not found: '{assemblyPath}'.");
                        return null;
                    }
                }
            }

            CSharpCompilation compilation = CSharpCompilation.Create(
                "",
                syntaxTrees: default(IEnumerable<SyntaxTree>),
                references: references,
                options: default(CSharpCompilationOptions));

            return new DocumentationModel(
                compilation,
                assemblies.Select(assemblyPath =>
                {
                    TryGetReference(references, assemblyPath, out PortableExecutableReference reference);
                    return (IAssemblySymbol)compilation.GetAssemblyOrModuleSymbol(reference);
                }),
                additionalXmlDocumentationPaths: additionalXmlDocumentationPaths);
        }

        private static IEnumerable<string> GetAssemblyReferences(string assemblyReferences)
        {
            if (assemblyReferences.Contains(";"))
            {
                return assemblyReferences.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                string path = assemblyReferences;

                if (!File.Exists(path))
                {
                    Console.WriteLine($"File not found: '{path}'.");
                    return null;
                }

                string extension = Path.GetExtension(path);

                if (string.Equals(extension, ".dll", StringComparison.OrdinalIgnoreCase))
                {
                    return assemblyReferences.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    return File.ReadLines(assemblyReferences).Where(f => !string.IsNullOrWhiteSpace(f));
                }
            }
        }

        private static bool TryGetIgnoredRootParts(IEnumerable<string> values, out RootDocumentationParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.IgnoredRootParts;
                return true;
            }

            parts = RootDocumentationParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out RootDocumentationParts result))
                {
                    parts |= result;
                }
                else
                {
                    Console.WriteLine($"Unknown root documentation part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        private static bool TryGetIgnoredNamespaceParts(IEnumerable<string> values, out NamespaceDocumentationParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.IgnoredNamespaceParts;
                return true;
            }

            parts = NamespaceDocumentationParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out NamespaceDocumentationParts result))
                {
                    parts |= result;
                }
                else
                {
                    Console.WriteLine($"Unknown namespace documentation part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        private static bool TryGetIgnoredTypeParts(IEnumerable<string> values, out TypeDocumentationParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.IgnoredTypeParts;
                return true;
            }

            parts = TypeDocumentationParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out TypeDocumentationParts result))
                {
                    parts |= result;
                }
                else
                {
                    Console.WriteLine($"Unknown type documentation part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        private static bool TryGetIgnoredMemberParts(IEnumerable<string> values, out MemberDocumentationParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.IgnoredMemberParts;
                return true;
            }

            parts = MemberDocumentationParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out MemberDocumentationParts result))
                {
                    parts |= result;
                }
                else
                {
                    Console.WriteLine($"Unknown member documentation part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        private static bool TryGetIgnoredDeclarationListParts(IEnumerable<string> values, out DeclarationListParts parts)
        {
            if (!values.Any())
            {
                parts = DeclarationListOptions.Default.IgnoredParts;
                return true;
            }

            parts = DeclarationListParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out DeclarationListParts result))
                {
                    parts |= result;
                }
                else
                {
                    Console.WriteLine($"Unknown declaration list part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        private static bool TryGetOmitContainingNamespaceParts(IEnumerable<string> values, out OmitContainingNamespaceParts parts)
        {
            if (!values.Any())
            {
                parts = DocumentationOptions.Default.OmitContainingNamespaceParts;
                return true;
            }

            parts = OmitContainingNamespaceParts.None;

            foreach (string value in values)
            {
                if (Enum.TryParse(value.Replace("-", ""), ignoreCase: true, out OmitContainingNamespaceParts result))
                {
                    parts |= result;
                }
                else
                {
                    Console.WriteLine($"Unknown omit containing namespace part '{value}'.");
                    return false;
                }
            }

            return true;
        }

        private static bool TryGetReference(List<PortableExecutableReference> references, string path, out PortableExecutableReference reference)
        {
            if (path.Contains(Path.DirectorySeparatorChar))
            {
                foreach (PortableExecutableReference r in references)
                {
                    if (r.FilePath == path)
                    {
                        reference = r;
                        return true;
                    }
                }
            }
            else
            {
                foreach (PortableExecutableReference r in references)
                {
                    string filePath = r.FilePath;

                    int index = filePath.LastIndexOf(Path.DirectorySeparatorChar);

                    if (string.Compare(filePath, index + 1, path, 0, path.Length, StringComparison.Ordinal) == 0)
                    {
                        reference = r;
                        return true;
                    }
                }
            }

            reference = null;
            return false;
        }
    }
}
