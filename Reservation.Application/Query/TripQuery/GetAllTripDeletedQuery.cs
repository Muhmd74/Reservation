using System.Collections.Generic;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Query.TripQuery
{
    public class GetAllTripDeletedQuery : IRequest<OutputResponse<List<TripResponses>>>
    {
        public int PageSize { get; }

        public GetAllTripDeletedQuery(int pageSize)
        {
            PageSize = pageSize;
        }


    }
}
