﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using CommandLine;
using static Roslynator.Documentation.DocumentationOptions;

namespace Roslynator.Documentation
{
    [Verb("root")]
    public class RootCommandLineOptions
    {
        [Option(longName: "assemblies", shortName: 'a', Required = true)]
        public IEnumerable<string> Assemblies { get; set; }

        [Option(longName: "heading", shortName: 'h', Required = true)]
        public string Heading { get; set; }

        [Option(longName: "output", shortName: 'o', Required = true)]
        public string OutputPath { get; set; }

        [Option(longName: "references", shortName: 'r', Required = true)]
        public string References { get; set; }

        [Option(longName: "depth", Default = DefaultValues.Depth)]
        public DocumentationDepth Depth { get; set; }

        [Option(longName: "ignored-names")]
        public IEnumerable<string> IgnoredNames { get; set; }

        [Option(longName: "include-class-hierarchy", Default = DefaultValues.IncludeClassHierarchy)]
        public bool IncludeClassHierarchy { get; set; }

        [Option(longName: "include-containing-namespace", Default = DefaultValues.IncludeContainingNamespace)]
        public bool IncludeContainingNamespace { get; set; }

        [Option(longName: "mark-obsolete", Default = DefaultValues.MarkObsolete)]
        public bool MarkObsolete { get; set; }

        [Option(longName: "mode", Default = "github")]
        public string Mode { get; set; }

        [Option(longName: "parts")]
        public IEnumerable<string> Parts { get; set; }

        [Option(longName: "place-system-namespace-first", Default = DefaultValues.PlaceSystemNamespaceFirst)]
        public bool PlaceSystemNamespaceFirst { get; set; }

        [Option(longName: "root-url")]
        public string RootUrl { get; set; }
    }
}
