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
    public class DeleteOrRestoreCityHandler : IRequestHandler<DeleteOrRestoreCityCommand,OutputResponse<bool>>
    {
        private readonly ICity _city;

        public DeleteOrRestoreCityHandler(ICity city)
        {
            _city = city;
        }

        public Task<OutputResponse<bool>> Handle(DeleteOrRestoreCityCommand request, CancellationToken cancellationToken)
        {
            var result = _city.DeleteOrRestore(request.CityId);
            return result;
        }
    }
}
