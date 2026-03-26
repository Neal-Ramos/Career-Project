using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.commons.DTOs;

namespace Application.commons.IServices
{
    public interface ITokenService
    {
        string GenerateAccessToken(AdminAccountsDto adminAccounts);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}