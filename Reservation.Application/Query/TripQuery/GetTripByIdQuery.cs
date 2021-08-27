using System;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Query.TripQuery
{
   public class GetTripByIdQuery : IRequest<OutputResponse<TripResponses>>
    {
        public Guid Id  { get;  }

        public GetTripByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
