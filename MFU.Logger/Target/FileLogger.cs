using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFU.Logger
{
    public class FileLogger : LoggerBase
    {
        private string FilePath
        {
            get
            {
                string logFolder = @"C:\Log";
                string logFilename = string.Format("{0}_{1}{2}", Level.ToString(), DateTime.Now.ToString("yyyyMMdd"),
                    ".log");
                if (ConfigurationManager.AppSettings.AllKeys.Contains("LoggerFilePath"))
                {
                    logFolder = ConfigurationManager.AppSettings["LoggerFilePath"];
                }

                if (!Directory.Exists(logFolder))
                    Directory.CreateDirectory(logFolder);

                return string.Format(@"{0}\{1}", logFolder, logFilename);
            }
        }

        public override void Log(string message)
        {
            lock (lockObj)
            {
                using (var streamWriter = new StreamWriter(FilePath, append: true))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
    }
}