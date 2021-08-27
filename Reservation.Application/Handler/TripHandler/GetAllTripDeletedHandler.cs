using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query.TripQuery;
using Reservation.Application.Repository.Trip;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Handler.TripHandler
{
    public class GetAllTripDeletedHandler : IRequestHandler<GetAllTripDeletedQuery, OutputResponse<List<TripResponses>>>
    {
        private readonly ITrip _trip;
        public GetAllTripDeletedHandler(ITrip trip)
        {
            _trip = trip;

        }

        public async Task<OutputResponse<List<TripResponses>>> Handle(GetAllTripDeletedQuery request, CancellationToken cancellationToken)
        {
            var result = await _trip.GetAllTripDeleted(request.PageSize);
            return result;
        }

    }
}
