using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.commons.DTOs;
using Application.commons.IServices;
using Microsoft.Extensions.Configuration;
using Resend;

namespace Infrastructure.Services.ResendServices
{
    public class ResendRepository: ISendEmail
    {
        private readonly IResend _resend;
        public ResendRepository(IResend resend)
        {
            _resend = resend;
        }

        public async Task<SentEmailDto> SendEmailAsync(
            string To,
            string Subject,
            string HtmlContent
        )
        {

            return new SentEmailDto
            {
                
            };
        }
    }
}