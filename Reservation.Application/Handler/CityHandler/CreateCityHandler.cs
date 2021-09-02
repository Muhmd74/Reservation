using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.CityCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.City;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Handler.CityHandler
{
    public class CreateCityHandler : IRequestHandler<CreateCityCommand,OutputResponse<CityResponse>>
    {
        private readonly ICity _city;

        public CreateCityHandler(ICity city)
        {
            _city = city;
        }

        public async Task<OutputResponse<CityResponse>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var result =await _city.CreateCity(request);
            return result;
        }
    }
}
