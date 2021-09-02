using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Commands.CityCommand;
using Reservation.Application.Commands.CountryCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.City.Dtos.Responses;
using Reservation.Application.Repository.Country.Dtos.Responses;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Repository.City
{
    public class CityService : ICity
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapperManager;

        public CityService(ApplicationDbContext context, IMapper mapperManager)
        {
            _context = context;
            _mapperManager = mapperManager;
        }

        public async Task<OutputResponse<CityResponse>> CreateCity(CreateCityCommand model)
        {
            try
            {

                var city = _mapperManager.Map<Core.Entities.City>(model);
                var result = await _context.Cities.AddAsync(city);
                await _context.SaveChangesAsync();
                return new OutputResponse<CityResponse>()
                {
                    Model = _mapperManager.Map<CityResponse>(result.Entity),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<CityResponse>()
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

        public async Task<OutputResponse<List<AllCityResponse>>> GetAllCity(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue)
        {
            var start = pageNumber * pageSize - pageSize;

            var model = await _context.Cities

                .Where(d => d.IsDeleted==false)
                .Skip(start).Take(pageSize)
                .ToListAsync();

            return new OutputResponse<List<AllCityResponse>>()
            {
                Model = _mapperManager.Map<List<AllCityResponse>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };
        }

        public async Task<OutputResponse<List<AllCityResponse>>> GetAllCityDeleted(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue)
        {
            var start = pageNumber * pageSize - pageSize;

            var model = await _context.Cities

                .Where(d => d.IsDeleted)
                .Skip(start).Take(pageSize)
                .ToListAsync();

            return new OutputResponse<List<AllCityResponse>>()
            {
                Model = _mapperManager.Map<List<AllCityResponse>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };
        }

        public async Task<OutputResponse<AllCityResponse>> GetByCityId(Guid id)
        {
            var model = await _context.Cities.FirstOrDefaultAsync(d => d.Id == id);
            if (model != null)
            {
                return new OutputResponse<AllCityResponse>()
                {
                    Model = _mapperManager.Map<AllCityResponse>(model),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<AllCityResponse>()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false
            };
        }

        public async Task<OutputResponse<CityResponse>> UpdateCity(UpdateCityCommand model)
        {
            var country = await _context.Cities.FirstOrDefaultAsync(d => d.Id == model.Id);

            if (country != null)
            {
                UpdateMapper(model, country);
                await _context.SaveChangesAsync();
                return new OutputResponse<CityResponse>()
                {
                    Model = _mapperManager.Map<CityResponse>(country),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<CityResponse>()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false
            };
        }
        public void UpdateMapper(UpdateCityCommand target, Core.Entities.City source)
        {

            source.Name = target.Name;
            source.Description = target.Description;
            source.CountryId = target.CountryId;

        }
        public async Task<OutputResponse<List<CountryNameResponse>>> GetAllCountryName()
        {
           

            var model = await _context.Countries
                .Where(d => d.IsDeleted==false)
                .ToListAsync();

            return new OutputResponse<List<CountryNameResponse>>()
            {
                Model = _mapperManager.Map<List<CountryNameResponse>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };
        }

        public async Task<OutputResponse<bool>> DeleteOrRestore(Guid id)
        {
            var result = await _context.Cities.FirstOrDefaultAsync(d => d.Id == id);
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
