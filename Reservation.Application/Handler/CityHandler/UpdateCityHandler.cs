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
    public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, OutputResponse<CityResponse>>
    {
        private readonly ICity _city;

        public UpdateCityHandler(ICity city)
        {
            _city = city;
        }

        public async Task<OutputResponse<CityResponse>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var result = await _city.UpdateCity(request);
            return result;
        }
    }
}

