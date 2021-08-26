using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Helpers.TripUser
{
   public class TripUserRequest
    {
        public Guid UserId { get; set; }
        public Guid TripId { get; set; }
    }
}
