using System;

namespace Reservation.Core.Entities
{
    public class FirmReview
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public decimal Rate { get; set; }
        public bool IsVerified { get; set; }
        public DateTime ReviewDateTime { get; set; } = DateTime.Now;
        public Guid FirmId { get; set; }
        public Firm Firm { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
