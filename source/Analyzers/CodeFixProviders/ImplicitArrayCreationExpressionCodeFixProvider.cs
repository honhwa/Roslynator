﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Composition;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslynator.CodeFixes;
using Roslynator.CSharp.Refactorings;

namespace Roslynator.CSharp.CodeFixes
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ImplicitArrayCreationExpressionCodeFixProvider))]
    [Shared]
    public class ImplicitArrayCreationExpressionCodeFixProvider : BaseCodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds
        {
            get { return ImmutableArray.Create(DiagnosticIdentifiers.AvoidImplicitlyTypedArray); }
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            SyntaxNode root = await context.GetSyntaxRootAsync().ConfigureAwait(false);

            if (!TryFindFirstAncestorOrSelf(root, context.Span, out ImplicitArrayCreationExpressionSyntax expression))
                return;

            SemanticModel semanticModel = await context.GetSemanticModelAsync().ConfigureAwait(false);

            var typeSymbol = semanticModel.GetTypeSymbol(expression, context.CancellationToken) as IArrayTypeSymbol;

            CodeAction codeAction = CodeAction.Create(
                $"Declare explicit type '{SymbolDisplay.ToMinimalDisplayString(typeSymbol, semanticModel, expression.SpanStart, SymbolDisplayFormats.Default)}'",
                cancellationToken => AvoidImplicitlyTypedArrayRefactoring.RefactorAsync(context.Document, expression, cancellationToken),
                GetEquivalenceKey(DiagnosticIdentifiers.AvoidImplicitlyTypedArray));

            context.RegisterCodeFix(codeAction, context.Diagnostics);
        }
    }
}
