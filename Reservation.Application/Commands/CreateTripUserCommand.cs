using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.TripUser.Dtos.Responses;

namespace Reservation.Application.Commands
{
    public class CreateTripUserCommand : IRequest<OutputResponse<CreateTripUserResponse>>
    {
        public Guid UserId { get; set; }
        public Guid TripId { get; set; }
    }
}
