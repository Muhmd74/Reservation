using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Core.Helpers.Category;

namespace Reservation.Core.Helpers.City
{
    public class CreateCity
    {
        public static IEnumerable<CityRequest> City()
        {
            return new List<CityRequest>()
            {
                new CityRequest()
                {

                    Id = new Guid("7d0f809a-3fb4-4c19-8923-0025ab0e6517"),
                    Name = "Hurghada",
                    Description= "the beach just in one trip to Egypt.",
                    CountryId = new Guid("13572456-6511-47af-9774-d1055004ce52")
                },
               
            };
        }
    }
}
