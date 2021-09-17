using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ManageUserRolesHandler : IRequestHandler<ManageUserRolesCommand, OutputResponseForValidationFilter>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageUserRolesHandler(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<OutputResponseForValidationFilter> Handle(ManageUserRolesCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, roles);

                if (result != null)
                {
                    result = await _userManager.AddToRolesAsync(user,
                        request.ListManageUserRolesCommand().Where(x => x.IsSelected).Select(y => y.RoleName));

                    return new OutputResponseForValidationFilter()
                    {
                        Model = result,
                        Message = ResponseMessages.Success,
                        Success = true,
                    };
                }
                return new OutputResponseForValidationFilter()
                {
                    Model = null,
                    Message = ResponseMessages.NotFound,
                    Success = false,
                };
            }
            return new OutputResponseForValidationFilter()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false,
            };

        }
    }
}
