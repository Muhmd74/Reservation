using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Entities
{
   public class TripUser
    {
        public Guid Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Trip Trip { get; set; }
        public Guid TripId { get; set; }

    }
}
