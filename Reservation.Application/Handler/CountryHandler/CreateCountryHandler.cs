using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.CountryCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Country;
using Reservation.Application.Repository.Country.Dtos.Responses;

namespace Reservation.Application.Handler.CountryHandler
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, OutputResponse<CountryResponse>>
    {
        private readonly ICountry _country;

        public CreateCountryHandler(ICountry country)
        {
            _country = country;
        }

        public async Task< OutputResponse<CountryResponse>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var result= await _country.CreateCountry(request);
            return result;
        }
    }
}
