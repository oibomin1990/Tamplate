using System.Configuration;

namespace MFU.DataAccess
{
    public class DataAccessConnectionString
    {
        public static readonly string SqlServer = ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
        public static readonly string Oracle = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
        public static readonly  string MySql = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
    }

    public enum DatabaseSource
    {
        SqlServer,
        Oracle,
        MySql
    }
}