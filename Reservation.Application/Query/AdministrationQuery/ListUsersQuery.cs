using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Dtos;

namespace Reservation.Application.Query.AdministrationQuery
{
    public class ListUsersQuery : IRequest<OutputResponse<List<ListUserAdministrationResponse>>>
    {
        public ListUsersQuery(int pageSize)
        {
            PageSize = pageSize;
        }

        public int PageSize { get; }
    }
}
