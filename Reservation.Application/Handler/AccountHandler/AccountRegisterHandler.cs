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
    public class AccountRegisterHandler : IRequestHandler<AccountRegisterCommand,OutputResponseForValidationFilter>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRegisterHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<OutputResponseForValidationFilter> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser()
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return new OutputResponseForValidationFilter()
                {
                    Model = request,
                    Message = ResponseMessages.Success,
                    Success = true
                };

            }

            return new OutputResponseForValidationFilter()
            {
                Model = null,
                Message = ResponseMessages.Failure,
                Success = false
            };
        }
    }
}
