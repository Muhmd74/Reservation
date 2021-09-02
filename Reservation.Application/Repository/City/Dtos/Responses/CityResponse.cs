using System;

namespace Reservation.Application.Repository.City.Dtos.Responses
{
    public class CityResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CountryId { get; set; }
    }
}
