using Domain.Entities;
using Infrastructure.Persistence.configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Jobs> Jobs => Set<Jobs>();
        public DbSet<JobApplications> JobApplications => Set<JobApplications>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobsConfigurations).Assembly);
        }
    }
}