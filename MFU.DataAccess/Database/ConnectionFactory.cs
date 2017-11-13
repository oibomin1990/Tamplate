using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace MFU.DataAccess
{
    public static class ConnectionFactory
    {

        public static Func<IDbConnection> Connection = () => GetDatabaseConnection();

        private static DatabaseSource CurrentDatabaseSource;

        public static void LoadDatabaseSource()
        {
            CurrentDatabaseSource = (DatabaseSource)Enum.Parse(typeof(DatabaseSource), DataAccessAppSetting.DefaultDatabase);
        }

        public static void LoadDatabaseSource(DatabaseSource dataSource)
        {
            CurrentDatabaseSource = dataSource;
        }

        private static IDbConnection GetDatabaseConnection()
        {
            switch (CurrentDatabaseSource)
            {
                case DatabaseSource.SqlServer:
                    return new SqlConnection(DataAccessConnectionString.SqlServer);
                case DatabaseSource.Oracle:
                    return new OracleConnection(DataAccessConnectionString.Oracle);
                case DatabaseSource.MySql:
                    return new MySqlConnection(DataAccessConnectionString.MySql);
                default:
                    return new SqlConnection(DataAccessConnectionString.SqlServer);
            }
        }
    }
}