using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.WebUI.ViewModel
{
    public class CardHomeViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
         public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
    }
}
