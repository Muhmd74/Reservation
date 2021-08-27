using System;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Query
{
   public class GetReservationByIdQuery : IRequest<OutputResponse<ReservationResponses>>
    {
        public Guid Id  { get;  }

        public GetReservationByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
