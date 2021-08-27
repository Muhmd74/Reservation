using System.Collections.Generic;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.TripUser.Dtos.Responses;

namespace Reservation.Application.Query.TripUserQuery
{
    public class SearchUserQuery : IRequest<OutputResponse<List<GetUsersName>>>
    {
        public SearchUserQuery(string name)
        {
            Name = name;
        }

        public string Name { get;  }
    }
}
