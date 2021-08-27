using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Repository.Reservation.Dtos.Request;

namespace Reservation.Application.Commands
{
  public  class CreateReservationCommand : IRequest<CreateReservationRequest>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
        public DateTime DateTime { get; set; }
    }
}
