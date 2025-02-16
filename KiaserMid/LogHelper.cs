﻿using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KiaserMid
{
    public class LogHelper
    {

        private static Logger logger;
        static LogHelper()
        {
           logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void WriteError(string message)
        {
            logger.Log(LogLevel.Error, message);
        }

        /// <summary>
        /// 写入操作日志
        /// </summary>
        /// <param name="message"></param>
        public static void WriteInfo(string message)
        {
            logger.Log(LogLevel.Info, message);
        }
    }
}
