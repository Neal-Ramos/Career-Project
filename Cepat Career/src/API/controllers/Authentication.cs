using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.common.Responses;
using Application.features.Authentication.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Authentication : ControllerBase
    {
        private readonly IMediator _mediator;
        public Authentication(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginCommand req,
            CancellationToken cancellationToken
        )
        {
            var query = new LoginCommand
            {
                UserName = req.UserName,
                Password = req.Password
            };
            var result = await _mediator.Send(query);

            return Ok(new APIResponse<object>
            {
                Message = "Success",
                Status = 200,
                Data = result
            });
        }
    }
}