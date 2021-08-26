using System;
using System.Collections.Generic;
using Reservation.Core.Enums;

namespace Reservation.Core.Helpers.User
{
    public static class CreateUser
    {
        public static IEnumerable<UserRequest> User()
        {
            return new List<UserRequest>()
            {
                new UserRequest()
                {
                    Address = "Cairo",
                    Email = "admin",
                    Name = "Admin",
                    Phone = "01093356547",
                    UserType = UserType.Admin,
                    Password = "admin",
                    Id = new Guid("e755d563-07b6-46c7-8a36-346e11144622")
                },
                new UserRequest()
                {
                    Address = "Cairo",
                    Email = "Ahmed43@Icloud.com",
                    Name = "Admin",
                    Phone = "01022453576",
                    UserType = UserType.Customer,
                    Password = "Ahmed43@Icloud.com",
                    Id = new Guid("e245d563-07b6-46c7-8a36-346e11144376")
                },
                new UserRequest()
                {
                    Address = "Aswan",
                    Email = "mohamed32@yahoo.com",
                    Name = "Mohamed Ali",
                    Phone = "01012489087",
                    UserType = UserType.Customer,
                    Password = "mohamed32@yahoo.com",
                    Id = new Guid("7d0f809a-7e7d-4d62-8923-85011cdc7046")
                },
                new UserRequest()
                {
                    Address = "Alexandria",
                    Email = "Mazen12@Yahoo.com",
                    Name = "Admin",
                    Phone = "01093355434",
                    UserType = UserType.Customer,
                    Password = "Mazen12@Yahoo.com",
                    Id = new Guid("1b26ba12-efd3-4cd0-bf45-2214dcba840b")
                },
                new UserRequest()
                {
                    Address = "Giza",
                    Email = "Ali55@Icloud.com",
                    Name = "Admin",
                    Phone = "01094242323",
                    UserType = UserType.Customer,
                    Password = "Ali55@Icloud.com",
                    Id = new Guid("e86a2575-8dd3-4ab6-97ce-749aa4da6629")
                },
            };
        }
    }
}
