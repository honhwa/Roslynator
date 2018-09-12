// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

#pragma warning disable CS1591, CA1051, CA1822, CA1711

namespace Roslynator.Documentation.Test
{
    public class C : B
    {
        new public string Field;

        new public string Method(string s1, string s2, string s3) => s1 + s2 + s3;

        new public string ToString() => "";

        new public int this[int index1, int index2, int index3] => index1 + index2 + index3;

        new public string Property { get; }

        new public event EventHandler Event;

        new public class FooClass
        {
        }

        new public struct FooStruct
        {
        }

        new public interface IFoo
        {
            void M();
        }

        new public delegate void FooDelegate();

        new public enum FooEnum
        {
            None
        }
    }
}
