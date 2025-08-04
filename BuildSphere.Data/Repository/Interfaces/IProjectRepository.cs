using BuildSphere.Data.Repository.Definitions;

namespace BuildSphere.Data.Repository.Interfaces
{
    public interface IProjectRepository
    {
        Project GetById(int id);
        IEnumerable<Project> Get();
        void Add(Project project);
        void Update(int id, Project project);
        void Delete(int id);
    }
}
