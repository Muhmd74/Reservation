using System;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.StaticCommand
{
    public class ChangeActivityCommand : IRequest<OutputResponse<bool>>
    {
        public Guid Id { get; set; }

    }
}
