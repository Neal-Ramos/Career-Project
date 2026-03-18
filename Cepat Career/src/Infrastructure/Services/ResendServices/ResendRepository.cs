using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.commons.DTOs;
using Application.commons.IServices;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.ResendServices
{
    public class ResendRepository: ISentEmail
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ResendRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Resend:ApiKey"];

            _httpClient.BaseAddress = new Uri("https://api.resend.com");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);
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