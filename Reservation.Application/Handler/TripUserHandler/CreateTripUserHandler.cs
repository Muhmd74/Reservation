using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands;
using Reservation.Application.Commands.TripUserCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.TripUser;
using Reservation.Application.Repository.TripUser.Dtos.Responses;

namespace Reservation.Application.Handler.TripUserHandler
{
    public class CreateTripUserHandler : IRequestHandler<CreateTripUserCommand, OutputResponse<CreateTripUserResponse>>
    {
        private readonly ITripUser _tripUser;

        public CreateTripUserHandler(ITripUser tripUser)
        {
            _tripUser = tripUser;
        }

        public async Task<OutputResponse<CreateTripUserResponse>> Handle(CreateTripUserCommand request, CancellationToken cancellationToken)
        {
            var model =await _tripUser.CreateTripUser(request );
            return model;
        }
    }
}
