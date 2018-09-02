// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

#pragma warning disable CS1591, CA1051, CA1822

namespace Roslynator.Documentation.Test
{
    public class B
    {
        public const string FooConst = "abc";

        public string Field;

        public string Method([SomeAttribute] [SomeAttribute] string s1, [SomeAttribute] string s2, [SomeAttribute] string s3) => s1 + s2 + s3;

        public int this[[SomeAttribute] [SomeAttribute] int index1, [SomeAttribute] int index2, [SomeAttribute] int index3] => index1 + index2 + index3;

        public string Property { [SomeAttribute] [SomeAttribute] get; }

        public event EventHandler Event
        {
            [SomeAttribute]
            add { }
            remove { }
        }
    }
}
