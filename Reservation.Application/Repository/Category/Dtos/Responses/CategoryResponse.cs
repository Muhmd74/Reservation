using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Application.Repository.Category.Dtos.Responses
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
