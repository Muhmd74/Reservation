using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Handler
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, OutputResponse<ReservationResponses>>
    {
        private readonly IReservation _reservation;

        public CreateReservationHandler(IReservation reservation)
        {
            _reservation = reservation;
        }

        public async Task<OutputResponse<ReservationResponses>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var result =await _reservation.CreateReservation(request);
            return result;
        }
    }
}
