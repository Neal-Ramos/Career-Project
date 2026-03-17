using Domain.enums;

namespace Domain.Entities
{
    public class JobApplications
    {
        public int Id {get; private set;}
        public Guid ApplicationId {get; private set;}
        public string? FirstName {get; set;}
        public string? MiddleName {get; set;}
        public string? LastName {get; set;}
        public string? Email {get; set;}
        public string? ContactNumber {get; set;}
        public string? UniversityName {get; set;}
        public string? Degree {get; set;}
        public int? GraduationYear {get; set;}
        public string? FileSubmitted {get; set;}
        public ApplicationStatusEnum Status {get; set;} = ApplicationStatusEnum.Pending;
        public DateTime DateSubmitted {get; set;} = DateTime.UtcNow;
        public DateTime? DateReviewed {get; set;} = null;

        //relation
        public Guid JobId {get; set;}
        public Jobs? Job {get; set;}
    }
}