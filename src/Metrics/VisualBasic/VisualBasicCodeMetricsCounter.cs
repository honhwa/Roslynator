// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.VisualBasic;

namespace Roslynator.Metrics.VisualBasic
{
    public class VisualBasicCodeMetricsCounter : CodeMetricsCounter
    {
        public override bool IsComment(SyntaxTrivia trivia)
        {
            return trivia.IsKind(SyntaxKind.CommentTrivia);
        }

        public override bool IsEndOfLine(SyntaxTrivia trivia)
        {
            return trivia.IsKind(SyntaxKind.EndOfLineTrivia);
        }

        protected override CodeMetrics CountLines(SyntaxNode node, TextLineCollection lines, CodeMetricsOptions options, CancellationToken cancellationToken)
        {
            var walker = new VisualBasicCodeMetricsWalker(lines, options, cancellationToken);

            walker.Visit(node);

            return new CodeMetrics(
                totalLineCount: lines.Count,
                whiteSpaceLineCount: 0,
                commentLineCount: walker.CommentLineCount,
                preprocessorDirectiveLineCount: walker.PreprocessorDirectiveLineCount,
                blockBoundaryLineCount: walker.BlockBoundaryLineCount);
        }
    }
}
