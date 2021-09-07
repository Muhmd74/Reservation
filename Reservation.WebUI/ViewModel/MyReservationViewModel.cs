using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.WebUI.ViewModel
{
    public class MyReservationViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "City")]
        public string CityName { get; set; }
      
        public string UserName { get; set; }
    }
}
