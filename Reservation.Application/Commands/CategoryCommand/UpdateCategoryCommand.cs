using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Application.Commands.CategoryCommand
{
    public class UpdateCategoryCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
     }
}
