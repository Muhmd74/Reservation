using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Http;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Commands.TripCommand
{
    public class UpdateTripCommand : IRequest<OutputResponse<TripResponses>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        [Range(3, 64)]
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CityId { get; set; }

        public Guid Id { get; set; }
    }
}
