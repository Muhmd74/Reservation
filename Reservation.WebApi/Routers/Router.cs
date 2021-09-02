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

        public static class Country
        {
            private const string Prefix = Root + "country/";
            public const string GetAllCountry = Prefix + "get-all";
            public const string GetAllCountryDeleted = Prefix + "get-all-deleted";

            public const string GetCountryById = Prefix + "get-by-id";
            public const string CreateNewCountry = Prefix + "create";
            public const string UpdateCountry = Prefix + "update";
            public const string DeleteOrRestoreCountry = Prefix + "delete-or-restore";


        }
        public static class City
        {
            private const string Prefix = Root + "city/";
            public const string GetAllCity = Prefix + "get-all";
            public const string GetAllCityDeleted = Prefix + "get-all-deleted";
            public const string GetAllCountry = Prefix + "get-all-country";

            public const string GetCityById = Prefix + "get-by-id";
            public const string CreateNewCity = Prefix + "create";
            public const string UpdateCity = Prefix + "update";
            public const string DeleteOrRestoreCity = Prefix + "delete-or-restore";


        }
        public static class Category
        {
            private const string Prefix = Root + "category/";
            public const string GetAllCategory = Prefix + "get-all";
 
             public const string CreateNewCategory = Prefix + "create";
 


        }
        public static class TripUserReservation
        {
            private const string Prefix = Root + "trip-user/";
            public const string Create = Prefix + "create";
            public const string Delete = Prefix + "delete";

            public const string SearchUsers = Prefix + "search-user-name";




        }

        public static class User
        {
            private const string Prefix = Root + "user/";
            public const string CreateUser = Prefix + "create";
            public const string GetAllUser = Prefix + "get-all";
            public const string ChangeActivity = Prefix + "change-activity";




        }
    }
}
