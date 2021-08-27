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

        public static class Trip
        {
            private const string Prefix = Root + "trip/";
            public const string GetAllTrip = Prefix + "get-all";
            public const string GetAllTripDeleted = Prefix + "get-all-deleted";

            public const string GetTripById = Prefix + "get-by-id";
            public const string CreateNewTrip = Prefix + "create";
            public const string UpdateTrip = Prefix + "update";
            public const string DeleteOrRestoreTrip = Prefix + "delete-or-restore";


        }
        public static class TripUser
        {
            private const string Prefix = Root + "trip-user/";
            public const string Create = Prefix + "create";
            public const string Delete = Prefix + "delete";

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
