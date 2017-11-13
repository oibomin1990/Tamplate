using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFU.Logger
{
    public static class LoggerHelper
    {
        private static string datetimeFormat;
        private static LoggerBase logger = null;
        public static void Log(string message, LoggerLevel level = LoggerLevel.INFO, LoggerTarget target = LoggerTarget.File)
        {
            message = string.Format("{0} {1}", GetLogMessage(level), message);

            switch (target)
            {
                case LoggerTarget.File:
                    logger = new FileLogger();
                    logger.Level = level;
                    logger.Log(message);
                    break;

                case LoggerTarget.Database:
                    logger = new DatabaseLogger();
                    logger.Level = level;
                    logger.Log(message);
                    break;
                default:
                    return;
            }
        }

        private static string GetLogMessage(LoggerLevel level)
        {
            datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            string pretext = DateTime.Now.ToString(datetimeFormat);
            switch (level)
            {
                case LoggerLevel.TRACE:
                    pretext = pretext + " [TRACE]";
                    break;
                case LoggerLevel.INFO:
                    pretext = pretext + " [INFO]";
                    break;
                case LoggerLevel.DEBUG:
                    pretext = pretext + " [DEBUG]";
                    break;
                case LoggerLevel.WARNING:
                    pretext = pretext + " [WARNING]";
                    break;
                case LoggerLevel.ERROR:
                    pretext = pretext + " [ERROR]";
                    break;
                case LoggerLevel.FATAL:
                    pretext = pretext + " [FATAL]";
                    break;
                default:
                    pretext = "";
                    break;
            }

            return pretext;
        }
    }
}
