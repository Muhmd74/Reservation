using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query;
using Reservation.Application.Query.TripQuery;
using Reservation.Application.Repository.Trip;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Handler.TripHandler
{
    public class GetAllTripHandlers : IRequestHandler<GetAllTripQuery, OutputResponse<List<TripResponses>>>
    {
        private readonly ITrip _trip;
        public GetAllTripHandlers(ITrip trip)
        {
            _trip = trip;

        }

        public async Task<OutputResponse<List<TripResponses>>> Handle(GetAllTripQuery request, CancellationToken cancellationToken)
        {
            var result = await _trip.GetAllTrip(request.PageSize,request.PageNumber);
            return result;
        }
    }
}
