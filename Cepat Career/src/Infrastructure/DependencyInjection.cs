using Application.commons.IRepository;
using Application.commons.IServices;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Infrastructure.Services;
using Infrastructure.Services.CloudinaryServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isDevelopment)
        {
            services.AddDbContext<AppDbContext>((sp, options) =>
            {
               options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
               );

               options.EnableDetailedErrors();

               if (isDevelopment)
                {
                    options.EnableSensitiveDataLogging();
                }
            });

            services.AddScoped<IJobsRepository, JobsRepository>();
            services.AddScoped<IApplicationsRepository, JobApplicationsRepository>();

            services.Configure<CloudinarySettings>(
                configuration.GetSection("CloudinarySettings")
            );

            services.AddScoped<IStorageRepository, StorageRepository>();

            return services;
        }
        
    }
}