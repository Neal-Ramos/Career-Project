using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.features.Jobs.DTOs
{
    public class GetAllJobsDto
    {
        public List<JobsDto> Jobs {get; set;} = [];
        public int TotalPages {get; set;}
        public int TotalRecords {get; set;}
    }
}