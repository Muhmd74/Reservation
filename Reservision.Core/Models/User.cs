using System;
using System.Collections.Generic;
using System.Text;
using RegisterUsers.Core.Enum;

namespace RegisterUsers.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Trip> Trips { get; set; }



    }
}
