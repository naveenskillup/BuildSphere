using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Data.Repository.Definitions;
using BuildSphere.Data.Repository.Interfaces;

namespace BuildSphere.Data.DataManager.Sql
{
    public class SqlSpecificationRepository : SqlRepository<Specification>, ISpecificationRepository
    {
        public SqlSpecificationRepository(SqlConnectionFactory sqlConnectionFactory) : base(sqlConnectionFactory)
        { }

        public async Task<IEnumerable<Specification>> GetByProjectId(int projectId)
        {
            var parameters = new { ProjectId = projectId };
            return await QueryAsync(StoredProcedures.Specification.GetByProjectId, parameters);
        }

        public async Task Create(int projectId, Specification specification)
        {
            var parameters = ObjectToParameters(specification, new[] { "Id" });
            parameters.Add("@ProjectId", projectId);
            specification.Id = await InsertAndReturnIdAsync(StoredProcedures.Specification.Create, parameters);
        }

        public async Task Update(int id, Specification specification)
        {
            var parameters = ObjectToParameters(specification, new[] { "Id" });
            parameters.Add("@Id", id);
            await ExecuteAsync(StoredProcedures.Specification.Update, parameters);
        }

        public async Task Delete(int id)
        {
            var parameters = new { Id = id };
            await ExecuteAsync(StoredProcedures.Specification.Delete, parameters);
        }

    }
}
