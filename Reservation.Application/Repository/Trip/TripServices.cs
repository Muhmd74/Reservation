using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Common.Files;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip.Dtos.Responses;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Repository.Trip
{
    public class TripServices : ITrip, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapperManager;
        private readonly FileService _fileService;

        public TripServices(ApplicationDbContext context, IMapper mapperManager, FileService fileService)
        {
            _context = context;
            _mapperManager = mapperManager;
            _fileService = fileService;
        }

        public async Task<OutputResponse<TripResponses>> CreateTrip(CreateTripCommand model)
        {
            try
            {
                if (model.Image != null)
                {
                    model.ImageUrl = _fileService.Upload(model.Image, DirectoryNames.Trip);
                }
                var trip = _mapperManager.Map<Core.Entities.Trip>(model);
                var result = await _context.Trips.AddAsync(trip);
                await _context.SaveChangesAsync();
                return new OutputResponse<TripResponses>()
                {
                    Model = _mapperManager.Map<TripResponses>(result.Entity),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<TripResponses>()
                {
                    Model = null,
                    Message = e.Message,
                    Success = true
                };
            }

        }

        public async Task<OutputResponse<List<TripResponses>>> GetAllTrip(int pageSize = Int32.MaxValue)
        {

            var model = await _context.Trips
                .OrderByDescending(d => d.DateTime)
                .Where(d => d.IsDeleted == false)
                .Take(pageSize)
                .ToListAsync();

            return new OutputResponse<List<TripResponses>>()
            {
                Model = _mapperManager.Map<List<TripResponses>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };


        }

        public async Task<OutputResponse<List<TripResponses>>> GetAllTripDeleted(int pageSize = Int32.MaxValue)
        {

            var model = await _context.Trips
                .OrderByDescending(d => d.DateTime)
                .Where(d => d.IsDeleted)
                .Take(pageSize)
                .ToListAsync();

            return new OutputResponse<List<TripResponses>>()
            {
                Model = _mapperManager.Map<List<TripResponses>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };


        }

        public async Task<OutputResponse<TripResponses>> GetByTripId(Guid id)
        {
            var model = await _context.Trips.FirstOrDefaultAsync(d => d.Id == id);
            if (model != null)
            {
                return new OutputResponse<TripResponses>()
                {
                    Model = _mapperManager.Map<TripResponses>(model),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<TripResponses>()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false
            };

        }

        public async Task<OutputResponse<TripResponses>> UpdateTrip(UpdateTripCommand model)
        {
            var currentTrip = await _context.Trips.FirstOrDefaultAsync(d => d.Id == model.Id);

            if (currentTrip != null)
            {
                UpdateMapper(model, currentTrip);
                await _context.SaveChangesAsync();
                return new OutputResponse<TripResponses>()
                {
                    Model = _mapperManager.Map<TripResponses>(currentTrip),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<TripResponses>()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false
            };

        }

        public async Task<OutputResponse<bool>> DeleteOrRestore(Guid id)
        {
            var result = await _context.Trips.FirstOrDefaultAsync(d => d.Id == id);
            if (result != null)
            {
                result.IsDeleted = !result.IsDeleted;
                await _context.SaveChangesAsync();
                return new OutputResponse<bool>()
                {
                    Model = result.IsDeleted,
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<bool>()
            {
                Model = false,
                Message = ResponseMessages.Failure,
                Success = false
            };
        }

        public void UpdateMapper(UpdateTripCommand target, Core.Entities.Trip source)
        {
            if (target.Image != null)
            {
                source.ImageUrl = _fileService.Upload(target.Image, DirectoryNames.Trip);
            }
            source.CityName = target.CityName;
            source.Content = HttpUtility.HtmlEncode(target.Content);
            source.Title = target.Title;
            source.DateTime = DateTime.Now;


        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
