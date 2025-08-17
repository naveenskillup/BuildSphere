using BuildSphere.Web.Adapters;

namespace BuildSphere.Web.Configure
{
    public static class Adaptors
    {
        public static IServiceCollection RegisterAdapters(this IServiceCollection services)
        {
            services.AddScoped<AuthAdapter>();
            return services;
        }
    }
}
