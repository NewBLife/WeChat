using System;
using System.Runtime.Serialization;
using Aurore.Framework.Core.Exceptions;

namespace WeChat.Core
{

    [Serializable]
    public class ErrorJsonResultException : AuroreException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //
        public string Url { get; set; }

        public ErrorJsonResultException()
        {
        }

        public ErrorJsonResultException(int errorCode, string message) : base(errorCode, message)
        {
        }

        public ErrorJsonResultException(string message, Exception inner) : base(message, inner)
        {
        }
        public ErrorJsonResultException(int errorCode, string message, Exception inner) : base(errorCode, message, inner)
        {
        }

    }
}