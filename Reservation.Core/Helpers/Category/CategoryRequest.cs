using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Helpers.Category
{
    public class CategoryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}
