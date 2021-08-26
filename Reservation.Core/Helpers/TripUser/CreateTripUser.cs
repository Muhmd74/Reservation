using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Helpers.TripUser
{
    public static class CreateTripUser
    {
        public static IEnumerable<TripUserRequest> TripUser()
        {
            return new List<TripUserRequest>()
            {
                new TripUserRequest()
                {
                    TripId = new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                    UserId = new Guid("e245d563-07b6-46c7-8a36-346e11144376")
                },
                new TripUserRequest()
                {
                    TripId = new Guid("4cd181b7-3e7a-4691-a8fa-3eba2a8a3f72"),
                    UserId = new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046")
                }
            };
        }
    }
}
