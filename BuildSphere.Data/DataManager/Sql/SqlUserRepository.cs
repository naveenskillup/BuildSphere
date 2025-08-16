using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Common.Definitions;
using BuildSphere.Data.Repository.Interfaces;
using Dapper;

namespace BuildSphere.Data.DataManager.Sql
{
    public class SqlUserRepository : SqlRepository<User>, IUserRepository
    {

        public SqlUserRepository(SqlConnectionFactory sqlConnectionFactory) : base(sqlConnectionFactory)
        { }

        public async Task<IEnumerable<User>> Get()
            => await QueryAsync(StoredProcedures.User.Get);

        public async Task<User> GetByUserName(string userName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("UserName", userName);
            return await QueryFirstAsync(StoredProcedures.User.Get, parameters);
        }

        public async Task<User> GetByUserNameAndPassword(string userName, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("UserName", userName);
            parameters.Add("Password", password);
            return await QueryFirstAsync(StoredProcedures.Project.Get, parameters);
        }

        public async Task Create(User user)
            => user.Id = await InsertAndReturnIdAsync(StoredProcedures.User.Create);

        public async Task Update(int id, User user)
        {
            var parameters = ObjectToParameters(user, new[] { "Id" });
            parameters.Add("@Id", id);
            await ExecuteAsync(StoredProcedures.User.Update, parameters);
        }

        public async Task Delete(int id)
        {
            var parameters = new { Id = id };
            await ExecuteAsync(StoredProcedures.User.Delete, parameters);
        }
    }
}
