using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BuildSphere.Data.DataManager.Sql
{
    public class SqlConnectionFactory
    {
        public SqlConnectionFactory(string server, string databaseName) 
        {
            var sqlConnectionBuilder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = databaseName,
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };
            _connectionString = sqlConnectionBuilder.ToString();
        }

        public Task<IDbConnection> GetConnectionAsync()
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            return Task.FromResult(connection);
        }

        private readonly string _connectionString;
    }
}
