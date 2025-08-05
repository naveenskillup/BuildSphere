
using BuildSphere.Core.Interfaces;
using BuildSphere.Data.Repository.Definitions;
using BuildSphere.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Services.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public ProjectController(IProjectService projectService)
            => _projectService = projectService;

        [HttpPost]
        public async Task<IActionResult> Create(Project project){
            await _projectService.Create(project);
            return Ok(project);
        }

        private readonly IProjectService _projectService;
    }
}
