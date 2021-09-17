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
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, OutputResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteUserHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<OutputResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return new OutputResponse<bool>()
                {
                    Model = true,
                    Message = ResponseMessages.Success,
                    Success = true
                };

            }
            return new OutputResponse<bool>()
            {
                Model = false,
                Message = ResponseMessages.NotFound,
                Success = false
            };

        }
    }
}
