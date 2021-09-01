using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Entities
{
    public class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Trip> Trips { get; set; }


    }
}
