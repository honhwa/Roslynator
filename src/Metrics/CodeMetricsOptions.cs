// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Roslynator.Metrics
{
    public class CodeMetricsOptions
    {
        public CodeMetricsOptions(
            bool includeGenerated = false,
            bool includeWhiteSpace = false,
            bool includeComments = false,
            bool includePreprocessorDirectives = false,
            bool ignoreBlockBoundary = false)
        {
            IncludeGenerated = includeGenerated;
            IncludeWhiteSpace = includeWhiteSpace;
            IncludeComments = includeComments;
            IncludePreprocessorDirectives = includePreprocessorDirectives;
            IgnoreBlockBoundary = ignoreBlockBoundary;
        }

        public static CodeMetricsOptions Default { get; } = new CodeMetricsOptions();

        public bool IncludeGenerated { get; }

        public bool IncludeWhiteSpace { get; }

        public bool IncludeComments { get; }

        public bool IncludePreprocessorDirectives { get; }

        public bool IgnoreBlockBoundary { get; }
    }
}
