using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Data.DataManager.Sql;
using BuildSphere.Data.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BuildSphere.Core
{
    public static class DataServicesRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, SqlProjectRepository>();
            services.AddScoped<IMilestoneRepository, SqlMilestoneRepository>();
            services.AddScoped<ISpecificationRepository, SqlSpecificationRepository>();
            services.AddScoped<IUserRepository, SqlUserRepository>();

            return services;
        }
    }
}
