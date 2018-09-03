// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

#pragma warning disable CS0618, CS1591, RCS1079 

namespace Roslynator.Documentation.Test
{
    public class FooEvent : IFoo, IFoo2
    {
        public void Bar()
        {
        }

        event EventHandler IFoo.Changed
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }
    }
}
