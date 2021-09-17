using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Reservation.Application.Commands.AdministrationCommand;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Handler.AdministrationHandler
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, OutputResponse<bool>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteRoleHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<OutputResponse<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
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
                Message = ResponseMessages.Success,
                Success = false
            };
        }
    }
}
