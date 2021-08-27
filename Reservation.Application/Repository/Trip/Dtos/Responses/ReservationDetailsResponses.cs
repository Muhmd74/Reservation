using System;
using System.Collections.Generic;

namespace Reservation.Application.Repository.Trip.Dtos.Responses
{
   public class TripDetailsResponses
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
        public List<UsersInTrip> UsersInTrips { get; set; }
    }

   public class UsersInTrip{
       public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
       public string Phone { get; set; }
    }
}
