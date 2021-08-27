using System.Collections.Generic;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.User.Dtos.Responses;

namespace Reservation.Application.Query.UserQuery
{
    public class GetAllUserQuery :  IRequest<OutputResponse<List<GetAllUserResponse>>>
    {
        public GetAllUserQuery(int pageSize)
        {
            PageSize = pageSize;
        }

        public int PageSize { get; }
    }
}
