using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Core.Helpers.Category;

namespace Reservation.Core.Helpers.Country
{
    public class CreateCountry
    {
        public static IEnumerable<CountryRequest> Country()
        {
            return new List<CountryRequest>()
            {
                new CountryRequest()
                {

                    Id = new Guid("13572456-6511-47af-9774-d1055004ce52"),
                    Name = "Egypt",
                    Description= "o Egypt to view its ancient monuments, natural attractions beckon travelers too. The Red Sea coast is known for its coral reefs and beach resorts.",
                    Iso = "EG"
                }
            };
        }
    }
}
