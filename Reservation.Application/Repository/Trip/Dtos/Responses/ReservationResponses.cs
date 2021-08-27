using System;

namespace Reservation.Application.Repository.Trip.Dtos.Responses
{
  public  class TripResponses
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
    }
}
