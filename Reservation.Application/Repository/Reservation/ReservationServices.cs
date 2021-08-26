using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
 using Reservation.Application.Repository.Reservation.Dtos.Responses;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Repository.Reservation
{
    public class ReservationServices : IReservation
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapperManager;

        public ReservationServices(ApplicationDbContext context, IMapper mapperManager)
        {
            _context = context;
            _mapperManager = mapperManager;
        }

        public async Task< List<ReservationResponses>> GetAllReservation()
        {
            try
            {
                var model = await _context.Trips.ToListAsync();

                var result= _mapperManager.Map<List<ReservationResponses>>(model);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
             

        }

        public async Task<ReservationResponses> GetByReservationId(Guid id)
        {
            var model = await _context.Trips.FirstOrDefaultAsync(d => d.Id == id);

            var result = _mapperManager.Map<ReservationResponses>(model);
            return result;
        }
    }
}
