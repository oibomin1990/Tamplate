using MFU.Models;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace MFU.DataAccess.Repository
{
    public class RequestRepository : Repository<Request>
    {
        public RequestRepository(DatabaseSource databaseSource) : base (databaseSource)
        {

        }
        public IEnumerable<Request> GetAllRequest()
        {
            using (var conn = ConnectionFactory.Connection())
            {
                return conn.Query<Request, RequestType, Request>(SqlText.Request_Select,
                (request, reuestType) =>
                {
                    request.RequestType = reuestType;
                    return request;
                },
                splitOn: "RequestTypeId"
                ).ToList();
            }
            return new List<Request>();
        }

        public Request GetRequestById(decimal id)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                return conn.Query<Request, RequestType, Request>(SqlText.Request_Select_ByID.Replace("@REQUESTID", id.ToString()),
                (request, reuestType) =>
                {
                    request.RequestType = reuestType;
                    return request;
                },
                splitOn: "RequestTypeId"
                ).FirstOrDefault();
            }
            return new Request();
        }

        public Province GetProvinceById(string id)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("vprovinceid", 170, dbType: OracleDbType.Int32);
                parameters.Add("vlanguage", "T", dbType: OracleDbType.Varchar2);
                parameters.Add("pdata", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
                var affectedRows = conn.Query<Province>(
                    sql: "SP_NAME",
                    param: parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return affectedRows;
            }
        }

        public Request AddRequest()
        {
            using (var conn = ConnectionFactory.Connection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("requesttypeid", 101);
                parameters.Add("requeststatus", "D");
                parameters.Add("acadyear", 2560);
                parameters.Add("semester", 1);
                parameters.Add("studentid", "4631301045");
                parameters.Add("requestid", dbType: DbType.Decimal, direction: ParameterDirection.Output);

                conn.Execute(SqlText.Request_Insert, parameters);
                var Id = parameters.Get<decimal>("requestid");

                return GetRequestById(Id);
            }
        }

        public Request UpdateRequest(decimal id)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("studentid", "6031301045");
                parameters.Add("requestid", id);

                conn.Execute(SqlText.Request_Update, parameters);

                return GetRequestById(id);
            }
        }

        public void DeleteRequest(decimal id)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("requestid", id);

                conn.Execute(SqlText.Request_Delete, parameters);
            }
        }

    }
}
