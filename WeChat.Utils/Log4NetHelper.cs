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
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }


        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="msg"></param>
        public void WriteError(string msg)
        {
            WriteError(msg, null);
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public void WriteError(string msg, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(msg, ex);
            }
        }

        
        /// <summary>
        /// 普通的文件记录日志
        /// </summary>
        /// <param name="msg"></param>
        public void WriteLog(string msg)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(msg);
            }
        }
    }
}