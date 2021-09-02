using System.Collections.Generic;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Country.Dtos.Responses;

namespace Reservation.Application.Query.CountryQuery
{
    public class GetAllCountryQuery : IRequest<OutputResponse<List<CountryResponse>>>
    {
        public int PageSize { get; }
        public int PageNumber { get; }
        public GetAllCountryQuery(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

    }
}
