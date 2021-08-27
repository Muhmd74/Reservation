﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.WebApi.Routers
{
    public static class Router
    {
        private const string Base = "api/";
        private const string Version = "v1/";
        private const string Root = Base + Version;

        public static class Reservation
        {
            private const string Prefix = Root + "reservation/";
            public const string GetAllReservation = Prefix + "gets-reservations";
            public const string GetReservationById = Prefix + "get-reservation-by-id";
            public const string CreateNewReservation = Prefix + "create-reservation";


        }
        public static class TripUser
        {
            private const string Prefix = Root + "trip-user/";
            public const string Create = Prefix + "create";
            public const string GetReservationById = Prefix + "get-reservation-by-id";
            public const string CreateNewReservation = Prefix + "create-reservation";


        }
    }
}
