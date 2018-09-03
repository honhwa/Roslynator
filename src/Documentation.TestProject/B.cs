// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

#pragma warning disable CS1591, CA1051, CA1822

namespace Roslynator.Documentation.Test
{
    public class B
    {
        public const string FooConst = "abc";

        public string Field;

        public string Method([FooAttribute] [FooAttribute] string s1, [FooAttribute] string s2, [FooAttribute] string s3) => s1 + s2 + s3;

        public int this[[FooAttribute] [FooAttribute] int index1, [FooAttribute] int index2, [FooAttribute] int index3] => index1 + index2 + index3;

        public string Property { [FooAttribute] [FooAttribute] get; }

        public event EventHandler Event
        {
            [FooAttribute]
            add { }
            remove { }
        }
    }
}
