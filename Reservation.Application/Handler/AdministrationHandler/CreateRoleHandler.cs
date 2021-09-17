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
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, OutputResponseForValidationFilter>
    {
         private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRoleHandler( RoleManager<IdentityRole> roleManager)
        {
             _roleManager = roleManager;
        }

        public async Task<OutputResponseForValidationFilter> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = request.RoleName,
            };
            IdentityResult result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return new OutputResponseForValidationFilter()
                {
                    Model = result,
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponseForValidationFilter()
            {
                Model = null,
                Message = ResponseMessages.Success,
                Success = false
            };
        }
    }
}
