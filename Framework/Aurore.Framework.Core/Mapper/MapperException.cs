using System;
using Aurore.Framework.Core.Exceptions;

namespace Aurore.Framework.Core.Mapper
{
    public class MapperException : InfrastructureException
    {
        public MapperException()
            : base()
        { }

        public MapperException(string message)
            : base(message)
        { }

        public MapperException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
