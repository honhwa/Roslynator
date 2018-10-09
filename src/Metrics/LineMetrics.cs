// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Roslynator.Metrics
{
    public readonly struct LineMetrics
    {
        public LineMetrics(
            int totalLineCount,
            int whiteSpaceLineCount,
            int commentLineCount,
            int preprocessDirectiveLineCount)
        {
            TotalLineCount = totalLineCount;
            WhiteSpaceLineCount = whiteSpaceLineCount;
            CommentLineCount = commentLineCount;
            PreprocessDirectiveLineCount = preprocessDirectiveLineCount;
        }

        public int TotalLineCount { get; }

        public int CodeLineCount
        {
            get { return TotalLineCount - CommentLineCount - PreprocessDirectiveLineCount - WhiteSpaceLineCount; }
        }

        public int WhiteSpaceLineCount { get; }

        public int CommentLineCount { get; }

        public int PreprocessDirectiveLineCount { get; }
    }
}
