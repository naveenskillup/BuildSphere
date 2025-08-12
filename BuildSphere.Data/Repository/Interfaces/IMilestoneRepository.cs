
using BuildSphere.Common.Definitions;

namespace BuildSphere.Data.Repository.Interfaces
{
    public interface IMilestoneRepository
    {
        Task<IEnumerable<Milestone>> GetByProjectId(int projectId);
        Task Create(int projectId, Milestone milestone);
        Task Update(int id, Milestone milestone);
        Task Delete(int id);
    }
}
