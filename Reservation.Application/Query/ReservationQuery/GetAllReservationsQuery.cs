﻿using System.Collections.Generic;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Query.ReservationQuery
{
    public class GetAllReservationsQuery : IRequest<OutputResponse<List<ReservationResponses>>>
    {
        public int PageSize { get; }

        public GetAllReservationsQuery(int pageSize)
        {
            PageSize = pageSize;
        }


    }
}