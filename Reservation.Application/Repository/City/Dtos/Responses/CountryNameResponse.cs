using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Application.Repository.City.Dtos.Responses
{
    public class CountryNameResponse
    {
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
