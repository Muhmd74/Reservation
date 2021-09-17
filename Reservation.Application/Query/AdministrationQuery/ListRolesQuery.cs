using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Dtos;
using Reservation.Application.Repository.Category.Dtos.Responses;

namespace Reservation.Application.Query.AdministrationQuery
{
    public class ListRolesQuery : IRequest<OutputResponse<List<ListRoleAdministrationResponse>>>
    {

    }
}
