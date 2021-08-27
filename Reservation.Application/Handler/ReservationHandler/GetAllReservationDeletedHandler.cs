using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query.ReservationQuery;
using Reservation.Application.Repository.Reservation;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Handler.ReservationHandler
{
    public class GetAllReservationDeletedHandler : IRequestHandler<GetAllReservationsQuery, OutputResponse<List<ReservationResponses>>>
    {
        private readonly IReservation _reservation;
        public GetAllReservationDeletedHandler(IReservation reservation)
        {
            _reservation = reservation;

        }

        public async Task<OutputResponse<List<ReservationResponses>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _reservation.GetAllReservationDeleted(request.PageSize);
            return result;
        }

    }
}
