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

        public async Task<GetAllJobsDto> GetAllJobs(
            int Page,
            int PageSize
        )
        {
            var count = await context.Jobs.CountAsync();
            var jobs = await context.Jobs
            .OrderBy(j => j.Id)
            .Skip((Page - 1) * PageSize)
            .Take(PageSize)
            .Select(j => new JobsDto
            {
                Id = j.Id,
                JobId = j.JobId,
                Title = j.Title,
                Description = j.Description,
                Roles = j.Roles,
                FileRequirements = j.FileRequirements,
                DateCreated = j.DateCreated
            }).ToListAsync();

            return new GetAllJobsDto
            {
                Jobs= jobs,
                TotalPages = (int)Math.Ceiling((double)count / PageSize),
                TotalRecords = count
            };
        }

        public async Task<JobsDto?> GetJobsById(
            Guid JobId
        )
        {
            var result = context.Jobs
                .FirstOrDefault(j => j.JobId == JobId);
            
            if(result == null)
            {
                return null;
            }
            else
            {
                return new JobsDto
                {
                    Id = result.Id,
                    JobId = result.JobId,
                    Title = result.Title,
                    Description = result.Description,
                    Roles = result.Roles,
                    FileRequirements = result.FileRequirements,
                    DateCreated = result.DateCreated
                };
            }
        }
    }
}