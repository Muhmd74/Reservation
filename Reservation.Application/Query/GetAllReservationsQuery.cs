using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Query
{
   public class GetAllReservationsQuery : IRequest<List<ReservationResponses>>
    {

    }
}
