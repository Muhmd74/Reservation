using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.CountryCommand;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Country;

namespace Reservation.Application.Handler.CountryHandler
{
    public class DeleteOrRestoreCountryHandler : IRequestHandler<DeleteOrRestoreCountryCommand, OutputResponse<bool>>
    {
        private readonly ICountry _country;

        public DeleteOrRestoreCountryHandler(ICountry country)
        {
            _country = country;
        }
        public  async Task<OutputResponse<bool>> Handle(DeleteOrRestoreCountryCommand request, CancellationToken cancellationToken)
        {
            var result =await _country.DeleteOrRestore(request.CountryId);
            return result;
        }
    }
}
