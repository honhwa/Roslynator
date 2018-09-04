// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;

#pragma warning disable CS1591, CA1051, CA1822, RCS1101, RCS1163

namespace Roslynator.Documentation.Test
{
    [Serializable]
    public class FooException<T> : Exception
    {
        public FooException()
        {
        }

        public FooException(string message) : base(message)
        {
        }

        public FooException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FooException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
