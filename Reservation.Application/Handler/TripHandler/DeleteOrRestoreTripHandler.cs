using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip;

namespace Reservation.Application.Handler.TripHandler
{
    public class DeleteOrRestoreTripHandler : IRequestHandler<DeleteOrRestoreTripCommand,OutputResponse<bool>>
    {
        private readonly ITrip _trip;

        public DeleteOrRestoreTripHandler(ITrip trip)
        {
            _trip = trip;
        }

        public Task<OutputResponse<bool>> Handle(DeleteOrRestoreTripCommand request, CancellationToken cancellationToken)
        {
            var result = _trip.DeleteOrRestore(request.TripId);
            return result;
        }
    }
}
