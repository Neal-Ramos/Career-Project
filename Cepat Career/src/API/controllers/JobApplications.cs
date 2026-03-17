using API.common.Responses;
using Application.features.JobApplications.Commands.AddApplication;
using Application.features.JobApplications.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobApplications : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobApplications(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/AddApplication")]
        public async Task<IActionResult> AddApplication(
            [FromForm] string FirstName,
            [FromForm] string MiddleName,
            [FromForm] string LastName,
            [FromForm] string Email,
            [FromForm] string ContactNumber,
            [FromForm] string UniversityName,
            [FromForm] string Degree,
            [FromForm] string GraduationYear,
            CancellationToken cancellationToken
        )
        {
            var dtoFiles = Request.Form.Files.Select(file => new FileUploadDTO
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                Content = file.OpenReadStream()
            }).ToList();
            var result = new AddApplicationCommand
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Email = Email,
                ContactNumber = ContactNumber,
                UniversityName = UniversityName,
                Degree = Degree,
                GraduationYear = int.Parse(GraduationYear)
            };
            
            return Ok(new APIResponse<object>
            {
                Message = "Success",
                Status = 200,
                Data = result
            });
        }
    }
}