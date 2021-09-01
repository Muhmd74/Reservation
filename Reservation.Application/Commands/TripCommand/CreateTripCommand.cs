using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Commands.TripCommand
{
    public class CreateTripCommand : IRequest<OutputResponse<TripResponses>>
    {
        
        [Required]
       
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
       
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid CityId { get; set; }

    }
}
