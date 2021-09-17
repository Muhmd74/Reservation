using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Reservation.Application.Commands.AdministrationCommand;
using Reservation.Application.Common.Response;
using Reservation.Core.Entities;

namespace Reservation.Application.Handler.AdministrationHandler
{
    public class EditUserHandler : IRequestHandler<EditUserCommand, OutputResponseForValidationFilter>
    {
         private readonly UserManager<ApplicationUser> _userManager;


        public EditUserHandler( UserManager<ApplicationUser> userManager)
        {
             _userManager = userManager;
        }

        public async Task<OutputResponseForValidationFilter> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user != null)
            {
                user.Email = request.Email;
                user.UserName = request.UserName;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.PhoneNumber = request.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
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
