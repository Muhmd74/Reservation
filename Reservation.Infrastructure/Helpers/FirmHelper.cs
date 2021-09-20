using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Infrastructure.Helpers
{
    public  class FirmHelper : IDisposable
    {
        private static ApplicationDbContext _context;

        public static decimal CalculationRate(Guid firmId)
        {
            _context = new ApplicationDbContext();
            var firm = _context.Firms
                .Include(d => d.FirmReviews)
                .FirstOrDefault(d => d.Id == firmId && d.IsActive && d.IsDeleted == false);
            if (firm == null) return 0;
            {
                try
                {
                    return firm.FirmReviews.Where(d => d.IsVerified).Sum(d => d.Rate) / firm.FirmReviews.Count(d => d.IsVerified);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        public static int RateCount(Guid firmId)
        {
            _context = new ApplicationDbContext();
            var firm = _context.Firms
                .Include(d => d.FirmReviews)
                .FirstOrDefault(d => d.Id == firmId && d.IsActive && d.IsDeleted == false);
            if (firm == null) return 0;
            {
                try
                {
                    return (int) firm.FirmReviews.Where(d => d.IsVerified).Sum(d => d.Rate);

                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
