using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Core.Definitions;

namespace BuildSphere.Core.Interfaces
{
    public interface IProjectRepository
    {
        Project GetById(int id);
        IEnumerable<Project> Get();
        void Add(Project project);
        void Update(Project project);
        void Delete(int id);
    }
}
