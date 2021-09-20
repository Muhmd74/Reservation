using System;
using System.Collections.Generic;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Dtos;

namespace Reservation.Application.Query.FirmQuery
{
    public class ListFirmQuery : IRequest<OutputResponse<List<ListFirmResponse>>>
    {
        public ListFirmQuery(int pageSize)
        {
            PageSize = pageSize;
        }

        public int PageSize { get;  }
    }
}
