using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Application.Repository.Reservation.Dtos.Responses
{
   public class ReservationDetailsResponses
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
        public List<UsersInReservation> UsersInReservations { get; set; }
    }

   public class UsersInReservation
   {
       public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
       public string Phone { get; set; }
    }
}
