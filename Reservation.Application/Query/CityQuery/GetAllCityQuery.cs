using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Query.CityQuery
{
    public class GetAllCityQuery : IRequest<OutputResponse<List<AllCityResponse>>>
    {
        public int PageSize { get; }
        public int PageNumber { get; }
        public GetAllCityQuery(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

    }
}
