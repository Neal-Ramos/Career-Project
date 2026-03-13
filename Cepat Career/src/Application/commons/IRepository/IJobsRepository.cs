using Application.features.Jobs.DTOs;

namespace Application.commons.IRepository
{
    public interface IJobsRepository
    {
        Task<List<JobsDto>> GetAllJobs(
            int Page,
            int PageSize
        );
    }
}