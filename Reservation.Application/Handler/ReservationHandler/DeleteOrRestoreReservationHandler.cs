using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.ReservationCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation;

namespace Reservation.Application.Handler.ReservationHandler
{
    public class DeleteOrRestoreReservationHandler : IRequestHandler<DeleteOrRestoreReservationCommand,OutputResponse<bool>>
    {
        private readonly IReservation _reservation;

        public DeleteOrRestoreReservationHandler(IReservation reservation)
        {
            _reservation = reservation;
        }

        public Task<OutputResponse<bool>> Handle(DeleteOrRestoreReservationCommand request, CancellationToken cancellationToken)
        {
            var result = _reservation.DeleteOrRestore(request.TripId);
            return result;
        }
    }
}
