using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.features.JobApplications.DTOs
{
    public class FileUploadDTO
    {
        public string? FileName { get; set; }
        public string? Name {get; set;}
        public string? ContentType { get; set; }
        public Stream? Content { get; set; }

    }
}