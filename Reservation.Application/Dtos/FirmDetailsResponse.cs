using System;
using System.Collections.Generic;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Dtos
{
    public class FirmDetailsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public decimal Rate { get; set; } = 0;
        public int RateCount { get; set; }

        public List<TripResponses> Trips { get; set; }
    }
}
