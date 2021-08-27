using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.TripCommand
{
    public class DeleteOrRestoreTripCommand : IRequest<OutputResponse<bool>>
    {

        public Guid TripId { get; set; }

    }
}
