using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Http;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Commands.ReservationCommand
{
    public class UpdateReservationCommand : IRequest<OutputResponse<ReservationResponses>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
         public Guid Id { get; set; }
    }
}
