﻿using System;
using Aurore.Framework.Core;
using WeChat.Utils.WeChat.Utils;

namespace WeChat.Utils
{
    using System;
    using System.IO;

    namespace WeChat.Utils
    {
        /// <summary>
        /// 使用LOG4NET记录日志的功能，在WEB.CONFIG里要配置相应的节点
        /// </summary>
        public class Log4NetHelper
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
            /// 普通的文件记录日志
            /// </summary>
            /// <param name="info"></param>
            public static void WriteLog(string info)
            {
                if (loginfo.IsInfoEnabled)
                {
                    loginfo.Info(info);
                }
            }

            /// <summary>
            /// 错误日志
            /// </summary>
            /// <param name="info"></param>
            /// <param name="se"></param>
            public static void WriteError(string info, Exception se)
            {
                if (logerror.IsErrorEnabled)
                {
                    logerror.Error(info, se);
                }
            }
        }
    }

    public class TextLogger : ILogger
    {
        public void WriteLog(string msg)
        {
            Log4NetHelper.WriteLog(msg);
        }

        public void WriteError(string msg)
        {
            WriteError(msg, null);

        }

        public void WriteError(string msg, Exception ex)
        {
            Log4NetHelper.WriteError(msg,ex);
        }
    }
}