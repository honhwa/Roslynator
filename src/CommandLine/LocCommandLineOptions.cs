// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using CommandLine;

namespace Roslynator.CommandLine
{
    [Verb("loc")]
    public class LocCommandLineOptions
    {
        [Value(index: 0, Required = true)]
        public string Solution { get; set; }

        [Option(shortName: 'p', longName: "properties")]
        public IEnumerable<string> Properties { get; set; }

        [Option(longName: "msbuild-path")]
        public string MSBuildPath { get; set; }

        [Option(longName: "include-generated")]
        public bool IncludeGenerated { get; set; }

        [Option(longName: "include-whitespace")]
        public bool IncludeWhiteSpace { get; set; }

        [Option(longName: "include-comments")]
        public bool IncludeComments { get; set; }

        [Option(longName: "include-preprocessor-directives")]
        public bool IncludePreprocessorDirectives { get; set; }

        [Option(longName: "ignore-block-boundary")]
        public bool IgnoreBlockBoundary { get; set; }

        [Option(longName: "ignored-projects")]
        public IEnumerable<string> IgnoredProjects { get; set; }
    }
}
