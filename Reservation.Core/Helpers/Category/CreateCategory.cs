using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Core.Helpers.TripUser;

namespace Reservation.Core.Helpers.Category
{
    public class CreateCategory
    {
        public static IEnumerable<CategoryRequest> Category()
        {
            return new List<CategoryRequest>()
            {
                new CategoryRequest()
                {

                    Id = new Guid("3cd161b7-3e7a-6914-a8fa-3eba2a8a3f91"),
                    Name = "Cruise",
                    Description= "Book your holiday at one of famous Red Sea resorts like Hurghada, el-Gouna, Makadi bay or even Marsa Alam and combine beach leisure trip with five days Nile "
                }
            };
        }
    }
}
