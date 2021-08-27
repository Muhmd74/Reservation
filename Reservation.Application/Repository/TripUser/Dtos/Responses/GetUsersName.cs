using System;

namespace Reservation.Application.Repository.TripUser.Dtos.Responses
{
    public class GetUsersName
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
