using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query.CountryQuery;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Query.CityQuery
{
    public class GetAllCountryNameQuery :  IRequest<OutputResponse<List<CountryNameResponse>>>
    {
    }
}
