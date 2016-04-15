using System;

namespace Aurore.Framework.Core
{
    public interface ILogger
    {

        void WriteLog(string msg);
        void WriteError(string msg);
        void WriteError( string msg, Exception ex);
    }
}