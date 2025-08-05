using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Data.Repository.Definitions;

namespace BuildSphere.Data.Repository.Interfaces
{
    public interface ISpecificationRepository
    {
        Task<IEnumerable<Specification>> GetByProjectId(int projectId);
        Task Create(int projectId, Specification milestone);
        Task Update(int id, Specification milestone);
        Task Delete(int id);
    }
}
