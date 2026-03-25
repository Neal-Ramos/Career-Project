using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Application.commons.DTOs;
using Application.commons.IServices;

namespace Infrastructure.Services.CodeGenerator
{
    public class CodeGeneratorRepository: IGenerateCode
    {
        public Task<GenerateCodeDto> Generate()
        {
            var bytes = RandomNumberGenerator.GetBytes(6);
            var code = string.Concat(bytes.Select(b => (b % 10).ToString()));
            long expiryMillis = DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeMilliseconds();
            var result = new GenerateCodeDto
            {
                Code = code,
                DateExpiry = expiryMillis
            };

            return Task.FromResult(result);
        }
    }
}