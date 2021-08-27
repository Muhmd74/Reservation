using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation.Dtos.Request;
using Reservation.Application.Repository.Reservation.Dtos.Responses;
using Reservation.Core.Entities;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Repository.Reservation
{
    public class ReservationServices : IReservation ,IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapperManager;

        public ReservationServices(ApplicationDbContext context, IMapper mapperManager)
        {
            _context = context;
            _mapperManager = mapperManager;
        }

        public async Task<CreateReservationRequest> CreateReservation(CreateReservationRequest model)
        {
            try
            {
                var trip = _mapperManager.Map<Trip>(model);
                var result = await _context.Trips.AddAsync(trip);
                await _context.SaveChangesAsync();
                return _mapperManager.Map<CreateReservationRequest>(result.Entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<OutputResponse<List<ReservationResponses>>> GetAllReservation()
        {

            var model = await _context.Trips
                .OrderByDescending(d => d.DateTime)
                .ToListAsync();

            return new OutputResponse<List<ReservationResponses>>()
            {
                Model = _mapperManager.Map<List<ReservationResponses>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };


        }

        public async Task<OutputResponse<ReservationResponses>> GetByReservationId(Guid id)
        {
            var model = await _context.Trips.FirstOrDefaultAsync(d => d.Id == id);
            if (model!=null)
            {
                return new OutputResponse<ReservationResponses>()
                {
                    Model = _mapperManager.Map<ReservationResponses>(model),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<ReservationResponses>()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false
            };

        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
