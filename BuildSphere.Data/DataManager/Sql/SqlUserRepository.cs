
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
            return await QueryFirstOrDefaultAsync(StoredProcedures.User.GetByUserName, parameters);
        }

        public async Task<User> GetByUserNameAndPassword(string userName, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("UserName", userName);
            parameters.Add("Password", password);
            return await QueryFirstOrDefaultAsync(StoredProcedures.User.GetByUserNameAndPassword, parameters);
        }

        public async Task Create(User user)
        {
            var parameters = ObjectToParameters(user, new[] { "Id" });
            user.Id = await InsertAndReturnIdAsync(StoredProcedures.User.Create, parameters);
        }

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
