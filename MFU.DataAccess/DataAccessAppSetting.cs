using System.Configuration;

namespace MFU.DataAccess
{
    public static class DataAccessAppSetting
    {
        public static readonly string DefaultDatabase = ConfigurationManager.AppSettings["DefaultDB"];
        public static readonly int RecordPerPage = int.Parse(ConfigurationManager.AppSettings["RecordPerPage"]);
    }
}