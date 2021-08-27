using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.TripUserCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.TripUser;

namespace Reservation.Application.Handler.TripUserHandler
{
    public class DeleteTripUserHandler : IRequestHandler<DeleteTripUserCommand,OutputResponse<bool>>
    {
        private readonly ITripUser _tripUser;

        public DeleteTripUserHandler(ITripUser tripUser)
        {
            _tripUser = tripUser;
        }

        public Task<OutputResponse<bool>> Handle(DeleteTripUserCommand request, CancellationToken cancellationToken)
        {
            var result = _tripUser.Delete(request.UserId, request.TripId);
            return result;
        }
    }
}
