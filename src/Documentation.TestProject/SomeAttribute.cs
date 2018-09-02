// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

#pragma warning disable CS1591, CA1051, CA1822

namespace Roslynator.Documentation.Test
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class SomeAttribute : Attribute
    {
    }
}
