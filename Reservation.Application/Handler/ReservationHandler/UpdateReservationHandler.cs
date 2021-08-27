using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.ReservationCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Handler.ReservationHandler
{
    public class UpdateReservationHandler :IRequestHandler<UpdateReservationCommand,OutputResponse<ReservationResponses>>
    {
        private readonly IReservation _reservation;

        public UpdateReservationHandler(IReservation reservation)
        {
            _reservation = reservation;
        }

        public async Task<OutputResponse<ReservationResponses>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var result = await _reservation.UpdateReservation(request);
            return result;
        }
    }
}
