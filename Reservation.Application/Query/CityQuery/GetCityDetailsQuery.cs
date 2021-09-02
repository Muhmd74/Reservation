using System;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Query.CityQuery
{
    public class GetCityDetailsQuery : IRequest<OutputResponse<AllCityResponse>>
    {
        public GetCityDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}
