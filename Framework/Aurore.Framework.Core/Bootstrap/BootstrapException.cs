using System;
using Aurore.Framework.Core.Exceptions;

namespace Aurore.Framework.Core.Bootstrap
{
    public class BootstrapException : InfrastructureException
    {
        public BootstrapException()
            : base()
        { }

        public BootstrapException(string message)
            : base(message)
        { }

        public BootstrapException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
