using System;

namespace Aurore.Framework.Core.Exceptions
{
    public class FrameworkException : Exception
    {
        public FrameworkException()
            : base()
        { }

        public FrameworkException(string message)
            : base(message)
        { }

        public FrameworkException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}