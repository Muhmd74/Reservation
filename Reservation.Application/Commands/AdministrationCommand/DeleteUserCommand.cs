using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.AdministrationCommand
{
    public class DeleteUserCommand : IRequest<OutputResponse<bool>>
    {
        public string Id { get; set; }
    }
}
