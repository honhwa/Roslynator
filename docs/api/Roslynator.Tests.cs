using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;
using Roslynator.Tests.Text;

namespace Roslynator.Tests
{
    public abstract class CodeFixVerifier : DiagnosticVerifier
    {
        protected CodeFixVerifier();

        public abstract CodeFixProvider FixProvider { get; }

        public Task VerifyDiagnosticAndFixAsync(string source, string expected, IEnumerable<(string source, string expected)> additionalData = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyDiagnosticAndFixAsync(string theory, string fromData, string toData, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyFixAsync(string source, string expected, IEnumerable<(string source, string expected)> additionalData = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyFixAsync(string theory, string fromData, string toData, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyNoFixAsync(string source, IEnumerable<string> additionalSources = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
    }

    public abstract class CodeRefactoringVerifier : CodeVerifier
    {
        protected CodeRefactoringVerifier();

        public abstract string RefactoringId { get; }
        public abstract CodeRefactoringProvider RefactoringProvider { get; }

        public Task VerifyNoRefactoringAsync(string source, IEnumerable<TextSpan> spans, string equivalenceKey = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyNoRefactoringAsync(string source, TextSpan span, string equivalenceKey = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyNoRefactoringAsync(string source, string equivalenceKey = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyRefactoringAsync(string source, string expected, IEnumerable<TextSpan> spans, string equivalenceKey = null, string[] additionalSources = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyRefactoringAsync(string source, string expected, TextSpan span, string equivalenceKey = null, string[] additionalSources = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyRefactoringAsync(string source, string expected, string equivalenceKey = null, string[] additionalSources = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyRefactoringAsync(string theory, string fromData, string toData, string equivalenceKey = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
    }

    public abstract class CodeVerificationOptions
    {
        protected CodeVerificationOptions(bool allowNewCompilerDiagnostics = false, bool enableDiagnosticsDisabledByDefault = true, DiagnosticSeverity maxAllowedCompilerDiagnosticSeverity = DiagnosticSeverity.Info, IEnumerable<string> allowedCompilerDiagnosticIds = null);

        public bool AllowNewCompilerDiagnostics { get; }
        public ImmutableArray<string> AllowedCompilerDiagnosticIds { get; }
        public bool EnableDiagnosticsDisabledByDefault { get; }
        public DiagnosticSeverity MaxAllowedCompilerDiagnosticSeverity { get; }

        public abstract CodeVerificationOptions AddAllowedCompilerDiagnosticId(string diagnosticId);
        public abstract CodeVerificationOptions AddAllowedCompilerDiagnosticIds(IEnumerable<string> diagnosticIds);
    }

    public abstract class CodeVerifier
    {
        protected CodeVerifier();

        public abstract string Language { get; }
        public abstract CodeVerificationOptions Options { get; }
        protected virtual SpanParser SpanParser { get; }

        protected virtual Document CreateDocument(string source, params string[] additionalSources);
        protected abstract string CreateFileName(int index = 0);
        protected abstract Project CreateProject();
    }

    public abstract class CompilerCodeFixVerifier : CodeVerifier
    {
        protected CompilerCodeFixVerifier();

        public abstract string DiagnosticId { get; }
        public abstract CodeFixProvider FixProvider { get; }

        public Task VerifyFixAsync(string source, string expected, string equivalenceKey = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyFixAsync(string theory, string fromData, string toData, string equivalenceKey = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyNoFixAsync(string source, string equivalenceKey = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
    }

    public abstract class DiagnosticVerifier : CodeVerifier
    {
        protected DiagnosticVerifier();

        public abstract DiagnosticAnalyzer Analyzer { get; }
        public abstract DiagnosticDescriptor Descriptor { get; }

        public Task VerifyDiagnosticAsync(string source, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyDiagnosticAsync(string source, Diagnostic expectedDiagnostic, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyDiagnosticAsync(string source, IEnumerable<Diagnostic> expectedDiagnostics, string[] additionalSources = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyDiagnosticAsync(string source, IEnumerable<TextSpan> spans, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyDiagnosticAsync(string source, TextSpan span, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyDiagnosticAsync(string theory, string fromData, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyNoDiagnosticAsync(string source, string[] additionalSources = null, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
        public Task VerifyNoDiagnosticAsync(string theory, string fromData, CodeVerificationOptions options = null, CancellationToken cancellationToken = default);
    }
}

namespace Roslynator.Tests.CSharp
{
    public abstract class CSharpCodeFixVerifier : CodeFixVerifier
    {
        protected CSharpCodeFixVerifier();

        public override string Language { get; }
        public override CodeVerificationOptions Options { get; }

        protected override string CreateFileName(int index = 0);
        protected override Project CreateProject();
    }

    public abstract class CSharpCodeRefactoringVerifier : CodeRefactoringVerifier
    {
        protected CSharpCodeRefactoringVerifier();

        public override string Language { get; }
        public override CodeVerificationOptions Options { get; }

        protected override string CreateFileName(int index = 0);
        protected override Project CreateProject();
    }

    public class CSharpCodeVerificationOptions : CodeVerificationOptions
    {
        public CSharpCodeVerificationOptions(bool allowNewCompilerDiagnostics = false, bool enableDiagnosticsDisabledByDefault = true, DiagnosticSeverity maxAllowedCompilerDiagnosticSeverity = DiagnosticSeverity.Info, IEnumerable<string> allowedCompilerDiagnosticIds = null, bool allowUnsafe = true, OutputKind outputKind = OutputKind.DynamicallyLinkedLibrary);

        public bool AllowUnsafe { get; }
        public static CSharpCodeVerificationOptions Default { get; }
        public OutputKind OutputKind { get; }

        public override CodeVerificationOptions AddAllowedCompilerDiagnosticId(string diagnosticId);
        public override CodeVerificationOptions AddAllowedCompilerDiagnosticIds(IEnumerable<string> diagnosticIds);
        public CSharpCodeVerificationOptions WithAllowedCompilerDiagnosticIds(ImmutableArray<string> allowedCompilerDiagnosticIds);
    }

    public abstract class CSharpCompilerCodeFixVerifier : CompilerCodeFixVerifier
    {
        protected CSharpCompilerCodeFixVerifier();

        public override string Language { get; }
        public override CodeVerificationOptions Options { get; }

        protected override string CreateFileName(int index = 0);
        protected override Project CreateProject();
    }

    public abstract class CSharpDiagnosticVerifier : DiagnosticVerifier
    {
        protected CSharpDiagnosticVerifier();

        public override string Language { get; }
        public override CodeVerificationOptions Options { get; }

        protected override string CreateFileName(int index = 0);
        protected override Project CreateProject();
    }
}

namespace Roslynator.Tests.Text
{
    public abstract class SpanParser
    {
        protected SpanParser();

        public static SpanParser Default { get; }

        public abstract SpanParserResult GetSpans(string s, bool reverse = false);
        public abstract (TextSpan span, string text) ReplaceSpan(string s, string replacement);
        public abstract (TextSpan span, string text1, string text2) ReplaceSpan(string s, string replacement1, string replacement2);
    }

    public readonly struct LinePositionInfo : IEquatable<LinePositionInfo>
    {
        public LinePositionInfo(int index, int lineIndex, int columnIndex);

        public int ColumnIndex { get; }
        public int Index { get; }
        public int LineIndex { get; }
        public LinePosition LinePosition { get; }

        public bool Equals(LinePositionInfo other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(in LinePositionInfo info1, in LinePositionInfo info2);
        public static bool operator !=(in LinePositionInfo info1, in LinePositionInfo info2);
    }

    public readonly struct LinePositionSpanInfo : IEquatable<LinePositionSpanInfo>
    {
        public LinePositionSpanInfo(in LinePositionInfo start, in LinePositionInfo end);

        public LinePositionInfo End { get; }
        public LinePositionSpan LineSpan { get; }
        public TextSpan Span { get; }
        public LinePositionInfo Start { get; }

        public bool Equals(LinePositionSpanInfo other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(in LinePositionSpanInfo info1, in LinePositionSpanInfo info2);
        public static bool operator !=(in LinePositionSpanInfo info1, in LinePositionSpanInfo info2);
    }

    public readonly struct SpanParserResult : IEquatable<SpanParserResult>
    {
        public SpanParserResult(string text, ImmutableArray<LinePositionSpanInfo> spans);

        public ImmutableArray<LinePositionSpanInfo> Spans { get; }
        public string Text { get; }

        public bool Equals(SpanParserResult other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(in SpanParserResult analysis1, in SpanParserResult analysis2);
        public static bool operator !=(in SpanParserResult analysis1, in SpanParserResult analysis2);
    }
}

