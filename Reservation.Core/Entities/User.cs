using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Reservation.Core.Enums;

namespace Reservation.Core.Entities
{
   public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<TripUser> TripUsers { get; set; }
    }
}
