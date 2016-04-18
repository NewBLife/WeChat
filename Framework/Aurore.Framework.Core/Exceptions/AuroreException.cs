using System;

namespace Aurore.Framework.Core.Exceptions
{
    [Serializable]
    public class AuroreException : Exception
    {
        public int ErrorCode { get; set; }

        public AuroreException() : this(-10000)
        {
        }

        public AuroreException(int errorCode) : this(errorCode, "不明确的异常")
        {

        }

        public AuroreException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public AuroreException(Exception inner) : this("不明确的异常", inner)
        {
        }

        public AuroreException(string message, Exception inner) : this(-10000, message, inner)
        {
        }
        public AuroreException(int errorCode, string message, Exception inner) : base(message, inner)
        {
            ErrorCode = errorCode;
        }
    }
}