﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Roslynator.Metrics.VisualBasic
{
    internal class VisualBasicCodeMetricsWalker : VisualBasicSyntaxWalker
    {
        public int CommentLineCount { get; set; }

        public int PreprocessorDirectiveLineCount { get; set; }

        public int BlockBoundaryLineCount { get; set; }

        public TextLineCollection Lines { get; }

        public CodeMetricsOptions Options { get; }

        public CancellationToken CancellationToken { get; }

        public VisualBasicCodeMetricsWalker(TextLineCollection lines, CodeMetricsOptions options, CancellationToken cancellationToken)
            : base(SyntaxWalkerDepth.Trivia)
        {
            Lines = lines;
            Options = options;
            CancellationToken = cancellationToken;
        }

        public override void VisitTrivia(SyntaxTrivia trivia)
        {
            if (trivia.IsDirective)
            {
                if (!Options.IncludePreprocessorDirectives)
                {
                    PreprocessorDirectiveLineCount++;
                }
            }
            else if (!Options.IncludeComments)
            {
                switch (trivia.Kind())
                {
                    case SyntaxKind.CommentTrivia:
                        {
                            TextSpan span = trivia.Span;

                            TextLine line = Lines.GetLineFromPosition(span.Start);

                            if (line.IsEmptyOrWhiteSpace(TextSpan.FromBounds(line.Start, span.Start)))
                            {
                                CommentLineCount++;
                            }

                            break;
                        }
                    case SyntaxKind.DocumentationCommentTrivia:
                        {
                            CommentLineCount += Lines.GetLinePositionSpan(trivia.Span).LineCount() - 1;
                            break;
                        }
                }
            }

            base.VisitTrivia(trivia);
        }

        public override void VisitEndBlockStatement(EndBlockStatementSyntax node)
        {
            TextSpan span = node.Span;

            TextLine line = Lines.GetLineFromPosition(span.Start);

            if (line.IsEmptyOrWhiteSpace(TextSpan.FromBounds(line.Start, span.Start))
                && line.IsEmptyOrWhiteSpace(TextSpan.FromBounds(span.End, line.End)))
            {
                BlockBoundaryLineCount++;
            }

            base.VisitEndBlockStatement(node);
        }
    }
}
