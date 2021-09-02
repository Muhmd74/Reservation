using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.CountryCommand
{
    public class DeleteOrRestoreCountryCommand : IRequest<OutputResponse<bool>>
    {
        public Guid CountryId { get; set; }

    }
}
