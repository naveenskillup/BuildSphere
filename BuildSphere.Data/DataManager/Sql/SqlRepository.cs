using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using Dapper;

namespace BuildSphere.Data.DataManager.Sql
{
    public abstract class SqlRepository<T>
    {
        protected SqlRepository(SqlConnectionFactory connectionFactory) 
          => _connectionFactory = connectionFactory;

        public DynamicParameters ObjectToParameters(object obj, string[]? exclude = null, bool skipNulls = false)
        {
            var parameters = new DynamicParameters();

            if (obj == null) return parameters;
            
            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttribute<NotMappedAttribute>() == null); ;

            properties.Where(prop => exclude == null || !exclude.Contains(prop.Name))
                      .Select(prop => new { prop.Name, value = prop.GetValue(obj) })
                      .Where(p => !skipNulls || p.value != null)
                      .ToList()
                      .ForEach(p => parameters.Add($"@{p.Name}", p.value));

            return parameters;
        }

        protected async Task<IEnumerable<T>> QueryAsync(string storedProcedure, object? parameters = null)
        {
            using var conn = await _connectionFactory.GetConnectionAsync();
            return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        protected async Task<T?> QueryFirstOrDefaultAsync(string storedProcedure, object? parameters = null)
        {
            using var conn = await _connectionFactory.GetConnectionAsync();
            return await conn.QueryFirstOrDefaultAsync<T?>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        protected async Task<int> InsertAndReturnIdAsync(string storedProcedure, object? parameters = null)
        {
            using var conn = await _connectionFactory.GetConnectionAsync();
            return await conn.QuerySingleAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        protected async Task<int> ExecuteAsync(string storedProcedure, object? parameters = null)
        {
            using var conn = await _connectionFactory.GetConnectionAsync();
            return await conn.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        private readonly SqlConnectionFactory _connectionFactory;
    }
}
