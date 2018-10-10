// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Roslynator.CSharp;
using Roslynator.Metrics.CSharp;

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
            int braceLineCount = 0;

            foreach (Project project in solution.Projects)
            {
                LineMetrics metrics = await CountLinesAsync(project, options, cancellationToken).ConfigureAwait(false);

                totalLineCount += metrics.TotalLineCount;
                preprocessDirectiveLineCount += metrics.PreprocessDirectiveLineCount;
                commentLineCount += metrics.CommentLineCount;
                whiteSpaceLineCount += metrics.WhiteSpaceLineCount;
                braceLineCount += metrics.BraceLineCount;
            }

            return new LineMetrics(
                totalLineCount: totalLineCount,
                whiteSpaceLineCount: whiteSpaceLineCount,
                commentLineCount: commentLineCount,
                preprocessDirectiveLineCount: preprocessDirectiveLineCount,
                braceLineCount: braceLineCount);
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
            int braceLineCount = 0;

            foreach (Document document in project.Documents)
            {
                if (!document.SupportsSyntaxTree)
                    continue;

                LineMetrics metrics = await CountLinesAsync(document, options, cancellationToken).ConfigureAwait(false);

                totalLineCount += metrics.TotalLineCount;
                preprocessDirectiveLineCount += metrics.PreprocessDirectiveLineCount;
                commentLineCount += metrics.CommentLineCount;
                whiteSpaceLineCount += metrics.WhiteSpaceLineCount;
                braceLineCount += metrics.BraceLineCount;
            }

            return new LineMetrics(
                totalLineCount: totalLineCount,
                whiteSpaceLineCount: whiteSpaceLineCount,
                commentLineCount: commentLineCount,
                preprocessDirectiveLineCount: preprocessDirectiveLineCount,
                braceLineCount: braceLineCount);
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

            SourceText sourceText = await document.GetTextAsync(cancellationToken).ConfigureAwait(false);

            TextLineCollection lines = sourceText.Lines;

            var walker = new CSharpCodeMetricsWalker(lines, options, cancellationToken);

            walker.Visit(root);

            int whiteSpaceLineCount = 0;

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
                totalLineCount: lines.Count,
                whiteSpaceLineCount: whiteSpaceLineCount,
                commentLineCount: walker.CommentLineCount,
                preprocessDirectiveLineCount: walker.PreprocessorDirectiveLineCount,
                braceLineCount: walker.BraceLineCount);
        }
    }
}
