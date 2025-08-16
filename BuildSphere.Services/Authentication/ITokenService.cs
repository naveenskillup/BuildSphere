using System;
using System.Security.Claims;

namespace BuildSphere.Services.Authentication
{
    public interface ITokenService
    {
        public string GenerateToken(string username, string role, int expirationInMinutes = 5 );
    }
}
