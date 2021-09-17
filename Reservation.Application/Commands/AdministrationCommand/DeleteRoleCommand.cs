using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.AdministrationCommand
{
    public class DeleteRoleCommand : IRequest<OutputResponse<bool>>
    {
        public string Id { get; set; }
    }
}
