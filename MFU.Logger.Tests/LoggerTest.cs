
using System.Configuration;
using System.Linq;
using System.IO;
using NUnit.Framework;

namespace MFU.Logger.Tests
{
    [TestFixture]
    [Category("IntegrationTests.MFU.Logger")]
    public class LoggerTest
    {
        private  string LogFolder { get; set; }
        [SetUp]
        public void SetUp()
        {
            ClearFolder();
        }

        [TearDown]
        public void TearDown()
        {
            ClearFolder();
        }

        private void ClearFolder()
        {
            LogFolder = ConfigurationManager.AppSettings["LoggerFilePath"];
            if (Directory.Exists(LogFolder))
                new DirectoryInfo(LogFolder).Delete(true);
        }

        private string GetTextInLogFile()
        {
            string actualResult = "";
            string[] fileEntries = Directory.GetFiles(LogFolder);
            if (File.Exists(fileEntries[0]))
                actualResult = File.ReadAllText(fileEntries[0]);
            return actualResult;
        }

        [Test]
        public void Should_Default_Log_To_File()
        {
            var message = string.Format("Log {0} message from Integration Tests", LoggerLevel.INFO);
            LoggerHelper.Log(message);
            string actualResult = GetTextInLogFile();
            Assert.IsTrue(actualResult.Contains(message));
        }

        [Test]
        public void Should_Log_To_File([Values]LoggerLevel loggerLevel)
        {
            var message = string.Format("Log {0} message from Integration Tests", loggerLevel.ToString());
            LoggerHelper.Log(message, loggerLevel);
            string actualResult = GetTextInLogFile();
            Assert.IsTrue(actualResult.Contains(message));
        }

        [Test]
        [Ignore("Ignore test log with database")]
        public void Should_Log_To_Database([Values]LoggerLevel loggerLevel)
        {
            var message = string.Format("Log {0} message from Integration Tests", loggerLevel.ToString());
            LoggerHelper.Log(message, loggerLevel, LoggerTarget.Database);
        }
    }
}
