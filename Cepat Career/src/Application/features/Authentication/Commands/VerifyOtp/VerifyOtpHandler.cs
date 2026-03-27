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
        private readonly IHashingService _hashingService;
        public VerifyOtpHandler(
            IAuthCodeRepository authCodeRepository,
            IHashingService hashingService
        )
        {
            _authCode = authCodeRepository;
            _hashingService = hashingService;
        }

        public async Task<VerifyOtpDto> Handle(
            VerifyOtpCommand req,
            CancellationToken cancellationToken
        )
        {
            var getCode = await _authCode.GetCodeByCodeAndEmail(
                Email: req.Email,
                Code: req.Code
            )?? throw new InvalidCodeExeption();

            

            return new VerifyOtpDto{};
        }
    }
}