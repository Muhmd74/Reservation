using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Helpers.Country
{
    public class CountryRequest 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iso { get; set; }
    }
}
