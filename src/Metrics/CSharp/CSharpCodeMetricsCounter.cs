// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Roslynator.CSharp;

namespace Roslynator.Metrics.CSharp
{
    public class CSharpCodeMetricsCounter : CodeMetricsCounter
    {
        //TODO: shebang directive?
        public override bool IsComment(SyntaxTrivia trivia)
        {
            return trivia.IsKind(SyntaxKind.SingleLineCommentTrivia, SyntaxKind.MultiLineCommentTrivia);
        }

        public override bool IsEndOfLine(SyntaxTrivia trivia)
        {
            return trivia.IsKind(SyntaxKind.EndOfLineTrivia);
        }

        protected override CodeMetrics CountLines(SyntaxNode node, TextLineCollection lines, CodeMetricsOptions options, CancellationToken cancellationToken)
        {
            var walker = new CSharpCodeMetricsWalker(lines, options, cancellationToken);

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
