using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.features.JobApplications.DTOs;

namespace Application.commons.IServices
{
    public interface IStorageServices
    {
        Task<string> UploadAsync(
            FileUploadDTO file
        );
    }
}