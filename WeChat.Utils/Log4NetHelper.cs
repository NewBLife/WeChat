using System;
using System.IO;
using Aurore.Framework.Core;

namespace WeChat.Utils
{
    /// <summary>
    /// 使用LOG4NET记录日志的功能，在WEB.CONFIG里要配置相应的节点
    /// </summary>
    public class Log4NetHelper:ILogger
    {
        //log4net日志专用
        private static readonly log4net.ILog Loginfo = log4net.LogManager.GetLogger("Loginfo");
        private static readonly log4net.ILog Logerror = log4net.LogManager.GetLogger("Logerror");

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        public void WriteLog(string msg)
        {
            if (Loginfo.IsInfoEnabled)
            {
                Loginfo.Info(msg);
            }
        }

        public void WriteError( string msg)
        {
            if (Loginfo.IsInfoEnabled)
            {
                Logerror.Error(msg);
            }
        }

        public void WriteError(string msg, Exception ex)
        {
            if (Loginfo.IsInfoEnabled)
            {
                Logerror.Error(msg, ex);
            }
        }
    }
}