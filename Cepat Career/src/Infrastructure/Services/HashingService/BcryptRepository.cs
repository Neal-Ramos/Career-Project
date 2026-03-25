using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.commons.IServices;

namespace Infrastructure.Services.HashingService
{
    public class BcryptRepository: IHashingRepository
    {
        public Task<string> HashString(
            string str
        )
        {
            return Task.FromResult(BCrypt.Net.BCrypt.HashPassword(str));
        }
    }
}