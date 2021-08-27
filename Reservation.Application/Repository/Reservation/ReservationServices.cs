using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Commands;
using Reservation.Application.Commands.ReservationCommand;
using Reservation.Application.Common.Files;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation.Dtos.Request;
using Reservation.Application.Repository.Reservation.Dtos.Responses;
using Reservation.Core.Entities;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Repository.Reservation
{
    public class ReservationServices : IReservation, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapperManager;
        private readonly FileService _fileService;

        public ReservationServices(ApplicationDbContext context, IMapper mapperManager, FileService fileService)
        {
            _context = context;
            _mapperManager = mapperManager;
            _fileService = fileService;
        }

        public async Task<OutputResponse<ReservationResponses>> CreateReservation(CreateReservationCommand model)
        {
            try
            {
                if (model.Image != null)
                {
                    model.ImageUrl = _fileService.Upload(model.Image, DirectoryNames.Trip);
                }
                var trip = _mapperManager.Map<Trip>(model);
                var result = await _context.Trips.AddAsync(trip);
                await _context.SaveChangesAsync();
                return new OutputResponse<ReservationResponses>()
                {
                    Model = _mapperManager.Map<ReservationResponses>(result.Entity),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<ReservationResponses>()
                {
                    Model = null,
                    Message = e.Message,
                    Success = true
                };
            }

        }

        public async Task<OutputResponse<List<ReservationResponses>>> GetAllReservation(int pageSize = Int32.MaxValue)
        {

            var model = await _context.Trips
                .OrderByDescending(d => d.DateTime)
                .Take(pageSize)
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
            if (model != null)
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

        public async Task<OutputResponse<ReservationResponses>> UpdateReservation(UpdateReservationCommand model)
        {
            var currentReservation = await _context.Trips.SingleOrDefaultAsync(d => d.Id == model.Id);

            if (currentReservation != null)
            {
                UpdateMapper(model, currentReservation);
                await _context.SaveChangesAsync();
                return new OutputResponse<ReservationResponses>()
                {
                    Model = _mapperManager.Map<ReservationResponses>(currentReservation),
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

        public void UpdateMapper(UpdateReservationCommand target, Trip source)
        {
            if (target.Image != null)
            {
                source.ImageUrl = _fileService.Upload(target.Image, DirectoryNames.Trip);
            }
            source.CityName = target.CityName;
            source.Content = HttpUtility.HtmlEncode(target.Content);
            source.Title = target.Title;
            source.DateTime=DateTime.Now;
           

        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
