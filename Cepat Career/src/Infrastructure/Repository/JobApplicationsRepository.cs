using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.commons.IRepository;
using Application.features.JobApplications.DTOs;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public class JobApplicationsRepository: IApplicationsRepository
    {
        private readonly AppDbContext context;
        public JobApplicationsRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        
        public async Task<JobApplicationDto> AddApplication(
            string FirstName,
            string MiddleName,
            string LastName,
            string Email,
            string ContactNumber,
            string UniversityName,
            string Degree,
            int GraduationYear,
            string FileSubmitted,
            Guid JobId
        )
        {
            var newApplication = new JobApplications
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Email = Email,
                ContactNumber = ContactNumber,
                UniversityName = UniversityName,
                Degree = Degree,
                GraduationYear = GraduationYear,
                FileSubmitted = FileSubmitted,
                JobId = JobId
            };
            await context.JobApplications.AddAsync(newApplication);
            context.SaveChanges();

            return new JobApplicationDto
            {
                Id = newApplication.Id,
                ApplicationId = newApplication.ApplicationId,
                FirstName = newApplication.FirstName,
                MiddleName = newApplication.MiddleName,
                LastName = newApplication.LastName,
                Email = newApplication.Email,
                ContactNumber = newApplication.ContactNumber,
                UniversityName = newApplication.UniversityName,
                Degree = newApplication.Degree,
                GraduationYear = newApplication.GraduationYear,
                FileSubmitted = FileSubmitted,
                Status = newApplication.Status,
                DateSubmitted = newApplication.DateSubmitted,
                DateReviewed = newApplication.DateReviewed,
                JobId = newApplication.JobId
            };
        }
    }
}