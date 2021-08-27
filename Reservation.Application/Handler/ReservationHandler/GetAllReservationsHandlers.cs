using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query;
using Reservation.Application.Query.ReservationQuery;
using Reservation.Application.Repository.Reservation;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Handler.ReservationHandler
{
    public class GetAllReservationsHandlers : IRequestHandler<GetAllReservationsQuery, OutputResponse<List<ReservationResponses>>>
    {
        private readonly IReservation _reservation;
        public GetAllReservationsHandlers(IReservation reservation)
        {
            _reservation = reservation;

        }

        public async Task<OutputResponse<List<ReservationResponses>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _reservation.GetAllReservation(request.PageSize);
            return result;
        }
    }
}
