using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.ReservationCommand
{
    public class DeleteOrRestoreReservationCommand : IRequest<OutputResponse<bool>>
    {

        public Guid TripId { get; set; }

    }
}
