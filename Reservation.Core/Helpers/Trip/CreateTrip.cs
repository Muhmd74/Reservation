﻿using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Core.Helpers.User;

namespace Reservation.Core.Helpers.Trip
{
    public class CreateTrip
    {
        public static IEnumerable<TripRequest> Trip()
        {
            return new List<TripRequest>()
            {
                new TripRequest()
                {
                    CityName = "Cairo",
                    Content =
                        "Start and end in Cairo! With the In-depth Cultural tour King Ramses with Cruise - 13 days, you have a 13 days tour package taking you through Cairo, Egypt and 8 other destinations in Egypt. King Ramses with Cruise - 13 days includes accommodation in a hotel as well as an expert guide, meals, transport and more",
                    ImageUrl = "",
                    Price = 456,
                    Title = "King Ramses with Cruise - 13 days",
                    Id = new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72")

                },
            };
        }
    }
}