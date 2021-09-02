using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query.CountryQuery;
using Reservation.Application.Repository.Country;
using Reservation.Application.Repository.Country.Dtos.Responses;

namespace Reservation.Application.Handler.CountryHandler
{
    public class GetAllCountryHandler : IRequestHandler<GetAllCountryQuery,OutputResponse<List<CountryResponse>>>
    {
        private readonly ICountry _country;

        public GetAllCountryHandler(ICountry country)
        {
            _country = country;
        }
        public  async Task<OutputResponse<List<CountryResponse>>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            var result =await _country.GetAllCountry(request.PageSize,request.PageNumber);
            return result;
        }
    }
}
