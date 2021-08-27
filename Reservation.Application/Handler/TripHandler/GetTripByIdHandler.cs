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
    public class GetTripByIdHandler : IRequestHandler<GetTripByIdQuery, OutputResponse<TripResponses>>
    {
        private readonly ITrip _trip;

        public GetTripByIdHandler(ITrip trip)
        {
            _trip = trip;
        }

        public Task<OutputResponse<TripResponses>> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
        {
            var model = _trip.GetByTripId(request.Id);
            return model;
        }
    }
}
