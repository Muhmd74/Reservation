using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query;
using Reservation.Application.Repository.Reservation;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Handler
{
    public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdQuery, OutputResponse<ReservationResponses>>
    {
        private readonly IReservation _reservation;

        public GetReservationByIdHandler(IReservation reservation)
        {
            _reservation = reservation;
        }

        public Task<OutputResponse<ReservationResponses>> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var model = _reservation.GetByReservationId(request.Id);
            return model;
        }
    }
}
