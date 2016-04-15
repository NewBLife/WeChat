namespace Aurore.Framework.Core
{
    public interface ILogger
    {

        void WriteLog(string msg);
        void WriteLog(string errorType,string msg);
        void WriteLog( string msg, AuroreException ex);
        void WriteLog(string errorType,string msg,AuroreException ex);
    }
}