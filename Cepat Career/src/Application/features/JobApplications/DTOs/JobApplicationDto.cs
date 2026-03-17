
using Domain.enums;

namespace Application.features.JobApplications.DTOs
{
    public class JobApplicationDto
    {
        public int Id {get; set;}
        public Guid ApplicationId {get; set;}
        public string? FirstName {get; set;}
        public string? MiddleName {get; set;}
        public string? LastName {get; set;}
        public string? Email {get; set;}
        public string? ContactNumber {get; set;}
        public string? UniversityName {get; set;}
        public string? Degree {get; set;}
        public int? GraduationYear {get; set;}
        public string? FileSubmitted {get; set;}
        public ApplicationStatusEnum Status {get; set;}
        public DateTime DateSubmitted {get; set;} = DateTime.UtcNow;
        public DateTime? DateReviewed {get; set;} = null;
        public Guid JobId {get; set;}
    }
} 