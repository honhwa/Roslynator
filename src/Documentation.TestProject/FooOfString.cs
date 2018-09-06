// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#pragma warning disable CS1591, CA1051, CA1822

namespace Roslynator.Documentation.Test
{
    public class FooOfString : Foo<string>
    {
        new public string Field;

        new public string Method(string p) => p;

        new public string ToString() => "";

        new public string this[string p] => p;

        new public string Property { get; }
    }
}
