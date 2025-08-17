
using System.Threading.Tasks;
using BuildSphere.Common.Exceptions;
using BuildSphere.Core.Interfaces;
using BuildSphere.Services.Authentication;

namespace BuildSphere.Core.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<string> Authenticate(string userName, string password)
        {
            var user = await _userService.GetByUserNameAndPassword(userName, password);

            if (user == null)
                throw BuildSphereErrors.Unauthorized("Invalid User");

            var token = _tokenService.GenerateToken(userName, user.Role);
            return token;
        }

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
    }
}
