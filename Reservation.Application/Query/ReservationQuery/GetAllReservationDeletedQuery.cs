using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Query.ReservationQuery
{
    public class GetAllReservationDeletedQuery : IRequest<OutputResponse<List<ReservationResponses>>>
    {
        public int PageSize { get; }

        public GetAllReservationDeletedQuery(int pageSize)
        {
            PageSize = pageSize;
        }


    }
}
