// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Roslynator.CSharp;

namespace Roslynator.Metrics
{
    public static class CodeMetrics
    {
        public static async Task<LineMetrics> CountLinesAsync(
            Solution solution,
            CodeMetricsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            int totalLineCount = 0;
            int preprocessDirectiveLineCount = 0;
            int commentLineCount = 0;
            int whiteSpaceLineCount = 0;

            foreach (Project project in solution.Projects)
            {
                LineMetrics metrics = await CountLinesAsync(project, options, cancellationToken).ConfigureAwait(false);

                totalLineCount += metrics.TotalLineCount;
                preprocessDirectiveLineCount += metrics.PreprocessDirectiveLineCount;
                commentLineCount += metrics.CommentLineCount;
                whiteSpaceLineCount += metrics.WhiteSpaceLineCount;
            }

            return new LineMetrics(totalLineCount, whiteSpaceLineCount, commentLineCount, preprocessDirectiveLineCount);
        }

        public static async Task<LineMetrics> CountLinesAsync(
            Project  project,
            CodeMetricsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            int totalLineCount = 0;
            int preprocessDirectiveLineCount = 0;
            int commentLineCount = 0;
            int whiteSpaceLineCount = 0;

            foreach (Document document in project.Documents)
            {
                if (!document.SupportsSyntaxTree)
                    continue;

                LineMetrics metrics = await CountLinesAsync(document, options, cancellationToken).ConfigureAwait(false);

                totalLineCount += metrics.TotalLineCount;
                preprocessDirectiveLineCount += metrics.PreprocessDirectiveLineCount;
                commentLineCount += metrics.CommentLineCount;
                whiteSpaceLineCount += metrics.WhiteSpaceLineCount;
            }

            return new LineMetrics(totalLineCount, whiteSpaceLineCount, commentLineCount, preprocessDirectiveLineCount);
        }

        //TODO: visual basic
        public static async Task<LineMetrics> CountLinesAsync(
            Document document,
            CodeMetricsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            SyntaxTree tree = await document.GetSyntaxTreeAsync(cancellationToken).ConfigureAwait(false);

            if (tree == null)
                return default;

            //TODO: shebang directive?
            if (GeneratedCodeUtility.IsGeneratedCode(tree, f => f.IsKind(SyntaxKind.SingleLineCommentTrivia, SyntaxKind.MultiLineCommentTrivia), cancellationToken)
                && !options.IncludeGenerated)
            {
                return default;
            }

            SyntaxNode root = tree.GetRoot(cancellationToken);

            var walker = new CodeMetricsWalker();

            walker.Visit(root);

            SourceText sourceText = await document.GetTextAsync(cancellationToken).ConfigureAwait(false);

            TextLineCollection lines = sourceText.Lines;

            int totalLineCount = lines.Count;
            int commentLineCount = 0;
            int whiteSpaceLineCount = 0;

            if (!options.IncludeComments)
            {
                foreach (SyntaxTrivia trivia in walker.SingleLineComments)
                {
                    TextSpan span = trivia.Span;

                    TextLine line = lines.GetLineFromPosition(span.Start);

                    if (line.IsEmptyOrWhiteSpace(TextSpan.FromBounds(line.Start, span.Start)))
                    {
                        commentLineCount++;
                    }
                }

                foreach (SyntaxTrivia trivia in walker.SingleLineDocumentationComments)
                {
                    commentLineCount += tree.GetLineCount(trivia.Span) - 1;
                }

                foreach (SyntaxTrivia trivia in walker.MultiLineComments)
                {
                    TextSpan span = trivia.Span;

                    TextLine line = lines.GetLineFromPosition(span.Start);

                    if (line.IsEmptyOrWhiteSpace(TextSpan.FromBounds(line.Start, span.Start)))
                    {
                        int lineCount = tree.GetLineCount(trivia.Span, cancellationToken);

                        if (lineCount == 1
                            || line.IsEmptyOrWhiteSpace(TextSpan.FromBounds(lines.GetLineFromPosition(span.End).End, span.End)))
                        {
                            commentLineCount += lineCount;
                        }
                    }
                }

                foreach (SyntaxTrivia trivia in walker.MultiLineDocumentationComments)
                {
                    commentLineCount += tree.GetLineCount(trivia.Span);
                }
            }

            if (!options.IncludeWhiteSpace)
            {
                foreach (TextLine line in lines)
                {
                    if (line.IsEmptyOrWhiteSpace())
                    {
                        if (line.End == sourceText.Length
                            || root.FindTrivia(line.End).IsKind(SyntaxKind.EndOfLineTrivia))
                        {
                            whiteSpaceLineCount++;
                        }
                    }
                }
            }

            return new LineMetrics(
                totalLineCount: totalLineCount,
                whiteSpaceLineCount: whiteSpaceLineCount,
                commentLineCount: commentLineCount,
                preprocessDirectiveLineCount: walker.PreprocessorDirectives.Count);
        }
    }
}
