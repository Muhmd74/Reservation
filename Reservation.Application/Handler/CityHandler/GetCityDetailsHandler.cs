using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query.CityQuery;
using Reservation.Application.Repository.City;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Handler.CityHandler
{
    public class GetCityDetailsHandler : IRequestHandler<GetCityDetailsQuery, OutputResponse<AllCityResponse>>
    {
        private readonly ICity _city;

        public GetCityDetailsHandler(ICity city)
        {
            _city = city;
        }

        public async Task<OutputResponse<AllCityResponse>> Handle(GetCityDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _city.GetByCityId(request.Id);
            return result;
        }

    }
}
