using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Reservation.Application.Commands.AccountCommand;
using Reservation.Application.Common.Response;
using Reservation.Core.Entities;

namespace Reservation.Application.Handler.AccountHandler
{
    public class AccountLoginHandler : IRequestHandler<AccountLoginCommand,OutputResponse<bool>>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountLoginHandler( SignInManager<ApplicationUser> signInManager)
        {
             _signInManager = signInManager;
        }

        public async Task<OutputResponse<bool>> Handle(AccountLoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email,
                request.Password, request.RememberMe, false);
            if (result.Succeeded)
            {
                return new OutputResponse<bool>()
                {
                    Model = true,
                    Success = true,
                    Message = ResponseMessages.Success
                };
            }
            return new OutputResponse<bool>()
            {
                Model = false,
                Success = false,
                Message = ResponseMessages.Failure
            };

        }
    }
}
