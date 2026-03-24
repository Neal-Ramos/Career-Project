
using Application.commons.DTOs;
using Application.features.JobApplications.DTOs;

namespace Application.features.Jobs.DTOs
{
    public class JobsDto
    {
        public int Id {get; set;}
        public Guid JobId {set; get;}
        public string? Title {set; get;}
        public string? Description {set; get;}
        public string? Roles {set; get;}
        public string? FileRequirements {set; get;}
        public DateTime DateCreated {set; get;}
        public ICollection<JobApplicationDto>? JobApplications {get; set;}
    }
}