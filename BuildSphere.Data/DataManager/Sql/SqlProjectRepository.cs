
using BuildSphere.Common.Definitions;
using BuildSphere.Data.Repository.Interfaces;

namespace BuildSphere.Data.DataManager.Sql
{
    public class SqlProjectRepository : SqlRepository<Project>, IProjectRepository
    {
        public SqlProjectRepository(SqlConnectionFactory sqlConnectionFactory) : base(sqlConnectionFactory) 
        { }

        public async Task<IEnumerable<Project>> Get()
            => await QueryAsync(StoredProcedures.Project.Get);

        public async Task<Project> GetById(int id)
        {
            var parameters = new { Id = id };
            return await QueryFirstAsync(StoredProcedures.Project.GetById, parameters);
        }

        public async Task Create(Project project)
        {
            var parameters = ObjectToParameters(project, new[] { "Id" });
            project.Id = await InsertAndReturnIdAsync(StoredProcedures.Project.Create, parameters);
        }

        public async Task Update(int id, Project project)
        {
            var parameters = ObjectToParameters(project, new[] { "Id" });
            parameters.Add("@Id", id);
            await ExecuteAsync(StoredProcedures.Project.Update, parameters);
        }

        public async Task Delete(int id)
        {
            var parameters = new { Id = id };
            await ExecuteAsync(StoredProcedures.Project.Delete, parameters);
        }

    }
}
