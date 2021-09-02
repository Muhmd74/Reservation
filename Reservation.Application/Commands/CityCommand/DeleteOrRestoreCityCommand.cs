using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Commands.CityCommand
{
    public class DeleteOrRestoreCityCommand : IRequest<OutputResponse<bool>>
    {
        public Guid CityId { get; set; }

    }
}
