using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservation.Core.Entities
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; } 
        public string Description { get; set; }
         public bool IsDeleted { get; set; } = false;
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
