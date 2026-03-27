using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.commons.DTOs;
using Application.commons.IRepository;
using Application.commons.IServices;
using Application.exeptions;
using MediatR;

namespace Application.features.Authentication.Commands.VerifyOtp
{
    public class VerifyOtpHandler: IRequestHandler<VerifyOtpCommand, VerifyOtpDto>
    {
        private readonly IAuthCodeRepository _authCode;
        private readonly ITokenService _tokenService;
        public VerifyOtpHandler(
            IAuthCodeRepository authCodeRepository,
            ITokenService tokenService
        )
        {
            _authCode = authCodeRepository;
            _tokenService = tokenService;
        }

        public async Task<VerifyOtpDto> Handle(
            VerifyOtpCommand req,
            CancellationToken cancellationToken
        )
        {
            // var getCode = await _authCode.GetCodeByCodeAndEmail(
            //     Email: req.Email,
            //     Code: req.Code
            // )?? throw new InvalidCodeExeption();

            var token = _tokenService.GenerateJwtToken(
                AdminId: Guid.NewGuid(),
                Email: "nealramos72@gmail.com",
                Role: "Admin"
            );

            return new VerifyOtpDto
            {
                Token = token
            };
        }
    }
}