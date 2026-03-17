using Application.features.JobApplications.DTOs;
using Domain.enums;

namespace Application.commons.IRepository
{
    public interface IApplicationsRepository
    {
        Task<JobApplicationDto> AddApplication(
            string FirstName,
            string MiddleName,
            string LastName,
            string Email,
            string ContactNumber,
            string UniversityName,
            string Degree,
            int GraduationYear,
            string SubmittedFile,
            Guid JobId
        );
    }
}