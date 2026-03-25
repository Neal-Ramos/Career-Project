using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.commons.DTOs;
using Application.commons.IRepository;
using Application.commons.IServices;
using AutoMapper;
using MediatR;

namespace Application.features.Authentication.Commands.Login
{
    public class LoginHandler: IRequestHandler<LoginCommand, LoginDto>
    {
        private readonly IAdminAccountsRepository _adminAccounts;
        private readonly IHashingRepository _hashingRepository;
        public LoginHandler(
            IAdminAccountsRepository adminAccountsRepository,
            IHashingRepository hashingRepository
        )
        {
            _adminAccounts = adminAccountsRepository;
            _hashingRepository = hashingRepository;
        }

        public async Task<LoginDto> Handle(
            LoginCommand req,
            CancellationToken cancellationToken
        )
        {
            var account = await _adminAccounts.GetByUsername(req.UserName)??
            throw new UnauthorizedAccessException("Invalid Credentials");

            var isVerified = await _hashingRepository.VerifyString(req.Password, account.Password);
            if(isVerified == false)throw new UnauthorizedAccessException("Invalid Credentials");
            
            return new LoginDto{};
        }
    }
}