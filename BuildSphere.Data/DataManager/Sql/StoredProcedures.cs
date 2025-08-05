using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSphere.Data.DataManager.Sql
{
    public static class StoredProcedures
    {
        public static class Project
        {
            public const string Get = "Sp_GetProjects";
            public const string GetById = "sp_GetProjectById";
            public const string Create = "sp_CreateProject";
            public const string Update = "sp_UpdateProject";
            public const string Delete = "sp_DeleteProject";
        }
    }
}
