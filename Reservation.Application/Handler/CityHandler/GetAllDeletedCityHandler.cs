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
    public class GetAllDeletedCityHandler : IRequestHandler<GetAllCityDeletedQuery, OutputResponse<List<AllCityResponse>>>
    {
        private readonly ICity _city;

        public GetAllDeletedCityHandler(ICity city)
        {
            _city = city;
        }

        public async Task<OutputResponse<List<AllCityResponse>>> Handle(GetAllCityDeletedQuery request, CancellationToken cancellationToken)
        {
            var result = await _city.GetAllCityDeleted(request.PageSize, request.PageNumber);
            return result;
        }

    }

}
