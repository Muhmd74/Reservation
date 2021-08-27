using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.UserCommand
{
    public class ChangeActivityCommand : IRequest<OutputResponse<bool>>
    {
        public Guid UserId { get; set; }

    }
}
