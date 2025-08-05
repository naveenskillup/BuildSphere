
using BuildSphere.Data.Repository.Definitions;
using BuildSphere.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Services.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            return Ok(_projectRepository.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetById(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public IActionResult Add(Project project)
        {
            _projectRepository.Create(project);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Project project)
        {
            var existing = _projectRepository.GetById(id);
            if (existing == null) return NotFound();

            _projectRepository.Update(id, project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _projectRepository.GetById(id);
            if (existing == null) return NotFound();

            _projectRepository.Delete(id);
            return NoContent();
        }
    }
}
