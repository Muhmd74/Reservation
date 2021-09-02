using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.CityCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Query.CityQuery;
using Reservation.Application.Repository.City;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Handler.CityHandler
{

    public class GetAllCountryNameCityHandler : IRequestHandler<GetAllCountryNameQuery, OutputResponse<List<CountryNameResponse>>>
    {
        private readonly ICity _city;

        public GetAllCountryNameCityHandler(ICity city)
        {
            _city = city;
        }

        public async Task<OutputResponse<List<CountryNameResponse>>> Handle(GetAllCountryNameQuery request, CancellationToken cancellationToken)
        {
            var result =await _city.GetAllCountryName();
            return result;
        }

    }
}
