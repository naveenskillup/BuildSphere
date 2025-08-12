

using BuildSphere.Common.Definitions;

namespace BuildSphere.Core.Interfaces
{
    public interface IProjectService
    {
        Task Create(Project project);
    }
}
