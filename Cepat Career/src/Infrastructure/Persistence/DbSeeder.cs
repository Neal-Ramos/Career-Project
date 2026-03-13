using System.Text.Json;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public interface IDbSeeder
    {
        Task SeedAsync();
    }
    public class DbSeeder: IDbSeeder
    {
        private readonly AppDbContext context;
        public DbSeeder(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public async Task SeedAsync()
        {
            if (!context.Jobs.Any())
        {
            context.Jobs.AddRange(
                new Jobs
                {
                    Title= "Frontend Developer",
                    Description= "We are looking for a frontend developer to build responsive interfaces using React and TailwindCSS. The candidate should be comfortable working with modern UI frameworks and collaborating with designers and backend developers.",
                    Roles = JsonSerializer.Serialize(new[]
                    {
                        new { Name = "React", Level = "Intermediate" },
                        new { Name = "Tailwind", Level = "Intermediate" },
                        new { Name = "TypeScript", Level = "Advanced" }
                    }),
                    FileRequirements = JsonSerializer.Serialize(new[]
                    {
                        new { FileName = "Resume", Required = true },
                        new { FileName = "Portfolio", Required = false }
                    }),
                    CreatedBy = "Admin"
                }
            );

            await context.SaveChangesAsync();
        }
        }
    }
}