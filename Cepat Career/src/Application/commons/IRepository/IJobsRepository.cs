using Application.features.Jobs.DTOs;

namespace Application.commons.IRepository
{
    public interface IJobsRepository
    {
        Task<GetAllJobsDto> GetAllJobs(
            int Page,
            int PageSize,
            string? Search
        );
        Task<JobsDto?> GetJobsById(
            Guid JobId
        );
    }
}