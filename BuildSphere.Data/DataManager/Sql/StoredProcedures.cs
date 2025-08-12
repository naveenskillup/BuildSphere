
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

        public static class Milestone
        {
            public const string GetByProjectId = "Sp_GetMilestonesByProjectId";
            public const string Create = "sp_CreateMilestone";
            public const string Update = "sp_UpdateMilestone";
            public const string Delete = "sp_DeleteMilestone";
        }

        public static class Specification
        {
            public const string GetByProjectId = "Sp_GetSpecificationsByProjectId";
            public const string Create = "sp_CreateSpecification";
            public const string Update = "sp_UpdateSpecification";
            public const string Delete = "sp_DeleteSpecification";
        }
    }
}
