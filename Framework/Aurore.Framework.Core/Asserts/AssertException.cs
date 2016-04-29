using System;
using Aurore.Framework.Core.Exceptions;

namespace Aurore.Framework.Core.Asserts
{
    public class AssertException : InfrastructureException
    {
        public AssertException()
            : base()
        { }

        public AssertException(string message)
            : base(message)
        { }

        public AssertException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
