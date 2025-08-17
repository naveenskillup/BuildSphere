using System;
using System.Security.Claims;
using BuildSphere.Common.Definitions;

namespace BuildSphere.Services.Authentication
{
    public interface ITokenService
    {
        public string GenerateToken(string username, UserRoles role, int expirationInMinutes = 5 );
    }
}
