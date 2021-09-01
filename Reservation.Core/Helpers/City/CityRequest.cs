using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Reservation.Core.Helpers.City
{
    public class CityRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
    }
}
