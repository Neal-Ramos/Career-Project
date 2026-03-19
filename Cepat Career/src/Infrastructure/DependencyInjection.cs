using Application.commons.IRepository;
using Application.commons.IServices;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Infrastructure.Services;
using Infrastructure.Services.CloudinaryServices;
using Infrastructure.Services.ResendServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resend;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isDevelopment)
        {
            //Register DbContext
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

            //Register Repositories
            services.AddScoped<IJobsRepository, JobsRepository>();
            services.AddScoped<IApplicationsRepository, JobApplicationsRepository>();

            //Register Cloudinary
            services.Configure<CloudinarySettings>(
                configuration.GetSection("CloudinarySettings")
            );
            services.AddScoped<IStorageRepository, StorageRepository>();

            //Register Resend
            services.AddOptions();
            services.AddHttpClient<ResendClient>();
            services.AddTransient<IResend, ResendClient>();
            services.Configure<ResendClientOptions>(options =>
            {
                options.ApiToken = configuration["Resend:ApiKey"]!;
            });
            services.AddScoped<ISendEmail, ResendRepository>();

            return services;
        }
        
    }
}