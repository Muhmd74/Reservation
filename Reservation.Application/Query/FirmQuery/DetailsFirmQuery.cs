using System;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Dtos;
using Reservation.Application.Handler.FirmHandler;

namespace Reservation.Application.Query.FirmQuery
{
    public class DetailsFirmQuery : IRequest<OutputResponse<FirmDetailsResponse>>
    {
        public DetailsFirmQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get;   }
    }
}
