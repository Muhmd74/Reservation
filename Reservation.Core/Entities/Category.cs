using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Trip> Trips { get; set; }

    }
}
