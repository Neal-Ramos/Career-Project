using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Jobs
    {
        public int Id {get; set;}
        public Guid JobId {set; get;} = Guid.NewGuid();
        public string? Title {set; get;}
        public string? Description {set; get;}
        public string? Roles {set; get;}
        public string? FileRequirements {set; get;}
        public DateTime DateCreated {set; get;} = DateTime.UtcNow;
        public string? CreatedBy {get; set;}
        public string? EditedBy {get; set;}

        //
        public ICollection<JobApplications>? JobApplications {get; set;}
    }
}