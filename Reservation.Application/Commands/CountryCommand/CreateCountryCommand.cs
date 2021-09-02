using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Country.Dtos.Responses;

namespace Reservation.Application.Commands.CountryCommand
{
    public class CreateCountryCommand : IRequest<OutputResponse<CountryResponse>>
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iso { get; set; }
    }
}
