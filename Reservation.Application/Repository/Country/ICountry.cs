using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservation.Application.Commands.CountryCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Country.Dtos.Responses;

namespace Reservation.Application.Repository.Country
{
    public interface ICountry
    {
        Task<OutputResponse<CountryResponse>> CreateCountry(CreateCountryCommand model);
        Task<OutputResponse<List<CountryResponse>>> GetAllCountry(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue);
        Task<OutputResponse<List<CountryResponse>>> GetAllCountryDeleted(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue);

        Task<OutputResponse<CountryResponse>> GetByCountryId(Guid id);
        Task<OutputResponse<CountryResponse>> UpdateCountry(UpdateCountryCommand model);

        Task<OutputResponse<bool>> DeleteOrRestore(Guid id);
    }
}
