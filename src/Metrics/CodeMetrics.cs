// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Roslynator.Metrics
{
    public readonly struct CodeMetrics
    {
        public CodeMetrics(
            int totalLineCount,
            int whiteSpaceLineCount,
            int commentLineCount,
            int preprocessorDirectiveLineCount,
            int blockBoundaryLineCount)
        {
            TotalLineCount = totalLineCount;
            WhiteSpaceLineCount = whiteSpaceLineCount;
            CommentLineCount = commentLineCount;
            PreprocessorDirectiveLineCount = preprocessorDirectiveLineCount;
            BlockBoundaryLineCount = blockBoundaryLineCount;
        }

        public int TotalLineCount { get; }

        public int CodeLineCount
        {
            get { return TotalLineCount - CommentLineCount - PreprocessorDirectiveLineCount - WhiteSpaceLineCount - BlockBoundaryLineCount; }
        }

        public int WhiteSpaceLineCount { get; }

        public int CommentLineCount { get; }

        public int PreprocessorDirectiveLineCount { get; }

        public int BlockBoundaryLineCount { get; }

        internal CodeMetrics WithWhiteSpaceLineCount(int whiteSpaceLineCount)
        {
            return new CodeMetrics(
                totalLineCount: TotalLineCount,
                whiteSpaceLineCount: whiteSpaceLineCount,
                commentLineCount: CommentLineCount,
                preprocessorDirectiveLineCount: PreprocessorDirectiveLineCount,
                blockBoundaryLineCount: BlockBoundaryLineCount);
        }
    }
}
