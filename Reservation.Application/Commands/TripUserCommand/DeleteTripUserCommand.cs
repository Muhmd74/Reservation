using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.TripUserCommand
{
    public class DeleteTripUserCommand : IRequest<OutputResponse<bool>>
    {
        public Guid UserId { get; set; }
        public Guid TripId { get; set; }

    }
}
