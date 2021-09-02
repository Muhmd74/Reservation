using System;

namespace Reservation.Application.Repository.Country.Dtos.Responses
{
    public class CountryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iso { get; set; }
    }
}
