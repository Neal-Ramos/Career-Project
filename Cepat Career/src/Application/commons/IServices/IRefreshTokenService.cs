using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.commons.IServices
{
    public interface IRefreshTokenService
    {
        Task<(string NewAccessToken, string NewRefreshToken)> RotateToken(Guid AdminId);
    }
}