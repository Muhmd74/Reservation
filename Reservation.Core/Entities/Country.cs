using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iso { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<City> Cities { get; set; }

    }
}
