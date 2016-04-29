namespace Aurore.Framework.Core.Logger
{
    public interface ILogger
    {
        void Debug(string message);
        //这种方法打印使用 Level.DEBUG 消息级别
        void Error(string message);
        //这种方法打印使用 Level.ERROR 消息级别
        void Fatal(string message);
        //这种方法打印使用 Level.FATAL 消息级别
        void Info(string message);
        //这种方法打印使用 Level.INFO 消息级别
        void Warn(string message);
        //这种方法打印使用 Level.WARN 消息级别
        void Trace(string message);
        //这种方法打印使用Level.TRACE消息级别
    }
}