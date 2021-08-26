using System;
using Reservation.Core.Enums;

namespace Reservation.Core.Helpers.User
{
    public class UserRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
