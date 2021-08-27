using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Common.Files;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Handler.TripHandler
{
    public class CreateTripHandler : IRequestHandler<CreateTripCommand, OutputResponse<TripResponses>>
    {
        private readonly ITrip _trip;
         public CreateTripHandler(ITrip trip )
        {
            _trip = trip;
          
        }

        public async Task<OutputResponse<TripResponses>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var result =await _trip.CreateTrip(request);
            return result;
        }
    }
}
