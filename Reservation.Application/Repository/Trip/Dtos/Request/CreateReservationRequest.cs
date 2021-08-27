using System;

namespace Reservation.Application.Repository.Trip.Dtos.Request
{
  public class CreateTripRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
        public DateTime DateTime { get; set; }  
    }
}
