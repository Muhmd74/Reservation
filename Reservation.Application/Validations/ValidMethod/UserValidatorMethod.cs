using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Validations.ValidMethod
{
    public static class   UserValidatorMethod
    {
        public static bool IsEmailExist(this string email)
        {
            var context = new ApplicationDbContext();
            return context.Users.Any(p => p.Email == email);
        }

        public static bool IsUniquePhone(this string phoneNumber)
        {
            var context = new ApplicationDbContext();
            return !context.Users.Select(p => p.Phone).Contains(phoneNumber);
        }
    }
}
