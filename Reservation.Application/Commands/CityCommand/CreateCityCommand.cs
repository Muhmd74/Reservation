using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Commands.CityCommand
{
    public class CreateCityCommand : IRequest<OutputResponse<CityResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
         public Guid CountryId { get; set; }
    }
}
