using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Entities
{
   public class TripUser
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Trip Trip { get; set; }
        public Guid TripId { get; set; }

    }
}
