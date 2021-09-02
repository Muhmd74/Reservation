using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Commands.CountryCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Country.Dtos.Responses;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Repository.Country
{
    public class CountryService : ICountry
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapperManager;

        public CountryService(ApplicationDbContext context, IMapper mapperManager)
        {
            _context = context;
            _mapperManager = mapperManager;
        }

        public async Task<OutputResponse<CountryResponse>> CreateCountry(CreateCountryCommand model)
        {
            try
            {

                var country = _mapperManager.Map<Core.Entities.Country>(model);
                var result = await _context.Countries.AddAsync(country);
                await _context.SaveChangesAsync();
                return new OutputResponse<CountryResponse>()
                {
                    Model = _mapperManager.Map<CountryResponse>(result.Entity),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<CountryResponse>()
                {
                    Model = null,
                    Message = e.Message,
                    Success = true,
                    Errors = new List<ErrorModel> {
                        new ErrorModel {
                            Message = e.Message,
                            Property = "Exception"
                        },
                        new ErrorModel {
                            Message = e.InnerException?.Message,
                            Property = "Inner Exception"
                        },
                        new ErrorModel {
                            Message = e.Source,
                            Property = "Source"
                        }
                    }
                };
            }
        }

        public async Task<OutputResponse<List<CountryResponse>>> GetAllCountry(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue)
        {
            var start = pageNumber * pageSize - pageSize;

            var model = await _context.Countries

                .Where(d => d.IsDeleted == false)
                .Skip(start).Take(pageSize)
                .ToListAsync();

            return new OutputResponse<List<CountryResponse>>()
            {
                Model = _mapperManager.Map<List<CountryResponse>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };
        }

        public async Task<OutputResponse<List<CountryResponse>>> GetAllCountryDeleted(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue)
        {
            var start = pageNumber * pageSize - pageSize;

            var model = await _context.Countries

                .Where(d => d.IsDeleted)
                .Skip(start).Take(pageSize)
                .ToListAsync();

            return new OutputResponse<List<CountryResponse>>()
            {
                Model = _mapperManager.Map<List<CountryResponse>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };
        }

        public async Task<OutputResponse<CountryResponse>> GetByCountryId(Guid id)
        {
            var model = await _context.Countries.FirstOrDefaultAsync(d => d.Id == id);
            if (model != null)
            {
                return new OutputResponse<CountryResponse>()
                {
                    Model = _mapperManager.Map<CountryResponse>(model),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<CountryResponse>()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false
            };

        }

        public async Task<OutputResponse<CountryResponse>> UpdateCountry(UpdateCountryCommand model)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(d => d.Id == model.Id);

            if (country != null)
            {
                UpdateMapper(model, country);
                await _context.SaveChangesAsync();
                return new OutputResponse<CountryResponse>()
                {
                    Model = _mapperManager.Map<CountryResponse>(country),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<CountryResponse>()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false
            };
        }
        public void UpdateMapper(UpdateCountryCommand target, Core.Entities.Country source)
        {

            source.Name = target.Name;
            source.Description = target.Description;
        }

        public async Task<OutputResponse<bool>> DeleteOrRestore(Guid id)
        {
            var result = await _context.Countries.FirstOrDefaultAsync(d => d.Id == id);
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
    }
}
