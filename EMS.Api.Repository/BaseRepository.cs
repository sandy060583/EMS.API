using System;
using System.Data;
using System.Data.SqlClient;

namespace EMS.Api.Repository
{
    public class BaseRepository : IDisposable
    {
        protected IDbConnection DbConnection;
        public BaseRepository()
        {
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=DemoEMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            DbConnection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            DbConnection.Dispose();
        }
    }
}
