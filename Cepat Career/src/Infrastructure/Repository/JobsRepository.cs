using Application.commons.IRepository;
using Application.features.Jobs.DTOs;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class JobsRepository: IJobsRepository
    {
        private readonly AppDbContext context;
        public JobsRepository (AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public async Task<List<JobsDto>> GetAllJobs(
            int Page,
            int PageSize
        )
        {
            var jobs = await context.Jobs
            .Take(PageSize)
            .Skip((Page - 1) * PageSize)
            .Select(j => new JobsDto
            {
                Id = j.Id,
                JobId = j.JobId,
                Title = j.Title,
                Description = j.Description,
                Roles = j.Roles,
                FileRequirements = j.FileRequirements,
                DateCreated = j.DateCreated,
            }).ToListAsync();

            return jobs;
        }
    }
}