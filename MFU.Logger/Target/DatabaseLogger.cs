using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;

namespace MFU.Logger
{
    public class DatabaseLogger : LoggerBase
    {
        private IDbConnection DbConnection
        {
            get
            {
				string loggerDefaultDb = ConfigurationManager.AppSettings["LoggerDefaultDB"];
                switch (loggerDefaultDb)
                {
                    case "SqlServer":
                        return new SqlConnection(ConfigurationManager.ConnectionStrings["LoggerSQLServerConnection"].ConnectionString);
                    case "Oracle":
                        return new OracleConnection(ConfigurationManager.ConnectionStrings["LoggerOracleConnection"].ConnectionString);
                    case "MySql":
                        return new MySqlConnection(ConfigurationManager.ConnectionStrings["LoggerMySqlConnection"].ConnectionString);
                    default:
                        return new SqlConnection(ConfigurationManager.ConnectionStrings["LoggerSQLServerConnection"].ConnectionString);
                }
            }
        }

        public override void Log(string message)
        {
            lock (lockObj)
            {
                using (IDbConnection dbConn = DbConnection)
                {
                    dbConn.Execute($"INSERT Logger([LogMessage],[LogLevel]) values ('{message}', '{Level.ToString()}')");
                }
            }
        }
    }
}