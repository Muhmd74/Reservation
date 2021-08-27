using System.Collections.Generic;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Query.TripQuery
{
    public class GetAllTripQuery : IRequest<OutputResponse<List<TripResponses>>>
    {
        public int PageSize { get; }
        public int PageNumber { get;   }
        public GetAllTripQuery(int pageSize,int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }


    }
}
