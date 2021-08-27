using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Commands.TripCommand
{
  public  class CreateTripCommand : IRequest<OutputResponse<TripResponses>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
        public DateTime DateTime { get; set; } =DateTime.Now;
    }
}
