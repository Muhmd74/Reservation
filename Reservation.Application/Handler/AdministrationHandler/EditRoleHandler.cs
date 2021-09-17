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
    public class EditRoleHandler : IRequestHandler<EditRoleCommand, OutputResponseForValidationFilter>
    {
        private readonly RoleManager<IdentityRole> _roleManager;


        public EditRoleHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<OutputResponseForValidationFilter> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            if (role != null)
            {
                role.Name = request.RoleName;

                var result = await _roleManager.UpdateAsync(role);
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
                Message = ResponseMessages.NotFound,
                Success = false
            };
        }
    }
}
