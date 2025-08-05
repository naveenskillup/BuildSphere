using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Data.Repository.Definitions;

namespace BuildSphere.Core.Interfaces
{
    public interface IProjectService
    {
        Task Create(Project project);
    }
}
