using BuildSphere.Data.Repository.Definitions;
using BuildSphere.Data.Repository.Interfaces;

namespace BuildSphere.Data.TextFile
{
    public class TextProjectRepository : SharedFileStorageManager<Project>, IProjectRepository
    {
        public TextProjectRepository() : base(_fileName)
        { }

        public override IEnumerable<Project> Get() => base.Get();

        public override Project GetById(int id) => base.GetById(id);

        public override void Add(Project project) => base.Add(project);

        public override void Delete(int id) => base.Delete(id);

        public override void Update(int id, Project project) => base.Update(id, project);

        private const string _fileName = "Projects.json";
    }
}
