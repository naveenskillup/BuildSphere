using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Data.Repository.Definitions;
using BuildSphere.Data.Repository.Interfaces;

namespace BuildSphere.Data.DataManager.Sql
{
    public class SqlMilestoneRepository : SqlRepository<Milestone>, IMilestoneRepository
    {
        public SqlMilestoneRepository(SqlConnectionFactory sqlConnectionFactory) : base(sqlConnectionFactory)
        { }

        public async Task<IEnumerable<Milestone>> GetByProjectId(int projectId)
        {
            var parameters = new { ProjectId = projectId };
            return await QueryAsync(StoredProcedures.Milestone.GetByProjectId, parameters);
        }

        public async Task Create(int projectId, Milestone milestone)
        {
            var parameters = ObjectToParameters(milestone, new[] { "Id" });
            parameters.Add("@ProjectId", projectId);
            milestone.Id = await InsertAndReturnIdAsync(StoredProcedures.Milestone.Create, parameters);
        }

        public async Task Delete(int id)
        {
            var parameters = new { Id = id };
            await ExecuteAsync(StoredProcedures.Milestone.Delete, parameters);
        }

        public async Task Update(int id, Milestone milestone)
        {
            var parameters = ObjectToParameters(milestone, new[] { "Id" });
            parameters.Add("@Id", id);
            await ExecuteAsync(StoredProcedures.Milestone.Update, parameters);
        }

    }
}
