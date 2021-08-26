using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterUsers.Core.Models
{
   public class Trip
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; }
        public Guid? UserId { get; set; }

    }
}
