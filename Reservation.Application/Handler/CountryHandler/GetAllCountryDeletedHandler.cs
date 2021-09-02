using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query.CountryQuery;
using Reservation.Application.Repository.Country;
using Reservation.Application.Repository.Country.Dtos.Responses;

namespace Reservation.Application.Handler.CountryHandler
{
    public class GetAllCountryDeletedHandler
    {
        public class GetAllCountryHandler : IRequestHandler<GetAllCountryDeletedQuery, OutputResponse<List<CountryResponse>>>
        {
            private readonly ICountry _country;

            public GetAllCountryHandler(ICountry country)
            {
                _country = country;
            }
            public async Task<OutputResponse<List<CountryResponse>>> Handle(GetAllCountryDeletedQuery request, CancellationToken cancellationToken)
            {
                var result = await _country.GetAllCountryDeleted(request.PageSize, request.PageNumber);
                return result;
            }
        }
    }
}
