using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Application.Repository.City.Dtos.Responses
{
    public class AllCityResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
         public Guid CountryId { get; set; }
         public string CountryName { get; set; }
    }
}
