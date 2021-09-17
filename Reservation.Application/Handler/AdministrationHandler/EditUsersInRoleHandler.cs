//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Reservation.Application.Commands.AdministrationCommand;
//using Reservation.Application.Common.Response;
//using Reservation.Core.Entities;

//namespace Reservation.Application.Handler.AdministrationHandler
//{
//    public class EditUsersInRoleHandler : IRequestHandler<EditUsersInRoleCommand,OutputResponseForValidationFilter>
//    {
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly UserManager<ApplicationUser> _userManager;

//        public EditUsersInRoleHandler(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
//        {
//            _roleManager = roleManager;
//            _userManager = userManager;
//        }

//        public async Task<OutputResponseForValidationFilter> Handle(EditUsersInRoleCommand request, CancellationToken cancellationToken)
//        {
//            var role = await _roleManager.FindByIdAsync(request.Id);

//            for (int i = 0; i < request.Count; i++)
//            {

//                var user = await _userManager.FindByIdAsync(request[i].UserId);

//                IdentityResult result;

//                if (request[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
//                {
//                    result = await _userManager.AddToRoleAsync(user, role.Name);
//                }
//                else if (!request[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
//                {
//                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
//                }
//                else
//                {
//                    continue;
//                }

//                if (result.Succeeded)
//                {
//                    if (i < (request.Count - 1))
//                        continue;
 
//                    return new OutputResponseForValidationFilter()
//                    {
//                        Model = result,
//                        Message = ResponseMessages.Success,
//                        Success = true
//                    };
//                }
//            }
//            return new OutputResponseForValidationFilter()
//            {
//                Model = null,
//                Message = ResponseMessages.Success,
//                Success = false
//            };
//        }
//    }
//}
