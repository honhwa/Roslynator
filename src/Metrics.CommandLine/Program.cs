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

                var codeMetricsOptions = new CodeMetricsOptions();

                WriteLine($"Count metrics for solution '{solutionPath}'", ConsoleColor.Cyan);

                var projectMetrics = new List<(Project project, LineMetrics metrics)>();

                foreach (Project project in solution.Projects)
                {
                    projectMetrics.Add((project, await CodeMetrics.CountLinesAsync(project, codeMetricsOptions)));
                }

                WriteLine();
                WriteLine("Solution metrics:");

                WriteLine($"{projectMetrics.Sum(f => f.metrics.CodeLineCount),7:n0} lines of code");
                WriteLine($"{projectMetrics.Sum(f => f.metrics.WhiteSpaceLineCount),7:n0} white-space lines");
                WriteLine($"{projectMetrics.Sum(f => f.metrics.CommentLineCount),7:n0} comment lines");
                WriteLine($"{projectMetrics.Sum(f => f.metrics.PreprocessDirectiveLineCount),7:n0} preprocessor directive lines");
                WriteLine($"{projectMetrics.Sum(f => f.metrics.TotalLineCount),7:n0} total lines");

                int maxDigits = projectMetrics.Max(f => f.metrics.CodeLineCount).ToString("n0").Length;

                WriteLine();
                WriteLine("Lines of code by project:");

                foreach ((Project project, LineMetrics metrics) in projectMetrics.OrderByDescending(f => f.metrics.CodeLineCount))
                {
                    WriteLine($"{metrics.CodeLineCount.ToString("n0").PadLeft(maxDigits)} {project.Name}");
                }

                WriteLine();

                ReadKey();
            }
        }
    }
}
