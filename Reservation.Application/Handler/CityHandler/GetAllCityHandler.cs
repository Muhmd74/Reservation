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
    public class GetAllCityHandler : IRequestHandler<GetAllCityQuery, OutputResponse<List<AllCityResponse>>>
    {
        private readonly ICity _city;

        public GetAllCityHandler(ICity city)
        {
            _city = city;
        }

        public async Task<OutputResponse<List<AllCityResponse>>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
        {
            var result = await _city.GetAllCity(request.PageSize,request.PageNumber);
            return result;
        }

    }
  
}
