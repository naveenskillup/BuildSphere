using System.Collections.Generic;
using System.Threading.Tasks;
using BuildSphere.Common.Definitions;
using BuildSphere.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Services.Controllers
{
    [Route("api/milestones")]
    [ApiController]
    public class MilestoneController : ControllerBase
    {
        public MilestoneController(IMilestoneRepository milestoneRepository)
        {
            _milestoneRepository = milestoneRepository;
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<IEnumerable<Milestone>>> GetByProjectId(int projectId)
        {
            var milestones = await _milestoneRepository.GetByProjectId(projectId);
            return Ok(milestones);
        }

        [HttpPost("{projectId}")]
        public async Task<ActionResult> Create(int projectId, [FromBody] Milestone milestone)
        {
            if (milestone == null)
                return BadRequest("Milestone data is required.");

            await _milestoneRepository.Create(projectId, milestone);
            return CreatedAtAction(nameof(GetByProjectId), new { projectId = projectId }, milestone);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Milestone milestone)
        {
            if (milestone == null)
                return BadRequest("Milestone data is required.");

            await _milestoneRepository.Update(id, milestone);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _milestoneRepository.Delete(id);
            return NoContent();
        }

        private readonly IMilestoneRepository _milestoneRepository;
    }
}
