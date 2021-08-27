using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query;
using Reservation.Application.Query.TripUserQuery;
using Reservation.Application.Repository.TripUser;
using Reservation.Application.Repository.TripUser.Dtos.Responses;

namespace Reservation.Application.Handler.TripUserHandler
{
    public class SearchUsersHandler : IRequestHandler<SearchUserQuery,OutputResponse<List<GetUsersName>>>
    {
        private readonly ITripUser _tripUser;

        public SearchUsersHandler(ITripUser tripUser)
        {
            _tripUser = tripUser;
        }

        public Task<OutputResponse<List<GetUsersName>>> Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {
            var result = _tripUser.SearchUsers(request.Name);
            return result;
        }
    }
}
