
using BuildSphere.Common.Definitions;

namespace BuildSphere.Data.TextFile
{
    public class TextProjectRepository : SharedFileStorageManager<Project>
    {
        public TextProjectRepository() : base(_fileName)
        { }

        public override IEnumerable<Project> Get() => base.Get();

        public override Project GetById(int id) => base.GetById(id);

        public override void Create(Project project) => base.Create(project);

        public override void Delete(int id) => base.Delete(id);

        public override void Update(int id, Project project) => base.Update(id, project);

        private const string _fileName = "Projects.json";
    }
}
