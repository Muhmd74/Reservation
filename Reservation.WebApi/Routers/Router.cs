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

        public static class Account
        {
            private const string Prefix = Root + "account/";
            public const string Register = Prefix + "register";
            public const string GetToken = Prefix + "get-token";

            public const string Login = Prefix + "login";

        }

        public static class Administration
        {
            private const string Prefix = Root + "administration/";
            public const string CreateRole = Prefix + "create-role";
            public const string ListRoles = Prefix + "list-role";
            public const string EditRole = Prefix + "edit-role";
            public const string DeleteRole = Prefix + "delete-role";
            public const string EditUser = Prefix + "edit-user";
            public const string DeleteUser = Prefix + "delete-user";
            public const string ListUsers = Prefix + "list-user";

            public const string ManageUserRoles = Prefix + "manage-user-roles";
            //public const string EditUsersInRole = Prefix + "edit-user-in-role";

        }

        public static class Firm
        {
            private const string Prefix = Root + "firm/";
            public const string ListFirm = Prefix + "list";
            public const string DetailsFirm = Prefix + "details";

            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string ChangeActivity = Prefix + "change-activity";
            public const string DeleteOrRestore = Prefix + "delete-or-restore";


        }
    }
}
