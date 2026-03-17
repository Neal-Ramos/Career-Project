using Application.commons.IRepository;
using Application.features.JobApplications.DTOs;
using MediatR;

namespace Application.features.JobApplications.Commands.AddApplication
{
    public class AddApplicationHandler: IRequestHandler<AddApplicationCommand, JobApplicationDto>
    {
        private readonly IApplicationsRepository _applicationsRepository;

        public AddApplicationHandler(IApplicationsRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
        }

        public async Task<JobApplicationDto> Handle(AddApplicationCommand req, CancellationToken cancellationToken)
        {
            var result = await _applicationsRepository.AddApplication(
                FirstName: req.FirstName,
                MiddleName: req.MiddleName,
                LastName: req.LastName,
                Email: req.Email,
                ContactNumber: req.ContactNumber,
                UniversityName: req.UniversityName,
                Degree: req.Degree,
                GraduationYear: req.GraduationYear
            );
            return result;
        }
    }
}