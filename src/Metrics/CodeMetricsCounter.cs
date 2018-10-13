// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Roslynator.Metrics
{
    public abstract class CodeMetricsCounter
    {
        internal static CodeMetricsCounter CSharp { get; } = new CSharp.CSharpCodeMetricsCounter();

        internal static CodeMetricsCounter VisualBasic { get; } = new VisualBasic.VisualBasicCodeMetricsCounter();

        public abstract bool IsComment(SyntaxTrivia trivia);

        public abstract bool IsEndOfLine(SyntaxTrivia trivia);

        protected abstract CodeMetrics CountLines(SyntaxNode node, TextLineCollection lines, CodeMetricsOptions options, CancellationToken cancellationToken);

        internal static CodeMetricsCounter GetInstanceOrDefault(string language)
        {
            switch (language)
            {
                case LanguageNames.CSharp:
                    return CSharp;
                case LanguageNames.VisualBasic:
                    return VisualBasic;
                default:
                    return null;
            }
        }

        public static async Task<CodeMetrics> CountLinesAsync(
            Project  project,
            CodeMetricsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            CodeMetricsCounter counter = GetInstanceOrDefault(project.Language);

            if (counter == null)
                return default;

            int totalLineCount = 0;
            int preprocessDirectiveLineCount = 0;
            int commentLineCount = 0;
            int whiteSpaceLineCount = 0;
            int blockBoundaryCount = 0;

            foreach (Document document in project.Documents)
            {
                if (!document.SupportsSyntaxTree)
                    continue;

                CodeMetrics metrics = await counter.CountLinesAsync(document, options, cancellationToken).ConfigureAwait(false);

                totalLineCount += metrics.TotalLineCount;
                preprocessDirectiveLineCount += metrics.PreprocessorDirectiveLineCount;
                commentLineCount += metrics.CommentLineCount;
                whiteSpaceLineCount += metrics.WhiteSpaceLineCount;
                blockBoundaryCount += metrics.BlockBoundaryLineCount;
            }

            return new CodeMetrics(
                totalLineCount: totalLineCount,
                whiteSpaceLineCount: whiteSpaceLineCount,
                commentLineCount: commentLineCount,
                preprocessorDirectiveLineCount: preprocessDirectiveLineCount,
                blockBoundaryLineCount: blockBoundaryCount);
        }

        public async Task<CodeMetrics> CountLinesAsync(
            Document document,
            CodeMetricsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            SyntaxTree tree = await document.GetSyntaxTreeAsync(cancellationToken).ConfigureAwait(false);

            if (tree == null)
                return default;

            if (GeneratedCodeUtility.IsGeneratedCode(tree, IsComment, cancellationToken)
                && !options.IncludeGenerated)
            {
                return default;
            }

            SyntaxNode root = tree.GetRoot(cancellationToken);

            SourceText sourceText = await document.GetTextAsync(cancellationToken).ConfigureAwait(false);

            TextLineCollection lines = sourceText.Lines;

            CodeMetrics metrics = CountLines(root, lines, options, cancellationToken);

            int whiteSpaceLineCount = 0;

            if (!options.IncludeWhiteSpace)
            {
                foreach (TextLine line in sourceText.Lines)
                {
                    if (line.IsEmptyOrWhiteSpace())
                    {
                        if (line.End == sourceText.Length
                            || IsEndOfLine(root.FindTrivia(line.End)))
                        {
                            whiteSpaceLineCount++;
                        }
                    }
                }
            }

            return metrics.WithWhiteSpaceLineCount(whiteSpaceLineCount);
        }
    }
}
