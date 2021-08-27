using System;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.TripUser.Dtos.Responses;

namespace Reservation.Application.Commands.TripUserCommand
{
    public class CreateTripUserCommand : IRequest<OutputResponse<CreateTripUserResponse>>
    {
        public Guid UserId { get; set; }
        public Guid TripId { get; set; }
    }
}
