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
using Reservation.Core.Entities;

namespace Reservation.Application.Handler.AdministrationHandler
{
    public class ListUsersHandler : IRequestHandler<ListUsersQuery, OutputResponse<List<ListUserAdministrationResponse>>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ListUsersHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<OutputResponse<List<ListUserAdministrationResponse>>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _userManager.Users
                .Select(d => new ListUserAdministrationResponse
                {
                    UserId = d.Id,
                    UserName = d.UserName,
                    FullName = $"{d.FirstName} {d.LastName}"
                })
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
            return new OutputResponse<List<ListUserAdministrationResponse>>()
            {
                Model = await result,
                Message = ResponseMessages.Success,
                Success = true
            };
        }
    }
}
