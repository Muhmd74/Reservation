using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Common.Response;
using Reservation.Application.Dtos;
using Reservation.Application.Query.AdministrationQuery;
using Reservation.Application.Repository.Category.Dtos.Responses;

namespace Reservation.Application.Handler.AdministrationHandler
{
    public class ListRoleAdministrationHandler : IRequestHandler<ListRolesQuery,OutputResponse<List<ListRoleAdministrationResponse>>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ListRoleAdministrationHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<OutputResponse<List<ListRoleAdministrationResponse>>> Handle(ListRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.Select(d=>new ListRoleAdministrationResponse()
            {
                Id = d.Id,
                RoleName = d.Name
            }).ToListAsync(cancellationToken: cancellationToken);
            if (roles!=null)
            {
                return new OutputResponse<List<ListRoleAdministrationResponse>>()
                {
                    Model = roles,
                    Success = true,
                    Message = ResponseMessages.Success
                };
            }
            return new OutputResponse<List<ListRoleAdministrationResponse>>()
            {
                Model = null,
                Success = false,
                Message = ResponseMessages.NotFound
            };
        }
    }
}
