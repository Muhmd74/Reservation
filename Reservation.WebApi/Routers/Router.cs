using System;
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
            public const string GetAllReservation = Prefix + "get-all";
            public const string GetReservationById = Prefix + "get-by-id";
            public const string CreateNewReservation = Prefix + "create";
            public const string UpdateReservation = Prefix + "update";

        }
        public static class TripUser
        {
            private const string Prefix = Root + "trip-user/";
            public const string Create = Prefix + "create";
            public const string SearchUsers = Prefix + "search-user-name";




        }

        public static class User
        {
            private const string Prefix = Root + "user/";
            public const string GetAllUser = Prefix + "get-all";
            public const string ChangeActivity = Prefix + "change-activity";




        }
    }
}
