using System;
using System.Collections.Generic;

namespace Reservation.Core.Entities
{
    public class Firm
    {
 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
         public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ApplicationUser> User { get; set; }
        public ICollection<Trip> Trips { get; set; }
        public ICollection<FirmReview> FirmReviews { get; set; }



    }
}
