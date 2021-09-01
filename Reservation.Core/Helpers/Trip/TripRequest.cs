using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Helpers.Trip
{
    public class TripRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CityId { get; set; }
        public Guid Id { get; set; }
    }
}
