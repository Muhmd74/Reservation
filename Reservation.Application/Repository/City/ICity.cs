using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservation.Application.Commands.CityCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Repository.City
{
    public interface ICity
    {
        Task<OutputResponse<CityResponse>> CreateCity(CreateCityCommand model);
        Task<OutputResponse<List<AllCityResponse>>> GetAllCity(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue);
        Task<OutputResponse<List<AllCityResponse>>> GetAllCityDeleted(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue);

        Task<OutputResponse<AllCityResponse>> GetByCityId(Guid id);
        Task<OutputResponse<CityResponse>> UpdateCity(UpdateCityCommand model);
        Task<OutputResponse<List<CountryNameResponse>>> GetAllCountryName();

        Task<OutputResponse<bool>> DeleteOrRestore(Guid id);
    }
}
