
using BuildSphere.Data.Repository.Definitions;
using BuildSphere.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Services.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public ProjectController(IProjectRepository projectRepository)
            => _projectRepository = projectRepository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            var projects = await _projectRepository.Get();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetById(int id)
        {
            var project = await _projectRepository.GetById(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Project project)
        {
            await _projectRepository.Create(project);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Project project)
        {
            var existing = await _projectRepository.GetById(id);
            if (existing == null) return NotFound();

            await _projectRepository.Update(id, project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _projectRepository.GetById(id);
            if (existing == null) return NotFound();

            await _projectRepository.Delete(id);
            return NoContent();
        }

        private readonly IProjectRepository _projectRepository;
    }
}
