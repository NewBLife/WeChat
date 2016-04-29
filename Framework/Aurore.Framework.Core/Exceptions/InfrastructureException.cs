using System;

namespace Aurore.Framework.Core.Exceptions
{
    public class InfrastructureException : FrameworkException
    {
        public InfrastructureException()
            : base()
        { }

        public InfrastructureException(string message)
            : base(message)
        { }

        public InfrastructureException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}