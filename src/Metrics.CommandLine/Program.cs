// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Roslynator.Metrics;
using static System.Console;

#pragma warning disable RCS1090

namespace Roslynator.CommandLine
{
    internal static class Program
    {
        private static async System.Threading.Tasks.Task Main(string[] args)
        {
            VisualStudioInstance instance = MSBuildLocator.QueryVisualStudioInstances().FirstOrDefault();

            if (instance == null)
            {
                WriteLine("MSBuild location not found.");
                return;
            }

            MSBuildLocator.RegisterInstance(instance);

            using (MSBuildWorkspace workspace = MSBuildWorkspace.Create())
            {
                string solutionPath = @"..\..\..\..\Roslynator.MetricsTest.sln";

                workspace.WorkspaceFailed += (o, e) => WriteLine(e.Diagnostic.Message, ConsoleColor.Yellow);

                WriteLine($"Load solution '{solutionPath}'", ConsoleColor.Cyan);

                Solution solution;

                try
                {
                    solution = await workspace.OpenSolutionAsync(solutionPath);
                }
                catch (Exception ex)
                {
                    if (ex is FileNotFoundException
                        || ex is InvalidOperationException)
                    {
                        WriteLine(ex.ToString(), ConsoleColor.Red);
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }

                var codeMetricsOptions = new CodeMetricsOptions(ignoreBlockBoundary: true);

                WriteLine($"Count metrics for solution '{solutionPath}'", ConsoleColor.Cyan);

                var projectsMetrics = new List<(Project project, CodeMetrics metrics)>();

                foreach (Project project in solution.Projects)
                {
                    projectsMetrics.Add((project, await CodeMetricsCounter.CountLinesAsync(project, codeMetricsOptions)));
                }

                int maxDigits = projectsMetrics.Max(f => f.metrics.CodeLineCount).ToString("n0").Length;

                int maxNameLength = projectsMetrics.Max(f => f.project.Name.Length);

                foreach ((Project project, CodeMetrics metrics) in projectsMetrics.OrderByDescending(f => f.metrics.CodeLineCount))
                {
                    WriteLine($"{metrics.CodeLineCount.ToString("n0").PadLeft(maxDigits)} {project.Name.PadRight(maxNameLength)} {project.Language}");
                }

                WriteLine();
                WriteLine("Solution metrics:");

                int totalCodeLineCount = projectsMetrics.Sum(f => f.metrics.CodeLineCount);
                int totalBraceLineCount = projectsMetrics.Sum(f => f.metrics.BlockBoundaryLineCount);
                int totalWhiteSpaceLineCount = projectsMetrics.Sum(f => f.metrics.WhiteSpaceLineCount);
                int totalCommentLineCount = projectsMetrics.Sum(f => f.metrics.CommentLineCount);
                int totalPreprocessorDirectiveLineCount = projectsMetrics.Sum(f => f.metrics.PreprocessorDirectiveLineCount);
                int totalLineCount = projectsMetrics.Sum(f => f.metrics.TotalLineCount);

                string totalCodeLines = totalCodeLineCount.ToString("n0");
                string totalBraceLines = totalBraceLineCount.ToString("n0");
                string totalWhiteSpaceLines = totalWhiteSpaceLineCount.ToString("n0");
                string totalCommentLines = totalCommentLineCount.ToString("n0");
                string totalPreprocessorDirectiveLines = totalPreprocessorDirectiveLineCount.ToString("n0");
                string totalLines = totalLineCount.ToString("n0");

                maxDigits = Math.Max(totalCodeLines.Length,
                    Math.Max(totalBraceLines.Length,
                        Math.Max(totalWhiteSpaceLines.Length,
                            Math.Max(totalCommentLines.Length,
                                Math.Max(totalPreprocessorDirectiveLines.Length, totalLines.Length)))));

                WriteLine($"{totalCodeLines.PadLeft(maxDigits)} {totalCodeLineCount / (double)totalLineCount,4:P0} lines of code");
                WriteLine($"{totalBraceLines.PadLeft(maxDigits)} {totalBraceLineCount / (double)totalLineCount,4:P0} brace lines");
                WriteLine($"{totalWhiteSpaceLines.PadLeft(maxDigits)} {totalWhiteSpaceLineCount / (double)totalLineCount,4:P0} white-space lines");
                WriteLine($"{totalCommentLines.PadLeft(maxDigits)} {totalCommentLineCount / (double)totalLineCount,4:P0} comment lines");
                WriteLine($"{totalPreprocessorDirectiveLines.PadLeft(maxDigits)} {totalPreprocessorDirectiveLineCount / (double)totalLineCount,4:P0} preprocessor directive lines");

                WriteLine($"{totalLines.PadLeft(maxDigits)} {totalLineCount / (double)totalLineCount,4:P0} total lines");

                WriteLine();

                ReadKey();
            }
        }
    }
}
