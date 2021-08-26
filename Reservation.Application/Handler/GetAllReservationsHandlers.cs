using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Reservation.Application.Query;
using Reservation.Application.Repository.Reservation;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Handler
{
    public class GetAllReservationsHandlers : IRequestHandler<GetAllReservationsQuery, List<ReservationResponses>>
    {
        private readonly IReservation _reservation;
      

        public GetAllReservationsHandlers(IReservation reservation )
        {
            _reservation = reservation;
          
        }

        public async Task<List<ReservationResponses>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _reservation.GetAllReservation();
            return result;
        }
    }
}
