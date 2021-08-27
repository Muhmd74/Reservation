using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation.Dtos.Request;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Commands
{
  public  class CreateReservationCommand : IRequest<OutputResponse<ReservationResponses>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
        public DateTime DateTime { get; set; } =DateTime.Now;
    }
}
