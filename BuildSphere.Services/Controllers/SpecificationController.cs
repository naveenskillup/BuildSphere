using BuildSphere.Data.Repository.Definitions;
using BuildSphere.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        public SpecificationController(ISpecificationRepository specificationRepository) 
            => _specificationRepository = specificationRepository;

        [HttpGet("{projectId}")]
        public async Task<ActionResult<IEnumerable<Specification>>> GetByProjectId(int projectId)
        {
            var specifications = await _specificationRepository.GetByProjectId(projectId);
            return Ok(specifications);
        }

        [HttpPost("{projectId}")]
        public async Task<ActionResult> Create(int projectId, [FromBody] Specification specification)
        {
            if (specification == null)
                return BadRequest("Specification data is required.");

            await _specificationRepository.Create(projectId, specification);
            return CreatedAtAction(nameof(GetByProjectId), new { projectId = projectId }, specification);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Specification specification)
        {
            if (specification == null)
                return BadRequest("Specification data is required.");

            await _specificationRepository.Update(id, specification);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _specificationRepository.Delete(id);
            return NoContent();
        }

        private readonly ISpecificationRepository _specificationRepository;
    }
}
