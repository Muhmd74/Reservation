using System;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.StaticCommand
{
    public class DeleteOrRestoreCommand : IRequest<OutputResponse<bool>>
    {
        public Guid Id { get; set; }


    }
}
