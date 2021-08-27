using System;

namespace Reservation.Application.Repository.TripUser.Dtos.Responses
{
    public class CreateTripUserResponse
    {
        public Guid UserId { get; set; }
        public Guid TripId { get; set; }
    }
}
