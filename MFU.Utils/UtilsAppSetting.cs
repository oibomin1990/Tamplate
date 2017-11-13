using System.Configuration;

namespace MFU.Utils
{
    public static class UtilsAppSetting
    {
        public static readonly int MailTimeout = int.Parse(ConfigurationManager.AppSettings["MailTimeout"]);
        public static readonly int MailPort = int.Parse(ConfigurationManager.AppSettings["MailPort"]);
        public static readonly string MailHost = ConfigurationManager.AppSettings["MailHost"];
        public static readonly string MailCredentialsUser = ConfigurationManager.AppSettings["MailCredentialsUser"];
        public static readonly string MailCredentialsPassword = ConfigurationManager.AppSettings["MailCredentialsPassword"];
        public static readonly string MailDonotReply = ConfigurationManager.AppSettings["MailDonotReply"];
    }
}
