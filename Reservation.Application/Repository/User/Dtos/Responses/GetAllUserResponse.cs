using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Core.Enums;

namespace Reservation.Application.Repository.User.Dtos.Responses
{
    public class GetAllUserResponse
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
