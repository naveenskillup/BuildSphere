using System.Threading.Tasks;
using BuildSphere.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Services.Authentication
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(IAuthService authService)
            => _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var token = await _authService.Authenticate(request.UserName, request.Password);
            return Ok(token);
        }
        private readonly IAuthService _authService;

    }
}
