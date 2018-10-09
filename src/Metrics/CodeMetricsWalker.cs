// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Roslynator.Metrics
{
    internal class CodeMetricsWalker : CSharpSyntaxWalker
    {
        public List<SyntaxTrivia> PreprocessorDirectives { get; } = new List<SyntaxTrivia>();

        public List<SyntaxTrivia> SingleLineComments { get; } = new List<SyntaxTrivia>();

        public List<SyntaxTrivia> SingleLineDocumentationComments { get; } = new List<SyntaxTrivia>();

        public List<SyntaxTrivia> MultiLineComments { get; } = new List<SyntaxTrivia>();

        public List<SyntaxTrivia> MultiLineDocumentationComments { get; } = new List<SyntaxTrivia>();

        public CodeMetricsWalker() : base(SyntaxWalkerDepth.Trivia)
        {
        }

        public override void VisitTrivia(SyntaxTrivia trivia)
        {
            if (trivia.IsDirective)
            {
                PreprocessorDirectives.Add(trivia);
            }
            else
            {
                switch (trivia.Kind())
                {
                    case SyntaxKind.SingleLineCommentTrivia:
                        {
                            SingleLineComments.Add(trivia);
                            break;
                        }
                    case SyntaxKind.SingleLineDocumentationCommentTrivia:
                        {
                            SingleLineDocumentationComments.Add(trivia);
                            break;
                        }
                    case SyntaxKind.MultiLineCommentTrivia:
                        {
                            MultiLineComments.Add(trivia);
                            break;
                        }
                    case SyntaxKind.MultiLineDocumentationCommentTrivia:
                        {
                            MultiLineDocumentationComments.Add(trivia);
                            break;
                        }
                }
            }

            base.VisitTrivia(trivia);
        }
    }
}
