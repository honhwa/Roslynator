// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable CS0219 // Variable is assigned but its value is never used

namespace Roslynator.Metrics
{
    /// <summary>
    /// Foo
    /// </summary>
    internal static class Foo //
    {

#if DEBUG
        /**
         * <summary>Bar</summary>
         */
        public static void Bar() /**/
        {
            //
            string s = @"

";

            Bar(); /*
             
             */ Bar();
        }
#endif

    }
}
