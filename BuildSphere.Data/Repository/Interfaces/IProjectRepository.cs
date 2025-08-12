

using BuildSphere.Common.Definitions;

namespace BuildSphere.Data.Repository.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetById(int id);
        Task<IEnumerable<Project>> Get();
        Task Create(Project project);
        Task Update(int id, Project project);
        Task Delete(int id);
    }
}
