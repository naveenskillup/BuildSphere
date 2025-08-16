using System.Collections.Generic;
using System.Threading.Tasks;
using BuildSphere.Common.Definitions;
using BuildSphere.Core.Interfaces;
using BuildSphere.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Services.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUserService userRepository)
             => _userService = userRepository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Milestone>>> Get()
        {
            var milestones = await _userService.Get();
            return Ok(milestones);
        }

        [HttpGet("username")]
        public async Task<ActionResult> GetByUserName(string userName)
        {
            if (userName == null)
                return BadRequest("username data is required.");

            var user = await _userService.GetByUserName(userName);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest("user data is required.");

            await _userService.Create(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest("Milestone data is required.");

            await _userService.Update(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }

        private readonly IUserService _userService;
    }
}
