using BuildSphere.Core.Interfaces;
using BuildSphere.Core.Services;
using BuildSphere.Data.DataManager.Sql;
using BuildSphere.Data.Repository.Interfaces;
using BuildSphere.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuildSphere.Services.Configurations
{
    public static class CoreServices
    {
        public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, JWTTokenGenerationService>();

            return services;
        }
    }
}
