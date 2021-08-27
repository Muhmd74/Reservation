using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Handler.TripHandler
{
    public class UpdateTripHandler :IRequestHandler<UpdateTripCommand,OutputResponse<TripResponses>>
    {
        private readonly ITrip _trip;

        public UpdateTripHandler(ITrip trip)
        {
            _trip = trip;
        }

        public async Task<OutputResponse<TripResponses>> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var result = await _trip.UpdateTrip(request);
            return result;
        }
    }
}
